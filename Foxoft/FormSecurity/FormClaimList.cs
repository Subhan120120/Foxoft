using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using Foxoft.Models;
using Foxoft.Models.Entity.RoleClaim;
using Foxoft.Models.ViewModel;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormClaimList : RibbonForm
    {
        public string? SelectedClaimCode => FocusedClaimCode();

        public FormClaimList()
        {
            InitializeComponent();

            Load += (_, _) => LoadData();

            btnNew.ItemClick += (_, _) => NewItem();
            btnEdit.ItemClick += (_, _) => EditItem();
            btnDelete.ItemClick += (_, _) => DeleteItem();
            btnRefresh.ItemClick += (_, _) => LoadData(FocusedClaimCode());
            btnExportExcel.ItemClick += (_, _) => ExportExcel();
            btnClose.ItemClick += (_, _) => Close();

            gridView1.DoubleClick += (_, _) => EditItem();
            gridView1.KeyDown += GridView1_KeyDown;
            gridView1.CustomDrawRowIndicator += (s, e) =>
            {
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            };
        }

        public FormClaimList(string? initialFocusClaimCode)
            : this()
        {
            Load += (_, _) =>
            {
                if (!string.IsNullOrWhiteSpace(initialFocusClaimCode))
                    FocusRowByCode(initialFocusClaimCode);
            };
        }

        private void GridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EditItem();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                DeleteItem();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Insert)
            {
                NewItem();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F5)
            {
                LoadData(FocusedClaimCode());
                e.Handled = true;
            }
        }

        private void LoadData(string? focusClaimCode = null)
        {
            using subContext db = new();

            var list = db.DcClaims.AsNoTracking()
                .Include(c => c.DcClaimCategory)
                .Include(c => c.DcClaimType)
                .OrderBy(c => c.DcClaimCategory != null ? c.DcClaimCategory.Order : 0)
                .ThenBy(c => c.ClaimCode)
                .Select(c => new ClaimViewModel
                {
                    ClaimCode = c.ClaimCode,
                    ClaimDesc = c.ClaimDesc,
                    CategoryId = c.CategoryId,
                    CategoryDesc = c.DcClaimCategory != null ? c.DcClaimCategory.CategoryDesc : string.Empty,
                    ClaimTypeId = c.ClaimTypeId,
                    ClaimTypeDesc = c.DcClaimType != null ? c.DcClaimType.ClaimTypeDesc : string.Empty,
                    Id = c.Id
                })
                .ToList();

            gridControl1.DataSource = list;
            bsiCount.Caption = $"{Resources.Common_Count}: {list.Count}";

            if (!string.IsNullOrWhiteSpace(focusClaimCode))
                FocusRowByCode(focusClaimCode);
        }

        private void FocusRowByCode(string claimCode)
        {
            int rowHandle = gridView1.LocateByValue(nameof(ClaimViewModel.ClaimCode), claimCode);
            if (rowHandle != GridControl.InvalidRowHandle)
            {
                gridView1.FocusedRowHandle = rowHandle;
                gridView1.MakeRowVisible(rowHandle);
            }
        }

        private string? FocusedClaimCode()
        {
            object? val = gridView1.GetFocusedRowCellValue(nameof(ClaimViewModel.ClaimCode));
            return val?.ToString();
        }

        private void NewItem()
        {
            using FormClaimEdit form = new(null);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadData(form.SavedClaimCode);
            }
        }

        private void EditItem()
        {
            string? claimCode = FocusedClaimCode();
            if (string.IsNullOrWhiteSpace(claimCode))
            {
                XtraMessageBox.Show(this, Resources.Form_ClaimList_NoClaimSelected, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using FormClaimEdit form = new(claimCode);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadData(form.SavedClaimCode);
            }
        }

        private void DeleteItem()
        {
            string? claimCode = FocusedClaimCode();
            if (string.IsNullOrWhiteSpace(claimCode))
            {
                XtraMessageBox.Show(this, Resources.Form_ClaimList_NoClaimSelected, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using subContext db = new();
            DcClaim? claim = db.DcClaims
                .Include(c => c.TrRoleClaims)
                .Include(c => c.TrClaimReports)
                .FirstOrDefault(c => c.ClaimCode == claimCode);

            if (claim == null)
                return;

            string confirmMessage = claim.TrRoleClaims.Count > 0
                ? string.Format(Resources.Form_ClaimList_HasRelatedRoleClaims, claim.TrRoleClaims.Count)
                : Resources.Common_DeleteConfirm;

            if (XtraMessageBox.Show(this, confirmMessage, Resources.Common_Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (claim.TrRoleClaims.Count > 0)
                db.TrRoleClaims.RemoveRange(claim.TrRoleClaims);

            if (claim.TrClaimReports.Count > 0)
                db.TrClaimReports.RemoveRange(claim.TrClaimReports);

            db.DcClaims.Remove(claim);
            db.SaveChanges();

            LoadData();
        }

        private void ExportExcel()
        {
            using SaveFileDialog sfd = new()
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = $"Claims_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                gridControl1.ExportToXlsx(sfd.FileName);

                if (File.Exists(sfd.FileName))
                {
                    Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                }
            }
        }
    }
}
