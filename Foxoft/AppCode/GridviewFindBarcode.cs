using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System.Reflection;

namespace Foxoft.AppCode
{
    internal class GridviewFindBarcode
    {

        // Call this once after form loads
        public void AddTextEditToFindPanel(GridControl grid)
        {
            Control findPanel = FindFindPanel(grid);

            if (findPanel == null)
            {
                // Try again later if panel is not ready
                grid.BeginInvoke(new System.Windows.Forms.MethodInvoker(() => AddTextEditToFindPanel(grid)));
                return;
            }

            // Avoid adding multiple
            if (findPanel.Controls.Find("CustomTextEditInFindPanel", true).Length > 0)
                return;

            // Create the TextEdit
            TextEdit customEdit = new TextEdit
            {
                Name = "CustomTextEditInFindPanel",
                Width = 150,
                Height = 20,
                Text = "Extra Filter",
                Anchor = AnchorStyles.Right | AnchorStyles.Top
            };

            // Position next to existing search TextBox (assumes first TextBox is the search box)
            var existingTextBox = findPanel.Controls.OfType<TextBox>().FirstOrDefault();
            if (existingTextBox != null)
            {
                customEdit.Left = existingTextBox.Right + 10;
                customEdit.Top = existingTextBox.Top;
            }
            else
            {
                customEdit.Left = findPanel.Width - customEdit.Width - 10;
                customEdit.Top = 5;
            }

            // Add and hook event
            findPanel.Controls.Add(customEdit);
            customEdit.BringToFront();
            customEdit.EditValueChanged += (s, e) =>
            {
                XtraMessageBox.Show("Custom filter: " + customEdit.Text);
            };
        }

        Control FindFindPanel(Control root)
        {
            foreach (Control ctrl in root.Controls)
            {
                if (ctrl.GetType().Name.Contains("FindPanel"))
                    return ctrl;

                var child = FindFindPanel(ctrl);
                if (child != null)
                    return child;
            }
            return null;
        }

    }
}
