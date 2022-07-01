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

namespace Foxoft
{
    public partial class FormPaymentHeaderList : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        subContext dbContext = new subContext();
        EfMethods efMethods = new EfMethods();
        public TrPaymentHeader trPaymentHeader { get; set; }

        public FormPaymentHeaderList()
        {
            InitializeComponent();

            //byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
            //MemoryStream stream = new MemoryStream(byteArray);
            //OptionsLayoutGrid option = new OptionsLayoutGrid() { StoreAllOptions = true, StoreAppearance = true };
            //this.gV_PaymentHeaderList.RestoreLayoutFromStream(stream, option);

            LoadPaymentHeaders();

            string dateTime = DateTime.Now.ToString("yyyy-MM-dd"); ;

            gV_PaymentHeaderList.ActiveFilterString = "([OperationDate] >= #" + dateTime + "# AND [OperationDate] <= #" + dateTime + "#)";
        }

        private void LoadPaymentHeaders()
        {
            dbContext.TrPaymentHeaders.Include(x => x.TrPaymentLines)
                                      .Include(x => x.TrInvoiceHeader)
                                      .Include(x => x.DcCurrAcc)
                                      .OrderByDescending(x => x.OperationDate)
                                      .LoadAsync()
                                      .ContinueWith(loadTask =>
                                      {
                                          LocalView<TrPaymentHeader> lV_trPaymentHeaders = dbContext.TrPaymentHeaders.Local;

                                          lV_trPaymentHeaders.ForEach(x => x.TotalNetAmountLoc = x.TrPaymentLines.Sum(x => Math.Round(x.PaymentLoc / (decimal)1.703, 2)));

                                          trPaymentHeadersBindingSource.DataSource = lV_trPaymentHeaders.ToBindingList();

                                          gV_PaymentHeaderList.BestFitColumns();

                                      }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void gV_PaymentHeaderList_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if ((info.InRow || info.InRowCell) && view.FocusedRowHandle >= 0)
            {
                string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();

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
            if (isFirstPaint)
            {
                if (!gV_PaymentHeaderList.FindPanelVisible)
                    gV_PaymentHeaderList.ShowFindPanel();
                gV_PaymentHeaderList.ShowFindPanel();
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