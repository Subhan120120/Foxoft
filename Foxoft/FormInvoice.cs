
#region Using
using DevExpress.Data;
using DevExpress.DataAccess.Excel;
using DevExpress.DataAccess.Native.Excel;
using DevExpress.DataAccess.Sql;
using DevExpress.Utils.Extensions;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraLayout;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using Foxoft.Models;
using Foxoft.Models.Entity.Report;
using Foxoft.Properties;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using PopupMenuShowingEventArgs = DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs;

#endregion

namespace Foxoft
{
    public partial class FormInvoice : RibbonForm
    {
        private EfMethods efMethods = new();
        private subContext dbContext;
        private subContext dbContext2;
        subContext subContext = new(); // for CustomUnboundColumnData

        string reportFileNameInvoiceWare = @"InvoiceRS_A4_depo.repx";

        readonly SettingStore settingStore;
        private TrInvoiceHeader trInvoiceHeader;
        private bool isReturn;
        Guid invoiceHeaderId;
        Guid? relatedInvoiceId;
        public DcProcess dcProcess;
        private byte[] productTypeArr;
        private decimal CurrAccBalanceBefore;
        private DcLoyaltyCard dcLoyaltyCard;
        ReportClass reportClass;

        private const int WM_GETTAG = 0x0400 + 1; // for acccess to tag via Windows API

        public FormInvoice(string processCode, bool? isReturn, byte[] productTypeArr, Guid? relatedInvoiceId)
        {
            settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);
            dcProcess = efMethods.SelectEntityById<DcProcess>(processCode);
            reportClass = new(settingStore.DesignFileFolder);

            InitializeComponent();

            InitializeColumnName();

            this.productTypeArr = productTypeArr;
            this.relatedInvoiceId = relatedInvoiceId;

            if (isReturn.HasValue)
            {
                this.isReturn = (bool)isReturn;

                checkEdit_IsReturn.Properties.Appearance.ForeColor = (bool)isReturn ? Color.Red : Color.Empty;
            }

            BEI_PrinterName.EditValue = settingStore.PrinterName;
            lUE_StoreCode.Properties.DataSource = efMethods.SelectStoresIncludeDisabled();
            LUE_InstallmentPlan.Properties.DataSource = efMethods.SelectEntities<DcInstallmentPlan>();

            string activeFilterStr = "[StoreCode] = \'" + Authorization.StoreCode + "\'";

            reportClass.AddReports(BSI_Reports, "Invoice", nameof(TrInvoiceLine.InvoiceHeaderId), gV_InvoiceLine, activeFilterStr);
            reportClass.AddReports(BSI_Reports, "Products", nameof(DcProduct.ProductCode), gV_InvoiceLine, activeFilterStr);

            repoLUE_CurrencyCode.DataSource = efMethods.SelectEntities<DcCurrency>();
            repoLUE_UnitOfMeasure.DataSource = efMethods.SelectEntities<DcUnitOfMeasure>();

            try
            {
                foreach (string printer in PrinterSettings.InstalledPrinters)
                    repoCBE_PrinterName.Items.Add(printer);
            }
            catch (Exception) { }

            LoadLayout();

            if (settingStore is not null)
                if (CustomExtensions.DirectoryExist(settingStore.ImageFolder))
                    AppDomain.CurrentDomain.SetData("DXResourceDirectory", settingStore.ImageFolder);

            ClearControlsAddNew();

            DateEdit_InstallmentDate.EditValueChanged += trInvoiceHeadersBindingSource_CurrentItemChanged;
            LUE_InstallmentPlan.EditValueChanged += trInvoiceHeadersBindingSource_CurrentItemChanged;
            txtEdit_Installment_Commission.Leave += trInvoiceHeadersBindingSource_CurrentItemChanged;
        }

        public FormInvoice(string processCode, bool? isReturn, byte[] productTypeArr, Guid? relatedInvoiceId, Guid invoiceHeaderId)
            : this(processCode, isReturn, productTypeArr, relatedInvoiceId)
        {
            trInvoiceHeader = efMethods.SelectInvoiceHeader(invoiceHeaderId);
            LoadInvoice(trInvoiceHeader.InvoiceHeaderId);
        }

        private void FormInvoice_Load(object sender, EventArgs e)
        {
            dataLayoutControl1.IsValid(out List<string> errorList);
        }

        private void FormInvoice_Shown(object sender, EventArgs e)
        {
            gC_InvoiceLine.Focus();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_GETTAG)
            {
                string tagValue = this.Tag?.ToString() ?? string.Empty;
                byte[] tagBytes = Encoding.UTF8.GetBytes(tagValue);
                IntPtr tagPointer = Marshal.AllocHGlobal(tagBytes.Length + 1);
                Marshal.Copy(tagBytes, 0, tagPointer, tagBytes.Length);
                Marshal.WriteByte(tagPointer, tagBytes.Length, 0); // Null-terminate the string
                m.Result = tagPointer;
                return;
            }
            base.WndProc(ref m);
        }

        private void InitializeColumnName()
        {
            colBalance.Caption = ReflectionExt.GetDisplayName<DcProduct>(x => x.Balance);
            col_ProductDesc.Caption = ReflectionExt.GetDisplayName<DcProduct>(x => x.ProductDesc);
            LCI_CashRegCode.Text = ReflectionExt.GetDisplayName<TrPaymentLine>(x => x.CashRegisterCode);
        }

        private void ClearControlsAddNew()
        {
            dbContext = new subContext();


            invoiceHeaderId = Guid.NewGuid();

            dbContext.TrInvoiceHeaders.Include(x => x.DcProcess)
                                      .Include(x => x.DcCurrAcc)
                                      .Include(x => x.TrInstallment)
                                      .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                                      .Load();

            trInvoiceHeadersBindingSource.DataSource = dbContext.TrInvoiceHeaders.Local.ToBindingList();

            trInvoiceLinesBindingSource.DataSource = null;
            trInvoiceHeader = trInvoiceHeadersBindingSource.AddNew() as TrInvoiceHeader;

            this.Text = $"{dcProcess.ProcessDesc} - ({btnEdit_DocNum.EditValue})";

            CalcPaidAmount();
            //CalcInstallmentAmount();

            lbl_CurrAccDesc.Text = trInvoiceHeader.CurrAccDesc;

            trInvoiceHeader.IsReturn = isReturn;

            dbContext.TrInvoiceLines.Include(x => x.DcProduct)
                                    .Include(x => x.TrInvoiceHeader).ThenInclude(x => x.DcProcess)
                                    .Include(x => x.DcUnitOfMeasure).ThenInclude(x => x.ParentUnitOfMeasure)
                                    .Where(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId)
                                    .LoadAsync()
                                    .ContinueWith(loadTask => trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());

            if (new string[] { "EX" }.Contains(dcProcess.ProcessCode))
                btn_CashRegCode.EditValue = efMethods.CashRegFromExpense(trInvoiceHeader.InvoiceHeaderId, Settings.Default.TerminalId);

            if (new string[] { "IS" }.Contains(dcProcess.ProcessCode))
                ClearInstallmentGarantorsAddNew();

            dataLayoutControl1.IsValid(out List<string> errorList);

            Tag = btnEdit_DocNum.EditValue;

            SetLayoutGroupReadOnly(LCG_Invoice, trInvoiceHeader.IsLocked);
        }

        private void ClearInstallmentGarantorsAddNew()
        {
            dbContext2 = new subContext();

            dbContext2.TrInstallmentGuarantors.Include(x => x.DcCurrAcc)
                                              .Where(x => x.InstallmentId == trInvoiceHeader.TrInstallment.InstallmentId)
                                              .Load();

            trInstallmentGuarantorsBindingSource.DataSource = dbContext2.TrInstallmentGuarantors.Local.ToBindingList();

            gV_InstallmentGarantor.BestFitColumns();
        }

        private void trInvoiceHeadersBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            TrInvoiceHeader invoiceHeader = new();
            invoiceHeader.InvoiceHeaderId = invoiceHeaderId;
            invoiceHeader.RelatedInvoiceId = relatedInvoiceId;
            string NewDocNum = efMethods.GetNextDocNum(true, dcProcess.ProcessCode, nameof(TrInvoiceHeader.DocumentNumber), nameof(subContext.TrInvoiceHeaders), 6);
            invoiceHeader.DocumentNumber = NewDocNum;
            invoiceHeader.DocumentDate = DateTime.Now;
            invoiceHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            invoiceHeader.ProcessCode = dcProcess.ProcessCode;
            invoiceHeader.OfficeCode = Authorization.OfficeCode;
            invoiceHeader.StoreCode = Authorization.StoreCode;
            invoiceHeader.CreatedUserName = Authorization.CurrAccCode;
            invoiceHeader.IsMainTF = true;
            invoiceHeader.IsCompleted = true;
            invoiceHeader.WarehouseCode = efMethods.SelectWarehouseByStore(Authorization.StoreCode);

            if (new string[] { "RS", "WS" }.Contains(dcProcess.ProcessCode))
            {
                string defaultCustomer = efMethods.SelectDefaultCustomerByStore(Authorization.StoreCode);
                invoiceHeader.CurrAccCode = defaultCustomer;

                if (efMethods.SelectCurrAcc(defaultCustomer) is not null)
                    invoiceHeader.CurrAccDesc = efMethods.SelectCurrAcc(defaultCustomer).CurrAccDesc;
            }

            if (new string[] { "IS" }.Contains(dcProcess.ProcessCode))
                invoiceHeader.TrInstallment = new TrInstallment
                {
                    InvoiceHeaderId = invoiceHeader.InvoiceHeaderId,
                    InstallmentPlanCode = "I00",
                    InstallmentDate = DateTime.Now
                };

            e.NewObject = invoiceHeader;
        }

        private void trInvoiceHeadersBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            dataLayoutControl1.Validate();  // ensure editor loses focus and commits value

            trInvoiceHeader = trInvoiceHeadersBindingSource.Current as TrInvoiceHeader;

            if (trInvoiceHeader is null)
                return;

            if (sender as LookUpEdit == LUE_InstallmentPlan && !string.IsNullOrEmpty(LUE_InstallmentPlan.EditValue?.ToString()))
                trInvoiceHeader.TrInstallment.InstallmentPlanCode = LUE_InstallmentPlan.EditValue?.ToString();

            if (sender as DateEdit == DateEdit_InstallmentDate && !string.IsNullOrEmpty(DateEdit_InstallmentDate.EditValue?.ToString()))
                trInvoiceHeader.TrInstallment.InstallmentDate = (DateTime)DateEdit_InstallmentDate.EditValue;

            if (dbContext != null && dataLayoutControl1.IsValid(out _))
                if (Settings.Default.AppSetting.AutoSave)
                    if (gV_InvoiceLine.DataRowCount > 0)
                        SaveInvoice();

            //gV_InvoiceLine.Focus();
        }

        private void btnEdit_DocNum_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            SelectDocNum();
        }

        private void btnEdit_DocNum_DoubleClick(object sender, EventArgs e)
        {
            SelectDocNum();
        }

        private void SelectDocNum()
        {
            using FormInvoiceHeaderList form = new(dcProcess.ProcessCode, relatedInvoiceId);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                //efMethods.UpdateInvoiceIsOpen(trInvoiceHeader.DocumentNumber, false);

                trInvoiceHeader = form.trInvoiceHeader;

                LoadInvoice(trInvoiceHeader.InvoiceHeaderId);
            }
        }

        private void LoadInvoice(Guid InvoiceHeaderId)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);

            if (new string[] { "EX" }.Contains(dcProcess.ProcessCode))
                btn_CashRegCode.EditValue = efMethods.CashRegFromExpense(trInvoiceHeader.InvoiceHeaderId, Settings.Default.TerminalId);

            dbContext = new subContext();

            dbContext.TrInvoiceHeaders.Include(x => x.DcCurrAcc)
                                      .Include(x => x.DcProcess)
                                      .Include(x => x.TrInstallment)
                                      .Where(x => x.InvoiceHeaderId == InvoiceHeaderId)
                                      .Load();

            LocalView<TrInvoiceHeader> lV_invoiceHeader = dbContext.TrInvoiceHeaders.Local;

            if (!lV_invoiceHeader.Any(x => x.DcCurrAcc is null))
                lV_invoiceHeader.ForEach(x =>
                {
                    x.CurrAccDesc = x.DcCurrAcc.CurrAccDesc + " " + x.DcCurrAcc.FirstName + " " + x.DcCurrAcc.LastName;
                    lbl_CurrAccDesc.Text = x.DcCurrAcc.CurrAccDesc + " " + x.DcCurrAcc.FirstName + " " + x.DcCurrAcc.LastName;
                });

            trInvoiceHeadersBindingSource.DataSource = lV_invoiceHeader.ToBindingList();

            trInvoiceHeader = trInvoiceHeadersBindingSource.Current as TrInvoiceHeader;

            dcProcess = efMethods.SelectEntityById<DcProcess>(trInvoiceHeader.ProcessCode);

            Text = $"{dcProcess.ProcessDesc} - ({btnEdit_DocNum.EditValue})";

            dbContext.TrInvoiceLines.Include(o => o.DcProduct).ThenInclude(f => f.TrProductFeatures)
                                    .Include(x => x.TrInvoiceHeader).ThenInclude(x => x.DcProcess)
                                    .Include(x => x.DcUnitOfMeasure).ThenInclude(x => x.ParentUnitOfMeasure).ThenInclude(x => x.ParentUnitOfMeasure)
                                    .Where(x => x.InvoiceHeaderId == InvoiceHeaderId)
                                    .OrderBy(x => x.CreatedDate)
                                    .LoadAsync()
                                    .ContinueWith(loadTask =>
                                    {
                                        trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList();

                                        gV_InvoiceLine.BestFitColumns();
                                        gV_InvoiceLine.Focus();

                                    }, TaskScheduler.FromCurrentSynchronizationContext());

            if (new string[] { "IS" }.Contains(dcProcess.ProcessCode))
                LoadInstallmentGarantors();

            dataLayoutControl1.IsValid(out List<string> errorList);
            CalcPaidAmount();
            //CalcInstallmentAmount();

            Tag = btnEdit_DocNum.EditValue;

            if (!trInvoiceHeader.IsLocked)
            {
                bool locked = (DateTime.Now - trInvoiceHeader.DocumentDate).Days > Settings.Default.AppSetting.InvoiceEditGraceDays;
                trInvoiceHeader.IsLocked = locked;
            }

            SetLayoutGroupReadOnly(LCG_Invoice, trInvoiceHeader.IsLocked);

            efMethods.UpdateInvoiceIsLocked(trInvoiceHeader.InvoiceHeaderId, trInvoiceHeader.IsLocked);

            SplashScreenManager.CloseForm(false);
        }

        private void CalcPaidAmount()
        {
            decimal cashSum = efMethods.SelectPaymentLinesCashSumByInvoice(trInvoiceHeader.InvoiceHeaderId, trInvoiceHeader.CurrAccCode) * (dcProcess.ProcessDir == 1 ? (-1) : 1);
            lbl_InvoicePaidCashSum.Text = Math.Round(cashSum, 2).ToString() + " " + Settings.Default.AppSetting.LocalCurrencyCode;

            decimal cashlessSum = efMethods.SelectPaymentLinesCashlessSumByInvoice(trInvoiceHeader.InvoiceHeaderId, trInvoiceHeader.CurrAccCode) * (dcProcess.ProcessDir == 1 ? (-1) : 1);
            lbl_InvoicePaidCashlessSum.Text = Math.Round(cashlessSum, 2).ToString() + " " + Settings.Default.AppSetting.LocalCurrencyCode;

            decimal totalSum = efMethods.SelectPaymentLinesSumByInvoice(trInvoiceHeader.InvoiceHeaderId, trInvoiceHeader.CurrAccCode) * (dcProcess.ProcessDir == 1 ? (-1) : 1);
            lbl_InvoicePaidTotalSum.Text = Math.Round(totalSum, 2).ToString() + " " + Settings.Default.AppSetting.LocalCurrencyCode;
        }

        private void ShowPrintCount()
        {
            int printCount = efMethods.SelectEntityById<TrInvoiceHeader>(trInvoiceHeader?.InvoiceHeaderId).PrintCount;

            txtEdit_PrintCount.Text = printCount.ToString();
        }

        private void btnEdit_CurrAccCode_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            SelectCurrAcc();
        }

        private void btnEdit_CurrAccCode_DoubleClick(object sender, EventArgs e)
        {
            SelectCurrAcc();
        }

        private void SelectCurrAcc()
        {
            if (btnEdit_CurrAccCode.Enabled)
            {
                FormCurrAccList form = new(new byte[] { 1, 2, 3 }, false, trInvoiceHeader.CurrAccCode);

                if (trInvoiceHeader.ProcessCode == "IT")
                    form = new FormCurrAccList(new byte[] { 4 }, false, trInvoiceHeader.CurrAccCode);

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    //if (form.dcCurrAcc.CreditLimit > Math.Abs(form.dcCurrAcc.Balance) || form.dcCurrAcc.CreditLimit == 0)
                    btnEdit_CurrAccCode.EditValue = form.dcCurrAcc.CurrAccCode;
                    //else
                    //    XtraMessageBox.Show(Resources.Form_Invoice_CreditLimitExceeded, Resources.Common_Attention);
                }
            }
        }

        private void gV_InvoiceLine_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView gv = sender as GridView;
            gv.SetRowCellValue(e.RowHandle, col_InvoiceHeaderId, trInvoiceHeader.InvoiceHeaderId);
            gv.SetRowCellValue(e.RowHandle, col_InvoiceLineId, Guid.NewGuid());
            gv.SetRowCellValue(e.RowHandle, colCreatedDate, DateTime.Now);
            gv.SetRowCellValue(e.RowHandle, colCreatedUserName, Authorization.CurrAccCode);

            string currencyCode = Settings.Default.AppSetting.LocalCurrencyCode;
            if (!string.IsNullOrEmpty(dcProcess.CustomCurrencyCode))
                currencyCode = dcProcess.CustomCurrencyCode;
            DcCurrency currency = efMethods.SelectEntityById<DcCurrency>(currencyCode);
            if (currency is not null)
            {
                gv.SetRowCellValue(e.RowHandle, colCurrencyCode, currency.CurrencyCode);
                gv.SetRowCellValue(e.RowHandle, colExchangeRate, currency.ExchangeRate);
            }

            if (settingStore.SalesmanContinuity)
            {
                int lastRowHandle = gv.GetRowHandle(gv.DataRowCount - 1);
                if (lastRowHandle >= 0)
                {
                    object lastValue = gv.GetRowCellValue(lastRowHandle, col_SalesPersonCode);
                    gv.SetRowCellValue(e.RowHandle, col_SalesPersonCode, lastValue);
                }
            }
        }

        private void gC_InvoiceLine_KeyDown(object sender, KeyEventArgs e)
        {
            GridControl gC = sender as GridControl;
            GridView gV = gC.MainView as GridView;

            StandartKeys(e);

            if (gV.SelectedRowsCount > 0)
            {
                if (e.KeyCode == Keys.Delete && gV.ActiveEditor == null)
                {
                    string claim = "DeleteLine" + dcProcess.ProcessCode;
                    bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, claim);
                    if (!currAccHasClaims)
                    {
                        MessageBox.Show(Resources.Common_NoPermission);
                        return;
                    }

                    if (MessageBox.Show(
                            Resources.Form_Invoice_RowDeleteQuestion,
                            Resources.Common_Confirm,
                            MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;

                    gV.DeleteSelectedRows();
                }

                if (e.KeyCode == Keys.C && e.Control)
                {
                    string cellValue = gV.GetFocusedValue()?.ToString();
                    if (!string.IsNullOrEmpty(cellValue))
                    {
                        Clipboard.SetText(cellValue);
                        e.Handled = true;
                    }
                }

                if (e.KeyCode == Keys.F5)
                {
                    object productCode = gV.GetFocusedRowCellValue(col_ProductCode);
                    if (productCode != null)
                    {
                        DcReport dcReport = efMethods.SelectReport(1004);

                        string filter = "[ProductCode] = '" + productCode + "' and [CurrAccCode] = '" + trInvoiceHeader.CurrAccCode + "'";
                        string activeFilterStr = "[StoreCode] = \'" + Authorization.StoreCode + "\'";
                        FormReportGrid formGrid = new(dcReport.ReportQuery, filter, dcReport, activeFilterStr);
                        formGrid.Show();
                    }
                }
            }
        }

        private void StandartKeys(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                SelectCurrAcc();

            if (e.KeyCode == Keys.F2)
            {
                gV_InvoiceLine.FocusedColumn = col_ProductCode;
                gV_InvoiceLine.ShowEditor();
                if (gV_InvoiceLine.ActiveEditor is ButtonEdit)
                    SelectProduct(gV_InvoiceLine.ActiveEditor);

                gV_InvoiceLine.CloseEditor();

                e.Handled = true;   // Stop the character from being entered into the control.
            }
        }

        private void gV_InvoiceLine_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
        }

        private void gV_InvoiceLine_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Value is null)
                return;

            string value = e.Value.ToString()?.Trim();
            if (string.IsNullOrWhiteSpace(value))
                return;

            DcProduct product = null;

            if (e.Column == col_ProductCode)
                product = efMethods.SelectProduct(value, productTypeArr);
            else if (e.Column == colBarcode)
                product = efMethods.SelectProductByBarcode(value);
            else if (e.Column == colSerialNumberCode)
                product = efMethods.SelectProductBySerialNumber(value);

            if (product is null)
                return;

            if (e.Column != col_ProductCode)
                gV_InvoiceLine.SetRowCellValue(e.RowHandle, col_ProductCode, product.ProductCode);

            FillRow(e.RowHandle, product);

            gV_InvoiceLine.UpdateCurrentRow();
        }

        private void gV_InvoiceLine_ValidateRow(object sender, ValidateRowEventArgs e)
        {
        }

        private void gV_InvoiceLine_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
        }

        private void gV_InvoiceLine_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            var view = (GridView)sender;
            GridColumn column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;
            var tr = view.GetFocusedRow() as TrInvoiceLine;

            string input = (e.Value ??= string.Empty).ToString();

            if (string.IsNullOrWhiteSpace(input))
            {
                if (Type.GetTypeCode(column.ColumnType) is TypeCode.Int32 or TypeCode.Int64
                    or TypeCode.Decimal or TypeCode.Double
                    or TypeCode.Single or TypeCode.Int16
                    or TypeCode.Byte)
                {
                    e.Value = Activator.CreateInstance(column.ColumnType); // default(0)
                }
                else
                {
                    e.Value = null;
                }

                return;
            }

            if (column == colBarcode || column == col_ProductCode || column == colSerialNumberCode)
            {
                DcProduct product = null;

                if (column == col_ProductCode)
                    product = efMethods.SelectProduct(input, productTypeArr);
                else if (column == colBarcode)
                    product = efMethods.SelectProductByBarcode(input);
                else if (column == colSerialNumberCode)
                {
                    bool sN_Exist = efMethods.EntityExists<DcSerialNumber>(input);
                    if (!sN_Exist)
                    {
                        e.Valid = false;
                        e.ErrorText = Resources.Form_Invoice_SerialNumberNotFound;
                        return;
                    }

                    product = efMethods.SelectProductBySerialNumber(input);
                }

                if (product == null)
                {
                    string entityName = dcProcess.ProcessCode == "EX"
                        ? Resources.Form_Invoice_Expense
                        : Resources.Form_Invoice_Product;

                    e.Valid = false;
                    e.ErrorText = string.Format(
                        Resources.Form_Invoice_EntityNotFoundOrDisabled,
                        entityName);

                    return;
                }

                string returnProductCode = efMethods.SelectReturnLinesByInvoiceLine(tr.InvoiceLineId)
                                                    .FirstOrDefault()?.ProductCode;

                if (!string.IsNullOrEmpty(returnProductCode) && product.ProductCode != returnProductCode)
                {
                    e.Valid = false;
                    e.ErrorText = Resources.Form_Invoice_ReturnOperationExists_CannotChangeProductCode;
                    return;
                }

                string waybillProductCode = efMethods.SelectWaybillByInvoiceLine(tr.InvoiceLineId)
                                                     .FirstOrDefault()?.ProductCode;

                if (!string.IsNullOrEmpty(waybillProductCode) && product.ProductCode != waybillProductCode)
                {
                    e.Valid = false;
                    e.ErrorText = Resources.Form_Invoice_HandOverOperationExists_CannotChangeProductCode;
                    return;
                }

                if (tr.RelatedLineId is not null)
                {
                    string invoiceProductCode = efMethods.SelectInvoiceLineByReturnLine(tr.RelatedLineId, tr.TrInvoiceHeader.ProcessCode)
                                                         .FirstOrDefault()?.ProductCode;

                    if (!string.IsNullOrEmpty(invoiceProductCode) && product.ProductCode != invoiceProductCode)
                    {
                        e.Valid = false;
                        e.ErrorText = Resources.Form_Invoice_RelatedReturnLineExists_CannotChangeProductCode;
                        return;
                    }

                    string invoiceProductCode2 = efMethods.SelectInvoiceLinesByLineId(tr.RelatedLineId)
                                                          .FirstOrDefault()?.ProductCode;

                    if (!string.IsNullOrEmpty(invoiceProductCode2) && product.ProductCode != invoiceProductCode2)
                    {
                        e.Valid = false;
                        e.ErrorText = Resources.Form_Invoice_RelatedHandOverLineExists_CannotChangeProductCode;
                        return;
                    }
                }

                if (new[] { "RP", "WP", "RS", "WS", "IS", "IT" }.Contains(trInvoiceHeader.ProcessCode)
                    && ((!trInvoiceHeader.IsReturn && !(bool)CustomExtensions.DirectionIsIn(trInvoiceHeader.ProcessCode))
                        || (trInvoiceHeader.IsReturn && !(bool)CustomExtensions.DirectionIsIn(trInvoiceHeader.ProcessCode))))
                {
                    var prodType = efMethods.SelectEntityById<DcProduct>(product.ProductCode)?.ProductTypeCode;
                    if (prodType == 3) // is service
                        return;

                    string wareHouse = lUE_WarehouseCode.EditValue?.ToString();
                    if (trInvoiceHeader.IsReturn && trInvoiceHeader.ProcessCode == "IT")
                        wareHouse = lUE_ToWarehouseCode.EditValue?.ToString();

                    bool permitNegativeStock = Convert.ToBoolean(lUE_WarehouseCode.GetColumnValue("PermitNegativeStock"));
                    decimal balance = CalcProductBalance(tr, product.ProductCode, wareHouse, 0);

                    if (!permitNegativeStock && tr.Qty > balance)
                    {
                        e.Valid = false;
                        e.ErrorText = Resources.Form_Invoice_NoStockQuantity;
                        return;
                    }
                }
            }
            else if (column == colQty)
            {
                if (new[] { "RP", "WP", "RS", "WS", "IS", "IT" }.Contains(trInvoiceHeader.ProcessCode)
                    && ((!trInvoiceHeader.IsReturn && !(bool)CustomExtensions.DirectionIsIn(trInvoiceHeader.ProcessCode))
                        || (trInvoiceHeader.IsReturn && !(bool)CustomExtensions.DirectionIsIn(trInvoiceHeader.ProcessCode))))
                {
                    var prodType = efMethods.SelectEntityById<DcProduct>(tr?.ProductCode)?.ProductTypeCode;
                    if (prodType == 3) // is service
                        return;

                    string wareHouse = lUE_WarehouseCode.EditValue?.ToString();
                    if (trInvoiceHeader.IsReturn && trInvoiceHeader.ProcessCode == "IT")
                        wareHouse = lUE_ToWarehouseCode.EditValue?.ToString();

                    bool permitNegativeStock = Convert.ToBoolean(lUE_WarehouseCode.GetColumnValue("PermitNegativeStock"));
                    decimal balance = CalcProductBalance(tr, tr.ProductCode, wareHouse, tr.Qty);

                    if (!permitNegativeStock && Convert.ToDecimal(e.Value) > balance && !trInvoiceHeader.IsReturn)
                    {
                        e.Valid = false;
                        e.ErrorText = Resources.Form_Invoice_NoStockQuantity;
                        return;
                    }
                }

                decimal returnSum = Math.Abs(efMethods.SelectReturnLinesByInvoiceLine(tr.InvoiceLineId)
                                                     .Sum(x => x.QtyIn - x.QtyOut));
                if (Convert.ToDecimal(e.Value) < returnSum)
                {
                    e.Valid = false;
                    e.ErrorText = string.Format(
                        Resources.Form_Invoice_ReturnQtyLessThanExisting,
                        returnSum);
                    return;
                }

                var invoiceLines = efMethods.SelectInvoiceLineByReturnLine(
                                       tr.RelatedLineId,
                                       tr.TrInvoiceHeader?.ProcessCode
                                   );

                decimal invoiceSum = Math.Abs(invoiceLines.Sum(x => x.QtyIn - x.QtyOut));

                if (trInvoiceHeader.IsReturn && invoiceLines.Any() && Convert.ToDecimal(e.Value) > invoiceSum)
                {
                    e.Valid = false;
                    e.ErrorText = string.Format(
                        Resources.Form_Invoice_ReturnQtyGreaterThanSale,
                        invoiceSum);
                    return;
                }

                decimal waybillSum = Math.Abs(efMethods.SelectWaybillByInvoiceLine(tr.InvoiceLineId)
                                                     .Sum(x => x.QtyIn - x.QtyOut));
                if (Convert.ToDecimal(e.Value) < waybillSum)
                {
                    e.Valid = false;
                    e.ErrorText = string.Format(
                        Resources.Form_Invoice_HandOverQtyLessThanDelivery,
                        waybillSum);
                    return;
                }

                decimal invoiceSum2 = Math.Abs(efMethods.SelectInvoiceLinesByLineId(tr.RelatedLineId)
                                                      .Sum(x => x.QtyIn - x.QtyOut));

                if (trInvoiceHeader.ProcessCode == "WO" && Convert.ToDecimal(e.Value) > invoiceSum2)
                {
                    e.Valid = false;
                    e.ErrorText = string.Format(
                        Resources.Form_Invoice_HandOverQtyGreaterThanSale,
                        invoiceSum2);
                    return;
                }

                if (!string.IsNullOrEmpty(trInvoiceHeader.CurrAccCode)
                    && new[] { "RP", "WP", "RS", "WS", "IS" }.Contains(trInvoiceHeader.ProcessCode)
                    && ((!trInvoiceHeader.IsReturn && !(bool)CustomExtensions.DirectionIsIn(trInvoiceHeader.ProcessCode))
                        || (trInvoiceHeader.IsReturn && (bool)CustomExtensions.DirectionIsIn(trInvoiceHeader.ProcessCode))))
                {
                    DcCurrAcc dc = efMethods.SelectCurrAcc(trInvoiceHeader.CurrAccCode);
                    decimal currAccBalance = CalcCurrAccCreditBalance(Convert.ToInt32(e.Value));

                    if (Math.Abs(currAccBalance) > dc.CreditLimit && dc.CreditLimit != 0 && Convert.ToInt32(e.Value) != 0)
                    {
                        e.Valid = false;
                        e.ErrorText = Resources.Form_Invoice_CreditLimitExceeded;
                        return;
                    }
                }
            }
            else if (column == col_SalesPersonCode)
            {
                var acc = efMethods.SelectSalesPerson(input);
                if (acc == null || acc.CurrAccTypeCode != 3)
                {
                    e.Valid = false;
                    e.ErrorText = Resources.Form_Invoice_SalesPersonNotFound;
                    return;
                }
            }
            else if (column == colWorkerCode)
            {
                var acc = efMethods.SelectWorker(input);
                if (acc == null || acc.CurrAccTypeCode != 3)
                {
                    e.Valid = false;
                    e.ErrorText = Resources.Form_Invoice_WorkerNotFound;
                }
            }
        }


        private void gV_InvoiceLine_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = Resources.Common_Attention;
        }

        private decimal CalcCurrAccCreditBalance(int eValue)
        {
            object objPriceLoc = gV_InvoiceLine.GetFocusedRowCellValue(colPriceLoc);
            decimal newNetAmountLoc = eValue * Convert.ToDecimal(objPriceLoc ??= 0);
            decimal oldNetAmountLoc = Convert.ToDecimal(gV_InvoiceLine.GetFocusedRowCellValue(colNetAmountLoc));

            decimal newSummaryValue = newNetAmountLoc - oldNetAmountLoc; // + oldSummaryValue;

            decimal balanceAfter = CurrAccBalanceBefore - newSummaryValue;

            return balanceAfter;
        }

        private decimal CalcNetAmountSummmaryValue()
        {
            decimal sum = 0;

            for (int i = 0; i < gV_InvoiceLine.DataRowCount; i++)
            {
                object value = gV_InvoiceLine.GetRowCellValue(i, colNetAmountLoc);

                if (value != null && value != DBNull.Value)
                    sum += Convert.ToDecimal(value);
            }

            return sum;
            //return (decimal)colNetAmountLoc.SummaryItem.SummaryValue
        }

        private decimal CalcAmountSummmaryValue()
        {
            decimal sum = 0;

            for (int i = 0; i < gV_InvoiceLine.DataRowCount; i++)
            {
                object value = gV_InvoiceLine.GetRowCellValue(i, colAmountLoc);

                if (value != null && value != DBNull.Value)
                    sum += Convert.ToDecimal(value);
            }

            return sum;
            //return (decimal)colAmountLoc.SummaryItem.SummaryValue
        }

        private decimal CalcProductBalance(TrInvoiceLine trInvoiceLine, string productCode, string wareHouse, decimal presentQty)
        {
            if (trInvoiceLine is not null && !String.IsNullOrEmpty(productCode))
            {
                if (!String.IsNullOrEmpty(trInvoiceLine.SerialNumberCode))
                    return efMethods.SelectProductBalanceSerialNumber(productCode, wareHouse, trInvoiceLine.SerialNumberCode) + presentQty;
                else
                    return efMethods.SelectProductBalance(productCode, wareHouse) + presentQty;
            }
            else return 0;
        }

        private void repoBtnEdit_ProductCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            SelectProduct(sender);
        }

        private void repoBtnEdit_SalesPersonCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            SelectSalesPerson(sender);
        }

        private void repoBtnEdit_WorkerCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            SelectWorker(sender);
        }

        private void repoBtnEdit_SerialNumberCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            string productCode = gV_InvoiceLine.GetFocusedRowCellValue(col_ProductCode)?.ToString();

            using FormCommonList<DcSerialNumber> form = new("SN", nameof(DcSerialNumber.SerialNumberCode), editor.EditValue?.ToString(), nameof(DcSerialNumber.ProductCode), productCode);

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

        BaseEdit editorCustom;
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

            GridView view = sender as GridView;
            editorCustom = view.ActiveEditor;
            editorCustom.DoubleClick += editor_DoubleClick;
        }

        void gV_InvoiceLine_HiddenEditor(object sender, EventArgs e)
        {
            editorCustom.DoubleClick -= editor_DoubleClick;
            editorCustom = null;
        }

        private void gV_InvoiceLine_DoubleClick(object sender, EventArgs e)
        {
        }

        void editor_DoubleClick(object sender, EventArgs e)
        {
            BaseEdit editor = (BaseEdit)sender;
            GridControl grid = editor.Parent as GridControl;
            GridView view = grid.FocusedView as GridView;
            Point pt = grid.PointToClient(Control.MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                if (info.Column == col_ProductCode)
                    SelectProduct(sender);
                else if (info.Column == col_SalesPersonCode)
                    SelectSalesPerson(sender);
                else if (info.Column == colWorkerCode)
                    SelectWorker(sender);
            }
        }

        private void SelectSalesPerson(object sender)
        {
            ButtonEdit editor = (ButtonEdit)sender;

            string value = editor.EditValue?.ToString();

            using FormCurrAccList form = new(new byte[] { 3 }, false, value, new byte[] { 1 });

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                editor.EditValue = form.dcCurrAcc.CurrAccCode;
            }
        }

        private void SelectWorker(object sender)
        {
            ButtonEdit editor = (ButtonEdit)sender;

            string value = editor.EditValue?.ToString();

            using FormCurrAccList form = new(new byte[] { 3 }, false, value, new byte[] { 3 });

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                editor.EditValue = form.dcCurrAcc.CurrAccCode;
            }
        }

        private void SelectProduct(object sender)
        {
            string productCode = "";
            if (gV_InvoiceLine.GetFocusedRowCellValue(col_ProductCode) != null)
                productCode = gV_InvoiceLine.GetFocusedRowCellValue(col_ProductCode).ToString();

            ButtonEdit editor = (ButtonEdit)sender;

            using FormProductList form = new(productTypeArr, false, productCode);

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    editor.EditValue = form.dcProduct?.ProductCode;

                    if (!gV_InvoiceLine.PostEditor()) // 🔹 Post editor to trigger ValidatingEditor for the ProductCode cell
                        return; // validation failed in ValidatingEditor

                    gV_InvoiceLine.FocusedColumn = colQty;
                    gV_InvoiceLine.ShowEditor();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void gV_InvoiceLine_RowUpdated(object sender, RowObjectEventArgs e)
        {
            if (Settings.Default.AppSetting.AutoSave)
                SaveInvoice();
        }

        private void gV_InvoiceLine_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {

        }

        private void gV_InvoiceLine_RowDeleted(object sender, RowDeletedEventArgs e)
        {
            if (Settings.Default.AppSetting.AutoSave)
                SaveInvoice();
        }

        private void gV_InvoiceLine_RowDeleting(object sender, RowDeletingEventArgs e)
        {
            GridView view = sender as GridView;
            Guid invoiceLineId = (Guid)view.GetRowCellValue(e.RowHandle, col_InvoiceLineId);

            if (efMethods.ReturnExistByInvoiceLine(invoiceLineId))
            {
                e.Cancel = true;
                XtraMessageBox.Show(
                    Resources.Form_Invoice_ProductHasReturn,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            if (efMethods.WaybillExistByInvoiceLine(invoiceLineId))
            {
                e.Cancel = true;
                XtraMessageBox.Show(
                    Resources.Form_Invoice_ProductHasDelivery,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        Guid quidHead;
        private void SaveInvoice()
        {
            dbContext.SaveChanges(false, Authorization.CurrAccCode);

            if (new string[] { "IT" }.Contains(trInvoiceHeader.ProcessCode))
                InitilizeTransfer();

            dbContext.ChangeTracker.AcceptAllChanges();

            if (new string[] { "IS" }.Contains(trInvoiceHeader.ProcessCode) && trInvoiceHeader.TrInstallment is not null)
                SaveInstallmentGarantors();

            if (new string[] { "EX", "EI" }.Contains(trInvoiceHeader.ProcessCode))
                SavePayment();

            SaveSession();

            Tag = btnEdit_DocNum.EditValue;
        }

        private void InitilizeTransfer()
        {
            IEnumerable<EntityEntry> entityEntries = dbContext.ChangeTracker.Entries();

            EntityEntry? entryHeader = entityEntries.FirstOrDefault(x => x.Entity is TrInvoiceHeader);

            if (entryHeader is not null)
            {
                TrInvoiceHeader trIH = (TrInvoiceHeader)entryHeader.CurrentValues.ToObject();

                string invoHeadStr = trIH.InvoiceHeaderId.ToString();

                quidHead = Guid.Parse(invoHeadStr.Replace(invoHeadStr.Substring(0, 8), "00000000")); // 00000000-ED42-11CE-BACD-00AA0057B223

                using subContext context2 = new();

                TrInvoiceHeader copyTrIH = trIH;
                copyTrIH.InvoiceHeaderId = quidHead;
                string temp = trIH.WarehouseCode;
                copyTrIH.WarehouseCode = trIH.ToWarehouseCode;
                copyTrIH.ToWarehouseCode = temp;
                copyTrIH.StoreCode = trIH.CurrAccCode ??= trIH.StoreCode;
                copyTrIH.IsMainTF = false;

                switch (entryHeader.State)
                {
                    case EntityState.Added: context2.TrInvoiceHeaders.Add(copyTrIH); break;
                    case EntityState.Modified: context2.TrInvoiceHeaders.Update(copyTrIH); break;
                    case EntityState.Deleted: context2.TrInvoiceHeaders.Remove(copyTrIH); break;
                    default: break;
                }
                context2.SaveChanges(Authorization.CurrAccCode);
            }

            EntityEntry? entryLine = entityEntries.FirstOrDefault(x => x.Entity is TrInvoiceLine);

            if (entryLine is not null)
            {
                TrInvoiceLine trIL = (TrInvoiceLine)entryLine.CurrentValues.ToObject();

                string invoLineStr = trIL.InvoiceLineId.ToString();
                Guid quidLine = Guid.Parse(invoLineStr.Replace(invoLineStr.Substring(0, 8), "00000000")); // 00000000-ED42-11CE-BACD-00AA0057B223

                using subContext context2 = new();

                TrInvoiceLine newTrIL = trIL;
                newTrIL.InvoiceHeaderId = quidHead;
                newTrIL.InvoiceLineId = quidLine;
                newTrIL.QtyIn = trIL.QtyOut;
                newTrIL.QtyOut -= trIL.QtyOut;

                switch (entryLine.State)
                {
                    case EntityState.Added: context2.TrInvoiceLines.Add(newTrIL); break;
                    case EntityState.Modified: context2.TrInvoiceLines.Update(newTrIL); break;
                    case EntityState.Deleted: context2.TrInvoiceLines.Remove(newTrIL); break;
                    default: break;
                }
                context2.SaveChanges(Authorization.CurrAccCode);
            }
        }

        private void SaveInstallmentGarantors()
        {
            var trInstallmentGuarantors = trInstallmentGuarantorsBindingSource.DataSource as BindingList<TrInstallmentGuarantor>;

            if (trInstallmentGuarantors != null && trInvoiceHeader.TrInstallment.InstallmentId > 0)
            {
                foreach (var garantor in trInstallmentGuarantors)
                    if (garantor.InstallmentId == 0)
                        garantor.InstallmentId = trInvoiceHeader.TrInstallment.InstallmentId;
            }

            dbContext2.SaveChanges();
        }

        private void SavePayment()
        {
            TrPaymentHeader trPaymentHeader = PaymentHeaderDefaults(trInvoiceHeader);
            TrPaymentLine trPaymentLine = PaymentLineDefaults();

            decimal invoiceSumLoc = Math.Abs(efMethods.SelectInvoiceSum(trInvoiceHeader.InvoiceHeaderId));

            if ((bool)CustomExtensions.DirectionIsIn(trInvoiceHeader.ProcessCode))
                invoiceSumLoc *= (-1);

            bool isNegativ = false;

            if (invoiceSumLoc < 0)
                isNegativ = true;

            bool paymentHeadExist = efMethods.PaymentExistByInvoice(trInvoiceHeader.InvoiceHeaderId);
            if (paymentHeadExist)
                trPaymentHeader = efMethods.SelectPaymentHeaderByInvoice(trInvoiceHeader.InvoiceHeaderId);
            else
            {
                string NewDocNum = efMethods.GetNextDocNum(true, "PA", nameof(TrPaymentHeader.DocumentNumber), nameof(subContext.TrPaymentHeaders), 6);
                trPaymentHeader.DocumentNumber = NewDocNum;
                trPaymentHeader.Description = trInvoiceHeader.Description;

                efMethods.InsertEntity(trPaymentHeader);
            }

            efMethods.DeletePaymentLinesByPaymentHeader(trPaymentHeader.PaymentHeaderId);

            List<TrInvoiceLine> trInvoiceLines = efMethods.SelectInvoiceLines(trInvoiceHeader.InvoiceHeaderId);
            foreach (TrInvoiceLine il in trInvoiceLines)
            {
                if (il.NetAmount != 0)
                {
                    trPaymentLine.PaymentHeaderId = trPaymentHeader.PaymentHeaderId;
                    trPaymentLine.PaymentLineId = il.InvoiceLineId;
                    trPaymentLine.Payment = isNegativ ? il.NetAmount * (-1) : il.NetAmount;
                    trPaymentLine.CurrencyCode = il.CurrencyCode;
                    trPaymentLine.ExchangeRate = il.ExchangeRate;
                    trPaymentLine.CashRegisterCode = btn_CashRegCode.EditValue?.ToString();
                    trPaymentLine.LineDescription = il.LineDescription;
                    trPaymentLine.PaymentLoc = isNegativ ? il.NetAmountLoc * (-1) : il.NetAmountLoc;
                    efMethods.InsertEntity(trPaymentLine);
                }
            }

            CalcPaidAmount();
        }

        private TrPaymentHeader PaymentHeaderDefaults(TrInvoiceHeader trInvoiceHeader)
        {
            TrPaymentHeader trPaymentHeader = new();

            Guid PaymentHeaderId = Guid.NewGuid();

            bool invoiceExist = trInvoiceHeader.InvoiceHeaderId != Guid.Empty && trInvoiceHeader != null;

            trPaymentHeader.PaymentHeaderId = PaymentHeaderId;
            trPaymentHeader.CurrAccCode = trInvoiceHeader.CurrAccCode;
            trPaymentHeader.ProcessCode = dcProcess.ProcessCode;
            trPaymentHeader.CreatedUserName = Authorization.CurrAccCode;
            trPaymentHeader.OfficeCode = Authorization.OfficeCode;
            trPaymentHeader.StoreCode = Authorization.StoreCode;
            trPaymentHeader.IsMainTF = true;
            trPaymentHeader.DocumentDate = trInvoiceHeader.DocumentDate;
            trPaymentHeader.DocumentTime = trInvoiceHeader.DocumentTime;
            if (invoiceExist)
            {
                trPaymentHeader.InvoiceHeaderId = trInvoiceHeader.InvoiceHeaderId;
                trPaymentHeader.PaymentKindId = 2;
            }
            else
                trPaymentHeader.PaymentKindId = 1;

            trPaymentHeader.InvoiceHeaderId = trInvoiceHeader.InvoiceHeaderId;
            trPaymentHeader.OperationDate = trInvoiceHeader.DocumentDate;
            trPaymentHeader.OperationTime = trInvoiceHeader.DocumentTime;

            return trPaymentHeader;
        }

        private TrPaymentLine PaymentLineDefaults()
        {
            TrPaymentLine trPaymentLine = new();
            trPaymentLine.PaymentTypeCode = PaymentType.Cash;
            trPaymentLine.PaymentMethodId = 1;
            trPaymentLine.CurrencyCode = Settings.Default.AppSetting.LocalCurrencyCode;
            trPaymentLine.ExchangeRate = 1f;
            string storeCode = trInvoiceHeader.StoreCode;
            trPaymentLine.CashRegisterCode = efMethods.SelectCashRegisterByTerminal(Settings.Default.TerminalId);
            trPaymentLine.CreatedUserName = Authorization.CurrAccCode;

            return trPaymentLine;
        }

        private void bBI_SaveAndNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {

                decimal summaryInvoice = CalcNetAmountSummmaryValue();

                if (summaryInvoice != 0 || trInvoiceHeader.ProcessCode == "IT")
                {
                    SaveInvoice();

                    ClearControlsAddNew();
                }
                else if (XtraMessageBox.Show("Ödəmə 0a bərabərdir! \n Fakturaya qayıtmaq istəyirsiz? ", "Diqqət", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    ClearControlsAddNew();
            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }
        }

        private void SaveSession()
        {
            object warehouseCode = lUE_WarehouseCode.EditValue;
            if (warehouseCode is not null)
            {
                Settings.Default.WarehouseCode = lUE_WarehouseCode.EditValue.ToString();
                Settings.Default.Save();
            }
        }

        private void MakePayment(decimal summaryInvoice)
        {
            decimal prePaid = efMethods.SelectPaymentLinesSumByInvoice(trInvoiceHeader.InvoiceHeaderId, trInvoiceHeader.CurrAccCode);
            decimal pay = Math.Max(Math.Round(Math.Abs(summaryInvoice) - Math.Abs(prePaid), 4), 0);

            using FormPayment formPayment = new(PaymentType.Cash, pay, trInvoiceHeader, dcLoyaltyCard);
            bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, formPayment.Name);
            if (!currAccHasClaims)
            {
                MessageBox.Show("Yetkiniz yoxdur! ");
                return;
            }
            else
            {
                if (formPayment.ShowDialog(this) == DialogResult.OK)
                {
                    CalcPaidAmount();
                }
            }
        }

        private void bBI_New_ItemClick(object sender, ItemClickEventArgs e)
        {
            ClearControlsAddNew();
        }

        private void bBI_reportPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowReportPreview();
        }

        private void ShowReportPreview()
        {
            DcReport dcReport = efMethods.SelectReportByName("Report_Embedded_InvoiceReport");

            foreach (var item in dcReport.DcReportVariables)
                if (item.VariableProperty == nameof(TrInvoiceHeader.InvoiceHeaderId))
                    item.VariableValue = trInvoiceHeader.InvoiceHeaderId.ToString();

            FormReportPreview form = new(dcReport.ReportQuery, "", dcReport);
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void bBI_Save_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                decimal summaryInvoice = CalcNetAmountSummmaryValue();

                if (summaryInvoice != 0)
                    SaveInvoice();
            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }
        }

        private void bBI_Payment_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                decimal summaryInvoice = CalcNetAmountSummmaryValue();

                if (summaryInvoice != 0)
                    MakePayment(summaryInvoice);

            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }
        }

        private void bBI_DeleteInvoice_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!efMethods.EntityExists<TrInvoiceHeader>(trInvoiceHeader.InvoiceHeaderId))
            {
                XtraMessageBox.Show(Resources.Form_Invoice_NoInvoiceToDelete);
                return;
            }

            string claim = "DeleteInvoice" + dcProcess.ProcessCode;
            bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, claim);
            if (!currAccHasClaims)
            {
                MessageBox.Show(Resources.Common_NoPermission);
                return;
            }

            List<TrInvoiceLine> invoicelines = efMethods.SelectInvoiceLines(trInvoiceHeader.InvoiceHeaderId);

            foreach (var invoiceline in invoicelines)
            {
                if (efMethods.ReturnExistByInvoiceLine(invoiceline.InvoiceLineId))
                {
                    XtraMessageBox.Show(
                        Resources.Form_Invoice_ProductHasReturn,
                        Resources.Common_Attention,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                if (efMethods.WaybillExistByInvoiceLine(invoiceline.InvoiceLineId))
                {
                    XtraMessageBox.Show(
                        Resources.Form_Invoice_ProductHasDelivery,
                        Resources.Common_Attention,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
            }

            if (XtraMessageBox.Show(
                    xtraMessageBox(
                        Resources.Common_Attention,
                        Resources.Form_Invoice_DeleteInvoiceQuestion,
                        "DeleteInvoice")) == DialogResult.OK)
            {
                bool currAccHasPayClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "PaymentDetail");
                bool currAccHasExpenceClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "Expense");
                bool currAccHasDeleteEXClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "DeleteInvoiceEX");
                bool currAccHasDeleteISClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "DeleteInvoiceIS");

                if (efMethods.PaymentExistByInvoice(trInvoiceHeader.InvoiceHeaderId))
                    if (new string[] { "EX", "EI" }.Contains(dcProcess.ProcessCode))
                        efMethods.DeletePaymentsByInvoiceId(trInvoiceHeader.InvoiceHeaderId);
                    else if (XtraMessageBox.Show(
                                 xtraMessageBox(
                                     Resources.Common_Attention,
                                     Resources.Form_Invoice_DeletePaymentsForInvoiceQuestion,
                                     "DeletePayment")) == DialogResult.OK)
                        if (currAccHasPayClaims)
                            efMethods.DeletePaymentsByInvoiceId(trInvoiceHeader.InvoiceHeaderId);
                        else
                            XtraMessageBox.Show(Resources.Form_Invoice_NoPermissionDeletePayment);

                if (efMethods.ExpensesExistByInvoiceId(trInvoiceHeader.InvoiceHeaderId))
                    if (XtraMessageBox.Show(
                            xtraMessageBox(
                                Resources.Common_Attention,
                                Resources.Form_Invoice_DeleteExpensesForInvoiceQuestion,
                                "DeleteExpenses")) == DialogResult.OK)
                        if (currAccHasExpenceClaims)
                            if (currAccHasDeleteEXClaims)
                                efMethods.DeleteExpensesByInvoiceId(trInvoiceHeader.InvoiceHeaderId);
                            else
                                XtraMessageBox.Show(Resources.Form_Invoice_NoPermissionDeleteExpense);
                        else
                            XtraMessageBox.Show(Resources.Form_Invoice_NoPermissionExpense);

                efMethods.DeleteInvoice(trInvoiceHeader.InvoiceHeaderId);

                ClearControlsAddNew();
            }
        }

        private XtraMessageBoxArgs xtraMessageBox(string caption, string text, string imageName)
        {
            XtraMessageBoxArgs argsDeleteInvoice = new XtraMessageBoxArgs
            {
                Caption = caption,
                Text = text,
                Buttons = new[] { DialogResult.OK, DialogResult.Cancel },
            };
            argsDeleteInvoice.ImageOptions.SvgImage = svgImageCollection1[imageName];
            return argsDeleteInvoice;
        }

        private void bBI_PaymentDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show(
                    Resources.Form_Invoice_DeletePaymentsQuestion,
                    Resources.Common_Attention,
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                efMethods.DeletePaymentsByInvoiceId(trInvoiceHeader.InvoiceHeaderId);
                CalcPaidAmount();
            }
        }


        private void repoLUE_CurrencyCode_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit textEditor = (LookUpEdit)sender;
            float exRate = efMethods.SelectEntityById<DcCurrency>(textEditor.EditValue.ToString()).ExchangeRate;
            gV_InvoiceLine.SetFocusedRowCellValue(colExchangeRate, exRate);
        }

        private void bBI_SaveAndQuit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                decimal summInvoice = CalcNetAmountSummmaryValue();

                if (summInvoice != 0 || trInvoiceHeader.ProcessCode == "IT")
                {
                    SaveInvoice();
                    Close();
                }
                else if (XtraMessageBox.Show(
                             Resources.Form_Invoice_PaymentIsZeroReturnToInvoice,
                             Resources.Common_Attention,
                             MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    Close();
                }
            }
            else
            {
                string combinedStr = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedStr);
            }
        }

        private void gV_InvoiceLine_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView gV = sender as GridView;

            Color readOnlyBackColor = Color.LightGray;
            try
            {
                if (e.RowHandle >= 0 && (!gV.OptionsBehavior.Editable || !e.Column.OptionsColumn.AllowEdit || e.Column.ReadOnly))
                {
                    GridViewInfo viewInfo = gV.GetViewInfo() as GridViewInfo;
                    GridDataRowInfo rowInfo = viewInfo.RowsInfo.GetInfoByHandle(e.RowHandle) as GridDataRowInfo;

                    if (rowInfo == null || (rowInfo != null && rowInfo.ConditionInfo.GetCellAppearance(e.Column) == null))
                    {
                        bool hasrules = false;
                        foreach (GridFormatRule rule in gV.FormatRules)
                        {
                            if (rule.IsFit(e.CellValue, gV.GetDataSourceRowIndex(e.RowHandle)))
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
                if (e.Column.AppearanceCell.Options.UseBackColor && gV.IsCellSelected(e.RowHandle, e.Column))
                    e.Appearance.BackColor = gV.PaintAppearance.SelectedRow.BackColor;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }

        private void dataLayoutControls_KeyDown(object sender, KeyEventArgs e)
        {
            StandartKeys(e);
        }

        private void bBI_CopyInvoice_ItemClick(object sender, ItemClickEventArgs e)
        {
            Image image = Image.FromStream(GetInvoiceReportImg());
            Clipboard.SetImage(image);
        }

        private MemoryStream GetInvoiceReportImg()
        {
            DcReport dcReport = efMethods.SelectReportByName("Report_Embedded_InvoiceReport");

            foreach (var item in dcReport.DcReportVariables)
                if (item.VariableProperty == nameof(TrInvoiceHeader.InvoiceHeaderId))
                    item.VariableValue = trInvoiceHeader.InvoiceHeaderId.ToString();

            SqlParameter[] sqlParameters;
            dcReport.ReportQuery = reportClass.ApplyFilter(dcReport, dcReport.ReportQuery, "", out sqlParameters);
            List<QueryParameter> qryParams = reportClass.ConvertSqlParametersToQueryParameters(sqlParameters);
            CustomSqlQuery mainQuery = new("Main", dcReport.ReportQuery);
            mainQuery.Parameters.AddRange(qryParams);
            List<CustomSqlQuery> sqlQueries = new(new[] { mainQuery });
            XtraReport xtraReport = reportClass.GetReport(dcReport.ReportName, dcReport.ReportName + ".repx", sqlQueries);

            MemoryStream ms = new();
            xtraReport.ExportToImage(ms, new ImageExportOptions() { Format = ImageFormat.Png, PageRange = "1", ExportMode = ImageExportMode.SingleFile, Resolution = 240 });

            return ms;
        }

        private async void bBI_Whatsapp_ItemClick(object sender, ItemClickEventArgs e)
        {
            MemoryStream memoryStream = GetInvoiceReportImg();
            Clipboard.SetImage(Image.FromStream(memoryStream));
            string phoneNum = efMethods.SelectCurrAcc(trInvoiceHeader.CurrAccCode).PhoneNum;

            SendWhatsApp(phoneNum, "");

            //var TOKEN = "EAAWMnYx6BxYBQcbO6PYlNa7QL9yC19ctbj4SbYwfUdZBWILi0sC28WJrEGgBsE7n1kiWzFFzt9nZBlexQUgVh9mwng15ofi6FlwrN9UZA9X6uABj9RZCc9Opb0mnBg4uMXgJGuvCTWAooR2DbMZBnxeLEMvbU2RJpLphqR4EAGPXtTW0LyBtO697rU33pNipXOejoq9ZAhpyTNPlbQCB39v3J1lfEDxQB3oIvgMfo6TC53ft48iB1d0DzYeBsNgVmQAsEDTy56qF3AgWHr7JgSLdouaCiMkD4ZC82UvKgZDZD";
            //var PHONEID = "758761373995375";

            //using var wa = new WhatsAppClient(TOKEN, PHONEID);

            //var messageId = await wa.UploadAndSendImageAsync(phoneNum, memoryStream, caption: "From MemoryStream", fileName: "pic.jpg", contentType: "image/jpeg");
            //XtraMessageBox.Show($"Sent: {messageId}");
        }

        private void SendWhatsApp(string number, string message)
        {
            if (string.IsNullOrEmpty(number))
            {
                MessageBox.Show(Resources.Form_Invoice_Whatsapp_NumberNotEntered);
                return;
            }

            number = number.Trim();

            string link = $"https://web.whatsapp.com/send?phone={number}&text={Uri.EscapeDataString(message)}";

            string profileName = Settings.Default.AppSetting.WhatsappChromeProfileName;

            ProcessStartInfo startInfo;

            if (!string.IsNullOrEmpty(profileName))
            {
                string profileCode = GetChromeProfileCodeByName(profileName);
                if (profileCode == null)
                {
                    MessageBox.Show(string.Format(Resources.Form_Invoice_Whatsapp_ProfileNotFound, profileName));
                    return;
                }
                else
                {
                    startInfo = new ProcessStartInfo
                    {
                        FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe",
                        Arguments = $"--profile-directory=\"{profileCode}\" \"{link}\"",
                        UseShellExecute = false
                    };
                }
            }
            else
            {
                startInfo = new ProcessStartInfo
                {
                    FileName = link,
                    UseShellExecute = true // UseShellExecute = true opens the URL in the default web browser
                };
            }

            try
            {
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(Resources.Form_Invoice_Whatsapp_FailedToOpenLink, ex.Message));
            }
        }

        private string GetChromeProfileCodeByName(string profileName)
        {
            string localStateFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Google\Chrome\User Data", "Local State");

            if (!File.Exists(localStateFile))
                return null;

            string json = File.ReadAllText(localStateFile);
            JObject localState = JObject.Parse(json);
            var profileInfoCache = localState["profile"]["info_cache"];

            foreach (var profile in profileInfoCache)
            {
                var profileCode = ((JProperty)profile).Name;
                var visibleName = profile.First["name"]?.ToString();
                if (visibleName == profileName)
                    return profileCode;
            }

            return null;
        }

        private void btnEdit_CurrAccCode_EditValueChanging(object sender, ChangingEventArgs e)
        {

        }

        private void btnEdit_CurrAccCode_EditValueChanged(object sender, EventArgs e)
        {
            DcCurrAcc curr = efMethods.SelectEntityById<DcCurrAcc>(btnEdit_CurrAccCode.EditValue?.ToString());
            if (trInvoiceHeader is null || curr is null)
                return;

            trInvoiceHeader.CurrAccCode = curr?.CurrAccCode;
            lbl_CurrAccDesc.Text = curr?.CurrAccDesc + " " + curr?.FirstName + " " + curr?.LastName;

            CurrAccBalanceBefore = Math.Round(efMethods.SelectCurrAccBalance(trInvoiceHeader.CurrAccCode, trInvoiceHeader.DocumentDate.Add(trInvoiceHeader.OperationTime)), 2);

            if (Settings.Default.AppSetting.AutoSave)
                efMethods.UpdatePaymentsCurrAccCode(trInvoiceHeader.InvoiceHeaderId, curr?.CurrAccCode);

            List<DcWarehouse> dcWarehouses = efMethods.SelectWarehousesByStoreIncludeDisabled(trInvoiceHeader.CurrAccCode);
            lUE_ToWarehouseCode.Properties.DataSource = dcWarehouses;

            if (!dcWarehouses.Any(x => x.WarehouseCode == trInvoiceHeader?.ToWarehouseCode))
                trInvoiceHeader.ToWarehouseCode = null;

            if (dcWarehouses is not null)
            {
                DcWarehouse dcWarehouse = dcWarehouses.FirstOrDefault(x => x.IsDefault == true);

                if (dcWarehouse is not null && trInvoiceHeader?.ToWarehouseCode is null)
                    lUE_ToWarehouseCode.EditValue = dcWarehouse.WarehouseCode;
            }
        }

        private void btnEdit_CurrAccCode_Validating(object sender, CancelEventArgs e)
        {
            if (sender is not ButtonEdit editor)
                return;

            dxErrorProvider1.SetError(editor, string.Empty);

            string value = editor.Text?.Trim();

            if (string.IsNullOrEmpty(value))
                return;

            DcCurrAcc curr = efMethods.SelectEntityById<DcCurrAcc>(value);

            if (curr is null)
            {
                SetValidationError(editor, e, Resources.Form_Invoice_NoSuchCurrAcc);
                return;
            }

            decimal netAmountLocSum = CalcNetAmountSummmaryValue();
            decimal currAccBalance = CurrAccBalanceBefore - netAmountLocSum;

            if (!(bool)CustomExtensions.DirectionIsIn(dcProcess.ProcessCode) && curr.CreditLimit > 0 && Math.Abs(currAccBalance) > curr.CreditLimit)
            {
                SetValidationError(editor, e, Resources.Form_Invoice_CreditLimitExceeded);
                return;
            }

            if (trInvoiceHeader.RelatedInvoiceId is not null)
            {
                var returnLine = efMethods
                    .SelectInvoiceLineByReturnHeader(trInvoiceHeader.RelatedInvoiceId, trInvoiceHeader.ProcessCode)
                    .FirstOrDefault();

                if (returnLine is not null && curr.CurrAccCode != returnLine.CurrAccCode)
                {
                    SetValidationError(editor, e, Resources.Form_Invoice_ReturnInvoiceExists_CurrAccCannotChange);
                    return;
                }

                var handoverLine = efMethods
                    .SelectInvoiceLinesByHeaderId(trInvoiceHeader.RelatedInvoiceId)
                    .FirstOrDefault();

                if (handoverLine is not null && curr.CurrAccCode != handoverLine.CurrAccCode)
                {
                    SetValidationError(editor, e, Resources.Form_Invoice_HandOverInvoiceExists_CurrAccCannotChange);
                    return;
                }
            }

            dxErrorProvider1.SetError(editor, string.Empty);
        }

        private void SetValidationError(BaseEdit editor, CancelEventArgs e, string message)
        {
            dxErrorProvider1.SetError(editor, message, ErrorType.Critical);
            e.Cancel = true;
        }

        private void btnEdit_CurrAccCode_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
        }

        private void BBI_ModifyInvoice_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (btnEdit_DocNum.Properties.ReadOnly)
            {
                SetLayoutGroupReadOnly(LCG_Invoice, false);
            }

            else
                SetLayoutGroupReadOnly(LCG_Invoice, true);
        }

        private void SetLayoutGroupReadOnly(LayoutControlGroup group, bool isReadOnly)
        {
            foreach (BaseLayoutItem item in group.Items)
            {
                if (item is not LayoutControlItem lci)
                    continue;

                if (lci.Control is GridControl gridControl)
                {
                    gridControl.Enabled = !isReadOnly;
                    continue;
                }

                if (lci.Control is not BaseEdit baseEdit)
                    continue;

                baseEdit.Properties.ReadOnly = isReadOnly;

                if (baseEdit is ButtonEdit buttonEdit)
                {
                    // Binding yoxdursa, sadəcə çıx (və ya default davranış seç)
                    if (baseEdit.DataBindings == null || baseEdit.DataBindings.Count == 0)
                        continue;

                    if (baseEdit.DataBindings[0].BindingMemberInfo.BindingField != nameof(TrInvoiceHeader.DocumentNumber))
                    {
                        buttonEdit.Properties.Buttons[0].Enabled = !isReadOnly;
                    }
                }
            }
        }


        private void gC_InvoiceLine_EditorKeyPress(object sender, KeyPressEventArgs e)
        {
            GridControl gc = sender as GridControl;
            GridView gv = gc.FocusedView as GridView;

            //if (e.KeyChar == (char)Keys.Return && gv.FocusedColumn == colBarcode)
            //    e.Handled = true;
        }

        private void gC_InvoiceLine_EditorKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) // Barcode Scan Device 
            {
            }
        }

        private void gV_InvoiceLine_KeyDown(object sender, KeyEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.KeyCode == Keys.Enter)
            {
                if (view.FocusedColumn != null && view.IsEditing)
                {
                    if (view.FocusedColumn == colSerialNumberCode)
                    {
                        view.CloseEditor();
                        if (view.FocusedRowHandle == GridControl.NewItemRowHandle)
                            view.FocusedColumn = colSerialNumberCode; // Optionally move to the first column
                        else
                        {
                            view.MoveNext();
                            view.FocusedColumn = colSerialNumberCode; // Optionally move to the first column
                        }
                    }
                    else if (view.FocusedColumn == colBarcode)
                    {
                        view.CloseEditor();
                        if (view.FocusedRowHandle == GridControl.NewItemRowHandle)
                            view.FocusedColumn = colBarcode; // Optionally move to the first column
                        else
                        {
                            view.MoveNext();
                            view.FocusedColumn = colBarcode; // Optionally move to the first column
                        }
                    }
                }
            }
        }

        private void LoadLayout()
        {
            // RP, WP, EX, EI, SB, CI, WI, CN, IT, RS, WS, IS, CO, WO, RPO, RSO

            if (new string[] { "EX", "EI", "CN", "CI", "CO", "IT" }.Contains(dcProcess.ProcessCode))
            {
                btnEdit_CurrAccCode.Enabled = false;
                colBalance.Visible = false;
                col_PosDiscount.Visible = false;
                colProductCost.Visible = false;
                colBenefit.Visible = false;

                BBI_InvoiceExpenses.Visibility = BarItemVisibility.Never;
                RPG_Payment.Visible = false;
                RPG_Installment.Visible = false;

                if (new string[] { "EX", "EI" }.Contains(dcProcess.ProcessCode))
                {
                    colQty.Visible = false;
                    colQty.OptionsColumn.ReadOnly = true;
                    ItemForWarehouseCode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    LCI_CashRegCode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }

                if (new string[] { "CI", "CO", "IT", "CN" }.Contains(dcProcess.ProcessCode))
                {
                    LCG_InfoPayment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    if (dcProcess.ProcessCode == "IT")
                    {
                        btnEdit_CurrAccCode.Enabled = true;
                        col_Price.Visible = false;
                        colCurrencyCode.Visible = false;
                        col_NetAmount.Visible = false;
                    }
                    else if (dcProcess.ProcessCode == "CN")
                    {
                        BBI_CountingStock.Visibility = BarItemVisibility.Always;
                    }
                }
            }
            else if (new string[] { "IS" }.Contains(dcProcess.ProcessCode))
            {
                LCG_InfoInstallment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                LCG_Installment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                RPG_Installment.Visible = true;
            }

            string layoutHeaderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Foxoft", Settings.Default.CompanyCode, "Layout Xml Files", "InvoiceHeader" + dcProcess.ProcessCode + "Layout.xml");

            if (File.Exists(layoutHeaderPath))
                dataLayoutControl1.RestoreLayoutFromXml(layoutHeaderPath);

            string layoutLineFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Foxoft", Settings.Default.CompanyCode, "Layout Xml Files", "InvoiceLine" + dcProcess.ProcessCode + "Layout.xml");

            if (File.Exists(layoutLineFilePath))
                gV_InvoiceLine.RestoreLayoutFromXml(layoutLineFilePath);

            bool currAccHasClaimsPayment = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "PaymentDetail");
            if (!currAccHasClaimsPayment)
                RPG_Payment.Visible = false;

            bool currAccHasClaimsExpences = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "ExpenseOfInvoice");
            if (!currAccHasClaimsExpences)
                BBI_InvoiceExpenses.Visibility = BarItemVisibility.Never;

            bool currAccHasClaimsEditInvoice = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "EditLockedInvoice");
            if (!currAccHasClaimsEditInvoice)
                BBI_EditInvoice.Visibility = BarItemVisibility.Never;

            if (colProductCost != null)
            {
                bool currAccHasClaimsColumn = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, $"Column_{nameof(TrInvoiceLine.ProductCost)}");
                if (!currAccHasClaimsColumn)
                {
                    colProductCost.OptionsColumn.ShowInCustomizationForm = false;
                    colProductCost.Visible = false;
                    colBenefit.OptionsColumn.ShowInCustomizationForm = false;
                    colBenefit.Visible = false;
                }
            }

            if (col_PosDiscount != null)
            {
                bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, nameof(TrInvoiceLine.PosDiscount));
                if (!currAccHasClaims)
                {
                    col_PosDiscount.OptionsColumn.ShowInCustomizationForm = false;
                    col_PosDiscount.Visible = false;
                }
            }

            if (col_Price != null)
            {
                bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "ChangePrice" + dcProcess.ProcessCode);
                if (!currAccHasClaims)
                    col_Price.OptionsColumn.ReadOnly = true;
            }

            colBalance.OptionsColumn.ReadOnly = true;
            colProductCost.OptionsColumn.ReadOnly = true;
            col_NetAmount.OptionsColumn.ReadOnly = true;
            colNetAmountLoc.OptionsColumn.ReadOnly = true;
            col_Amount.OptionsColumn.ReadOnly = true;
            colAmountLoc.OptionsColumn.ReadOnly = true;


            if (!colNetAmountLoc.Summary.Any(x => x.SummaryType == SummaryItemType.Sum))
                colNetAmountLoc.Summary.AddRange(new GridSummaryItem[] { new GridColumnSummaryItem(SummaryItemType.Sum, nameof(TrInvoiceLine.NetAmountLoc), "{0:n2}") });
            if (!colAmountLoc.Summary.Any(x => x.SummaryType == SummaryItemType.Sum))
                colAmountLoc.Summary.AddRange(new GridSummaryItem[] { new GridColumnSummaryItem(SummaryItemType.Sum, nameof(TrInvoiceLine.AmountLoc), "{0:n2}") });
        }

        private void SaveLayout()
        {
            string fileName = "InvoiceLine" + dcProcess.ProcessCode + "Layout.xml";
            string layoutFileDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Foxoft", Settings.Default.CompanyCode, "Layout Xml Files");

            if (!Directory.Exists(layoutFileDir))
                Directory.CreateDirectory(layoutFileDir);
            gV_InvoiceLine.SaveLayoutToXml(Path.Combine(layoutFileDir, fileName));
        }

        private void gV_InvoiceLine_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Column)
            {
                GridViewColumnMenu menu = e.Menu as GridViewColumnMenu;
                //menu.Items.Clear();
                if (menu.Column != null)
                    menu.Items.Add(CreateItem("Save Layout", menu.Column, null));

                if (menu.Column == col_SalesPersonCode)
                {
                    string columnName = ReflectionExt.GetDisplayName<SettingStore>(x => x.SalesmanContinuity);
                    menu.Items.Add(CreateCheckItem(columnName, menu.Column, null));
                }
            }
        }

        DXMenuCheckItem CreateCheckItem(string caption, GridColumn column, Image image)
        {
            DXMenuCheckItem item = new DXMenuCheckItem(caption, settingStore.SalesmanContinuity, image, new EventHandler(MenuCheckItem_Click));
            item.Tag = new MenuColumnInfo(column);
            return item;
        }

        void MenuCheckItem_Click(object sender, EventArgs e)
        {
            DXMenuCheckItem item = sender as DXMenuCheckItem;
            MenuColumnInfo info = item.Tag as MenuColumnInfo;
            if (info == null) return;

            if (item.Checked)
                settingStore.SalesmanContinuity = true;

            else
                settingStore.SalesmanContinuity = false;

            efMethods.UpdateStoreSettingSalesmanContinuity(settingStore.StoreCode, settingStore.SalesmanContinuity);
        }

        DXMenuItem CreateItem(string caption, GridColumn column, Image image)
        {
            DXMenuItem item = new(caption, new EventHandler(DXMenuItem_Click), image);
            item.Tag = new MenuColumnInfo(column);
            return item;
        }

        void DXMenuItem_Click(object sender, EventArgs e)
        {
            DXMenuItem item = sender as DXMenuItem;
            MenuColumnInfo info = item.Tag as MenuColumnInfo;
            if (info == null) return;

            SaveLayout();
        }

        class MenuColumnInfo
        {
            public MenuColumnInfo(GridColumn column)
            {
                this.Column = column;
            }
            public GridColumn Column;
        }

        private void FormInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void BBI_exportXLSX_ItemClick(object sender, ItemClickEventArgs e)
        {
            CustomExtensions.ExportToExcel(this, dcProcess.ProcessDesc, gC_InvoiceLine);
        }

        private void BBI_ImportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            string captionProductCode = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.ProductCode);
            string captionBarcode = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.Barcode); // <-- property adını sizdəki kimi edin
            string captionQty = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.Qty);
            string captionLineDesc = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.LineDescription);
            string captionPrice = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.Price);
            string captionCurrency = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.CurrencyCode);
            string captionExRate = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.ExchangeRate);
            string captionPosDiscount = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.PosDiscount);
            string captionSerialNumber = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.SerialNumberCode);

            OpenFileDialog dialog = new();
            dialog.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|All files (*.*)|*.*";
            dialog.Title = "Excel faylı seçin.";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);

            ExcelDataSource excelDataSource = new();
            excelDataSource.FileName = dialog.FileName;

            ExcelWorksheetSettings excelWorksheetSettings = new(0);

            ExcelSourceOptions excelOptions = new();
            excelOptions.ImportSettings = excelWorksheetSettings;
            excelOptions.SkipHiddenRows = false;
            excelOptions.SkipHiddenColumns = false;
            excelOptions.UseFirstRowAsHeader = true;
            excelDataSource.SourceOptions = excelOptions;

            excelDataSource.Fill();

            gV_InvoiceLine.GridControl.BeginUpdate();
            gV_InvoiceLine.BeginUpdate();

            DataTable dt = ToDataTableFromExcelDataSource(excelDataSource);

            static string Cell(DataRow r, string colName)
                => (r.Table.Columns.Contains(colName) ? r[colName] : null)?.ToString()?.Trim() ?? "";

            string errorCodes = "";
            double rowCount = 0;

            foreach (DataRow row in dt.Rows)
            {
                int i = Convert.ToInt32(rowCount / dt.Rows.Count * 100);
                SplashScreenManager.Default.SendCommand(WaitForm.WaitFormCommand.SetProgress, i);
                SplashScreenManager.Default.SetWaitFormDescription(i + "%");
                rowCount++;

                string productCode = Cell(row, captionProductCode);
                string barcode = Cell(row, captionBarcode);

                if (string.IsNullOrEmpty(productCode) && string.IsNullOrEmpty(barcode))
                    continue;

                DcProduct product = null;

                if (!string.IsNullOrEmpty(productCode))
                    product = efMethods.SelectProduct(productCode, productTypeArr);

                // ProductCode yoxdursa Barcode ilə axtar
                if (product is null && !string.IsNullOrEmpty(barcode))
                    product = efMethods.SelectProductByBarcode(barcode);

                if (product is null)
                {
                    // Hansı dəyərə görə tapılmadığını yaz
                    if (!string.IsNullOrEmpty(productCode))
                        errorCodes += $"{captionProductCode}: {productCode}\n";
                    else
                        errorCodes += $"{captionBarcode}: {barcode}\n";

                    continue;
                }

                if (gV_InvoiceLine.GetRowCellValue(GridControl.NewItemRowHandle, col_InvoiceHeaderId) is null)
                    gV_InvoiceLine.AddNewRow();

                foreach (DataColumn column in dt.Columns)
                {
                    try
                    {
                        if (column.ColumnName == captionProductCode || column.ColumnName == captionBarcode)
                        {
                            // Hər iki halda məhsul tapılıbsa ProductCode yazırıq
                            gV_InvoiceLine.SetRowCellValue(GridControl.NewItemRowHandle, col_ProductCode, product.ProductCode);

                            // Əgər grid-də ayrıca barcode sütununuz varsa, onu da doldurun:
                            // gV_InvoiceLine.SetRowCellValue(GridControl.NewItemRowHandle, col_Barcode, barcode);
                        }
                        else if (column.ColumnName == captionQty)
                        {
                            gV_InvoiceLine.SetFocusedRowCellValue(colQty, Cell(row, captionQty));
                        }
                        else if (column.ColumnName == captionLineDesc)
                            gV_InvoiceLine.SetFocusedRowCellValue(col_LineDesc, Cell(row, captionLineDesc));

                        else if (column.ColumnName == captionSerialNumber)
                            gV_InvoiceLine.SetFocusedRowCellValue(colSerialNumberCode, Cell(row, captionSerialNumber));

                        else if (dcProcess.ProcessCode == "IT")
                            break;

                        else if (column.ColumnName == captionPrice)
                            gV_InvoiceLine.SetFocusedRowCellValue(col_Price, Cell(row, captionPrice));

                        else if (column.ColumnName == captionCurrency)
                        {
                            string curText = Cell(row, captionCurrency);
                            if (string.IsNullOrEmpty(curText))
                                continue;

                            DcCurrency currency = efMethods.SelectEntityById<DcCurrency>(curText)
                                                  ?? efMethods.SelectCurrencyByName(curText);

                            if (currency is not null)
                            {
                                gV_InvoiceLine.SetFocusedRowCellValue(colCurrencyCode, currency.CurrencyCode);
                                gV_InvoiceLine.SetFocusedRowCellValue(colExchangeRate, currency.ExchangeRate);
                            }
                            else
                                errorCodes += $"{captionCurrency}: {curText}\n";
                        }
                        else if (column.ColumnName == captionExRate)
                            gV_InvoiceLine.SetFocusedRowCellValue(colExchangeRate, Cell(row, captionExRate));

                        else if (column.ColumnName == captionPosDiscount)
                            gV_InvoiceLine.SetFocusedRowCellValue(col_PosDiscount, Cell(row, captionPosDiscount));
                    }
                    catch (ArgumentException ae)
                    {
                        MessageBox.Show("Xəta No: 256545 \n" + ae.Message, "Import xetası");
                    }
                }

                gV_InvoiceLine.UpdateCurrentRow();
            }

            gV_InvoiceLine.EndUpdate();
            gV_InvoiceLine.GridControl.EndUpdate();

            SplashScreenManager.CloseForm(false);

            if (!string.IsNullOrEmpty(errorCodes))
                MessageBox.Show("Aşağıdakı kodlar üzrə Dəyər tapılmadı \n" + errorCodes, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void FillRow(int rowHandle, DcProduct product)
        {
            gV_InvoiceLine.SetRowCellValue(rowHandle, colProductCost, product.ProductCost);
            gV_InvoiceLine.SetRowCellValue(rowHandle, colUnitOfMeasureId, product.DefaultUnitOfMeasureId);

            decimal priceProduct = 0;

            priceProduct = Settings.Default.AppSetting.UsePriceList
                ? efMethods.SelectPriceByProcess(dcProcess.ProcessCode, product.ProductCode)
                : dcProcess.ProcessCode switch
                {
                    "RP" or "CI" or "CO" => product.PurchasePrice,
                    "RS" => product.RetailPrice,
                    "WS" => product.WholesalePrice,
                    _ => 0m
                };

            decimal priceInvoice = Convert.ToInt32(gV_InvoiceLine.GetRowCellValue(rowHandle, col_Price));
            if (priceInvoice == 0)
                gV_InvoiceLine.SetRowCellValue(rowHandle, col_Price, priceProduct);

            if (new string[] { "EX", "EI" }.Contains(dcProcess.ProcessCode))
                gV_InvoiceLine.SetRowCellValue(rowHandle, colQtyIn, 1);
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

        private void lUE_StoreCode_EditValueChanged(object sender, EventArgs e)
        {
            string storeCode = lUE_StoreCode.EditValue.ToString();
            List<DcWarehouse> dcWarehouses = efMethods.SelectWarehousesByStoreIncludeDisabled(storeCode);
            lUE_WarehouseCode.Properties.DataSource = dcWarehouses;

            if (dcWarehouses is not null && trInvoiceHeader is not null)
            {
                DcWarehouse dcWarehouse = dcWarehouses.Where(x => x.IsDefault == true).FirstOrDefault();

                if (dcWarehouse is not null && !dcWarehouses.Any(x => x.WarehouseCode == trInvoiceHeader.WarehouseCode))
                {
                    lUE_WarehouseCode.EditValue = dcWarehouse.WarehouseCode;
                    //trInvoiceHeader.WarehouseCode = dcWarehouse.WarehouseCode;
                }
            }
        }

        private void lUE_WarehouseCode_EditValueChanged(object sender, EventArgs e)
        {
            trInvoiceHeader.WarehouseCode = lUE_WarehouseCode.EditValue?.ToString();
        }

        private void lUE_ToWarehouseCode_EditValueChanged(object sender, EventArgs e)
        {
            trInvoiceHeader.ToWarehouseCode = lUE_ToWarehouseCode.EditValue?.ToString();
        }

        private async void BBI_ReportPrintFast_ItemClick(object sender, ItemClickEventArgs e)
        {
            await PrintFast(settingStore.PrinterName);
        }

        private async Task PrintFast(string printerName)
        {
            alertControl1.Show(this, "Print Göndərilir...", "Printer: " + printerName, "", (Image)null, null);

            if (trInvoiceHeader is not null)
                await Task.Run(() => GetPrint(trInvoiceHeader.InvoiceHeaderId, printerName));
            else MessageBox.Show("Çap olunmaq üçün qaimə yoxdur");

            Task task = Task.Run((Action)ShowPrintCount);

            alertControl1.Show(this, "Print Göndərildi.", "Printer: " + printerName, "", (Image)null, null);
        }

        private void GetPrint(Guid invoiceHeaderId, string printerName)
        {
            XtraReport report = GetInvoiceReport(reportFileNameInvoiceWare);
            report.PrinterName = printerName;

            if (report is not null)
            {
                ReportPrintTool printTool = new(report);
                printTool.Print();
                efMethods.UpdateInvoicePrintCount(invoiceHeaderId);
            }
            report.Dispose();
        }

        private XtraReport GetInvoiceReport(string fileName)
        {
            DsMethods dsMethods = new();
            SqlQuery sqlQuerySale = dsMethods.SelectInvoice(trInvoiceHeader.InvoiceHeaderId);
            return reportClass.GetReport("Main", fileName, new SqlQuery[] { sqlQuerySale });
        }

        private void repoCBE_PrinterName_EditValueChanged(object sender, EventArgs e)
        {
            ComboBoxEdit comboBox = (ComboBoxEdit)sender;
            settingStore.PrinterName = comboBox.EditValue.ToString();
        }

        private void BBI_PrintSettingSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            efMethods.UpdateStoreSettingPrinterName(BEI_PrinterName.EditValue.ToString());
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void gV_InvoiceLine_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;

            if (e.RowHandle >= 0)
            {
                object benefit = view.GetRowCellValue(e.RowHandle, view.Columns["Benefit"]);

                if (benefit is not null)
                {
                    decimal value = (decimal)benefit;

                    if (value <= 0 && new string[] { "RS", "WS", "IS" }.Contains(dcProcess.ProcessCode) && trInvoiceHeader.IsReturn == false)
                        e.Appearance.ForeColor = Color.Red;
                }
            }
        }

        private void Btn_info_ItemClick(object sender, ItemClickEventArgs e)
        {
            DcCurrAcc createdCurrAcc = efMethods.SelectCurrAcc(trInvoiceHeader.CreatedUserName);
            DcCurrAcc updatedCurrAcc = efMethods.SelectCurrAcc(efMethods.SelectInvoiceLastUpdatedUserName(trInvoiceHeader.InvoiceHeaderId));
            DateTime lastUpdatedDate = efMethods.SelectInvoiceLastModifiedDate();

            string createdUserName = ReflectionExt.GetDisplayName<TrInvoiceHeader>(x => x.CreatedUserName) + ": " + createdCurrAcc.CurrAccDesc + " " + createdCurrAcc.FirstName;
            string createdDate = ReflectionExt.GetDisplayName<TrInvoiceHeader>(x => x.CreatedDate) + ": " + trInvoiceHeader.CreatedDate.ToString();
            string updatedUserName = ReflectionExt.GetDisplayName<TrInvoiceHeader>(x => x.LastUpdatedUserName) + ": " + updatedCurrAcc?.CurrAccDesc + " " + updatedCurrAcc?.FirstName;
            string updatedDate = ReflectionExt.GetDisplayName<TrInvoiceHeader>(x => x.LastUpdatedDate) + ": " + lastUpdatedDate.ToString();

            XtraMessageBox.Show(createdUserName + "\n\n" + createdDate + "\n\n" + updatedUserName + "\n\n" + updatedDate, "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BBI_picture_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "ExpenseOfInvoice");
            if (!currAccHasClaims)
            {
                MessageBox.Show("Yetkiniz yoxdur! ");
                return;
            }

            FormImage formPictures = new(btnEdit_DocNum.EditValue?.ToString());
            formPictures.ShowDialog();
        }

        private async void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            MemoryStream memoryStream = GetInvoiceReportImg();
            Clipboard.SetImage(Image.FromStream(memoryStream));
            string phoneNum = efMethods.SelectCurrAcc(trInvoiceHeader.CurrAccCode).PhoneNum;

            //SendWhatsApp(phoneNum, "");

            var TOKEN = "EAAWMnYx6BxYBPvCUQYulGoALBtuiLPjpaZBfEEdKRnnDelxUTrjLDLa3SoESY6IREkTwkK3SZBZA5weFRUyZCOgZBD6oKo2nyOx5jAi7JPWPeCxrBN1uSfdbwALmljhdfEVdlL0OrNjqY2LCNAtHiCdMgaGfi0J1YzvpG9AGGLbTK0eEGB5hHkEMPBPKCKeW6pgZDZD";
            var PHONEID = "767335943132720";

            using var wa = new WhatsAppClient(TOKEN, PHONEID);

            var messageId = await wa.UploadAndSendImageAsync(phoneNum, memoryStream, caption: "From MemoryStream", fileName: "pic.jpg", contentType: "image/jpeg");
            Console.WriteLine($"Sent: {messageId}");
        }

        private void gV_InvoiceLine_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (!e.IsGetData)
                return;

            int rowInd = gV_InvoiceLine.GetRowHandle(e.ListSourceRowIndex);
            object productCode = gV_InvoiceLine.GetRowCellValue(rowInd, col_ProductCode);

            if (string.IsNullOrEmpty(productCode?.ToString()))
                return;

            DcProduct dcProduct = subContext.DcProducts // more fast query
                        .AsNoTracking()
                        .Include(x => x.DcHierarchy)
                        .Include(x => x.TrProductFeatures)
                        .FirstOrDefault(x => x.ProductCode == productCode);

            if (dcProduct is null)
                return;

            if (e.Column == col_ProductDesc)
            {
                e.Value = GetProductDescWide(dcProduct);
            }
            else if (e.Column == colBalance)
            {
                dcProduct.Balance = subContext.TrInvoiceLines.AsNoTracking()
                                                             .Include(x => x.TrInvoiceHeader)
                                                             .Where(x => new string[] { "RP", "WP", "RS", "WS", "IS", "CI", "CO", "IT" }.Contains(x.TrInvoiceHeader.ProcessCode))
                                                             .Where(x => x.ProductCode == productCode)
                                                             .Sum(x => x.QtyIn - x.QtyOut);
                e.Value = dcProduct.Balance;
            }
        }

        private static string GetProductDescWide(DcProduct product)
        {
            int[] featureTypeIds = new[] { 4, 5 };
            string arr = "";
            foreach (var item in product?.TrProductFeatures.Where(f => featureTypeIds.Contains(f.FeatureTypeId)))
                arr += " " + item.FeatureCode;
            string productDescWide = product.HierarchyCode + " " + product.ProductDesc + arr;
            return productDescWide;
        }

        private void BBI_InvoiceExpenses_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormInvoice formInvoice = new("EI", null, new byte[] { 2, 3 }, trInvoiceHeader.InvoiceHeaderId);
            formInvoice.WindowState = FormWindowState.Normal;
            formInvoice.ShowDialog();
        }

        private void BCI_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            BBI_picture.Visibility = BCI_ShowPicture.Checked ? BarItemVisibility.Always : BarItemVisibility.Never;
            BBI_ReportPrintFast.Visibility = BCI_ShowPrint.Checked ? BarItemVisibility.Always : BarItemVisibility.Never;
            bBI_CopyInvoice.Visibility = BCI_ShowCopy.Checked ? BarItemVisibility.Always : BarItemVisibility.Never;
        }

        private void lUE_StoreCode_PopupFilter(object sender, PopupFilterEventArgs e)
        {
            lUE_StoreCode.Properties.DataSource = efMethods.SelectStores();
        }

        private void lUE_WarehouseCode_PopupFilter(object sender, PopupFilterEventArgs e)
        {
            string storeCode = lUE_StoreCode.EditValue?.ToString();
            lUE_WarehouseCode.Properties.DataSource = efMethods.SelectWarehousesByStore(storeCode);
        }

        private void lUE_ToWarehouseCode_PopupFilter(object sender, PopupFilterEventArgs e)
        {
            string storeCode = btnEdit_CurrAccCode.EditValue?.ToString();
            lUE_ToWarehouseCode.Properties.DataSource = efMethods.SelectWarehousesByStore(storeCode);
        }

        private void lUE_WarehouseCode_Validating(object sender, CancelEventArgs e)
        {
            LookUpEdit warehouse = sender as LookUpEdit;

            for (int i = 0; i < gV_InvoiceLine.RowCount; i++)
            {
                var trInvoiceLine = gV_InvoiceLine.GetRow(i) as TrInvoiceLine;
                if (trInvoiceLine != null)
                {
                    decimal productBalance = CalcProductBalance(trInvoiceLine, trInvoiceLine.ProductCode, warehouse.EditValue?.ToString(), trInvoiceLine.Qty);

                    if (productBalance < trInvoiceLine.Qty)
                    {
                        //e.Cancel = true;
                        //lookUpEdit.ErrorText = "Please select a valid value.";
                    }
                }
            }
        }

        private void lUE_WarehouseCode_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            //e.ExceptionMode = ExceptionMode.DisplayError;
            //e.ErrorText = "Qaimədə məhsulların bəzisi anbarda yoxdu";
        }

        private void popupMenuPrinters_BeforePopup(object sender, CancelEventArgs e)
        {
            PopupMenu menu = (sender as PopupMenu);
            menu.ItemLinks.Clear();

            try
            {
                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
                    BarButtonItem BBI = new();
                    BBI.Caption = printer;
                    BBI.Name = printer;
                    BBI.ImageOptions.SvgImage = svgImageCollection1["print"];
                    BBI.ItemClick += async (sender, e) =>
                    {
                        await PrintFast(printer);
                    };

                    menu.AddItem(BBI);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(Resources.Form_Invoice_PrinterError_1256795721, ex.Message));
            }

            e.Cancel = false;
        }

        private void dataLayoutControl1_Changed(object sender, EventArgs e)
        {
            //MessageBox.Show("Changed");
        }

        private void repoBtnEdit_UnitOfMeasure_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            FormCommonList<DcUnitOfMeasure> formCommon = new("", nameof(DcUnitOfMeasure.UnitOfMeasureId));
            formCommon.ShowDialog();
        }

        private void repoLUE_UnitOfMeasure_PopupFilter(object sender, PopupFilterEventArgs e)
        {
            var lookupEdit = sender as LookUpEdit;
            if (lookupEdit != null)
            {
                string productCode = gV_InvoiceLine.GetFocusedRowCellValue(col_ProductCode)?.ToString();

                DcProduct product = efMethods.SelectProduct(productCode, productTypeArr);
                if (product is not null)
                {
                    List<DcUnitOfMeasure> unitOfMeasure = efMethods.SelectUnitOfMeasuresAllRelated(product.DefaultUnitOfMeasureId);
                    lookupEdit.Properties.DataSource = unitOfMeasure;
                }
            }
        }

        private void gV_InvoiceLine_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (new GridColumn[] { colQty, colBalance }.Contains(e.Column) && e.Value is decimal decimalValue)
            {
                //e.DisplayText = decimalValue.ToString("0.##");// Display without ".00" if there are no decimals

                //if (e.DisplayText.EndsWith("."))
                //{
                //    e.DisplayText = e.DisplayText.Replace(".", "");
                //}
            }
        }

        private void gV_InvoiceLine_ShowingEditor(object sender, CancelEventArgs e)
        {
        }

        private void gV_InvoiceLine_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
        }

        private void repoBtnEdit_InstallmentGarantorDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (gV_InstallmentGarantor.FocusedRowHandle >= 0)
            {
                DialogResult result = XtraMessageBox.Show(
                    Resources.Form_Invoice_DeleteGuarantorQuestion,
                    Resources.Common_Attention,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                    trInstallmentGuarantorsBindingSource.RemoveCurrent();

                if (dbContext != null && dataLayoutControl1.IsValid(out _))
                    if (Settings.Default.AppSetting.AutoSave)
                        if (gV_InvoiceLine.DataRowCount > 0)
                            SaveInvoice();
            }
        }

        private void BBI_InstallmentGuarantorAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormCurrAccList form = new(new byte[] { 1, 2, 3 }, false);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var newGuarantor = new TrInstallmentGuarantor
                {
                    CurrAccCode = form.dcCurrAcc.CurrAccCode,
                    DcCurrAcc = form.dcCurrAcc,
                    InstallmentId = trInvoiceHeader.TrInstallment.InstallmentId
                };

                var existingEntity = dbContext2.ChangeTracker.Entries<DcCurrAcc>()
                    .FirstOrDefault(en => en.Entity.CurrAccCode == form.dcCurrAcc.CurrAccCode);

                if (existingEntity != null)
                {
                    XtraMessageBox.Show(
                        Resources.Form_Invoice_GuarantorAlreadyAdded,
                        Resources.Common_Attention,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                dbContext2.Attach(form.dcCurrAcc);

                trInstallmentGuarantorsBindingSource.Add(newGuarantor);

                if (dbContext != null && dataLayoutControl1.IsValid(out _))
                    if (Settings.Default.AppSetting.AutoSave)
                        if (gV_InvoiceLine.DataRowCount > 0)
                            SaveInvoice();
            }
        }

        private void LoadInstallmentGarantors()
        {
            dbContext2 = new subContext();

            int installmentId = trInvoiceHeader.TrInstallment?.InstallmentId ?? 0;

            dbContext2.TrInstallmentGuarantors.Include(x => x.DcCurrAcc)
                                              .Where(x => x.InstallmentId == installmentId)
                                              .Load();

            trInstallmentGuarantorsBindingSource.DataSource = dbContext2.TrInstallmentGuarantors.Local.ToBindingList();

            gV_InstallmentGarantor.BestFitColumns();
        }

        private void gV_InstallmentGarantor_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == nameof(DcCurrAcc.CurrAccDesc) && e.IsGetData)
            {
                BindingList<TrInstallmentGuarantor> trInstallmentGuarantors = trInstallmentGuarantorsBindingSource.DataSource as BindingList<TrInstallmentGuarantor>;
                TrInstallmentGuarantor row = (TrInstallmentGuarantor)e.Row;
                e.Value = trInstallmentGuarantors?.FirstOrDefault(x => x.CurrAccCode == row.CurrAccCode)?.DcCurrAcc?.CurrAccDesc;
            }
        }

        private void LUE_InstallmentPlan_EditValueChanged(object sender, EventArgs e)
        {
            if (trInvoiceHeader is null) return;
            if (trInvoiceHeader.ProcessCode == "IS" && trInvoiceHeader?.TrInstallment is not null)
                if (LUE_InstallmentPlan.GetColumnValue(nameof(DcInstallmentPlan.InterestRate)) is float interestRate)
                    trInvoiceHeader.TrInstallment.InterestRate = interestRate;
        }

        private void BBI_InvoiceDiscount_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, nameof(TrInvoiceLine.PosDiscount));
            if (!currAccHasClaims)
            {
                XtraMessageBox.Show(
                    Resources.Common_NoPermission,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (gV_InvoiceLine.DataRowCount > 0)
            {
                decimal amountSummary = CalcAmountSummmaryValue();
                using (FormPosDiscount formPosDiscount = new(0, amountSummary))
                {
                    if (formPosDiscount.ShowDialog(this) == DialogResult.OK)
                    {
                        for (int i = 0; i < gV_InvoiceLine.DataRowCount; i++)
                            gV_InvoiceLine.SetRowCellValue(i, col_PosDiscount, formPosDiscount.DiscountPercent);
                        gV_InvoiceLine.RefreshData();//update footer summary
                    }
                }
            }
            else
            {
                XtraMessageBox.Show(
                    Resources.Form_Invoice_NoLines,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }


        private void BBI_Salesman_ItemClick(object sender, ItemClickEventArgs e)
        {
            using FormCurrAccList form = new(new byte[] { 3 }, false, new byte[] { 1 });


            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (form.dcCurrAcc?.CurrAccCode is not null)
                {
                    for (int i = 0; i < gV_InvoiceLine.DataRowCount; i++)
                        gV_InvoiceLine.SetRowCellValue(i, col_SalesPersonCode, form.dcCurrAcc.CurrAccCode);
                }
            }
        }

        private void BBI_SumSameProducts_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Əvvəlcə formdakı dəyişiklikləri bağlayaq
            this.Validate();
            trInvoiceLinesBindingSource.EndEdit();

            // Yalnız bu fakturaya aid sətrləri götürək (əgər header filterin budursa)
            var lines = dbContext.TrInvoiceLines.Local
                .Where(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId)
                .ToList();

            // Burada "eyni" sayılan sahələri yazırsan (Qty/Quantity-dən başqa hamısı)
            var groups = lines.GroupBy(x => new
            {
                x.ProductCode,
                x.Price,
                x.SerialNumberCode,
                x.PosDiscount,
                x.DiscountCampaign,
                x.VatRate,
                x.CurrencyCode,
                x.ExchangeRate,
                x.SalesPersonCode,
                x.UnitOfMeasureId
            });

            foreach (var group in groups)
            {
                var list = group.ToList();
                if (list.Count <= 1)
                    continue; // tək sətirdirsə, birləşməyə ehtiyac yoxdur

                // Saxlayacağımız əsas sətir
                var first = list[0];

                // Qty / Quantity property adı nədirsə onu istifadə et
                first.Qty = list.Sum(l => l.Qty);

                // Qalan sətrləri dbContext-dən silirik
                foreach (TrInvoiceLine extra in list.Skip(1))
                {
                    dbContext.TrInvoiceLines.Remove(extra);
                }
            }

            // Dəyişiklikləri DB-yə yaz (əgər dərhal saxlamaq istəyirsənsə)
            dbContext.SaveChanges();

            // BindingSource-u yenilə ki, grid yenilənsin
            trInvoiceLinesBindingSource.ResetBindings(false);
        }

        private void BBI_CountingStock_ItemClick(object sender, ItemClickEventArgs e)
        {
            var bindingList = trInvoiceLinesBindingSource.DataSource as BindingList<TrInvoiceLine>;
            List<TrInvoiceLine> invoiceLines = bindingList?.ToList();

            FormCounting wizardForm1 = new(invoiceLines, trInvoiceHeader.InvoiceHeaderId);
            wizardForm1.ShowDialog();
        }

        private void Btn_CashRegCode_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            string storeCode = lUE_StoreCode.EditValue?.ToString();

            using (FormCashRegisterList form = new(editor.EditValue?.ToString(), storeCode))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    editor.EditValue = form.dcCurrAcc.CurrAccCode;
                }
            }
        }

        private void Btn_CashRegCode_EditValueChanged(object sender, EventArgs e)
        {
            DcCurrAcc curr = efMethods.SelectCashRegById(btn_CashRegCode.EditValue?.ToString());
            if (trInvoiceHeader is null || curr is null)
                return;

            if (dbContext != null && dataLayoutControl1.IsValid(out _))
                if (gV_InvoiceLine.DataRowCount > 0)
                    SavePayment();
        }

        private void Btn_CashRegCode_Validating(object sender, CancelEventArgs e)
        {
            if (sender is not ButtonEdit editor)
                return;

            dxErrorProvider1.SetError(editor, string.Empty);

            string value = editor.Text?.Trim();

            if (string.IsNullOrEmpty(value))
                return;

            DcCurrAcc curr = efMethods.SelectCashRegById(value);

            if (curr is null)
            {
                SetValidationError(editor, e, Resources.Form_Invoice_NoCashReg);
                return;
            }

            dxErrorProvider1.SetError(editor, string.Empty);
        }

        private void Btn_CashRegCode_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
        }
    }
}