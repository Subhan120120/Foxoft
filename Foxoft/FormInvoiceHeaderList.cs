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
using DevExpress.Data.Filtering;
using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;
using System.Collections.Generic;

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
            IQueryable<TrInvoiceHeader> trInvoiceHeaders = dbContext.TrInvoiceHeaders;

            CriteriaToExpressionConverter converter = new CriteriaToExpressionConverter();
            IQueryable<TrInvoiceHeader> filteredData = trInvoiceHeaders.AppendWhere(converter, gV_InvoiceHeaderList.ActiveFilterCriteria) as IQueryable<TrInvoiceHeader>;


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
            //                    x.CurrAccDesc = x.DcCurrAcc.CurrAccDesc;
            //                });

            //                trInvoiceHeadersBindingSource.DataSource = lV_invoiceHeader.ToBindingList();

            //            }, TaskScheduler.FromCurrentSynchronizationContext());

            filteredData.Include(x => x.DcCurrAcc)
                        .Include(x => x.TrInvoiceLines)
                        .Where(x => x.ProcessCode == processCode)
                        .OrderByDescending(x => x.DocumentDate)
                        .Load();
            LocalView<TrInvoiceHeader> lV_invoiceHeader = dbContext.TrInvoiceHeaders.Local;

            lV_invoiceHeader.ForEach(x =>
            {
                x.TotalNetAmount = x.TrInvoiceLines.Sum(x => x.NetAmount);
                x.CurrAccDesc = x.DcCurrAcc.CurrAccDesc;
            });

            trInvoiceHeadersBindingSource.DataSource = lV_invoiceHeader.ToBindingList();

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
            LoadInvoiveHeaders();

        }
    }
}