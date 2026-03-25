using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WWPRevitToolBar.Infrastructure;
using WWPRevitToolBar.Ui;

namespace WWPRevitToolBar.Commands.Setup
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public sealed class ProjectUpgraderCommand : CommandBase
    {
        protected override Result ExecuteInternal(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            DialogResult<ProjectUpgraderOptions> dialog = DialogService.ShowProjectUpgraderOptions();
            if (!dialog.Accepted)
            {
                return Result.Cancelled;
            }

            ProjectUpgraderOptions options = dialog.Value;
            if (options == null || string.IsNullOrWhiteSpace(options.Folder) || !Directory.Exists(options.Folder))
            {
                DialogService.ShowInfo("Project Upgrader", "Please select a valid folder.");
                return Result.Cancelled;
            }

            UIApplication uiApp = commandData.Application;
            Autodesk.Revit.ApplicationServices.Application app = uiApp.Application;
            List<string> files = CollectFiles(options.Folder, options.IncludeSubfolders);
            if (files.Count == 0)
            {
                DialogService.ShowInfo("Project Upgrader", "No Revit files found in the selected folder.");
                return Result.Cancelled;
            }

            string activePath = uiApp.ActiveUIDocument != null ? uiApp.ActiveUIDocument.Document.PathName : null;
            string versionSuffix = app.VersionNumber.Substring(app.VersionNumber.Length - 2);
            List<string> upgraded = new List<string>();
            List<string> skipped = new List<string>();
            List<string> failed = new List<string>();

            foreach (string file in files)
            {
                if (!string.IsNullOrWhiteSpace(activePath) &&
                    string.Equals(Path.GetFullPath(file), Path.GetFullPath(activePath), StringComparison.OrdinalIgnoreCase))
                {
                    skipped.Add(file);
                    continue;
                }

                string error;
                string outputPath = UpgradeFile(app, file, versionSuffix, out error);
                if (outputPath != null)
                {
                    upgraded.Add(outputPath);
                }
                else
                {
                    failed.Add(file + ": " + error);
                }
            }

            DialogService.ShowInfo("Project Upgrader", BuildSummary(upgraded, skipped, failed));
            return Result.Succeeded;
        }

        private static List<string> CollectFiles(string folder, bool includeSubfolders)
        {
            SearchOption searchOption = includeSubfolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            return Directory.EnumerateFiles(folder, "*.*", searchOption)
                .Where(x =>
                {
                    string ext = Path.GetExtension(x);
                    return string.Equals(ext, ".rvt", StringComparison.OrdinalIgnoreCase) ||
                           string.Equals(ext, ".rfa", StringComparison.OrdinalIgnoreCase);
                })
                .ToList();
        }

        private static string UpgradeFile(Autodesk.Revit.ApplicationServices.Application app, string filePath, string versionSuffix, out string error)
        {
            error = null;
            Document doc = null;
            try
            {
                doc = OpenDocument(app, filePath);
                string outputPath = BuildSavePath(filePath, versionSuffix);
                SaveAsOptions saveOptions = new SaveAsOptions { OverwriteExistingFile = false };
                if (doc.IsWorkshared)
                {
                    WorksharingSaveAsOptions worksharingOptions = new WorksharingSaveAsOptions { SaveAsCentral = true };
                    saveOptions.SetWorksharingOptions(worksharingOptions);
                }

                doc.SaveAs(outputPath, saveOptions);
                return outputPath;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }
            finally
            {
                if (doc != null)
                {
                    try
                    {
                        doc.Close(false);
                    }
                    catch
                    {
                    }
                }
            }
        }

        private static string BuildSavePath(string filePath, string versionSuffix)
        {
            string directory = Path.GetDirectoryName(filePath);
            string name = Path.GetFileNameWithoutExtension(filePath);
            string ext = Path.GetExtension(filePath);
            string candidate = Path.Combine(directory, name + "_R" + versionSuffix + ext);
            int index = 2;
            while (File.Exists(candidate))
            {
                candidate = Path.Combine(directory, name + "_R" + versionSuffix + "_" + index + ext);
                index++;
            }

            return candidate;
        }

        private static string BuildSummary(IList<string> upgraded, IList<string> skipped, IList<string> failed)
        {
            List<string> lines = new List<string>
            {
                "Upgraded: " + upgraded.Count,
                "Skipped: " + skipped.Count,
                "Failed: " + failed.Count
            };

            if (failed.Count > 0)
            {
                lines.Add(string.Empty);
                lines.Add("Failures:");
                foreach (string item in failed.Take(10))
                {
                    lines.Add("- " + item);
                }
            }

            return string.Join(Environment.NewLine, lines);
        }

        private static Document OpenDocument(Autodesk.Revit.ApplicationServices.Application app, string filePath)
        {
            ModelPath modelPath = ModelPathUtils.ConvertUserVisiblePathToModelPath(filePath);
            OpenOptions options = new OpenOptions();
            try
            {
                options.DetachFromCentralOption = DetachFromCentralOption.DetachAndPreserveWorksets;
                return app.OpenDocumentFile(modelPath, options);
            }
            catch
            {
                options.DetachFromCentralOption = DetachFromCentralOption.DoNotDetach;
                return app.OpenDocumentFile(modelPath, options);
            }
        }
    }
}
