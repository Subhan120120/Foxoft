using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Foxoft
{
    public partial class UcRetailSale : XtraUserControl
    {
        public Guid invoiceHeaderId = Guid.NewGuid();
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

            ActiveControl = txtEdit_Barcode;

            settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);
            reportClass = new ReportClass(settingStore.DesignFileFolder);
        }

        private void UcRetailSale_Load(object sender, EventArgs e)
        {
            this.ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing); // set Parent Form Closing event

            LoadCurrAcc();
        }

        private void LoadCurrAcc()
        {
            dbContext = new subContext();

            if (string.IsNullOrEmpty(trInvoiceHeader.CurrAccCode))
            {
                string defaultCustomer = efMethods.SelectDefaultCustomerByStore(Authorization.StoreCode);
                trInvoiceHeader.CurrAccCode = defaultCustomer;
            }

            dbContext.DcCurrAccs.Where(x => x.CurrAccCode == trInvoiceHeader.CurrAccCode)
                .Load();
            dcCurrAccBindingSource.DataSource = dbContext.DcCurrAccs.Local.ToBindingList();
        }

        private void dcCurrAccBindingSource_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
        {

        }

        void ParentForm_FormClosing(object sender, FormClosingEventArgs e) // Parent Form Closing event
        {
            if (efMethods.EntityExists<TrInvoiceHeader>(invoiceHeaderId))
                efMethods.DeleteInvoice(invoiceHeaderId);                // delete incomplete invoice
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
            String salesPersonDesc = efMethods.SelectEntityById<DcCurrAcc>(SalesPersonCode)?.CurrAccDesc;

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
                    if (!efMethods.EntityExists<TrInvoiceHeader>(invoiceHeaderId)) //if invoiceHeader doesnt exist
                        InsertInvoiceHeader();

                    DcProduct DcProduct = formProductList.dcProduct;
                    int result = efMethods.InsertInvoiceLine(DcProduct, invoiceHeaderId, 1);

                    if (result > 0)
                    {
                        gC_InvoiceLine.DataSource = efMethods.SelectInvoiceLines(invoiceHeaderId);
                        gV_InvoiceLine.MoveLast();
                    }
                    else
                        XtraMessageBox.Show("Məhsul əlavə edilə bilmədi");
                }
            }
        }

        private void InsertInvoiceHeader()
        {
            trInvoiceHeader = new();
            trInvoiceHeader.InvoiceHeaderId = invoiceHeaderId;
            string NewDocNum = efMethods.GetNextDocNum(true, "RS", "DocumentNumber", "TrInvoiceHeaders", 6);
            trInvoiceHeader.DocumentNumber = NewDocNum;
            trInvoiceHeader.DocumentDate = DateTime.Now;
            trInvoiceHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            trInvoiceHeader.ProcessCode = "RS";
            trInvoiceHeader.OfficeCode = Authorization.OfficeCode;
            trInvoiceHeader.StoreCode = Authorization.StoreCode;
            trInvoiceHeader.CreatedUserName = Authorization.CurrAccCode;
            trInvoiceHeader.IsMainTF = true;
            trInvoiceHeader.WarehouseCode = efMethods.SelectWarehouseByStore(Authorization.StoreCode);
            trInvoiceHeader.CurrAccCode = dcCurrAcc.CurrAccCode;

            efMethods.InsertEntity<TrInvoiceHeader>(trInvoiceHeader);
        }

        private void btn_CancelInvoice_Click(object sender, EventArgs e)
        {
            if (rowIndx >= 0)
            {
                DialogResult dialogResult = XtraMessageBox.Show("Silmək istədiyinizə əminmisiniz?", "Diqqət", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int result = efMethods.DeleteInvoice(invoiceHeaderId);

                    if (result >= 0)
                    {
                        gC_InvoiceLine.DataSource = efMethods.SelectInvoiceLines(invoiceHeaderId);
                        invoiceHeaderId = Guid.NewGuid();
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
                    Guid invoiceLineId = Guid.Parse(gV_InvoiceLine.GetRowCellValue(rowIndx, nameof(TrInvoiceLine.InvoiceLineId)).ToString());
                    int result = efMethods.DeleteEntityById<TrInvoiceLine>(invoiceLineId);

                    if (result >= 0)
                    {
                        gC_InvoiceLine.DataSource = efMethods.SelectInvoiceLines(invoiceHeaderId);
                        gV_InvoiceLine.MoveLast();
                    }
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
                            gC_InvoiceLine.DataSource = efMethods.SelectInvoiceLines(invoiceHeaderId);
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
                        efMethods.UpdateInvoiceIsCompleted(invoiceHeaderId);

                        if (Settings.Default.AppSetting.GetPrint == true)
                        {
                            string designPath = Settings.Default.AppSetting.PrintDesignPath;
                            if (!File.Exists(designPath))
                                designPath = reportClass.SelectDesign();

                            ReportPrintTool printTool = new(reportClass.CreateReport(efMethods.SelectInvoiceLineForReport(invoiceHeaderId), designPath));
                            printTool.Print();
                        }

                        invoiceHeaderId = Guid.NewGuid();
                        gC_InvoiceLine.DataSource = efMethods.SelectInvoiceLines(invoiceHeaderId); // sifirlamaq
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
                    if (!efMethods.EntityExists<TrInvoiceHeader>(invoiceHeaderId)) //if invoiceHeader doesnt exist
                        InsertInvoiceHeader();

                    int result = efMethods.UpdateInvoiceCurrAccCode(invoiceHeaderId, formCustomer.dcCurrAcc.CurrAccCode);

                    if (result >= 0)
                    {
                        trInvoiceHeader.CurrAccCode = formCustomer.dcCurrAcc.CurrAccCode;
                        LoadCurrAcc();
                    }
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
                        if (!efMethods.EntityExists<TrInvoiceHeader>(invoiceHeaderId)) //if invoiceHeader doesnt exist
                            InsertInvoiceHeader();

                        int result = efMethods.UpdateInvoiceCurrAccCode(invoiceHeaderId, formCustomer.dcCurrAcc.CurrAccCode);

                        if (result >= 0)
                        {
                            trInvoiceHeader.CurrAccCode = formCustomer.dcCurrAcc.CurrAccCode;
                            LoadCurrAcc();
                        }
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
            using (FormCurrAccList form = new(new byte[] { 1 }, trInvoiceHeader.CurrAccCode))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    trInvoiceHeader.CurrAccCode = form.dcCurrAcc.CurrAccCode;
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
                        object invoiceLineId = gV_InvoiceLine.GetRowCellValue(rowIndx, nameof(TrInvoiceLine.InvoiceLineId));
                        efMethods.UpdateInvoiceLineQtyOut(invoiceLineId, formQty.qty);
                        gC_InvoiceLine.DataSource = efMethods.SelectInvoiceLines(invoiceHeaderId);
                        gV_InvoiceLine.MoveLast();
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
            DcReport dcReport = efMethods.SelectReportByName("Gun Sonu");

            foreach (var item in dcReport.DcReportVariables)
                if (item.VariableProperty == nameof(TrInvoiceHeader.InvoiceHeaderId))
                    item.VariableValue = trInvoiceHeader.InvoiceHeaderId.ToString();

            FormReportPreview form = new(dcReport.ReportQuery, "", dcReport);
            form.WindowState = FormWindowState.Maximized;
            form.Show();
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
            if (txtEdit_Barcode.EditValue == null)
                return;

            string barcode = txtEdit_Barcode.EditValue.ToString()?.Trim() ?? "";
            if (string.IsNullOrEmpty(barcode))
                return;

            DcProduct dcProductByBarcode = efMethods.SelectProductByBarcode(barcode);
            DcProduct dcProductScales = null;
            decimal qty = 0;

            if (barcode.Length == 13 && barcode.All(char.IsDigit))
            {
                int productId = int.Parse(barcode.Substring(1, 6));
                dcProductScales = efMethods.SelectProductById(productId);
                qty = int.Parse(barcode.Substring(7, 6)) / 10m;
            }

            DcProduct selectedProduct = dcProductByBarcode ?? dcProductScales;

            if (dcProductByBarcode != null && dcProductScales != null)
            {
                using var formProductList = new FormProductList(new byte[] { 1 }, false, new[] { dcProductByBarcode.ProductCode, dcProductScales.ProductCode });
                if (formProductList.ShowDialog(this) == DialogResult.OK)
                {
                    selectedProduct = formProductList.dcProduct;

                    if (selectedProduct?.ProductCode == dcProductByBarcode.ProductCode)
                        qty = dcProductByBarcode.TrProductBarcodes.FirstOrDefault()?.Qty ?? qty;
                }
            }

            if (selectedProduct != null)
            {
                if (!efMethods.EntityExists<TrInvoiceHeader>(invoiceHeaderId))
                    InsertInvoiceHeader();

                if (efMethods.InsertInvoiceLine(selectedProduct, invoiceHeaderId, qty) > 0)
                {
                    gC_InvoiceLine.DataSource = efMethods.SelectInvoiceLines(invoiceHeaderId);
                    gV_InvoiceLine.MoveLast();
                    txtEdit_Barcode.EditValue = string.Empty;
                }
            }
            else
            {
                XtraMessageBox.Show("Barkod Tapılmadı", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            ActiveControl = txtEdit_Barcode;
        }

    }
}
