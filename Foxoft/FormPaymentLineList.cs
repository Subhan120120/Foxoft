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

         this.gV_PaymentLineList.ActiveFilterString = $"[DocumentDate] = #{DateTime.Now.ToString("yyyy-MM-dd")}#";

         LoadPaymentLines();
      }

      private void LoadPaymentLines()
      {
         dbContext = new subContext();

         IQueryable<TrPaymentLine> trPaymentLines = dbContext.TrPaymentLines
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
                                                     });

         CriteriaToExpressionConverter converter = new CriteriaToExpressionConverter();
         IQueryable<TrPaymentLine> filteredData = trPaymentLines.AppendWhere(converter, gV_PaymentLineList.ActiveFilterCriteria) as IQueryable<TrPaymentLine>;

         trPaymentLinesBindingSource.DataSource = filteredData.ToList();

         gV_PaymentLineList.BestFitColumns();
      }

      private void gV_PaymentLineList_ColumnFilterChanged(object sender, EventArgs e)
      {
         LoadPaymentLines();
      }

      private void gV_PaymentLineList_DoubleClick(object sender, EventArgs e)
      {
         //DXMouseEventArgs ea = e as DXMouseEventArgs;
         //GridView view = sender as GridView;
         //GridHitInfo info = view.CalcHitInfo(ea.Location);
         //if ((info.InRow || info.InRowCell) && view.FocusedRowHandle >= 0)
         //{
         //    //string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();

         //    trPaymentLine = view.GetRow(view.FocusedRowHandle) as TrPaymentLine;

         //    DialogResult = DialogResult.OK;
         //}
      }

      private void gC_PaymentLineList_ProcessGridKey(object sender, KeyEventArgs e)
      {
         ColumnView view = (sender as GridControl).FocusedView as ColumnView;
         if (view == null) return;
         if (e.KeyCode == Keys.Enter && view.SelectedRowsCount > 0)
         {
            DialogResult = DialogResult.OK;
         }
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

         if (!object.ReferenceEquals(obj, null))
         {
            Guid invoiceHeaderId = Guid.Parse(obj.ToString());
            TrInvoiceHeader trInvoiceHeader = efMethods.SelectInvoiceHeader(invoiceHeaderId);

            FormInvoice formInvoice = new FormInvoice(trInvoiceHeader.ProcessCode, 1, 2, invoiceHeaderId);
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

         if (!object.ReferenceEquals(obj, null))
         {
            Guid paymentHeaderId = Guid.Parse(obj.ToString());

            TrPaymentHeader trPaymentHeader = efMethods.SelectPaymentHeader(paymentHeaderId);

            FormPaymentDetail formPayment = new FormPaymentDetail(trPaymentHeader.PaymentHeaderId);
            FormERP formERP = Application.OpenForms["FormERP"] as FormERP;
            formPayment.MdiParent = formERP;
            formPayment.WindowState = FormWindowState.Maximized;
            formPayment.Show();
            formERP.parentRibbonControl.SelectedPage = formERP.parentRibbonControl.MergedPages[0];
         }
      }

      private void bBI_ReceivePayment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
         gV_PaymentLineList.ExportToXlsx(@"C:\Users\Public\Desktop\PaymentLineList.xlsx");
      }
   }
}