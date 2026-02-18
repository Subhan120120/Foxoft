using DevExpress.Data.Filtering;
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
using System.IO;
using System.Text;

namespace Foxoft
{
    public partial class FormInvoiceLineList : XtraForm
    {
        EfMethods efMethods = new();
        public TrInvoiceLine trInvoiceLine { get; set; }
        subContext dbContext;
        public string[] processCode { get; set; }

        public FormInvoiceLineList()
        {
            InitializeComponent();

            byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
            MemoryStream stream = new(byteArray);
            OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
            gV_InvoiceLineList.RestoreLayoutFromStream(stream, option);

            gV_InvoiceLineList.OptionsFind.FindMode = FindMode.Always;
        }

        public FormInvoiceLineList(string[] processCode)
            : this()
        {
            this.processCode = processCode;
            LoadInvoiveHeaders();

            string storeCode = Authorization.StoreCode;
            gV_InvoiceLineList.ActiveFilterString =
                $"[{nameof(TrInvoiceHeader.StoreCode)}] = '{storeCode}'";

            gV_InvoiceLineList.BestFitColumns();
        }

        private void LoadInvoiveHeaders()
        {
            dbContext = new subContext();

            IQueryable<TrInvoiceLine> trInvoiceLines = dbContext.TrInvoiceLines;
            IQueryable<TrInvoiceLine> filteredData =
                trInvoiceLines.AppendWhere(new CriteriaToExpressionConverter(), gV_InvoiceLineList.ActiveFilterCriteria) as IQueryable<TrInvoiceLine>;

            var headerList = filteredData
                        .Include(x => x.TrInvoiceHeader)
                        .ThenInclude(x => x.DcCurrAcc)
                        .Where(x => processCode.Contains(x.TrInvoiceHeader.ProcessCode) && x.TrInvoiceHeader.IsReturn == false)
                        .OrderByDescending(x => x.TrInvoiceHeader.DocumentDate)
                        .ThenByDescending(x => x.TrInvoiceHeader.DocumentTime)
                        .Select(x => new
                        {
                            x.InvoiceLineId,
                            x.ProductCode,
                            x.DcProduct.ProductDesc,
                            Qty = Math.Abs(x.QtyIn - x.QtyOut),
                            x.Price,
                            x.CurrencyCode,
                            x.PriceLoc,
                            x.SerialNumberCode,
                            x.TrInvoiceHeader.DcCurrAcc.CurrAccDesc,
                            x.InvoiceHeaderId,
                            x.TrInvoiceHeader.CreatedDate,
                            x.TrInvoiceHeader.CreatedUserName,
                            x.TrInvoiceHeader.CurrAccCode,
                            x.TrInvoiceHeader.Description,
                            x.TrInvoiceHeader.DocumentDate,
                            x.TrInvoiceHeader.DocumentNumber,
                            x.TrInvoiceHeader.DocumentTime,
                            x.TrInvoiceHeader.IsCompleted,
                            x.TrInvoiceHeader.IsLocked,
                            x.TrInvoiceHeader.PrintCount,
                            x.TrInvoiceHeader.IsReturn,
                            x.TrInvoiceHeader.IsSalesViaInternet,
                            x.TrInvoiceHeader.IsSuspended,
                            x.TrInvoiceHeader.LastUpdatedDate,
                            x.TrInvoiceHeader.LastUpdatedUserName,
                            x.TrInvoiceHeader.OfficeCode,
                            x.TrInvoiceHeader.OperationDate,
                            x.TrInvoiceHeader.OperationTime,
                            x.TrInvoiceHeader.TerminalId,
                            x.TrInvoiceHeader.ProcessCode,
                            x.TrInvoiceHeader.RelatedInvoiceId,
                            x.TrInvoiceHeader.StoreCode,
                            x.TrInvoiceHeader.WarehouseCode,
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
                DialogResult = DialogResult.OK;
            }
        }

        private void gC_InvoiceLineList_ProcessGridKey(object sender, KeyEventArgs e)
        {
            ColumnView view = (sender as GridControl).FocusedView as ColumnView;
            if (view is null) return;

            if (view.SelectedRowsCount > 0 && view.FocusedRowHandle >= 0)
            {
                trInvoiceLine = new();
                trInvoiceLine.InvoiceLineId = (Guid)view.GetFocusedRowCellValue(colInvoiceLineId);
                trInvoiceLine.InvoiceHeaderId = (Guid)view.GetFocusedRowCellValue(colInvoiceHeaderId);
            }

            if (e.KeyCode == Keys.Enter && trInvoiceLine is not null)
                DialogResult = DialogResult.OK;

            if (e.KeyCode == Keys.Escape)
                Close();

            if (view.SelectedRowsCount > 0)
            {
                if (e.KeyCode == Keys.C && e.Control)
                {
                    object cellValue = view.GetFocusedValue();
                    Clipboard.SetText(cellValue?.ToString());
                }
            }
        }

        private void gV_InvoiceLineList_ColumnFilterChanged(object sender, EventArgs e)
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
                gV.OptionsFind.ShowFindButton = false;
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

        private void BtnEdit_FindBarcode_EditValueChanged(object sender, EventArgs e)
        {
            ButtonEdit buttonEdit = (ButtonEdit)sender;
            string barcode = buttonEdit.EditValue?.ToString();

            string productCode = efMethods.SelectProductByBarcode(barcode)?.ProductCode;

            if (string.IsNullOrEmpty(barcode))
            {
                gV_InvoiceLineList.ActiveFilterCriteria = new BinaryOperator(colProductCode.FieldName, "");
            }
            else
            {
                gV_InvoiceLineList.ActiveFilterCriteria = new BinaryOperator(colProductCode.FieldName, productCode);
            }

            gV_InvoiceLineList.RefreshData();
        }
    }
}
