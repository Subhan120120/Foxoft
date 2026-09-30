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

        public static void EnsurePayrollReportRepx()
        {
            try
            {
                EfMethods efMethods = new();
                SettingStore? settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);
                if (settingStore != null && !string.IsNullOrEmpty(settingStore.DesignFileFolder))
                {
                    if (!Directory.Exists(settingStore.DesignFileFolder))
                        Directory.CreateDirectory(settingStore.DesignFileFolder);

                    string repxPath = Path.Combine(settingStore.DesignFileFolder, PayrollReportName + ".repx");
                    if (!File.Exists(repxPath))
                    {
                        using var defaultReport = CreateDefaultPayrollReport(Guid.Empty);
                        defaultReport.SaveLayoutToXml(repxPath);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print($"EnsurePayrollReportRepx error: {ex.Message}");
            }
        }

        public static XtraReport? GetPayrollReport(Guid payrollHeaderId)
        {
            try
            {
                EnsurePayrollReportRepx();

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
                return CreateDefaultPayrollReport(payrollHeaderId);
            }
        }

        public static XtraReport CreateDefaultPayrollReport(Guid payrollHeaderId)
        {
            using var db = new subContext();
            var header = db.TrPayrollHeaders
                .AsNoTracking()
                .Include(x => x.Lines)
                .Include(x => x.PayrollPeriod)
                .Include(x => x.DcCurrAcc)
                .FirstOrDefault(x => x.Id == payrollHeaderId);

            XtraReport report = new()
            {
                PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4,
                Margins = new DevExpress.Drawing.DXMargins(35, 35, 35, 35),
                ShowPrintMarginsWarning = false
            };

            string localCurr = Settings.Default.AppSetting?.LocalCurrencyCode ?? "AZN";
            string empName = header?.DcCurrAcc != null
                ? (!string.IsNullOrWhiteSpace(header.DcCurrAcc.CurrAccDesc)
                    ? header.DcCurrAcc.CurrAccDesc
                    : $"{header.DcCurrAcc.FirstName} {header.DcCurrAcc.LastName}".Trim())
                : (header?.CurrAccCode ?? string.Empty);

            string periodStr = header?.PayrollPeriod != null
                ? $"{header.PayrollPeriod.PeriodYear:0000}-{header.PayrollPeriod.PeriodMonth:00}"
                : string.Empty;

            EfMethods efMethods = new();
            SettingStore? store = efMethods.SelectSettingStore(Authorization.StoreCode);
            string storeName = store?.DcStore?.CurrAccDesc ?? string.Empty;

            // Report Header Band
            ReportHeaderBand rptHeader = new() { HeightF = 120 };
            report.Bands.Add(rptHeader);

            if (!string.IsNullOrWhiteSpace(storeName))
            {
                XRLabel lblStore = new()
                {
                    Text = storeName,
                    Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                    TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter,
                    SizeF = new SizeF(750, 24),
                    LocationF = new PointF(0, 5)
                };
                rptHeader.Controls.Add(lblStore);
            }

            XRLabel lblTitle = new()
            {
                Text = Resources.Report_PayrollSlip_Title,
                Font = new Font("Segoe UI", 16f, FontStyle.Bold),
                TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter,
                SizeF = new SizeF(750, 30),
                LocationF = new PointF(0, string.IsNullOrWhiteSpace(storeName) ? 5 : 32)
            };
            rptHeader.Controls.Add(lblTitle);

            float topY = string.IsNullOrWhiteSpace(storeName) ? 42 : 68;

            XRLabel lblEmp = new()
            {
                Text = $"{Resources.Common_EmployeeName}: {empName} ({header?.CurrAccCode})",
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                SizeF = new SizeF(450, 20),
                LocationF = new PointF(0, topY)
            };
            rptHeader.Controls.Add(lblEmp);

            XRLabel lblPeriod = new()
            {
                Text = $"{Resources.Entity_TrPayrollHeader_PeriodId}: {periodStr}",
                Font = new Font("Segoe UI", 10f),
                SizeF = new SizeF(450, 20),
                LocationF = new PointF(0, topY + 22)
            };
            rptHeader.Controls.Add(lblPeriod);

            XRLabel lblDate = new()
            {
                Text = $"{DateTime.Now:dd.MM.yyyy HH:mm}",
                Font = new Font("Segoe UI", 9f),
                TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight,
                SizeF = new SizeF(250, 20),
                LocationF = new PointF(500, topY)
            };
            rptHeader.Controls.Add(lblDate);

            // Page Header Band (Table Columns)
            PageHeaderBand pageHeader = new() { HeightF = 28 };
            report.Bands.Add(pageHeader);

            XRTable headerTable = new()
            {
                SizeF = new SizeF(750, 26),
                LocationF = new PointF(0, 0),
                BackColor = Color.FromArgb(240, 243, 246),
                Borders = DevExpress.XtraPrinting.BorderSide.All,
                BorderColor = Color.LightGray
            };

            XRTableRow headerRow = new() { HeightF = 26 };
            headerRow.Cells.Add(new XRTableCell { Text = Resources.Entity_TrPayrollLine_PayrollItemType, WidthF = 140, Font = new Font("Segoe UI", 9f, FontStyle.Bold), TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft, Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0) });
            headerRow.Cells.Add(new XRTableCell { Text = Resources.Entity_TrPayrollLine_Description, WidthF = 220, Font = new Font("Segoe UI", 9f, FontStyle.Bold), TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft, Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0) });
            headerRow.Cells.Add(new XRTableCell { Text = Resources.Entity_TrPayrollLine_Amount, WidthF = 100, Font = new Font("Segoe UI", 9f, FontStyle.Bold), TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight, Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0) });
            headerRow.Cells.Add(new XRTableCell { Text = Resources.Entity_Currency_Code, WidthF = 70, Font = new Font("Segoe UI", 9f, FontStyle.Bold), TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter });
            headerRow.Cells.Add(new XRTableCell { Text = Resources.Entity_Currency_ExchangeRate, WidthF = 80, Font = new Font("Segoe UI", 9f, FontStyle.Bold), TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight, Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0) });
            headerRow.Cells.Add(new XRTableCell { Text = $"{Resources.Entity_InvoiceLine_AmountLoc} ({localCurr})", WidthF = 140, Font = new Font("Segoe UI", 9f, FontStyle.Bold), TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight, Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0) });
            headerTable.Rows.Add(headerRow);
            pageHeader.Controls.Add(headerTable);

            // Detail Band
            DetailBand detail = new() { HeightF = 24 };
            report.Bands.Add(detail);

            XRTable detailTable = new()
            {
                SizeF = new SizeF(750, 24),
                LocationF = new PointF(0, 0),
                Borders = DevExpress.XtraPrinting.BorderSide.Bottom | DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right,
                BorderColor = Color.LightGray
            };

            var orderedLines = header?.Lines?.OrderBy(x => x.PayrollItemType).ToList() ?? new List<TrPayrollLine>();
            foreach (var line in orderedLines)
            {
                XRTableRow row = new() { HeightF = 24 };
                string itemTypeName = GetPayrollItemTypeName(line.PayrollItemType);

                row.Cells.Add(new XRTableCell { Text = itemTypeName, WidthF = 140, Font = new Font("Segoe UI", 9f), TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft, Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0) });
                row.Cells.Add(new XRTableCell { Text = line.Description ?? string.Empty, WidthF = 220, Font = new Font("Segoe UI", 9f), TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft, Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0) });
                row.Cells.Add(new XRTableCell { Text = line.Amount.ToString("N2"), WidthF = 100, Font = new Font("Segoe UI", 9f), TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight, Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0) });
                row.Cells.Add(new XRTableCell { Text = line.CurrencyCode ?? localCurr, WidthF = 70, Font = new Font("Segoe UI", 9f), TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter });
                row.Cells.Add(new XRTableCell { Text = line.ExchangeRate.ToString("N4"), WidthF = 80, Font = new Font("Segoe UI", 9f), TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight, Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0) });
                row.Cells.Add(new XRTableCell { Text = line.AmountLoc.ToString("N2"), WidthF = 140, Font = new Font("Segoe UI", 9f), TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight, Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0) });
                detailTable.Rows.Add(row);
            }
            detail.Controls.Add(detailTable);

            // Report Footer Band (Totals & Signatures)
            ReportFooterBand rptFooter = new() { HeightF = 120 };
            report.Bands.Add(rptFooter);

            XRTable totalTable = new()
            {
                SizeF = new SizeF(750, 48),
                LocationF = new PointF(0, 10),
                Borders = DevExpress.XtraPrinting.BorderSide.All,
                BorderColor = Color.LightGray
            };

            decimal gross = header?.GrossSalary ?? 0;
            decimal net = header?.NetSalary ?? 0;

            XRTableRow grossRow = new() { HeightF = 24 };
            grossRow.Cells.Add(new XRTableCell { Text = $"{Resources.Entity_TrPayrollHeader_GrossSalary}:", WidthF = 550, Font = new Font("Segoe UI", 9.5f, FontStyle.Bold), TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight, Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 10, 0, 0) });
            grossRow.Cells.Add(new XRTableCell { Text = $"{gross:N2} {localCurr}", WidthF = 200, Font = new Font("Segoe UI", 9.5f, FontStyle.Bold), TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight, Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 10, 0, 0) });
            totalTable.Rows.Add(grossRow);

            XRTableRow netRow = new() { HeightF = 24, BackColor = Color.FromArgb(235, 247, 238) };
            netRow.Cells.Add(new XRTableCell { Text = $"{Resources.Entity_TrPayrollHeader_NetSalary}:", WidthF = 550, Font = new Font("Segoe UI", 11f, FontStyle.Bold), TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight, Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 10, 0, 0) });
            netRow.Cells.Add(new XRTableCell { Text = $"{net:N2} {localCurr}", WidthF = 200, Font = new Font("Segoe UI", 11f, FontStyle.Bold), ForeColor = Color.DarkGreen, TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight, Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 10, 0, 0) });
            totalTable.Rows.Add(netRow);

            rptFooter.Controls.Add(totalTable);

            XRLabel lblSigEmp = new()
            {
                Text = $"{Resources.Common_EmployeeSignature}: _______________________",
                Font = new Font("Segoe UI", 9f),
                SizeF = new SizeF(350, 22),
                LocationF = new PointF(20, 80)
            };
            rptFooter.Controls.Add(lblSigEmp);

            XRLabel lblSigMgr = new()
            {
                Text = $"{Resources.Common_ManagerSignature}: _______________________",
                Font = new Font("Segoe UI", 9f),
                TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight,
                SizeF = new SizeF(350, 22),
                LocationF = new PointF(380, 80)
            };
            rptFooter.Controls.Add(lblSigMgr);

            return report;
        }

        private static string GetPayrollItemTypeName(PayrollItemType itemType)
        {
            return itemType switch
            {
                PayrollItemType.Salary => Resources.Entity_TrPayrollHeader_BaseSalary,
                PayrollItemType.Bonus => Resources.Entity_TrPayrollHeader_Bonus,
                PayrollItemType.Overtime => Resources.Entity_TrPayrollLine_Overtime,
                PayrollItemType.Tax => Resources.Entity_TrPayrollLine_Tax,
                PayrollItemType.Insurance => Resources.Entity_TrPayrollLine_Insurance,
                PayrollItemType.Deduction => Resources.Entity_TrPayrollHeader_Deduction,
                _ => Resources.Entity_TrPayrollLine_Other
            };
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
            EnsurePayrollReportRepx();

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
