
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
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Tokens;
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
using System.Windows.Forms;
using System.Xml;
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
        CustomMethods cM = new();

        string reportFileNameInvoiceWare = @"InvoiceRS_A4_depo.repx";

        readonly SettingStore settingStore;
        private TrInvoiceHeader trInvoiceHeader;
        private bool isReturn;
        Guid invoiceHeaderId;
        Guid? relatedInvoiceId;
        public DcProcess dcProcess;
        private byte[] productTypeArr;
        private decimal CurrAccBalanceBefore;
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

            this.Text = dcProcess.ProcessDesc;
            BEI_PrinterName.EditValue = settingStore.PrinterName;
            lUE_StoreCode.Properties.DataSource = efMethods.SelectStoresIncludeDisabled();
            LUE_InstallmentPlan.Properties.DataSource = efMethods.SelectEntities<DcInstallmentPlan>();

            string activeFilterStr = "[StoreCode] = \'" + Authorization.StoreCode + "\'";

            cM.AddReports(BSI_Reports, "Invoice", nameof(TrInvoiceLine.InvoiceHeaderId), gV_InvoiceLine, activeFilterStr);
            cM.AddReports(BSI_Reports, "Products", nameof(DcProduct.ProductCode), gV_InvoiceLine, activeFilterStr);

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

            // ikinci dereceli entitylerde (TrInstallment.PaymentPlanCode) CurrentItemChanged islemir.
            LUE_InstallmentPlan.EditValueChanged += trInvoiceHeadersBindingSource_CurrentItemChanged;
            txtEdit_Installment_Commission.Leave += trInvoiceHeadersBindingSource_CurrentItemChanged;

            //foreach (BaseLayoutItem item in dataLayoutControl1.Items)
            //{
            //    if (item is LayoutControlItem)
            //    {
            //        LayoutControlItem controlItem = item as LayoutControlItem;
            //        if (controlItem != null)
            //        {
            //            if (controlItem.Control is LookUpEdit lookUpEdit)
            //            {
            //                lookUpEdit.EditValueChanged += LookUpEdit_EditValueChanged;
            //            }
            //            else if (controlItem.Control is BaseEdit baseEdit)
            //            {
            //                baseEdit.Leave += Control_Leave;
            //            }
            //        }
            //    }
            //}
            // This line of code is generated by Data Source Configuration Wizard
            // Instantiate a new DBContext
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

        private void LookUpEdit_EditValueChanged(object? sender, EventArgs e)
        {
            //if (sender is LookUpEdit lookUpEdit)
            //{
            //    trInvoiceHeader = trInvoiceHeadersBindingSource.Current as TrInvoiceHeader;

            //    if (trInvoiceHeader is not null)
            //    {
            //        if (lookUpEdit == lUE_StoreCode)
            //            trInvoiceHeader.StoreCode = lookUpEdit.EditValue?.ToString();
            //        if (lookUpEdit == lUE_ToWarehouseCode)
            //            trInvoiceHeader.ToWarehouseCode = lookUpEdit.EditValue?.ToString();

            //        if (dbContext != null
            //            && dataLayoutControl1.IsValid(out _)
            //            && Settings.Default.AppSetting.AutoSave
            //            && gV_InvoiceLine.DataRowCount > 0)
            //            SaveInvoice();
            //    }
            //}
        }

        private void Control_Leave(object sender, EventArgs e)
        {
            //trInvoiceHeader = trInvoiceHeadersBindingSource.Current as TrInvoiceHeader;

            //if (trInvoiceHeader != null && dbContext != null && dataLayoutControl1.IsValid(out _))
            //    if (Settings.Default.AppSetting.AutoSave)
            //        if (gV_InvoiceLine.DataRowCount > 0)
            //            SaveInvoice();
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
            colProductCost.Caption = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.ProductCost);
            colBalance.Caption = ReflectionExt.GetDisplayName<DcProduct>(x => x.Balance);
            col_ProductDesc.Caption = ReflectionExt.GetDisplayName<DcProduct>(x => x.ProductDesc);
            checkEdit_IsSent.Properties.Caption = ReflectionExt.GetDisplayName<TrInvoiceHeader>(x => x.IsSent);
            checkEdit_IsReturn.Properties.Caption = ReflectionExt.GetDisplayName<TrInvoiceHeader>(x => x.IsReturn);
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

            trInvoiceHeader = trInvoiceHeadersBindingSource.AddNew() as TrInvoiceHeader;

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
            string NewDocNum = efMethods.GetNextDocNum(true, dcProcess.ProcessCode, "DocumentNumber", "TrInvoiceHeaders", 6);
            invoiceHeader.DocumentNumber = NewDocNum;
            invoiceHeader.DocumentDate = DateTime.Now;
            invoiceHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            invoiceHeader.ProcessCode = dcProcess.ProcessCode;
            invoiceHeader.OfficeCode = Authorization.OfficeCode;
            invoiceHeader.StoreCode = Authorization.StoreCode;
            invoiceHeader.CreatedUserName = Authorization.CurrAccCode;
            invoiceHeader.IsMainTF = true;
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
                    InstallmentPlanCode = "I00"
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

            if (dbContext != null && dataLayoutControl1.IsValid(out _))
                if (Settings.Default.AppSetting.AutoSave)
                    if (gV_InvoiceLine.DataRowCount > 0)
                        SaveInvoice();

            gV_InvoiceLine.Focus();
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

        private void CalcInstallmentAmount()
        {
            //decimal installmentSum = efMethods.SelectInstallmentsSumByInvoice(trInvoiceHeader.InvoiceHeaderId);
            //lbl_InstallmentSum.Text = Math.Round(installmentSum, 2).ToString() + " " + Settings.Default.AppSetting.LocalCurrencyCode;

            //decimal InstallmentCommissionsSum = efMethods.SelectInstallmentCommissionsSumByInvoice(trInvoiceHeader.InvoiceHeaderId);
            //lbl_InstallmentCommissionSum.Text = Math.Round(InstallmentCommissionsSum, 2).ToString() + " " + Settings.Default.AppSetting.LocalCurrencyCode;

            //decimal InstallmentsTotalSum = efMethods.SelectInstallmentsTotalSumByInvoice(trInvoiceHeader.InvoiceHeaderId);
            //lbl_InstallmentTotalSum.Text = Math.Round(InstallmentsTotalSum, 2).ToString() + " " + Settings.Default.AppSetting.LocalCurrencyCode;
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
                FormCurrAccList form = new(new byte[] { 1, 2, 3 }, trInvoiceHeader.CurrAccCode);

                if (trInvoiceHeader.ProcessCode == "IT")
                    form = new FormCurrAccList(new byte[] { 4 }, trInvoiceHeader.CurrAccCode);

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (form.dcCurrAcc.CreditLimit > Math.Abs(form.dcCurrAcc.Balance) || form.dcCurrAcc.CreditLimit == 0)
                        btnEdit_CurrAccCode.EditValue = form.dcCurrAcc.CurrAccCode;
                    else
                        XtraMessageBox.Show("Müştəri Kredit Limitin Aşır", "Diqqət");
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

            if (btnEdit_SalesPerson.EditValue != null)
                gv.SetRowCellValue(e.RowHandle, col_SalesPersonCode, btnEdit_SalesPerson.EditValue);
            else if (settingStore.SalesmanContinuity)
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
                    if (MessageBox.Show("Sətir Silinsin?", "Təsdiqlə", MessageBoxButtons.YesNo) != DialogResult.Yes)
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
            //if (e.Column == col_ProductCode)
            //{
            //    var row = gV_InvoiceLine.GetRow(e.RowHandle) as TrInvoiceLine;

            //    if (row != null)
            //    {
            //        row.DcProduct = efMethods.SelectEntityById<DcProduct>(row.ProductCode);
            //        gV_InvoiceLine.RefreshRow(e.RowHandle); // Refresh to show ProductDesc
            //    }
            //}
        }

        private void gV_InvoiceLine_ValidateRow(object sender, ValidateRowEventArgs e)
        {
        }

        private void gV_InvoiceLine_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
        }

        private void gV_InvoiceLine_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            GridColumn column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;

            if (column == colQty)
            {
                if (new string[] { "RP", "WP", "RS", "WS", "IS", "IT" }.Contains(trInvoiceHeader.ProcessCode)
                    && (!trInvoiceHeader.IsReturn && !(bool)CustomExtensions.DirectionIsIn(trInvoiceHeader.ProcessCode)
                    || trInvoiceHeader.IsReturn && !(bool)CustomExtensions.DirectionIsIn(trInvoiceHeader.ProcessCode)))
                {
                    TrInvoiceLine trInvoiceLine = view.GetFocusedRow() as TrInvoiceLine;

                    if (efMethods.SelectEntityById<DcProduct>(trInvoiceLine?.ProductCode)?.ProductTypeCode != 3) // product is not service product
                    {
                        string wareHouse = lUE_WarehouseCode.EditValue.ToString();
                        if (trInvoiceHeader.IsReturn && trInvoiceHeader.ProcessCode == "IT")
                            wareHouse = lUE_ToWarehouseCode.EditValue.ToString();

                        bool permitNegativeStock = (bool)lUE_WarehouseCode.GetColumnValue("PermitNegativeStock");

                        decimal balance = CalcProductBalance(trInvoiceLine, wareHouse);

                        if (permitNegativeStock)
                            if (Convert.ToDecimal(e.Value) > balance)
                            {
                                e.ErrorText = "Stokda miqdar yoxdur";
                                e.Valid = false;
                            }
                    }
                }

                if (!String.IsNullOrEmpty(trInvoiceHeader.CurrAccCode)
                    && new string[] { "RP", "WP", "RS", "WS", "IS" }.Contains(trInvoiceHeader.ProcessCode)
                    && (!trInvoiceHeader.IsReturn && !(bool)CustomExtensions.DirectionIsIn(trInvoiceHeader.ProcessCode)
                    || trInvoiceHeader.IsReturn && (bool)CustomExtensions.DirectionIsIn(trInvoiceHeader.ProcessCode)))
                {
                    DcCurrAcc dcCurrAcc = efMethods.SelectCurrAcc(trInvoiceHeader.CurrAccCode);
                    decimal currAccBalance = CalcCurrAccCreditBalance(Convert.ToInt32(e.Value), view, trInvoiceHeader.CurrAccCode);

                    if (Math.Abs(currAccBalance) > dcCurrAcc.CreditLimit && dcCurrAcc.CreditLimit != 0 && Convert.ToInt32(e.Value) != 0)
                    {
                        e.ErrorText = "Müştəri Kredit Limitini Aşır!";
                        e.Valid = false;
                    }
                }
            }

            if (column == colBarcode || column == col_ProductCode || column == colSerialNumberCode)
            {
                string eValue = (e.Value ??= String.Empty).ToString();

                if (!string.IsNullOrEmpty(eValue))
                {
                    DcProduct product = null;

                    if (column == colBarcode)
                        product = efMethods.SelectProductByBarcode(eValue);
                    if (column == colSerialNumberCode)
                    {
                        gV_InvoiceLine.SetFocusedRowCellValue(colSerialNumberCode, eValue);
                        product = efMethods.SelectProductBySerialNumber(eValue);
                    }
                    if (column == col_ProductCode)
                    {
                        product = efMethods.SelectProduct(eValue);
                        view.SetFocusedRowCellValue(colSerialNumberCode, null);
                    }

                    if (product is not null)
                    {
                        FillRow(view.FocusedRowHandle, product);
                        view.UpdateCurrentRow(); // For Model/Entity/trInvoiceLine Included TrInvoiceHeader
                        if (new string[] { "EX", "EI" }.Contains(dcProcess.ProcessCode))
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

            if (column == col_SalesPersonCode)
            {
                string eValue = (e.Value ??= String.Empty).ToString();

                if (!String.IsNullOrEmpty(eValue))
                {
                    DcCurrAcc dcCurrAcc = efMethods.SelectSalesPerson(eValue);
                    if (dcCurrAcc is null || dcCurrAcc?.CurrAccTypeCode != 3)
                    {
                        e.ErrorText = "Belə bir satıcı yoxdur";
                        e.Valid = false;
                    }
                }
                else
                {
                    e.Value = null;
                }
            }

            if (column == colWorkerCode)
            {
                string eValue = (e.Value ??= String.Empty).ToString();

                if (!String.IsNullOrEmpty(eValue))
                {
                    DcCurrAcc dcCurrAcc = efMethods.SelectWorker(eValue);
                    if (dcCurrAcc is null || dcCurrAcc?.CurrAccTypeCode != 3)
                    {
                        e.ErrorText = "Belə bir usta yoxdur";
                        e.Valid = false;
                    }
                }
                else
                {
                    e.Value = null;
                }
            }
        }

        private decimal CalcCurrAccCreditBalance(int eValue, GridView view, string currAccCode)
        {
            object objPriceLoc = view.GetFocusedRowCellValue(colPriceLoc);
            decimal newValue = eValue * Convert.ToDecimal(objPriceLoc ??= 0);
            decimal oldValue = Convert.ToDecimal(gV_InvoiceLine.GetFocusedRowCellValue(colNetAmountLoc));

            decimal oldSummaryValue = CalcSummmaryValue();
            decimal newSummaryValue = oldSummaryValue - oldValue + newValue;

            decimal balanceAfter = CurrAccBalanceBefore - newSummaryValue;

            return balanceAfter;
        }

        private decimal CalcSummmaryValue()
        {
            decimal sum = 0;

            for (int i = 0; i < gV_InvoiceLine.DataRowCount; i++)
            {
                object value = gV_InvoiceLine.GetRowCellValue(i, colNetAmountLoc);

                if (value != null && value != DBNull.Value)
                    sum += Convert.ToDecimal(value);
            }

            return sum;
        }

        private decimal CalcProductBalance(TrInvoiceLine trInvoiceLine, string wareHouse)
        {
            if (trInvoiceLine is not null && !String.IsNullOrEmpty(trInvoiceLine.ProductCode))
            {
                if (!String.IsNullOrEmpty(trInvoiceLine.SerialNumberCode))
                    return efMethods.SelectProductBalanceSerialNumber(trInvoiceLine.ProductCode, wareHouse, trInvoiceLine.SerialNumberCode) + trInvoiceLine.Qty;
                else
                    return efMethods.SelectProductBalance(trInvoiceLine.ProductCode, wareHouse) + trInvoiceLine.Qty;
            }
            else return 0;
        }

        private void gV_InvoiceLine_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "Diqqət";
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

            using FormCommonList<DcSerialNumber> form = new("SN", "SerialNumberCode", editor.EditValue?.ToString(), "ProductCode", productCode);

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
            #region DXMouseEventArgs ea
            //DXMouseEventArgs ea = e as DXMouseEventArgs;
            //GridView view = sender as GridView;
            //GridHitInfo info = view.CalcHitInfo(ea.Location);
            //info.Column
            //if (info.InRow || info.InRowCell)
            //{
            //    string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
            //    MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));
            //} 
            #endregion
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

            using FormCurrAccList form = new(new byte[] { 3 }, value, new byte[] { 1 });

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                editor.EditValue = form.dcCurrAcc.CurrAccCode;
            }
        }

        private void SelectWorker(object sender)
        {
            ButtonEdit editor = (ButtonEdit)sender;

            string value = editor.EditValue?.ToString();

            using FormCurrAccList form = new(new byte[] { 3 }, value, new byte[] { 3 });

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                editor.EditValue = form.dcCurrAcc.CurrAccCode;
            }
        }

        private void SelectProduct(object sender)
        {
            string productCode = "";
            if (gV_InvoiceLine.GetFocusedRowCellValue("ProductCode") != null)
                productCode = gV_InvoiceLine.GetFocusedRowCellValue("ProductCode").ToString();

            ButtonEdit editor = (ButtonEdit)sender;

            using FormProductList form = new(productTypeArr, false, productCode);

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    editor.EditValue = form.dcProduct.ProductCode;
                    gV_InvoiceLine.SetFocusedRowCellValue(colProductCost, form.dcProduct.ProductCost);
                    gV_InvoiceLine.SetFocusedRowCellValue(colUnitOfMeasureId, form.dcProduct.DefaultUnitOfMeasureId);

                    gV_InvoiceLine.CloseEditor();
                    gV_InvoiceLine.UpdateCurrentRow(); // For Model/Entity/trInvoiceLine Included TrInvoiceHeader

                    gV_InvoiceLine.BestFitColumns();
                    gV_InvoiceLine.FocusedColumn = colQty;
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
                e.Cancel = true; // Cancel the deletion if validation fails
                XtraMessageBox.Show("Bu məhsul üzrə geri qaytarma mövcuddur", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (efMethods.WaybillExistByInvoiceLine(invoiceLineId))
            {
                e.Cancel = true; // Cancel the deletion if validation fails
                XtraMessageBox.Show("Bu məhsul üzrə təhvil mövcuddur", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string NewDocNum = efMethods.GetNextDocNum(true, "PA", "DocumentNumber", "TrPaymentHeaders", 6);
                trPaymentHeader.DocumentNumber = NewDocNum;
                trPaymentHeader.Description = trInvoiceHeader.Description;

                efMethods.InsertEntity<TrPaymentHeader>(trPaymentHeader);
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
                    trPaymentLine.LineDescription = il.LineDescription;
                    trPaymentLine.PaymentLoc = isNegativ ? il.NetAmountLoc * (-1) : il.NetAmountLoc;
                    efMethods.InsertEntity<TrPaymentLine>(trPaymentLine);
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
            trPaymentLine.PaymentTypeCode = 1;
            trPaymentLine.PaymentMethodId = 1;
            trPaymentLine.CurrencyCode = Settings.Default.AppSetting.LocalCurrencyCode;
            trPaymentLine.ExchangeRate = 1f;
            string storeCode = trInvoiceHeader.StoreCode;
            trPaymentLine.CashRegisterCode = efMethods.SelectCashRegByStore(storeCode);
            trPaymentLine.CreatedUserName = Authorization.CurrAccCode;

            return trPaymentLine;
        }

        private void bBI_SaveAndNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                decimal summaryInvoice = (decimal)colNetAmountLoc.SummaryItem.SummaryValue;

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

            byte[] paymentTypes = dcProcess.ProcessCode == "IS" ? new byte[] { 1, 2, 3, 4 } : new byte[] { 1, 2 };
            using FormPayment formPayment = new(1, pay, trInvoiceHeader, paymentTypes);
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
                    //CalcInstallmentAmount();
                    //efMethods.UpdateInvoiceIsCompleted(trInvoiceHeader.InvoiceHeaderId);
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
                decimal summaryInvoice = (decimal)colNetAmountLoc.SummaryItem.SummaryValue;

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
                decimal summaryInvoice = (decimal)colNetAmountLoc.SummaryItem.SummaryValue;

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
                XtraMessageBox.Show("Silinmeli olan faktura yoxdur");
                return;
            }

            string claim = "DeleteInvoice" + dcProcess.ProcessCode;
            bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, claim);
            if (!currAccHasClaims)
            {
                MessageBox.Show("Yetkiniz yoxdur! ");
                return;
            }

            List<TrInvoiceLine> invoicelines = efMethods.SelectInvoiceLines(trInvoiceHeader.InvoiceHeaderId);

            foreach (var invoiceline in invoicelines)
            {
                if (efMethods.ReturnExistByInvoiceLine(invoiceline.InvoiceLineId))
                {
                    XtraMessageBox.Show("Bu məhsul üzrə geri qaytarma mövcuddur", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (efMethods.WaybillExistByInvoiceLine(invoiceline.InvoiceLineId))
                {
                    XtraMessageBox.Show("Bu məhsul üzrə təhvil mövcuddur", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (XtraMessageBox.Show(new XtraMessageBoxArgs { Caption = "Diqqət", Text = "Silmek Isteyirsiz?", Buttons = new[] { DialogResult.OK, DialogResult.Cancel }, ImageOptions = new MessageBoxImageOptions() { SvgImage = svgImageCollection1["DeleteInvoice"] } }) == DialogResult.OK)
            {
                bool currAccHasPayClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "PaymentDetail");
                bool currAccHasExpenceClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "Expense");
                bool currAccHasDeleteEXClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "DeleteInvoiceEX");
                bool currAccHasDeleteISClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "DeleteInvoiceIS");

                if (efMethods.PaymentExistByInvoice(trInvoiceHeader.InvoiceHeaderId))
                    if (new string[] { "EX", "EI" }.Contains(dcProcess.ProcessCode))
                        efMethods.DeletePaymentsByInvoiceId(trInvoiceHeader.InvoiceHeaderId);
                    else if (XtraMessageBox.Show(new XtraMessageBoxArgs { Caption = "Diqqət", Text = "Qaimə üzrə olan ödənişləri də silirsiniz?", Buttons = new[] { DialogResult.OK, DialogResult.Cancel }, ImageOptions = new MessageBoxImageOptions() { SvgImage = svgImageCollection1["DeletePayment"] } }) == DialogResult.OK)
                        if (currAccHasPayClaims)
                            efMethods.DeletePaymentsByInvoiceId(trInvoiceHeader.InvoiceHeaderId);
                        else
                            XtraMessageBox.Show("Ödəniş Yetkiniz yoxdur!");

                if (efMethods.ExpensesExistByInvoiceId(trInvoiceHeader.InvoiceHeaderId))
                    if (XtraMessageBox.Show(new XtraMessageBoxArgs { Caption = "Diqqət", Text = "Qaimə üzrə olan xərcləri də Silirsiniz?", Buttons = new[] { DialogResult.OK, DialogResult.Cancel }, ImageOptions = new MessageBoxImageOptions() { SvgImage = svgImageCollection1["DeleteExpenses"] } }) == DialogResult.OK)
                        if (currAccHasExpenceClaims)
                            if (currAccHasDeleteEXClaims)
                                efMethods.DeleteExpensesByInvoiceId(trInvoiceHeader.InvoiceHeaderId);
                            else XtraMessageBox.Show("Xərci Silmə Yetkiniz yoxdur!");
                        else
                            XtraMessageBox.Show("Xərc Yetkiniz yoxdur!");

                //if (efMethods.InstallmentsExistByInvoiceId(trInvoiceHeader.InvoiceHeaderId))
                //    if (XtraMessageBox.Show(new XtraMessageBoxArgs { Caption = "Diqqət", Text = "Qaimə üzrə olan kreditləri də Silirsiniz?", Buttons = new[] { DialogResult.OK, DialogResult.Cancel }, ImageOptions = new MessageBoxImageOptions() { SvgImage = svgImageCollection1["DeleteInvoiceIS"] } }) == DialogResult.OK)
                //        if (currAccHasDeleteISClaims)
                //            efMethods.DeleteInstallmentsByInvoiceId(trInvoiceHeader.InvoiceHeaderId);
                //        else
                //            XtraMessageBox.Show("Kredit Silmə Yetkiniz yoxdur!");

                efMethods.DeleteInvoice(trInvoiceHeader.InvoiceHeaderId);

                ClearControlsAddNew();
            }
        }

        private void bBI_PaymentDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Ödənişləri Silmek Isteyirsiz?", "Diqqet", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                efMethods.DeletePaymentsByInvoiceId(trInvoiceHeader.InvoiceHeaderId);
                CalcPaidAmount();
            }
        }

        private void BBI_InstallmentDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (MessageBox.Show("Kreditləri Silmek Isteyirsiz?", "Diqqet", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //{
            //    efMethods.DeleteInstallmentsByInvoiceId(trInvoiceHeader.InvoiceHeaderId);
            //    CalcInstallmentAmount();
            //}
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
                decimal summInvoice = (decimal)colNetAmountLoc.SummaryItem.SummaryValue;

                if (summInvoice != 0 || trInvoiceHeader.ProcessCode == "IT")
                {
                    SaveInvoice();
                    Close();
                }
                else if (XtraMessageBox.Show("Ödəmə 0a bərabərdir! \n Fakturaya qayıtmaq istəyirsiz? ", "Diqqət", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    Close();
                }
                ;
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
            dcReport.ReportQuery = cM.ApplyFilter(dcReport, dcReport.ReportQuery, "", out sqlParameters);
            List<QueryParameter> qryParams = cM.ConvertSqlParametersToQueryParameters(sqlParameters);
            CustomSqlQuery mainQuery = new("Main", dcReport.ReportQuery);
            mainQuery.Parameters.AddRange(qryParams);
            List<CustomSqlQuery> sqlQueries = new(new[] { mainQuery });
            XtraReport xtraReport = reportClass.GetReport(dcReport.ReportName, dcReport.ReportName + ".repx", sqlQueries);

            MemoryStream ms = new();
            xtraReport.ExportToImage(ms, new ImageExportOptions() { Format = ImageFormat.Png, PageRange = "1", ExportMode = ImageExportMode.SingleFile, Resolution = 240 });

            return ms;
        }

        private void bBI_Whatsapp_ItemClick(object sender, ItemClickEventArgs e)
        {
            MemoryStream memoryStream = GetInvoiceReportImg();
            Clipboard.SetImage(Image.FromStream(memoryStream));
            string phoneNum = efMethods.SelectCurrAcc(trInvoiceHeader.CurrAccCode).PhoneNum;

            SendWhatsApp(phoneNum, "");
        }

        private void SendWhatsApp(string number, string message)
        {
            if (string.IsNullOrEmpty(number))
            {
                MessageBox.Show("Nömrə qeyd olunmayıb.");
                return;
            }

            number = "+994" + number.Trim();

            string link = $"https://web.whatsapp.com/send?phone={number}&text={Uri.EscapeDataString(message)}";

            string profileName = Settings.Default.AppSetting.WhatsappChromeProfileName;

            ProcessStartInfo startInfo;

            if (!string.IsNullOrEmpty(profileName))
            {
                string profileCode = GetChromeProfileCodeByName(profileName);
                if (profileCode == null)
                {
                    MessageBox.Show($"Chrome profil '{profileName}' tapılmadı."); // Chrome profil couldn't find
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
                MessageBox.Show($"Failed to open link: {ex.Message}");
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


        private void btnEdit_CurrAccCode_Validating(object sender, CancelEventArgs e)
        {
            object eValue = trInvoiceHeader?.CurrAccCode;

            if (eValue is not null)
            {
                DcCurrAcc curr = efMethods.SelectEntityById<DcCurrAcc>(eValue.ToString());

                if (curr is null)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnEdit_CurrAccCode_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = "Belə bir cari yoxdur";
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
                if (item is LayoutControlItem layoutControlItem)
                {
                    if (layoutControlItem.Control is GridControl gridControl)
                        gridControl.Enabled = !isReadOnly;
                    else if (layoutControlItem.Control is BaseEdit baseEdit)
                    {
                        baseEdit.Properties.ReadOnly = isReadOnly;

                        if (baseEdit is ButtonEdit buttonEdit && baseEdit.DataBindings[0].BindingMemberInfo.BindingField != nameof(TrInvoiceHeader.DocumentNumber))
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
            //gV_InvoiceLine.OptionsNavigation.EnterMoveNextColumn = false;
            if (new string[] { "EX", "EI", "IT" }.Contains(dcProcess.ProcessCode))
            {
                BBI_InvoiceExpenses.Visibility = BarItemVisibility.Never;
                RPG_Payment.Visible = false;
                RPG_Installment.Visible = false;
            }
            else
            {
                BBI_InvoiceExpenses.Visibility = BarItemVisibility.Always;
                RPG_Payment.Visible = true;
                RPG_Installment.Visible = true;
            }

            LCG_InfoInstallment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            LCG_Installment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            RPG_Installment.Visible = false;

            if (new string[] { "EX", "EI", "CI", "CO", "IT" }.Contains(dcProcess.ProcessCode))
            {
                btnEdit_CurrAccCode.Enabled = false;
                colBalance.Visible = false;
                col_PosDiscount.Visible = false;
                colProductCost.Visible = false;
                colBenefit.Visible = false;

                if (new string[] { "EX", "EI" }.Contains(dcProcess.ProcessCode))
                {
                    colQty.Visible = false;
                    colQty.OptionsColumn.ReadOnly = true;
                }

                if (new string[] { "CI", "CO", "IT" }.Contains(dcProcess.ProcessCode))
                {
                    LCG_InfoPayment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    if (dcProcess.ProcessCode == "IT")
                    {
                        btnEdit_CurrAccCode.Enabled = true;
                        col_Price.Visible = false;
                        colCurrencyCode.Visible = false;
                        col_NetAmount.Visible = false;
                    }
                }
            }
            if (new string[] { "IS" }.Contains(dcProcess.ProcessCode))
            {
                LCG_InfoInstallment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                LCG_Installment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                RPG_Installment.Visible = true;
            }

            //string layoutHeaderPath = Path.Combine(AppContext.BaseDirectory, "Layout Xml Files", "InvoiceHeader" + dcProcess.ProcessCode + "Layout.xml");

            string layoutHeaderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Foxoft", Settings.Default.CompanyCode, "Layout Xml Files", "InvoiceHeader" + dcProcess.ProcessCode + "Layout.xml");

            if (File.Exists(layoutHeaderPath))
                dataLayoutControl1.RestoreLayoutFromXml(layoutHeaderPath);

            //string layoutLineFilePath = Path.Combine(AppContext.BaseDirectory, "Layout Xml Files", "InvoiceLine" + dcProcess.ProcessCode + "Layout.xml");
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

            colBalance.OptionsColumn.ReadOnly = true;
            colProductCost.OptionsColumn.ReadOnly = true;
            col_NetAmount.OptionsColumn.ReadOnly = true;
            colNetAmountLoc.OptionsColumn.ReadOnly = true;
            col_Amount.OptionsColumn.ReadOnly = true;
            colAmountLoc.OptionsColumn.ReadOnly = true;


            if (!colNetAmountLoc.Summary.Any(x => x.SummaryType == SummaryItemType.Sum))
                colNetAmountLoc.Summary.AddRange(new GridSummaryItem[] { new GridColumnSummaryItem(SummaryItemType.Sum, "NetAmountLoc", "{0:n2}") });
        }

        private void SaveLayout()
        {
            string fileName = "InvoiceLine" + dcProcess.ProcessCode + "Layout.xml";
            //string layoutFileDir = Path.Combine(AppContext.BaseDirectory, "Layout Xml Files");
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
            OpenFileDialog dialog = new();
            dialog.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|" +
                            "All files (*.*)|*.*";
            dialog.Title = "Excel faylı seçin.";

            DialogResult dr = dialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);

                ExcelDataSource excelDataSource = new();
                excelDataSource.FileName = dialog.FileName;

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
                double rowCount = 0;
                foreach (DataRow row in dt.Rows)
                {
                    int i = Convert.ToInt32(rowCount / dt.Rows.Count * 100);
                    SplashScreenManager.Default.SendCommand(WaitForm.WaitFormCommand.SetProgress, i);
                    SplashScreenManager.Default.SetWaitFormDescription(i + "%");
                    rowCount++;

                    string captionProductCode = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.ProductCode);
                    string productCode = row[captionProductCode].ToString();

                    if (!string.IsNullOrEmpty(productCode))
                    {
                        DcProduct product = efMethods.SelectProduct(productCode);

                        if (product is not null)
                        {
                            object objInvoiceHeadId = gV_InvoiceLine.GetRowCellValue(GridControl.NewItemRowHandle, col_InvoiceHeaderId);
                            if (objInvoiceHeadId is null) // Check InitNewRow
                                gV_InvoiceLine.AddNewRow();

                            FillRow(GridControl.NewItemRowHandle, product);

                            foreach (DataColumn column in dt.Columns)
                            {
                                try
                                {
                                    string captionQty = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.Qty);
                                    if (column.ColumnName == captionQty)
                                    {
                                        GridColumn qty = (bool)CustomExtensions.DirectionIsIn(trInvoiceHeader.ProcessCode) ? colQtyIn : colQtyOut;
                                        gV_InvoiceLine.SetRowCellValue(GridControl.NewItemRowHandle, qty, row[captionQty].ToString());
                                    }

                                    string captionLineDesc = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.LineDescription);
                                    if (column.ColumnName == captionLineDesc)
                                        gV_InvoiceLine.SetRowCellValue(GridControl.NewItemRowHandle, col_LineDesc, row[captionLineDesc].ToString());

                                    if (dcProcess.ProcessCode != "IT")
                                    {
                                        string captionPrice = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.Price);
                                        if (column.ColumnName == captionPrice)
                                            gV_InvoiceLine.SetRowCellValue(GridControl.NewItemRowHandle, col_Price, row[captionPrice].ToString());

                                        string captionCurrency = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.CurrencyCode);
                                        if (column.ColumnName == captionCurrency)
                                        {
                                            if (!string.IsNullOrEmpty(row[captionCurrency].ToString()))
                                            {
                                                DcCurrency currency = efMethods.SelectEntityById<DcCurrency>(row[captionCurrency].ToString());
                                                if (currency is null)
                                                    currency = efMethods.SelectCurrencyByName(row[captionCurrency].ToString());

                                                if (currency is not null)
                                                {
                                                    gV_InvoiceLine.SetRowCellValue(GridControl.NewItemRowHandle, colCurrencyCode, currency.CurrencyCode);
                                                    gV_InvoiceLine.SetRowCellValue(GridControl.NewItemRowHandle, colExchangeRate, currency.ExchangeRate);
                                                }
                                                else
                                                    errorCodes += captionCurrency + ": " + row[captionCurrency].ToString() + "\n";
                                            }
                                        }

                                        string captionExRate = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.ExchangeRate);
                                        if (column.ColumnName == captionExRate)
                                            gV_InvoiceLine.SetRowCellValue(GridControl.NewItemRowHandle, colExchangeRate, row[captionExRate].ToString());

                                        string captionPosDiscount = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.PosDiscount);
                                        if (column.ColumnName == captionPosDiscount)
                                            gV_InvoiceLine.SetRowCellValue(GridControl.NewItemRowHandle, col_PosDiscount, row[captionPosDiscount].ToString());

                                        string captionSerialNumber = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.SerialNumberCode);
                                        if (column.ColumnName == captionSerialNumber)
                                            gV_InvoiceLine.SetRowCellValue(GridControl.NewItemRowHandle, colSerialNumberCode, row[captionSerialNumber].ToString());
                                    }
                                }
                                catch (ArgumentException ae)
                                {
                                    MessageBox.Show("Xəta No: 256545 \n" + ae.Message, "Import xetası");
                                }
                            }

                            gV_InvoiceLine.UpdateCurrentRow();
                        }
                        else
                            errorCodes += captionProductCode + ": " + row[captionProductCode].ToString() + "\n";
                    }
                }

                SplashScreenManager.CloseForm(false);
                if (!string.IsNullOrEmpty(errorCodes))
                    MessageBox.Show("Aşağıdakı kodlar üzrə Dəyər tapılmadı \n" + errorCodes, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillRow(int rowHandle, DcProduct product)
        {
            gV_InvoiceLine.SetRowCellValue(rowHandle, col_ProductCode, product.ProductCode);
            gV_InvoiceLine.SetFocusedRowCellValue(colProductCost, product.ProductCost);

            decimal priceProduct = 0;

            priceProduct = Settings.Default.AppSetting.UsePriceList
                ? efMethods.SelectPriceByProcess(dcProcess.ProcessCode, product.ProductCode)
                : dcProcess.ProcessCode switch
                {
                    "RP" => product.PurchasePrice,
                    "RS" => product.RetailPrice,
                    "WS" => product.WholesalePrice,
                    _ => 0
                };

            decimal priceInvoice = Convert.ToInt32(gV_InvoiceLine.GetRowCellValue(rowHandle, col_Price));
            if (priceInvoice == 0)
                gV_InvoiceLine.SetRowCellValue(rowHandle, col_Price, priceProduct);
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

        private void btnEdit_CurrAccCode_EditValueChanged(object sender, EventArgs e)
        {
            DcCurrAcc curr = efMethods.SelectEntityById<DcCurrAcc>(btnEdit_CurrAccCode.EditValue?.ToString());
            if (trInvoiceHeader is null || curr is null)
                return;

            trInvoiceHeader.CurrAccCode = curr?.CurrAccCode;
            lbl_CurrAccDesc.Text = curr?.CurrAccDesc + " " + curr?.FirstName + " " + curr?.LastName;

            CurrAccBalanceBefore = Math.Round(efMethods.SelectCurrAccBalance(trInvoiceHeader.CurrAccCode, trInvoiceHeader.OperationDate.Add(trInvoiceHeader.OperationTime)), 2);

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
            return reportClass.GetReport("invoice", fileName, new SqlQuery[] { sqlQuerySale });
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

        private void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show(gV_InvoiceLine.ActiveEditor?.Text.ToString());
        }

        private void gV_InvoiceLine_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            int rowInd = gV_InvoiceLine.GetRowHandle(e.ListSourceRowIndex);
            object obj = gV_InvoiceLine.GetRowCellValue(rowInd, col_ProductCode);

            if (obj is not null && new GridColumn[] { col_ProductDesc, colBalance }.Contains(e.Column) && e.IsGetData)
            {
                string productCode = obj.ToString();
                DcProduct dcProduct = subContext.DcProducts // more fast query
                                        .Include(x => x.DcHierarchy)
                                        .Include(x => x.TrProductFeatures)
                                        .FirstOrDefault(x => x.ProductCode == productCode);

                if (dcProduct is not null)
                {
                    dcProduct.Balance = subContext.TrInvoiceLines.Include(x => x.TrInvoiceHeader)
                                                                 .Where(x => new string[] { "RP", "WP", "RS", "WS", "IS", "CI", "CO", "IT" }.Contains(x.TrInvoiceHeader.ProcessCode))
                                                                 .Where(x => x.ProductCode == productCode)
                                                                 .Sum(x => x.QtyIn - x.QtyOut);

                    if (e.Column == col_ProductDesc)
                        e.Value = GetProductDescWide(dcProduct);
                    else if (e.Column == colBalance)
                        e.Value = dcProduct.Balance;
                }
            }
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
                    decimal productBalance = CalcProductBalance(trInvoiceLine, warehouse.EditValue?.ToString());

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

        private void btnEdit_SalesPerson_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            FormCurrAccList form = new(new byte[] { 3 }, trInvoiceHeader.CurrAccCode, new byte[] { 1 });

            if (form.ShowDialog(this) == DialogResult.OK)
                btnEdit_SalesPerson.EditValue = form.dcCurrAcc.CurrAccCode;
        }

        private void btnEdit_SalesPerson_EditValueChanged(object sender, EventArgs e)
        {
            DcCurrAcc salesMan = efMethods.SelectSalesPerson(btnEdit_SalesPerson.EditValue?.ToString());
            if (salesMan is not null)
            {
                LBL_SalesPersonDesc.Text = salesMan.CurrAccDesc + " " + salesMan.FirstName + " " + salesMan.LastName;

                for (int i = 0; i < gV_InvoiceLine.DataRowCount; i++)
                    gV_InvoiceLine.SetRowCellValue(i, col_SalesPersonCode, btnEdit_SalesPerson.EditValue);
            }
            else
            {
                LBL_SalesPersonDesc.Text = string.Empty;

                for (int i = 0; i < gV_InvoiceLine.DataRowCount; i++)
                    gV_InvoiceLine.SetRowCellValue(i, col_SalesPersonCode, null);
            }
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
                MessageBox.Show("Xeta: 1256795721 \n" + ex.Message);
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

                DcProduct product = efMethods.SelectProduct(productCode);
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

        private void btnEdit_CurrAccCode_EditValueChanging(object sender, ChangingEventArgs e)
        {

        }

        private void repoBtnEdit_InstallmentGarantorDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (gV_InstallmentGarantor.FocusedRowHandle >= 0)
            {
                DialogResult result = XtraMessageBox.Show(
                    "Silmək istəyirsiz?",
                    "Diqqət!",
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
            FormCurrAccList form = new(new byte[] { 1, 2, 3 });

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var newGuarantor = new TrInstallmentGuarantor
                {
                    CurrAccCode = form.dcCurrAcc.CurrAccCode,
                    DcCurrAcc = form.dcCurrAcc,
                    InstallmentId = trInvoiceHeader.TrInstallment.InstallmentId
                };

                var existingEntity = dbContext2.ChangeTracker.Entries<DcCurrAcc>()
                    .FirstOrDefault(e => e.Entity.CurrAccCode == form.dcCurrAcc.CurrAccCode);

                if (existingEntity != null)
                {
                    XtraMessageBox.Show("Bu cari artıq əlavə olunub", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}