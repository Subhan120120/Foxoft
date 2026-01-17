using DevExpress.XtraEditors;
using Foxoft.Models;
using Foxoft.Properties;

namespace Foxoft
{
    partial class FormBarcodeOperations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBarcodeOperations));
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            BBI_New = new DevExpress.XtraBars.BarButtonItem();
            BBI_Save = new DevExpress.XtraBars.BarButtonItem();
            BBI_Delete = new DevExpress.XtraBars.BarButtonItem();
            BBI_BarcodePreview = new DevExpress.XtraBars.BarButtonItem();
            BBI_ImportFromXLSX = new DevExpress.XtraBars.BarButtonItem();
            BBI_ExportToXLSX = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            trBarcodeOperationLinesBindingSource = new BindingSource(components);
            trBarcodeOperationHeaderBindingSource = new BindingSource(components);
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colId = new DevExpress.XtraGrid.Columns.GridColumn();
            colBarcodeOperationHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colBarcodeTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            NameTextEdit = new TextEdit();
            IdButtonEdit = new ButtonEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForId = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForName = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trBarcodeOperationLinesBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trBarcodeOperationHeaderBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).BeginInit();
            dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NameTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IdButtonEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            SuspendLayout();
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, BBI_New, BBI_Save, BBI_Delete, BBI_BarcodePreview, BBI_ImportFromXLSX, BBI_ExportToXLSX });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 7;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(1120, 158);
            // 
            // BBI_New
            // 
            BBI_New.Caption = "New";
            BBI_New.Id = 1;
            BBI_New.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_New.ImageOptions.SvgImage");
            BBI_New.Name = "BBI_New";
            BBI_New.ItemClick += BBI_New_ItemClick;
            // 
            // BBI_Save
            // 
            BBI_Save.Caption = "Save";
            BBI_Save.Id = 2;
            BBI_Save.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Save.ImageOptions.SvgImage");
            BBI_Save.Name = "BBI_Save";
            // 
            // BBI_Delete
            // 
            BBI_Delete.Caption = "Delete";
            BBI_Delete.Id = 3;
            BBI_Delete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Delete.ImageOptions.SvgImage");
            BBI_Delete.Name = "BBI_Delete";
            BBI_Delete.ItemClick += BBI_Delete_ItemClick;
            // 
            // BBI_BarcodePreview
            // 
            BBI_BarcodePreview.Caption = "Barcode Preview";
            BBI_BarcodePreview.Id = 4;
            BBI_BarcodePreview.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_BarcodePreview.ImageOptions.SvgImage");
            BBI_BarcodePreview.Name = "BBI_BarcodePreview";
            BBI_BarcodePreview.ItemClick += BBI_BarcodePreview_ItemClick;
            // 
            // BBI_ImportFromXLSX
            // 
            BBI_ImportFromXLSX.Caption = "Import From XLSX";
            BBI_ImportFromXLSX.Id = 5;
            BBI_ImportFromXLSX.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ImportFromXLSX.ImageOptions.SvgImage");
            BBI_ImportFromXLSX.Name = "BBI_ImportFromXLSX";
            BBI_ImportFromXLSX.ItemClick += BBI_ImportFromXLSX_ItemClick;
            // 
            // BBI_ExportToXLSX
            // 
            BBI_ExportToXLSX.Caption = "Export To XLSX";
            BBI_ExportToXLSX.Id = 6;
            BBI_ExportToXLSX.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ExportToXLSX.ImageOptions.SvgImage");
            BBI_ExportToXLSX.Name = "BBI_ExportToXLSX";
            BBI_ExportToXLSX.ItemClick += BBI_ExportToXLSX_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup3, ribbonPageGroup2 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(BBI_New);
            ribbonPageGroup1.ItemLinks.Add(BBI_Save);
            ribbonPageGroup1.ItemLinks.Add(BBI_Delete);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Operations";
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.ItemLinks.Add(BBI_BarcodePreview);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = "Barcode";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(BBI_ImportFromXLSX);
            ribbonPageGroup2.ItemLinks.Add(BBI_ExportToXLSX);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Tools";
            // 
            // gridControl1
            // 
            gridControl1.DataSource = trBarcodeOperationLinesBindingSource;
            gridControl1.Location = new Point(12, 36);
            gridControl1.MainView = gridView1;
            gridControl1.MenuManager = ribbonControl1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(1096, 352);
            gridControl1.TabIndex = 1;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // trBarcodeOperationLinesBindingSource
            // 
            trBarcodeOperationLinesBindingSource.DataSource = trBarcodeOperationHeaderBindingSource;
            // 
            // trBarcodeOperationHeaderBindingSource
            // 
            trBarcodeOperationHeaderBindingSource.DataSource = typeof(TrBarcodeOperationHeader);
            trBarcodeOperationHeaderBindingSource.CurrentItemChanged += TrBarcodeOperationHeaderBindingSource_CurrentItemChanged;
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colBarcodeOperationHeaderId, colBarcode, colProductCode, colBarcodeTypeCode, colQty, colCreatedUserName, colCreatedDate, colLastUpdatedUserName, colLastUpdatedDate });
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.InitNewRow += gridView1_InitNewRow;
            gridView1.RowUpdated += GridView1_RowUpdated;
            // 
            // colId
            // 
            colId.FieldName = "Id";
            colId.Name = "colId";
            colId.Visible = true;
            colId.VisibleIndex = 0;
            // 
            // colBarcodeOperationHeaderId
            // 
            colBarcodeOperationHeaderId.FieldName = "BarcodeOperationHeaderId";
            colBarcodeOperationHeaderId.Name = "colBarcodeOperationHeaderId";
            // 
            // colBarcode
            // 
            colBarcode.FieldName = "Barcode";
            colBarcode.Name = "colBarcode";
            colBarcode.Visible = true;
            colBarcode.VisibleIndex = 1;
            // 
            // colProductCode
            // 
            colProductCode.FieldName = "ProductCode";
            colProductCode.Name = "colProductCode";
            colProductCode.Visible = true;
            colProductCode.VisibleIndex = 2;
            colProductCode.Width = 88;
            // 
            // colBarcodeTypeCode
            // 
            colBarcodeTypeCode.FieldName = "BarcodeTypeCode";
            colBarcodeTypeCode.Name = "colBarcodeTypeCode";
            colBarcodeTypeCode.Visible = true;
            colBarcodeTypeCode.VisibleIndex = 3;
            colBarcodeTypeCode.Width = 89;
            // 
            // colQty
            // 
            colQty.FieldName = "Qty";
            colQty.Name = "colQty";
            colQty.Visible = true;
            colQty.VisibleIndex = 4;
            // 
            // colCreatedUserName
            // 
            colCreatedUserName.FieldName = "CreatedUserName";
            colCreatedUserName.Name = "colCreatedUserName";
            // 
            // colCreatedDate
            // 
            colCreatedDate.FieldName = "CreatedDate";
            colCreatedDate.Name = "colCreatedDate";
            // 
            // colLastUpdatedUserName
            // 
            colLastUpdatedUserName.FieldName = "LastUpdatedUserName";
            colLastUpdatedUserName.Name = "colLastUpdatedUserName";
            // 
            // colLastUpdatedDate
            // 
            colLastUpdatedDate.FieldName = "LastUpdatedDate";
            colLastUpdatedDate.Name = "colLastUpdatedDate";
            // 
            // dataLayoutControl1
            // 
            dataLayoutControl1.Controls.Add(gridControl1);
            dataLayoutControl1.Controls.Add(NameTextEdit);
            dataLayoutControl1.Controls.Add(IdButtonEdit);
            dataLayoutControl1.DataSource = trBarcodeOperationHeaderBindingSource;
            dataLayoutControl1.Dock = DockStyle.Fill;
            dataLayoutControl1.Location = new Point(0, 158);
            dataLayoutControl1.Name = "dataLayoutControl1";
            dataLayoutControl1.Root = Root;
            dataLayoutControl1.Size = new Size(1120, 400);
            dataLayoutControl1.TabIndex = 2;
            dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // NameTextEdit
            // 
            NameTextEdit.DataBindings.Add(new Binding("EditValue", trBarcodeOperationHeaderBindingSource, "Name", true));
            NameTextEdit.Location = new Point(712, 12);
            NameTextEdit.MenuManager = ribbonControl1;
            NameTextEdit.Name = "NameTextEdit";
            NameTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            NameTextEdit.Size = new Size(396, 20);
            NameTextEdit.StyleController = dataLayoutControl1;
            NameTextEdit.TabIndex = 5;
            // 
            // IdButtonEdit
            // 
            IdButtonEdit.DataBindings.Add(new Binding("EditValue", trBarcodeOperationHeaderBindingSource, "Id", true));
            IdButtonEdit.Location = new Point(162, 12);
            IdButtonEdit.MenuManager = ribbonControl1;
            IdButtonEdit.Name = "IdButtonEdit";
            IdButtonEdit.Properties.Appearance.Options.UseTextOptions = true;
            IdButtonEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            IdButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            IdButtonEdit.Properties.Mask.EditMask = "N0";
            IdButtonEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            IdButtonEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            IdButtonEdit.Size = new Size(396, 20);
            IdButtonEdit.StyleController = dataLayoutControl1;
            IdButtonEdit.TabIndex = 6;
            IdButtonEdit.ButtonClick += IdButtonEdit_ButtonClick;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlGroup1 });
            Root.Name = "Root";
            Root.Size = new Size(1120, 400);
            Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.AllowDrawBackground = false;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForId, ItemForName, layoutControlItem1 });
            layoutControlGroup1.Location = new Point(0, 0);
            layoutControlGroup1.Name = "autoGeneratedGroup0";
            layoutControlGroup1.Size = new Size(1100, 380);
            // 
            // ItemForId
            // 
            ItemForId.Control = IdButtonEdit;
            ItemForId.Location = new Point(0, 0);
            ItemForId.Name = "ItemForId";
            ItemForId.Size = new Size(550, 24);
            ItemForId.TextSize = new Size(138, 13);
            // 
            // ItemForName
            // 
            ItemForName.Control = NameTextEdit;
            ItemForName.Location = new Point(550, 0);
            ItemForName.Name = "ItemForName";
            ItemForName.Size = new Size(550, 24);
            ItemForName.TextSize = new Size(138, 13);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = gridControl1;
            layoutControlItem1.Location = new Point(0, 24);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(1100, 356);
            layoutControlItem1.TextVisible = false;
            // 
            // FormBarcodeOperations
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1120, 558);
            Controls.Add(dataLayoutControl1);
            Controls.Add(ribbonControl1);
            Name = "FormBarcodeOperations";
            Ribbon = ribbonControl1;
            Text = Resources.Form_BarcodeOperations_Title;
            Load += FormBarcodeOperations_Load;
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trBarcodeOperationLinesBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)trBarcodeOperationHeaderBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).EndInit();
            dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NameTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)IdButtonEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForId).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForName).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }




        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit IdTextEdit;
        private BindingSource trBarcodeOperationHeaderBindingSource;
        private DevExpress.XtraEditors.TextEdit NameTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForName;
        private BindingSource trBarcodeOperationLinesBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcodeOperationHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcodeTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedDate;
        private DevExpress.XtraEditors.ButtonEdit IdButtonEdit;
        private DevExpress.XtraBars.BarButtonItem BBI_New;
        private DevExpress.XtraBars.BarButtonItem BBI_Save;
        private DevExpress.XtraBars.BarButtonItem BBI_Delete;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.BarButtonItem BBI_BarcodePreview;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem BBI_ImportFromXLSX;
        private DevExpress.XtraBars.BarButtonItem BBI_ExportToXLSX;
    }
}