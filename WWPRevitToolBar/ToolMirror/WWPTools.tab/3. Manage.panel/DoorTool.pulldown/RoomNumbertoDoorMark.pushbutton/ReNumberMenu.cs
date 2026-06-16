using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WWPRevitToolBar.ToolMirror._3_Manage_panel_DoorTool_pulldown_RoomNumbertoDoorMark_pushbutton
{
    public partial class ReNumberMenu : Form
    {
        string placeholderPrefix = "D";
        string placeholderSep = "_";
        int placeholderStartInd = 0;
        int sigFigs = 1;

        static public string categorySelection = "Doors";
        public ReNumberMenu()
        {
            InitializeComponent();
            RoomNumbertoDoorMarkCommand.ex = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RoomNumbertoDoorMarkCommand.ex = true;
            placeholderPrefix = textBox2.Text;
            placeholderSep = SepText.Text;
            try
            {
                sigFigs = textBox1.Text.Length;
                placeholderStartInd = int.Parse(textBox1.Text);
            }
            catch { TaskDialog.Show("Error", "Error in start index format"); }
            RoomNumbertoDoorMarkCommand.prefix = placeholderPrefix;
            RoomNumbertoDoorMarkCommand.Sep = placeholderSep;


            RoomNumbertoDoorMarkCommand.sigFigs = sigFigs;
            RoomNumbertoDoorMarkCommand.startInd = placeholderStartInd;
            RoomNumbertoDoorMarkCommand.excludeErrors = errorsWrite.Checked;
            if (ParameterDropdown.Text != "Select")
            {
                RoomNumbertoDoorMarkCommand.FilterPar = ParameterDropdown.Text;
            }
            if (textBox3.Text.Length > 0)
            {
                RoomNumbertoDoorMarkCommand.FilterVal = textBox3.Text;
            }




            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        protected void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Category_ValueChanged(object sender, EventArgs e)
        {
            categorySelection = Category.SelectedItem as string;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Sep1.Text = SepText.Text;
            Sep2.Text = SepText.Text;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void errorsWrite_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}
