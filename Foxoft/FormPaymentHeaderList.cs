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
    public partial class FormPaymentHeaderList : XtraForm
    {
        subContext dbContext = new subContext();
        EfMethods efMethods = new EfMethods();
        public TrPaymentHeader trPaymentHeader { get; set; }

        public FormPaymentHeaderList()
        {
            InitializeComponent();

            byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
            MemoryStream stream = new MemoryStream(byteArray);
            OptionsLayoutGrid option = new OptionsLayoutGrid() { StoreAllOptions = true, StoreAppearance = true };
            this.gV_PaymentHeaderList.RestoreLayoutFromStream(stream, option);


            dbContext.TrPaymentHeaders.Include(x => x.TrPaymentLines)
                                      .Include(x => x.TrInvoiceHeader)
                                      .Include(x => x.DcCurrAcc)
                                      .OrderByDescending(x => x.OperationDate)
                                      .LoadAsync()
                                      .ContinueWith(loadTask =>
                                      {
                                          LocalView<TrPaymentHeader> lV_trPaymentHeaders = dbContext.TrPaymentHeaders.Local;

                                          lV_trPaymentHeaders.ForEach(x => x.TotalNetAmountLoc = x.TrPaymentLines.Sum(x => x.PaymentLoc));

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

        private void repositoryItemHyperLinkEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {

            MessageBox.Show("btn klik");
        }

        private void repoHLE_InvoiceNumber_OpenLink(object sender, OpenLinkEventArgs e)
        {
            object obj = gV_PaymentHeaderList.GetFocusedRowCellValue(colInvoiceHeaderId);

            if (!object.ReferenceEquals(obj, null))
            {
                Guid invoiceHeaderId = Guid.Parse(obj.ToString());
                TrInvoiceHeader trInvoiceHeader = efMethods.SelectInvoiceHeader(invoiceHeaderId);

                this.Close();

                FormInvoice formInvoice = new FormInvoice(trInvoiceHeader.ProcessCode, 1, 2, invoiceHeaderId);
                FormERP formERP = Application.OpenForms["FormERP"] as FormERP;
                formInvoice.MdiParent = formERP;
                formInvoice.WindowState = FormWindowState.Maximized;
                formInvoice.Show();
                formERP.parentRibbonControl.SelectedPage = formERP.parentRibbonControl.MergedPages[0];
            }
        }
    }
}