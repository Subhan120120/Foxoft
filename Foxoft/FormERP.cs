using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.Diagram.Core.Themes;
using DevExpress.LookAndFeel;
using DevExpress.Utils.Svg;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraReports.UI;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Foxoft
{
   public partial class FormERP : RibbonForm
   {
      //AdornerUIManager adornerUIManager1;
      //IList<AdornerElement> adorners1;

      EfMethods efMethods = new();

      public FormERP()
      {

         InitializeComponent();

         string path = Path.Combine(Environment.CurrentDirectory, "backgroundImage.png");

         if (File.Exists(path))
         {
            this.BackgroundImageLayoutStore = ImageLayout.Stretch;
            Stream stream = File.OpenRead(path);
            this.BackgroundImage = Image.FromStream(stream);
         }
         UserLookAndFeel.Default.StyleChanged += new EventHandler(UserLookAndFeel_StyleChanged);
         LookAndFeelSettingsHelper.Load(Authorization.CurrAccCode);

         bSI_UserName.Caption = "| " + efMethods.SelectCurrAcc(Authorization.CurrAccCode).CurrAccDesc;
         BSI_StoreDesc.Caption = "| " + efMethods.SelectCurrAcc(Authorization.StoreCode).CurrAccDesc;
         InitializeReports();
         //adorners1 = new List<AdornerElement>();
         //adornerUIManager1 = new AdornerUIManager(this.components);
      }

      private void InitializeReports()
      {
         ComponentResourceManager resources = new(typeof(FormERP));
         List<DcReport> dcReports = efMethods.SelectReports();

         foreach (DcReport dcReport in dcReports)
         {
            AccordionControlElement aCE = new();

            aCE.ImageOptions.SvgImage = ((SvgImage)(resources.GetObject("aCE_ReportZet.ImageOptions.SvgImage")));

            //SvgImageCollection collection = SvgImageCollection.FromResources(typeof(FormERP).Assembly);
            //aCE.ImageOptions.SvgImage = collection["bo_report"];

            aCE.Name = dcReport.ReportName;
            aCE.Style = ElementStyle.Item;
            aCE.Text = dcReport.ReportName;
            aCE.Click += (sender, e) =>
            {
               FormReportFilter formReport = new(dcReport);
               formReport.MdiParent = this;
               formReport.Show();
               parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];
            };

            this.aCE_Reports.Elements.Add(aCE);
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
         foreach (var child in this.MdiChildren)
         {
            var customChild = child as RibbonForm;
            if (customChild == null) continue; //if there are any casting problems

            customChild.Close();
         }
      }

      private void FormERP_MdiChildActivate(object sender, EventArgs e)
      {
         try
         {
            parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];
         }
         catch (Exception) { }
      }

      private void aCE_Products_Click(object sender, EventArgs e)
      {
         bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, (sender as AccordionControlElement).Name);
         if (!currAccHasClaims)
         {
            MessageBox.Show("Yetkiniz yoxdur! ");
            return;
         }

         FormProductList form = Application.OpenForms[nameof(FormProductList)] as FormProductList;

         if (form != null)
         {
            form.BringToFront();
            form.Activate();
         }
         else
         {
            try
            {
               form = new(new byte[] { 1 });
               form.MdiParent = this;
               form.Show();
               form.WindowState = FormWindowState.Maximized;
               parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.ToString());
            }
         }
      }

      private void aCE_CurrAccs_Click(object sender, EventArgs e)
      {
         bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, (sender as AccordionControlElement).Name);
         if (!currAccHasClaims)
         {
            MessageBox.Show("Yetkiniz yoxdur! ");
            return;
         }

         try
         {
            FormCurrAccList form = Application.OpenForms[nameof(FormCurrAccList)] as FormCurrAccList;
            form = new(0);
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
            parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];
         }
         catch (Exception ex)
         {
            MessageBox.Show("Cari Hesablar açıla bilmir: \n" + ex.ToString());
         }
      }

      private void aCE_CurrAccAll_Click(object sender, EventArgs e)
      {

      }

      private void aCE_RetailPurchaseInvoice_Click(object sender, EventArgs e)
      {
         bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, (sender as AccordionControlElement).Name);
         if (!currAccHasClaims)
         {
            MessageBox.Show("Yetkiniz yoxdur! ");
            return;
         }

         FormInvoice formInvoice = new("RP", new byte[] { 1, 3 }, 2);
         formInvoice.MdiParent = this;
         formInvoice.WindowState = FormWindowState.Maximized;
         formInvoice.Show();
         parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];
      }

      private void aCE_RetailSaleInvoice_Click(object sender, EventArgs e)
      {
         bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, (sender as AccordionControlElement).Name);
         if (!currAccHasClaims)
         {
            MessageBox.Show("Yetkiniz yoxdur! ");
            return;
         }

         FormInvoice formInvoice = new("RS", new byte[] { 1, 3 }, 1);
         formInvoice.MdiParent = this;
         formInvoice.WindowState = FormWindowState.Maximized;
         formInvoice.Show();
         parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];

      }

      private void aCE_Expense_Click(object sender, EventArgs e)
      {
         bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, (sender as AccordionControlElement).Name);
         if (!currAccHasClaims)
         {
            MessageBox.Show("Yetkiniz yoxdur! ");
            return;
         }

         int OpenFormCount = 0;

         foreach (Form form in Application.OpenForms)
         {
            FormInvoice formInvoice = form as FormInvoice;
            if (formInvoice != null && formInvoice.dcProcess.ProcessCode == "EX")
            {
               formInvoice.BringToFront();
               formInvoice.Activate();
               OpenFormCount++;
            }
         }

         if (OpenFormCount == 0)
         {
            FormInvoice formInvoice = new("EX", new byte[] { 2, 3 }, 0);
            formInvoice.MdiParent = this;
            formInvoice.Show();
            parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];
         }
      }

      private string subConnString = ConfigurationManager
                       .OpenExeConfiguration(ConfigurationUserLevel.None)
                       .ConnectionStrings
                       .ConnectionStrings["Foxoft.Properties.Settings.subConnString"]
                       .ConnectionString;

      private void aCE_ReportZet_Click(object sender, EventArgs e)
      {
         bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, (sender as AccordionControlElement).Name);
         if (!currAccHasClaims)
         {
            MessageBox.Show("Yetkiniz yoxdur! ");
            return;
         }

         DsMethods dsMethods = new();
         ReportClass reportClass = new();

         //object[] objInvoiceHeaders = efMethods.SelectInvoiceLineForReport(invoiceHeaderId).Cast<object>().ToArray();

         //DataTable trInvoiceLines = adoMethods.SelectInvoiceLines(DateTime.Now.Date, DateTime.Now.Date);
         //DataTable trPaymentLines = adoMethods.SelectPaymentLines(DateTime.Now.Date, DateTime.Now.Date);

         //DataSet dataSet = new("GunSonu");
         //dataSet.Tables.AddRange(new DataTable[] { trInvoiceLines, trPaymentLines });

         SqlDataSource dataSource = new(new CustomStringConnectionParameters(subConnString));
         dataSource.Name = "GunSonu";

         //SqlQuery sqlQueryPurchases = dsMethods.SelectPurchases(DateTime.Now.Date, DateTime.Now.Date);

         CustomSqlQuery sqlDepozit = new("Depozit", "select 0 depozit");

         DateTime dateTime = new(2022, 06, 23); // DateTime.Now.Date; // 

         DateTime startDate = dateTime;
         DateTime endDate = dateTime;

         SqlQuery sqlQuerySale = dsMethods.SelectSales(startDate, endDate);
         SqlQuery sqlQueryPayment = dsMethods.SelectPayments(startDate, endDate);
         SqlQuery sqlQueryExpences = dsMethods.SelectExpences(startDate, endDate);
         SqlQuery sqlQueryDbtCustomers = dsMethods.SelectDebtCustomers();
         //SqlQuery sqlQueryDbtVendors = dsMethods.SelectDebtVendors();
         SqlQuery sqlQueryPaymentCustomers = dsMethods.SelectPaymentCustomers(startDate, endDate);
         SqlQuery sqlQueryPaymentVendors = dsMethods.SelectPaymentVendors(startDate, endDate);

         dataSource.Queries.AddRange(new SqlQuery[] { sqlDepozit, sqlQuerySale, sqlQueryPayment, sqlQueryExpences, sqlQueryDbtCustomers, sqlQueryPaymentCustomers, sqlQueryPaymentVendors });
         dataSource.Fill();

         // string designPath = Settings.Default.AppSetting.PrintDesignPath;

         string designPath = Path.Combine(Environment.CurrentDirectory, @"AppCode\ReportDesign\", "GUNSONU.repx");

         if (!File.Exists(designPath))
         {
            designPath = reportClass.SelectDesign();
         }
         if (File.Exists(designPath))
         {
            ReportDesignTool designTool = new(reportClass.CreateReport(dataSource, designPath));
            designTool.ShowRibbonDesignerDialog();
         }
      }

      private void aCE_Payments_Click(object sender, EventArgs e)
      {
         bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, (sender as AccordionControlElement).Name);
         if (!currAccHasClaims)
         {
            MessageBox.Show("Yetkiniz yoxdur! ");
            return;
         }

         int OpenFormCount = 0;

         foreach (Form form in Application.OpenForms)
         {
            FormPaymentLineList formPaymentHeaders = form as FormPaymentLineList;
            if (formPaymentHeaders != null)
            {
               formPaymentHeaders.BringToFront();
               formPaymentHeaders.Activate();
               OpenFormCount++;
            }
         }

         if (OpenFormCount == 0)
         {
            FormPaymentLineList formPaymentHeaders = new();
            formPaymentHeaders.MdiParent = this;
            formPaymentHeaders.WindowState = FormWindowState.Maximized;
            formPaymentHeaders.Show();
            parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];
         }
      }

      private void aCE_CountIn_Click(object sender, EventArgs e)
      {
         bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, (sender as AccordionControlElement).Name);
         if (!currAccHasClaims)
         {
            MessageBox.Show("Yetkiniz yoxdur! ");
            return;
         }

         FormInvoice formInvoice = new("CI", new byte[] { 1 }, 0);
         formInvoice.MdiParent = this;
         formInvoice.WindowState = FormWindowState.Maximized;
         formInvoice.Show();
         parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];
      }

      private void aCE_CountOut_Click(object sender, EventArgs e)
      {
         bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, (sender as AccordionControlElement).Name);
         if (!currAccHasClaims)
         {
            MessageBox.Show("Yetkiniz yoxdur! ");
            return;
         }

         FormInvoice formInvoice = new("CO", new byte[] { 1 }, 0);
         formInvoice.MdiParent = this;
         formInvoice.WindowState = FormWindowState.Maximized;
         formInvoice.Show();
         parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];
      }

      private void aCE_PaymentDetail_Click(object sender, EventArgs e)
      {
         bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, (sender as AccordionControlElement).Name);
         if (!currAccHasClaims)
         {
            MessageBox.Show("Yetkiniz yoxdur! ");
            return;
         }

         FormPaymentDetail formPaymentDetail = new();
         formPaymentDetail.MdiParent = this;
         formPaymentDetail.WindowState = FormWindowState.Maximized;
         formPaymentDetail.Show();
         parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];
      }

      private void FormERP_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (MessageBox.Show("Programdan Çıx", "Diqqət", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            e.Cancel = true;
      }

      private void aCE_InventoryTransfer_Click(object sender, EventArgs e)
      {
         bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, (sender as AccordionControlElement).Name);
         if (!currAccHasClaims)
         {
            MessageBox.Show("Yetkiniz yoxdur! ");
            return;
         }

         FormInvoice formInvoice = new("IT", new byte[] { 1 }, 4);
         formInvoice.MdiParent = this;
         formInvoice.WindowState = FormWindowState.Maximized;
         formInvoice.Show();
         parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];
      }

      private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
      {

      }

      private void ACE_CashTransfer_Click(object sender, EventArgs e)
      {
         bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, (sender as AccordionControlElement).Name);
         if (!currAccHasClaims)
         {
            MessageBox.Show("Yetkiniz yoxdur! ");
            return;
         }

         FormMoneyTransfer form = new();
         form.MdiParent = this;
         form.WindowState = FormWindowState.Maximized;
         form.Show();
         parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];
      }

      private void ACE_PurchaseIsReturn_Click(object sender, EventArgs e)
      {
         bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, (sender as AccordionControlElement).Name);
         if (!currAccHasClaims)
         {
            MessageBox.Show("Yetkiniz yoxdur! ");
            return;
         }

         int OpenFormCount = 0;

         foreach (Form form in Application.OpenForms)
         {
            FormReturn frmRtrn = form as FormReturn;
            if (frmRtrn != null)
            {
               frmRtrn.BringToFront();
               frmRtrn.Activate();
               OpenFormCount++;
            }
         }

         if (OpenFormCount == 0)
         {
            FormReturn frmRtrn = new("RP");
            frmRtrn.MdiParent = this;
            frmRtrn.WindowState = FormWindowState.Maximized;
            frmRtrn.Show();
         }
      }

      private void ACE_SaleIsReturn_Click(object sender, EventArgs e)
      {
         bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, (sender as AccordionControlElement).Name);
         if (!currAccHasClaims)
         {
            MessageBox.Show("Yetkiniz yoxdur! ");
            return;
         }

         int OpenFormCount = 0;

         foreach (Form form in Application.OpenForms)
         {
            FormReturn frmRtrn = form as FormReturn;
            if (frmRtrn != null)
            {
               frmRtrn.BringToFront();
               frmRtrn.Activate();
               OpenFormCount++;
            }
         }

         if (OpenFormCount == 0)
         {
            FormReturn frmRtrn = new("RS");
            frmRtrn.MdiParent = this;
            frmRtrn.WindowState = FormWindowState.Maximized;
            frmRtrn.Show();
         }
      }

      private void ACE_ReportFinally_Click(object sender, EventArgs e)
      {
         bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, (sender as AccordionControlElement).Name);
         if (!currAccHasClaims)
         {
            MessageBox.Show("Yetkiniz yoxdur! ");
            return;
         }

         DsMethods dsMethods = new();
         ReportClass reportClass = new();

         SqlDataSource dataSource = new(new CustomStringConnectionParameters(subConnString));
         dataSource.Name = "Kapital";

         //SqlQuery sqlQueryPurchases = dsMethods.SelectPurchases(DateTime.Now.Date, DateTime.Now.Date);

         CustomSqlQuery sqlDepozit = new("Depozit", "select 0 depozit");

         DateTime dateTime = new(2022, 06, 23); // DateTime.Now.Date; // 

         DateTime startDate = dateTime;
         DateTime endDate = dateTime;

         SqlQuery sqlQuerySale = dsMethods.SelectSales(startDate, endDate);
         SqlQuery sqlQueryPayment = dsMethods.SelectPayments(startDate, endDate);
         SqlQuery sqlQueryExpences = dsMethods.SelectExpences(startDate, endDate);
         SqlQuery sqlQueryDbtCustomers = dsMethods.SelectDebtCustomers();
         //SqlQuery sqlQueryDbtVendors = dsMethods.SelectDebtVendors();
         SqlQuery sqlQueryPaymentCustomers = dsMethods.SelectPaymentCustomers(startDate, endDate);
         SqlQuery sqlQueryPaymentVendors = dsMethods.SelectPaymentVendors(startDate, endDate);

         dataSource.Queries.AddRange(new SqlQuery[] { sqlDepozit, sqlQuerySale, sqlQueryPayment, sqlQueryExpences, sqlQueryDbtCustomers, sqlQueryPaymentCustomers, sqlQueryPaymentVendors });
         dataSource.Fill();

         // string designPath = Settings.Default.AppSetting.PrintDesignPath;

         string designPath = Path.Combine(Environment.CurrentDirectory, @"AppCode\ReportDesign\", "GUNSONU.repx");

         if (!File.Exists(designPath))
         {
            designPath = reportClass.SelectDesign();
         }
         if (File.Exists(designPath))
         {
            ReportDesignTool designTool = new(reportClass.CreateReport(dataSource, designPath));
            designTool.ShowRibbonDesignerDialog();
         }
      }

      private void ACE_CashRegs_Click(object sender, EventArgs e)
      {
         bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, (sender as AccordionControlElement).Name);
         if (!currAccHasClaims)
         {
            MessageBox.Show("Yetkiniz yoxdur! ");
            return;
         }

         FormCurrAccList form = Application.OpenForms[nameof(FormCurrAccList)] as FormCurrAccList;

         try
         {
            form = new(5);
            form.MdiParent = this;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
            parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];
         }
         catch (Exception ex)
         {
            MessageBox.Show("Kassa Hesablar açıla bilmir: \n" + ex.ToString());
         }

      }

      private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
      {

      }

      private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
      {
      }
   }
}