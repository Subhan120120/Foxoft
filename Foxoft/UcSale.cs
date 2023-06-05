using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class UcSale : XtraUserControl
    {
        public Guid invoiceHeaderId = Guid.NewGuid();
        public int rowIndx = (-1);                      // setting by "FocusedRowChanged" event
        EfMethods efMethods = new EfMethods();
        AdoMethods adoMethods = new AdoMethods();
        DsMethods dsMethods = new DsMethods();
        ReportClass reportClass = new ReportClass();

        public UcSale()
        {
            InitializeComponent();
            btn_CustomerAdd.BorderStyle = BorderStyles.UltraFlat;
            btn_CustomerSearch.BorderStyle = BorderStyles.UltraFlat;
            btn_CustomerEdit.BorderStyle = BorderStyles.UltraFlat;

            ActiveControl = txtEdit_Barcode;
        }

        private void UcSale_Load(object sender, EventArgs e)
        {
            this.ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing); // set Parent Form Closing event
        }
        void ParentForm_FormClosing(object sender, FormClosingEventArgs e) // Parent Form Closing event
        {
            if (efMethods.InvoiceHeaderExist(invoiceHeaderId))
                efMethods.DeleteInvoice(invoiceHeaderId);                // delete incomplete invoice
        }

        private void gV_InvoiceLine_CalcPreviewText(object sender, CalcPreviewTextEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;

            string Barcode = view.GetRowCellDisplayText(e.RowHandle, view.Columns["Barcode"]);
            decimal PosDiscount = Convert.ToDecimal(view.GetRowCellDisplayText(e.RowHandle, view.Columns["PosDiscount"]));
            decimal Amount = Convert.ToDecimal(view.GetRowCellDisplayText(e.RowHandle, view.Columns["Amount"]));
            decimal NetAmount = Convert.ToDecimal(view.GetRowCellDisplayText(e.RowHandle, view.Columns["NetAmount"]));
            string SalesPersonCode = view.GetRowCellDisplayText(e.RowHandle, view.Columns["SalesPersonCode"]);
            string strVatRate = view.GetRowCellDisplayText(e.RowHandle, view.Columns["VatRate"]);
            float VatRate = float.Parse(strVatRate);

            e.PreviewText = CustomExtensions.GetPreviewText(PosDiscount, Amount, NetAmount, VatRate, Barcode, SalesPersonCode);
        }

        private void btn_ProductSearch_Click(object sender, EventArgs e)
        {
            using (FormProductList formProductList = new FormProductList(new byte[] { 1 }))
            {
                if (formProductList.ShowDialog(this) == DialogResult.OK)
                {
                    if (!efMethods.InvoiceHeaderExist(invoiceHeaderId)) //if invoiceHeader doesnt exist
                    {
                        string NewDocNum = efMethods.GetNextDocNum(true, "RS", "DocumentNumber", "TrInvoiceHeaders", 6);

                        TrInvoiceHeader TrInvoiceHeader = new TrInvoiceHeader()
                        {
                            InvoiceHeaderId = invoiceHeaderId,
                            ProcessCode = "RS",
                            DocumentNumber = NewDocNum,
                            DocumentDate = DateTime.Now,
                            DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
                        };
                        efMethods.InsertInvoiceHeader(TrInvoiceHeader);
                    }

                    DcProduct DcProduct = formProductList.dcProduct;
                    int result = efMethods.InsertInvoiceLine(DcProduct, invoiceHeaderId);

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
                    object invoiceLineId = gV_InvoiceLine.GetRowCellValue(rowIndx, "InvoiceLineId");
                    int result = efMethods.DeleteInvoiceLine(invoiceLineId);

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
            if (Authorization.Authorized("Admin"))
            {
                if (rowIndx >= 0)                           //if product selected
                {
                    decimal PosDiscount = Convert.ToDecimal(gV_InvoiceLine.GetRowCellValue(rowIndx, "PosDiscount"));
                    decimal Amount = Convert.ToDecimal(gV_InvoiceLine.GetRowCellValue(rowIndx, "Amount"));

                    using (FormPosDiscount formPosDiscount = new FormPosDiscount(PosDiscount, Amount))
                    {
                        if (formPosDiscount.ShowDialog(this) == DialogResult.OK)
                        {
                            object invoiceLineId = gV_InvoiceLine.GetRowCellValue(rowIndx, "InvoiceLineId");

                            TrInvoiceLine TrInvoiceLine = new TrInvoiceLine()
                            {
                                InvoiceLineId = (Guid)invoiceLineId,
                                NetAmount = Amount - formPosDiscount.PosDiscount,
                                PosDiscount = formPosDiscount.PosDiscount
                            };
                            int result = efMethods.UpdateInvoicePosDiscount(TrInvoiceLine);

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
            else
                XtraMessageBox.Show("Yetkiniz Yoxdur", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btn_Num_Click(object sender, EventArgs e)
        {
            SimpleButton simpleButton = sender as SimpleButton;
            string key = simpleButton.Text;

            switch (key)
            {
                case "←":
                    SendKeys.Send("{BACKSPACE}");
                    break;
                case "C":
                    SendKeys.Send("^A");
                    SendKeys.Send("{BACKSPACE}");
                    break;
                default:
                    SendKeys.Send(key);
                    break;
            }
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            if (txtEdit_Barcode.EditValue != null)
            {
                DcProduct DcProduct = new DcProduct { Barcode = txtEdit_Barcode.EditValue.ToString() };

                if (!efMethods.InvoiceHeaderExist(invoiceHeaderId)) //if invoiceHeader doesnt exist
                {
                    string NewDocNum = efMethods.GetNextDocNum(true, "RS", "DocumentNumber", "TrInvoiceHeaders", 6);
                    TrInvoiceHeader TrInvoiceHeader = new TrInvoiceHeader()
                    {
                        InvoiceHeaderId = invoiceHeaderId,
                        ProcessCode = "RS",
                        DocumentNumber = NewDocNum,
                    };
                    efMethods.InsertInvoiceHeader(TrInvoiceHeader);
                }
                int result = efMethods.InsertInvoiceLine(DcProduct, invoiceHeaderId);

                if (result > 0)
                {
                    gC_InvoiceLine.DataSource = efMethods.SelectInvoiceLines(invoiceHeaderId);
                    gV_InvoiceLine.MoveLast();
                    txtEdit_Barcode.EditValue = string.Empty;
                }
                else
                    XtraMessageBox.Show("Barkod Tapılmadı", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ActiveControl = txtEdit_Barcode;
        }

        private void gC_Sale_MouseUp(object sender, MouseEventArgs e)
        {
            txtEdit_Barcode.Focus();
        }

        private void btn_Payment_Click(object sender, EventArgs e)
        {
            decimal summaryNetAmount = Convert.ToDecimal(gV_InvoiceLine.Columns["NetAmount"].SummaryItem.SummaryValue);

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

                using (FormPayment formPayment = new FormPayment(paymentType, summaryNetAmount, new TrInvoiceHeader() { }))
                {
                    if (formPayment.ShowDialog(this) == DialogResult.OK)
                    {
                        efMethods.UpdateInvoiceIsCompleted(invoiceHeaderId);

                        if (Settings.Default.AppSetting.GetPrint == true)
                        {
                            string designPath = Settings.Default.AppSetting.PrintDesignPath;
                            if (!File.Exists(designPath))
                                designPath = reportClass.SelectDesign();

                            ReportPrintTool printTool = new ReportPrintTool(reportClass.CreateReport(efMethods.SelectInvoiceLineForReport(invoiceHeaderId), designPath));
                            printTool.Print();
                        }

                        invoiceHeaderId = Guid.NewGuid();
                        gC_InvoiceLine.DataSource = efMethods.SelectInvoiceLines(invoiceHeaderId); // sifirlamaq
                    }
                }
            }
            else XtraMessageBox.Show("Ödəmə 0a bərabərdir");
        }

        private void btn_Customer_Click(object sender, EventArgs e)
        {
            SimpleButton simpleButton = (SimpleButton)sender;
            DcCurrAcc DcCurrAcc = new DcCurrAcc();

            if (simpleButton.Name == "btn_CustomerEdit")
            {
                if (!string.IsNullOrEmpty(txtEdit_CustomerCode.Text))
                {
                    string currAccCode = txtEdit_CustomerCode.Text;
                    DcCurrAcc = efMethods.SelectCurrAcc(currAccCode);
                }
                else
                {
                    XtraMessageBox.Show("Müştəri seçin");
                    return; // return btn_Customer_Click
                }
            }

            using (FormCustomer formCustomer = new FormCustomer(DcCurrAcc))
            {
                if (formCustomer.ShowDialog(this) == DialogResult.OK)
                {
                    if (!efMethods.InvoiceHeaderExist(invoiceHeaderId)) //if invoiceHeader doesnt exist
                    {
                        string NewDocNum = efMethods.GetNextDocNum(true, "RS", "DocumentNumber", "TrInvoiceHeaders", 6);
                        TrInvoiceHeader TrInvoiceHeader = new TrInvoiceHeader()
                        {
                            InvoiceHeaderId = invoiceHeaderId,
                            ProcessCode = "RS",
                            DocumentNumber = NewDocNum,
                        };
                        efMethods.InsertInvoiceHeader(TrInvoiceHeader);
                    }

                    int result = efMethods.UpdateInvoiceCurrAccCode(invoiceHeaderId, formCustomer.DcCurrAcc.CurrAccCode);

                    if (result >= 0)
                    {
                        txtEdit_CustomerCode.EditValue = formCustomer.DcCurrAcc.CurrAccCode;
                        txtEdit_BonCardNum.EditValue = formCustomer.DcCurrAcc.BonusCardNum;
                        txtEdit_CustomerName.EditValue = formCustomer.DcCurrAcc.FirstName + " " + formCustomer.DcCurrAcc.LastName;
                        txtEdit_CustomerAddress.EditValue = formCustomer.DcCurrAcc.Address;
                        txtEdit_CustomerPhoneNum.EditValue = formCustomer.DcCurrAcc.PhoneNum;
                    }
                }
            }
        }

        private void btn_CustomerSearch_Click(object sender, EventArgs e)
        {
            using (FormCurrAccList form = new FormCurrAccList(1))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (!efMethods.InvoiceHeaderExist(invoiceHeaderId)) //if invoiceHeader doesnt exist
                    {
                        string NewDocNum = efMethods.GetNextDocNum(true, "RS", "DocumentNumber", "TrInvoiceHeaders", 6);
                        TrInvoiceHeader TrInvoiceHeader = new TrInvoiceHeader()
                        {
                            InvoiceHeaderId = invoiceHeaderId,
                            ProcessCode = "RS",
                            DocumentNumber = NewDocNum,
                        };
                        efMethods.InsertInvoiceHeader(TrInvoiceHeader);
                    }

                    int result = efMethods.UpdateInvoiceCurrAccCode(invoiceHeaderId, form.dcCurrAcc.CurrAccCode);

                    if (result >= 0)
                    {
                        txtEdit_CustomerCode.EditValue = form.dcCurrAcc.CurrAccCode;
                        txtEdit_BonCardNum.EditValue = form.dcCurrAcc.BonusCardNum;
                        txtEdit_CustomerName.EditValue = form.dcCurrAcc.FirstName + " " + form.dcCurrAcc.LastName;
                        txtEdit_CustomerAddress.EditValue = form.dcCurrAcc.Address;
                        txtEdit_CustomerPhoneNum.EditValue = form.dcCurrAcc.PhoneNum;
                    }
                }
            }
        }

        private void gC_Sale_DoubleClick(object sender, EventArgs e)
        {
            if (gV_InvoiceLine.FocusedColumn == col_Qty)
            {
                using (FormQty formQty = new FormQty())
                {
                    if (formQty.ShowDialog(this) == DialogResult.OK)
                    {
                        object invoiceLineId = gV_InvoiceLine.GetRowCellValue(rowIndx, "InvoiceLineId");
                        efMethods.UpdateInvoiceLineQtyOut(invoiceLineId, formQty.qty);
                        gC_InvoiceLine.DataSource = efMethods.SelectInvoiceLines(invoiceHeaderId);
                        gV_InvoiceLine.MoveLast();
                    }
                }
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            string designPath = Settings.Default.AppSetting.PrintDesignPath;

            if (!File.Exists(designPath))
                designPath = reportClass.SelectDesign();

            ReportPrintTool printTool = new ReportPrintTool(reportClass.CreateReport(efMethods.SelectInvoiceLineForReport(invoiceHeaderId), designPath));
            printTool.ShowPreview();

        }

        private void btn_PrintDesign_Click(object sender, EventArgs e)
        {
            string designPath = Settings.Default.AppSetting.PrintDesignPath;

            if (!File.Exists(designPath))
                designPath = reportClass.SelectDesign();

            ReportDesignTool designTool = new ReportDesignTool(reportClass.CreateReport(efMethods.SelectInvoiceLineForReport(invoiceHeaderId), designPath));
            designTool.ShowRibbonDesignerDialog();

        }

        private string subConnString = ConfigurationManager
                       .OpenExeConfiguration(ConfigurationUserLevel.None)
                       .ConnectionStrings
                       .ConnectionStrings["subConnString"]
                       .ConnectionString;

        private void btn_ReportZ_Click(object sender, EventArgs e)
        {
            //object[] objInvoiceHeaders = efMethods.SelectInvoiceLineForReport(invoiceHeaderId).Cast<object>().ToArray();

            //DataTable trInvoiceLines = adoMethods.SelectInvoiceLines(DateTime.Now.Date, DateTime.Now.Date);
            //DataTable trPaymentLines = adoMethods.SelectPaymentLines(DateTime.Now.Date, DateTime.Now.Date);

            //DataSet dataSet = new DataSet("GunSonu");
            //dataSet.Tables.AddRange(new DataTable[] { trInvoiceLines, trPaymentLines });

            SqlDataSource dataSource = new SqlDataSource(new CustomStringConnectionParameters(subConnString));
            dataSource.Name = "GunSonu";

            //SqlQuery sqlQueryPurchases = dsMethods.SelectPurchases(DateTime.Now.Date, DateTime.Now.Date);
            SqlQuery sqlQuerySale = dsMethods.SelectSales(DateTime.Now.Date, DateTime.Now.Date);
            SqlQuery sqlQueryPayment = dsMethods.SelectPayments(DateTime.Now.Date, DateTime.Now.Date);
            SqlQuery sqlQueryExpences = dsMethods.SelectExpences(DateTime.Now.Date, DateTime.Now.Date);


            dataSource.Queries.AddRange(new SqlQuery[] { sqlQuerySale, sqlQueryPayment, sqlQueryExpences });
            dataSource.Fill();

            string designPath = Settings.Default.AppSetting.PrintDesignPath;
            if (!File.Exists(designPath))
                designPath = reportClass.SelectDesign();
            ReportDesignTool designTool = new ReportDesignTool(reportClass.CreateReport(dataSource, designPath));
            designTool.ShowRibbonDesignerDialog();

        }

        private void btn_SalesPerson_Click(object sender, EventArgs e)
        {
            if (rowIndx >= 0)
            {
                using (FormCurrAccList form = new FormCurrAccList(1))
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        Guid invoiceLineId = (Guid)gV_InvoiceLine.GetRowCellValue(rowIndx, "InvoiceLineId");
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
    }
}
