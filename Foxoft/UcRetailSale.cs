using DevExpress.DataAccess.Sql;
using DevExpress.Mvvm.Native;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using Foxoft.Models;
using Foxoft.Models.Entity.Report;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using static Foxoft.FormAppSetting;

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
        DcLoyaltyCard loyaltyCard;

        public UcRetailSale()
        {
            InitializeComponent();

            BindCheckedCombo();

            MouseWheelHelper.DisableMouseWheelForType<LookUpEdit>(this);
            MouseWheelHelper.DisableMouseWheelForType<DateEdit>(this);

            ActiveControl = txtEdit_Barcode;

            settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);
            reportClass = new ReportClass(settingStore.DesignFileFolder);

            ClearControlsAddNew();

            InitializeResourseName();
        }

        private void InitializeResourseName()
        {
            lbl_InvoicePaidTotalSumTxt.Text = Resources.Form_RetailSale_Label_PaidTotal;
            lbl_InvoicePaidCashlessSumTxt.Text = Resources.Form_RetailSale_Label_PaidCashless;
            lbl_InvoicePaidCashSumTxt.Text = Resources.Form_RetailSale_Label_PaidCash;
            btn_ProductSearch.Text = Resources.Form_RetailSale_SelectProduct;
            btn_LineDiscount.Text = Resources.Form_RetailSale_Button_LineDiscount;
            btn_CancelInvoice.Text = Resources.Form_RetailSale_Button_CancelInvoice;
            btn_DeleteLine.Text = Resources.Form_RetailSale_Button_DeleteLine;
            btn_SalesPerson.Text = Resources.Form_RetailSale_Button_SalesPerson;
            btn_Cash.Text = Resources.Form_RetailSale_Button_PaymentCash;
            btn_Cashless.Text = Resources.Form_RetailSale_Button_PaymentCashless;
            btn_CustomerBonus.Text = Resources.Form_RetailSale_Button_PaymentBonus;
            btn_Print.Text = Resources.Form_RetailSale_Button_Print;
            btn_PrintPreview.Text = Resources.Form_RetailSale_Button_PrintPreview;
            btn_ReportZ.Text = Resources.Form_RetailSale_Button_ReportZ;
            btn_AddBasket.Text = Resources.Form_RetailSale_Button_AddBasket;
            btn_IncomplatedInvoices.Text = Resources.Form_RetailSale_Button_IncompletedInvoices;
            btn_InvoiceDiscount.Text = Resources.Form_RetailSale_Button_InvoiceDiscount;
            btn_NewInvoice.Text = Resources.Form_RetailSale_Button_New;
        }

        private void BindCheckedCombo()
        {
            List<FindBy> list = new()
            {
                new() { Id = 1, Name = "ProductCode" },
                new() { Id = 2, Name = "Barcode" },
                new() { Id = 3, Name = "SerialNumber" }
            };

            POSFindProductByCheckedComboBoxEdit.Properties.DataSource = list;
            POSFindProductByCheckedComboBoxEdit.Properties.ValueMember = nameof(FindBy.Id);
            POSFindProductByCheckedComboBoxEdit.Properties.DisplayMember = nameof(FindBy.Name);
        }

        private void UcRetailSale_Load(object sender, EventArgs e)
        {
            this.ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing); // set Parent Form Closing event

            if (string.IsNullOrEmpty(trInvoiceHeader.CurrAccCode))
            {
                string defaultCustomer = efMethods.SelectDefaultCustomerByStore(Authorization.StoreCode);
                trInvoiceHeader.CurrAccCode = defaultCustomer;
            }

            POSFindProductByCheckedComboBoxEdit.EditValue = Settings.Default.AppSetting.POSFindProductBy?.Trim() ?? "";
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

        private bool TryMergeSameProduct(DcProduct dcProduct, decimal qty, string? salesman)
        {
            if (dcProduct == null) return false;

            if (!Settings.Default.AppSetting.POSMergeSameProducts) return false;

            if (gV_InvoiceLine.DataRowCount <= 0) return false;

            // Şərtlər: ProductCode + Price + Salesman + PosDiscount + VatRate (istəsən azaldarıq)
            // NOTE: serial/lot kimi sahələr varsa, buraya əlavə et.
            for (int i = 0; i < gV_InvoiceLine.DataRowCount; i++)
            {
                string productCode = gV_InvoiceLine.GetRowCellValue(i, nameof(TrInvoiceLine.ProductCode))?.ToString();
                if (!string.Equals(productCode, dcProduct.ProductCode, StringComparison.OrdinalIgnoreCase))
                    continue;

                decimal price = Convert.ToDecimal(gV_InvoiceLine.GetRowCellValue(i, nameof(TrInvoiceLine.Price)) ?? 0m);
                decimal rowDiscount = Convert.ToDecimal(gV_InvoiceLine.GetRowCellValue(i, nameof(TrInvoiceLine.PosDiscount)) ?? 0m);
                string rowSalesman = gV_InvoiceLine.GetRowCellValue(i, nameof(TrInvoiceLine.SalesPersonCode))?.ToString();

                // yeni sətr üçün gözlənilən dəyərlər (səndə AddNewRow bunları yazır)
                string newSalesman = salesman ?? "";

                // Əgər qiymət/satıcı fərqlidirsə -> merge etmə
                if (price != dcProduct.RetailPrice) continue;
                if (!string.Equals(rowSalesman ?? "", newSalesman, StringComparison.OrdinalIgnoreCase)) continue;

                // discount fərqlidirsə merge etməsin (istəsən bunu də deaktiv edərik)
                if (rowDiscount != 0m) continue;

                // ✅ uyğun sətr tapıldı -> qty artır
                decimal oldQty = Convert.ToDecimal(gV_InvoiceLine.GetRowCellValue(i, nameof(TrInvoiceLine.QtyOut)) ?? 0m);
                decimal newQty = oldQty + qty;

                gV_InvoiceLine.SetRowCellValue(i, nameof(TrInvoiceLine.QtyOut), newQty);

                // Əgər Amount/NetAmount manual hesablanırsa, RefreshData kifayət edir.
                gV_InvoiceLine.RefreshData();
                gV_InvoiceLine.FocusedRowHandle = i;
                gV_InvoiceLine.MoveLast();

                return true;
            }

            return false;
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
                    string? salesmanCode = null;

                    if (permitNegativeStock)
                        balance = null;

                    if (Settings.Default.AppSetting.POSShowQuantityDialog)
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

                    if (Settings.Default.AppSetting.POSShowSalesmanCodeDialog)
                    {
                        salesmanCode = InputSalesMan();
                    }

                    if (!TryMergeSameProduct(formProductList.dcProduct, qty, salesmanCode))
                    {
                        AddNewRow(formProductList.dcProduct, qty, salesmanCode);
                    }

                    SaveInvoice();
                }
            }
        }



        private void AddNewRow(DcProduct dcProduct, decimal qty, string? salesman)
        {
            gV_InvoiceLine.AddNewRow();

            gV_InvoiceLine.SetFocusedRowCellValue(colProductCode, dcProduct.ProductCode);
            gV_InvoiceLine.SetFocusedRowCellValue(col_Price, dcProduct.RetailPrice);
            gV_InvoiceLine.SetFocusedRowCellValue(colQtyOut, qty);
            gV_InvoiceLine.SetFocusedRowCellValue(colProductCost, dcProduct.ProductCost);
            gV_InvoiceLine.SetFocusedRowCellValue(col_SalesPersonCode, salesman);

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

        private async void btn_Payment_Click(object sender, EventArgs e)
        {
            var summaryValue = gV_InvoiceLine.Columns[nameof(TrInvoiceLine.NetAmount)]
                .SummaryItem?.SummaryValue;

            decimal summaryNetAmount = summaryValue == null
                ? 0m
                : Convert.ToDecimal(summaryValue);

            if (summaryNetAmount <= 0)
            {
                XtraMessageBox.Show(
                    Resources.Form_RetailSale_PaymentZero,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (sender is not SimpleButton simpleButton)
                return;

            var paymentType = simpleButton.Name switch
            {
                "btn_Cash" => PaymentType.Cash,
                "btn_Cashless" => PaymentType.Cashless,
                "btn_CustomerBonus" => PaymentType.Bonus,
                _ => default(PaymentType)     // or: _ => (PaymentType)0
            };

            using var formPayment = new FormPayment(
                paymentType,
                summaryNetAmount,
                trInvoiceHeader,
                new[] { PaymentType.Cash, PaymentType.Cashless, PaymentType.Bonus, PaymentType.Commission },
                loyaltyCard);

            if (formPayment.ShowDialog(this) != DialogResult.OK)
                return;

            efMethods.UpdateInvoiceIsCompleted(trInvoiceHeader.InvoiceHeaderId);

            if (Settings.Default.AppSetting.AutoPrint)
            {
                string printerName = string.IsNullOrWhiteSpace(settingStore.PrinterName)
                    ? new PrinterSettings().PrinterName
                    : settingStore.PrinterName;

                await PrintFast(printerName);
            }

            CalcPaidAmount();
            ClearControlsAddNew();
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

            bool useProductCode = POSFindProductByContainsId(1);
            bool useBarCode = POSFindProductByContainsId(2);

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
                string? salesmanCode = null;

                if (permitNegativeStock)
                    balance = null;

                if (Settings.Default.AppSetting.POSShowQuantityDialog && dcProductByScale == null)
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

                if (Settings.Default.AppSetting.POSShowSalesmanCodeDialog)
                    salesmanCode = InputSalesMan();

                if (!TryMergeSameProduct(selectedProduct, qty, salesmanCode))
                {
                    AddNewRow(selectedProduct, qty, salesmanCode);
                }

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

        private string? InputSalesMan()
        {
            string identityCardNum = Interaction.InputBox(
                "Satıcı Kodu Daxil Edin:",
                "Satıcı",
                ""
            );

            if (string.IsNullOrEmpty(identityCardNum))
                return null;

            DcCurrAcc dcCurrAcc = efMethods.SelectSalesManByIdentityCard(identityCardNum);
            if (dcCurrAcc is not null)
                return dcCurrAcc.CurrAccCode;
            else
            {
                XtraMessageBox.Show(
                    Resources.Form_RetailSale_SalesPersonNotExists,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return null;
            }
        }
        private bool POSFindProductByContainsId(int id)
        {
            var text = POSFindProductByCheckedComboBoxEdit.EditValue?.ToString() ?? "";
            var set = text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(x => x.Trim())
                          .ToHashSet(StringComparer.OrdinalIgnoreCase);

            return set.Contains(id.ToString());
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

            // ✅ Bonus qazanma ledger-i (Earn) yaradılır / update olunur / silinir
            SyncLoyaltyEarn(trInvoiceHeader);

            dbContext.SaveChanges(Authorization.CurrAccCode);

            Tag = trInvoiceHeader.DocumentNumber;
        }

        private void SyncLoyaltyEarn(TrInvoiceHeader inv)
        {
            if (inv == null || inv.InvoiceHeaderId == Guid.Empty)
                return;

            if (loyaltyCard is null)
                return;

            // Bonus yalnız müştəri olan satışlarda
            if (string.IsNullOrWhiteSpace(inv.CurrAccCode))
            {
                RemoveEarnTxn(inv.InvoiceHeaderId);
                return;
            }

            // ✅ Burada öz qaydanı qoy:
            // məsələn yalnız satış (return deyil) üçün qazanılsın.
            // Return invoice-larda adətən bonus qazanılmır, əksinə əvvəl qazanılan geri alınır.
            bool isReturn = inv.IsReturn == true;

            decimal earnPercent = loyaltyCard.LoyaltyProgram.EarnPercent;
            if (earnPercent <= 0)
            {
                RemoveEarnTxn(inv.InvoiceHeaderId);
                return;
            }

            decimal summaryNetAmount = Convert.ToDecimal(
                gV_InvoiceLine.Columns[nameof(TrInvoiceLine.NetAmount)].SummaryItem.SummaryValue);

            decimal baseLoc = Math.Abs(summaryNetAmount);
            decimal earnLoc = Math.Round(baseLoc * earnPercent / 100m, 2);
            if (earnLoc <= 0)
            {
                RemoveEarnTxn(inv.InvoiceHeaderId);
                return;
            }

            // Return-dursa: əvvəl qazanılan bonusu geri al (mənfi yaz)
            LoyaltyTxnType txnType = isReturn ? LoyaltyTxnType.Reverse : LoyaltyTxnType.Earn;

            // ✅ Eyni invoice üçün Earn/Reverse təkrar yazılmasın deyə "sync" edirik
            var txn = dbContext.Set<TrLoyaltyTxn>()
                .FirstOrDefault(x => x.InvoiceHeaderId == inv.InvoiceHeaderId
                                     && (x.TxnType == LoyaltyTxnType.Earn || x.TxnType == LoyaltyTxnType.Reverse));

            if (txn == null)
            {
                txn = new TrLoyaltyTxn
                {
                    LoyaltyTxnId = Guid.NewGuid(),
                    InvoiceHeaderId = inv.InvoiceHeaderId,
                    CurrAccCode = inv.CurrAccCode,
                    LoyaltyCardId = loyaltyCard.LoyaltyCardId,
                    CreatedUserName = Authorization.CurrAccCode,
                    DocumentDate = inv.DocumentDate,
                };
                dbContext.Set<TrLoyaltyTxn>().Add(txn);
            }

            txn.TxnType = txnType;
            txn.Note = $"Invoice: {inv.DocumentNumber}";

            // İstəsən expireni də burada qoy:
            // txn.ExpireAt = DateTime.Today.AddDays(Settings.Default.AppSetting.BonusExpireDays);
        }

        private void RemoveEarnTxn(Guid invoiceHeaderId)
        {
            var txn = dbContext.Set<TrLoyaltyTxn>()
                .FirstOrDefault(x => x.InvoiceHeaderId == invoiceHeaderId
                                     && (x.TxnType == LoyaltyTxnType.Earn || x.TxnType == LoyaltyTxnType.Reverse));

            if (txn != null)
                dbContext.Set<TrLoyaltyTxn>().Remove(txn);
        }


        private void Btn_NewInvoice_Click(object sender, EventArgs e)
        {
            efMethods.UpdateInvoiceIsCompleted(trInvoiceHeader.InvoiceHeaderId);
            ClearControlsAddNew();
        }

        private void Btn_AddBasket_Click(object sender, EventArgs e)
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

        private void POSFindProductByCheckedComboBoxEdit_EditValueChanged(object sender, EventArgs e)
        {
            //Settings.Default.AppSetting.POSFindProductBy = POSFindProductByCheckedComboBoxEdit.EditValue?.ToString()?.Trim() ?? "";

            //efMethods.UpdateAppSettingPOSFindProductBy(Settings.Default.AppSetting.POSFindProductBy);
        }

        private void GV_InvoiceLine_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator) return;

            // data rows only (group rows are < 0)
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();

            // optional: header indicator text
            // else e.Info.DisplayText = "#";
        }


        private void Btn_LoyaltyCard_Click(object sender, EventArgs e)
        {
            string bonusCardNum = Interaction.InputBox(
                "Bonus Kart Daxil Edin:",
                "Bonus Kart",
                ""
            );

            if (string.IsNullOrEmpty(bonusCardNum))
                return;

            loyaltyCard = efMethods.SelectLoyalityCard(bonusCardNum);

            if (loyaltyCard is null)
            {
                XtraMessageBox.Show("Bonus Kartı tapılmadı!");
                return;
            }

            trInvoiceHeader.CurrAccCode = loyaltyCard.CurrAccCode;

            SaveInvoice();

            LoadCurrAcc();

        }
    }
}
