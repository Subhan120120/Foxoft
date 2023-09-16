using DevExpress.Utils;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using Foxoft.Migrations;
using Foxoft.Models;
using Foxoft.Properties;
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
        public T entity { get; set; }
        subContext dbContext;
        public string id_Value;
        GridColumn col_Id = new();

        public FormCommonList(string idFieldName)
        {
            InitializeComponent();

            LoadLayout();

            col_Id.FieldName = idFieldName;
        }

        public FormCommonList(string idFieldName, string id_Value)
            : this(idFieldName)
        {
            this.id_Value = id_Value;
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

        private void LoadData()
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

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
            FormCommon<T> formProduct = new(col_Id.FieldName, true);
            if (formProduct.ShowDialog(this) == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void BBI_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BBI_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BBI_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
