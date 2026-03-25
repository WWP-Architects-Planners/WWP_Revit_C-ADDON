using System.Windows.Forms;

namespace WWPRevitToolBar.Ui
{
    internal sealed class LevelSetupForm : Form
    {
        private readonly TextBox _levelCount;
        private readonly TextBox _height12;
        private readonly TextBox _height23;
        private readonly TextBox _typicalHeight;
        private readonly TextBox _undergroundCount;
        private readonly TextBox _heightP1ToL1;
        private readonly TextBox _typicalDepth;

        public LevelSetupForm()
        {
            Text = "Level Setup";
            StartPosition = FormStartPosition.CenterScreen;
            Width = 560;
            Height = 410;
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            _levelCount = AddField("How many levels are needed?", "50", 12);
            _height12 = AddField("Level 1 to Level 2 height (mm):", "4500", 52);
            _height23 = AddField("Level 2 to Level 3 height (mm):", "4500", 92);
            _typicalHeight = AddField("Typical floor-to-floor height after Level 3 (mm):", "3000", 132);
            _undergroundCount = AddField("How many underground levels?", "3", 172);
            _heightP1ToL1 = AddField("Floor-to-floor height from P1 to Level 1 (mm):", "3000", 212);
            _typicalDepth = AddField("Typical depth below (P2-P3, P3-P4...) (mm):", "3000", 252);

            Button okButton = new Button
            {
                Text = "OK",
                Left = 376,
                Top = 308,
                Width = 75,
                DialogResult = DialogResult.OK
            };

            Button cancelButton = new Button
            {
                Text = "Cancel",
                Left = 457,
                Top = 308,
                Width = 75,
                DialogResult = DialogResult.Cancel
            };

            Controls.Add(okButton);
            Controls.Add(cancelButton);
            AcceptButton = okButton;
            CancelButton = cancelButton;
        }

        public LevelSetupInput GetInput()
        {
            return new LevelSetupInput
            {
                LevelCount = _levelCount.Text,
                Height12 = _height12.Text,
                Height23 = _height23.Text,
                TypicalHeight = _typicalHeight.Text,
                UndergroundCount = _undergroundCount.Text,
                HeightP1ToL1 = _heightP1ToL1.Text,
                TypicalDepth = _typicalDepth.Text
            };
        }

        private TextBox AddField(string labelText, string defaultValue, int top)
        {
            Label label = new Label
            {
                Text = labelText,
                Left = 12,
                Top = top + 4,
                Width = 360,
                Height = 24
            };

            TextBox textBox = new TextBox
            {
                Left = 376,
                Top = top,
                Width = 156,
                Text = defaultValue
            };

            Controls.Add(label);
            Controls.Add(textBox);
            return textBox;
        }
    }
}
