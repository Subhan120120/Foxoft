using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Menu;
using DevExpress.XtraTreeList.Nodes;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void TreeList_GetStateImage(object sender, GetStateImageEventArgs e)
        {
            e.NodeImageIndex = 0;
        }

        private void FormTreeView_Load(object sender, EventArgs e)
        {
            List<DcHierarchy> DcHierarchies = efMethods.SelectHierarchies();
            treeList1.DataSource = DcHierarchies;
        }

        private void treeList1_InitNewRow(object sender, TreeListInitNewRowEventArgs e)
        {
            string NewDocNum = efMethods.GetNextDocNum(false, "H", "HierarchyCode", "DcHierarchies", 4);
            e.SetValue(treeListCol_HierarchyCode, NewDocNum);
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            object HierarchyCode = e.Node.GetValue(treeListCol_HierarchyCode);

            if (HierarchyCode is not null)
                DcHierarchy = efMethods.SelectHierarchy(HierarchyCode.ToString());
        }

        private void bbAddChild_ItemClick(object sender, EventArgs e)
        {
            TreeListNode newNode = treeList1.AppendNode(null, treeList1.FocusedNode);
            //newNode.SetValue("HierarchyCode", "");
            treeList1.FocusedNode = newNode;

            treeList1.OptionsBehavior.Editable = true;
            treeList1.ShowEditor();
        }

        private void bbAdd_ItemClick(object sender, EventArgs e)
        {
            TreeListNode newNode = treeList1.AppendNode(null, treeList1.FocusedNode.ParentNode);
            treeList1.FocusedNode = newNode;

            treeList1.OptionsBehavior.Editable = true;
            treeList1.ShowEditor();
        }

        private void bbEdit_ItemClick(object sender, EventArgs e)
        {
            treeList1.OptionsBehavior.Editable = true;
            treeList1.ShowEditor();
        }

        private void bbDelete_ItemClick(object sender, EventArgs e)
        {
            string hierarchyCode = treeList1.FocusedNode.GetValue(treeListCol_HierarchyCode)?.ToString();

            int result = efMethods.DeleteHierarchy(hierarchyCode);

            if (result > 0)
                treeList1.DeleteNode(treeList1.FocusedNode);
        }

        private void treeList1_HiddenEditor(object sender, System.EventArgs e)
        {
            treeList1.OptionsBehavior.Editable = false;
        }

        private void treeList1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.Menu is TreeListNodeMenu)
            {
                treeList1.FocusedNode = ((TreeListNodeMenu)e.Menu).Node;

                e.Menu.Items.Add(new DXMenuItem("Əlavə et", bbAdd_ItemClick, svgImageCollection1["add"], DXMenuItemPriority.Normal));
                e.Menu.Items.Add(new DXMenuItem("Uşaq əlavə et", bbAddChild_ItemClick, svgImageCollection1["child"], DXMenuItemPriority.Normal));
                e.Menu.Items.Add(new DXMenuItem("Dəyiş", bbEdit_ItemClick, svgImageCollection1["edit"], DXMenuItemPriority.Normal));
                e.Menu.Items.Add(new DXMenuItem("Sil", bbDelete_ItemClick, svgImageCollection1["delete"], DXMenuItemPriority.Normal));
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
                DcHierarchy = efMethods.SelectHierarchy(hierarchyCode);

                if (DcHierarchy == null)
                {
                    DcHierarchy = new() { HierarchyCode = hierarchyCode, HierarchyDesc = "Yeni", HierarchyLevel = treeList1.FocusedNode.Level, HierarchyParentCode = treeList1.FocusedNode.ParentNode?.GetValue(treeListCol_HierarchyCode)?.ToString() };
                    efMethods.InsertHierarchy(DcHierarchy);
                }

                if (!string.IsNullOrEmpty(hierarchyCode))
                {
                    efMethods.UpdateHierarchyDesc(hierarchyCode, hierarchyDesc);
                }
            }
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
    }
}
