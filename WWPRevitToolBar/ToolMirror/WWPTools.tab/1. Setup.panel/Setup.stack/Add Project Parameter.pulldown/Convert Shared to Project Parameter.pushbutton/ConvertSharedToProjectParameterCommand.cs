using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace WWPRevitToolBar.ToolMirror._1_Setup_panel_Setup_stack_Add_Project_Parameter_pulldown_Convert_Shared_to_Project_Parameter_pushbutton
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal sealed class ConvertSharedToProjectParameterCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog.Show("Tool Not Migrated", "Convert Shared to Project Parameter has not migrated yet, please use WWPTools.");
            return Result.Succeeded;
        }
    }
}
