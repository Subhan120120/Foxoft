using DevExpress.Data.Linq.Helpers;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormPriceListHeaderList : XtraForm
    {
        public TrPriceListHeader trPriceListHeader { get; set; }
        subContext dbContext;

        public FormPriceListHeaderList()
        {
            InitializeComponent();

            byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
            MemoryStream stream = new(byteArray);
            OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
            gV_priceListHeader.RestoreLayoutFromStream(stream, option);

            //gridView1.OptionsFind.FindMode = FindMode.Always;

            UpdateGridViewData();
            gV_priceListHeader.BestFitColumns();
        }

        private void UpdateGridViewData()
        {
            int fr = gV_priceListHeader.FocusedRowHandle;

            LoadPriceListHeaders();

            if (fr > 0)
                gV_priceListHeader.FocusedRowHandle = fr;
            else
                gV_priceListHeader.MoveLast();

            if (gV_priceListHeader.FocusedRowHandle >= 0)
                trPriceListHeader = gV_priceListHeader.GetFocusedRow() as TrPriceListHeader;
            else
                trPriceListHeader = null;
        }

        private void LoadPriceListHeaders()
        {
            dbContext = new subContext();

            IList<TrPriceListHeader> trPriceListHeaders = dbContext.TrPriceListHeaders
                        .OrderByDescending(x => x.DocumentDate)
                        .ThenByDescending(x => x.DocumentTime)
                        .ToList();

            trPriceListBindingSource.DataSource = trPriceListHeaders;
        }

        private void gV_priceListHeader_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle >= 0)
                trPriceListHeader = view.GetFocusedRow() as TrPriceListHeader;
            else
                trPriceListHeader = null;
        }

        private void gV_priceListHeader_DoubleClick(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (trPriceListHeader is not null)
                DialogResult = DialogResult.OK;
        }

        private void myGridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            ColumnView view = (sender as GridControl).FocusedView as ColumnView;
            if (view == null) return;

            if (trPriceListHeader is not null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DialogResult = DialogResult.OK;
                }

                if (e.KeyCode == Keys.C && e.Control)
                {
                    //if (view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn) != null && view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString() != String.Empty)
                    //   Clipboard.SetText(view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString());
                    //else
                    //   MessageBox.Show("The value in the selected cell is null or empty!");

                    string cellValue = gV_priceListHeader.GetFocusedValue().ToString();
                    Clipboard.SetText(cellValue);
                    e.Handled = true;
                }

            }
        }

        private void gV_priceListHeader_ColumnFilterChanged(object sender, EventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle >= 0)
                trPriceListHeader = view.GetFocusedRow() as TrPriceListHeader;
            else
                trPriceListHeader = null;
        }
    }
}
