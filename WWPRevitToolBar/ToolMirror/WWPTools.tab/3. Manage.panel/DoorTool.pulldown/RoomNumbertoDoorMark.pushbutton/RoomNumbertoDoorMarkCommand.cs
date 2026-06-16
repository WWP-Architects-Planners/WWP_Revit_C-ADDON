using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WWPRevitToolBar.ToolMirror._3_Manage_panel_DoorTool_pulldown_RoomNumbertoDoorMark_pushbutton
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class RoomNumbertoDoorMarkCommand : IExternalCommand
    {

        public static string prefix = "D";
        public static string Sep = "_";
        public static int startInd = 0;
        public static int sigFigs = 1;
        public static string FilterPar = null;
        public static string FilterVal = null;
        public static bool excludeErrors = true;
        public static bool ex = false;
        public Result Execute(

          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            System.Windows.Forms.Form form = new ReNumberMenu();

            form.ShowDialog();
            if (ex)
            {
                //load input window



                //get current project document
                UIApplication uiapp = commandData.Application;
                UIDocument uidoc = uiapp.ActiveUIDocument;
                Document doc = uidoc.Document;




                List<string> roomNumbers = new List<string>();
                List<string> lowPrioritySpaces = new List<string> { "CIRC", "CIRCULATION", "LOBBY", "CORRIDOR", "CAR PARK" , "PARKING"};
                //load doors and windows
                List<FamilyInstance> allDoors = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Doors).OfType<FamilyInstance>().ToList();
                List<FamilyInstance> allWindows = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Windows).OfType<FamilyInstance>().ToList();
                List<FamilyInstance> allElements = new List<FamilyInstance>();

                if (ReNumberMenu.categorySelection == "Doors")
                {
                    allElements = allDoors;
                }
                else if (ReNumberMenu.categorySelection == "Windows")
                {
                    allElements = allWindows;
                }
                else
                {
                    TaskDialog.Show("Error", "Invalid Category Selection");
                }

                if (FilterVal != null && FilterPar != null)
                {
                    List<FamilyInstance> filtered = new List<FamilyInstance>();

                    foreach (FamilyInstance elm in allElements)
                    {
                        string FilterValue;
                        if (FilterPar == "Family Name")
                        {
                            FilterValue = elm.Symbol.FamilyName.ToString();

                        }
                        else if (FilterPar == "Type")
                        {
                            FilterValue = elm.Name.ToString();
                        }
                        else
                        {
                            FilterValue = elm.LookupParameter(FilterPar).AsValueString();
                        }
                        if (FilterValue.Contains(FilterVal))
                        {

                            filtered.Add(elm);

                        }
                    }
                    allElements = filtered;
                }

                using (Transaction t = new Transaction(doc, "Change Door/Window Numbers"))
                {

                    t.Start();
                    foreach (FamilyInstance door in allElements)
                    {

                        string roomNumb = "";


                        if (door.FromRoom != null && !(lowPrioritySpaces.Any(s => door.FromRoom.Name.ToUpper().Contains(s))) && !(lowPrioritySpaces.Any(s => RoomDep(door, s))))
                        {
                            roomNumb = door.FromRoom.Number;
                        }
                        else
                        {
                            if (door.ToRoom != null)
                            {
                                roomNumb = door.ToRoom.Number;
                            }
                            else
                            {
                                if (door.FromRoom != null)
                                {
                                    roomNumb = door.FromRoom.Number;
                                }
                                else
                                {
                                    roomNumb = "error";
                                }
                            }

                        }

                        string doorNumber = prefix + Sep + roomNumb + Sep;

                        if (!roomNumbers.Contains(roomNumb))
                        {

                            doorNumber = doorNumber + startInd.ToString($"D{sigFigs}");
                            roomNumbers.Add(roomNumb);
                        }
                        else
                        {
                            int count = roomNumbers.Where(s => s != null && s.Equals(roomNumb)).Count();
                            doorNumber = doorNumber + (count + startInd).ToString($"D{sigFigs}");

                            roomNumbers.Add(roomNumb);
                        }


                        if (!doorNumber.Contains("error") || excludeErrors)
                        {
                            try
                            {
                                door.get_Parameter(BuiltInParameter.DOOR_NUMBER).Set(doorNumber);

                            }
                            catch
                            {
                                t.RollBack();
                            }
                        }
                    }

                    t.Commit();

                }

                return Result.Succeeded;
            }
            else
            {
                return Result.Failed;
            }
        }




        private bool RoomDep(FamilyInstance door, string s)
        {
            try { return door.FromRoom.get_Parameter(BuiltInParameter.ROOM_DEPARTMENT).AsValueString().ToUpper().Contains(s); }
            catch { return false; }
        }
    }
}
