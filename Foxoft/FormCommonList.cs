using DevExpress.ClipboardSource.SpreadsheetML;
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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        T Entity { get; set; }
        subContext dbContext;
        public string Value_Id;
        public string Value_2;
        string ProcessCode;
        GridColumn Col_Id = new();
        GridColumn Col_2 = new();

        public FormCommonList(string processCode, string fieldName_Id)
        {
            InitializeComponent();
            Text = ((DisplayAttribute)typeof(T).GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault())?.Name;

            BBI_New.ImageOptions.SvgImage = svgImageCollection1["add"];
            BBI_Edit.ImageOptions.SvgImage = svgImageCollection1["edit"];
            bBI_Delete.ImageOptions.SvgImage = svgImageCollection1["delete"];
            bBI_Refresh.ImageOptions.SvgImage = svgImageCollection1["refresh"];
            BBI_query.ImageOptions.SvgImage = svgImageCollection1["queryedit"];
            bBI_ExportExcel.ImageOptions.SvgImage = svgImageCollection1["sendxlsx"];
            BBI_Quit.ImageOptions.SvgImage = svgImageCollection1["delete"];

            LoadLayout();

            Col_Id.FieldName = fieldName_Id;
            this.ProcessCode = processCode;
        }

        public FormCommonList(string processCode, string fieldName_Id, string value_Id)
            : this(processCode, fieldName_Id)
        {
            this.Value_Id = value_Id;
        }

        public FormCommonList(string processCode, string fieldName_Id, string value_Id, string fieldName_2, string value_2)
            : this(processCode, fieldName_Id, value_Id)
        {
            this.Col_2.FieldName = fieldName_2;
            this.Value_2 = value_2;
        }

        private void FormCommonList_Load(object sender, EventArgs e)
        {
            int rowHandle = gridView1.LocateByValue(0, Col_Id, Value_Id);
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
            {
                Value_Id = gridView1.GetFocusedRowCellValue(Col_Id)?.ToString();
                if (Value_Id is not null)
                    Entity = gridView1.GetFocusedRow() as T;
            }
            else
            {
                Value_Id = null;
                Entity = null;
            }

            gridView1.Columns.ToList().ForEach(column =>
           {
               RemoveSomeColumns(column);
               InvisibleSomeColumns(column);
               AddUnboundColumns(column);
           });
        }

        private void LoadData()
        {
            dbContext = new subContext();

            Func<T, bool> pred = String.IsNullOrEmpty(Col_2.FieldName) ? _ => true : ConvertToPredicate(Col_2.FieldName, Value_2);

            //dbContext.Set<T>().Where(pred).AsQueryable().Load();
            //bindingSource1.DataSource = dbContext.Set<T>().Local.ToBindingList();

            IList<T> data = dbContext.Set<T>().Where(pred).ToList();
            bindingSource1.DataSource = data;

            gridView1.BestFitColumns();
        }

        private static void InvisibleSomeColumns(GridColumn column)
        {
            string[] hiddenColumns = new[] { "CreatedUserName", "CreatedDate", "LastUpdatedUserName", "LastUpdatedDate" };

            if (hiddenColumns.Contains(column.FieldName))
                column.Visible = false;
        }

        private void AddUnboundColumns(GridColumn column)
        {
            GridColumn gridColumn = new GridColumn();
            gridColumn.OptionsColumn.AllowEdit = false;
            gridColumn.OptionsColumn.ReadOnly = true;

            if (column.FieldName == "ProductCode")
            {
                if (gridView1.Columns["ProductDesc"] is null)
                {
                    gridColumn.Caption = ReflectionExtensions.GetPropertyDisplayName<DcProduct>(x => x.ProductDesc);
                    gridColumn.FieldName = "ProductDesc";
                    gridColumn.UnboundDataType = typeof(string);
                    gridView1.Columns.Add(gridColumn);
                }
            }

            else if (column.FieldName == "DiscountId")
            {
                if (gridView1.Columns["DiscountDesc"] is null)
                {
                    gridColumn.Caption = ReflectionExtensions.GetPropertyDisplayName<DcDiscount>(x => x.DiscountDesc);
                    gridColumn.FieldName = "DiscountDesc";
                    gridColumn.UnboundDataType = typeof(string);
                    gridView1.Columns.Add(gridColumn);
                }
            }

            gridColumn.VisibleIndex = column.VisibleIndex + 1;
        }

        private void RemoveSomeColumns(GridColumn column)
        {
            dbContext = new subContext();

            var tableNames = dbContext.Model.GetEntityTypes().Select(t => t.GetTableName()).Distinct().ToList();
            var typeNames = dbContext.Model.GetEntityTypes().Select(t => t.ClrType.Name).ToList();

            if (tableNames.Contains(column.FieldName) || typeNames.Contains(column.FieldName)) // relation table adlari silinsin
                gridView1.Columns.Remove(column);
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
                Value_Id = view.GetFocusedRowCellValue(Col_Id)?.ToString();
                if (Value_Id is not null)
                    Entity = view.GetFocusedRow() as T;
            }
            else
            {
                Value_Id = null;
                Entity = null;
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (Value_Id is not null)
                DialogResult = DialogResult.OK;
        }

        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            ColumnView view = (sender as GridControl).FocusedView as ColumnView;
            if (view == null) return;

            if (Value_Id is not null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DialogResult = DialogResult.OK;
                }

                if (e.KeyCode == Keys.C && e.Control)
                {
                    string cellValue = view.GetFocusedValue()?.ToString();
                    if (!String.IsNullOrEmpty(cellValue))
                        Clipboard.SetText(cellValue);
                    e.Handled = true;
                }

            }
        }

        private void gridView1_ColumnFilterChanged(object sender, EventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle >= 0)
            {
                Value_Id = view.GetFocusedRowCellValue(Col_Id)?.ToString();
                if (Value_Id is not null)
                    Entity = view.GetFocusedRow() as T;
            }
            else
            {
                Value_Id = null;
                Entity = null;
            }
        }

        private void BBI_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Value_Id = null;
            Entity = null;

            FormCommon<T> formProduct = new(ProcessCode, true, Col_Id.FieldName, "", Col_2.FieldName, Value_2);
            if (formProduct.ShowDialog(this) == DialogResult.OK)
                UpdateGridViewData();
        }

        private void BBI_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Value_Id is not null)
            {
                FormCommon<T> formProduct = new(ProcessCode, false, Col_Id.FieldName, Value_Id, Col_2.FieldName, Value_2);

                if (formProduct.ShowDialog(this) == DialogResult.OK)
                    UpdateGridViewData();
            }
            else
                MessageBox.Show("Sətir Seçilməyib");
        }

        private void BBI_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var redicate = ConvertToPredicate(Col_Id.FieldName, Value_Id);

            if (dbContext.Set<T>().Any(redicate))
            {
                if (XtraMessageBox.Show("Silmek Isteyirsiz? \n " + Value_Id, "Diqqet", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    dbContext.Set<T>().Remove(Entity);
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

        private void gridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            int rowInd = view.GetRowHandle(e.ListSourceRowIndex);

            if (e.Column.FieldName == "DiscountDesc" && e.IsGetData)
            {
                object value = view.GetRowCellValue(rowInd, "DiscountId");

                if (value is not null)
                {
                    DcDiscount dcDiscount = efMethods.SelectDiscount(Convert.ToInt32(value));
                    e.Value = dcDiscount?.DiscountDesc;
                }
            }
            else if (e.Column.FieldName == "ProductDesc" && e.IsGetData)
            {
                object value = view.GetRowCellValue(rowInd, "ProductCode");

                if (value is not null)
                {
                    DcProduct dcProduct = efMethods.SelectProduct(value.ToString());
                    e.Value = dcProduct?.ProductDesc;
                }
            }
        }

        private void gridView1_RowLoaded(object sender, RowEventArgs e)
        {
        }
    }
}
