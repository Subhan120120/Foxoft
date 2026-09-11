using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Menu;
using DevExpress.XtraTreeList.Nodes;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormHierarchyList : XtraForm
    {
        private readonly EfMethods efMethods = new();

        public DcHierarchy? DcHierarchy { get; set; }

        public FormHierarchyList()
        {
            InitializeComponent();

            treeList1.GetStateImage += TreeList_GetStateImage;
            treeList1.AfterExpand += (_, _) => treeList1.Invalidate();
            treeList1.AfterCollapse += (_, _) => treeList1.Invalidate();
        }

        public FormHierarchyList(string? hierarchyCode)
            : this()
        {
            if (!string.IsNullOrEmpty(hierarchyCode))
                DcHierarchy = efMethods.SelectEntityById<DcHierarchy>(hierarchyCode);
        }

        private void TreeList_GetStateImage(object sender, GetStateImageEventArgs e)
        {
            if (e.Node == null)
                return;

            const int openIndex = 0;
            const int closedIndex = 12;

            if (e.Node.HasChildren)
            {
                e.NodeImageIndex = e.Node.Expanded ? openIndex : closedIndex;
            }
            else
            {
                e.NodeImageIndex = openIndex;
            }
        }

        private void FormTreeView_Load(object sender, EventArgs e)
        {
            LoadData();
            SelectAndFocusNode(DcHierarchy?.HierarchyCode);
        }

        private void FormTreeView_Shown(object sender, EventArgs e)
        {
            treeList1.ShowFindPanel();
        }

        private void LoadData()
        {
            string? currentCode = treeList1.FocusedNode?.GetValue(treeListCol_HierarchyCode)?.ToString()
                ?? DcHierarchy?.HierarchyCode;

            List<DcHierarchy> dcHierarchies = efMethods.SelectHierarchies();
            treeList1.DataSource = dcHierarchies;

            SelectAndFocusNode(currentCode);
        }

        private void SelectAndFocusNode(string? code)
        {
            if (string.IsNullOrEmpty(code))
                return;

            TreeListNode? node = treeList1.FindNodeByFieldValue(
                nameof(DcHierarchy.HierarchyCode),
                code
            );

            if (node != null)
            {
                treeList1.MakeNodeVisible(node);
                treeList1.FocusedNode = node;
            }
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            object? hierarchyCode = e.Node?.GetValue(treeListCol_HierarchyCode);

            if (hierarchyCode is not null)
                DcHierarchy = efMethods.SelectEntityById<DcHierarchy>(hierarchyCode.ToString()!);
        }

        private void ConfirmSelection()
        {
            string? hierarchyCode = treeList1.FocusedNode?.GetValue(treeListCol_HierarchyCode)?.ToString();
            if (!string.IsNullOrEmpty(hierarchyCode))
            {
                DcHierarchy = efMethods.SelectEntityById<DcHierarchy>(hierarchyCode);
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            TreeListHitInfo hitInfo = treeList1.CalcHitInfo(treeList1.PointToClient(Cursor.Position));
            if (hitInfo.HitInfoType == HitInfoType.Cell || hitInfo.HitInfoType == HitInfoType.Row)
            {
                ConfirmSelection();
            }
        }

        private void treeList1_KeyDown(object sender, KeyEventArgs e)
        {
            if (treeList1.ActiveEditor != null)
                return;

            if (e.KeyCode == Keys.Enter)
            {
                ConfirmSelection();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F2)
            {
                EditNode();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                DeleteFocusedNode();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Insert)
            {
                AddChildNode();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F5)
            {
                LoadData();
                e.Handled = true;
            }
        }

        private string GenerateNextHierarchyCode()
        {
            try
            {
                string code = efMethods.GetNextDocNum(
                    false,
                    "H",
                    nameof(DcHierarchy.HierarchyCode),
                    nameof(subContext.DcHierarchies),
                    4);

                if (!string.IsNullOrEmpty(code))
                    return code;
            }
            catch
            {
                // Fallback if stored procedure fails
            }

            using subContext db = new();
            var codes = db.DcHierarchies
                .Select(x => x.HierarchyCode)
                .ToList();

            int maxNum = 0;
            foreach (string? c in codes)
            {
                if (!string.IsNullOrEmpty(c) && c.StartsWith("H", StringComparison.OrdinalIgnoreCase))
                {
                    if (int.TryParse(c.Substring(1), out int num) && num > maxNum)
                        maxNum = num;
                }
            }

            return $"H{(maxNum + 1).ToString("D4")}";
        }

        private void CreateNode(string? parentCode, int level)
        {
            string suggestedCode = GenerateNextHierarchyCode();
            string? code = XtraInputBox.Show(
                Resources.Form_HierarchyList_Input_Prompt,
                Resources.Form_HierarchyList_Input_Title,
                suggestedCode)?.Trim();

            if (string.IsNullOrWhiteSpace(code))
                return;

            try
            {
                using (subContext db = new())
                {
                    if (db.DcHierarchies.Any(x => x.HierarchyCode == code))
                    {
                        XtraMessageBox.Show(
                            this,
                            Resources.Form_HierarchyList_CodeExistsWarning,
                            Text,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    int maxOrder = db.DcHierarchies
                        .Where(x => x.HierarchyParentCode == parentCode)
                        .Select(x => (int?)x.Order)
                        .Max() ?? 0;

                    DcHierarchy newEntity = new()
                    {
                        HierarchyCode = code,
                        HierarchyDesc = Resources.Form_HierarchyList_NewDesc,
                        HierarchyLevel = level,
                        HierarchyParentCode = parentCode,
                        Order = maxOrder + 1
                    };

                    efMethods.InsertEntity(newEntity);
                }

                LoadData();
                SelectAndFocusNode(code);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, Resources.Common_ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddRootNode()
        {
            CreateNode(null, 0);
        }

        private void AddChildNode()
        {
            TreeListNode? focusedNode = treeList1.FocusedNode;
            if (focusedNode == null)
            {
                AddRootNode();
                return;
            }

            string? parentCode = focusedNode.GetValue(treeListCol_HierarchyCode)?.ToString();
            if (string.IsNullOrEmpty(parentCode))
                return;

            CreateNode(parentCode, focusedNode.Level + 1);
        }

        private void AddSiblingNode()
        {
            TreeListNode? focusedNode = treeList1.FocusedNode;
            if (focusedNode == null || focusedNode.ParentNode == null)
            {
                AddRootNode();
                return;
            }

            string? parentCode = focusedNode.ParentNode.GetValue(treeListCol_HierarchyCode)?.ToString();
            CreateNode(parentCode, focusedNode.Level);
        }

        private void EditNode()
        {
            if (treeList1.FocusedNode != null)
            {
                treeList1.OptionsBehavior.Editable = true;
                treeList1.FocusedColumn = treeListCol_HierarchyDesc;
                treeList1.ShowEditor();
            }
        }

        private void treeList1_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (treeList1.FocusedColumn != treeListCol_HierarchyDesc)
                e.Cancel = true;
        }

        private void treeList1_HiddenEditor(object sender, EventArgs e)
        {
            treeList1.OptionsBehavior.Editable = false;
        }

        private void DeleteFocusedNode()
        {
            TreeListNode? focusedNode = treeList1.FocusedNode;
            if (focusedNode == null)
                return;

            string? hierarchyCode = focusedNode.GetValue(treeListCol_HierarchyCode)?.ToString();
            string hierarchyDesc = focusedNode.GetValue(treeListCol_HierarchyDesc)?.ToString() ?? hierarchyCode ?? string.Empty;

            if (string.IsNullOrEmpty(hierarchyCode))
                return;

            if (focusedNode.HasChildren)
            {
                XtraMessageBox.Show(
                    this,
                    Resources.Form_HierarchyList_HasChildrenWarning,
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using subContext db = new();

            bool hasChildren = db.DcHierarchies.Any(x => x.HierarchyParentCode == hierarchyCode);
            if (hasChildren)
            {
                XtraMessageBox.Show(
                    this,
                    Resources.Form_HierarchyList_HasChildrenWarning,
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            bool hasProducts = db.DcProducts.Any(x => x.HierarchyCode == hierarchyCode);
            if (hasProducts)
            {
                XtraMessageBox.Show(
                    this,
                    Resources.Form_HierarchyList_HasProductsWarning,
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = XtraMessageBox.Show(
                this,
                string.Format(Resources.Form_HierarchyList_DeleteConfirm, hierarchyDesc),
                Resources.Common_Confirm,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                var featureLinks = db.TrHierarchyFeatureTypes.Where(x => x.HierarchyCode == hierarchyCode).ToList();
                if (featureLinks.Count > 0)
                    db.TrHierarchyFeatureTypes.RemoveRange(featureLinks);

                var entity = db.DcHierarchies.FirstOrDefault(x => x.HierarchyCode == hierarchyCode);
                if (entity != null)
                    db.DcHierarchies.Remove(entity);

                db.SaveChanges();

                if (DcHierarchy?.HierarchyCode == hierarchyCode)
                    DcHierarchy = null;

                treeList1.DeleteNode(focusedNode);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, Resources.Common_ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void treeList1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column == treeListCol_HierarchyDesc)
            {
                string? hierarchyCode = e.Node.GetValue(treeListCol_HierarchyCode)?.ToString();
                string? hierarchyDesc = e.Value?.ToString()?.Trim();

                if (!string.IsNullOrEmpty(hierarchyCode) && !string.IsNullOrEmpty(hierarchyDesc))
                {
                    efMethods.UpdateHierarchyDesc(hierarchyCode, hierarchyDesc);
                    if (DcHierarchy?.HierarchyCode == hierarchyCode)
                        DcHierarchy.HierarchyDesc = hierarchyDesc;
                }
            }
        }

        private void treeList1_AfterDropNode(object sender, AfterDropNodeEventArgs e)
        {
            if (e.Node == null)
                return;

            string? hierarchyCode = e.Node.GetValue(treeListCol_HierarchyCode)?.ToString();
            if (string.IsNullOrEmpty(hierarchyCode))
                return;

            string? newParentCode = e.Node.ParentNode?.GetValue(treeListCol_HierarchyCode)?.ToString();
            int newLevel = e.Node.Level;

            try
            {
                using subContext db = new();
                var entity = db.DcHierarchies.FirstOrDefault(x => x.HierarchyCode == hierarchyCode);
                if (entity != null)
                {
                    entity.HierarchyParentCode = newParentCode;
                    entity.HierarchyLevel = newLevel;

                    UpdateChildLevels(db, hierarchyCode, newLevel);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, Resources.Common_ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadData();
            }
        }

        private void UpdateChildLevels(subContext db, string parentCode, int parentLevel)
        {
            var children = db.DcHierarchies.Where(x => x.HierarchyParentCode == parentCode).ToList();
            foreach (var child in children)
            {
                child.HierarchyLevel = parentLevel + 1;
                UpdateChildLevels(db, child.HierarchyCode, child.HierarchyLevel);
            }
        }

        private void treeList1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.Menu is TreeListNodeMenu nodeMenu)
            {
                treeList1.FocusedNode = nodeMenu.Node;

                DXMenuItem dx_AddRoot = new(
                    Resources.Form_HierarchyList_AddRoot,
                    (_, _) => AddRootNode(),
                    svgImageCollection1["add"],
                    DXMenuItemPriority.Normal);

                DXMenuItem dx_AddChild = new(
                    Resources.Form_HierarchyList_AddChild,
                    (_, _) => AddChildNode(),
                    svgImageCollection1["child"],
                    DXMenuItemPriority.Normal);

                DXMenuItem dx_AddSibling = new(
                    Resources.Form_HierarchyList_AddSibling,
                    (_, _) => AddSiblingNode(),
                    svgImageCollection1["add"],
                    DXMenuItemPriority.Normal);

                DXMenuItem dx_Edit = new(
                    Resources.Common_Edit,
                    (_, _) => EditNode(),
                    svgImageCollection1["edit"],
                    DXMenuItemPriority.Normal);

                DXMenuItem dx_Delete = new(
                    Resources.Common_Delete,
                    (_, _) => DeleteFocusedNode(),
                    svgImageCollection1["delete"],
                    DXMenuItemPriority.Normal);

                DXMenuItem dx_Expand = new(
                    Resources.Form_HierarchyList_ExpandAll,
                    (_, _) => treeList1.ExpandAll(),
                    svgImageCollection1["expand"],
                    DXMenuItemPriority.Normal);

                DXMenuItem dx_Collapse = new(
                    Resources.Form_HierarchyList_CollapseAll,
                    (_, _) => treeList1.CollapseAll(),
                    svgImageCollection1["collapse"],
                    DXMenuItemPriority.Normal);

                e.Menu.Items.Add(dx_AddRoot);
                e.Menu.Items.Add(dx_AddChild);
                e.Menu.Items.Add(dx_AddSibling);
                e.Menu.Items.Add(dx_Edit);
                e.Menu.Items.Add(dx_Delete);
                e.Menu.Items.Add(dx_Expand);
                e.Menu.Items.Add(dx_Collapse);
            }
            else
            {
                DXMenuItem dx_AddRoot = new(
                    Resources.Form_HierarchyList_AddRoot,
                    (_, _) => AddRootNode(),
                    svgImageCollection1["add"],
                    DXMenuItemPriority.Normal);

                DXMenuItem dx_Refresh = new(
                    Resources.Common_Refresh,
                    (_, _) => LoadData(),
                    svgImageCollection1["refresh"],
                    DXMenuItemPriority.Normal);

                e.Menu.Items.Add(dx_AddRoot);
                e.Menu.Items.Add(dx_Refresh);
            }
        }

        private void BBI_AddRoot_ItemClick(object sender, ItemClickEventArgs e) => AddRootNode();
        private void BBI_AddChild_ItemClick(object sender, ItemClickEventArgs e) => AddChildNode();
        private void BBI_AddSibling_ItemClick(object sender, ItemClickEventArgs e) => AddSiblingNode();
        private void BBI_Edit_ItemClick(object sender, ItemClickEventArgs e) => EditNode();
        private void BBI_Delete_ItemClick(object sender, ItemClickEventArgs e) => DeleteFocusedNode();
        private void BBI_ExpandAll_ItemClick(object sender, ItemClickEventArgs e) => treeList1.ExpandAll();
        private void BBI_CollapseAll_ItemClick(object sender, ItemClickEventArgs e) => treeList1.CollapseAll();
        private void BBI_Refresh_ItemClick(object sender, ItemClickEventArgs e) => LoadData();

        private void btn_Select_Click(object sender, EventArgs e) => ConfirmSelection();

        private void btnClear_Click(object sender, EventArgs e)
        {
            DcHierarchy = null;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
