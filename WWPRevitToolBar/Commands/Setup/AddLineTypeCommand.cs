using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using WWPRevitToolBar.Infrastructure;
using WWPRevitToolBar.Ui;

namespace WWPRevitToolBar.Commands.Setup
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public sealed class AddLineTypeCommand : CommandBase
    {
        protected override Result ExecuteInternal(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            DialogService.ShowInfo("Add Line Type", "This Setup tool still needs the Excel import port. It is queued after the core Setup commands.");
            return Result.Succeeded;
        }
    }
}
