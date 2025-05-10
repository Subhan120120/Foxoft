using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

namespace Foxoft
{
    public partial class UcExpense : XtraUserControl
    {
        subContext dbContext;

        EfMethods efMethods = new EfMethods();
        TrInvoiceHeader trInvoiceHeader;
        Guid invoiceHeaderId;

        public UcExpense()
        {
            InitializeComponent();
        }

        private void UcExpense_Load(object sender, EventArgs e)
        {
            ClearControlsAddNew();
        }

        private void trInvoiceHeadersBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            TrInvoiceHeader invoiceHeader = new();
            invoiceHeader.InvoiceHeaderId = invoiceHeaderId;
            string NewDocNum = efMethods.GetNextDocNum(true, "EX", "DocumentNumber", "TrInvoiceHeaders", 6);
            invoiceHeader.DocumentNumber = NewDocNum;
            invoiceHeader.DocumentDate = DateTime.Now;
            invoiceHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            invoiceHeader.ProcessCode = "EX";
            invoiceHeader.OfficeCode = Authorization.OfficeCode;
            invoiceHeader.StoreCode = Authorization.StoreCode;
            invoiceHeader.CreatedUserName = Authorization.CurrAccCode;
            invoiceHeader.IsMainTF = true;
            invoiceHeader.WarehouseCode = efMethods.SelectWarehouseByStore(Authorization.StoreCode);

            e.NewObject = invoiceHeader;
        }

        private void gV_InvoiceLine_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gV_InvoiceLine.SetRowCellValue(e.RowHandle, nameof(TrInvoiceLine.InvoiceHeaderId), trInvoiceHeader.InvoiceHeaderId);
            gV_InvoiceLine.SetRowCellValue(e.RowHandle, nameof(TrInvoiceLine.InvoiceLineId), Guid.NewGuid());
            gV_InvoiceLine.SetRowCellValue(e.RowHandle, nameof(TrInvoiceLine.QtyIn), 1);

            DcProcess dcProcess = efMethods.SelectEntityById<DcProcess>("EX");

            string currencyCode = Settings.Default.AppSetting.LocalCurrencyCode;
            if (!string.IsNullOrEmpty(dcProcess.CustomCurrencyCode))
                currencyCode = dcProcess.CustomCurrencyCode;
            DcCurrency currency = efMethods.SelectEntityById<DcCurrency>(currencyCode);

            if (currency is not null)
            {
                gV_InvoiceLine.SetRowCellValue(e.RowHandle, colCurrencyCode, currency.CurrencyCode);
                gV_InvoiceLine.SetRowCellValue(e.RowHandle, colExchangeRate, currency.ExchangeRate);
            }
        }

        private void ClearControlsAddNew()
        {
            dbContext = new subContext();

            invoiceHeaderId = Guid.NewGuid();

            dbContext.TrInvoiceHeaders.Include(x => x.DcProcess)
                                      .Include(x => x.DcCurrAcc)
                                      .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                      .Load();

            trInvoiceHeadersBindingSource.DataSource = dbContext.TrInvoiceHeaders.Local.ToBindingList();

            trInvoiceHeader = trInvoiceHeadersBindingSource.AddNew() as TrInvoiceHeader;

            dbContext.TrInvoiceLines.Include(x => x.DcProduct)
                                    .Include(x => x.TrInvoiceHeader).ThenInclude(x => x.DcProcess)
                                    .Where(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId)
                                    .LoadAsync()
                                    .ContinueWith(loadTask =>
                                    {
                                        trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList();
                                        gV_InvoiceLine.Focus();
                                    }, TaskScheduler.FromCurrentSynchronizationContext());

            dataLayoutControl1.IsValid(out List<string> errorList);


            Tag = btnEdit_DocNum.EditValue;

            //checkEdit_IsReturn.Enabled = false;
        }


        private void LoadInvoice()
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);

            dbContext = new subContext();

            dbContext.TrInvoiceHeaders.Where(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId)
                                      .Load();

            trInvoiceHeadersBindingSource.DataSource = dbContext.TrInvoiceHeaders.Local.ToBindingList();

            trInvoiceHeader = trInvoiceHeadersBindingSource.Current as TrInvoiceHeader;

            dbContext.TrInvoiceLines.Include(o => o.DcProduct)
                                    .Include(x => x.TrInvoiceHeader).ThenInclude(x => x.DcProcess)
                                    .Where(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId)
                                    .OrderBy(x => x.CreatedDate)
                                    .LoadAsync()
                                    .ContinueWith(loadTask =>
                                    {
                                        trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList();

                                        gV_InvoiceLine.Focus();

                                    }, TaskScheduler.FromCurrentSynchronizationContext());

            dataLayoutControl1.IsValid(out List<string> errorList);

            Tag = btnEdit_DocNum.EditValue;

            SplashScreenManager.CloseForm(false);
        }

        private void btnEdit_DocNum_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            using (FormInvoiceHeaderList form = new("EX", null))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    trInvoiceHeader.InvoiceHeaderId = form.trInvoiceHeader.InvoiceHeaderId;

                    LoadInvoice();
                }
            }
        }

        private void btnEdit_CurrAccCode_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            using (FormCurrAccList form = new(new byte[] { 2 }))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    btnEdit_CurrAccCode.EditValue = form.dcCurrAcc.CurrAccCode;
            }
        }

        private void gV_InvoiceLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (gV_InvoiceLine.SelectedRowsCount > 0)
            {
                if (e.KeyCode == Keys.Delete && gV_InvoiceLine.ActiveEditor == null)
                {
                    if (MessageBox.Show("Sətir Silinsin?", "Təsdiqlə", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;

                    gV_InvoiceLine.DeleteSelectedRows();
                }

                if (e.KeyCode == Keys.C && e.Control)
                {
                    string cellValue = gV_InvoiceLine.GetFocusedValue()?.ToString();
                    if (!string.IsNullOrEmpty(cellValue))
                    {
                        Clipboard.SetText(cellValue);
                        e.Handled = true;
                    }
                }

                if (e.KeyCode == Keys.F2)
                {
                    gV_InvoiceLine.FocusedColumn = colProductCode;
                    gV_InvoiceLine.ShowEditor();
                    if (gV_InvoiceLine.ActiveEditor is ButtonEdit)
                        SelectProduct(gV_InvoiceLine.ActiveEditor);

                    gV_InvoiceLine.CloseEditor();

                    e.Handled = true;   // Stop the character from being entered into the control.
                }
            }
        }

        private void SelectProduct(object sender)
        {
            string productCode = gV_InvoiceLine.GetFocusedRowCellValue(colProductCode)?.ToString();

            ButtonEdit editor = (ButtonEdit)sender;

            using FormProductList form = new(new byte[] { 2 }, false, productCode);

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    editor.EditValue = form.dcProduct.ProductCode;

                    gV_InvoiceLine.CloseEditor();
                    gV_InvoiceLine.UpdateCurrentRow(); // For Model/Entity/trInvoiceLine Included TrInvoiceHeader

                    gV_InvoiceLine.FocusedColumn = colPrice;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GV_InvoiceLine_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column == colProductCode)
            {
                var row = gV_InvoiceLine.GetRow(e.RowHandle) as TrInvoiceLine;

                if (row != null)
                {
                    DcProduct product = efMethods.SelectEntityById<DcProduct>(row.ProductCode);

                    if (dbContext.Entry(product).State == EntityState.Detached) // dbContext.SaveChanges() metodunda DcProduct insert etmeye calismasin deye 
                        dbContext.Attach(product);

                    row.DcProduct = product;

                    gV_InvoiceLine.RefreshRow(e.RowHandle); // Refresh to show ProductDesc
                }
            }
        }

        private void gV_InvoiceLine_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
        }

        private void repoBtnEdit_ProductCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            SelectProduct(sender);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            //TrInvoiceHeader trInvoiceHeader = trInvoiceHeadersBindingSource.Current as TrInvoiceHeader;
            if (!efMethods.EntityExists<TrInvoiceHeader>(trInvoiceHeader.InvoiceHeaderId))
                dbContext.TrInvoiceHeaders.Add(trInvoiceHeader);
            dbContext.SaveChanges();
            efMethods.UpdateInvoiceIsCompleted(trInvoiceHeader.InvoiceHeaderId);

            ClearControlsAddNew();
        }

        private void gV_InvoiceLine_ShownEditor(object sender, EventArgs e)
        {
            if (new Type[] { typeof(decimal), typeof(float), typeof(Single) }.Contains(gV_InvoiceLine.FocusedColumn.ColumnType))
            {
                TextEdit? editor = gV_InvoiceLine.ActiveEditor as TextEdit;
                if (editor != null)
                {
                    CultureInfo customCulture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                    customCulture.NumberFormat.NumberDecimalSeparator = ".";
                    editor.Properties.Mask.MaskType = MaskType.Numeric;
                    editor.Properties.Mask.Culture = customCulture; // Ensure '.' is used
                }
            }
        }

        private void GV_InvoiceLine_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            GridColumn column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;

            if (column == colBarcode || column == colProductCode)
            {
                string eValue = (e.Value ??= String.Empty).ToString();

                if (!string.IsNullOrEmpty(eValue))
                {
                    DcProduct product = null;

                    if (column == colBarcode)
                        product = efMethods.SelectProductByBarcode(eValue);
                    if (column == colProductCode)
                    {
                        product = efMethods.SelectExpense(eValue);
                    }

                    if (product is not null)
                    {
                        gV_InvoiceLine.SetRowCellValue(view.FocusedRowHandle, colProductCode, product.ProductCode);
                        view.UpdateCurrentRow(); // For Model/Entity/trInvoiceLine Included TrInvoiceHeader

                        view.SetRowCellValue(view.FocusedRowHandle, colQty, 1);
                    }
                    else
                    {
                        e.ErrorText = "Belə bir məhsul yoxdur";
                        e.Valid = false;
                    }
                }
                else
                {
                    e.Value = null;
                }
            }
        }

        private void GV_InvoiceLine_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "Diqqət";
        }

    }
}
