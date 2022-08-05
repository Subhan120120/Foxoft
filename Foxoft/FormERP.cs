using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.Utils.VisualEffects;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraReports.UI;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Foxoft
{
   public partial class FormERP : RibbonForm
   {
      AdornerUIManager adornerUIManager1;
      IList<AdornerElement> adorners1;

      public FormERP()
      {
         InitializeComponent();
         ComponentResourceManager resources = new ComponentResourceManager(typeof(FormERP));
         EfMethods efMethods = new EfMethods();

         List<DcReport> dcReports = efMethods.SelectReports();

         foreach (DcReport dcReport in dcReports)
         {
            AccordionControlElement aCE = new AccordionControlElement();

            aCE.ImageOptions.SvgImage = ((SvgImage)(resources.GetObject("aCE_ReportZet.ImageOptions.SvgImage")));

            //SvgImageCollection collection = SvgImageCollection.FromResources(typeof(FormERP).Assembly);
            //aCE.ImageOptions.SvgImage = collection["bo_report"];

            aCE.Name = dcReport.ReportName;
            aCE.Style = ElementStyle.Item;
            aCE.Text = dcReport.ReportName;
            aCE.Click += (sender, e) =>
            {
               FormReportFilter formReport = new FormReportFilter(dcReport);
               formReport.MdiParent = this;
               formReport.Show();
               parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];
            };

            this.aCE_Reports.Elements.Add(aCE);
         }

         //adorners1 = new List<AdornerElement>();
         //adornerUIManager1 = new AdornerUIManager(this.components);
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
         FormPOS formPOS = new FormPOS();
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
            var myCustomChild = child as RibbonForm;
            if (myCustomChild == null) continue; //if there are any casting problems

            myCustomChild.Close();
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
         FormProductList form = Application.OpenForms["FormProductList"] as FormProductList;

         if (form != null)
         {
            form.BringToFront();
            form.Activate();
         }
         else
         {
            try
            {

               form = new FormProductList(1);
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

      private void aCE_CurrAcc_Click(object sender, EventArgs e)
      {
         FormCurrAccList form = Application.OpenForms["FormCurrAccList"] as FormCurrAccList;

         if (form != null)
         {
            form.BringToFront();
            form.Activate();
         }
         else
         {
            try
            {
               form = new FormCurrAccList(0);
               form.MdiParent = this;
               form.Show();
               form.WindowState = FormWindowState.Maximized;
               parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];
            }
            catch (Exception ex)
            {
               MessageBox.Show("Cari Hesablar acila bilmir: \n" + ex.ToString());
            }
         }
      }

      private void aCE_CurrAccs_Click(object sender, EventArgs e)
      {

      }

      private void aCE_RetailPurchaseInvoice_Click(object sender, EventArgs e)
      {
         FormInvoice formInvoice = new FormInvoice("RP", 1, 2);
         formInvoice.MdiParent = this;
         formInvoice.WindowState = FormWindowState.Maximized;
         formInvoice.Show();
         parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];

      }

      private void aCE_RetailSaleInvoice_Click(object sender, EventArgs e)
      {
         FormInvoice formInvoice = new FormInvoice("RS", 1, 1);
         formInvoice.MdiParent = this;
         formInvoice.WindowState = FormWindowState.Maximized;
         formInvoice.Show();
         parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];

      }

      private void aCE_Expense_Click(object sender, EventArgs e)
      {
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
            FormInvoice formInvoice = new FormInvoice("EX", 2, 0);
            formInvoice.MdiParent = this;
            formInvoice.Show();
            parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];
         }
      }

      private string subConnString = Settings.Default.subConnString;

      private void accordionControlElement2_Click(object sender, EventArgs e)
      {
         DsMethods dsMethods = new DsMethods();
         ReportClass reportClass = new ReportClass();

         //object[] objInvoiceHeaders = efMethods.SelectInvoiceLineForReport(invoiceHeaderId).Cast<object>().ToArray();

         //DataTable trInvoiceLines = adoMethods.SelectInvoiceLines(DateTime.Now.Date, DateTime.Now.Date);
         //DataTable trPaymentLines = adoMethods.SelectPaymentLines(DateTime.Now.Date, DateTime.Now.Date);

         //DataSet dataSet = new DataSet("GunSonu");
         //dataSet.Tables.AddRange(new DataTable[] { trInvoiceLines, trPaymentLines });

         SqlDataSource dataSource = new SqlDataSource(new CustomStringConnectionParameters(subConnString));
         dataSource.Name = "GunSonu";

         //SqlQuery sqlQueryPurchases = dsMethods.SelectPurchases(DateTime.Now.Date, DateTime.Now.Date);

         CustomSqlQuery sqlDepozit = new CustomSqlQuery("Depozit", "select 0 depozit");

         DateTime dateTime = new DateTime(2022, 06, 23); // DateTime.Now.Date; // 

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
            ReportDesignTool designTool = new ReportDesignTool(reportClass.CreateReport(dataSource, designPath));
            designTool.ShowRibbonDesignerDialog();
         }


      }

      private void aCE_MakePayment_Click(object sender, EventArgs e)
      {
         using (FormCurrAccList formCurrAcc = new FormCurrAccList(0))
         {
            if (formCurrAcc.ShowDialog(this) == DialogResult.OK)
            {
               TrInvoiceHeader trInvoiceHeader = new TrInvoiceHeader() { CurrAccCode = formCurrAcc.dcCurrAcc.CurrAccCode };

               using (FormPayment formPayment = new FormPayment(1, -1, trInvoiceHeader))
               {
                  if (formPayment.ShowDialog(this) == DialogResult.OK)
                  {
                     //efMethods.UpdateInvoiceIsCompleted(trInvoiceHeader.InvoiceHeaderId);
                  }
               }
            }
         }
      }

      private void aCE_receivePayment_Click(object sender, EventArgs e)
      {
         using (FormCurrAccList formCurrAcc = new FormCurrAccList(0))
         {
            if (formCurrAcc.ShowDialog(this) == DialogResult.OK)
            {
               TrInvoiceHeader trInvoiceHeader = new TrInvoiceHeader() { CurrAccCode = formCurrAcc.dcCurrAcc.CurrAccCode };
               //decimal debt = 
               using (FormPayment formPayment = new FormPayment(1, 0, trInvoiceHeader))
               {
                  if (formPayment.ShowDialog(this) == DialogResult.OK)
                  {
                     //efMethods.UpdateInvoiceIsCompleted(trInvoiceHeader.InvoiceHeaderId);
                  }
               }
            }
         }
      }

      private void aCE_Payments_Click(object sender, EventArgs e)
      {
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
            FormPaymentLineList formPaymentHeaders = new FormPaymentLineList();
            formPaymentHeaders.MdiParent = this;
            formPaymentHeaders.WindowState = FormWindowState.Maximized;
            formPaymentHeaders.Show();
            parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];
         }
      }

      private void aCE_CountIn_Click(object sender, EventArgs e)
      {
         FormInvoice formInvoice = new FormInvoice("CI", 1, 0);
         formInvoice.MdiParent = this;
         formInvoice.WindowState = FormWindowState.Maximized;
         formInvoice.Show();
         parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];
      }

      private void aCE_CountOut_Click(object sender, EventArgs e)
      {
         FormInvoice formInvoice = new FormInvoice("CO", 1, 0);
         formInvoice.MdiParent = this;
         formInvoice.WindowState = FormWindowState.Maximized;
         formInvoice.Show();
         parentRibbonControl.SelectedPage = parentRibbonControl.MergedPages[0];
      }

      private void aCE_PaymentDetail_Click(object sender, EventArgs e)
      {
         FormPaymentDetail formPaymentDetail = new FormPaymentDetail();
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
   }
}