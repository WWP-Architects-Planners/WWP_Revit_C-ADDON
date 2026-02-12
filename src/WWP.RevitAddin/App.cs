using System.Reflection;
using Autodesk.Revit.UI;

namespace WWP.RevitAddin;

public class App : IExternalApplication
{
    public Result OnStartup(UIControlledApplication application)
    {
        const string tabName = "WWP";

        try
        {
            application.CreateRibbonTab(tabName);
        }
        catch
        {
            // Ribbon tab already exists.
        }

        var panel = application.CreateRibbonPanel(tabName, "General");
        var buttonData = new PushButtonData(
            "WWP_Hello",
            "Hello",
            Assembly.GetExecutingAssembly().Location,
            "WWP.RevitAddin.Command");

        panel.AddItem(buttonData);

        return Result.Succeeded;
    }

    public Result OnShutdown(UIControlledApplication application)
    {
        return Result.Succeeded;
    }
}
