using Autodesk.Revit.UI;
using WWPRevitToolBar.Infrastructure;

namespace WWPRevitToolBar
{
    public class MyApp : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            FullToolbarBuilder.Build(application);
            return Result.Succeeded;
        }
    }
}
