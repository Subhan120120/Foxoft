
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
         this.components = new System.ComponentModel.Container();
         this.gC_InvoiceLineList = new DevExpress.XtraGrid.GridControl();
         this.trInvoiceHeadersBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.gV_InvoiceLineList = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.colDocumentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colIsReturn = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colDocumentDate = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colDocumentTime = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colOperationDate = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colOperationTime = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colStoreCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colTotalNetAmount = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colCurrAccDesc = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colWarehouseCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colToWarehouseCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colProductDesc = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colInvoiceLineId = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colInvoiceHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colPriceLoc = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
         ((System.ComponentModel.ISupportInitialize)(this.gC_InvoiceLineList)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.trInvoiceHeadersBindingSource)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gV_InvoiceLineList)).BeginInit();
         this.SuspendLayout();
         // 
         // gC_InvoiceLineList
         // 
         this.gC_InvoiceLineList.DataSource = this.trInvoiceHeadersBindingSource;
         this.gC_InvoiceLineList.Dock = System.Windows.Forms.DockStyle.Fill;
         this.gC_InvoiceLineList.Location = new System.Drawing.Point(0, 0);
         this.gC_InvoiceLineList.MainView = this.gV_InvoiceLineList;
         this.gC_InvoiceLineList.Name = "gC_InvoiceLineList";
         this.gC_InvoiceLineList.Size = new System.Drawing.Size(872, 475);
         this.gC_InvoiceLineList.TabIndex = 0;
         this.gC_InvoiceLineList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_InvoiceLineList});
         this.gC_InvoiceLineList.Paint += new System.Windows.Forms.PaintEventHandler(this.gC_InvoiceHeaderList_Paint);
         this.gC_InvoiceLineList.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gC_InvoiceLineList_ProcessGridKey);
         // 
         // trInvoiceHeadersBindingSource
         // 
         this.trInvoiceHeadersBindingSource.DataSource = typeof(Foxoft.Models.TrInvoiceHeader);
         // 
         // gV_InvoiceLineList
         // 
         this.gV_InvoiceLineList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDocumentNumber,
            this.colIsReturn,
            this.colDocumentDate,
            this.colCurrAccCode,
            this.colDocumentTime,
            this.colOperationDate,
            this.colOperationTime,
            this.colStoreCode,
            this.colTotalNetAmount,
            this.colCurrAccDesc,
            this.colWarehouseCode,
            this.colToWarehouseCode,
            this.colProductCode,
            this.colProductDesc,
            this.colInvoiceLineId,
            this.colInvoiceHeaderId,
            this.colCurrencyCode,
            this.colPrice,
            this.colPriceLoc,
            this.colQty});
         this.gV_InvoiceLineList.CustomizationFormBounds = new System.Drawing.Rectangle(622, 285, 264, 272);
         this.gV_InvoiceLineList.GridControl = this.gC_InvoiceLineList;
         this.gV_InvoiceLineList.Name = "gV_InvoiceLineList";
         this.gV_InvoiceLineList.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
         this.gV_InvoiceLineList.OptionsView.FilterCriteriaDisplayStyle = DevExpress.XtraEditors.FilterCriteriaDisplayStyle.Visual;
         this.gV_InvoiceLineList.OptionsView.ShowAutoFilterRow = true;
         this.gV_InvoiceLineList.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gV_InvoiceHeaderList_RowStyle);
         this.gV_InvoiceLineList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gV_InvoiceLineList_FocusedRowChanged);
         this.gV_InvoiceLineList.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gV_InvoiceHeaderList_CellValueChanging);
         this.gV_InvoiceLineList.ColumnFilterChanged += new System.EventHandler(this.gV_InvoiceLineList_ColumnFilterChanged);
         this.gV_InvoiceLineList.DoubleClick += new System.EventHandler(this.gV_TrInvoiceHeaderList_DoubleClick);
         // 
         // colDocumentNumber
         // 
         this.colDocumentNumber.FieldName = "DocumentNumber";
         this.colDocumentNumber.Name = "colDocumentNumber";
         this.colDocumentNumber.Visible = true;
         this.colDocumentNumber.VisibleIndex = 0;
         this.colDocumentNumber.Width = 169;
         // 
         // colIsReturn
         // 
         this.colIsReturn.FieldName = "IsReturn";
         this.colIsReturn.Name = "colIsReturn";
         this.colIsReturn.Width = 93;
         // 
         // colDocumentDate
         // 
         this.colDocumentDate.FieldName = "DocumentDate";
         this.colDocumentDate.Name = "colDocumentDate";
         this.colDocumentDate.Visible = true;
         this.colDocumentDate.VisibleIndex = 1;
         this.colDocumentDate.Width = 194;
         // 
         // colCurrAccCode
         // 
         this.colCurrAccCode.FieldName = "CurrAccCode";
         this.colCurrAccCode.Name = "colCurrAccCode";
         // 
         // colDocumentTime
         // 
         this.colDocumentTime.FieldName = "DocumentTime";
         this.colDocumentTime.Name = "colDocumentTime";
         // 
         // colOperationDate
         // 
         this.colOperationDate.FieldName = "OperationDate";
         this.colOperationDate.Name = "colOperationDate";
         // 
         // colOperationTime
         // 
         this.colOperationTime.FieldName = "OperationTime";
         this.colOperationTime.Name = "colOperationTime";
         // 
         // colStoreCode
         // 
         this.colStoreCode.FieldName = "StoreCode";
         this.colStoreCode.Name = "colStoreCode";
         // 
         // colTotalNetAmount
         // 
         this.colTotalNetAmount.FieldName = "TotalNetAmount";
         this.colTotalNetAmount.Name = "colTotalNetAmount";
         this.colTotalNetAmount.Width = 194;
         // 
         // colCurrAccDesc
         // 
         this.colCurrAccDesc.FieldName = "CurrAccDesc";
         this.colCurrAccDesc.Name = "colCurrAccDesc";
         this.colCurrAccDesc.Visible = true;
         this.colCurrAccDesc.VisibleIndex = 2;
         this.colCurrAccDesc.Width = 197;
         // 
         // colWarehouseCode
         // 
         this.colWarehouseCode.FieldName = "WarehouseCode";
         this.colWarehouseCode.Name = "colWarehouseCode";
         // 
         // colToWarehouseCode
         // 
         this.colToWarehouseCode.FieldName = "ToWarehouseCode";
         this.colToWarehouseCode.Name = "colToWarehouseCode";
         // 
         // colProductCode
         // 
         this.colProductCode.Caption = "Mehsul";
         this.colProductCode.FieldName = "ProductCode";
         this.colProductCode.Name = "colProductCode";
         // 
         // colProductDesc
         // 
         this.colProductDesc.Caption = "Məhsul Adı";
         this.colProductDesc.FieldName = "ProductDesc";
         this.colProductDesc.Name = "colProductDesc";
         this.colProductDesc.Visible = true;
         this.colProductDesc.VisibleIndex = 3;
         // 
         // colInvoiceLineId
         // 
         this.colInvoiceLineId.Caption = "InvoiceLineId";
         this.colInvoiceLineId.FieldName = "InvoiceLineId";
         this.colInvoiceLineId.Name = "colInvoiceLineId";
         // 
         // colInvoiceHeaderId
         // 
         this.colInvoiceHeaderId.FieldName = "InvoiceHeaderId";
         this.colInvoiceHeaderId.Name = "colInvoiceHeaderId";
         // 
         // colCurrencyCode
         // 
         this.colCurrencyCode.Caption = "Valyuta";
         this.colCurrencyCode.FieldName = "CurrencyCode";
         this.colCurrencyCode.Name = "colCurrencyCode";
         this.colCurrencyCode.Visible = true;
         this.colCurrencyCode.VisibleIndex = 6;
         // 
         // colPrice
         // 
         this.colPrice.Caption = "Qiymət";
         this.colPrice.FieldName = "Price";
         this.colPrice.Name = "colPrice";
         this.colPrice.Visible = true;
         this.colPrice.VisibleIndex = 5;
         // 
         // colPriceLoc
         // 
         this.colPriceLoc.Caption = "Qiymət (YPV)";
         this.colPriceLoc.FieldName = "PriceLoc";
         this.colPriceLoc.Name = "colPriceLoc";
         // 
         // colQty
         // 
         this.colQty.Caption = "Say";
         this.colQty.FieldName = "Qty";
         this.colQty.Name = "colQty";
         this.colQty.Visible = true;
         this.colQty.VisibleIndex = 4;
         // 
         // FormInvoiceLineList
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(872, 475);
         this.Controls.Add(this.gC_InvoiceLineList);
         this.Name = "FormInvoiceLineList";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "FormInvoiceLineList";
         ((System.ComponentModel.ISupportInitialize)(this.gC_InvoiceLineList)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.trInvoiceHeadersBindingSource)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gV_InvoiceLineList)).EndInit();
         this.ResumeLayout(false);

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