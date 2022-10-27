using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Foxoft
{
   public partial class FormInvoiceLineList : XtraForm
   {
      EfMethods efMethods = new();
      public TrInvoiceLine trInvoiceLine { get; set; }
      subContext dbContext;
      public string processCode { get; set; }

      public FormInvoiceLineList()
      {
         InitializeComponent();

         byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
         MemoryStream stream = new(byteArray);
         OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
         gV_InvoiceLineList.RestoreLayoutFromStream(stream, option);
      }


      public FormInvoiceLineList(string processCode)
          : this()
      {
         this.processCode = processCode;
         LoadInvoiveHeaders();

         string storeCode = Authorization.StoreCode;
         gV_InvoiceLineList.ActiveFilterString = "[StoreCode] = \'" + storeCode + "\'";

         gV_InvoiceLineList.BestFitColumns();
      }

      private void LoadInvoiveHeaders()
      {
         dbContext = new subContext();

         //filteredData
         //            .Include(x => x.DcCurrAcc)
         //            .Include(x => x.TrInvoiceLines)
         //            .Where(x => x.ProcessCode == processCode)
         //            .OrderByDescending(x => x.DocumentDate)
         //            .LoadAsync()
         //            .ContinueWith(loadTask =>
         //            {
         //                LocalView<TrInvoiceHeader> lV_invoiceHeader = dbContext.TrInvoiceHeaders.Local;

         //                lV_invoiceHeader.ForEach(x =>
         //                {
         //                    x.TotalNetAmount = x.TrInvoiceLines.Sum(x => x.NetAmount);
         //                });

         //                trInvoiceHeadersBindingSource.DataSource = lV_invoiceHeader.ToBindingList();

         //            }, TaskScheduler.FromCurrentSynchronizationContext());

         IQueryable<TrInvoiceLine> trInvoiceHeaders = dbContext.TrInvoiceLines;
         CriteriaToExpressionConverter converter = new();
         IQueryable<TrInvoiceLine> filteredData = trInvoiceHeaders.AppendWhere(new CriteriaToExpressionConverter(), gV_InvoiceLineList.ActiveFilterCriteria) as IQueryable<TrInvoiceLine>;


         var headerList = filteredData.Include(x => x.TrInvoiceHeader)
                     .ThenInclude(x => x.DcCurrAcc)
                     .Where(x => x.TrInvoiceHeader.ProcessCode == processCode && x.TrInvoiceHeader.IsReturn == false)
                     .OrderByDescending(x => x.TrInvoiceHeader.DocumentDate).ThenByDescending(x => x.TrInvoiceHeader.DocumentTime)
                     .Select(x => new
                     {
                        InvoiceLineId = x.InvoiceLineId,
                        ProductCode = x.ProductCode,
                        ProductDesc = x.DcProduct.ProductDesc,
                        CurrAccDesc = x.TrInvoiceHeader.DcCurrAcc.CurrAccDesc,
                        InvoiceHeaderId = x.InvoiceHeaderId,
                        CreatedDate = x.TrInvoiceHeader.CreatedDate,
                        CreatedUserName = x.TrInvoiceHeader.CreatedUserName,
                        CurrAccCode = x.TrInvoiceHeader.CurrAccCode,
                        Description = x.TrInvoiceHeader.Description,
                        DocumentDate = x.TrInvoiceHeader.DocumentDate,
                        DocumentNumber = x.TrInvoiceHeader.DocumentNumber,
                        DocumentTime = x.TrInvoiceHeader.DocumentTime,
                        IsCompleted = x.TrInvoiceHeader.IsCompleted,
                        IsLocked = x.TrInvoiceHeader.IsLocked,
                        PrintCount = x.TrInvoiceHeader.PrintCount,
                        IsReturn = x.TrInvoiceHeader.IsReturn,
                        IsSalesViaInternet = x.TrInvoiceHeader.IsSalesViaInternet,
                        IsSuspended = x.TrInvoiceHeader.IsSuspended,
                        LastUpdatedDate = x.TrInvoiceHeader.LastUpdatedDate,
                        LastUpdatedUserName = x.TrInvoiceHeader.LastUpdatedUserName,
                        OfficeCode = x.TrInvoiceHeader.OfficeCode,
                        OperationDate = x.TrInvoiceHeader.OperationDate,
                        OperationTime = x.TrInvoiceHeader.OperationTime,
                        PosTerminalId = x.TrInvoiceHeader.PosTerminalId,
                        ProcessCode = x.TrInvoiceHeader.ProcessCode,
                        RelatedInvoiceId = x.TrInvoiceHeader.RelatedInvoiceId,
                        StoreCode = x.TrInvoiceHeader.StoreCode,
                        WarehouseCode = x.TrInvoiceHeader.WarehouseCode,
                     })
                     .ToList();

         trInvoiceHeadersBindingSource.DataSource = headerList;

         //gC_InvoiceHeaderList.DataSource = efMethods.SelectInvoiceHeadersByProcessCode(processCode);
      }

      private void gV_TrInvoiceHeaderList_DoubleClick(object sender, EventArgs e)
      {
         DXMouseEventArgs ea = e as DXMouseEventArgs;
         GridView view = sender as GridView;
         GridHitInfo info = view.CalcHitInfo(ea.Location);
         if ((info.InRow || info.InRowCell) && trInvoiceLine is not null)
         {
            //info.RowHandle
            //string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();

            DialogResult = DialogResult.OK;
         }
      }

      private void gC_InvoiceLineList_ProcessGridKey(object sender, KeyEventArgs e)
      {
         ColumnView view = (sender as GridControl).FocusedView as ColumnView;
         if (view is null) return;

         if (view.SelectedRowsCount > 0)
         {
            trInvoiceLine = new();
            trInvoiceLine.InvoiceLineId = (Guid)view.GetFocusedRowCellValue(colInvoiceLineId);
            trInvoiceLine.InvoiceHeaderId = (Guid)view.GetFocusedRowCellValue(colInvoiceHeaderId);
         }

         if (e.KeyCode == Keys.Enter && trInvoiceLine is not null)
            DialogResult = DialogResult.OK;

         if (e.KeyCode == Keys.Escape)
            Close();
      }

      private void gV_InvoiceLineList_ColumnFilterChanged(object sender, EventArgs e)
      {
         GridView view = sender as GridView;
         if (view.SelectedRowsCount > 0)
         {
            trInvoiceLine = new();
            trInvoiceLine.InvoiceLineId = (Guid)view.GetFocusedRowCellValue(colInvoiceLineId);
            trInvoiceLine.InvoiceHeaderId = (Guid)view.GetFocusedRowCellValue(colInvoiceHeaderId);
         }
         else
            trInvoiceLine = null;

         //LoadInvoiveHeaders();
      }

      private void gV_InvoiceHeaderList_CellValueChanging(object sender, CellValueChangedEventArgs e)
      {
         //if ((sender as GridView).IsFilterRow(e.RowHandle))
         //    LoadInvoiveHeaders();
      }

      private void gV_InvoiceHeaderList_RowStyle(object sender, RowStyleEventArgs e)
      {
         GridView view = sender as GridView;

         if (e.RowHandle >= 0)
         {
            //string col = view.GetRowCellDisplayText(e.RowHandle, isre);
            object isReturn = view.GetRowCellValue(e.RowHandle, colIsReturn);
            bool value = (bool)isReturn;

            if (value)
               e.Appearance.BackColor = Color.MistyRose;
         }
      }

      // AutoFocus FindPanel
      bool isFirstPaint = true;
      private void gC_InvoiceHeaderList_Paint(object sender, PaintEventArgs e)
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

      private void gV_InvoiceLineList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
      {
         GridView view = sender as GridView;
         if (view.SelectedRowsCount > 0 && view.FocusedRowHandle >= 0)
         {
            trInvoiceLine = new();
            trInvoiceLine.InvoiceLineId = (Guid)view.GetFocusedRowCellValue(colInvoiceLineId);
            trInvoiceLine.InvoiceHeaderId = (Guid)view.GetFocusedRowCellValue(colInvoiceHeaderId);
         }
         else
            trInvoiceLine = null;
      }
   }
}