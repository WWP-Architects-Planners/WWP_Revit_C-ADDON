using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace WWPRevitToolBar.ToolMirror._4_Sheets_panel_SheetManager_pulldown_DeleteViewsonSheet_pushbutton
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal sealed class DeleteViewsonSheetCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog.Show("Tool Not Migrated", "DeleteViewsonSheet has not migrated yet, please use WWPTools.");
            return Result.Succeeded;
        }
    }
}
