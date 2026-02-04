namespace Foxoft
{
    partial class FormLoyaltyCards
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
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            dcLoyaltyCardBindingSource = new BindingSource(components);
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colLoyaltyCardId = new DevExpress.XtraGrid.Columns.GridColumn();
            colCardNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colLoyaltyProgramId = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            colRowVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            colLoyaltyProgram = new DevExpress.XtraGrid.Columns.GridColumn();
            colDcCurrAcc = new DevExpress.XtraGrid.Columns.GridColumn();
            colLoyaltyTxns = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dcLoyaltyCardBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            SuspendLayout();
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, BBI_New, BBI_Edit, BBI_Refresh, BBI_Delete });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 5;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(800, 158);
            // 
            // BBI_New
            // 
            BBI_New.Caption = "Yeni";
            BBI_New.Id = 1;
            BBI_New.Name = "BBI_New";
            BBI_New.ItemClick += BBI_New_ItemClick;
            // 
            // BBI_Edit
            // 
            BBI_Edit.Caption = "Dəyiş";
            BBI_Edit.Id = 2;
            BBI_Edit.Name = "BBI_Edit";
            BBI_Edit.ItemClick += BBI_Edit_ItemClick;
            // 
            // BBI_Refresh
            // 
            BBI_Refresh.Caption = "Yenilə";
            BBI_Refresh.Id = 3;
            BBI_Refresh.Name = "BBI_Refresh";
            BBI_Refresh.ItemClick += BBI_Refresh_ItemClick;
            // 
            // BBI_Delete
            // 
            BBI_Delete.Caption = "Sil";
            BBI_Delete.Id = 4;
            BBI_Delete.Name = "BBI_Delete";
            BBI_Delete.ItemClick += BBI_Delete_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(BBI_New);
            ribbonPageGroup1.ItemLinks.Add(BBI_Edit);
            ribbonPageGroup1.ItemLinks.Add(BBI_Refresh);
            ribbonPageGroup1.ItemLinks.Add(BBI_Delete);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Əməliyat";
            // 
            // gridControl1
            // 
            gridControl1.DataSource = dcLoyaltyCardBindingSource;
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 158);
            gridControl1.MainView = gridView1;
            gridControl1.MenuManager = ribbonControl1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(800, 292);
            gridControl1.TabIndex = 1;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // dcLoyaltyCardBindingSource
            // 
            dcLoyaltyCardBindingSource.DataSource = typeof(Models.DcLoyaltyCard);
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colLoyaltyCardId, colCardNumber, colCurrAccCode, colLoyaltyProgramId, colIsActive, colNote, colRowVersion, colLoyaltyProgram, colDcCurrAcc, colLoyaltyTxns, colCreatedUserName, colCreatedDate, colLastUpdatedUserName, colLastUpdatedDate });
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            // 
            // colLoyaltyCardId
            // 
            colLoyaltyCardId.FieldName = "LoyaltyCardId";
            colLoyaltyCardId.Name = "colLoyaltyCardId";
            colLoyaltyCardId.Visible = true;
            colLoyaltyCardId.VisibleIndex = 0;
            colLoyaltyCardId.Width = 97;
            // 
            // colCardNumber
            // 
            colCardNumber.FieldName = "CardNumber";
            colCardNumber.Name = "colCardNumber";
            colCardNumber.Visible = true;
            colCardNumber.VisibleIndex = 1;
            colCardNumber.Width = 86;
            // 
            // colCurrAccCode
            // 
            colCurrAccCode.FieldName = "CurrAccCode";
            colCurrAccCode.Name = "colCurrAccCode";
            colCurrAccCode.Visible = true;
            colCurrAccCode.VisibleIndex = 2;
            colCurrAccCode.Width = 92;
            // 
            // colLoyaltyProgramId
            // 
            colLoyaltyProgramId.FieldName = "LoyaltyProgramId";
            colLoyaltyProgramId.Name = "colLoyaltyProgramId";
            colLoyaltyProgramId.Visible = true;
            colLoyaltyProgramId.VisibleIndex = 3;
            colLoyaltyProgramId.Width = 114;
            // 
            // colIsActive
            // 
            colIsActive.FieldName = "IsActive";
            colIsActive.Name = "colIsActive";
            colIsActive.Visible = true;
            colIsActive.VisibleIndex = 4;
            // 
            // colNote
            // 
            colNote.FieldName = "Note";
            colNote.Name = "colNote";
            colNote.Visible = true;
            colNote.VisibleIndex = 5;
            // 
            // colRowVersion
            // 
            colRowVersion.FieldName = "RowVersion";
            colRowVersion.Name = "colRowVersion";
            colRowVersion.Width = 82;
            // 
            // colLoyaltyProgram
            // 
            colLoyaltyProgram.FieldName = "LoyaltyProgram";
            colLoyaltyProgram.Name = "colLoyaltyProgram";
            colLoyaltyProgram.Width = 101;
            // 
            // colDcCurrAcc
            // 
            colDcCurrAcc.FieldName = "DcCurrAcc";
            colDcCurrAcc.Name = "colDcCurrAcc";
            colDcCurrAcc.Width = 102;
            // 
            // colLoyaltyTxns
            // 
            colLoyaltyTxns.FieldName = "LoyaltyTxns";
            colLoyaltyTxns.Name = "colLoyaltyTxns";
            colLoyaltyTxns.Width = 84;
            // 
            // colCreatedUserName
            // 
            colCreatedUserName.FieldName = "CreatedUserName";
            colCreatedUserName.Name = "colCreatedUserName";
            colCreatedUserName.Width = 87;
            // 
            // colCreatedDate
            // 
            colCreatedDate.FieldName = "CreatedDate";
            colCreatedDate.Name = "colCreatedDate";
            colCreatedDate.Width = 88;
            // 
            // colLastUpdatedUserName
            // 
            colLastUpdatedUserName.FieldName = "LastUpdatedUserName";
            colLastUpdatedUserName.Name = "colLastUpdatedUserName";
            colLastUpdatedUserName.Width = 112;
            // 
            // colLastUpdatedDate
            // 
            colLastUpdatedDate.FieldName = "LastUpdatedDate";
            colLastUpdatedDate.Name = "colLastUpdatedDate";
            colLastUpdatedDate.Width = 113;
            // 
            // FormLoyaltyCards
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gridControl1);
            Controls.Add(ribbonControl1);
            Name = "FormLoyaltyCards";
            Ribbon = ribbonControl1;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dcLoyaltyCardBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private BindingSource dcLoyaltyCardBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colLoyaltyCardId;
        private DevExpress.XtraGrid.Columns.GridColumn colCardNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colLoyaltyProgramId;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colRowVersion;
        private DevExpress.XtraGrid.Columns.GridColumn colLoyaltyProgram;
        private DevExpress.XtraGrid.Columns.GridColumn colDcCurrAcc;
        private DevExpress.XtraGrid.Columns.GridColumn colLoyaltyTxns;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedDate;
        private DevExpress.XtraBars.BarButtonItem BBI_New;
        private DevExpress.XtraBars.BarButtonItem BBI_Edit;
        private DevExpress.XtraBars.BarButtonItem BBI_Refresh;
        private DevExpress.XtraBars.BarButtonItem BBI_Delete;
    }
}