using Autodesk.Revit.UI;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace WWPRevitToolBar.Infrastructure
{
    internal static class RibbonBuilder
    {
        public static RibbonPanel GetOrCreatePanel(UIControlledApplication application, string tabName, string panelName)
        {
            try
            {
                application.CreateRibbonTab(tabName);
            }
            catch
            {
            }

            RibbonPanel panel = application.GetRibbonPanels(tabName).FirstOrDefault(x => x.Name == panelName);
            return panel ?? application.CreateRibbonPanel(tabName, panelName);
        }

        public static PushButton AddPushButton(RibbonPanel panel, string name, string text, string className, string tooltip, string imageResourcePath)
        {
            PushButtonData data = new PushButtonData(name, text, Assembly.GetExecutingAssembly().Location, className);
            PushButton button = panel.AddItem(data) as PushButton;
            ApplyPushButtonMetadata(button, tooltip, imageResourcePath);
            return button;
        }

        public static PushButton AddPushButton(PulldownButton pulldown, string name, string text, string className, string tooltip, string imageResourcePath)
        {
            PushButtonData data = new PushButtonData(name, text, Assembly.GetExecutingAssembly().Location, className);
            PushButton button = pulldown.AddPushButton(data);
            ApplyPushButtonMetadata(button, tooltip, imageResourcePath);
            return button;
        }

        public static PulldownButton AddPulldown(RibbonPanel panel, string name, string text, string tooltip, string imageResourcePath)
        {
            PulldownButtonData data = new PulldownButtonData(name, text);
            PulldownButton button = panel.AddItem(data) as PulldownButton;
            if (button != null)
            {
                ApplyPulldownMetadata(button, tooltip, imageResourcePath);
            }

            return button;
        }

        public static void ApplyPushButtonMetadata(PushButton button, string tooltip, string imageResourcePath)
        {
            if (button == null)
            {
                return;
            }

            button.ToolTip = tooltip;
            button.Image = LoadImage(imageResourcePath);
            button.LargeImage = LoadImage(imageResourcePath);
        }

        public static void ApplyPulldownMetadata(PulldownButton button, string tooltip, string imageResourcePath)
        {
            if (button == null)
            {
                return;
            }

            button.ToolTip = tooltip;
            button.Image = LoadImage(imageResourcePath);
            button.LargeImage = LoadImage(imageResourcePath);
        }

        public static BitmapImage LoadImage(string imageResourcePath)
        {
            try
            {
                return new BitmapImage(new Uri("pack://application:,,,/WWPRevitToolBar;component/" + imageResourcePath, UriKind.Absolute));
            }
            catch
            {
                return new BitmapImage(new Uri("pack://application:,,,/WWPRevitToolBar;component/Resources/Smile.png", UriKind.Absolute));
            }
        }
    }
}
