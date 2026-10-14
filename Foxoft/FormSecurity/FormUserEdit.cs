using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Models.ViewModel;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormUserEdit : XtraForm
    {
        private readonly EfMethods efMethods = new();
        private readonly string? _userName;
        private readonly bool _isNew;
        private DcUser _entity = null!;
        private BindingList<UserCompanyItemVM> _companiesList = new();
        private bool _isPasswordMasked = true;
        private bool _isUpdatingStoreEditor = false;

        public string SavedUserName { get; private set; } = string.Empty;

        public FormUserEdit(string? userName)
        {
            InitializeComponent();
            _userName = userName;
            _isNew = string.IsNullOrWhiteSpace(userName);

            txtPassword.Properties.Buttons.Clear();
            txtPassword.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Glyph)
            {
                Caption = "👁"
            });
            txtPassword.ButtonClick += TxtPassword_ButtonClick;

            lueStore.Properties.Columns.Clear();
            lueStore.Properties.Columns.Add(new LookUpColumnInfo(nameof(DcCurrAcc.CurrAccCode), 60, Resources.Entity_CurrAcc_Code));
            lueStore.Properties.Columns.Add(new LookUpColumnInfo(nameof(DcCurrAcc.CurrAccDesc), 140, Resources.Entity_CurrAcc_Desc));
            lueStore.Properties.DisplayMember = nameof(DcCurrAcc.CurrAccDesc);
            lueStore.Properties.ValueMember = nameof(DcCurrAcc.CurrAccCode);
            lueStore.EditValueChanged += LueStore_EditValueChanged;
            lueStore.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)
                    lueStore.EditValue = null;
            };

            gvCompanies.FocusedRowChanged += (_, _) => UpdateStoreEditorForFocusedCompany();
            gvCompanies.CellValueChanging += GvCompanies_CellValueChanging;

            btnSelectAll.Click += (_, _) => SelectAllCompanies(true);
            btnUnselectAll.Click += (_, _) => SelectAllCompanies(false);
            btnSave.Click += (_, _) => Save();
            btnCancel.Click += (_, _) => DialogResult = DialogResult.Cancel;
            Load += (_, _) => LoadEntity();
        }

        private void TxtPassword_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            _isPasswordMasked = !_isPasswordMasked;
            txtPassword.Properties.PasswordChar = _isPasswordMasked ? '●' : '\0';
        }

        private void SelectAllCompanies(bool select)
        {
            foreach (var item in _companiesList)
            {
                item.IsSelected = select;
            }
            gvCompanies.RefreshData();
            UpdateStoreEditorForFocusedCompany();
        }

        private void GvCompanies_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colIsSelected && e.Value != null)
            {
                bool isSelected = Convert.ToBoolean(e.Value);
                UserCompanyItemVM? focused = gvCompanies.GetRow(e.RowHandle) as UserCompanyItemVM;
                if (focused != null && e.RowHandle == gvCompanies.FocusedRowHandle)
                {
                    lueStore.Enabled = isSelected;
                }
            }
        }

        private void LoadEntity()
        {
            List<DcCompany> allCompanies = efMethods.SelectCompanies();

            if (_isNew)
            {
                Text = Resources.Form_UserEdit_Caption_New;
                _entity = new DcUser
                {
                    RowGuid = Guid.NewGuid()
                };

                txtUserName.ReadOnly = false;
                txtUserName.Text = string.Empty;
                txtUserDesc.Text = string.Empty;
                txtPassword.Text = string.Empty;
                chkIsDisabled.Checked = false;

                _companiesList = new BindingList<UserCompanyItemVM>(
                    allCompanies.Select(c => new UserCompanyItemVM
                    {
                        IsSelected = true,
                        CompanyCode = c.CompanyCode,
                        CompanyDesc = c.CompanyDesc
                    }).ToList()
                );
            }
            else
            {
                _entity = efMethods.SelectMainUser(_userName!) ?? new DcUser();
                Text = $"{Resources.Form_UserEdit_Caption_Edit} - {_userName}";

                txtUserName.ReadOnly = true;
                txtUserName.Text = _entity.UserName;
                txtUserDesc.Text = _entity.UserDesc;
                txtPassword.Text = _entity.Password;
                chkIsDisabled.Checked = _entity.IsDisabled;

                HashSet<string> assignedCompanyCodes = new(
                    _entity.TrUserCompanies.Select(uc => uc.CompanyCode)
                );

                var list = new List<UserCompanyItemVM>();
                foreach (var c in allCompanies)
                {
                    bool isAssigned = assignedCompanyCodes.Contains(c.CompanyCode);
                    string? storeCode = isAssigned ? efMethods.SelectUserStoreCode(_userName!, c.CompanyCode) : null;
                    string? storeDesc = null;

                    if (!string.IsNullOrEmpty(storeCode))
                    {
                        var companyStores = efMethods.SelectStoresByCompany(c.CompanyCode);
                        storeDesc = companyStores.FirstOrDefault(s => s.CurrAccCode == storeCode)?.CurrAccDesc ?? storeCode;
                    }

                    list.Add(new UserCompanyItemVM
                    {
                        IsSelected = isAssigned,
                        CompanyCode = c.CompanyCode,
                        CompanyDesc = c.CompanyDesc,
                        StoreCode = storeCode,
                        StoreDesc = storeDesc
                    });
                }

                _companiesList = new BindingList<UserCompanyItemVM>(list);
            }

            gcCompanies.DataSource = _companiesList;

            if (gvCompanies.RowCount > 0)
            {
                gvCompanies.FocusedRowHandle = 0;
            }
            UpdateStoreEditorForFocusedCompany();
        }

        private void UpdateStoreEditorForFocusedCompany()
        {
            if (_isUpdatingStoreEditor)
                return;

            UserCompanyItemVM? focused = gvCompanies.GetFocusedRow() as UserCompanyItemVM;
            if (focused == null)
            {
                _isUpdatingStoreEditor = true;
                try
                {
                    lueStore.Properties.DataSource = null;
                    lueStore.EditValue = null;
                    lueStore.Enabled = false;
                }
                finally
                {
                    _isUpdatingStoreEditor = false;
                }
                return;
            }

            List<DcCurrAcc> stores = efMethods.SelectStoresByCompany(focused.CompanyCode);

            _isUpdatingStoreEditor = true;
            try
            {
                lueStore.Properties.DataSource = stores;
                lueStore.EditValue = focused.StoreCode;
                lueStore.Enabled = focused.IsSelected;
            }
            finally
            {
                _isUpdatingStoreEditor = false;
            }
        }

        private void LueStore_EditValueChanged(object sender, EventArgs e)
        {
            if (_isUpdatingStoreEditor)
                return;

            UserCompanyItemVM? focused = gvCompanies.GetFocusedRow() as UserCompanyItemVM;
            if (focused == null)
                return;

            string? selectedStoreCode = lueStore.EditValue?.ToString();
            focused.StoreCode = selectedStoreCode;
            focused.StoreDesc = !string.IsNullOrEmpty(selectedStoreCode) ? lueStore.Text : null;
            gvCompanies.RefreshRow(gvCompanies.FocusedRowHandle);
        }

        private void Save()
        {
            string userName = txtUserName.Text?.Trim() ?? string.Empty;
            string userDesc = txtUserDesc.Text?.Trim() ?? string.Empty;
            string password = txtPassword.Text?.Trim() ?? string.Empty;
            bool isDisabled = chkIsDisabled.Checked;

            if (string.IsNullOrWhiteSpace(userName))
            {
                XtraMessageBox.Show(this, Resources.Form_UserEdit_UserNameRequired, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }

            if (_isNew && efMethods.MainUserExist(userName))
            {
                XtraMessageBox.Show(this, Resources.Form_UserEdit_UserNameExists, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                XtraMessageBox.Show(this, Resources.Form_UserEdit_PasswordRequired, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            List<string> selectedCompanies = _companiesList
                .Where(x => x.IsSelected)
                .Select(x => x.CompanyCode)
                .ToList();

            if (selectedCompanies.Count == 0)
            {
                XtraMessageBox.Show(this, Resources.Form_UserEdit_CompanyRequired, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _entity.UserName = userName;
            _entity.UserDesc = userDesc;
            _entity.Password = password;
            _entity.IsDisabled = isDisabled;

            if (!EntityValidationHelper.TryValidate(_entity, out string msg))
            {
                XtraMessageBox.Show(this, msg, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_isNew)
            {
                efMethods.InsertMainUser(_entity, selectedCompanies);
            }
            else
            {
                efMethods.UpdateMainUser(_entity, selectedCompanies);
            }

            foreach (var item in _companiesList)
            {
                if (item.IsSelected)
                {
                    efMethods.SaveUserStore(_entity.UserName, item.CompanyCode, item.StoreCode);
                }
                else
                {
                    efMethods.DeleteUserStore(_entity.UserName, item.CompanyCode);
                }
            }

            SavedUserName = _entity.UserName;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
