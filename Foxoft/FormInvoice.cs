
#region Using
using DevExpress.Data;
using DevExpress.DataAccess.Excel;
using DevExpress.DataAccess.Native.Excel;
using DevExpress.DataAccess.Sql;
using DevExpress.Utils.Behaviors.Common;
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
using Foxoft.AppCode;
using Foxoft.AppCode.Service;
using Foxoft.AppCode.Services;
using Foxoft.Models;
using Foxoft.Models.Entity.Report;
using Foxoft.Properties;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
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
        readonly DcTerminal dcTerminal;
        public TrInvoiceHeader trInvoiceHeader;
        private bool isReturn;
        Guid newInvoiceHeaderId;
        Guid? relatedInvoiceId;
        public DcProcess dcProcess;
        private byte[] productTypeArr;
        private decimal CurrAccBalanceBefore;
        ReportClass reportClass;
        private string salesPersonCode;
        private FormProductList? productsForm;

        private readonly DocumentLockService _lockService;
        private LoyaltyService _loyaltyService;
        private PaymentService _paymentService;
        private readonly Guid _appInstanceId;
        public Guid _formInstanceId;
        private bool _closingByLock = false;
        private DateTime _lastInfoPaymentPopupAt = DateTime.MinValue;
        private int _pid => Process.GetCurrentProcess().Id;

        public bool isNew = false;
        private bool _isSaved = false;
        private bool _isLoading = false;
        private bool IsCampaignEnabled
            => Settings.Default.AppSetting != null
            && Settings.Default.AppSetting.UseCampaign;

        public FormInvoice(string processCode, bool? isReturn, byte[] productTypeArr, Guid? relatedInvoiceId)
        {
            settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);
            dcTerminal = efMethods.SelectEntityById<DcTerminal>(Settings.Default.TerminalId);
            dcProcess = efMethods.SelectEntityById<DcProcess>(processCode);
            reportClass = new(settingStore.DesignFileFolder);

            dbContext = new subContext();
            _lockService = new DocumentLockService(dbContext);
            _paymentService = new PaymentService(dcProcess);

            FormERP parent = Application.OpenForms["FormERP"] as FormERP;
            _appInstanceId = parent._appInstanceId;

            InitializeComponent();

            _formInstanceId = Guid.NewGuid();

            InitializeColumnName();

            this.productTypeArr = productTypeArr;
            this.relatedInvoiceId = relatedInvoiceId;

            if (isReturn.HasValue)
            {
                this.isReturn = (bool)isReturn;

                checkEdit_IsReturn.Properties.Appearance.ForeColor = (bool)isReturn ? Color.Red : Color.Empty;
            }

            lUE_StoreCode.Properties.DataSource = efMethods.SelectStoresIncludeDisabled();

            bool canChangeStore = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "ChangeStore");
            lUE_StoreCode.ReadOnly = !canChangeStore;
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

            LoadInvoiceLineFeaturesColumns();
            LoadLayout();

            if (settingStore is not null)
                if (CustomExtensions.DirectoryExist(settingStore.ImageFolder))
                    AppDomain.CurrentDomain.SetData("DXResourceDirectory", settingStore.ImageFolder);


            DateEdit_InstallmentDate.EditValueChanged += trInvoiceHeadersBindingSource_CurrentItemChanged;
            LUE_InstallmentPlan.EditValueChanged += trInvoiceHeadersBindingSource_CurrentItemChanged;
            txtEdit_Installment_Commission.Leave += trInvoiceHeadersBindingSource_CurrentItemChanged;
        }

        public FormInvoice(string processCode, bool? isReturn, byte[] productTypeArr, Guid? relatedInvoiceId, bool isNew)
            : this(processCode, isReturn, productTypeArr, relatedInvoiceId)
        {
            this.isNew = isNew;
        }

        public FormInvoice(string processCode, bool? isReturn, byte[] productTypeArr, Guid? relatedInvoiceId, Guid invoiceHeaderId)
            : this(processCode, isReturn, productTypeArr, relatedInvoiceId)
        {
            trInvoiceHeader = efMethods.SelectInvoiceHeader(invoiceHeaderId);
        }

        private void FormInvoice_Load(object sender, EventArgs e)
        {
            LoadShortcuts();
        }

        private void LoadShortcuts()
        {
            // Button adı → BarButtonItem referansı
            var buttonMap = new Dictionary<string, BarButtonItem>(StringComparer.OrdinalIgnoreCase)
            {
                ["bBI_Save"]              = bBI_Save,
                ["bBI_SaveAndNew"]        = bBI_SaveAndNew,
                ["bBI_SaveAndQuit"]       = bBI_SaveAndQuit,
                ["bBI_Payment"]           = bBI_Payment,
                ["bBI_New"]               = bBI_New,
                ["bBI_reportPreview"]     = bBI_reportPreview,
                ["bBI_DeleteInvoice"]     = bBI_DeleteInvoice,
                ["bBI_PaymentDelete"]     = bBI_DeletePayment,
                ["bBI_CopyInvoice"]       = bBI_CopyInvoice,
                ["bBI_Whatsapp"]          = bBI_Whatsapp,
                ["BBI_EditInvoice"]       = BBI_ModifyInvoice,
                ["BBI_exportXLSX"]        = BBI_exportXLSX,
                ["BBI_ImportExcel"]       = BBI_ImportExcel,
                ["BBI_ReportPrintFast"]   = BBI_ReportPrintFast,
                ["BBI_picture"]           = BBI_picture,
                ["BBI_InvoiceExpenses"]   = BBI_InvoiceExpenses
                // Note: Kampaniya düymələri kimi bəzi buttonlar bəlkə tam başqa yerdədir, onları tapana qədər commentdə saxlayaq.
            };

            var shortcuts = Foxoft.AppCode.ShortcutHelper.LoadShortcuts("FormInvoice");

            foreach (var kvp in shortcuts)
            {
                if (buttonMap.TryGetValue(kvp.Key, out var item) && item != null)
                {
                    // DevExpress BarButtonItem üçün ItemShortcut istifadə olunur
                    if (kvp.Value != Keys.None)
                    {
                        item.ItemShortcut = new BarShortcut(kvp.Value);
                        // Text-ə əlavə etmirik çünki DevExpress özü tooltip-də göstərir (və ya ItemShortcut property özü kifayət edir)
                    }
                }
            }
        }

        private void LoadInvoiceLineFeaturesColumns()
        {
            List<DcInvoiceLineFeatureType> dcFeatures = efMethods.SelectEntities<DcInvoiceLineFeatureType>();
            if (dcFeatures == null) return;

            foreach (DcInvoiceLineFeatureType feature in dcFeatures)
            {
                string fieldName = "Feature_" + feature.InvoiceLineFeatureTypeId;

                if (gV_InvoiceLine.Columns[fieldName] != null) continue;

                GridColumn col = new GridColumn();
                col.FieldName = fieldName;
                col.Caption = feature.FeatureTypeName;
                col.Name = "col" + fieldName;
                col.UnboundDataType = typeof(string);
                col.Visible = true;
                col.Tag = feature.InvoiceLineFeatureTypeId;
                col.OptionsColumn.AllowEdit = true;

                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repoBtn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                repoBtn.Name = "repoBtn" + fieldName;
                repoBtn.Tag = feature.InvoiceLineFeatureTypeId;
                repoBtn.ButtonPressed += RepoBtnFeature_ButtonPressed;

                gC_InvoiceLine.RepositoryItems.Add(repoBtn);
                col.ColumnEdit = repoBtn;

                gV_InvoiceLine.Columns.Add(col);
            }
        }

        private void RepoBtnFeature_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            GridColumn column = gV_InvoiceLine.FocusedColumn;
            if (column == null || column.Tag == null) return;

            int featureTypeId = Convert.ToInt32(column.Tag);

            using FormCommonList<DcInvoiceLineFeature> frm = new("F", nameof(DcInvoiceLineFeature.InvoiceLineFeatureCode), editor.EditValue?.ToString(), nameof(DcInvoiceLineFeature.InvoiceLineFeatureTypeId), featureTypeId);
            if (DialogResult.OK == frm.ShowDialog(this))
            {
                editor.EditValue = frm.Value_Id;
                gV_InvoiceLine.PostEditor();
            }
        }


        private async void FormInvoice_Shown(object sender, EventArgs e)
        {
            if (isNew)
                ClearControlsAddNew();
            else
                await LoadInvoiceAsync(trInvoiceHeader.InvoiceHeaderId);

            dataLayoutControl1.IsValid(out List<string> errorList);
            gC_InvoiceLine.Focus();
        }

        private bool HasUnsavedChanges()
        {
            if (Settings.Default.AppSetting.AutoSave)
                return false;

            if (dbContext == null || trInvoiceHeader == null)
                return false;

            if (!HasInvoiceProductLines())
                return false;

            return dbContext.ChangeTracker.HasChanges();
        }

        private bool HasInvoiceProductLines()
        {
            if (trInvoiceHeader is null)
                return false;

            if (trInvoiceLinesBindingSource?.List is IEnumerable invoiceLines)
            {
                foreach (object item in invoiceLines)
                    if (item is TrInvoiceLine line
                        && line.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId
                        && !string.IsNullOrWhiteSpace(line.ProductCode))
                        return true;
            }

            for (int i = 0; i < gV_InvoiceLine.DataRowCount; i++)
                if (!string.IsNullOrWhiteSpace(gV_InvoiceLine.GetRowCellValue(i, col_ProductCode)?.ToString()))
                    return true;

            return false;
        }

        /// <summary>
        /// Prompts the user to save unsaved changes when AutoSave is off.
        /// Returns true if the caller should proceed, false if the action was cancelled.
        /// </summary>
        private bool PromptSaveChanges()
        {
            if (!HasUnsavedChanges())
                return true;

            var result = XtraMessageBox.Show(
                Resources.Form_Invoice_UnsavedChangesQuestion,
                Resources.Common_Attention,
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (dataLayoutControl1.IsValid(out _))
                {
                    return SaveInvoice();
                }
                return false; // validation failed, cancel the action
            }

            if (result == DialogResult.No)
                return true; // discard changes, proceed

            return false; // Cancel
        }

        private bool EnsureInvoiceSaved()
        {
            if (Settings.Default.AppSetting.AutoSave)
            {
                if (!HasUnsavedChanges())
                    return true;

                return SaveInvoice();
            }

            if (!HasUnsavedChanges())
                return true;

            var result = XtraMessageBox.Show(
                Resources.Form_Invoice_UnsavedChangesQuestion,
                Resources.Common_Attention,
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return false;

            if (!dataLayoutControl1.IsValid(out _))
                return false;

            return SaveInvoice();
        }

        private void InitializeColumnName()
        {
            colBalance.Caption = ReflectionExt.GetDisplayName<DcProduct>(x => x.Balance);
            col_ProductDesc.Caption = ReflectionExt.GetDisplayName<DcProduct>(x => x.ProductDesc);
            LCI_CashRegCode.Text = ReflectionExt.GetDisplayName<TrPaymentLine>(x => x.CashRegisterCode);
        }

        private void ClearControlsAddNew()
        {
            if (trInvoiceHeader is not null)
            {
                _lockService.ReleaseLock(
                    "Invoice",
                    trInvoiceHeader.InvoiceHeaderId,
                    Authorization.CurrAccCode,
                    Environment.MachineName,
                    _appInstanceId);
            }

            dbContext = new subContext();
            _loyaltyService = new LoyaltyService(dbContext);

            newInvoiceHeaderId = Guid.NewGuid();

            if (TryAcquireInvoiceLockForEdit(newInvoiceHeaderId))
            {
                if (trInvoiceHeader is not null)
                {
                    Guid oldInvoiceHeaderId = trInvoiceHeader.InvoiceHeaderId;

                    _lockService.ReleaseLock(
                            "Invoice",
                            oldInvoiceHeaderId,
                            Authorization.CurrAccCode,
                            Environment.MachineName,
                            _appInstanceId);
                }
            }
            else
                return;

            dbContext.TrInvoiceHeaders.Include(x => x.DcProcess)
                                      .Include(x => x.DcCurrAcc)
                                      .Include(x => x.TrInstallment)
                                      .Where(x => x.InvoiceHeaderId == newInvoiceHeaderId)
                                      .Load();

            trInvoiceHeadersBindingSource.DataSource = dbContext.TrInvoiceHeaders.Local.ToBindingList();
            trInvoiceHeader = trInvoiceHeadersBindingSource.AddNew() as TrInvoiceHeader;

            trInvoiceLinesBindingSource.DataSource = null;

            this.Text = $"{dcProcess.ProcessDesc} - ({btnEdit_DocNum.EditValue})";

            UpdatePaidLabels();
            UpdateInstallmentLabels();

            lbl_CurrAccDesc.Text = trInvoiceHeader.CurrAccDesc;

            trInvoiceHeader.IsReturn = isReturn;

            dbContext.TrInvoiceLines.Include(x => x.DcProduct)
                                    .Include(x => x.TrInvoiceHeader).ThenInclude(x => x.DcProcess)
                                    .Include(x => x.DcUnitOfMeasure).ThenInclude(x => x.ParentUnitOfMeasure)
                                    .Include(x => x.TrInvoiceLineFeatures)
                                    .Where(x => x.InvoiceHeaderId == trInvoiceHeader.InvoiceHeaderId)
                                    .LoadAsync();

            trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList();

            if (new string[] { "EX", "EI" }.Contains(dcProcess.ProcessCode))
            {
                ApplyExpenseDefaultCashRegisterByStore(trInvoiceHeader.StoreCode);

                trInvoiceHeader.CashRegisterCode = efMethods.SelectCashRegisterByTerminal(Settings.Default.TerminalId, GetInvoiceCashRegPaymentTypeFilter());
                btn_CashRegCode.EditValue = trInvoiceHeader.CashRegisterCode;
            }

            if (IsInstallmentProcess())
                ClearInstallmentGarantorsAddNew();

            dataLayoutControl1.IsValid(out List<string> errorList);

            txt_LoyaltyEarn.EditValue = 0m;

            InitCampaignIfEnabled();

            if (!IsCampaignEnabled)
            {
                _cashOnlyCampaignApplied = false;
                _appliedPromoCode = null;
            }

            Tag = btnEdit_DocNum.EditValue;
            _isSaved = false;

            PopulateRelatedInvoicesMenu();

            SetLayoutGroupReadOnly(LCG_Invoice, trInvoiceHeader.IsLocked);
        }

        private void ClearInstallmentGarantorsAddNew()
        {
            dbContext2 = new subContext();
            int installmentId = EnsureInstallment().InstallmentId;

            dbContext2.TrInstallmentGuarantors.Include(x => x.DcCurrAcc)
                                              .Where(x => x.InstallmentId == installmentId)
                                              .Load();

            trInstallmentGuarantorsBindingSource.DataSource = dbContext2.TrInstallmentGuarantors.Local.ToBindingList();

            gV_InstallmentGarantor.BestFitColumns();
        }

        private void trInvoiceHeadersBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            TrInvoiceHeader invoiceHeader = new();
            invoiceHeader.InvoiceHeaderId = newInvoiceHeaderId;
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
            invoiceHeader.TerminalId = Settings.Default.TerminalId;
            invoiceHeader.WarehouseCode = efMethods.SelectWarehouseByStore(Authorization.StoreCode);

            if (new string[] { "RS", "WS" }.Contains(dcProcess.ProcessCode))
            {
                string defaultCustomer = efMethods.SelectDefaultCustomerByStore(Authorization.StoreCode);
                invoiceHeader.CurrAccCode = defaultCustomer;

                if (efMethods.SelectCurrAcc(defaultCustomer) is not null)
                    invoiceHeader.CurrAccDesc = efMethods.SelectCurrAcc(defaultCustomer).CurrAccDesc;
            }

            if (dcProcess.ProcessCode == "IS")
                invoiceHeader.TrInstallment = CreateInstallment(invoiceHeader.InvoiceHeaderId);

            e.NewObject = invoiceHeader;
        }

        private void trInvoiceHeadersBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            dataLayoutControl1.Validate();  // ensure editor loses focus and commits value

            trInvoiceHeader = trInvoiceHeadersBindingSource.Current as TrInvoiceHeader;

            if (trInvoiceHeader is null)
                return;

            if (IsInstallmentProcess())
            {
                TrInstallment installment = EnsureInstallment();

                if (sender as LookUpEdit == LUE_InstallmentPlan
                && !string.IsNullOrEmpty(LUE_InstallmentPlan.EditValue?.ToString()))
                    ApplySelectedInstallmentPlan(installment);

                if (sender as DateEdit == DateEdit_InstallmentDate
                && !string.IsNullOrEmpty(DateEdit_InstallmentDate.EditValue?.ToString()))
                    installment.InstallmentDate = (DateTime)DateEdit_InstallmentDate.EditValue;

                UpdateInstallmentLabels();
            }

            if (!_isLoading && dbContext != null && dataLayoutControl1.IsValid(out _))
                if (Settings.Default.AppSetting.AutoSave)
                    if (gV_InvoiceLine.DataRowCount > 0)
                        if (!new[] { "EX", "EI" }.Contains(dcProcess.ProcessCode)
                            || !string.IsNullOrEmpty(trInvoiceHeader.CashRegisterCode))
                            SaveInvoice();

            //gV_InvoiceLine.Focus();
        }

        private async void btnEdit_DocNum_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Left)
                await NavigateInvoiceAsync(isPrevious: true);
            else if (e.Button.Kind == ButtonPredefines.Right)
                await NavigateInvoiceAsync(isPrevious: false);
            else
                await SelectDocNumAsync();
        }

        //private void btnEdit_DocNum_DoubleClick(object sender, EventArgs e)
        //{
        //    SelectDocNum();
        //}

        private async Task SelectDocNumAsync()
        {
            if (!PromptSaveChanges())
                return;

            using FormInvoiceHeaderList form = new(dcProcess.ProcessCode, relatedInvoiceId);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (TryAcquireInvoiceLockForEdit(form.trInvoiceHeader.InvoiceHeaderId))
                {
                    if (trInvoiceHeader is not null)
                        _lockService.ReleaseLock(
                        "Invoice",
                        trInvoiceHeader.InvoiceHeaderId,
                        Authorization.CurrAccCode,
                        Environment.MachineName,
                        _appInstanceId);

                    trInvoiceHeader = form.trInvoiceHeader;
                    await LoadInvoiceAsync(trInvoiceHeader.InvoiceHeaderId);
                }
            }
        }

        private async void BBI_Previous_ItemClick(object sender, ItemClickEventArgs e)
        {
            await NavigateInvoiceAsync(isPrevious: true);
        }

        private async void BBI_Next_ItemClick(object sender, ItemClickEventArgs e)
        {
            await NavigateInvoiceAsync(isPrevious: false);
        }

        private async Task NavigateInvoiceAsync(bool isPrevious)
        {
            if (trInvoiceHeader is null)
                return;

            if (!PromptSaveChanges())
                return;

            using var ctx = new subContext();

            TrInvoiceHeader adjacent;

            if (isPrevious)
            {
                adjacent = ctx.TrInvoiceHeaders
                    .Where(x => relatedInvoiceId == null || x.RelatedInvoiceId == relatedInvoiceId)
                    .Where(x => x.ProcessCode == dcProcess.ProcessCode && x.IsMainTF == true)
                    .Where(x => x.DocumentDate < trInvoiceHeader.DocumentDate
                             || (x.DocumentDate == trInvoiceHeader.DocumentDate
                                 && x.DocumentTime < trInvoiceHeader.DocumentTime)
                             || (x.DocumentDate == trInvoiceHeader.DocumentDate
                                 && x.DocumentTime == trInvoiceHeader.DocumentTime
                                 && x.InvoiceHeaderId != trInvoiceHeader.InvoiceHeaderId
                                 && string.Compare(x.DocumentNumber, trInvoiceHeader.DocumentNumber) < 0))
                    .OrderByDescending(x => x.DocumentDate)
                    .ThenByDescending(x => x.DocumentTime)
                    .ThenByDescending(x => x.DocumentNumber)
                    .FirstOrDefault();
            }
            else
            {
                adjacent = ctx.TrInvoiceHeaders
                    .Where(x => relatedInvoiceId == null || x.RelatedInvoiceId == relatedInvoiceId)
                    .Where(x => x.ProcessCode == dcProcess.ProcessCode && x.IsMainTF == true)
                    .Where(x => x.DocumentDate > trInvoiceHeader.DocumentDate
                             || (x.DocumentDate == trInvoiceHeader.DocumentDate
                                 && x.DocumentTime > trInvoiceHeader.DocumentTime)
                             || (x.DocumentDate == trInvoiceHeader.DocumentDate
                                 && x.DocumentTime == trInvoiceHeader.DocumentTime
                                 && x.InvoiceHeaderId != trInvoiceHeader.InvoiceHeaderId
                                 && string.Compare(x.DocumentNumber, trInvoiceHeader.DocumentNumber) > 0))
                    .OrderBy(x => x.DocumentDate)
                    .ThenBy(x => x.DocumentTime)
                    .ThenBy(x => x.DocumentNumber)
                    .FirstOrDefault();
            }

            if (adjacent is null)
            {
                XtraMessageBox.Show(Resources.FormInvoice_NoMoreInvoice, Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (TryAcquireInvoiceLockForEdit(adjacent.InvoiceHeaderId))
            {
                _lockService.ReleaseLock(
                    "Invoice",
                    trInvoiceHeader.InvoiceHeaderId,
                    Authorization.CurrAccCode,
                    Environment.MachineName,
                    _appInstanceId);

                trInvoiceHeader = adjacent;
                await LoadInvoiceAsync(trInvoiceHeader.InvoiceHeaderId);
            }
        }

        private async Task LoadInvoiceAsync(Guid invoiceHeaderId)
        {
            SetLoadingState(true);

            try
            {
                dbContext = new subContext();
                _loyaltyService = new LoyaltyService(dbContext);

                txt_LoyaltyEarn.EditValue = 0m;

                await dbContext.TrInvoiceHeaders
                    .Include(x => x.DcCurrAcc)
                    .Include(x => x.DcProcess)
                    .Include(x => x.TrInstallment)
                    .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                    .LoadAsync();

                trInvoiceHeadersBindingSource.DataSource = dbContext.TrInvoiceHeaders.Local.ToBindingList();
                trInvoiceHeader = trInvoiceHeadersBindingSource.Current as TrInvoiceHeader;

                dcProcess = efMethods.SelectEntityById<DcProcess>(trInvoiceHeader.ProcessCode);

                Text = $"{dcProcess.ProcessDesc} - ({btnEdit_DocNum.EditValue})";

                // lines
                await dbContext.TrInvoiceLines
                    .Include(o => o.DcProduct).ThenInclude(f => f.TrProductFeatures)
                    .Include(x => x.TrInvoiceHeader).ThenInclude(x => x.DcProcess)
                    .Include(x => x.DcUnitOfMeasure).ThenInclude(x => x.ParentUnitOfMeasure).ThenInclude(x => x.ParentUnitOfMeasure)
                    .Include(x => x.TrInvoiceLineFeatures)
                    .Where(x => x.InvoiceHeaderId == invoiceHeaderId)
                    .OrderBy(x => x.CreatedDate)
                    .LoadAsync();

                trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList();
                gV_InvoiceLine.Focus();

                if (new string[] { "IS" }.Contains(dcProcess.ProcessCode))
                    LoadInstallmentGarantors();

                dataLayoutControl1.IsValid(out List<string> errorList);

                Tag = btnEdit_DocNum.EditValue;

                ApplyInvoiceGracePeriodLock(updateLayout: false);

                SetLayoutGroupReadOnly(LCG_Invoice, trInvoiceHeader.IsLocked);

                trInvoiceHeader.CashRegisterCode = efMethods.CashRegFromExpense(trInvoiceHeader.InvoiceHeaderId);
                btn_CashRegCode.EditValue = trInvoiceHeader.CashRegisterCode;

                UpdatePaidLabels();
                UpdateInstallmentLabels();

                txt_LoyaltyEarn.EditValue = await efMethods.SelectEarnedLoyaltyByInvoiceAsync(invoiceHeaderId);

                if (IsCampaignEnabled)
                {
                    InitCampaignIfEnabled();
                    _cashOnlyCampaignApplied =
                        _campaignService.HasCashOnlyCampaignApplied(invoiceHeaderId);
                }
                else
                {
                    _cashOnlyCampaignApplied = false;
                    _appliedPromoCode = null;
                }

                PopulateRelatedInvoicesMenu();
            }
            finally
            {
                SetLoadingState(false);
            }
        }

        /// <summary>
        /// Loading zamanı navigation/action buttonları disable edir və DbContext-ə paralel
        /// əməliyyat getməsinin qarşısını alır (_isLoading flag vasitəsilə).
        /// </summary>
        private void SetLoadingState(bool isLoading)
        {
            _isLoading = isLoading;

            // Navigation
            BBI_Previous.Enabled = !isLoading;
            BBI_Next.Enabled     = !isLoading;
            btnEdit_DocNum.Enabled = !isLoading;

            if (isLoading)
                SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
            else
                SplashScreenManager.CloseForm(false);
        }

        private bool IsInvoiceGracePeriodExpired()
        {
            if (trInvoiceHeader is null)
                return false;

            return GracePeriodHelper.IsExpired(
                trInvoiceHeader.DocumentDate,
                Settings.Default.AppSetting?.InvoiceEditGraceDays);
        }

        private void ApplyInvoiceGracePeriodLock(bool updateLayout)
        {
            if (!IsInvoiceGracePeriodExpired())
                return;

            trInvoiceHeader.IsLocked = true;

            if (updateLayout)
                SetLayoutGroupReadOnly(LCG_Invoice, true);

            if (efMethods.EntityExists<TrInvoiceHeader>(trInvoiceHeader.InvoiceHeaderId))
                efMethods.UpdateInvoiceIsLocked(trInvoiceHeader.InvoiceHeaderId, true);

            if (dbContext is not null)
            {
                EntityEntry<TrInvoiceHeader> entry = dbContext.Entry(trInvoiceHeader);
                if (entry.State == EntityState.Modified)
                    entry.Property(x => x.IsLocked).IsModified = false;
            }
        }

        private bool EnsureInvoiceCanBeChanged()
        {
            if (!IsInvoiceGracePeriodExpired())
                return true;

            ApplyInvoiceGracePeriodLock(updateLayout: true);

            XtraMessageBox.Show(
                Resources.Form_Invoice_GracePeriodExpired,
                Resources.Common_Attention,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return false;
        }

        private void UpdatePaidLabels()
        {
            var s = _paymentService.GetPaidSummary(
                trInvoiceHeader.InvoiceHeaderId,
                trInvoiceHeader.CurrAccCode,
                dcProcess.ProcessDir);

            lbl_InvoicePaidCashSum.Text = $"{s.Cash:n2} {s.CurrencyCode}";
            lbl_InvoicePaidCashlessSum.Text = $"{s.Cashless:n2} {s.CurrencyCode}";
            lbl_InvoicePaidLoyaltySum.Text = $"{s.Loyalty:n2} {s.CurrencyCode}";
            lbl_InvoicePaidTotalSum.Text = $"{s.Total:n2} {s.CurrencyCode}";
        }

        private bool IsInstallmentProcess()
            => string.Equals(trInvoiceHeader?.ProcessCode ?? dcProcess?.ProcessCode, "IS", StringComparison.OrdinalIgnoreCase);

        private TrInstallment CreateInstallment(Guid invoiceHeaderId)
        {
            DcInstallmentPlan? installmentPlan = GetDefaultInstallmentPlan();

            return new TrInstallment
            {
                InvoiceHeaderId = invoiceHeaderId,
                InstallmentPlanCode = installmentPlan?.InstallmentPlanCode ?? "I00",
                InstallmentDate = DateTime.Now,
                InterestRate = installmentPlan?.InterestRate ?? 0
            };
        }

        private TrInstallment EnsureInstallment()
        {
            if (trInvoiceHeader.TrInstallment is null)
                trInvoiceHeader.TrInstallment = CreateInstallment(trInvoiceHeader.InvoiceHeaderId);

            return trInvoiceHeader.TrInstallment;
        }

        private DcInstallmentPlan? GetDefaultInstallmentPlan()
        {
            IEnumerable<DcInstallmentPlan> installmentPlans =
                (LUE_InstallmentPlan.Properties.DataSource as IEnumerable)?.OfType<DcInstallmentPlan>()
                ?? Enumerable.Empty<DcInstallmentPlan>();

            return installmentPlans.FirstOrDefault(x => x.IsDefault)
                ?? installmentPlans.FirstOrDefault();
        }

        private void ApplySelectedInstallmentPlan(TrInstallment installment)
        {
            string? installmentPlanCode = LUE_InstallmentPlan.EditValue?.ToString();
            if (!string.IsNullOrWhiteSpace(installmentPlanCode))
                installment.InstallmentPlanCode = installmentPlanCode;

            object? interestRateValue = LUE_InstallmentPlan.GetColumnValue(nameof(DcInstallmentPlan.InterestRate));
            if (TryConvertToSingle(interestRateValue, out float interestRate))
            {
                installment.InterestRate = interestRate;
                txtEdit_Installment_InterestRate.EditValue = interestRate;
            }
        }

        private bool TryConvertToSingle(object? value, out float result)
        {
            try
            {
                result = Convert.ToSingle(value, CultureInfo.InvariantCulture);
                return true;
            }
            catch
            {
                result = 0;
                return false;
            }
        }

        private void UpdateInstallmentLabels()
        {
            if (!IsInstallmentProcess())
                return;

            decimal installmentSum = Math.Abs(CalcNetAmountSummmaryValue());
            decimal commission = Math.Abs(trInvoiceHeader?.TrInstallment?.Commission ?? 0);
            decimal total = installmentSum + commission;

            lbl_InstallmentSum.Text = FormatLocalCurrency(installmentSum);
            lbl_InstallmentCommissionSum.Text = FormatLocalCurrency(commission);
            lbl_InstallmentTotalSum.Text = FormatLocalCurrency(total);
        }

        private string FormatLocalCurrency(decimal amount)
        {
            string currencyCode = Settings.Default.AppSetting?.LocalCurrencyCode ?? string.Empty;

            return string.IsNullOrWhiteSpace(currencyCode)
                ? $"{amount:n2}"
                : $"{amount:n2} {currencyCode}";
        }

        private void ShowPrintCount()
        {
            int printCount = efMethods.SelectEntityById<TrInvoiceHeader>(trInvoiceHeader?.InvoiceHeaderId).PrintCount;

            txtEdit_PrintCount.Text = printCount.ToString();
        }

        private void btnEdit_CurrAccCode_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            SelectCurrAccAsync();
        }

        //private void btnEdit_CurrAccCode_DoubleClick(object sender, EventArgs e)
        //{
        //    SelectCurrAccAsync();
        //}

        private async Task SelectCurrAccAsync()
        {
            if (!btnEdit_CurrAccCode.Enabled)
                return;

            FormCurrAccList form = new(new byte[] { 1, 2, 3 }, false, trInvoiceHeader.CurrAccCode);

            if (trInvoiceHeader.ProcessCode == "IT")
                form = new FormCurrAccList(new byte[] { 4 }, false, trInvoiceHeader.CurrAccCode);

            if (form.ShowDialog(this) != DialogResult.OK)
                return;

            btnEdit_CurrAccCode.EditValue = form.dcCurrAcc.CurrAccCode;

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

            if (!string.IsNullOrEmpty(salesPersonCode))
            {
                gv.SetRowCellValue(e.RowHandle, col_SalesPersonCode, salesPersonCode);
            }
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
                    if (!EnsureInvoiceCanBeChanged())
                        return;

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
                SelectCurrAccAsync();

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
            var column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;
            var tr = view.GetFocusedRow() as TrInvoiceLine;

            // If we can't validate safely, do nothing.
            if (column == null || tr == null)
                return;

            string input = (e.Value ?? string.Empty).ToString();

            // Normalize empty input -> default numeric or null (and exit)
            if (string.IsNullOrWhiteSpace(input))
            {
                e.Value = GetEmptyValueForColumn(column);
                return;
            }

            // --- Local helpers --------------------------------------------------------
            void SetError(string msg)
            {
                e.Valid = false;
                e.ErrorText = msg;
            }

            bool IsProductIdentityColumn()
                => column == colBarcode || column == col_ProductCode || column == colSerialNumberCode;

            bool IsStockSensitiveProcess()
                => new[] { "RP", "WP", "RS", "WS", "IS", "IT" }.Contains(trInvoiceHeader?.ProcessCode);

            bool ShouldCheckStock()
            {
                // Stock check only for stock-sensitive processes.
                if (!IsStockSensitiveProcess()) return false;

                bool dirIn = Convert.ToBoolean(CustomExtensions.DirectionIsIn(trInvoiceHeader.ProcessCode));
                // Check stock only when the effective direction is OUT (depleting stock).
                // For returns the direction is flipped: a sale-return brings goods IN → skip stock check.
                return (!trInvoiceHeader.IsReturn && !dirIn) || (trInvoiceHeader.IsReturn && dirIn);
            }

            string ResolveWarehouse()
            {
                var wh = lUE_WarehouseCode.EditValue?.ToString();

                // For IT returns, you were checking ToWarehouse
                if (trInvoiceHeader.IsReturn && trInvoiceHeader.ProcessCode == "IT")
                    wh = lUE_ToWarehouseCode.EditValue?.ToString();

                return wh;
            }

            bool PermitNegativeStock()
                => Convert.ToBoolean(lUE_WarehouseCode.GetColumnValue("PermitNegativeStock"));

            bool IsServiceProduct(string productCode)
                => efMethods.SelectEntityById<DcProduct>(productCode)?.ProductTypeCode == 3;

            void ValidateStock(string productCode, decimal qtyToCompare, decimal qtyDeltaForBalanceCalc)
            {
                if (!ShouldCheckStock()) return;
                if (string.IsNullOrWhiteSpace(productCode)) return;
                if (IsServiceProduct(productCode)) return;

                string wh = ResolveWarehouse();
                decimal balance = CalcProductBalance(tr, productCode, wh, qtyDeltaForBalanceCalc);

                if (!PermitNegativeStock() && qtyToCompare > balance)
                    SetError(Resources.Form_Invoice_NoStockQuantity);
            }

            // -------------------------------------------------------------------------

            if (column.FieldName.StartsWith("Feature_"))
            {
                if (column.Tag == null) return;
                int featureTypeId = Convert.ToInt32(column.Tag);

                bool isValid = dbContext.DcInvoiceLineFeatures
                    .AsNoTracking()
                    .Any(x => x.InvoiceLineFeatureTypeId == featureTypeId && x.InvoiceLineFeatureCode == input);

                if (!isValid)
                {
                    SetError(Resources.Common_InvalidValue);
                    return;
                }
                return;
            }

            if (IsProductIdentityColumn())
            {
                var product = ResolveProduct(column, input, out string errorMsg);
                if (product == null)
                {
                    SetError(errorMsg);
                    return;
                }

                // Prevent changing product if dependent operations exist
                if (HasMismatchingProductInReturnLines(tr, product.ProductCode))
                {
                    SetError(Resources.Form_Invoice_ReturnOperationExists_CannotChangeProductCode);
                    return;
                }

                if (HasMismatchingProductInWaybillLines(tr, product.ProductCode))
                {
                    SetError(Resources.Form_Invoice_HandOverOperationExists_CannotChangeProductCode);
                    return;
                }

                if (tr.RelatedLineId is not null)
                {
                    if (HasMismatchingProductInRelatedReturnLine(tr, product.ProductCode))
                    {
                        SetError(Resources.Form_Invoice_RelatedReturnLineExists_CannotChangeProductCode);
                        return;
                    }

                    if (HasMismatchingProductInRelatedHandOverLine(tr, product.ProductCode))
                    {
                        SetError(Resources.Form_Invoice_RelatedHandOverLineExists_CannotChangeProductCode);
                        return;
                    }
                }

                // Stock check: compare current qty vs balance (same as your original)
                ValidateStock(product.ProductCode, tr.Qty, qtyDeltaForBalanceCalc: 0);
                if (!e.Valid) return;

                return;
            }

            if (column == colQty)
            {
                if (!decimal.TryParse(e.Value?.ToString(), out decimal newQty))
                {
                    SetError(Resources.Common_InvalidNumber);
                    return;
                }

                // Stock check for qty edit: you were passing tr.Qty as delta; keeping same behavior
                ValidateStock(tr.ProductCode, newQty, qtyDeltaForBalanceCalc: tr.Qty);
                if (!e.Valid) return;

                // Return qty cannot be less than existing return operations
                decimal returnSum = Math.Abs(
                    efMethods.SelectReturnLinesByInvoiceLine(tr.InvoiceLineId)
                             .Sum(x => x.QtyIn - x.QtyOut)
                );

                if (newQty < returnSum)
                {
                    SetError(string.Format(Resources.Form_Invoice_ReturnQtyLessThanExisting, returnSum));
                    return;
                }

                // Return qty cannot exceed original sale qty (when invoice is return)
                var invoiceLines = efMethods.SelectInvoiceLineByReturnLine(tr.RelatedLineId, tr.TrInvoiceHeader?.ProcessCode);
                decimal invoiceSum = Math.Abs(invoiceLines.Sum(x => x.QtyIn - x.QtyOut));

                if (trInvoiceHeader.IsReturn && invoiceLines.Any() && newQty > invoiceSum)
                {
                    SetError(string.Format(Resources.Form_Invoice_ReturnQtyGreaterThanSale, invoiceSum));
                    return;
                }

                // Handover qty cannot be less than delivered qty
                decimal waybillSum = Math.Abs(
                    efMethods.SelectWaybillByInvoiceLine(tr.InvoiceLineId)
                             .Sum(x => x.QtyIn - x.QtyOut)
                );

                if (newQty < waybillSum)
                {
                    SetError(string.Format(Resources.Form_Invoice_HandOverQtyLessThanDelivery, waybillSum));
                    return;
                }

                // Work order (?) cannot exceed related invoice qty
                decimal invoiceSum2 = Math.Abs(
                    efMethods.SelectInvoiceLinesByLineId(tr.RelatedLineId)
                             .Sum(x => x.QtyIn - x.QtyOut)
                );

                if (trInvoiceHeader.ProcessCode == "WO" && newQty > invoiceSum2)
                {
                    SetError(string.Format(Resources.Form_Invoice_HandOverQtyGreaterThanSale, invoiceSum2));
                    return;
                }

                // Credit limit check (kept as-is, but now uses newQty)
                if (!string.IsNullOrEmpty(trInvoiceHeader.CurrAccCode)
                    && new[] { "RP", "WP", "RS", "WS", "IS" }.Contains(trInvoiceHeader.ProcessCode))
                {
                    bool dirIn = Convert.ToBoolean(CustomExtensions.DirectionIsIn(trInvoiceHeader.ProcessCode));
                    if ((!trInvoiceHeader.IsReturn && !dirIn) || (trInvoiceHeader.IsReturn && dirIn))
                    {
                        DcCurrAcc dc = efMethods.SelectCurrAcc(trInvoiceHeader.CurrAccCode);
                        decimal currAccBalance = CalcCurrAccCreditBalance(Convert.ToInt32(newQty));

                        if (Math.Abs(currAccBalance) > dc.CreditLimit && dc.CreditLimit != 0 && Convert.ToInt32(newQty) != 0)
                        {
                            SetError(Resources.Form_Invoice_CreditLimitExceeded);
                            return;
                        }
                    }
                }

                // Stock balance warning notification
                if (Settings.Default.AppSetting.NotifyBalanceWarningLevel
                    && new[] { "RS", "WS", "IS" }.Contains(trInvoiceHeader.ProcessCode)
                    && !string.IsNullOrEmpty(tr.ProductCode))
                {
                    DcProduct warningProduct = efMethods.SelectEntityById<DcProduct>(tr.ProductCode);
                    if (warningProduct != null && warningProduct.BalanceWarningLevel > 0)
                    {
                        string wh = ResolveWarehouse();
                        decimal remainingBalance = CalcProductBalance(tr, tr.ProductCode, wh, 0) - newQty + tr.Qty;
                        if (remainingBalance <= warningProduct.BalanceWarningLevel)
                        {
                            alertControl1.Show(this,
                                "Stok Xəbərdarlığı",
                                $"{warningProduct.ProductDesc}: Qalıq {remainingBalance:n2} (Limit: {warningProduct.BalanceWarningLevel:n2})",
                                "", (Image)null, null);
                        }
                    }
                }

                return;
            }

            if (column == col_SalesPersonCode)
            {
                var acc = efMethods.SelectSalesPerson(input);
                if (acc == null || acc.CurrAccTypeCode != CurrAccType.Personnel)
                {
                    SetError(Resources.Form_Invoice_SalesPersonNotFound);
                    return;
                }

                return;
            }

            if (column == colWorkerCode)
            {
                var acc = efMethods.SelectWorker(input);
                if (acc == null || acc.CurrAccTypeCode != CurrAccType.Personnel)
                {
                    SetError(Resources.Form_Invoice_WorkerNotFound);
                    return;
                }

                return;
            }
        }

        private object GetEmptyValueForColumn(GridColumn column)
        {
            var type = column.ColumnType ?? typeof(string);
            var code = Type.GetTypeCode(type);

            return code switch
            {
                TypeCode.Int16 or TypeCode.Int32 or TypeCode.Int64
                or TypeCode.Decimal or TypeCode.Double or TypeCode.Single
                or TypeCode.Byte => Activator.CreateInstance(type), // default numeric = 0
                _ => null
            };
        }

        private DcProduct ResolveProduct(GridColumn column, string input, out string errorMsg)
        {
            errorMsg = null;
            DcProduct product = null;

            if (column == col_ProductCode)
            {
                product = efMethods.SelectProduct(input, productTypeArr);
            }
            else if (column == colBarcode)
            {
                product = efMethods.SelectProductByBarcode(input);
            }
            else if (column == colSerialNumberCode)
            {
                bool exists = efMethods.EntityExists<DcSerialNumber>(input);
                if (!exists)
                {
                    errorMsg = Resources.Form_Invoice_SerialNumberNotFound;
                    return null;
                }

                product = efMethods.SelectProductBySerialNumber(input);
            }

            if (product == null)
            {
                string entityName = new string[] { "EX", "EI" }.Contains(dcProcess.ProcessCode)
                    ? Resources.Form_Invoice_Expense
                    : Resources.Form_Invoice_Product;

                errorMsg = string.Format(Resources.Form_Invoice_EntityNotFoundOrDisabled, entityName);
                return null;
            }

            return product;
        }

        private bool HasMismatchingProductInReturnLines(TrInvoiceLine tr, string newProductCode)
        {
            string existing = efMethods.SelectReturnLinesByInvoiceLine(tr.InvoiceLineId)
                                       .FirstOrDefault()?.ProductCode;
            return !string.IsNullOrEmpty(existing) && existing != newProductCode;
        }

        private bool HasMismatchingProductInWaybillLines(TrInvoiceLine tr, string newProductCode)
        {
            string existing = efMethods.SelectWaybillByInvoiceLine(tr.InvoiceLineId)
                                       .FirstOrDefault()?.ProductCode;
            return !string.IsNullOrEmpty(existing) && existing != newProductCode;
        }

        private bool HasMismatchingProductInRelatedReturnLine(TrInvoiceLine tr, string newProductCode)
        {
            string existing = efMethods.SelectInvoiceLineByReturnLine(tr.RelatedLineId, tr.TrInvoiceHeader.ProcessCode)
                                       .FirstOrDefault()?.ProductCode;
            return !string.IsNullOrEmpty(existing) && existing != newProductCode;
        }

        private bool HasMismatchingProductInRelatedHandOverLine(TrInvoiceLine tr, string newProductCode)
        {
            string existing = efMethods.SelectInvoiceLinesByLineId(tr.RelatedLineId)
                                       .FirstOrDefault()?.ProductCode;
            return !string.IsNullOrEmpty(existing) && existing != newProductCode;
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

        // Double-click lookup shortcut is disabled for now. Keep this block for future use.
        //BaseEdit editorCustom;
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

            // Double-click lookup shortcut is disabled for now. Keep this block for future use.
            //GridView view = sender as GridView;
            //editorCustom = view.ActiveEditor;
            //editorCustom.DoubleClick += editor_DoubleClick;
        }

        void gV_InvoiceLine_HiddenEditor(object sender, EventArgs e)
        {
            // Double-click lookup shortcut is disabled for now. Keep this block for future use.
            //editorCustom.DoubleClick -= editor_DoubleClick;
            //editorCustom = null;
        }

        private void gV_InvoiceLine_DoubleClick(object sender, EventArgs e)
        {
        }

        // Double-click lookup shortcut is disabled for now. Keep this method for future use.
        //void editor_DoubleClick(object sender, EventArgs e)
        //{
        //    BaseEdit editor = (BaseEdit)sender;
        //    GridControl grid = editor.Parent as GridControl;
        //    GridView view = grid.FocusedView as GridView;
        //    Point pt = grid.PointToClient(Control.MousePosition);
        //    GridHitInfo info = view.CalcHitInfo(pt);
        //    if (info.InRow || info.InRowCell)
        //    {
        //        if (info.Column == col_ProductCode)
        //            SelectProduct(sender);
        //        else if (info.Column == col_SalesPersonCode)
        //            SelectSalesPerson(sender);
        //        else if (info.Column == colWorkerCode)
        //            SelectWorker(sender);
        //    }
        //}

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

            if (Settings.Default.AppSetting?.ProductsFormKeepActive == true)
            {
                ShowProductsFormKeepActive(productCode);
                return;
            }

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

        private void ShowProductsFormKeepActive(string productCode)
        {
            if (productsForm is null || productsForm.IsDisposed)
            {
                productsForm = new FormProductList(productTypeArr, false, productCode);
                productsForm.ProductSelected += ProductsForm_ProductSelected;
                productsForm.FormClosed += ProductsForm_FormClosed;
                productsForm.Show(this);
                return;
            }

            productsForm.FocusProduct(productCode);
            if (productsForm.WindowState == FormWindowState.Minimized)
                productsForm.WindowState = FormWindowState.Normal;

            productsForm.Activate();
            productsForm.BringToFront();
        }

        private void ProductsForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (ReferenceEquals(sender, productsForm))
                productsForm = null;
        }

        private void ProductsForm_ProductSelected(object? sender, EventArgs e)
        {
            if (sender is FormProductList form)
                ApplySelectedProduct(form.dcProduct?.ProductCode);
        }

        private bool ApplySelectedProduct(string? productCode)
        {
            if (string.IsNullOrWhiteSpace(productCode))
                return false;

            gC_InvoiceLine.Focus();
            gV_InvoiceLine.FocusedColumn = col_ProductCode;
            gV_InvoiceLine.ShowEditor();

            if (gV_InvoiceLine.ActiveEditor is BaseEdit editor)
            {
                editor.EditValue = productCode;

                if (!gV_InvoiceLine.PostEditor())
                    return false;
            }
            else
            {
                gV_InvoiceLine.SetFocusedRowCellValue(col_ProductCode, productCode);
            }

            gV_InvoiceLine.FocusedColumn = colQty;
            gV_InvoiceLine.ShowEditor();

            return true;
        }

        private void gV_InvoiceLine_RowUpdated(object sender, RowObjectEventArgs e)
        {
            if (Settings.Default.AppSetting.AutoSave)
                SaveInvoice();

            UpdateInstallmentLabels();
        }

        private void gV_InvoiceLine_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {

        }

        private void gV_InvoiceLine_RowDeleted(object sender, RowDeletedEventArgs e)
        {
            if (Settings.Default.AppSetting.AutoSave)
                SaveInvoice();

            UpdateInstallmentLabels();
        }

        private void gV_InvoiceLine_RowDeleting(object sender, RowDeletingEventArgs e)
        {
            if (!EnsureInvoiceCanBeChanged())
            {
                e.Cancel = true;
                return;
            }

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

        private bool SaveInvoice()
        {
            if (trInvoiceHeader is null)
                return false;

            if (!EnsureInvoiceCanBeChanged())
                return false;

            if (!_lockService.IsLockOwnedByMe("Invoice", trInvoiceHeader.InvoiceHeaderId,
                Authorization.CurrAccCode, _appInstanceId, _formInstanceId))
            {
                XtraMessageBox.Show("Sənəd artıq sizin deyil...");
                Close();
                return false;
            }

            if (new[] { "IT" }.Contains(trInvoiceHeader.ProcessCode))
            {
                if (Settings.Default.AppSetting.TransferAutoApprove)
                    trInvoiceHeader.TransferApprovalStatus = TransferApprovalStatus.AutoApproved;
                else
                    trInvoiceHeader.TransferApprovalStatus = TransferApprovalStatus.Pending;
            }

            if (IsInstallmentProcess())
                EnsureInstallment();

            dbContext.SaveChanges(false, Authorization.CurrAccCode);
            _isSaved = true;

            if (new[] { "IT" }.Contains(trInvoiceHeader.ProcessCode)
                && Settings.Default.AppSetting.TransferAutoApprove)
                InitilizeTransfer();

            dbContext.ChangeTracker.AcceptAllChanges();

            if (new[] { "EX", "EI" }.Contains(trInvoiceHeader.ProcessCode))
            {
                _paymentService.RebuildPaymentsFromInvoice(trInvoiceHeader, trInvoiceHeader.CashRegisterCode);

                UpdatePaidLabels();
            }

            var result = _loyaltyService.SyncInvoiceEarn(trInvoiceHeader);
            txt_LoyaltyEarn.EditValue = result.EarnAmount;

            if (IsInstallmentProcess())
            {
                EnsureInstallment();
                SaveInstallmentGarantors();
                UpdateInstallmentLabels();
            }

            // Send WhatsApp product purchase message for IS process
            if (new[] { "IS" }.Contains(trInvoiceHeader.ProcessCode) && !string.IsNullOrEmpty(trInvoiceHeader.CurrAccCode))
            {
                string currAccCode = trInvoiceHeader.CurrAccCode;
                List<string> phoneNums = efMethods.SelectCurrAccWhatsappRecipients(currAccCode);

                if (phoneNums.Count > 0)
                {
                    _ = Task.Run(async () =>
                    {
                        var messagingService = new AppCode.Service.MessagingService();

                        foreach (string phoneNum in phoneNums)
                        {
                            try
                            {
                                await messagingService.SendProductPurchaseMessageAsync(currAccCode, phoneNum);
                            }
                            catch (Exception ex) { System.Diagnostics.Debug.Print($"ProductPurchase message error: {ex.Message}"); }
                        }
                    });
                }
            }

            SaveSession();
            Tag = btnEdit_DocNum.EditValue;

            if (IsCampaignEnabled && !_isApplyingCampaign)
            {
                RecalcCampaignsIfNeeded();
                AutoApplyCampaignsIfConfigured();
            }

            return true;
        }


        Guid quidHead;
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

                var newWarehouseCode = trIH.ToWarehouseCode ?? trIH.WarehouseCode; // fallback
                var newToWarehouseCode = trIH.WarehouseCode ?? trIH.ToWarehouseCode;

                TrInvoiceHeader copyTrIH = trIH;
                copyTrIH.InvoiceHeaderId = quidHead;
                copyTrIH.WarehouseCode = newWarehouseCode;
                copyTrIH.ToWarehouseCode = newToWarehouseCode;
                copyTrIH.StoreCode = trIH.CurrAccCode ??= trIH.StoreCode;
                copyTrIH.IsMainTF = false;


                context2.Entry(copyTrIH).State = entryHeader.State;

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

                context2.Entry(newTrIL).State = entryLine.State;

                context2.SaveChanges(Authorization.CurrAccCode);
            }
        }

        readonly DateTime DefaultSqlDate = new DateTime(1901, 1, 1);

        DateTime FixSqlDate(DateTime dt)
        {
            // MinValue və ya SQL datetime limitindən kiçikdirsə default ver
            return (dt < new DateTime(1753, 1, 1)) ? DefaultSqlDate : dt;
        }

        private void SaveInstallmentGarantors()
        {
            if (dbContext2 is null)
                return;

            TrInstallment installment = EnsureInstallment();
            if (installment.InstallmentId <= 0)
                return;

            var trInstallmentGuarantors = trInstallmentGuarantorsBindingSource.DataSource as BindingList<TrInstallmentGuarantor>;

            if (trInstallmentGuarantors != null)
            {
                foreach (var garantor in trInstallmentGuarantors)
                    if (garantor.InstallmentId == 0)
                        garantor.InstallmentId = installment.InstallmentId;
            }

            dbContext2.SaveChanges();
        }

        private void bBI_SaveAndNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                if (SaveInvoice())
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

        private void bBI_New_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!PromptSaveChanges())
                return;

            ClearControlsAddNew();
        }

        private void bBI_reportPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!EnsureInvoiceSaved())
                return;

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
                SaveInvoice();
            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }
        }

        private void bBI_Payment_ItemClick(object sender, ItemClickEventArgs e)
            => bBI_Payment_ItemClick_WithCampaign(sender, e);

        private PaymentType ResolvePaymentTypeByAllowedMethods(IEnumerable<int>? allowedPaymentMethodIds, PaymentType defaultPaymentType)
        {
            List<int> paymentMethodIds = allowedPaymentMethodIds?
                .Distinct()
                .ToList() ?? new List<int>();

            if (!paymentMethodIds.Any())
                return defaultPaymentType;

            List<PaymentType> paymentTypes = efMethods.SelectEntities<DcPaymentMethod>()
                .Where(x => paymentMethodIds.Contains(x.PaymentMethodId))
                .Select(x => x.PaymentTypeCode)
                .Distinct()
                .ToList();

            if (paymentTypes.Count == 1)
                return paymentTypes.First();

            return defaultPaymentType;
        }

        private void bBI_DeleteInvoice_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!efMethods.EntityExists<TrInvoiceHeader>(trInvoiceHeader.InvoiceHeaderId))
            {
                XtraMessageBox.Show(Resources.Form_Invoice_NoInvoiceToDelete);
                return;
            }

            if (!EnsureInvoiceCanBeChanged())
                return;

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
                bool currAccHasDeletePayClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "DeletePayment");
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
                        if (currAccHasDeletePayClaims)
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
            => bBI_PaymentDelete_ItemClick_WithCampaign(sender, e);


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
                SaveInvoice();
                Close();
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
            List<string> phoneNums = efMethods.SelectCurrAccWhatsappRecipients(trInvoiceHeader.CurrAccCode);
            if (phoneNums.Count == 0)
            {
                MessageBox.Show(Resources.Form_Invoice_Whatsapp_NumberNotEntered);
                return;
            }

            MemoryStream memoryStream = GetInvoiceReportImg();

            if (Settings.Default.AppSetting.WhatsAppProvider == WhatsAppProvider.API)
            {
                foreach (string phoneNum in phoneNums)
                    await SendWhatsAppViaEvolutionApi(phoneNum, memoryStream, trInvoiceHeader.DocumentNumber);
            }
            else
            {
                if (memoryStream.CanSeek) memoryStream.Position = 0;
                Clipboard.SetImage(Image.FromStream(memoryStream));

                foreach (string phoneNum in phoneNums)
                    SendWhatsApp(phoneNum, $"Faktura No: {trInvoiceHeader.DocumentNumber}");
            }
        }

        private async Task SendWhatsAppViaEvolutionApi(string number, MemoryStream memoryStream, string documentNumber = null)
        {
            if (string.IsNullOrEmpty(number))
            {
                MessageBox.Show(Resources.Form_Invoice_Whatsapp_NumberNotEntered);
                return;
            }

            var apiSetting = efMethods.SelectEntityById<DcWhatsAppProviderSetting>(1);
            if (apiSetting == null || string.IsNullOrEmpty(apiSetting.ServerUrl) || string.IsNullOrEmpty(apiSetting.InstanceName) || string.IsNullOrEmpty(apiSetting.ApiKey))
            {
                XtraMessageBox.Show(Resources.Payment_ApiSettingsIncomplete);
                return;
            }

            string formattedNumber = number.Trim().Replace("+", "").Replace(" ", "");
            string caption = string.IsNullOrEmpty(documentNumber)
                ? Resources.FormInvoice_WhatsAppCaptionDefault
                : string.Format(Resources.FormInvoice_WhatsAppCaption, documentNumber);

            if (!WhatsAppCreditService.HasEnoughBalance())
            {
                SaveWhatsAppLog(trInvoiceHeader.InvoiceHeaderId, formattedNumber, memoryStream, caption, isSuccessful: false);
                XtraMessageBox.Show(Resources.Common_InsufficientBalance);
                return;
            }

            try
            {
                using var client = new Foxoft.AppCode.EvolutionApiClient(apiSetting.ServerUrl, apiSetting.InstanceName, apiSetting.ApiKey);

                string response = await client.SendImageBase64Async(formattedNumber, memoryStream, caption: caption);
                
                SaveWhatsAppLog(trInvoiceHeader.InvoiceHeaderId, formattedNumber, memoryStream, caption, isSuccessful: true);

                alertControl1.Show(this, Resources.FormInvoice_WhatsappSend, Resources.Common_SentSuccessfully, "", (Image)null, null);
            }
            catch (Exception ex)
            {
                SaveWhatsAppLog(trInvoiceHeader.InvoiceHeaderId, formattedNumber, memoryStream, caption, isSuccessful: false);
                XtraMessageBox.Show(Properties.Resources.Common_ErrorOccurred + " " + ex.Message);
            }
        }

        private void SaveWhatsAppLog(Guid documentHeaderId, string receiverPhone, MemoryStream? imageStream = null,
            string? message = null, bool isSuccessful = false)
        {
            try
            {
                string? imageFilePath = null;

                if (imageStream != null && imageStream.Length > 0)
                {
                    imageFilePath = SaveWhatsAppImageToDisk(imageStream);
                }

                using var ctx = new subContext();

                ctx.TrWhatsAppMessageLogs.Add(new TrWhatsAppMessageLog
                {
                    WhatsAppMessageLogId = Guid.NewGuid(),
                    DocumentHeaderId = documentHeaderId,
                    ReceiverPhoneNumber = receiverPhone,
                    MessageType = dcProcess?.ProcessDesc,
                    Message = message,
                    Sender = Authorization.CurrAccCode,
                    CurrAccCode = trInvoiceHeader?.CurrAccCode,
                    ImageFilePath = imageFilePath,
                    IsSuccessful = isSuccessful
                });

                if (isSuccessful)
                    ctx.TrCredits.Add(WhatsAppCreditService.CreateUsage(dcProcess?.ProcessDesc, receiverPhone));

                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.Print($"WhatsApp log save error: {ex.Message}");
            }
        }
                 
        private string? SaveWhatsAppImageToDisk(MemoryStream imageStream) 
        {
            try
            {
                string whatsAppFolder = CustomExtensions.CombinePath(settingStore?.ImageFolder, "WhatsApp");
                if (string.IsNullOrWhiteSpace(whatsAppFolder))
                    return null;

                if (!Directory.Exists(whatsAppFolder))
                    Directory.CreateDirectory(whatsAppFolder);

                string fileName = $"{Guid.NewGuid()}.png";
                string filePath = Path.Combine(whatsAppFolder, fileName); 

                if (imageStream.CanSeek) imageStream.Position = 0;
                File.WriteAllBytes(filePath, imageStream.ToArray());

                return filePath;
            }
            catch (Exception ex)
            {
                Debug.Print($"WhatsApp Image save error: {ex.Message}");
                return null;
            }
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

        private string _CurrAccCodeOldValue;
        private void btnEdit_CurrAccCode_EditValueChanging(object sender, ChangingEventArgs e)
        {
            DcCurrAcc? curr = efMethods.SelectEntityById<DcCurrAcc>(e.OldValue?.ToString());
            if (curr is null) return;
            _CurrAccCodeOldValue = curr.CurrAccCode;
        }

        private void btnEdit_CurrAccCode_EditValueChanged(object sender, EventArgs e)
        {
            if (trInvoiceHeader is null) return;

            DcCurrAcc? curr = efMethods.SelectEntityById<DcCurrAcc>(btnEdit_CurrAccCode.EditValue?.ToString());
            if (curr is null) return;

            // Əgər həqiqətən dəyişməyibsə boşuna iş görmə
            if (string.Equals(_CurrAccCodeOldValue, curr.CurrAccCode, StringComparison.OrdinalIgnoreCase))
                return;

            trInvoiceHeader.CurrAccCode = curr.CurrAccCode;
            lbl_CurrAccDesc.Text = $"{curr.CurrAccDesc} {curr.FirstName} {curr.LastName}";

            CurrAccBalanceBefore = Math.Round(
                efMethods.SelectCurrAccBalance(trInvoiceHeader.CurrAccCode,
                    trInvoiceHeader.DocumentDate.Add(trInvoiceHeader.OperationTime)), 2);

            if (Settings.Default.AppSetting.AutoSave)
                efMethods.UpdatePaymentsCurrAccCode(trInvoiceHeader.InvoiceHeaderId, curr.CurrAccCode);

            List<DcWarehouse> dcWarehouses = efMethods.SelectWarehousesByStoreIncludeDisabled(trInvoiceHeader.CurrAccCode);
            lUE_ToWarehouseCode.Properties.DataSource = dcWarehouses;

            if (!dcWarehouses.Any(x => x.WarehouseCode == trInvoiceHeader?.ToWarehouseCode))
                trInvoiceHeader.ToWarehouseCode = null;

            if (dcWarehouses is not null)
            {
                DcWarehouse dcWarehouse = dcWarehouses.FirstOrDefault(x => x.IsDefault == true);

                if (dcWarehouse is not null && trInvoiceHeader?.ToWarehouseCode is null)
                {
                    trInvoiceHeader.ToWarehouseCode = dcWarehouse.WarehouseCode;
                    //lUE_ToWarehouseCode.EditValue = dcWarehouse.WarehouseCode;
                }
            }

            // Kart varsa və yeni CurrAccCode kartın CurrAccCode-u ilə fərqlidirsə -> kartı ləğv et
            if (trInvoiceHeader.LoyaltyCardId is Guid cardId && _CurrAccCodeOldValue is not null)
            {
                DcLoyaltyCard? card = efMethods.SelectEntityById<DcLoyaltyCard>(cardId);

                if (card != null && !string.Equals(curr.CurrAccCode, card.CurrAccCode, StringComparison.OrdinalIgnoreCase))
                {
                    var result = _loyaltyService.DetachCard(trInvoiceHeader);

                    if (!result.Success)
                    {
                        XtraMessageBox.Show(result.Message);
                        return;
                    }

                    txt_LoyaltyEarn.EditValue = 0m;
                    XtraMessageBox.Show(result.Message);
                    return;
                }
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

            if (trInvoiceHeader.ProcessCode == "IT")
            {
                DcCurrAcc store = efMethods.SelectStoreIsDisabled(value);

                if (store is not null)
                {
                    SetValidationError(editor, e, "Mağaza deaktivdir");
                    return;
                }

                store = efMethods.SelectStore(value);

                if (store is null)
                {
                    SetValidationError(editor, e, Resources.Form_Invoice_NoSuchCurrAcc);
                    return;
                }
            }
            else
            {
                DcCurrAcc curr = efMethods.SelectCurrAccIsDisabled(value);

                if (curr is not null)
                {
                    SetValidationError(editor, e, "Cari hesab deaktivdir");
                    return;
                }

                curr = efMethods.SelectCurrAcc(value);

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

                bool hasBonusPayment = efMethods.BonusPaymentExist(trInvoiceHeader.InvoiceHeaderId);

                if (hasBonusPayment)
                {
                    SetValidationError(editor, e, Resources.Form_Invoice_BonusPaymentExists_CannotChangeCurrAccCode);
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
                if (!EnsureInvoiceCanBeChanged())
                    return;

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

            RPG_Campaign.Visible = IsCampaignEnabled;
            if (colDiscountCampaign != null) colDiscountCampaign.Visible = IsCampaignEnabled;
            if (colDiscountCampaignLoc != null) colDiscountCampaignLoc.Visible = IsCampaignEnabled;

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

                    if (dcProcess.ProcessCode == "EX")
                        ItemForDeliveryDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
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

                bool canChangeInstallmentCommission = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "InstallmentCommissionChange");
                txtEdit_Installment_Commission.ReadOnly = !canChangeInstallmentCommission;
            }

            string layoutHeaderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Foxoft", Settings.Default.CompanyCode, "Layout Xml Files", "InvoiceHeader" + dcProcess.ProcessCode + "Layout.xml");

            if (File.Exists(layoutHeaderPath))
                dataLayoutControl1.RestoreLayoutFromXml(layoutHeaderPath);

            string layoutLineFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Foxoft", Settings.Default.CompanyCode, "Layout Xml Files", "InvoiceLine" + dcProcess.ProcessCode + "Layout.xml");

            if (File.Exists(layoutLineFilePath))
                gV_InvoiceLine.RestoreLayoutFromXml(layoutLineFilePath);

            bool currAccHasClaimsExpences = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "ExpenseOfInvoice");
            if (!currAccHasClaimsExpences)
                BBI_InvoiceExpenses.Visibility = BarItemVisibility.Never;

            bool currAccHasMakePayClaim = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "MakePayment");
            bool currAccHasReceivePayClaim = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "ReceivePayment");
            if (currAccHasMakePayClaim || currAccHasReceivePayClaim)
                bBI_Payment.Visibility = BarItemVisibility.Always;

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

            if (colExchangeRate != null)
            {
                bool canChangeExchangeRate = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "ChangeExchangeRate");
                colExchangeRate.OptionsColumn.ReadOnly = !canChangeExchangeRate;
            }


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
                    menu.Items.Add(CreateItem(Resources.Common_SaveLayout, menu.Column, null));

                if (menu.Column == col_SalesPersonCode)
                {
                    string columnName = ReflectionExt.GetDisplayName<SettingStore>(x => x.SalesmanContinuity);
                    menu.Items.Add(CreateCheckItem(columnName, menu.Column, null));
                }
            }
            else if (e.MenuType == GridMenuType.Row)
            {
                DevExpress.Utils.Menu.DXMenuItem itemFeature = new DevExpress.Utils.Menu.DXMenuItem(Resources.Entity_InvoiceLineFeature, new EventHandler(DXMenuItem_Features_Click), null);
                e.Menu.Items.Add(itemFeature);
            }
        }

        private void DXMenuItem_Features_Click(object sender, EventArgs e)
        {
            if (gV_InvoiceLine.GetFocusedRowCellValue(col_InvoiceLineId) is Guid invoiceLineId && invoiceLineId != Guid.Empty)
            {
                // Ensure the row is saved to database if possible
                if (dbContext.ChangeTracker.HasChanges())
                    dbContext.SaveChanges(false, Authorization.CurrAccCode);

                FormInvoiceLineFeature frm = new(invoiceLineId);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show(Resources.Message_NoRowSelected);
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
            string captionBarcode = ReflectionExt.GetDisplayName<TrInvoiceLine>(x => x.Barcode);
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
                            gV_InvoiceLine.SetRowCellValue(GridControl.NewItemRowHandle, col_ProductCode, product.ProductCode);

                            gV_InvoiceLine.SetRowCellValue(GridControl.NewItemRowHandle, colBarcode, barcode);
                        }
                        else if (column.ColumnName == captionQty)
                        {
                            gV_InvoiceLine.SetFocusedRowCellValue(colQty, Cell(row, captionQty));
                        }
                        else if (column.ColumnName == captionLineDesc)
                            gV_InvoiceLine.SetFocusedRowCellValue(col_LineDesc, Cell(row, captionLineDesc));

                        else if (column.ColumnName == captionSerialNumber)
                            gV_InvoiceLine.SetFocusedRowCellValue(colSerialNumberCode, Cell(row, captionSerialNumber));

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
                MessageBox.Show(Properties.Resources.Invoice_NoValueFoundForCodes + "\n" + errorCodes, Properties.Resources.Common_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (new string[] { "EX", "EI", "CN" }.Contains(dcProcess.ProcessCode))
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
            if (trInvoiceHeader is null)
                return;

            string storeCode = lUE_StoreCode.EditValue?.ToString();

            if (string.IsNullOrWhiteSpace(storeCode))
                return;

            trInvoiceHeader.StoreCode = storeCode;

            ApplyExpenseDefaultCashRegisterByStore(storeCode);

            List<DcWarehouse> dcWarehouses = efMethods.SelectWarehousesByStoreIncludeDisabled(storeCode);
            lUE_WarehouseCode.Properties.DataSource = dcWarehouses;

            string currentWarehouseCode = trInvoiceHeader.WarehouseCode;

            if (!string.IsNullOrWhiteSpace(currentWarehouseCode)
                && dcWarehouses.Any(x => x.WarehouseCode == currentWarehouseCode))
            {
                lUE_WarehouseCode.EditValue = currentWarehouseCode;
                return;
            }

            DcWarehouse defaultWarehouse = dcWarehouses.FirstOrDefault(x => x.IsDefault);

            if (defaultWarehouse is not null)
            {
                trInvoiceHeader.WarehouseCode = defaultWarehouse.WarehouseCode;
                //lUE_WarehouseCode.EditValue = defaultWarehouse.WarehouseCode;
            }
        }

        private void lUE_WarehouseCode_EditValueChanged(object sender, EventArgs e)
        {
            //if (trInvoiceHeader is not null)
            //    trInvoiceHeader.WarehouseCode = lUE_WarehouseCode.EditValue?.ToString();
        }

        private void lUE_ToWarehouseCode_EditValueChanged(object sender, EventArgs e)
        {
            //if (trInvoiceHeader is not null)
            //    trInvoiceHeader.ToWarehouseCode = lUE_ToWarehouseCode.EditValue?.ToString();
        }

        private async void BBI_ReportPrintFast_ItemClick(object sender, ItemClickEventArgs e)
        {
            await PrintFast(dcTerminal.PrinterName);
        }

        private async Task PrintFast(string printerName)
        {
            alertControl1.Show(this, "Print Göndərilir...", "Printer: " + printerName, "", (Image)null, null);

            if (trInvoiceHeader is not null)
                await Task.Run(() => GetPrint(trInvoiceHeader.InvoiceHeaderId, printerName));
            else MessageBox.Show("Çap olunmaq üçün qaimə yoxdur");

            if (this.IsHandleCreated)
                this.BeginInvoke(new Action(ShowPrintCount));

            alertControl1.Show(this, "Print Göndərildi.", printerName, "", (Image)null, null);
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
            dcTerminal.PrinterName = comboBox.EditValue.ToString();
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

            XtraMessageBox.Show(createdUserName + "\n\n" + createdDate + "\n\n" + updatedUserName + "\n\n" + updatedDate, Properties.Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BBI_picture_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "ExpenseOfInvoice");
            if (!currAccHasClaims)
            {
                MessageBox.Show(Properties.Resources.Report_NoPermission);
                return;
            }

            FormImage formPictures = new(btnEdit_DocNum.EditValue?.ToString());
            formPictures.ShowDialog();
        }

        private async void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e)
        {

        }

        private void gV_InvoiceLine_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName.StartsWith("Feature_"))
            {
                if (e.Column.Tag == null) return;
                int featureTypeId = Convert.ToInt32(e.Column.Tag);
                int rowHnd = gV_InvoiceLine.GetRowHandle(e.ListSourceRowIndex);
                TrInvoiceLine rowLine = gV_InvoiceLine.GetRow(rowHnd) as TrInvoiceLine;

                if (rowLine == null) return;

                if (e.IsGetData)
                {
                    var feature = rowLine.TrInvoiceLineFeatures?.FirstOrDefault(x => x.InvoiceLineFeatureTypeId == featureTypeId);
                    e.Value = feature?.InvoiceLineFeatureCode;
                }
                else if (e.IsSetData)
                {
                    string newVal = e.Value?.ToString()?.Trim();
                    var existingFeature = rowLine.TrInvoiceLineFeatures?.FirstOrDefault(x => x.InvoiceLineFeatureTypeId == featureTypeId);

                    if (existingFeature != null)
                    {
                        if (existingFeature.InvoiceLineFeatureCode != newVal)
                        {
                            if (dbContext.Entry(existingFeature).State != EntityState.Detached)
                                dbContext.TrInvoiceLineFeatures.Remove(existingFeature);
                            
                            rowLine.TrInvoiceLineFeatures.Remove(existingFeature);
                        }
                        else
                        {
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(newVal))
                    {
                        var newFeature = new TrInvoiceLineFeature()
                        {
                            InvoiceLineId = rowLine.InvoiceLineId,
                            InvoiceLineFeatureTypeId = featureTypeId,
                            InvoiceLineFeatureCode = newVal
                        };

                        if (rowLine.TrInvoiceLineFeatures == null)
                            rowLine.TrInvoiceLineFeatures = new List<TrInvoiceLineFeature>();

                        rowLine.TrInvoiceLineFeatures.Add(newFeature);
                        dbContext.TrInvoiceLineFeatures.Add(newFeature);
                    }
                }
                return;
            }

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
            FormInvoice formInvoice = new("EI", null, new byte[] { 2, 3 }, trInvoiceHeader.InvoiceHeaderId, true);
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

        private void LCG_InfoPayment_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            DateTime utcNow = DateTime.UtcNow;
            if (utcNow - _lastInfoPaymentPopupAt < TimeSpan.FromMilliseconds(150)) return;

            _lastInfoPaymentPopupAt = utcNow;
            popupMenuInfoPayment.ShowPopup(Cursor.Position);
        }

        private void bBI_OpenPayments_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (trInvoiceHeader is null || trInvoiceHeader.InvoiceHeaderId == Guid.Empty) return;

            using FormPaymentHeaderList formPaymentHeaderList = new(trInvoiceHeader.InvoiceHeaderId);

            if (formPaymentHeaderList.ShowDialog(this) != DialogResult.OK) return;
            if (formPaymentHeaderList.trPaymentHeader is null) return;

            OpenPaymentDetail(formPaymentHeaderList.trPaymentHeader.PaymentHeaderId);
        }

        private void OpenPaymentDetail(Guid paymentHeaderId)
        {
            FormPaymentDetail formPaymentDetail = new(paymentHeaderId);
            FormERP formERP = Application.OpenForms[nameof(FormERP)] as FormERP;

            if (formERP is null)
            {
                formPaymentDetail.Show(this);
                return;
            }

            formPaymentDetail.MdiParent = formERP;
            formPaymentDetail.WindowState = FormWindowState.Maximized;
            formPaymentDetail.Show();

            if (formERP.parentRibbonControl.MergedPages.Count > 0)
                formERP.parentRibbonControl.SelectedPage = formERP.parentRibbonControl.MergedPages[0];
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
            if (!EnsureInvoiceCanBeChanged())
                e.Cancel = true;
        }

        private void gV_InvoiceLine_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
        }

        private void repoBtnEdit_InstallmentGarantorDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (!EnsureInvoiceCanBeChanged())
                return;

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
            if (!EnsureInvoiceCanBeChanged())
                return;

            TrInstallment installment = EnsureInstallment();
            if (dbContext2 is null)
                LoadInstallmentGarantors();

            FormCurrAccList form = new(new byte[] { 1, 2, 3 }, false);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                var trInstallmentGuarantors = trInstallmentGuarantorsBindingSource.DataSource as BindingList<TrInstallmentGuarantor>;
                bool guarantorAlreadyAdded = trInstallmentGuarantors?.Any(x => x.CurrAccCode == form.dcCurrAcc.CurrAccCode) == true;

                if (guarantorAlreadyAdded)
                {
                    XtraMessageBox.Show(
                        Resources.Form_Invoice_GuarantorAlreadyAdded,
                        Resources.Common_Attention,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                var newGuarantor = new TrInstallmentGuarantor
                {
                    CurrAccCode = form.dcCurrAcc.CurrAccCode,
                    DcCurrAcc = form.dcCurrAcc,
                    InstallmentId = installment.InstallmentId
                };

                var existingEntity = dbContext2.ChangeTracker.Entries<DcCurrAcc>()
                    .FirstOrDefault(en => en.Entity.CurrAccCode == form.dcCurrAcc.CurrAccCode);

                if (existingEntity != null)
                    newGuarantor.DcCurrAcc = existingEntity.Entity;
                else
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

            int installmentId = EnsureInstallment().InstallmentId;

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
            if (!IsInstallmentProcess()) return;

            ApplySelectedInstallmentPlan(EnsureInstallment());
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
                        UpdateInstallmentLabels();
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
                    salesPersonCode = form.dcCurrAcc.CurrAccCode;

                    for (int i = 0; i < gV_InvoiceLine.DataRowCount; i++)
                        gV_InvoiceLine.SetRowCellValue(i, col_SalesPersonCode, salesPersonCode);
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

            using (FormCashRegisterList form = new(editor.EditValue?.ToString(), storeCode, GetInvoiceCashRegPaymentTypeFilter()))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    editor.EditValue = form.dcCurrAcc.CurrAccCode;
                }
            }
        }

        private void Btn_CashRegCode_EditValueChanged(object sender, EventArgs e)
        {
            DcCurrAcc curr = efMethods.SelectCashReg(btn_CashRegCode.EditValue?.ToString(), GetInvoiceCashRegPaymentTypeFilter());
            if (trInvoiceHeader is null || curr is null)
                return;

            trInvoiceHeader.CashRegisterCode = curr.CurrAccCode;

            if (new string[] { "EX", "EI" }.Contains(dcProcess.ProcessCode)
                    && dbContext != null
                    && dataLayoutControl1.IsValid(out _)
                    && gV_InvoiceLine.DataRowCount > 0)
            {
                _paymentService.RebuildPaymentsFromInvoice(
                    trInvoiceHeader,
                    trInvoiceHeader.CashRegisterCode);

                UpdatePaidLabels();
            }
        }

        private void Btn_CashRegCode_Validating(object sender, CancelEventArgs e)
        {
            if (sender is not ButtonEdit editor)
                return;

            dxErrorProvider1.SetError(editor, string.Empty);

            string value = editor.Text?.Trim();

            if (string.IsNullOrEmpty(value))
                return;

            DcCurrAcc curr = efMethods.SelectCashReg(value, GetInvoiceCashRegPaymentTypeFilter());

            if (curr is null)
            {
                SetValidationError(editor, e, Resources.Form_Invoice_NoCashReg);
                return;
            }

            trInvoiceHeader.CashRegisterCode = curr.CurrAccCode;

            dxErrorProvider1.SetError(editor, string.Empty);
        }

        private void ApplyExpenseDefaultCashRegisterByStore(string storeCode)
        {
            if (dcProcess?.ProcessCode != "EX" || trInvoiceHeader is null || string.IsNullOrWhiteSpace(storeCode))
                return;

            trInvoiceHeader.CashRegisterCode = efMethods.SelectDefaultCashRegister(storeCode, GetInvoiceCashRegPaymentTypeFilter());
            btn_CashRegCode.EditValue = trInvoiceHeader.CashRegisterCode;
        }

        private PaymentType? GetInvoiceCashRegPaymentTypeFilter()
        {
            return dcProcess?.ProcessCode == "EX" ? null : PaymentType.Cash;
        }

        private void Btn_CashRegCode_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
        }

        private void BBI_LoyaltyCardInput_ItemClick(object sender, ItemClickEventArgs e)
        {
            var result = XtraInputBox.Show("Bonus Kart Daxil Edin:", "Bonus Kart", "");

            if (result == null)
                return;

            string bonusCardNum = result.ToString().Trim();

            if (string.IsNullOrWhiteSpace(bonusCardNum))
            {
                _loyaltyService.DetachCard(trInvoiceHeader);
                txt_LoyaltyEarn.EditValue = 0m;
                XtraMessageBox.Show(Properties.Resources.BonusCard_Cancelled, Properties.Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var card = efMethods.SelectLoyalityCard(bonusCardNum);
            if (card is null)
            {
                XtraMessageBox.Show(Properties.Resources.BonusCard_NotFound, Properties.Resources.Common_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _loyaltyService.AttachCard(trInvoiceHeader, card);
            btnEdit_CurrAccCode.EditValue = card.CurrAccCode;

            SaveInvoice();
        }

        private bool TryActivateOpenInvoiceWindow(Guid invoiceHeaderId)
        {
            if (MdiParent == null)
                return false;

            foreach (Form child in MdiParent.MdiChildren)
            {
                if (child is FormInvoice frm &&
                    frm.trInvoiceHeader.InvoiceHeaderId == invoiceHeaderId)
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                        frm.WindowState = FormWindowState.Normal;

                    frm.BringToFront();
                    frm.Activate();
                    return true;
                }
            }

            return false;
        }

        private System.Windows.Forms.Timer? _lockHeartbeatTimer;
        private bool _isClosingByLockEvent;
        private bool _closeRequestDialogOpen;

        private bool TryAcquireInvoiceLockForEdit(Guid invoiceHeaderId)
        {
            var res = _lockService.TryAcquireLock(
                documentType: "Invoice",
                documentId: invoiceHeaderId,
                userId: Authorization.CurrAccCode,
                machineName: Environment.MachineName,
                appInstanceId: _appInstanceId,
                formInstanceId: _formInstanceId,
                clientProcessId: _pid,
                timeout: TimeSpan.FromMinutes(10),
                reason: "Edit invoice");

            if (!res.Acquired)
            {
                if (res.LockedBy == Authorization.CurrAccCode &&
                    res.AppInstanceId == _appInstanceId)
                {
                    if (TryActivateOpenInvoiceWindow(invoiceHeaderId))
                        return false;
                }

                bool canTakeover = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "DocumentLockTakeover");

                if (canTakeover)
                {
                    var answer = XtraMessageBox.Show(
                        string.Format(Properties.Resources.Form_Invoice_LockTakeoverQuestion, res.LockedByName),
                        Properties.Resources.Form_Invoice_LockTakeoverCaption,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (answer == DialogResult.Yes)
                    {
                        var takeoverRes = _lockService.ForceTakeoverLock(
                            documentType: "Invoice",
                            documentId: invoiceHeaderId,
                            newUserId: Authorization.CurrAccCode,
                            machineName: Environment.MachineName,
                            appInstanceId: _appInstanceId,
                            formInstanceId: _formInstanceId,
                            clientProcessId: _pid,
                            reason: "Force takeover by authorized user");

                        if (takeoverRes.Acquired)
                        {
                            StartLockHeartbeat();
                            return true;
                        }
                    }

                    return false;
                }

                var closeAnswer = XtraMessageBox.Show(
                    $"Faktura hazırda {res.LockedByName} tərəfindən redaktə olunur.\n" +
                    $"Machine: {res.MachineName}\n" +
                    $"LockedAt: {res.LockedAtUtc:yyyy-MM-dd HH:mm:ss} (UTC)\n" +
                    $"Heartbeat: {res.LastHeartbeatAtUtc:yyyy-MM-dd HH:mm:ss} (UTC)\n\n" +
                    $"Sənəd sahibinə bağlama sorğusu göndərilsin?",
                    "Sənəd lock olunub",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (closeAnswer == DialogResult.Yes)
                {
                    _lockService.RequestOwnerToClose(
                        documentType: "Invoice",
                        documentId: invoiceHeaderId,
                        requestedByUserId: Authorization.CurrAccCode,
                        note: "Another user wants to edit this invoice.");
                }

                return false;
            }

            StartLockHeartbeat();
            return true;
        }

        private void StartLockHeartbeat()
        {
            _lockHeartbeatTimer?.Stop();
            _lockHeartbeatTimer?.Dispose();

            _lockHeartbeatTimer = new System.Windows.Forms.Timer { Interval = 30_000 };
            _lockHeartbeatTimer.Tick += (_, __) =>
            {
                try
                {
                    var chk = _lockService.RefreshLockHeartbeatAndCheckSignals(
                        "Invoice",
                        trInvoiceHeader.InvoiceHeaderId,
                        Authorization.CurrAccCode,
                        _appInstanceId,
                        _formInstanceId);

                    if (chk.Reason == LockCloseReason.None)
                        return;

                    BeginInvoke(new Action(() =>
                    {
                        if (chk.Reason == LockCloseReason.CLOSE_REQUESTED)
                        {
                            if (_closeRequestDialogOpen)
                                return;

                            _closeRequestDialogOpen = true;
                            try
                            {
                                var result = XtraMessageBox.Show(
                                    $"İstifadəçi: {chk.RequestedByUserName}\n" +
                                    $"Qeyd: {chk.Note}\n\n" +
                                    $"Bu sənədi bağlamağa razısınız?",
                                    "Bağlama sorğusu",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);

                                if (result == DialogResult.Yes)
                                {
                                    _isClosingByLockEvent = true;
                                    Close();
                                }
                                else
                                {
                                    _lockService.ClearOwnerCloseRequest(
                                        "Invoice",
                                        trInvoiceHeader.InvoiceHeaderId,
                                        Authorization.CurrAccCode,
                                        _appInstanceId,
                                        _formInstanceId,
                                        "Owner rejected close request.");
                                }
                            }
                            finally
                            {
                                _closeRequestDialogOpen = false;
                            }

                            return;
                        }

                        _isClosingByLockEvent = true;

                        string msg = chk.Reason switch
                        {
                            LockCloseReason.FORCE_CLOSE =>
                                $"Admin bu sənəd üçün bağlanma əmri verdi.\n{chk.Note}",
                            LockCloseReason.OWNERSHIP_CHANGED =>
                                $"Sənəd artıq başqa istifadəçiyə keçib: {chk.CurrentOwnerUserName}",
                            LockCloseReason.LOCK_REMOVED =>
                                "Sənədin lock-u silinib.",
                            _ => "Sənəd bağlanır."
                        };

                        XtraMessageBox.Show(
                            msg,
                            "Sənəd bağlanır",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        Close();
                    }));
                }
                catch
                {
                    // log
                }
            };

            _lockHeartbeatTimer.Start();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!_isClosingByLockEvent && HasUnsavedChanges())
            {
                var result = XtraMessageBox.Show(
                    Resources.Form_Invoice_UnsavedChangesQuestion,
                    Resources.Common_Attention,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (dataLayoutControl1.IsValid(out _))
                    {
                        if (!SaveInvoice())
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                // DialogResult.No => discard, proceed closing
            }

            _lockHeartbeatTimer?.Stop();
            _lockHeartbeatTimer?.Dispose();
            _lockHeartbeatTimer = null;

            try
            {
                _lockService.ReleaseLock(
                    "Invoice",
                    trInvoiceHeader.InvoiceHeaderId,
                    Authorization.CurrAccCode,
                    Environment.MachineName,
                    _appInstanceId);
            }
            catch
            {
                // log
            }

            base.OnFormClosing(e);
        }

        private decimal GetRemainingPaymentAmount()
        {
            decimal invoiceSum = Math.Abs(efMethods.SelectInvoiceSum(trInvoiceHeader.InvoiceHeaderId));
            decimal prePaid = efMethods.SelectPaymentLinesSumByInvoice(trInvoiceHeader.InvoiceHeaderId, trInvoiceHeader.CurrAccCode);

            return Math.Max(Math.Round(Math.Abs(invoiceSum) - Math.Abs(prePaid), 4), 0);
        }

        // ══════════════════════════════════════════════════════
        //  KAMPANİYA İNTEQRASİYASI
        // ══════════════════════════════════════════════════════

        private CampaignService _campaignService = null!;
        private bool _cashOnlyCampaignApplied = false;
        private string? _appliedPromoCode = null;
        private bool _isApplyingCampaign = false;

        private void InitCampaignIfEnabled()
        {
            if (!IsCampaignEnabled)
            {
                _cashOnlyCampaignApplied = false;
                _appliedPromoCode = null;
                return;
            }

            _campaignService = new CampaignService(dbContext);
        }

        private List<TrInvoiceLine> GetInvoiceLines()
        {
            var lines = new List<TrInvoiceLine>();
            for (int i = 0; i < gV_InvoiceLine.DataRowCount; i++)
                if (gV_InvoiceLine.GetRow(i) is TrInvoiceLine line)
                    lines.Add(line);
            return lines;
        }

        /// <summary>"Kampaniya Tətbiq Et" düyməsi</summary>
        private void bBI_CampaignApply_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsCampaignEnabled)
                return;

            ApplyRegularCampaigns();
        }

        private void ApplyRegularCampaigns()
        {
            if (trInvoiceHeader is null) return;
            if (gV_InvoiceLine.DataRowCount <= 0)
            {
                XtraMessageBox.Show(Properties.Resources.Campaign_NoProductInInvoice,
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            gV_InvoiceLine.CloseEditor();
            gV_InvoiceLine.UpdateCurrentRow();

            InitCampaignIfEnabled();

            _isApplyingCampaign = true;
            try
            {
                var result = _campaignService.ApplyCampaigns(
                    trInvoiceHeader, GetInvoiceLines(), _appliedPromoCode, CampaignFilter.RegularOnly);

                gV_InvoiceLine.RefreshData();
                if (result.Success) SaveInvoice();

                XtraMessageBox.Show(result.Message, "Kampaniya",
                    MessageBoxButtons.OK,
                    result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
            finally
            {
                _isApplyingCampaign = false;
            }
        }

        /// <summary>"Kampaniya Log" düyməsi – tətbiq edilmiş kampaniyaları göstər</summary>
        private void bBI_CampaignLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (trInvoiceHeader is null) return;
            InitCampaignIfEnabled();

            var logs = _campaignService.GetCampaignLogs(trInvoiceHeader.InvoiceHeaderId);
            if (!logs.Any())
            {
                XtraMessageBox.Show(Properties.Resources.Campaign_NoCampaignApplied,
                    Properties.Resources.Campaign_LogTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var grouped = logs
                .GroupBy(l => new { l.CampaignCode, l.CampaignDesc })
                .Select(g => new
                {
                    g.Key.CampaignCode,
                    g.Key.CampaignDesc,
                    TotalDiscount = g.Sum(l => l.DiscountAmount),
                    TotalDiscountLoc = g.Sum(l => l.DiscountAmountLoc),
                    Lines = g.Count()
                });

            string text = string.Join("\n\n", grouped.Select(g =>
                $"{g.CampaignCode} – {g.CampaignDesc}\n" +
                $"  Sətir sayı : {g.Lines}\n" +
                $"  Endirim    : {g.TotalDiscount:n2}  ({g.TotalDiscountLoc:n2} AZN)"));

            XtraMessageBox.Show(text, Properties.Resources.Campaign_LogTitle,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>"Promo Kod" düyməsi</summary>
        private void BBI_PromoCodeCampaign_ItemClick(object sender, ItemClickEventArgs e)
        {
            var input = XtraInputBox.Show(Properties.Resources.Campaign_EnterPromoCode, Properties.Resources.Campaign_PromoCodeTitle,
                _appliedPromoCode ?? "");
            if (input == null) return;

            string code = input.ToString()?.Trim() ?? "";
            if (string.IsNullOrEmpty(code)) return;

            InitCampaignIfEnabled();
            var lines = GetInvoiceLines();

            _isApplyingCampaign = true;
            try
            {
                // Mövcud endirimləri sil
                _campaignService.RemoveAllCampaigns(trInvoiceHeader, lines);
                _cashOnlyCampaignApplied = false;
                _appliedPromoCode = code;

                var result = _campaignService.ApplyCampaigns(
                    trInvoiceHeader, lines, _appliedPromoCode, CampaignFilter.RegularOnly);

                gV_InvoiceLine.RefreshData();
                if (result.Success) SaveInvoice();

                XtraMessageBox.Show(result.Message, Properties.Resources.Campaign_PromoCodeTitle,
                    MessageBoxButtons.OK,
                    result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
            finally
            {
                _isApplyingCampaign = false;
            }
        }

        /// <summary>"Kampaniyaları Sil" düyməsi</summary>
        private void bBI_CampaignDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (trInvoiceHeader is null) return;

            if (XtraMessageBox.Show(
                Properties.Resources.Campaign_ConfirmDelete,
                Resources.Common_Attention,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            InitCampaignIfEnabled();
            var lines = GetInvoiceLines();

            _isApplyingCampaign = true;
            try
            {
                _campaignService.RemoveAllCampaigns(trInvoiceHeader, lines);
                _cashOnlyCampaignApplied = false;
                _appliedPromoCode = null;

                gV_InvoiceLine.RefreshData();
                SaveInvoice();

                XtraMessageBox.Show(Properties.Resources.Campaign_DiscountDeleted,
                    "Kampaniya", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                _isApplyingCampaign = false;
            }
        }

        // ── ÖDƏNİŞ DÜYMƏSİ (kampaniya ilə) ─────────────────
        private void bBI_Payment_ItemClick_WithCampaign(object sender, ItemClickEventArgs e)
        {
            if (trInvoiceHeader is null) return;

            if (!EnsureInvoiceCanBeChanged())
                return;

            gV_InvoiceLine.CloseEditor();
            gV_InvoiceLine.UpdateCurrentRow();
            dataLayoutControl1.Validate();

            if (!dataLayoutControl1.IsValid(out _)) return;
            if (gV_InvoiceLine.DataRowCount <= 0) return;

            if (!EnsureInvoiceSaved()) return;

            decimal pay = GetRemainingPaymentAmount();
            if (pay <= 0)
            {
                XtraMessageBox.Show(Properties.Resources.Payment_NoRemainingAmount, Properties.Resources.Payment_Title,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            IEnumerable<int>? allowedPaymentMethodIds = null;
            if (IsCampaignEnabled)
            {
                // IsCashOnly kampaniya yoxlaması
                TryApplyCashOnlyCampaign(ref pay, out allowedPaymentMethodIds);
            }

            // FormPayment açılır
            using FormPayment form = new(PaymentType.Cash, pay, trInvoiceHeader, allowedPaymentMethodIds);

            if (form.ShowDialog(this) != DialogResult.OK)
            {
                if (IsCampaignEnabled)
                    if (_cashOnlyCampaignApplied)
                    {
                        // İstifadəçi ödənişi ləğv etdi → IsCashOnly geri al
                        RollbackCashOnlyCampaign();
                    }

                return;
            }

            UpdatePaidLabels();
        }

        // ── IsCashOnly kampaniya sihirbazı ──────────────────────────────
        private bool TryApplyCashOnlyCampaign(
            ref decimal remainingPay,
            out IEnumerable<int>? allowedPaymentMethodIds)
        {
            allowedPaymentMethodIds = null;

            InitCampaignIfEnabled();
            var lines = GetInvoiceLines();
            var cashOnlyCampaigns = _campaignService.GetEligibleCampaigns(
                trInvoiceHeader, lines, null, CampaignFilter.CashOnlyOnly);

            if (!cashOnlyCampaigns.Any()) return false;

            var campaign = cashOnlyCampaigns.First(); // ən yüksək prioritet

            // 1) İstifadəçiyə soruş
            string discountStr = campaign.DiscountTypeCode == DiscountTypeCode.Percent
                ? $"{campaign.DiscountValue}%"
                : $"{campaign.DiscountValue:n2} AZN";

            var answer = XtraMessageBox.Show(
                $"«{campaign.CampaignDesc}» kampaniyası tətbiq edilə bilər.\n\n" +
                $"Endirim: {discountStr}\n" +
                "⚠  Bu kampaniya yalnız nağd ödənişdə keçərlidir.\n\n" +
                "Tətbiq edilsin?",
                "Kampaniya",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer != DialogResult.Yes) return false;

            // 2) Şifrə yoxla
            if (!string.IsNullOrEmpty(campaign.CampaignPassword))
            {
                var pwd = XtraInputBox.Show("Kampaniya şifrəsini daxil edin:", "Şifrə", "");
                if (pwd?.ToString() != campaign.CampaignPassword)
                {
                    XtraMessageBox.Show(Properties.Resources.Campaign_PasswordIncorrect,
                        Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            // 3) Tətbiq et
            _isApplyingCampaign = true;
            try
            {
                var result = _campaignService.ApplyCampaigns(
                    trInvoiceHeader, lines, null, CampaignFilter.CashOnlyOnly);

                if (!result.Success)
                {
                    XtraMessageBox.Show(Properties.Resources.Campaign_NotApplied,
                        Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                gV_InvoiceLine.RefreshData();
                SaveInvoice();
                _cashOnlyCampaignApplied = true;

                // Yenilənmiş ödəniləcək məbləğ
                remainingPay = GetRemainingPaymentAmount();

                // Yalnız nağd ödəniş metodlarını icazəli et
                allowedPaymentMethodIds = efMethods
                    .SelectPaymentMethodsByPaymentTypes(new[] { PaymentType.Cash })
                    .Select(m => m.PaymentMethodId);

                return true;
            }
            finally
            {
                _isApplyingCampaign = false;
            }
        }

        // ── IsCashOnly geri alma ─────────────────────────────────────────
        private void RollbackCashOnlyCampaign()
        {
            _isApplyingCampaign = true;
            try
            {
                InitCampaignIfEnabled();
                _campaignService.RollbackCashOnlyCampaigns(
                    trInvoiceHeader.InvoiceHeaderId, GetInvoiceLines());

                gV_InvoiceLine.RefreshData();
                SaveInvoice();
                _cashOnlyCampaignApplied = false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"RollbackCashOnlyCampaign: {ex.Message}");
            }
            finally
            {
                _isApplyingCampaign = false;
            }
        }

        // ── ÖDƏNİŞ SİLMƏ (kampaniya ilə) ────────────────────
        private void bBI_PaymentDelete_ItemClick_WithCampaign(object sender, ItemClickEventArgs e)
        {
            if (trInvoiceHeader is null) return;

            if (!EnsureInvoiceCanBeChanged())
                return;

            if (IsCampaignEnabled)
            {
                // IsCashOnly kampaniya tətbiq edilibsə – silinməyə icazə verma
                InitCampaignIfEnabled();

                if (_campaignService.HasCashOnlyCampaignApplied(trInvoiceHeader.InvoiceHeaderId))
                {
                    XtraMessageBox.Show(
                        Properties.Resources.Campaign_CashOnlyAppliedDeleteWarning,
                        Resources.Common_Attention,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

            }
            if (MessageBox.Show(
                Resources.Form_Invoice_DeletePaymentsQuestion,
                Resources.Common_Attention,
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                efMethods.DeletePaymentsByInvoiceId(trInvoiceHeader.InvoiceHeaderId);
                UpdatePaidLabels();
            }
        }

        /// <summary>
        /// Kampaniya tətbiq edilmişsə sətir dəyişikliyindən sonra yenidən hesabla.
        /// </summary>
        private void RecalcCampaignsIfNeeded()
        {
            if (_isApplyingCampaign) return;
            if (!IsCampaignEnabled)
                return;

            if (trInvoiceHeader is null) return;
            InitCampaignIfEnabled();

            if (!_campaignService.HasCampaignApplied(trInvoiceHeader.InvoiceHeaderId))
                return;

            _isApplyingCampaign = true;
            try
            {
                var recalcResult = _campaignService.RecalculateCampaigns(
                    trInvoiceHeader,
                    GetInvoiceLines(),
                    _appliedPromoCode,
                    _cashOnlyCampaignApplied);

                gV_InvoiceLine.RefreshData();

                if (recalcResult.Success)
                    SaveInvoice();
            }
            finally
            {
                _isApplyingCampaign = false;
            }
        }

        /// <summary>
        /// IsAutoApply=true olan kampaniyaları məhsul əlavə edildikdə avtomatik tətbiq edir.
        /// Kampaniya artıq tətbiq edilibsə yenidən tətbiq etmir.
        /// </summary>
        private void AutoApplyCampaignsIfConfigured()
        {
            if (_isApplyingCampaign) return;
            if (trInvoiceHeader is null) return;
            InitCampaignIfEnabled();

            var lines = GetInvoiceLines();
            var eligible = _campaignService.GetEligibleCampaigns(
                trInvoiceHeader, lines, _appliedPromoCode, CampaignFilter.RegularOnly);

            if (!eligible.Any(c => c.IsAutoApply)) return;

            _isApplyingCampaign = true;
            try
            {
                var result = _campaignService.ApplyCampaigns(
                    trInvoiceHeader, lines, _appliedPromoCode, CampaignFilter.RegularOnly);

                if (result.Success)
                    gV_InvoiceLine.RefreshData();
            }
            finally
            {
                _isApplyingCampaign = false;
            }
        }

        #region Related Invoices

        private void PopulateRelatedInvoicesMenu()
        {
            BSI_RelatedInvoices.ClearLinks();

            if (trInvoiceHeader is null || trInvoiceHeader.InvoiceHeaderId == Guid.Empty)
                return;

            using var ctx = new subContext();
            var relatedInvoices = new List<TrInvoiceHeader>();

            // Parent invoice (the one this invoice references)
            if (trInvoiceHeader.RelatedInvoiceId.HasValue)
            {
                var parent = ctx.TrInvoiceHeaders
                    .Include(x => x.DcProcess)
                    .FirstOrDefault(x => x.InvoiceHeaderId == trInvoiceHeader.RelatedInvoiceId.Value);
                if (parent != null)
                    relatedInvoices.Add(parent);
            }

            // Child invoices (those that reference this invoice)
            var children = ctx.TrInvoiceHeaders
                .Include(x => x.DcProcess)
                .Where(x => x.RelatedInvoiceId == trInvoiceHeader.InvoiceHeaderId)
                .OrderBy(x => x.DocumentDate)
                .ThenBy(x => x.DocumentNumber)
                .ToList();

            relatedInvoices.AddRange(children);

            foreach (var related in relatedInvoices)
            {
                var item = new BarButtonItem();
                string processDesc = related.DcProcess?.ProcessDesc ?? related.ProcessCode;
                item.Caption = $"{processDesc} - {related.DocumentNumber} ({related.DocumentDate:dd.MM.yyyy})";
                item.Tag = related.InvoiceHeaderId;
                item.ItemClick += BSI_RelatedInvoices_ItemClick;
                BSI_RelatedInvoices.AddItem(item);
            }
        }

        private async void BSI_RelatedInvoices_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Tag is not Guid invoiceHeaderId)
                return;

            if (!PromptSaveChanges())
                return;

            if (TryAcquireInvoiceLockForEdit(invoiceHeaderId))
            {
                if (trInvoiceHeader is not null)
                    _lockService.ReleaseLock(
                        "Invoice",
                        trInvoiceHeader.InvoiceHeaderId,
                        Authorization.CurrAccCode,
                        Environment.MachineName,
                        _appInstanceId);

                trInvoiceHeader = efMethods.SelectInvoiceHeader(invoiceHeaderId);
                await LoadInvoiceAsync(trInvoiceHeader.InvoiceHeaderId);
            }
        }

        #endregion

    }
}
