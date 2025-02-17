using DevExpress.XtraEditors;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class RoleClaimsForm : XtraForm
    {
        private subContext db = new subContext();
        private string selectedRoleCode;

        public RoleClaimsForm()
        {
            InitializeComponent();
            LoadClaims();
        }

        private void LoadClaims()
        {
            var claims = db.DcClaims.ToList();
            foreach (var claim in claims)
            {
                CheckBox checkBox = new CheckBox
                {
                    Text = claim.ClaimDesc,
                    Tag = claim.ClaimCode,
                    AutoSize = true
                };
                checkBox.CheckedChanged += CheckBox_CheckedChanged;
                flowLayoutPanel1.Controls.Add(checkBox);
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            string claimCode = checkBox.Tag.ToString();

            if (checkBox.Checked)
            {
                if (!db.TrRoleClaims.Any(rc => rc.RoleCode == selectedRoleCode && rc.ClaimCode == claimCode))
                {
                    db.TrRoleClaims.Add(new TrRoleClaim { RoleCode = selectedRoleCode, ClaimCode = claimCode });
                    db.SaveChanges();
                }
            }
            else
            {
                var roleClaim = db.TrRoleClaims.FirstOrDefault(rc => rc.RoleCode == selectedRoleCode && rc.ClaimCode == claimCode);
                if (roleClaim != null)
                {
                    db.TrRoleClaims.Remove(roleClaim);
                    db.SaveChanges();
                }
            }
        }

        private void buttonEditRole_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit buttonEdit = (ButtonEdit)sender;
            using (FormCommonList<DcRole> form = new FormCommonList<DcRole>("", nameof(DcRole.RoleCode), buttonEdit.EditValue?.ToString()))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    selectedRoleCode = form.Value_Id.ToString();
                    buttonEdit.EditValue = selectedRoleCode;
                    UpdateCheckBoxes(selectedRoleCode);
                }
            }
        }

        private void UpdateCheckBoxes(string roleCode)
        {
            var roleClaims = db.TrRoleClaims.Where(rc => rc.RoleCode == roleCode).Select(rc => rc.ClaimCode).ToList();
            foreach (CheckBox checkBox in flowLayoutPanel1.Controls)
            {
                checkBox.Checked = roleClaims.Contains(checkBox.Tag.ToString());
            }
        }
    }
}