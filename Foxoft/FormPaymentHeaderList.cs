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

namespace Foxoft
{
    public partial class FormPaymentHeaderList : XtraForm
    {
        subContext dbContext = new subContext();
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

                                          lV_trPaymentHeaders.ForEach(x => x.TotalNetAmount = x.TrPaymentLines.Sum(x => x.Payment));

                                          trPaymentHeadersBindingSource.DataSource = lV_trPaymentHeaders.ToBindingList();

                                      }, TaskScheduler.FromCurrentSynchronizationContext());

            gV_PaymentHeaderList.BestFitColumns();
        }

        //private void gV_PaymentHeaderList_DoubleClick(object sender, EventArgs e)
        //{
        //    DXMouseEventArgs ea = e as DXMouseEventArgs;
        //    GridView view = sender as GridView;
        //    GridHitInfo info = view.CalcHitInfo(ea.Location);
        //    if ((info.InRow || info.InRowCell) && view.FocusedRowHandle >= 0)
        //    {
        //        string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();

        //        trPaymentHeader = view.GetRow(view.FocusedRowHandle) as TrPaymentHeader;

        //        DialogResult = DialogResult.OK;
        //    }
        //}

        private void gC_PaymentHeaderList_ProcessGridKey(object sender, KeyEventArgs e)
        {
            ColumnView view = (sender as GridControl).FocusedView as ColumnView;
            if (view == null) return;
            if (e.KeyCode == Keys.Enter && view.SelectedRowsCount > 0)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void repoHLE_DocNum_ButtonClick(object sender, ButtonPressedEventArgs e)
        {

            object objHeaderId = gV_PaymentHeaderList.GetFocusedRowCellValue(colInvoiceHeaderId);

            if (!object.ReferenceEquals(objHeaderId, null))
            {
                Guid trInvoiceHeaderId = Guid.Parse(objHeaderId.ToString());
                FormInvoice formInvoice = new FormInvoice("RP", 1, 2, trInvoiceHeaderId);
                formInvoice.MdiParent = this;
                formInvoice.WindowState = FormWindowState.Maximized;
                formInvoice.Show();
            }

        }

        private void repoHLE_DocNum_OpenLink(object sender, OpenLinkEventArgs e)
        {
            object objHeaderId = gV_PaymentHeaderList.GetFocusedRowCellValue(colInvoiceHeaderId);

            if (!object.ReferenceEquals(objHeaderId, null))
            {
                Guid trInvoiceHeaderId = Guid.Parse(objHeaderId.ToString());
                FormInvoice formInvoice = new FormInvoice("RP", 1, 2, trInvoiceHeaderId);
                formInvoice.MdiParent = this;
                formInvoice.WindowState = FormWindowState.Maximized;
                formInvoice.Show();
            }
        }

        private void repoHLE_DocNum_Click(object sender, EventArgs e)
        {
            object objHeaderId = gV_PaymentHeaderList.GetFocusedRowCellValue(colInvoiceHeaderId);

            if (!object.ReferenceEquals(objHeaderId, null))
            {
                Guid trInvoiceHeaderId = Guid.Parse(objHeaderId.ToString());
                FormInvoice formInvoice = new FormInvoice("RP", 1, 2, trInvoiceHeaderId);
                formInvoice.MdiParent = this;
                formInvoice.WindowState = FormWindowState.Maximized;
                formInvoice.Show();
            }
        }

        private void repoHLE_DocNum_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            object objHeaderId = gV_PaymentHeaderList.GetFocusedRowCellValue(colInvoiceHeaderId);

            if (!object.ReferenceEquals(objHeaderId, null))
            {
                Guid trInvoiceHeaderId = Guid.Parse(objHeaderId.ToString());
                FormInvoice formInvoice = new FormInvoice("RP", 1, 2, trInvoiceHeaderId);
                formInvoice.MdiParent = this;
                formInvoice.WindowState = FormWindowState.Maximized;
                formInvoice.Show();
            }
        }

        private void repositoryItemHypertextLabel1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            MessageBox.Show("btn klik");
        }

        private void repositoryItemHypertextLabel1_OpenHyperlink(object sender, OpenHyperlinkEventArgs e)
        {

            MessageBox.Show("openHyperLink");
        }

        private void repositoryItemHyperLinkEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {

            MessageBox.Show("btn klik");
        }

        private void repositoryItemHyperLinkEdit1_OpenLink(object sender, OpenLinkEventArgs e)
        {

            MessageBox.Show("openLink");
        }
    }
}