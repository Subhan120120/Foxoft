
using DevExpress.Utils;

namespace Foxoft
{
    partial class FormCurrAccList
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCurrAccList));
         this.gC_CurrAccList = new DevExpress.XtraGrid.GridControl();
         this.dcCurrAccsBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.gV_CurrAccList = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colCurrAccDesc = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colCurrAccTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colCompanyCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colOfficeCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colStoreCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colFatherName = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colNewPassword = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colConfirmPassword = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colIdentityNum = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colTaxNum = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colDataLanguageCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colCreditLimit = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colIsVip = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colCustomerTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colVendorTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colCustomerPosDiscountRate = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colIsDisabled = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colRowGuid = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colBonusCardNum = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colPhoneNum = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colBirthDate = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colBalance = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colDcCurrAccType = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colTrInvoiceHeaders = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colTrPaymentHeaders = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colTrPaymentLines = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colTrCurrAccRole = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colLastUpdatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
         this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
         this.bBI_CurrAccNew = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_CurAccEdit = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_quit = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_Report1 = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_ExportXlsx = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_CurrAccDelete = new DevExpress.XtraBars.BarButtonItem();
         this.bBI_CurAccRefresh = new DevExpress.XtraBars.BarButtonItem();
         this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
         this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
         this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
         ((System.ComponentModel.ISupportInitialize)(this.gC_CurrAccList)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dcCurrAccsBindingSource)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gV_CurrAccList)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
         this.SuspendLayout();
         // 
         // gC_CurrAccList
         // 
         this.gC_CurrAccList.DataSource = this.dcCurrAccsBindingSource;
         this.gC_CurrAccList.Dock = System.Windows.Forms.DockStyle.Fill;
         this.gC_CurrAccList.Location = new System.Drawing.Point(0, 158);
         this.gC_CurrAccList.MainView = this.gV_CurrAccList;
         this.gC_CurrAccList.Name = "gC_CurrAccList";
         this.gC_CurrAccList.Size = new System.Drawing.Size(858, 413);
         this.gC_CurrAccList.TabIndex = 0;
         this.gC_CurrAccList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_CurrAccList});
         this.gC_CurrAccList.Paint += new System.Windows.Forms.PaintEventHandler(this.gC_CurrAccList_Paint);
         this.gC_CurrAccList.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gC_CurrAccList_ProcessGridKey);
         // 
         // gV_CurrAccList
         // 
         this.gV_CurrAccList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCurrAccCode,
            this.colCurrAccDesc,
            this.colCurrAccTypeCode,
            this.colCompanyCode,
            this.colOfficeCode,
            this.colStoreCode,
            this.colFirstName,
            this.colLastName,
            this.colFatherName,
            this.colNewPassword,
            this.colConfirmPassword,
            this.colIdentityNum,
            this.colTaxNum,
            this.colDataLanguageCode,
            this.colCreditLimit,
            this.colIsVip,
            this.colCustomerTypeCode,
            this.colVendorTypeCode,
            this.colCustomerPosDiscountRate,
            this.colIsDisabled,
            this.colRowGuid,
            this.colBonusCardNum,
            this.colAddress,
            this.colPhoneNum,
            this.colBirthDate,
            this.colBalance,
            this.colDcCurrAccType,
            this.colTrInvoiceHeaders,
            this.colTrPaymentHeaders,
            this.colTrPaymentLines,
            this.colTrCurrAccRole,
            this.colCreatedUserName,
            this.colCreatedDate,
            this.colLastUpdatedUserName,
            this.colLastUpdatedDate});
         this.gV_CurrAccList.CustomizationFormBounds = new System.Drawing.Rectangle(867, 248, 264, 272);
         this.gV_CurrAccList.GridControl = this.gC_CurrAccList;
         this.gV_CurrAccList.Name = "gV_CurrAccList";
         this.gV_CurrAccList.OptionsView.ShowGroupPanel = false;
         this.gV_CurrAccList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gV_CurrAccList_FocusedRowChanged);
         this.gV_CurrAccList.ColumnFilterChanged += new System.EventHandler(this.gV_CurrAccList_ColumnFilterChanged);
         this.gV_CurrAccList.DoubleClick += new System.EventHandler(this.gV_CurrAccList_DoubleClick);
         // 
         // colCurrAccCode
         // 
         this.colCurrAccCode.FieldName = "CurrAccCode";
         this.colCurrAccCode.Name = "colCurrAccCode";
         this.colCurrAccCode.Visible = true;
         this.colCurrAccCode.VisibleIndex = 0;
         // 
         // colCurrAccDesc
         // 
         this.colCurrAccDesc.FieldName = "CurrAccDesc";
         this.colCurrAccDesc.Name = "colCurrAccDesc";
         this.colCurrAccDesc.Visible = true;
         this.colCurrAccDesc.VisibleIndex = 1;
         // 
         // colCurrAccTypeCode
         // 
         this.colCurrAccTypeCode.FieldName = "CurrAccTypeCode";
         this.colCurrAccTypeCode.Name = "colCurrAccTypeCode";
         // 
         // colCompanyCode
         // 
         this.colCompanyCode.FieldName = "CompanyCode";
         this.colCompanyCode.Name = "colCompanyCode";
         // 
         // colOfficeCode
         // 
         this.colOfficeCode.FieldName = "OfficeCode";
         this.colOfficeCode.Name = "colOfficeCode";
         // 
         // colStoreCode
         // 
         this.colStoreCode.FieldName = "StoreCode";
         this.colStoreCode.Name = "colStoreCode";
         // 
         // colFirstName
         // 
         this.colFirstName.FieldName = "FirstName";
         this.colFirstName.Name = "colFirstName";
         // 
         // colLastName
         // 
         this.colLastName.FieldName = "LastName";
         this.colLastName.Name = "colLastName";
         // 
         // colFatherName
         // 
         this.colFatherName.FieldName = "FatherName";
         this.colFatherName.Name = "colFatherName";
         // 
         // colNewPassword
         // 
         this.colNewPassword.FieldName = "NewPassword";
         this.colNewPassword.Name = "colNewPassword";
         // 
         // colConfirmPassword
         // 
         this.colConfirmPassword.FieldName = "ConfirmPassword";
         this.colConfirmPassword.Name = "colConfirmPassword";
         // 
         // colIdentityNum
         // 
         this.colIdentityNum.FieldName = "IdentityNum";
         this.colIdentityNum.Name = "colIdentityNum";
         // 
         // colTaxNum
         // 
         this.colTaxNum.FieldName = "TaxNum";
         this.colTaxNum.Name = "colTaxNum";
         // 
         // colDataLanguageCode
         // 
         this.colDataLanguageCode.FieldName = "DataLanguageCode";
         this.colDataLanguageCode.Name = "colDataLanguageCode";
         // 
         // colCreditLimit
         // 
         this.colCreditLimit.FieldName = "CreditLimit";
         this.colCreditLimit.Name = "colCreditLimit";
         // 
         // colIsVip
         // 
         this.colIsVip.FieldName = "IsVip";
         this.colIsVip.Name = "colIsVip";
         this.colIsVip.Visible = true;
         this.colIsVip.VisibleIndex = 2;
         // 
         // colCustomerTypeCode
         // 
         this.colCustomerTypeCode.FieldName = "CustomerTypeCode";
         this.colCustomerTypeCode.Name = "colCustomerTypeCode";
         // 
         // colVendorTypeCode
         // 
         this.colVendorTypeCode.FieldName = "VendorTypeCode";
         this.colVendorTypeCode.Name = "colVendorTypeCode";
         // 
         // colCustomerPosDiscountRate
         // 
         this.colCustomerPosDiscountRate.FieldName = "CustomerPosDiscountRate";
         this.colCustomerPosDiscountRate.Name = "colCustomerPosDiscountRate";
         // 
         // colIsDisabled
         // 
         this.colIsDisabled.FieldName = "IsDisabled";
         this.colIsDisabled.Name = "colIsDisabled";
         // 
         // colRowGuid
         // 
         this.colRowGuid.FieldName = "RowGuid";
         this.colRowGuid.Name = "colRowGuid";
         // 
         // colBonusCardNum
         // 
         this.colBonusCardNum.FieldName = "BonusCardNum";
         this.colBonusCardNum.Name = "colBonusCardNum";
         // 
         // colAddress
         // 
         this.colAddress.FieldName = "Address";
         this.colAddress.Name = "colAddress";
         // 
         // colPhoneNum
         // 
         this.colPhoneNum.FieldName = "PhoneNum";
         this.colPhoneNum.Name = "colPhoneNum";
         this.colPhoneNum.Visible = true;
         this.colPhoneNum.VisibleIndex = 3;
         // 
         // colBirthDate
         // 
         this.colBirthDate.FieldName = "BirthDate";
         this.colBirthDate.Name = "colBirthDate";
         // 
         // colBalance
         // 
         this.colBalance.FieldName = "Balance";
         this.colBalance.Name = "colBalance";
         this.colBalance.Visible = true;
         this.colBalance.VisibleIndex = 4;
         // 
         // colDcCurrAccType
         // 
         this.colDcCurrAccType.FieldName = "DcCurrAccType";
         this.colDcCurrAccType.Name = "colDcCurrAccType";
         // 
         // colTrInvoiceHeaders
         // 
         this.colTrInvoiceHeaders.FieldName = "TrInvoiceHeaders";
         this.colTrInvoiceHeaders.Name = "colTrInvoiceHeaders";
         // 
         // colTrPaymentHeaders
         // 
         this.colTrPaymentHeaders.FieldName = "TrPaymentHeaders";
         this.colTrPaymentHeaders.Name = "colTrPaymentHeaders";
         // 
         // colTrPaymentLines
         // 
         this.colTrPaymentLines.FieldName = "TrPaymentLines";
         this.colTrPaymentLines.Name = "colTrPaymentLines";
         // 
         // colTrCurrAccRole
         // 
         this.colTrCurrAccRole.FieldName = "TrCurrAccRole";
         this.colTrCurrAccRole.Name = "colTrCurrAccRole";
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
         // ribbonControl1
         // 
         this.ribbonControl1.ExpandCollapseItem.Id = 0;
         this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.bBI_CurrAccNew,
            this.bBI_CurAccEdit,
            this.bBI_quit,
            this.bBI_Report1,
            this.bBI_ExportXlsx,
            this.bBI_CurrAccDelete,
            this.bBI_CurAccRefresh});
         this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
         this.ribbonControl1.MaxItemId = 9;
         this.ribbonControl1.Name = "ribbonControl1";
         this.ribbonControl1.PageHeaderItemLinks.Add(this.bBI_quit);
         this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
         this.ribbonControl1.Size = new System.Drawing.Size(858, 158);
         this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
         // 
         // bBI_CurrAccNew
         // 
         this.bBI_CurrAccNew.Caption = "Yeni";
         this.bBI_CurrAccNew.Id = 1;
         this.bBI_CurrAccNew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_CurrAccNew.ImageOptions.SvgImage")));
         this.bBI_CurrAccNew.Name = "bBI_CurrAccNew";
         this.bBI_CurrAccNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_CurrAccNew_ItemClick);
         // 
         // bBI_CurAccEdit
         // 
         this.bBI_CurAccEdit.Caption = "Dəyiş";
         this.bBI_CurAccEdit.Id = 2;
         this.bBI_CurAccEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_CurAccEdit.ImageOptions.SvgImage")));
         this.bBI_CurAccEdit.Name = "bBI_CurAccEdit";
         this.bBI_CurAccEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_CurrAccEdit_ItemClick);
         // 
         // bBI_quit
         // 
         this.bBI_quit.Caption = "Bağla";
         this.bBI_quit.Id = 4;
         this.bBI_quit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_quit.ImageOptions.SvgImage")));
         this.bBI_quit.Name = "bBI_quit";
         this.bBI_quit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_quit_ItemClick);
         // 
         // bBI_Report1
         // 
         this.bBI_Report1.Caption = "Müştəri ilə Haqq Hesab";
         this.bBI_Report1.Id = 5;
         this.bBI_Report1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_Report1.ImageOptions.SvgImage")));
         this.bBI_Report1.Name = "bBI_Report1";
         this.bBI_Report1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_Report1_ItemClick);
         // 
         // bBI_ExportXlsx
         // 
         this.bBI_ExportXlsx.Caption = "Excelə Göndər";
         this.bBI_ExportXlsx.Id = 6;
         this.bBI_ExportXlsx.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_ExportXlsx.ImageOptions.SvgImage")));
         this.bBI_ExportXlsx.Name = "bBI_ExportXlsx";
         this.bBI_ExportXlsx.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_ExportXlsx_ItemClick);
         // 
         // bBI_CurrAccDelete
         // 
         this.bBI_CurrAccDelete.Caption = "Sil";
         this.bBI_CurrAccDelete.Id = 7;
         this.bBI_CurrAccDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_CurrAccDelete.ImageOptions.SvgImage")));
         this.bBI_CurrAccDelete.Name = "bBI_CurrAccDelete";
         this.bBI_CurrAccDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_CurrAccDelete_ItemClick);
         // 
         // bBI_CurAccRefresh
         // 
         this.bBI_CurAccRefresh.Caption = "Yenilə";
         this.bBI_CurAccRefresh.Id = 8;
         this.bBI_CurAccRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_CurAccRefresh.ImageOptions.SvgImage")));
         this.bBI_CurAccRefresh.Name = "bBI_CurAccRefresh";
         this.bBI_CurAccRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_CurAccRefresh_ItemClick);
         // 
         // ribbonPage1
         // 
         this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup3});
         this.ribbonPage1.Name = "ribbonPage1";
         this.ribbonPage1.Text = "Cari Hesab";
         // 
         // ribbonPageGroup1
         // 
         this.ribbonPageGroup1.ItemLinks.Add(this.bBI_CurrAccNew);
         this.ribbonPageGroup1.ItemLinks.Add(this.bBI_CurAccEdit);
         this.ribbonPageGroup1.ItemLinks.Add(this.bBI_CurrAccDelete);
         this.ribbonPageGroup1.ItemLinks.Add(this.bBI_CurAccRefresh);
         this.ribbonPageGroup1.Name = "ribbonPageGroup1";
         this.ribbonPageGroup1.Text = "İdarə";
         // 
         // ribbonPageGroup3
         // 
         this.ribbonPageGroup3.ItemLinks.Add(this.bBI_Report1);
         this.ribbonPageGroup3.ItemLinks.Add(this.bBI_ExportXlsx);
         this.ribbonPageGroup3.Name = "ribbonPageGroup3";
         this.ribbonPageGroup3.Text = "Hesabat";
         // 
         // ribbonStatusBar1
         // 
         this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 571);
         this.ribbonStatusBar1.Name = "ribbonStatusBar1";
         this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
         this.ribbonStatusBar1.Size = new System.Drawing.Size(858, 24);
         // 
         // ribbonPage2
         // 
         this.ribbonPage2.Name = "ribbonPage2";
         this.ribbonPage2.Text = "ribbonPage2";
         // 
         // FormCurrAccList
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(858, 595);
         this.Controls.Add(this.gC_CurrAccList);
         this.Controls.Add(this.ribbonStatusBar1);
         this.Controls.Add(this.ribbonControl1);
         this.Name = "FormCurrAccList";
         this.Ribbon = this.ribbonControl1;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.StatusBar = this.ribbonStatusBar1;
         this.Text = "Cari Hesablar";
         ((System.ComponentModel.ISupportInitialize)(this.gC_CurrAccList)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dcCurrAccsBindingSource)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gV_CurrAccList)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gC_CurrAccList;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_CurrAccList;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem bBI_CurrAccNew;
        private DevExpress.XtraBars.BarButtonItem bBI_CurAccEdit;
        private DevExpress.XtraBars.BarButtonItem bBI_quit;
      private DevExpress.XtraBars.BarButtonItem bBI_Report1;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
      private DevExpress.XtraBars.BarButtonItem bBI_ExportXlsx;
      private System.Windows.Forms.BindingSource dcCurrAccsBindingSource;
      private DevExpress.XtraGrid.Columns.GridColumn colCurrAccCode;
      private DevExpress.XtraGrid.Columns.GridColumn colCurrAccDesc;
      private DevExpress.XtraGrid.Columns.GridColumn colCurrAccTypeCode;
      private DevExpress.XtraGrid.Columns.GridColumn colCompanyCode;
      private DevExpress.XtraGrid.Columns.GridColumn colOfficeCode;
      private DevExpress.XtraGrid.Columns.GridColumn colStoreCode;
      private DevExpress.XtraGrid.Columns.GridColumn colFirstName;
      private DevExpress.XtraGrid.Columns.GridColumn colLastName;
      private DevExpress.XtraGrid.Columns.GridColumn colFatherName;
      private DevExpress.XtraGrid.Columns.GridColumn colNewPassword;
      private DevExpress.XtraGrid.Columns.GridColumn colConfirmPassword;
      private DevExpress.XtraGrid.Columns.GridColumn colIdentityNum;
      private DevExpress.XtraGrid.Columns.GridColumn colTaxNum;
      private DevExpress.XtraGrid.Columns.GridColumn colDataLanguageCode;
      private DevExpress.XtraGrid.Columns.GridColumn colCreditLimit;
      private DevExpress.XtraGrid.Columns.GridColumn colIsVip;
      private DevExpress.XtraGrid.Columns.GridColumn colCustomerTypeCode;
      private DevExpress.XtraGrid.Columns.GridColumn colVendorTypeCode;
      private DevExpress.XtraGrid.Columns.GridColumn colCustomerPosDiscountRate;
      private DevExpress.XtraGrid.Columns.GridColumn colIsDisabled;
      private DevExpress.XtraGrid.Columns.GridColumn colRowGuid;
      private DevExpress.XtraGrid.Columns.GridColumn colBonusCardNum;
      private DevExpress.XtraGrid.Columns.GridColumn colAddress;
      private DevExpress.XtraGrid.Columns.GridColumn colPhoneNum;
      private DevExpress.XtraGrid.Columns.GridColumn colBirthDate;
      private DevExpress.XtraGrid.Columns.GridColumn colBalance;
      private DevExpress.XtraGrid.Columns.GridColumn colDcCurrAccType;
      private DevExpress.XtraGrid.Columns.GridColumn colTrInvoiceHeaders;
      private DevExpress.XtraGrid.Columns.GridColumn colTrPaymentHeaders;
      private DevExpress.XtraGrid.Columns.GridColumn colTrPaymentLines;
      private DevExpress.XtraGrid.Columns.GridColumn colTrCurrAccRole;
      private DevExpress.XtraGrid.Columns.GridColumn colCreatedUserName;
      private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
      private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedUserName;
      private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedDate;
      private DevExpress.XtraBars.BarButtonItem bBI_CurrAccDelete;
      private DevExpress.XtraBars.BarButtonItem bBI_CurAccRefresh;
   }
}