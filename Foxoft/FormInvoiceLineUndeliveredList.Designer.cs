﻿
namespace Foxoft
{
    partial class FormInvoiceLineUndeliveredList
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
            gC_InvoiceLineList = new DevExpress.XtraGrid.GridControl();
            trInvoiceHeadersBindingSource = new System.Windows.Forms.BindingSource(components);
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
            ((System.ComponentModel.ISupportInitialize)gC_InvoiceLineList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trInvoiceHeadersBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_InvoiceLineList).BeginInit();
            SuspendLayout();
            // 
            // gC_InvoiceLineList
            // 
            gC_InvoiceLineList.DataSource = trInvoiceHeadersBindingSource;
            gC_InvoiceLineList.Dock = System.Windows.Forms.DockStyle.Fill;
            gC_InvoiceLineList.Location = new System.Drawing.Point(0, 0);
            gC_InvoiceLineList.MainView = gV_InvoiceLineList;
            gC_InvoiceLineList.Name = "gC_InvoiceLineList";
            gC_InvoiceLineList.Size = new System.Drawing.Size(872, 475);
            gC_InvoiceLineList.TabIndex = 0;
            gC_InvoiceLineList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_InvoiceLineList });
            gC_InvoiceLineList.Paint += gC_InvoiceHeaderList_Paint;
            gC_InvoiceLineList.ProcessGridKey += gC_InvoiceLineList_ProcessGridKey;
            // 
            // trInvoiceHeadersBindingSource
            // 
            trInvoiceHeadersBindingSource.DataSource = typeof(Models.TrInvoiceHeader);
            // 
            // gV_InvoiceLineList
            // 
            gV_InvoiceLineList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colDocumentNumber, colIsReturn, colDocumentDate, colCurrAccCode, colDocumentTime, colOperationDate, colOperationTime, colStoreCode, colTotalNetAmount, colCurrAccDesc, colWarehouseCode, colToWarehouseCode, colProductCode, colProductDesc, colInvoiceLineId, colInvoiceHeaderId, colCurrencyCode, colPrice, colPriceLoc, colQty });
            gV_InvoiceLineList.CustomizationFormBounds = new System.Drawing.Rectangle(622, 285, 264, 272);
            gV_InvoiceLineList.GridControl = gC_InvoiceLineList;
            gV_InvoiceLineList.Name = "gV_InvoiceLineList";
            gV_InvoiceLineList.OptionsFind.FindDelay = 100;
            gV_InvoiceLineList.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
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
            colDocumentNumber.FieldName = "DocumentNumber";
            colDocumentNumber.Name = "colDocumentNumber";
            colDocumentNumber.Visible = true;
            colDocumentNumber.VisibleIndex = 0;
            colDocumentNumber.Width = 169;
            // 
            // colIsReturn
            // 
            colIsReturn.FieldName = "IsReturn";
            colIsReturn.Name = "colIsReturn";
            colIsReturn.Width = 93;
            // 
            // colDocumentDate
            // 
            colDocumentDate.FieldName = "DocumentDate";
            colDocumentDate.Name = "colDocumentDate";
            colDocumentDate.Visible = true;
            colDocumentDate.VisibleIndex = 1;
            colDocumentDate.Width = 194;
            // 
            // colCurrAccCode
            // 
            colCurrAccCode.FieldName = "CurrAccCode";
            colCurrAccCode.Name = "colCurrAccCode";
            // 
            // colDocumentTime
            // 
            colDocumentTime.FieldName = "DocumentTime";
            colDocumentTime.Name = "colDocumentTime";
            // 
            // colOperationDate
            // 
            colOperationDate.FieldName = "OperationDate";
            colOperationDate.Name = "colOperationDate";
            // 
            // colOperationTime
            // 
            colOperationTime.FieldName = "OperationTime";
            colOperationTime.Name = "colOperationTime";
            // 
            // colStoreCode
            // 
            colStoreCode.FieldName = "StoreCode";
            colStoreCode.Name = "colStoreCode";
            // 
            // colTotalNetAmount
            // 
            colTotalNetAmount.FieldName = "TotalNetAmount";
            colTotalNetAmount.Name = "colTotalNetAmount";
            colTotalNetAmount.Width = 194;
            // 
            // colCurrAccDesc
            // 
            colCurrAccDesc.FieldName = "CurrAccDesc";
            colCurrAccDesc.Name = "colCurrAccDesc";
            colCurrAccDesc.Visible = true;
            colCurrAccDesc.VisibleIndex = 2;
            colCurrAccDesc.Width = 197;
            // 
            // colWarehouseCode
            // 
            colWarehouseCode.FieldName = "WarehouseCode";
            colWarehouseCode.Name = "colWarehouseCode";
            // 
            // colToWarehouseCode
            // 
            colToWarehouseCode.FieldName = "ToWarehouseCode";
            colToWarehouseCode.Name = "colToWarehouseCode";
            // 
            // colProductCode
            // 
            colProductCode.Caption = "Mehsul";
            colProductCode.FieldName = "ProductCode";
            colProductCode.Name = "colProductCode";
            // 
            // colProductDesc
            // 
            colProductDesc.Caption = "Məhsul Adı";
            colProductDesc.FieldName = "ProductDesc";
            colProductDesc.Name = "colProductDesc";
            colProductDesc.Visible = true;
            colProductDesc.VisibleIndex = 3;
            // 
            // colInvoiceLineId
            // 
            colInvoiceLineId.Caption = "InvoiceLineId";
            colInvoiceLineId.FieldName = "InvoiceLineId";
            colInvoiceLineId.Name = "colInvoiceLineId";
            // 
            // colInvoiceHeaderId
            // 
            colInvoiceHeaderId.FieldName = "InvoiceHeaderId";
            colInvoiceHeaderId.Name = "colInvoiceHeaderId";
            // 
            // colCurrencyCode
            // 
            colCurrencyCode.Caption = "Valyuta";
            colCurrencyCode.FieldName = "CurrencyCode";
            colCurrencyCode.Name = "colCurrencyCode";
            colCurrencyCode.Visible = true;
            colCurrencyCode.VisibleIndex = 6;
            // 
            // colPrice
            // 
            colPrice.Caption = "Qiymət";
            colPrice.FieldName = "Price";
            colPrice.Name = "colPrice";
            colPrice.Visible = true;
            colPrice.VisibleIndex = 5;
            // 
            // colPriceLoc
            // 
            colPriceLoc.Caption = "Qiymət (YPV)";
            colPriceLoc.FieldName = "PriceLoc";
            colPriceLoc.Name = "colPriceLoc";
            // 
            // colQty
            // 
            colQty.Caption = "Say";
            colQty.FieldName = "Qty";
            colQty.Name = "colQty";
            colQty.Visible = true;
            colQty.VisibleIndex = 4;
            // 
            // FormInvoiceLineList
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(872, 475);
            Controls.Add(gC_InvoiceLineList);
            Name = "FormInvoiceLineList";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "FormInvoiceLineList";
            ((System.ComponentModel.ISupportInitialize)gC_InvoiceLineList).EndInit();
            ((System.ComponentModel.ISupportInitialize)trInvoiceHeadersBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_InvoiceLineList).EndInit();
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
    }
}