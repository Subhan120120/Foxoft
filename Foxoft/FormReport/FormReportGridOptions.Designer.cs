using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.XtraVerticalGrid;
using Foxoft.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace Foxoft
{
    partial class FormReportGridOptions
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabView = new DevExpress.XtraTab.XtraTabPage();
            this.scrollTabView = new DevExpress.XtraEditors.XtraScrollableControl();
            this.chkShowFooter = new DevExpress.XtraEditors.CheckEdit();
            this.chkShowGroupPanel = new DevExpress.XtraEditors.CheckEdit();
            this.chkShowAutoFilterRow = new DevExpress.XtraEditors.CheckEdit();
            this.chkShowIndicator = new DevExpress.XtraEditors.CheckEdit();
            this.chkShowHorizontalLines = new DevExpress.XtraEditors.CheckEdit();
            this.chkShowVerticalLines = new DevExpress.XtraEditors.CheckEdit();
            this.chkShowGroupedColumns = new DevExpress.XtraEditors.CheckEdit();
            this.chkColumnAutoWidth = new DevExpress.XtraEditors.CheckEdit();
            this.chkRowAutoHeight = new DevExpress.XtraEditors.CheckEdit();
            this.chkEnableAppearanceEvenRow = new DevExpress.XtraEditors.CheckEdit();
            this.chkEnableAppearanceOddRow = new DevExpress.XtraEditors.CheckEdit();
            this.lblGroupFooterShowMode = new DevExpress.XtraEditors.LabelControl();
            this.cmbGroupFooterShowMode = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblShowFilterPanelMode = new DevExpress.XtraEditors.LabelControl();
            this.cmbShowFilterPanelMode = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblNewItemRowPosition = new DevExpress.XtraEditors.LabelControl();
            this.cmbNewItemRowPosition = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblRowHeight = new DevExpress.XtraEditors.LabelControl();
            this.spnRowHeight = new DevExpress.XtraEditors.SpinEdit();

            this.tabBehavior = new DevExpress.XtraTab.XtraTabPage();
            this.scrollTabBehavior = new DevExpress.XtraEditors.XtraScrollableControl();
            this.chkEditable = new DevExpress.XtraEditors.CheckEdit();
            this.chkReadOnly = new DevExpress.XtraEditors.CheckEdit();
            this.chkAllowAddRows = new DevExpress.XtraEditors.CheckEdit();
            this.chkAllowDeleteRows = new DevExpress.XtraEditors.CheckEdit();
            this.chkAutoExpandAllGroups = new DevExpress.XtraEditors.CheckEdit();
            this.chkKeepFocusedRowOnUpdate = new DevExpress.XtraEditors.CheckEdit();
            this.chkImmediateUpdateRowPosition = new DevExpress.XtraEditors.CheckEdit();
            this.chkAllowPixelScrolling = new DevExpress.XtraEditors.CheckEdit();
            this.chkCopyToClipboardWithHeaders = new DevExpress.XtraEditors.CheckEdit();
            this.lblEditorShowMode = new DevExpress.XtraEditors.LabelControl();
            this.cmbEditorShowMode = new DevExpress.XtraEditors.ComboBoxEdit();

            this.tabCustomization = new DevExpress.XtraTab.XtraTabPage();
            this.scrollTabCustomization = new DevExpress.XtraEditors.XtraScrollableControl();
            this.chkAllowRowSizing = new DevExpress.XtraEditors.CheckEdit();
            this.chkAllowColumnMoving = new DevExpress.XtraEditors.CheckEdit();
            this.chkAllowColumnResizing = new DevExpress.XtraEditors.CheckEdit();
            this.chkAllowQuickHideColumns = new DevExpress.XtraEditors.CheckEdit();
            this.chkAllowGroup = new DevExpress.XtraEditors.CheckEdit();
            this.chkAllowSort = new DevExpress.XtraEditors.CheckEdit();
            this.chkAllowFilter = new DevExpress.XtraEditors.CheckEdit();

            this.tabFind = new DevExpress.XtraTab.XtraTabPage();
            this.scrollTabFind = new DevExpress.XtraEditors.XtraScrollableControl();
            this.chkFindAlwaysVisible = new DevExpress.XtraEditors.CheckEdit();
            this.chkFindShowClearButton = new DevExpress.XtraEditors.CheckEdit();
            this.chkFindShowCloseButton = new DevExpress.XtraEditors.CheckEdit();
            this.chkFindShowFindButton = new DevExpress.XtraEditors.CheckEdit();
            this.chkFindHighlightResults = new DevExpress.XtraEditors.CheckEdit();
            this.chkFindSearchInPreview = new DevExpress.XtraEditors.CheckEdit();
            this.lblFindFilterColumns = new DevExpress.XtraEditors.LabelControl();
            this.txtFindFilterColumns = new DevExpress.XtraEditors.TextEdit();
            this.lblFindNullPrompt = new DevExpress.XtraEditors.LabelControl();
            this.txtFindNullPrompt = new DevExpress.XtraEditors.TextEdit();

            this.tabSelectionMenu = new DevExpress.XtraTab.XtraTabPage();
            this.scrollTabSelectionMenu = new DevExpress.XtraEditors.XtraScrollableControl();
            this.chkMultiSelect = new DevExpress.XtraEditors.CheckEdit();
            this.chkEnableAppearanceFocusedRow = new DevExpress.XtraEditors.CheckEdit();
            this.chkEnableAppearanceFocusedCell = new DevExpress.XtraEditors.CheckEdit();
            this.chkShowCheckBoxInGroup = new DevExpress.XtraEditors.CheckEdit();
            this.chkShowCheckBoxInHeader = new DevExpress.XtraEditors.CheckEdit();
            this.chkShowCheckBoxInPrintExport = new DevExpress.XtraEditors.CheckEdit();
            this.chkResetSelectionClickOutside = new DevExpress.XtraEditors.CheckEdit();
            this.lblMultiSelectMode = new DevExpress.XtraEditors.LabelControl();
            this.cmbMultiSelectMode = new DevExpress.XtraEditors.ComboBoxEdit();
            this.chkEnableColumnMenu = new DevExpress.XtraEditors.CheckEdit();
            this.chkEnableFooterMenu = new DevExpress.XtraEditors.CheckEdit();
            this.chkEnableGroupPanelMenu = new DevExpress.XtraEditors.CheckEdit();
            this.chkShowConditionalFormattingItem = new DevExpress.XtraEditors.CheckEdit();

            this.tabAdvanced = new DevExpress.XtraTab.XtraTabPage();
            this.panelAdvancedTop = new DevExpress.XtraEditors.PanelControl();
            this.lblAdvancedCategory = new DevExpress.XtraEditors.LabelControl();
            this.cmbPropertyTarget = new DevExpress.XtraEditors.ComboBoxEdit();
            this.propertyGridControl1 = new DevExpress.XtraVerticalGrid.PropertyGridControl();

            this.panelBottom = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)this.xtraTabControl1).BeginInit();
            this.xtraTabControl1.SuspendLayout();

            this.tabView.SuspendLayout();
            this.scrollTabView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.chkShowFooter.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkShowGroupPanel.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkShowAutoFilterRow.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkShowIndicator.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkShowHorizontalLines.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkShowVerticalLines.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkShowGroupedColumns.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkColumnAutoWidth.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkRowAutoHeight.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkEnableAppearanceEvenRow.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkEnableAppearanceOddRow.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.cmbGroupFooterShowMode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.cmbShowFilterPanelMode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.cmbNewItemRowPosition.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.spnRowHeight.Properties).BeginInit();

            this.tabBehavior.SuspendLayout();
            this.scrollTabBehavior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.chkEditable.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkReadOnly.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkAllowAddRows.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkAllowDeleteRows.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkAutoExpandAllGroups.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkKeepFocusedRowOnUpdate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkImmediateUpdateRowPosition.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkAllowPixelScrolling.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkCopyToClipboardWithHeaders.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.cmbEditorShowMode.Properties).BeginInit();

            this.tabCustomization.SuspendLayout();
            this.scrollTabCustomization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.chkAllowRowSizing.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkAllowColumnMoving.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkAllowColumnResizing.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkAllowQuickHideColumns.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkAllowGroup.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkAllowSort.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkAllowFilter.Properties).BeginInit();

            this.tabFind.SuspendLayout();
            this.scrollTabFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.chkFindAlwaysVisible.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkFindShowClearButton.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkFindShowCloseButton.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkFindShowFindButton.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkFindHighlightResults.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkFindSearchInPreview.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.txtFindFilterColumns.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.txtFindNullPrompt.Properties).BeginInit();

            this.tabSelectionMenu.SuspendLayout();
            this.scrollTabSelectionMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.chkMultiSelect.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkEnableAppearanceFocusedRow.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkEnableAppearanceFocusedCell.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkShowCheckBoxInGroup.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkShowCheckBoxInHeader.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkShowCheckBoxInPrintExport.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkResetSelectionClickOutside.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.cmbMultiSelectMode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkEnableColumnMenu.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkEnableFooterMenu.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkEnableGroupPanelMenu.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.chkShowConditionalFormattingItem.Properties).BeginInit();

            this.tabAdvanced.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.panelAdvancedTop).BeginInit();
            this.panelAdvancedTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.cmbPropertyTarget.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.propertyGridControl1).BeginInit();

            ((System.ComponentModel.ISupportInitialize)this.panelBottom).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabView;
            this.xtraTabControl1.Size = new System.Drawing.Size(684, 474);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
                this.tabView,
                this.tabBehavior,
                this.tabCustomization,
                this.tabFind,
                this.tabSelectionMenu,
                this.tabAdvanced
            });

            // 
            // tabView
            // 
            this.tabView.Controls.Add(this.scrollTabView);
            this.tabView.Name = "tabView";
            this.tabView.Size = new System.Drawing.Size(682, 446);
            this.tabView.Text = Resources.Form_ReportGridOptions_TabView;

            // 
            // scrollTabView
            // 
            this.scrollTabView.AutoScroll = true;
            this.scrollTabView.Controls.Add(this.chkShowFooter);
            this.scrollTabView.Controls.Add(this.chkShowGroupPanel);
            this.scrollTabView.Controls.Add(this.chkShowAutoFilterRow);
            this.scrollTabView.Controls.Add(this.chkShowIndicator);
            this.scrollTabView.Controls.Add(this.chkShowHorizontalLines);
            this.scrollTabView.Controls.Add(this.chkShowVerticalLines);
            this.scrollTabView.Controls.Add(this.chkShowGroupedColumns);
            this.scrollTabView.Controls.Add(this.chkColumnAutoWidth);
            this.scrollTabView.Controls.Add(this.chkRowAutoHeight);
            this.scrollTabView.Controls.Add(this.chkEnableAppearanceEvenRow);
            this.scrollTabView.Controls.Add(this.chkEnableAppearanceOddRow);
            this.scrollTabView.Controls.Add(this.lblGroupFooterShowMode);
            this.scrollTabView.Controls.Add(this.cmbGroupFooterShowMode);
            this.scrollTabView.Controls.Add(this.lblShowFilterPanelMode);
            this.scrollTabView.Controls.Add(this.cmbShowFilterPanelMode);
            this.scrollTabView.Controls.Add(this.lblNewItemRowPosition);
            this.scrollTabView.Controls.Add(this.cmbNewItemRowPosition);
            this.scrollTabView.Controls.Add(this.lblRowHeight);
            this.scrollTabView.Controls.Add(this.spnRowHeight);
            this.scrollTabView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollTabView.Location = new System.Drawing.Point(0, 0);
            this.scrollTabView.Name = "scrollTabView";
            this.scrollTabView.Size = new System.Drawing.Size(682, 446);
            this.scrollTabView.TabIndex = 0;

            // chkShowFooter
            this.chkShowFooter.Location = new System.Drawing.Point(16, 16);
            this.chkShowFooter.Name = "chkShowFooter";
            this.chkShowFooter.Properties.Caption = Resources.Form_ReportGridOptions_ShowFooter;
            this.chkShowFooter.Size = new System.Drawing.Size(290, 20);
            this.chkShowFooter.TabIndex = 0;

            // chkShowGroupPanel
            this.chkShowGroupPanel.Location = new System.Drawing.Point(16, 44);
            this.chkShowGroupPanel.Name = "chkShowGroupPanel";
            this.chkShowGroupPanel.Properties.Caption = Resources.Form_ReportGridOptions_ShowGroupPanel;
            this.chkShowGroupPanel.Size = new System.Drawing.Size(290, 20);
            this.chkShowGroupPanel.TabIndex = 1;

            // chkShowAutoFilterRow
            this.chkShowAutoFilterRow.Location = new System.Drawing.Point(16, 72);
            this.chkShowAutoFilterRow.Name = "chkShowAutoFilterRow";
            this.chkShowAutoFilterRow.Properties.Caption = Resources.Form_ReportGridOptions_ShowAutoFilterRow;
            this.chkShowAutoFilterRow.Size = new System.Drawing.Size(290, 20);
            this.chkShowAutoFilterRow.TabIndex = 2;

            // chkShowIndicator
            this.chkShowIndicator.Location = new System.Drawing.Point(16, 100);
            this.chkShowIndicator.Name = "chkShowIndicator";
            this.chkShowIndicator.Properties.Caption = Resources.Form_ReportGridOptions_ShowIndicator;
            this.chkShowIndicator.Size = new System.Drawing.Size(290, 20);
            this.chkShowIndicator.TabIndex = 3;

            // chkShowHorizontalLines
            this.chkShowHorizontalLines.Location = new System.Drawing.Point(16, 128);
            this.chkShowHorizontalLines.Name = "chkShowHorizontalLines";
            this.chkShowHorizontalLines.Properties.Caption = Resources.Form_ReportGridOptions_ShowHorizontalLines;
            this.chkShowHorizontalLines.Size = new System.Drawing.Size(290, 20);
            this.chkShowHorizontalLines.TabIndex = 4;

            // chkShowVerticalLines
            this.chkShowVerticalLines.Location = new System.Drawing.Point(16, 156);
            this.chkShowVerticalLines.Name = "chkShowVerticalLines";
            this.chkShowVerticalLines.Properties.Caption = Resources.Form_ReportGridOptions_ShowVerticalLines;
            this.chkShowVerticalLines.Size = new System.Drawing.Size(290, 20);
            this.chkShowVerticalLines.TabIndex = 5;

            // chkShowGroupedColumns
            this.chkShowGroupedColumns.Location = new System.Drawing.Point(16, 184);
            this.chkShowGroupedColumns.Name = "chkShowGroupedColumns";
            this.chkShowGroupedColumns.Properties.Caption = Resources.Form_ReportGridOptions_ShowGroupedColumns;
            this.chkShowGroupedColumns.Size = new System.Drawing.Size(290, 20);
            this.chkShowGroupedColumns.TabIndex = 6;

            // chkColumnAutoWidth
            this.chkColumnAutoWidth.Location = new System.Drawing.Point(330, 16);
            this.chkColumnAutoWidth.Name = "chkColumnAutoWidth";
            this.chkColumnAutoWidth.Properties.Caption = Resources.Form_ReportGridOptions_ColumnAutoWidth;
            this.chkColumnAutoWidth.Size = new System.Drawing.Size(290, 20);
            this.chkColumnAutoWidth.TabIndex = 7;

            // chkRowAutoHeight
            this.chkRowAutoHeight.Location = new System.Drawing.Point(330, 44);
            this.chkRowAutoHeight.Name = "chkRowAutoHeight";
            this.chkRowAutoHeight.Properties.Caption = Resources.Form_ReportGridOptions_RowAutoHeight;
            this.chkRowAutoHeight.Size = new System.Drawing.Size(290, 20);
            this.chkRowAutoHeight.TabIndex = 8;

            // chkEnableAppearanceEvenRow
            this.chkEnableAppearanceEvenRow.Location = new System.Drawing.Point(330, 72);
            this.chkEnableAppearanceEvenRow.Name = "chkEnableAppearanceEvenRow";
            this.chkEnableAppearanceEvenRow.Properties.Caption = Resources.Form_ReportGridOptions_EnableAppearanceEvenRow;
            this.chkEnableAppearanceEvenRow.Size = new System.Drawing.Size(290, 20);
            this.chkEnableAppearanceEvenRow.TabIndex = 9;

            // chkEnableAppearanceOddRow
            this.chkEnableAppearanceOddRow.Location = new System.Drawing.Point(330, 100);
            this.chkEnableAppearanceOddRow.Name = "chkEnableAppearanceOddRow";
            this.chkEnableAppearanceOddRow.Properties.Caption = Resources.Form_ReportGridOptions_EnableAppearanceOddRow;
            this.chkEnableAppearanceOddRow.Size = new System.Drawing.Size(290, 20);
            this.chkEnableAppearanceOddRow.TabIndex = 10;

            // lblGroupFooterShowMode
            this.lblGroupFooterShowMode.Location = new System.Drawing.Point(16, 220);
            this.lblGroupFooterShowMode.Name = "lblGroupFooterShowMode";
            this.lblGroupFooterShowMode.Size = new System.Drawing.Size(120, 13);
            this.lblGroupFooterShowMode.TabIndex = 11;
            this.lblGroupFooterShowMode.Text = Resources.Form_ReportGridOptions_GroupFooterShowMode;

            // cmbGroupFooterShowMode
            this.cmbGroupFooterShowMode.Location = new System.Drawing.Point(16, 238);
            this.cmbGroupFooterShowMode.Name = "cmbGroupFooterShowMode";
            this.cmbGroupFooterShowMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbGroupFooterShowMode.Properties.Items.AddRange(new object[] {
                Resources.Form_ReportGridOptions_GroupFooter_Hidden,
                Resources.Form_ReportGridOptions_GroupFooter_VisibleAlways,
                Resources.Form_ReportGridOptions_GroupFooter_VisibleIfExpanded
            });
            this.cmbGroupFooterShowMode.Size = new System.Drawing.Size(290, 20);
            this.cmbGroupFooterShowMode.TabIndex = 12;

            // lblShowFilterPanelMode
            this.lblShowFilterPanelMode.Location = new System.Drawing.Point(330, 220);
            this.lblShowFilterPanelMode.Name = "lblShowFilterPanelMode";
            this.lblShowFilterPanelMode.Size = new System.Drawing.Size(120, 13);
            this.lblShowFilterPanelMode.TabIndex = 13;
            this.lblShowFilterPanelMode.Text = Resources.Form_ReportGridOptions_ShowFilterPanelMode;

            // cmbShowFilterPanelMode
            this.cmbShowFilterPanelMode.Location = new System.Drawing.Point(330, 238);
            this.cmbShowFilterPanelMode.Name = "cmbShowFilterPanelMode";
            this.cmbShowFilterPanelMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbShowFilterPanelMode.Properties.Items.AddRange(new object[] {
                Resources.Form_ReportGridOptions_FilterPanel_Default,
                Resources.Form_ReportGridOptions_FilterPanel_Never,
                Resources.Form_ReportGridOptions_FilterPanel_ShowAlways
            });
            this.cmbShowFilterPanelMode.Size = new System.Drawing.Size(290, 20);
            this.cmbShowFilterPanelMode.TabIndex = 14;

            // lblNewItemRowPosition
            this.lblNewItemRowPosition.Location = new System.Drawing.Point(16, 274);
            this.lblNewItemRowPosition.Name = "lblNewItemRowPosition";
            this.lblNewItemRowPosition.Size = new System.Drawing.Size(120, 13);
            this.lblNewItemRowPosition.TabIndex = 15;
            this.lblNewItemRowPosition.Text = Resources.Form_ReportGridOptions_NewItemRowPosition;

            // cmbNewItemRowPosition
            this.cmbNewItemRowPosition.Location = new System.Drawing.Point(16, 292);
            this.cmbNewItemRowPosition.Name = "cmbNewItemRowPosition";
            this.cmbNewItemRowPosition.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbNewItemRowPosition.Properties.Items.AddRange(new object[] {
                Resources.Form_ReportGridOptions_NewItemRow_None,
                Resources.Form_ReportGridOptions_NewItemRow_Top,
                Resources.Form_ReportGridOptions_NewItemRow_Bottom
            });
            this.cmbNewItemRowPosition.Size = new System.Drawing.Size(290, 20);
            this.cmbNewItemRowPosition.TabIndex = 16;

            // lblRowHeight
            this.lblRowHeight.Location = new System.Drawing.Point(330, 274);
            this.lblRowHeight.Name = "lblRowHeight";
            this.lblRowHeight.Size = new System.Drawing.Size(120, 13);
            this.lblRowHeight.TabIndex = 17;
            this.lblRowHeight.Text = Resources.Form_ReportGridOptions_RowHeight;

            // spnRowHeight
            this.spnRowHeight.Location = new System.Drawing.Point(330, 292);
            this.spnRowHeight.Name = "spnRowHeight";
            this.spnRowHeight.Properties.IsFloatValue = false;
            this.spnRowHeight.Properties.MinValue = 0;
            this.spnRowHeight.Properties.MaxValue = 500;
            this.spnRowHeight.Size = new System.Drawing.Size(290, 20);
            this.spnRowHeight.TabIndex = 18;

            // 
            // tabBehavior
            // 
            this.tabBehavior.Controls.Add(this.scrollTabBehavior);
            this.tabBehavior.Name = "tabBehavior";
            this.tabBehavior.Size = new System.Drawing.Size(682, 446);
            this.tabBehavior.Text = Resources.Form_ReportGridOptions_TabBehavior;

            // 
            // scrollTabBehavior
            // 
            this.scrollTabBehavior.AutoScroll = true;
            this.scrollTabBehavior.Controls.Add(this.chkEditable);
            this.scrollTabBehavior.Controls.Add(this.chkReadOnly);
            this.scrollTabBehavior.Controls.Add(this.chkAllowAddRows);
            this.scrollTabBehavior.Controls.Add(this.chkAllowDeleteRows);
            this.scrollTabBehavior.Controls.Add(this.chkAutoExpandAllGroups);
            this.scrollTabBehavior.Controls.Add(this.chkKeepFocusedRowOnUpdate);
            this.scrollTabBehavior.Controls.Add(this.chkImmediateUpdateRowPosition);
            this.scrollTabBehavior.Controls.Add(this.chkAllowPixelScrolling);
            this.scrollTabBehavior.Controls.Add(this.chkCopyToClipboardWithHeaders);
            this.scrollTabBehavior.Controls.Add(this.lblEditorShowMode);
            this.scrollTabBehavior.Controls.Add(this.cmbEditorShowMode);
            this.scrollTabBehavior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollTabBehavior.Location = new System.Drawing.Point(0, 0);
            this.scrollTabBehavior.Name = "scrollTabBehavior";
            this.scrollTabBehavior.Size = new System.Drawing.Size(682, 446);
            this.scrollTabBehavior.TabIndex = 0;

            // chkEditable
            this.chkEditable.Location = new System.Drawing.Point(16, 16);
            this.chkEditable.Name = "chkEditable";
            this.chkEditable.Properties.Caption = Resources.Form_ReportGridOptions_Editable;
            this.chkEditable.Size = new System.Drawing.Size(290, 20);
            this.chkEditable.TabIndex = 0;

            // chkReadOnly
            this.chkReadOnly.Location = new System.Drawing.Point(16, 44);
            this.chkReadOnly.Name = "chkReadOnly";
            this.chkReadOnly.Properties.Caption = Resources.Form_ReportGridOptions_ReadOnly;
            this.chkReadOnly.Size = new System.Drawing.Size(290, 20);
            this.chkReadOnly.TabIndex = 1;

            // chkAllowAddRows
            this.chkAllowAddRows.Location = new System.Drawing.Point(16, 72);
            this.chkAllowAddRows.Name = "chkAllowAddRows";
            this.chkAllowAddRows.Properties.Caption = Resources.Form_ReportGridOptions_AllowAddRows;
            this.chkAllowAddRows.Size = new System.Drawing.Size(290, 20);
            this.chkAllowAddRows.TabIndex = 2;

            // chkAllowDeleteRows
            this.chkAllowDeleteRows.Location = new System.Drawing.Point(16, 100);
            this.chkAllowDeleteRows.Name = "chkAllowDeleteRows";
            this.chkAllowDeleteRows.Properties.Caption = Resources.Form_ReportGridOptions_AllowDeleteRows;
            this.chkAllowDeleteRows.Size = new System.Drawing.Size(290, 20);
            this.chkAllowDeleteRows.TabIndex = 3;

            // chkAutoExpandAllGroups
            this.chkAutoExpandAllGroups.Location = new System.Drawing.Point(330, 16);
            this.chkAutoExpandAllGroups.Name = "chkAutoExpandAllGroups";
            this.chkAutoExpandAllGroups.Properties.Caption = Resources.Form_ReportGridOptions_AutoExpandAllGroups;
            this.chkAutoExpandAllGroups.Size = new System.Drawing.Size(290, 20);
            this.chkAutoExpandAllGroups.TabIndex = 4;

            // chkKeepFocusedRowOnUpdate
            this.chkKeepFocusedRowOnUpdate.Location = new System.Drawing.Point(330, 44);
            this.chkKeepFocusedRowOnUpdate.Name = "chkKeepFocusedRowOnUpdate";
            this.chkKeepFocusedRowOnUpdate.Properties.Caption = Resources.Form_ReportGridOptions_KeepFocusedRowOnUpdate;
            this.chkKeepFocusedRowOnUpdate.Size = new System.Drawing.Size(290, 20);
            this.chkKeepFocusedRowOnUpdate.TabIndex = 5;

            // chkImmediateUpdateRowPosition
            this.chkImmediateUpdateRowPosition.Location = new System.Drawing.Point(330, 72);
            this.chkImmediateUpdateRowPosition.Name = "chkImmediateUpdateRowPosition";
            this.chkImmediateUpdateRowPosition.Properties.Caption = Resources.Form_ReportGridOptions_ImmediateUpdateRowPosition;
            this.chkImmediateUpdateRowPosition.Size = new System.Drawing.Size(290, 20);
            this.chkImmediateUpdateRowPosition.TabIndex = 6;

            // chkAllowPixelScrolling
            this.chkAllowPixelScrolling.Location = new System.Drawing.Point(330, 100);
            this.chkAllowPixelScrolling.Name = "chkAllowPixelScrolling";
            this.chkAllowPixelScrolling.Properties.Caption = Resources.Form_ReportGridOptions_AllowPixelScrolling;
            this.chkAllowPixelScrolling.Size = new System.Drawing.Size(290, 20);
            this.chkAllowPixelScrolling.TabIndex = 7;

            // chkCopyToClipboardWithHeaders
            this.chkCopyToClipboardWithHeaders.Location = new System.Drawing.Point(330, 128);
            this.chkCopyToClipboardWithHeaders.Name = "chkCopyToClipboardWithHeaders";
            this.chkCopyToClipboardWithHeaders.Properties.Caption = Resources.Form_ReportGridOptions_CopyToClipboardWithHeaders;
            this.chkCopyToClipboardWithHeaders.Size = new System.Drawing.Size(290, 20);
            this.chkCopyToClipboardWithHeaders.TabIndex = 8;

            // lblEditorShowMode
            this.lblEditorShowMode.Location = new System.Drawing.Point(16, 140);
            this.lblEditorShowMode.Name = "lblEditorShowMode";
            this.lblEditorShowMode.Size = new System.Drawing.Size(120, 13);
            this.lblEditorShowMode.TabIndex = 9;
            this.lblEditorShowMode.Text = Resources.Form_ReportGridOptions_EditorShowMode;

            // cmbEditorShowMode
            this.cmbEditorShowMode.Location = new System.Drawing.Point(16, 158);
            this.cmbEditorShowMode.Name = "cmbEditorShowMode";
            this.cmbEditorShowMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbEditorShowMode.Properties.Items.AddRange(new object[] {
                Resources.Form_ReportGridOptions_EditorShow_Default,
                Resources.Form_ReportGridOptions_EditorShow_MouseDown,
                Resources.Form_ReportGridOptions_EditorShow_MouseDownFocused,
                Resources.Form_ReportGridOptions_EditorShow_Click
            });
            this.cmbEditorShowMode.Size = new System.Drawing.Size(290, 20);
            this.cmbEditorShowMode.TabIndex = 10;

            // 
            // tabCustomization
            // 
            this.tabCustomization.Controls.Add(this.scrollTabCustomization);
            this.tabCustomization.Name = "tabCustomization";
            this.tabCustomization.Size = new System.Drawing.Size(682, 446);
            this.tabCustomization.Text = Resources.Form_ReportGridOptions_TabCustomization;

            // 
            // scrollTabCustomization
            // 
            this.scrollTabCustomization.AutoScroll = true;
            this.scrollTabCustomization.Controls.Add(this.chkAllowRowSizing);
            this.scrollTabCustomization.Controls.Add(this.chkAllowColumnMoving);
            this.scrollTabCustomization.Controls.Add(this.chkAllowColumnResizing);
            this.scrollTabCustomization.Controls.Add(this.chkAllowQuickHideColumns);
            this.scrollTabCustomization.Controls.Add(this.chkAllowGroup);
            this.scrollTabCustomization.Controls.Add(this.chkAllowSort);
            this.scrollTabCustomization.Controls.Add(this.chkAllowFilter);
            this.scrollTabCustomization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollTabCustomization.Location = new System.Drawing.Point(0, 0);
            this.scrollTabCustomization.Name = "scrollTabCustomization";
            this.scrollTabCustomization.Size = new System.Drawing.Size(682, 446);
            this.scrollTabCustomization.TabIndex = 0;

            // chkAllowRowSizing
            this.chkAllowRowSizing.Location = new System.Drawing.Point(16, 16);
            this.chkAllowRowSizing.Name = "chkAllowRowSizing";
            this.chkAllowRowSizing.Properties.Caption = Resources.Form_ReportGridOptions_AllowRowSizing;
            this.chkAllowRowSizing.Size = new System.Drawing.Size(290, 20);
            this.chkAllowRowSizing.TabIndex = 0;

            // chkAllowColumnMoving
            this.chkAllowColumnMoving.Location = new System.Drawing.Point(16, 44);
            this.chkAllowColumnMoving.Name = "chkAllowColumnMoving";
            this.chkAllowColumnMoving.Properties.Caption = Resources.Form_ReportGridOptions_AllowColumnMoving;
            this.chkAllowColumnMoving.Size = new System.Drawing.Size(290, 20);
            this.chkAllowColumnMoving.TabIndex = 1;

            // chkAllowColumnResizing
            this.chkAllowColumnResizing.Location = new System.Drawing.Point(16, 72);
            this.chkAllowColumnResizing.Name = "chkAllowColumnResizing";
            this.chkAllowColumnResizing.Properties.Caption = Resources.Form_ReportGridOptions_AllowColumnResizing;
            this.chkAllowColumnResizing.Size = new System.Drawing.Size(290, 20);
            this.chkAllowColumnResizing.TabIndex = 2;

            // chkAllowQuickHideColumns
            this.chkAllowQuickHideColumns.Location = new System.Drawing.Point(16, 100);
            this.chkAllowQuickHideColumns.Name = "chkAllowQuickHideColumns";
            this.chkAllowQuickHideColumns.Properties.Caption = Resources.Form_ReportGridOptions_AllowQuickHideColumns;
            this.chkAllowQuickHideColumns.Size = new System.Drawing.Size(290, 20);
            this.chkAllowQuickHideColumns.TabIndex = 3;

            // chkAllowGroup
            this.chkAllowGroup.Location = new System.Drawing.Point(330, 16);
            this.chkAllowGroup.Name = "chkAllowGroup";
            this.chkAllowGroup.Properties.Caption = Resources.Form_ReportGridOptions_AllowGroup;
            this.chkAllowGroup.Size = new System.Drawing.Size(290, 20);
            this.chkAllowGroup.TabIndex = 4;

            // chkAllowSort
            this.chkAllowSort.Location = new System.Drawing.Point(330, 44);
            this.chkAllowSort.Name = "chkAllowSort";
            this.chkAllowSort.Properties.Caption = Resources.Form_ReportGridOptions_AllowSort;
            this.chkAllowSort.Size = new System.Drawing.Size(290, 20);
            this.chkAllowSort.TabIndex = 5;

            // chkAllowFilter
            this.chkAllowFilter.Location = new System.Drawing.Point(330, 72);
            this.chkAllowFilter.Name = "chkAllowFilter";
            this.chkAllowFilter.Properties.Caption = Resources.Form_ReportGridOptions_AllowFilter;
            this.chkAllowFilter.Size = new System.Drawing.Size(290, 20);
            this.chkAllowFilter.TabIndex = 6;

            // 
            // tabFind
            // 
            this.tabFind.Controls.Add(this.scrollTabFind);
            this.tabFind.Name = "tabFind";
            this.tabFind.Size = new System.Drawing.Size(682, 446);
            this.tabFind.Text = Resources.Form_ReportGridOptions_TabFind;

            // 
            // scrollTabFind
            // 
            this.scrollTabFind.AutoScroll = true;
            this.scrollTabFind.Controls.Add(this.chkFindAlwaysVisible);
            this.scrollTabFind.Controls.Add(this.chkFindShowClearButton);
            this.scrollTabFind.Controls.Add(this.chkFindShowCloseButton);
            this.scrollTabFind.Controls.Add(this.chkFindShowFindButton);
            this.scrollTabFind.Controls.Add(this.chkFindHighlightResults);
            this.scrollTabFind.Controls.Add(this.chkFindSearchInPreview);
            this.scrollTabFind.Controls.Add(this.lblFindFilterColumns);
            this.scrollTabFind.Controls.Add(this.txtFindFilterColumns);
            this.scrollTabFind.Controls.Add(this.lblFindNullPrompt);
            this.scrollTabFind.Controls.Add(this.txtFindNullPrompt);
            this.scrollTabFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollTabFind.Location = new System.Drawing.Point(0, 0);
            this.scrollTabFind.Name = "scrollTabFind";
            this.scrollTabFind.Size = new System.Drawing.Size(682, 446);
            this.scrollTabFind.TabIndex = 0;

            // chkFindAlwaysVisible
            this.chkFindAlwaysVisible.Location = new System.Drawing.Point(16, 16);
            this.chkFindAlwaysVisible.Name = "chkFindAlwaysVisible";
            this.chkFindAlwaysVisible.Properties.Caption = Resources.Form_ReportGridOptions_FindAlwaysVisible;
            this.chkFindAlwaysVisible.Size = new System.Drawing.Size(290, 20);
            this.chkFindAlwaysVisible.TabIndex = 0;

            // chkFindShowClearButton
            this.chkFindShowClearButton.Location = new System.Drawing.Point(16, 44);
            this.chkFindShowClearButton.Name = "chkFindShowClearButton";
            this.chkFindShowClearButton.Properties.Caption = Resources.Form_ReportGridOptions_FindShowClearButton;
            this.chkFindShowClearButton.Size = new System.Drawing.Size(290, 20);
            this.chkFindShowClearButton.TabIndex = 1;

            // chkFindShowCloseButton
            this.chkFindShowCloseButton.Location = new System.Drawing.Point(16, 72);
            this.chkFindShowCloseButton.Name = "chkFindShowCloseButton";
            this.chkFindShowCloseButton.Properties.Caption = Resources.Form_ReportGridOptions_FindShowCloseButton;
            this.chkFindShowCloseButton.Size = new System.Drawing.Size(290, 20);
            this.chkFindShowCloseButton.TabIndex = 2;

            // chkFindShowFindButton
            this.chkFindShowFindButton.Location = new System.Drawing.Point(330, 16);
            this.chkFindShowFindButton.Name = "chkFindShowFindButton";
            this.chkFindShowFindButton.Properties.Caption = Resources.Form_ReportGridOptions_FindShowFindButton;
            this.chkFindShowFindButton.Size = new System.Drawing.Size(290, 20);
            this.chkFindShowFindButton.TabIndex = 3;

            // chkFindHighlightResults
            this.chkFindHighlightResults.Location = new System.Drawing.Point(330, 44);
            this.chkFindHighlightResults.Name = "chkFindHighlightResults";
            this.chkFindHighlightResults.Properties.Caption = Resources.Form_ReportGridOptions_FindHighlightResults;
            this.chkFindHighlightResults.Size = new System.Drawing.Size(290, 20);
            this.chkFindHighlightResults.TabIndex = 4;

            // chkFindSearchInPreview
            this.chkFindSearchInPreview.Location = new System.Drawing.Point(330, 72);
            this.chkFindSearchInPreview.Name = "chkFindSearchInPreview";
            this.chkFindSearchInPreview.Properties.Caption = Resources.Form_ReportGridOptions_FindSearchInPreview;
            this.chkFindSearchInPreview.Size = new System.Drawing.Size(290, 20);
            this.chkFindSearchInPreview.TabIndex = 5;

            // lblFindFilterColumns
            this.lblFindFilterColumns.Location = new System.Drawing.Point(16, 110);
            this.lblFindFilterColumns.Name = "lblFindFilterColumns";
            this.lblFindFilterColumns.Size = new System.Drawing.Size(150, 13);
            this.lblFindFilterColumns.TabIndex = 6;
            this.lblFindFilterColumns.Text = Resources.Form_ReportGridOptions_FindFilterColumns;

            // txtFindFilterColumns
            this.txtFindFilterColumns.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right;
            this.txtFindFilterColumns.Location = new System.Drawing.Point(16, 128);
            this.txtFindFilterColumns.Name = "txtFindFilterColumns";
            this.txtFindFilterColumns.Size = new System.Drawing.Size(604, 20);
            this.txtFindFilterColumns.TabIndex = 7;

            // lblFindNullPrompt
            this.lblFindNullPrompt.Location = new System.Drawing.Point(16, 160);
            this.lblFindNullPrompt.Name = "lblFindNullPrompt";
            this.lblFindNullPrompt.Size = new System.Drawing.Size(150, 13);
            this.lblFindNullPrompt.TabIndex = 8;
            this.lblFindNullPrompt.Text = Resources.Form_ReportGridOptions_FindNullPrompt;

            // txtFindNullPrompt
            this.txtFindNullPrompt.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right;
            this.txtFindNullPrompt.Location = new System.Drawing.Point(16, 178);
            this.txtFindNullPrompt.Name = "txtFindNullPrompt";
            this.txtFindNullPrompt.Size = new System.Drawing.Size(604, 20);
            this.txtFindNullPrompt.TabIndex = 9;

            // 
            // tabSelectionMenu
            // 
            this.tabSelectionMenu.Controls.Add(this.scrollTabSelectionMenu);
            this.tabSelectionMenu.Name = "tabSelectionMenu";
            this.tabSelectionMenu.Size = new System.Drawing.Size(682, 446);
            this.tabSelectionMenu.Text = Resources.Form_ReportGridOptions_TabSelectionMenu;

            // 
            // scrollTabSelectionMenu
            // 
            this.scrollTabSelectionMenu.AutoScroll = true;
            this.scrollTabSelectionMenu.Controls.Add(this.chkMultiSelect);
            this.scrollTabSelectionMenu.Controls.Add(this.chkEnableAppearanceFocusedRow);
            this.scrollTabSelectionMenu.Controls.Add(this.chkEnableAppearanceFocusedCell);
            this.scrollTabSelectionMenu.Controls.Add(this.chkShowCheckBoxInGroup);
            this.scrollTabSelectionMenu.Controls.Add(this.chkShowCheckBoxInHeader);
            this.scrollTabSelectionMenu.Controls.Add(this.chkShowCheckBoxInPrintExport);
            this.scrollTabSelectionMenu.Controls.Add(this.chkResetSelectionClickOutside);
            this.scrollTabSelectionMenu.Controls.Add(this.lblMultiSelectMode);
            this.scrollTabSelectionMenu.Controls.Add(this.cmbMultiSelectMode);
            this.scrollTabSelectionMenu.Controls.Add(this.chkEnableColumnMenu);
            this.scrollTabSelectionMenu.Controls.Add(this.chkEnableFooterMenu);
            this.scrollTabSelectionMenu.Controls.Add(this.chkEnableGroupPanelMenu);
            this.scrollTabSelectionMenu.Controls.Add(this.chkShowConditionalFormattingItem);
            this.scrollTabSelectionMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollTabSelectionMenu.Location = new System.Drawing.Point(0, 0);
            this.scrollTabSelectionMenu.Name = "scrollTabSelectionMenu";
            this.scrollTabSelectionMenu.Size = new System.Drawing.Size(682, 446);
            this.scrollTabSelectionMenu.TabIndex = 0;

            // chkMultiSelect
            this.chkMultiSelect.Location = new System.Drawing.Point(16, 16);
            this.chkMultiSelect.Name = "chkMultiSelect";
            this.chkMultiSelect.Properties.Caption = Resources.Form_ReportGridOptions_MultiSelect;
            this.chkMultiSelect.Size = new System.Drawing.Size(290, 20);
            this.chkMultiSelect.TabIndex = 0;

            // chkEnableAppearanceFocusedRow
            this.chkEnableAppearanceFocusedRow.Location = new System.Drawing.Point(16, 44);
            this.chkEnableAppearanceFocusedRow.Name = "chkEnableAppearanceFocusedRow";
            this.chkEnableAppearanceFocusedRow.Properties.Caption = Resources.Form_ReportGridOptions_EnableAppearanceFocusedRow;
            this.chkEnableAppearanceFocusedRow.Size = new System.Drawing.Size(290, 20);
            this.chkEnableAppearanceFocusedRow.TabIndex = 1;

            // chkEnableAppearanceFocusedCell
            this.chkEnableAppearanceFocusedCell.Location = new System.Drawing.Point(16, 72);
            this.chkEnableAppearanceFocusedCell.Name = "chkEnableAppearanceFocusedCell";
            this.chkEnableAppearanceFocusedCell.Properties.Caption = Resources.Form_ReportGridOptions_EnableAppearanceFocusedCell;
            this.chkEnableAppearanceFocusedCell.Size = new System.Drawing.Size(290, 20);
            this.chkEnableAppearanceFocusedCell.TabIndex = 2;

            // chkShowCheckBoxInGroup
            this.chkShowCheckBoxInGroup.Location = new System.Drawing.Point(330, 16);
            this.chkShowCheckBoxInGroup.Name = "chkShowCheckBoxInGroup";
            this.chkShowCheckBoxInGroup.Properties.Caption = Resources.Form_ReportGridOptions_ShowCheckBoxInGroup;
            this.chkShowCheckBoxInGroup.Size = new System.Drawing.Size(290, 20);
            this.chkShowCheckBoxInGroup.TabIndex = 3;

            // chkShowCheckBoxInHeader
            this.chkShowCheckBoxInHeader.Location = new System.Drawing.Point(330, 44);
            this.chkShowCheckBoxInHeader.Name = "chkShowCheckBoxInHeader";
            this.chkShowCheckBoxInHeader.Properties.Caption = Resources.Form_ReportGridOptions_ShowCheckBoxInHeader;
            this.chkShowCheckBoxInHeader.Size = new System.Drawing.Size(290, 20);
            this.chkShowCheckBoxInHeader.TabIndex = 4;

            // chkShowCheckBoxInPrintExport
            this.chkShowCheckBoxInPrintExport.Location = new System.Drawing.Point(330, 72);
            this.chkShowCheckBoxInPrintExport.Name = "chkShowCheckBoxInPrintExport";
            this.chkShowCheckBoxInPrintExport.Properties.Caption = Resources.Form_ReportGridOptions_ShowCheckBoxInPrintExport;
            this.chkShowCheckBoxInPrintExport.Size = new System.Drawing.Size(290, 20);
            this.chkShowCheckBoxInPrintExport.TabIndex = 5;

            // chkResetSelectionClickOutside
            this.chkResetSelectionClickOutside.Location = new System.Drawing.Point(330, 100);
            this.chkResetSelectionClickOutside.Name = "chkResetSelectionClickOutside";
            this.chkResetSelectionClickOutside.Properties.Caption = Resources.Form_ReportGridOptions_ResetSelectionClickOutside;
            this.chkResetSelectionClickOutside.Size = new System.Drawing.Size(290, 20);
            this.chkResetSelectionClickOutside.TabIndex = 6;

            // lblMultiSelectMode
            this.lblMultiSelectMode.Location = new System.Drawing.Point(16, 110);
            this.lblMultiSelectMode.Name = "lblMultiSelectMode";
            this.lblMultiSelectMode.Size = new System.Drawing.Size(120, 13);
            this.lblMultiSelectMode.TabIndex = 7;
            this.lblMultiSelectMode.Text = Resources.Form_ReportGridOptions_MultiSelectMode;

            // cmbMultiSelectMode
            this.cmbMultiSelectMode.Location = new System.Drawing.Point(16, 128);
            this.cmbMultiSelectMode.Name = "cmbMultiSelectMode";
            this.cmbMultiSelectMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbMultiSelectMode.Properties.Items.AddRange(new object[] {
                Resources.Form_ReportGridOptions_MultiSelect_Row,
                Resources.Form_ReportGridOptions_MultiSelect_CheckBox,
                Resources.Form_ReportGridOptions_MultiSelect_Cell
            });
            this.cmbMultiSelectMode.Size = new System.Drawing.Size(290, 20);
            this.cmbMultiSelectMode.TabIndex = 8;

            // chkEnableColumnMenu
            this.chkEnableColumnMenu.Location = new System.Drawing.Point(16, 172);
            this.chkEnableColumnMenu.Name = "chkEnableColumnMenu";
            this.chkEnableColumnMenu.Properties.Caption = Resources.Form_ReportGridOptions_EnableColumnMenu;
            this.chkEnableColumnMenu.Size = new System.Drawing.Size(290, 20);
            this.chkEnableColumnMenu.TabIndex = 9;

            // chkEnableFooterMenu
            this.chkEnableFooterMenu.Location = new System.Drawing.Point(16, 200);
            this.chkEnableFooterMenu.Name = "chkEnableFooterMenu";
            this.chkEnableFooterMenu.Properties.Caption = Resources.Form_ReportGridOptions_EnableFooterMenu;
            this.chkEnableFooterMenu.Size = new System.Drawing.Size(290, 20);
            this.chkEnableFooterMenu.TabIndex = 10;

            // chkEnableGroupPanelMenu
            this.chkEnableGroupPanelMenu.Location = new System.Drawing.Point(330, 172);
            this.chkEnableGroupPanelMenu.Name = "chkEnableGroupPanelMenu";
            this.chkEnableGroupPanelMenu.Properties.Caption = Resources.Form_ReportGridOptions_EnableGroupPanelMenu;
            this.chkEnableGroupPanelMenu.Size = new System.Drawing.Size(290, 20);
            this.chkEnableGroupPanelMenu.TabIndex = 11;

            // chkShowConditionalFormattingItem
            this.chkShowConditionalFormattingItem.Location = new System.Drawing.Point(330, 200);
            this.chkShowConditionalFormattingItem.Name = "chkShowConditionalFormattingItem";
            this.chkShowConditionalFormattingItem.Properties.Caption = Resources.Form_ReportGridOptions_ShowConditionalFormattingItem;
            this.chkShowConditionalFormattingItem.Size = new System.Drawing.Size(290, 20);
            this.chkShowConditionalFormattingItem.TabIndex = 12;

            // 
            // tabAdvanced
            // 
            this.tabAdvanced.Controls.Add(this.propertyGridControl1);
            this.tabAdvanced.Controls.Add(this.panelAdvancedTop);
            this.tabAdvanced.Name = "tabAdvanced";
            this.tabAdvanced.Size = new System.Drawing.Size(682, 446);
            this.tabAdvanced.Text = Resources.Form_ReportGridOptions_TabAdvanced;

            // 
            // panelAdvancedTop
            // 
            this.panelAdvancedTop.Controls.Add(this.lblAdvancedCategory);
            this.panelAdvancedTop.Controls.Add(this.cmbPropertyTarget);
            this.panelAdvancedTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAdvancedTop.Location = new System.Drawing.Point(0, 0);
            this.panelAdvancedTop.Name = "panelAdvancedTop";
            this.panelAdvancedTop.Size = new System.Drawing.Size(682, 42);
            this.panelAdvancedTop.TabIndex = 0;

            // lblAdvancedCategory
            this.lblAdvancedCategory.Location = new System.Drawing.Point(12, 14);
            this.lblAdvancedCategory.Name = "lblAdvancedCategory";
            this.lblAdvancedCategory.Size = new System.Drawing.Size(120, 13);
            this.lblAdvancedCategory.TabIndex = 0;
            this.lblAdvancedCategory.Text = Resources.Form_ReportGridOptions_AdvancedCategory;

            // cmbPropertyTarget
            this.cmbPropertyTarget.Location = new System.Drawing.Point(150, 11);
            this.cmbPropertyTarget.Name = "cmbPropertyTarget";
            this.cmbPropertyTarget.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbPropertyTarget.Properties.Items.AddRange(new object[] {
                Resources.Form_ReportGridOptions_Category_OptionsView,
                Resources.Form_ReportGridOptions_Category_OptionsBehavior,
                Resources.Form_ReportGridOptions_Category_OptionsCustomization,
                Resources.Form_ReportGridOptions_Category_OptionsFind,
                Resources.Form_ReportGridOptions_Category_OptionsSelection,
                Resources.Form_ReportGridOptions_Category_OptionsMenu,
                Resources.Form_ReportGridOptions_Category_OptionsFilter,
                Resources.Form_ReportGridOptions_Category_OptionsPrint,
                Resources.Form_ReportGridOptions_Category_GridView
            });
            this.cmbPropertyTarget.Size = new System.Drawing.Size(340, 20);
            this.cmbPropertyTarget.TabIndex = 1;

            // 
            // propertyGridControl1
            // 
            this.propertyGridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.propertyGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridControl1.Location = new System.Drawing.Point(0, 42);
            this.propertyGridControl1.Name = "propertyGridControl1";
            this.propertyGridControl1.OptionsView.ShowRootCategories = true;
            this.propertyGridControl1.Size = new System.Drawing.Size(682, 404);
            this.propertyGridControl1.TabIndex = 1;

            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 474);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(684, 46);
            this.panelBottom.TabIndex = 1;

            // 
            // btnClose
            // 
            this.btnClose.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnClose.Location = new System.Drawing.Point(576, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 30);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = Resources.Common_Close;

            // 
            // FormReportGridOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 520);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.panelBottom);
            this.MinimumSize = new System.Drawing.Size(660, 480);
            this.MaximizeBox = true;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "FormReportGridOptions";
            this.Text = Resources.Form_ReportGridOptions_Caption;

            ((System.ComponentModel.ISupportInitialize)this.xtraTabControl1).EndInit();
            this.xtraTabControl1.ResumeLayout(false);

            this.tabView.ResumeLayout(false);
            this.scrollTabView.ResumeLayout(false);
            this.scrollTabView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.chkShowFooter.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkShowGroupPanel.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkShowAutoFilterRow.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkShowIndicator.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkShowHorizontalLines.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkShowVerticalLines.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkShowGroupedColumns.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkColumnAutoWidth.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkRowAutoHeight.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkEnableAppearanceEvenRow.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkEnableAppearanceOddRow.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.cmbGroupFooterShowMode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.cmbShowFilterPanelMode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.cmbNewItemRowPosition.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.spnRowHeight.Properties).EndInit();

            this.tabBehavior.ResumeLayout(false);
            this.scrollTabBehavior.ResumeLayout(false);
            this.scrollTabBehavior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.chkEditable.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkReadOnly.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkAllowAddRows.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkAllowDeleteRows.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkAutoExpandAllGroups.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkKeepFocusedRowOnUpdate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkImmediateUpdateRowPosition.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkAllowPixelScrolling.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkCopyToClipboardWithHeaders.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.cmbEditorShowMode.Properties).EndInit();

            this.tabCustomization.ResumeLayout(false);
            this.scrollTabCustomization.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.chkAllowRowSizing.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkAllowColumnMoving.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkAllowColumnResizing.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkAllowQuickHideColumns.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkAllowGroup.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkAllowSort.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkAllowFilter.Properties).EndInit();

            this.tabFind.ResumeLayout(false);
            this.scrollTabFind.ResumeLayout(false);
            this.scrollTabFind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.chkFindAlwaysVisible.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkFindShowClearButton.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkFindShowCloseButton.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkFindShowFindButton.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkFindHighlightResults.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkFindSearchInPreview.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.txtFindFilterColumns.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.txtFindNullPrompt.Properties).EndInit();

            this.tabSelectionMenu.ResumeLayout(false);
            this.scrollTabSelectionMenu.ResumeLayout(false);
            this.scrollTabSelectionMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.chkMultiSelect.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkEnableAppearanceFocusedRow.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkEnableAppearanceFocusedCell.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkShowCheckBoxInGroup.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkShowCheckBoxInHeader.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkShowCheckBoxInPrintExport.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkResetSelectionClickOutside.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.cmbMultiSelectMode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkEnableColumnMenu.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkEnableFooterMenu.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkEnableGroupPanelMenu.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.chkShowConditionalFormattingItem.Properties).EndInit();

            this.tabAdvanced.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.panelAdvancedTop).EndInit();
            this.panelAdvancedTop.ResumeLayout(false);
            this.panelAdvancedTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.cmbPropertyTarget.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.propertyGridControl1).EndInit();

            ((System.ComponentModel.ISupportInitialize)this.panelBottom).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tabView;
        private DevExpress.XtraTab.XtraTabPage tabBehavior;
        private DevExpress.XtraTab.XtraTabPage tabCustomization;
        private DevExpress.XtraTab.XtraTabPage tabFind;
        private DevExpress.XtraTab.XtraTabPage tabSelectionMenu;
        private DevExpress.XtraTab.XtraTabPage tabAdvanced;

        private DevExpress.XtraEditors.PanelControl panelBottom;
        private DevExpress.XtraEditors.SimpleButton btnClose;

        // tabView
        private DevExpress.XtraEditors.XtraScrollableControl scrollTabView;
        private DevExpress.XtraEditors.CheckEdit chkShowFooter;
        private DevExpress.XtraEditors.CheckEdit chkShowGroupPanel;
        private DevExpress.XtraEditors.CheckEdit chkShowAutoFilterRow;
        private DevExpress.XtraEditors.CheckEdit chkShowIndicator;
        private DevExpress.XtraEditors.CheckEdit chkShowHorizontalLines;
        private DevExpress.XtraEditors.CheckEdit chkShowVerticalLines;
        private DevExpress.XtraEditors.CheckEdit chkShowGroupedColumns;
        private DevExpress.XtraEditors.CheckEdit chkColumnAutoWidth;
        private DevExpress.XtraEditors.CheckEdit chkRowAutoHeight;
        private DevExpress.XtraEditors.CheckEdit chkEnableAppearanceEvenRow;
        private DevExpress.XtraEditors.CheckEdit chkEnableAppearanceOddRow;
        private DevExpress.XtraEditors.LabelControl lblGroupFooterShowMode;
        private DevExpress.XtraEditors.ComboBoxEdit cmbGroupFooterShowMode;
        private DevExpress.XtraEditors.LabelControl lblShowFilterPanelMode;
        private DevExpress.XtraEditors.ComboBoxEdit cmbShowFilterPanelMode;
        private DevExpress.XtraEditors.LabelControl lblNewItemRowPosition;
        private DevExpress.XtraEditors.ComboBoxEdit cmbNewItemRowPosition;
        private DevExpress.XtraEditors.LabelControl lblRowHeight;
        private DevExpress.XtraEditors.SpinEdit spnRowHeight;

        // tabBehavior
        private DevExpress.XtraEditors.XtraScrollableControl scrollTabBehavior;
        private DevExpress.XtraEditors.CheckEdit chkEditable;
        private DevExpress.XtraEditors.CheckEdit chkReadOnly;
        private DevExpress.XtraEditors.CheckEdit chkAllowAddRows;
        private DevExpress.XtraEditors.CheckEdit chkAllowDeleteRows;
        private DevExpress.XtraEditors.CheckEdit chkAutoExpandAllGroups;
        private DevExpress.XtraEditors.CheckEdit chkKeepFocusedRowOnUpdate;
        private DevExpress.XtraEditors.CheckEdit chkImmediateUpdateRowPosition;
        private DevExpress.XtraEditors.CheckEdit chkAllowPixelScrolling;
        private DevExpress.XtraEditors.CheckEdit chkCopyToClipboardWithHeaders;
        private DevExpress.XtraEditors.LabelControl lblEditorShowMode;
        private DevExpress.XtraEditors.ComboBoxEdit cmbEditorShowMode;

        // tabCustomization
        private DevExpress.XtraEditors.XtraScrollableControl scrollTabCustomization;
        private DevExpress.XtraEditors.CheckEdit chkAllowRowSizing;
        private DevExpress.XtraEditors.CheckEdit chkAllowColumnMoving;
        private DevExpress.XtraEditors.CheckEdit chkAllowColumnResizing;
        private DevExpress.XtraEditors.CheckEdit chkAllowQuickHideColumns;
        private DevExpress.XtraEditors.CheckEdit chkAllowGroup;
        private DevExpress.XtraEditors.CheckEdit chkAllowSort;
        private DevExpress.XtraEditors.CheckEdit chkAllowFilter;

        // tabFind
        private DevExpress.XtraEditors.XtraScrollableControl scrollTabFind;
        private DevExpress.XtraEditors.CheckEdit chkFindAlwaysVisible;
        private DevExpress.XtraEditors.CheckEdit chkFindShowClearButton;
        private DevExpress.XtraEditors.CheckEdit chkFindShowCloseButton;
        private DevExpress.XtraEditors.CheckEdit chkFindShowFindButton;
        private DevExpress.XtraEditors.CheckEdit chkFindHighlightResults;
        private DevExpress.XtraEditors.CheckEdit chkFindSearchInPreview;
        private DevExpress.XtraEditors.LabelControl lblFindFilterColumns;
        private DevExpress.XtraEditors.TextEdit txtFindFilterColumns;
        private DevExpress.XtraEditors.LabelControl lblFindNullPrompt;
        private DevExpress.XtraEditors.TextEdit txtFindNullPrompt;

        // tabSelectionMenu
        private DevExpress.XtraEditors.XtraScrollableControl scrollTabSelectionMenu;
        private DevExpress.XtraEditors.CheckEdit chkMultiSelect;
        private DevExpress.XtraEditors.CheckEdit chkEnableAppearanceFocusedRow;
        private DevExpress.XtraEditors.CheckEdit chkEnableAppearanceFocusedCell;
        private DevExpress.XtraEditors.CheckEdit chkShowCheckBoxInGroup;
        private DevExpress.XtraEditors.CheckEdit chkShowCheckBoxInHeader;
        private DevExpress.XtraEditors.CheckEdit chkShowCheckBoxInPrintExport;
        private DevExpress.XtraEditors.CheckEdit chkResetSelectionClickOutside;
        private DevExpress.XtraEditors.LabelControl lblMultiSelectMode;
        private DevExpress.XtraEditors.ComboBoxEdit cmbMultiSelectMode;
        private DevExpress.XtraEditors.CheckEdit chkEnableColumnMenu;
        private DevExpress.XtraEditors.CheckEdit chkEnableFooterMenu;
        private DevExpress.XtraEditors.CheckEdit chkEnableGroupPanelMenu;
        private DevExpress.XtraEditors.CheckEdit chkShowConditionalFormattingItem;

        // tabAdvanced
        private DevExpress.XtraEditors.PanelControl panelAdvancedTop;
        private DevExpress.XtraEditors.LabelControl lblAdvancedCategory;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPropertyTarget;
        private DevExpress.XtraVerticalGrid.PropertyGridControl propertyGridControl1;
    }
}
