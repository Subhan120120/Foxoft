using DevExpress.Data;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormPaymentDetail : RibbonForm
    {
        private TrPaymentHeader trPaymentHeader;
        private EfMethods efMethods = new();
        private subContext dbContext;
        private Guid paymentHeaderId;

        public FormPaymentDetail()
        {
            InitializeComponent();

            StoreCodeLookUpEdit.Properties.DataSource = efMethods.SelectStores();
            repoLUE_CurrencyCode.DataSource = efMethods.SelectCurrencies();
            repoLUE_PaymentTypeCode.DataSource = efMethods.SelectPaymentTypes();

            ClearControlsAddNew();

            bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "PaymentDetail");
            if (!currAccHasClaims)
            {
                MessageBox.Show("Yetkiniz yoxdur! ");
                return;
            }
            else
                this.Show();
        }

        public FormPaymentDetail(Guid paymentHeaderId)
            : this()
        {
            trPaymentHeader = efMethods.SelectPaymentHeader(paymentHeaderId);

            if (trPaymentHeader is not null)
            {
                LoadPayment(trPaymentHeader.PaymentHeaderId);
            }
        }

        private void ClearControlsAddNew()
        {
            dbContext = new subContext();

            paymentHeaderId = Guid.NewGuid();

            dbContext.TrPaymentHeaders.Where(x => x.InvoiceHeaderId == paymentHeaderId)
                                      .Load();
            trPaymentHeadersBindingSource.DataSource = dbContext.TrPaymentHeaders.Local.ToBindingList();

            trPaymentHeader = trPaymentHeadersBindingSource.AddNew() as TrPaymentHeader;

            dbContext.TrPaymentLines.Where(x => x.PaymentHeaderId == trPaymentHeader.InvoiceHeaderId)
                                    .LoadAsync()
                                    .ContinueWith(loadTask => trPaymentLinesBindingSource.DataSource = dbContext.TrPaymentLines.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());

            lbl_CurrAccDesc.Text = trPaymentHeader.CurrAccDesc;

            dataLayoutControl1.IsValid(out List<string> errorList);

            gV_PaymentLine.Focus();
        }

        private void trPaymentHeadersBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            TrPaymentHeader paymentHeader = new();
            paymentHeader.PaymentHeaderId = paymentHeaderId;
            string NewDocNum = efMethods.GetNextDocNum(true, "PA", "DocumentNumber", "TrPaymentHeaders", 6);
            paymentHeader.DocumentNumber = NewDocNum;
            paymentHeader.DocumentDate = DateTime.Now;
            paymentHeader.OperationDate = DateTime.Now;
            paymentHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            paymentHeader.OperationTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            paymentHeader.OfficeCode = Authorization.OfficeCode;
            paymentHeader.StoreCode = Authorization.StoreCode;
            paymentHeader.ProcessCode = "PA";
            paymentHeader.CreatedUserName = Authorization.CurrAccCode;
            paymentHeader.IsMainTF = true;

            e.NewObject = paymentHeader;
        }

        private void trPaymentHeadersBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            trPaymentHeader = trPaymentHeadersBindingSource.Current as TrPaymentHeader;

            if (trPaymentHeader != null && dbContext != null && dataLayoutControl1.IsValid(out List<string> errorList))
            {
                int count = efMethods.SelectPaymentLines(trPaymentHeader.PaymentHeaderId).Count;
                if (count > 0)
                    SavePayment();
            }
        }

        private void SavePayment()
        {
            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Daxil Etdiyiniz Məlumatlar Əsaslı Deyil ! \n \n {ex}");
            }
        }

        private void btnEdit_DocNum_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            SelectDocNum();
        }

        private void CurrAccCodeButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            SelectCurrAcc();
        }

        private void SelectDocNum()
        {
            using (FormPaymentHeaderList form = new("PA"))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    trPaymentHeader = form.trPaymentHeader;
                    if (trPaymentHeader is not null)
                    {
                        LoadPayment(trPaymentHeader.PaymentHeaderId);
                    }
                }
            }
        }

        private void LoadPayment(Guid paymentHeaderId)
        {
            dbContext = new subContext();

            dbContext.TrPaymentHeaders.Include(x => x.DcCurrAcc)
                                      .Where(x => x.PaymentHeaderId == paymentHeaderId).Load();

            LocalView<TrPaymentHeader> lV_paymentHeader = dbContext.TrPaymentHeaders.Local;

            lV_paymentHeader.ForEach(x =>
            {
                string fullName = "";
                if (!lV_paymentHeader.Any(x => x.DcCurrAcc is null))
                    fullName = x.DcCurrAcc.CurrAccDesc + " " + x.DcCurrAcc.FirstName + " " + x.DcCurrAcc.LastName;

                x.CurrAccDesc = fullName;
                lbl_CurrAccDesc.Text = fullName;
            });

            trPaymentHeadersBindingSource.DataSource = lV_paymentHeader.ToBindingList();
            trPaymentHeader = trPaymentHeadersBindingSource.Current as TrPaymentHeader;

            dbContext.TrPaymentLines.Where(x => x.PaymentHeaderId == paymentHeaderId)
                                    .OrderBy(x => x.CreatedDate)
                                    .LoadAsync()
                                    .ContinueWith(loadTask =>
                                    {
                                        LocalView<TrPaymentLine> lV_paymentLine = dbContext.TrPaymentLines.Local;
                                        trPaymentLinesBindingSource.DataSource = lV_paymentLine.ToBindingList();

                                    }, TaskScheduler.FromCurrentSynchronizationContext());

            dataLayoutControl1.IsValid(out List<string> errorList);

            CalcCurrAccBalance(trPaymentHeader.CurrAccCode, trPaymentHeader.OperationDate);
        }

        private void bBI_DeletePayment_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (efMethods.PaymentHeaderExist(trPaymentHeader.PaymentHeaderId))
            {
                if (MessageBox.Show("Silmek Isteyirsiz?", "Diqqet", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    efMethods.DeletePayment(trPaymentHeader.PaymentHeaderId);

                    ClearControlsAddNew();
                }
            }
            else
                XtraMessageBox.Show("Silinmeli olan faktura yoxdur");
        }

        private void SelectCurrAcc()
        {
            using (FormCurrAccList form = new(new byte[] { 1, 2, 3 }, trPaymentHeader.CurrAccCode))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    CurrAccCodeButtonEdit.EditValue = form.dcCurrAcc.CurrAccCode;
                    trPaymentHeader.CurrAccCode = form.dcCurrAcc.CurrAccCode;
                    lbl_CurrAccDesc.Text = form.dcCurrAcc.CurrAccDesc + " " + form.dcCurrAcc.FirstName + " " + form.dcCurrAcc.LastName;

                    CalcCurrAccBalance(form.dcCurrAcc.CurrAccCode, trPaymentHeader.OperationDate);
                }
            }
        }

        private void gV_PaymentLine_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gV_PaymentLine.SetRowCellValue(e.RowHandle, colPaymentHeaderId, trPaymentHeader.PaymentHeaderId);
            gV_PaymentLine.SetRowCellValue(e.RowHandle, colPaymentLineId, Guid.NewGuid());
            gV_PaymentLine.SetRowCellValue(e.RowHandle, colPaymentTypeCode, 1);
            gV_PaymentLine.SetRowCellValue(e.RowHandle, colPaymentMethodId, 1);

            string cashReg = efMethods.SelectDefaultCashRegister(Authorization.StoreCode);

            if (!String.IsNullOrEmpty(cashReg))
                gV_PaymentLine.SetRowCellValue(e.RowHandle, colCashRegisterCode, cashReg);

            string currencyCode = Settings.Default.AppSetting.LocalCurrencyCode;
            DcProcess dcProcess = efMethods.SelectProcess("PA");
            if (!string.IsNullOrEmpty(dcProcess.CustomCurrencyCode))
                currencyCode = dcProcess.CustomCurrencyCode;
            DcCurrency currency = efMethods.SelectCurrency(currencyCode);
            if (currency is not null)
            {
                gV_PaymentLine.SetRowCellValue(e.RowHandle, colCurrencyCode, currency.CurrencyCode);
                gV_PaymentLine.SetRowCellValue(e.RowHandle, colExchangeRate, currency.ExchangeRate);
            }

            gV_PaymentLine.SetRowCellValue(e.RowHandle, colCreatedDate, DateTime.Now);
            gV_PaymentLine.SetRowCellValue(e.RowHandle, colCreatedUserName, Authorization.CurrAccCode);
        }

        private void gC_PaymentLine_KeyDown(object sender, KeyEventArgs e)
        {
            GridControl gC = sender as GridControl;
            GridView gV = gC.MainView as GridView;

            StandartKeys(e);

            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Sətir Silinsin?", "Təsdiqlə", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                gV.DeleteSelectedRows();
            }
        }

        private void StandartKeys(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                SelectCurrAcc();
            }

            if (e.KeyCode == Keys.F2)
            {
                gV_PaymentLine.FocusedColumn = colReceivePayment;
                e.Handled = true;   // Stop the character from being entered into the control.
            }
        }

        private void gV_PaymentLine_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            //CalcRowLocNetAmount(e);
        }

        private void CalcCurrAccBalance(string CurrAccCode, DateTime dateTime)
        {
            if (!String.IsNullOrEmpty(CurrAccCode))
            {
                decimal Balance = efMethods.SelectCurrAccBalance(CurrAccCode, dateTime);

                lbl_CurrAccBalansAfter.Text = "Cari Hesab Sonrakı Borc: " + Balance.ToString();

                decimal CurrentBalance = efMethods.SelectPaymentSum(CurrAccCode, trPaymentHeader.DocumentNumber);
                Balance = Balance - CurrentBalance;
                lbl_CurrAccBalansBefore.Text = "Cari Hesab Əvvəlki Borc: " + Balance.ToString();
            }
        }

        //private void CalcRowLocNetAmount(CellValueChangedEventArgs e)
        //{
        //object objExRate = gV_PaymentLine.GetFocusedRowCellValue(colExchangeRate);
        //object objPayment = gV_PaymentLine.GetRowCellValue(e.RowHandle, colPayment);
        //object objPaymentLoc = gV_PaymentLine.GetFocusedRowCellValue(colPaymentLoc);

        //decimal exRate = objExRate.IsNumeric() ? Convert.ToDecimal(objExRate, CultureInfo.InvariantCulture) : 1;
        //decimal Payment = objPayment.IsNumeric() ? Convert.ToDecimal(objPayment, CultureInfo.InvariantCulture) : 0;
        //decimal PaymentLoc = objPaymentLoc.IsNumeric() ? Convert.ToDecimal(objPaymentLoc, CultureInfo.InvariantCulture) : 0;

        //if (e.Value != null && e.Column == colPayment)
        //{
        //    objPayment = e.Value;
        //    Payment = objPayment.IsNumeric() ? Convert.ToDecimal(objPayment, CultureInfo.InvariantCulture) : 0;
        //    gV_PaymentLine.SetRowCellValue(e.RowHandle, colPaymentLoc, Math.Round(Payment * exRate, 2));
        //}
        //else if (e.Value != null && e.Column == colExchangeRate)
        //{
        //    objExRate = e.Value;
        //    exRate = objExRate.IsNumeric() ? Convert.ToDecimal(objExRate, CultureInfo.InvariantCulture) : 1;
        //    gV_PaymentLine.SetRowCellValue(e.RowHandle, colPaymentLoc, Math.Round(Payment * exRate, 2));
        //}
        //}

        private void gV_PaymentLine_RowUpdated(object sender, RowObjectEventArgs e)
        {
            decimal balanceAfter = efMethods.SelectCurrAccBalance(trPaymentHeader.CurrAccCode, trPaymentHeader.OperationDate);
            decimal invoiceSum = efMethods.SelectPaymentSum(trPaymentHeader.CurrAccCode, trPaymentHeader.DocumentNumber);
            decimal balanceBefore = balanceAfter - invoiceSum;

            gV_PaymentLine.SetFocusedRowCellValue(colBalanceBefor, balanceBefore);
            gV_PaymentLine.SetFocusedRowCellValue(colBalanceAfter, balanceAfter);

            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                SavePayment();
            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }

            CalcCurrAccBalance(trPaymentHeader.CurrAccCode, trPaymentHeader.OperationDate);
        }

        private void gV_PaymentLine_RowDeleted(object sender, RowDeletedEventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                SavePayment();
            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }
        }

        private void repoLUE_CurrencyCode_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit textEditor = (LookUpEdit)sender;
            float exRate = efMethods.SelectExRate(textEditor.EditValue.ToString());
            gV_PaymentLine.SetFocusedRowCellValue(colExchangeRate, exRate);

            //CalcRowLocNetAmount(new CellValueChangedEventArgs(gV_PaymentLine.FocusedRowHandle, colExchangeRate, exRate));
        }

        private void bBI_SaveAndClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (trPaymentHeader != null && dbContext != null && dataLayoutControl1.IsValid(out List<string> errorList))
            {
                int count = efMethods.SelectPaymentLines(trPaymentHeader.PaymentHeaderId).Count;
                if (count > 0)
                    SavePayment();
            }
            this.Close();
        }

        private void bBI_SendWhatsapp_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!String.IsNullOrEmpty(trPaymentHeader.CurrAccCode))
            {
                string phoneNum = efMethods.SelectCurrAcc(trPaymentHeader.CurrAccCode).PhoneNum;

                string copyText = PaymentText("%0A");

                sendWhatsApp(phoneNum, copyText);
            }
            else
                MessageBox.Show("Cari Hesab qeyd olunmayıb.");
        }

        private string PaymentText(string newLine)
        {
            string paid = "";
            for (int i = 0; i < gV_PaymentLine.DataRowCount; i++)
            {
                TrPaymentLine trPaymentLine = gV_PaymentLine.GetRow(i) as TrPaymentLine;

                decimal pay = trPaymentLine.Payment;

                string txtPay = pay > 0 ? "Ödəniş alındı: " : "Ödəniş verildi: ";

                decimal payment = Math.Abs(Math.Round(pay, 2));

                string currency = trPaymentLine.CurrencyCode;

                string lineDesc = trPaymentLine.LineDescription;

                if (!String.IsNullOrEmpty(lineDesc))
                    lineDesc = " (" + lineDesc + ")";

                paid += txtPay + payment.ToString() + " " + currency + lineDesc + newLine;
            }

            decimal balance = Math.Round(efMethods.SelectCurrAccBalance(trPaymentHeader.CurrAccCode, trPaymentHeader.OperationDate), 2);
            string balanceTxt = "Qalıq: " + balance.ToString() + " " + Settings.Default.AppSetting.LocalCurrencyCode;

            return paid + balanceTxt;
        }

        private void sendWhatsApp(string number, string message)
        {
            number = number.Trim();

            if (String.IsNullOrEmpty(number))
            {
                MessageBox.Show("Nömrə qeyd olunmayıb.");
                return;
            }

            number = "+994" + number;

            string link = $"https://web.whatsapp.com/send?phone={number}&text={message}";

            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.FileName = link;
            myProcess.Start();
        }

        private void bBI_NewPayment_ItemClick(object sender, ItemClickEventArgs e)
        {
            ClearControlsAddNew();
        }

        private void dataLayout_KeyDown(object sender, KeyEventArgs e)
        {
            StandartKeys(e);
        }

        private void bBI_CopyPayment_ItemClick(object sender, ItemClickEventArgs e)
        {
            string CopyText = PaymentText("\n");

            Clipboard.SetText(CopyText);
        }

        private void repoBtnEdit_CashregisterCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;

            using (FormCurrAccList form = new(new byte[] { 5 }, trPaymentHeader.CurrAccCode))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    editor.EditValue = form.dcCurrAcc.CurrAccCode;
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!String.IsNullOrEmpty(trPaymentHeader.CurrAccCode))
            {
                string phoneNum = efMethods.SelectCurrAcc(trPaymentHeader.CurrAccCode).PhoneNum;
                string CopyText2 = PaymentText("\n");

                //TwilioClass twilioClass = new();
                //TwilioResponce responce = twilioClass.SendWhatsapp(phoneNum, "chat", CopyText2);

                //if (responce.message == "ok")
                //{
                //    efMethods.UpdatePaymentIsSent(trPaymentHeader.PaymentHeaderId);
                //    checkEdit_IsSent.EditValue = true;
                //    MessageBox.Show("Göndərildi", "İnfo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else
                //    MessageBox.Show(responce.message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);


                MetaWhatsapp meta = new();
                var metaResponce = meta.SendWhatsapp(phoneNum, CopyText2);

                if (metaResponce.error is not null)
                    MessageBox.Show(metaResponce.error.message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else //(!string.IsNullOrEmpty(metaResponce.messages.FirstOrDefault().id))
                {
                    efMethods.UpdatePaymentIsSent(trPaymentHeader.PaymentHeaderId);
                    checkEdit_IsSent.EditValue = true;
                    MessageBox.Show("Göndərildi", "İnfo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            else
                MessageBox.Show("Cari Hesab qeyd olunmayıb.");


        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            //TwilioClass twilio = new TwilioClass();
            //twilio.AlmaDolmasi();
        }

        private void BBI_Info_ItemClick(object sender, ItemClickEventArgs e)
        {
            DcCurrAcc dcCurrAcc = efMethods.SelectCurrAcc(trPaymentHeader.CreatedUserName);

            string userName = ReflectionExtensions.GetPropertyDisplayName<TrInvoiceHeader>(x => x.CreatedUserName) + ": " + dcCurrAcc.CurrAccDesc + " " + dcCurrAcc.FirstName;
            string createDate = ReflectionExtensions.GetPropertyDisplayName<TrInvoiceHeader>(x => x.CreatedDate) + ": " + trPaymentHeader.CreatedDate.ToString();
            XtraMessageBox.Show(userName + '\n' + '\n' + createDate, "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}