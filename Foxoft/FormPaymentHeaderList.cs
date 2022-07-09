using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Utils;
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
    public partial class FormPaymentHeaderList : DevExpress.XtraBars.Ribbon.RibbonForm
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
            this.gV_PaymentHeaderList.RestoreLayoutFromStream(stream, option);

            LoadPaymentHeaders();
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
                                                           .OrderByDescending(x => x.DocumentDate)
                                                           .Select(x => new TrPaymentHeader
                                                           {
                                                               CurrAccDesc = x.DcCurrAcc.CurrAccDesc,
                                                               TotalPayment = x.TrPaymentLines.Sum(x => x.Payment),
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

                trPaymentHeader = view.GetRow(view.FocusedRowHandle) as TrPaymentHeader;

                DialogResult = DialogResult.OK;
            }
        }

        private void gC_PaymentHeaderList_ProcessGridKey(object sender, KeyEventArgs e)
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
            object obj = gV_PaymentHeaderList.GetFocusedRowCellValue(colPaymentHeaderId);

            if (!object.ReferenceEquals(obj, null))
            {
                Guid invoiceHeaderId = Guid.Parse(obj.ToString());
                TrPaymentHeader trInvoiceHeader = efMethods.SelectPaymentHeader(invoiceHeaderId);

                FormPaymentDetail formaPayment = new FormPaymentDetail(trInvoiceHeader.PaymentHeaderId);
                FormERP formERP = Application.OpenForms["FormERP"] as FormERP;
                formaPayment.MdiParent = formERP;
                formaPayment.WindowState = FormWindowState.Maximized;
                formaPayment.Show();
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
                            LoadPaymentHeaders();
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
                            LoadPaymentHeaders();
                        }
                    }
                }
            }
        }
    }
}