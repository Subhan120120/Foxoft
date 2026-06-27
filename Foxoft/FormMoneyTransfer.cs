using DevExpress.Data;
using DevExpress.Utils.Extensions;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Models.Entity.Report;
using Foxoft.Properties;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;

namespace Foxoft
{
    public partial class FormMoneyTransfer : RibbonForm
    {
        private TrPaymentHeader trPaymentHeader;
        private EfMethods efMethods = new();
        private readonly ReportClass reportClass;
        private readonly SettingStore settingStore;
        private readonly DcTerminal? dcTerminal;
        private subContext dbContext;
        private Guid paymentHeaderId;
        private decimal BalanceBefore;

        public FormMoneyTransfer()
        {
            InitializeComponent();

            settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);
            dcTerminal = efMethods.SelectEntityById<DcTerminal>(Settings.Default.TerminalId);
            reportClass = new(settingStore?.DesignFileFolder ?? string.Empty);

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
            string newDocNum = efMethods.GetNextDocNum(true, "CT", nameof(TrPaymentHeader.DocumentNumber), "TrPaymentHeaders", 6);
            paymentHeader.DocumentNumber = newDocNum;
            paymentHeader.DocumentDate = DateTime.Now.Date;
            paymentHeader.OperationDate = DateTime.Now.Date;
            paymentHeader.ProcessCode = "CT";
            paymentHeader.DocumentTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            paymentHeader.OperationTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
            paymentHeader.OfficeCode = Authorization.OfficeCode;
            paymentHeader.StoreCode = Authorization.StoreCode;
            paymentHeader.CreatedUserName = Authorization.CurrAccCode;
            paymentHeader.IsMainTF = true;
            paymentHeader.TerminalId = Settings.Default.TerminalId;

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
            if (!ValidateChildren()) return;
            try
            {
                dbContext.SaveChanges(false);

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
                MessageBox.Show(string.Format(Resources.Form_MoneyTransfer_SaveError, ex));
            }
        }

        private void btnEdit_DocNum_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Left)
                NavigateToAdjacentMoneyTransfer(isPrevious: true);
            else if (e.Button.Kind == ButtonPredefines.Right)
                NavigateToAdjacentMoneyTransfer(isPrevious: false);
            else
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

            trPaymentHeadersBindingSource.DataSource = lV_paymentHeader.ToBindingList();
            trPaymentHeader = trPaymentHeadersBindingSource.Current as TrPaymentHeader;

            lbl_FromCashRegDesc.Text = GetCurrAccDisplayName(trPaymentHeader?.DcCurrAcc);
            lbl_ToCashRegDesc.Text = GetCurrAccDisplayName(trPaymentHeader?.ToCashReg);

            if (trPaymentHeader is null)
            {
                trPaymentLinesBindingSource.DataSource = null;
                BalanceBefore = 0;
                CalcCashRegBalance();
                return;
            }

            BalanceBefore = string.IsNullOrWhiteSpace(trPaymentHeader.CurrAccCode)
                ? 0
                : Math.Round(efMethods.SelectCashRegBalance(trPaymentHeader.CurrAccCode, trPaymentHeader.OperationDate.Add(trPaymentHeader.OperationTime)), 2);

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
        }

        private static string GetCurrAccDisplayName(DcCurrAcc currAcc)
        {
            if (currAcc is null)
                return string.Empty;

            return $"{currAcc.CurrAccDesc} {currAcc.FirstName} {currAcc.LastName}".Trim();
        }

        private void bBI_DeletePayment_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (efMethods.EntityExists<TrPaymentHeader>(trPaymentHeader.PaymentHeaderId))
            {
                if (MessageBox.Show(Resources.Common_DeleteConfirm, Resources.Common_Attention, MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    efMethods.DeleteMoneyTransfer(trPaymentHeader.PaymentHeaderId);

                    ClearControlsAddNew();
                }
            }
            else
                XtraMessageBox.Show(Resources.Form_MoneyTransfer_NoPaymentToDelete);
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
            gV_PaymentLine.SetRowCellValue(e.RowHandle, colPaymentTypeCode, PaymentType.Cash);
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
                if (MessageBox.Show(Resources.Common_DeleteConfirm, Resources.Common_Attention, MessageBoxButtons.YesNo) != DialogResult.Yes)
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

            lbl_CurrAccBalansAfter.Text = Resources.Form_MoneyTransfer_Label_CurrAccBalanceAfter + balanceAfter.ToString();
            lbl_CurrAccBalansBefore.Text = Resources.Form_MoneyTransfer_Label_CurrAccBalanceBefore + BalanceBefore.ToString();
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

        private async void bBI_SendWhatsapp_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (trPaymentHeader is null || string.IsNullOrEmpty(trPaymentHeader.CurrAccCode))
            {
                MessageBox.Show(Resources.Form_MoneyTransfer_CurrAccNotDefined);
                return;
            }

            string phoneNum = efMethods.SelectCurrAcc(trPaymentHeader.CurrAccCode)?.PhoneNum;

            if (string.IsNullOrEmpty(phoneNum))
            {
                MessageBox.Show(Resources.Form_MoneyTransfer_PhoneNotDefined);
                return;
            }

            MemoryStream? memoryStream = GetPaymentReportImg();
            if (memoryStream == null) return;

            if (Settings.Default.AppSetting.WhatsAppProvider == WhatsAppProvider.API)
            {
                await SendWhatsAppViaEvolutionApi(phoneNum, memoryStream);
            }
            else
            {
                if (memoryStream.CanSeek) memoryStream.Position = 0;
                Clipboard.SetImage(Image.FromStream(memoryStream));
                sendWhatsApp(phoneNum, GetWhatsAppCaption());
            }
        }

        private string PaymentText(string newLine)
        {
            string paidTxt = "";
            for (int i = 0; i < gV_PaymentLine.DataRowCount; i++)
            {
                TrPaymentLine trPaymentLine = gV_PaymentLine.GetRow(i) as TrPaymentLine;

                decimal pay = trPaymentLine.Payment;

                string txtPay = pay > 0 ? Resources.Form_MoneyTransfer_PaymentReceived : Resources.Form_MoneyTransfer_PaymentGiven;

                decimal payment = Math.Abs(Math.Round(pay, 2));

                string lineDesc = String.IsNullOrEmpty(trPaymentLine.LineDescription) ? "" : " (" + trPaymentLine.LineDescription + ")";

                paidTxt += txtPay + payment.ToString() + " " + trPaymentLine.CurrencyCode + lineDesc + newLine;
            }

            decimal summaryValue = CalcSummaryValue();
            decimal balanceAfter = Math.Round(BalanceBefore - summaryValue, 2);
            string balanceTxt = Resources.Form_MoneyTransfer_Balance + balanceAfter.ToString() + " " + Settings.Default.AppSetting.LocalCurrencyCode;

            return paidTxt + balanceTxt;
        }

        private string GetWhatsAppCaption()
        {
            return $"{Resources.Form_MoneyTransfer_Caption} {Resources.Entity_PaymentHeader_DocumentNumber}: {trPaymentHeader.DocumentNumber}";
        }

        private MemoryStream? GetPaymentReportImg()
        {
            XtraReport? xtraReport = GetPaymentReport(trPaymentHeader.PaymentHeaderId);

            if (xtraReport == null)
                return null;

            MemoryStream ms = new();

            using (xtraReport)
            {
                xtraReport.ExportToImage(ms, new ImageExportOptions() { Format = ImageFormat.Png, PageRange = "1", ExportMode = ImageExportMode.SingleFile, Resolution = 240 });
            }

            if (ms.CanSeek) ms.Position = 0;

            return ms;
        }

        private XtraReport? GetPaymentReport(Guid paymentHeaderId)
        {
            DcReport? dcReport = GetPaymentReportDefinition(paymentHeaderId);

            if (dcReport == null)
                return null;

            SqlParameter[] sqlParameters;
            string query = reportClass.ApplyFilter(dcReport, dcReport.ReportQuery, "", out sqlParameters);
            List<QueryParameter> qryParams = reportClass.ConvertSqlParametersToQueryParameters(sqlParameters);
            CustomSqlQuery mainQuery = new("Main", query);
            mainQuery.Parameters.AddRange(qryParams);
            List<CustomSqlQuery> sqlQueries = new(new[] { mainQuery });

            return reportClass.GetReport(dcReport.ReportName, dcReport.ReportName + ".repx", sqlQueries);
        }

        private DcReport? GetPaymentReportDefinition(Guid paymentHeaderId)
        {
            DcReport dcReport = efMethods.SelectReportByName("Report_Embedded_PaymentReport");

            if (dcReport == null)
            {
                XtraMessageBox.Show(Resources.Report_NotFound);
                return null;
            }

            // Older seeded report queries are PA-only; money transfers need the embedded CT-compatible query.
            if (dcReport.ReportQuery?.IndexOf("ph.ProcessCode = 'PA'", StringComparison.OrdinalIgnoreCase) >= 0)
                dcReport.ReportQuery = new CustomMethods().GetDataFromFile("Foxoft.AppCode.Report.Report_Embedded_PaymentReport.sql");

            foreach (var item in dcReport.DcReportVariables)
                if (item.VariableProperty == nameof(TrPaymentHeader.PaymentHeaderId))
                    item.VariableValue = paymentHeaderId.ToString();

            return dcReport;
        }

        private void bBI_reportPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowReportPreview();
        }

        private void ShowReportPreview()
        {
            gV_PaymentLine.PostEditor();
            gV_PaymentLine.UpdateCurrentRow();

            if (trPaymentHeader is null || !efMethods.EntityExists<TrPaymentHeader>(trPaymentHeader.PaymentHeaderId))
            {
                XtraMessageBox.Show(Resources.Form_MoneyTransfer_NoPaymentToPrint);
                return;
            }

            DcReport? dcReport = GetPaymentReportDefinition(trPaymentHeader.PaymentHeaderId);

            if (dcReport == null)
                return;

            FormReportPreview form = new(dcReport.ReportQuery, "", dcReport);
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private async void BBI_ReportPrintFast_ItemClick(object sender, ItemClickEventArgs e)
        {
            await PrintFast(GetPrinterName(dcTerminal?.PrinterName));
        }

        private async Task PrintFast(string printerName)
        {
            gV_PaymentLine.PostEditor();
            gV_PaymentLine.UpdateCurrentRow();

            alertControl1.Show(
                this,
                Resources.Common_PrintSending,
                string.Format(Resources.Common_PrinterLabel, printerName),
                string.Empty,
                (Image)null,
                null);

            if (trPaymentHeader is not null && efMethods.EntityExists<TrPaymentHeader>(trPaymentHeader.PaymentHeaderId))
                await Task.Run(() => GetPrint(trPaymentHeader.PaymentHeaderId, printerName));
            else
                XtraMessageBox.Show(Resources.Form_MoneyTransfer_NoPaymentToPrint);

            alertControl1.Show(
                this,
                Resources.Common_PrintSent,
                string.Format(Resources.Common_PrinterLabel, printerName),
                string.Empty,
                (Image)null,
                null);
        }

        private void GetPrint(Guid paymentHeaderId, string printerName)
        {
            XtraReport? xtraReport = GetPaymentReport(paymentHeaderId);

            if (xtraReport is null)
                return;

            using (xtraReport)
            {
                xtraReport.PrinterName = printerName;

                ReportPrintTool printTool = new(xtraReport);
                printTool.Print();
            }
        }

        private static string GetPrinterName(string? printerName)
        {
            return string.IsNullOrWhiteSpace(printerName)
                ? new PrinterSettings().PrinterName
                : printerName;
        }

        private async Task SendWhatsAppViaEvolutionApi(string number, MemoryStream memoryStream)
        {
            if (string.IsNullOrEmpty(number))
            {
                MessageBox.Show(Resources.Form_MoneyTransfer_PhoneNotDefined);
                return;
            }

            var apiSetting = efMethods.SelectEntityById<DcWhatsAppProviderSetting>(1);
            if (apiSetting == null || string.IsNullOrEmpty(apiSetting.ServerUrl) || string.IsNullOrEmpty(apiSetting.InstanceName) || string.IsNullOrEmpty(apiSetting.ApiKey))
            {
                XtraMessageBox.Show(Resources.Payment_ApiSettingsIncomplete);
                return;
            }

            string formattedNumber = number.Trim().Replace("+", "").Replace(" ", "");
            string caption = GetWhatsAppCaption();

            if (!WhatsAppCreditService.HasEnoughBalance())
            {
                SaveWhatsAppLog(trPaymentHeader.PaymentHeaderId, formattedNumber, memoryStream, caption, isSuccessful: false);
                XtraMessageBox.Show(Resources.Common_InsufficientBalance);
                return;
            }

            try
            {
                using var client = new EvolutionApiClient(apiSetting.ServerUrl, apiSetting.InstanceName, apiSetting.ApiKey);

                await client.SendImageBase64Async(formattedNumber, memoryStream, caption: caption);

                SaveWhatsAppLog(trPaymentHeader.PaymentHeaderId, formattedNumber, memoryStream, caption, isSuccessful: true);

                XtraMessageBox.Show(Resources.Common_SentSuccessfully, Resources.Form_MoneyTransfer_Button_SendWhatsapp, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                SaveWhatsAppLog(trPaymentHeader.PaymentHeaderId, formattedNumber, memoryStream, caption, isSuccessful: false);
                XtraMessageBox.Show(Resources.Common_ErrorOccurred + " " + ex.Message);
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
                    MessageType = trPaymentHeader?.DcProcess?.ProcessDesc,
                    Message = message,
                    Sender = Authorization.CurrAccCode,
                    CurrAccCode = trPaymentHeader?.CurrAccCode,
                    ImageFilePath = imageFilePath,
                    IsSuccessful = isSuccessful
                });

                if (isSuccessful)
                    ctx.TrCredits.Add(WhatsAppCreditService.CreateUsage(trPaymentHeader?.DcProcess?.ProcessDesc, receiverPhone));

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
                string? whatsAppFolder = CustomExtensions.CombinePath(settingStore?.ImageFolder, "WhatsApp");
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
                Debug.Print($"WhatsApp image save error: {ex.Message}");
                return null;
            }
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
                MessageBox.Show(Resources.Form_MoneyTransfer_NumberNotDefined);
                return;
            }

            string link = $"https://web.whatsapp.com/send?phone={number}&text={Uri.EscapeDataString(message)}";

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

                BalanceBefore = Math.Round(efMethods.SelectCashRegBalance(trPaymentHeader.CurrAccCode, trPaymentHeader.OperationDate.Add(trPaymentHeader.OperationTime)), 2);
                CalcCashRegBalance();
            }
        }

        private void FromCashRegCodeButtonEdit_EditValueChanged(object sender, EventArgs e)
        {
            SavePayment();
        }

        private void ToCashRegCodeButtonEdit_EditValueChanged(object sender, EventArgs e)
        {
            SavePayment();
        }

        private void CashReg_Validating(object sender, CancelEventArgs e)
        {
            ButtonEdit be = sender as ButtonEdit;
            if (be == null)
                return;

            string code = (be.EditValue ?? string.Empty).ToString().Trim();

            bool isFromCashReg = be == FromCashRegCodeButtonEdit;

            string emptyMessage = isFromCashReg
                ? "Çıxış kassası seçilməlidir."
                : "Giriş kassası seçilməlidir.";

            LabelControl targetLabel = isFromCashReg
                ? lbl_FromCashRegDesc
                : lbl_ToCashRegDesc;

            if (string.IsNullOrWhiteSpace(code))
            {
                be.ErrorText = emptyMessage;
                targetLabel.Text = string.Empty;
                e.Cancel = true;
                return;
            }

            DcCurrAcc cashReg = efMethods.SelectCashReg(code);

            if (cashReg == null)
            {
                be.ErrorText = "Belə kassa mövcud deyil.";
                targetLabel.Text = string.Empty;
                e.Cancel = true;
                return;
            }

            be.ErrorText = string.Empty;
            targetLabel.Text = $"{cashReg.CurrAccDesc} {cashReg.FirstName} {cashReg.LastName}".Trim();
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

            XtraMessageBox.Show(createdUserName + "\n\n" + createdDate + "\n\n" + updatedUserName + "\n\n" + updatedDate, Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void popupMenuPrinters_BeforePopup(object sender, CancelEventArgs e)
        {
            if (sender is not PopupMenu menu)
            {
                e.Cancel = true;
                return;
            }

            menu.ItemLinks.Clear();

            try
            {
                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
                    BarButtonItem bBI = new();
                    bBI.Caption = printer;
                    bBI.Name = printer;
                    bBI.ImageOptions.ImageUri.Uri = "Print";
                    bBI.ItemClick += async (sender, e) =>
                    {
                        await PrintFast(printer);
                    };

                    menu.AddItem(bBI);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(Resources.Form_MoneyTransfer_PrinterError, ex.Message));
            }

            e.Cancel = false;
        }

        private void NavigateToAdjacentMoneyTransfer(bool isPrevious)
        {
            if (trPaymentHeader is null)
                return;

            using var ctx = new subContext();

            TrPaymentHeader adjacent;

            if (isPrevious)
            {
                adjacent = ctx.TrPaymentHeaders
                    .Where(x => x.ProcessCode == "CT" && x.IsMainTF == true)
                    .Where(x => x.OperationDate < trPaymentHeader.OperationDate
                             || (x.OperationDate == trPaymentHeader.OperationDate
                                 && x.OperationTime < trPaymentHeader.OperationTime)
                             || (x.OperationDate == trPaymentHeader.OperationDate
                                 && x.OperationTime == trPaymentHeader.OperationTime
                                 && x.PaymentHeaderId != trPaymentHeader.PaymentHeaderId
                                 && string.Compare(x.DocumentNumber, trPaymentHeader.DocumentNumber) < 0))
                    .OrderByDescending(x => x.OperationDate)
                    .ThenByDescending(x => x.OperationTime)
                    .ThenByDescending(x => x.DocumentNumber)
                    .FirstOrDefault();
            }
            else
            {
                adjacent = ctx.TrPaymentHeaders
                    .Where(x => x.ProcessCode == "CT" && x.IsMainTF == true)
                    .Where(x => x.OperationDate > trPaymentHeader.OperationDate
                             || (x.OperationDate == trPaymentHeader.OperationDate
                                 && x.OperationTime > trPaymentHeader.OperationTime)
                             || (x.OperationDate == trPaymentHeader.OperationDate
                                 && x.OperationTime == trPaymentHeader.OperationTime
                                 && x.PaymentHeaderId != trPaymentHeader.PaymentHeaderId
                                 && string.Compare(x.DocumentNumber, trPaymentHeader.DocumentNumber) > 0))
                    .OrderBy(x => x.OperationDate)
                    .ThenBy(x => x.OperationTime)
                    .ThenBy(x => x.DocumentNumber)
                    .FirstOrDefault();
            }

            if (adjacent is null)
            {
                XtraMessageBox.Show(Resources.Common_NoMoreRecords, Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LoadPayment(adjacent.PaymentHeaderId);
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
