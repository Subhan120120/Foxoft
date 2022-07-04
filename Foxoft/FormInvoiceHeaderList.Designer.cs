
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
            this.colTotalNetAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrAccDesc = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gC_InvoiceHeaderList.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gC_InvoiceHeaderList_ProcessGridKey);
            this.gC_InvoiceHeaderList.Paint += new System.Windows.Forms.PaintEventHandler(this.gC_InvoiceHeaderList_Paint);
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
            this.colTotalNetAmount,
            this.colStoreCode,
            this.colCurrAccDesc});
            this.gV_InvoiceHeaderList.CustomizationFormBounds = new System.Drawing.Rectangle(622, 285, 264, 272);
            this.gV_InvoiceHeaderList.GridControl = this.gC_InvoiceHeaderList;
            this.gV_InvoiceHeaderList.Name = "gV_InvoiceHeaderList";
            this.gV_InvoiceHeaderList.OptionsView.FilterCriteriaDisplayStyle = DevExpress.XtraEditors.FilterCriteriaDisplayStyle.Visual;
            this.gV_InvoiceHeaderList.OptionsView.ShowAutoFilterRow = true;
            this.gV_InvoiceHeaderList.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gV_InvoiceHeaderList_RowStyle);
            this.gV_InvoiceHeaderList.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gV_InvoiceHeaderList_CellValueChanging);
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
            // 
            // colIsReturn
            // 
            this.colIsReturn.FieldName = "IsReturn";
            this.colIsReturn.Name = "colIsReturn";
            this.colIsReturn.Visible = true;
            this.colIsReturn.VisibleIndex = 1;
            // 
            // colDocumentDate
            // 
            this.colDocumentDate.FieldName = "DocumentDate";
            this.colDocumentDate.Name = "colDocumentDate";
            this.colDocumentDate.Visible = true;
            this.colDocumentDate.VisibleIndex = 2;
            // 
            // colCurrAccCode
            // 
            this.colCurrAccCode.FieldName = "CurrAccCode";
            this.colCurrAccCode.Name = "colCurrAccCode";
            this.colCurrAccCode.Visible = true;
            this.colCurrAccCode.VisibleIndex = 4;
            // 
            // colDocumentTime
            // 
            this.colDocumentTime.FieldName = "DocumentTime";
            this.colDocumentTime.Name = "colDocumentTime";
            this.colDocumentTime.Visible = true;
            this.colDocumentTime.VisibleIndex = 3;
            // 
            // colOperationDate
            // 
            this.colOperationDate.FieldName = "OperationDate";
            this.colOperationDate.Name = "colOperationDate";
            this.colOperationDate.Visible = true;
            this.colOperationDate.VisibleIndex = 5;
            // 
            // colOperationTime
            // 
            this.colOperationTime.FieldName = "OperationTime";
            this.colOperationTime.Name = "colOperationTime";
            this.colOperationTime.Visible = true;
            this.colOperationTime.VisibleIndex = 6;
            // 
            // colTotalNetAmount
            // 
            this.colTotalNetAmount.DisplayFormat.FormatString = "{0:n2}";
            this.colTotalNetAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalNetAmount.FieldName = "TotalNetAmount";
            this.colTotalNetAmount.Name = "colTotalNetAmount";
            this.colTotalNetAmount.Visible = true;
            this.colTotalNetAmount.VisibleIndex = 7;
            // 
            // colStoreCode
            // 
            this.colStoreCode.FieldName = "StoreCode";
            this.colStoreCode.Name = "colStoreCode";
            this.colStoreCode.Visible = true;
            this.colStoreCode.VisibleIndex = 8;
            // 
            // colCurrAccDesc
            // 
            this.colCurrAccDesc.FieldName = "DcCurrAcc.CurrAccDesc";
            this.colCurrAccDesc.Name = "colCurrAccDesc";
            this.colCurrAccDesc.Visible = true;
            this.colCurrAccDesc.VisibleIndex = 9;
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
        private DevExpress.XtraGrid.Columns.GridColumn col_DocNum;
        private DevExpress.XtraGrid.Columns.GridColumn col_IsReturn;
        private DevExpress.XtraGrid.Columns.GridColumn col_DocDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_DocTime;
        private DevExpress.XtraGrid.Columns.GridColumn col_Desc;
        private DevExpress.XtraGrid.Columns.GridColumn col_CurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_OfficeCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_StoreCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_WarehouseCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_CustomsDocNum;
        private DevExpress.XtraGrid.Columns.GridColumn col_CreatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn col_CreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn col_InvoiceHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProcessCode;
        private System.Windows.Forms.BindingSource trInvoiceHeadersBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colOperationDate;
        private DevExpress.XtraGrid.Columns.GridColumn colOperationTime;
        private DevExpress.XtraGrid.Columns.GridColumn colIsReturn;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentTime;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalNetAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccDesc;
    }
}