﻿using DevExpress.Data;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Commands;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormPaymentDetail : RibbonForm
    {
        private TrPaymentHeader trPaymentHeader;
        private EfMethods efMethods = new();
        private CustomMethods cM = new();

        private subContext dbContext;
        private Guid paymentHeaderId;
        private decimal BalanceBefore;


        public FormPaymentDetail()
        {
            InitializeComponent();

            string activeFilterStr = "[StoreCode] = \'" + Authorization.StoreCode + "\'";

            cM.AddReports(BSI_Reports, "PaymentDetails", nameof(trPaymentHeader.PaymentHeaderId), gV_PaymentLine, activeFilterStr);

            LUE_StoreCode.Properties.DataSource = efMethods.SelectStoresIncludeDisabled();
            repoLUE_CurrencyCode.DataSource = efMethods.SelectCurrencies();
            repoLUE_PaymentTypeCode.DataSource = efMethods.SelectPaymentTypes();

            ClearControlsAddNew();
        }

        public FormPaymentDetail(Guid paymentHeaderId)
            : this()
        {
            trPaymentHeader = efMethods.SelectPaymentHeader(paymentHeaderId);

            if (trPaymentHeader is not null)
                LoadPayment(trPaymentHeader.PaymentHeaderId);
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

            dataLayoutControl1.IsValid(out List<string> errorList);

            gV_PaymentLine.Focus();
        }

        private void trPaymentHeadersBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            TrPaymentHeader paymentHeader = new();
            paymentHeader.PaymentHeaderId = paymentHeaderId;
            string NewDocNum = efMethods.GetNextDocNum(true, "PA", "DocumentNumber", "TrPaymentHeaders", 6);
            paymentHeader.DocumentNumber = NewDocNum;
            paymentHeader.DocumentDate = DateTime.Now.Date;
            paymentHeader.OperationDate = DateTime.Now.Date;
            paymentHeader.ProcessCode = "PA";
            paymentHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            paymentHeader.OperationTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            paymentHeader.OfficeCode = Authorization.OfficeCode;
            paymentHeader.StoreCode = Authorization.StoreCode;
            paymentHeader.CreatedUserName = Authorization.CurrAccCode;
            paymentHeader.IsMainTF = true;

            e.NewObject = paymentHeader;
        }

        public static List<T> GetFilteredData<T>(ColumnView view)
        {
            List<T> resp = new List<T>();
            for (int i = 0; i < view.DataRowCount; i++)
                resp.Add((T)view.GetRow(i));

            return resp;
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
                                      .Where(x => x.PaymentHeaderId == paymentHeaderId)
                                      .Load();

            LocalView<TrPaymentHeader> lV_paymentHeader = dbContext.TrPaymentHeaders.Local;

            //lV_paymentHeader.ForEach(x =>
            //{
            //    string fullName = "";
            //    if (!lV_paymentHeader.Any(x => x.DcCurrAcc is null))
            //        fullName = x.DcCurrAcc.CurrAccDesc + " " + x.DcCurrAcc.FirstName + " " + x.DcCurrAcc.LastName;

            //    x.CurrAccDesc = fullName;
            //});

            trPaymentHeadersBindingSource.DataSource = lV_paymentHeader.ToBindingList();
            trPaymentHeader = trPaymentHeadersBindingSource.Current as TrPaymentHeader;

            dbContext.TrPaymentLines.Where(x => x.PaymentHeaderId == paymentHeaderId)
                                    .OrderBy(x => x.CreatedDate)
                                    .LoadAsync()
                                    .ContinueWith(loadTask =>
                                    {
                                        LocalView<TrPaymentLine> lV_paymentLine = dbContext.TrPaymentLines.Local;
                                        trPaymentLinesBindingSource.DataSource = lV_paymentLine.ToBindingList();

                                        CalcCurrAccBalance();
                                    }, TaskScheduler.FromCurrentSynchronizationContext());

            dataLayoutControl1.IsValid(out List<string> errorList);

            //BalanceBefore = Math.Round(efMethods.SelectCurrAccBalance(trPaymentHeader.CurrAccCode, trPaymentHeader.OperationDate.Add(trPaymentHeader.OperationTime)), 2);
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
                    btnEdit_CurrAccCode.EditValue = form.dcCurrAcc.CurrAccCode;
                    trPaymentHeader.CurrAccCode = form.dcCurrAcc.CurrAccCode;

                    //BalanceBefore = Math.Round(efMethods.SelectCurrAccBalance(trPaymentHeader.CurrAccCode, trPaymentHeader.OperationDate.Add(trPaymentHeader.OperationTime)), 2);
                    //CalcCurrAccBalance();
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

        private void CalcCurrAccBalance()
        {
            decimal summaryValue = CalcSummmaryValue();
            decimal balanceAfter = BalanceBefore + summaryValue;

            lbl_CurrAccBalansAfter.Text = "Cari Hesab Sonrakı Borc: " + Math.Round(balanceAfter, 2).ToString();
            lbl_CurrAccBalansBefore.Text = "Cari Hesab Əvvəlki Borc: " + Math.Round(BalanceBefore, 2).ToString();
        }

        private decimal CalcSummmaryValue()
        {
            decimal sum = 0;

            for (int i = 0; i < gV_PaymentLine.RowCount; i++)
            {
                object value = gV_PaymentLine.GetRowCellValue(i, colPaymentLoc);

                if (value != null && value != DBNull.Value)
                    sum += Convert.ToDecimal(value);
            }

            return sum;
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
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                SavePayment();
            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }

            CalcCurrAccBalance();
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
            string paidTxt = "";
            for (int i = 0; i < gV_PaymentLine.DataRowCount; i++)
            {
                TrPaymentLine trPaymentLine = gV_PaymentLine.GetRow(i) as TrPaymentLine;

                decimal pay = trPaymentLine.Payment;

                string txtPay = pay > 0 ? "Ödəniş alındı: " : "Ödəniş verildi: ";

                decimal payment = Math.Abs(Math.Round(pay, 2));

                string lineDesc = String.IsNullOrEmpty(trPaymentLine.LineDescription) ? "" : " (" + trPaymentLine.LineDescription + ")";

                paidTxt += txtPay + payment.ToString() + " " + trPaymentLine.CurrencyCode + lineDesc + newLine;
            }

            decimal summaryValue = CalcSummmaryValue();
            decimal balanceAfter = Math.Round(BalanceBefore + summaryValue, 2);
            string balanceTxt = "Qalıq: " + balanceAfter.ToString() + " " + Settings.Default.AppSetting.LocalCurrencyCode;

            return paidTxt + balanceTxt;
        }

        private void sendWhatsApp(string number, string message)
        {
            number = number?.Trim();

            if (String.IsNullOrEmpty(number))
            {
                MessageBox.Show("Nömrə qeyd olunmayıb.");
                return;
            }

            number = "+994" + number;

            string link = $"https://web.whatsapp.com/send?phone={number}&text={message}";

            Process myProcess = new();
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
            DcCurrAcc createdCurrAcc = efMethods.SelectCurrAcc(trPaymentHeader.CreatedUserName);
            DcCurrAcc updatedCurrAcc = efMethods.SelectCurrAcc(trPaymentHeader.LastUpdatedUserName);

            string lastUpdatedDate = efMethods.SelectPaymentLines(trPaymentHeader.PaymentHeaderId).OrderByDescending(x => x.LastUpdatedDate).FirstOrDefault().LastUpdatedDate.ToString();
            string lastUpdatedUserName = efMethods.SelectPaymentLines(trPaymentHeader.PaymentHeaderId).OrderByDescending(x => x.LastUpdatedDate).FirstOrDefault().LastUpdatedUserName.ToString();

            string createdUserName = ReflectionExt.GetDisplayName<TrInvoiceHeader>(x => x.CreatedUserName) + ": " + createdCurrAcc.CurrAccDesc + " " + createdCurrAcc.FirstName;
            string createdDate = ReflectionExt.GetDisplayName<TrInvoiceHeader>(x => x.CreatedDate) + ": " + trPaymentHeader.CreatedDate.ToString();
            string updatedUserName = ReflectionExt.GetDisplayName<TrInvoiceHeader>(x => x.LastUpdatedUserName) + ": " + lastUpdatedUserName;
            string updatedDate = ReflectionExt.GetDisplayName<TrInvoiceHeader>(x => x.LastUpdatedDate) + ": " + lastUpdatedDate;

            XtraMessageBox.Show(createdUserName + "\n\n" + createdDate + "\n\n" + updatedUserName + "\n\n" + updatedDate, "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gV_PaymentLine_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            GridView gV = (GridView)sender;

            if (gV is not null)
            {
                if (e.Column != colLastUpdatedDate && e.Column != colLastUpdatedUserName && !e.Column.ReadOnly && e.Column.OptionsColumn.AllowEdit)
                {
                    Object oldvalue1 = gV.ActiveEditor?.OldEditValue;

                    if (!Object.Equals(e.Value, oldvalue1))
                    {
                        string userName = efMethods.SelectCurrAcc(Authorization.CurrAccCode)?.CurrAccDesc;

                        gV.SetRowCellValue(e.RowHandle, colLastUpdatedDate, DateTime.Now);
                        gV.SetRowCellValue(e.RowHandle, colLastUpdatedUserName, userName);
                    }
                }
            }
        }

        private void gV_PaymentLine_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            //MessageBox.Show("FocusedRowChanged");
        }

        private void gV_PaymentLine_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (new GridColumn[] { colRunningTotal, colRunningTotalBefore }.Contains(e.Column) && e.IsGetData)
            {
                GridView view = sender as GridView;
                decimal runningTotal = BalanceBefore;
                for (int i = 0; i <= e.ListSourceRowIndex; i++)
                {
                    decimal value = 0;
                    if (e.Column == colRunningTotal)
                        value = Math.Round(Convert.ToDecimal(view.GetListSourceRowCellValue(i, colPaymentLoc)), 2);
                    else if (e.Column == colRunningTotalBefore)
                        value = Math.Round(Convert.ToDecimal(view.GetListSourceRowCellValue(i - 1, colPaymentLoc)), 2);

                    runningTotal += value;
                }
                e.Value = runningTotal;
            }
        }

        private void btnEdit_CurrAccCode_Validating(object sender, CancelEventArgs e)
        {
            object eValue = trPaymentHeader?.CurrAccCode;

            if (eValue is not null)
            {
                DcCurrAcc curr = efMethods.SelectCurrAcc(eValue.ToString());

                if (curr is null)
                    e.Cancel = true;
            }
        }

        private void btnEdit_CurrAccCode_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = "Belə bir cari yoxdur";
            e.ExceptionMode = ExceptionMode.DisplayError;
        }

        private void btnEdit_CurrAccCode_EditValueChanged(object sender, EventArgs e)
        {
            string eValueStr = btnEdit_CurrAccCode.EditValue?.ToString();
            lbl_CurrAccDesc.Text = "";
            BalanceBefore = 0;

            if (!string.IsNullOrEmpty(eValueStr))
            {
                DcCurrAcc curr = efMethods.SelectCurrAcc(eValueStr);
                trPaymentHeader.CurrAccCode = curr?.CurrAccCode;

                if (curr != null)
                {
                    lbl_CurrAccDesc.Text = $"{curr.CurrAccDesc} {curr.FirstName} {curr.LastName}";
                    BalanceBefore = Math.Round(efMethods.SelectCurrAccBalance(trPaymentHeader.CurrAccCode, trPaymentHeader.OperationDate.Add(trPaymentHeader.OperationTime)), 2);
                }

                CalcCurrAccBalance();
            }
        }

        private void LUE_StoreCode_PopupFilter(object sender, PopupFilterEventArgs e)
        {
            LUE_StoreCode.Properties.DataSource = efMethods.SelectStores();
        }

        private void gV_PaymentLine_ShownEditor(object sender, EventArgs e)
        {
            CultureInfo customCulture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            if (gV_PaymentLine.FocusedColumn == colExchangeRate)
            {
                var editor = gV_PaymentLine.ActiveEditor as TextEdit;
                if (editor != null)
                {
                    editor.Properties.Mask.MaskType = MaskType.Numeric;
                    editor.Properties.Mask.Culture = customCulture; // Ensure '.' is used
                }
            }
        }

        private void popupMenuReports_BeforePopup(object sender, CancelEventArgs e)
        {

        }
    }
}