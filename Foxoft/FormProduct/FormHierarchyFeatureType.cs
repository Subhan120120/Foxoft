using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList.Nodes;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormHierarchyFeatureType : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly List<DcHierarchy> _hierarchies = new();
        private readonly List<DcFeatureType> _featureTypes = new();
        private HashSet<(string HierarchyCode, int FeatureTypeId)> _assignedLinks = new();
        private HashSet<int> _globalFeatureTypeIds = new();
        private readonly HashSet<int> _deletedFeatureTypeIds = new();
        private readonly BindingList<HierarchyFeatureTypeItem> _gridItems = new();

        private string? _currentHierarchyCode = null;
        private bool _isDirty = false;
        private bool _isSyncing = false;
        private int _nextTempId = -1;

        public FormHierarchyFeatureType()
        {
            InitializeComponent();
        }

        private void FormHierarchyFeatureType_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            _isSyncing = true;
            try
            {
                using subContext db = new();

                _hierarchies.Clear();
                _hierarchies.AddRange(db.DcHierarchies.OrderBy(x => x.Order).ToList());

                _featureTypes.Clear();
                _featureTypes.AddRange(db.DcFeatureTypes.OrderBy(x => x.Order).ToList());

                List<TrHierarchyFeatureType> links = db.TrHierarchyFeatureTypes.ToList();
                _assignedLinks = new HashSet<(string HierarchyCode, int FeatureTypeId)>(
                    links.Select(l => (l.HierarchyCode, l.FeatureTypeId))
                );

                HashSet<int> linkedIds = links.Select(l => l.FeatureTypeId).ToHashSet();
                _globalFeatureTypeIds = new HashSet<int>(
                    _featureTypes.Where(ft => !linkedIds.Contains(ft.FeatureTypeId)).Select(ft => ft.FeatureTypeId)
                );

                _deletedFeatureTypeIds.Clear();
                _isDirty = false;

                PopulateHierarchyTree();
            }
            finally
            {
                _isSyncing = false;
            }

            LoadGridForCurrentHierarchy();
        }

        private void PopulateHierarchyTree()
        {
            List<HierarchyTreeItem> treeItems = new()
            {
                new HierarchyTreeItem
                {
                    HierarchyCode = "__GLOBAL__",
                    HierarchyDesc = $"🌐 {Resources.Form_HierarchyFeatureType_GlobalFeatures}",
                    HierarchyParentCode = null
                }
            };

            foreach (DcHierarchy h in _hierarchies)
            {
                treeItems.Add(new HierarchyTreeItem
                {
                    HierarchyCode = h.HierarchyCode,
                    HierarchyDesc = h.HierarchyDesc,
                    HierarchyParentCode = h.HierarchyParentCode
                });
            }

            treeListHierarchy.DataSource = treeItems;
            treeListHierarchy.ExpandAll();

            TreeListNode? targetNode = null;
            if (!string.IsNullOrEmpty(_currentHierarchyCode))
                targetNode = treeListHierarchy.FindNodeByFieldValue("HierarchyCode", _currentHierarchyCode);

            if (targetNode == null)
                targetNode = treeListHierarchy.FindNodeByFieldValue("HierarchyCode", "__GLOBAL__");

            if (targetNode != null)
                treeListHierarchy.FocusedNode = targetNode;
        }

        private void treeListHierarchy_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (_isSyncing)
                return;

            SyncGridToMemory();

            TreeListNode? node = e.Node;
            if (node == null)
                return;

            string code = node.GetValue(treeColHierarchyCode)?.ToString() ?? string.Empty;
            string desc = node.GetValue(treeColHierarchyDesc)?.ToString() ?? string.Empty;

            if (code == "__GLOBAL__")
            {
                _currentHierarchyCode = null;
                lblSelectedHierarchy.Text = $"🌐 {Resources.Form_HierarchyFeatureType_GlobalFeatures}";
            }
            else
            {
                _currentHierarchyCode = code;
                lblSelectedHierarchy.Text = $"📁 {desc} ({code})";
            }

            LoadGridForCurrentHierarchy();
        }

        private void LoadGridForCurrentHierarchy()
        {
            _isSyncing = true;
            try
            {
                _gridItems.Clear();

                List<DcFeatureType> activeFts = _featureTypes
                    .Where(x => !_deletedFeatureTypeIds.Contains(x.FeatureTypeId))
                    .OrderBy(x => x.Order)
                    .ToList();

                foreach (DcFeatureType ft in activeFts)
                {
                    bool isGlobal = _globalFeatureTypeIds.Contains(ft.FeatureTypeId);
                    bool isAssigned = isGlobal || (!string.IsNullOrEmpty(_currentHierarchyCode) && _assignedLinks.Contains((_currentHierarchyCode, ft.FeatureTypeId)));

                    _gridItems.Add(new HierarchyFeatureTypeItem
                    {
                        FeatureTypeId = ft.FeatureTypeId,
                        FeatureTypeName = ft.FeatureTypeName,
                        Order = ft.Order,
                        Filterable = ft.Filterable,
                        IsGlobal = isGlobal,
                        IsAssigned = isAssigned
                    });
                }

                bindingSource1.DataSource = _gridItems;
                ApplySelectedFilter();
                gridView1.BestFitColumns();
            }
            finally
            {
                _isSyncing = false;
            }
        }

        private void BBI_FilterSelected_ItemClick(object sender, ItemClickEventArgs e)
        {
            ApplySelectedFilter();
        }

        private void ApplySelectedFilter()
        {
            if (BBI_FilterSelected.Down)
            {
                if (string.IsNullOrEmpty(_currentHierarchyCode))
                {
                    gridView1.ActiveFilterString = "[IsGlobal] = True";
                }
                else
                {
                    gridView1.ActiveFilterString = "[IsAssigned] = True";
                }
            }
            else
            {
                gridView1.ActiveFilterString = string.Empty;
            }
        }

        private void SyncGridToMemory()
        {
            foreach (HierarchyFeatureTypeItem item in _gridItems)
            {
                DcFeatureType? ft = _featureTypes.FirstOrDefault(x => x.FeatureTypeId == item.FeatureTypeId);
                if (ft != null)
                {
                    ft.FeatureTypeName = item.FeatureTypeName;
                    ft.Order = item.Order;
                    ft.Filterable = item.Filterable;
                }
            }
        }

        private void repoImageCombo_Scope_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.PostEditor();
            HierarchyFeatureTypeItem? item = gridView1.GetFocusedRow() as HierarchyFeatureTypeItem;
            if (item == null)
                return;

            HandleScopeChanged(item);
        }

        private void HandleScopeChanged(HierarchyFeatureTypeItem item)
        {
            switch (item.Scope)
            {
                case HierarchyFeatureScope.Global:
                    MakeItemGlobal(item);
                    break;

                case HierarchyFeatureScope.Assigned:
                    if (string.IsNullOrEmpty(_currentHierarchyCode))
                    {
                        using FormHierarchyList form = new();
                        if (form.ShowDialog(this) == DialogResult.OK && form.DcHierarchy != null)
                        {
                            string targetHierarchy = form.DcHierarchy.HierarchyCode;
                            _globalFeatureTypeIds.Remove(item.FeatureTypeId);
                            _assignedLinks.Add((targetHierarchy, item.FeatureTypeId));
                            item.IsGlobal = false;
                            item.IsAssigned = false;
                            _isDirty = true;
                        }
                        else
                        {
                            item.IsGlobal = true;
                            item.IsAssigned = true;
                        }
                    }
                    else
                    {
                        _globalFeatureTypeIds.Remove(item.FeatureTypeId);
                        _assignedLinks.Add((_currentHierarchyCode, item.FeatureTypeId));
                        item.IsGlobal = false;
                        item.IsAssigned = true;
                        _isDirty = true;
                    }
                    break;

                case HierarchyFeatureScope.NotAssigned:
                    if (string.IsNullOrEmpty(_currentHierarchyCode))
                    {
                        RemoveItemFromGlobal(item);
                    }
                    else
                    {
                        if (_globalFeatureTypeIds.Contains(item.FeatureTypeId))
                        {
                            _globalFeatureTypeIds.Remove(item.FeatureTypeId);
                            item.IsGlobal = false;
                            item.IsAssigned = false;
                            _isDirty = true;
                        }
                        else
                        {
                            _assignedLinks.Remove((_currentHierarchyCode, item.FeatureTypeId));
                            item.IsAssigned = false;
                            item.IsGlobal = false;
                            _isDirty = true;
                        }
                    }
                    break;
            }

            if (BBI_FilterSelected.Down)
                ApplySelectedFilter();

            gridView1.RefreshRow(gridView1.FocusedRowHandle);
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && gridView1.FocusedColumn == colScope)
            {
                HierarchyFeatureTypeItem? item = gridView1.GetFocusedRow() as HierarchyFeatureTypeItem;
                if (item != null)
                {
                    if (item.IsGlobal)
                    {
                        RemoveItemFromGlobal(item);
                    }
                    else if (item.IsAssigned)
                    {
                        item.Scope = HierarchyFeatureScope.NotAssigned;
                        HandleScopeChanged(item);
                    }
                    else
                    {
                        item.Scope = HierarchyFeatureScope.Assigned;
                        HandleScopeChanged(item);
                    }
                    e.Handled = true;
                }
            }
        }

        private void MakeItemGlobal(HierarchyFeatureTypeItem item)
        {
            item.IsGlobal = true;
            item.IsAssigned = true;

            _globalFeatureTypeIds.Add(item.FeatureTypeId);
            _assignedLinks.RemoveWhere(l => l.FeatureTypeId == item.FeatureTypeId);

            _isDirty = true;
            if (BBI_FilterSelected.Down)
                ApplySelectedFilter();
            gridView1.RefreshRow(gridView1.FocusedRowHandle);
        }

        private void RemoveItemFromGlobal(HierarchyFeatureTypeItem item)
        {
            string? targetHierarchy = _currentHierarchyCode;

            if (string.IsNullOrEmpty(targetHierarchy))
            {
                using FormHierarchyList form = new();
                if (form.ShowDialog(this) == DialogResult.OK && form.DcHierarchy != null)
                {
                    targetHierarchy = form.DcHierarchy.HierarchyCode;
                }
                else
                {
                    // Revert back to global if canceled
                    item.IsGlobal = true;
                    item.IsAssigned = true;
                    gridView1.RefreshRow(gridView1.FocusedRowHandle);
                    return;
                }
            }

            item.IsGlobal = false;
            _globalFeatureTypeIds.Remove(item.FeatureTypeId);
            _assignedLinks.Add((targetHierarchy, item.FeatureTypeId));

            item.IsAssigned = (!string.IsNullOrEmpty(_currentHierarchyCode) && _currentHierarchyCode == targetHierarchy);

            _isDirty = true;
            if (BBI_FilterSelected.Down)
                ApplySelectedFilter();
            gridView1.RefreshRow(gridView1.FocusedRowHandle);
        }


        private void BBI_FeatureTypeAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            int tempId = _nextTempId--;
            bool isGlobal = string.IsNullOrEmpty(_currentHierarchyCode);

            int maxOrder = _featureTypes.Count > 0 ? _featureTypes.Max(x => x.Order) + 10 : 10;
            DcFeatureType newFt = new()
            {
                FeatureTypeId = tempId,
                FeatureTypeName = Resources.Form_HierarchyList_NewDesc,
                Order = maxOrder,
                Filterable = true
            };

            _featureTypes.Add(newFt);

            if (isGlobal)
            {
                _globalFeatureTypeIds.Add(tempId);
            }
            else if (!string.IsNullOrEmpty(_currentHierarchyCode))
            {
                _assignedLinks.Add((_currentHierarchyCode, tempId));
            }

            _isDirty = true;
            LoadGridForCurrentHierarchy();

            int rowHandle = gridView1.LocateByValue("FeatureTypeId", tempId);
            if (rowHandle >= 0)
            {
                gridView1.FocusedRowHandle = rowHandle;
                gridView1.FocusedColumn = colFeatureTypeName;
                gridView1.ShowEditor();
            }
        }

        private void BBI_Delete_ItemClick(object sender, ItemClickEventArgs e)
        {
            HierarchyFeatureTypeItem? item = gridView1.GetFocusedRow() as HierarchyFeatureTypeItem;
            if (item == null)
                return;

            DialogResult confirm = XtraMessageBox.Show(
                Resources.Form_HierarchyFeatureType_ConfirmDelete,
                Text,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            if (item.FeatureTypeId > 0)
                _deletedFeatureTypeIds.Add(item.FeatureTypeId);

            _featureTypes.RemoveAll(x => x.FeatureTypeId == item.FeatureTypeId);
            _globalFeatureTypeIds.Remove(item.FeatureTypeId);
            _assignedLinks.RemoveWhere(l => l.FeatureTypeId == item.FeatureTypeId);

            _isDirty = true;
            LoadGridForCurrentHierarchy();
        }

        private void BBI_Save_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveAll();
        }

        private bool SaveAll()
        {
            gridView1.PostEditor();
            gridView1.UpdateCurrentRow();
            SyncGridToMemory();

            if (_featureTypes.Any(x => !_deletedFeatureTypeIds.Contains(x.FeatureTypeId) && string.IsNullOrWhiteSpace(x.FeatureTypeName)))
            {
                XtraMessageBox.Show(Resources.Validation_Required, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                using subContext db = new();

                // 1. Process deletions
                foreach (int id in _deletedFeatureTypeIds)
                {
                    DcFeatureType? dbFt = db.DcFeatureTypes
                        .Include(x => x.TrHierarchyFeatureTypes)
                        .FirstOrDefault(x => x.FeatureTypeId == id);

                    if (dbFt != null)
                    {
                        db.TrHierarchyFeatureTypes.RemoveRange(dbFt.TrHierarchyFeatureTypes);
                        db.DcFeatureTypes.Remove(dbFt);
                    }
                }

                // 2. Process updates and new insertions
                Dictionary<int, int> tempIdMap = new();
                foreach (DcFeatureType ft in _featureTypes.Where(x => !_deletedFeatureTypeIds.Contains(x.FeatureTypeId)))
                {
                    if (ft.FeatureTypeId < 0)
                    {
                        DcFeatureType newFt = new()
                        {
                            FeatureTypeName = ft.FeatureTypeName.Trim(),
                            Order = ft.Order,
                            Filterable = ft.Filterable
                        };
                        db.DcFeatureTypes.Add(newFt);
                        db.SaveChanges(); // get identity
                        tempIdMap[ft.FeatureTypeId] = newFt.FeatureTypeId;
                    }
                    else
                    {
                        DcFeatureType? existing = db.DcFeatureTypes.Find(ft.FeatureTypeId);
                        if (existing != null)
                        {
                            existing.FeatureTypeName = ft.FeatureTypeName.Trim();
                            existing.Order = ft.Order;
                            existing.Filterable = ft.Filterable;
                        }
                    }
                }

                // Remap temporary IDs
                foreach (KeyValuePair<int, int> kvp in tempIdMap)
                {
                    int tempId = kvp.Key;
                    int realId = kvp.Value;
                    DcFeatureType ft = _featureTypes.First(x => x.FeatureTypeId == tempId);
                    ft.FeatureTypeId = realId;

                    if (_globalFeatureTypeIds.Remove(tempId))
                        _globalFeatureTypeIds.Add(realId);

                    List<(string HierarchyCode, int FeatureTypeId)> oldLinks = _assignedLinks
                        .Where(x => x.FeatureTypeId == tempId)
                        .ToList();

                    foreach (var l in oldLinks)
                    {
                        _assignedLinks.Remove(l);
                        _assignedLinks.Add((l.HierarchyCode, realId));
                    }
                }

                // 3. Sync TrHierarchyFeatureTypes
                // Remove all links for global feature types (0 links = global)
                foreach (int globalId in _globalFeatureTypeIds)
                {
                    List<TrHierarchyFeatureType> existingLinks = db.TrHierarchyFeatureTypes
                        .Where(x => x.FeatureTypeId == globalId)
                        .ToList();

                    if (existingLinks.Count > 0)
                        db.TrHierarchyFeatureTypes.RemoveRange(existingLinks);
                }

                // For non-global feature types, sync assigned hierarchies
                List<int> activeNonGlobalIds = _featureTypes
                    .Where(x => !_deletedFeatureTypeIds.Contains(x.FeatureTypeId) && !_globalFeatureTypeIds.Contains(x.FeatureTypeId))
                    .Select(x => x.FeatureTypeId)
                    .ToList();

                foreach (int ftId in activeNonGlobalIds)
                {
                    List<TrHierarchyFeatureType> currentDbLinks = db.TrHierarchyFeatureTypes
                        .Where(x => x.FeatureTypeId == ftId)
                        .ToList();

                    HashSet<string> targetHierarchies = _assignedLinks
                        .Where(x => x.FeatureTypeId == ftId)
                        .Select(x => x.HierarchyCode)
                        .ToHashSet();

                    List<TrHierarchyFeatureType> toRemove = currentDbLinks
                        .Where(x => !targetHierarchies.Contains(x.HierarchyCode))
                        .ToList();

                    if (toRemove.Count > 0)
                        db.TrHierarchyFeatureTypes.RemoveRange(toRemove);

                    HashSet<string> existingCodes = currentDbLinks
                        .Select(x => x.HierarchyCode)
                        .ToHashSet();

                    foreach (string hCode in targetHierarchies)
                    {
                        if (!existingCodes.Contains(hCode))
                        {
                            db.TrHierarchyFeatureTypes.Add(new TrHierarchyFeatureType
                            {
                                HierarchyCode = hCode,
                                FeatureTypeId = ftId
                            });
                        }
                    }
                }

                db.SaveChanges();
                _isDirty = false;

                XtraMessageBox.Show(
                    Resources.Common_SavedSuccessfully,
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void BBI_Update_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_isDirty)
            {
                DialogResult dr = XtraMessageBox.Show(
                    Resources.Form_HierarchyFeatureType_ConfirmSaveChanges,
                    Text,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    if (!SaveAll())
                        return;
                }
                else if (dr == DialogResult.Cancel)
                {
                    return;
                }
            }

            LoadData();
        }

        private void ReloadHierarchies()
        {
            using subContext db = new();
            _hierarchies.Clear();
            _hierarchies.AddRange(db.DcHierarchies.OrderBy(x => x.Order).ToList());
            PopulateHierarchyTree();
        }

        private void BBI_Hierarchy_ItemClick(object sender, ItemClickEventArgs e)
        {
            using FormHierarchyList form = string.IsNullOrEmpty(_currentHierarchyCode)
                ? new FormHierarchyList()
                : new FormHierarchyList(_currentHierarchyCode);

            if (form.ShowDialog(this) == DialogResult.OK && form.DcHierarchy != null)
            {
                _currentHierarchyCode = form.DcHierarchy.HierarchyCode;
            }

            ReloadHierarchies();
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            HierarchyFeatureTypeItem? item = gridView1.GetRow(e.RowHandle) as HierarchyFeatureTypeItem;
            if (item == null)
                return;

            if (e.Column == colScope)
            {
                if (item.IsGlobal)
                {
                    e.Appearance.ForeColor = Color.FromArgb(0, 120, 215);
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }
                else if (item.IsAssigned)
                {
                    e.Appearance.ForeColor = Color.FromArgb(16, 124, 65);
                }
                else
                {
                    e.Appearance.ForeColor = Color.Gray;
                }
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (_isSyncing)
                return;

            _isDirty = true;
        }

        private void FormHierarchyFeatureType_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isDirty)
            {
                DialogResult dr = XtraMessageBox.Show(
                    Resources.Form_HierarchyFeatureType_ConfirmSaveChanges,
                    Text,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    if (!SaveAll())
                        e.Cancel = true;
                }
                else if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private class HierarchyTreeItem
        {
            public string HierarchyCode { get; set; } = string.Empty;
            public string HierarchyDesc { get; set; } = string.Empty;
            public string? HierarchyParentCode { get; set; }
        }
    }

    public enum HierarchyFeatureScope
    {
        NotAssigned = 0,
        Assigned = 1,
        Global = 2
    }

    public class HierarchyFeatureTypeItem
    {
        public int FeatureTypeId { get; set; }
        public string FeatureTypeName { get; set; } = string.Empty;
        public int Order { get; set; }
        public bool Filterable { get; set; }
        public bool IsGlobal { get; set; }
        public bool IsAssigned { get; set; }

        public HierarchyFeatureScope Scope
        {
            get
            {
                if (IsGlobal) return HierarchyFeatureScope.Global;
                if (IsAssigned) return HierarchyFeatureScope.Assigned;
                return HierarchyFeatureScope.NotAssigned;
            }
            set
            {
                if (value == HierarchyFeatureScope.Global)
                {
                    IsGlobal = true;
                    IsAssigned = true;
                }
                else if (value == HierarchyFeatureScope.Assigned)
                {
                    IsGlobal = false;
                    IsAssigned = true;
                }
                else
                {
                    IsGlobal = false;
                    IsAssigned = false;
                }
            }
        }
    }
}
