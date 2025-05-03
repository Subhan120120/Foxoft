
using Foxoft.Models;

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
            components = new System.ComponentModel.Container();
            dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            gC_InvoiceLine = new DevExpress.XtraGrid.GridControl();
            trInvoiceLinesBindingSource = new BindingSource(components);
            gV_InvoiceLine = new DevExpress.XtraGrid.Views.Grid.GridView();
            colInvoiceLineId = new DevExpress.XtraGrid.Columns.GridColumn();
            colInvoiceHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            repoBtnEdit_ProductCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            colNetAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            colLineDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colSalesPersonCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colQtyIn = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            btn_Save = new DevExpress.XtraEditors.SimpleButton();
            btnEdit_DocNum = new DevExpress.XtraEditors.ButtonEdit();
            trInvoiceHeadersBindingSource = new BindingSource(components);
            dateEdit_DocDate = new DevExpress.XtraEditors.DateEdit();
            dateEdit_DocTime = new DevExpress.XtraEditors.TimeSpanEdit();
            memoEdit_InvoiceDesc = new DevExpress.XtraEditors.MemoEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForDocumentNumber = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDocumentDate = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDocumentTime = new DevExpress.XtraLayout.LayoutControlItem();
            colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).BeginInit();
            dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gC_InvoiceLine).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trInvoiceLinesBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_InvoiceLine).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_ProductCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_DocNum.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trInvoiceHeadersBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit_DocDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit_DocDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit_DocTime.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memoEdit_InvoiceDesc.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentTime).BeginInit();
            SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            dataLayoutControl1.AutoRetrieveFields = true;
            dataLayoutControl1.Controls.Add(gC_InvoiceLine);
            dataLayoutControl1.Controls.Add(btn_Save);
            dataLayoutControl1.Controls.Add(btnEdit_DocNum);
            dataLayoutControl1.Controls.Add(dateEdit_DocDate);
            dataLayoutControl1.Controls.Add(dateEdit_DocTime);
            dataLayoutControl1.Controls.Add(memoEdit_InvoiceDesc);
            dataLayoutControl1.DataSource = trInvoiceHeadersBindingSource;
            dataLayoutControl1.Dock = DockStyle.Fill;
            dataLayoutControl1.Location = new Point(0, 0);
            dataLayoutControl1.Name = "dataLayoutControl1";
            dataLayoutControl1.Root = Root;
            dataLayoutControl1.Size = new Size(950, 561);
            dataLayoutControl1.TabIndex = 0;
            dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // gC_InvoiceLine
            // 
            gC_InvoiceLine.DataSource = trInvoiceLinesBindingSource;
            gC_InvoiceLine.Location = new Point(12, 60);
            gC_InvoiceLine.MainView = gV_InvoiceLine;
            gC_InvoiceLine.Name = "gC_InvoiceLine";
            gC_InvoiceLine.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repoBtnEdit_ProductCode });
            gC_InvoiceLine.Size = new Size(926, 396);
            gC_InvoiceLine.TabIndex = 11;
            gC_InvoiceLine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_InvoiceLine });
            // 
            // trInvoiceLinesBindingSource
            // 
            trInvoiceLinesBindingSource.DataSource = typeof(TrInvoiceLine);
            // 
            // gV_InvoiceLine
            // 
            gV_InvoiceLine.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colInvoiceLineId, colInvoiceHeaderId, colProductCode, colAmount, colNetAmount, colLineDescription, colSalesPersonCode, colCurrencyCode, colExchangeRate, colCreatedUserName, colCreatedDate, colLastUpdatedUserName, colLastUpdatedDate, colQtyIn, colProductDesc, gridColumn2, colBarcode });
            gV_InvoiceLine.CustomizationFormBounds = new Rectangle(1167, 397, 264, 272);
            gV_InvoiceLine.GridControl = gC_InvoiceLine;
            gV_InvoiceLine.Name = "gV_InvoiceLine";
            gV_InvoiceLine.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gV_InvoiceLine.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gV_InvoiceLine.InitNewRow += gV_InvoiceLine_InitNewRow;
            gV_InvoiceLine.ShownEditor += gV_InvoiceLine_ShownEditor;
            gV_InvoiceLine.CellValueChanged += GV_InvoiceLine_CellValueChanged;
            gV_InvoiceLine.CellValueChanging += gV_InvoiceLine_CellValueChanging;
            gV_InvoiceLine.KeyDown += gV_InvoiceLine_KeyDown;
            gV_InvoiceLine.ValidatingEditor += GV_InvoiceLine_ValidatingEditor;
            gV_InvoiceLine.InvalidValueException += GV_InvoiceLine_InvalidValueException;
            // 
            // colInvoiceLineId
            // 
            colInvoiceLineId.FieldName = "InvoiceLineId";
            colInvoiceLineId.Name = "colInvoiceLineId";
            // 
            // colInvoiceHeaderId
            // 
            colInvoiceHeaderId.FieldName = "InvoiceHeaderId";
            colInvoiceHeaderId.Name = "colInvoiceHeaderId";
            // 
            // colProductCode
            // 
            colProductCode.ColumnEdit = repoBtnEdit_ProductCode;
            colProductCode.FieldName = "ProductCode";
            colProductCode.Name = "colProductCode";
            colProductCode.Visible = true;
            colProductCode.VisibleIndex = 0;
            // 
            // repoBtnEdit_ProductCode
            // 
            repoBtnEdit_ProductCode.AutoHeight = false;
            repoBtnEdit_ProductCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            repoBtnEdit_ProductCode.Name = "repoBtnEdit_ProductCode";
            repoBtnEdit_ProductCode.ButtonPressed += repoBtnEdit_ProductCode_ButtonPressed;
            // 
            // colAmount
            // 
            colAmount.FieldName = "Amount";
            colAmount.Name = "colAmount";
            // 
            // colNetAmount
            // 
            colNetAmount.FieldName = "NetAmount";
            colNetAmount.Name = "colNetAmount";
            // 
            // colLineDescription
            // 
            colLineDescription.FieldName = "LineDescription";
            colLineDescription.Name = "colLineDescription";
            colLineDescription.Visible = true;
            colLineDescription.VisibleIndex = 3;
            // 
            // colSalesPersonCode
            // 
            colSalesPersonCode.FieldName = "SalesPersonCode";
            colSalesPersonCode.Name = "colSalesPersonCode";
            // 
            // colCurrencyCode
            // 
            colCurrencyCode.FieldName = "CurrencyCode";
            colCurrencyCode.Name = "colCurrencyCode";
            // 
            // colExchangeRate
            // 
            colExchangeRate.FieldName = "ExchangeRate";
            colExchangeRate.Name = "colExchangeRate";
            // 
            // colCreatedUserName
            // 
            colCreatedUserName.FieldName = "CreatedUserName";
            colCreatedUserName.Name = "colCreatedUserName";
            // 
            // colCreatedDate
            // 
            colCreatedDate.FieldName = "CreatedDate";
            colCreatedDate.Name = "colCreatedDate";
            // 
            // colLastUpdatedUserName
            // 
            colLastUpdatedUserName.FieldName = "LastUpdatedUserName";
            colLastUpdatedUserName.Name = "colLastUpdatedUserName";
            // 
            // colLastUpdatedDate
            // 
            colLastUpdatedDate.FieldName = "LastUpdatedDate";
            colLastUpdatedDate.Name = "colLastUpdatedDate";
            // 
            // colQtyIn
            // 
            colQtyIn.FieldName = "QtyIn";
            colQtyIn.Name = "colQtyIn";
            // 
            // colProductDesc
            // 
            colProductDesc.FieldName = "DcProduct.ProductDesc";
            colProductDesc.Name = "colProductDesc";
            colProductDesc.Visible = true;
            colProductDesc.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            gridColumn2.FieldName = "Price";
            gridColumn2.Name = "gridColumn2";
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 2;
            // 
            // btn_Save
            // 
            btn_Save.Location = new Point(12, 460);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(926, 89);
            btn_Save.StyleController = dataLayoutControl1;
            btn_Save.TabIndex = 10;
            btn_Save.Text = "simpleButton1";
            btn_Save.Click += btn_Save_Click;
            // 
            // btnEdit_DocNum
            // 
            btnEdit_DocNum.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "DocumentNumber", true));
            btnEdit_DocNum.Location = new Point(112, 12);
            btnEdit_DocNum.Name = "btnEdit_DocNum";
            btnEdit_DocNum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            btnEdit_DocNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            btnEdit_DocNum.Size = new Size(361, 20);
            btnEdit_DocNum.StyleController = dataLayoutControl1;
            btnEdit_DocNum.TabIndex = 4;
            btnEdit_DocNum.ButtonPressed += btnEdit_DocNum_ButtonPressed;
            // 
            // trInvoiceHeadersBindingSource
            // 
            trInvoiceHeadersBindingSource.DataSource = typeof(TrInvoiceHeader);
            trInvoiceHeadersBindingSource.AddingNew += trInvoiceHeadersBindingSource_AddingNew;
            // 
            // dateEdit_DocDate
            // 
            dateEdit_DocDate.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "DocumentDate", true));
            dateEdit_DocDate.EditValue = null;
            dateEdit_DocDate.Location = new Point(577, 12);
            dateEdit_DocDate.Name = "dateEdit_DocDate";
            dateEdit_DocDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEdit_DocDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEdit_DocDate.Size = new Size(361, 20);
            dateEdit_DocDate.StyleController = dataLayoutControl1;
            dateEdit_DocDate.TabIndex = 12;
            // 
            // dateEdit_DocTime
            // 
            dateEdit_DocTime.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "DocumentTime", true));
            dateEdit_DocTime.EditValue = TimeSpan.Parse("00:00:00");
            dateEdit_DocTime.Location = new Point(577, 36);
            dateEdit_DocTime.Name = "dateEdit_DocTime";
            dateEdit_DocTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEdit_DocTime.Size = new Size(361, 20);
            dateEdit_DocTime.StyleController = dataLayoutControl1;
            dateEdit_DocTime.TabIndex = 13;
            // 
            // memoEdit_InvoiceDesc
            // 
            memoEdit_InvoiceDesc.DataBindings.Add(new Binding("EditValue", trInvoiceHeadersBindingSource, "Description", true));
            memoEdit_InvoiceDesc.Location = new Point(112, 36);
            memoEdit_InvoiceDesc.Name = "memoEdit_InvoiceDesc";
            memoEdit_InvoiceDesc.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            memoEdit_InvoiceDesc.Properties.LinesCount = 2;
            memoEdit_InvoiceDesc.Size = new Size(361, 20);
            memoEdit_InvoiceDesc.StyleController = dataLayoutControl1;
            memoEdit_InvoiceDesc.TabIndex = 7;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlGroup1 });
            Root.Name = "Root";
            Root.Size = new Size(950, 561);
            Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.AllowDrawBackground = false;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForDocumentNumber, ItemForDescription, layoutControlItem2, layoutControlItem1, ItemForDocumentDate, ItemForDocumentTime });
            layoutControlGroup1.Location = new Point(0, 0);
            layoutControlGroup1.Name = "autoGeneratedGroup0";
            layoutControlGroup1.Size = new Size(930, 541);
            // 
            // ItemForDocumentNumber
            // 
            ItemForDocumentNumber.Control = btnEdit_DocNum;
            ItemForDocumentNumber.Location = new Point(0, 0);
            ItemForDocumentNumber.Name = "ItemForDocumentNumber";
            ItemForDocumentNumber.Size = new Size(465, 24);
            ItemForDocumentNumber.Text = "Document Number";
            ItemForDocumentNumber.TextSize = new Size(88, 13);
            // 
            // ItemForDescription
            // 
            ItemForDescription.Control = memoEdit_InvoiceDesc;
            ItemForDescription.Location = new Point(0, 24);
            ItemForDescription.Name = "ItemForDescription";
            ItemForDescription.Size = new Size(465, 24);
            ItemForDescription.Text = "Description";
            ItemForDescription.TextSize = new Size(88, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = btn_Save;
            layoutControlItem2.Location = new Point(0, 448);
            layoutControlItem2.MinSize = new Size(78, 26);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(930, 93);
            layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem2.TextSize = new Size(0, 0);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = gC_InvoiceLine;
            layoutControlItem1.Location = new Point(0, 48);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(930, 400);
            layoutControlItem1.TextSize = new Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // ItemForDocumentDate
            // 
            ItemForDocumentDate.Control = dateEdit_DocDate;
            ItemForDocumentDate.Location = new Point(465, 0);
            ItemForDocumentDate.Name = "ItemForDocumentDate";
            ItemForDocumentDate.Size = new Size(465, 24);
            ItemForDocumentDate.Text = "Document Date";
            ItemForDocumentDate.TextSize = new Size(88, 13);
            // 
            // ItemForDocumentTime
            // 
            ItemForDocumentTime.Control = dateEdit_DocTime;
            ItemForDocumentTime.Location = new Point(465, 24);
            ItemForDocumentTime.Name = "ItemForDocumentTime";
            ItemForDocumentTime.Size = new Size(465, 24);
            ItemForDocumentTime.Text = "Document Time";
            ItemForDocumentTime.TextSize = new Size(88, 13);
            // 
            // colBarcode
            // 
            colBarcode.Caption = "Barkod";
            colBarcode.Name = "colBarcode";
            // 
            // UcExpense
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataLayoutControl1);
            Name = "UcExpense";
            Size = new Size(950, 561);
            Load += UcExpense_Load;
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).EndInit();
            dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gC_InvoiceLine).EndInit();
            ((System.ComponentModel.ISupportInitialize)trInvoiceLinesBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_InvoiceLine).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_ProductCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_DocNum.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)trInvoiceHeadersBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit_DocDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit_DocDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit_DocTime.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)memoEdit_InvoiceDesc.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentDate).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDocumentTime).EndInit();
            ResumeLayout(false);
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
        private DevExpress.XtraGrid.Columns.GridColumn colUnitOfMeasureId;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyIn;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyOut;
        private DevExpress.XtraGrid.Columns.GridColumn colProductDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
    }
}
