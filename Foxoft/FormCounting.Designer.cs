using Foxoft.Models.ViewModel;
using Foxoft.Properties;

namespace Foxoft
{
    partial class FormCounting
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            colDifference = new DevExpress.XtraGrid.Columns.GridColumn();
            wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            LUE_StoreCode = new DevExpress.XtraEditors.LookUpEdit();
            LUE_WarehouseCode = new DevExpress.XtraEditors.LookUpEdit();
            checkEdit_ResetUncountedProductBalance = new DevExpress.XtraEditors.CheckEdit();
            completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            wizardPage2 = new DevExpress.XtraWizard.WizardPage();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            trInvoiceLineBindingSource = new BindingSource(components);
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colInvoiceLineId = new DevExpress.XtraGrid.Columns.GridColumn();
            colInvoiceHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            colRelatedLineId = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            colQtyIn = new DevExpress.XtraGrid.Columns.GridColumn();
            colQtyOut = new DevExpress.XtraGrid.Columns.GridColumn();
            colUnitOfMeasureId = new DevExpress.XtraGrid.Columns.GridColumn();
            colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            colPriceLoc = new DevExpress.XtraGrid.Columns.GridColumn();
            colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            colAmountLoc = new DevExpress.XtraGrid.Columns.GridColumn();
            colNetAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            colNetAmountLoc = new DevExpress.XtraGrid.Columns.GridColumn();
            colDiscountCampaign = new DevExpress.XtraGrid.Columns.GridColumn();
            colLineDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colSerialNumberCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            colPosDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            col_ProductDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)wizardControl1).BeginInit();
            wizardControl1.SuspendLayout();
            welcomeWizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LUE_StoreCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LUE_WarehouseCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkEdit_ResetUncountedProductBalance.Properties).BeginInit();
            wizardPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trInvoiceLineBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            SuspendLayout();
            // 
            // colDifference
            // 
            colDifference.FieldName = "Difference";
            colDifference.Name = "colDifference";
            colDifference.Visible = true;
            colDifference.VisibleIndex = 11;
            // 
            // wizardControl1
            // 
            wizardControl1.Controls.Add(welcomeWizardPage1);
            wizardControl1.Controls.Add(completionWizardPage1);
            wizardControl1.Controls.Add(wizardPage2);
            wizardControl1.Dock = DockStyle.Fill;
            wizardControl1.ImageOptions.ImageWidth = 216;
            wizardControl1.Margin = new Padding(4, 3, 4, 3);
            wizardControl1.MinimumSize = new Size(117, 115);
            wizardControl1.Name = "wizardControl1";
            wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] { welcomeWizardPage1, wizardPage2, completionWizardPage1 });
            wizardControl1.Size = new Size(1015, 528);
            wizardControl1.FinishClick += WizardControl1_FinishClick;
            wizardControl1.NextClick += WizardControl1_NextClick;
            // 
            // welcomeWizardPage1
            // 
            welcomeWizardPage1.Controls.Add(LUE_StoreCode);
            welcomeWizardPage1.Controls.Add(LUE_WarehouseCode);
            welcomeWizardPage1.Controls.Add(checkEdit_ResetUncountedProductBalance);
            welcomeWizardPage1.Margin = new Padding(4, 3, 4, 3);
            welcomeWizardPage1.Name = "welcomeWizardPage1";
            welcomeWizardPage1.Size = new Size(767, 396);
            // 
            // LUE_StoreCode
            // 
            LUE_StoreCode.Location = new Point(3, 46);
            LUE_StoreCode.Name = "LUE_StoreCode";
            LUE_StoreCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            LUE_StoreCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrAccCode", "Mağaza Kodu"), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrAccDesc", "Mağaza Adı") });
            LUE_StoreCode.Properties.DisplayMember = "CurrAccDesc";
            LUE_StoreCode.Properties.NullText = Resources.Form_Counting_LUE_Store_NullText;
            LUE_StoreCode.Properties.ValueMember = "CurrAccCode";
            LUE_StoreCode.Size = new Size(255, 20);
            LUE_StoreCode.TabIndex = 1;
            LUE_StoreCode.EditValueChanged += LUE_StoreCode_EditValueChanged;
            // 
            // LUE_WarehouseCode
            // 
            LUE_WarehouseCode.Location = new Point(3, 72);
            LUE_WarehouseCode.Name = "LUE_WarehouseCode";
            LUE_WarehouseCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            LUE_WarehouseCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseCode", "Depo Kodu"), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseDesc", "Depo Adı") });
            LUE_WarehouseCode.Properties.DisplayMember = "WarehouseDesc";
            LUE_WarehouseCode.Properties.NullText = Resources.Form_Counting_LUE_Warehouse_NullText;
            LUE_WarehouseCode.Properties.ValueMember = "WarehouseCode";
            LUE_WarehouseCode.Size = new Size(255, 20);
            LUE_WarehouseCode.TabIndex = 1;
            // 
            // checkEdit_ResetUncountedProductBalance
            // 
            checkEdit_ResetUncountedProductBalance.Location = new Point(3, 98);
            checkEdit_ResetUncountedProductBalance.Name = "checkEdit_ResetUncountedProductBalance";
            checkEdit_ResetUncountedProductBalance.Properties.Caption = Resources.Form_Counting_CheckEdit_ResetUncountedProductBalance;
            checkEdit_ResetUncountedProductBalance.Size = new Size(255, 20);
            checkEdit_ResetUncountedProductBalance.TabIndex = 1;
            // 
            // completionWizardPage1
            // 
            completionWizardPage1.Margin = new Padding(4, 3, 4, 3);
            completionWizardPage1.Name = "completionWizardPage1";
            completionWizardPage1.Size = new Size(767, 396);
            // 
            // wizardPage2
            // 
            wizardPage2.Controls.Add(gridControl1);
            wizardPage2.Name = "wizardPage2";
            wizardPage2.Size = new Size(983, 385);
            wizardPage2.PageInit += WizardPage2_PageInit;
            // 
            // gridControl1
            // 
            gridControl1.DataSource = trInvoiceLineBindingSource;
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 0);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(983, 385);
            gridControl1.TabIndex = 1;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // trInvoiceLineBindingSource
            // 
            trInvoiceLineBindingSource.DataSource = typeof(CountingVM);
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colInvoiceLineId, colInvoiceHeaderId, colRelatedLineId, colProductCode, colQty, colQtyIn, colQtyOut, colUnitOfMeasureId, colPrice, colPriceLoc, colAmount, colAmountLoc, colNetAmount, colNetAmountLoc, colDiscountCampaign, colLineDescription, colSerialNumberCode, colBalance, colCurrencyCode, colExchangeRate, colPosDiscount, colDifference, col_ProductDesc });
            gridFormatRule1.Column = colDifference;
            gridFormatRule1.Name = "ruleNegative";
            formatConditionRuleValue1.Appearance.ForeColor = Color.Red;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Less;
            formatConditionRuleValue1.Value1 = 0;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.Column = colDifference;
            gridFormatRule2.Name = "rulePositive";
            formatConditionRuleValue2.Appearance.ForeColor = Color.Green;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Greater;
            formatConditionRuleValue2.Value1 = 0;
            gridFormatRule2.Rule = formatConditionRuleValue2;
            gridView1.FormatRules.Add(gridFormatRule1);
            gridView1.FormatRules.Add(gridFormatRule2);
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsView.ShowFooter = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.CustomUnboundColumnData += gridView1_CustomUnboundColumnData;
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
            // colRelatedLineId
            // 
            colRelatedLineId.FieldName = "RelatedLineId";
            colRelatedLineId.Name = "colRelatedLineId";
            // 
            // colProductCode
            // 
            colProductCode.FieldName = "ProductCode";
            colProductCode.Name = "colProductCode";
            colProductCode.Visible = true;
            colProductCode.VisibleIndex = 1;
            // 
            // colQty
            // 
            colQty.FieldName = "Qty";
            colQty.Name = "colQty";
            colQty.Visible = true;
            colQty.VisibleIndex = 3;
            // 
            // colQtyIn
            // 
            colQtyIn.FieldName = "QtyIn";
            colQtyIn.Name = "colQtyIn";
            // 
            // colQtyOut
            // 
            colQtyOut.FieldName = "QtyOut";
            colQtyOut.Name = "colQtyOut";
            // 
            // colUnitOfMeasureId
            // 
            colUnitOfMeasureId.FieldName = "UnitOfMeasureId";
            colUnitOfMeasureId.Name = "colUnitOfMeasureId";
            colUnitOfMeasureId.Visible = true;
            colUnitOfMeasureId.VisibleIndex = 4;
            // 
            // colPrice
            // 
            colPrice.FieldName = "Price";
            colPrice.Name = "colPrice";
            colPrice.Visible = true;
            colPrice.VisibleIndex = 5;
            // 
            // colPriceLoc
            // 
            colPriceLoc.FieldName = "PriceLoc";
            colPriceLoc.Name = "colPriceLoc";
            // 
            // colAmount
            // 
            colAmount.FieldName = "Amount";
            colAmount.Name = "colAmount";
            // 
            // colAmountLoc
            // 
            colAmountLoc.FieldName = "AmountLoc";
            colAmountLoc.Name = "colAmountLoc";
            // 
            // colNetAmount
            // 
            colNetAmount.FieldName = "NetAmount";
            colNetAmount.Name = "colNetAmount";
            colNetAmount.Visible = true;
            colNetAmount.VisibleIndex = 8;
            // 
            // colNetAmountLoc
            // 
            colNetAmountLoc.FieldName = "NetAmountLoc";
            colNetAmountLoc.Name = "colNetAmountLoc";
            // 
            // colDiscountCampaign
            // 
            colDiscountCampaign.FieldName = "DiscountCampaign";
            colDiscountCampaign.Name = "colDiscountCampaign";
            // 
            // colLineDescription
            // 
            colLineDescription.FieldName = "LineDescription";
            colLineDescription.Name = "colLineDescription";
            colLineDescription.Visible = true;
            colLineDescription.VisibleIndex = 9;
            // 
            // colSerialNumberCode
            // 
            colSerialNumberCode.FieldName = "SerialNumberCode";
            colSerialNumberCode.Name = "colSerialNumberCode";
            colSerialNumberCode.Visible = true;
            colSerialNumberCode.VisibleIndex = 0;
            // 
            // colBalance
            // 
            colBalance.FieldName = "Balance";
            colBalance.Name = "colBalance";
            colBalance.Visible = true;
            colBalance.VisibleIndex = 10;
            // 
            // colCurrencyCode
            // 
            colCurrencyCode.FieldName = "CurrencyCode";
            colCurrencyCode.Name = "colCurrencyCode";
            colCurrencyCode.Visible = true;
            colCurrencyCode.VisibleIndex = 6;
            // 
            // colExchangeRate
            // 
            colExchangeRate.FieldName = "ExchangeRate";
            colExchangeRate.Name = "colExchangeRate";
            // 
            // colPosDiscount
            // 
            colPosDiscount.FieldName = "PosDiscount";
            colPosDiscount.Name = "colPosDiscount";
            colPosDiscount.OptionsFilter.AllowFilter = false;
            colPosDiscount.Visible = true;
            colPosDiscount.VisibleIndex = 7;
            // 
            // col_ProductDesc
            // 
            col_ProductDesc.Caption = Resources.Entity_Product_Desc;
            col_ProductDesc.FieldName = "DcProduct.ProductDesc";
            col_ProductDesc.Name = "col_ProductDesc";
            col_ProductDesc.OptionsFilter.AllowFilter = false;
            col_ProductDesc.UnboundDataType = typeof(string);
            col_ProductDesc.Visible = true;
            col_ProductDesc.VisibleIndex = 2;
            // 
            // FormCounting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1015, 528);
            Controls.Add(wizardControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCounting";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WizardForm1";
            ((System.ComponentModel.ISupportInitialize)wizardControl1).EndInit();
            wizardControl1.ResumeLayout(false);
            welcomeWizardPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LUE_StoreCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)LUE_WarehouseCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)checkEdit_ResetUncountedProductBalance.Properties).EndInit();
            wizardPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trInvoiceLineBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
        }


        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage1;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.CheckEdit checkEdit_ResetUncountedProductBalance;
        private DevExpress.XtraWizard.WizardPage wizardPage2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private BindingSource trInvoiceLineBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceLineId;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colRelatedLineId;
        private DevExpress.XtraGrid.Columns.GridColumn colProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyIn;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyOut;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitOfMeasureId;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceLoc;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colAmountLoc;
        private DevExpress.XtraGrid.Columns.GridColumn colNetAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colNetAmountLoc;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountCampaign;
        private DevExpress.XtraGrid.Columns.GridColumn colLineDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colSerialNumberCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBalance;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyCode;
        private DevExpress.XtraGrid.Columns.GridColumn colExchangeRate;
        private DevExpress.XtraGrid.Columns.GridColumn colPosDiscount;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraEditors.LookUpEdit LUE_WarehouseCode;
        private DevExpress.XtraEditors.LookUpEdit LUE_StoreCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDifference;
        private DevExpress.XtraGrid.GridFormatRule ruleNegative;
        private DevExpress.XtraGrid.GridFormatRule rulePositive;
        private DevExpress.XtraEditors.FormatConditionRuleValue conditionNegative;
        private DevExpress.XtraEditors.FormatConditionRuleValue conditionPositive;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProductDesc;
    }
}