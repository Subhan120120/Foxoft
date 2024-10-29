using Foxoft.Models;

namespace Foxoft
{
    partial class FormProductBarcode
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProductBarcode));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            GC_ProductBarcode = new MyGridControl();
            bindingSourceProductBarcode = new System.Windows.Forms.BindingSource(components);
            gV_ProductBarcode = new DevExpress.XtraGrid.Views.Grid.GridView();
            colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            RepoBtnEdit_BarcodeGenerate = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            colBarcodeTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            RepoBtnEdit_BarcodeType = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            RepoBtnEdit_ProductCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colId = new DevExpress.XtraGrid.Columns.GridColumn();
            colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            BBI_PrintBarcode = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)GC_ProductBarcode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceProductBarcode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_ProductBarcode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RepoBtnEdit_BarcodeGenerate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RepoBtnEdit_BarcodeType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RepoBtnEdit_ProductCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            SuspendLayout();
            // 
            // GC_ProductBarcode
            // 
            GC_ProductBarcode.DataSource = bindingSourceProductBarcode;
            GC_ProductBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            GC_ProductBarcode.Location = new System.Drawing.Point(0, 158);
            GC_ProductBarcode.MainView = gV_ProductBarcode;
            GC_ProductBarcode.Name = "GC_ProductBarcode";
            GC_ProductBarcode.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { RepoBtnEdit_BarcodeType, RepoBtnEdit_BarcodeGenerate, RepoBtnEdit_ProductCode });
            GC_ProductBarcode.Size = new System.Drawing.Size(800, 292);
            GC_ProductBarcode.TabIndex = 0;
            GC_ProductBarcode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_ProductBarcode });
            GC_ProductBarcode.Click += myGridControl1_Click;
            GC_ProductBarcode.KeyDown += GC_ProductBarcode_KeyDown;
            // 
            // bindingSourceProductBarcode
            // 
            bindingSourceProductBarcode.DataSource = typeof(TrProductBarcode);
            // 
            // GV_ProductBarcode
            // 
            gV_ProductBarcode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colBarcode, colBarcodeTypeCode, colProductCode, colCreatedDate, colCreatedUserName, colLastUpdatedDate, colLastUpdatedUserName, colId, colQty });
            gV_ProductBarcode.GridControl = GC_ProductBarcode;
            gV_ProductBarcode.Name = "GV_ProductBarcode";
            gV_ProductBarcode.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gV_ProductBarcode.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gV_ProductBarcode.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            gV_ProductBarcode.OptionsView.ShowGroupPanel = false;
            gV_ProductBarcode.InitNewRow += GV_ProductBarcode_InitNewRow;
            gV_ProductBarcode.RowDeleted += GV_ProductBarcode_RowDeleted;
            gV_ProductBarcode.RowUpdated += GV_ProductBarcode_RowUpdated;
            gV_ProductBarcode.ValidatingEditor += GV_ProductBarcode_ValidatingEditor;
            gV_ProductBarcode.InvalidValueException += GV_ProductBarcode_InvalidValueException;
            // 
            // colBarcode
            // 
            colBarcode.ColumnEdit = RepoBtnEdit_BarcodeGenerate;
            colBarcode.FieldName = "Barcode";
            colBarcode.Name = "colBarcode";
            colBarcode.Visible = true;
            colBarcode.VisibleIndex = 0;
            // 
            // RepoBtnEdit_BarcodeGenerate
            // 
            RepoBtnEdit_BarcodeGenerate.AutoHeight = false;
            editorButtonImageOptions1.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("editorButtonImageOptions1.SvgImage");
            editorButtonImageOptions1.SvgImageSize = new System.Drawing.Size(16, 16);
            editorButtonImageOptions2.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("editorButtonImageOptions2.SvgImage");
            editorButtonImageOptions2.SvgImageSize = new System.Drawing.Size(16, 16);
            RepoBtnEdit_BarcodeGenerate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default), new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default) });
            RepoBtnEdit_BarcodeGenerate.Name = "RepoBtnEdit_BarcodeGenerate";
            RepoBtnEdit_BarcodeGenerate.ButtonPressed += RepoBtnEdit_Barcode_ButtonPressed;
            // 
            // colBarcodeTypeCode
            // 
            colBarcodeTypeCode.ColumnEdit = RepoBtnEdit_BarcodeType;
            colBarcodeTypeCode.FieldName = "BarcodeTypeCode";
            colBarcodeTypeCode.Name = "colBarcodeTypeCode";
            colBarcodeTypeCode.Visible = true;
            colBarcodeTypeCode.VisibleIndex = 1;
            // 
            // RepoBtnEdit_BarcodeType
            // 
            RepoBtnEdit_BarcodeType.AutoHeight = false;
            RepoBtnEdit_BarcodeType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            RepoBtnEdit_BarcodeType.Name = "RepoBtnEdit_BarcodeType";
            RepoBtnEdit_BarcodeType.ButtonPressed += RepoBtnEdit_BarcodeType_ButtonPressed;
            // 
            // colProductCode
            // 
            colProductCode.ColumnEdit = RepoBtnEdit_ProductCode;
            colProductCode.FieldName = "ProductCode";
            colProductCode.Name = "colProductCode";
            // 
            // RepoBtnEdit_ProductCode
            // 
            RepoBtnEdit_ProductCode.AutoHeight = false;
            RepoBtnEdit_ProductCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            RepoBtnEdit_ProductCode.Name = "RepoBtnEdit_ProductCode";
            RepoBtnEdit_ProductCode.ButtonPressed += RepoBtnEdit_ProductCode_ButtonPressed;
            // 
            // colCreatedDate
            // 
            colCreatedDate.FieldName = "CreatedDate";
            colCreatedDate.Name = "colCreatedDate";
            // 
            // colCreatedUserName
            // 
            colCreatedUserName.FieldName = "CreatedUserName";
            colCreatedUserName.Name = "colCreatedUserName";
            // 
            // colLastUpdatedDate
            // 
            colLastUpdatedDate.FieldName = "LastUpdatedDate";
            colLastUpdatedDate.Name = "colLastUpdatedDate";
            // 
            // colLastUpdatedUserName
            // 
            colLastUpdatedUserName.FieldName = "LastUpdatedUserName";
            colLastUpdatedUserName.Name = "colLastUpdatedUserName";
            // 
            // colId
            // 
            colId.FieldName = "Id";
            colId.Name = "colId";
            // 
            // colQty
            // 
            colQty.FieldName = "Qty";
            colQty.Name = "colQty";
            colQty.Visible = true;
            colQty.VisibleIndex = 2;
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, ribbonControl1.SearchEditItem, BBI_PrintBarcode });
            ribbonControl1.Location = new System.Drawing.Point(0, 0);
            ribbonControl1.MaxItemId = 2;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new System.Drawing.Size(800, 158);
            // 
            // barButtonItem1
            // 
            BBI_PrintBarcode.Caption = "Barkod";
            BBI_PrintBarcode.Id = 1;
            BBI_PrintBarcode.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem1.ImageOptions.SvgImage");
            BBI_PrintBarcode.Name = "barButtonItem1";
            BBI_PrintBarcode.ItemClick += BBI_PrintBarcode_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(BBI_PrintBarcode);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "İdarə";
            // 
            // FormProductBarcode
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(GC_ProductBarcode);
            Controls.Add(ribbonControl1);
            Name = "FormProductBarcode";
            Ribbon = ribbonControl1;
            Text = "FormBarcode";
            ((System.ComponentModel.ISupportInitialize)GC_ProductBarcode).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceProductBarcode).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_ProductBarcode).EndInit();
            ((System.ComponentModel.ISupportInitialize)RepoBtnEdit_BarcodeGenerate).EndInit();
            ((System.ComponentModel.ISupportInitialize)RepoBtnEdit_BarcodeType).EndInit();
            ((System.ComponentModel.ISupportInitialize)RepoBtnEdit_ProductCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MyGridControl myGridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_ProductBarcode;
        private System.Windows.Forms.BindingSource bindingSourceProductBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcodeTypeCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedUserName;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit RepoBtnEdit_BarcodeType;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedUserName;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit RepoBtnEdit_Barcode;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit RepoBtnEdit_ProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private MyGridControl GC_ProductBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit RepoBtnEdit_BarcodeGenerate;
        private DevExpress.XtraBars.BarButtonItem BBI_PrintBarcode;
    }
}