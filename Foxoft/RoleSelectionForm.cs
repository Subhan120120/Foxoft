using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Foxoft
{
    public partial class RoleSelectionForm : XtraForm
    {
        public string SelectedRoleCode { get; private set; }

        public RoleSelectionForm()
        {
            InitializeComponent();
            LoadRoles();
        }

        private void LoadRoles()
        {
            // Load roles from the database or a predefined list
            listBoxControl1.Items.AddRange(new string[] { "Admin", "Manager", "User" });
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectedRoleCode = listBoxControl1.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}