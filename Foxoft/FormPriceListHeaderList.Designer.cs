using Foxoft.Models;
using Foxoft.Properties;

namespace Foxoft
{
    partial class FormPriceListHeaderList
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
            myGridControl1 = new MyGridControl();
            trPriceListBindingSource = new System.Windows.Forms.BindingSource(components);
            gV_priceListHeader = new DevExpress.XtraGrid.Views.Grid.GridView();
            colPriceListHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            colDocumentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colPriceListTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colDocumentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colDocumentTime = new DevExpress.XtraGrid.Columns.GridColumn();
            colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colDueTime = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsConfirmed = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsDisabled = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)myGridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trPriceListBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_priceListHeader).BeginInit();
            SuspendLayout();
            // 
            // myGridControl1
            // 
            myGridControl1.DataSource = trPriceListBindingSource;
            myGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            myGridControl1.Location = new System.Drawing.Point(0, 0);
            myGridControl1.MainView = gV_priceListHeader;
            myGridControl1.Name = "myGridControl1";
            myGridControl1.Size = new System.Drawing.Size(1123, 470);
            myGridControl1.TabIndex = 0;
            myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_priceListHeader });
            myGridControl1.ProcessGridKey += myGridControl1_ProcessGridKey;
            // 
            // trPriceListBindingSource
            // 
            trPriceListBindingSource.DataSource = typeof(TrPriceListHeader);
            // 
            // gV_priceListHeader
            // 
            gV_priceListHeader.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                colPriceListHeaderId,
                colDocumentNumber,
                colDescription,
                colPriceListTypeCode,
                colDocumentDate,
                colDocumentTime,
                colDueDate,
                colDueTime,
                colIsConfirmed,
                colIsDisabled});
            gV_priceListHeader.DetailHeight = 303;
            gV_priceListHeader.GridControl = myGridControl1;
            gV_priceListHeader.Name = "gV_priceListHeader";
            gV_priceListHeader.OptionsView.ShowGroupPanel = false;
            gV_priceListHeader.FocusedRowChanged += gV_priceListHeader_FocusedRowChanged;
            gV_priceListHeader.ColumnFilterChanged += gV_priceListHeader_ColumnFilterChanged;
            gV_priceListHeader.DoubleClick += gV_priceListHeader_DoubleClick;
            // 
            // colPriceListHeaderId
            // 
            colPriceListHeaderId.FieldName = "PriceListHeaderId";
            colPriceListHeaderId.Name = "colPriceListHeaderId";
            // 
            // colDocumentNumber
            // 
            colDocumentNumber.FieldName = "DocumentNumber";
            colDocumentNumber.Name = "colDocumentNumber";
            colDocumentNumber.Visible = true;
            colDocumentNumber.VisibleIndex = 0;
            // 
            // colDescription
            // 
            colDescription.FieldName = "Description";
            colDescription.Name = "colDescription";
            colDescription.Visible = true;
            colDescription.VisibleIndex = 1;
            // 
            // colPriceListTypeCode
            // 
            colPriceListTypeCode.FieldName = "PriceTypeCode";
            colPriceListTypeCode.Name = "colPriceListTypeCode";
            colPriceListTypeCode.Visible = true;
            colPriceListTypeCode.VisibleIndex = 7;
            // 
            // colDocumentDate
            // 
            colDocumentDate.FieldName = "DocumentDate";
            colDocumentDate.Name = "colDocumentDate";
            colDocumentDate.Visible = true;
            colDocumentDate.VisibleIndex = 2;
            // 
            // colDocumentTime
            // 
            colDocumentTime.FieldName = "DocumentTime";
            colDocumentTime.Name = "colDocumentTime";
            colDocumentTime.Visible = true;
            colDocumentTime.VisibleIndex = 3;
            // 
            // colDueDate
            // 
            colDueDate.FieldName = "DueDate";
            colDueDate.Name = "colDueDate";
            colDueDate.Visible = true;
            colDueDate.VisibleIndex = 4;
            // 
            // colDueTime
            // 
            colDueTime.FieldName = "DueTime";
            colDueTime.Name = "colDueTime";
            colDueTime.Visible = true;
            colDueTime.VisibleIndex = 5;
            // 
            // colIsConfirmed
            // 
            colIsConfirmed.FieldName = "IsConfirmed";
            colIsConfirmed.Name = "colIsConfirmed";
            colIsConfirmed.Visible = true;
            colIsConfirmed.VisibleIndex = 6;
            // 
            // colIsDisabled
            // 
            colIsDisabled.FieldName = "IsDisabled";
            colIsDisabled.Name = "colIsDisabled";
            colIsDisabled.Visible = true;
            colIsDisabled.VisibleIndex = 8;
            // 
            // FormPriceListHeaderList
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1123, 470);
            Controls.Add(myGridControl1);
            Name = "FormPriceListHeaderList";
            Text = Resources.Form_PriceListHeaderList_Caption;
            ((System.ComponentModel.ISupportInitialize)myGridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trPriceListBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_priceListHeader).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MyGridControl myGridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_priceListHeader;
        private System.Windows.Forms.BindingSource trPriceListBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceListHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceListTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentTime;
        private DevExpress.XtraGrid.Columns.GridColumn colDueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDueTime;
        private DevExpress.XtraGrid.Columns.GridColumn colIsConfirmed;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDisabled;
    }
}
