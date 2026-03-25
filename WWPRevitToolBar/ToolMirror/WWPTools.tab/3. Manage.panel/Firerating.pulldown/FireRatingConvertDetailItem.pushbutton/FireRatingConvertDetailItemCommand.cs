using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace WWPRevitToolBar.ToolMirror._3_Manage_panel_Firerating_pulldown_FireRatingConvertDetailItem_pushbutton
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal sealed class FireRatingConvertDetailItemCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog.Show("Tool Not Migrated", "FireRatingConvertDetailItem has not migrated yet, please use WWPTools.");
            return Result.Succeeded;
        }
    }
}
