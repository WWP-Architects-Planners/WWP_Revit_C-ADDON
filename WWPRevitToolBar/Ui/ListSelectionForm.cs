using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WWPRevitToolBar.Ui
{
    internal sealed class ListSelectionForm<T> : Form
    {
        private readonly ListBox _listBox;

        public ListSelectionForm(string title, string prompt, IEnumerable<SelectionItem<T>> items, bool multiSelect)
        {
            Text = title;
            StartPosition = FormStartPosition.CenterScreen;
            Width = 540;
            Height = 560;
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            Label label = new Label
            {
                Text = prompt,
                Left = 12,
                Top = 12,
                Width = 500,
                Height = 32
            };

            _listBox = new ListBox
            {
                Left = 12,
                Top = 48,
                Width = 500,
                Height = 430,
                SelectionMode = multiSelect ? SelectionMode.MultiExtended : SelectionMode.One
            };
            _listBox.Items.AddRange(items.Cast<object>().ToArray());

            Button okButton = new Button
            {
                Text = "OK",
                Left = 356,
                Top = 490,
                Width = 75,
                DialogResult = DialogResult.OK
            };

            Button cancelButton = new Button
            {
                Text = "Cancel",
                Left = 437,
                Top = 490,
                Width = 75,
                DialogResult = DialogResult.Cancel
            };

            Controls.Add(label);
            Controls.Add(_listBox);
            Controls.Add(okButton);
            Controls.Add(cancelButton);
            AcceptButton = okButton;
            CancelButton = cancelButton;
        }

        public IList<T> SelectedValues
        {
            get
            {
                return _listBox.SelectedItems
                    .Cast<SelectionItem<T>>()
                    .Select(x => x.Value)
                    .ToList();
            }
        }
    }
}
