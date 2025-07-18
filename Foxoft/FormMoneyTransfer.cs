﻿using DevExpress.Data;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace Foxoft
{
    public partial class FormMoneyTransfer : RibbonForm
    {
        private TrPaymentHeader trPaymentHeader;
        private EfMethods efMethods = new();
        private subContext dbContext;
        private Guid paymentHeaderId;
        private decimal BalanceBefore;

        public FormMoneyTransfer()
        {
            InitializeComponent();

            repoLUE_CurrencyCode.DataSource = efMethods.SelectEntities<DcCurrency>();
            repoLUE_PaymentTypeCode.DataSource = efMethods.SelectEntities<DcPaymentType>();

            ClearControlsAddNew();
        }

        public FormMoneyTransfer(Guid paymentHeaderId)
            : this()
        {
            trPaymentHeader = efMethods.SelectPaymentHeader(paymentHeaderId);

            if (trPaymentHeader is not null)
                LoadPayment(trPaymentHeader.PaymentHeaderId);
        }

        private void ClearControlsAddNew()
        {
            dbContext = new();

            paymentHeaderId = Guid.NewGuid();

            dbContext.TrPaymentHeaders.Where(x => x.InvoiceHeaderId == paymentHeaderId)
                                      .Load();
            trPaymentHeadersBindingSource.DataSource = dbContext.TrPaymentHeaders.Local.ToBindingList();

            trPaymentHeader = trPaymentHeadersBindingSource.AddNew() as TrPaymentHeader;

            dbContext.TrPaymentLines.Where(x => x.PaymentHeaderId == trPaymentHeader.InvoiceHeaderId)
                                    .LoadAsync()
                                    .ContinueWith(loadTask => trPaymentLinesBindingSource.DataSource = dbContext.TrPaymentLines.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());

            lbl_ToCashRegDesc.Text = trPaymentHeader.CurrAccDesc;
            lbl_FromCashRegDesc.Text = trPaymentHeader.CurrAccDesc;

            dataLayoutControl1.IsValid(out List<string> errorList);

            gV_PaymentLine.Focus();
        }

        private void trPaymentHeadersBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            TrPaymentHeader paymentHeader = new();
            paymentHeader.PaymentHeaderId = paymentHeaderId;
            string NewDocNum = efMethods.GetNextDocNum(true, "CT", "DocumentNumber", "TrPaymentHeaders", 6);
            paymentHeader.DocumentNumber = NewDocNum;
            paymentHeader.DocumentDate = DateTime.Now.Date;
            paymentHeader.OperationDate = DateTime.Now.Date;
            paymentHeader.ProcessCode = "CT";
            paymentHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            paymentHeader.OperationTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            paymentHeader.OfficeCode = Authorization.OfficeCode;
            paymentHeader.StoreCode = Authorization.StoreCode;
            paymentHeader.CreatedUserName = Authorization.CurrAccCode;
            paymentHeader.IsMainTF = true;

            e.NewObject = paymentHeader;
        }

        private void trPaymentHeadersBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            trPaymentHeader = trPaymentHeadersBindingSource.Current as TrPaymentHeader;

            if (trPaymentHeader is not null)
            {
                for (int i = 0; i < gV_PaymentLine.RowCount; i++)
                {
                    gV_PaymentLine.SetRowCellValue(i, colCashRegisterCode, trPaymentHeader.ToCashRegCode);
                }
            }

            if (trPaymentHeader != null && dbContext != null && dataLayoutControl1.IsValid(out List<string> errorList))
            {
                int count = efMethods.SelectPaymentLines(trPaymentHeader.PaymentHeaderId).Count;
                if (count > 0)
                    SavePayment();
            }
        }

        Guid guidHead;
        private void SavePayment()
        {
            try
            {
                dbContext.SaveChanges(false);

                //List<EntityEntry> entityEntry = new();
                IEnumerable<EntityEntry> entityEntry = dbContext.ChangeTracker.Entries();

                foreach (var entry in entityEntry)
                {
                    if (entry.Entity.GetType().Name == nameof(TrPaymentHeader))
                    {
                        TrPaymentHeader trPH = (TrPaymentHeader)entry.CurrentValues.ToObject();

                        string payHeadStr = trPH.PaymentHeaderId.ToString();

                        guidHead = Guid.Parse(payHeadStr.Replace(payHeadStr.Substring(0, 8), "00000000")); // 00000000-ED42-11CE-BACD-00AA0057B223

                        using subContext context2 = new();

                        TrPaymentHeader copyTrPH = trPH;
                        copyTrPH.PaymentHeaderId = guidHead;
                        string temp = trPH.FromCashRegCode;
                        copyTrPH.FromCashRegCode = trPH.ToCashRegCode;
                        copyTrPH.ToCashRegCode = temp;
                        copyTrPH.IsMainTF = false;

                        switch (entry.State)
                        {
                            case EntityState.Added: context2.TrPaymentHeaders.Add(copyTrPH); break;
                            case EntityState.Modified: context2.TrPaymentHeaders.Update(copyTrPH); break;
                            case EntityState.Deleted: context2.TrPaymentHeaders.Remove(copyTrPH); break;
                            default: break;
                        }
                        context2.SaveChanges();
                    }

                    if (entry.Entity.GetType().Name == nameof(TrPaymentLine))
                    {
                        TrPaymentLine trPl = (TrPaymentLine)entry.CurrentValues.ToObject();

                        string invoLineStr = trPl.PaymentLineId.ToString();
                        Guid quidLine = Guid.Parse(invoLineStr.Replace(invoLineStr.Substring(0, 8), "00000000")); // 00000000-ED42-11CE-BACD-00AA0057B223

                        using subContext context2 = new();

                        TrPaymentLine newTrPl = trPl;
                        newTrPl.PaymentHeaderId = guidHead;
                        newTrPl.PaymentLineId = quidLine;
                        newTrPl.CashRegisterCode = trPaymentHeader.FromCashRegCode;
                        newTrPl.Payment *= (-1);

                        switch (entry.State)
                        {
                            case EntityState.Added: context2.TrPaymentLines.Add(newTrPl); break;
                            case EntityState.Modified: context2.TrPaymentLines.Update(newTrPl); break;
                            case EntityState.Deleted: context2.TrPaymentLines.Remove(newTrPl); break;
                            default: break;
                        }
                        context2.SaveChanges();
                    }
                }

                dbContext.ChangeTracker.AcceptAllChanges();
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
            //SelectCurrAcc(sender);
        }

        private void SelectDocNum()
        {
            using (FormPaymentHeaderList form = new("CT"))
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

            dbContext.TrPaymentHeaders
                                      .Include(x => x.DcCurrAcc)
                                      .Include(x => x.ToCashReg)
                                      .Where(x => x.PaymentHeaderId == paymentHeaderId)
                                      .Load();

            LocalView<TrPaymentHeader> lV_paymentHeader = dbContext.TrPaymentHeaders.Local;

            lV_paymentHeader.ForEach(x =>
            {
                if (lV_paymentHeader.Any(x => x.DcCurrAcc is not null) || lV_paymentHeader.Any(x => x.ToCashReg is not null))
                {
                    lbl_FromCashRegDesc.Text = x.DcCurrAcc.CurrAccDesc + " " + x.DcCurrAcc.FirstName + " " + x.DcCurrAcc.LastName;

                    if (x.ToCashReg is not null)
                        lbl_ToCashRegDesc.Text = x.ToCashReg.CurrAccDesc + " " + x.ToCashReg.FirstName + " " + x.ToCashReg.LastName;

                }
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
                                        CalcCashRegBalance();
                                    }, TaskScheduler.FromCurrentSynchronizationContext());

            dataLayoutControl1.IsValid(out List<string> errorList);

            BalanceBefore = Math.Round(efMethods.SelectCashRegBalance(trPaymentHeader.CurrAccCode, trPaymentHeader.OperationDate.Add(trPaymentHeader.OperationTime)), 2);
        }

        private void bBI_DeletePayment_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (efMethods.EntityExists<TrPaymentHeader>(trPaymentHeader.PaymentHeaderId))
            {
                if (MessageBox.Show("Silmek Isteyirsiz?", "Diqqet", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    efMethods.DeleteMoneyTransfer(trPaymentHeader.PaymentHeaderId);

                    ClearControlsAddNew();
                }
            }
            else
                XtraMessageBox.Show("Silinmeli olan faktura yoxdur");
        }

        private DcCurrAcc SelectCurrAcc()
        {
            using (FormCashRegisterList form = new(trPaymentHeader.CurrAccCode))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    return form.dcCurrAcc;
                }
                else return null;
            }
        }

        private void gV_PaymentLine_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gV_PaymentLine.SetRowCellValue(e.RowHandle, colPaymentHeaderId, trPaymentHeader.PaymentHeaderId);
            gV_PaymentLine.SetRowCellValue(e.RowHandle, colPaymentLineId, Guid.NewGuid());
            gV_PaymentLine.SetRowCellValue(e.RowHandle, colPaymentTypeCode, 1);
            gV_PaymentLine.SetRowCellValue(e.RowHandle, colPaymentMethodId, 1);

            string cashReg = trPaymentHeader.ToCashRegCode;

            if (!String.IsNullOrEmpty(cashReg))
                gV_PaymentLine.SetRowCellValue(e.RowHandle, colCashRegisterCode, cashReg);

            string currencyCode = Settings.Default.AppSetting.LocalCurrencyCode;
            DcProcess dcProcess = efMethods.SelectEntityById<DcProcess>("CT");
            if (!string.IsNullOrEmpty(dcProcess.CustomCurrencyCode))
                currencyCode = dcProcess.CustomCurrencyCode;
            DcCurrency currency = efMethods.SelectEntityById<DcCurrency>(currencyCode);
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
            if (e.KeyCode == Keys.F2)
            {
                gV_PaymentLine.FocusedColumn = colPayment;
                e.Handled = true;   // Stop the character from being entered into the control.
            }
        }

        private void gV_PaymentLine_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            //CalcRowLocNetAmount(e);
        }

        private void CalcCashRegBalance()
        {
            decimal summaryValue = CalcSummaryValue();
            decimal balanceAfter = BalanceBefore + summaryValue;

            lbl_CurrAccBalansAfter.Text = "Cari Hesab Sonrakı Borc: " + balanceAfter.ToString();
            lbl_CurrAccBalansBefore.Text = "Cari Hesab Əvvəlki Borc: " + BalanceBefore.ToString();
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

            CalcCashRegBalance();
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
            float exRate = efMethods.SelectEntityById<DcCurrency>(textEditor.EditValue.ToString()).ExchangeRate;
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

                if (!string.IsNullOrEmpty(phoneNum))
                {
                    string copyText = PaymentText("%0A");

                    sendWhatsApp(phoneNum, copyText);
                }
                else
                    MessageBox.Show("Telefon nömrəsi qeyd olunmayıb.");
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

            decimal summaryValue = CalcSummaryValue();
            decimal balanceAfter = Math.Round(BalanceBefore - summaryValue, 2);
            string balanceTxt = "Qalıq: " + balanceAfter.ToString() + " " + Settings.Default.AppSetting.LocalCurrencyCode;

            return paidTxt + balanceTxt;
        }

        private decimal CalcSummaryValue()
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

        private void FromCashRegCodeButtonEdit_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit buttonEdit = sender as ButtonEdit;
            DcCurrAcc dcCurrAcc = SelectCurrAcc();

            if (dcCurrAcc is not null)
            {
                buttonEdit.EditValue = dcCurrAcc.CurrAccCode;
                trPaymentHeader.FromCashRegCode = dcCurrAcc.CurrAccCode;
                lbl_FromCashRegDesc.Text = dcCurrAcc.CurrAccDesc + " " + dcCurrAcc.FirstName + " " + dcCurrAcc.LastName;

                CalcCashRegBalance();
            }
        }

        private void ToCashRegCodeButtonEdit_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit buttonEdit = sender as ButtonEdit;
            DcCurrAcc dcCurrAcc = SelectCurrAcc();

            if (dcCurrAcc is not null)
            {
                buttonEdit.EditValue = dcCurrAcc.CurrAccCode;
                trPaymentHeader.ToCashRegCode = dcCurrAcc.CurrAccCode;
                lbl_ToCashRegDesc.Text = dcCurrAcc.CurrAccDesc + " " + dcCurrAcc.FirstName + " " + dcCurrAcc.LastName;

                BalanceBefore = Math.Round(efMethods.SelectCashRegBalance(trPaymentHeader.CurrAccCode, trPaymentHeader.OperationDate.Add(trPaymentHeader.OperationTime)), 2);
                CalcCashRegBalance();
            }
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
                if (e.Column != colLastUpdatedDate && e.Column != colLastUpdatedUserName)
                {
                    if (gV.ActiveEditor is not null && !Equals(e.Value, gV.ActiveEditor.OldEditValue))
                    {
                        string userName = efMethods.SelectCurrAcc(Authorization.CurrAccCode)?.CurrAccDesc;

                        gV.SetRowCellValue(e.RowHandle, colLastUpdatedDate, DateTime.Now);
                        gV.SetRowCellValue(e.RowHandle, colLastUpdatedUserName, userName);
                    }
                }
            }
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

                    runningTotal -= value;
                }
                e.Value = runningTotal;
            }
        }
    }
}