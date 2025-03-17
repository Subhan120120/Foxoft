using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormProductBarcode : RibbonForm
    {
        private subContext dbContext;
        string ProductCode;
        private EfMethods efMethods = new();

        public FormProductBarcode()
        {
            InitializeComponent();

            ClearControlsAddNew();
        }

        public FormProductBarcode(string productCode)
            : this()
        {
            ProductCode = productCode;

            LoadData(productCode);
        }

        private void ClearControlsAddNew()
        {
            dbContext = new subContext();

            dbContext.TrProductBarcodes
                                    .LoadAsync()
                                    .ContinueWith(loadTask => bindingSourceProductBarcode.DataSource = dbContext.TrProductBarcodes.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());

        }

        private void LoadData(string productCode)
        {
            dbContext = new subContext();

            dbContext.TrProductBarcodes.Where(x => x.ProductCode == productCode)
                //.OrderBy(x => x.CreatedDate)
                .LoadAsync()
                .ContinueWith(loadTask =>
                {
                    LocalView<TrProductBarcode> lV_productBarcode = dbContext.TrProductBarcodes.Local;
                    bindingSourceProductBarcode.DataSource = lV_productBarcode.ToBindingList();
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void GV_ProductBarcode_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gV_ProductBarcode.SetRowCellValue(e.RowHandle, colProductCode, ProductCode);
            DcBarcodeType defaultBarcodeType = efMethods.SelectBarcodTypeDefault();
            gV_ProductBarcode.SetRowCellValue(e.RowHandle, colBarcodeTypeCode, defaultBarcodeType?.BarcodeTypeCode);
        }

        private void GV_ProductBarcode_RowUpdated(object sender, RowObjectEventArgs e)
        {
            SaveData();
        }

        private void SaveData()
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

        private void GV_ProductBarcode_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            SaveData();
        }

        private void RepoBtnEdit_BarcodeType_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;

            using FormCommonList<DcBarcodeType> form = new("", "BarcodeTypeCode", editor.EditValue?.ToString());

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    editor.EditValue = form.Value_Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void RepoBtnEdit_ProductCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;

            using FormProductList form = new(new byte[] { 1, 3 }, editor.EditValue?.ToString());

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    editor.EditValue = form.dcProduct.ProductCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xeta No: 252124269 \n" + ex.ToString());
            }
        }

        private void RepoBtnEdit_Barcode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            int buttonIndex = editor.Properties.Buttons.IndexOf(e.Button);
            if (buttonIndex == 0)
            {
                string genNumber = efMethods.GetNextDocNum(false, "20", "Barcode", "TrProductBarcodes", 10);
                string checkDigit = CalculateChecksumDigit("20", genNumber.Substring(2));
                string barcode = genNumber + checkDigit;
                editor.EditValue = barcode;
            }
            if (buttonIndex == 1)
            {
                DcReport dcReport = efMethods.SelectReportByName("Report_Embedded_Barcode");

                string barcode = gV_ProductBarcode.GetFocusedRowCellValue(colBarcode)?.ToString();

                string filter = "";
                if (!string.IsNullOrEmpty(barcode))
                    filter = "[Barcode] = '" + barcode + "' ";
                //else
                //{
                //    List<TrProductBarcode> mydata = GetFilteredData<TrProductBarcode>(GV_ProductBarcode).ToList();
                //    var combined = "";
                //    foreach (TrProductBarcode rowView in mydata)
                //        combined += "'" + rowView.ProductCode.ToString() + "',";

                //    combined = combined.Substring(0, combined.Length - 1);
                //    filter = "[ProductCode] in ( " + combined + ")";
                //}

                FormReportPreview form = new(dcReport.ReportQuery, filter, dcReport);
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }
        }

        public static List<T> GetFilteredData<T>(ColumnView view)
        {
            List<T> resp = new List<T>();
            for (int i = 0; i < view.DataRowCount; i++)
                resp.Add((T)view.GetRow(i));

            return resp;
        }

        public string CalculateChecksumDigit(string countryCode, string productCode)
        {
            string sTemp = countryCode + productCode;
            int iSum = 0;
            int iDigit = 0;

            // Calculate the checksum digit here.
            for (int i = sTemp.Length; i >= 1; i--)
            {
                iDigit = Convert.ToInt32(sTemp.Substring(i - 1, 1));
                if (i % 2 == 0)
                {  // odd
                    iSum += iDigit * 3;
                }
                else
                {  // even
                    iSum += iDigit * 1;
                }
            }

            int iCheckSum = (10 - (iSum % 10)) % 10;
            return iCheckSum.ToString();
        }

        private void GV_ProductBarcode_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            GridColumn column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;

            if (column == colBarcode)
            {
                string eValue = (e.Value ??= String.Empty).ToString();
                string oldValue = gV_ProductBarcode.GetFocusedValue()?.ToString();

                if (eValue != oldValue) // different value
                {
                    DcProduct product = efMethods.SelectProductByBarcode(eValue);
                    if (product is not null)
                    {
                        e.ErrorText = "Belə bir barcode var";
                        e.Valid = false;
                    }
                }
            }
        }

        private void GV_ProductBarcode_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "Diqqət";
        }

        private void myGridControl1_Click(object sender, EventArgs e)
        {

        }

        private void GC_ProductBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            GridControl gC = sender as GridControl;
            GridView gV = gC.MainView as GridView;

            if (gV.SelectedRowsCount > 0)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (MessageBox.Show("Sətir Silinsin?", "Təsdiqlə", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;

                    gV.DeleteSelectedRows();
                }
            }
        }

        private void BBI_PrintBarcode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DcReport dcReport = efMethods.SelectReportByName("Report_Embedded_Barcode");

            string productCode = gV_ProductBarcode.GetFocusedRowCellValue(colProductCode)?.ToString();

            string filter = "";
            if (!string.IsNullOrEmpty(productCode))
                filter = "[ProductCode] = '" + productCode + "' ";

            FormReportPreview form = new(dcReport.ReportQuery, filter, dcReport);
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void FormProductBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
