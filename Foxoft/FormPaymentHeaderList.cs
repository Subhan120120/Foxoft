using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Foxoft
{
   public partial class FormPaymentHeaderList : RibbonForm
   {
      subContext dbContext;
      EfMethods efMethods = new EfMethods();
      public TrPaymentHeader trPaymentHeader { get; set; }

      public FormPaymentHeaderList()
      {
         InitializeComponent();

         //gV_PaymentHeaderList.OptionsFilter.filter = true;

         byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
         MemoryStream stream = new MemoryStream(byteArray);
         OptionsLayoutGrid option = new OptionsLayoutGrid() { StoreAllOptions = true, StoreAppearance = true };
         gV_PaymentHeaderList.RestoreLayoutFromStream(stream, option);

         LoadPaymentHeaders();

         string storeCode = Authorization.StoreCode;
         gV_PaymentHeaderList.ActiveFilterString = "[StoreCode] = \'" + storeCode + "\'";

      }

      private void LoadPaymentHeaders()
      {
         dbContext = new subContext();

         //dbContext.TrPaymentHeaders.Include(x => x.TrPaymentLines)
         //                          .Include(x => x.TrInvoiceHeader)
         //                          .Include(x => x.DcCurrAcc)
         //                          .OrderByDescending(x => x.OperationDate)
         //                          .LoadAsync()
         //                          .ContinueWith(loadTask =>
         //                          {
         //                              LocalView<TrPaymentHeader> lV_trPaymentHeaders = dbContext.TrPaymentHeaders.Local;

         //                              //lV_trPaymentHeaders.ForEach(x => x.TotalNetAmountLoc = x.TrPaymentLines.Sum(x => Math.Round(x.PaymentLoc / (decimal)1.703, 2)));

         //                              trPaymentHeadersBindingSource.DataSource = lV_trPaymentHeaders.ToBindingList();

         //                              //string date = DateTime.Now.ToString("2022.06.30");
         //                              //this.gV_PaymentHeaderList.ActiveFilterCriteria = CriteriaOperator.Parse("DocumentDate >= " + date);
         //                              //string result = CriteriaToWhereClauseHelper.GetDataSetWhere(gV_PaymentHeaderList.ActiveFilterString);
         //                              //trPaymentHeadersBindingSource.Filter = result;

         //                              gV_PaymentHeaderList.BestFitColumns();

         //                          }, TaskScheduler.FromCurrentSynchronizationContext());

         IQueryable<TrPaymentHeader> trPaymentHeaders = dbContext.TrPaymentHeaders;
         CriteriaToExpressionConverter converter = new CriteriaToExpressionConverter();
         IQueryable<TrPaymentHeader> filteredData = trPaymentHeaders.AppendWhere(new CriteriaToExpressionConverter(), gV_PaymentHeaderList.ActiveFilterCriteria) as IQueryable<TrPaymentHeader>;


         List<TrPaymentHeader> headerList = filteredData.Include(x => x.TrPaymentLines)
                                                        .Include(x => x.DcCurrAcc)
                                                        .Where(x => x.IsMainTF == true)
                                                        .OrderByDescending(x => x.OperationDate)
                                                        .ThenByDescending(x => x.OperationTime)
                                                        .Select(x => new TrPaymentHeader
                                                        {
                                                           TrInvoiceHeader = x.TrInvoiceHeader,
                                                           CurrAccDesc = x.DcCurrAcc.CurrAccDesc,
                                                           TotalPayment = x.TrPaymentLines.Sum(x => x.PaymentLoc),
                                                           PaymentHeaderId = x.PaymentHeaderId,
                                                           InvoiceHeaderId = x.InvoiceHeaderId,
                                                           DocumentNumber = x.DocumentNumber,
                                                           DocumentDate = x.DocumentDate,
                                                           DocumentTime = x.DocumentTime,
                                                           OperationDate = x.OperationDate,
                                                           OperationTime = x.OperationTime,
                                                           CurrAccCode = x.CurrAccCode,
                                                           Description = x.Description,
                                                           OperationType = x.OperationType,
                                                           CompanyCode = x.CompanyCode,
                                                           OfficeCode = x.OfficeCode,
                                                           StoreCode = x.StoreCode,
                                                           PosterminalId = x.PosterminalId,
                                                           IsCompleted = x.IsCompleted,
                                                           IsLocked = x.IsLocked,
                                                           CreatedUserName = x.CreatedUserName,
                                                           CreatedDate = x.CreatedDate,
                                                           LastUpdatedUserName = x.LastUpdatedUserName,
                                                           LastUpdatedDate = x.LastUpdatedDate,
                                                           //FromCashRegCode = x.FromCashRegCode,
                                                           ToCashRegCode = x.ToCashRegCode,
                                                        })
                                                        .ToList();

         trPaymentHeadersBindingSource.DataSource = headerList;
      }

      private void gV_PaymentHeaderList_DoubleClick(object sender, EventArgs e)
      {
         DXMouseEventArgs ea = e as DXMouseEventArgs;
         GridView view = sender as GridView;
         GridHitInfo info = view.CalcHitInfo(ea.Location);
         if ((info.InRow || info.InRowCell) && view.FocusedRowHandle >= 0)
         {
            //string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();

            trPaymentHeader = view.GetFocusedRow() as TrPaymentHeader;

            DialogResult = DialogResult.OK;
         }
      }

      private void gC_PaymentHeaderList_ProcessGridKey(object sender, KeyEventArgs e)
      {
         ColumnView view = (sender as GridControl).FocusedView as ColumnView;
         if (view == null) return;

         if (view.SelectedRowsCount > 0)
            trPaymentHeader = view.GetFocusedRow() as TrPaymentHeader;

         if (e.KeyCode == Keys.Enter && trPaymentHeader is not null)
            DialogResult = DialogResult.OK;

         if (e.KeyCode == Keys.Escape)
            Close();
      }

      GridColumn prevColumn = null; // Disable the Immediate Edit Cell
      int prevRow = -1;
      private void gV_PaymentHeaderList_ShowingEditor(object sender, CancelEventArgs e)
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
         object obj = gV_PaymentHeaderList.GetFocusedRowCellValue(colInvoiceHeaderId);

         if (obj is not null)
         {
            Guid invoiceHeaderId = Guid.Parse(obj.ToString());
            TrInvoiceHeader trInvoiceHeader = efMethods.SelectInvoiceHeader(invoiceHeaderId);

            FormInvoice formInvoice = new (trInvoiceHeader.ProcessCode, 1, 2, invoiceHeaderId);
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
         object obj = gV_PaymentHeaderList.GetFocusedRowCellValue(colPaymentHeaderId);

         if (obj is not null)
         {
            Guid invoiceHeaderId = Guid.Parse(obj.ToString());
            TrPaymentHeader trInvoiceHeader = efMethods.SelectPaymentHeader(invoiceHeaderId);

            FormPaymentDetail formaPayment = new (trInvoiceHeader.PaymentHeaderId);
            FormERP formERP = Application.OpenForms["FormERP"] as FormERP;
            formaPayment.MdiParent = formERP;
            formaPayment.WindowState = FormWindowState.Maximized;
            formaPayment.Show();
            formERP.parentRibbonControl.SelectedPage = formERP.parentRibbonControl.MergedPages[0];
         }
      }

      private void bBI_ReceivePayment_ItemClick(object sender, ItemClickEventArgs e)
      {
         using (FormCurrAccList formCurrAcc = new (0))
         {
            if (formCurrAcc.ShowDialog(this) == DialogResult.OK)
            {
               TrInvoiceHeader trInvoiceHeader = new () { CurrAccCode = formCurrAcc.dcCurrAcc.CurrAccCode };
               
               using (FormPayment formPayment = new (1, 0, trInvoiceHeader))
               {
                  if (formPayment.ShowDialog(this) == DialogResult.OK)
                  {
                     //efMethods.UpdateInvoiceIsCompleted(trInvoiceHeader.InvoiceHeaderId);
                     LoadPaymentHeaders();
                  }
               }
            }
         }
      }

      private void bBI_MakePayment_ItemClick(object sender, ItemClickEventArgs e)
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
                     LoadPaymentHeaders();
                  }
               }
            }
         }
      }

      private void bBI_ExportXlsx_ItemClick(object sender, ItemClickEventArgs e)
      {
         gV_PaymentHeaderList.ExportToXlsx(@"C:\Users\Public\Desktop\PaymentHeaderList.xlsx");
      }

      private void gV_PaymentHeaderList_ColumnFilterChanged(object sender, EventArgs e)
      {
         GridView view = sender as GridView;

         if (view.SelectedRowsCount > 0)
            trPaymentHeader = view.GetFocusedRow() as TrPaymentHeader;
         else
            trPaymentHeader = null;
      }

      private void gV_PaymentHeaderList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
      {
         GridView view = sender as GridView;
         if (view.SelectedRowsCount > 0)
            trPaymentHeader = view.GetFocusedRow() as TrPaymentHeader;
         else
            trPaymentHeader = null;
      }
   }
}