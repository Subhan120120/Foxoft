
using DevExpress.XtraBars;
using DevExpress.XtraReports.Serialization;
using DevExpress.XtraScheduler;
using Foxoft.Properties;

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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormERP));
            parentRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            skinRibbonGalleryBarItem = new SkinRibbonGalleryBarItem();
            skinPaletteDropDownButtonItem = new SkinPaletteDropDownButtonItem();
            bBI_MdiChildrenList = new BarMdiChildrenListItem();
            bBI_CloseWindows = new BarButtonItem();
            bBI_POS = new BarButtonItem();
            bSI_UserName = new BarStaticItem();
            BSI_StoreDesc = new BarStaticItem();
            BBI_ChangeUser = new BarButtonItem();
            barSubItem1 = new BarSubItem();
            BBI_ModeMouse = new BarButtonItem();
            BBI_ModeTouch = new BarButtonItem();
            bSI_TerminalName = new BarStaticItem();
            BSI_CompanyDesc = new BarStaticItem();
            bBI_Session = new BarButtonItem();
            BSI_Report = new BarSubItem();
            BBI_FavoriteAdd = new BarButtonItem();
            BBI_FavoriteRemove = new BarButtonItem();
            BEI_Language = new BarEditItem();
            repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ribbonPage_Home = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGr_Control = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            popupMenuAccordian = new PopupMenu(components);
            aC_Root = new DevExpress.XtraBars.Navigation.AccordionControl();
            ACG_Favorites = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aCE_Invoices = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aCE_Products = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aCE_CurrAccs = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ACE_CashRegs = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlSeparator3 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            aCE_RetailPurchaseInvoice = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aCE_RetailSaleInvoice = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aCE_WholesaleInvoice = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aCE_InstallmentSaleInvoice = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlSeparator6 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            ACE_RetailPurchaseReturn = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ACE_RetailSaleReturn = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aCE_WholesaleReturn = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ACE_InstallmentSaleReturn = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlSeparator10 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            ACE_RetailPurchaseReturnCustom = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ACE_RetailsaleReturnCustom = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ACE_WholesaleReturnCustom = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ACE_InstallmentSaleReturnCustom = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ACE_InventoryTransferReturnCustom = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlSeparator5 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            aCE_InventoryTransfer = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ACE_CashTransfer = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlSeparator7 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            aCE_Expense = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aCE_PaymentDetail = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlSeparator1 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            ACE_InstallmentSales = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ACE_Group_InventoryCount = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aCE_Count = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aCE_CountIn = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aCE_CountOut = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlSeparator9 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            ACE_RetailPurchaseOrder = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ACE_RetailSaleOrder = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlSeparator4 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            ACE_Waybill = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ACE_WaybillIn = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ACE_WaybillOut = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlSeparator11 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            ACE_BarcodeOperations = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aCE_Operation = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ACE_PriceList = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aCE_ProductsDisabled = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aCE_CurrAccsDisabled = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlSeparator8 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            ACE_ProductDiscounts = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ACE_ProductFeatureType = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ACE_CurrAccFeatureType = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ACE_PayrollList = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ACE_LoyaltyCards = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aCE_Reports = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aCE_Setting = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aCE_CurrAccRole = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ACE_StoreList = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ACE_WarehouseList = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ACE_TerminalList = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlSeparator2 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            ACE_AppSettings = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)parentRibbonControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemLookUpEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemImageComboBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemComboBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)popupMenuAccordian).BeginInit();
            ((System.ComponentModel.ISupportInitialize)aC_Root).BeginInit();
            SuspendLayout();
            // 
            // parentRibbonControl
            // 
            parentRibbonControl.ExpandCollapseItem.Id = 0;
            parentRibbonControl.Items.AddRange(new BarItem[] { parentRibbonControl.ExpandCollapseItem, skinRibbonGalleryBarItem, skinPaletteDropDownButtonItem, bBI_MdiChildrenList, bBI_CloseWindows, bBI_POS, bSI_UserName, BSI_StoreDesc, BBI_ChangeUser, barSubItem1, BBI_ModeMouse, BBI_ModeTouch, bSI_TerminalName, BSI_CompanyDesc, bBI_Session, BSI_Report, BBI_FavoriteAdd, BBI_FavoriteRemove, BEI_Language });
            parentRibbonControl.Location = new Point(0, 0);
            parentRibbonControl.MaxItemId = 47;
            parentRibbonControl.Name = "parentRibbonControl";
            parentRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage_Home });
            parentRibbonControl.QuickToolbarItemLinks.Add(skinRibbonGalleryBarItem);
            parentRibbonControl.QuickToolbarItemLinks.Add(skinPaletteDropDownButtonItem);
            parentRibbonControl.QuickToolbarItemLinks.Add(bBI_POS);
            parentRibbonControl.QuickToolbarItemLinks.Add(barSubItem1);
            parentRibbonControl.QuickToolbarItemLinks.Add(BEI_Language);
            parentRibbonControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemImageComboBox1, repositoryItemComboBox1, repositoryItemLookUpEdit1 });
            parentRibbonControl.Size = new Size(1023, 158);
            parentRibbonControl.StatusBar = ribbonStatusBar;
            // 
            // skinRibbonGalleryBarItem
            // 
            skinRibbonGalleryBarItem.Caption = Resources.Common_Theme;
            skinRibbonGalleryBarItem.Id = 1;
            skinRibbonGalleryBarItem.Name = "skinRibbonGalleryBarItem";
            // 
            // skinPaletteDropDownButtonItem
            // 
            skinPaletteDropDownButtonItem.ActAsDropDown = true;
            skinPaletteDropDownButtonItem.ButtonStyle = BarButtonStyle.DropDown;
            skinPaletteDropDownButtonItem.Id = 3;
            skinPaletteDropDownButtonItem.Name = "skinPaletteDropDownButtonItem";
            // 
            // bBI_MdiChildrenList
            // 
            bBI_MdiChildrenList.Caption = Resources.ERP_BBI_ActiveWindows;
            bBI_MdiChildrenList.Id = 4;
            bBI_MdiChildrenList.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_MdiChildrenList.ImageOptions.SvgImage");
            bBI_MdiChildrenList.Name = "bBI_MdiChildrenList";
            // 
            // bBI_CloseWindows
            // 
            bBI_CloseWindows.Caption = Resources.ERP_BBI_CloseWindows;
            bBI_CloseWindows.Id = 9;
            bBI_CloseWindows.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_CloseWindows.ImageOptions.SvgImage");
            bBI_CloseWindows.Name = "bBI_CloseWindows";
            bBI_CloseWindows.ItemClick += bBI_CloseWindows_ItemClick;
            // 
            // bBI_POS
            // 
            bBI_POS.Caption = Resources.Login_POS;
            bBI_POS.Id = 12;
            bBI_POS.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_POS.ImageOptions.SvgImage");
            bBI_POS.Name = "bBI_POS";
            bBI_POS.ItemClick += bBI_POS_ItemClick;
            // 
            // bSI_UserName
            // 
            bSI_UserName.Alignment = BarItemLinkAlignment.Right;
            bSI_UserName.Caption = "| User Name";
            bSI_UserName.Id = 13;
            bSI_UserName.Name = "bSI_UserName";
            // 
            // BSI_StoreDesc
            // 
            BSI_StoreDesc.Alignment = BarItemLinkAlignment.Right;
            BSI_StoreDesc.Caption = "| Store Description";
            BSI_StoreDesc.Id = 18;
            BSI_StoreDesc.Name = "BSI_StoreDesc";
            // 
            // BBI_ChangeUser
            // 
            BBI_ChangeUser.Caption = Resources.ERP_BBI_ChangeUser;
            BBI_ChangeUser.Id = 19;
            BBI_ChangeUser.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ChangeUser.ImageOptions.SvgImage");
            BBI_ChangeUser.Name = "BBI_ChangeUser";
            // 
            // barSubItem1
            // 
            barSubItem1.Caption = Resources.Common_InputMode;
            barSubItem1.Id = 23;
            barSubItem1.ImageOptions.Image = (Image)resources.GetObject("barSubItem1.ImageOptions.Image");
            barSubItem1.ImageOptions.LargeImage = (Image)resources.GetObject("barSubItem1.ImageOptions.LargeImage");
            barSubItem1.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(BarLinkUserDefines.PaintStyle, BBI_ModeMouse, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, BBI_ModeTouch, BarItemPaintStyle.CaptionGlyph) });
            barSubItem1.MenuDrawMode = MenuDrawMode.LargeImagesText;
            barSubItem1.Name = "barSubItem1";
            // 
            // BBI_ModeMouse
            // 
            BBI_ModeMouse.Caption = Resources.Common_MouseMode;
            BBI_ModeMouse.Id = 24;
            BBI_ModeMouse.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ModeMouse.ImageOptions.SvgImage");
            BBI_ModeMouse.Name = "BBI_ModeMouse";
            BBI_ModeMouse.ItemClick += BBI_ModeMouse_ItemClick;
            // 
            // BBI_ModeTouch
            // 
            BBI_ModeTouch.Caption = Resources.Common_SensorMode;
            BBI_ModeTouch.Id = 25;
            BBI_ModeTouch.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_ModeTouch.ImageOptions.SvgImage");
            BBI_ModeTouch.Name = "BBI_ModeTouch";
            BBI_ModeTouch.ItemClick += BBI_ModeTouch_ItemClick;
            // 
            // bSI_TerminalName
            // 
            bSI_TerminalName.Alignment = BarItemLinkAlignment.Right;
            bSI_TerminalName.Caption = " | Terminal Name";
            bSI_TerminalName.Id = 28;
            bSI_TerminalName.Name = "bSI_TerminalName";
            // 
            // BSI_CompanyDesc
            // 
            BSI_CompanyDesc.Alignment = BarItemLinkAlignment.Right;
            BSI_CompanyDesc.Caption = "| Company Description";
            BSI_CompanyDesc.Id = 29;
            BSI_CompanyDesc.Name = "BSI_CompanyDesc";
            // 
            // bBI_Session
            // 
            bBI_Session.Caption = Resources.ERP_BBI_ActiveUsers;
            bBI_Session.Id = 30;
            bBI_Session.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bBI_Session.ImageOptions.SvgImage");
            bBI_Session.Name = "bBI_Session";
            bBI_Session.ItemClick += bBI_Session_ItemClick;
            // 
            // BSI_Report
            // 
            BSI_Report.Caption = Resources.ERP_ACE_Reports;
            BSI_Report.Id = 34;
            BSI_Report.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BSI_Report.ImageOptions.SvgImage");
            BSI_Report.Name = "BSI_Report";
            // 
            // BBI_FavoriteAdd
            // 
            BBI_FavoriteAdd.Caption = Resources.ERP_AddToFavorites;
            BBI_FavoriteAdd.Id = 38;
            BBI_FavoriteAdd.Name = "BBI_FavoriteAdd";
            BBI_FavoriteAdd.ItemClick += BBI_FavoriteAdd_ItemClick;
            // 
            // BBI_FavoriteRemove
            // 
            BBI_FavoriteRemove.Caption = Resources.ERP_RemoveFromFavorites;
            BBI_FavoriteRemove.Id = 39;
            BBI_FavoriteRemove.Name = "BBI_FavoriteRemove";
            BBI_FavoriteRemove.ItemClick += BBI_FavoriteRemove_ItemClick;
            // 
            // BEI_Language
            // 
            BEI_Language.Edit = repositoryItemLookUpEdit1;
            BEI_Language.Id = 46;
            BEI_Language.Name = "BEI_Language";
            BEI_Language.EditValueChanged += BEI_Language_EditValueChanged;
            // 
            // repositoryItemLookUpEdit1
            // 
            repositoryItemLookUpEdit1.AutoHeight = false;
            repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LanguageCode", Resources.Entity_UILanguage_Code), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LanguageDesc", Resources.Entity_UILanguage_Desc) });
            repositoryItemLookUpEdit1.DisplayMember = "LanguageCode";
            repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            repositoryItemLookUpEdit1.ValueMember = "LanguageCode";
            // 
            // ribbonPage_Home
            // 
            ribbonPage_Home.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGr_Control, ribbonPageGroup1 });
            ribbonPage_Home.MergeOrder = 0;
            ribbonPage_Home.Name = "ribbonPage_Home";
            ribbonPage_Home.Text = Resources.ERP_RibbonPage_Home;
            // 
            // ribbonPageGr_Control
            // 
            ribbonPageGr_Control.ItemLinks.Add(bBI_MdiChildrenList);
            ribbonPageGr_Control.ItemLinks.Add(bBI_CloseWindows);
            ribbonPageGr_Control.ItemLinks.Add(BSI_Report);
            ribbonPageGr_Control.Name = "ribbonPageGr_Control";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(BBI_ChangeUser, true);
            ribbonPageGroup1.ItemLinks.Add(bBI_Session);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = Resources.ERP_RibbonPage_Control;
            // 
            // repositoryItemImageComboBox1
            // 
            repositoryItemImageComboBox1.AutoHeight = false;
            repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // repositoryItemComboBox1
            // 
            repositoryItemComboBox1.AutoHeight = false;
            repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // ribbonStatusBar
            // 
            ribbonStatusBar.ItemLinks.Add(BSI_CompanyDesc);
            ribbonStatusBar.ItemLinks.Add(BSI_StoreDesc);
            ribbonStatusBar.ItemLinks.Add(bSI_UserName);
            ribbonStatusBar.ItemLinks.Add(bSI_TerminalName);
            ribbonStatusBar.Location = new Point(0, 591);
            ribbonStatusBar.Name = "ribbonStatusBar";
            ribbonStatusBar.Ribbon = parentRibbonControl;
            ribbonStatusBar.Size = new Size(1023, 24);
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("properties", "image://svgimages/setup/properties.svg");
            svgImageCollection1.Add("report", "image://svgimages/business objects/bo_report.svg");
            // 
            // popupMenuAccordian
            // 
            popupMenuAccordian.ItemLinks.Add(BBI_FavoriteAdd);
            popupMenuAccordian.ItemLinks.Add(BBI_FavoriteRemove);
            popupMenuAccordian.Name = "popupMenuAccordian";
            popupMenuAccordian.Ribbon = parentRibbonControl;
            popupMenuAccordian.Popup += popupMenuAccordian_Popup;
            // 
            // aC_Root
            // 
            aC_Root.Dock = DockStyle.Left;
            aC_Root.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { ACG_Favorites, aCE_Invoices, ACE_Group_InventoryCount, aCE_Operation, aCE_Reports, aCE_Setting });
            aC_Root.Location = new Point(0, 158);
            aC_Root.Name = "aC_Root";
            aC_Root.OptionsMinimizing.AllowMinimizeMode = DevExpress.Utils.DefaultBoolean.True;
            aC_Root.ResizeMode = DevExpress.XtraBars.Navigation.AccordionControlResizeMode.InnerResizeZone;
            aC_Root.RootDisplayMode = DevExpress.XtraBars.Navigation.AccordionControlRootDisplayMode.Footer;
            aC_Root.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            aC_Root.ShowFilterControl = DevExpress.XtraBars.Navigation.ShowFilterControl.Always;
            aC_Root.Size = new Size(314, 433);
            aC_Root.TabIndex = 2;
            aC_Root.MouseDown += aC_Root_MouseDown;
            // 
            // ACG_Favorites
            // 
            ACG_Favorites.Expanded = true;
            ACG_Favorites.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACG_Favorites.ImageOptions.SvgImage");
            ACG_Favorites.Name = "ACG_Favorites";
            ACG_Favorites.Text = Resources.ERP_ACE_Favorites;
            ACG_Favorites.Visible = false;
            // 
            // aCE_Invoices
            // 
            aCE_Invoices.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { aCE_Products, aCE_CurrAccs, ACE_CashRegs, accordionControlSeparator3, aCE_RetailPurchaseInvoice, aCE_RetailSaleInvoice, aCE_WholesaleInvoice, aCE_InstallmentSaleInvoice, accordionControlSeparator6, ACE_RetailPurchaseReturn, ACE_RetailSaleReturn, aCE_WholesaleReturn, ACE_InstallmentSaleReturn, accordionControlSeparator10, ACE_RetailPurchaseReturnCustom, ACE_RetailsaleReturnCustom, ACE_WholesaleReturnCustom, ACE_InstallmentSaleReturnCustom, ACE_InventoryTransferReturnCustom, accordionControlSeparator5, aCE_InventoryTransfer, ACE_CashTransfer, accordionControlSeparator7, aCE_Expense, aCE_PaymentDetail, accordionControlSeparator1, ACE_InstallmentSales });
            aCE_Invoices.Expanded = true;
            aCE_Invoices.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("aCE_Invoices.ImageOptions.SvgImage");
            aCE_Invoices.Name = "aCE_Invoices";
            aCE_Invoices.Text = Resources.ERP_ACE_Invoices;
            // 
            // aCE_Products
            // 
            aCE_Products.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("aCE_Products.ImageOptions.SvgImage");
            aCE_Products.Name = "aCE_Products";
            aCE_Products.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aCE_Products.Text = Resources.ERP_ACE_Products;
            // 
            // aCE_CurrAccs
            // 
            aCE_CurrAccs.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("aCE_CurrAccs.ImageOptions.SvgImage");
            aCE_CurrAccs.Name = "aCE_CurrAccs";
            aCE_CurrAccs.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aCE_CurrAccs.Text = Resources.ERP_ACE_CurrAccs;
            // 
            // ACE_CashRegs
            // 
            ACE_CashRegs.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_CashRegs.ImageOptions.SvgImage");
            ACE_CashRegs.Name = "ACE_CashRegs";
            ACE_CashRegs.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_CashRegs.Text = Resources.ERP_CashRegs;
            // 
            // accordionControlSeparator3
            // 
            accordionControlSeparator3.Name = "accordionControlSeparator3";
            // 
            // aCE_RetailPurchaseInvoice
            // 
            aCE_RetailPurchaseInvoice.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("aCE_RetailPurchaseInvoice.ImageOptions.SvgImage");
            aCE_RetailPurchaseInvoice.Name = "aCE_RetailPurchaseInvoice";
            aCE_RetailPurchaseInvoice.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aCE_RetailPurchaseInvoice.Text = Resources.ERP_ACE_RetailPurchaseInvoice;
            // 
            // aCE_RetailSaleInvoice
            // 
            aCE_RetailSaleInvoice.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("aCE_RetailSaleInvoice.ImageOptions.SvgImage");
            aCE_RetailSaleInvoice.Name = "aCE_RetailSaleInvoice";
            aCE_RetailSaleInvoice.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aCE_RetailSaleInvoice.Text = Resources.ERP_ACE_RetailSaleInvoice;
            // 
            // aCE_WholesaleInvoice
            // 
            aCE_WholesaleInvoice.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("aCE_WholesaleInvoice.ImageOptions.SvgImage");
            aCE_WholesaleInvoice.Name = "aCE_WholesaleInvoice";
            aCE_WholesaleInvoice.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aCE_WholesaleInvoice.Text = Resources.ERP_ACE_WholeSaleInvoice;
            // 
            // aCE_InstallmentSaleInvoice
            // 
            aCE_InstallmentSaleInvoice.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("aCE_InstallmentSaleInvoice.ImageOptions.SvgImage");
            aCE_InstallmentSaleInvoice.Name = "aCE_InstallmentSaleInvoice";
            aCE_InstallmentSaleInvoice.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aCE_InstallmentSaleInvoice.Text = Resources.ERP_ACE_InstallmentsaleInvoice;
            // 
            // accordionControlSeparator6
            // 
            accordionControlSeparator6.Name = "accordionControlSeparator6";
            // 
            // ACE_RetailPurchaseReturn
            // 
            ACE_RetailPurchaseReturn.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_RetailPurchaseReturn.ImageOptions.SvgImage");
            ACE_RetailPurchaseReturn.Name = "ACE_RetailPurchaseReturn";
            ACE_RetailPurchaseReturn.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_RetailPurchaseReturn.Text = Resources.ERP_ACE_RetailPurchaseReturn;
            // 
            // ACE_RetailSaleReturn
            // 
            ACE_RetailSaleReturn.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_RetailSaleReturn.ImageOptions.SvgImage");
            ACE_RetailSaleReturn.Name = "ACE_RetailSaleReturn";
            ACE_RetailSaleReturn.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_RetailSaleReturn.Text = Resources.ERP_ACE_RetailSaleReturn;
            // 
            // aCE_WholesaleReturn
            // 
            aCE_WholesaleReturn.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("aCE_WholesaleReturn.ImageOptions.SvgImage");
            aCE_WholesaleReturn.Name = "aCE_WholesaleReturn";
            aCE_WholesaleReturn.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aCE_WholesaleReturn.Text = Resources.ERP_ACE_WholeSaleReturn;
            // 
            // ACE_InstallmentSaleReturn
            // 
            ACE_InstallmentSaleReturn.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_InstallmentSaleReturn.ImageOptions.SvgImage");
            ACE_InstallmentSaleReturn.Name = "ACE_InstallmentSaleReturn";
            ACE_InstallmentSaleReturn.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_InstallmentSaleReturn.Text = Resources.ERP_ACE_InstallmentsaleReturn;
            // 
            // accordionControlSeparator10
            // 
            accordionControlSeparator10.Name = "accordionControlSeparator10";
            // 
            // ACE_RetailPurchaseReturnCustom
            // 
            ACE_RetailPurchaseReturnCustom.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_RetailPurchaseReturnCustom.ImageOptions.SvgImage");
            ACE_RetailPurchaseReturnCustom.Name = "ACE_RetailPurchaseReturnCustom";
            ACE_RetailPurchaseReturnCustom.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_RetailPurchaseReturnCustom.Text = Resources.ERP_ACE_RetailPurchaseReturnCustom;
            // 
            // ACE_RetailsaleReturnCustom
            // 
            ACE_RetailsaleReturnCustom.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_RetailsaleReturnCustom.ImageOptions.SvgImage");
            ACE_RetailsaleReturnCustom.Name = "ACE_RetailsaleReturnCustom";
            ACE_RetailsaleReturnCustom.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_RetailsaleReturnCustom.Text = Resources.ERP_ACE_RetailSaleReturnCustom;
            // 
            // ACE_WholesaleReturnCustom
            // 
            ACE_WholesaleReturnCustom.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_WholesaleReturnCustom.ImageOptions.SvgImage");
            ACE_WholesaleReturnCustom.Name = "ACE_WholesaleReturnCustom";
            ACE_WholesaleReturnCustom.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_WholesaleReturnCustom.Text = Resources.ERP_ACE_WholeSaleReturnCustom;
            // 
            // ACE_InstallmentSaleReturnCustom
            // 
            ACE_InstallmentSaleReturnCustom.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_InstallmentSaleReturnCustom.ImageOptions.SvgImage");
            ACE_InstallmentSaleReturnCustom.Name = "ACE_InstallmentSaleReturnCustom";
            ACE_InstallmentSaleReturnCustom.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_InstallmentSaleReturnCustom.Text = Resources.ERP_ACE_InstallmentSaleReturnCustom;
            // 
            // ACE_InventoryTransferReturnCustom
            // 
            ACE_InventoryTransferReturnCustom.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_InventoryTransferReturnCustom.ImageOptions.SvgImage");
            ACE_InventoryTransferReturnCustom.Name = "ACE_InventoryTransferReturnCustom";
            ACE_InventoryTransferReturnCustom.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_InventoryTransferReturnCustom.Text = Resources.Form_ERP_ACE_InventoryTransferReturnCustom;
            // 
            // accordionControlSeparator5
            // 
            accordionControlSeparator5.Name = "accordionControlSeparator5";
            // 
            // aCE_InventoryTransfer
            // 
            aCE_InventoryTransfer.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("aCE_InventoryTransfer.ImageOptions.SvgImage");
            aCE_InventoryTransfer.Name = "aCE_InventoryTransfer";
            aCE_InventoryTransfer.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aCE_InventoryTransfer.Text = Resources.ERP_ACE_InventoryTransfers;
            // 
            // ACE_CashTransfer
            // 
            ACE_CashTransfer.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_CashTransfer.ImageOptions.SvgImage");
            ACE_CashTransfer.Name = "ACE_CashTransfer";
            ACE_CashTransfer.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_CashTransfer.Text = Resources.ERP_ACE_CashTransfers;
            // 
            // accordionControlSeparator7
            // 
            accordionControlSeparator7.Name = "accordionControlSeparator7";
            // 
            // aCE_Expense
            // 
            aCE_Expense.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("aCE_Expense.ImageOptions.SvgImage");
            aCE_Expense.Name = "aCE_Expense";
            aCE_Expense.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aCE_Expense.Text = Resources.ERP_ACE_Expenses;
            // 
            // aCE_PaymentDetail
            // 
            aCE_PaymentDetail.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("aCE_PaymentDetail.ImageOptions.SvgImage");
            aCE_PaymentDetail.Name = "aCE_PaymentDetail";
            aCE_PaymentDetail.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aCE_PaymentDetail.Text = Resources.ERP_ACE_PaymentDetail;
            // 
            // accordionControlSeparator1
            // 
            accordionControlSeparator1.Name = "accordionControlSeparator1";
            // 
            // ACE_InstallmentSales
            // 
            ACE_InstallmentSales.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_InstallmentSales.ImageOptions.SvgImage");
            ACE_InstallmentSales.Name = "ACE_InstallmentSales";
            ACE_InstallmentSales.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_InstallmentSales.Text = Resources.ERP_ACE_InstallmentSales;
            // 
            // ACE_Group_InventoryCount
            // 
            ACE_Group_InventoryCount.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { aCE_Count, aCE_CountIn, aCE_CountOut, accordionControlSeparator9, ACE_RetailPurchaseOrder, ACE_RetailSaleOrder, accordionControlSeparator4, ACE_Waybill, ACE_WaybillIn, ACE_WaybillOut, accordionControlSeparator11, ACE_BarcodeOperations });
            ACE_Group_InventoryCount.Expanded = true;
            ACE_Group_InventoryCount.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_Group_InventoryCount.ImageOptions.SvgImage");
            ACE_Group_InventoryCount.Name = "ACE_Group_InventoryCount";
            ACE_Group_InventoryCount.Text = Resources.ERP_ACE_InventoryCount;
            // 
            // aCE_Count
            // 
            aCE_Count.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("aCE_Count.ImageOptions.SvgImage");
            aCE_Count.Name = "aCE_Count";
            aCE_Count.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aCE_Count.Text = Resources.Form_ERP_ACE_InvertoryCount;
            // 
            // aCE_CountIn
            // 
            aCE_CountIn.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("aCE_CountIn.ImageOptions.SvgImage");
            aCE_CountIn.Name = "aCE_CountIn";
            aCE_CountIn.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aCE_CountIn.Text = Resources.ERP_ACE_CountInInvoice;
            // 
            // aCE_CountOut
            // 
            aCE_CountOut.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("aCE_CountOut.ImageOptions.SvgImage");
            aCE_CountOut.Name = "aCE_CountOut";
            aCE_CountOut.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aCE_CountOut.Text = Resources.ERP_ACE_CountOutInvoice;
            // 
            // accordionControlSeparator9
            // 
            accordionControlSeparator9.Name = "accordionControlSeparator9";
            // 
            // ACE_RetailPurchaseOrder
            // 
            ACE_RetailPurchaseOrder.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_RetailPurchaseOrder.ImageOptions.SvgImage");
            ACE_RetailPurchaseOrder.Name = "ACE_RetailPurchaseOrder";
            ACE_RetailPurchaseOrder.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_RetailPurchaseOrder.Text = Resources.ERP_ACE_RetailPurchaseOrder;
            // 
            // ACE_RetailSaleOrder
            // 
            ACE_RetailSaleOrder.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_RetailSaleOrder.ImageOptions.SvgImage");
            ACE_RetailSaleOrder.Name = "ACE_RetailSaleOrder";
            ACE_RetailSaleOrder.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_RetailSaleOrder.Text = Resources.ERP_ACE_RetailSaleOrder;
            // 
            // accordionControlSeparator4
            // 
            accordionControlSeparator4.Name = "accordionControlSeparator4";
            // 
            // ACE_Waybill
            // 
            ACE_Waybill.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_Waybill.ImageOptions.SvgImage");
            ACE_Waybill.Name = "ACE_Waybill";
            ACE_Waybill.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_Waybill.Text = Resources.ERP_ACE_Waybill;
            // 
            // ACE_WaybillIn
            // 
            ACE_WaybillIn.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_WaybillIn.ImageOptions.SvgImage");
            ACE_WaybillIn.Name = "ACE_WaybillIn";
            ACE_WaybillIn.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_WaybillIn.Text = Resources.ERP_ACE_WaybillIn;
            // 
            // ACE_WaybillOut
            // 
            ACE_WaybillOut.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_WaybillOut.ImageOptions.SvgImage");
            ACE_WaybillOut.Name = "ACE_WaybillOut";
            ACE_WaybillOut.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_WaybillOut.Text = Resources.ERP_ACE_WaybillOut;
            // 
            // accordionControlSeparator11
            // 
            accordionControlSeparator11.Name = "accordionControlSeparator11";
            // 
            // ACE_BarcodeOperations
            // 
            ACE_BarcodeOperations.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_BarcodeOperations.ImageOptions.SvgImage");
            ACE_BarcodeOperations.Name = "ACE_BarcodeOperations";
            ACE_BarcodeOperations.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_BarcodeOperations.Text = "Barcode Operations";
            ACE_BarcodeOperations.Click += ACE_BarcodeOperations_Click;
            // 
            // aCE_Operation
            // 
            aCE_Operation.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { ACE_PriceList, aCE_ProductsDisabled, aCE_CurrAccsDisabled, accordionControlSeparator8, ACE_ProductDiscounts, ACE_ProductFeatureType, ACE_CurrAccFeatureType, ACE_PayrollList, ACE_LoyaltyCards });
            aCE_Operation.Expanded = true;
            aCE_Operation.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("aCE_Operation.ImageOptions.SvgImage");
            aCE_Operation.Name = "aCE_Operation";
            aCE_Operation.Text = Resources.ERP_ACE_Operations;
            // 
            // ACE_PriceList
            // 
            ACE_PriceList.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_PriceList.ImageOptions.SvgImage");
            ACE_PriceList.Name = "ACE_PriceList";
            ACE_PriceList.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_PriceList.Text = Resources.ERP_ACE_PriceList;
            // 
            // aCE_ProductsDisabled
            // 
            aCE_ProductsDisabled.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("aCE_ProductsDisabled.ImageOptions.SvgImage");
            aCE_ProductsDisabled.Name = "aCE_ProductsDisabled";
            aCE_ProductsDisabled.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aCE_ProductsDisabled.Text = Resources.ERP_ACE_ProductsDisabled;
            // 
            // aCE_CurrAccsDisabled
            // 
            aCE_CurrAccsDisabled.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("aCE_CurrAccsDisabled.ImageOptions.SvgImage");
            aCE_CurrAccsDisabled.Name = "aCE_CurrAccsDisabled";
            aCE_CurrAccsDisabled.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aCE_CurrAccsDisabled.Text = Resources.ERP_ACE_CurrAccsDisabled;
            // 
            // accordionControlSeparator8
            // 
            accordionControlSeparator8.Name = "accordionControlSeparator8";
            // 
            // ACE_ProductDiscounts
            // 
            ACE_ProductDiscounts.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_ProductDiscounts.ImageOptions.SvgImage");
            ACE_ProductDiscounts.Name = "ACE_ProductDiscounts";
            ACE_ProductDiscounts.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_ProductDiscounts.Text = Resources.ERP_ACE_ProductDiscounts;
            // 
            // ACE_ProductFeatureType
            // 
            ACE_ProductFeatureType.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_ProductFeatureType.ImageOptions.SvgImage");
            ACE_ProductFeatureType.Name = "ACE_ProductFeatureType";
            ACE_ProductFeatureType.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_ProductFeatureType.Text = Resources.ERP_ACE_ProductFeatureType;
            // 
            // ACE_CurrAccFeatureType
            // 
            ACE_CurrAccFeatureType.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_CurrAccFeatureType.ImageOptions.SvgImage");
            ACE_CurrAccFeatureType.Name = "ACE_CurrAccFeatureType";
            ACE_CurrAccFeatureType.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_CurrAccFeatureType.Text = Resources.ERP_ACE_CurrAccFeatureType;
            // 
            // ACE_PayrollList
            // 
            ACE_PayrollList.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_PayrollList.ImageOptions.SvgImage");
            ACE_PayrollList.Name = "ACE_PayrollList";
            ACE_PayrollList.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_PayrollList.Text = "PayrollList";
            // 
            // ACE_LoyaltyCards
            // 
            ACE_LoyaltyCards.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_LoyaltyCards.ImageOptions.SvgImage");
            ACE_LoyaltyCards.Name = "ACE_LoyaltyCards";
            ACE_LoyaltyCards.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_LoyaltyCards.Text = "Bonus Kartlar";
            // 
            // aCE_Reports
            // 
            aCE_Reports.Expanded = true;
            aCE_Reports.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("aCE_Reports.ImageOptions.SvgImage");
            aCE_Reports.Name = "aCE_Reports";
            aCE_Reports.Text = Resources.ERP_ACE_Reports;
            // 
            // aCE_Setting
            // 
            aCE_Setting.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { aCE_CurrAccRole, ACE_StoreList, ACE_WarehouseList, ACE_TerminalList, accordionControlSeparator2, ACE_AppSettings });
            aCE_Setting.Expanded = true;
            aCE_Setting.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("aCE_Setting.ImageOptions.SvgImage");
            aCE_Setting.Name = "aCE_Setting";
            aCE_Setting.Text = Resources.ERP_ACE_Parameters;
            // 
            // aCE_CurrAccRole
            // 
            aCE_CurrAccRole.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("aCE_CurrAccRole.ImageOptions.SvgImage");
            aCE_CurrAccRole.Name = "aCE_CurrAccRole";
            aCE_CurrAccRole.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aCE_CurrAccRole.Text = Resources.ERP_ACE_Users;
            // 
            // ACE_StoreList
            // 
            ACE_StoreList.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_StoreList.ImageOptions.SvgImage");
            ACE_StoreList.Name = "ACE_StoreList";
            ACE_StoreList.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_StoreList.Text = Resources.ERP_ACE_StoreList;
            // 
            // ACE_WarehouseList
            // 
            ACE_WarehouseList.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_WarehouseList.ImageOptions.SvgImage");
            ACE_WarehouseList.Name = "ACE_WarehouseList";
            ACE_WarehouseList.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_WarehouseList.Text = Resources.Form_WarehouseList_Caption;
            // 
            // ACE_TerminalList
            // 
            ACE_TerminalList.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_TerminalList.ImageOptions.SvgImage");
            ACE_TerminalList.Name = "ACE_TerminalList";
            ACE_TerminalList.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_TerminalList.Text = "Element1";
            // 
            // accordionControlSeparator2
            // 
            accordionControlSeparator2.Name = "accordionControlSeparator2";
            // 
            // ACE_AppSettings
            // 
            ACE_AppSettings.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ACE_AppSettings.ImageOptions.SvgImage");
            ACE_AppSettings.Name = "ACE_AppSettings";
            ACE_AppSettings.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ACE_AppSettings.Text = Resources.ERP_ACE_AppSettings;
            // 
            // FormERP
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 615);
            Controls.Add(aC_Root);
            Controls.Add(ribbonStatusBar);
            Controls.Add(parentRibbonControl);
            IsMdiContainer = true;
            Name = "FormERP";
            Ribbon = parentRibbonControl;
            StatusBar = ribbonStatusBar;
            Text = "Foxoft";
            WindowState = FormWindowState.Maximized;
            FormClosing += FormERP_FormClosing;
            MdiChildActivate += FormERP_MdiChildActivate;
            ((System.ComponentModel.ISupportInitialize)parentRibbonControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemLookUpEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemImageComboBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemComboBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)popupMenuAccordian).EndInit();
            ((System.ComponentModel.ISupportInitialize)aC_Root).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DevExpress.XtraBars.Ribbon.RibbonControl parentRibbonControl;
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
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_CountOut;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_CountIn;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_Group_InventoryCount;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_HumanResource;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_Reports;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_Setting;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_CurrAccRole;
        private DevExpress.XtraBars.BarButtonItem bBI_POS;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_RetailSaleInvoice;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_Expense;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator1;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_Products;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_CurrAccs;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator3;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_PaymentDetail;
        private DevExpress.XtraBars.BarStaticItem bSI_UserName;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator5;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator4;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_InventoryTransfer;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_CashTransfer;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_RetailPurchaseReturn;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_RetailSaleReturn;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator6;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_RetailSalesOrder;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_CashRegs;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarStaticItem BSI_StoreDesc;
        private DevExpress.XtraBars.BarButtonItem BBI_ChangeUser;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_Operation;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_PriceList;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator8;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_ProductDiscounts;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem BBI_ModeMouse;
        private DevExpress.XtraBars.BarButtonItem BBI_ModeTouch;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraBars.BarStaticItem bSI_TerminalName;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_RetailPurchaseOrder;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_RetailSaleOrder;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_Waybill;
        private DevExpress.XtraBars.BarStaticItem BSI_CompanyDesc;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_WholesaleInvoice;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_WholesaleReturn;
        private DevExpress.XtraBars.BarButtonItem bBI_Session;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator9;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_WaybillIn;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_WaybillOut;
        private DevExpress.XtraBars.PopupMenu popupMenuAccordian;
        private DevExpress.XtraBars.BarSubItem BSI_Report;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_InstallmentSaleInvoice;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_InstallmentSaleReturn;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_InstallmentSales;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_RetailPurchaseReturnCustom;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator10;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_RetailsaleReturnCustom;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_WholesaleReturnCustom;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_InstallmentSaleReturnCustom;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_CurrAccFeatureType;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_ProductFeatureType;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_AppSettings;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_StoreList;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACG_Favorites;
        private DevExpress.XtraBars.BarButtonItem BBI_FavoriteAdd;
        private DevExpress.XtraBars.BarButtonItem BBI_FavoriteRemove;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_ProductsDisabled;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_CurrAccsDisabled;
        private BarEditItem BEI_Language;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_WarehouseList;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aCE_Count;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_InventoryTransferReturnCustom;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_BarcodeOperations;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator11;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_PayrollList;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_LoyaltyCards;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_TerminalList;
    }
}