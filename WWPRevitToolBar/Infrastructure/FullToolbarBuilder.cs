using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Linq;
using WWPRevitToolBar.Generated;

namespace WWPRevitToolBar.Infrastructure
{
    internal static class FullToolbarBuilder
    {
        public static void Build(UIControlledApplication application)
        {
            foreach (ToolbarItemDefinition panelDefinition in ToolbarDefinition.Panels)
            {
                RibbonPanel panel = RibbonBuilder.GetOrCreatePanel(application, RibbonNames.Tab, panelDefinition.Title);
                foreach (ToolbarItemDefinition child in panelDefinition.Children)
                {
                    AddPanelItem(panel, child);
                }
            }
        }

        private static void AddPanelItem(RibbonPanel panel, ToolbarItemDefinition definition)
        {
            switch (definition.ItemType)
            {
                case ToolbarItemType.PushButton:
                case ToolbarItemType.UrlButton:
                    RibbonBuilder.AddPushButton(panel, definition.Id, definition.Title, definition.CommandClass, definition.Tooltip, definition.IconResourcePath);
                    break;

                case ToolbarItemType.Pulldown:
                    PulldownButton pulldown = RibbonBuilder.AddPulldown(panel, definition.Id, definition.Title, definition.Tooltip, definition.IconResourcePath);
                    PopulatePulldown(pulldown, definition);
                    break;

                case ToolbarItemType.Stack:
                    AddStack(panel, definition);
                    break;
            }
        }

        private static void AddStack(RibbonPanel panel, ToolbarItemDefinition definition)
        {
            List<RibbonItemData> itemData = definition.Children.Select(CreateRibbonItemData).Where(x => x != null).ToList();
            if (itemData.Count < 2 || itemData.Count > 3)
            {
                foreach (ToolbarItemDefinition child in definition.Children)
                {
                    AddPanelItem(panel, child);
                }

                return;
            }

            IList<RibbonItem> items = itemData.Count == 2
                ? panel.AddStackedItems(itemData[0], itemData[1])
                : panel.AddStackedItems(itemData[0], itemData[1], itemData[2]);
            for (int index = 0; index < items.Count && index < definition.Children.Length; index++)
            {
                ToolbarItemDefinition child = definition.Children[index];
                RibbonItem item = items[index];
                if (item is PushButton pushButton)
                {
                    RibbonBuilder.ApplyPushButtonMetadata(pushButton, child.Tooltip, child.IconResourcePath);
                }
                else if (item is PulldownButton pulldownButton)
                {
                    RibbonBuilder.ApplyPulldownMetadata(pulldownButton, child.Tooltip, child.IconResourcePath);
                    PopulatePulldown(pulldownButton, child);
                }
            }
        }

        private static RibbonItemData CreateRibbonItemData(ToolbarItemDefinition definition)
        {
            switch (definition.ItemType)
            {
                case ToolbarItemType.PushButton:
                case ToolbarItemType.UrlButton:
                    return new PushButtonData(definition.Id, definition.Title, System.Reflection.Assembly.GetExecutingAssembly().Location, definition.CommandClass);

                case ToolbarItemType.Pulldown:
                    return new PulldownButtonData(definition.Id, definition.Title);

                default:
                    return null;
            }
        }

        private static void PopulatePulldown(PulldownButton pulldown, ToolbarItemDefinition definition)
        {
            if (pulldown == null)
            {
                return;
            }

            foreach (ToolbarItemDefinition child in definition.Children)
            {
                if (child.ItemType == ToolbarItemType.PushButton || child.ItemType == ToolbarItemType.UrlButton)
                {
                    RibbonBuilder.AddPushButton(pulldown, child.Id, child.Title, child.CommandClass, child.Tooltip, child.IconResourcePath);
                }
            }
        }
    }
}
