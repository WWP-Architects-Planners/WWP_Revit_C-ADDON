using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using WWPRevitToolBar.Infrastructure;
using WWPRevitToolBar.Ui;

namespace WWPRevitToolBar.Commands.Setup
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public sealed class CreateProjectParameterTemplateCommand : CommandBase
    {
        protected override Result ExecuteInternal(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            DialogService.ShowInfo("Create Project Parameter Template", "This Setup tool still needs the Excel/template generation port. It is queued after the core Setup commands.");
            return Result.Succeeded;
        }
    }
}
