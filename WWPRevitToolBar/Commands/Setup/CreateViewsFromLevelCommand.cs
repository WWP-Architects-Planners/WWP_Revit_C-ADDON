using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using WWPRevitToolBar.Infrastructure;
using WWPRevitToolBar.Ui;

namespace WWPRevitToolBar.Commands.Setup
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public sealed class CreateViewsFromLevelCommand : CommandBase
    {
        protected override Result ExecuteInternal(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            if (uiDoc == null)
            {
                DialogService.ShowInfo("Create Views From Level", "No active Revit document found.");
                return Result.Cancelled;
            }

            Document doc = uiDoc.Document;
            List<Level> levels = new FilteredElementCollector(doc)
                .OfClass(typeof(Level))
                .Cast<Level>()
                .OrderBy(x => x.Elevation)
                .ToList();

            if (levels.Count == 0)
            {
                DialogService.ShowInfo("Create Views From Level", "No levels found in the document.");
                return Result.Cancelled;
            }

            IList<Level> selectedLevels = DialogService.SelectMany(
                "Choose Levels",
                "Select levels:",
                levels.Select(x => new SelectionItem<Level>(x.Name, x)));

            if (selectedLevels.Count == 0)
            {
                return Result.Cancelled;
            }

            string[] viewTypeOptions = { "RCP", "Floor Plan", "Area Plan" };
            IList<string> selectedTypes = DialogService.SelectMany(
                "View Types",
                "Select view types to create:",
                viewTypeOptions.Select(x => new SelectionItem<string>(x, x)));

            if (selectedTypes.Count == 0)
            {
                return Result.Cancelled;
            }

            bool createRcp = selectedTypes.Contains("RCP");
            bool createFloor = selectedTypes.Contains("Floor Plan");
            bool createArea = selectedTypes.Contains("Area Plan");

            List<View> templates = new FilteredElementCollector(doc)
                .OfClass(typeof(View))
                .Cast<View>()
                .Where(x => x.IsTemplate)
                .OrderBy(x => x.Name)
                .ToList();

            View floorTemplate = createFloor
                ? DialogService.SelectOne("Floor Plan Template", "Select Floor Plan template (Cancel to skip):", templates.Select(x => new SelectionItem<View>(x.Name, x)))
                : null;
            View rcpTemplate = createRcp
                ? DialogService.SelectOne("RCP Template", "Select RCP template (Cancel to skip):", templates.Select(x => new SelectionItem<View>(x.Name, x)))
                : null;
            View areaTemplate = createArea
                ? DialogService.SelectOne("Area Plan Template", "Select Area Plan template (Cancel to skip):", templates.Select(x => new SelectionItem<View>(x.Name, x)))
                : null;

            AreaScheme scheme = null;
            if (createArea)
            {
                List<AreaScheme> schemes = new FilteredElementCollector(doc)
                    .OfClass(typeof(AreaScheme))
                    .Cast<AreaScheme>()
                    .OrderBy(x => x.Name)
                    .ToList();

                scheme = DialogService.SelectOne("Choose an Area Scheme", "Select an area scheme:", schemes.Select(x => new SelectionItem<AreaScheme>(x.Name, x)));
                if (scheme == null)
                {
                    DialogService.ShowInfo("Create Views From Level", "No area scheme selected.");
                    return Result.Cancelled;
                }
            }

            ViewFamilyType floorType = createFloor ? GetViewFamilyType(doc, ViewFamily.FloorPlan) : null;
            ViewFamilyType rcpType = createRcp ? GetViewFamilyType(doc, ViewFamily.CeilingPlan) : null;

            List<string> created = new List<string>();
            List<string> failed = new List<string>();

            using (Transaction transaction = new Transaction(doc, "Create Views From Level"))
            {
                transaction.Start();

                foreach (Level level in selectedLevels)
                {
                    if (createFloor)
                    {
                        TryCreatePlan(doc, floorType, level, floorTemplate, created, failed, "Floor plan");
                    }

                    if (createRcp)
                    {
                        TryCreatePlan(doc, rcpType, level, rcpTemplate, created, failed, "RCP");
                    }

                    if (createArea && scheme != null)
                    {
                        try
                        {
                            ViewPlan areaView = ViewPlan.CreateAreaPlan(doc, scheme.Id, level.Id);
                            if (areaTemplate != null)
                            {
                                areaView.ViewTemplateId = areaTemplate.Id;
                            }

                            Element areaViewType = doc.GetElement(areaView.GetTypeId());
                            string typeName = areaViewType != null ? areaViewType.Name : string.Empty;
                            SetParameter(areaView, "View Category", typeName);
                            SetParameter(areaView, "View Subcategory", "05 Area");
                            created.Add(areaView.Name);
                        }
                        catch (Exception ex)
                        {
                            failed.Add(level.Name + ": Area plan: " + ex.Message);
                        }
                    }
                }

                transaction.Commit();
            }

            DialogService.ShowInfo("Create Views From Level", BuildSummary(created, failed));
            return Result.Succeeded;
        }

        private static ViewFamilyType GetViewFamilyType(Document doc, ViewFamily family)
        {
            return new FilteredElementCollector(doc)
                .OfClass(typeof(ViewFamilyType))
                .Cast<ViewFamilyType>()
                .FirstOrDefault(x => x.ViewFamily == family);
        }

        private static void TryCreatePlan(Document doc, ViewFamilyType type, Level level, View template, ICollection<string> created, ICollection<string> failed, string label)
        {
            if (type == null)
            {
                failed.Add(level.Name + ": " + label + " type missing");
                return;
            }

            try
            {
                ViewPlan view = ViewPlan.Create(doc, type.Id, level.Id);
                if (template != null)
                {
                    view.ViewTemplateId = template.Id;
                }

                created.Add(view.Name);
            }
            catch (Exception ex)
            {
                failed.Add(level.Name + ": " + label + ": " + ex.Message);
            }
        }

        private static void SetParameter(View view, string parameterName, string value)
        {
            Parameter parameter = view.LookupParameter(parameterName);
            if (parameter != null && !parameter.IsReadOnly)
            {
                parameter.Set(value ?? string.Empty);
            }
        }

        private static string BuildSummary(IList<string> created, IList<string> failed)
        {
            List<string> lines = new List<string>
            {
                "Created: " + created.Count,
                "Failed: " + failed.Count
            };

            if (created.Count > 0)
            {
                lines.Add(string.Empty);
                lines.Add("Created views:");
                foreach (string item in created.Take(20))
                {
                    lines.Add("- " + item);
                }
            }

            if (failed.Count > 0)
            {
                lines.Add(string.Empty);
                lines.Add("Failures:");
                foreach (string item in failed.Take(20))
                {
                    lines.Add("- " + item);
                }
            }

            return string.Join(Environment.NewLine, lines);
        }
    }
}
