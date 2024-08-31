using DevExpress.Data;
using DevExpress.DataAccess.Excel;
using DevExpress.DataAccess.Native.Excel;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace Foxoft
{
    public partial class FormDiscountCompaniesDetail : RibbonForm
    {
        private TrDiscountCompaniesHeader trDiscountCompaniesHeader;
        private EfMethods efMethods = new();
        private subContext dbContext;
        private Guid DiscountCompaniesHeaderId;

        public FormDiscountCompaniesDetail()
        {
            InitializeComponent();
            colProductDesc.Caption = ReflectionExt.GetDisplayName<DcProduct>(x => x.ProductDesc);
            colProductCost.Caption = ReflectionExt.GetDisplayName<DcProduct>(x => x.ProductCost);

            //StoreCodeLookUpEdit.Properties.DataSource = efMethods.SelectStores();
            repoLUE_CurrencyCode.DataSource = efMethods.SelectCurrencies();

            ClearControlsAddNew();
        }

        public FormDiscountCompaniesDetail(Guid DiscountCompaniesHeaderId)
            : this()
        {
            trDiscountCompaniesHeader = efMethods.SelectDiscountCompaniesHeader(DiscountCompaniesHeaderId);

            if (trDiscountCompaniesHeader is not null)
            {
                LoadDiscountCompanies(trDiscountCompaniesHeader.DiscountCompaniesHeaderId);
            }
        }

        private void ClearControlsAddNew()
        {
            dbContext = new subContext();

            DiscountCompaniesHeaderId = Guid.NewGuid();

            dbContext.TrDiscountCompaniesHeaders.Where(x => x.DiscountCompaniesHeaderId == DiscountCompaniesHeaderId)
                                      .Load();
            trDiscountCompaniesHeadersBindingSource.DataSource = dbContext.TrDiscountCompaniesHeaders.Local.ToBindingList();

            trDiscountCompaniesHeader = trDiscountCompaniesHeadersBindingSource.AddNew() as TrDiscountCompaniesHeader;

            dbContext.TrDiscountCompaniesLines.Include(x => x.DcProduct)
                                    .Where(x => x.DiscountCompaniesHeaderId == trDiscountCompaniesHeader.DiscountCompaniesHeaderId)
                                    .LoadAsync()
                                    .ContinueWith(loadTask => trDiscountCompaniesLinesBindingSource.DataSource = dbContext.TrDiscountCompaniesLines.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());

            dataLayoutControl1.IsValid(out List<string> errorList);

            gV_DiscountCompaniesLine.Focus();
        }

        private void trDiscountCompaniesHeadersBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            TrDiscountCompaniesHeader DiscountCompaniesHeader = new();
            DiscountCompaniesHeader.DiscountCompaniesHeaderId = DiscountCompaniesHeaderId;
            string NewDocNum = efMethods.GetNextDocNum(true, "PL", "DocumentNumber", "TrDiscountCompaniesHeaders", 6);
            DiscountCompaniesHeader.DocumentNumber = NewDocNum;
            DiscountCompaniesHeader.DocumentDate = DateTime.Now;
            DiscountCompaniesHeader.OperationDate = DateTime.Now;
            DiscountCompaniesHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            DiscountCompaniesHeader.OperationTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            DiscountCompaniesHeader.OfficeCode = Authorization.OfficeCode;
            DiscountCompaniesHeader.CreatedUserName = Authorization.CurrAccCode;

            e.NewObject = DiscountCompaniesHeader;
        }

        private void trDiscountCompaniesHeadersBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            trDiscountCompaniesHeader = trDiscountCompaniesHeadersBindingSource.Current as TrDiscountCompaniesHeader;

            if (trDiscountCompaniesHeader != null && dbContext != null && dataLayoutControl1.IsValid(out List<string> errorList))
            {
                int count = efMethods.SelectDiscountCompaniesLines(trDiscountCompaniesHeader.DiscountCompaniesHeaderId).Count;
                if (count > 0)
                    SaveDiscountCompanies();
            }
        }

        private void SaveDiscountCompanies()
        {
            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Daxil Etdiyiniz Məlumatlar Əsaslı Deyil ! \n \n {ex}");
            }
        }

        private void btnEdit_DocNum_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            SelectDocNum();
        }

        private void SelectDocNum()
        {
            using (FormDiscountCompaniesHeaderList form = new())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    trDiscountCompaniesHeader = form.trDiscountCompaniesHeader;
                    if (trDiscountCompaniesHeader is not null)
                    {
                        LoadDiscountCompanies(trDiscountCompaniesHeader.DiscountCompaniesHeaderId);
                    }
                }
            }
        }

        private void LoadDiscountCompanies(Guid DiscountCompaniesHeaderId)
        {
            dbContext = new subContext();

            dbContext.TrDiscountCompaniesHeaders
                                      .Where(x => x.DiscountCompaniesHeaderId == DiscountCompaniesHeaderId).Load();

            LocalView<TrDiscountCompaniesHeader> lV_DiscountCompaniesHeader = dbContext.TrDiscountCompaniesHeaders.Local;

            trDiscountCompaniesHeadersBindingSource.DataSource = lV_DiscountCompaniesHeader.ToBindingList();
            trDiscountCompaniesHeader = trDiscountCompaniesHeadersBindingSource.Current as TrDiscountCompaniesHeader;

            dbContext.TrDiscountCompaniesLines.Include(x => x.DcProduct)
                                    .Where(x => x.DiscountCompaniesHeaderId == DiscountCompaniesHeaderId)
                                    .OrderBy(x => x.CreatedDate)
                                    .LoadAsync()
                                    .ContinueWith(loadTask =>
                                    {
                                        LocalView<TrDiscountCompaniesLine> lV_DiscountCompaniesLine = dbContext.TrDiscountCompaniesLines.Local;
                                        trDiscountCompaniesLinesBindingSource.DataSource = lV_DiscountCompaniesLine.ToBindingList();

                                    }, TaskScheduler.FromCurrentSynchronizationContext());

            dataLayoutControl1.IsValid(out List<string> errorList);

        }

        private void bBI_DeleteDiscountCompanies_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (efMethods.DiscountCompaniesHeaderExist(trDiscountCompaniesHeader.DiscountCompaniesHeaderId))
            {
                if (MessageBox.Show("Silmek Isteyirsiz?", "Diqqet", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    efMethods.DeleteDiscountCompanies(trDiscountCompaniesHeader.DiscountCompaniesHeaderId);

                    ClearControlsAddNew();
                }
            }
            else
                XtraMessageBox.Show("Silinmeli olan faktura yoxdur");
        }

        private void gV_DiscountCompaniesLine_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gV_DiscountCompaniesLine.SetRowCellValue(e.RowHandle, colDiscountCompaniesHeaderId, trDiscountCompaniesHeader.DiscountCompaniesHeaderId);
            gV_DiscountCompaniesLine.SetRowCellValue(e.RowHandle, colDiscountCompaniesLineId, Guid.NewGuid());

            string currencyCode = Settings.Default.AppSetting.LocalCurrencyCode;
            DcProcess dcProcess = efMethods.SelectProcess("PL");
            if (!string.IsNullOrEmpty(dcProcess.CustomCurrencyCode))
                currencyCode = dcProcess.CustomCurrencyCode;
            DcCurrency currency = efMethods.SelectCurrency(currencyCode);
            if (currency is not null)
            {
                gV_DiscountCompaniesLine.SetRowCellValue(e.RowHandle, colCurrencyCode, currency.CurrencyCode);
            }

            //gV_DiscountCompaniesLine.SetRowCellValue(e.RowHandle, colCreatedDate, DateTime.Now);
            //gV_DiscountCompaniesLine.SetRowCellValue(e.RowHandle, colCreatedUserName, Authorization.CurrAccCode);
        }

        private void gC_DiscountCompaniesLine_KeyDown(object sender, KeyEventArgs e)
        {
            GridControl gC = sender as GridControl;
            GridView gV = gC.MainView as GridView;

            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Sətir Silinsin?", "Təsdiqlə", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                gV.DeleteSelectedRows();
            }
        }

        private void gV_DiscountCompaniesLine_RowUpdated(object sender, RowObjectEventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                SaveDiscountCompanies();
            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }
        }

        private void gV_DiscountCompaniesLine_RowDeleted(object sender, RowDeletedEventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                SaveDiscountCompanies();
            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }
        }

        private void bBI_SaveAndClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (trDiscountCompaniesHeader != null && dbContext != null && dataLayoutControl1.IsValid(out List<string> errorList))
            {
                int count = efMethods.SelectDiscountCompaniesLines(trDiscountCompaniesHeader.DiscountCompaniesHeaderId).Count;
                if (count > 0)
                    SaveDiscountCompanies();
            }
            this.Close();
        }

        private void bBI_NewDiscountCompanies_ItemClick(object sender, ItemClickEventArgs e)
        {
            ClearControlsAddNew();
        }

        private void repoBtnEdit_ProductCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            string productCode = gV_DiscountCompaniesLine.GetFocusedRowCellValue("ProductCode")?.ToString();

            ButtonEdit editor = (ButtonEdit)sender;

            using FormProductList form = new(new byte[] { 1, 3 }, productCode);

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    editor.EditValue = form.dcProduct.ProductCode;
                    gV_DiscountCompaniesLine.CloseEditor();
                    gV_DiscountCompaniesLine.UpdateCurrentRow(); // For Model/Entity/trInvoiceLine Included TrInvoiceHeader

                    gV_DiscountCompaniesLine.BestFitColumns();
                    gV_DiscountCompaniesLine.FocusedColumn = colPrice;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void gV_DiscountCompaniesLine_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == $"{nameof(DcProduct)}.{nameof(DcProduct.ProductDesc)}" && e.IsGetData)
            {
                GridView view = sender as GridView;
                int rowInd = view.GetRowHandle(e.ListSourceRowIndex);
                string productCode = view.GetRowCellValue(rowInd, colProductCode) as string ?? string.Empty;

                DcProduct dcProduct = efMethods.SelectProduct(productCode);

                e.Value = dcProduct?.ProductDesc;
            }

            if (e.Column.FieldName == $"{nameof(DcProduct)}.{nameof(DcProduct.ProductCost)}" && e.IsGetData)
            {
                GridView view = sender as GridView;
                int rowInd = view.GetRowHandle(e.ListSourceRowIndex);
                string productCode = view.GetRowCellValue(rowInd, colProductCode) as string ?? string.Empty;

                DcProduct dcProduct = efMethods.SelectProduct(productCode);

                e.Value = dcProduct?.ProductCost;
            }
        }

        private void btnEdit_PriceTypeCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            string priceTypeCode = btnEdit_PriceTypeCode.EditValue?.ToString();

            ButtonEdit editor = (ButtonEdit)sender;

            //using FormPriceTypeList form = new(priceTypeCode);
            using FormCommonList<DcPriceType> form = new("", nameof(DcPriceType.PriceTypeCode), priceTypeCode);

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    editor.EditValue = form.Value_Id;
                    gV_DiscountCompaniesLine.CloseEditor();
                    gV_DiscountCompaniesLine.UpdateCurrentRow(); // For Model/Entity/trInvoiceLine Included TrInvoiceHeader

                    gV_DiscountCompaniesLine.BestFitColumns();
                    gV_DiscountCompaniesLine.FocusedColumn = colPrice;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BBI_exportXLSX_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void BBI_ImportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                OpenFileDialog dialog = new();
                dialog.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|" +
                                "All files (*.*)|*.*";
                dialog.Title = "Excel faylı seçin.";

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
                string captionProductCode = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.ProductCode);
                string productCode = row[captionProductCode].ToString();

                if (!string.IsNullOrEmpty(productCode))
                {
                    DcProduct product = efMethods.SelectProduct(productCode);
                    if (product is not null)
                    {
                        object objInvoiceHeadId = gV_DiscountCompaniesLine.GetRowCellValue(GridControl.NewItemRowHandle, colDiscountCompaniesHeaderId);
                        if (objInvoiceHeadId is null) // Check InitNewRow
                            gV_DiscountCompaniesLine.AddNewRow();

                        gV_DiscountCompaniesLine.SetRowCellValue(GridControl.NewItemRowHandle, colProductCode, product.ProductCode);

                        foreach (DataColumn column in dt.Columns)
                        {
                            try
                            {
                                //string captionLineDesc = ReflectionExtensions.GetPropertyDisplayName<TrInvoiceLine>(x => x.LineDescription);
                                //if (column.ColumnName == captionLineDesc)
                                //    gV_DiscountCompaniesLine.SetRowCellValue(GridControl.NewItemRowHandle, col_LineDesc, row[captionLineDesc].ToString());

                                string captionPrice = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.Price);
                                if (column.ColumnName == captionPrice)
                                    gV_DiscountCompaniesLine.SetRowCellValue(GridControl.NewItemRowHandle, colPrice, row[captionPrice].ToString());

                                string captionCurrency = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.CurrencyCode);
                                if (column.ColumnName == captionCurrency)
                                {
                                    if (!string.IsNullOrEmpty(row[captionCurrency].ToString()))
                                    {
                                        DcCurrency currency = efMethods.SelectCurrency(row[captionCurrency].ToString());
                                        if (currency is null)
                                            currency = efMethods.SelectCurrencyByName(row[captionCurrency].ToString());

                                        if (currency is not null)
                                            gV_DiscountCompaniesLine.SetRowCellValue(GridControl.NewItemRowHandle, colCurrencyCode, currency.CurrencyCode);
                                        else
                                            errorCodes += captionCurrency + ": " + row[captionCurrency].ToString() + "\n";
                                    }
                                }
                            }
                            catch (ArgumentException ae)
                            {
                                MessageBox.Show("Xəta No: 256543 \n" + ae.Message, "Import xetası");
                            }
                        }

                        gV_DiscountCompaniesLine.UpdateCurrentRow();
                    }
                    else
                        errorCodes += captionProductCode + ": " + row[captionProductCode].ToString() + "\n";
                }
            }

            if (!string.IsNullOrEmpty(errorCodes))
                MessageBox.Show("Aşağıdakı kodlar üzrə Dəyər tapılmadı \n" + errorCodes, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void gV_DiscountCompaniesLine_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView gridView = sender as GridView;

            Color readOnlyBackColor = Color.LightGray;
            try
            {
                if (e.RowHandle >= 0 && (!gridView.OptionsBehavior.Editable || !e.Column.OptionsColumn.AllowEdit || e.Column.ReadOnly))
                {
                    GridViewInfo viewInfo = gridView.GetViewInfo() as GridViewInfo;
                    GridDataRowInfo rowInfo = viewInfo.RowsInfo.GetInfoByHandle(e.RowHandle) as GridDataRowInfo;

                    if (rowInfo == null || (rowInfo != null && rowInfo.ConditionInfo.GetCellAppearance(e.Column) == null))
                    {
                        bool hasrules = false;
                        foreach (GridFormatRule rule in gridView.FormatRules)
                        {
                            if (rule.IsFit(e.CellValue, gridView.GetDataSourceRowIndex(e.RowHandle)))
                            {
                                hasrules = true;
                                break;
                            }
                        }
                        if (!hasrules)
                            e.Appearance.BackColor = readOnlyBackColor;
                    }
                }
                // This is to fix the selection color when a color is set for the column  
                if (e.Column.AppearanceCell.Options.UseBackColor && gridView.IsCellSelected(e.RowHandle, e.Column))
                    e.Appearance.BackColor = gridView.PaintAppearance.SelectedRow.BackColor;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }
    }
}