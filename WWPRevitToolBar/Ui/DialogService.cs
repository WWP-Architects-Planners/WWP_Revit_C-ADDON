using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WWPRevitToolBar.Infrastructure;

namespace WWPRevitToolBar.Ui
{
    internal static class DialogService
    {
        public static IList<T> SelectMany<T>(string title, string prompt, IEnumerable<SelectionItem<T>> items)
        {
            using (ListSelectionForm<T> form = new ListSelectionForm<T>(title, prompt, items, true))
            {
                return form.ShowDialog() == DialogResult.OK ? form.SelectedValues : new List<T>();
            }
        }

        public static T SelectOne<T>(string title, string prompt, IEnumerable<SelectionItem<T>> items)
        {
            using (ListSelectionForm<T> form = new ListSelectionForm<T>(title, prompt, items, false))
            {
                return form.ShowDialog() == DialogResult.OK ? form.SelectedValues.FirstOrDefault() : default(T);
            }
        }

        public static DialogResult<LevelSetupInput> ShowLevelSetup()
        {
            using (LevelSetupForm form = new LevelSetupForm())
            {
                bool accepted = form.ShowDialog() == DialogResult.OK;
                return new DialogResult<LevelSetupInput> { Accepted = accepted, Value = form.GetInput() };
            }
        }

        public static DialogResult<ProjectUpgraderOptions> ShowProjectUpgraderOptions()
        {
            using (ProjectUpgraderForm form = new ProjectUpgraderForm())
            {
                bool accepted = form.ShowDialog() == DialogResult.OK;
                return new DialogResult<ProjectUpgraderOptions>
                {
                    Accepted = accepted,
                    Value = new ProjectUpgraderOptions { Folder = form.FolderPath, IncludeSubfolders = form.IncludeSubfolders }
                };
            }
        }

        public static bool Confirm(string title, string message)
        {
            return Autodesk.Revit.UI.TaskDialog.Show(title, message, TaskDialogCommonButtons.Ok | TaskDialogCommonButtons.Cancel) == TaskDialogResult.Ok;
        }

        public static void ShowInfo(string title, string message)
        {
            Autodesk.Revit.UI.TaskDialog.Show(title, message);
        }
    }
}
