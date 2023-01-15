using DevExpress.Data;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
   public partial class FormMoneyTransfer : RibbonForm
   {
      private TrPaymentHeader trPaymentHeader;
      private EfMethods efMethods = new();
      private subContext dbContext;
      private Guid paymentHeaderId;

      public FormMoneyTransfer()
      {
         InitializeComponent();

         repoLUE_CurrencyCode.DataSource = efMethods.SelectCurrencies();
         repoLUE_PaymentTypeCode.DataSource = efMethods.SelectPaymentTypes();

         ClearControlsAddNew();
      }

      public FormMoneyTransfer(Guid paymentHeaderId)
          : this()
      {
         trPaymentHeader = efMethods.SelectPaymentHeader(paymentHeaderId);

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

                  TrPaymentHeader newTrIP = trPH;
                  newTrIP.PaymentHeaderId = guidHead;
                  string temp = trPH.FromCashRegCode;
                  newTrIP.FromCashRegCode = trPH.ToCashRegCode;
                  newTrIP.ToCashRegCode = temp;
                  newTrIP.IsMainTF = false;

                  switch (entry.State)
                  {
                     case EntityState.Added: context2.TrPaymentHeaders.Add(newTrIP); break;
                     case EntityState.Modified: context2.TrPaymentHeaders.Update(newTrIP); break;
                     case EntityState.Deleted: context2.TrPaymentHeaders.Remove(newTrIP); break;
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
         using (FormPaymentHeaderList form = new FormPaymentHeaderList())
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
               efMethods.DeleteMoneyTransfer(trPaymentHeader.PaymentHeaderId);

               ClearControlsAddNew();
            }
         }
         else
            XtraMessageBox.Show("Silinmeli olan faktura yoxdur");
      }

      private DcCurrAcc SelectCurrAcc()
      {
         using (FormCurrAccList form = new(5, trPaymentHeader.CurrAccCode))
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

         string cashReg = trPaymentHeader.ToCashRegCode;

         if (!String.IsNullOrEmpty(cashReg))
            gV_PaymentLine.SetRowCellValue(e.RowHandle, colCashRegisterCode, cashReg);

         gV_PaymentLine.SetRowCellValue(e.RowHandle, colCurrencyCode, "AZN");
         gV_PaymentLine.SetRowCellValue(e.RowHandle, colExchangeRate, 1.703f);
         gV_PaymentLine.SetRowCellValue(e.RowHandle, colCreatedDate, DateTime.Now);
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
            string CopyText2 = PaymentText("\n");

            Clipboard.SetText(CopyText2);

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

            CalcCurrAccBalance(dcCurrAcc.CurrAccCode, trPaymentHeader.OperationDate);
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

            CalcCurrAccBalance(dcCurrAcc.CurrAccCode, trPaymentHeader.OperationDate);
         }
      }
   }
}