namespace Foxoft
{
    partial class FormHierarchyFeatureType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHierarchyFeatureType));
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            BBI_Add = new DevExpress.XtraBars.BarButtonItem();
            BBI_Update = new DevExpress.XtraBars.BarButtonItem();
            BBI_Delete = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            Əməliyatlar = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            myGridControl1 = new MyGridControl();
            bindingSource1 = new System.Windows.Forms.BindingSource(components);
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colFeatureTypeId = new DevExpress.XtraGrid.Columns.GridColumn();
            colFeatureTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            colHierarchyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colHierarchyDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            btn_Hierarchy = new DevExpress.XtraEditors.ButtonEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            LCI_Hierarchy = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)myGridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_Hierarchy.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_Hierarchy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                ribbon.ExpandCollapseItem,
                BBI_Add,
                BBI_Update,
                BBI_Delete
            });
            ribbon.Location = new System.Drawing.Point(0, 0);
            ribbon.MaxItemId = 4;
            ribbon.Name = "ribbon";
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbon.Size = new System.Drawing.Size(1236, 158);
            ribbon.StatusBar = ribbonStatusBar;
            // 
            // BBI_Add
            // 
            BBI_Add.Caption = Foxoft.Properties.Resources.Common_New;
            BBI_Add.Id = 1;
            BBI_Add.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Add.ImageOptions.SvgImage");
            BBI_Add.Name = "BBI_Add";
            BBI_Add.ItemClick += BBI_FeatureTypeAdd_ItemClick;
            // 
            // BBI_Update
            // 
            BBI_Update.Caption = Foxoft.Properties.Resources.Common_Refresh;
            BBI_Update.Id = 2;
            BBI_Update.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Update.ImageOptions.SvgImage");
            BBI_Update.Name = "BBI_Update";
            BBI_Update.ItemClick += BBI_Update_ItemClick;
            // 
            // BBI_Delete
            // 
            BBI_Delete.Caption = Foxoft.Properties.Resources.Common_Delete;
            BBI_Delete.Id = 3;
            BBI_Delete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Delete.ImageOptions.SvgImage");
            BBI_Delete.Name = "BBI_Delete";
            BBI_Delete.ItemClick += BBI_Delete_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { Əməliyatlar });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = Foxoft.Properties.Resources.Form_HierarchyFeatureType_Caption;
            // 
            // Əməliyatlar
            // 
            Əməliyatlar.ItemLinks.Add(BBI_Add);
            Əməliyatlar.ItemLinks.Add(BBI_Update);
            Əməliyatlar.ItemLinks.Add(BBI_Delete);
            Əməliyatlar.Name = "Əməliyatlar";
            Əməliyatlar.Text = Foxoft.Properties.Resources.Common_Operations;
            // 
            // ribbonStatusBar
            // 
            ribbonStatusBar.Location = new System.Drawing.Point(0, 586);
            ribbonStatusBar.Name = "ribbonStatusBar";
            ribbonStatusBar.Ribbon = ribbon;
            ribbonStatusBar.Size = new System.Drawing.Size(1236, 24);
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(myGridControl1);
            layoutControl1.Controls.Add(btn_Hierarchy);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 158);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize =
                new System.Drawing.Rectangle(1270, 295, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(1236, 428);
            layoutControl1.TabIndex = 2;
            layoutControl1.Text = "layoutControl1";
            // 
            // myGridControl1
            // 
            myGridControl1.DataSource = bindingSource1;
            myGridControl1.Location = new System.Drawing.Point(12, 36);
            myGridControl1.MainView = gridView1;
            myGridControl1.MenuManager = ribbon;
            myGridControl1.Name = "myGridControl1";
            myGridControl1.Size = new System.Drawing.Size(1212, 380);
            myGridControl1.TabIndex = 5;
            myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = typeof(Models.TrHierarchyFeatureType);
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colFeatureTypeId,
                colFeatureTypeName,
                colHierarchyCode,
                colHierarchyDesc
            });
            gridView1.GridControl = myGridControl1;
            gridView1.Name = "gridView1";
            gridView1.CustomUnboundColumnData += gV_PriceListLine_CustomUnboundColumnData;
            // 
            // colFeatureTypeId
            // 
            colFeatureTypeId.FieldName = "FeatureTypeId";
            colFeatureTypeId.Name = "colFeatureTypeId";
            colFeatureTypeId.Visible = true;
            colFeatureTypeId.VisibleIndex = 0;
            // 
            // colFeatureTypeName
            // 
            colFeatureTypeName.FieldName = "DcFeatureType.FeatureTypeName";
            colFeatureTypeName.Name = "colFeatureTypeName";
            colFeatureTypeName.UnboundDataType = typeof(string);
            colFeatureTypeName.Visible = true;
            colFeatureTypeName.VisibleIndex = 1;
            // 
            // colHierarchyCode
            // 
            colHierarchyCode.FieldName = "HierarchyCode";
            colHierarchyCode.Name = "colHierarchyCode";
            colHierarchyCode.Visible = true;
            colHierarchyCode.VisibleIndex = 2;
            // 
            // colHierarchyDesc
            // 
            colHierarchyDesc.FieldName = "DcHierarchy.HierarchyDesc";
            colHierarchyDesc.Name = "colHierarchyDesc";
            colHierarchyDesc.UnboundDataType = typeof(string);
            colHierarchyDesc.Visible = true;
            colHierarchyDesc.VisibleIndex = 3;
            // 
            // btn_Hierarchy
            // 
            btn_Hierarchy.EditValue = "";
            btn_Hierarchy.Location = new System.Drawing.Point(74, 12);
            btn_Hierarchy.MenuManager = ribbon;
            btn_Hierarchy.Name = "btn_Hierarchy";
            btn_Hierarchy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton()
            });
            btn_Hierarchy.Size = new System.Drawing.Size(1150, 20);
            btn_Hierarchy.StyleController = layoutControl1;
            btn_Hierarchy.TabIndex = 3;
            btn_Hierarchy.ButtonPressed += btn_Hierarchy_ButtonPressed;
            btn_Hierarchy.EditValueChanged += btn_Hierarchy_EditValueChanged;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                LCI_Hierarchy,
                layoutControlItem1
            });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(1236, 428);
            Root.TextVisible = false;
            // 
            // LCI_Hierarchy
            // 
            LCI_Hierarchy.Control = btn_Hierarchy;
            LCI_Hierarchy.Location = new System.Drawing.Point(0, 0);
            LCI_Hierarchy.Name = "LCI_Hierarchy";
            LCI_Hierarchy.Size = new System.Drawing.Size(1216, 24);
            LCI_Hierarchy.Text = Foxoft.Properties.Resources.Entity_Hierarchy;
            LCI_Hierarchy.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = myGridControl1;
            layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(1216, 384);
            layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // FormHierarchyFeatureType
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1236, 610);
            Controls.Add(layoutControl1);
            Controls.Add(ribbonStatusBar);
            Controls.Add(ribbon);
            Name = "FormHierarchyFeatureType";
            Ribbon = ribbon;
            StatusBar = ribbonStatusBar;
            Text = Foxoft.Properties.Resources.Form_HierarchyFeatureType_Caption;
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)myGridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_Hierarchy.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_Hierarchy).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup Əməliyatlar;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.ButtonEdit btn_Hierarchy;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem LCI_Hierarchy;
        private MyGridControl myGridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colDcHierarchy;
        private DevExpress.XtraGrid.Columns.GridColumn colDcFeatureType;
        private DevExpress.XtraBars.BarButtonItem BBI_Delete;
        private DevExpress.XtraBars.BarButtonItem BBI_Add;
        private DevExpress.XtraGrid.Columns.GridColumn colFeatureTypeId;
        private DevExpress.XtraGrid.Columns.GridColumn colFeatureTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colFilterable;
        private DevExpress.XtraGrid.Columns.GridColumn colOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colHierarchyDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colHierarchyCode;
        private DevExpress.XtraBars.BarButtonItem BBI_Update;
    }
}
