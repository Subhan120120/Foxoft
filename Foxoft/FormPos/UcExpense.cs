using DevExpress.Utils.Menu;
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

        EfMethods efMethods = new();
        TrInvoiceHeader trInvoiceHeader;
        Guid invoiceHeaderId;
        private bool _isLoading = false;

        public UcExpense()
        {
            InitializeComponent();
        }

        private void UcExpense_Load(object sender, EventArgs e)
        {
            ClearControlsAddNew();
            ApplyPermissions();
        }

        private void ApplyPermissions()
        {
            bool hasExpenseClaim = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "Expense");
            if (!hasExpenseClaim)
            {
                dataLayoutControl1.Enabled = false;
            }
            else
            {
                dataLayoutControl1.Enabled = true;

                string processCode = trInvoiceHeader?.ProcessCode ?? "EX";
                bool canChangePrice = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "ChangePrice" + processCode);
                gridColumn2.OptionsColumn.ReadOnly = !canChangePrice;

                bool canDeleteInvoice = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "DeleteInvoice" + processCode);
                btn_Delete.Enabled = canDeleteInvoice;
            }
        }

        private void trInvoiceHeadersBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            TrInvoiceHeader invoiceHeader = new();
            invoiceHeader.InvoiceHeaderId = invoiceHeaderId;
            string NewDocNum = efMethods.GetNextDocNum(true, "EX", nameof(TrInvoiceHeader.DocumentNumber), nameof(subContext.TrInvoiceHeaders), 6);
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
            _isLoading = true;

            dbContext = new subContext();

            invoiceHeaderId = Guid.NewGuid();

            dbContext.TrInvoiceHeaders
                     .Include(x => x.DcProcess)
                     .Include(x => x.DcCurrAcc)
                     .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                     .Load();

            trInvoiceHeadersBindingSource.DataSource = dbContext.TrInvoiceHeaders.Local.ToBindingList();

            trInvoiceHeader = trInvoiceHeadersBindingSource.AddNew() as TrInvoiceHeader;

            dbContext.TrInvoiceLines
                     .Include(x => x.DcProduct)
                     .Include(x => x.TrInvoiceHeader).ThenInclude(x => x.DcProcess)
                     .Where(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId)
                     .LoadAsync()
                     .ContinueWith(loadTask =>
                     {
                         try
                         {
                             if (!loadTask.IsFaulted)
                             {
                                 trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList();
                                 gV_InvoiceLine.Focus();
                             }
                         }
                         finally
                         {
                             _isLoading = false;
                         }
                     }, TaskScheduler.FromCurrentSynchronizationContext());

            dataLayoutControl1.IsValid(out List<string> errorList);

            Tag = btnEdit_DocNum.EditValue;

            ApplyPermissions();
        }

        private void LoadInvoice(Guid headerId)
        {
            _isLoading = true;
            SplashScreenManager.ShowForm(ParentForm, typeof(WaitForm), true, true, false);

            invoiceHeaderId = headerId;
            dbContext = new subContext();

            dbContext.TrInvoiceHeaders
                     .Include(x => x.DcProcess)
                     .Include(x => x.DcCurrAcc)
                     .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                     .Load();

            trInvoiceHeadersBindingSource.DataSource = dbContext.TrInvoiceHeaders.Local.ToBindingList();

            trInvoiceHeader = trInvoiceHeadersBindingSource.Current as TrInvoiceHeader;

            dbContext.TrInvoiceLines
                     .Include(o => o.DcProduct)
                     .Include(x => x.TrInvoiceHeader).ThenInclude(x => x.DcProcess)
                     .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                     .OrderBy(x => x.CreatedDate)
                     .LoadAsync()
                     .ContinueWith(loadTask =>
                     {
                         try
                         {
                             if (!loadTask.IsFaulted)
                             {
                                 trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList();
                                 gV_InvoiceLine.Focus();
                             }
                         }
                         finally
                         {
                             _isLoading = false;
                             SplashScreenManager.CloseForm(false);
                         }
                     }, TaskScheduler.FromCurrentSynchronizationContext());

            dataLayoutControl1.IsValid(out List<string> errorList);

            Tag = btnEdit_DocNum.EditValue;

            ApplyPermissions();
        }

        private void btnEdit_DocNum_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (!efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "Expense"))
            {
                XtraMessageBox.Show(Resources.Common_NoPermission);
                return;
            }

            using (FormInvoiceHeaderList form = new("EX"))
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.trInvoiceHeader is not null)
                {
                    LoadInvoice(form.trInvoiceHeader.InvoiceHeaderId);
                }
            }
        }

        private void gV_InvoiceLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (gV_InvoiceLine.SelectedRowsCount > 0)
            {
                if (e.KeyCode == Keys.Delete && gV_InvoiceLine.ActiveEditor == null)
                {
                    DeleteSelectedLine();
                    e.Handled = true;
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

                    e.Handled = true;  // Stop the character from being entered into the control.
                }
            }
        }

        private void DeleteSelectedLine()
        {
            if (gV_InvoiceLine.SelectedRowsCount > 0 && gV_InvoiceLine.FocusedRowHandle >= 0)
            {
                string claim = "DeleteLine" + (trInvoiceHeader?.ProcessCode ?? "EX");
                bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, claim);
                if (!currAccHasClaims)
                {
                    XtraMessageBox.Show(Resources.Common_NoPermission);
                    return;
                }

                if (XtraMessageBox.Show(
                        Resources.Form_Expense_RowDeleteQuestion,
                        Resources.Common_Attention,
                        MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                gV_InvoiceLine.DeleteSelectedRows();
                AutoSaveIfEnabled();
            }
        }

        private void gV_InvoiceLine_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow && e.HitInfo.RowHandle >= 0)
            {
                e.Menu ??= new DevExpress.XtraGrid.Menu.GridViewMenu(gV_InvoiceLine);
                DXMenuItem itemDelete = new(Resources.Common_Delete, (s, args) => DeleteSelectedLine());
                e.Menu.Items.Add(itemDelete);
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
                    gV_InvoiceLine.UpdateCurrentRow();

                    gV_InvoiceLine.FocusedColumn = gridColumn2; // Price column
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void GV_InvoiceLine_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column == colProductCode)
            {
                var row = gV_InvoiceLine.GetRow(e.RowHandle) as TrInvoiceLine;

                if (row != null)
                {
                    var tracked = dbContext.TrInvoiceLines
                                           .Where(x => x.DcProduct.ProductCode == row.ProductCode)
                                           .Select(x => x.DcProduct);

                    row.DcProduct = tracked.FirstOrDefault();
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

        private bool SaveInvoice()
        {
            if (trInvoiceHeader is null)
                return false;

            if (!efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "Expense"))
            {
                XtraMessageBox.Show(Resources.Common_NoPermission);
                return false;
            }

            gV_InvoiceLine.CloseEditor();
            gV_InvoiceLine.UpdateCurrentRow();
            dataLayoutControl1.Validate();

            if (!dataLayoutControl1.IsValid(out _))
                return false;

            if (dbContext == null)
                return false;

            try
            {
                if (dbContext.Entry(trInvoiceHeader).State == EntityState.Detached)
                    dbContext.TrInvoiceHeaders.Add(trInvoiceHeader);

                dbContext.SaveChanges(Authorization.CurrAccCode);
                efMethods.UpdateInvoiceIsCompleted(trInvoiceHeader.InvoiceHeaderId);

                Tag = btnEdit_DocNum.EditValue;

                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "Expense"))
            {
                XtraMessageBox.Show(Resources.Common_NoPermission);
                return;
            }

            if (SaveInvoice())
            {
                ClearControlsAddNew();
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DeleteExpense();
        }

        private void DeleteExpense()
        {
            if (!efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "Expense"))
            {
                XtraMessageBox.Show(Resources.Common_NoPermission);
                return;
            }

            string processCode = trInvoiceHeader?.ProcessCode ?? "EX";
            string claim = "DeleteInvoice" + processCode;
            if (!efMethods.CurrAccHasClaims(Authorization.CurrAccCode, claim))
            {
                XtraMessageBox.Show(Resources.Common_NoPermission);
                return;
            }

            bool invoiceExistsInDb = trInvoiceHeader is not null && efMethods.EntityExists<TrInvoiceHeader>(trInvoiceHeader.InvoiceHeaderId);
            bool hasLines = gV_InvoiceLine.DataRowCount > 0;
            bool hasDesc = !string.IsNullOrWhiteSpace(memoEdit_InvoiceDesc.Text);

            if (!invoiceExistsInDb && !hasLines && !hasDesc)
            {
                XtraMessageBox.Show(Resources.Form_Invoice_NoInvoiceToDelete, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dialogResult = XtraMessageBox.Show(
                Resources.Form_Invoice_DeleteInvoiceQuestion,
                Resources.Common_Attention,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes)
                return;

            if (invoiceExistsInDb)
            {
                if (efMethods.PaymentExistByInvoice(trInvoiceHeader.InvoiceHeaderId))
                {
                    efMethods.DeletePaymentsByInvoiceId(trInvoiceHeader.InvoiceHeaderId, Authorization.CurrAccCode);
                }

                efMethods.DeleteInvoice(trInvoiceHeader.InvoiceHeaderId, Authorization.CurrAccCode);
            }

            ClearControlsAddNew();
        }

        private void gV_InvoiceLine_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gV_InvoiceLine.FocusedColumn == gridColumn2)
            {
                string processCode = trInvoiceHeader?.ProcessCode ?? "EX";
                bool canChangePrice = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "ChangePrice" + processCode);
                if (!canChangePrice)
                    e.Cancel = true;
            }
        }

        private void gV_InvoiceLine_ShownEditor(object sender, EventArgs e)
        {
            if (new Type[] { typeof(decimal), typeof(float), typeof(Single) }.Contains(gV_InvoiceLine.FocusedColumn.ColumnType))
            {
                TextEdit editor = gV_InvoiceLine.ActiveEditor as TextEdit;
                if (editor != null)
                {
                    CultureInfo customCulture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                    customCulture.NumberFormat.NumberDecimalSeparator = ".";
                    editor.Properties.Mask.MaskType = MaskType.Numeric;
                    editor.Properties.Mask.Culture = customCulture;
                }
            }
        }

        private void GV_InvoiceLine_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            GridColumn column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;

            if (column == colBarcode || column == colProductCode)
            {
                string eValue = (e.Value ??= string.Empty).ToString();

                if (!string.IsNullOrEmpty(eValue))
                {
                    DcProduct product = null;

                    if (column == colBarcode)
                        product = efMethods.SelectProductByBarcode(eValue);
                    if (column == colProductCode)
                        product = efMethods.SelectExpense(eValue);

                    if (product is not null)
                    {
                        gV_InvoiceLine.SetRowCellValue(view.FocusedRowHandle, colProductCode, product.ProductCode);
                        view.UpdateCurrentRow();
                        view.SetRowCellValue(view.FocusedRowHandle, colQtyIn, 1);
                    }
                    else
                    {
                        e.ErrorText = Resources.Form_Expense_ProductNotFound;
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
            e.WindowCaption = Resources.Common_Attention;
        }

        private void AutoSaveIfEnabled()
        {
            if (_isLoading || dbContext == null || trInvoiceHeader == null)
                return;

            if (!Settings.Default.AppSetting.AutoSave)
                return;

            bool invoiceExistsInDb = efMethods.EntityExists<TrInvoiceHeader>(trInvoiceHeader.InvoiceHeaderId);
            if (invoiceExistsInDb || gV_InvoiceLine.DataRowCount > 0)
            {
                SaveInvoice();
            }
        }

        private void gV_InvoiceLine_RowUpdated(object sender, RowObjectEventArgs e)
        {
            AutoSaveIfEnabled();
        }

        private void trInvoiceHeadersBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            if (!_isLoading)
                dataLayoutControl1.Validate();

            trInvoiceHeader = trInvoiceHeadersBindingSource.Current as TrInvoiceHeader;

            if (trInvoiceHeader is null)
                return;

            AutoSaveIfEnabled();
        }

        private void UcExpense_Leave(object sender, EventArgs e)
        {
            AutoSaveIfEnabled();
        }
    }
}
