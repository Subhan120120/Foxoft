using DevExpress.Utils;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormCommonList<T> : RibbonForm
        where T : class
    {
        EfMethods efMethods = new();
        AdoMethods adoMethods = new();
         T entity { get; set; }
        subContext dbContext;
         string id_Value;
         string processCode;
        GridColumn col_Id = new();

        public FormCommonList(string idFieldName, string processCode)
        {
            InitializeComponent();

            LoadLayout();

            col_Id.FieldName = idFieldName;
        }

        public FormCommonList(string idFieldName, string processCode, string id_Value)
            : this(idFieldName, processCode)
        {
            this.id_Value = id_Value;
            this.processCode = processCode;
        }

        private void FormCommonList_Load(object sender, EventArgs e)
        {
            int rowHandle = gridView1.LocateByValue(0, col_Id, id_Value);
            if (rowHandle != GridControl.InvalidRowHandle)
                gridView1.FocusedRowHandle = rowHandle;
        }

        private void FormCommonList_Activated(object sender, EventArgs e)
        {
            UpdateGridViewData();
        }

        private void LoadLayout()
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
            MemoryStream stream = new(byteArray);
            OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
            gridView1.RestoreLayoutFromStream(stream, option);
        }

        private void UpdateGridViewData()
        {
            int fr = gridView1.FocusedRowHandle;

            LoadData();

            if (fr > 0)
                gridView1.FocusedRowHandle = fr;
            else
                gridView1.MoveLast();

            if (gridView1.FocusedRowHandle >= 0)
                entity = gridView1.GetFocusedRow() as T;
            else
                entity = default(T);
        }

        private void LoadDataByQuery()
        {
            object dataSource = null;

            DcReport dcReport = efMethods.SelectReportByName(typeof(T).Name);
            if (dcReport is not null)
            {
                if (!String.IsNullOrEmpty(dcReport.ReportQuery))
                {
                    string query = CustomExtensions.AddTop(dcReport.ReportQuery);
                    DataTable dt = adoMethods.SqlGetDt(query);
                    if (dt.Rows.Count > 0)
                        dataSource = dt;
                }
            }

            bindingSource1.DataSource = dataSource;

            if (gridView1.FocusedRowHandle >= 0)
            {
                object idValue = gridView1.GetFocusedRowCellValue(col_Id);
                if (idValue is not null)
                    entity = gridView1.GetFocusedRow() as T;
            }
            else
                entity = null;

            gridView1.BestFitColumns();
            gridView1.MakeRowVisible(gridView1.FocusedRowHandle);
        }


        private void LoadData()
        {
            dbContext = new subContext();

            DbSet<T> allEntities = dbContext.Set<T>();

            IList<T> dcPriceTypes = allEntities
                        .ToList();

            bindingSource1.DataSource = dcPriceTypes;

            gridView1.BestFitColumns();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle >= 0)
            {
                id_Value = view.GetFocusedRowCellValue(col_Id)?.ToString();
                if (id_Value is not null)
                {
                    entity = view.GetFocusedRow() as T;
                }
            }
            else
                entity = null;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {

        }

        private void gridView1_ColumnFilterChanged(object sender, EventArgs e)
        {

        }

        private void BBI_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormCommon<T> formProduct = new(col_Id.FieldName, true, processCode);
            if (formProduct.ShowDialog(this) == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void BBI_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (entity is not null)
            {
                FormCommon<T> formProduct = new(col_Id.FieldName, id_Value);

                if (formProduct.ShowDialog(this) == DialogResult.OK)
                {
                    int fr = gridView1.FocusedRowHandle;

                    LoadData();

                    gridView1.FocusedRowHandle = fr;
                }
            }
            else
                MessageBox.Show("Sətir Seçilməyib");
        }

        private void BBI_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BBI_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
