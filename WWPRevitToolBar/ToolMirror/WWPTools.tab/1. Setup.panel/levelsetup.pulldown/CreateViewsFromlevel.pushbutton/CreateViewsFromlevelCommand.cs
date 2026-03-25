using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace WWPRevitToolBar.ToolMirror._1_Setup_panel_levelsetup_pulldown_CreateViewsFromlevel_pushbutton
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal sealed class CreateViewsFromlevelCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog.Show("Tool Not Migrated", "CreateViewsFromlevel has not migrated yet, please use WWPTools.");
            return Result.Succeeded;
        }
    }
}
