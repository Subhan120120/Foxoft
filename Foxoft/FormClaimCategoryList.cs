using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using Foxoft.Models;

namespace Foxoft
{
    public partial class FormClaimCategoryList : XtraForm
    {
        private EfMethods efMethods = new();
        private string RoleCode;

        public DcClaimCategory DcClaimCategory;

        public FormClaimCategoryList()
        {
            InitializeComponent();

            treeList1.GetStateImage += TreeList_GetStateImage;

            // Enable multi-select with checkboxes
            treeList1.OptionsSelection.MultiSelect = true;
            treeList1.OptionsSelection.EnableAppearanceFocusedRow = false;

            RepositoryItemCheckEdit repoCheck = new RepositoryItemCheckEdit
            {
                AllowGrayed = false,             // enables indeterminate
                ValueChecked = true,            // maps to true
                ValueUnchecked = false,         // maps to false
                ValueGrayed = null              // maps to null
            };

            // Add an unbound checkbox column
            TreeListColumn checkBoxColumn = new TreeListColumn();
            checkBoxColumn.Caption = "Select";
            checkBoxColumn.FieldName = "IsSelected"; // Must match model property
            checkBoxColumn.ColumnEdit = repoCheck;
            checkBoxColumn.VisibleIndex = 1;
            checkBoxColumn.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.Boolean;
            treeList1.BestFitColumns();

            treeList1.Columns.Add(checkBoxColumn);

            treeList1.CellValueChanged += TreeList1_CellValueChanged;
        }

        public FormClaimCategoryList(string roleCode)
            : this()
        {
            RoleCode = roleCode;
        }

        private void TreeList_GetStateImage(object sender, GetStateImageEventArgs e)
        {
            if ((bool)e.Node.GetValue("IsCategory"))
                e.NodeImageIndex = 0;
            else
                e.NodeImageIndex = 6;
        }

        private void FormTreeView_Load(object sender, EventArgs e)
        {
            List<DcClaimCategoryViewModel> DcClaimCategories = efMethods.SelectDcClaimCategories(RoleCode);
            treeList1.DataSource = DcClaimCategories;
        }

        private void treeList1_InitNewRow(object sender, TreeListInitNewRowEventArgs e)
        {
            string NewDocNum = efMethods.GetNextDocNum(false, "", "CategoryId", "DcClaimCategories", 4);
            e.SetValue(treeListCol_CategoryId, NewDocNum);
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            object categoryId = e.Node?.GetValue(treeListCol_CategoryId);

            if (categoryId is not null)
                DcClaimCategory = efMethods.SelectEntityById<DcClaimCategory>(Convert.ToInt32(categoryId));
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
        }

        private void TreeList1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "IsSelected")
            {
                bool isChecked = Convert.ToBoolean(e.Value);
                TreeListNode node = e.Node;

                SetChildNodesChecked(node, isChecked);

                SetParentNodesChecked(node);
            }
        }

        private void SetChildNodesChecked(TreeListNode parentNode, bool isChecked)
        {
            foreach (TreeListNode child in parentNode.Nodes)
            {
                child.SetValue("IsSelected", isChecked);
                SetChildNodesChecked(child, isChecked);
            }
        }

        private void SetParentNodesChecked(TreeListNode childNode)
        {
            TreeListNode parent = childNode.ParentNode;
            while (parent != null)
            {
                bool allChecked = parent.Nodes.Cast<TreeListNode>().All(n => Convert.ToBoolean(n.GetValue("IsSelected")));
                parent.SetValue("IsSelected", allChecked);
                parent = parent.ParentNode;
            }
        }

        private void Btn_Claims_Click(object sender, EventArgs e)
        {
            FormCommonList<DcClaim> formCommonList = new FormCommonList<DcClaim>("", nameof(DcClaim.ClaimCode));
            formCommonList.ShowDialog();
        }


        private void Btn_Save_Click(object sender, EventArgs e)
        {
            SaveNodesToDb(treeList1.Nodes);
        }

        private void SaveNodesToDb(IEnumerable<TreeListNode> nodes)
        {
            foreach (TreeListNode child in nodes)
            {
                bool isCategory = (bool)child.GetValue("IsCategory");

                if (!isCategory)
                {
                    DcClaim dcClaim = efMethods.SelectDcClaimByIdentity(Convert.ToInt32(child.GetValue("CategoryId")) - 1000);
                    bool chckd = (bool)child.GetValue("IsSelected");

                    if (chckd)
                    {
                        if (!efMethods.TrRoleClaimExist(RoleCode, dcClaim.ClaimCode))
                        {
                            efMethods.InsertEntity(new TrRoleClaim()
                            {
                                RoleCode = RoleCode,
                                ClaimCode = dcClaim.ClaimCode
                            });
                        }
                    }
                    else
                    {
                        TrRoleClaim trRoleClaim = efMethods.SelectRoleClaim(RoleCode, dcClaim.ClaimCode);

                        if (trRoleClaim != null)
                            efMethods.DeleteEntity(trRoleClaim);
                    }
                }

                if (child.Nodes.Count > 0)
                {
                    SaveNodesToDb(child.Nodes);
                }
            }
        }

    }
}
