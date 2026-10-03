using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Models.ViewModel;
using Foxoft.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormUserList : RibbonForm
    {
        private readonly EfMethods efMethods = new();
        private readonly bool _isSelectMode;

        public DcUser? SelectedUser { get; private set; }
        public string? SelectedUserName => FocusedUserName();

        public FormUserList()
            : this(false, null)
        {
        }

        public FormUserList(string? initialFocusUserName)
            : this(false, initialFocusUserName)
        {
        }

        public FormUserList(bool isSelectMode, string? initialFocusUserName = null)
        {
            _isSelectMode = isSelectMode;
            InitializeComponent();

            btnSelect.Visibility = _isSelectMode ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            btnSelect.ItemClick += (_, _) => AcceptSelection();

            Load += (_, _) =>
            {
                LoadData();
                if (!string.IsNullOrWhiteSpace(initialFocusUserName))
                    FocusRowByUserName(initialFocusUserName);
            };

            btnNew.ItemClick += (_, _) => NewItem();
            btnEdit.ItemClick += (_, _) => EditItem();
            btnDelete.ItemClick += (_, _) => DeleteItem();
            btnRefresh.ItemClick += (_, _) => LoadData(FocusedUserName());
            btnExportExcel.ItemClick += (_, _) => ExportExcel();
            btnClose.ItemClick += (_, _) => Close();

            gridView1.DoubleClick += (_, _) =>
            {
                if (_isSelectMode)
                    AcceptSelection();
                else
                    EditItem();
            };
            gridView1.KeyDown += GridView1_KeyDown;
            gridView1.CustomDrawRowIndicator += (s, e) =>
            {
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            };
        }

        private void AcceptSelection()
        {
            string? userName = FocusedUserName();
            if (string.IsNullOrWhiteSpace(userName))
            {
                XtraMessageBox.Show(this, Resources.Form_UserList_NoUserSelected, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SelectedUser = efMethods.SelectMainUser(userName);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void GridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_isSelectMode)
                {
                    AcceptSelection();
                }
                else
                {
                    EditItem();
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Delete && !_isSelectMode)
            {
                DeleteItem();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Insert && !_isSelectMode)
            {
                NewItem();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F5)
            {
                LoadData(FocusedUserName());
                e.Handled = true;
            }
        }

        private void LoadData(string? focusUserName = null)
        {
            var users = efMethods.SelectMainUsers();

            var list = users.Select(u => new UserViewModel
            {
                UserName = u.UserName,
                UserDesc = u.UserDesc,
                Companies = string.Join(", ", u.TrUserCompanies.Select(c =>
                    !string.IsNullOrWhiteSpace(c.DcCompany?.CompanyDesc)
                        ? c.DcCompany.CompanyDesc
                        : c.CompanyCode)),
                CompanyCount = u.TrUserCompanies.Count,
                IsDisabled = u.IsDisabled
            }).ToList();

            gridControl1.DataSource = list;
            bsiCount.Caption = $"{Resources.Common_Count}: {list.Count}";

            if (!string.IsNullOrWhiteSpace(focusUserName))
                FocusRowByUserName(focusUserName);
        }

        private void FocusRowByUserName(string userName)
        {
            int rowHandle = gridView1.LocateByValue(nameof(UserViewModel.UserName), userName);
            if (rowHandle != GridControl.InvalidRowHandle)
            {
                gridView1.FocusedRowHandle = rowHandle;
                gridView1.MakeRowVisible(rowHandle);
            }
        }

        private string? FocusedUserName()
        {
            object? val = gridView1.GetFocusedRowCellValue(nameof(UserViewModel.UserName));
            return val?.ToString();
        }

        private void NewItem()
        {
            using FormUserEdit form = new(null);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadData(form.SavedUserName);
            }
        }

        private void EditItem()
        {
            string? userName = FocusedUserName();
            if (string.IsNullOrWhiteSpace(userName))
            {
                XtraMessageBox.Show(this, Resources.Form_UserList_NoUserSelected, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using FormUserEdit form = new(userName);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadData(form.SavedUserName);
            }
        }

        private void DeleteItem()
        {
            string? userName = FocusedUserName();
            if (string.IsNullOrWhiteSpace(userName))
            {
                XtraMessageBox.Show(this, Resources.Form_UserList_NoUserSelected, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.Equals(userName, Authorization.CurrAccCode, StringComparison.OrdinalIgnoreCase))
            {
                XtraMessageBox.Show(this, Resources.Form_UserList_CannotDeleteSelf, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.Equals(userName, "admin", StringComparison.OrdinalIgnoreCase))
            {
                XtraMessageBox.Show(this, Resources.Form_UserList_CannotDeleteAdmin, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show(this, Resources.Common_DeleteConfirm, Resources.Common_Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            efMethods.DeleteMainUser(userName);
            LoadData();
        }

        private void ExportExcel()
        {
            using SaveFileDialog sfd = new()
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = $"Users_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
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
