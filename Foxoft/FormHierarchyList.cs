using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Menu;
using DevExpress.XtraTreeList.Nodes;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormHierarchyList : XtraForm
    {
        private EfMethods efMethods = new();
        private subContext dbContext;

        public DcHierarchy DcHierarchy;

        public FormHierarchyList()
        {
            InitializeComponent();

            treeList1.GetStateImage += TreeList_GetStateImage;
        }

        public FormHierarchyList(string hierarchyCode)
            : this()
        {
            DcHierarchy = efMethods.SelectEntityById<DcHierarchy>(hierarchyCode);
        }

        private void TreeList_GetStateImage(object sender, GetStateImageEventArgs e)
        {
            e.NodeImageIndex = 0;
        }

        private void FormTreeView_Load(object sender, EventArgs e)
        {
            List<DcHierarchy> DcHierarchies = efMethods.SelectHierarchies();
            treeList1.DataSource = DcHierarchies;

            TreeListNode node = treeList1.FindNodeByFieldValue("HierarchyCode", DcHierarchy?.HierarchyCode);
            treeList1.FocusedNode = node;
            if (node is not null)
                node.Expanded = true;
        }

        private void FormTreeView_Activated(object sender, EventArgs e)
        {
            //AutoFocus FindPanel
            if (treeList1 is not null)
            {
                treeList1.FindPanelVisible = false;
                if (!treeList1.FindPanelVisible)
                    treeList1.BeginInvoke(new Action(treeList1.ShowFindPanel));
            }
        }

        private void treeList1_InitNewRow(object sender, TreeListInitNewRowEventArgs e)
        {
            string NewDocNum = efMethods.GetNextDocNum(false, "H", "HierarchyCode", "DcHierarchies", 4);
            e.SetValue(treeListCol_HierarchyCode, NewDocNum);
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            object HierarchyCode = e.Node?.GetValue(treeListCol_HierarchyCode);

            if (HierarchyCode is not null)
                DcHierarchy = efMethods.SelectEntityById<DcHierarchy>(HierarchyCode.ToString());
        }

        private void dx_AddChild_ItemClick(object sender, EventArgs e)
        {
            TreeListNode newNode = treeList1.AppendNode(null, treeList1.FocusedNode);
            //newNode.SetValue("HierarchyCode", "");
            treeList1.FocusedNode = newNode;

            treeList1.OptionsBehavior.Editable = true;
            treeList1.ShowEditor();
        }

        private void dx_Add_ItemClick(object sender, EventArgs e)
        {
            TreeListNode newNode = treeList1.AppendNode(null, treeList1.FocusedNode.ParentNode);
            treeList1.FocusedNode = newNode;

            treeList1.OptionsBehavior.Editable = true;
            treeList1.ShowEditor();
        }

        private void dx_Edit_ItemClick(object sender, EventArgs e)
        {
            treeList1.OptionsBehavior.Editable = true;
            treeList1.ShowEditor();
        }

        private void dx_Delete_ItemClick(object sender, EventArgs e)
        {
            string hierarchyCode = treeList1.FocusedNode.GetValue(treeListCol_HierarchyCode)?.ToString();

            if (!string.IsNullOrEmpty(hierarchyCode))
            {
                int result = efMethods.DeleteEntityById<DcHierarchy>(hierarchyCode);

                if (result > 0)
                    treeList1.DeleteNode(treeList1.FocusedNode);
            }
        }

        private void treeList1_HiddenEditor(object sender, EventArgs e)
        {
            treeList1.OptionsBehavior.Editable = false;
        }

        private void treeList1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.Menu is TreeListNodeMenu)
            {
                treeList1.FocusedNode = ((TreeListNodeMenu)e.Menu).Node;

                DXMenuItem dx_Edit = new("Dəyiş", dx_Edit_ItemClick, svgImageCollection1["edit"], DXMenuItemPriority.Normal);
                DXMenuItem dx_Add = new("Əlavə et", dx_Add_ItemClick, svgImageCollection1["add"], DXMenuItemPriority.Normal);
                DXMenuItem dx_AddChild = new("Uşaq əlavə et", dx_AddChild_ItemClick, svgImageCollection1["child"], DXMenuItemPriority.Normal);
                DXMenuItem dx_Delete = new("Sil", dx_Delete_ItemClick, svgImageCollection1["delete"], DXMenuItemPriority.Normal);

                e.Menu.Items.Add(dx_Add);
                e.Menu.Items.Add(dx_AddChild);
                e.Menu.Items.Add(dx_Edit);
                e.Menu.Items.Add(dx_Delete);

                if (treeList1.FocusedColumn == treeListCol_HierarchyCode)
                {
                    string hierarchyCode = treeList1.FocusedValue?.ToString();
                    if (!string.IsNullOrEmpty(hierarchyCode))
                    {
                        DcHierarchy dcHierarchy = efMethods.SelectEntityById<DcHierarchy>(hierarchyCode);
                        if (dcHierarchy is not null)
                            dx_Edit.Enabled = false;
                    }
                }
            }
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void treeList1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            string hierarchyCode = e.Node.GetValue(treeListCol_HierarchyCode)?.ToString();
            string hierarchyDesc = e.Node.GetValue(treeListCol_HierarchyDesc)?.ToString();

            if (!string.IsNullOrEmpty(hierarchyCode))
            {
                DcHierarchy = efMethods.SelectEntityById<DcHierarchy>(hierarchyCode);

                if (DcHierarchy == null)
                {
                    DcHierarchy = new() { HierarchyCode = hierarchyCode, HierarchyDesc = "Yeni", HierarchyLevel = treeList1.FocusedNode.Level, HierarchyParentCode = treeList1.FocusedNode.ParentNode?.GetValue(treeListCol_HierarchyCode)?.ToString() };
                    efMethods.InsertEntity(DcHierarchy);
                }

                if (!string.IsNullOrEmpty(hierarchyDesc))
                {
                    efMethods.UpdateHierarchyDesc(hierarchyCode, hierarchyDesc);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DcHierarchy = null;
            DialogResult = DialogResult.OK;
        }
    }
}
