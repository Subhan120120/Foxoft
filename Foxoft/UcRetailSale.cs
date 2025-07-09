using DevExpress.DataAccess.Sql;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraRichEdit.Model;
using DevExpress.XtraSplashScreen;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics;
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

        }

        private void trInvoiceHeadersBindingSource_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
        {
            TrInvoiceHeader invoiceHeader = new();
            invoiceHeader.InvoiceHeaderId = invoiceHeaderId;
            string NewDocNum = efMethods.GetNextDocNum(true, "RS", "DocumentNumber", "TrInvoiceHeaders", 6);
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
                                    .ContinueWith(loadTask => trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());

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

            //dataLayoutControl1.IsValid(out List<string> errorList);

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
                efMethods.UpdateInvoiceIsSuspended(trInvoiceHeader.InvoiceHeaderId, true);                // delete incomplete invoice
        }

        private void gV_InvoiceLine_CalcPreviewText(object sender, CalcPreviewTextEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;

            string Barcode = view.GetRowCellDisplayText(e.RowHandle, view.Columns["Barcode"]);
            decimal PosDiscount = Convert.ToDecimal(view.GetRowCellDisplayText(e.RowHandle, view.Columns[nameof(TrInvoiceLine.PosDiscount)]));
            decimal Amount = Convert.ToDecimal(view.GetRowCellDisplayText(e.RowHandle, view.Columns[nameof(TrInvoiceLine.Amount)]));
            decimal NetAmount = Convert.ToDecimal(view.GetRowCellDisplayText(e.RowHandle, view.Columns[nameof(TrInvoiceLine.NetAmount)]));
            string SalesPersonCode = view.GetRowCellDisplayText(e.RowHandle, view.Columns[nameof(TrInvoiceLine.SalesPersonCode)]);
            string salesPersonDesc = efMethods.SelectEntityById<DcCurrAcc>(SalesPersonCode)?.CurrAccDesc;

            string strVatRate = view.GetRowCellDisplayText(e.RowHandle, view.Columns[nameof(TrInvoiceLine.VatRate)]);
            float VatRate = float.Parse(strVatRate);

            e.PreviewText = CustomExtensions.GetPreviewText(PosDiscount, Amount, NetAmount, VatRate, Barcode, salesPersonDesc);
        }

        private void btn_ProductSearch_Click(object sender, EventArgs e)
        {
            using (FormProductList formProductList = new(new byte[] { 1 }, false))
            {
                if (formProductList.ShowDialog(this) == DialogResult.OK)
                {
                    if (formProductList.dcProduct is null)
                    {
                        XtraMessageBox.Show("Məhsul əlavə edilə bilmədi");
                        return;
                    }

                    if (formProductList.dcProduct?.ProductTypeCode != 3) // product is not service product
                    {
                        string wareHouseCode = efMethods.SelectWarehouseByStore(Authorization.StoreCode);

                        bool permitNegativeStock = efMethods.SelectEntityById<DcWarehouse>(wareHouseCode).PermitNegativeStock;

                        decimal balance = CalcProductBalance(formProductList.dcProduct, wareHouseCode);

                        if (permitNegativeStock)
                            if (Convert.ToDecimal(1) > balance)
                            {
                                MessageBox.Show("Stokda miqdar yoxdur");
                                return;
                            }
                    }
                    AddNewRow(formProductList.dcProduct, 1);

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
            if (dcProduct is not null && !String.IsNullOrEmpty(dcProduct.ProductCode))
            {
                return efMethods.SelectProductBalance(dcProduct.ProductCode, wareHouse);
            }
            else return 0;
        }

        //private void InsertInvoiceHeader()
        //{
        //    trInvoiceHeader = new();
        //    trInvoiceHeader.InvoiceHeaderId = invoiceHeaderId;
        //    string NewDocNum = efMethods.GetNextDocNum(true, "RS", "DocumentNumber", "TrInvoiceHeaders", 6);
        //    trInvoiceHeader.DocumentNumber = NewDocNum;
        //    trInvoiceHeader.DocumentDate = DateTime.Now;
        //    trInvoiceHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
        //    trInvoiceHeader.ProcessCode = "RS";
        //    trInvoiceHeader.OfficeCode = Authorization.OfficeCode;
        //    trInvoiceHeader.StoreCode = Authorization.StoreCode;
        //    trInvoiceHeader.CreatedUserName = Authorization.CurrAccCode;
        //    trInvoiceHeader.IsMainTF = true;
        //    trInvoiceHeader.WarehouseCode = efMethods.SelectWarehouseByStore(Authorization.StoreCode);
        //    //trInvoiceHeader.CurrAccCode = dcCurrAcc.CurrAccCode;

        //    efMethods.InsertEntity<TrInvoiceHeader>(trInvoiceHeader);
        //}

        private void btn_CancelInvoice_Click(object sender, EventArgs e)
        {
            if (rowIndx >= 0)
            {
                DialogResult dialogResult = XtraMessageBox.Show("Silmək istədiyinizə əminmisiniz?", "Diqqət", MessageBoxButtons.YesNo);
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
                XtraMessageBox.Show("Faktura boşdur");
        }


        private void btn_DeleteLine_Click(object sender, EventArgs e)
        {
            if (gV_InvoiceLine.RowCount > 1)
            {
                DialogResult dialogResult = XtraMessageBox.Show("Silmək istədiyinizə əminmisiniz?", "Diqqət", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //Guid invoiceLineId = Guid.Parse(gV_InvoiceLine.GetRowCellValue(rowIndx, nameof(TrInvoiceLine.InvoiceLineId)).ToString());
                    //int result = efMethods.DeleteEntityById<TrInvoiceLine>(invoiceLineId);

                    //if (result >= 0)
                    //{
                    //    gC_InvoiceLine.DataSource = efMethods.SelectInvoiceLines(trInvoiceHeader.InvoiceHeaderId);
                    //    gV_InvoiceLine.MoveLast();
                    //}

                    gV_InvoiceLine.DeleteRow(gV_InvoiceLine.FocusedRowHandle);

                    SaveInvoice();
                }
            }
            else if (gV_InvoiceLine.RowCount == 1)
                XtraMessageBox.Show("Son Sətri Silmək Olmur.\nSilmək üçün çeki ləğv etməlisiniz!", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                XtraMessageBox.Show("Məhsul seçin", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btn_Discount_Click(object sender, EventArgs e)
        {
            bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, nameof(TrInvoiceLine.PosDiscount));
            if (!currAccHasClaims)
            {
                XtraMessageBox.Show("Yetkiniz Yoxdur", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (rowIndx >= 0) //if product selected
            {
                decimal PosDiscount = Convert.ToDecimal(gV_InvoiceLine.GetRowCellValue(rowIndx, nameof(TrInvoiceLine.PosDiscount)));
                decimal Amount = Convert.ToDecimal(gV_InvoiceLine.GetRowCellValue(rowIndx, nameof(TrInvoiceLine.Amount)));

                using (FormPosDiscount formPosDiscount = new(PosDiscount, Amount))
                {
                    if (formPosDiscount.ShowDialog(this) == DialogResult.OK)
                    {
                        object invoiceLineId = gV_InvoiceLine.GetRowCellValue(rowIndx, nameof(TrInvoiceLine.InvoiceLineId));

                        TrInvoiceLine trInvoiceLine = new()
                        {
                            InvoiceLineId = (Guid)invoiceLineId,
                            NetAmount = Amount - formPosDiscount.PosDiscount,
                            PosDiscount = formPosDiscount.PosDiscount
                        };
                        int result = efMethods.UpdateInvoiceLine_PosDiscount(trInvoiceLine);

                        if (result >= 0)
                        {
                            gC_InvoiceLine.DataSource = efMethods.SelectInvoiceLines(trInvoiceHeader.InvoiceHeaderId);
                            gV_InvoiceLine.MoveLast();
                        }
                    }
                }
            }
            else
                XtraMessageBox.Show("Məhsul seçin", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void gC_Sale_MouseUp(object sender, MouseEventArgs e)
        {
            txtEdit_Barcode.Focus();
        }

        private void btn_Payment_Click(object sender, EventArgs e)
        {
            decimal summaryNetAmount = Convert.ToDecimal(gV_InvoiceLine.Columns[nameof(TrInvoiceLine.NetAmount)].SummaryItem.SummaryValue);

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

                        if (Settings.Default.AppSetting.GetPrint == true)
                        {
                            string designPath = Settings.Default.AppSetting.PrintDesignPath;
                            if (!File.Exists(designPath))
                                designPath = reportClass.SelectDesign();

                            ReportPrintTool printTool = new(reportClass.CreateReport(efMethods.SelectInvoiceLineForReport(trInvoiceHeader.InvoiceHeaderId), designPath));
                            printTool.Print();
                        }

                        CalcPaidAmount();

                        ClearControlsAddNew();
                    }
                }
            }
            else XtraMessageBox.Show("Ödəmə 0a bərabərdir");
        }

        private void btn_CustomerAdd_Click(object sender, EventArgs e)
        {
            using (FormCurrAcc formCustomer = new((byte)1, true))
            {
                if (formCustomer.ShowDialog(this) == DialogResult.OK)
                {
                    //if (!efMethods.EntityExists<TrInvoiceHeader>(invoiceHeaderId)) //if invoiceHeader doesnt exist
                    //    InsertInvoiceHeader();

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
                        //if (!efMethods.EntityExists<TrInvoiceHeader>(invoiceHeaderId)) //if invoiceHeader doesnt exist
                        //    InsertInvoiceHeader();

                        //int result = efMethods.UpdateInvoiceCurrAccCode(invoiceHeaderId, formCustomer.dcCurrAcc.CurrAccCode);

                        //if (result >= 0)
                        //{
                        //    trInvoiceHeader.CurrAccCode = formCustomer.dcCurrAcc.CurrAccCode;
                        //    LoadCurrAcc();
                        //}

                        LoadCurrAcc();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Müştəri seçin");
                return; // return btn_Customer_Click
            }

        }


        private void btn_CustomerSearch_Click(object sender, EventArgs e)
        {
            using (FormCurrAccList form = new(new byte[] { 1, 2, 3 }, trInvoiceHeader.CurrAccCode))
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
                using (FormQty formQty = new())
                {
                    if (formQty.ShowDialog(this) == DialogResult.OK)
                    {
                        //object invoiceLineId = gV_InvoiceLine.GetRowCellValue(rowIndx, nameof(TrInvoiceLine.InvoiceLineId));

                        //efMethods.UpdateInvoiceLineQtyOut(invoiceLineId, formQty.qty);

                        //gC_InvoiceLine.DataSource = efMethods.SelectInvoiceLines(invoiceHeaderId);
                        //gV_InvoiceLine.MoveLast();

                        gV_InvoiceLine.SetRowCellValue(rowIndx, nameof(TrInvoiceLine.QtyOut), formQty.qty);
                        gV_InvoiceLine.RefreshData(); // footer yenilensin deye
                        SaveInvoice();
                    }
                }
        }

        private async void btn_Print_Click(object sender, EventArgs e)
        {
            await PrintFast(settingStore.PrinterName);
        }

        private async Task PrintFast(string printerName)
        {
            alertControl1.Show(this.ParentForm, "Print Göndərilir...", "Printer: " + printerName, "", (Image)null, null);

            if (trInvoiceHeader is not null)
                await Task.Run(() => GetPrint(trInvoiceHeader.InvoiceHeaderId, printerName));
            else MessageBox.Show("Çap olunmaq üçün qaimə yoxdur");

            Task task = Task.Run((Action)ShowPrintCount);

            alertControl1.Show(this.ParentForm, "Print Göndərildi.", "Printer: " + printerName, "", (Image)null, null);
        }

        private void ShowPrintCount()
        {
            int printCount = efMethods.SelectEntityById<TrInvoiceHeader>(trInvoiceHeader?.InvoiceHeaderId).PrintCount;

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
                MessageBox.Show("Yetkiniz yoxdur! ");
                return;
            }

            foreach (var item in dcReport.DcReportVariables.Where(x => x.ReportId == dcReport.ReportId))
            {
                if (item.VariableProperty == "StartDate")
                {
                    item.VariableValue = DateTime.Now.ToString("yyyy-MM-dd");

                    //efMethods.UpdateDcReportVariable_Value(item.ReportId, item.VariableProperty, item.VariableValue);
                }
                else if (item.VariableProperty == "EndDate")
                {
                    item.VariableValue = DateTime.Now.ToString("yyyy-MM-dd");

                    //efMethods.UpdateDcReportVariable_Value(item.ReportId, item.VariableProperty, item.VariableValue);
                }
            }

            reportClass.ShowReport(dcReport, "");

            //ShowReportForm(dcReport, "", "");
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
                using (FormCurrAccList form = new(new byte[] { 3 }))
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        Guid invoiceLineId = (Guid)gV_InvoiceLine.GetRowCellValue(rowIndx, nameof(TrInvoiceLine.InvoiceLineId));
                        efMethods.UpdateInvoiceSalesPerson(invoiceLineId, form.dcCurrAcc.CurrAccCode);
                        gC_InvoiceLine.DataSource = efMethods.SelectInvoiceLines(invoiceHeaderId);
                        gV_InvoiceLine.MoveLast();
                    }
                }
            }
            else
                XtraMessageBox.Show("Məhsul Seçin");
        }

        private void gV_InvoiceLine_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
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
            DcProduct dcProductByBarcode = efMethods.SelectProductByBarcode(input);

            decimal qty = 0;
            DcProduct dcProductByScale = null;

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
                qty = int.Parse(input.Substring(7, 6)) / 10000m; //2 000003 02.0000
            }

            if (dcProductByBarcode != null && dcProductByScale != null)
            {
                using var formProductList = new FormProductList(new byte[] { 1 }, false, new[] { dcProductByBarcode.ProductCode, dcProductByScale.ProductCode });
                if (formProductList.ShowDialog(this) == DialogResult.OK)
                {
                    selectedProduct = formProductList.dcProduct;

                    if (selectedProduct?.ProductCode == dcProductByBarcode.ProductCode)
                        qty = dcProductByBarcode.TrProductBarcodes.FirstOrDefault().Qty;
                    else if (selectedProduct?.ProductCode == dcProductByScale.ProductCode)
                        qty = int.Parse(input.Substring(7, 6)) / 10000m; //2 000003 02.0000
                }
            }

            if (selectedProduct != null)
            {
                AddNewRow(selectedProduct, qty);
                SaveInvoice();
                txtEdit_Barcode.EditValue = string.Empty;
            }
            else
            {
                XtraMessageBox.Show("Barkod Tapılmadı", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            ActiveControl = txtEdit_Barcode;
        }

        private void GV_InvoiceLine_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column == colProductCode)
            {
                var row = gV_InvoiceLine.GetRow(e.RowHandle) as TrInvoiceLine;

                if (row != null)
                {
                    row.DcProduct = dbContext.DcProducts.FirstOrDefault(x => x.ProductCode == row.ProductCode);

                    //if (tracked == null) // already tracked xetasi vermesin deye
                    //    dbContext.Attach(tracked); // dbsavechanges eliyende dcproductu insert elemeye calismasin deye

                    //gV_InvoiceLine.RefreshRow(e.RowHandle); // Refresh to show ProductDesc
                }
            }
        }

        private void SaveInvoice()
        {
            dbContext.SaveChanges(Authorization.CurrAccCode);

            trInvoiceHeader = trInvoiceHeadersBindingSource.Current as TrInvoiceHeader;

            Tag = trInvoiceHeader.DocumentNumber;

            //dbContext = new subContext();
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
            decimal cashSum = efMethods.SelectPaymentLinesCashSumByInvoice(trInvoiceHeader.InvoiceHeaderId, trInvoiceHeader.CurrAccCode);
            lbl_InvoicePaidCashSum.Text = Math.Round(cashSum, 2).ToString() + " " + Settings.Default.AppSetting.LocalCurrencyCode;

            decimal cashlessSum = efMethods.SelectPaymentLinesCashlessSumByInvoice(trInvoiceHeader.InvoiceHeaderId, trInvoiceHeader.CurrAccCode);
            lbl_InvoicePaidCashlessSum.Text = Math.Round(cashlessSum, 2).ToString() + " " + Settings.Default.AppSetting.LocalCurrencyCode;

            decimal totalSum = efMethods.SelectPaymentLinesSumByInvoice(trInvoiceHeader.InvoiceHeaderId, trInvoiceHeader.CurrAccCode);
            lbl_InvoicePaidTotalSum.Text = Math.Round(totalSum, 2).ToString() + " " + Settings.Default.AppSetting.LocalCurrencyCode;
        }
    }
}
