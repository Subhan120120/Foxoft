using Foxoft.Models;
using Foxoft.Properties;

namespace Foxoft
{
    partial class FormInvoiceLineList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInvoiceLineList));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            gC_InvoiceLineList = new DevExpress.XtraGrid.GridControl();
            trInvoiceHeadersBindingSource = new BindingSource(components);
            gV_InvoiceLineList = new DevExpress.XtraGrid.Views.Grid.GridView();
            colDocumentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsReturn = new DevExpress.XtraGrid.Columns.GridColumn();
            colDocumentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colDocumentTime = new DevExpress.XtraGrid.Columns.GridColumn();
            colOperationDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colOperationTime = new DevExpress.XtraGrid.Columns.GridColumn();
            colStoreCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colTotalNetAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrAccDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colWarehouseCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colToWarehouseCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colInvoiceLineId = new DevExpress.XtraGrid.Columns.GridColumn();
            colInvoiceHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            colPriceLoc = new DevExpress.XtraGrid.Columns.GridColumn();
            colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colSerialNumberCode = new DevExpress.XtraGrid.Columns.GridColumn();
            btnEdit_FindBarcode = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)gC_InvoiceLineList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trInvoiceHeadersBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_InvoiceLineList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_FindBarcode.Properties).BeginInit();
            SuspendLayout();
            // 
            // gC_InvoiceLineList
            // 
            gC_InvoiceLineList.DataSource = trInvoiceHeadersBindingSource;
            gC_InvoiceLineList.Dock = DockStyle.Fill;
            gC_InvoiceLineList.Location = new Point(0, 0);
            gC_InvoiceLineList.MainView = gV_InvoiceLineList;
            gC_InvoiceLineList.Name = "gC_InvoiceLineList";
            gC_InvoiceLineList.Size = new Size(872, 475);
            gC_InvoiceLineList.TabIndex = 0;
            gC_InvoiceLineList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_InvoiceLineList });
            gC_InvoiceLineList.Paint += gC_InvoiceHeaderList_Paint;
            gC_InvoiceLineList.ProcessGridKey += gC_InvoiceLineList_ProcessGridKey;
            // 
            // trInvoiceHeadersBindingSource
            // 
            trInvoiceHeadersBindingSource.DataSource = typeof(TrInvoiceHeader);
            // 
            // gV_InvoiceLineList
            // 
            gV_InvoiceLineList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colDocumentNumber,
                colIsReturn,
                colDocumentDate,
                colCurrAccCode,
                colDocumentTime,
                colOperationDate,
                colOperationTime,
                colStoreCode,
                colTotalNetAmount,
                colCurrAccDesc,
                colWarehouseCode,
                colToWarehouseCode,
                colProductCode,
                colProductDesc,
                colInvoiceLineId,
                colInvoiceHeaderId,
                colCurrencyCode,
                colPrice,
                colPriceLoc,
                colQty,
                colSerialNumberCode
            });
            gV_InvoiceLineList.CustomizationFormBounds = new Rectangle(622, 285, 264, 272);
            gV_InvoiceLineList.GridControl = gC_InvoiceLineList;
            gV_InvoiceLineList.Name = "gV_InvoiceLineList";
            gV_InvoiceLineList.OptionsFind.AlwaysVisible = true;
            gV_InvoiceLineList.OptionsFind.FindDelay = 100;
            gV_InvoiceLineList.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            gV_InvoiceLineList.OptionsFind.FindPanelLocation = DevExpress.XtraGrid.Views.Grid.GridFindPanelLocation.Panel;
            gV_InvoiceLineList.OptionsFind.ShowFindButton = false;
            gV_InvoiceLineList.OptionsView.FilterCriteriaDisplayStyle = DevExpress.XtraEditors.FilterCriteriaDisplayStyle.Visual;
            gV_InvoiceLineList.OptionsView.ShowAutoFilterRow = true;
            gV_InvoiceLineList.RowStyle += gV_InvoiceHeaderList_RowStyle;
            gV_InvoiceLineList.FocusedRowChanged += gV_InvoiceLineList_FocusedRowChanged;
            gV_InvoiceLineList.CellValueChanging += gV_InvoiceHeaderList_CellValueChanging;
            gV_InvoiceLineList.ColumnFilterChanged += gV_InvoiceLineList_ColumnFilterChanged;
            gV_InvoiceLineList.DoubleClick += gV_TrInvoiceHeaderList_DoubleClick;
            // 
            // colDocumentNumber
            // 
            colDocumentNumber.Caption = Resources.Entity_InvoiceHeader_DocumentNumber;
            colDocumentNumber.FieldName = "DocumentNumber";
            colDocumentNumber.Name = "colDocumentNumber";
            colDocumentNumber.Visible = true;
            colDocumentNumber.VisibleIndex = 0;
            colDocumentNumber.Width = 169;
            // 
            // colIsReturn
            // 
            colIsReturn.Caption = Resources.Entity_InvoiceHeader_IsReturn;
            colIsReturn.FieldName = "IsReturn";
            colIsReturn.Name = "colIsReturn";
            colIsReturn.Width = 93;
            // 
            // colDocumentDate
            // 
            colDocumentDate.Caption = Resources.Entity_InvoiceHeader_DocumentDate;
            colDocumentDate.FieldName = "DocumentDate";
            colDocumentDate.Name = "colDocumentDate";
            colDocumentDate.Visible = true;
            colDocumentDate.VisibleIndex = 1;
            colDocumentDate.Width = 194;
            // 
            // colCurrAccCode
            // 
            colCurrAccCode.Caption = Resources.Entity_CurrAcc_Code;
            colCurrAccCode.FieldName = "CurrAccCode";
            colCurrAccCode.Name = "colCurrAccCode";
            // 
            // colDocumentTime
            // 
            colDocumentTime.Caption = Resources.Entity_InvoiceHeader_DocumentTime;
            colDocumentTime.FieldName = "DocumentTime";
            colDocumentTime.Name = "colDocumentTime";
            // 
            // colOperationDate
            // 
            colOperationDate.Caption = Resources.Entity_InvoiceHeader_OperationDate;
            colOperationDate.FieldName = "OperationDate";
            colOperationDate.Name = "colOperationDate";
            // 
            // colOperationTime
            // 
            colOperationTime.Caption = Resources.Entity_InvoiceHeader_OperationTime;
            colOperationTime.FieldName = "OperationTime";
            colOperationTime.Name = "colOperationTime";
            // 
            // colStoreCode
            // 
            colStoreCode.Caption = Resources.Entity_InvoiceHeader_StoreCode;
            colStoreCode.FieldName = "StoreCode";
            colStoreCode.Name = "colStoreCode";
            // 
            // colTotalNetAmount
            // 
            colTotalNetAmount.Caption = Resources.Entity_InvoiceHeader_TotalNetAmount;
            colTotalNetAmount.FieldName = "TotalNetAmount";
            colTotalNetAmount.Name = "colTotalNetAmount";
            colTotalNetAmount.Width = 194;
            // 
            // colCurrAccDesc
            // 
            colCurrAccDesc.Caption = Resources.Entity_CurrAcc_Desc;
            colCurrAccDesc.FieldName = "CurrAccDesc";
            colCurrAccDesc.Name = "colCurrAccDesc";
            colCurrAccDesc.Visible = true;
            colCurrAccDesc.VisibleIndex = 2;
            colCurrAccDesc.Width = 197;
            // 
            // colWarehouseCode
            // 
            colWarehouseCode.Caption = Resources.Entity_InvoiceHeader_WarehouseCode;
            colWarehouseCode.FieldName = "WarehouseCode";
            colWarehouseCode.Name = "colWarehouseCode";
            // 
            // colToWarehouseCode
            // 
            colToWarehouseCode.Caption = Resources.Entity_InvoiceHeader_ToWarehouseCode;
            colToWarehouseCode.FieldName = "ToWarehouseCode";
            colToWarehouseCode.Name = "colToWarehouseCode";
            // 
            // colProductCode
            // 
            colProductCode.Caption = Resources.Form_InvoiceLineList_Column_ProductCode;
            colProductCode.FieldName = "ProductCode";
            colProductCode.Name = "colProductCode";
            // 
            // colProductDesc
            // 
            colProductDesc.Caption = Resources.Form_InvoiceLineList_Column_ProductDesc;
            colProductDesc.FieldName = "ProductDesc";
            colProductDesc.Name = "colProductDesc";
            colProductDesc.Visible = true;
            colProductDesc.VisibleIndex = 3;
            // 
            // colInvoiceLineId
            // 
            colInvoiceLineId.Caption = Resources.Entity_InvoiceLineExt_Id;
            colInvoiceLineId.FieldName = "InvoiceLineId";
            colInvoiceLineId.Name = "colInvoiceLineId";
            // 
            // colInvoiceHeaderId
            // 
            colInvoiceHeaderId.Caption = Resources.Entity_InvoiceHeader_InvoiceHeaderId;
            colInvoiceHeaderId.FieldName = "InvoiceHeaderId";
            colInvoiceHeaderId.Name = "colInvoiceHeaderId";
            // 
            // colCurrencyCode
            // 
            colCurrencyCode.Caption = Resources.Form_InvoiceLineList_Column_CurrencyCode;
            colCurrencyCode.FieldName = "CurrencyCode";
            colCurrencyCode.Name = "colCurrencyCode";
            colCurrencyCode.Visible = true;
            colCurrencyCode.VisibleIndex = 6;
            // 
            // colPrice
            // 
            colPrice.Caption = Resources.Form_InvoiceLineList_Column_Price;
            colPrice.FieldName = "Price";
            colPrice.Name = "colPrice";
            colPrice.Visible = true;
            colPrice.VisibleIndex = 5;
            // 
            // colPriceLoc
            // 
            colPriceLoc.Caption = Resources.Form_InvoiceLineList_Column_PriceLoc;
            colPriceLoc.FieldName = "PriceLoc";
            colPriceLoc.Name = "colPriceLoc";
            // 
            // colQty
            // 
            colQty.Caption = Resources.Form_InvoiceLineList_Column_Qty;
            colQty.FieldName = "Qty";
            colQty.Name = "colQty";
            colQty.Visible = true;
            colQty.VisibleIndex = 4;
            // 
            // colSerialNumberCode
            // 
            colSerialNumberCode.Caption = Resources.Form_InvoiceLineList_Column_SerialNumberCode;
            colSerialNumberCode.FieldName = "SerialNumberCode";
            colSerialNumberCode.Name = "colSerialNumberCode";
            colSerialNumberCode.Visible = true;
            colSerialNumberCode.VisibleIndex = 7;
            // 
            // btnEdit_FindBarcode
            // 
            btnEdit_FindBarcode.EditValue = "";
            btnEdit_FindBarcode.Location = new Point(439, 13);
            btnEdit_FindBarcode.Name = "btnEdit_FindBarcode";
            editorButtonImageOptions1.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("editorButtonImageOptions1.SvgImage");
            editorButtonImageOptions1.SvgImageSize = new Size(13, 13);
            btnEdit_FindBarcode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(
                    DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph,
                    "",
                    -1,
                    true,
                    true,
                    false,
                    editorButtonImageOptions1,
                    new DevExpress.Utils.KeyShortcut(Keys.None),
                    serializableAppearanceObject1,
                    serializableAppearanceObject2,
                    serializableAppearanceObject3,
                    serializableAppearanceObject4,
                    "",
                    null,
                    null,
                    DevExpress.Utils.ToolTipAnchor.Default)
            });
            btnEdit_FindBarcode.Size = new Size(214, 21);
            btnEdit_FindBarcode.TabIndex = 1;
            btnEdit_FindBarcode.EditValueChanged += BtnEdit_FindBarcode_EditValueChanged;
            // 
            // FormInvoiceLineList
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(872, 475);
            Controls.Add(btnEdit_FindBarcode);
            Controls.Add(gC_InvoiceLineList);
            Name = "FormInvoiceLineList";
            StartPosition = FormStartPosition.CenterParent;
            Text = Resources.Form_InvoiceLineList_Caption;
            ((System.ComponentModel.ISupportInitialize)gC_InvoiceLineList).EndInit();
            ((System.ComponentModel.ISupportInitialize)trInvoiceHeadersBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_InvoiceLineList).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_FindBarcode.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gC_InvoiceLineList;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_InvoiceLineList;
        private System.Windows.Forms.BindingSource trInvoiceHeadersBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colOperationDate;
        private DevExpress.XtraGrid.Columns.GridColumn colOperationTime;
        private DevExpress.XtraGrid.Columns.GridColumn colIsReturn;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentTime;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalNetAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouseCode;
        private DevExpress.XtraGrid.Columns.GridColumn colToWarehouseCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProductDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceLineId;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceLoc;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colSerialNumberCode;
        private DevExpress.XtraEditors.ButtonEdit btnEdit_FindBarcode;
    }
}
