using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Foxoft.Models;
using Foxoft.Models.Entity.RoleClaim;
using Foxoft.Properties;

namespace Foxoft
{
    public partial class FormClaimCategoryList : XtraForm
    {
        private readonly EfMethods efMethods = new();
        private string? _roleCode;
        private bool _isModified = false;
        private bool _isUpdatingCheckState = false;
        private bool _isLoading = false;

        public DcClaimCategory? DcClaimCategory;

        public FormClaimCategoryList()
        {
            InitializeComponent();

            treeList1.GetStateImage += TreeList_GetStateImage;
            treeList1.AfterExpand += (_, _) => treeList1.Invalidate();
            treeList1.AfterCollapse += (_, _) => treeList1.Invalidate();
        }

        public FormClaimCategoryList(string? roleCode)
            : this()
        {
            _roleCode = roleCode;
        }

        private void FormClaimCategoryList_Load(object sender, EventArgs e)
        {
            _isLoading = true;
            try
            {
                LoadRoles();

                if (!string.IsNullOrEmpty(_roleCode))
                {
                    lue_Role.EditValue = _roleCode;
                }
                else if (lue_Role.Properties.DataSource is List<DcRole> roles && roles.Count > 0)
                {
                    _roleCode = roles[0].RoleCode;
                    lue_Role.EditValue = _roleCode;
                }

                UpdateFormTitle();
                LoadData(_roleCode);
            }
            finally
            {
                _isLoading = false;
            }

            treeList1.ShowFindPanel();
        }

        private void LoadRoles()
        {
            List<DcRole> roles = efMethods.SelectEntities<DcRole>();

            lue_Role.Properties.DataSource = roles;
            lue_Role.Properties.ValueMember = nameof(DcRole.RoleCode);
            lue_Role.Properties.DisplayMember = nameof(DcRole.RoleDesc);

            lue_Role.Properties.Columns.Clear();
            lue_Role.Properties.Columns.Add(new LookUpColumnInfo(nameof(DcRole.RoleCode), Resources.Entity_Role_Code, 80));
            lue_Role.Properties.Columns.Add(new LookUpColumnInfo(nameof(DcRole.RoleDesc), Resources.Entity_Role_Desc, 160));
        }

        private void UpdateFormTitle()
        {
            if (!string.IsNullOrEmpty(_roleCode))
            {
                string roleText = !string.IsNullOrWhiteSpace(lue_Role.Text) ? lue_Role.Text : _roleCode;
                Text = $"{Resources.Form_ClaimCategoryList_Caption} - {roleText} ({_roleCode})";
            }
            else
            {
                Text = Resources.Form_ClaimCategoryList_Caption;
            }
        }

        private void lue_Role_EditValueChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            string? newRoleCode = lue_Role.EditValue?.ToString();

            if (_roleCode == newRoleCode)
                return;

            if (_isModified)
            {
                DialogResult dr = XtraMessageBox.Show(
                    Resources.Form_ClaimCategoryList_UnsavedChanges,
                    Text,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                if (dr == DialogResult.Yes)
                {
                    if (!SaveData())
                    {
                        lue_Role.EditValue = _roleCode;
                        return;
                    }
                }
                else if (dr == DialogResult.Cancel)
                {
                    lue_Role.EditValue = _roleCode;
                    return;
                }
            }

            _roleCode = newRoleCode;
            UpdateFormTitle();
            LoadData(_roleCode);
        }

        private void LoadData(string? roleCode)
        {
            treeList1.BeginUpdate();
            try
            {
                _isUpdatingCheckState = true;
                List<DcClaimCategoryViewModel> dcClaimCategories = efMethods.SelectDcClaimCategories(roleCode ?? string.Empty);
                treeList1.DataSource = dcClaimCategories;
                treeList1.ForceInitialize();

                InitializeTreeParentStates(treeList1.Nodes);
                treeList1.ExpandAll();
                treeList1.BestFitColumns();
                UpdateSummary();
                _isModified = false;
            }
            finally
            {
                _isUpdatingCheckState = false;
                treeList1.EndUpdate();
            }
        }

        private void TreeList_GetStateImage(object sender, GetStateImageEventArgs e)
        {
            if (e.Node == null)
                return;

            bool isCategory = Convert.ToBoolean(e.Node.GetValue(treeListCol_IsCategory));
            if (isCategory)
            {
                e.NodeImageIndex = e.Node.Expanded ? 0 : 1;
            }
            else
            {
                e.NodeImageIndex = 9; // Key icon
            }
        }

        private void repoCheckEdit_EditValueChanged(object sender, EventArgs e)
        {
            treeList1.PostEditor();
        }

        private void treeList1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (_isUpdatingCheckState)
                return;

            if (e.Column == treeListCol_IsSelected)
            {
                try
                {
                    _isUpdatingCheckState = true;
                    bool isChecked = Convert.ToBoolean(e.Value);

                    SetChildNodesChecked(e.Node, isChecked);
                    SetParentNodesChecked(e.Node);
                    _isModified = true;
                    UpdateSummary();
                }
                finally
                {
                    _isUpdatingCheckState = false;
                }
            }
        }

        private void SetChildNodesChecked(TreeListNode parentNode, bool isChecked)
        {
            foreach (TreeListNode child in parentNode.Nodes)
            {
                child.SetValue(treeListCol_IsSelected, isChecked);
                SetChildNodesChecked(child, isChecked);
            }
        }

        private void SetParentNodesChecked(TreeListNode childNode)
        {
            TreeListNode? parent = childNode.ParentNode;
            while (parent != null)
            {
                var childStates = parent.Nodes.Cast<TreeListNode>()
                    .Select(n => n.GetValue(treeListCol_IsSelected) as bool?)
                    .ToList();

                if (childStates.Count > 0 && childStates.All(s => s == true))
                    parent.SetValue(treeListCol_IsSelected, true);
                else if (childStates.Count > 0 && childStates.All(s => s == false))
                    parent.SetValue(treeListCol_IsSelected, false);
                else
                    parent.SetValue(treeListCol_IsSelected, null);

                parent = parent.ParentNode;
            }
        }

        private void InitializeTreeParentStates(TreeListNodes nodes)
        {
            foreach (TreeListNode node in nodes)
            {
                if (node.HasChildren)
                {
                    InitializeTreeParentStates(node.Nodes);

                    var childStates = node.Nodes.Cast<TreeListNode>()
                        .Select(n => n.GetValue(treeListCol_IsSelected) as bool?)
                        .ToList();

                    if (childStates.Count > 0 && childStates.All(s => s == true))
                        node.SetValue(treeListCol_IsSelected, true);
                    else if (childStates.Count > 0 && childStates.All(s => s == false))
                        node.SetValue(treeListCol_IsSelected, false);
                    else
                        node.SetValue(treeListCol_IsSelected, null);
                }
            }
        }

        private void UpdateSummary()
        {
            var leafNodes = treeList1.GetNodeList()
                .Where(n => !Convert.ToBoolean(n.GetValue(treeListCol_IsCategory)))
                .ToList();

            int totalClaims = leafNodes.Count;
            int selectedClaims = leafNodes.Count(n => n.GetValue(treeListCol_IsSelected) as bool? == true);

            lbl_Summary.Text = string.Format(Resources.Form_ClaimCategoryList_Summary, totalClaims, selectedClaims);
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            object? categoryId = e.Node?.GetValue(treeListCol_CategoryId);
            bool isCategory = Convert.ToBoolean(e.Node?.GetValue(treeListCol_IsCategory) ?? false);

            if (categoryId is not null && isCategory)
                DcClaimCategory = efMethods.SelectEntityById<DcClaimCategory>(Convert.ToInt32(categoryId));
        }

        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            treeList1.BeginUpdate();
            try
            {
                _isUpdatingCheckState = true;
                foreach (TreeListNode node in treeList1.GetNodeList())
                {
                    node.SetValue(treeListCol_IsSelected, true);
                }
                _isModified = true;
                UpdateSummary();
            }
            finally
            {
                _isUpdatingCheckState = false;
                treeList1.EndUpdate();
            }
        }

        private void btn_UnselectAll_Click(object sender, EventArgs e)
        {
            treeList1.BeginUpdate();
            try
            {
                _isUpdatingCheckState = true;
                foreach (TreeListNode node in treeList1.GetNodeList())
                {
                    node.SetValue(treeListCol_IsSelected, false);
                }
                _isModified = true;
                UpdateSummary();
            }
            finally
            {
                _isUpdatingCheckState = false;
                treeList1.EndUpdate();
            }
        }

        private void btn_ExpandAll_Click(object sender, EventArgs e)
        {
            treeList1.ExpandAll();
        }

        private void btn_CollapseAll_Click(object sender, EventArgs e)
        {
            treeList1.CollapseAll();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            if (_isModified)
            {
                DialogResult dr = XtraMessageBox.Show(
                    Resources.Form_ClaimCategoryList_UnsavedChanges,
                    Text,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                if (dr == DialogResult.Yes)
                {
                    if (!SaveData())
                        return;
                }
                else if (dr == DialogResult.Cancel)
                {
                    return;
                }
            }

            LoadData(_roleCode);
        }

        private void btn_Claims_Click(object sender, EventArgs e)
        {
            using FormCommonList<DcClaim> formCommonList = new("", nameof(DcClaim.ClaimCode));
            if (formCommonList.ShowDialog(this) == DialogResult.OK)
            {
                LoadData(_roleCode);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                XtraMessageBox.Show(
                    Resources.Common_SavedSuccessfully,
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private bool SaveData()
        {
            if (string.IsNullOrWhiteSpace(_roleCode))
            {
                XtraMessageBox.Show(
                    Resources.Form_ClaimCategoryList_RoleRequired,
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                lue_Role.Focus();
                return false;
            }

            try
            {
                List<string> selectedClaimCodes = treeList1.GetNodeList()
                    .Where(n => !Convert.ToBoolean(n.GetValue(treeListCol_IsCategory)) && (n.GetValue(treeListCol_IsSelected) as bool? == true))
                    .Select(n => n.GetValue(treeListCol_ClaimCode)?.ToString())
                    .Where(c => !string.IsNullOrWhiteSpace(c))
                    .ToList()!;

                efMethods.SaveRoleClaims(_roleCode, selectedClaimCodes);
                _isModified = false;
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    ex.Message,
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormClaimCategoryList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isModified)
            {
                DialogResult dr = XtraMessageBox.Show(
                    Resources.Form_ClaimCategoryList_UnsavedChanges,
                    Text,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                if (dr == DialogResult.Yes)
                {
                    if (!SaveData())
                        e.Cancel = true;
                }
                else if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void FormClaimCategoryList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                btn_Save.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F5)
            {
                btn_Refresh.PerformClick();
                e.Handled = true;
            }
        }
    }
}

