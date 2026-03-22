namespace Foxoft
{
    partial class FormInvoiceCampaignLogList
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            gC_Log = new DevExpress.XtraGrid.GridControl();
            invoiceCampaignLogRowsBindingSource = new BindingSource(components);
            gV_Log = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colCampaignCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCampaignDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colCampaignTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colPromoCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colBaseAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            colBaseAmountLoc = new DevExpress.XtraGrid.Columns.GridColumn();
            colDiscountAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            colDiscountAmountLoc = new DevExpress.XtraGrid.Columns.GridColumn();
            colDiscountPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            colPaymentMethodId = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bBI_Refresh = new DevExpress.XtraBars.BarButtonItem();
            bBI_Export = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)gC_Log).BeginInit();
            ((System.ComponentModel.ISupportInitialize)invoiceCampaignLogRowsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_Log).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            SuspendLayout();
            gC_Log.DataSource = invoiceCampaignLogRowsBindingSource;
            gC_Log.Dock = DockStyle.Fill;
            gC_Log.Location = new Point(0, 158);
            gC_Log.MainView = gV_Log;
            gC_Log.Name = "gC_Log";
            gC_Log.Size = new Size(1100, 418);
            gC_Log.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_Log });
            gV_Log.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCreatedDate, colCampaignCode, colCampaignDesc, colCampaignTypeCode, colPromoCode, colProductCode, colBaseAmount, colBaseAmountLoc, colDiscountAmount, colDiscountAmountLoc, colDiscountPercent, colPaymentMethodId });
            gV_Log.GridControl = gC_Log;
            gV_Log.Name = "gV_Log";
            gV_Log.OptionsFind.FindDelay = 100;
            gV_Log.OptionsView.ShowGroupPanel = false;
            colCreatedDate.FieldName = "CreatedDate"; colCreatedDate.Caption = "Tarix"; colCreatedDate.Visible = true; colCreatedDate.VisibleIndex = 0;
            colCampaignCode.FieldName = "CampaignCode"; colCampaignCode.Caption = "Kod"; colCampaignCode.Visible = true; colCampaignCode.VisibleIndex = 1;
            colCampaignDesc.FieldName = "CampaignDesc"; colCampaignDesc.Caption = "Kampaniya"; colCampaignDesc.Visible = true; colCampaignDesc.VisibleIndex = 2;
            colCampaignTypeCode.FieldName = "CampaignTypeCode"; colCampaignTypeCode.Caption = "Tip"; colCampaignTypeCode.Visible = true; colCampaignTypeCode.VisibleIndex = 3;
            colPromoCode.FieldName = "PromoCode"; colPromoCode.Caption = "Promo"; colPromoCode.Visible = true; colPromoCode.VisibleIndex = 4;
            colProductCode.FieldName = "ProductCode"; colProductCode.Caption = "Məhsul"; colProductCode.Visible = true; colProductCode.VisibleIndex = 5;
            colBaseAmount.FieldName = "BaseAmount"; colBaseAmount.Caption = "Əsas məbləğ"; colBaseAmount.Visible = true; colBaseAmount.VisibleIndex = 6;
            colBaseAmountLoc.FieldName = "BaseAmountLoc"; colBaseAmountLoc.Caption = "Əsas məbləğ loc"; colBaseAmountLoc.Visible = true; colBaseAmountLoc.VisibleIndex = 7;
            colDiscountAmount.FieldName = "DiscountAmount"; colDiscountAmount.Caption = "Endirim"; colDiscountAmount.Visible = true; colDiscountAmount.VisibleIndex = 8;
            colDiscountAmountLoc.FieldName = "DiscountAmountLoc"; colDiscountAmountLoc.Caption = "Endirim loc"; colDiscountAmountLoc.Visible = true; colDiscountAmountLoc.VisibleIndex = 9;
            colDiscountPercent.FieldName = "DiscountPercent"; colDiscountPercent.Caption = "%"; colDiscountPercent.Visible = true; colDiscountPercent.VisibleIndex = 10;
            colPaymentMethodId.FieldName = "PaymentMethodId"; colPaymentMethodId.Caption = "Ödəmə üsulu"; colPaymentMethodId.Visible = true; colPaymentMethodId.VisibleIndex = 11;
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, bBI_Refresh, bBI_Export });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 3;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(1100, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            bBI_Refresh.Caption = "Yenilə"; bBI_Refresh.Id = 1; bBI_Refresh.ItemClick += bBI_Refresh_ItemClick;
            bBI_Export.Caption = "Excel"; bBI_Export.Id = 2; bBI_Export.ItemClick += bBI_Export_ItemClick;
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            ribbonPage1.Text = "Kampaniya log";
            ribbonPageGroup1.ItemLinks.Add(bBI_Refresh);
            ribbonPageGroup1.ItemLinks.Add(bBI_Export);
            ribbonPageGroup1.Text = "Əməliyyatlar";
            ribbonStatusBar1.Location = new Point(0, 576);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new Size(1100, 24);
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 600);
            Controls.Add(gC_Log);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            Name = "FormInvoiceCampaignLogList";
            Ribbon = ribbonControl1;
            StartPosition = FormStartPosition.CenterScreen;
            StatusBar = ribbonStatusBar1;
            Text = "Kampaniya log";
            Load += FormInvoiceCampaignLogList_Load;
            ((System.ComponentModel.ISupportInitialize)gC_Log).EndInit();
            ((System.ComponentModel.ISupportInitialize)invoiceCampaignLogRowsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_Log).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DevExpress.XtraGrid.GridControl gC_Log;
        private BindingSource invoiceCampaignLogRowsBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_Log;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCampaignCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCampaignDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colCampaignTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPromoCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseAmountLoc;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountAmountLoc;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountPercent;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentMethodId;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem bBI_Refresh;
        private DevExpress.XtraBars.BarButtonItem bBI_Export;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
    }
}