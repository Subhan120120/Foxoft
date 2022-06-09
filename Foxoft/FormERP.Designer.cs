
namespace Foxoft
{
    partial class FormERP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormERP));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.skinRibbonGalleryBarItem = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.skinPaletteDropDownButtonItem = new DevExpress.XtraBars.SkinPaletteDropDownButtonItem();
            this.bBI_MdiChildrenList = new DevExpress.XtraBars.BarMdiChildrenListItem();
            this.bBI_CloseWindows = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_POS = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage_Home = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGr_Control = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.aC_Root = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.aCE_Invoices = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aCE_RetailPurchaseInvoice = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aCE_RetailSaleInvoice = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aCE_shipment = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aCE_ApproveInvoice = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aCE_Expense = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aCE_MakePayment = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aCE_receivePayment = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aCE_Acounting = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aCE_HumanResource = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aCE_Reports = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aCE_Report = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aCE_Setting = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aCE_CurrAccs = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aCE_Payments = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aC_Root)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.ribbonControl.SearchEditItem,
            this.skinRibbonGalleryBarItem,
            this.skinPaletteDropDownButtonItem,
            this.bBI_MdiChildrenList,
            this.bBI_CloseWindows,
            this.bBI_POS});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 13;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.OptionsTouch.ShowTouchUISelectorInQAT = true;
            this.ribbonControl.OptionsTouch.ShowTouchUISelectorVisibilityItemInQATMenu = true;
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage_Home});
            this.ribbonControl.QuickToolbarItemLinks.Add(this.skinRibbonGalleryBarItem);
            this.ribbonControl.QuickToolbarItemLinks.Add(this.skinPaletteDropDownButtonItem);
            this.ribbonControl.QuickToolbarItemLinks.Add(this.bBI_POS);
            this.ribbonControl.Size = new System.Drawing.Size(1023, 158);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            // 
            // skinRibbonGalleryBarItem
            // 
            this.skinRibbonGalleryBarItem.Caption = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem.Id = 1;
            this.skinRibbonGalleryBarItem.Name = "skinRibbonGalleryBarItem";
            // 
            // skinPaletteDropDownButtonItem
            // 
            this.skinPaletteDropDownButtonItem.ActAsDropDown = true;
            this.skinPaletteDropDownButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.skinPaletteDropDownButtonItem.Id = 3;
            this.skinPaletteDropDownButtonItem.Name = "skinPaletteDropDownButtonItem";
            // 
            // bBI_MdiChildrenList
            // 
            this.bBI_MdiChildrenList.Caption = "Aktiv Pencereler";
            this.bBI_MdiChildrenList.Id = 4;
            this.bBI_MdiChildrenList.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_MdiChildrenList.ImageOptions.SvgImage")));
            this.bBI_MdiChildrenList.Name = "bBI_MdiChildrenList";
            // 
            // bBI_CloseWindows
            // 
            this.bBI_CloseWindows.Caption = "Pəncərələri Bağla";
            this.bBI_CloseWindows.Id = 9;
            this.bBI_CloseWindows.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_CloseWindows.ImageOptions.SvgImage")));
            this.bBI_CloseWindows.Name = "bBI_CloseWindows";
            this.bBI_CloseWindows.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_CloseWindows_ItemClick);
            // 
            // bBI_POS
            // 
            this.bBI_POS.Caption = "barButtonItem1";
            this.bBI_POS.Id = 12;
            this.bBI_POS.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_POS.ImageOptions.SvgImage")));
            this.bBI_POS.Name = "bBI_POS";
            this.bBI_POS.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_POS_ItemClick);
            // 
            // ribbonPage_Home
            // 
            this.ribbonPage_Home.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGr_Control});
            this.ribbonPage_Home.MergeOrder = 0;
            this.ribbonPage_Home.Name = "ribbonPage_Home";
            this.ribbonPage_Home.Text = "Ümumi";
            // 
            // ribbonPageGr_Control
            // 
            this.ribbonPageGr_Control.ItemLinks.Add(this.bBI_MdiChildrenList);
            this.ribbonPageGr_Control.ItemLinks.Add(this.bBI_CloseWindows);
            this.ribbonPageGr_Control.Name = "ribbonPageGr_Control";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 608);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1023, 24);
            // 
            // aC_Root
            // 
            this.aC_Root.Dock = System.Windows.Forms.DockStyle.Left;
            this.aC_Root.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aCE_Invoices,
            this.aCE_Acounting,
            this.aCE_HumanResource,
            this.aCE_Reports,
            this.aCE_Setting});
            this.aC_Root.Location = new System.Drawing.Point(0, 158);
            this.aC_Root.Name = "aC_Root";
            this.aC_Root.ResizeMode = DevExpress.XtraBars.Navigation.AccordionControlResizeMode.OuterResizeZone;
            this.aC_Root.RootDisplayMode = DevExpress.XtraBars.Navigation.AccordionControlRootDisplayMode.Footer;
            this.aC_Root.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.aC_Root.ShowFilterControl = DevExpress.XtraBars.Navigation.ShowFilterControl.Always;
            this.aC_Root.Size = new System.Drawing.Size(223, 450);
            this.aC_Root.TabIndex = 2;
            // 
            // aCE_Invoices
            // 
            this.aCE_Invoices.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aCE_RetailPurchaseInvoice,
            this.aCE_RetailSaleInvoice,
            this.aCE_shipment,
            this.aCE_ApproveInvoice,
            this.aCE_Expense,
            this.aCE_MakePayment,
            this.aCE_receivePayment,
            this.aCE_Payments});
            this.aCE_Invoices.Expanded = true;
            this.aCE_Invoices.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("aCE_Invoices.ImageOptions.SvgImage")));
            this.aCE_Invoices.Name = "aCE_Invoices";
            this.aCE_Invoices.Text = "Report";
            // 
            // aCE_RetailPurchaseInvoice
            // 
            this.aCE_RetailPurchaseInvoice.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("aCE_RetailPurchaseInvoice.ImageOptions.SvgImage")));
            this.aCE_RetailPurchaseInvoice.Name = "aCE_RetailPurchaseInvoice";
            this.aCE_RetailPurchaseInvoice.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aCE_RetailPurchaseInvoice.Text = "Alış Fakturası";
            this.aCE_RetailPurchaseInvoice.Click += new System.EventHandler(this.aCE_RetailPurchaseInvoice_Click);
            // 
            // aCE_RetailSaleInvoice
            // 
            this.aCE_RetailSaleInvoice.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("aCE_RetailSaleInvoice.ImageOptions.SvgImage")));
            this.aCE_RetailSaleInvoice.Name = "aCE_RetailSaleInvoice";
            this.aCE_RetailSaleInvoice.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aCE_RetailSaleInvoice.Text = "Satış Fakturası";
            this.aCE_RetailSaleInvoice.Click += new System.EventHandler(this.aCE_RetailSaleInvoice_Click);
            // 
            // aCE_shipment
            // 
            this.aCE_shipment.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("aCE_shipment.ImageOptions.SvgImage")));
            this.aCE_shipment.Name = "aCE_shipment";
            this.aCE_shipment.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aCE_shipment.Text = "Transfer Qəbzi";
            this.aCE_shipment.Click += new System.EventHandler(this.aCE_shipment_Click);
            // 
            // aCE_ApproveInvoice
            // 
            this.aCE_ApproveInvoice.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("aCE_ApproveInvoice.ImageOptions.SvgImage")));
            this.aCE_ApproveInvoice.Name = "aCE_ApproveInvoice";
            this.aCE_ApproveInvoice.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aCE_ApproveInvoice.Text = "Transferi Təsdiqlə";
            // 
            // aCE_Expense
            // 
            this.aCE_Expense.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("aCE_Expense.ImageOptions.SvgImage")));
            this.aCE_Expense.Name = "aCE_Expense";
            this.aCE_Expense.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aCE_Expense.Text = "Xərclər";
            this.aCE_Expense.Click += new System.EventHandler(this.aCE_Expense_Click);
            // 
            // aCE_MakePayment
            // 
            this.aCE_MakePayment.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("aCE_MakePayment.ImageOptions.SvgImage")));
            this.aCE_MakePayment.Name = "aCE_MakePayment";
            this.aCE_MakePayment.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aCE_MakePayment.Text = "Ödəniş Et";
            this.aCE_MakePayment.Click += new System.EventHandler(this.aCE_MakePayment_Click);
            // 
            // aCE_receivePayment
            // 
            this.aCE_receivePayment.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("aCE_receivePayment.ImageOptions.SvgImage")));
            this.aCE_receivePayment.Name = "aCE_receivePayment";
            this.aCE_receivePayment.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aCE_receivePayment.Text = "Ödəniş Al";
            this.aCE_receivePayment.Click += new System.EventHandler(this.aCE_receivePayment_Click);
            // 
            // aCE_Acounting
            // 
            this.aCE_Acounting.Expanded = true;
            this.aCE_Acounting.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("aCE_Acounting.ImageOptions.SvgImage")));
            this.aCE_Acounting.Name = "aCE_Acounting";
            this.aCE_Acounting.Text = "Element3";
            // 
            // aCE_HumanResource
            // 
            this.aCE_HumanResource.Expanded = true;
            this.aCE_HumanResource.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("aCE_HumanResource.ImageOptions.SvgImage")));
            this.aCE_HumanResource.Name = "aCE_HumanResource";
            this.aCE_HumanResource.Text = "Element5";
            // 
            // aCE_Reports
            // 
            this.aCE_Reports.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aCE_Report,
            this.accordionControlElement2,
            this.accordionControlElement1});
            this.aCE_Reports.Expanded = true;
            this.aCE_Reports.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("aCE_Reports.ImageOptions.SvgImage")));
            this.aCE_Reports.Name = "aCE_Reports";
            this.aCE_Reports.Text = "Element2";
            // 
            // aCE_Report
            // 
            this.aCE_Report.Expanded = true;
            this.aCE_Report.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aCE_Report.ImageOptions.Image")));
            this.aCE_Report.Name = "aCE_Report";
            this.aCE_Report.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aCE_Report.Text = "Report";
            this.aCE_Report.Click += new System.EventHandler(this.aCE_Report_Click);
            // 
            // accordionControlElement2
            // 
            this.accordionControlElement2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("accordionControlElement2.ImageOptions.SvgImage")));
            this.accordionControlElement2.Name = "accordionControlElement2";
            this.accordionControlElement2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement2.Text = "Element2";
            this.accordionControlElement2.Click += new System.EventHandler(this.accordionControlElement2_Click);
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement1.Text = "Element1";
            // 
            // aCE_Setting
            // 
            this.aCE_Setting.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aCE_CurrAccs});
            this.aCE_Setting.Expanded = true;
            this.aCE_Setting.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("aCE_Setting.ImageOptions.SvgImage")));
            this.aCE_Setting.Name = "aCE_Setting";
            this.aCE_Setting.Text = "Element4";
            // 
            // aCE_CurrAccs
            // 
            this.aCE_CurrAccs.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("aCE_CurrAccs.ImageOptions.SvgImage")));
            this.aCE_CurrAccs.Name = "aCE_CurrAccs";
            this.aCE_CurrAccs.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aCE_CurrAccs.Text = "İstifadəçilər";
            this.aCE_CurrAccs.Click += new System.EventHandler(this.aCE_CurrAccs_Click);
            // 
            // aCE_Payments
            // 
            this.aCE_Payments.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("accordionControlElement3.ImageOptions.SvgImage")));
            this.aCE_Payments.Name = "aCE_Payments";
            this.aCE_Payments.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aCE_Payments.Text = "Ödənişlər";
            this.aCE_Payments.Click += new System.EventHandler(this.aCE_Payments_Click);
            // 
            // FormERP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 632);
            this.Controls.Add(this.aC_Root);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbonControl);
            this.IsMdiContainer = true;
            this.Name = "FormERP";
            this.Ribbon = this.ribbonControl;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "ERP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MdiChildActivate += new System.EventHandler(this.FormERP_MdiChildActivate);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aC_Root)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage_Home;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGr_Control;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Navigation.AccordionControl aC_Root;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_Invoices;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_RetailPurchaseInvoice;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem;
        private DevExpress.XtraBars.SkinPaletteDropDownButtonItem skinPaletteDropDownButtonItem;
        private DevExpress.XtraBars.BarMdiChildrenListItem bBI_MdiChildrenList;
        private DevExpress.XtraBars.BarButtonItem bBI_CloseWindows;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_shipment;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_ApproveInvoice;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_Acounting;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_HumanResource;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_Reports;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_Setting;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_Report;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_CurrAccs;
        private DevExpress.XtraBars.BarButtonItem bBI_POS;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_RetailSaleInvoice;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_Expense;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_MakePayment;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_receivePayment;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_Payments;
    }
}