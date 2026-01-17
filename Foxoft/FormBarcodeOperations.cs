using DevExpress.DataAccess.Excel;
using DevExpress.DataAccess.Native.Excel;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraReports;
using Foxoft.Migrations;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Tokens;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;

namespace Foxoft
{
    public partial class FormBarcodeOperations : RibbonForm
    {
        private TrBarcodeOperationHeader trBarcodeOperationHeader;
        private subContext dbContext;
        private EfMethods efMethods = new();
        private bool _isLoading;
        private bool _isSaving;

        public FormBarcodeOperations()
        {
            InitializeComponent();

            trBarcodeOperationLinesBindingSource.DataMember = nameof(TrBarcodeOperationHeader.TrBarcodeOperationLines);

            dbContext = new subContext();

            colProductCode.ColumnEdit = gridControl1.AddProductCodeButtonEdit();
            colBarcodeTypeCode.ColumnEdit = gridControl1.AddBarcodeTypeButtonEdit();

            gridControl1.DataSource = trBarcodeOperationLinesBindingSource;

            LoadData(null);
        }

        private void FormBarcodeOperations_Load(object sender, EventArgs e)
        {

        }

        private void LoadData(int? headerId)
        {
            dbContext ??= new subContext();
            _isLoading = true;

            try
            {
                if (headerId.HasValue)
                {
                    trBarcodeOperationHeader = dbContext.TrBarcodeOperationHeaders
                        .Include(x => x.TrBarcodeOperationLines)
                        .Single(x => x.Id == headerId.Value);
                }
                else
                {
                    trBarcodeOperationHeader = new TrBarcodeOperationHeader
                    {
                        Name = "New",
                        TrBarcodeOperationLines = new BindingList<TrBarcodeOperationLine>()
                    };

                    dbContext.TrBarcodeOperationHeaders.Add(trBarcodeOperationHeader);
                }

                trBarcodeOperationHeaderBindingSource.DataSource = trBarcodeOperationHeader;
            }
            finally
            {
                _isLoading = false;
            }
        }

        private void GridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (_isLoading) return;
            SaveAll(); // saves header + lines
        }

        private void IdButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (FormCommonList<TrBarcodeOperationHeader> form = new("", nameof(TrBarcodeOperationHeader.Id)))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (form.Value_Id is not null)
                    {
                        LoadData(Convert.ToInt32(form.Value_Id));
                    }
                }
            }
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var line = (TrBarcodeOperationLine)gridView1.GetRow(e.RowHandle);
            if (line == null) return;

            if (line.Qty == 0) line.Qty = 1;

            // Default barcode type
            if (string.IsNullOrEmpty(line.BarcodeTypeCode))
                line.BarcodeTypeCode = "EAN13";

            // Header context-də deyilsə, ilk line zamanı add et
            if (dbContext.Entry(trBarcodeOperationHeader).State == EntityState.Detached)
                dbContext.TrBarcodeOperationHeaders.Add(trBarcodeOperationHeader);

            line.TrBarcodeOperationHeader = trBarcodeOperationHeader;

            if (dbContext.Entry(line).State == EntityState.Detached)
                dbContext.TrBarcodeOperationLines.Add(line);
        }


        private void BBI_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_isSaving) return;

            // Əgər əvvəlki header-də line var idisə, saxla
            if (HasAnyLine())
                SaveAll();

            CreateNewHeader();
        }

        private void CreateNewHeader()
        {
            _isLoading = true;

            try
            {
                dbContext?.Dispose();
                dbContext = new subContext();

                trBarcodeOperationHeader = new TrBarcodeOperationHeader
                {
                    Name = "New",
                    TrBarcodeOperationLines = new BindingList<TrBarcodeOperationLine>()
                };

                trBarcodeOperationHeaderBindingSource.DataSource = trBarcodeOperationHeader;
                trBarcodeOperationLinesBindingSource.DataSource = trBarcodeOperationHeader.TrBarcodeOperationLines;

                gridView1.Focus();
            }
            finally
            {
                _isLoading = false;
            }
        }


        private bool HasAnyLine()
        {
            return trBarcodeOperationHeader?.TrBarcodeOperationLines?
                .Any(l => dbContext.Entry(l).State != EntityState.Deleted) == true;
        }


        private void TrBarcodeOperationHeaderBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            SaveHeader();
        }

        private void BBI_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_isLoading || _isSaving) return;

            // Heç nə seçilməyibsə, sadəcə yeni sənəd aç
            if (trBarcodeOperationHeader == null)
            {
                CreateNewHeader();
                return;
            }

            // Hələ DB-yə yazılmayıbsa -> discard et, DB-yə toxunma
            if (trBarcodeOperationHeader.Id == 0)
            {
                var r0 = XtraMessageBox.Show(
                    "This document is not saved yet. Discard it?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (r0 != DialogResult.Yes) return;

                CreateNewHeader();
                return;
            }

            // DB-də var -> sil
            var r = XtraMessageBox.Show(
                $"Delete document #{trBarcodeOperationHeader.Id} ?\nAll lines will be deleted too.",
                "Confirm delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r != DialogResult.Yes) return;

            try
            {
                _isSaving = true;

                // UI editləri bitir
                gridView1.CloseEditor();
                gridView1.UpdateCurrentRow();
                trBarcodeOperationLinesBindingSource.EndEdit();
                trBarcodeOperationHeaderBindingSource.EndEdit();

                // ən sağlamı: yenidən DB-dən Include ilə çək, sonra sil
                var header = dbContext.TrBarcodeOperationHeaders
                    .Include(x => x.TrBarcodeOperationLines)
                    .Single(x => x.Id == trBarcodeOperationHeader.Id);

                // sonra header sil
                dbContext.TrBarcodeOperationHeaders.Remove(header);

                dbContext.SaveChanges();

                // Siləndən sonra yeni boş sənəd aç
                CreateNewHeader();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Delete Error");
            }
            finally
            {
                _isSaving = false;
            }
        }

        private void SaveHeader()
        {
            if (_isLoading || _isSaving) return;

            // Sadəcə UI edit bitirsin, DB save eləməsin
            trBarcodeOperationHeaderBindingSource.EndEdit();
        }


        private void SaveAll()
        {
            if (_isLoading || _isSaving) return;

            try
            {
                _isSaving = true;

                gridView1.CloseEditor();
                gridView1.UpdateCurrentRow();
                trBarcodeOperationLinesBindingSource.EndEdit();
                trBarcodeOperationHeaderBindingSource.EndEdit();

                var hasAnyLine = trBarcodeOperationHeader?.TrBarcodeOperationLines?
                    .Any(l => dbContext.Entry(l).State != EntityState.Deleted) == true;

                if (!hasAnyLine)
                    return; // line yoxdursa DB-yə heç nə yazma

                // header yeni idisə, burada insert olacaq
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Save Error");
            }
            finally
            {
                _isSaving = false;
            }
        }

        private void BBI_BarcodePreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DcReport dcReport = efMethods.SelectReportByName("Report_Embedded_BarcodeOperation");

            if (dcReport == null)
            {
                MessageBox.Show("Report_Embedded_BarcodeOperation query is not found on databasa");
                return;
            }

            int id = trBarcodeOperationHeader.Id;

            string filter = "";
            if (id > 0)
                filter = "BarcodeOperationHeaderId = " + id + " ";

            FormReportPreview form = new(dcReport.ReportQuery, filter, dcReport);
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void BBI_ImportFromXLSX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                OpenFileDialog dialog = new();
                dialog.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|All files (*.*)|*.*";
                dialog.Title = Resources.Form_PriceListDetail_OpenFileDialog_Title;

                DialogResult dr = dialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ImportFromExcel(dialog.FileName);
                }
            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }
        }


        private void ImportFromExcel(string fileName)
        {
            ExcelDataSource excelDataSource = new();
            excelDataSource.FileName = fileName;

            ExcelWorksheetSettings excelWorksheetSettings = new(0);
            //ExcelWorksheetSettings excelWorksheetSettings = new(0, "A1:A10000");
            //excelWorksheetSettings.WorksheetName = "10QK";

            ExcelSourceOptions excelOptions = new();
            excelOptions.ImportSettings = excelWorksheetSettings;
            excelOptions.SkipHiddenRows = false;
            excelOptions.SkipHiddenColumns = false;
            excelOptions.UseFirstRowAsHeader = true;
            excelDataSource.SourceOptions = excelOptions;

            excelDataSource.Fill();

            DataTable dt = new();
            dt = ToDataTableFromExcelDataSource(excelDataSource);

            string errorCodes = "";

            foreach (DataRow row in dt.Rows)
            {
                string captionProductCode = ReflectionExt.GetDisplayName<TrBarcodeOperationLine>(x => x.ProductCode);
                string captionBarcode = ReflectionExt.GetDisplayName<TrBarcodeOperationLine>(x => x.Barcode);
                string captionQty = ReflectionExt.GetDisplayName<TrBarcodeOperationLine>(x => x.Qty);

                string productCode = row[captionProductCode].ToString();
                string barcode = row[captionBarcode].ToString();

                if (string.IsNullOrEmpty(productCode))
                    continue;

                if (string.IsNullOrEmpty(barcode))
                    continue;

                DcProduct product = efMethods.SelectProduct(productCode, new byte[] { 1 });
                if (product is null)
                {
                    errorCodes += captionProductCode + ": " + row[captionProductCode].ToString() + "Bu Kodda Məhsul Tapılmadı" + "\n";
                    continue;
                }

                object objInvoiceHeadId = gridView1.GetRowCellValue(GridControl.NewItemRowHandle, colId);
                if (objInvoiceHeadId is null) // Check InitNewRow
                    gridView1.AddNewRow();

                gridView1.SetRowCellValue(GridControl.NewItemRowHandle, colProductCode, product.ProductCode);

                foreach (DataColumn column in dt.Columns)
                {
                    try
                    {
                        if (column.ColumnName == captionQty)
                            gridView1.SetRowCellValue(GridControl.NewItemRowHandle, colQty, row[captionQty].ToString());

                        if (column.ColumnName == captionBarcode)
                            gridView1.SetRowCellValue(GridControl.NewItemRowHandle, colBarcode, row[captionBarcode].ToString());
                    }
                    catch (ArgumentException ae)
                    {
                        MessageBox.Show(
                            $"{Resources.Form_PriceListDetail_Message_ImportErrorCode}\n{ae.Message}",
                            Resources.Form_PriceListDetail_Message_ImportErrorCaption);
                    }
                }

                gridView1.UpdateCurrentRow();
            }

            if (!string.IsNullOrEmpty(errorCodes))
                MessageBox.Show(
                    Resources.Form_PriceListDetail_Message_ValueNotFound + " \n" + errorCodes,
                    Resources.Common_ErrorTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        public DataTable ToDataTableFromExcelDataSource(ExcelDataSource excelDataSource)
        {
            IList list = ((IListSource)excelDataSource).GetList();
            DevExpress.DataAccess.Native.Excel.DataView dataView = (DevExpress.DataAccess.Native.Excel.DataView)list;
            List<PropertyDescriptor> props = dataView.Columns.ToList<PropertyDescriptor>();

            DataTable dt = new();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                dt.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (ViewRow item in list)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                dt.Rows.Add(values);
            }
            return dt;
        }


        private void BBI_ExportToXLSX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using var sFD = new XtraSaveFileDialog
            {
                Filter = Resources.Common_File_ExcelFilter,
                Title = Resources.Common_File_SaveExcel,
                FileName = "Barcode Operations",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                DefaultExt = "*.xlsx",
            };

            if (sFD.ShowDialog() == DialogResult.OK)
            {
                gridView1.ExportToXlsx(sFD.FileName);

                if (XtraMessageBox.Show(
                        this,
                        Resources.Form_ReportGrid_Message_OpenExportedFileQuestion,
                        Resources.Common_Attention,
                        MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    using var p = new Process
                    {
                        StartInfo = new ProcessStartInfo(sFD.FileName) { UseShellExecute = true }
                    };
                    p.Start();
                }
            }
        }
    }
}
