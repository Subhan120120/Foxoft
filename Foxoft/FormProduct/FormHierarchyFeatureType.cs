using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
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

        private readonly HashSet<AssignmentKey> originalAssignments = new();
        private readonly HashSet<AssignmentKey> workingAssignments = new();
        private List<DcFeatureType> allFeatureTypes = new();

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
            LoadDataFromDatabase();
        }

        private void LoadDataFromDatabase()
        {
            using subContext db = new();

            allFeatureTypes = db.DcFeatureTypes
                .AsNoTracking()
                .OrderBy(x => x.Order)
                .ThenBy(x => x.FeatureTypeName)
                .ToList();

            List<TrHierarchyFeatureType> dbAssignments = db.TrHierarchyFeatureTypes
                .AsNoTracking()
                .ToList();

            originalAssignments.Clear();
            workingAssignments.Clear();
            foreach (TrHierarchyFeatureType r in dbAssignments)
            {
                AssignmentKey key = new(r.HierarchyCode, r.FeatureTypeId);
                originalAssignments.Add(key);
                workingAssignments.Add(key);
            }

            LoadHierarchies();
            UpdateDirtyState();
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

        private bool HasChanges()
        {
            return !workingAssignments.SetEquals(originalAssignments);
        }

        private void UpdateDirtyState()
        {
            bool dirty = HasChanges();
            BBI_Save.Enabled = dirty;

            string baseCaption = Resources.Form_HierarchyFeatureType_Caption;
            Text = dirty ? $"{baseCaption} *" : baseCaption;

            if (dirty)
            {
                BSI_Status.Caption = Resources.Common_UnsavedChanges;
            }
            else
            {
                BSI_Status.Caption = Resources.Common_SavedSuccessfully;
            }
        }

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

            HashSet<int> featureTypeIdsWithHierarchies = workingAssignments
                .Select(x => x.FeatureTypeId)
                .ToHashSet();

            HashSet<int> assignedToCurrentHierarchy = new();
            if (!IsGlobalNode)
            {
                assignedToCurrentHierarchy = workingAssignments
                    .Where(x => string.Equals(x.HierarchyCode, currentHierarchyCode, StringComparison.OrdinalIgnoreCase))
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
            if (vm.IsSelected)
            {
                // Making it global: clear any category restrictions from workingAssignments
                workingAssignments.RemoveWhere(x => x.FeatureTypeId == vm.FeatureTypeId);

                vm.IsGlobal = true;
                vm.ScopeText = Resources.Form_HierarchyFeatureType_ScopeGlobal;

                UpdateDirtyState();
                UpdateStats();
            }
            else
            {
                // Removing from global: choose which category it should belong to
                RemoveFeatureFromGlobalWithPicker(vm, null);
            }
        }

        private void HandleSpecificCategoryCheckboxChange(HierarchyFeatureTypeViewModel vm)
        {
            if (vm.IsGlobal)
            {
                // User clicked a global feature in a specific category: offer to remove from global and assign to this category
                RemoveFeatureFromGlobalWithPicker(vm, currentHierarchyCode);
                return;
            }

            if (vm.IsSelected)
            {
                workingAssignments.Add(new AssignmentKey(currentHierarchyCode!, vm.FeatureTypeId));
                vm.IsSpecificallyAssigned = true;
                vm.ScopeText = Resources.Form_HierarchyFeatureType_ScopeSpecific;
            }
            else
            {
                workingAssignments.Remove(new AssignmentKey(currentHierarchyCode!, vm.FeatureTypeId));
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

            UpdateDirtyState();
            UpdateStats();
        }

        private void RemoveFeatureFromGlobalWithPicker(HierarchyFeatureTypeViewModel vm, string? suggestedHierarchyCode)
        {
            if (!string.IsNullOrEmpty(suggestedHierarchyCode) && suggestedHierarchyCode != GlobalHierarchyCode)
            {
                string question = string.Format(Resources.Form_HierarchyFeatureType_RemoveGlobalToThisCategoryConfirm, vm.FeatureTypeName, currentHierarchyDesc);
                DialogResult dr = XtraMessageBox.Show(this, question, Resources.Common_Confirm, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    workingAssignments.Add(new AssignmentKey(suggestedHierarchyCode, vm.FeatureTypeId));

                    LoadFeatureTypesForCurrentHierarchy();
                    UpdateDirtyState();
                    return;
                }
                else if (dr == DialogResult.Cancel)
                {
                    RevertCheckbox(vm, true);
                    return;
                }
                // If "No", proceed to open category picker below
            }

            XtraMessageBox.Show(this,
                string.Format(Resources.Form_HierarchyFeatureType_RemoveGlobalSelectCategory, vm.FeatureTypeName),
                Resources.Common_Info,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            using FormHierarchyList form = new();
            if (form.ShowDialog(this) == DialogResult.OK && form.DcHierarchy is not null)
            {
                string targetCode = form.DcHierarchy.HierarchyCode;
                workingAssignments.Add(new AssignmentKey(targetCode, vm.FeatureTypeId));

                LoadFeatureTypesForCurrentHierarchy();
                UpdateDirtyState();
            }
            else
            {
                RevertCheckbox(vm, true);
            }
        }

        private void RevertCheckbox(HierarchyFeatureTypeViewModel vm, bool value)
        {
            isInternalChange = true;
            vm.IsSelected = value;
            gridView1.RefreshRow(gridView1.FocusedRowHandle);
            isInternalChange = false;
        }

        private void BBI_Save_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveAllChanges();
        }

        private bool SaveAllChanges()
        {
            if (!HasChanges())
            {
                XtraMessageBox.Show(this, Resources.Common_NoChanges, Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            try
            {
                using subContext db = new();
                using var tx = db.Database.BeginTransaction();

                // 1. Assignments to remove
                List<AssignmentKey> toRemove = originalAssignments.Except(workingAssignments).ToList();
                if (toRemove.Count > 0)
                {
                    HashSet<AssignmentKey> toRemoveSet = toRemove.ToHashSet();
                    List<TrHierarchyFeatureType> dbRecords = db.TrHierarchyFeatureTypes.ToList();
                    List<TrHierarchyFeatureType> entitiesToDelete = dbRecords
                        .Where(x => toRemoveSet.Contains(new AssignmentKey(x.HierarchyCode, x.FeatureTypeId)))
                        .ToList();

                    if (entitiesToDelete.Count > 0)
                        db.TrHierarchyFeatureTypes.RemoveRange(entitiesToDelete);
                }

                // 2. Assignments to add
                List<AssignmentKey> toAdd = workingAssignments.Except(originalAssignments).ToList();
                if (toAdd.Count > 0)
                {
                    List<TrHierarchyFeatureType> entitiesToAdd = toAdd.Select(x => new TrHierarchyFeatureType
                    {
                        HierarchyCode = x.HierarchyCode,
                        FeatureTypeId = x.FeatureTypeId
                    }).ToList();

                    db.TrHierarchyFeatureTypes.AddRange(entitiesToAdd);
                }

                db.SaveChanges();
                tx.Commit();

                originalAssignments.Clear();
                originalAssignments.UnionWith(workingAssignments);

                UpdateDirtyState();
                XtraMessageBox.Show(this, Resources.Common_SavedSuccessfully, Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, Resources.Common_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void BBI_SelectAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(currentHierarchyCode) || featureTypeViewModels.Count == 0 || IsGlobalNode)
                return;

            foreach (HierarchyFeatureTypeViewModel vm in featureTypeViewModels)
            {
                if (!vm.IsGlobal)
                {
                    workingAssignments.Add(new AssignmentKey(currentHierarchyCode, vm.FeatureTypeId));
                    vm.IsSpecificallyAssigned = true;
                    vm.ScopeText = Resources.Form_HierarchyFeatureType_ScopeSpecific;
                }
                vm.IsSelected = true;
            }

            isInternalChange = true;
            ApplyFilterAndBind();
            isInternalChange = false;

            UpdateDirtyState();
            UpdateStats();
        }

        private void BBI_ClearSelection_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(currentHierarchyCode) || featureTypeViewModels.Count == 0 || IsGlobalNode)
                return;

            foreach (HierarchyFeatureTypeViewModel vm in featureTypeViewModels)
            {
                if (!vm.IsGlobal)
                {
                    workingAssignments.Remove(new AssignmentKey(currentHierarchyCode, vm.FeatureTypeId));
                    vm.IsSelected = false;
                    vm.IsSpecificallyAssigned = false;
                    vm.ScopeText = Resources.Form_HierarchyFeatureType_ScopeNone;
                }
            }

            isInternalChange = true;
            ApplyFilterAndBind();
            isInternalChange = false;

            UpdateDirtyState();
            UpdateStats();
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

            List<int> parentFeatureTypeIds = workingAssignments
                .Where(x => string.Equals(x.HierarchyCode, parentCode, StringComparison.OrdinalIgnoreCase))
                .Select(x => x.FeatureTypeId)
                .ToList();

            int addedCount = 0;
            foreach (int ftId in parentFeatureTypeIds)
            {
                if (workingAssignments.Add(new AssignmentKey(currentHierarchyCode, ftId)))
                {
                    addedCount++;
                }
            }

            LoadFeatureTypesForCurrentHierarchy();
            UpdateDirtyState();

            string msg = string.Format(Resources.Form_HierarchyFeatureType_CopiedCount, addedCount);
            XtraMessageBox.Show(this, msg, Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BBI_ManageFeatureTypes_ItemClick(object sender, ItemClickEventArgs e)
        {
            using FormCommonList<DcFeatureType> form = new("", nameof(DcFeatureType.FeatureTypeId));
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                using subContext db = new();
                allFeatureTypes = db.DcFeatureTypes
                    .AsNoTracking()
                    .OrderBy(x => x.Order)
                    .ThenBy(x => x.FeatureTypeName)
                    .ToList();

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
            if (HasChanges())
            {
                DialogResult dr = XtraMessageBox.Show(
                    this,
                    Resources.Common_UnsavedChangesQuestion,
                    Resources.Common_Confirm,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    if (!SaveAllChanges())
                        return;
                }
                else if (dr == DialogResult.Cancel)
                {
                    return;
                }
            }

            LoadDataFromDatabase();
        }

        private void FormHierarchyFeatureType_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!HasChanges())
                return;

            DialogResult dr = XtraMessageBox.Show(
                this,
                Resources.Common_UnsavedChangesQuestion,
                Resources.Common_Confirm,
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                bool success = SaveAllChanges();
                if (!success)
                    e.Cancel = true;
            }
            else if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
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

    public readonly struct AssignmentKey : IEquatable<AssignmentKey>
    {
        public string HierarchyCode { get; }
        public int FeatureTypeId { get; }

        public AssignmentKey(string hierarchyCode, int featureTypeId)
        {
            HierarchyCode = hierarchyCode ?? string.Empty;
            FeatureTypeId = featureTypeId;
        }

        public bool Equals(AssignmentKey other) =>
            string.Equals(HierarchyCode, other.HierarchyCode, StringComparison.OrdinalIgnoreCase) &&
            FeatureTypeId == other.FeatureTypeId;

        public override bool Equals(object? obj) =>
            obj is AssignmentKey other && Equals(other);

        public override int GetHashCode() =>
            HashCode.Combine(StringComparer.OrdinalIgnoreCase.GetHashCode(HierarchyCode), FeatureTypeId);
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
