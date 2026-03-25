using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace WWPRevitToolBar.ToolMirror._5_Cleanup_panel_Resources_stack_Gitbook_pulldown_4_AI_Based_Tools_urlbutton
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal sealed class _4AIBasedToolsCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog.Show("Tool Not Migrated", "4-AI Based Tools has not migrated yet, please use WWPTools.");
            return Result.Succeeded;
        }
    }
}
