﻿using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using System.Collections;
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

            this.ACE_CashTransfer.Name = "CashTransfer";
            this.aCE_Expense.Name = "Expense";
            this.aCE_PaymentDetail.Name = "PaymentDetail";
            this.aCE_Acounting.Name = "Acounting";
            this.aCE_CountIn.Name = "CountIn";
            this.aCE_CountOut.Name = "CountOut";
            this.ACE_Waybill.Name = "Waybill";
            this.ACE_WaybillIn.Name = "WaybillIn";
            this.ACE_WaybillOut.Name = "WaybillOut";
            this.aCE_Reports.Name = "Reports";
            this.aCE_Setting.Name = "Setting";
            this.ACE_Parameters.Name = "Parameters";
            this.ACE_PriceList.Name = "PriceList";
            this.ACE_ProductDiscounts.Name = "ProductDiscountList";
            this.ACE_ProductFeatureType.Name = "ProductFeatureType";
            this.ACE_CurrAccFeatureType.Name = "CurrAccFeatureType";
            this.aCE_CurrAccRole.Name = "CurrAccClaim";
            this.bBI_Session.Name = "Session";
            this.ACE_Installments.Name = "Installments";
            this.ACE_Stores.Name = "StoreList";
        }

        private void InitializeReports()
        {
            List<DcReport> dcReports = efMethods.SelectReportsByType(new byte[] { 1, 2 });

            foreach (DcReport dcReport in dcReports)
            {
                AccordionControlElement aCE = new();

                aCE.ImageOptions.SvgImage = svgImageCollection1["report"];
                aCE.Name = dcReport.ReportId.ToString();
                aCE.Style = ElementStyle.Item;
                aCE.Text = dcReport.ReportName;
                aCE.Click += (sender, e) =>
                {
                    bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, dcReport.ReportId.ToString());
                    if (!currAccHasClaims)
                    {
                        MessageBox.Show("Yetkiniz yoxdur! ");
                        return;
                    }
                    ShowNewForm<FormReportFilter>(dcReport);
                };

                aCE_Reports.Elements.Add(aCE);
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

            //foreach (var child in this.MdiChildren)
            //{
            //    var customChild = child as RibbonForm;
            //    if (customChild == null) continue; //if there are any casting problems

            //    customChild.Close();
            //}
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

        private void aCE_Products_Click(object sender, EventArgs e)
        {
            ShowExistForm<FormProductList>(new byte[] { 1 }, false);
        }

        private void aCE_CurrAccs_Click(object sender, EventArgs e)
        {
            ShowNewForm<FormCurrAccList>(new byte[] { 1, 2, 3 });
        }

        private void aCE_RetailPurchaseInvoice_Click(object sender, EventArgs e)
        {
            ShowNewForm<FormInvoice>("RP", false, new byte[] { 1, 3 }, null);
        }

        private void aCE_RetailSaleInvoice_Click(object sender, EventArgs e)
        {
            ShowNewForm<FormInvoice>("RS", false, new byte[] { 1, 3 }, null);
        }

        private void ACE_WholesaleInvoice_Click(object sender, EventArgs e)
        {
            ShowNewForm<FormInvoice>("WS", false, new byte[] { 1, 3 }, null);
        }

        private void ACE_InstallmentSaleInvoice_Click(object sender, EventArgs e)
        {
            ShowNewForm<FormInvoice>("IS", false, new byte[] { 1, 3 }, null);
        }

        private void aCE_Expense_Click(object sender, EventArgs e)
        {
            ShowNewForm<FormInvoice>("EX", false, new byte[] { 2, 3 }, null);
        }

        private void aCE_CountIn_Click(object sender, EventArgs e)
        {
            ShowNewForm<FormInvoice>("CI", false, new byte[] { 1 }, null);
        }

        private void aCE_CountOut_Click(object sender, EventArgs e)
        {
            ShowNewForm<FormInvoice>("CO", false, new byte[] { 1 }, null);
        }

        private void aCE_InventoryTransfer_Click(object sender, EventArgs e)
        {
            ShowNewForm<FormInvoice>("IT", false, new byte[] { 1 }, null);
        }

        private void ACE_PurchaseReturnCustom_Click(object sender, EventArgs e)
        {
            ShowNewForm<FormInvoice>("RP", true, new byte[] { 1, 3 }, null);
        }

        private void ACE_RetailsaleReturnCustom_Click(object sender, EventArgs e)
        {
            ShowNewForm<FormInvoice>("RS", true, new byte[] { 1, 3 }, null);
        }

        private void ACE_WholesaleReturnCustom_Click(object sender, EventArgs e)
        {
            ShowNewForm<FormInvoice>("WS", true, new byte[] { 1, 3 }, null);
        }

        private void ACE_InstallmentSaleReturnCustom_Click(object sender, EventArgs e)
        {
            ShowNewForm<FormInvoice>("IS", true, new byte[] { 1, 3 }, null);
        }

        private void aCE_PaymentDetail_Click(object sender, EventArgs e)
        {
            ShowNewForm<FormPaymentDetail>();
        }

        private void ACE_CashTransfer_Click(object sender, EventArgs e)
        {
            ShowNewForm<FormMoneyTransfer>();
        }

        private void ACE_PurchaseReturn_Click(object sender, EventArgs e)
        {
            ShowExistForm<FormReturn>("RP");
        }

        private void ACE_RetailSaleReturn_Click(object sender, EventArgs e)
        {
            ShowExistForm<FormReturn>("RS");
        }

        private void aCE_WholesaleReturn_Click(object sender, EventArgs e)
        {
            ShowExistForm<FormReturn>("WS");
        }

        private void ACE_InstallmentSaleReturn_Click(object sender, EventArgs e)
        {
            ShowExistForm<FormReturn>("IS");
        }

        private void ACE_CashRegs_Click(object sender, EventArgs e)
        {
            ShowExistForm<FormCashRegisterList>();
        }

        private void ACE_Installments_Click(object sender, EventArgs e)
        {
            ShowExistForm<FormInstallmentSale>();
        }

        private void ACE_PricList_Click(object sender, EventArgs e)
        {
            ShowNewForm<FormPriceListDetail>();
        }

        private void ACE_Discounts_Click(object sender, EventArgs e)
        {
            ShowExistForm<FormCommonList<DcDiscount>>("", nameof(DcDiscount.DiscountId));
        }

        private void BBI_ChangeUser_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void ACE_RetailPurchaseOrder_Click(object sender, EventArgs e)
        {

        }

        private void ACE_RetailSaleOrder_Click(object sender, EventArgs e)
        {
            ShowNewForm<FormInvoice>("RSO", false, new byte[] { 1, 3 }, null);
        }

        private void BBI_Test_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void BBI_Session_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowExistForm<FormCurrAccSession>();
        }

        private void ACE_ProductFeatureTypes_Click(object sender, EventArgs e)
        {
            ShowExistForm<FormHierarchyFeatureType>();
        }

        private void ACE_CurrAccFeatureTypes_Click(object sender, EventArgs e)
        {
            ShowExistForm<FormCommonList<DcCurrAccFeatureType>>("", nameof(DcCurrAccFeatureType.CurrAccFeatureTypeId));
        }

        private void aCE_CurrAccRole_Click(object sender, EventArgs e)
        {
            ShowExistForm<FormCurrAccProfile>();
        }

        private void ACE_Delivery_Click(object sender, EventArgs e)
        {
            ShowNewForm<FormWaybill>("WO");
        }

        private void ACE_WaybillIn_Click(object sender, EventArgs e)
        {
            ShowNewForm<FormInvoice>("WI", false, new byte[] { 1 }, null);
        }

        private void ACE_WaybillOut_Click(object sender, EventArgs e)
        {
            ShowNewForm<FormInvoice>("WO", false, new byte[] { 1 }, null);
        }

        private void ACE_Parameters_Click(object sender, EventArgs e)
        {
            ShowExistForm<FormAppSetting>();
        }

        private void ACE_Stores_Click(object sender, EventArgs e)
        {
            ShowExistForm<FormStoreList>();
        }
    }
}