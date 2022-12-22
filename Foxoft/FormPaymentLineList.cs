using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors.Controls;
using System.ComponentModel;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data.Filtering;
using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;
using System.Collections.Generic;
using System.Net;
using System.Diagnostics;
using System.Security;

namespace Foxoft
{
   public partial class FormPaymentLineList : DevExpress.XtraBars.Ribbon.RibbonForm
   {
      subContext dbContext;
      EfMethods efMethods = new EfMethods();
      public TrPaymentLine trPaymentLine { get; set; }

      public FormPaymentLineList()
      {
         InitializeComponent();

         byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
         MemoryStream stream = new MemoryStream(byteArray);
         OptionsLayoutGrid option = new OptionsLayoutGrid() { StoreAllOptions = true, StoreAppearance = true };
         gV_PaymentLineList.RestoreLayoutFromStream(stream, option);
         //this.gV_PaymentLineList.ActiveFilterString = $"[DocumentDate] = #{DateTime.Now.ToString("yyyy-MM-dd")}#";

         LoadPaymentLines();

         string storeCode = Authorization.StoreCode;
         gV_PaymentLineList.ActiveFilterString = "[StoreCode] = \'" + storeCode + "\'";
      }

      private void LoadPaymentLines()
      {
         dbContext = new subContext();

         IQueryable<TrPaymentLine> trPaymentLines = dbContext.TrPaymentLines;
         CriteriaToExpressionConverter converter = new CriteriaToExpressionConverter();
         IQueryable<TrPaymentLine> filteredData = trPaymentLines.AppendWhere(new CriteriaToExpressionConverter(), gV_PaymentLineList.ActiveFilterCriteria) as IQueryable<TrPaymentLine>;


         List<TrPaymentLine> LineList = filteredData
                                                     .Include(x => x.TrPaymentHeader).ThenInclude(x => x.TrInvoiceHeader)
                                                     .Include(x => x.TrPaymentHeader).ThenInclude(x => x.DcCurrAcc)
                                                     .OrderByDescending(x => x.TrPaymentHeader.DocumentDate).ThenByDescending(x => x.CreatedDate)
                                                     .Select(x => new TrPaymentLine
                                                     {
                                                        CurrAccCode = x.TrPaymentHeader.CurrAccCode,
                                                        CurrAccDesc = x.TrPaymentHeader.DcCurrAcc.CurrAccDesc,
                                                        DocumentNumber = x.TrPaymentHeader.DocumentNumber,
                                                        DocumentDate = x.TrPaymentHeader.DocumentDate,
                                                        InvoiceNumber = x.TrPaymentHeader.TrInvoiceHeader.DocumentNumber,
                                                        PaymentLineId = x.PaymentLineId,
                                                        PaymentHeaderId = x.PaymentHeaderId,
                                                        InvoiceHeaderId = x.TrPaymentHeader.InvoiceHeaderId,
                                                        PaymentTypeCode = x.PaymentTypeCode,
                                                        Payment = x.Payment,
                                                        LineDescription = x.LineDescription,
                                                        ExchangeRate = x.ExchangeRate,
                                                        CreatedUserName = x.CreatedUserName,
                                                        CreatedDate = x.CreatedDate,
                                                        LastUpdatedUserName = x.LastUpdatedUserName,
                                                        LastUpdatedDate = x.LastUpdatedDate,
                                                        CurrencyCode = x.CurrencyCode,
                                                        PaymentLoc = x.PaymentLoc,
                                                        CashRegisterCode = x.CashRegisterCode,
                                                     }).ToList();

         trPaymentLinesBindingSource.DataSource = LineList;

         gV_PaymentLineList.BestFitColumns();
      }



      private void gV_PaymentLineList_DoubleClick(object sender, EventArgs e)
      {
         DXMouseEventArgs ea = e as DXMouseEventArgs;
         GridView view = sender as GridView;
         GridHitInfo info = view.CalcHitInfo(ea.Location);
         if ((info.InRow || info.InRowCell) && view.FocusedRowHandle >= 0)
         {
            //string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();

            trPaymentLine = view.GetFocusedRow() as TrPaymentLine;

            DialogResult = DialogResult.OK;
         }
      }

      private void gC_PaymentLineList_ProcessGridKey(object sender, KeyEventArgs e)
      {
         ColumnView view = (sender as GridControl).FocusedView as ColumnView;
         if (view == null) return;

         if (view.SelectedRowsCount > 0)
            trPaymentLine = view.GetFocusedRow() as TrPaymentLine;

         if (e.KeyCode == Keys.Enter && trPaymentLine is not null)
            DialogResult = DialogResult.OK;

         if (e.KeyCode == Keys.Escape)
            Close();
      }

      GridColumn prevColumn = null; // Disable the Immediate Edit Cell
      int prevRow = -1;
      private void gV_PaymentLineList_ShowingEditor(object sender, CancelEventArgs e)
      {
         GridView view = sender as GridView;
         if (prevColumn != view.FocusedColumn || prevRow != view.FocusedRowHandle)
            e.Cancel = true;
         prevColumn = view.FocusedColumn;
         prevRow = view.FocusedRowHandle;
      }

      bool isFirstPaint = true; // Focus FindPanel
      private void gC_ProductList_Paint(object sender, PaintEventArgs e)
      {
         GridControl gC = sender as GridControl;
         GridView gV = gC.MainView as GridView;

         if (isFirstPaint)
         {
            if (!gV.FindPanelVisible)
               gV.ShowFindPanel();
            gV.ShowFindPanel();
         }
         isFirstPaint = false;
      }

      private void repoHLE_InvoiceNumber_ButtonClick(object sender, ButtonPressedEventArgs e)
      {
         MessageBox.Show("repoHLE_InvoiceNumber_ButtonClick klik");
      }

      private void repoHLE_InvoiceNumber_OpenLink(object sender, OpenLinkEventArgs e)
      {
         object obj = gV_PaymentLineList.GetFocusedRowCellValue(colInvoiceHeaderId); //deyisdir

         if (obj is not null)
         {
            Guid invoiceHeaderId = Guid.Parse(obj.ToString());
            TrInvoiceHeader trInvoiceHeader = efMethods.SelectInvoiceHeader(invoiceHeaderId);

            FormInvoice formInvoice = new(trInvoiceHeader.ProcessCode, 1, 2, invoiceHeaderId);
            FormERP formERP = Application.OpenForms["FormERP"] as FormERP;
            formInvoice.MdiParent = formERP;
            formInvoice.WindowState = FormWindowState.Maximized;
            formInvoice.Show();
            formERP.parentRibbonControl.SelectedPage = formERP.parentRibbonControl.MergedPages[0];
         }
      }

      private void repoHLE_DocNum_ButtonClick(object sender, ButtonPressedEventArgs e)
      {

         MessageBox.Show("repoHLE_DocNum_ButtonClick klik");
      }

      private void repoHLE_DocNum_OpenLink(object sender, OpenLinkEventArgs e)
      {
         object obj = gV_PaymentLineList.GetFocusedRowCellValue(colPaymentHeaderId);

         if (obj is not null)
         {
            Guid paymentHeaderId = Guid.Parse(obj.ToString());

            TrPaymentHeader trPaymentHeader = efMethods.SelectPaymentHeader(paymentHeaderId);

            FormPaymentDetail formPayment = new(trPaymentHeader.PaymentHeaderId);
            FormERP formERP = Application.OpenForms["FormERP"] as FormERP;
            formPayment.MdiParent = formERP;
            formPayment.WindowState = FormWindowState.Maximized;
            formPayment.Show();
            formERP.parentRibbonControl.SelectedPage = formERP.parentRibbonControl.MergedPages[0];
         }
      }

      private void bBI_ReceivePayment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         using (FormCurrAccList formCurrAcc = new(0))
         {
            if (formCurrAcc.ShowDialog(this) == DialogResult.OK)
            {
               TrInvoiceHeader trInvoiceHeader = new() { CurrAccCode = formCurrAcc.dcCurrAcc.CurrAccCode };

               using (FormPayment formPayment = new(1, 0, trInvoiceHeader))
               {
                  if (formPayment.ShowDialog(this) == DialogResult.OK)
                  {
                     //efMethods.UpdateInvoiceIsCompleted(trInvoiceHeader.InvoiceHeaderId);
                     LoadPaymentLines();
                  }
               }
            }
         }
      }

      private void bBI_MakePayment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                     LoadPaymentLines();
                  }
               }
            }
         }
      }

      private void bBI_Reload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         LoadPaymentLines();
      }

      private void bBI_ExportXlsx_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         SaveFileDialog saveFileDialog1 = new();
         saveFileDialog1.Filter = "Excel Faylı|*.xlsx";
         saveFileDialog1.Title = "Excel Faylı Yadda Saxla";
         saveFileDialog1.FileName = $@"PaymentLineList.xlsx";
         saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
         saveFileDialog1.DefaultExt = "*.xlsx";

         if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            gV_PaymentLineList.ExportToXlsx(saveFileDialog1.FileName);
      }
      private void gV_PaymentLineList_ColumnFilterChanged(object sender, EventArgs e)
      {
         GridView view = sender as GridView;

         if (view.SelectedRowsCount > 0)
            trPaymentLine = view.GetFocusedRow() as TrPaymentLine;
         else
            trPaymentLine = null;
      }

      private void test_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
      }

      private void test_ItemClick()
      {
         //try
         //{
         //   string accountSid = "AC3975230c878fd8f23210d643a30a94b6";
         //   string authToken = "a17365de8e7d28057adef930da03ee71";

         //   TwilioClient.Init(accountSid, authToken);
         //   var mediaUrl = new[] {
         //           new Uri(@"https://www.gardendesign.com/pictures/images/675x529Max/site_3/helianthus-yellow-flower-pixabay_11863.jpg")
         //       }.ToList();
         //   var message = MessageResource.Create(mediaUrl: mediaUrl, from: new PhoneNumber("whatsapp: +18507578553"), body: "Profile", to: new PhoneNumber("whatsapp:+994519678909"));
         //   MessageBox.Show(message.Sid);
         //}
         //catch (Exception ex)
         //{

         //   MessageBox.Show(ex.ToString());
         //}
      }

      private void gV_PaymentLineList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
      {
         GridView view = sender as GridView;

         if (view.SelectedRowsCount > 0)
            trPaymentLine = view.GetFocusedRow() as TrPaymentLine;
         else
            trPaymentLine = null;
      }
   }
}