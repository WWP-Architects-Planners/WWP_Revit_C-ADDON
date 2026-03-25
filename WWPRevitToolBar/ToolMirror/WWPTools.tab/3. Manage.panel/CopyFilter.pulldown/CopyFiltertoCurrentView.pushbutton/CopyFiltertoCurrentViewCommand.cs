using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace WWPRevitToolBar.ToolMirror._3_Manage_panel_CopyFilter_pulldown_CopyFiltertoCurrentView_pushbutton
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal sealed class CopyFiltertoCurrentViewCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog.Show("Tool Not Migrated", "CopyFiltertoCurrentView has not migrated yet, please use WWPTools.");
            return Result.Succeeded;
        }
    }
}
