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

namespace Foxoft
{
    public partial class FormInvoiceHeaderList : XtraForm
    {
        EfMethods efMethods = new EfMethods();
        public TrInvoiceHeader trInvoiceHeader { get; set; }
        subContext dbContext = new subContext();
        //public string processCode { get; set; }

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
            //this.processCode = processCode;

            dbContext.TrInvoiceHeaders.Include(x => x.DcCurrAcc)
                                      .Where(x => x.ProcessCode == processCode)
                                      .OrderByDescending(x => x.DocumentDate)
                                      .LoadAsync()
                                      .ContinueWith(loadTask => trInvoiceHeadersBindingSource.DataSource = dbContext.TrInvoiceHeaders.Local.ToBindingList(), System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());

            //gC_InvoiceHeaderList.DataSource = efMethods.SelectInvoiceHeadersByProcessCode(processCode);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if ((info.InRow || info.InRowCell) && view.FocusedRowHandle >= 0)
            {
                //info.RowHandle
                string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();

                trInvoiceHeader = view.GetRow(view.FocusedRowHandle) as TrInvoiceHeader;

                DialogResult = DialogResult.OK;
            }
        }

        private void gC_InvoiceHeaderList_ProcessGridKey(object sender, KeyEventArgs e)
        {
            ColumnView view = (sender as GridControl).FocusedView as ColumnView;
            if (view == null) return;
            if (e.KeyCode == Keys.Enter && view.SelectedRowsCount > 0)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}