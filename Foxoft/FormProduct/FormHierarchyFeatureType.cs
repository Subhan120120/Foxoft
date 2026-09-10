using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormHierarchyFeatureType : RibbonForm
    {
        private readonly EfMethods efMethods = new();
        private string? currentHierarchyCode;
        private string? currentHierarchyDesc;
        private List<HierarchyFeatureTypeViewModel> featureTypeViewModels = new();
        private bool isInternalChange;

        public FormHierarchyFeatureType()
        {
            InitializeComponent();

            Text = Resources.Form_HierarchyFeatureType_Caption;
            Load += FormHierarchyFeatureType_Load;
        }

        public FormHierarchyFeatureType(string hierarchyCode) : this()
        {
            currentHierarchyCode = hierarchyCode;
        }

        private void FormHierarchyFeatureType_Load(object? sender, EventArgs e)
        {
            LoadHierarchies();
        }

        private void LoadHierarchies()
        {
            List<DcHierarchy> hierarchies = efMethods.SelectHierarchies();
            treeListHierarchies.DataSource = hierarchies;

            if (!string.IsNullOrEmpty(currentHierarchyCode))
            {
                TreeListNode? node = treeListHierarchies.FindNodeByFieldValue(nameof(DcHierarchy.HierarchyCode), currentHierarchyCode);
                if (node is not null)
                {
                    treeListHierarchies.FocusedNode = node;
                    node.Expanded = true;
                    return;
                }
            }

            if (treeListHierarchies.Nodes.Count > 0)
            {
                treeListHierarchies.FocusedNode = treeListHierarchies.Nodes[0];
                treeListHierarchies.Nodes[0].Expanded = true;
            }
        }

        private void treeListHierarchies_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            object? codeObj = e.Node?.GetValue(treeListCol_HierarchyCode);
            object? descObj = e.Node?.GetValue(treeListCol_HierarchyDesc);

            currentHierarchyCode = codeObj?.ToString();
            currentHierarchyDesc = descObj?.ToString();

            UpdateHeaderInfo();
            LoadFeatureTypesForCurrentHierarchy();
        }

        private void UpdateHeaderInfo()
        {
            if (string.IsNullOrEmpty(currentHierarchyCode))
            {
                lblHierarchyTitle.Text = Resources.Form_HierarchyFeatureType_NoHierarchySelected;
                lblHierarchyStats.Text = string.Empty;
                BSI_HierarchyInfo.Caption = string.Empty;
                BSI_CountInfo.Caption = string.Empty;
                return;
            }

            lblHierarchyTitle.Text = $"<b>{currentHierarchyDesc}</b> <color=gray>({currentHierarchyCode})</color>";
            BSI_HierarchyInfo.Caption = $"{currentHierarchyDesc} ({currentHierarchyCode})";
        }

        private void LoadFeatureTypesForCurrentHierarchy()
        {
            if (string.IsNullOrEmpty(currentHierarchyCode))
            {
                featureTypeViewModels.Clear();
                myGridControl1.DataSource = null;
                UpdateStats();
                return;
            }

            using subContext db = new();
            List<DcFeatureType> allFeatureTypes = db.DcFeatureTypes
                .OrderBy(x => x.Order)
                .ThenBy(x => x.FeatureTypeName)
                .ToList();

            HashSet<int> assignedFeatureTypeIds = db.TrHierarchyFeatureTypes
                .Where(x => x.HierarchyCode == currentHierarchyCode)
                .Select(x => x.FeatureTypeId)
                .ToHashSet();

            featureTypeViewModels = allFeatureTypes.Select(ft => new HierarchyFeatureTypeViewModel
            {
                IsSelected = assignedFeatureTypeIds.Contains(ft.FeatureTypeId),
                FeatureTypeId = ft.FeatureTypeId,
                FeatureTypeName = ft.FeatureTypeName,
                Filterable = ft.Filterable,
                Order = ft.Order
            }).ToList();

            isInternalChange = true;
            ApplyFilterAndBind();
            isInternalChange = false;

            UpdateStats();
        }

        private void ApplyFilterAndBind()
        {
            if (BCI_ShowAssignedOnly.Checked)
                myGridControl1.DataSource = featureTypeViewModels.Where(x => x.IsSelected).ToList();
            else
                myGridControl1.DataSource = featureTypeViewModels.ToList();
        }

        private void UpdateStats()
        {
            int assignedCount = featureTypeViewModels.Count(x => x.IsSelected);
            int totalCount = featureTypeViewModels.Count;
            string statsText = string.Format(Resources.Form_HierarchyFeatureType_Stats, assignedCount, totalCount);

            lblHierarchyStats.Text = statsText;
            BSI_CountInfo.Caption = statsText;
        }

        private void repoCheckEditSelect_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.PostEditor();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (isInternalChange || e.Column != colIsSelected || string.IsNullOrEmpty(currentHierarchyCode))
                return;

            if (gridView1.GetRow(e.RowHandle) is HierarchyFeatureTypeViewModel vm)
            {
                using subContext db = new();
                if (vm.IsSelected)
                {
                    bool exists = db.TrHierarchyFeatureTypes.Any(x => x.HierarchyCode == currentHierarchyCode && x.FeatureTypeId == vm.FeatureTypeId);
                    if (!exists)
                    {
                        db.TrHierarchyFeatureTypes.Add(new TrHierarchyFeatureType
                        {
                            HierarchyCode = currentHierarchyCode,
                            FeatureTypeId = vm.FeatureTypeId
                        });
                        db.SaveChanges();
                    }
                }
                else
                {
                    TrHierarchyFeatureType? existing = db.TrHierarchyFeatureTypes.FirstOrDefault(x => x.HierarchyCode == currentHierarchyCode && x.FeatureTypeId == vm.FeatureTypeId);
                    if (existing is not null)
                    {
                        db.TrHierarchyFeatureTypes.Remove(existing);
                        db.SaveChanges();
                    }
                }

                HierarchyFeatureTypeViewModel? masterItem = featureTypeViewModels.FirstOrDefault(x => x.FeatureTypeId == vm.FeatureTypeId);
                if (masterItem is not null)
                    masterItem.IsSelected = vm.IsSelected;

                BSI_Status.Caption = Resources.Common_SavedSuccessfully;
                UpdateStats();
            }
        }

        private void BBI_SelectAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(currentHierarchyCode) || featureTypeViewModels.Count == 0)
                return;

            using subContext db = new();
            HashSet<int> existingIds = db.TrHierarchyFeatureTypes
                .Where(x => x.HierarchyCode == currentHierarchyCode)
                .Select(x => x.FeatureTypeId)
                .ToHashSet();

            foreach (HierarchyFeatureTypeViewModel vm in featureTypeViewModels)
            {
                if (!existingIds.Contains(vm.FeatureTypeId))
                {
                    db.TrHierarchyFeatureTypes.Add(new TrHierarchyFeatureType
                    {
                        HierarchyCode = currentHierarchyCode,
                        FeatureTypeId = vm.FeatureTypeId
                    });
                }
                vm.IsSelected = true;
            }
            db.SaveChanges();

            isInternalChange = true;
            ApplyFilterAndBind();
            isInternalChange = false;

            UpdateStats();
            BSI_Status.Caption = Resources.Common_SavedSuccessfully;
        }

        private void BBI_ClearSelection_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(currentHierarchyCode) || featureTypeViewModels.Count == 0)
                return;

            using subContext db = new();
            List<TrHierarchyFeatureType> existing = db.TrHierarchyFeatureTypes
                .Where(x => x.HierarchyCode == currentHierarchyCode)
                .ToList();

            if (existing.Count > 0)
            {
                db.TrHierarchyFeatureTypes.RemoveRange(existing);
                db.SaveChanges();
            }

            foreach (HierarchyFeatureTypeViewModel vm in featureTypeViewModels)
                vm.IsSelected = false;

            isInternalChange = true;
            ApplyFilterAndBind();
            isInternalChange = false;

            UpdateStats();
            BSI_Status.Caption = Resources.Common_SavedSuccessfully;
        }

        private void BBI_CopyFromParent_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(currentHierarchyCode))
                return;

            TreeListNode? focusedNode = treeListHierarchies.FocusedNode;
            TreeListNode? parentNode = focusedNode?.ParentNode;
            if (parentNode is null)
            {
                XtraMessageBox.Show(this, Resources.Form_HierarchyFeatureType_NoParent, Resources.Form_HierarchyFeatureType_Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string? parentCode = parentNode.GetValue(treeListCol_HierarchyCode)?.ToString();
            string? parentDesc = parentNode.GetValue(treeListCol_HierarchyDesc)?.ToString();

            if (string.IsNullOrEmpty(parentCode))
                return;

            string confirmMsg = string.Format(Resources.Form_HierarchyFeatureType_CopyConfirm, $"{parentDesc} ({parentCode})");
            if (XtraMessageBox.Show(this, confirmMsg, Resources.Common_Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using subContext db = new();
            List<int> parentFeatureTypeIds = db.TrHierarchyFeatureTypes
                .Where(x => x.HierarchyCode == parentCode)
                .Select(x => x.FeatureTypeId)
                .ToList();

            HashSet<int> currentFeatureTypeIds = db.TrHierarchyFeatureTypes
                .Where(x => x.HierarchyCode == currentHierarchyCode)
                .Select(x => x.FeatureTypeId)
                .ToHashSet();

            int addedCount = 0;
            foreach (int ftId in parentFeatureTypeIds)
            {
                if (!currentFeatureTypeIds.Contains(ftId))
                {
                    db.TrHierarchyFeatureTypes.Add(new TrHierarchyFeatureType
                    {
                        HierarchyCode = currentHierarchyCode,
                        FeatureTypeId = ftId
                    });
                    addedCount++;
                }
            }
            db.SaveChanges();

            LoadFeatureTypesForCurrentHierarchy();
            string successMsg = string.Format(Resources.Form_HierarchyFeatureType_CopiedCount, addedCount);
            BSI_Status.Caption = successMsg;
            XtraMessageBox.Show(this, successMsg, Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BBI_ManageFeatureTypes_ItemClick(object sender, ItemClickEventArgs e)
        {
            using FormCommonList<DcFeatureType> form = new("", nameof(DcFeatureType.FeatureTypeId));
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadFeatureTypesForCurrentHierarchy();
            }
        }

        private void BBI_ExpandAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            treeListHierarchies.ExpandAll();
        }

        private void BBI_CollapseAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            treeListHierarchies.CollapseAll();
        }

        private void BCI_ShowAssignedOnly_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            ApplyFilterAndBind();
        }

        private void BBI_Refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadHierarchies();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }

    public class HierarchyFeatureTypeViewModel
    {
        public bool IsSelected { get; set; }
        public int FeatureTypeId { get; set; }
        public string FeatureTypeName { get; set; } = string.Empty;
        public bool Filterable { get; set; }
        public int Order { get; set; }
    }
}
