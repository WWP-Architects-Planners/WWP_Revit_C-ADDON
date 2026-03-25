using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace WWPRevitToolBar.ToolMirror._4_Sheets_panel_DeleteViews_pulldown_DeleteAllunsedViews_pushbutton
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal sealed class DeleteAllunsedViewsCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog.Show("Tool Not Migrated", "DeleteAllunsedViews has not migrated yet, please use WWPTools.");
            return Result.Succeeded;
        }
    }
}
