namespace Foxoft
{
    partial class FormUnitOfMeasureList
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
            this.components = new System.ComponentModel.Container();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnSetBasic = new DevExpress.XtraBars.BarButtonItem();
            this.btnToggleActive = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportPdf = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupStatus = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupExport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupClose = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gridControl1 = new MyGridControl();
            this.gridView1 = new MyGridView();
            this.colUnitOfMeasureId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitOfMeasureDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsBasic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoCheckEditIsBasic = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colParentDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConversionRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFormula = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsDisabled = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoCheckEditIsDisabled = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoCheckEditIsBasic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoCheckEditIsDisabled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnNew,
            this.btnEdit,
            this.btnDelete,
            this.btnRefresh,
            this.btnSetBasic,
            this.btnToggleActive,
            this.btnExportExcel,
            this.btnExportPdf,
            this.btnClose});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 10;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(1040, 158);
            // 
            // btnNew
            // 
            this.btnNew.Caption = Foxoft.Properties.Resources.Common_New;
            this.btnNew.Id = 1;
            this.btnNew.Name = "btnNew";
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = Foxoft.Properties.Resources.Common_Edit;
            this.btnEdit.Id = 2;
            this.btnEdit.Name = "btnEdit";
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = Foxoft.Properties.Resources.Common_Delete;
            this.btnDelete.Id = 3;
            this.btnDelete.Name = "btnDelete";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = Foxoft.Properties.Resources.Common_Refresh;
            this.btnRefresh.Id = 4;
            this.btnRefresh.Name = "btnRefresh";
            // 
            // btnSetBasic
            // 
            this.btnSetBasic.Caption = Foxoft.Properties.Resources.Common_SetBasic;
            this.btnSetBasic.Id = 5;
            this.btnSetBasic.Name = "btnSetBasic";
            // 
            // btnToggleActive
            // 
            this.btnToggleActive.Caption = Foxoft.Properties.Resources.Common_ToggleActive;
            this.btnToggleActive.Id = 6;
            this.btnToggleActive.Name = "btnToggleActive";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Caption = Foxoft.Properties.Resources.Common_ExportExcel;
            this.btnExportExcel.Id = 7;
            this.btnExportExcel.Name = "btnExportExcel";
            // 
            // btnExportPdf
            // 
            this.btnExportPdf.Caption = Foxoft.Properties.Resources.Common_ExportPdf;
            this.btnExportPdf.Id = 8;
            this.btnExportPdf.Name = "btnExportPdf";
            // 
            // btnClose
            // 
            this.btnClose.Caption = Foxoft.Properties.Resources.Common_Close;
            this.btnClose.Id = 9;
            this.btnClose.Name = "btnClose";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupActions,
            this.ribbonPageGroupStatus,
            this.ribbonPageGroupExport,
            this.ribbonPageGroupClose});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = Foxoft.Properties.Resources.Form_UnitOfMeasureList_Caption;
            // 
            // ribbonPageGroupActions
            // 
            this.ribbonPageGroupActions.ItemLinks.Add(this.btnNew);
            this.ribbonPageGroupActions.ItemLinks.Add(this.btnEdit);
            this.ribbonPageGroupActions.ItemLinks.Add(this.btnDelete);
            this.ribbonPageGroupActions.ItemLinks.Add(this.btnRefresh);
            this.ribbonPageGroupActions.Name = "ribbonPageGroupActions";
            this.ribbonPageGroupActions.Text = Foxoft.Properties.Resources.Common_Feature;
            // 
            // ribbonPageGroupStatus
            // 
            this.ribbonPageGroupStatus.ItemLinks.Add(this.btnSetBasic);
            this.ribbonPageGroupStatus.ItemLinks.Add(this.btnToggleActive);
            this.ribbonPageGroupStatus.Name = "ribbonPageGroupStatus";
            this.ribbonPageGroupStatus.Text = Foxoft.Properties.Resources.Common_Identity;
            // 
            // ribbonPageGroupExport
            // 
            this.ribbonPageGroupExport.ItemLinks.Add(this.btnExportExcel);
            this.ribbonPageGroupExport.ItemLinks.Add(this.btnExportPdf);
            this.ribbonPageGroupExport.Name = "ribbonPageGroupExport";
            this.ribbonPageGroupExport.Text = Foxoft.Properties.Resources.Common_Load;
            // 
            // ribbonPageGroupClose
            // 
            this.ribbonPageGroupClose.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroupClose.Name = "ribbonPageGroupClose";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 158);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoCheckEditIsBasic,
            this.repoCheckEditIsDisabled});
            this.gridControl1.Size = new System.Drawing.Size(1040, 520);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUnitOfMeasureId,
            this.colUnitOfMeasureDesc,
            this.colIsBasic,
            this.colParentDesc,
            this.colConversionRate,
            this.colFormula,
            this.colLevel,
            this.colProductCount,
            this.colIsDisabled});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colUnitOfMeasureId
            // 
            this.colUnitOfMeasureId.AppearanceCell.Options.UseTextOptions = true;
            this.colUnitOfMeasureId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUnitOfMeasureId.Caption = Foxoft.Properties.Resources.Entity_UnitOfMeasure_Id;
            this.colUnitOfMeasureId.FieldName = "UnitOfMeasureId";
            this.colUnitOfMeasureId.Name = "colUnitOfMeasureId";
            this.colUnitOfMeasureId.Visible = true;
            this.colUnitOfMeasureId.VisibleIndex = 0;
            this.colUnitOfMeasureId.Width = 65;
            // 
            // colUnitOfMeasureDesc
            // 
            this.colUnitOfMeasureDesc.Caption = Foxoft.Properties.Resources.Entity_UnitOfMeasure_Desc;
            this.colUnitOfMeasureDesc.FieldName = "UnitOfMeasureDesc";
            this.colUnitOfMeasureDesc.Name = "colUnitOfMeasureDesc";
            this.colUnitOfMeasureDesc.Visible = true;
            this.colUnitOfMeasureDesc.VisibleIndex = 1;
            this.colUnitOfMeasureDesc.Width = 140;
            // 
            // colIsBasic
            // 
            this.colIsBasic.AppearanceCell.Options.UseTextOptions = true;
            this.colIsBasic.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsBasic.Caption = Foxoft.Properties.Resources.Entity_UnitOfMeasure_IsBasic;
            this.colIsBasic.ColumnEdit = this.repoCheckEditIsBasic;
            this.colIsBasic.FieldName = "IsBasic";
            this.colIsBasic.Name = "colIsBasic";
            this.colIsBasic.Visible = true;
            this.colIsBasic.VisibleIndex = 2;
            this.colIsBasic.Width = 85;
            // 
            // repoCheckEditIsBasic
            // 
            this.repoCheckEditIsBasic.AutoHeight = false;
            this.repoCheckEditIsBasic.Name = "repoCheckEditIsBasic";
            // 
            // colParentDesc
            // 
            this.colParentDesc.Caption = Foxoft.Properties.Resources.Entity_UnitOfMeasure_ParentId;
            this.colParentDesc.FieldName = "ParentDesc";
            this.colParentDesc.Name = "colParentDesc";
            this.colParentDesc.Visible = true;
            this.colParentDesc.VisibleIndex = 3;
            this.colParentDesc.Width = 130;
            // 
            // colConversionRate
            // 
            this.colConversionRate.AppearanceCell.Options.UseTextOptions = true;
            this.colConversionRate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colConversionRate.Caption = Foxoft.Properties.Resources.Entity_UnitOfMeasure_ConversionRate;
            this.colConversionRate.DisplayFormat.FormatString = "0.######";
            this.colConversionRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colConversionRate.FieldName = "ConversionRate";
            this.colConversionRate.Name = "colConversionRate";
            this.colConversionRate.Visible = true;
            this.colConversionRate.VisibleIndex = 4;
            this.colConversionRate.Width = 115;
            // 
            // colFormula
            // 
            this.colFormula.Caption = Foxoft.Properties.Resources.Entity_UnitOfMeasure_Formula;
            this.colFormula.FieldName = "Formula";
            this.colFormula.Name = "colFormula";
            this.colFormula.Visible = true;
            this.colFormula.VisibleIndex = 5;
            this.colFormula.Width = 240;
            // 
            // colLevel
            // 
            this.colLevel.AppearanceCell.Options.UseTextOptions = true;
            this.colLevel.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel.Caption = Foxoft.Properties.Resources.Entity_UnitOfMeasure_Level;
            this.colLevel.FieldName = "Level";
            this.colLevel.Name = "colLevel";
            this.colLevel.Visible = true;
            this.colLevel.VisibleIndex = 6;
            this.colLevel.Width = 65;
            // 
            // colProductCount
            // 
            this.colProductCount.AppearanceCell.Options.UseTextOptions = true;
            this.colProductCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colProductCount.Caption = Foxoft.Properties.Resources.Entity_UnitOfMeasure_ProductCount;
            this.colProductCount.DisplayFormat.FormatString = "n0";
            this.colProductCount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colProductCount.FieldName = "ProductCount";
            this.colProductCount.Name = "colProductCount";
            this.colProductCount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ProductCount", "{0:n0}")});
            this.colProductCount.Visible = true;
            this.colProductCount.VisibleIndex = 7;
            this.colProductCount.Width = 90;
            // 
            // colIsDisabled
            // 
            this.colIsDisabled.AppearanceCell.Options.UseTextOptions = true;
            this.colIsDisabled.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsDisabled.Caption = Foxoft.Properties.Resources.Common_IsDisabled;
            this.colIsDisabled.ColumnEdit = this.repoCheckEditIsDisabled;
            this.colIsDisabled.FieldName = "IsDisabled";
            this.colIsDisabled.Name = "colIsDisabled";
            this.colIsDisabled.Visible = true;
            this.colIsDisabled.VisibleIndex = 8;
            this.colIsDisabled.Width = 75;
            // 
            // repoCheckEditIsDisabled
            // 
            this.repoCheckEditIsDisabled.AutoHeight = false;
            this.repoCheckEditIsDisabled.Name = "repoCheckEditIsDisabled";
            // 
            // popupMenu1
            // 
            this.popupMenu1.ItemLinks.Add(this.btnNew);
            this.popupMenu1.ItemLinks.Add(this.btnEdit);
            this.popupMenu1.ItemLinks.Add(this.btnDelete);
            this.popupMenu1.ItemLinks.Add(this.btnRefresh);
            this.popupMenu1.ItemLinks.Add(this.btnSetBasic);
            this.popupMenu1.ItemLinks.Add(this.btnToggleActive);
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.Ribbon = this.ribbon;
            // 
            // FormUnitOfMeasureList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 678);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbon);
            this.Name = "FormUnitOfMeasureList";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Foxoft.Properties.Resources.Form_UnitOfMeasureList_Caption;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoCheckEditIsBasic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoCheckEditIsDisabled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnSetBasic;
        private DevExpress.XtraBars.BarButtonItem btnToggleActive;
        private DevExpress.XtraBars.BarButtonItem btnExportExcel;
        private DevExpress.XtraBars.BarButtonItem btnExportPdf;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupActions;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupStatus;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupExport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupClose;
        private MyGridControl gridControl1;
        private MyGridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitOfMeasureId;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitOfMeasureDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colIsBasic;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repoCheckEditIsBasic;
        private DevExpress.XtraGrid.Columns.GridColumn colParentDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colConversionRate;
        private DevExpress.XtraGrid.Columns.GridColumn colFormula;
        private DevExpress.XtraGrid.Columns.GridColumn colLevel;
        private DevExpress.XtraGrid.Columns.GridColumn colProductCount;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDisabled;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repoCheckEditIsDisabled;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
    }
}
