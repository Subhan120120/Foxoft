using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using Foxoft.Models;
using Foxoft.Models.Entity.Report;
using Foxoft.Models.Entity.RoleClaim;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormCurrAccPermission : RibbonForm
    {
        private readonly EfMethods efMethods = new();
        private string? _currentCurrAccCode;
        private string? _currentRoleCode;
        private bool _isRolesModified = false;
        private bool _isRoleClaimsModified = false;
        private bool _isUpdatingCheckState = false;
        private bool _isLoading = false;

        public FormCurrAccPermission()
        {
            InitializeComponent();
            BBI_SetPassword.Enabled = CanChangePassword() && !string.IsNullOrWhiteSpace(_currentCurrAccCode);
        }

        private bool CanChangePassword()
        {
            return efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "ChangeCurrAccPassword");
        }

        public FormCurrAccPermission(string currAccCode)
            : this()
        {
            btnEdit_CurrAccCode.EditValue = currAccCode;
        }

        #region Form Load & CurrAcc Selection

        private void btnEdit_CurrAccCode_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit buttonEdit = (ButtonEdit)sender;

            using FormCurrAccList form = new(new byte[] { 3 }, false, buttonEdit.EditValue?.ToString());
            if (form.ShowDialog(this) == DialogResult.OK && form.dcCurrAcc != null)
            {
                buttonEdit.EditValue = form.dcCurrAcc.CurrAccCode;
            }
        }

        private void btnEdit_CurrAccCode_EditValueChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            string? newCurrAccCode = btnEdit_CurrAccCode.EditValue?.ToString();

            if (_currentCurrAccCode == newCurrAccCode)
                return;

            if (_isRolesModified || _isRoleClaimsModified)
            {
                DialogResult dr = XtraMessageBox.Show(
                    Resources.Form_ClaimCategoryList_UnsavedChanges,
                    Text,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                if (dr == DialogResult.Yes)
                {
                    if (_isRolesModified && !SaveCurrAccRoles(silent: true))
                    {
                        btnEdit_CurrAccCode.EditValue = _currentCurrAccCode;
                        return;
                    }
                    if (_isRoleClaimsModified && !SaveRoleClaims(silent: true))
                        return;
                }
                else if (dr == DialogResult.Cancel)
                {
                    btnEdit_CurrAccCode.EditValue = _currentCurrAccCode;
                    return;
                }
            }

            LoadCurrAccData(newCurrAccCode);
        }

        private void LoadCurrAccData(string? currAccCode)
        {
            _isLoading = true;
            try
            {
                _currentCurrAccCode = currAccCode;

                if (string.IsNullOrWhiteSpace(currAccCode))
                {
                    txt_CurrAccDesc.Text = string.Empty;
                    gridControl_Roles.DataSource = null;
                    treeListEffectiveClaims.DataSource = null;
                    lbl_EffectiveSummary.Text = string.Empty;
                    BBI_SetPassword.Enabled = false;
                    return;
                }

                DcCurrAcc? dcCurrAcc = efMethods.SelectCurrAcc(currAccCode);
                if (dcCurrAcc != null)
                {
                    string fullName = $"{dcCurrAcc.FirstName} {dcCurrAcc.LastName}".Trim();
                    txt_CurrAccDesc.Text = !string.IsNullOrWhiteSpace(dcCurrAcc.CurrAccDesc)
                        ? dcCurrAcc.CurrAccDesc
                        : fullName;
                }
                else
                {
                    txt_CurrAccDesc.Text = string.Empty;
                }

                BBI_SetPassword.Enabled = CanChangePassword() && dcCurrAcc != null;

                LoadRoles(currAccCode);
                LoadEffectiveClaims(currAccCode);
            }
            finally
            {
                _isLoading = false;
            }
        }

        #endregion

        #region Roles Management

        private void LoadRoles(string? currAccCode)
        {
            List<CurrAccRoleVM> roles = efMethods.SelectCurrAccRoleVMs(currAccCode ?? string.Empty);
            bindingSourceRoles.DataSource = roles;
            gridControl_Roles.DataSource = bindingSourceRoles;
            _isRolesModified = false;

            if (gV_Roles.RowCount > 0)
            {
                gV_Roles.FocusedRowHandle = 0;
                UpdateFocusedRole();
            }
            else
            {
                _currentRoleCode = null;
                lbl_SelectedRole.Text = Resources.Form_CurrAccProfile_NoRoleSelected;
                treeListRoleClaims.DataSource = null;
            }
        }

        private void gV_Roles_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (_isLoading)
                return;

            if (_isRoleClaimsModified)
            {
                DialogResult dr = XtraMessageBox.Show(
                    Resources.Form_ClaimCategoryList_UnsavedChanges,
                    Text,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                if (dr == DialogResult.Yes)
                {
                    if (!SaveRoleClaims(silent: true))
                        return;
                }
                else if (dr == DialogResult.Cancel)
                {
                    return;
                }
            }

            UpdateFocusedRole();
        }

        private void UpdateFocusedRole()
        {
            if (gV_Roles.GetFocusedRow() is CurrAccRoleVM selectedRole)
            {
                _currentRoleCode = selectedRole.RoleCode;
                string roleText = !string.IsNullOrWhiteSpace(selectedRole.RoleDesc) ? selectedRole.RoleDesc : selectedRole.RoleCode;
                lbl_SelectedRole.Text = string.Format(Resources.Form_CurrAccProfile_SelectedRolePrefix, $"{roleText} ({selectedRole.RoleCode})");
                LoadRoleClaims(_currentRoleCode);
            }
            else
            {
                _currentRoleCode = null;
                lbl_SelectedRole.Text = Resources.Form_CurrAccProfile_NoRoleSelected;
                treeListRoleClaims.DataSource = null;
            }
        }

        private void gV_Roles_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == col_IsAssigned)
            {
                _isRolesModified = true;
            }
        }

        private void repoCheckEditRole_EditValueChanged(object sender, EventArgs e)
        {
            gV_Roles.PostEditor();
        }

        private void btn_SaveRoles_Click(object sender, EventArgs e)
        {
            SaveCurrAccRoles();
        }

        private bool SaveCurrAccRoles(bool silent = false)
        {
            if (string.IsNullOrWhiteSpace(_currentCurrAccCode))
            {
                if (!silent)
                {
                    XtraMessageBox.Show(
                        Resources.Form_CurrAccProfile_SelectCurrAccFirst,
                        Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                return false;
            }

            try
            {
                gV_Roles.CloseEditor();
                gV_Roles.UpdateCurrentRow();

                List<string> assignedRoleCodes = new();
                if (bindingSourceRoles.DataSource is IEnumerable<CurrAccRoleVM> roles)
                {
                    assignedRoleCodes = roles
                        .Where(r => r.IsAssigned)
                        .Select(r => r.RoleCode)
                        .ToList();
                }

                efMethods.SaveCurrAccRoles(_currentCurrAccCode, assignedRoleCodes);
                _isRolesModified = false;

                LoadEffectiveClaims(_currentCurrAccCode);

                if (!silent)
                {
                    XtraMessageBox.Show(
                        Resources.Form_CurrAccProfile_RolesSavedSuccessfully,
                        Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void SelectAllRoles(bool assign)
        {
            if (bindingSourceRoles.DataSource is IEnumerable<CurrAccRoleVM> roles)
            {
                foreach (var r in roles)
                {
                    r.IsAssigned = assign;
                }
                gV_Roles.RefreshData();
                _isRolesModified = true;
            }
        }

        private void BBI_SelectAllRoles_ItemClick(object sender, ItemClickEventArgs e)
        {
            SelectAllRoles(true);
        }

        private void BBI_UnselectAllRoles_ItemClick(object sender, ItemClickEventArgs e)
        {
            SelectAllRoles(false);
        }

        #endregion

        #region Role Claims (TreeList) Management

        private void LoadRoleClaims(string? roleCode)
        {
            treeListRoleClaims.BeginUpdate();
            try
            {
                _isUpdatingCheckState = true;
                List<DcClaimCategoryViewModel> categories = efMethods.SelectDcClaimCategories(roleCode ?? string.Empty);
                treeListRoleClaims.DataSource = categories;
                treeListRoleClaims.ForceInitialize();

                InitializeTreeParentStates(treeListRoleClaims.Nodes, colRC_IsSelected);
                treeListRoleClaims.ExpandAll();
                treeListRoleClaims.BestFitColumns();
                _isRoleClaimsModified = false;
            }
            finally
            {
                _isUpdatingCheckState = false;
                treeListRoleClaims.EndUpdate();
            }
        }

        private void treeListRoleClaims_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (_isUpdatingCheckState)
                return;

            if (e.Column == colRC_IsSelected)
            {
                try
                {
                    _isUpdatingCheckState = true;
                    bool isChecked = Convert.ToBoolean(e.Value);

                    SetChildNodesChecked(e.Node, colRC_IsSelected, isChecked);
                    SetParentNodesChecked(e.Node, colRC_IsSelected);
                    _isRoleClaimsModified = true;
                }
                finally
                {
                    _isUpdatingCheckState = false;
                }
            }
        }

        private void repoCheckEditRoleClaim_EditValueChanged(object sender, EventArgs e)
        {
            treeListRoleClaims.PostEditor();
        }

        private void btn_SaveRoleClaims_Click(object sender, EventArgs e)
        {
            SaveRoleClaims();
        }

        private bool SaveRoleClaims(bool silent = false)
        {
            if (string.IsNullOrWhiteSpace(_currentRoleCode))
            {
                if (!silent)
                {
                    XtraMessageBox.Show(
                        Resources.Form_ClaimCategoryList_RoleRequired,
                        Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                return false;
            }

            try
            {
                treeListRoleClaims.CloseEditor();

                List<string> selectedClaimCodes = treeListRoleClaims.GetNodeList()
                    .Where(n => !Convert.ToBoolean(n.GetValue(colRC_IsCategory)) && (n.GetValue(colRC_IsSelected) as bool? == true))
                    .Select(n => n.GetValue(colRC_ClaimCode)?.ToString())
                    .Where(c => !string.IsNullOrWhiteSpace(c))
                    .ToList()!;

                efMethods.SaveRoleClaims(_currentRoleCode, selectedClaimCodes);
                _isRoleClaimsModified = false;

                if (!string.IsNullOrWhiteSpace(_currentCurrAccCode))
                {
                    LoadEffectiveClaims(_currentCurrAccCode);
                }

                if (!silent)
                {
                    XtraMessageBox.Show(
                        Resources.Form_CurrAccProfile_RoleClaimsSavedSuccessfully,
                        Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btn_SelectAllClaims_Click(object sender, EventArgs e)
        {
            treeListRoleClaims.BeginUpdate();
            try
            {
                _isUpdatingCheckState = true;
                foreach (TreeListNode node in treeListRoleClaims.GetNodeList())
                {
                    node.SetValue(colRC_IsSelected, true);
                }
                _isRoleClaimsModified = true;
            }
            finally
            {
                _isUpdatingCheckState = false;
                treeListRoleClaims.EndUpdate();
            }
        }

        private void btn_UnselectAllClaims_Click(object sender, EventArgs e)
        {
            treeListRoleClaims.BeginUpdate();
            try
            {
                _isUpdatingCheckState = true;
                foreach (TreeListNode node in treeListRoleClaims.GetNodeList())
                {
                    node.SetValue(colRC_IsSelected, false);
                }
                _isRoleClaimsModified = true;
            }
            finally
            {
                _isUpdatingCheckState = false;
                treeListRoleClaims.EndUpdate();
            }
        }

        private void btn_ExpandAllClaims_Click(object sender, EventArgs e)
        {
            treeListRoleClaims.ExpandAll();
        }

        private void btn_CollapseAllClaims_Click(object sender, EventArgs e)
        {
            treeListRoleClaims.CollapseAll();
        }

        private void btn_OpenClaimsWindow_Click(object sender, EventArgs e)
        {
            OpenFullClaimsWindow();
        }

        private void BBI_RoleClaimsWindow_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFullClaimsWindow();
        }

        private void OpenFullClaimsWindow()
        {
            using FormClaimCategoryList form = new(_currentRoleCode);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadRoleClaims(_currentRoleCode);
                if (!string.IsNullOrWhiteSpace(_currentCurrAccCode))
                {
                    LoadEffectiveClaims(_currentCurrAccCode);
                }
            }
        }

        #endregion

        #region Effective Claims (Tab 2)

        private void LoadEffectiveClaims(string? currAccCode)
        {
            treeListEffectiveClaims.BeginUpdate();
            try
            {
                List<DcClaimCategoryViewModel> categories = efMethods.SelectDcClaimCategoriesByCurrAcc(currAccCode ?? string.Empty);
                treeListEffectiveClaims.DataSource = categories;
                treeListEffectiveClaims.ForceInitialize();

                InitializeTreeParentStates(treeListEffectiveClaims.Nodes, colEff_IsSelected);
                treeListEffectiveClaims.ExpandAll();
                treeListEffectiveClaims.BestFitColumns();

                var leafNodes = treeListEffectiveClaims.GetNodeList()
                    .Where(n => !Convert.ToBoolean(n.GetValue(colEff_IsCategory)))
                    .ToList();

                int total = leafNodes.Count;
                int granted = leafNodes.Count(n => n.GetValue(colEff_IsSelected) as bool? == true);
                lbl_EffectiveSummary.Text = string.Format(Resources.Form_CurrAccProfile_EffectiveSummary, total, granted);
            }
            finally
            {
                treeListEffectiveClaims.EndUpdate();
            }
        }

        private void btn_RefreshEffective_Click(object sender, EventArgs e)
        {
            LoadEffectiveClaims(_currentCurrAccCode);
        }

        private void btn_ExpandAllEffective_Click(object sender, EventArgs e)
        {
            treeListEffectiveClaims.ExpandAll();
        }

        private void btn_CollapseAllEffective_Click(object sender, EventArgs e)
        {
            treeListEffectiveClaims.CollapseAll();
        }

        #endregion

        #region TreeList CheckState Helper Methods

        private void SetChildNodesChecked(TreeListNode parentNode, TreeListColumn column, bool isChecked)
        {
            foreach (TreeListNode child in parentNode.Nodes)
            {
                child.SetValue(column, isChecked);
                SetChildNodesChecked(child, column, isChecked);
            }
        }

        private void SetParentNodesChecked(TreeListNode childNode, TreeListColumn column)
        {
            TreeListNode? parent = childNode.ParentNode;
            while (parent != null)
            {
                var childStates = parent.Nodes.Cast<TreeListNode>()
                    .Select(n => n.GetValue(column) as bool?)
                    .ToList();

                if (childStates.Count > 0 && childStates.All(s => s == true))
                    parent.SetValue(column, true);
                else if (childStates.Count > 0 && childStates.All(s => s == false))
                    parent.SetValue(column, false);
                else
                    parent.SetValue(column, null);

                parent = parent.ParentNode;
            }
        }

        private void InitializeTreeParentStates(TreeListNodes nodes, TreeListColumn column)
        {
            foreach (TreeListNode node in nodes)
            {
                if (node.HasChildren)
                {
                    InitializeTreeParentStates(node.Nodes, column);

                    var childStates = node.Nodes.Cast<TreeListNode>()
                        .Select(n => n.GetValue(column) as bool?)
                        .ToList();

                    if (childStates.Count > 0 && childStates.All(s => s == true))
                        node.SetValue(column, true);
                    else if (childStates.Count > 0 && childStates.All(s => s == false))
                        node.SetValue(column, false);
                    else
                        node.SetValue(column, null);
                }
            }
        }

        #endregion

        #region Report Claims (Tab 3)

        private void LoadClaimReport()
        {
            string claimCode = btnEdit_ClaimReport.Text;

            List<DcClaimReportViewModel> data = efMethods.SelectClaimReport(claimCode);
            treeListReportClaims.DataSource = data;
            treeListReportClaims.BestFitColumns();
        }

        private void btnEdit_ClaimReport_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit buttonEdit = (ButtonEdit)sender;

            using FormCommonList<DcClaim> form = new("", nameof(DcClaim.ClaimCode), buttonEdit.EditValue?.ToString(), nameof(DcClaim.ClaimTypeId), 2);
            if (form.ShowDialog(this) == DialogResult.OK)
                buttonEdit.EditValue = form.Value_Id;
        }

        private void btnEdit_ClaimReport_EditValueChanged(object sender, EventArgs e)
        {
            LoadClaimReport();
        }

        private void treeListReportClaims_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "IsSelected")
            {
                bool isChecked = Convert.ToBoolean(e.Value);
                TreeListNode node = e.Node;

                SetChildNodesChecked(node, colReport_IsSelected, isChecked);
                SetParentNodesChecked(node, colReport_IsSelected);
            }
        }

        private void btn_ClaimReportSave_Click(object sender, EventArgs e)
        {
            SaveNodesToDb(treeListReportClaims.Nodes);
            XtraMessageBox.Show(Resources.Common_SavedSuccessfully, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveNodesToDb(IEnumerable<TreeListNode> nodes)
        {
            string claimCode = btnEdit_ClaimReport.Text;

            foreach (TreeListNode child in nodes)
            {
                DcReport report = efMethods.SelectEntityById<DcReport>(Convert.ToInt32(child.GetValue("ReportId")));
                bool chckd = (bool)child.GetValue("IsSelected");

                if (chckd)
                {
                    if (!efMethods.TrClaimReportExist(report.ReportId, claimCode))
                    {
                        efMethods.InsertEntity(new TrClaimReport()
                        {
                            ClaimCode = claimCode,
                            ReportId = report.ReportId
                        });
                    }
                }
                else
                {
                    TrClaimReport claimReport = efMethods.SelectClaimReport(report.ReportId, claimCode);

                    if (claimReport != null)
                        efMethods.DeleteEntity(claimReport);
                }
            }
        }

        #endregion

        #region Ribbon Actions

        private void BBI_Save_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool anySaved = false;

            if (_isRolesModified)
            {
                if (SaveCurrAccRoles(silent: true))
                    anySaved = true;
            }

            if (_isRoleClaimsModified)
            {
                if (SaveRoleClaims(silent: true))
                    anySaved = true;
            }

            if (anySaved)
            {
                XtraMessageBox.Show(Resources.Common_SavedSuccessfully, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BBI_Refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_isRolesModified || _isRoleClaimsModified)
            {
                DialogResult dr = XtraMessageBox.Show(
                    Resources.Form_ClaimCategoryList_UnsavedChanges,
                    Text,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                if (dr == DialogResult.Yes)
                {
                    if (_isRolesModified) SaveCurrAccRoles(silent: true);
                    if (_isRoleClaimsModified) SaveRoleClaims(silent: true);
                }
                else if (dr == DialogResult.Cancel)
                {
                    return;
                }
            }

            LoadCurrAccData(_currentCurrAccCode);
        }

        private void BBI_SetPassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CanChangePassword())
            {
                XtraMessageBox.Show(Resources.Common_NoPermission, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(_currentCurrAccCode))
            {
                XtraMessageBox.Show(Resources.Form_CurrAcc_Message_SaveFirst, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using FormCurrAccPassword frm = new(_currentCurrAccCode, txt_CurrAccDesc.Text);
            frm.ShowDialog(this);
        }

        private void BBI_NewRole_ItemClick(object sender, ItemClickEventArgs e)
        {
            using FormCommon<DcRole> form = new("", true, nameof(DcRole.RoleCode));
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadRoles(_currentCurrAccCode);
            }
        }

        private void BBI_EditRole_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_currentRoleCode))
            {
                XtraMessageBox.Show(Resources.Form_CurrAccProfile_NoRoleSelected, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using FormCommon<DcRole> form = new("", false, nameof(DcRole.RoleCode), _currentRoleCode);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadRoles(_currentCurrAccCode);
            }
        }

        private void BBI_DeleteRole_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_currentRoleCode))
            {
                XtraMessageBox.Show(Resources.Form_CurrAccProfile_NoRoleSelected, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show(Resources.Common_DeleteConfirm, Resources.Common_Attention, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    efMethods.DeleteEntityById<DcRole>(_currentRoleCode);
                    LoadRoles(_currentCurrAccCode);
                    XtraMessageBox.Show(Resources.Common_SavedSuccessfully, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Tab & Form Lifecycle

        private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (e.Page == tab_EffectiveClaims)
            {
                LoadEffectiveClaims(_currentCurrAccCode);
            }
            else if (e.Page == tab_ReportClaims)
            {
                LoadClaimReport();
            }
        }

        private void FormCurrAccPermission_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isRolesModified || _isRoleClaimsModified)
            {
                DialogResult dr = XtraMessageBox.Show(
                    Resources.Form_ClaimCategoryList_UnsavedChanges,
                    Text,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                if (dr == DialogResult.Yes)
                {
                    if (_isRolesModified && !SaveCurrAccRoles(silent: true))
                        e.Cancel = true;
                    if (_isRoleClaimsModified && !SaveRoleClaims(silent: true))
                        e.Cancel = true;
                }
                else if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void FormCurrAccPermission_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                BBI_Save.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F5)
            {
                BBI_Refresh.PerformClick();
                e.Handled = true;
            }
        }

        #endregion
    }
}
