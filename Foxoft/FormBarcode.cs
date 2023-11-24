using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormProductBarcode : XtraForm
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
            GV_ProductBarcode.SetRowCellValue(e.RowHandle, colProductCode, ProductCode);
        }

        private void GV_ProductBarcode_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
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

        private void RepoBtnEdit_BarcodeType_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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

        private void RepoBtnEdit_ProductCode_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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

        private void RepoBtnEdit_Barcode_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            EfMethods efMethods = new EfMethods();
            string genNumber = efMethods.GetNextDocNum(false, "20", "Barcode", "DcProducts", 10);
            string checkDigit = CalculateChecksumDigit("20", genNumber.Substring(2));
            string barcode = genNumber + checkDigit;
            editor.EditValue = barcode;
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

        private void GV_ProductBarcode_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            GridColumn column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;

            if (column == colBarcode)
            {
                string eValue = (e.Value ??= String.Empty).ToString();
                DcProduct product = efMethods.SelectProductByBarcode(eValue);

                if (product is not null)
                {
                    e.ErrorText = "Belə bir barcode var";
                    e.Valid = false;
                }
            }
        }

        private void GV_ProductBarcode_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "Diqqət";
        }
    }
}
