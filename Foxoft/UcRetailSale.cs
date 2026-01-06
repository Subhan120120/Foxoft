using DevExpress.DataAccess.Sql;
using DevExpress.Mvvm.Native;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGauges.Core;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Collections.Specialized;
using System.Drawing.Printing;
using System.IO;

namespace Foxoft
{
    public partial class UcRetailSale : XtraUserControl
    {
        public Guid invoiceHeaderId;
        public TrInvoiceHeader trInvoiceHeader = new();
        DcCurrAcc dcCurrAcc = new();
        public int rowIndx = (-1); // setting by "FocusedRowChanged" event
        EfMethods efMethods = new();
        ReportClass reportClass;
        subContext dbContext = new();
        readonly SettingStore settingStore;

        public UcRetailSale()
        {
            InitializeComponent();

            MouseWheelHelper.DisableMouseWheelForType<LookUpEdit>(this);
            MouseWheelHelper.DisableMouseWheelForType<DateEdit>(this);

            ActiveControl = txtEdit_Barcode;

            settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);
            reportClass = new ReportClass(settingStore.DesignFileFolder);

            ClearControlsAddNew();
        }

        private void UcRetailSale_Load(object sender, EventArgs e)
        {
            this.ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing); // set Parent Form Closing event

            if (string.IsNullOrEmpty(trInvoiceHeader.CurrAccCode))
            {
                string defaultCustomer = efMethods.SelectDefaultCustomerByStore(Authorization.StoreCode);
                trInvoiceHeader.CurrAccCode = defaultCustomer;
            }

            var sc = Settings.Default.POSFindProduct;
            if (sc == null)
            {
                sc = new StringCollection();
                Settings.Default.POSFindProduct = sc;
                Settings.Default.Save();
            }

            foreach (CheckedListBoxItem item in checkedComboBoxEdit1.Properties.Items)
            {
                item.CheckState = sc.Contains(item.Value.ToString())
                    ? CheckState.Checked
                    : CheckState.Unchecked;
            }
        }

        private void trInvoiceHeadersBindingSource_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
        {
            TrInvoiceHeader invoiceHeader = new();
            invoiceHeader.InvoiceHeaderId = invoiceHeaderId;
            string NewDocNum = efMethods.GetNextDocNum(
                true,
                "RS",
                nameof(TrInvoiceHeader.DocumentNumber),
                nameof(subContext.TrInvoiceHeaders),
                6);
            invoiceHeader.DocumentNumber = NewDocNum;
            invoiceHeader.DocumentDate = DateTime.Now;
            invoiceHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            invoiceHeader.ProcessCode = "RS";
            invoiceHeader.OfficeCode = Authorization.OfficeCode;
            invoiceHeader.StoreCode = Authorization.StoreCode;
            invoiceHeader.CreatedUserName = Authorization.CurrAccCode;
            invoiceHeader.IsMainTF = true;
            invoiceHeader.WarehouseCode = efMethods.SelectWarehouseByStore(Authorization.StoreCode);
            string defaultCustomer = efMethods.SelectDefaultCustomerByStore(Authorization.StoreCode);
            invoiceHeader.CurrAccCode = defaultCustomer;

            e.NewObject = invoiceHeader;
        }

        private void gV_InvoiceLine_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView gv = sender as GridView;
            gv.SetRowCellValue(e.RowHandle, colInvoiceHeaderId, trInvoiceHeader.InvoiceHeaderId);
            gv.SetRowCellValue(e.RowHandle, colInvoiceLineId, Guid.NewGuid());
            gv.SetRowCellValue(e.RowHandle, colCreatedDate, DateTime.Now);
            gv.SetRowCellValue(e.RowHandle, colCreatedUserName, Authorization.CurrAccCode);

            string currencyCode = Settings.Default.AppSetting.LocalCurrencyCode;

            DcProcess dcProcess = efMethods.SelectEntityById<DcProcess>("RS");
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
                                    }, TaskScheduler.FromCurrentSynchronizationContext());

            LoadCurrAcc();

            CalcPaidAmount();
        }

        private void LoadInvoice(Guid InvoiceHeaderId)
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(WaitForm), true, true, false);

            dbContext = new subContext();

            dbContext.TrInvoiceHeaders.Include(x => x.DcCurrAcc)
                                      .Include(x => x.DcProcess)
                                      .Where(x => x.InvoiceHeaderId == InvoiceHeaderId)
                                      .Load();

            trInvoiceHeadersBindingSource.DataSource = dbContext.TrInvoiceHeaders.Local.ToBindingList();

            trInvoiceHeader = trInvoiceHeadersBindingSource.Current as TrInvoiceHeader;

            dbContext.TrInvoiceLines.Include(o => o.DcProduct).ThenInclude(f => f.TrProductFeatures)
                                    .Include(x => x.TrInvoiceHeader).ThenInclude(x => x.DcProcess)
                                    .Where(x => x.InvoiceHeaderId == InvoiceHeaderId)
                                    .OrderBy(x => x.CreatedDate)
                                    .LoadAsync()
                                    .ContinueWith(loadTask =>
                                    {
                                        trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList();
                                    }, TaskScheduler.FromCurrentSynchronizationContext());

            SplashScreenManager.CloseForm(false);
        }

        private void LoadCurrAcc()
        {
            using (var newContext = new subContext())
            {
                var currAcc = newContext.DcCurrAccs
                                       .AsNoTracking()
                                       .FirstOrDefault(x => x.CurrAccCode == trInvoiceHeader.CurrAccCode);

                dcCurrAccBindingSource.DataSource = currAcc;
            }

            dcCurrAcc = dcCurrAccBindingSource.Current as DcCurrAcc;
        }

        private void dcCurrAccBindingSource_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
        {
        }

        void ParentForm_FormClosing(object sender, FormClosingEventArgs e) // Parent Form Closing event
        {
            if (efMethods.EntityExists<TrInvoiceHeader>(trInvoiceHeader.InvoiceHeaderId))
                efMethods.UpdateInvoiceIsSuspended(trInvoiceHeader.InvoiceHeaderId, true); // delete incomplete invoice
        }

        private void gV_InvoiceLine_CalcPreviewText(object sender, CalcPreviewTextEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;

            string barcode = view.GetRowCellDisplayText(
                e.RowHandle,
                view.Columns[nameof(TrInvoiceLine.Barcode)]);

            decimal posDiscount = Convert.ToDecimal(
                view.GetRowCellDisplayText(e.RowHandle, view.Columns[nameof(TrInvoiceLine.PosDiscount)]));

            decimal amount = Convert.ToDecimal(
                view.GetRowCellDisplayText(e.RowHandle, view.Columns[nameof(TrInvoiceLine.Amount)]));

            decimal netAmount = Convert.ToDecimal(
                view.GetRowCellDisplayText(e.RowHandle, view.Columns[nameof(TrInvoiceLine.NetAmount)]));

            string salesPersonCode = view.GetRowCellDisplayText(
                e.RowHandle,
                view.Columns[nameof(TrInvoiceLine.SalesPersonCode)]);

            string salesPersonDesc = efMethods
                .SelectEntityById<DcCurrAcc>(salesPersonCode)
                ?.CurrAccDesc;

            string strVatRate = view.GetRowCellDisplayText(
                e.RowHandle,
                view.Columns[nameof(TrInvoiceLine.VatRate)]);

            float vatRate = float.Parse(strVatRate);

            e.PreviewText = CustomExtensions.GetPreviewText(
                posDiscount,
                amount,
                netAmount,
                vatRate,
                barcode,
                salesPersonDesc);
        }

        private void btn_ProductSearch_Click(object sender, EventArgs e)
        {
            using (FormProductList formProductList = new(new byte[] { 1 }, false))
            {
                if (formProductList.ShowDialog(this) == DialogResult.OK)
                {
                    if (formProductList.dcProduct is null)
                    {
                        XtraMessageBox.Show(
                            Resources.Form_RetailSale_ProductAddFailed,
                            Resources.Common_Attention,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    if (formProductList.dcProduct?.ProductTypeCode == 3) // product is not service product
                        return;

                    string wareHouseCode = efMethods.SelectWarehouseByStore(Authorization.StoreCode);

                    bool permitNegativeStock = efMethods
                        .SelectEntityById<DcWarehouse>(wareHouseCode)
                        .PermitNegativeStock;

                    decimal? balance = CalcProductBalance(formProductList.dcProduct, wareHouseCode);

                    decimal qty = 1;

                    if (permitNegativeStock)
                        balance = null;

                    if (Settings.Default.POSShowQuantityDialog)
                        using (FormInput formQty = new(qty, balance))
                        {
                            if (formQty.ShowDialog(this) == DialogResult.OK)
                                qty = formQty.input;
                            else
                                return;
                        }
                    else if (!permitNegativeStock)
                        if (balance <= 0m)
                        {
                            XtraMessageBox.Show(
                                Resources.Form_RetailSale_NoStock,
                                Resources.Common_Attention,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }

                    AddNewRow(formProductList.dcProduct, qty);

                    SaveInvoice();
                }
            }
        }

        private void AddNewRow(DcProduct dcProduct, decimal qty)
        {
            gV_InvoiceLine.AddNewRow();
            int newRowHandle = gV_InvoiceLine.FocusedRowHandle; // get the handle of the new row

            gV_InvoiceLine.SetRowCellValue(newRowHandle, colProductCode, dcProduct.ProductCode);
            gV_InvoiceLine.SetRowCellValue(newRowHandle, col_Price, dcProduct.RetailPrice);
            gV_InvoiceLine.SetRowCellValue(newRowHandle, colQtyOut, qty);
            gV_InvoiceLine.SetRowCellValue(newRowHandle, colProductCost, dcProduct.ProductCost);

            gV_InvoiceLine.UpdateCurrentRow(); // finalize changes
        }

        private decimal CalcProductBalance(DcProduct dcProduct, string wareHouse)
        {
            if (dcProduct is not null && !string.IsNullOrEmpty(dcProduct.ProductCode))
            {
                return efMethods.SelectProductBalance(dcProduct.ProductCode, wareHouse);
            }
            else return 0;
        }

        private void btn_CancelInvoice_Click(object sender, EventArgs e)
        {
            if (rowIndx >= 0)
            {
                DialogResult dialogResult = XtraMessageBox.Show(
                    Resources.Form_RetailSale_DeleteQuestion,
                    Resources.Common_Attention,
                    MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    int result = efMethods.DeleteInvoice(trInvoiceHeader.InvoiceHeaderId);

                    if (result >= 0)
                    {
                        ClearControlsAddNew();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show(
                    Resources.Form_RetailSale_InvoiceEmpty,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btn_DeleteLine_Click(object sender, EventArgs e)
        {
            if (gV_InvoiceLine.RowCount > 1)
            {
                DialogResult dialogResult = XtraMessageBox.Show(
                    Resources.Form_RetailSale_DeleteQuestion,
                    Resources.Common_Attention,
                    MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    gV_InvoiceLine.DeleteRow(gV_InvoiceLine.FocusedRowHandle);

                    SaveInvoice();
                }
            }
            else if (gV_InvoiceLine.RowCount == 1)
            {
                XtraMessageBox.Show(
                    Resources.Form_RetailSale_DeleteLastLineNotAllowed,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show(
                    Resources.Form_RetailSale_SelectProduct,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btn_LineDiscount_Click(object sender, EventArgs e)
        {
            bool currAccHasClaims = efMethods.CurrAccHasClaims(
                Authorization.CurrAccCode,
                nameof(TrInvoiceLine.PosDiscount));

            if (!currAccHasClaims)
            {
                XtraMessageBox.Show(
                    Resources.Form_RetailSale_NoPermission,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (rowIndx >= 0) // if product selected
            {
                decimal posDiscount = Convert.ToDecimal(
                    gV_InvoiceLine.GetRowCellValue(rowIndx, nameof(TrInvoiceLine.PosDiscount)));

                decimal amount = Convert.ToDecimal(
                    gV_InvoiceLine.GetRowCellValue(rowIndx, nameof(TrInvoiceLine.Amount)));

                using (FormPosDiscount formPosDiscount = new(posDiscount, amount))
                {
                    if (formPosDiscount.ShowDialog(this) == DialogResult.OK)
                    {
                        gV_InvoiceLine.SetRowCellValue(
                            rowIndx,
                            nameof(TrInvoiceLine.PosDiscount),
                            formPosDiscount.DiscountPercent);

                        gV_InvoiceLine.RefreshData(); // footer yenilensin deye
                        gV_InvoiceLine.MoveLast();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show(
                    Resources.Form_RetailSale_SelectProduct,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void gC_Sale_MouseUp(object sender, MouseEventArgs e)
        {
            txtEdit_Barcode.Focus();
        }

        private void btn_Payment_Click(object sender, EventArgs e)
        {
            decimal summaryNetAmount = Convert.ToDecimal(
                gV_InvoiceLine.Columns[nameof(TrInvoiceLine.NetAmount)].SummaryItem.SummaryValue);

            if (summaryNetAmount > 0)
            {
                byte paymentType = 0;

                SimpleButton simpleButton = sender as SimpleButton;
                switch (simpleButton.Name)
                {
                    case "btn_Cash":
                        paymentType = 1;
                        break;
                    case "btn_Cashless":
                        paymentType = 2;
                        break;
                    case "btn_CustomerBonus":
                        paymentType = 3;
                        break;
                    default:
                        break;
                }

                using (FormPayment formPayment = new(paymentType, summaryNetAmount, trInvoiceHeader, new byte[] { 1, 2, 3, 4 }))
                {
                    if (formPayment.ShowDialog(this) == DialogResult.OK)
                    {
                        efMethods.UpdateInvoiceIsCompleted(trInvoiceHeader.InvoiceHeaderId);

                        if (Settings.Default.AppSetting.AutoPrint == true)
                        {
                            string designPath = Settings.Default.AppSetting.PrintDesignPath;
                            if (!File.Exists(designPath))
                                designPath = reportClass.SelectDesign();

                            ReportPrintTool printTool = new(
                                reportClass.CreateReport(
                                    efMethods.SelectInvoiceLineForReport(trInvoiceHeader.InvoiceHeaderId),
                                    designPath));
                            printTool.Print();
                        }

                        CalcPaidAmount();

                        ClearControlsAddNew();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show(
                    Resources.Form_RetailSale_PaymentZero,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btn_CustomerAdd_Click(object sender, EventArgs e)
        {
            using (FormCurrAcc formCustomer = new((byte)1, true))
            {
                if (formCustomer.ShowDialog(this) == DialogResult.OK)
                {
                    trInvoiceHeader.CurrAccCode = formCustomer.dcCurrAcc.CurrAccCode;

                    SaveInvoice();

                    LoadCurrAcc();
                }
            }
        }

        private void Btn_CustomerEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CurrAccCodeTextEdit.Text))
            {
                using (FormCurrAcc formCustomer = new(CurrAccCodeTextEdit.Text, true))
                {
                    if (formCustomer.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadCurrAcc();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show(
                    Resources.Form_RetailSale_SelectCustomer,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
        }

        private void btn_CustomerSearch_Click(object sender, EventArgs e)
        {
            using (FormCurrAccList form = new(new byte[] { 1, 2, 3 }, false, trInvoiceHeader.CurrAccCode))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    trInvoiceHeader.CurrAccCode = form.dcCurrAcc.CurrAccCode;

                    SaveInvoice();

                    LoadCurrAcc();
                }
            }
        }

        private void gC_Sale_DoubleClick(object sender, EventArgs e)
        {
            if (gV_InvoiceLine.FocusedColumn == col_Qty)
            {
                using (FormInput formQty = new())
                {
                    if (formQty.ShowDialog(this) == DialogResult.OK)
                    {
                        gV_InvoiceLine.SetRowCellValue(
                            rowIndx,
                            nameof(TrInvoiceLine.QtyOut),
                            formQty.input);

                        gV_InvoiceLine.RefreshData(); // footer yenilensin deye
                        SaveInvoice();
                    }
                }
            }

            if (gV_InvoiceLine.FocusedColumn == col_Price)
            {
                if (!efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "ChangePriceRS"))
                    return;

                using (FormInput formQty = new())
                {
                    if (formQty.ShowDialog(this) == DialogResult.OK)
                    {
                        gV_InvoiceLine.SetRowCellValue(
                            rowIndx,
                            nameof(TrInvoiceLine.Price),
                            formQty.input);

                        gV_InvoiceLine.RefreshData(); // footer yenilensin deye
                        SaveInvoice();
                    }
                }
            }
        }

        private async void btn_Print_Click(object sender, EventArgs e)
        {
            string printerName =
                string.IsNullOrEmpty(settingStore.PrinterName)
                    ? new PrinterSettings().PrinterName
                    : settingStore.PrinterName;

            await PrintFast(settingStore.PrinterName);
        }

        private async Task PrintFast(string printerName)
        {
            alertControl1.Show(
                this.ParentForm,
                Resources.Common_PrintSending,
                string.Format("{0}: {1}", Resources.Common_PrinterLabel, printerName),
                string.Empty,
                (Image)null,
                null);

            if (trInvoiceHeader is not null)
                await Task.Run(() => GetPrint(trInvoiceHeader.InvoiceHeaderId, printerName));
            else
                XtraMessageBox.Show(
                    Resources.Form_RetailSale_NoInvoiceToPrint,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            Task task = Task.Run((Action)ShowPrintCount);

            alertControl1.Show(
                this.ParentForm,
                Resources.Common_PrintSent,
                string.Format("{0}: {1}", Resources.Common_PrinterLabel, printerName),
                string.Empty,
                (Image)null,
                null);
        }

        private void ShowPrintCount()
        {
            int printCount = efMethods
                .SelectEntityById<TrInvoiceHeader>(trInvoiceHeader?.InvoiceHeaderId)
                .PrintCount;

            txt_PrintCount.Text = printCount.ToString();
        }

        private void GetPrint(Guid invoiceHeaderId, string printerName)
        {
            XtraReport report = GetInvoiceReport("Report_Embedded_InvoiceReport.repx");
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

        private void btn_PrintPrevieww_Click(object sender, EventArgs e)
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

        private void ShowZetPreview()
        {
            DcReport dcReport = efMethods.SelectReportByName("ZET");

            if (dcReport is null)
                return;

            if (!efMethods.CurrAccHasClaims(Authorization.CurrAccCode, dcReport.ReportId.ToString()))
            {
                XtraMessageBox.Show(
                    Resources.Common_NoPermission,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            foreach (var item in dcReport.DcReportVariables.Where(x => x.ReportId == dcReport.ReportId))
            {
                if (item.VariableProperty == "StartDate")
                {
                    item.VariableValue = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else if (item.VariableProperty == "EndDate")
                {
                    item.VariableValue = DateTime.Now.ToString("yyyy-MM-dd");
                }
            }

            reportClass.ShowReport(dcReport, "");
        }

        private void ShowReportForm(DcReport dcReport, string filter, string activeFilterStr)
        {
            if (dcReport.ReportTypeId == 1)
            {
                FormReportGrid formGrid = new(dcReport.ReportQuery, filter, dcReport, activeFilterStr);
                formGrid.Show();
            }
            else if (dcReport.ReportTypeId == 2)
            {
                FormReportPreview form = new(dcReport.ReportQuery, filter, dcReport)
                {
                    WindowState = FormWindowState.Maximized
                };
                form.Show();
            }
        }

        private void btn_ReportZ_Click(object sender, EventArgs e)
        {
            ShowZetPreview();
        }

        private void btn_SalesPerson_Click(object sender, EventArgs e)
        {
            if (rowIndx >= 0)
            {
                string salesPerson = gV_InvoiceLine
                    .GetRowCellValue(rowIndx, nameof(TrInvoiceLine.SalesPersonCode))
                    ?.ToString();

                using (FormCurrAccList form = new(new byte[] { 3 }, false, salesPerson, new byte[] { 1 }))
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        gV_InvoiceLine.SetRowCellValue(
                            rowIndx,
                            nameof(TrInvoiceLine.SalesPersonCode),
                            form.dcCurrAcc.CurrAccCode);

                        gV_InvoiceLine.RefreshData(); // footer yenilensin deye
                        gV_InvoiceLine.MoveLast();

                        SaveInvoice();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show(
                    Resources.Form_RetailSale_SelectProduct,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void gV_InvoiceLine_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            rowIndx = gV_InvoiceLine.FocusedRowHandle;
        }

        private void TxtEdit_Barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // Prevent further processing if needed
                OnEnterKeyPressed();
            }
        }

        protected virtual void OnEnterKeyPressed()
        {
            if (string.IsNullOrWhiteSpace(txtEdit_Barcode.EditValue?.ToString()))
                return;

            string input = txtEdit_Barcode.EditValue.ToString().Trim();

            var items = checkedComboBoxEdit1.Properties.Items;

            bool useBarCode = items["Barcode"].CheckState == CheckState.Checked;
            bool useProductCode = items["ProductCode"].CheckState == CheckState.Checked;

            DcProduct dcProductByProductCode = null;
            DcProduct dcProductByBarcode = null;
            DcProduct dcProductByScale = null;

            decimal qty = 0;

            if (useBarCode)
            {
                dcProductByBarcode = efMethods.SelectProductByBarcode(input);
            }

            if (useProductCode)
            {
                dcProductByProductCode = efMethods.SelectEntityById<DcProduct>(input);

                if (dcProductByProductCode is null)
                    dcProductByProductCode = efMethods.SelectEntityById<DcProduct>("P-" + input);
            }

            if (Settings.Default.AppSetting.UseScales && input.Length == 13 && input.All(char.IsDigit))
            {
                int productId = int.Parse(input.Substring(1, 6));
                dcProductByScale = efMethods.SelectProductById(productId);
            }

            DcProduct selectedProduct = null;
            if (dcProductByBarcode != null)
            {
                selectedProduct = dcProductByBarcode;
                qty = dcProductByBarcode.TrProductBarcodes.FirstOrDefault().Qty;
            }
            else if (dcProductByScale != null)
            {
                selectedProduct = dcProductByScale;
                qty = int.Parse(input.Substring(7, 6)) / 10000m; // 2 000003 02.0000
            }
            else if (dcProductByProductCode != null)
            {
                selectedProduct = dcProductByProductCode;
                qty = 1;
            }

            if (dcProductByBarcode != null && dcProductByScale != null)
            {
                using FormProductList formProductList = new(
                    new byte[] { 1 },
                    false,
                    new[] { dcProductByBarcode.ProductCode, dcProductByScale.ProductCode });

                if (formProductList.ShowDialog(this) == DialogResult.OK)
                {
                    selectedProduct = formProductList.dcProduct;

                    if (selectedProduct?.ProductCode == dcProductByBarcode.ProductCode)
                        qty = dcProductByBarcode.TrProductBarcodes.FirstOrDefault().Qty;
                    else if (selectedProduct?.ProductCode == dcProductByScale.ProductCode)
                        qty = int.Parse(input.Substring(7, 6)) / 10000m; // 2 000003 02.0000
                }
            }

            if (selectedProduct != null)
            {
                if (selectedProduct?.ProductTypeCode == 3) // product is not service product
                    return;

                string wareHouseCode = efMethods.SelectWarehouseByStore(Authorization.StoreCode);

                bool permitNegativeStock = efMethods
                    .SelectEntityById<DcWarehouse>(wareHouseCode)
                    .PermitNegativeStock;

                decimal? balance = CalcProductBalance(selectedProduct, wareHouseCode);

                if (permitNegativeStock)
                    balance = null;

                if (Settings.Default.POSShowQuantityDialog && dcProductByScale == null)
                    using (FormInput formQty = new(qty, balance))
                    {
                        if (formQty.ShowDialog(this) == DialogResult.OK)
                            qty = formQty.input;
                        else
                            return;
                    }
                else if (!permitNegativeStock)
                    if (balance <= 0m)
                    {
                        XtraMessageBox.Show(
                            Resources.Form_RetailSale_NoStock,
                            Resources.Common_Attention,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                AddNewRow(selectedProduct, qty);
                SaveInvoice();
                txtEdit_Barcode.EditValue = string.Empty;
            }
            else
            {
                XtraMessageBox.Show(
                    Resources.Form_RetailSale_BarcodeNotFound,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            ActiveControl = txtEdit_Barcode;
        }

        private decimal ShowQtyDialog(decimal qty, decimal? maxQty = null)
        {
            using (FormInput formQty = new(qty, maxQty))
            {
                if (formQty.ShowDialog(this) == DialogResult.OK)
                    qty = formQty.input;
            }
            return qty;
        }

        private void GV_InvoiceLine_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column == colProductCode)
            {
                var row = gV_InvoiceLine.GetRow(e.RowHandle) as TrInvoiceLine;

                if (row != null)
                {
                    row.DcProduct = dbContext.DcProducts.FirstOrDefault(
                        x => x.ProductCode == row.ProductCode);
                }
            }
        }

        private void SaveInvoice()
        {
            dbContext.SaveChanges(Authorization.CurrAccCode);

            trInvoiceHeader = trInvoiceHeadersBindingSource.Current as TrInvoiceHeader;

            Tag = trInvoiceHeader.DocumentNumber;
        }

        private void Btn_NewInvoice_Click(object sender, EventArgs e)
        {
            ClearControlsAddNew();
        }

        private void btn_IncomplatedInvoices_Click(object sender, EventArgs e)
        {
            using FormInvoiceHeaderList form = new("RS", false);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                trInvoiceHeader = form.trInvoiceHeader;

                LoadInvoice(trInvoiceHeader.InvoiceHeaderId);
            }
        }

        private void CalcPaidAmount()
        {
            decimal cashSum = efMethods.SelectPaymentLinesCashSumByInvoice(
                trInvoiceHeader.InvoiceHeaderId,
                trInvoiceHeader.CurrAccCode);

            lbl_InvoicePaidCashSum.Text =
                Math.Round(cashSum, 2).ToString() + " " + Settings.Default.AppSetting.LocalCurrencyCode;

            decimal cashlessSum = efMethods.SelectPaymentLinesCashlessSumByInvoice(
                trInvoiceHeader.InvoiceHeaderId,
                trInvoiceHeader.CurrAccCode);

            lbl_InvoicePaidCashlessSum.Text =
                Math.Round(cashlessSum, 2).ToString() + " " + Settings.Default.AppSetting.LocalCurrencyCode;

            decimal totalSum = efMethods.SelectPaymentLinesSumByInvoice(
                trInvoiceHeader.InvoiceHeaderId,
                trInvoiceHeader.CurrAccCode);

            lbl_InvoicePaidTotalSum.Text =
                Math.Round(totalSum, 2).ToString() + " " + Settings.Default.AppSetting.LocalCurrencyCode;
        }

        private void btn_InvoiceDiscount_Click(object sender, EventArgs e)
        {
            bool currAccHasClaims = efMethods.CurrAccHasClaims(
                Authorization.CurrAccCode,
                nameof(TrInvoiceLine.PosDiscount));

            if (!currAccHasClaims)
            {
                XtraMessageBox.Show(
                    Resources.Form_RetailSale_NoPermission,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            decimal amount = efMethods.SelectInvoiceSum(trInvoiceHeader.InvoiceHeaderId);

            if (gV_InvoiceLine.DataRowCount <= 0)
            {
                XtraMessageBox.Show(
                    Resources.Form_RetailSale_NoProduct,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using (FormPosDiscount formPosDiscount = new(0, amount))
            {
                if (formPosDiscount.ShowDialog(this) == DialogResult.OK)
                {
                    for (int i = 0; i < gV_InvoiceLine.DataRowCount; i++)
                    {
                        gV_InvoiceLine.SetRowCellValue(
                            i,
                            nameof(TrInvoiceLine.PosDiscount),
                            formPosDiscount.DiscountPercent);
                    }
                }
            }

            gV_InvoiceLine.RefreshData();
            gV_InvoiceLine.MoveLast();
        }

        private void checkedComboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {
            var sc = new StringCollection();

            foreach (CheckedListBoxItem item in checkedComboBoxEdit1.Properties.Items)
            {
                if (item.CheckState == CheckState.Checked)
                    sc.Add(item.Value.ToString());
            }

            Settings.Default.POSFindProduct = sc;
            Settings.Default.Save();
        }

    }
}
