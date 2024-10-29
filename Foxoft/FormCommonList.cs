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
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Text;

namespace Foxoft
{
    public partial class FormCommonList<T> : RibbonForm
        where T : class
    {
        EfMethods efMethods = new();
        AdoMethods adoMethods = new();
        T Entity { get; set; }
        subContext dbContext;
        public object Value_Id;
        public object FocusToValue_Id;
        public object Value_2;
        string ProcessCode;
        string[] SpecialColumnsHide;
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

        public FormCommonList(string processCode, string fieldName_Id, object value_Id, string[] specialColumnsHide = null)
            : this(processCode, fieldName_Id)
        {
            this.Value_Id = value_Id;
            this.FocusToValue_Id = value_Id;
            this.SpecialColumnsHide = specialColumnsHide;
        }

        public FormCommonList(string processCode, string fieldName_Id, object value_Id, string fieldName_2, object value_2, string[] specialColumnsHide = null) // 2 eded deyisen olanlar ucun
            : this(processCode, fieldName_Id, value_Id, specialColumnsHide)
        {
            this.Col_2.FieldName = fieldName_2;
            this.Value_2 = value_2;
        }

        private void FormCommonList_Load(object sender, EventArgs e)
        {
            FocusValue(Value_Id);
        }

        private void FormCommonList_Activated(object sender, EventArgs e)
        {
            //AutoFocus FindPanel
            if (gridView1 is not null)
            {
                gridView1.FindPanelVisible = false;
                if (!gridView1.FindPanelVisible)
                    gridControl1.BeginInvoke(new Action(gridView1.ShowFindPanel));
            }

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
            LoadData();

            if (gridView1.FocusedRowHandle >= 0)
            {
                if (Value_Id != null)
                {
                    FocusValue(Value_Id);
                    Entity = gridView1.GetFocusedRow() as T;
                }
                else
                {
                    Value_Id = gridView1.GetFocusedRowCellValue(Col_Id)?.ToString();
                    if (Value_Id is not null)
                        Entity = gridView1.GetFocusedRow() as T;
                }
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
            gridView1.FocusedRowChanged -= gridView1_FocusedRowChanged;
            dbContext = new subContext();

            Func<T, bool> pred = String.IsNullOrEmpty(Col_2.FieldName) ? _ => true : ConvertToPredicate(Col_2.FieldName, Value_2);

            IList<T> data = dbContext.Set<T>().Where(pred).ToList();
            bindingSource1.DataSource = data;

            gridView1.BestFitColumns();

            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
        }

        private void InvisibleSomeColumns(GridColumn column)
        {
            string[] hiddenColumns = new[] { "CreatedUserName", "CreatedDate", "LastUpdatedUserName", "LastUpdatedDate" };

            if (hiddenColumns.Contains(column.FieldName))
                column.Visible = false;

            if (SpecialColumnsHide is not null)
                if (SpecialColumnsHide.Contains(column.FieldName))
                    column.Visible = false;
        }

        private void AddUnboundColumns(GridColumn column)
        {
            GridColumn gridColumn = new();
            gridColumn.OptionsColumn.AllowEdit = false;
            gridColumn.OptionsColumn.ReadOnly = true;

            if (column.FieldName == nameof(DcProduct.ProductCode))
            {
                if (gridView1.Columns[nameof(DcProduct.ProductDesc)] is null)
                {
                    gridColumn.Caption = ReflectionExt.GetDisplayName<DcProduct>(x => x.ProductDesc);
                    gridColumn.FieldName = nameof(DcProduct.ProductDesc);
                    gridColumn.UnboundDataType = typeof(string);
                    gridView1.Columns.Add(gridColumn);
                }
            }
            else if (column.FieldName == nameof(DcDiscount.DiscountId))
            {
                if (gridView1.Columns[nameof(DcDiscount.DiscountDesc)] is null)
                {
                    gridColumn.Caption = ReflectionExt.GetDisplayName<DcDiscount>(x => x.DiscountDesc);
                    gridColumn.FieldName = nameof(DcDiscount.DiscountDesc);
                    gridColumn.UnboundDataType = typeof(string);
                    gridView1.Columns.Add(gridColumn);
                }
            }
            else if (column.FieldName == nameof(DcReport.ReportId))
            {
                if (gridView1.Columns[nameof(DcReport.ReportName)] is null)
                {
                    gridColumn.Caption = ReflectionExt.GetDisplayName<DcReport>(x => x.ReportName);
                    gridColumn.FieldName = nameof(DcReport.ReportName);
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
            {
                UpdateGridViewData();
                FocusValue(formProduct.Value_Id?.ToString());
            }
        }

        private void FocusValue(object value)
        {
            int rowHandle = gridView1.LocateByValue(0, Col_Id, value);
            if (rowHandle != GridControl.InvalidRowHandle)
                gridView1.FocusedRowHandle = rowHandle;
        }

        private void BBI_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!String.IsNullOrEmpty(Value_Id?.ToString()))
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

        private Func<T, bool> ConvertToPredicate(string propName, object value)
        {
            var param = Expression.Parameter(typeof(T), "x");
            MemberExpression member = Expression.Property(param, propName);
            UnaryExpression memberAsObject = Expression.Convert(member, typeof(object));
            //var convertedValue = Convert.ChangeType(value, member.Type);

            object convertedValue;
            if (string.IsNullOrEmpty(value?.ToString()))
            {
                if (member.Type.IsValueType && Nullable.GetUnderlyingType(member.Type) == null)
                    convertedValue = Activator.CreateInstance(member.Type);
                else
                    convertedValue = null;
            }
            else
                convertedValue = Convert.ChangeType(value, member.Type);

            ConstantExpression constant = Expression.Constant(convertedValue, member.Type);
            var expression = Expression.Equal(member, constant);
            var lambda = Expression.Lambda<Func<T, bool>>(expression, param);
            var predicate = lambda.Compile();
            return predicate;
        }

        private void bBI_ExportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CustomExtensions.ExportToExcel(this, Text, gridControl1);

            //XtraSaveFileDialog sFD = new();
            //sFD.Filter = "Excel Faylı|*.xlsx";
            //sFD.Title = "Excel Faylı Yadda Saxla";
            //sFD.FileName = $@"\{Text}.xlsx";
            //sFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //sFD.DefaultExt = "*.xlsx";

            //var fileName = Invoke((Func<string>)(() =>
            //{
            //    if (sFD.ShowDialog() == DialogResult.OK)
            //    {
            //        gridView1.ExportToXlsx(sFD.FileName);

            //        if (XtraMessageBox.Show(this, "Açmaq istəyirsiz?", "Diqqət", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //        {
            //            Process p = new Process();
            //            p.StartInfo = new ProcessStartInfo(sFD.FileName) { UseShellExecute = true };
            //            p.Start();
            //        }

            //        return "Ok";
            //    }
            //    else
            //        return "Fail";
            //}));
        }

        private void gridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            int rowInd = view.GetRowHandle(e.ListSourceRowIndex);

            if (e.Column.FieldName == nameof(DcDiscount.DiscountDesc) && e.IsGetData)
            {
                object value = view.GetRowCellValue(rowInd, nameof(DcDiscount.DiscountId));

                if (value is not null)
                {
                    DcDiscount dcDiscount = efMethods.SelectDiscount(Convert.ToInt32(value));
                    e.Value = dcDiscount?.DiscountDesc;
                }
            }
            else if (e.Column.FieldName == nameof(DcProduct.ProductDesc) && e.IsGetData)
            {
                object value = view.GetRowCellValue(rowInd, nameof(DcProduct.ProductCode));

                if (value is not null)
                {
                    DcProduct dcProduct = efMethods.SelectProduct(value.ToString());
                    e.Value = dcProduct?.ProductDesc;
                }
            }
            else if (e.Column.FieldName == nameof(DcReport.ReportName) && e.IsGetData)
            {
                object value = view.GetRowCellValue(rowInd, nameof(DcReport.ReportId));

                if (value is not null)
                {
                    DcReport report = efMethods.SelectReport(Convert.ToInt32(value));
                    e.Value = report?.ReportName;
                }
            }
        }

        private void gridView1_RowLoaded(object sender, RowEventArgs e)
        {
        }
    }
}
