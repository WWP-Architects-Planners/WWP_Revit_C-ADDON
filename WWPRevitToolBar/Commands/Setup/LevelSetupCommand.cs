using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using WWPRevitToolBar.Infrastructure;
using WWPRevitToolBar.Ui;

namespace WWPRevitToolBar.Commands.Setup
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public sealed class LevelSetupCommand : CommandBase
    {
        protected override Result ExecuteInternal(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            if (uiDoc == null)
            {
                DialogService.ShowInfo("Level Setup", "No active Revit document found.");
                return Result.Cancelled;
            }

            DialogResult<LevelSetupInput> dialog = DialogService.ShowLevelSetup();
            if (!dialog.Accepted)
            {
                return Result.Cancelled;
            }

            Document doc = uiDoc.Document;
            LevelSetupInput input = dialog.Value;
            int levelCount = ParseInt(input.LevelCount, 50, 1);
            double h12 = MmToInternal(ParseDouble(input.Height12, 4500.0));
            double h23 = MmToInternal(ParseDouble(input.Height23, 4500.0));
            double typical = MmToInternal(ParseDouble(input.TypicalHeight, 3000.0));
            int undergroundCount = ParseInt(input.UndergroundCount, 0, 0);
            double heightP1ToL1 = MmToInternal(ParseDouble(input.HeightP1ToL1, 3000.0));
            double typicalDepth = MmToInternal(ParseDouble(input.TypicalDepth, 3000.0));

            List<Level> levels = new FilteredElementCollector(doc)
                .OfClass(typeof(Level))
                .Cast<Level>()
                .ToList();

            if (levels.Count == 0)
            {
                DialogService.ShowInfo("Level Setup", "No levels found in the document.");
                return Result.Cancelled;
            }

            Dictionary<int, List<Level>> levelsByNumber = new Dictionary<int, List<Level>>();
            Dictionary<int, List<Level>> parkingByNumber = new Dictionary<int, List<Level>>();

            foreach (Level level in levels)
            {
                string name = level.Name ?? string.Empty;
                if (IsParkingLevel(name))
                {
                    int? parkingNumber = ParseParkingNumber(name);
                    if (parkingNumber.HasValue)
                    {
                        AddToLookup(parkingByNumber, parkingNumber.Value, level);
                    }

                    continue;
                }

                if (IsExcludedLevel(name))
                {
                    continue;
                }

                int? number = ParseLevelNumber(name);
                if (number.HasValue)
                {
                    AddToLookup(levelsByNumber, number.Value, level);
                }
            }

            if (levelsByNumber.Count == 0)
            {
                DialogService.ShowInfo("Level Setup", "No eligible levels found (excluding P levels and 1.5).");
                return Result.Cancelled;
            }

            List<Level> levelsToDelete = levelsByNumber.Where(x => x.Key > levelCount).SelectMany(x => x.Value).ToList();
            List<Level> parkingToDelete = parkingByNumber.Where(x => x.Key > undergroundCount).SelectMany(x => x.Value).ToList();

            if ((levelsToDelete.Count > 0 || parkingToDelete.Count > 0) &&
                !DialogService.Confirm("Level Setup", BuildDeleteMessage(levelCount, levelsToDelete, parkingToDelete)))
            {
                levelsToDelete.Clear();
                parkingToDelete.Clear();
            }

            HashSet<string> existingNames = new HashSet<string>(levels.Where(x => !string.IsNullOrWhiteSpace(x.Name)).Select(x => x.Name));
            double baseElevation = GetBaseElevation(levelsByNumber);
            List<string> created = new List<string>();
            List<string> updated = new List<string>();
            List<string> deleted = new List<string>();

            using (Transaction transaction = new Transaction(doc, "Setup Levels"))
            {
                transaction.Start();

                foreach (Level level in levelsToDelete.Concat(parkingToDelete))
                {
                    try
                    {
                        doc.Delete(level.Id);
                        deleted.Add(level.Name);
                    }
                    catch
                    {
                    }
                }

                if (!levelsByNumber.ContainsKey(1) || levelsByNumber[1].Count == 0)
                {
                    Level level1 = Level.Create(doc, baseElevation);
                    level1.Name = GetUniqueName(existingNames, LevelName(1));
                    created.Add(level1.Name);
                    AddToLookup(levelsByNumber, 1, level1);
                }

                for (int levelNumber = 2; levelNumber <= levelCount; levelNumber++)
                {
                    double elevation = baseElevation + h12 + h23 + Math.Max(0, levelNumber - 3) * typical;
                    if (levelNumber == 2)
                    {
                        elevation = baseElevation + h12;
                    }
                    else if (levelNumber == 3)
                    {
                        elevation = baseElevation + h12 + h23;
                    }

                    Level existing = GetPrimaryLevel(levelsByNumber, levelNumber);
                    if (existing == null)
                    {
                        Level createdLevel = Level.Create(doc, elevation);
                        createdLevel.Name = GetUniqueName(existingNames, LevelName(levelNumber));
                        created.Add(createdLevel.Name);
                        AddToLookup(levelsByNumber, levelNumber, createdLevel);
                    }
                    else
                    {
                        SetLevelElevation(existing, elevation);
                        string expectedName = LevelName(levelNumber);
                        if (!string.Equals(existing.Name, expectedName, StringComparison.OrdinalIgnoreCase))
                        {
                            existing.Name = GetUniqueName(existingNames, expectedName);
                        }

                        updated.Add(existing.Name);
                    }
                }

                for (int parkingNumber = 1; parkingNumber <= undergroundCount; parkingNumber++)
                {
                    double elevation = baseElevation - heightP1ToL1 - Math.Max(0, parkingNumber - 1) * typicalDepth;
                    Level existing = GetPrimaryLevel(parkingByNumber, parkingNumber);
                    if (existing == null)
                    {
                        Level parking = Level.Create(doc, elevation);
                        parking.Name = GetUniqueName(existingNames, ParkingLevelName(parkingNumber));
                        created.Add(parking.Name);
                        AddToLookup(parkingByNumber, parkingNumber, parking);
                    }
                    else
                    {
                        SetLevelElevation(existing, elevation);
                        string expectedName = ParkingLevelName(parkingNumber);
                        if (!string.Equals(existing.Name, expectedName, StringComparison.OrdinalIgnoreCase))
                        {
                            existing.Name = GetUniqueName(existingNames, expectedName);
                        }

                        updated.Add(existing.Name);
                    }
                }

                transaction.Commit();
            }

            DialogService.ShowInfo("Level Setup", BuildSummary(created, updated, deleted));
            return Result.Succeeded;
        }

        private static void AddToLookup(Dictionary<int, List<Level>> lookup, int key, Level level)
        {
            if (!lookup.ContainsKey(key))
            {
                lookup[key] = new List<Level>();
            }

            lookup[key].Add(level);
        }

        private static string BuildDeleteMessage(int levelCount, IList<Level> levelsToDelete, IList<Level> parkingToDelete)
        {
            List<string> lines = new List<string> { "Delete levels above " + levelCount + "?", string.Empty };
            foreach (string name in levelsToDelete.Concat(parkingToDelete).Select(x => x.Name).Take(20))
            {
                lines.Add(name);
            }

            return string.Join(Environment.NewLine, lines);
        }

        private static string BuildSummary(IList<string> created, IList<string> updated, IList<string> deleted)
        {
            return string.Join(Environment.NewLine, new[]
            {
                "Created: " + created.Count,
                "Updated: " + updated.Count,
                "Deleted: " + deleted.Count
            });
        }

        private static double GetBaseElevation(Dictionary<int, List<Level>> levelsByNumber)
        {
            Level level1 = GetPrimaryLevel(levelsByNumber, 1);
            return level1 != null ? level1.Elevation : 0.0;
        }

        private static Level GetPrimaryLevel(Dictionary<int, List<Level>> levelsByNumber, int number)
        {
            return levelsByNumber.ContainsKey(number) ? levelsByNumber[number].OrderBy(x => x.Elevation).FirstOrDefault() : null;
        }

        private static string GetUniqueName(HashSet<string> existingNames, string baseName)
        {
            if (existingNames.Add(baseName))
            {
                return baseName;
            }

            int index = 2;
            while (true)
            {
                string candidate = baseName + " (" + index + ")";
                if (existingNames.Add(candidate))
                {
                    return candidate;
                }

                index++;
            }
        }

        private static bool IsExcludedLevel(string name)
        {
            return string.IsNullOrWhiteSpace(name) || name.Contains("1.5") || name.IndexOf("P", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static bool IsParkingLevel(string name)
        {
            return Regex.IsMatch(name ?? string.Empty, @"\b[Pp]\d+\b");
        }

        private static string LevelName(int number)
        {
            return "FLOOR " + number.ToString("00");
        }

        private static string ParkingLevelName(int number)
        {
            return "LEVEL P" + number;
        }

        private static double MmToInternal(double millimeters)
        {
            return UnitUtils.ConvertToInternalUnits(millimeters, UnitTypeId.Millimeters);
        }

        private static int ParseInt(string text, int defaultValue, int minimum)
        {
            int value;
            if (!int.TryParse(text, out value))
            {
                double asDouble;
                value = double.TryParse(text, out asDouble) ? (int)Math.Round(asDouble) : defaultValue;
            }

            return Math.Max(minimum, value);
        }

        private static double ParseDouble(string text, double defaultValue)
        {
            double value;
            return double.TryParse(text, out value) ? value : defaultValue;
        }

        private static int? ParseLevelNumber(string name)
        {
            Match match = Regex.Match(name ?? string.Empty, @"\d+");
            if (!match.Success)
            {
                return null;
            }

            int value;
            return int.TryParse(match.Value, out value) ? value : (int?)null;
        }

        private static int? ParseParkingNumber(string name)
        {
            Match match = Regex.Match(name ?? string.Empty, @"\b[Pp](\d+)\b");
            if (!match.Success)
            {
                return null;
            }

            int value;
            return int.TryParse(match.Groups[1].Value, out value) ? value : (int?)null;
        }

        private static void SetLevelElevation(Level level, double elevation)
        {
            Parameter parameter = level.get_Parameter(BuiltInParameter.LEVEL_ELEV);
            if (parameter != null && !parameter.IsReadOnly)
            {
                parameter.Set(elevation);
            }
        }
    }
}
