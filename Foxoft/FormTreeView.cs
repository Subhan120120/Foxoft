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
    public partial class FormTreeView : XtraForm
    {
        private EfMethods efMethods = new();
        private subContext dbContext;

        public DcHierarchy DcHierarchy;

        public FormTreeView()
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

            //treeList1.Columns[treeList1.KeyFieldName].Visible = false;
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            object HierarchyCode = e.Node.GetValue(treeListCol_HierarchyCode);

            if (HierarchyCode is not null)
                DcHierarchy = efMethods.SelectHierarchy(HierarchyCode.ToString());
        }

        private void bbEdit_ItemClick(object sender, EventArgs e)
        {
            treeList1.OptionsBehavior.Editable = !treeList1.OptionsBehavior.Editable;
            treeList1.ShowEditor();
        }

        private void bbAddChild_ItemClick(object sender, EventArgs e)
        {
            TreeListNode newNode = treeList1.AppendNode(null, treeList1.FocusedNode);
            newNode.SetValue(0, "New Node");
            treeList1.OptionsBehavior.Editable = !treeList1.OptionsBehavior.Editable;
            treeList1.ShowEditor();
        }

        private void bbDelete_ItemClick(object sender, EventArgs e)
        {
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
                e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Dəyiş", bbEdit_ItemClick));
                e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Əlavə Et", bbAddChild_ItemClick));
                e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Sil", bbDelete_ItemClick));
            }
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
