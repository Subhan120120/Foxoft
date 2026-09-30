using DevExpress.DataAccess.Sql;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using Foxoft.Models;
using Foxoft.Models.Entity.Report;
using Foxoft.Properties;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft.AppCode.Service
{
    public static class PayrollReportService
    {
        public const string PayrollReportName = "Report_Embedded_PayrollReport";

        public static DcReport GetPayrollReportDefinition(Guid payrollHeaderId)
        {
            EfMethods efMethods = new();
            DcReport? dcReport = efMethods.SelectReportByName(PayrollReportName);

            if (dcReport == null)
            {
                string sql = new CustomMethods().GetDataFromFile("Foxoft.AppCode.Report." + PayrollReportName + ".sql");
                dcReport = new DcReport
                {
                    ReportId = 10,
                    ReportTypeId = 0,
                    ReportName = PayrollReportName,
                    ReportQuery = sql,
                    DcReportVariables = new List<DcReportVariable>
                    {
                        new DcReportVariable
                        {
                            VariableId = 5,
                            ReportId = 10,
                            VariableProperty = "PayrollHeaderId",
                            Representative = "@PayrollHeaderId",
                            VariableTypeId = 1,
                            VariableValueType = "System.Guid",
                            VariableValue = payrollHeaderId.ToString()
                        }
                    }
                };
            }
            else
            {
                if (string.IsNullOrWhiteSpace(dcReport.ReportQuery))
                {
                    dcReport.ReportQuery = new CustomMethods().GetDataFromFile("Foxoft.AppCode.Report." + PayrollReportName + ".sql");
                }

                bool found = false;
                foreach (var item in dcReport.DcReportVariables)
                {
                    if (string.Equals(item.VariableProperty, "PayrollHeaderId", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(item.VariableProperty, "Id", StringComparison.OrdinalIgnoreCase))
                    {
                        item.VariableValue = payrollHeaderId.ToString();
                        found = true;
                    }
                }

                if (!found)
                {
                    dcReport.DcReportVariables.Add(new DcReportVariable
                    {
                        VariableProperty = "PayrollHeaderId",
                        Representative = "@PayrollHeaderId",
                        VariableTypeId = 1,
                        VariableValueType = "System.Guid",
                        VariableValue = payrollHeaderId.ToString()
                    });
                }
            }

            return dcReport;
        }


        public static XtraReport? GetPayrollReport(Guid payrollHeaderId)
        {
            try
            {
                EfMethods efMethods = new();
                SettingStore settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);
                ReportClass reportClass = new(settingStore?.DesignFileFolder ?? string.Empty);
                DcReport dcReport = GetPayrollReportDefinition(payrollHeaderId);

                SqlParameter[] sqlParameters;
                string query = reportClass.ApplyFilter(dcReport, dcReport.ReportQuery, "", out sqlParameters);
                List<QueryParameter> qryParams = reportClass.ConvertSqlParametersToQueryParameters(sqlParameters);
                CustomSqlQuery mainQuery = new("Main", query);
                mainQuery.Parameters.AddRange(qryParams);
                List<CustomSqlQuery> sqlQueries = new(new[] { mainQuery });

                return reportClass.GetReport(dcReport.ReportName, dcReport.ReportName + ".repx", sqlQueries);
            }
            catch (Exception ex)
            {
                Debug.Print($"GetPayrollReport repx load error: {ex.Message}");
                return null;
            }
        }


        public static MemoryStream? GetPayrollReportImg(Guid payrollHeaderId)
        {
            XtraReport? report = GetPayrollReport(payrollHeaderId);
            if (report == null)
                return null;

            MemoryStream ms = new();
            report.ExportToImage(ms, new ImageExportOptions
            {
                Format = ImageFormat.Png,
                PageRange = "1",
                ExportMode = ImageExportMode.SingleFile,
                Resolution = 240
            });
            report.Dispose();

            if (ms.CanSeek) ms.Position = 0;
            return ms;
        }

        public static void ShowPayrollReportPreview(Guid payrollHeaderId)
        {
            EfMethods efMethods = new();
            DcReport? dcReport = efMethods.SelectReportByName(PayrollReportName);

            if (dcReport == null)
            {
                XtraMessageBox.Show(Resources.Report_NotFound);
                return;
            }

            if (string.IsNullOrWhiteSpace(dcReport.ReportQuery))
                dcReport.ReportQuery = new CustomMethods().GetDataFromFile("Foxoft.AppCode.Report." + PayrollReportName + ".sql");

            foreach (var item in dcReport.DcReportVariables)
            {
                if (string.Equals(item.VariableProperty, "PayrollHeaderId", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(item.VariableProperty, "Id", StringComparison.OrdinalIgnoreCase))
                {
                    item.VariableValue = payrollHeaderId.ToString();
                }
            }

            FormReportPreview form = new(dcReport.ReportQuery, "", dcReport);
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        public static bool IsWhatsAppSent(Guid payrollHeaderId)
        {
            if (payrollHeaderId == Guid.Empty)
                return false;

            try
            {
                using var ctx = new subContext();
                return ctx.TrMessageLogs
                    .Any(x => x.DocumentHeaderId == payrollHeaderId &&
                              x.ChannelCode == NotificationChannels.WhatsApp &&
                              x.IsSuccessful);
            }
            catch (Exception ex)
            {
                Debug.Print($"IsWhatsAppSent check error: {ex.Message}");
                return false;
            }
        }

        public static async Task<bool> SendWhatsAppViaEvolutionApiAsync(
            Guid payrollHeaderId,
            string currAccCode,
            string number,
            MemoryStream memoryStream,
            string caption,
            IWin32Window? owner = null,
            AlertControl? alertControl = null)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                XtraMessageBox.Show(owner, Resources.Form_PaymentDetail_PhoneNotFound, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            EfMethods efMethods = new();
            var apiSetting = efMethods.SelectEntityById<DcWhatsAppProviderSetting>(1);
            if (apiSetting == null || string.IsNullOrEmpty(apiSetting.ServerUrl) || string.IsNullOrEmpty(apiSetting.InstanceName) || string.IsNullOrEmpty(apiSetting.ApiKey))
            {
                XtraMessageBox.Show(owner, Resources.Payment_ApiSettingsIncomplete, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string formattedNumber = number.Trim().Replace("+", "").Replace(" ", "");
            Guid messageLogId = Guid.NewGuid();

            if (!WhatsAppCreditService.HasEnoughBalance())
            {
                SaveWhatsAppLog(payrollHeaderId, currAccCode, formattedNumber, memoryStream, caption, isSuccessful: false, errorMessage: Resources.Common_InsufficientBalance, messageLogId: messageLogId);
                MessageToastService.ShowUnsentToast(NotificationChannels.WhatsApp, formattedNumber, Resources.Common_InsufficientBalance, messageLogId);
                return false;
            }

            try
            {
                using var client = new EvolutionApiClient(apiSetting.ServerUrl, apiSetting.InstanceName, apiSetting.ApiKey);
                string response = await client.SendImageBase64Async(formattedNumber, memoryStream, caption: caption);

                SaveWhatsAppLog(payrollHeaderId, currAccCode, formattedNumber, memoryStream, caption, isSuccessful: true, messageLogId: messageLogId);
                MessageToastService.ShowSentToast(NotificationChannels.WhatsApp, formattedNumber, caption, messageLogId);
                return true;
            }
            catch (Exception ex)
            {
                SaveWhatsAppLog(payrollHeaderId, currAccCode, formattedNumber, memoryStream, caption, isSuccessful: false, errorMessage: ex.Message, messageLogId: messageLogId);
                MessageToastService.ShowUnsentToast(NotificationChannels.WhatsApp, formattedNumber, ex.Message, messageLogId);
                return false;
            }
        }

        public static void SendWhatsAppWeb(string number, string message, MemoryStream? imageStream = null)
        {
            number = number?.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(number))
            {
                XtraMessageBox.Show(Resources.Form_PaymentDetail_PhoneNotFound);
                return;
            }

            if (imageStream != null && imageStream.Length > 0)
            {
                try
                {
                    if (imageStream.CanSeek) imageStream.Position = 0;
                    Clipboard.SetImage(Image.FromStream(imageStream));
                }
                catch (Exception ex)
                {
                    Debug.Print($"Clipboard copy error: {ex.Message}");
                }
            }

            string link = $"https://web.whatsapp.com/send?phone={number}&text={Uri.EscapeDataString(message)}";
            Process myProcess = new();
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.FileName = link;
            myProcess.Start();
        }

        public static void SaveWhatsAppLog(
            Guid documentHeaderId,
            string currAccCode,
            string receiverPhone,
            MemoryStream? imageStream = null,
            string? message = null,
            bool isSuccessful = false,
            string? errorMessage = null,
            Guid? messageLogId = null)
        {
            try
            {
                string? imageFileName = null;
                if (imageStream != null && imageStream.Length > 0)
                {
                    imageFileName = SaveWhatsAppImageToDisk(imageStream);
                }

                using var ctx = new subContext();
                ctx.TrMessageLogs.Add(new TrMessageLog
                {
                    MessageLogId = messageLogId ?? Guid.NewGuid(),
                    DocumentHeaderId = documentHeaderId,
                    ReceiverPhoneNumber = receiverPhone,
                    ChannelCode = NotificationChannels.WhatsApp,
                    MessageType = "Payroll",
                    Message = message,
                    Sender = Authorization.CurrAccCode,
                    CurrAccCode = currAccCode,
                    ImageFileName = imageFileName,
                    IsSuccessful = isSuccessful,
                    LastError = errorMessage,
                    LastTryDate = DateTime.Now
                });

                if (isSuccessful)
                {
                    ctx.TrCredits.Add(WhatsAppCreditService.CreateUsage("Payroll", receiverPhone));
                }

                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.Print($"WhatsApp log save error: {ex.Message}");
            }
        }

        public static string? SaveWhatsAppImageToDisk(MemoryStream imageStream)
        {
            try
            {
                EfMethods efMethods = new();
                SettingStore? settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);
                string whatsAppFolder = CustomExtensions.CombinePath(settingStore?.ImageFolder, "WhatsApp");
                if (string.IsNullOrWhiteSpace(whatsAppFolder))
                    return null;

                if (!Directory.Exists(whatsAppFolder))
                    Directory.CreateDirectory(whatsAppFolder);

                string fileName = $"{Guid.NewGuid()}.png";
                string filePath = Path.Combine(whatsAppFolder, fileName);

                if (imageStream.CanSeek) imageStream.Position = 0;
                File.WriteAllBytes(filePath, imageStream.ToArray());

                return fileName;
            }
            catch (Exception ex)
            {
                Debug.Print($"WhatsApp image save error: {ex.Message}");
                return null;
            }
        }
    }
}
