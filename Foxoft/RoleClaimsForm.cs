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
        private List<DcClaim> claims;
        private string selectedRoleCode;
        subContext db = new subContext();

        public RoleClaimsForm()
        {
            InitializeComponent();
            LoadClaims();
            btnEditRole.ButtonClick += BtnEditRole_ButtonClick;
            btnSave.Click += BtnSave_Click;
        }

        private void LoadClaims()
        {
            claims = new List<DcClaim>
            {
                new DcClaim { ClaimCode = "ButunHesabatlar", ClaimDesc = "Butun Hesabatlar", ClaimTypeId = 2 },
                new DcClaim { ClaimCode = "CashRegs", ClaimDesc = "Kassalar", ClaimTypeId = 1 },
                // Add all other claims here...
            };

            foreach (var claim in claims)
            {
                var chk = new CheckBox
                {
                    Text = claim.ClaimDesc,
                    Tag = claim.ClaimCode,
                    AutoSize = true
                };
                chk.CheckedChanged += Chk_CheckedChanged;
                flowLayoutPanel1.Controls.Add(chk);
            }
        }

        private void BtnEditRole_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            // Open a form or dialog to select a role and set selectedRoleCode
            // For simplicity, let's assume we have a method to select a role
            selectedRoleCode = SelectRole();
            btnEditRole.Text = selectedRoleCode;
        }

        private void Chk_CheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            var claimCode = chk.Tag.ToString();

            if (chk.Checked)
            {
                db.TrRoleClaims.Add(new TrRoleClaim { RoleClaimId = 1, RoleCode = selectedRoleCode, ClaimCode = claimCode });
            }
            else
            {
                var roleClaim = db.TrRoleClaims.FirstOrDefault(rc => rc.RoleCode == selectedRoleCode && rc.ClaimCode == claimCode);
                if (roleClaim != null)
                {
                    db.TrRoleClaims.Remove(roleClaim);
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
            XtraMessageBox.Show("Changes saved successfully!");
        }

        private string SelectRole()
        {
            // Implement role selection logic here
            return "Admin"; // Placeholder
        }
    }
}