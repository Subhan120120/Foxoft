using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using Foxoft.AppCode;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Foxoft.Models.Entity.Report;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormPayrollEdit : RibbonForm
    {
        private Guid? id;
        private TrPayrollHeader entity;
        private BindingList<TrPayrollLine> lines = new();
        private EfMethods efMethods = new();

        public FormPayrollEdit(Guid? payrollHeaderId)
        {
            InitializeComponent();
            id = payrollHeaderId;

            Text = id == null ? Properties.Resources.Form_PayrollEdit_Caption_New : Properties.Resources.Form_PayrollEdit_Caption_Edit;

            btnEditEmployee.ButtonClick += btnEditEmployee_ButtonClick;

            btnAddLine.Click += (_, __) => AddLine();
            btnRemoveLine.Click += (_, __) => RemoveLine();

            viewLines.CustomDrawRowIndicator += (s, e) =>
            {
                if (e.Info.IsRowIndicator && e.RowHandle >= 0) e.Info.DisplayText = (e.RowHandle + 1).ToString();
            };

            var repoType = new RepositoryItemComboBox();
            repoType.Items.AddRange(Enum.GetNames(typeof(PayrollItemType)));

            var repoAmount = new RepositoryItemCalcEdit();
            repoAmount.DisplayFormat.FormatString = "n2";
            repoAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            var repoCurrency = new RepositoryItemLookUpEdit();
            using (var dbCur = new subContext())
            {
                repoCurrency.DataSource = dbCur.DcCurrencies.AsNoTracking().OrderBy(x => x.CurrencyCode).ToList();
            }
            repoCurrency.DisplayMember = "CurrencyCode";
            repoCurrency.ValueMember = "CurrencyCode";
            repoCurrency.NullText = "";
            repoCurrency.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            repoCurrency.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            repoCurrency.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrencyCode", Properties.Resources.Entity_Currency_Code));
            repoCurrency.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrencyDesc", Properties.Resources.Entity_Currency_Desc));
            repoCurrency.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ExchangeRate", Properties.Resources.Entity_Currency_ExchangeRate, 20, DevExpress.Utils.FormatType.Numeric, "n4", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default));

            var repoExRate = new RepositoryItemCalcEdit();
            repoExRate.DisplayFormat.FormatString = "n4";
            repoExRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repoExRate.Mask.EditMask = "n4";

            var repoAmountLoc = new RepositoryItemCalcEdit();
            repoAmountLoc.DisplayFormat.FormatString = "n2";
            repoAmountLoc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            gridLines.RepositoryItems.Add(repoType);
            gridLines.RepositoryItems.Add(repoAmount);
            gridLines.RepositoryItems.Add(repoCurrency);
            gridLines.RepositoryItems.Add(repoExRate);
            gridLines.RepositoryItems.Add(repoAmountLoc);

            viewLines.Columns.AddVisible(nameof(TrPayrollLine.PayrollItemType), Properties.Resources.Entity_TrPayrollLine_PayrollItemType).ColumnEdit = repoType;
            viewLines.Columns.AddVisible(nameof(TrPayrollLine.Description), Properties.Resources.Entity_TrPayrollLine_Description);
            viewLines.Columns.AddVisible(nameof(TrPayrollLine.Amount), Properties.Resources.Entity_TrPayrollLine_Amount).ColumnEdit = repoAmount;
            viewLines.Columns.AddVisible(nameof(TrPayrollLine.CurrencyCode), Properties.Resources.Entity_Currency_Code).ColumnEdit = repoCurrency;
            viewLines.Columns.AddVisible(nameof(TrPayrollLine.ExchangeRate), Properties.Resources.Entity_Currency_ExchangeRate).ColumnEdit = repoExRate;
            var colAmtLoc = viewLines.Columns.AddVisible(nameof(TrPayrollLine.AmountLoc), Properties.Resources.Entity_InvoiceLine_AmountLoc);
            colAmtLoc.ColumnEdit = repoAmountLoc;
            colAmtLoc.OptionsColumn.AllowEdit = false;

            repoCurrency.EditValueChanged += (s, e) =>
            {
                if (s is LookUpEdit editor && editor.EditValue != null)
                {
                    string code = editor.EditValue.ToString()?.Trim() ?? string.Empty;
                    using var cDb = new subContext();
                    var cur = cDb.DcCurrencies.AsNoTracking().FirstOrDefault(x => x.CurrencyCode == code);
                    float rate = cur?.ExchangeRate ?? 1f;

                    viewLines.PostEditor();
                    viewLines.SetFocusedRowCellValue(nameof(TrPayrollLine.CurrencyCode), cur?.CurrencyCode ?? code);
                    viewLines.SetFocusedRowCellValue(nameof(TrPayrollLine.ExchangeRate), rate);

                    var row = viewLines.GetFocusedRow() as TrPayrollLine;
                    if (row != null)
                    {
                        row.ExchangeRate = rate;
                        row.AmountLoc = Math.Round(row.Amount / (rate == 0 ? 1m : (decimal)rate), 2);
                        viewLines.SetFocusedRowCellValue(nameof(TrPayrollLine.AmountLoc), row.AmountLoc);
                    }
                    viewLines.RefreshRow(viewLines.FocusedRowHandle);
                    RecalculateTotals();
                }
            };

            viewLines.CellValueChanged += (s, e) =>
            {
                var row = viewLines.GetRow(e.RowHandle) as TrPayrollLine;
                if (row != null)
                {
                    decimal rate = row.ExchangeRate == 0 ? 1m : (decimal)row.ExchangeRate;
                    row.AmountLoc = Math.Round(row.Amount / rate, 2);
                    if (e.Column.FieldName != nameof(TrPayrollLine.AmountLoc))
                    {
                        viewLines.SetRowCellValue(e.RowHandle, nameof(TrPayrollLine.AmountLoc), row.AmountLoc);
                    }
                }
                RecalculateTotals();
            };
            viewLines.RowDeleted += (s, e) => RecalculateTotals();

            Load += (_, __) => LoadEntity();
        }

        private void btnEditEmployee_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FormCurrAccList formCommonList = new(new byte[] { 3 }, false, btnEditEmployee.EditValue?.ToString());
            if (formCommonList.ShowDialog() == DialogResult.OK)
            {
                btnEditEmployee.EditValue = formCommonList.dcCurrAcc.CurrAccCode;
                string name = $"{formCommonList.dcCurrAcc.FirstName} {formCommonList.dcCurrAcc.LastName}".Trim();
                if (string.IsNullOrWhiteSpace(name))
                    name = formCommonList.dcCurrAcc.CurrAccDesc ?? string.Empty;
                txtEmployeeName.Text = name;
                LoadActiveContractForEmployee(formCommonList.dcCurrAcc.CurrAccCode);
            }
        }

        private void LoadEntity()
        {
            using var db = new subContext();
            var periods = db.DcPayrollPeriods.AsNoTracking()
                .OrderByDescending(x => x.PeriodYear)
                .ThenByDescending(x => x.PeriodMonth)
                .ToList()
                .Select(x => new 
                { 
                    x.Id, 
                    x.PeriodYear,
                    x.PeriodMonth,
                    PeriodName = $"{x.PeriodYear:0000}-{x.PeriodMonth:00}" + (x.IsClosed ? " (Closed)" : "")
                })
                .ToList();
            lkpPeriod.Properties.DataSource = periods;

            if (id == null)
            {
                entity = new TrPayrollHeader
                {
                    Id = Guid.NewGuid()
                };
                lines = new BindingList<TrPayrollLine>();
            }
            else
            {
                entity = db.TrPayrollHeaders.AsNoTracking()
                    .Include(x => x.Lines)
                    .First(x => x.Id == id.Value);

                lines = new BindingList<TrPayrollLine>(
                    entity.Lines
                        .OrderBy(x => x.PayrollItemType)
                        .Select(x => new TrPayrollLine
                        {
                            Id = x.Id,
                            PayrollHeaderId = entity.Id,
                            PayrollItemType = x.PayrollItemType,
                            Description = x.Description,
                            Amount = x.Amount,
                            CurrencyCode = x.CurrencyCode,
                            ExchangeRate = x.ExchangeRate,
                            AmountLoc = x.AmountLoc
                        }).ToList()
                );
                
                var emp = db.DcCurrAccs.AsNoTracking().FirstOrDefault(x => x.CurrAccCode == entity.CurrAccCode);
                if (emp != null)
                {
                    string name = $"{emp.FirstName} {emp.LastName}".Trim();
                    if (string.IsNullOrWhiteSpace(name))
                        name = emp.CurrAccDesc ?? string.Empty;
                    txtEmployeeName.Text = name;
                }
            }

            btnEditEmployee.EditValue = entity.CurrAccCode == string.Empty ? null : entity.CurrAccCode;
            lkpPeriod.EditValue = entity.PayrollPeriodId == Guid.Empty ? null : (Guid?)entity.PayrollPeriodId;

            gridLines.DataSource = lines;
            viewLines.BestFitColumns();

            spGrossSalary.Value = entity.GrossSalary;
            spNetSalary.Value = entity.NetSalary;
            lines.ListChanged += (s, e) => RecalculateTotals();

            UpdateWhatsAppIcon(entity.Id);
        }

        private void AddLine()
        {
            var line = new TrPayrollLine
            {
                Id = Guid.NewGuid(),
                PayrollHeaderId = entity.Id,
                PayrollItemType = PayrollItemType.Salary,
                Amount = 0,
                CurrencyCode = Properties.Settings.Default.AppSetting?.LocalCurrencyCode ?? "AZN",
                ExchangeRate = 1f,
                AmountLoc = 0
            };
            lines.Add(line);

            viewLines.FocusedRowHandle = viewLines.RowCount - 1;
            viewLines.FocusedColumn = viewLines.Columns[nameof(TrPayrollLine.PayrollItemType)];
            viewLines.ShowEditor();
        }

        private void RemoveLine()
        {
            var row = viewLines.GetFocusedRow() as TrPayrollLine;
            if (row == null) return;

            if (XtraMessageBox.Show(this, Properties.Resources.Form_PayrollEdit_RemoveLineConfirm, Properties.Resources.Common_Confirm,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            lines.Remove(row);
        }

        private void bBI_SaveAndClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Save())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void bBI_reportPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowReportPreview();
        }

        private void ShowReportPreview()
        {
            if (entity == null) return;

            if (id == null || entity.Id == Guid.Empty)
            {
                if (!Save()) return;
            }

            //PayrollReportService.EnsurePayrollReportRepx();

            DcReport dcReport = efMethods.SelectReportByName(PayrollReportService.PayrollReportName);

            if (dcReport == null)
            {
                XtraMessageBox.Show(Properties.Resources.Report_NotFound);
                return;
            }

            if (string.IsNullOrWhiteSpace(dcReport.ReportQuery))
                dcReport.ReportQuery = new CustomMethods().GetDataFromFile("Foxoft.AppCode.Report." + PayrollReportService.PayrollReportName + ".sql");

            foreach (var item in dcReport.DcReportVariables)
            {
                if (string.Equals(item.VariableProperty, "PayrollHeaderId", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(item.VariableProperty, nameof(TrPayrollHeader.Id), StringComparison.OrdinalIgnoreCase))
                {
                    item.VariableValue = entity.Id.ToString();
                }
            }

            FormReportPreview form = new(dcReport.ReportQuery, "", dcReport);
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private async void bBI_SendWhatsapp_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (entity == null) return;

            if (id == null || entity.Id == Guid.Empty)
            {
                if (!Save()) return;
            }

            if (string.IsNullOrEmpty(entity.CurrAccCode))
            {
                XtraMessageBox.Show(this, Properties.Resources.Form_Payment_CurrAccNotSelected, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> phoneNums = efMethods.SelectCurrAccWhatsappRecipients(entity.CurrAccCode);
            if (phoneNums.Count == 0)
            {
                XtraMessageBox.Show(this, Properties.Resources.Form_PaymentDetail_PhoneNotFound, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MemoryStream? memoryStream = PayrollReportService.GetPayrollReportImg(entity.Id);
            if (memoryStream == null)
            {
                XtraMessageBox.Show(this, Properties.Resources.Report_NotFound, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string empName = txtEmployeeName.Text;
            string periodName = lkpPeriod.Text;
            string caption = string.Format(Properties.Resources.Form_PayrollEdit_WhatsAppCaption, empName, periodName);

            if (Properties.Settings.Default.AppSetting?.WhatsAppProvider == WhatsAppProvider.API)
            {
                foreach (string phoneNum in phoneNums)
                {
                    await PayrollReportService.SendWhatsAppViaEvolutionApiAsync(
                        entity.Id,
                        entity.CurrAccCode,
                        phoneNum,
                        memoryStream,
                        caption,
                        this,
                        alertControl1);
                }
            }
            else
            {
                foreach (string phoneNum in phoneNums)
                {
                    PayrollReportService.SendWhatsAppWeb(phoneNum, caption, memoryStream);
                }
            }

            UpdateWhatsAppIcon(entity.Id);
        }

        private void UpdateWhatsAppIcon(Guid payrollHeaderId)
        {
            try
            {
                bool isSent = PayrollReportService.IsWhatsAppSent(payrollHeaderId);
                string svgKey = isSent ? "whatsapp_sent" : "whatsapp_unsend";
                bBI_SendWhatsapp.ImageOptions.SvgImage = svgImageCollection1[svgKey];
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print($"WhatsApp icon update error: {ex.Message}");
            }
        }

        private bool Save()
        {
            viewLines.CloseEditor();
            viewLines.UpdateCurrentRow();

            RecalculateTotals();

            if (btnEditEmployee.EditValue == null)
            {
                XtraMessageBox.Show(this, string.Format(Properties.Resources.Validation_Required, Properties.Resources.Entity_TrPayrollHeader_CurrAccCode),
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (lkpPeriod.EditValue == null)
            {
                XtraMessageBox.Show(this, string.Format(Properties.Resources.Validation_Required, Properties.Resources.Entity_TrPayrollHeader_PeriodId),
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            entity.CurrAccCode = btnEditEmployee.EditValue?.ToString();
            entity.PayrollPeriodId = (Guid)lkpPeriod.EditValue;

            if (!EntityValidationHelper.TryValidate(entity, out var msgHeader))
            {
                XtraMessageBox.Show(this, msgHeader, Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            foreach (var ln in lines)
            {
                ln.PayrollHeaderId = entity.Id;
                if (ln.Id == Guid.Empty) ln.Id = Guid.NewGuid();

                if (!EntityValidationHelper.TryValidate(ln, out var msgLine))
                {
                    XtraMessageBox.Show(this, msgLine, Properties.Resources.Common_Attention,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            try
            {
                using var saveDb = new subContext();
                var strategy = saveDb.Database.CreateExecutionStrategy();

                strategy.Execute(() =>
                {
                    using var tran = saveDb.Database.BeginTransaction();

                    if (id == null)
                    {
                        var newHeader = new TrPayrollHeader
                        {
                            Id = entity.Id == Guid.Empty ? Guid.NewGuid() : entity.Id,
                            CurrAccCode = entity.CurrAccCode,
                            PayrollPeriodId = entity.PayrollPeriodId
                        };

                        foreach (var ln in lines)
                        {
                            decimal rate = ln.ExchangeRate == 0 ? 1m : (decimal)ln.ExchangeRate;
                            decimal amtLoc = Math.Round(ln.Amount / rate, 2);
                            string currCode = string.IsNullOrWhiteSpace(ln.CurrencyCode) ? (Properties.Settings.Default.AppSetting?.LocalCurrencyCode ?? "AZN") : ln.CurrencyCode;
                            float exRate = ln.ExchangeRate == 0 ? 1f : ln.ExchangeRate;

                            newHeader.Lines.Add(new TrPayrollLine
                            {
                                Id = ln.Id == Guid.Empty ? Guid.NewGuid() : ln.Id,
                                PayrollHeaderId = newHeader.Id,
                                PayrollItemType = ln.PayrollItemType,
                                Description = ln.Description,
                                Amount = ln.Amount,
                                CurrencyCode = currCode,
                                ExchangeRate = exRate,
                                AmountLoc = amtLoc
                            });
                        }

                        saveDb.TrPayrollHeaders.Add(newHeader);
                        saveDb.SaveChanges();
                        tran.Commit();

                        id = newHeader.Id;
                        entity.Id = newHeader.Id;
                        Text = Properties.Resources.Form_PayrollEdit_Caption_Edit;
                    }
                    else
                    {
                        var dbEntity = saveDb.TrPayrollHeaders
                            .Include(x => x.Lines)
                            .FirstOrDefault(x => x.Id == entity.Id);

                        if (dbEntity == null)
                        {
                            throw new Exception("Payroll record not found in database.");
                        }

                        dbEntity.CurrAccCode = entity.CurrAccCode;
                        dbEntity.PayrollPeriodId = entity.PayrollPeriodId;

                        var incomingIds = lines.Select(x => x.Id).ToHashSet();
                        var toRemove = dbEntity.Lines.Where(x => !incomingIds.Contains(x.Id)).ToList();
                        saveDb.TrPayrollLines.RemoveRange(toRemove);

                        foreach (var ln in lines)
                        {
                            decimal rate = ln.ExchangeRate == 0 ? 1m : (decimal)ln.ExchangeRate;
                            decimal amtLoc = Math.Round(ln.Amount / rate, 2);
                            string currCode = string.IsNullOrWhiteSpace(ln.CurrencyCode) ? (Properties.Settings.Default.AppSetting?.LocalCurrencyCode ?? "AZN") : ln.CurrencyCode;
                            float exRate = ln.ExchangeRate == 0 ? 1f : ln.ExchangeRate;

                            var existing = dbEntity.Lines.FirstOrDefault(x => x.Id == ln.Id);
                            if (existing == null)
                            {
                                saveDb.TrPayrollLines.Add(new TrPayrollLine
                                {
                                    Id = ln.Id == Guid.Empty ? Guid.NewGuid() : ln.Id,
                                    PayrollHeaderId = dbEntity.Id,
                                    PayrollItemType = ln.PayrollItemType,
                                    Description = ln.Description,
                                    Amount = ln.Amount,
                                    CurrencyCode = currCode,
                                    ExchangeRate = exRate,
                                    AmountLoc = amtLoc
                                });
                            }
                            else
                            {
                                existing.PayrollItemType = ln.PayrollItemType;
                                existing.Description = ln.Description;
                                existing.Amount = ln.Amount;
                                existing.CurrencyCode = currCode;
                                existing.ExchangeRate = exRate;
                                existing.AmountLoc = amtLoc;
                            }
                        }

                        saveDb.SaveChanges();
                        tran.Commit();
                    }
                });

                UpdateWhatsAppIcon(entity.Id);
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this,
                    ex.InnerException?.Message ?? ex.Message,
                    Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        private void RecalculateTotals()
        {
            if (entity == null) return;

            decimal gross = 0;
            decimal deductions = 0;

            foreach (var line in lines)
            {
                decimal rate = line.ExchangeRate == 0 ? 1m : (decimal)line.ExchangeRate;
                line.AmountLoc = Math.Round(line.Amount / rate, 2);

                if (line.PayrollItemType == PayrollItemType.Salary ||
                    line.PayrollItemType == PayrollItemType.Bonus ||
                    line.PayrollItemType == PayrollItemType.Overtime)
                {
                    gross += line.AmountLoc;
                }
                else if (line.PayrollItemType == PayrollItemType.Tax ||
                         line.PayrollItemType == PayrollItemType.Insurance ||
                         line.PayrollItemType == PayrollItemType.Deduction)
                {
                    deductions += line.AmountLoc;
                }
            }

            entity.Lines = lines.ToList();
            entity.GrossSalary = gross;
            entity.NetSalary = gross - deductions;

            spGrossSalary.Value = entity.GrossSalary;
            spNetSalary.Value = entity.NetSalary;
        }

        private void LoadActiveContractForEmployee(string currAccCode)
        {
            if (id == null && lines.Count == 0 && !string.IsNullOrEmpty(currAccCode))
            {
                using var db = new subContext();
                var today = DateTime.Today;
                var activeContract = db.TrEmployeeContracts.AsNoTracking()
                    .Where(x => x.CurrAccCode == currAccCode && x.StartDate <= today && (x.EndDate == null || x.EndDate >= today))
                    .OrderByDescending(x => x.StartDate)
                    .FirstOrDefault();

                if (activeContract != null)
                {
                    string currCode = activeContract.CurrencyCode ?? Properties.Settings.Default.AppSetting?.LocalCurrencyCode ?? "AZN";
                    float rate = 1f;
                    var cur = db.DcCurrencies.AsNoTracking().FirstOrDefault(c => c.CurrencyCode == currCode);
                    if (cur != null && cur.ExchangeRate > 0)
                        rate = cur.ExchangeRate;

                    decimal amt = activeContract.BaseSalary;
                    decimal amtLoc = Math.Round(amt / (decimal)rate, 2);

                    var salaryLine = new TrPayrollLine
                    {
                        Id = Guid.NewGuid(),
                        PayrollHeaderId = entity.Id,
                        PayrollItemType = PayrollItemType.Salary,
                        Description = Properties.Resources.Form_PayrollEdit_BaseSalaryFromContract,
                        Amount = amt,
                        CurrencyCode = currCode,
                        ExchangeRate = rate,
                        AmountLoc = amtLoc
                    };
                    lines.Add(salaryLine);
                    RecalculateTotals();
                }
            }
        }
    }
}
