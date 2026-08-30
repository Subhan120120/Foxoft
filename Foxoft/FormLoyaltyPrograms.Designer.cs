using Foxoft.Properties;

namespace Foxoft
{
    partial class FormLoyaltyPrograms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            BBI_New = new DevExpress.XtraBars.BarButtonItem();
            BBI_Edit = new DevExpress.XtraBars.BarButtonItem();
            BBI_Refresh = new DevExpress.XtraBars.BarButtonItem();
            BBI_Delete = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            gridControl1 = new MyGridControl();
            dcLoyaltyProgramsBindingSource = new System.Windows.Forms.BindingSource(components);
            gridView1 = new MyGridView();
            colName = new DevExpress.XtraGrid.Columns.GridColumn();
            colEarnPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            colExpireDays = new DevExpress.XtraGrid.Columns.GridColumn();
            colMaxRedeemPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            colCardCount = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dcLoyaltyProgramsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            SuspendLayout();
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            ribbonControl1.ExpandCollapseItem,
            BBI_New,
            BBI_Edit,
            BBI_Refresh,
            BBI_Delete});
            ribbonControl1.Location = new System.Drawing.Point(0, 0);
            ribbonControl1.MaxItemId = 5;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            ribbonPage1});
            ribbonControl1.Size = new System.Drawing.Size(800, 158);
            // 
            // BBI_New
            // 
            BBI_New.Caption = Resources.Common_New;
            BBI_New.Id = 1;
            BBI_New.Name = "BBI_New";
            BBI_New.ItemClick += BBI_New_ItemClick;
            // 
            // BBI_Edit
            // 
            BBI_Edit.Caption = Resources.Common_Edit;
            BBI_Edit.Id = 2;
            BBI_Edit.Name = "BBI_Edit";
            BBI_Edit.ItemClick += BBI_Edit_ItemClick;
            // 
            // BBI_Refresh
            // 
            BBI_Refresh.Caption = Resources.Common_Refresh;
            BBI_Refresh.Id = 3;
            BBI_Refresh.Name = "BBI_Refresh";
            BBI_Refresh.ItemClick += BBI_Refresh_ItemClick;
            // 
            // BBI_Delete
            // 
            BBI_Delete.Caption = Resources.Common_Delete;
            BBI_Delete.Id = 4;
            BBI_Delete.Name = "BBI_Delete";
            BBI_Delete.ItemClick += BBI_Delete_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            ribbonPageGroup1});
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = Resources.Form_LoyaltyPrograms_Title;
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(BBI_New);
            ribbonPageGroup1.ItemLinks.Add(BBI_Edit);
            ribbonPageGroup1.ItemLinks.Add(BBI_Refresh);
            ribbonPageGroup1.ItemLinks.Add(BBI_Delete);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "ÆmÉ™liyyat";
            // 
            // gridControl1
            // 
            gridControl1.DataSource = dcLoyaltyProgramsBindingSource;
            gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControl1.Location = new System.Drawing.Point(0, 158);
            gridControl1.MainView = gridView1;
            gridControl1.MenuManager = ribbonControl1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new System.Drawing.Size(800, 292);
            gridControl1.TabIndex = 1;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            gridView1});
            // 
            // dcLoyaltyProgramsBindingSource
            // 
            dcLoyaltyProgramsBindingSource.DataSource = typeof(Foxoft.Models.DcLoyaltyProgram);
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            colName,
            colEarnPercent,
            colExpireDays,
            colMaxRedeemPercent,
            colCardCount,
            colIsActive,
            colNote});
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowFooter = true;
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            gridView1.DoubleClick += gridView1_DoubleClick;
            // 
            // colName
            // 
            colName.Caption = Resources.Entity_DcLoyaltyProgram_Name;
            colName.FieldName = "Name";
            colName.Name = "colName";
            colName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Name", "{0}")});
            colName.Visible = true;
            colName.VisibleIndex = 0;
            colName.Width = 180;
            // 
            // colEarnPercent
            // 
            colEarnPercent.Caption = Resources.Entity_DcLoyaltyProgram_EarnPercent;
            colEarnPercent.DisplayFormat.FormatString = "N2";
            colEarnPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colEarnPercent.FieldName = "EarnPercent";
            colEarnPercent.Name = "colEarnPercent";
            colEarnPercent.Visible = true;
            colEarnPercent.VisibleIndex = 1;
            colEarnPercent.Width = 100;
            // 
            // colExpireDays
            // 
            colExpireDays.Caption = Resources.Entity_DcLoyaltyProgram_ExpireDays;
            colExpireDays.DisplayFormat.FormatString = "N0";
            colExpireDays.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colExpireDays.FieldName = "ExpireDays";
            colExpireDays.Name = "colExpireDays";
            colExpireDays.Visible = true;
            colExpireDays.VisibleIndex = 2;
            colExpireDays.Width = 110;
            // 
            // colMaxRedeemPercent
            // 
            colMaxRedeemPercent.Caption = Resources.Entity_DcLoyaltyProgram_MaxRedeemPercent;
            colMaxRedeemPercent.DisplayFormat.FormatString = "N2";
            colMaxRedeemPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colMaxRedeemPercent.FieldName = "MaxRedeemPercent";
            colMaxRedeemPercent.Name = "colMaxRedeemPercent";
            colMaxRedeemPercent.Visible = true;
            colMaxRedeemPercent.VisibleIndex = 3;
            colMaxRedeemPercent.Width = 110;
            // 
            // colCardCount
            // 
            colCardCount.Caption = Resources.Entity_DcLoyaltyProgram_CardCount;
            colCardCount.FieldName = "DcLoyaltyCards.Count";
            colCardCount.Name = "colCardCount";
            colCardCount.Visible = true;
            colCardCount.VisibleIndex = 4;
            colCardCount.Width = 80;
            // 
            // colIsActive
            // 
            colIsActive.Caption = Resources.Entity_DcLoyaltyProgram_IsActive;
            colIsActive.FieldName = "IsActive";
            colIsActive.Name = "colIsActive";
            colIsActive.Visible = true;
            colIsActive.VisibleIndex = 5;
            colIsActive.Width = 70;
            // 
            // colNote
            // 
            colNote.Caption = Resources.Entity_DcLoyaltyProgram_Note;
            colNote.FieldName = "Note";
            colNote.Name = "colNote";
            colNote.Visible = true;
            colNote.VisibleIndex = 6;
            colNote.Width = 150;
            // 
            // FormLoyaltyPrograms
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(gridControl1);
            Controls.Add(ribbonControl1);
            Name = "FormLoyaltyPrograms";
            Ribbon = ribbonControl1;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = Resources.Form_LoyaltyPrograms_Title;
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dcLoyaltyProgramsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem BBI_New;
        private DevExpress.XtraBars.BarButtonItem BBI_Edit;
        private DevExpress.XtraBars.BarButtonItem BBI_Refresh;
        private DevExpress.XtraBars.BarButtonItem BBI_Delete;
        private MyGridControl gridControl1;
        private MyGridView gridView1;
        private System.Windows.Forms.BindingSource dcLoyaltyProgramsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colEarnPercent;
        private DevExpress.XtraGrid.Columns.GridColumn colExpireDays;
        private DevExpress.XtraGrid.Columns.GridColumn colMaxRedeemPercent;
        private DevExpress.XtraGrid.Columns.GridColumn colCardCount;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
    }
}