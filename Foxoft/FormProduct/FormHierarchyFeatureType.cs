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
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormHierarchyFeatureType : RibbonForm
    {
        public const string GlobalHierarchyCode = "$GLOBAL$";

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
            List<DcHierarchy> dbHierarchies = efMethods.SelectHierarchies();

            List<DcHierarchy> hierarchies = new()
            {
                new DcHierarchy
                {
                    HierarchyCode = GlobalHierarchyCode,
                    HierarchyDesc = "🌐 " + Resources.Form_HierarchyFeatureType_AllHierarchiesGlobal,
                    HierarchyParentCode = null,
                    Order = -1000
                }
            };
            hierarchies.AddRange(dbHierarchies);

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

        private bool IsGlobalNode => currentHierarchyCode == GlobalHierarchyCode;

        private void UpdateHeaderInfo()
        {
            if (string.IsNullOrEmpty(currentHierarchyCode))
            {
                lblHierarchyTitle.Text = Resources.Form_HierarchyFeatureType_NoHierarchySelected;
                lblHierarchyStats.Text = string.Empty;
                BSI_HierarchyInfo.Caption = string.Empty;
                BSI_CountInfo.Caption = string.Empty;
                BBI_CopyFromParent.Enabled = false;
                return;
            }

            if (IsGlobalNode)
            {
                lblHierarchyTitle.Text = $"<b>🌐 {Resources.Form_HierarchyFeatureType_AllHierarchiesGlobal}</b>";
                BSI_HierarchyInfo.Caption = Resources.Form_HierarchyFeatureType_AllHierarchiesGlobal;
                BBI_CopyFromParent.Enabled = false;
            }
            else
            {
                lblHierarchyTitle.Text = $"<b>{currentHierarchyDesc}</b> <color=gray>({currentHierarchyCode})</color>";
                BSI_HierarchyInfo.Caption = $"{currentHierarchyDesc} ({currentHierarchyCode})";
                BBI_CopyFromParent.Enabled = true;
            }
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

            // Distinct feature type IDs that have at least one hierarchy assigned
            HashSet<int> featureTypeIdsWithHierarchies = db.TrHierarchyFeatureTypes
                .Select(x => x.FeatureTypeId)
                .Distinct()
                .ToHashSet();

            // Feature type IDs specifically assigned to current hierarchy
            HashSet<int> assignedToCurrentHierarchy = new();
            if (!IsGlobalNode)
            {
                assignedToCurrentHierarchy = db.TrHierarchyFeatureTypes
                    .Where(x => x.HierarchyCode == currentHierarchyCode)
                    .Select(x => x.FeatureTypeId)
                    .ToHashSet();
            }

            featureTypeViewModels = allFeatureTypes.Select(ft =>
            {
                bool isGlobal = !featureTypeIdsWithHierarchies.Contains(ft.FeatureTypeId);
                bool isSpecificallyAssigned = !IsGlobalNode && assignedToCurrentHierarchy.Contains(ft.FeatureTypeId);

                bool isSelected;
                string scopeText;

                if (IsGlobalNode)
                {
                    isSelected = isGlobal;
                    scopeText = isGlobal
                        ? Resources.Form_HierarchyFeatureType_ScopeGlobal
                        : Resources.Form_HierarchyFeatureType_ScopeSpecific;
                }
                else
                {
                    isSelected = isGlobal || isSpecificallyAssigned;
                    if (isGlobal)
                        scopeText = Resources.Form_HierarchyFeatureType_ScopeGlobal;
                    else if (isSpecificallyAssigned)
                        scopeText = Resources.Form_HierarchyFeatureType_ScopeSpecific;
                    else
                        scopeText = Resources.Form_HierarchyFeatureType_ScopeNone;
                }

                return new HierarchyFeatureTypeViewModel
                {
                    IsSelected = isSelected,
                    IsGlobal = isGlobal,
                    IsSpecificallyAssigned = isSpecificallyAssigned,
                    ScopeText = scopeText,
                    FeatureTypeId = ft.FeatureTypeId,
                    FeatureTypeName = ft.FeatureTypeName,
                    Filterable = ft.Filterable,
                    Order = ft.Order
                };
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
            if (IsGlobalNode)
            {
                int globalCount = featureTypeViewModels.Count(x => x.IsGlobal);
                int totalCount = featureTypeViewModels.Count;
                string statsText = string.Format(Resources.Form_HierarchyFeatureType_GlobalStats, globalCount, totalCount);

                lblHierarchyStats.Text = statsText;
                BSI_CountInfo.Caption = statsText;
            }
            else
            {
                int globalCount = featureTypeViewModels.Count(x => x.IsGlobal);
                int specificCount = featureTypeViewModels.Count(x => x.IsSpecificallyAssigned);
                int totalAssigned = globalCount + specificCount;
                int totalCount = featureTypeViewModels.Count;
                string statsText = string.Format(Resources.Form_HierarchyFeatureType_StatsDetail, totalAssigned, globalCount, specificCount, totalCount);

                lblHierarchyStats.Text = statsText;
                BSI_CountInfo.Caption = statsText;
            }
        }

        private void repoCheckEditSelect_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.PostEditor();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (isInternalChange || e.Column != colIsSelected || string.IsNullOrEmpty(currentHierarchyCode))
                return;

            if (gridView1.GetRow(e.RowHandle) is not HierarchyFeatureTypeViewModel vm)
                return;

            if (IsGlobalNode)
            {
                HandleGlobalNodeCheckboxChange(vm);
            }
            else
            {
                HandleSpecificCategoryCheckboxChange(vm);
            }
        }

        private void HandleGlobalNodeCheckboxChange(HierarchyFeatureTypeViewModel vm)
        {
            using subContext db = new();

            if (vm.IsSelected)
            {
                // Making it global: clear any category restrictions
                List<TrHierarchyFeatureType> existing = db.TrHierarchyFeatureTypes
                    .Where(x => x.FeatureTypeId == vm.FeatureTypeId)
                    .ToList();

                if (existing.Count > 0)
                {
                    db.TrHierarchyFeatureTypes.RemoveRange(existing);
                    db.SaveChanges();
                }

                vm.IsGlobal = true;
                vm.ScopeText = Resources.Form_HierarchyFeatureType_ScopeGlobal;

                string msg = string.Format(Resources.Form_HierarchyFeatureType_MadeGlobal, vm.FeatureTypeName);
                BSI_Status.Caption = msg;
            }
            else
            {
                // Cannot uncheck a global feature without assigning it to a category
                XtraMessageBox.Show(this,
                    "Xüsusiyyət tipini qloballıqdan çıxarmaq üçün sol tərəfdəki ağacdan onu aid etmək istədiyiniz konkret kateqoriyaya keçib orada seçin.",
                    Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);

                isInternalChange = true;
                vm.IsSelected = true;
                gridView1.RefreshRow(gridView1.FocusedRowHandle);
                isInternalChange = false;
                return;
            }

            UpdateStats();
        }

        private void HandleSpecificCategoryCheckboxChange(HierarchyFeatureTypeViewModel vm)
        {
            if (vm.IsGlobal)
            {
                // User clicked a global feature in a specific category
                XtraMessageBox.Show(this,
                    Resources.Form_HierarchyFeatureType_GlobalInfo,
                    Resources.Common_Info,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                isInternalChange = true;
                vm.IsSelected = true;
                gridView1.RefreshRow(gridView1.FocusedRowHandle);
                isInternalChange = false;
                return;
            }

            using subContext db = new();

            if (vm.IsSelected)
            {
                bool exists = db.TrHierarchyFeatureTypes.Any(x => x.HierarchyCode == currentHierarchyCode && x.FeatureTypeId == vm.FeatureTypeId);
                if (!exists)
                {
                    db.TrHierarchyFeatureTypes.Add(new TrHierarchyFeatureType
                    {
                        HierarchyCode = currentHierarchyCode!,
                        FeatureTypeId = vm.FeatureTypeId
                    });
                    db.SaveChanges();
                }

                vm.IsSpecificallyAssigned = true;
                vm.ScopeText = Resources.Form_HierarchyFeatureType_ScopeSpecific;
            }
            else
            {
                TrHierarchyFeatureType? existing = db.TrHierarchyFeatureTypes
                    .FirstOrDefault(x => x.HierarchyCode == currentHierarchyCode && x.FeatureTypeId == vm.FeatureTypeId);

                if (existing is not null)
                {
                    db.TrHierarchyFeatureTypes.Remove(existing);
                    db.SaveChanges();
                }

                vm.IsSpecificallyAssigned = false;
                vm.ScopeText = Resources.Form_HierarchyFeatureType_ScopeNone;
            }

            HierarchyFeatureTypeViewModel? masterItem = featureTypeViewModels.FirstOrDefault(x => x.FeatureTypeId == vm.FeatureTypeId);
            if (masterItem is not null)
            {
                masterItem.IsSelected = vm.IsSelected;
                masterItem.IsSpecificallyAssigned = vm.IsSpecificallyAssigned;
                masterItem.ScopeText = vm.ScopeText;
            }

            BSI_Status.Caption = Resources.Common_SavedSuccessfully;
            UpdateStats();
        }

        private void BBI_MakeGlobal_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRow() is not HierarchyFeatureTypeViewModel vm)
                return;

            if (vm.IsGlobal)
            {
                XtraMessageBox.Show(this,
                    Resources.Form_HierarchyFeatureType_GlobalInfo,
                    Resources.Common_Info,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string confirmMsg = string.Format(Resources.Form_HierarchyFeatureType_MakeGlobalConfirm, vm.FeatureTypeName);
            if (XtraMessageBox.Show(this, confirmMsg, Resources.Common_Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using subContext db = new();
            List<TrHierarchyFeatureType> existing = db.TrHierarchyFeatureTypes
                .Where(x => x.FeatureTypeId == vm.FeatureTypeId)
                .ToList();

            if (existing.Count > 0)
            {
                db.TrHierarchyFeatureTypes.RemoveRange(existing);
                db.SaveChanges();
            }

            LoadFeatureTypesForCurrentHierarchy();

            string successMsg = string.Format(Resources.Form_HierarchyFeatureType_MadeGlobal, vm.FeatureTypeName);
            BSI_Status.Caption = successMsg;
            XtraMessageBox.Show(this, successMsg, Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BBI_SelectAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(currentHierarchyCode) || featureTypeViewModels.Count == 0 || IsGlobalNode)
                return;

            using subContext db = new();
            HashSet<int> existingIds = db.TrHierarchyFeatureTypes
                .Where(x => x.HierarchyCode == currentHierarchyCode)
                .Select(x => x.FeatureTypeId)
                .ToHashSet();

            foreach (HierarchyFeatureTypeViewModel vm in featureTypeViewModels)
            {
                if (!vm.IsGlobal && !existingIds.Contains(vm.FeatureTypeId))
                {
                    db.TrHierarchyFeatureTypes.Add(new TrHierarchyFeatureType
                    {
                        HierarchyCode = currentHierarchyCode,
                        FeatureTypeId = vm.FeatureTypeId
                    });
                    vm.IsSpecificallyAssigned = true;
                    vm.ScopeText = Resources.Form_HierarchyFeatureType_ScopeSpecific;
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
            if (string.IsNullOrEmpty(currentHierarchyCode) || featureTypeViewModels.Count == 0 || IsGlobalNode)
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
            {
                if (!vm.IsGlobal)
                {
                    vm.IsSelected = false;
                    vm.IsSpecificallyAssigned = false;
                    vm.ScopeText = Resources.Form_HierarchyFeatureType_ScopeNone;
                }
            }

            isInternalChange = true;
            ApplyFilterAndBind();
            isInternalChange = false;

            UpdateStats();
            BSI_Status.Caption = Resources.Common_SavedSuccessfully;
        }

        private void BBI_CopyFromParent_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(currentHierarchyCode) || IsGlobalNode)
                return;

            TreeListNode? focusedNode = treeListHierarchies.FocusedNode;
            TreeListNode? parentNode = focusedNode?.ParentNode;
            if (parentNode is null || parentNode.GetValue(treeListCol_HierarchyCode)?.ToString() == GlobalHierarchyCode)
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

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column == colScope)
            {
                if (gridView1.GetRow(e.RowHandle) is HierarchyFeatureTypeViewModel vm)
                {
                    if (vm.IsGlobal)
                    {
                        e.Appearance.ForeColor = Color.ForestGreen;
                        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                    }
                    else if (vm.IsSpecificallyAssigned)
                    {
                        e.Appearance.ForeColor = Color.DodgerBlue;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Gray;
                    }
                }
            }
        }
    }

    public class HierarchyFeatureTypeViewModel
    {
        public bool IsSelected { get; set; }
        public bool IsGlobal { get; set; }
        public bool IsSpecificallyAssigned { get; set; }
        public string ScopeText { get; set; } = string.Empty;
        public int FeatureTypeId { get; set; }
        public string FeatureTypeName { get; set; } = string.Empty;
        public bool Filterable { get; set; }
        public int Order { get; set; }
    }
}
