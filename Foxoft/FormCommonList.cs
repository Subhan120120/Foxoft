using DevExpress.Utils;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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
        public string id_Value;
        string processCode;
        GridColumn col_Id = new();

        public FormCommonList(string idFieldName, string processCode)
        {
            InitializeComponent();

            dbContext = new subContext();
            var mapping = dbContext.Model.FindEntityType(typeof(T));
            Text = mapping.GetTableName();

            BBI_New.ImageOptions.SvgImage = svgImageCollection1["add"];
            BBI_Edit.ImageOptions.SvgImage = svgImageCollection1["edit"];
            bBI_Delete.ImageOptions.SvgImage = svgImageCollection1["delete"];
            bBI_Refresh.ImageOptions.SvgImage = svgImageCollection1["refresh"];
            BBI_query.ImageOptions.SvgImage = svgImageCollection1["queryedit"];
            bBI_ExportExcel.ImageOptions.SvgImage = svgImageCollection1["sendxlsx"];

            //LoadLayout();

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
            //else
            //    gridView1.MoveLast();

            if (gridView1.FocusedRowHandle >= 0)
                entity = gridView1.GetFocusedRow() as T;
            else
                entity = null;
        }

        private void LoadData()
        {
            dbContext = new subContext();

            dbContext.Set<T>().Load();

            bindingSource1.DataSource = dbContext.Set<T>().Local.ToBindingList();

            gridView1.Columns.ToList().ForEach(column =>
            {
                if ((column.FieldName.StartsWith("Tr") && column.FieldName.EndsWith("s"))
                || column.FieldName.StartsWith("Dc"))
                    gridView1.Columns.Remove(column);
            });

            gridView1.BestFitColumns();
        }

        //private void LoadDataByQuery()
        //{
        //    object dataSource = null;

        //    DcReport dcReport = efMethods.SelectReportByName(typeof(T).Name);
        //    if (dcReport is not null)
        //    {
        //        if (!String.IsNullOrEmpty(dcReport.ReportQuery))
        //        {
        //            string query = CustomExtensions.AddTop(dcReport.ReportQuery);
        //            DataTable dt = adoMethods.SqlGetDt(query);
        //            if (dt.Rows.Count > 0)
        //                dataSource = dt;
        //        }
        //    }

        //    bindingSource1.DataSource = dataSource;

        //    if (gridView1.FocusedRowHandle >= 0)
        //    {
        //        object idValue = gridView1.GetFocusedRowCellValue(col_Id);
        //        if (idValue is not null)
        //            entity = gridView1.GetFocusedRow() as T;
        //    }
        //    else
        //        entity = null;

        //    gridView1.BestFitColumns();
        //    gridView1.MakeRowVisible(gridView1.FocusedRowHandle);
        //}


        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
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
            if (entity is not null)
                DialogResult = DialogResult.OK;
        }

        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            ColumnView view = (sender as GridControl).FocusedView as ColumnView;
            if (view == null) return;

            if (entity is not null)
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

                    string cellValue = view.GetFocusedValue().ToString();
                    Clipboard.SetText(cellValue);
                    e.Handled = true;
                }

            }
        }

        private void gridView1_ColumnFilterChanged(object sender, EventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle >= 0)
                entity = view.GetFocusedRow() as T;
            else
                entity = null;
        }

        private void BBI_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormCommon<T> formProduct = new(col_Id.FieldName, true, processCode);
            if (formProduct.ShowDialog(this) == DialogResult.OK)
                UpdateGridViewData();
        }

        private void BBI_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (id_Value is not null)
            {
                FormCommon<T> formProduct = new(col_Id.FieldName, id_Value);

                if (formProduct.ShowDialog(this) == DialogResult.OK)
                    UpdateGridViewData();
            }
            else
                MessageBox.Show("Sətir Seçilməyib");
        }

        private void BBI_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var redicate = ConvertToPredicate(col_Id.FieldName, id_Value);

            if (dbContext.Set<T>().Any(redicate))
            {
                if (XtraMessageBox.Show("Silmek Isteyirsiz? \n " + id_Value, "Diqqet", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    dbContext.Set<T>().Remove(entity);
                    dbContext.SaveChanges();

                    UpdateGridViewData();
                }
            }
            else
                XtraMessageBox.Show("Sətir Seçilməyib");
        }

        private void BBI_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpdateGridViewData();
        }

        public static string AsString(object obj)
        {
            return obj?.ToString();
        }

        private Func<T, bool> ConvertToPredicate(string propName, string value)
        {
            var param = Expression.Parameter(typeof(T));
            MemberExpression member = Expression.Property(param, propName);
            var asString = this.GetType().GetMethod("AsString");
            var stringMember = Expression.Call(asString, Expression.Convert(member, typeof(object)));
            ConstantExpression constant = Expression.Constant(value);
            var expression = Expression.Equal(stringMember, constant);
            var lambda = Expression.Lambda(expression, param);
            var predicate = (Func<T, bool>)lambda.Compile();
            return predicate;
        }

        private void bBI_ExportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraSaveFileDialog sFD = new();
            sFD.Filter = "Excel Faylı|*.xlsx";
            sFD.Title = "Excel Faylı Yadda Saxla";
            sFD.FileName = $@"\{Text}.xlsx";
            sFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            sFD.DefaultExt = "*.xlsx";

            var fileName = Invoke((Func<string>)(() =>
            {
                if (sFD.ShowDialog() == DialogResult.OK)
                {
                    gridView1.ExportToXlsx(sFD.FileName);

                    if (XtraMessageBox.Show(this, "Açmaq istəyirsiz?", "Diqqət", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Process p = new Process();
                        p.StartInfo = new ProcessStartInfo(sFD.FileName) { UseShellExecute = true };
                        p.Start();
                    }

                    return "Ok";
                }
                else
                    return "Fail";
            }));
        }

        private void gridView1_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            var a = e.RelationIndex;
            var b = e.RowHandle;
        }
    }
}
