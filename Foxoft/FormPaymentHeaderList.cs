using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormPaymentHeaderList : RibbonForm
    {
        subContext dbContext;
        string processCode { get; set; }
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

            gV_PaymentHeaderList.OptionsFind.FindMode = FindMode.Always;
        }

        public FormPaymentHeaderList(string processCode)
           : this()
        {
            string storeCode = Authorization.StoreCode;
            this.processCode = processCode;

            LoadPaymentHeaders();
            gV_PaymentHeaderList.ActiveFilterString =
                $"[{nameof(TrPaymentHeader.StoreCode)}] = '{storeCode}'";
        }

        private void LoadPaymentHeaders()
        {
            dbContext = new subContext();

            IQueryable<TrPaymentHeader> trPaymentHeaders = dbContext.TrPaymentHeaders;
            CriteriaToExpressionConverter converter = new CriteriaToExpressionConverter();
            IQueryable<TrPaymentHeader> filteredData =
                trPaymentHeaders.AppendWhere(new CriteriaToExpressionConverter(), gV_PaymentHeaderList.ActiveFilterCriteria)
                as IQueryable<TrPaymentHeader>;

            List<TrPaymentHeader> headerList = filteredData
                .Include(x => x.TrPaymentLines)
                .Include(x => x.DcCurrAcc)
                .Where(x => x.IsMainTF == true)
                .Where(x => x.ProcessCode == processCode)
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
                    PaymentKindId = x.PaymentKindId,
                    CompanyCode = x.CompanyCode,
                    OfficeCode = x.OfficeCode,
                    StoreCode = x.StoreCode,
                    PosterminalId = x.PosterminalId,
                    IsCompleted = x.IsCompleted,
                    IsLocked = x.IsLocked,
                    IsSent = x.IsSent,
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

            if (view.SelectedRowsCount > 0)
            {
                if (e.KeyCode == Keys.C && e.Control)
                {
                    object cellValue = view.GetFocusedValue();
                    Clipboard.SetText(cellValue.ToString());
                }
            }
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
                byte[] bytes = CustomExtensions.GetProductTypeArray(trInvoiceHeader.ProcessCode);

                FormInvoice formInvoice = new(trInvoiceHeader.ProcessCode, null, bytes, null, invoiceHeaderId);
                FormERP formERP = Application.OpenForms[nameof(FormERP)] as FormERP;
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

                FormPaymentDetail formaPayment = new(trInvoiceHeader.PaymentHeaderId);
                FormERP formERP = Application.OpenForms[nameof(FormERP)] as FormERP;
                formaPayment.MdiParent = formERP;
                formaPayment.WindowState = FormWindowState.Maximized;
                //formaPayment.Show();
                if (formERP.parentRibbonControl.MergedPages.Count > 0)
                    formERP.parentRibbonControl.SelectedPage = formERP.parentRibbonControl.MergedPages[0];
            }
        }

        private void bBI_ReceivePayment_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FormCurrAccList formCurrAcc = new(new byte[] { 0 }, false))
            {
                if (formCurrAcc.ShowDialog(this) == DialogResult.OK)
                {
                    TrInvoiceHeader trInvoiceHeader = new() { CurrAccCode = formCurrAcc.dcCurrAcc.CurrAccCode };

                    using (FormPayment formPayment = new(PaymentType.Cash, 0, trInvoiceHeader, new[] { PaymentType.Cash, PaymentType.Cashless, PaymentType.Bonus, PaymentType.Commission }, new DcLoyaltyCard() { }))
                    {
                        bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, formPayment.Name);
                        if (!currAccHasClaims)
                        {
                            MessageBox.Show(Resources.Common_AccessDenied);
                            return;
                        }
                        else
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
        }

        private void bBI_MakePayment_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FormCurrAccList formCurrAcc = new(new byte[] { 0 }, false))
            {
                if (formCurrAcc.ShowDialog(this) == DialogResult.OK)
                {
                    TrInvoiceHeader trInvoiceHeader = new() { CurrAccCode = formCurrAcc.dcCurrAcc.CurrAccCode };

                    using (FormPayment formPayment = new(PaymentType.Cash, -1, trInvoiceHeader, new[] { PaymentType.Cash, PaymentType.Cashless, PaymentType.Bonus, PaymentType.Commission }, new DcLoyaltyCard() { }))
                    {
                        bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, formPayment.Name);
                        if (!currAccHasClaims)
                        {
                            MessageBox.Show(Resources.Common_AccessDenied);
                            return;
                        }
                        else
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
        }

        private void bBI_ExportXlsx_ItemClick(object sender, ItemClickEventArgs e)
        {
            CustomExtensions.ExportToExcel(this, $@"PaymentHeaderList.xlsx", gC_PaymentHeaderList);
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
