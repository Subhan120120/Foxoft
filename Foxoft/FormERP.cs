using DevExpress.LookAndFeel;
using DevExpress.Mvvm.Native;
using DevExpress.Utils.Extensions;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using DevExpress.XtraReports;
using DevExpress.XtraReports.Serialization;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.IO;

namespace Foxoft
{
    public partial class FormERP : RibbonForm
    {
        //AdornerUIManager adornerUIManager1;
        //IList<AdornerElement> adorners1;

        EfMethods efMethods = new();
        ReportClass reportClass = new();
        AdoMethods adoMethods = new();

        private AccordionControlElement aCE_Active;
        private ContextMenuStrip _cms;

        public FormERP()
        {
            InitializeComponent();

            InitComponentName();

            string activeFilterStr = "[StoreCode] = \'" + Authorization.StoreCode + "\'";
            reportClass.AddReports(BSI_Report, "ERP", null, null, activeFilterStr);

            foreach (AccordionControlElement ACE_Groups in aC_Root.Elements)
                foreach (AccordionControlElement? ACE_Element in ACE_Groups.Elements)
                    HideClaimlesElements(ACE_Element);

            foreach (BarItem bbi in parentRibbonControl.Items)
                if (bbi is BarButtonItem barButtonItem)
                    if (new string[] { "Session" }.Contains(bbi.Name))
                    {
                        bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, bbi.Name);
                        if (!currAccHasClaims)
                            bbi.Visibility = BarItemVisibility.Never;
                    }

            DcTerminal dcTerminal = efMethods.SelectEntityById<DcTerminal>(Settings.Default.TerminalId);
            UIMode(dcTerminal.TouchUIMode);

            string path = Path.Combine(AppContext.BaseDirectory, $"backgroundImage-{Settings.Default.CompanyCode}.png");

            if (File.Exists(path))
            {
                this.BackgroundImageLayoutStore = ImageLayout.Stretch;
                Stream stream = File.OpenRead(path);
                this.BackgroundImage = Image.FromStream(stream);
            }

            UserLookAndFeel.Default.StyleChanged += new EventHandler(UserLookAndFeel_StyleChanged);
            LookAndFeelSettingsHelper.Load(Authorization.CurrAccCode);

            BSI_CompanyDesc.Caption = "| " + efMethods.SelectCompany(Settings.Default.CompanyCode).CompanyDesc;
            bSI_UserName.Caption = "| " + efMethods.SelectCurrAcc(Authorization.CurrAccCode).CurrAccDesc;
            BSI_StoreDesc.Caption = "| " + efMethods.SelectCurrAcc(Authorization.StoreCode).CurrAccDesc;
            bSI_TerminalName.Caption = "| " + efMethods.SelectEntityById<DcTerminal>(Settings.Default.TerminalId).TerminalDesc;

            InitializeReports();
            InitializeFavorites();
        }

        private void aC_Root_MouseDown(object sender, MouseEventArgs e)
        {
            var hit = aC_Root.CalcHitInfo(e.Location).ItemInfo;
            if (hit?.Element == null) return;                 // clicked empty space
            if (hit.Element.Style != ElementStyle.Item) return; // ignore group headers, etc.

            aCE_Active = hit.Element; // remember the element for later

            if (e.Button == MouseButtons.Left)
            {
                BBI_ItemClick(hit.Element);
            }
            else if (e.Button == MouseButtons.Right)
            {
                popupMenuAccordian.ShowPopup(Cursor.Position);
            }
        }

        private void BBI_Report_ItemClick(AccordionControlElement el)
        {

        }

        private void UIMode(bool toucUIMode)
        {
            int TerminalId = Settings.Default.TerminalId;
            DcTerminal dcTerminal = efMethods.SelectEntityById<DcTerminal>(TerminalId);
            if (dcTerminal is not null)
            {
                if (toucUIMode == true)
                {
                    efMethods.UpdateTerminalTouchUIMode(TerminalId, true);

                    WindowsFormsSettings.TouchUIMode = TouchUIMode.True;
                    WindowsFormsSettings.TouchScaleFactor = dcTerminal.TouchScaleFactor;
                    aC_Root.Padding = new Padding(10);
                    aC_Root.ItemHeight = 24 + (dcTerminal.TouchScaleFactor * 8);
                }
                else
                {
                    efMethods.UpdateTerminalTouchUIMode(TerminalId, false);
                    WindowsFormsSettings.TouchUIMode = TouchUIMode.False;
                    aC_Root.Padding = new Padding(0);
                    aC_Root.ItemHeight = 0;
                }
            }
        }

        private void HideClaimlesElements(AccordionControlElement? childElement)
        {
            bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, childElement.Name);
            if (!currAccHasClaims)
                childElement.Visible = false;
        }

        private void BBI_ItemClick(AccordionControlElement el)
        {
            if (el?.Name is not string name) return;

            switch (name)
            {
                case "Products": ShowExistForm<FormProductList>(new byte[] { 1 }, false); break;
                case "CurrAccs": ShowExistForm<FormCurrAccList>(new byte[] { 1, 2, 3 }); break;

                case "RetailPurchaseInvoice": ShowNewForm<FormInvoice>("RP", false, new byte[] { 1, 3 }, null); break;
                case "RetailSaleInvoice": ShowNewForm<FormInvoice>("RS", false, new byte[] { 1, 3 }, null); break;
                case "WholesaleInvoice": ShowNewForm<FormInvoice>("WS", false, new byte[] { 1, 3 }, null); break;
                case "InstallmentSaleInvoice": ShowNewForm<FormInvoice>("IS", false, new byte[] { 1, 3 }, null); break;
                case "Expense": ShowNewForm<FormInvoice>("EX", false, new byte[] { 2, 3 }, null); break;
                case "CountIn": ShowNewForm<FormInvoice>("CI", false, new byte[] { 1 }, null); break;
                case "CountOut": ShowNewForm<FormInvoice>("CO", false, new byte[] { 1 }, null); break;
                case "InventoryTransfer": ShowNewForm<FormInvoice>("IT", false, new byte[] { 1 }, null); break;

                case "PurchaseReturnCustom": ShowNewForm<FormInvoice>("RP", true, new byte[] { 1, 3 }, null); break;
                case "RetailsaleReturnCustom": ShowNewForm<FormInvoice>("RS", true, new byte[] { 1, 3 }, null); break;
                case "WholesaleReturnCustom": ShowNewForm<FormInvoice>("WS", true, new byte[] { 1, 3 }, null); break;
                case "InstallmentSaleReturnCustom": ShowNewForm<FormInvoice>("IS", true, new byte[] { 1, 3 }, null); break;

                case "RetailPurchaseReturn": ShowExistForm<FormReturn>("RP"); break;
                case "RetailSaleReturn": ShowExistForm<FormReturn>("RS"); break;
                case "WholesaleReturn": ShowExistForm<FormReturn>("WS"); break;
                case "InstallmentSaleReturn": ShowExistForm<FormReturn>("IS"); break;

                case "Waybill": ShowNewForm<FormWaybill>("WO"); break;
                case "WaybillIn": ShowNewForm<FormInvoice>("WI", false, new byte[] { 1 }, null); break;
                case "WaybillOut": ShowNewForm<FormInvoice>("WO", false, new byte[] { 1 }, null); break;

                case "PaymentDetail": ShowNewForm<FormPaymentDetail>(); break;
                case "CashTransfer": ShowNewForm<FormMoneyTransfer>(); break;
                case "CashRegs": ShowExistForm<FormCashRegisterList>(); break;
                case "InstallmentSales": ShowExistForm<FormInstallmentSale>(); break;
                case "PriceList": ShowNewForm<FormPriceListDetail>(); break;
                case "ProductDiscountList": ShowExistForm<FormCommonList<DcDiscount>>("", nameof(DcDiscount.DiscountId)); break;
                case "RetailSaleOrder": ShowNewForm<FormInvoice>("RSO", false, new byte[] { 1, 3 }, null); break;
                case "Session": ShowExistForm<FormCurrAccSession>(); break;
                case "ProductFeatureType": ShowExistForm<FormHierarchyFeatureType>(); break;
                case "CurrAccFeatureType": ShowExistForm<FormCommonList<DcCurrAccFeatureType>>("", nameof(DcCurrAccFeatureType.CurrAccFeatureTypeId)); break;
                case "CurrAccClaim": ShowExistForm<FormCurrAccProfile>(); break;
                case "Parameters": ShowExistForm<FormAppSetting>(); break;
                case "StoreList": ShowExistForm<FormStoreList>(); break;

                default: break;
            }

            if (el.Name.StartsWith("report_"))
            {
                string idPart = el.Name.Substring("report_".Length);

                if (int.TryParse(idPart, out int reportId))
                {
                    DcReport dcReport = efMethods.SelectEntityById<DcReport>(reportId);

                    bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, dcReport.ReportId.ToString());

                    if (!currAccHasClaims)
                    {
                        MessageBox.Show("Yetkiniz yoxdur! ");
                        return;
                    }

                    if (dcReport is not null)
                        ShowNewForm<FormReportFilter>(dcReport);
                }
            }

        }

        private void InitComponentName()
        {
            this.aCE_Invoices.Name = "Invoices";
            this.aCE_Products.Name = "Products";
            this.aCE_CurrAccs.Name = "CurrAccs";
            this.ACE_CashRegs.Name = "CashRegs";

            this.aCE_RetailPurchaseInvoice.Name = "RetailPurchaseInvoice";
            this.aCE_RetailSaleInvoice.Name = "RetailSaleInvoice";
            this.aCE_WholesaleInvoice.Name = "WholesaleInvoice";
            this.aCE_InstallmentSaleInvoice.Name = "InstallmentSaleInvoice";
            this.aCE_InventoryTransfer.Name = "InventoryTransfer";

            this.ACE_RetailPurchaseOrder.Name = "RetailPurchaseOrder";
            this.ACE_RetailSaleOrder.Name = "RetailSaleOrder";

            this.ACE_PurchaseReturn.Name = "RetailPurchaseReturn";
            this.ACE_RetailSaleReturn.Name = "RetailSaleReturn";
            this.aCE_WholesaleReturn.Name = "WholesaleReturn";
            this.ACE_InstallmentSaleReturn.Name = "InstallmentSaleReturn";

            this.ACE_PurchaseReturnCustom.Name = "PurchaseReturnCustom";
            this.ACE_RetailsaleReturnCustom.Name = "RetailsaleReturnCustom";
            this.ACE_WholesaleReturnCustom.Name = "WholesaleReturnCustom";
            this.ACE_InstallmentSaleReturnCustom.Name = "InstallmentSaleReturnCustom";

            this.ACE_Waybill.Name = "Waybill";
            this.ACE_WaybillIn.Name = "WaybillIn";
            this.ACE_WaybillOut.Name = "WaybillOut";

            this.aCE_CountIn.Name = "CountIn";
            this.aCE_CountOut.Name = "CountOut";

            this.ACE_CashTransfer.Name = "CashTransfer";
            this.aCE_Expense.Name = "Expense";
            this.aCE_PaymentDetail.Name = "PaymentDetail";
            this.aCE_Acounting.Name = "Acounting";
            this.aCE_Reports.Name = "Reports";
            this.aCE_Setting.Name = "Setting";
            this.ACE_Parameters.Name = "Parameters";
            this.ACE_PriceList.Name = "PriceList";
            this.ACE_ProductDiscounts.Name = "ProductDiscountList";
            this.ACE_ProductFeatureType.Name = "ProductFeatureType";
            this.ACE_CurrAccFeatureType.Name = "CurrAccFeatureType";
            this.aCE_CurrAccRole.Name = "CurrAccClaim";
            this.bBI_Session.Name = "Session";
            this.ACE_InstallmentSales.Name = "InstallmentSales";
            this.ACE_StoreList.Name = "StoreList";
        }

        private void InitializeReports()
        {
            List<DcReport> dcReports = efMethods.SelectReportsByType(new byte[] { 1, 2 });

            foreach (DcReport dcReport in dcReports)
            {
                AccordionControlElement aCE = new();

                aCE.ImageOptions.SvgImage = svgImageCollection1["report"];
                aCE.Name = "report_" + dcReport.ReportId.ToString();
                aCE.Style = ElementStyle.Item;
                aCE.Text = dcReport.ReportName;
                aCE.Tag = dcReport;

                aCE_Reports.Elements.Add(aCE);
            }
        }

        private void InitializeFavorites()
        {
            StringCollection aceList = Settings.Default.FavoritesMenus;

            if (aceList is null)
                return;

            foreach (string aCE in aceList)
            {
                AccordionControlElement element = aC_Root.Elements
                                    .SelectMany(x => x.Elements)
                                    .FirstOrDefault(x => x.Name == aCE);

                if (element != null)
                {
                    AccordionControlElement shortcut = new()
                    {
                        Name = element.Name,
                        Text = element.Text,
                        Style = ElementStyle.Item,
                        Tag = element  // orijinal elementin linki
                    };
                    shortcut.ImageOptions.SvgImage = element.ImageOptions.SvgImage;

                    ACG_Favorites.Visible = true;
                    ACG_Favorites.Elements.Add(shortcut);
                }
            }

        }

        private void UserLookAndFeel_StyleChanged(object sender, EventArgs e)
        {
            LookAndFeelSettingsHelper.Save(Authorization.CurrAccCode);
        }

        private void RibbonControl1_Merge(object sender, RibbonMergeEventArgs e)
        {
            //AdornerElement[] badges = ((FormInvoice)e.MergedChild.Parent).Badges;
            //adornerUIManager1.BeginUpdate();
            //foreach (AdornerElement badge in badges)
            //{
            //   AdornerElement clone = badge.Clone() as AdornerElement;
            //   if (badge.TargetElement is BarItem)
            //      clone.TargetElement = badge.TargetElement;
            //   if (badge.TargetElement is RibbonPage)
            //      clone.TargetElement = parentRibbonControl.MergedPages.GetPageByName((badge.TargetElement as RibbonPage).Name);
            //   adornerUIManager1.Elements.Add(clone);
            //   adorners1.Add(clone);
            //}
            //adornerUIManager1.EndUpdate();
        }

        private void RibbonControl1_UnMerge(object sender, RibbonMergeEventArgs e)
        {
            //adornerUIManager1.BeginUpdate();
            //foreach (AdornerElement badge in adorners1)
            //{
            //   adornerUIManager1.Elements.Remove(badge);
            //   badge.Dispose();
            //}
            //adorners1.Clear();
            //adornerUIManager1.EndUpdate();
        }

        private void bBI_POS_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormPOS formPOS = new();
            formPOS.Show();
        }

        private void bBI_CloseWindows_ItemClick(object sender, ItemClickEventArgs e)
        {
            CloseOpenChildForms();
        }

        private void CloseOpenChildForms()
        {
            ArrayList list = new(MdiChildren);
            foreach (Form f in list)
                f.Close();
        }

        private void FormERP_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Programdan Çıx", "Diqqət", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void BBI_ModeMouse_ItemClick(object sender, ItemClickEventArgs e)
        {
            UIMode(false);
        }

        private void BBI_ModeTouch_ItemClick(object sender, ItemClickEventArgs e)
        {
            UIMode(true);
        }

        private void FormERP_MdiChildActivate(object sender, EventArgs e)
        {
            //if (parentRibbonControl.MergedPages.Count > 0)
            //    parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0]; // islemir
        }

        private void BBI_FavoriteAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            AccordionControlElement newElement = new()
            {
                Name = aCE_Active.Name,
                Text = aCE_Active.Text,
                Style = ElementStyle.Item,
                Tag = aCE_Active,
            };

            newElement.ImageOptions.SvgImage = aCE_Active.ImageOptions.SvgImage;

            ACG_Favorites.Visible = true;
            ACG_Favorites.Elements.Add(newElement);

            Settings.Default.FavoritesMenus.Add(newElement.Name);
            Settings.Default.Save();
        }

        private void BBI_FavoriteRemove_ItemClick(object sender, ItemClickEventArgs e)
        {
            AccordionControlElement removeElement = ACG_Favorites.Elements.FirstOrDefault(x => x.Name == aCE_Active.Name);

            ACG_Favorites.Elements.Remove(removeElement);

            Settings.Default.FavoritesMenus.Remove(removeElement.Name);
            Settings.Default.Save();

            if (ACG_Favorites.Elements.Count == 0)
                ACG_Favorites.Visible = false;
        }

        private void popupMenuAccordian_Popup(object sender, EventArgs e)
        {
            bool isFavorite = Settings.Default.FavoritesMenus.Contains(aCE_Active.Name);
            BBI_FavoriteRemove.Enabled = isFavorite;
            BBI_FavoriteAdd.Enabled = !isFavorite;
        }

        private void ShowNewForm<T>(params object[] args) where T : Form
        {
            T form = null;

            try
            {
                var constructors = typeof(T).GetConstructors();
                var constructor = constructors.FirstOrDefault(c =>
                {
                    var parameters = c.GetParameters();
                    if (parameters.Length != args.Length)
                        return false;

                    for (int i = 0; i < parameters.Length; i++)
                    {
                        if (args[i] == null)
                        {
                            if (parameters[i].ParameterType.IsValueType && Nullable.GetUnderlyingType(parameters[i].ParameterType) == null)
                                return false;
                        }
                        else if (!parameters[i].ParameterType.IsInstanceOfType(args[i]))
                        {
                            return false;
                        }
                    }
                    return true;
                });

                if (constructor == null)
                    throw new ArgumentException($"No matching constructor found for {typeof(T).Name}");

                form = (T)constructor.Invoke(args);
                form.MdiParent = this;
                form.Show();
                form.WindowState = FormWindowState.Maximized;
                if (parentRibbonControl.MergedPages.Count > 0)
                    parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{(form != null ? form.Text : typeof(T).Name)} açıla bilmir: \n" + ex);
            }
        }

        private void ShowExistForm<T>(params object[] args) where T : Form
        {
            T form = Application.OpenForms[typeof(T).Name] as T;

            if (form != null)
            {
                form.BringToFront();
                form.Activate();
            }
            else
            {
                ShowNewForm<T>(args);
            }
        }


    }
}