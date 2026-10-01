using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;

namespace Foxoft
{
    public partial class FormReportGridOptions : XtraForm
    {
        private GridView gridView;
        private bool isUpdating = false;

        public FormReportGridOptions(GridView gridView)
        {
            InitializeComponent();
            this.gridView = gridView;
            InitAdvancedTab();
            LoadCurrentSettings();
            AttachEventHandlers();
        }

        public FormReportGridOptions(MyGridView gridView) : this((GridView)gridView)
        {
        }

        private void InitAdvancedTab()
        {
            if (cmbPropertyTarget.Properties.Items.Count > 0)
                cmbPropertyTarget.SelectedIndex = 0;
            UpdatePropertyGridTarget();
        }

        private void UpdatePropertyGridTarget()
        {
            if (gridView == null) return;

            object? target = cmbPropertyTarget.SelectedIndex switch
            {
                0 => gridView.OptionsView,
                1 => gridView.OptionsBehavior,
                2 => gridView.OptionsCustomization,
                3 => gridView.OptionsFind,
                4 => gridView.OptionsSelection,
                5 => gridView.OptionsMenu,
                6 => gridView.OptionsFilter,
                7 => gridView.OptionsPrint,
                8 => gridView,
                _ => gridView.OptionsView
            };

            propertyGridControl1.SelectedObject = target;
        }

        private void LoadCurrentSettings()
        {
            if (gridView == null) return;

            isUpdating = true;
            try
            {
                // OptionsView
                chkShowFooter.Checked = gridView.OptionsView.ShowFooter;
                chkShowGroupPanel.Checked = gridView.OptionsView.ShowGroupPanel;
                chkShowAutoFilterRow.Checked = gridView.OptionsView.ShowAutoFilterRow;
                chkShowIndicator.Checked = gridView.OptionsView.ShowIndicator;
                chkShowHorizontalLines.Checked = gridView.OptionsView.ShowHorzLines;
                chkShowVerticalLines.Checked = gridView.OptionsView.ShowVertLines;
                chkShowGroupedColumns.Checked = gridView.OptionsView.ShowGroupedColumns;
                chkColumnAutoWidth.Checked = gridView.OptionsView.ColumnAutoWidth;
                chkRowAutoHeight.Checked = gridView.OptionsView.RowAutoHeight;
                chkEnableAppearanceEvenRow.Checked = gridView.OptionsView.EnableAppearanceEvenRow;
                chkEnableAppearanceOddRow.Checked = gridView.OptionsView.EnableAppearanceOddRow;
                cmbGroupFooterShowMode.SelectedIndex = (int)gridView.OptionsView.GroupFooterShowMode;
                cmbShowFilterPanelMode.SelectedIndex = (int)gridView.OptionsView.ShowFilterPanelMode;
                cmbNewItemRowPosition.SelectedIndex = (int)gridView.OptionsView.NewItemRowPosition;
                spnRowHeight.Value = gridView.RowHeight;

                // OptionsBehavior
                chkEditable.Checked = gridView.OptionsBehavior.Editable;
                chkReadOnly.Checked = gridView.OptionsBehavior.ReadOnly;
                chkAllowAddRows.Checked = gridView.OptionsBehavior.AllowAddRows == DefaultBoolean.True;
                chkAllowDeleteRows.Checked = gridView.OptionsBehavior.AllowDeleteRows == DefaultBoolean.True;
                chkAutoExpandAllGroups.Checked = gridView.OptionsBehavior.AutoExpandAllGroups;
                chkKeepFocusedRowOnUpdate.Checked = gridView.OptionsBehavior.KeepFocusedRowOnUpdate;
                chkImmediateUpdateRowPosition.Checked = gridView.OptionsBehavior.ImmediateUpdateRowPosition;
                chkAllowPixelScrolling.Checked = gridView.OptionsBehavior.AllowPixelScrolling == DefaultBoolean.True;
                chkCopyToClipboardWithHeaders.Checked = gridView.OptionsBehavior.CopyToClipboardWithColumnHeaders;
                cmbEditorShowMode.SelectedIndex = (int)gridView.OptionsBehavior.EditorShowMode;

                // OptionsCustomization
                chkAllowRowSizing.Checked = gridView.OptionsCustomization.AllowRowSizing;
                chkAllowColumnMoving.Checked = gridView.OptionsCustomization.AllowColumnMoving;
                chkAllowColumnResizing.Checked = gridView.OptionsCustomization.AllowColumnResizing;
                chkAllowQuickHideColumns.Checked = gridView.OptionsCustomization.AllowQuickHideColumns;
                chkAllowGroup.Checked = gridView.OptionsCustomization.AllowGroup;
                chkAllowSort.Checked = gridView.OptionsCustomization.AllowSort;
                chkAllowFilter.Checked = gridView.OptionsCustomization.AllowFilter;

                // OptionsFind
                chkFindAlwaysVisible.Checked = gridView.OptionsFind.AlwaysVisible;
                chkFindShowClearButton.Checked = gridView.OptionsFind.ShowClearButton;
                chkFindShowCloseButton.Checked = gridView.OptionsFind.ShowCloseButton;
                chkFindShowFindButton.Checked = gridView.OptionsFind.ShowFindButton;
                chkFindHighlightResults.Checked = gridView.OptionsFind.HighlightFindResults;
                chkFindSearchInPreview.Checked = gridView.OptionsFind.SearchInPreview;
                txtFindFilterColumns.Text = gridView.OptionsFind.FindFilterColumns ?? string.Empty;
                txtFindNullPrompt.Text = gridView.OptionsFind.FindNullPrompt ?? string.Empty;

                // OptionsSelection
                chkMultiSelect.Checked = gridView.OptionsSelection.MultiSelect;
                chkEnableAppearanceFocusedRow.Checked = gridView.OptionsSelection.EnableAppearanceFocusedRow;
                chkEnableAppearanceFocusedCell.Checked = gridView.OptionsSelection.EnableAppearanceFocusedCell;
                chkShowCheckBoxInGroup.Checked = gridView.OptionsSelection.ShowCheckBoxSelectorInGroupRow == DefaultBoolean.True;
                chkShowCheckBoxInHeader.Checked = gridView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader == DefaultBoolean.True;
                chkShowCheckBoxInPrintExport.Checked = gridView.OptionsSelection.ShowCheckBoxSelectorInPrintExport == DefaultBoolean.True;
                chkResetSelectionClickOutside.Checked = gridView.OptionsSelection.ResetSelectionClickOutsideCheckboxSelector;
                cmbMultiSelectMode.SelectedIndex = (int)gridView.OptionsSelection.MultiSelectMode;

                // OptionsMenu
                chkEnableColumnMenu.Checked = gridView.OptionsMenu.EnableColumnMenu;
                chkEnableFooterMenu.Checked = gridView.OptionsMenu.EnableFooterMenu;
                chkEnableGroupPanelMenu.Checked = gridView.OptionsMenu.EnableGroupPanelMenu;
                chkShowConditionalFormattingItem.Checked = gridView.OptionsMenu.ShowConditionalFormattingItem;
            }
            finally
            {
                isUpdating = false;
            }
        }

        private void AttachEventHandlers()
        {
            // View
            chkShowFooter.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsView.ShowFooter = chkShowFooter.Checked; };
            chkShowGroupPanel.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsView.ShowGroupPanel = chkShowGroupPanel.Checked; };
            chkShowAutoFilterRow.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsView.ShowAutoFilterRow = chkShowAutoFilterRow.Checked; };
            chkShowIndicator.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsView.ShowIndicator = chkShowIndicator.Checked; };
            chkShowHorizontalLines.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsView.ShowHorzLines = chkShowHorizontalLines.Checked; };
            chkShowVerticalLines.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsView.ShowVertLines = chkShowVerticalLines.Checked; };
            chkShowGroupedColumns.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsView.ShowGroupedColumns = chkShowGroupedColumns.Checked; };
            chkColumnAutoWidth.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsView.ColumnAutoWidth = chkColumnAutoWidth.Checked; };
            chkRowAutoHeight.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsView.RowAutoHeight = chkRowAutoHeight.Checked; };
            chkEnableAppearanceEvenRow.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsView.EnableAppearanceEvenRow = chkEnableAppearanceEvenRow.Checked; };
            chkEnableAppearanceOddRow.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsView.EnableAppearanceOddRow = chkEnableAppearanceOddRow.Checked; };
            cmbGroupFooterShowMode.SelectedIndexChanged += (s, e) => { if (!isUpdating && cmbGroupFooterShowMode.SelectedIndex >= 0) gridView.OptionsView.GroupFooterShowMode = (GroupFooterShowMode)cmbGroupFooterShowMode.SelectedIndex; };
            cmbShowFilterPanelMode.SelectedIndexChanged += (s, e) => { if (!isUpdating && cmbShowFilterPanelMode.SelectedIndex >= 0) gridView.OptionsView.ShowFilterPanelMode = (ShowFilterPanelMode)cmbShowFilterPanelMode.SelectedIndex; };
            cmbNewItemRowPosition.SelectedIndexChanged += (s, e) => { if (!isUpdating && cmbNewItemRowPosition.SelectedIndex >= 0) gridView.OptionsView.NewItemRowPosition = (NewItemRowPosition)cmbNewItemRowPosition.SelectedIndex; };
            spnRowHeight.EditValueChanged += (s, e) => { if (!isUpdating) gridView.RowHeight = (int)spnRowHeight.Value; };

            // Behavior
            chkEditable.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsBehavior.Editable = chkEditable.Checked; };
            chkReadOnly.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsBehavior.ReadOnly = chkReadOnly.Checked; };
            chkAllowAddRows.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsBehavior.AllowAddRows = chkAllowAddRows.Checked ? DefaultBoolean.True : DefaultBoolean.False; };
            chkAllowDeleteRows.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsBehavior.AllowDeleteRows = chkAllowDeleteRows.Checked ? DefaultBoolean.True : DefaultBoolean.False; };
            chkAutoExpandAllGroups.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsBehavior.AutoExpandAllGroups = chkAutoExpandAllGroups.Checked; };
            chkKeepFocusedRowOnUpdate.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsBehavior.KeepFocusedRowOnUpdate = chkKeepFocusedRowOnUpdate.Checked; };
            chkImmediateUpdateRowPosition.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsBehavior.ImmediateUpdateRowPosition = chkImmediateUpdateRowPosition.Checked; };
            chkAllowPixelScrolling.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsBehavior.AllowPixelScrolling = chkAllowPixelScrolling.Checked ? DefaultBoolean.True : DefaultBoolean.False; };
            chkCopyToClipboardWithHeaders.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsBehavior.CopyToClipboardWithColumnHeaders = chkCopyToClipboardWithHeaders.Checked; };
            cmbEditorShowMode.SelectedIndexChanged += (s, e) => { if (!isUpdating && cmbEditorShowMode.SelectedIndex >= 0) gridView.OptionsBehavior.EditorShowMode = (EditorShowMode)cmbEditorShowMode.SelectedIndex; };

            // Customization
            chkAllowRowSizing.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsCustomization.AllowRowSizing = chkAllowRowSizing.Checked; };
            chkAllowColumnMoving.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsCustomization.AllowColumnMoving = chkAllowColumnMoving.Checked; };
            chkAllowColumnResizing.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsCustomization.AllowColumnResizing = chkAllowColumnResizing.Checked; };
            chkAllowQuickHideColumns.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsCustomization.AllowQuickHideColumns = chkAllowQuickHideColumns.Checked; };
            chkAllowGroup.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsCustomization.AllowGroup = chkAllowGroup.Checked; };
            chkAllowSort.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsCustomization.AllowSort = chkAllowSort.Checked; };
            chkAllowFilter.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsCustomization.AllowFilter = chkAllowFilter.Checked; };

            // Find
            chkFindAlwaysVisible.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsFind.AlwaysVisible = chkFindAlwaysVisible.Checked; };
            chkFindShowClearButton.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsFind.ShowClearButton = chkFindShowClearButton.Checked; };
            chkFindShowCloseButton.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsFind.ShowCloseButton = chkFindShowCloseButton.Checked; };
            chkFindShowFindButton.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsFind.ShowFindButton = chkFindShowFindButton.Checked; };
            chkFindHighlightResults.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsFind.HighlightFindResults = chkFindHighlightResults.Checked; };
            chkFindSearchInPreview.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsFind.SearchInPreview = chkFindSearchInPreview.Checked; };
            txtFindFilterColumns.EditValueChanged += (s, e) => { if (!isUpdating) gridView.OptionsFind.FindFilterColumns = txtFindFilterColumns.Text; };
            txtFindNullPrompt.EditValueChanged += (s, e) => { if (!isUpdating) gridView.OptionsFind.FindNullPrompt = txtFindNullPrompt.Text; };

            // Selection & Menu
            chkMultiSelect.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsSelection.MultiSelect = chkMultiSelect.Checked; };
            chkEnableAppearanceFocusedRow.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsSelection.EnableAppearanceFocusedRow = chkEnableAppearanceFocusedRow.Checked; };
            chkEnableAppearanceFocusedCell.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsSelection.EnableAppearanceFocusedCell = chkEnableAppearanceFocusedCell.Checked; };
            chkShowCheckBoxInGroup.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsSelection.ShowCheckBoxSelectorInGroupRow = chkShowCheckBoxInGroup.Checked ? DefaultBoolean.True : DefaultBoolean.False; };
            chkShowCheckBoxInHeader.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = chkShowCheckBoxInHeader.Checked ? DefaultBoolean.True : DefaultBoolean.False; };
            chkShowCheckBoxInPrintExport.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsSelection.ShowCheckBoxSelectorInPrintExport = chkShowCheckBoxInPrintExport.Checked ? DefaultBoolean.True : DefaultBoolean.False; };
            chkResetSelectionClickOutside.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsSelection.ResetSelectionClickOutsideCheckboxSelector = chkResetSelectionClickOutside.Checked; };
            cmbMultiSelectMode.SelectedIndexChanged += (s, e) => { if (!isUpdating && cmbMultiSelectMode.SelectedIndex >= 0) gridView.OptionsSelection.MultiSelectMode = (GridMultiSelectMode)cmbMultiSelectMode.SelectedIndex; };
            chkEnableColumnMenu.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsMenu.EnableColumnMenu = chkEnableColumnMenu.Checked; };
            chkEnableFooterMenu.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsMenu.EnableFooterMenu = chkEnableFooterMenu.Checked; };
            chkEnableGroupPanelMenu.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsMenu.EnableGroupPanelMenu = chkEnableGroupPanelMenu.Checked; };
            chkShowConditionalFormattingItem.CheckedChanged += (s, e) => { if (!isUpdating) gridView.OptionsMenu.ShowConditionalFormattingItem = chkShowConditionalFormattingItem.Checked; };

            // Advanced tab & Tab switching
            cmbPropertyTarget.SelectedIndexChanged += (s, e) => UpdatePropertyGridTarget();
            xtraTabControl1.SelectedPageChanged += (s, e) =>
            {
                if (xtraTabControl1.SelectedTabPage == tabAdvanced)
                    propertyGridControl1.Refresh();
                else
                    LoadCurrentSettings();
            };

            // Close
            btnClose.Click += (s, e) => this.Close();
        }
    }
}
