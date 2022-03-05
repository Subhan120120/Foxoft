
using DevExpress.Utils;

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
            this.gC_InvoiceHeaderList = new DevExpress.XtraGrid.GridControl();
            this.gV_InvoiceHeaderList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_DocNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_IsReturn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DocDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DocTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Desc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_CurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_OfficeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_StoreCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_WarehouseCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_CustomsDocNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_CreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_CreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_InvoiceHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ProcessCode = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gC_InvoiceHeaderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_InvoiceHeaderList)).BeginInit();
            this.SuspendLayout();
            // 
            // gC_InvoiceHeaderList
            // 
            this.gC_InvoiceHeaderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gC_InvoiceHeaderList.Location = new System.Drawing.Point(0, 0);
            this.gC_InvoiceHeaderList.MainView = this.gV_InvoiceHeaderList;
            this.gC_InvoiceHeaderList.Name = "gC_InvoiceHeaderList";
            this.gC_InvoiceHeaderList.Size = new System.Drawing.Size(838, 418);
            this.gC_InvoiceHeaderList.TabIndex = 0;
            this.gC_InvoiceHeaderList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_InvoiceHeaderList});
            // 
            // gV_InvoiceHeaderList
            // 
            this.gV_InvoiceHeaderList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_DocNum,
            this.col_IsReturn,
            this.col_DocDate,
            this.col_DocTime,
            this.col_Desc,
            this.col_CurrAccCode,
            this.col_OfficeCode,
            this.col_StoreCode,
            this.col_WarehouseCode,
            this.col_CustomsDocNum,
            this.col_CreatedUserName,
            this.col_CreatedDate,
            this.col_InvoiceHeaderId,
            this.col_ProcessCode});
            this.gV_InvoiceHeaderList.GridControl = this.gC_InvoiceHeaderList;
            this.gV_InvoiceHeaderList.Name = "gV_InvoiceHeaderList";
            this.gV_InvoiceHeaderList.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // col_DocNum
            // 
            this.col_DocNum.Caption = "Faktura Nömrəsi";
            this.col_DocNum.FieldName = "DocumentNumber";
            this.col_DocNum.Name = "col_DocNum";
            this.col_DocNum.Visible = true;
            this.col_DocNum.VisibleIndex = 0;
            // 
            // col_IsReturn
            // 
            this.col_IsReturn.Caption = "Geri Qaytarma";
            this.col_IsReturn.FieldName = "IsReturn";
            this.col_IsReturn.Name = "col_IsReturn";
            this.col_IsReturn.Visible = true;
            this.col_IsReturn.VisibleIndex = 1;
            // 
            // col_DocDate
            // 
            this.col_DocDate.Caption = "Tarix";
            this.col_DocDate.FieldName = "DocumentDate";
            this.col_DocDate.Name = "col_DocDate";
            this.col_DocDate.Visible = true;
            this.col_DocDate.VisibleIndex = 2;
            // 
            // col_DocTime
            // 
            this.col_DocTime.Caption = "Saat";
            this.col_DocTime.FieldName = "DocumentTime";
            this.col_DocTime.Name = "col_DocTime";
            this.col_DocTime.Visible = true;
            this.col_DocTime.VisibleIndex = 3;
            // 
            // col_Desc
            // 
            this.col_Desc.Caption = "Açıqlama";
            this.col_Desc.FieldName = "Description";
            this.col_Desc.Name = "col_Desc";
            this.col_Desc.Visible = true;
            this.col_Desc.VisibleIndex = 4;
            // 
            // col_CurrAccCode
            // 
            this.col_CurrAccCode.Caption = "Tədarikçi";
            this.col_CurrAccCode.FieldName = "CurrAccCode";
            this.col_CurrAccCode.Name = "col_CurrAccCode";
            this.col_CurrAccCode.Visible = true;
            this.col_CurrAccCode.VisibleIndex = 5;
            // 
            // col_OfficeCode
            // 
            this.col_OfficeCode.Caption = "Ofis Kodu";
            this.col_OfficeCode.FieldName = "OfficeCode";
            this.col_OfficeCode.Name = "col_OfficeCode";
            this.col_OfficeCode.Visible = true;
            this.col_OfficeCode.VisibleIndex = 6;
            // 
            // col_StoreCode
            // 
            this.col_StoreCode.Caption = "Mağaza Kodu";
            this.col_StoreCode.FieldName = "StoreCode";
            this.col_StoreCode.Name = "col_StoreCode";
            // 
            // col_WarehouseCode
            // 
            this.col_WarehouseCode.Caption = "Depo Kodu";
            this.col_WarehouseCode.FieldName = "WarehouseCode";
            this.col_WarehouseCode.Name = "col_WarehouseCode";
            this.col_WarehouseCode.Visible = true;
            this.col_WarehouseCode.VisibleIndex = 7;
            // 
            // col_CustomsDocNum
            // 
            this.col_CustomsDocNum.Caption = "Xüsusi Sənəd Nömrəsi";
            this.col_CustomsDocNum.FieldName = "CustomsDocumentNumber";
            this.col_CustomsDocNum.Name = "col_CustomsDocNum";
            this.col_CustomsDocNum.Visible = true;
            this.col_CustomsDocNum.VisibleIndex = 8;
            // 
            // col_CreatedUserName
            // 
            this.col_CreatedUserName.Caption = "Tərtib Edən İstifadəçi";
            this.col_CreatedUserName.FieldName = "CreatedUserName";
            this.col_CreatedUserName.Name = "col_CreatedUserName";
            this.col_CreatedUserName.Visible = true;
            this.col_CreatedUserName.VisibleIndex = 9;
            // 
            // col_CreatedDate
            // 
            this.col_CreatedDate.Caption = "Yaradılma Tarixi";
            this.col_CreatedDate.FieldName = "CreatedDate";
            this.col_CreatedDate.Name = "col_CreatedDate";
            // 
            // col_InvoiceHeaderId
            // 
            this.col_InvoiceHeaderId.Caption = "InvoiceHeaderId";
            this.col_InvoiceHeaderId.FieldName = "InvoiceHeaderId";
            this.col_InvoiceHeaderId.Name = "col_InvoiceHeaderId";
            // 
            // col_ProcessCode
            // 
            this.col_ProcessCode.Caption = "ProcessCode";
            this.col_ProcessCode.FieldName = "ProcessCode";
            this.col_ProcessCode.Name = "col_ProcessCode";
            // 
            // FormInvoiceHeaderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 418);
            this.Controls.Add(this.gC_InvoiceHeaderList);
            this.Name = "FormInvoiceHeaderList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormInvoiceHeaderList";
            ((System.ComponentModel.ISupportInitialize)(this.gC_InvoiceHeaderList)).EndInit();
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
    }
}