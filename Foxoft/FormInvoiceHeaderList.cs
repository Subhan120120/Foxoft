using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormInvoiceHeaderList : XtraForm
    {
        EfMethods efMethods = new EfMethods();
        public TrInvoiceHeader trInvoiceHeader { get; set; }
        subContext dbContext;
        public string processCode { get; set; }

        List<object> filters = new List<object>();

        public FormInvoiceHeaderList()
        {
            InitializeComponent();

            byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
            MemoryStream stream = new MemoryStream(byteArray);
            OptionsLayoutGrid option = new OptionsLayoutGrid() { StoreAllOptions = true, StoreAppearance = true };
            this.gV_InvoiceHeaderList.RestoreLayoutFromStream(stream, option);
        }

        public FormInvoiceHeaderList(string processCode)
            : this()
        {
            this.processCode = processCode;
            LoadInvoiveHeaders();
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

            IQueryable<TrInvoiceHeader> trInvoiceHeaders = dbContext.TrInvoiceHeaders;
            CriteriaToExpressionConverter converter = new CriteriaToExpressionConverter();
            IQueryable<TrInvoiceHeader> filteredData = trInvoiceHeaders.AppendWhere(new CriteriaToExpressionConverter(), gV_InvoiceHeaderList.ActiveFilterCriteria) as IQueryable<TrInvoiceHeader>;


            filteredData.Include(x => x.TrInvoiceLines)
                        .Include(x => x.DcCurrAcc)
                        .Where(x => x.ProcessCode == processCode)
                        .OrderByDescending(x => x.DocumentDate)
                        .Load();
            //.Select(x => new TrInvoiceHeader
            //{
            //    DcCurrAcc = x.DcCurrAcc,
            //    TotalNetAmount = x.TrInvoiceLines.Sum(x => x.NetAmountLoc),
            //    InvoiceHeaderId = x.InvoiceHeaderId,
            //    CreatedDate = x.CreatedDate,
            //    CreatedUserName = x.CreatedUserName,
            //    CurrAccCode = x.CurrAccCode,
            //    CustomsDocumentNumber = x.CustomsDocumentNumber,
            //    Description = x.Description,
            //    DocumentDate = x.DocumentDate,
            //    DocumentNumber = x.DocumentNumber,
            //    DocumentTime = x.DocumentTime,
            //    FiscalPrintedState = x.FiscalPrintedState,
            //    IsCompleted = x.IsCompleted,
            //    IsLocked = x.IsLocked,
            //    IsPrinted = x.IsPrinted,
            //    IsReturn = x.IsReturn,
            //    IsSalesViaInternet = x.IsSalesViaInternet,
            //    IsSuspended = x.IsSuspended,
            //    LastUpdatedDate = x.LastUpdatedDate,
            //    LastUpdatedUserName = x.LastUpdatedUserName,
            //    OfficeCode = x.OfficeCode,
            //    OperationDate = x.OperationDate,
            //    OperationTime = x.OperationTime,
            //    PosTerminalId = x.PosTerminalId,
            //    ProcessCode = x.ProcessCode,
            //    RelatedInvoiceId = x.RelatedInvoiceId,
            //    StoreCode = x.StoreCode,
            //    WarehouseCode = x.WarehouseCode,
            //});

            trInvoiceHeadersBindingSource.DataSource = dbContext.TrInvoiceHeaders.Local.ToBindingList();

            //gC_InvoiceHeaderList.DataSource = efMethods.SelectInvoiceHeadersByProcessCode(processCode);
        }

        private void gV_TrInvoiceHeaderList_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if ((info.InRow || info.InRowCell) && view.FocusedRowHandle >= 0)
            {
                //info.RowHandle
                string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();

                trInvoiceHeader = view.GetRow(view.FocusedRowHandle) as TrInvoiceHeader;

                if (!object.ReferenceEquals(trInvoiceHeader, null))
                    DialogResult = DialogResult.OK;
            }
        }

        private void gC_InvoiceHeaderList_ProcessGridKey(object sender, KeyEventArgs e)
        {
            ColumnView view = (sender as GridControl).FocusedView as ColumnView;
            if (view == null) return;
            if (e.KeyCode == Keys.Enter && view.SelectedRowsCount > 0)
            {
                if (!object.ReferenceEquals(trInvoiceHeader, null))
                    DialogResult = DialogResult.OK;
            }
        }

        private void gV_InvoiceHeaderList_ColumnFilterChanged(object sender, EventArgs e)
        {
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
    }
}