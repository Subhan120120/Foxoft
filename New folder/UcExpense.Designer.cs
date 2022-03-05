
namespace Foxoft
{
    partial class UcExpense
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.gC_InvoiceLine = new DevExpress.XtraGrid.GridControl();
            this.trInvoiceLinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gV_InvoiceLine = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInvoiceLineId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRelatedLineId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoBtnEdit_ProductCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscountCampaign = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNetAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVatRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesPersonCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReturnQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemainingQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrInvoiceHeader = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDcProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit_DocNum = new DevExpress.XtraEditors.ButtonEdit();
            this.trInvoiceHeadersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dateEdit_DocDate = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit_DocTime = new DevExpress.XtraEditors.TimeSpanEdit();
            this.memoEdit_InvoiceDesc = new DevExpress.XtraEditors.MemoEdit();
            this.btnEdit_CurrAccCode = new DevExpress.XtraEditors.ButtonEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForDocumentNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCurrAccCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDocumentDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDocumentTime = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gC_InvoiceLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trInvoiceLinesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_InvoiceLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoBtnEdit_ProductCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit_DocNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trInvoiceHeadersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DocDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DocDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DocTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_InvoiceDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit_CurrAccCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCurrAccCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentTime)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.AutoRetrieveFields = true;
            this.dataLayoutControl1.Controls.Add(this.gC_InvoiceLine);
            this.dataLayoutControl1.Controls.Add(this.btn_Save);
            this.dataLayoutControl1.Controls.Add(this.btnEdit_DocNum);
            this.dataLayoutControl1.Controls.Add(this.dateEdit_DocDate);
            this.dataLayoutControl1.Controls.Add(this.dateEdit_DocTime);
            this.dataLayoutControl1.Controls.Add(this.memoEdit_InvoiceDesc);
            this.dataLayoutControl1.Controls.Add(this.btnEdit_CurrAccCode);
            this.dataLayoutControl1.DataSource = this.trInvoiceHeadersBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(1018, 561);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // gC_InvoiceLine
            // 
            this.gC_InvoiceLine.DataSource = this.trInvoiceLinesBindingSource;
            this.gC_InvoiceLine.Location = new System.Drawing.Point(12, 84);
            this.gC_InvoiceLine.MainView = this.gV_InvoiceLine;
            this.gC_InvoiceLine.Name = "gC_InvoiceLine";
            this.gC_InvoiceLine.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoBtnEdit_ProductCode});
            this.gC_InvoiceLine.Size = new System.Drawing.Size(994, 372);
            this.gC_InvoiceLine.TabIndex = 11;
            this.gC_InvoiceLine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_InvoiceLine});
            // 
            // trInvoiceLinesBindingSource
            // 
            this.trInvoiceLinesBindingSource.DataSource = typeof(Foxoft.Models.TrInvoiceLine);
            // 
            // gV_InvoiceLine
            // 
            this.gV_InvoiceLine.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colInvoiceLineId,
            this.colInvoiceHeaderId,
            this.colRelatedLineId,
            this.colProductCode,
            this.colQty,
            this.colPrice,
            this.colAmount,
            this.colPosDiscount,
            this.colDiscountCampaign,
            this.colNetAmount,
            this.colVatRate,
            this.colLineDescription,
            this.colSalesPersonCode,
            this.colCurrencyCode,
            this.colExchangeRate,
            this.colReturnQty,
            this.colRemainingQty,
            this.colTrInvoiceHeader,
            this.colDcProduct,
            this.colCreatedUserName,
            this.colCreatedDate,
            this.colLastUpdatedUserName,
            this.colLastUpdatedDate});
            this.gV_InvoiceLine.CustomizationFormBounds = new System.Drawing.Rectangle(1167, 397, 264, 272);
            this.gV_InvoiceLine.GridControl = this.gC_InvoiceLine;
            this.gV_InvoiceLine.Name = "gV_InvoiceLine";
            this.gV_InvoiceLine.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gV_InvoiceLine.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gV_InvoiceLine.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gV_InvoiceLine_InitNewRow);
            this.gV_InvoiceLine.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gV_InvoiceLine_CellValueChanging);
            this.gV_InvoiceLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gV_InvoiceLine_KeyDown);
            // 
            // colInvoiceLineId
            // 
            this.colInvoiceLineId.FieldName = "InvoiceLineId";
            this.colInvoiceLineId.Name = "colInvoiceLineId";
            // 
            // colInvoiceHeaderId
            // 
            this.colInvoiceHeaderId.FieldName = "InvoiceHeaderId";
            this.colInvoiceHeaderId.Name = "colInvoiceHeaderId";
            // 
            // colRelatedLineId
            // 
            this.colRelatedLineId.FieldName = "RelatedLineId";
            this.colRelatedLineId.Name = "colRelatedLineId";
            // 
            // colProductCode
            // 
            this.colProductCode.ColumnEdit = this.repoBtnEdit_ProductCode;
            this.colProductCode.FieldName = "ProductCode";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.Visible = true;
            this.colProductCode.VisibleIndex = 0;
            // 
            // repoBtnEdit_ProductCode
            // 
            this.repoBtnEdit_ProductCode.AutoHeight = false;
            this.repoBtnEdit_ProductCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repoBtnEdit_ProductCode.Name = "repoBtnEdit_ProductCode";
            this.repoBtnEdit_ProductCode.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repoBtnEdit_ProductCode_ButtonPressed);
            // 
            // colQty
            // 
            this.colQty.FieldName = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 1;
            // 
            // colPrice
            // 
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 2;
            // 
            // colAmount
            // 
            this.colAmount.FieldName = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 3;
            // 
            // colPosDiscount
            // 
            this.colPosDiscount.FieldName = "PosDiscount";
            this.colPosDiscount.Name = "colPosDiscount";
            // 
            // colDiscountCampaign
            // 
            this.colDiscountCampaign.FieldName = "DiscountCampaign";
            this.colDiscountCampaign.Name = "colDiscountCampaign";
            // 
            // colNetAmount
            // 
            this.colNetAmount.FieldName = "NetAmount";
            this.colNetAmount.Name = "colNetAmount";
            // 
            // colVatRate
            // 
            this.colVatRate.FieldName = "VatRate";
            this.colVatRate.Name = "colVatRate";
            // 
            // colLineDescription
            // 
            this.colLineDescription.FieldName = "LineDescription";
            this.colLineDescription.Name = "colLineDescription";
            this.colLineDescription.Visible = true;
            this.colLineDescription.VisibleIndex = 4;
            // 
            // colSalesPersonCode
            // 
            this.colSalesPersonCode.FieldName = "SalesPersonCode";
            this.colSalesPersonCode.Name = "colSalesPersonCode";
            // 
            // colCurrencyCode
            // 
            this.colCurrencyCode.FieldName = "CurrencyCode";
            this.colCurrencyCode.Name = "colCurrencyCode";
            // 
            // colExchangeRate
            // 
            this.colExchangeRate.FieldName = "ExchangeRate";
            this.colExchangeRate.Name = "colExchangeRate";
            // 
            // colReturnQty
            // 
            this.colReturnQty.FieldName = "ReturnQty";
            this.colReturnQty.Name = "colReturnQty";
            // 
            // colRemainingQty
            // 
            this.colRemainingQty.FieldName = "RemainingQty";
            this.colRemainingQty.Name = "colRemainingQty";
            // 
            // colTrInvoiceHeader
            // 
            this.colTrInvoiceHeader.FieldName = "TrInvoiceHeader";
            this.colTrInvoiceHeader.Name = "colTrInvoiceHeader";
            // 
            // colDcProduct
            // 
            this.colDcProduct.FieldName = "DcProduct";
            this.colDcProduct.Name = "colDcProduct";
            // 
            // colCreatedUserName
            // 
            this.colCreatedUserName.FieldName = "CreatedUserName";
            this.colCreatedUserName.Name = "colCreatedUserName";
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            // 
            // colLastUpdatedUserName
            // 
            this.colLastUpdatedUserName.FieldName = "LastUpdatedUserName";
            this.colLastUpdatedUserName.Name = "colLastUpdatedUserName";
            // 
            // colLastUpdatedDate
            // 
            this.colLastUpdatedDate.FieldName = "LastUpdatedDate";
            this.colLastUpdatedDate.Name = "colLastUpdatedDate";
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(12, 460);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(994, 89);
            this.btn_Save.StyleController = this.dataLayoutControl1;
            this.btn_Save.TabIndex = 10;
            this.btn_Save.Text = "simpleButton1";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btnEdit_DocNum
            // 
            this.btnEdit_DocNum.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trInvoiceHeadersBindingSource, "DocumentNumber", true));
            this.btnEdit_DocNum.Location = new System.Drawing.Point(112, 12);
            this.btnEdit_DocNum.Name = "btnEdit_DocNum";
            this.btnEdit_DocNum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.btnEdit_DocNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnEdit_DocNum.Size = new System.Drawing.Size(395, 20);
            this.btnEdit_DocNum.StyleController = this.dataLayoutControl1;
            this.btnEdit_DocNum.TabIndex = 4;
            this.btnEdit_DocNum.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnEdit_DocNum_ButtonPressed);
            // 
            // trInvoiceHeadersBindingSource
            // 
            this.trInvoiceHeadersBindingSource.DataSource = typeof(Foxoft.Models.TrInvoiceHeader);
            // 
            // dateEdit_DocDate
            // 
            this.dateEdit_DocDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trInvoiceHeadersBindingSource, "DocumentDate", true));
            this.dateEdit_DocDate.EditValue = null;
            this.dateEdit_DocDate.Location = new System.Drawing.Point(611, 36);
            this.dateEdit_DocDate.Name = "dateEdit_DocDate";
            this.dateEdit_DocDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_DocDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_DocDate.Size = new System.Drawing.Size(395, 20);
            this.dateEdit_DocDate.StyleController = this.dataLayoutControl1;
            this.dateEdit_DocDate.TabIndex = 12;
            // 
            // dateEdit_DocTime
            // 
            this.dateEdit_DocTime.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trInvoiceHeadersBindingSource, "DocumentTime", true));
            this.dateEdit_DocTime.EditValue = System.TimeSpan.Parse("00:00:00");
            this.dateEdit_DocTime.Location = new System.Drawing.Point(611, 60);
            this.dateEdit_DocTime.Name = "dateEdit_DocTime";
            this.dateEdit_DocTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_DocTime.Size = new System.Drawing.Size(395, 20);
            this.dateEdit_DocTime.StyleController = this.dataLayoutControl1;
            this.dateEdit_DocTime.TabIndex = 13;
            // 
            // memoEdit_InvoiceDesc
            // 
            this.memoEdit_InvoiceDesc.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trInvoiceHeadersBindingSource, "Description", true));
            this.memoEdit_InvoiceDesc.Location = new System.Drawing.Point(112, 36);
            this.memoEdit_InvoiceDesc.Name = "memoEdit_InvoiceDesc";
            this.memoEdit_InvoiceDesc.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.memoEdit_InvoiceDesc.Properties.LinesCount = 2;
            this.memoEdit_InvoiceDesc.Size = new System.Drawing.Size(395, 44);
            this.memoEdit_InvoiceDesc.StyleController = this.dataLayoutControl1;
            this.memoEdit_InvoiceDesc.TabIndex = 7;
            // 
            // btnEdit_CurrAccCode
            // 
            this.btnEdit_CurrAccCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.trInvoiceHeadersBindingSource, "CurrAccCode", true));
            this.btnEdit_CurrAccCode.Location = new System.Drawing.Point(611, 12);
            this.btnEdit_CurrAccCode.Name = "btnEdit_CurrAccCode";
            this.btnEdit_CurrAccCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnEdit_CurrAccCode.Size = new System.Drawing.Size(395, 20);
            this.btnEdit_CurrAccCode.StyleController = this.dataLayoutControl1;
            this.btnEdit_CurrAccCode.TabIndex = 8;
            this.btnEdit_CurrAccCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnEdit_CurrAccCode_ButtonClick);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1018, 561);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForDocumentNumber,
            this.ItemForDescription,
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.ItemForCurrAccCode,
            this.ItemForDocumentDate,
            this.ItemForDocumentTime});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(998, 541);
            // 
            // ItemForDocumentNumber
            // 
            this.ItemForDocumentNumber.Control = this.btnEdit_DocNum;
            this.ItemForDocumentNumber.Location = new System.Drawing.Point(0, 0);
            this.ItemForDocumentNumber.Name = "ItemForDocumentNumber";
            this.ItemForDocumentNumber.Size = new System.Drawing.Size(499, 24);
            this.ItemForDocumentNumber.Text = "Document Number";
            this.ItemForDocumentNumber.TextSize = new System.Drawing.Size(88, 13);
            // 
            // ItemForDescription
            // 
            this.ItemForDescription.Control = this.memoEdit_InvoiceDesc;
            this.ItemForDescription.Location = new System.Drawing.Point(0, 24);
            this.ItemForDescription.Name = "ItemForDescription";
            this.ItemForDescription.Size = new System.Drawing.Size(499, 48);
            this.ItemForDescription.Text = "Description";
            this.ItemForDescription.TextSize = new System.Drawing.Size(88, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btn_Save;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 448);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(78, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(998, 93);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gC_InvoiceLine;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(998, 376);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ItemForCurrAccCode
            // 
            this.ItemForCurrAccCode.Control = this.btnEdit_CurrAccCode;
            this.ItemForCurrAccCode.Location = new System.Drawing.Point(499, 0);
            this.ItemForCurrAccCode.Name = "ItemForCurrAccCode";
            this.ItemForCurrAccCode.Size = new System.Drawing.Size(499, 24);
            this.ItemForCurrAccCode.Text = "Curr Acc Code";
            this.ItemForCurrAccCode.TextSize = new System.Drawing.Size(88, 13);
            // 
            // ItemForDocumentDate
            // 
            this.ItemForDocumentDate.Control = this.dateEdit_DocDate;
            this.ItemForDocumentDate.Location = new System.Drawing.Point(499, 24);
            this.ItemForDocumentDate.Name = "ItemForDocumentDate";
            this.ItemForDocumentDate.Size = new System.Drawing.Size(499, 24);
            this.ItemForDocumentDate.Text = "Document Date";
            this.ItemForDocumentDate.TextSize = new System.Drawing.Size(88, 13);
            // 
            // ItemForDocumentTime
            // 
            this.ItemForDocumentTime.Control = this.dateEdit_DocTime;
            this.ItemForDocumentTime.Location = new System.Drawing.Point(499, 48);
            this.ItemForDocumentTime.Name = "ItemForDocumentTime";
            this.ItemForDocumentTime.Size = new System.Drawing.Size(499, 24);
            this.ItemForDocumentTime.Text = "Document Time";
            this.ItemForDocumentTime.TextSize = new System.Drawing.Size(88, 13);
            // 
            // UcExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "UcExpense";
            this.Size = new System.Drawing.Size(1018, 561);
            this.Load += new System.EventHandler(this.UcExpense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gC_InvoiceLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trInvoiceLinesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_InvoiceLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoBtnEdit_ProductCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit_DocNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trInvoiceHeadersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DocDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DocDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DocTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_InvoiceDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit_CurrAccCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCurrAccCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private System.Windows.Forms.BindingSource trInvoiceHeadersBindingSource;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDocumentNumber;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescription;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCurrAccCode;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.BindingSource trInvoiceLinesBindingSource;
        private DevExpress.XtraGrid.GridControl gC_InvoiceLine;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_InvoiceLine;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceLineId;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colRelatedLineId;
        private DevExpress.XtraGrid.Columns.GridColumn colProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colPosDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountCampaign;
        private DevExpress.XtraGrid.Columns.GridColumn colNetAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colVatRate;
        private DevExpress.XtraGrid.Columns.GridColumn colLineDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesPersonCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyCode;
        private DevExpress.XtraGrid.Columns.GridColumn colExchangeRate;
        private DevExpress.XtraGrid.Columns.GridColumn colReturnQty;
        private DevExpress.XtraGrid.Columns.GridColumn colRemainingQty;
        private DevExpress.XtraGrid.Columns.GridColumn colTrInvoiceHeader;
        private DevExpress.XtraGrid.Columns.GridColumn colDcProduct;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.ButtonEdit btnEdit_DocNum;
        private DevExpress.XtraEditors.DateEdit dateEdit_DocDate;
        private DevExpress.XtraEditors.TimeSpanEdit dateEdit_DocTime;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDocumentDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDocumentTime;
        private DevExpress.XtraEditors.MemoEdit memoEdit_InvoiceDesc;
        private DevExpress.XtraEditors.ButtonEdit btnEdit_CurrAccCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repoBtnEdit_ProductCode;
    }
}
