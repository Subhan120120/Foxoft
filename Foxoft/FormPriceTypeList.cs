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
using Foxoft.Migrations;
using DevExpress.XtraBars.Ribbon;
using DevExpress.Map.Kml.Model;

namespace Foxoft
{
    public partial class FormPriceTypeList : RibbonForm
    {
        EfMethods efMethods = new();
        public DcPriceType dcPriceType { get; set; }
        subContext dbContext;
        public string priceTypeCode;

        public FormPriceTypeList()
        {
            InitializeComponent();

            byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
            MemoryStream stream = new(byteArray);
            OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
            gV_priceType.RestoreLayoutFromStream(stream, option);

            //gridView1.OptionsFind.FindMode = FindMode.Always;

        }
        public FormPriceTypeList(string priceTypeCode)
            : this()
        {
            this.priceTypeCode = priceTypeCode;
        }

        private void FormPriceTypeList_Load(object sender, EventArgs e)
        {
            int rowHandle = gV_priceType.LocateByValue(0, colPriceTypeCode, priceTypeCode);
            if (rowHandle != GridControl.InvalidRowHandle)
                gV_priceType.FocusedRowHandle = rowHandle;
        }

        private void FormPriceTypeList_Activated(object sender, EventArgs e)
        {
            UpdateGridViewData();
        }

        private void UpdateGridViewData()
        {
            int fr = gV_priceType.FocusedRowHandle;

            LoadPriceTypes();

            if (fr > 0)
                gV_priceType.FocusedRowHandle = fr;
            else
                gV_priceType.MoveLast();

            if (gV_priceType.FocusedRowHandle >= 0)
                dcPriceType = gV_priceType.GetFocusedRow() as DcPriceType;
            else
                dcPriceType = null;
        }

        private void LoadPriceTypes()
        {
            dbContext = new subContext();

            IList<DcPriceType> dcPriceTypes = dbContext.DcPriceTypes
                        .ToList();

            trPriceTypeBindingSource.DataSource = dcPriceTypes;

            gV_priceType.BestFitColumns();
        }

        private void gV_priceType_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle >= 0)
                dcPriceType = view.GetFocusedRow() as DcPriceType;
            else
                dcPriceType = null;
        }

        private void gV_priceType_DoubleClick(object sender, EventArgs e)
        {
            if (dcPriceType is not null)
                DialogResult = DialogResult.OK;
        }

        private void myGridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            ColumnView view = (sender as GridControl).FocusedView as ColumnView;
            if (view == null) return;

            if (dcPriceType is not null)
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

                    string cellValue = gV_priceType.GetFocusedValue().ToString();
                    Clipboard.SetText(cellValue);
                    e.Handled = true;
                }

            }
        }

        private void gV_priceType_ColumnFilterChanged(object sender, EventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle >= 0)
                dcPriceType = view.GetFocusedRow() as DcPriceType;
            else
                dcPriceType = null;
        }

        private void BBI_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dcPriceType = new DcPriceType();
            FormPriceType form = new(true);
            if (form.ShowDialog(this) == DialogResult.OK)
                UpdateGridViewData();
        }

        private void BBI_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dcPriceType is not null)
            {
                FormPriceType form = new(dcPriceType.PriceTypeCode);
                if (form.ShowDialog(this) == DialogResult.OK)
                    UpdateGridViewData();
            }
        }

        private void BBI_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (efMethods.PriceTypeExist(dcPriceType.PriceTypeCode))
            {
                if (XtraMessageBox.Show("Silmek Isteyirsiz? \n " + dcPriceType.PriceTypeDesc, "Diqqet", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    efMethods.DeletePriceType(dcPriceType);

                    LoadPriceTypes();
                }
            }
            else
                XtraMessageBox.Show("Silinmeli olan faktura yoxdur");
        }

        private void BBI_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpdateGridViewData();
        }
    }
}
