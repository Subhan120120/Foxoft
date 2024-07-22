namespace Foxoft
{
    partial class FormCurrAccRole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCurrAccRole));
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            BBI_Add = new DevExpress.XtraBars.BarButtonItem();
            BBI_Update = new DevExpress.XtraBars.BarButtonItem();
            BBI_Delete = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            btnEdit_CurrAccCode = new DevExpress.XtraEditors.ButtonEdit();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            bindingSource1 = new BindingSource(components);
            gV_CurrAccRole = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCurrAccRoleId = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colRoleCode = new DevExpress.XtraGrid.Columns.GridColumn();
            col_CurrAccDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            col_RoleDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_CurrAccCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_CurrAccRole).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbon.ExpandCollapseItem, BBI_Add, BBI_Update, BBI_Delete });
            ribbon.Location = new Point(0, 0);
            ribbon.MaxItemId = 4;
            ribbon.Name = "ribbon";
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbon.Size = new Size(981, 158);
            ribbon.StatusBar = ribbonStatusBar;
            // 
            // BBI_Add
            // 
            BBI_Add.Caption = "Əlavə Et";
            BBI_Add.Id = 1;
            BBI_Add.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Add.ImageOptions.SvgImage");
            BBI_Add.Name = "BBI_Add";
            BBI_Add.ItemClick += BBI_Add_ItemClick;
            // 
            // BBI_Update
            // 
            BBI_Update.Caption = "Yenilə";
            BBI_Update.Id = 2;
            BBI_Update.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Update.ImageOptions.SvgImage");
            BBI_Update.Name = "BBI_Update";
            // 
            // BBI_Delete
            // 
            BBI_Delete.Caption = "Sil";
            BBI_Delete.Id = 3;
            BBI_Delete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Delete.ImageOptions.SvgImage");
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
            ribbonPageGroup1.ItemLinks.Add(BBI_Add);
            ribbonPageGroup1.ItemLinks.Add(BBI_Update);
            ribbonPageGroup1.ItemLinks.Add(BBI_Delete);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Əməliyatlar";
            // 
            // ribbonStatusBar
            // 
            ribbonStatusBar.Location = new Point(0, 524);
            ribbonStatusBar.Name = "ribbonStatusBar";
            ribbonStatusBar.Ribbon = ribbon;
            ribbonStatusBar.Size = new Size(981, 24);
            // 
            // btnEdit_CurrAccCode
            // 
            btnEdit_CurrAccCode.Location = new Point(76, 12);
            btnEdit_CurrAccCode.MenuManager = ribbon;
            btnEdit_CurrAccCode.Name = "btnEdit_CurrAccCode";
            btnEdit_CurrAccCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            btnEdit_CurrAccCode.Size = new Size(893, 20);
            btnEdit_CurrAccCode.StyleController = layoutControl1;
            btnEdit_CurrAccCode.TabIndex = 2;
            btnEdit_CurrAccCode.ButtonPressed += btnEdit_CurrAccCode_ButtonPressed;
            btnEdit_CurrAccCode.EditValueChanged += btnEdit_CurrAccCode_EditValueChanged;
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(gridControl1);
            layoutControl1.Controls.Add(btnEdit_CurrAccCode);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 158);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(228, 0, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(981, 366);
            layoutControl1.TabIndex = 3;
            layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            gridControl1.DataSource = bindingSource1;
            gridControl1.Location = new Point(12, 36);
            gridControl1.MainView = gV_CurrAccRole;
            gridControl1.MenuManager = ribbon;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(957, 318);
            gridControl1.TabIndex = 4;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_CurrAccRole });
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = typeof(Models.TrCurrAccRole);
            // 
            // gV_CurrAccRole
            // 
            gV_CurrAccRole.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCurrAccRoleId, colCurrAccCode, colRoleCode, col_CurrAccDesc, col_RoleDesc });
            gV_CurrAccRole.GridControl = gridControl1;
            gV_CurrAccRole.Name = "gV_CurrAccRole";
            gV_CurrAccRole.CustomUnboundColumnData += gV_CurrAccRole_CustomUnboundColumnData;
            // 
            // colCurrAccRoleId
            // 
            colCurrAccRoleId.FieldName = "CurrAccRoleId";
            colCurrAccRoleId.Name = "colCurrAccRoleId";
            colCurrAccRoleId.Visible = true;
            colCurrAccRoleId.VisibleIndex = 0;
            // 
            // colCurrAccCode
            // 
            colCurrAccCode.FieldName = "CurrAccCode";
            colCurrAccCode.Name = "colCurrAccCode";
            colCurrAccCode.Visible = true;
            colCurrAccCode.VisibleIndex = 1;
            // 
            // colRoleCode
            // 
            colRoleCode.FieldName = "RoleCode";
            colRoleCode.Name = "colRoleCode";
            colRoleCode.Visible = true;
            colRoleCode.VisibleIndex = 2;
            // 
            // col_CurrAccDesc
            // 
            col_CurrAccDesc.Caption = "gridColumn1";
            col_CurrAccDesc.FieldName = "DcCurrAcc.FirstName";
            col_CurrAccDesc.Name = "col_CurrAccDesc";
            col_CurrAccDesc.UnboundDataType = typeof(string);
            col_CurrAccDesc.Visible = true;
            col_CurrAccDesc.VisibleIndex = 3;
            // 
            // col_RoleDesc
            // 
            col_RoleDesc.Caption = "gridColumn2";
            col_RoleDesc.FieldName = "DcRole.RoleDesc";
            col_RoleDesc.Name = "col_RoleDesc";
            col_RoleDesc.UnboundDataType = typeof(string);
            col_RoleDesc.Visible = true;
            col_RoleDesc.VisibleIndex = 4;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2 });
            Root.Name = "Root";
            Root.Size = new Size(981, 366);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = btnEdit_CurrAccCode;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(961, 24);
            layoutControlItem1.Text = "Cari Hesab";
            layoutControlItem1.TextSize = new Size(52, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = gridControl1;
            layoutControlItem2.Location = new Point(0, 24);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(961, 322);
            layoutControlItem2.TextSize = new Size(0, 0);
            layoutControlItem2.TextVisible = false;
            // 
            // FormCurrAccRole
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(981, 548);
            Controls.Add(layoutControl1);
            Controls.Add(ribbonStatusBar);
            Controls.Add(ribbon);
            Name = "FormCurrAccRole";
            Ribbon = ribbon;
            StatusBar = ribbonStatusBar;
            Text = "FormCurrAccRole";
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_CurrAccCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_CurrAccRole).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.ButtonEdit btnEdit_CurrAccCode;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_CurrAccRole;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccRoleId;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRoleCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_CurrAccDesc;
        private DevExpress.XtraGrid.Columns.GridColumn col_RoleDesc;
        private DevExpress.XtraBars.BarButtonItem BBI_Add;
        private DevExpress.XtraBars.BarButtonItem BBI_Update;
        private DevExpress.XtraBars.BarButtonItem BBI_Delete;
    }
}