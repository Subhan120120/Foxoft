namespace Foxoft
{
    partial class FormClaimList
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
            this.btnExportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.bsiCount = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.gridControl1 = new MyGridControl();
            this.gridView1 = new MyGridView();
            this.colClaimCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClaimDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClaimTypeDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.btnExportExcel,
            this.btnClose,
            this.bsiCount});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 8;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(1000, 158);
            this.ribbon.StatusBar = this.ribbonStatusBar;
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
            // btnExportExcel
            // 
            this.btnExportExcel.Caption = Foxoft.Properties.Resources.Common_ExportToExcel;
            this.btnExportExcel.Id = 5;
            this.btnExportExcel.Name = "btnExportExcel";
            // 
            // btnClose
            // 
            this.btnClose.Caption = Foxoft.Properties.Resources.Common_Close;
            this.btnClose.Id = 6;
            this.btnClose.Name = "btnClose";
            // 
            // bsiCount
            // 
            this.bsiCount.Id = 7;
            this.bsiCount.Name = "bsiCount";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = Foxoft.Properties.Resources.Form_ClaimList_Caption;
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDelete);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRefresh);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnExportExcel);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = Foxoft.Properties.Resources.Common_Operations;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiCount);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 626);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1000, 24);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 158);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1000, 468);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colClaimCode,
            this.colClaimDesc,
            this.colCategoryDesc,
            this.colClaimTypeDesc,
            this.colId});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = true;
            // 
            // colClaimCode
            // 
            this.colClaimCode.Caption = Foxoft.Properties.Resources.Entity_Claim_Code;
            this.colClaimCode.FieldName = "ClaimCode";
            this.colClaimCode.Name = "colClaimCode";
            this.colClaimCode.Visible = true;
            this.colClaimCode.VisibleIndex = 0;
            this.colClaimCode.Width = 200;
            // 
            // colClaimDesc
            // 
            this.colClaimDesc.Caption = Foxoft.Properties.Resources.Entity_Claim_Desc;
            this.colClaimDesc.FieldName = "ClaimDesc";
            this.colClaimDesc.Name = "colClaimDesc";
            this.colClaimDesc.Visible = true;
            this.colClaimDesc.VisibleIndex = 1;
            this.colClaimDesc.Width = 320;
            // 
            // colCategoryDesc
            // 
            this.colCategoryDesc.Caption = Foxoft.Properties.Resources.Entity_Claim_CategoryId;
            this.colCategoryDesc.FieldName = "CategoryDesc";
            this.colCategoryDesc.Name = "colCategoryDesc";
            this.colCategoryDesc.Visible = true;
            this.colCategoryDesc.VisibleIndex = 2;
            this.colCategoryDesc.Width = 200;
            // 
            // colClaimTypeDesc
            // 
            this.colClaimTypeDesc.Caption = Foxoft.Properties.Resources.Entity_Claim_TypeId;
            this.colClaimTypeDesc.FieldName = "ClaimTypeDesc";
            this.colClaimTypeDesc.Name = "colClaimTypeDesc";
            this.colClaimTypeDesc.Visible = true;
            this.colClaimTypeDesc.VisibleIndex = 3;
            this.colClaimTypeDesc.Width = 140;
            // 
            // colId
            // 
            this.colId.Caption = Foxoft.Properties.Resources.Entity_Claim_Id;
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Width = 80;
            // 
            // FormClaimList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "FormClaimList";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Foxoft.Properties.Resources.Form_ClaimList_Caption;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnExportExcel;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.BarStaticItem bsiCount;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private MyGridControl gridControl1;
        private MyGridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colClaimCode;
        private DevExpress.XtraGrid.Columns.GridColumn colClaimDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colClaimTypeDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
    }
}
