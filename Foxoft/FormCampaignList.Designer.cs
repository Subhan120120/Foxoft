using Foxoft.Models;
using Foxoft.Models.Entity;

namespace Foxoft
{
    partial class FormCampaignList
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
            gC_CampaignList = new DevExpress.XtraGrid.GridControl();
            dcCampaignsBindingSource = new BindingSource(components);
            gV_CampaignList = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCampaignId = new DevExpress.XtraGrid.Columns.GridColumn();
            colCampaignCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCampaignDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colCampaignTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colPromoCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colDiscountTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colDiscountValue = new DevExpress.XtraGrid.Columns.GridColumn();
            colPriority = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            colIsCombinable = new DevExpress.XtraGrid.Columns.GridColumn();
            colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bBI_CampaignNew = new DevExpress.XtraBars.BarButtonItem();
            bBI_CampaignEdit = new DevExpress.XtraBars.BarButtonItem();
            bBI_CampaignDelete = new DevExpress.XtraBars.BarButtonItem();
            bBI_CampaignRefresh = new DevExpress.XtraBars.BarButtonItem();
            bBI_ExportXlsx = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)gC_CampaignList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dcCampaignsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_CampaignList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            SuspendLayout();
            // grid
            gC_CampaignList.DataSource = dcCampaignsBindingSource;
            gC_CampaignList.Dock = DockStyle.Fill;
            gC_CampaignList.Location = new Point(0, 158);
            gC_CampaignList.MainView = gV_CampaignList;
            gC_CampaignList.Name = "gC_CampaignList";
            gC_CampaignList.Size = new Size(1200, 418);
            gC_CampaignList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_CampaignList });
            gC_CampaignList.ProcessGridKey += gC_CampaignList_ProcessGridKey;
            dcCampaignsBindingSource.DataSource = typeof(DcCampaign);
            gV_CampaignList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCampaignId, colCampaignCode, colCampaignDesc, colCampaignTypeCode, colPromoCode, colDiscountTypeCode, colDiscountValue, colPriority, colIsActive, colIsCombinable, colStartDate, colEndDate });
            gV_CampaignList.GridControl = gC_CampaignList;
            gV_CampaignList.Name = "gV_CampaignList";
            gV_CampaignList.OptionsFind.FindDelay = 100;
            gV_CampaignList.OptionsView.ShowGroupPanel = false;
            gV_CampaignList.DoubleClick += gV_CampaignList_DoubleClick;
            colCampaignId.FieldName = "CampaignId"; colCampaignId.Name = "colCampaignId";
            colCampaignCode.FieldName = "CampaignCode"; colCampaignCode.Caption = "Kod"; colCampaignCode.Visible = true; colCampaignCode.VisibleIndex = 0;
            colCampaignDesc.FieldName = "CampaignDesc"; colCampaignDesc.Caption = "Ad"; colCampaignDesc.Visible = true; colCampaignDesc.VisibleIndex = 1;
            colCampaignTypeCode.FieldName = "CampaignTypeCode"; colCampaignTypeCode.Caption = "Tip"; colCampaignTypeCode.Visible = true; colCampaignTypeCode.VisibleIndex = 2;
            colPromoCode.FieldName = "PromoCode"; colPromoCode.Caption = "Promo"; colPromoCode.Visible = true; colPromoCode.VisibleIndex = 3;
            colDiscountTypeCode.FieldName = "DiscountTypeCode"; colDiscountTypeCode.Caption = "Endirim tipi"; colDiscountTypeCode.Visible = true; colDiscountTypeCode.VisibleIndex = 4;
            colDiscountValue.FieldName = "DiscountValue"; colDiscountValue.Caption = "Dəyər"; colDiscountValue.Visible = true; colDiscountValue.VisibleIndex = 5;
            colPriority.FieldName = "Priority"; colPriority.Caption = "Prioritet"; colPriority.Visible = true; colPriority.VisibleIndex = 6;
            colIsActive.FieldName = "IsActive"; colIsActive.Caption = "Aktiv"; colIsActive.Visible = true; colIsActive.VisibleIndex = 7;
            colIsCombinable.FieldName = "IsCombinable"; colIsCombinable.Caption = "Birləşə bilir"; colIsCombinable.Visible = true; colIsCombinable.VisibleIndex = 8;
            colStartDate.FieldName = "StartDate"; colStartDate.Caption = "Başlama"; colStartDate.Visible = true; colStartDate.VisibleIndex = 9;
            colEndDate.FieldName = "EndDate"; colEndDate.Caption = "Bitmə"; colEndDate.Visible = true; colEndDate.VisibleIndex = 10;
            // ribbon
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, bBI_CampaignNew, bBI_CampaignEdit, bBI_CampaignDelete, bBI_CampaignRefresh, bBI_ExportXlsx });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 6;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(1200, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            bBI_CampaignNew.Caption = "Yeni"; bBI_CampaignNew.Id = 1; bBI_CampaignNew.Name = "bBI_CampaignNew"; bBI_CampaignNew.ItemClick += bBI_CampaignNew_ItemClick;
            bBI_CampaignEdit.Caption = "Dəyiş"; bBI_CampaignEdit.Id = 2; bBI_CampaignEdit.Name = "bBI_CampaignEdit"; bBI_CampaignEdit.ItemClick += bBI_CampaignEdit_ItemClick;
            bBI_CampaignDelete.Caption = "Sil"; bBI_CampaignDelete.Id = 3; bBI_CampaignDelete.Name = "bBI_CampaignDelete"; bBI_CampaignDelete.ItemClick += bBI_CampaignDelete_ItemClick;
            bBI_CampaignRefresh.Caption = "Yenilə"; bBI_CampaignRefresh.Id = 4; bBI_CampaignRefresh.Name = "bBI_CampaignRefresh"; bBI_CampaignRefresh.ItemClick += bBI_CampaignRefresh_ItemClick;
            bBI_ExportXlsx.Caption = "Excel"; bBI_ExportXlsx.Id = 5; bBI_ExportXlsx.Name = "bBI_ExportXlsx"; bBI_ExportXlsx.ItemClick += bBI_ExportXlsx_ItemClick;
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup2 });
            ribbonPage1.Text = "Kampaniyalar";
            ribbonPageGroup1.ItemLinks.Add(bBI_CampaignNew);
            ribbonPageGroup1.ItemLinks.Add(bBI_CampaignEdit);
            ribbonPageGroup1.ItemLinks.Add(bBI_CampaignDelete);
            ribbonPageGroup1.ItemLinks.Add(bBI_CampaignRefresh);
            ribbonPageGroup1.Text = "İdarəetmə";
            ribbonPageGroup2.ItemLinks.Add(bBI_ExportXlsx);
            ribbonPageGroup2.Text = "Hesabat";
            ribbonStatusBar1.Location = new Point(0, 576);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new Size(1200, 24);
            // form
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 600);
            Controls.Add(gC_CampaignList);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            KeyPreview = true;
            Name = "FormCampaignList";
            Ribbon = ribbonControl1;
            StartPosition = FormStartPosition.CenterScreen;
            StatusBar = ribbonStatusBar1;
            Text = "Kampaniyalar";
            Load += FormCampaignList_Load;
            KeyDown += FormCampaignList_KeyDown;
            ((System.ComponentModel.ISupportInitialize)gC_CampaignList).EndInit();
            ((System.ComponentModel.ISupportInitialize)dcCampaignsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_CampaignList).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DevExpress.XtraGrid.GridControl gC_CampaignList;
        private BindingSource dcCampaignsBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_CampaignList;
        private DevExpress.XtraGrid.Columns.GridColumn colCampaignId;
        private DevExpress.XtraGrid.Columns.GridColumn colCampaignCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCampaignDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colCampaignTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPromoCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountValue;
        private DevExpress.XtraGrid.Columns.GridColumn colPriority;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colIsCombinable;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colEndDate;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem bBI_CampaignNew;
        private DevExpress.XtraBars.BarButtonItem bBI_CampaignEdit;
        private DevExpress.XtraBars.BarButtonItem bBI_CampaignDelete;
        private DevExpress.XtraBars.BarButtonItem bBI_CampaignRefresh;
        private DevExpress.XtraBars.BarButtonItem bBI_ExportXlsx;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
    }
}