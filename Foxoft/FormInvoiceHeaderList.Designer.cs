
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
            components = new System.ComponentModel.Container();
            gC_InvoiceHeaderList = new DevExpress.XtraGrid.GridControl();
            trInvoiceHeadersBindingSource = new System.Windows.Forms.BindingSource(components);
            gV_InvoiceHeaderList = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            colPrintCount = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsOpen = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsMainTF = new DevExpress.XtraGrid.Columns.GridColumn();
            colInvoiceHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsSent = new DevExpress.XtraGrid.Columns.GridColumn();
            colCustomsDocumentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)gC_InvoiceHeaderList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trInvoiceHeadersBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_InvoiceHeaderList).BeginInit();
            SuspendLayout();
            // 
            // gC_InvoiceHeaderList
            // 
            gC_InvoiceHeaderList.DataSource = trInvoiceHeadersBindingSource;
            gC_InvoiceHeaderList.Dock = System.Windows.Forms.DockStyle.Fill;
            gC_InvoiceHeaderList.Location = new System.Drawing.Point(0, 0);
            gC_InvoiceHeaderList.MainView = gV_InvoiceHeaderList;
            gC_InvoiceHeaderList.Name = "gC_InvoiceHeaderList";
            gC_InvoiceHeaderList.Size = new System.Drawing.Size(872, 475);
            gC_InvoiceHeaderList.TabIndex = 0;
            gC_InvoiceHeaderList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_InvoiceHeaderList });
            gC_InvoiceHeaderList.Paint += gC_InvoiceHeaderList_Paint;
            gC_InvoiceHeaderList.ProcessGridKey += gC_InvoiceHeaderList_ProcessGridKey;
            // 
            // trInvoiceHeadersBindingSource
            // 
            trInvoiceHeadersBindingSource.DataSource = typeof(TrInvoiceHeader);
            // 
            // gV_InvoiceHeaderList
            // 
            gV_InvoiceHeaderList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colDocumentNumber, colIsReturn, colDocumentDate, colCurrAccCode, colDocumentTime, colOperationDate, colOperationTime, colStoreCode, colTotalNetAmount, colCurrAccDesc, colWarehouseCode, colToWarehouseCode, colPrintCount, colDescription, colIsOpen, colIsMainTF, colInvoiceHeaderId, colIsSent, colCustomsDocumentNumber });
            gV_InvoiceHeaderList.CustomizationFormBounds = new System.Drawing.Rectangle(622, 285, 264, 272);
            gV_InvoiceHeaderList.GridControl = gC_InvoiceHeaderList;
            gV_InvoiceHeaderList.Name = "gV_InvoiceHeaderList";
            gV_InvoiceHeaderList.OptionsFind.AlwaysVisible = true;
            gV_InvoiceHeaderList.OptionsFind.FindDelay = 100;
            gV_InvoiceHeaderList.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            gV_InvoiceHeaderList.OptionsView.FilterCriteriaDisplayStyle = DevExpress.XtraEditors.FilterCriteriaDisplayStyle.Visual;
            gV_InvoiceHeaderList.OptionsView.ShowAutoFilterRow = true;
            gV_InvoiceHeaderList.RowStyle += gV_InvoiceHeaderList_RowStyle;
            gV_InvoiceHeaderList.FocusedRowChanged += gV_InvoiceHeaderList_FocusedRowChanged;
            gV_InvoiceHeaderList.CellValueChanging += gV_InvoiceHeaderList_CellValueChanging;
            gV_InvoiceHeaderList.ColumnFilterChanged += gV_InvoiceHeaderList_ColumnFilterChanged;
            gV_InvoiceHeaderList.DoubleClick += gV_TrInvoiceHeaderList_DoubleClick;
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
            colIsReturn.Visible = true;
            colIsReturn.VisibleIndex = 1;
            colIsReturn.Width = 93;
            // 
            // colDocumentDate
            // 
            colDocumentDate.FieldName = "DocumentDate";
            colDocumentDate.Name = "colDocumentDate";
            colDocumentDate.Visible = true;
            colDocumentDate.VisibleIndex = 2;
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
            colTotalNetAmount.Visible = true;
            colTotalNetAmount.VisibleIndex = 3;
            colTotalNetAmount.Width = 194;
            // 
            // colCurrAccDesc
            // 
            colCurrAccDesc.FieldName = "CurrAccDesc";
            colCurrAccDesc.Name = "colCurrAccDesc";
            colCurrAccDesc.Visible = true;
            colCurrAccDesc.VisibleIndex = 4;
            colCurrAccDesc.Width = 197;
            // 
            // colWarehouseCode
            // 
            colWarehouseCode.FieldName = "WarehouseCode";
            colWarehouseCode.Name = "colWarehouseCode";
            colWarehouseCode.Visible = true;
            colWarehouseCode.VisibleIndex = 5;
            // 
            // colToWarehouseCode
            // 
            colToWarehouseCode.FieldName = "ToWarehouseCode";
            colToWarehouseCode.Name = "colToWarehouseCode";
            colToWarehouseCode.Visible = true;
            colToWarehouseCode.VisibleIndex = 6;
            // 
            // colPrintCount
            // 
            colPrintCount.FieldName = "PrintCount";
            colPrintCount.Name = "colPrintCount";
            // 
            // colDescription
            // 
            colDescription.FieldName = "Description";
            colDescription.Name = "colDescription";
            // 
            // colIsOpen
            // 
            colIsOpen.FieldName = "IsOpen";
            colIsOpen.Name = "colIsOpen";
            // 
            // colIsMainTF
            // 
            colIsMainTF.FieldName = "IsMainTF";
            colIsMainTF.Name = "colIsMainTF";
            // 
            // colInvoiceHeaderId
            // 
            colInvoiceHeaderId.FieldName = "InvoiceHeaderId";
            colInvoiceHeaderId.Name = "colInvoiceHeaderId";
            // 
            // colIsSent
            // 
            colIsSent.FieldName = "IsSent";
            colIsSent.Name = "colIsSent";
            // 
            // colCustomsDocumentNumber
            // 
            colCustomsDocumentNumber.FieldName = "CustomsDocumentNumber";
            colCustomsDocumentNumber.Name = "colCustomsDocumentNumber";
            // 
            // FormInvoiceHeaderList
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(872, 475);
            Controls.Add(gC_InvoiceHeaderList);
            Name = "FormInvoiceHeaderList";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "FormInvoiceHeaderList";
            Activated += FormInvoiceHeaderList_Activated;
            ((System.ComponentModel.ISupportInitialize)gC_InvoiceHeaderList).EndInit();
            ((System.ComponentModel.ISupportInitialize)trInvoiceHeadersBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_InvoiceHeaderList).EndInit();
            ResumeLayout(false);
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
        private DevExpress.XtraGrid.Columns.GridColumn colPrintCount;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colIsOpen;
        private DevExpress.XtraGrid.Columns.GridColumn colIsMainTF;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSent;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomsDocumentNumber;
    }
}