using System;
using System.Windows.Forms;

namespace WWPRevitToolBar.Ui
{
    internal sealed class ProjectUpgraderForm : Form
    {
        private readonly TextBox _folderPath;
        private readonly CheckBox _includeSubfolders;

        public ProjectUpgraderForm()
        {
            Text = "Project Upgrader";
            StartPosition = FormStartPosition.CenterScreen;
            Width = 560;
            Height = 180;
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            Label label = new Label
            {
                Text = "Select folder containing Revit files",
                Left = 12,
                Top = 16,
                Width = 250,
                Height = 24
            };

            _folderPath = new TextBox
            {
                Left = 12,
                Top = 44,
                Width = 430
            };

            Button browseButton = new Button
            {
                Text = "Browse...",
                Left = 448,
                Top = 42,
                Width = 84
            };
            browseButton.Click += BrowseButtonOnClick;

            _includeSubfolders = new CheckBox
            {
                Text = "Include subfolders",
                Left = 12,
                Top = 76,
                Width = 160,
                Checked = true
            };

            Button okButton = new Button
            {
                Text = "OK",
                Left = 376,
                Top = 104,
                Width = 75,
                DialogResult = DialogResult.OK
            };

            Button cancelButton = new Button
            {
                Text = "Cancel",
                Left = 457,
                Top = 104,
                Width = 75,
                DialogResult = DialogResult.Cancel
            };

            Controls.Add(label);
            Controls.Add(_folderPath);
            Controls.Add(browseButton);
            Controls.Add(_includeSubfolders);
            Controls.Add(okButton);
            Controls.Add(cancelButton);
            AcceptButton = okButton;
            CancelButton = cancelButton;
        }

        public string FolderPath
        {
            get { return _folderPath.Text; }
        }

        public bool IncludeSubfolders
        {
            get { return _includeSubfolders.Checked; }
        }

        private void BrowseButtonOnClick(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select folder containing Revit files";
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    _folderPath.Text = dialog.SelectedPath;
                }
            }
        }
    }
}
