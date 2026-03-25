using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace WWPRevitToolBar.ToolMirror._1_Setup_panel_Setup_stack_Add_Project_Parameter_pulldown_Import_from_Excel_pushbutton
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal sealed class ImportfromExcelCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog.Show("Tool Not Migrated", "Import from Excel has not migrated yet, please use WWPTools.");
            return Result.Succeeded;
        }
    }
}
