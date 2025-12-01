using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Properties;
using System;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormReportGridOptions : Form
    {
        private GridView gridView;

        public FormReportGridOptions(GridView gridView)
        {
            InitializeComponent();
            this.gridView = gridView;
            LoadCurrentSettings();
            AttachEventHandlers();
        }

        private void LoadCurrentSettings()
        {
            // Load current settings into the form controls
            chkReadOnly.Checked = gridView.OptionsBehavior.ReadOnly; // Read Only
            chkAllowRowSizing.Checked = gridView.OptionsCustomization.AllowRowSizing; // Allow Row Sizing
            cmbGroupFooterShowMode.SelectedIndex = (int)gridView.OptionsView.GroupFooterShowMode; // Group Footer Show Mode
            chkEditable.Checked = gridView.OptionsBehavior.Editable; // Editable
            chkShowFooter.Checked = gridView.OptionsView.ShowFooter; // Show Footer
        }

        private void AttachEventHandlers()
        {
            // Attach event handlers to apply changes immediately
            chkReadOnly.CheckedChanged += (s, e) =>
                gridView.OptionsBehavior.ReadOnly = chkReadOnly.Checked; // Read Only

            chkAllowRowSizing.CheckedChanged += (s, e) =>
                gridView.OptionsCustomization.AllowRowSizing = chkAllowRowSizing.Checked; // Allow Row Sizing

            cmbGroupFooterShowMode.SelectedIndexChanged += (s, e) =>
                gridView.OptionsView.GroupFooterShowMode =
                    (GroupFooterShowMode)cmbGroupFooterShowMode.SelectedIndex; // Group Footer Show Mode

            chkEditable.CheckedChanged += (s, e) =>
                gridView.OptionsBehavior.Editable = chkEditable.Checked; // Editable

            chkShowFooter.CheckedChanged += (s, e) =>
                gridView.OptionsView.ShowFooter = chkShowFooter.Checked; // Show Footer
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form
        }
    }
}
