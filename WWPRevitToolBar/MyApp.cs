using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WWPRevitToolBar
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class MyApp : IExternalApplication
    {
        public static UIControlledApplication uIControlledApplication;

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            uIControlledApplication = application;
            RibbonPanel panel = RibbonPanel(application);



            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            if (panel.AddItem(new PushButtonData("Press Me!", "Press Me!", thisAssemblyPath, "WWPRevitToolBar.Command")) is PushButton DrawingList)
            {
                DrawingList.ToolTip = "PRESS ME!";

                BitmapImage pb1Image = new BitmapImage(new Uri("pack://application:,,,/WWPRevitToolBar;component/Resources/Smile.png"));
                DrawingList.LargeImage = pb1Image;
            }

            return Result.Succeeded;
        }

        public RibbonPanel RibbonPanel(UIControlledApplication a)
        {
            string tab = "WW+P";
            RibbonPanel ribbonPanel = null;


            try
            {
                a.CreateRibbonTab(tab);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }


            try
            {
                a.CreateRibbonPanel(tab, "WIP Tools");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }


            List<RibbonPanel> panels = a.GetRibbonPanels(tab);
            foreach (RibbonPanel panel in panels.Where(panel => panel.Name == "WIP Tools"))
            {
                ribbonPanel = panel;
            }



            return ribbonPanel;
        }
    }
}
