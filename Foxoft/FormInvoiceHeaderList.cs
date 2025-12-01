using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Foxoft
{
    public partial class FormInvoiceHeaderList : XtraForm
    {
        EfMethods efMethods = new();
        public TrInvoiceHeader trInvoiceHeader { get; set; }
        public Guid? RelatedInvoiceId { get; set; }
        public bool? isComplated;
        subContext dbContext;
        public string processCode { get; set; }


        public FormInvoiceHeaderList()
        {
            InitializeComponent();

            byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
            MemoryStream stream = new(byteArray);
            OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
            gV_InvoiceHeaderList.RestoreLayoutFromStream(stream, option);

            gV_InvoiceHeaderList.OptionsFind.FindMode = FindMode.Always;
        }

        public FormInvoiceHeaderList(string processCode)
            : this()
        {
            this.processCode = processCode;
        }

        public FormInvoiceHeaderList(string processCode, Guid? relatedInvoiceId)
            : this(processCode)
        {
            RelatedInvoiceId = relatedInvoiceId;

            LoadInvoiveHeaders();
        }

        public FormInvoiceHeaderList(string processCode, bool? isComplated)
            : this(processCode)
        {
            this.isComplated = isComplated;

            LoadInvoiveHeaders();
        }

        private void LoadInvoiveHeaders()
        {
            dbContext = new subContext();

            IQueryable<TrInvoiceHeader> trInvoiceHeaders = dbContext.TrInvoiceHeaders;
            IQueryable<TrInvoiceHeader> filteredData = trInvoiceHeaders.AppendWhere(new CriteriaToExpressionConverter(), gV_InvoiceHeaderList.ActiveFilterCriteria) as IQueryable<TrInvoiceHeader>;

            List<TrInvoiceHeader> headerList = filteredData.Include(x => x.TrInvoiceLines)
                        .Include(x => x.DcCurrAcc)
                        .Where(x => RelatedInvoiceId == null ? true : x.RelatedInvoiceId == RelatedInvoiceId)
                        .Where(x => isComplated == null ? true : x.IsCompleted == isComplated)
                        .Where(x => x.ProcessCode == processCode && x.IsMainTF == true)
                        .OrderByDescending(x => x.DocumentDate).ThenByDescending(x => x.DocumentTime)
                        .Select(x => new TrInvoiceHeader
                        {
                            CurrAccDesc = x.DcCurrAcc.CurrAccDesc,
                            TotalNetAmount = x.TrInvoiceLines.Sum(l => l.NetAmountLoc),
                            InvoiceHeaderId = x.InvoiceHeaderId,
                            CreatedDate = x.CreatedDate,
                            CreatedUserName = x.CreatedUserName,
                            CurrAccCode = x.CurrAccCode,
                            CustomsDocumentNumber = x.CustomsDocumentNumber,
                            Description = x.Description,
                            DocumentDate = x.DocumentDate,
                            DocumentNumber = x.DocumentNumber,
                            DocumentTime = x.DocumentTime,
                            FiscalPrintedState = x.FiscalPrintedState,
                            IsCompleted = x.IsCompleted,
                            IsLocked = x.IsLocked,
                            PrintCount = x.PrintCount,
                            IsReturn = x.IsReturn,
                            IsOpen = x.IsOpen,
                            IsSent = x.IsSent,
                            IsSalesViaInternet = x.IsSalesViaInternet,
                            IsSuspended = x.IsSuspended,
                            LastUpdatedDate = x.LastUpdatedDate,
                            LastUpdatedUserName = x.LastUpdatedUserName,
                            OfficeCode = x.OfficeCode,
                            OperationDate = x.OperationDate,
                            OperationTime = x.OperationTime,
                            PosTerminalId = x.PosTerminalId,
                            ProcessCode = x.ProcessCode,
                            RelatedInvoiceId = x.RelatedInvoiceId,
                            StoreCode = x.StoreCode,
                            WarehouseCode = x.WarehouseCode,
                            ToWarehouseCode = x.ToWarehouseCode,
                            IsMainTF = x.IsMainTF
                        })
                        .ToList();

            trInvoiceHeadersBindingSource.DataSource = headerList;

            string storeCode = Authorization.StoreCode;
            gV_InvoiceHeaderList.ActiveFilterString =
                $"[{nameof(TrInvoiceHeader.StoreCode)}] = '{storeCode}'";

            gV_InvoiceHeaderList.BestFitColumns();
        }

        private void gV_TrInvoiceHeaderList_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if ((info.InRow || info.InRowCell) && trInvoiceHeader is not null)
                ApproveInvoiceHeader();
        }

        private void ApproveInvoiceHeader()
        {
            bool isOpen = InvoiceIsOpen(trInvoiceHeader.DocumentNumber);

            if (!isOpen)
                DialogResult = DialogResult.OK;
        }

        private bool InvoiceIsOpen(string docNum)
        {
            bool isOpen = false;
            Process[]? processes = Process.GetProcessesByName("Foxoft");
            foreach (Process? process in processes)
            {
                List<WindowInfo> childWindows = WindowsAPI.GetMDIChildWindowsOfProcess(process);
                foreach (WindowInfo? window in childWindows)
                {
                    if (window.Tag == docNum)
                    {
                        isOpen = true;
                        XtraMessageBox.Show(Resources.Form_InvoiceHeaderList_InvoiceIsOpen);
                    }
                }
            }

            return isOpen;
        }

        private void gC_InvoiceHeaderList_ProcessGridKey(object sender, KeyEventArgs e)
        {
            ColumnView view = (sender as GridControl).FocusedView as ColumnView;
            if (view is null) return;

            if (view.SelectedRowsCount > 0)
                trInvoiceHeader = view.GetFocusedRow() as TrInvoiceHeader;

            if (e.KeyCode == Keys.Enter && trInvoiceHeader is not null)
                ApproveInvoiceHeader();

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

        private void gV_InvoiceHeaderList_ColumnFilterChanged(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view.SelectedRowsCount > 0)
                trInvoiceHeader = view.GetFocusedRow() as TrInvoiceHeader;
            else
                trInvoiceHeader = null;
        }

        private void gV_InvoiceHeaderList_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
        }

        private void gV_InvoiceHeaderList_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;

            if (e.RowHandle >= 0)
            {
                object isReturn = view.GetRowCellValue(e.RowHandle, colIsReturn);
                bool bIsReturn = (bool)isReturn;
                if (bIsReturn)
                    e.Appearance.BackColor = Color.MistyRose;

                object isOpen = view.GetRowCellValue(e.RowHandle, colIsOpen);
                object documentNumber = view.GetRowCellValue(e.RowHandle, colDocumentNumber);
                bool bIsOpen = (bool)isOpen;
                string docNum = documentNumber.ToString();

                if (bIsOpen && docNum != Settings.Default.OpenDocNum)
                {
                    //e.Appearance.ForeColor = Color.Red;
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }
            }
        }

        private void gC_InvoiceHeaderList_Paint(object sender, PaintEventArgs e)
        {
        }

        private void gV_InvoiceHeaderList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.SelectedRowsCount > 0)
                trInvoiceHeader = view.GetFocusedRow() as TrInvoiceHeader;
            else
                trInvoiceHeader = null;
        }

        private void FormInvoiceHeaderList_Activated(object sender, EventArgs e)
        {
            //AutoFocus FindPanel
            if (gV_InvoiceHeaderList is not null)
            {
                gV_InvoiceHeaderList.FindPanelVisible = false;
                if (!gV_InvoiceHeaderList.FindPanelVisible)
                    gC_InvoiceHeaderList.BeginInvoke(new Action(gV_InvoiceHeaderList.ShowFindPanel));
            }
        }
    }
}
