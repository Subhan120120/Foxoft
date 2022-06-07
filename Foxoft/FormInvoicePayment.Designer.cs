
namespace Foxoft
{
    partial class FormInvoicePayment
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
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPaymentLineId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBankId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrPaymentHeader = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDcPaymentType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PaymentHeaderIdTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.InvoiceHeaderIdTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DocumentNumberTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DocumentDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.DocumentTimeTimeSpanEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            this.CurrAccCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.OfficeCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.StoreCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.CurrencyCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForPaymentHeaderId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForInvoiceHeaderId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDocumentNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDocumentDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDocumentTime = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCurrencyCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForStoreCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForOfficeCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCurrAccCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.trPaymentLinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.trPaymentHeadersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentHeaderIdTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceHeaderIdTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentNumberTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentDateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentDateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentTimeTimeSpanEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrAccCodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfficeCodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoreCodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrencyCodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPaymentHeaderId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForInvoiceHeaderId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCurrencyCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStoreCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOfficeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCurrAccCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trPaymentLinesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trPaymentHeadersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.gridControl1);
            this.dataLayoutControl1.Controls.Add(this.PaymentHeaderIdTextEdit);
            this.dataLayoutControl1.Controls.Add(this.InvoiceHeaderIdTextEdit);
            this.dataLayoutControl1.Controls.Add(this.DocumentNumberTextEdit);
            this.dataLayoutControl1.Controls.Add(this.DocumentDateDateEdit);
            this.dataLayoutControl1.Controls.Add(this.DocumentTimeTimeSpanEdit);
            this.dataLayoutControl1.Controls.Add(this.CurrAccCodeTextEdit);
            this.dataLayoutControl1.Controls.Add(this.OfficeCodeTextEdit);
            this.dataLayoutControl1.Controls.Add(this.StoreCodeTextEdit);
            this.dataLayoutControl1.Controls.Add(this.CurrencyCodeTextEdit);
            this.dataLayoutControl1.DataSource = this.trPaymentHeadersBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(578, 67, 650, 400);
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(530, 328);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.trPaymentLinesBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 132);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(506, 184);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPaymentLineId,
            this.colPaymentHeaderId,
            this.colPaymentTypeCode,
            this.colPayment,
            this.colLineDescription,
            this.colCurrencyCode,
            this.colExchangeRate,
            this.colBankId,
            this.colTrPaymentHeader,
            this.colDcPaymentType,
            this.colCreatedUserName,
            this.colCreatedDate,
            this.colLastUpdatedUserName,
            this.colLastUpdatedDate});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colPaymentLineId
            // 
            this.colPaymentLineId.FieldName = "PaymentLineId";
            this.colPaymentLineId.Name = "colPaymentLineId";
            this.colPaymentLineId.Visible = true;
            this.colPaymentLineId.VisibleIndex = 0;
            // 
            // colPaymentHeaderId
            // 
            this.colPaymentHeaderId.FieldName = "PaymentHeaderId";
            this.colPaymentHeaderId.Name = "colPaymentHeaderId";
            this.colPaymentHeaderId.Visible = true;
            this.colPaymentHeaderId.VisibleIndex = 1;
            // 
            // colPaymentTypeCode
            // 
            this.colPaymentTypeCode.FieldName = "PaymentTypeCode";
            this.colPaymentTypeCode.Name = "colPaymentTypeCode";
            this.colPaymentTypeCode.Visible = true;
            this.colPaymentTypeCode.VisibleIndex = 2;
            // 
            // colPayment
            // 
            this.colPayment.FieldName = "Payment";
            this.colPayment.Name = "colPayment";
            this.colPayment.Visible = true;
            this.colPayment.VisibleIndex = 3;
            // 
            // colLineDescription
            // 
            this.colLineDescription.FieldName = "LineDescription";
            this.colLineDescription.Name = "colLineDescription";
            this.colLineDescription.Visible = true;
            this.colLineDescription.VisibleIndex = 4;
            // 
            // colCurrencyCode
            // 
            this.colCurrencyCode.FieldName = "CurrencyCode";
            this.colCurrencyCode.Name = "colCurrencyCode";
            this.colCurrencyCode.Visible = true;
            this.colCurrencyCode.VisibleIndex = 5;
            // 
            // colExchangeRate
            // 
            this.colExchangeRate.FieldName = "ExchangeRate";
            this.colExchangeRate.Name = "colExchangeRate";
            this.colExchangeRate.Visible = true;
            this.colExchangeRate.VisibleIndex = 6;
            // 
            // colBankId
            // 
            this.colBankId.FieldName = "BankId";
            this.colBankId.Name = "colBankId";
            this.colBankId.Visible = true;
            this.colBankId.VisibleIndex = 7;
            // 
            // colTrPaymentHeader
            // 
            this.colTrPaymentHeader.FieldName = "TrPaymentHeader";
            this.colTrPaymentHeader.Name = "colTrPaymentHeader";
            this.colTrPaymentHeader.Visible = true;
            this.colTrPaymentHeader.VisibleIndex = 8;
            // 
            // colDcPaymentType
            // 
            this.colDcPaymentType.FieldName = "DcPaymentType";
            this.colDcPaymentType.Name = "colDcPaymentType";
            this.colDcPaymentType.Visible = true;
            this.colDcPaymentType.VisibleIndex = 9;
            // 
            // colCreatedUserName
            // 
            this.colCreatedUserName.FieldName = "CreatedUserName";
            this.colCreatedUserName.Name = "colCreatedUserName";
            this.colCreatedUserName.Visible = true;
            this.colCreatedUserName.VisibleIndex = 10;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 11;
            // 
            // colLastUpdatedUserName
            // 
            this.colLastUpdatedUserName.FieldName = "LastUpdatedUserName";
            this.colLastUpdatedUserName.Name = "colLastUpdatedUserName";
            this.colLastUpdatedUserName.Visible = true;
            this.colLastUpdatedUserName.VisibleIndex = 12;
            // 
            // colLastUpdatedDate
            // 
            this.colLastUpdatedDate.FieldName = "LastUpdatedDate";
            this.colLastUpdatedDate.Name = "colLastUpdatedDate";
            this.colLastUpdatedDate.Visible = true;
            this.colLastUpdatedDate.VisibleIndex = 13;
            // 
            // PaymentHeaderIdTextEdit
            // 
            this.PaymentHeaderIdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPaymentHeadersBindingSource, "PaymentHeaderId", true));
            this.PaymentHeaderIdTextEdit.Location = new System.Drawing.Point(117, 12);
            this.PaymentHeaderIdTextEdit.Name = "PaymentHeaderIdTextEdit";
            this.PaymentHeaderIdTextEdit.Size = new System.Drawing.Size(146, 20);
            this.PaymentHeaderIdTextEdit.StyleController = this.dataLayoutControl1;
            this.PaymentHeaderIdTextEdit.TabIndex = 0;
            // 
            // InvoiceHeaderIdTextEdit
            // 
            this.InvoiceHeaderIdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPaymentHeadersBindingSource, "InvoiceHeaderId", true));
            this.InvoiceHeaderIdTextEdit.Location = new System.Drawing.Point(117, 36);
            this.InvoiceHeaderIdTextEdit.Name = "InvoiceHeaderIdTextEdit";
            this.InvoiceHeaderIdTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.InvoiceHeaderIdTextEdit.Size = new System.Drawing.Size(146, 20);
            this.InvoiceHeaderIdTextEdit.StyleController = this.dataLayoutControl1;
            this.InvoiceHeaderIdTextEdit.TabIndex = 3;
            // 
            // DocumentNumberTextEdit
            // 
            this.DocumentNumberTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPaymentHeadersBindingSource, "DocumentNumber", true));
            this.DocumentNumberTextEdit.Location = new System.Drawing.Point(117, 60);
            this.DocumentNumberTextEdit.Name = "DocumentNumberTextEdit";
            this.DocumentNumberTextEdit.Size = new System.Drawing.Size(146, 20);
            this.DocumentNumberTextEdit.StyleController = this.dataLayoutControl1;
            this.DocumentNumberTextEdit.TabIndex = 5;
            // 
            // DocumentDateDateEdit
            // 
            this.DocumentDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPaymentHeadersBindingSource, "DocumentDate", true));
            this.DocumentDateDateEdit.EditValue = null;
            this.DocumentDateDateEdit.Location = new System.Drawing.Point(117, 84);
            this.DocumentDateDateEdit.Name = "DocumentDateDateEdit";
            this.DocumentDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DocumentDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DocumentDateDateEdit.Size = new System.Drawing.Size(146, 20);
            this.DocumentDateDateEdit.StyleController = this.dataLayoutControl1;
            this.DocumentDateDateEdit.TabIndex = 7;
            // 
            // DocumentTimeTimeSpanEdit
            // 
            this.DocumentTimeTimeSpanEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPaymentHeadersBindingSource, "OperationTime", true));
            this.DocumentTimeTimeSpanEdit.EditValue = System.TimeSpan.Parse("00:00:00");
            this.DocumentTimeTimeSpanEdit.Location = new System.Drawing.Point(117, 108);
            this.DocumentTimeTimeSpanEdit.Name = "DocumentTimeTimeSpanEdit";
            this.DocumentTimeTimeSpanEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DocumentTimeTimeSpanEdit.Size = new System.Drawing.Size(146, 20);
            this.DocumentTimeTimeSpanEdit.StyleController = this.dataLayoutControl1;
            this.DocumentTimeTimeSpanEdit.TabIndex = 9;
            // 
            // CurrAccCodeTextEdit
            // 
            this.CurrAccCodeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPaymentHeadersBindingSource, "CurrAccCode", true));
            this.CurrAccCodeTextEdit.Location = new System.Drawing.Point(372, 84);
            this.CurrAccCodeTextEdit.Name = "CurrAccCodeTextEdit";
            this.CurrAccCodeTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.CurrAccCodeTextEdit.Size = new System.Drawing.Size(146, 20);
            this.CurrAccCodeTextEdit.StyleController = this.dataLayoutControl1;
            this.CurrAccCodeTextEdit.TabIndex = 10;
            // 
            // OfficeCodeTextEdit
            // 
            this.OfficeCodeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPaymentHeadersBindingSource, "OfficeCode", true));
            this.OfficeCodeTextEdit.Location = new System.Drawing.Point(372, 60);
            this.OfficeCodeTextEdit.Name = "OfficeCodeTextEdit";
            this.OfficeCodeTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.OfficeCodeTextEdit.Size = new System.Drawing.Size(146, 20);
            this.OfficeCodeTextEdit.StyleController = this.dataLayoutControl1;
            this.OfficeCodeTextEdit.TabIndex = 6;
            // 
            // StoreCodeTextEdit
            // 
            this.StoreCodeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPaymentHeadersBindingSource, "StoreCode", true));
            this.StoreCodeTextEdit.Location = new System.Drawing.Point(372, 36);
            this.StoreCodeTextEdit.Name = "StoreCodeTextEdit";
            this.StoreCodeTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.StoreCodeTextEdit.Size = new System.Drawing.Size(146, 20);
            this.StoreCodeTextEdit.StyleController = this.dataLayoutControl1;
            this.StoreCodeTextEdit.TabIndex = 4;
            // 
            // CurrencyCodeTextEdit
            // 
            this.CurrencyCodeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trPaymentHeadersBindingSource, "CurrencyCode", true));
            this.CurrencyCodeTextEdit.Location = new System.Drawing.Point(372, 12);
            this.CurrencyCodeTextEdit.Name = "CurrencyCodeTextEdit";
            this.CurrencyCodeTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.CurrencyCodeTextEdit.Size = new System.Drawing.Size(146, 20);
            this.CurrencyCodeTextEdit.StyleController = this.dataLayoutControl1;
            this.CurrencyCodeTextEdit.TabIndex = 2;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(530, 328);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForPaymentHeaderId,
            this.ItemForInvoiceHeaderId,
            this.ItemForDocumentNumber,
            this.ItemForDocumentDate,
            this.ItemForDocumentTime,
            this.ItemForCurrencyCode,
            this.ItemForStoreCode,
            this.ItemForOfficeCode,
            this.ItemForCurrAccCode,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(510, 308);
            // 
            // ItemForPaymentHeaderId
            // 
            this.ItemForPaymentHeaderId.Control = this.PaymentHeaderIdTextEdit;
            this.ItemForPaymentHeaderId.Location = new System.Drawing.Point(0, 0);
            this.ItemForPaymentHeaderId.Name = "ItemForPaymentHeaderId";
            this.ItemForPaymentHeaderId.Size = new System.Drawing.Size(255, 24);
            this.ItemForPaymentHeaderId.Text = "Payment Header Id";
            this.ItemForPaymentHeaderId.TextSize = new System.Drawing.Size(93, 13);
            // 
            // ItemForInvoiceHeaderId
            // 
            this.ItemForInvoiceHeaderId.Control = this.InvoiceHeaderIdTextEdit;
            this.ItemForInvoiceHeaderId.Location = new System.Drawing.Point(0, 24);
            this.ItemForInvoiceHeaderId.Name = "ItemForInvoiceHeaderId";
            this.ItemForInvoiceHeaderId.Size = new System.Drawing.Size(255, 24);
            this.ItemForInvoiceHeaderId.Text = "Invoice Header Id";
            this.ItemForInvoiceHeaderId.TextSize = new System.Drawing.Size(93, 13);
            // 
            // ItemForDocumentNumber
            // 
            this.ItemForDocumentNumber.Control = this.DocumentNumberTextEdit;
            this.ItemForDocumentNumber.Location = new System.Drawing.Point(0, 48);
            this.ItemForDocumentNumber.Name = "ItemForDocumentNumber";
            this.ItemForDocumentNumber.Size = new System.Drawing.Size(255, 24);
            this.ItemForDocumentNumber.Text = "Sənəd Nömrəsi";
            this.ItemForDocumentNumber.TextSize = new System.Drawing.Size(93, 13);
            // 
            // ItemForDocumentDate
            // 
            this.ItemForDocumentDate.Control = this.DocumentDateDateEdit;
            this.ItemForDocumentDate.Location = new System.Drawing.Point(0, 72);
            this.ItemForDocumentDate.Name = "ItemForDocumentDate";
            this.ItemForDocumentDate.Size = new System.Drawing.Size(255, 24);
            this.ItemForDocumentDate.Text = "Sənəd Tarixi";
            this.ItemForDocumentDate.TextSize = new System.Drawing.Size(93, 13);
            // 
            // ItemForDocumentTime
            // 
            this.ItemForDocumentTime.Control = this.DocumentTimeTimeSpanEdit;
            this.ItemForDocumentTime.Location = new System.Drawing.Point(0, 96);
            this.ItemForDocumentTime.Name = "ItemForDocumentTime";
            this.ItemForDocumentTime.Size = new System.Drawing.Size(255, 24);
            this.ItemForDocumentTime.Text = "Sənəd Vaxtı";
            this.ItemForDocumentTime.TextSize = new System.Drawing.Size(93, 13);
            // 
            // ItemForCurrencyCode
            // 
            this.ItemForCurrencyCode.Control = this.CurrencyCodeTextEdit;
            this.ItemForCurrencyCode.Location = new System.Drawing.Point(255, 0);
            this.ItemForCurrencyCode.Name = "ItemForCurrencyCode";
            this.ItemForCurrencyCode.Size = new System.Drawing.Size(255, 24);
            this.ItemForCurrencyCode.Text = "Valyuta";
            this.ItemForCurrencyCode.TextSize = new System.Drawing.Size(93, 13);
            // 
            // ItemForStoreCode
            // 
            this.ItemForStoreCode.Control = this.StoreCodeTextEdit;
            this.ItemForStoreCode.Location = new System.Drawing.Point(255, 24);
            this.ItemForStoreCode.Name = "ItemForStoreCode";
            this.ItemForStoreCode.Size = new System.Drawing.Size(255, 24);
            this.ItemForStoreCode.Text = "Mağaza";
            this.ItemForStoreCode.TextSize = new System.Drawing.Size(93, 13);
            // 
            // ItemForOfficeCode
            // 
            this.ItemForOfficeCode.Control = this.OfficeCodeTextEdit;
            this.ItemForOfficeCode.Location = new System.Drawing.Point(255, 48);
            this.ItemForOfficeCode.Name = "ItemForOfficeCode";
            this.ItemForOfficeCode.Size = new System.Drawing.Size(255, 24);
            this.ItemForOfficeCode.Text = "Ofis";
            this.ItemForOfficeCode.TextSize = new System.Drawing.Size(93, 13);
            // 
            // ItemForCurrAccCode
            // 
            this.ItemForCurrAccCode.Control = this.CurrAccCodeTextEdit;
            this.ItemForCurrAccCode.Location = new System.Drawing.Point(255, 72);
            this.ItemForCurrAccCode.Name = "ItemForCurrAccCode";
            this.ItemForCurrAccCode.Size = new System.Drawing.Size(255, 48);
            this.ItemForCurrAccCode.Text = "Cari Hesab";
            this.ItemForCurrAccCode.TextSize = new System.Drawing.Size(93, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(510, 188);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // trPaymentLinesBindingSource
            // 
            this.trPaymentLinesBindingSource.DataSource = typeof(Foxoft.Models.TrPaymentLine);
            // 
            // trPaymentHeadersBindingSource
            // 
            this.trPaymentHeadersBindingSource.DataSource = typeof(Foxoft.Models.TrPaymentHeader);
            // 
            // FormInvoicePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 328);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "FormInvoicePayment";
            this.Text = "FormInvoicePayment";
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentHeaderIdTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceHeaderIdTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentNumberTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentDateDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentDateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentTimeTimeSpanEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrAccCodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfficeCodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoreCodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrencyCodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPaymentHeaderId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForInvoiceHeaderId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCurrencyCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStoreCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOfficeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCurrAccCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trPaymentLinesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trPaymentHeadersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit PaymentHeaderIdTextEdit;
        private DevExpress.XtraEditors.TextEdit InvoiceHeaderIdTextEdit;
        private DevExpress.XtraEditors.TextEdit DocumentNumberTextEdit;
        private DevExpress.XtraEditors.DateEdit DocumentDateDateEdit;
        private DevExpress.XtraEditors.TimeSpanEdit DocumentTimeTimeSpanEdit;
        private DevExpress.XtraEditors.TextEdit CurrAccCodeTextEdit;
        private DevExpress.XtraEditors.TextEdit OfficeCodeTextEdit;
        private DevExpress.XtraEditors.TextEdit StoreCodeTextEdit;
        private DevExpress.XtraEditors.TextEdit CurrencyCodeTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPaymentHeaderId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForInvoiceHeaderId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDocumentNumber;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDocumentDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDocumentTime;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCurrAccCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOfficeCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStoreCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCurrencyCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentLineId;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPayment;
        private DevExpress.XtraGrid.Columns.GridColumn colLineDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyCode;
        private DevExpress.XtraGrid.Columns.GridColumn colExchangeRate;
        private DevExpress.XtraGrid.Columns.GridColumn colBankId;
        private DevExpress.XtraGrid.Columns.GridColumn colTrPaymentHeader;
        private DevExpress.XtraGrid.Columns.GridColumn colDcPaymentType;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedDate;
        private System.Windows.Forms.BindingSource trPaymentLinesBindingSource;
        private System.Windows.Forms.BindingSource trPaymentHeadersBindingSource;
    }
}