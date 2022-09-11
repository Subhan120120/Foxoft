
using DevExpress.Utils;
using Foxoft.Models;

namespace Foxoft
{
    partial class FormInvoiceHeaderList
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
         this.gC_InvoiceHeaderList = new DevExpress.XtraGrid.GridControl();
         this.trInvoiceHeadersBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.gV_InvoiceHeaderList = new DevExpress.XtraGrid.Views.Grid.GridView();
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
         ((System.ComponentModel.ISupportInitialize)(this.gC_InvoiceHeaderList)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.trInvoiceHeadersBindingSource)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gV_InvoiceHeaderList)).BeginInit();
         this.SuspendLayout();
         // 
         // gC_InvoiceHeaderList
         // 
         this.gC_InvoiceHeaderList.DataSource = this.trInvoiceHeadersBindingSource;
         this.gC_InvoiceHeaderList.Dock = System.Windows.Forms.DockStyle.Fill;
         this.gC_InvoiceHeaderList.Location = new System.Drawing.Point(0, 0);
         this.gC_InvoiceHeaderList.MainView = this.gV_InvoiceHeaderList;
         this.gC_InvoiceHeaderList.Name = "gC_InvoiceHeaderList";
         this.gC_InvoiceHeaderList.Size = new System.Drawing.Size(872, 475);
         this.gC_InvoiceHeaderList.TabIndex = 0;
         this.gC_InvoiceHeaderList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_InvoiceHeaderList});
         this.gC_InvoiceHeaderList.Paint += new System.Windows.Forms.PaintEventHandler(this.gC_InvoiceHeaderList_Paint);
         this.gC_InvoiceHeaderList.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gC_InvoiceHeaderList_ProcessGridKey);
         this.gC_InvoiceHeaderList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gC_InvoiceHeaderList_KeyDown);
         // 
         // trInvoiceHeadersBindingSource
         // 
         this.trInvoiceHeadersBindingSource.DataSource = typeof(Foxoft.Models.TrInvoiceHeader);
         // 
         // gV_InvoiceHeaderList
         // 
         this.gV_InvoiceHeaderList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.colToWarehouseCode});
         this.gV_InvoiceHeaderList.CustomizationFormBounds = new System.Drawing.Rectangle(622, 285, 264, 272);
         this.gV_InvoiceHeaderList.GridControl = this.gC_InvoiceHeaderList;
         this.gV_InvoiceHeaderList.Name = "gV_InvoiceHeaderList";
         this.gV_InvoiceHeaderList.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
         this.gV_InvoiceHeaderList.OptionsView.FilterCriteriaDisplayStyle = DevExpress.XtraEditors.FilterCriteriaDisplayStyle.Visual;
         this.gV_InvoiceHeaderList.OptionsView.ShowAutoFilterRow = true;
         this.gV_InvoiceHeaderList.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gV_InvoiceHeaderList_RowStyle);
         this.gV_InvoiceHeaderList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gV_InvoiceHeaderList_FocusedRowChanged);
         this.gV_InvoiceHeaderList.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gV_InvoiceHeaderList_CellValueChanging);
         this.gV_InvoiceHeaderList.ColumnFilterChanged += new System.EventHandler(this.gV_InvoiceHeaderList_ColumnFilterChanged);
         this.gV_InvoiceHeaderList.DoubleClick += new System.EventHandler(this.gV_TrInvoiceHeaderList_DoubleClick);
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
         this.colIsReturn.Visible = true;
         this.colIsReturn.VisibleIndex = 1;
         this.colIsReturn.Width = 93;
         // 
         // colDocumentDate
         // 
         this.colDocumentDate.FieldName = "DocumentDate";
         this.colDocumentDate.Name = "colDocumentDate";
         this.colDocumentDate.Visible = true;
         this.colDocumentDate.VisibleIndex = 2;
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
         this.colTotalNetAmount.Visible = true;
         this.colTotalNetAmount.VisibleIndex = 3;
         this.colTotalNetAmount.Width = 194;
         // 
         // colCurrAccDesc
         // 
         this.colCurrAccDesc.FieldName = "CurrAccDesc";
         this.colCurrAccDesc.Name = "colCurrAccDesc";
         this.colCurrAccDesc.Visible = true;
         this.colCurrAccDesc.VisibleIndex = 4;
         this.colCurrAccDesc.Width = 197;
         // 
         // colWarehouseCode
         // 
         this.colWarehouseCode.FieldName = "WarehouseCode";
         this.colWarehouseCode.Name = "colWarehouseCode";
         this.colWarehouseCode.Visible = true;
         this.colWarehouseCode.VisibleIndex = 5;
         // 
         // colToWarehouseCode
         // 
         this.colToWarehouseCode.FieldName = "ToWarehouseCode";
         this.colToWarehouseCode.Name = "colToWarehouseCode";
         this.colToWarehouseCode.Visible = true;
         this.colToWarehouseCode.VisibleIndex = 6;
         // 
         // FormInvoiceHeaderList
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(872, 475);
         this.Controls.Add(this.gC_InvoiceHeaderList);
         this.Name = "FormInvoiceHeaderList";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "FormInvoiceHeaderList";
         ((System.ComponentModel.ISupportInitialize)(this.gC_InvoiceHeaderList)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.trInvoiceHeadersBindingSource)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gV_InvoiceHeaderList)).EndInit();
         this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gC_InvoiceHeaderList;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_InvoiceHeaderList;
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
   }
}