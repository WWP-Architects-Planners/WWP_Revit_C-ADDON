namespace WWPRevitToolBar.Generated
{
    internal enum ToolbarItemType
    {
        Tab,
        Panel,
        Stack,
        Pulldown,
        PushButton,
        UrlButton,
    }

    internal sealed class ToolbarItemDefinition
    {
        public string Id { get; set; }
        public ToolbarItemType ItemType { get; set; }
        public string Title { get; set; }
        public string Tooltip { get; set; }
        public string IconResourcePath { get; set; }
        public string CommandClass { get; set; }
        public ToolbarItemDefinition[] Children { get; set; }
    }

    internal static class ToolbarDefinition
    {
        public static readonly ToolbarItemDefinition[] Panels = new[]
        {
        new ToolbarItemDefinition
        {
            Id = @"_1_Setup_panel",
            ItemType = ToolbarItemType.Panel,
            Title = @"1. Setup",
            Tooltip = @"1. Setup",
            IconResourcePath = @"Resources/Smile.png",
            CommandClass = null,
            Children = new[]
            {
                new ToolbarItemDefinition
                {
                    Id = @"_1_Setup_panel_levelsetup_pulldown",
                    ItemType = ToolbarItemType.Pulldown,
                    Title = @"Levels
Setup",
                    Tooltip = @"Manage Levels",
                    IconResourcePath = @"Resources/GeneratedIcons/_1_Setup_panel_levelsetup_pulldown.png",
                    CommandClass = null,
                    Children = new[]
                    {
                        new ToolbarItemDefinition
                        {
                            Id = @"_1_Setup_panel_levelsetup_pulldown_CreateViewsFromlevel_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Views
Creator",
                            Tooltip = @"Create Views on selected Area Plans, Floor Plans, and RCPs from selected Levels",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.Commands.Setup.CreateViewsFromLevelCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_1_Setup_panel_levelsetup_pulldown_SetupLevels_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Levels
Setup",
                            Tooltip = @"Setup levels based on how many levels you want in your project.",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.Commands.Setup.LevelSetupCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        }
                    }
                },
                new ToolbarItemDefinition
                {
                    Id = @"_1_Setup_panel_Project_Upgrader_pushbutton",
                    ItemType = ToolbarItemType.PushButton,
                    Title = @"Project
Upgrader",
                    Tooltip = @"Upgrade all Revit files in a selected folder to the current Revit version.",
                    IconResourcePath = @"Resources/GeneratedIcons/_1_Setup_panel_Project_Upgrader_pushbutton.png",
                    CommandClass = @"WWPRevitToolBar.Commands.Setup.ProjectUpgraderCommand",
                    Children = System.Array.Empty<ToolbarItemDefinition>()
                },
                new ToolbarItemDefinition
                {
                    Id = @"_1_Setup_panel_Setup_stack",
                    ItemType = ToolbarItemType.Stack,
                    Title = @"Setup",
                    Tooltip = @"Setup",
                    IconResourcePath = @"Resources/GeneratedIcons/_1_Setup_panel_Setup_stack.png",
                    CommandClass = null,
                    Children = new[]
                    {
                        new ToolbarItemDefinition
                        {
                            Id = @"_1_Setup_panel_Setup_stack_Add_Line_Type_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Add Line Type",
                            Tooltip = @"Add Line Type",
                            IconResourcePath = @"Resources/GeneratedIcons/_1_Setup_panel_Setup_stack_Add_Line_Type_pushbutton.png",
                            CommandClass = @"WWPRevitToolBar.Commands.Setup.AddLineTypeCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_1_Setup_panel_Setup_stack_Add_Project_Parameter_pulldown",
                            ItemType = ToolbarItemType.Pulldown,
                            Title = @"Add Project
Parameter",
                            Tooltip = @"Import project parameters or create templates",
                            IconResourcePath = @"Resources/GeneratedIcons/_1_Setup_panel_Setup_stack_Add_Project_Parameter_pulldown.png",
                            CommandClass = null,
                            Children = new[]
                            {
                                new ToolbarItemDefinition
                                {
                                    Id = @"_1_Setup_panel_Setup_stack_Add_Project_Parameter_pulldown_Import_from_Excel_pushbutton",
                                    ItemType = ToolbarItemType.PushButton,
                                    Title = @"Import from Excel",
                                    Tooltip = @"Import project parameters from an Excel workbook based on shared parameters",
                                    IconResourcePath = @"Resources/Smile.png",
                                    CommandClass = @"WWPRevitToolBar.Commands.Setup.ImportProjectParametersCommand",
                                    Children = System.Array.Empty<ToolbarItemDefinition>()
                                },
                                new ToolbarItemDefinition
                                {
                                    Id = @"_1_Setup_panel_Setup_stack_Add_Project_Parameter_pulldown_Create_Template_pushbutton",
                                    ItemType = ToolbarItemType.PushButton,
                                    Title = @"Create Template",
                                    Tooltip = @"Create an Excel template with shared parameters listed in Variables sheet",
                                    IconResourcePath = @"Resources/Smile.png",
                                    CommandClass = @"WWPRevitToolBar.Commands.Setup.CreateProjectParameterTemplateCommand",
                                    Children = System.Array.Empty<ToolbarItemDefinition>()
                                }
                            }
                        }
                    }
                }
            }
        },
        new ToolbarItemDefinition
        {
            Id = @"_2_Context_panel",
            ItemType = ToolbarItemType.Panel,
            Title = @"2. Context",
            Tooltip = @"2. Context",
            IconResourcePath = @"Resources/Smile.png",
            CommandClass = null,
            Children = new[]
            {
                new ToolbarItemDefinition
                {
                    Id = @"_2_Context_panel_ContextBuilder_pulldown",
                    ItemType = ToolbarItemType.Pulldown,
                    Title = @"Context 
Builder",
                    Tooltip = @"Create context building based on OSM/CAD file.",
                    IconResourcePath = @"Resources/GeneratedIcons/_2_Context_panel_ContextBuilder_pulldown.png",
                    CommandClass = null,
                    Children = new[]
                    {
                        new ToolbarItemDefinition
                        {
                            Id = @"_2_Context_panel_ContextBuilder_pulldown_Buildingimporter_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Building Importer",
                            Tooltip = @"Create context building based on OSM file.",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._2_Context_panel_ContextBuilder_pulldown_Buildingimporter_pushbutton.BuildingimporterCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_2_Context_panel_ContextBuilder_pulldown_CADBuilder_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"CAD Builder",
                            Tooltip = @"Create random-height massing from selected CAD layers.",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._2_Context_panel_ContextBuilder_pulldown_CADBuilder_pushbutton.CADBuilderCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_2_Context_panel_ContextBuilder_pulldown_DirectShapeToMass_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"DirectShape
To Mass",
                            Tooltip = @"Convert imported direct-shape buildings into conceptual mass families.",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._2_Context_panel_ContextBuilder_pulldown_DirectShapeToMass_pushbutton.DirectShapeToMassCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_2_Context_panel_ContextBuilder_pulldown_UKContextBuilder_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"UK Context
Builder",
                            Tooltip = @"Automatically build UK context from web OSM data with EA terrain.",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._2_Context_panel_ContextBuilder_pulldown_UKContextBuilder_pushbutton.UKContextBuilderCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_2_Context_panel_ContextBuilder_pulldown_WebContextBuilder_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Web Context
Builder",
                            Tooltip = @"Automatically build context masses and floors from web OSM data.",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._2_Context_panel_ContextBuilder_pulldown_WebContextBuilder_pushbutton.WebContextBuilderCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        }
                    }
                },
                new ToolbarItemDefinition
                {
                    Id = @"_2_Context_panel_DetailLineCAD_pushbutton",
                    ItemType = ToolbarItemType.PushButton,
                    Title = @"CAD Line 
Tool",
                    Tooltip = @"Convert a layer of CAD lines to mapped revit Detail lines as a group for each selected layer",
                    IconResourcePath = @"Resources/GeneratedIcons/_2_Context_panel_DetailLineCAD_pushbutton.png",
                    CommandClass = @"WWPRevitToolBar.ToolMirror._2_Context_panel_DetailLineCAD_pushbutton.DetailLineCADCommand",
                    Children = System.Array.Empty<ToolbarItemDefinition>()
                },
                new ToolbarItemDefinition
                {
                    Id = @"_2_Context_panel_FixFloorHeights_pushbutton",
                    ItemType = ToolbarItemType.PushButton,
                    Title = @"Fix Floor
Heights",
                    Tooltip = @"Update selected floor slab-shape point elevations from a CSV by matching existing vertices on XY and changing only the point height.",
                    IconResourcePath = @"Resources/GeneratedIcons/_2_Context_panel_FixFloorHeights_pushbutton.png",
                    CommandClass = @"WWPRevitToolBar.ToolMirror._2_Context_panel_FixFloorHeights_pushbutton.FixFloorHeightsCommand",
                    Children = System.Array.Empty<ToolbarItemDefinition>()
                },
                new ToolbarItemDefinition
                {
                    Id = @"_2_Context_panel_MassIDTool_pushbutton",
                    ItemType = ToolbarItemType.PushButton,
                    Title = @"Sync
Mass Tool",
                    Tooltip = @"Sync data among area plans with the same block name to Mass and Mass Floor, along with the NET SITE AREA.",
                    IconResourcePath = @"Resources/GeneratedIcons/_2_Context_panel_MassIDTool_pushbutton.png",
                    CommandClass = @"WWPRevitToolBar.ToolMirror._2_Context_panel_MassIDTool_pushbutton.MassIDToolCommand",
                    Children = System.Array.Empty<ToolbarItemDefinition>()
                },
                new ToolbarItemDefinition
                {
                    Id = @"_2_Context_panel_RandomPlants_pushbutton",
                    ItemType = ToolbarItemType.PushButton,
                    Title = @"Random
Tree",
                    Tooltip = @"Randomly rotate the trees and set different sizes.",
                    IconResourcePath = @"Resources/GeneratedIcons/_2_Context_panel_RandomPlants_pushbutton.png",
                    CommandClass = @"WWPRevitToolBar.ToolMirror._2_Context_panel_RandomPlants_pushbutton.RandomPlantsCommand",
                    Children = System.Array.Empty<ToolbarItemDefinition>()
                },
                new ToolbarItemDefinition
                {
                    Id = @"_2_Context_panel_RenameMaterials_pushbutton",
                    ItemType = ToolbarItemType.PushButton,
                    Title = @"Bulk Rename 
Materials",
                    Tooltip = @"Find/replace text across all material names in the current model.",
                    IconResourcePath = @"Resources/GeneratedIcons/_2_Context_panel_RenameMaterials_pushbutton.png",
                    CommandClass = @"WWPRevitToolBar.ToolMirror._2_Context_panel_RenameMaterials_pushbutton.RenameMaterialsCommand",
                    Children = System.Array.Empty<ToolbarItemDefinition>()
                }
            }
        },
        new ToolbarItemDefinition
        {
            Id = @"_3_Manage_panel",
            ItemType = ToolbarItemType.Panel,
            Title = @"3. Manage",
            Tooltip = @"3. Manage",
            IconResourcePath = @"Resources/Smile.png",
            CommandClass = null,
            Children = new[]
            {
                new ToolbarItemDefinition
                {
                    Id = @"_3_Manage_panel_AreaCopier_pushbutton",
                    ItemType = ToolbarItemType.PushButton,
                    Title = @"Area Plan
Duplicator",
                    Tooltip = @"Purpose: Duplicate area plans from one area scheme into another, including boundaries, areas, tags, and instance parameters.
Use: Select a source scheme, a target scheme, and levels. The tool recreates boundaries and areas in the target scheme to match the source.",
                    IconResourcePath = @"Resources/GeneratedIcons/_3_Manage_panel_AreaCopier_pushbutton.png",
                    CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_AreaCopier_pushbutton.AreaCopierCommand",
                    Children = System.Array.Empty<ToolbarItemDefinition>()
                },
                new ToolbarItemDefinition
                {
                    Id = @"_3_Manage_panel_CopyColorScheme_pulldown",
                    ItemType = ToolbarItemType.Pulldown,
                    Title = @"Copy 
Color Scheme",
                    Tooltip = @"Copy, export, or import color schemes",
                    IconResourcePath = @"Resources/GeneratedIcons/_3_Manage_panel_CopyColorScheme_pulldown.png",
                    CommandClass = null,
                    Children = new[]
                    {
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_CopyColorScheme_pulldown_Copy_Within_Model_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Copy Within Model",
                            Tooltip = @"Copy a color scheme from one model scope to another",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_CopyColorScheme_pulldown_Copy_Within_Model_pushbutton.CopyWithinModelCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_CopyColorScheme_pulldown_Export_to_Excel_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Export to Excel",
                            Tooltip = @"Export a selected color scheme to Excel",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_CopyColorScheme_pulldown_Export_to_Excel_pushbutton.ExporttoExcelCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_CopyColorScheme_pulldown_Import_from_Excel_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Import from Excel",
                            Tooltip = @"Import a color scheme from Excel",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_CopyColorScheme_pulldown_Import_from_Excel_pushbutton.ImportfromExcelCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        }
                    }
                },
                new ToolbarItemDefinition
                {
                    Id = @"_3_Manage_panel_CopyFilter_pulldown",
                    ItemType = ToolbarItemType.Pulldown,
                    Title = @"Copy 
Filters",
                    Tooltip = @"Copy filter graphic overrides from one template to another",
                    IconResourcePath = @"Resources/GeneratedIcons/_3_Manage_panel_CopyFilter_pulldown.png",
                    CommandClass = null,
                    Children = new[]
                    {
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_CopyFilter_pulldown_CopyCurrentFiltertMultView_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Copy Current Filters to Multiple Templates",
                            Tooltip = @"Copy filter graphic overrides from current view to Multiple Templates",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_CopyFilter_pulldown_CopyCurrentFiltertMultView_pushbutton.CopyCurrentFiltertMultViewCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_CopyFilter_pulldown_CopyFiltertoCurrentView_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Copy Filters to Current View",
                            Tooltip = @"Copy filter graphic overrides from one template to Current View",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_CopyFilter_pulldown_CopyFiltertoCurrentView_pushbutton.CopyFiltertoCurrentViewCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_CopyFilter_pulldown_CopyFiltertoTemplate_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Copy Filters to Template",
                            Tooltip = @"Copy filter graphic overrides from one template to another",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_CopyFilter_pulldown_CopyFiltertoTemplate_pushbutton.CopyFiltertoTemplateCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        }
                    }
                },
                new ToolbarItemDefinition
                {
                    Id = @"_3_Manage_panel_CopyParameter_pulldown",
                    ItemType = ToolbarItemType.Pulldown,
                    Title = @"Copy
Parameter",
                    Tooltip = @"Copy parameter values from selected elements or by category.",
                    IconResourcePath = @"Resources/GeneratedIcons/_3_Manage_panel_CopyParameter_pulldown.png",
                    CommandClass = null,
                    Children = new[]
                    {
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_CopyParameter_pulldown_CopyParameterByCategory_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Copy Parameter By Category",
                            Tooltip = @"Copy and transform a parameter value across all elements in a selected category.",
                            IconResourcePath = @"Resources/GeneratedIcons/_3_Manage_panel_CopyParameter_pulldown_CopyParameterByCategory_pushbutton.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_CopyParameter_pulldown_CopyParameterByCategory_pushbutton.CopyParameterByCategoryCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_CopyParameter_pulldown_CopyParameterFromSelected_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Copy Parameter From Selected",
                            Tooltip = @"Copy and transform a parameter value across the currently selected elements.",
                            IconResourcePath = @"Resources/GeneratedIcons/_3_Manage_panel_CopyParameter_pulldown_CopyParameterFromSelected_pushbutton.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_CopyParameter_pulldown_CopyParameterFromSelected_pushbutton.CopyParameterFromSelectedCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        }
                    }
                },
                new ToolbarItemDefinition
                {
                    Id = @"_3_Manage_panel_DoorTool_pulldown",
                    ItemType = ToolbarItemType.Pulldown,
                    Title = @"Door 
Tool",
                    Tooltip = @"''Useful tool for Doors''",
                    IconResourcePath = @"Resources/GeneratedIcons/_3_Manage_panel_DoorTool_pulldown.png",
                    CommandClass = null,
                    Children = new[]
                    {
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_DoorTool_pulldown_DoorFireRating_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Publish Fire Rating to Doors",
                            Tooltip = @"''Publish Fire Rating from Hosted Wall to Selected Doors''",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_DoorTool_pulldown_DoorFireRating_pushbutton.DoorFireRatingCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_DoorTool_pulldown_DoorsInView_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Select Doors in View",
                            Tooltip = @"''Select all doors in current view''",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_DoorTool_pulldown_DoorsInView_pushbutton.DoorsInViewCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_DoorTool_pulldown_DoorTypeDuplicator_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Door Type Duplicator",
                            Tooltip = @"'''Choose the Door type you like, then hit set Value.",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_DoorTool_pulldown_DoorTypeDuplicator_pushbutton.DoorTypeDuplicatorCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_DoorTool_pulldown_RoomNumbertoDoorMark_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Get Door Number from Room",
                            Tooltip = @"'''Get door numbers on Mark from its hosted ToRoom Number.",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_DoorTool_pulldown_RoomNumbertoDoorMark_pushbutton.RoomNumbertoDoorMarkCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        }
                    }
                },
                new ToolbarItemDefinition
                {
                    Id = @"_3_Manage_panel_FindReplaceName_pushbutton",
                    ItemType = ToolbarItemType.PushButton,
                    Title = @"Replace
View Name",
                    Tooltip = @"Find and replace text from Element.name, such as view names, type names, etc.",
                    IconResourcePath = @"Resources/GeneratedIcons/_3_Manage_panel_FindReplaceName_pushbutton.png",
                    CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_FindReplaceName_pushbutton.FindReplaceNameCommand",
                    Children = System.Array.Empty<ToolbarItemDefinition>()
                },
                new ToolbarItemDefinition
                {
                    Id = @"_3_Manage_panel_FindReplaceTypeName_pushbutton",
                    ItemType = ToolbarItemType.PushButton,
                    Title = @"Replace
Type Name",
                    Tooltip = @"Find and replace text from Type Name.",
                    IconResourcePath = @"Resources/GeneratedIcons/_3_Manage_panel_FindReplaceTypeName_pushbutton.png",
                    CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_FindReplaceTypeName_pushbutton.FindReplaceTypeNameCommand",
                    Children = System.Array.Empty<ToolbarItemDefinition>()
                },
                new ToolbarItemDefinition
                {
                    Id = @"_3_Manage_panel_Firerating_pulldown",
                    ItemType = ToolbarItemType.Pulldown,
                    Title = @"Fire Rating 
Tool",
                    Tooltip = @"Create lines from fire rating of walls based on their center lines",
                    IconResourcePath = @"Resources/GeneratedIcons/_3_Manage_panel_Firerating_pulldown.png",
                    CommandClass = null,
                    Children = new[]
                    {
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_Firerating_pulldown_FireLineAll_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Create Non-Rated Line for ALL walls in Current View",
                            Tooltip = @"Create lines from fire rating for ALL walls regardless of wall settings in current view",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_Firerating_pulldown_FireLineAll_pushbutton.FireLineAllCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_Firerating_pulldown_FireRatingAll_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Create Fire Rating Lines for ALL walls in Current View",
                            Tooltip = @"Create lines from fire rating for ALL walls on current view based on their center lines; Parameter will be set on 'FRR Walls', and Parameter should be formated as Number+HR, such as 0HR,1.5HR,3/4HR,2HR,3HR,1HR",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_Firerating_pulldown_FireRatingAll_pushbutton.FireRatingAllCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_Firerating_pulldown_FireRatingClear_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Clear Fire Rating Lines",
                            Tooltip = @"Remove fire rating detail lines from the current view",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_Firerating_pulldown_FireRatingClear_pushbutton.FireRatingClearCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_Firerating_pulldown_FireRatingConvertDetailItem_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Convert Lines to Detail Items",
                            Tooltip = @"Clear lines from fire rating for ALL walls on current view based on their center lines",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_Firerating_pulldown_FireRatingConvertDetailItem_pushbutton.FireRatingConvertDetailItemCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_Firerating_pulldown_FireRatingFRRViews_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Create Fire Rating Lines for All walls in views with FRR indicator",
                            Tooltip = @"Clear lines from fire rating for ALL walls on current view based on their center lines",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_Firerating_pulldown_FireRatingFRRViews_pushbutton.FireRatingFRRViewsCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_Firerating_pulldown_FireRatingSelected_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Create Fire Rating Lines for Selected walls in Current View",
                            Tooltip = @"Create lines from fire rating for Selected walls on current view based on their center lines",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_Firerating_pulldown_FireRatingSelected_pushbutton.FireRatingSelectedCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        }
                    }
                },
                new ToolbarItemDefinition
                {
                    Id = @"_3_Manage_panel_Import_Key_Schedule_pulldown",
                    ItemType = ToolbarItemType.Pulldown,
                    Title = @"Import Key
Schedule",
                    Tooltip = @"Import or map Area and Room key schedules",
                    IconResourcePath = @"Resources/GeneratedIcons/_3_Manage_panel_Import_Key_Schedule_pulldown.png",
                    CommandClass = null,
                    Children = new[]
                    {
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_Import_Key_Schedule_pulldown_Import_from_Excel_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Import from
Excel",
                            Tooltip = @"Import an Excel workbook into an Area or Room key schedule",
                            IconResourcePath = @"Resources/GeneratedIcons/_3_Manage_panel_Import_Key_Schedule_pulldown_Import_from_Excel_pushbutton.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_Import_Key_Schedule_pulldown_Import_from_Excel_pushbutton.ImportfromExcelCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_Import_Key_Schedule_pulldown_Map_by_Name_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Map by
Name",
                            Tooltip = @"Match existing Rooms or Areas to key schedule entries by Name, preferring Residential program duplicates",
                            IconResourcePath = @"Resources/GeneratedIcons/_3_Manage_panel_Import_Key_Schedule_pulldown_Map_by_Name_pushbutton.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_Import_Key_Schedule_pulldown_Map_by_Name_pushbutton.MapbyNameCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        }
                    }
                },
                new ToolbarItemDefinition
                {
                    Id = @"_3_Manage_panel_ManualRevisions_pushbutton",
                    ItemType = ToolbarItemType.PushButton,
                    Title = @"Manual Rev
updater",
                    Tooltip = @"Toggle and fill manual revision block on active or selected sheet(s).",
                    IconResourcePath = @"Resources/GeneratedIcons/_3_Manage_panel_ManualRevisions_pushbutton.png",
                    CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_ManualRevisions_pushbutton.ManualRevisionsCommand",
                    Children = System.Array.Empty<ToolbarItemDefinition>()
                },
                new ToolbarItemDefinition
                {
                    Id = @"_3_Manage_panel_ParkingtoRoom_pushbutton",
                    ItemType = ToolbarItemType.PushButton,
                    Title = @"Parking Count 
in Room",
                    Tooltip = @"Publish Parking elements count to associated rooms in CURRENT VIEW",
                    IconResourcePath = @"Resources/GeneratedIcons/_3_Manage_panel_ParkingtoRoom_pushbutton.png",
                    CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_ParkingtoRoom_pushbutton.ParkingtoRoomCommand",
                    Children = System.Array.Empty<ToolbarItemDefinition>()
                },
                new ToolbarItemDefinition
                {
                    Id = @"_3_Manage_panel_Room2AreaBoundary_pushbutton",
                    ItemType = ToolbarItemType.PushButton,
                    Title = @"RoomâArea
Boundaries",
                    Tooltip = @"Convert Rooms on a selected level into an Area Plan: creates Area Boundary Lines from Room boundaries, places Areas at Room locations, and copies matching instance/shared parameters from Rooms to Areas (when the parameters exist on both categories).",
                    IconResourcePath = @"Resources/GeneratedIcons/_3_Manage_panel_Room2AreaBoundary_pushbutton.png",
                    CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_Room2AreaBoundary_pushbutton.Room2AreaBoundaryCommand",
                    Children = System.Array.Empty<ToolbarItemDefinition>()
                },
                new ToolbarItemDefinition
                {
                    Id = @"_3_Manage_panel_SheetScaleUpdater_pushbutton",
                    ItemType = ToolbarItemType.PushButton,
                    Title = @"Sheet Scale 
Updater",
                    Tooltip = @"Update titleblock Sheet Scale parameter from sheet views",
                    IconResourcePath = @"Resources/GeneratedIcons/_3_Manage_panel_SheetScaleUpdater_pushbutton.png",
                    CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_SheetScaleUpdater_pushbutton.SheetScaleUpdaterCommand",
                    Children = System.Array.Empty<ToolbarItemDefinition>()
                },
                new ToolbarItemDefinition
                {
                    Id = @"_3_Manage_panel_Suite_Plan_Tool_pulldown",
                    ItemType = ToolbarItemType.Pulldown,
                    Title = @"Marketing 
View Maker",
                    Tooltip = @"Create marketing views (* Only works on Revit 2023, Revit 2024 + )",
                    IconResourcePath = @"Resources/GeneratedIcons/_3_Manage_panel_Suite_Plan_Tool_pulldown.png",
                    CommandClass = null,
                    Children = new[]
                    {
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_Suite_Plan_Tool_pulldown_MakeKeyPlanView_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Make MULTIPLE KeyPlans from Selected Area",
                            Tooltip = @"Create Keyplans from selections with filled region on ONE view - separated based on their area number",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_Suite_Plan_Tool_pulldown_MakeKeyPlanView_pushbutton.MakeKeyPlanViewCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_Suite_Plan_Tool_pulldown_MakeViews_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Make Marketing Views with Key plans",
                            Tooltip = @"Select an single suite area and the associated door;
Run the tool and select corresponding templates;
Then, check the views and sheets under C1 schedule and shift the viewports to the right place on titleblock.",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_Suite_Plan_Tool_pulldown_MakeViews_pushbutton.MakeViewsCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        }
                    }
                },
                new ToolbarItemDefinition
                {
                    Id = @"_3_Manage_panel_TypeLayers_pulldown",
                    ItemType = ToolbarItemType.Pulldown,
                    Title = @"Type
Layers",
                    Tooltip = @"Export, import, or transfer wall, ceiling, floor, and roof types.",
                    IconResourcePath = @"Resources/GeneratedIcons/_3_Manage_panel_TypeLayers_pulldown.png",
                    CommandClass = null,
                    Children = new[]
                    {
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_TypeLayers_pulldown_ExportTypeLayers_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Export
Type Layers",
                            Tooltip = @"Export wall, ceiling, floor, or roof type layers to Ideate-style Excel sheets.",
                            IconResourcePath = @"Resources/GeneratedIcons/_3_Manage_panel_TypeLayers_pulldown_ExportTypeLayers_pushbutton.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_TypeLayers_pulldown_ExportTypeLayers_pushbutton.ExportTypeLayersCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_TypeLayers_pulldown_ImportTypeLayers_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Import
Type Layers",
                            Tooltip = @"Import type layer data from Excel and update wall, floor, and roof types.",
                            IconResourcePath = @"Resources/GeneratedIcons/_3_Manage_panel_TypeLayers_pulldown_ImportTypeLayers_pushbutton.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_TypeLayers_pulldown_ImportTypeLayers_pushbutton.ImportTypeLayersCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_3_Manage_panel_TypeLayers_pulldown_TransferTypes_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Transfer
Standards",
                            Tooltip = @"Copy selected host types and standards from another open Revit project.",
                            IconResourcePath = @"Resources/GeneratedIcons/_3_Manage_panel_TypeLayers_pulldown_TransferTypes_pushbutton.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._3_Manage_panel_TypeLayers_pulldown_TransferTypes_pushbutton.TransferTypesCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        }
                    }
                }
            }
        },
        new ToolbarItemDefinition
        {
            Id = @"_4_Sheets_panel",
            ItemType = ToolbarItemType.Panel,
            Title = @"4. Sheets",
            Tooltip = @"4. Sheets",
            IconResourcePath = @"Resources/Smile.png",
            CommandClass = null,
            Children = new[]
            {
                new ToolbarItemDefinition
                {
                    Id = @"_4_Sheets_panel_CombinedPrintSet_pushbutton",
                    ItemType = ToolbarItemType.PushButton,
                    Title = @"Combined
Print Set",
                    Tooltip = @"Build one ordered PDF drawing set from sheets across multiple Revit files.",
                    IconResourcePath = @"Resources/Smile.png",
                    CommandClass = @"WWPRevitToolBar.ToolMirror._4_Sheets_panel_CombinedPrintSet_pushbutton.CombinedPrintSetCommand",
                    Children = System.Array.Empty<ToolbarItemDefinition>()
                },
                new ToolbarItemDefinition
                {
                    Id = @"_4_Sheets_panel_DeleteViews_pulldown",
                    ItemType = ToolbarItemType.Pulldown,
                    Title = @"Purge
 Views/Sheets",
                    Tooltip = @"Cleanup the Documents for Views not on Sheet & Selected Sheets",
                    IconResourcePath = @"Resources/GeneratedIcons/_4_Sheets_panel_DeleteViews_pulldown.png",
                    CommandClass = null,
                    Children = new[]
                    {
                        new ToolbarItemDefinition
                        {
                            Id = @"_4_Sheets_panel_DeleteViews_pulldown_DeleteAllunsedViews_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Clean Selected Sheet sets & Views",
                            Tooltip = @"Cleanup The Documents For Views Not On Sheet & Selected Sheets",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._4_Sheets_panel_DeleteViews_pulldown_DeleteAllunsedViews_pushbutton.DeleteAllunsedViewsCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_4_Sheets_panel_DeleteViews_pulldown_DeleteViews_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Delete Unused Views",
                            Tooltip = @"cleanup all the views that are not on sheets",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._4_Sheets_panel_DeleteViews_pulldown_DeleteViews_pushbutton.DeleteViewsCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        }
                    }
                },
                new ToolbarItemDefinition
                {
                    Id = @"_4_Sheets_panel_Export2Ex_pushbutton",
                    ItemType = ToolbarItemType.PushButton,
                    Title = @"Schedules
to Excel/CSV",
                    Tooltip = @"Publish existing schedules to excel file sheets or csv files.",
                    IconResourcePath = @"Resources/GeneratedIcons/_4_Sheets_panel_Export2Ex_pushbutton.png",
                    CommandClass = @"WWPRevitToolBar.ToolMirror._4_Sheets_panel_Export2Ex_pushbutton.Export2ExCommand",
                    Children = System.Array.Empty<ToolbarItemDefinition>()
                },
                new ToolbarItemDefinition
                {
                    Id = @"_4_Sheets_panel_LayViewsOnSheet_pushbutton",
                    ItemType = ToolbarItemType.PushButton,
                    Title = @"Lay Views
on Sheet",
                    Tooltip = @"Create one new sheet from selected views with a draggable viewport layout preview.",
                    IconResourcePath = @"Resources/GeneratedIcons/_4_Sheets_panel_LayViewsOnSheet_pushbutton.png",
                    CommandClass = @"WWPRevitToolBar.ToolMirror._4_Sheets_panel_LayViewsOnSheet_pushbutton.LayViewsOnSheetCommand",
                    Children = System.Array.Empty<ToolbarItemDefinition>()
                },
                new ToolbarItemDefinition
                {
                    Id = @"_4_Sheets_panel_SheetDuplicator_pushbutton",
                    ItemType = ToolbarItemType.PushButton,
                    Title = @"Sheet
Duplicator",
                    Tooltip = @"Duplicate a source sheet with a preview of viewport locations and assign duplicate view names before creating the new sheet.",
                    IconResourcePath = @"Resources/GeneratedIcons/_4_Sheets_panel_SheetDuplicator_pushbutton.png",
                    CommandClass = @"WWPRevitToolBar.ToolMirror._4_Sheets_panel_SheetDuplicator_pushbutton.SheetDuplicatorCommand",
                    Children = System.Array.Empty<ToolbarItemDefinition>()
                },
                new ToolbarItemDefinition
                {
                    Id = @"_4_Sheets_panel_SheetManager_pulldown",
                    ItemType = ToolbarItemType.Pulldown,
                    Title = @"Sheets 
Manager",
                    Tooltip = @"Sheet duplicate or delete",
                    IconResourcePath = @"Resources/GeneratedIcons/_4_Sheets_panel_SheetManager_pulldown.png",
                    CommandClass = null,
                    Children = new[]
                    {
                        new ToolbarItemDefinition
                        {
                            Id = @"_4_Sheets_panel_SheetManager_pulldown_DeleteCurrentSheet_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Delete Current Selected Sheet and its views",
                            Tooltip = @"delete all selected Sheets, and all views on it.",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._4_Sheets_panel_SheetManager_pulldown_DeleteCurrentSheet_pushbutton.DeleteCurrentSheetCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_4_Sheets_panel_SheetManager_pulldown_DeleteSheetsfromList_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Delete Sheets and its views from list",
                            Tooltip = @"delete all selected Sheets, and all views on it.",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._4_Sheets_panel_SheetManager_pulldown_DeleteSheetsfromList_pushbutton.DeleteSheetsfromListCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_4_Sheets_panel_SheetManager_pulldown_DeleteViewsonSheet_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Delete Views from Current Sheet",
                            Tooltip = @"Delete views from current sheet and also from project browser.",
                            IconResourcePath = @"Resources/Smile.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._4_Sheets_panel_SheetManager_pulldown_DeleteViewsonSheet_pushbutton.DeleteViewsonSheetCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_4_Sheets_panel_SheetManager_pulldown_SheetReNumber_pushbutton",
                            ItemType = ToolbarItemType.PushButton,
                            Title = @"Sheets 
Renumber",
                            Tooltip = @"Renumber selected set of Sheets",
                            IconResourcePath = @"Resources/GeneratedIcons/_4_Sheets_panel_SheetManager_pulldown_SheetReNumber_pushbutton.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._4_Sheets_panel_SheetManager_pulldown_SheetReNumber_pushbutton.SheetReNumberCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        }
                    }
                },
                new ToolbarItemDefinition
                {
                    Id = @"_4_Sheets_panel_ViewsDuplicator_pushbutton",
                    ItemType = ToolbarItemType.PushButton,
                    Title = @"Views
Duplicator",
                    Tooltip = @"Duplicate selected views with new names. If you leave the text empty, the tool uses '-copy'.",
                    IconResourcePath = @"Resources/GeneratedIcons/_4_Sheets_panel_ViewsDuplicator_pushbutton.png",
                    CommandClass = @"WWPRevitToolBar.ToolMirror._4_Sheets_panel_ViewsDuplicator_pushbutton.ViewsDuplicatorCommand",
                    Children = System.Array.Empty<ToolbarItemDefinition>()
                }
            }
        },
        new ToolbarItemDefinition
        {
            Id = @"_5_Cleanup_panel",
            ItemType = ToolbarItemType.Panel,
            Title = @"5. Cleanup",
            Tooltip = @"5. Cleanup",
            IconResourcePath = @"Resources/Smile.png",
            CommandClass = null,
            Children = new[]
            {
                new ToolbarItemDefinition
                {
                    Id = @"_5_Cleanup_panel_About_us_urlbutton",
                    ItemType = ToolbarItemType.UrlButton,
                    Title = @"About WWPTools",
                    Tooltip = @"Installed version: 1.2.5",
                    IconResourcePath = @"Resources/GeneratedIcons/_5_Cleanup_panel_About_us_urlbutton.png",
                    CommandClass = @"WWPRevitToolBar.ToolMirror._5_Cleanup_panel_About_us_urlbutton.AboutusCommand",
                    Children = System.Array.Empty<ToolbarItemDefinition>()
                },
                new ToolbarItemDefinition
                {
                    Id = @"_5_Cleanup_panel_Resources_stack",
                    ItemType = ToolbarItemType.Stack,
                    Title = @"Resources",
                    Tooltip = @"Resources",
                    IconResourcePath = @"Resources/GeneratedIcons/_5_Cleanup_panel_Resources_stack.png",
                    CommandClass = null,
                    Children = new[]
                    {
                        new ToolbarItemDefinition
                        {
                            Id = @"_5_Cleanup_panel_Resources_stack_Autodesk_Construction_Cloud_urlbutton",
                            ItemType = ToolbarItemType.UrlButton,
                            Title = @"ACC",
                            Tooltip = @"ACC",
                            IconResourcePath = @"Resources/GeneratedIcons/_5_Cleanup_panel_Resources_stack_Autodesk_Construction_Cloud_urlbutton.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._5_Cleanup_panel_Resources_stack_Autodesk_Construction_Cloud_urlbutton.AutodeskConstructionCloudCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_5_Cleanup_panel_Resources_stack_Gitbook_pulldown",
                            ItemType = ToolbarItemType.Pulldown,
                            Title = @"Gitbook",
                            Tooltip = @"Gitbook",
                            IconResourcePath = @"Resources/GeneratedIcons/_5_Cleanup_panel_Resources_stack_Gitbook_pulldown.png",
                            CommandClass = null,
                            Children = new[]
                            {
                                new ToolbarItemDefinition
                                {
                                    Id = @"_5_Cleanup_panel_Resources_stack_Gitbook_pulldown_1_Office_Wide_urlbutton",
                                    ItemType = ToolbarItemType.UrlButton,
                                    Title = @"1-Office Wide",
                                    Tooltip = @"1-Office Wide",
                                    IconResourcePath = @"Resources/Smile.png",
                                    CommandClass = @"WWPRevitToolBar.ToolMirror._5_Cleanup_panel_Resources_stack_Gitbook_pulldown_1_Office_Wide_urlbutton._1OfficeWideCommand",
                                    Children = System.Array.Empty<ToolbarItemDefinition>()
                                },
                                new ToolbarItemDefinition
                                {
                                    Id = @"_5_Cleanup_panel_Resources_stack_Gitbook_pulldown_2_Revit_urlbutton",
                                    ItemType = ToolbarItemType.UrlButton,
                                    Title = @"2-Revit",
                                    Tooltip = @"2-Revit",
                                    IconResourcePath = @"Resources/Smile.png",
                                    CommandClass = @"WWPRevitToolBar.ToolMirror._5_Cleanup_panel_Resources_stack_Gitbook_pulldown_2_Revit_urlbutton._2RevitCommand",
                                    Children = System.Array.Empty<ToolbarItemDefinition>()
                                },
                                new ToolbarItemDefinition
                                {
                                    Id = @"_5_Cleanup_panel_Resources_stack_Gitbook_pulldown_3_Additional_Tools_urlbutton",
                                    ItemType = ToolbarItemType.UrlButton,
                                    Title = @"3-Additonal Tools",
                                    Tooltip = @"3-Additonal Tools",
                                    IconResourcePath = @"Resources/Smile.png",
                                    CommandClass = @"WWPRevitToolBar.ToolMirror._5_Cleanup_panel_Resources_stack_Gitbook_pulldown_3_Additional_Tools_urlbutton._3AdditionalToolsCommand",
                                    Children = System.Array.Empty<ToolbarItemDefinition>()
                                },
                                new ToolbarItemDefinition
                                {
                                    Id = @"_5_Cleanup_panel_Resources_stack_Gitbook_pulldown_4_AI_Based_Tools_urlbutton",
                                    ItemType = ToolbarItemType.UrlButton,
                                    Title = @"4-AI Based Tools",
                                    Tooltip = @"4-AI Based Tools",
                                    IconResourcePath = @"Resources/Smile.png",
                                    CommandClass = @"WWPRevitToolBar.ToolMirror._5_Cleanup_panel_Resources_stack_Gitbook_pulldown_4_AI_Based_Tools_urlbutton._4AIBasedToolsCommand",
                                    Children = System.Array.Empty<ToolbarItemDefinition>()
                                },
                                new ToolbarItemDefinition
                                {
                                    Id = @"_5_Cleanup_panel_Resources_stack_Gitbook_pulldown_5_Microsoft_365_Transition_urlbutton",
                                    ItemType = ToolbarItemType.UrlButton,
                                    Title = @"5-Microsoft 365 Transition",
                                    Tooltip = @"5-Microsoft 365 Transition",
                                    IconResourcePath = @"Resources/Smile.png",
                                    CommandClass = @"WWPRevitToolBar.ToolMirror._5_Cleanup_panel_Resources_stack_Gitbook_pulldown_5_Microsoft_365_Transition_urlbutton._5Microsoft365TransitionCommand",
                                    Children = System.Array.Empty<ToolbarItemDefinition>()
                                }
                            }
                        },
                        new ToolbarItemDefinition
                        {
                            Id = @"_5_Cleanup_panel_Resources_stack_Miro_urlbutton",
                            ItemType = ToolbarItemType.UrlButton,
                            Title = @"Miro Board",
                            Tooltip = @"Miro Board",
                            IconResourcePath = @"Resources/GeneratedIcons/_5_Cleanup_panel_Resources_stack_Miro_urlbutton.png",
                            CommandClass = @"WWPRevitToolBar.ToolMirror._5_Cleanup_panel_Resources_stack_Miro_urlbutton.MiroCommand",
                            Children = System.Array.Empty<ToolbarItemDefinition>()
                        }
                    }
                },
                new ToolbarItemDefinition
                {
                    Id = @"_5_Cleanup_panel_Revit_Local_File_Cleaner_pushbutton",
                    ItemType = ToolbarItemType.PushButton,
                    Title = @"Project 
Cleaner",
                    Tooltip = @"Delete all Temp files, Local files and Caches. 
Please close all your BIM360/ACC projects, and open an empty revit file before doing so.",
                    IconResourcePath = @"Resources/GeneratedIcons/_5_Cleanup_panel_Revit_Local_File_Cleaner_pushbutton.png",
                    CommandClass = @"WWPRevitToolBar.ToolMirror._5_Cleanup_panel_Revit_Local_File_Cleaner_pushbutton.RevitLocalFileCleanerCommand",
                    Children = System.Array.Empty<ToolbarItemDefinition>()
                },
                new ToolbarItemDefinition
                {
                    Id = @"_5_Cleanup_panel_RoundAngles_pushbutton",
                    ItemType = ToolbarItemType.PushButton,
                    Title = @"Round
Angles",
                    Tooltip = @"Modeless off-axis warning browser. Review, zoom, edit groups, and apply 2-decimal sketch-line fixes without closing the tool. Property lines are ignored.",
                    IconResourcePath = @"Resources/GeneratedIcons/_5_Cleanup_panel_RoundAngles_pushbutton.png",
                    CommandClass = @"WWPRevitToolBar.ToolMirror._5_Cleanup_panel_RoundAngles_pushbutton.RoundAnglesCommand",
                    Children = System.Array.Empty<ToolbarItemDefinition>()
                },
                new ToolbarItemDefinition
                {
                    Id = @"_5_Cleanup_panel_Wipe_Schema_pushbutton",
                    ItemType = ToolbarItemType.PushButton,
                    Title = @"Wipe 
Schema",
                    Tooltip = @"Wipe Extra Schema for Revit 2024",
                    IconResourcePath = @"Resources/GeneratedIcons/_5_Cleanup_panel_Wipe_Schema_pushbutton.png",
                    CommandClass = @"WWPRevitToolBar.ToolMirror._5_Cleanup_panel_Wipe_Schema_pushbutton.WipeSchemaCommand",
                    Children = System.Array.Empty<ToolbarItemDefinition>()
                }
            }
        }
        };
    }
}
