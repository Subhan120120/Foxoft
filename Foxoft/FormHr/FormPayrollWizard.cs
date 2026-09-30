using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraWizard;
using Foxoft.AppCode;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Foxoft.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Foxoft
{
    public partial class FormPayrollWizard : XtraForm
    {
        private BindingList<PayrollWizardEmployeeVM> employeeList = new();
        private List<DcCurrency> currencies = new();

        public FormPayrollWizard()
        {
            InitializeComponent();
            LoadCurrencies();
            LoadPeriods();
        }

        private void LoadCurrencies()
        {
            using var db = new subContext();
            currencies = db.DcCurrencies.AsNoTracking().OrderBy(x => x.CurrencyCode).ToList();
            repoLookUpCurrency.DataSource = currencies;
        }

        private void LoadPeriods()
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
                    x.IsClosed,
                    PeriodName = $"{x.PeriodYear:0000}-{x.PeriodMonth:00}" + (x.IsClosed ? " (" + Properties.Resources.Entity_TrPayrollPeriod_IsClosed + ")" : "")
                })
                .ToList();

            lkpPeriod.Properties.DataSource = periods;

            if (periods.Any())
            {
                var openPeriod = periods.FirstOrDefault(x => !x.IsClosed) ?? periods.First();
                lkpPeriod.EditValue = openPeriod.Id;
            }
        }

        private void LkpPeriod_EditValueChanged(object sender, EventArgs e)
        {
            employeeList.Clear();
        }

        private void LoadEmployeesForPeriod(Guid periodId)
        {
            using var db = new subContext();
            var period = db.DcPayrollPeriods.AsNoTracking().FirstOrDefault(x => x.Id == periodId);
            if (period == null) return;

            currencies = db.DcCurrencies.AsNoTracking().OrderBy(x => x.CurrencyCode).ToList();
            repoLookUpCurrency.DataSource = currencies;

            DateTime periodStartDate = new(period.PeriodYear, period.PeriodMonth, 1);
            int daysInMonth = DateTime.DaysInMonth(period.PeriodYear, period.PeriodMonth);
            DateTime periodEndDate = new(period.PeriodYear, period.PeriodMonth, daysInMonth);

            var employees = db.DcCurrAccs.AsNoTracking()
                .Where(x => x.CurrAccTypeCode == CurrAccType.Personnel && !x.IsDisabled)
                .OrderBy(x => x.CurrAccCode)
                .ToList();

            var employeeCodes = employees.Select(x => x.CurrAccCode).ToList();

            var contracts = db.TrEmployeeContracts.AsNoTracking()
                .Include(x => x.EmploymentType)
                .Where(x => employeeCodes.Contains(x.CurrAccCode) && x.StartDate <= periodEndDate && (x.EndDate == null || x.EndDate >= periodStartDate))
                .OrderByDescending(x => x.StartDate)
                .ToList();

            var positions = db.TrEmployeePositions.AsNoTracking()
                .Include(x => x.Position)
                .ThenInclude(x => x.Department)
                .Where(x => employeeCodes.Contains(x.CurrAccCode) && x.StartDate <= periodEndDate && (x.EndDate == null || x.EndDate >= periodStartDate))
                .OrderByDescending(x => x.StartDate)
                .ToList();

            var existingPayrolls = db.TrPayrollHeaders.AsNoTracking()
                .Include(x => x.Lines)
                .Where(x => x.PayrollPeriodId == periodId && employeeCodes.Contains(x.CurrAccCode))
                .ToList();

            var localCurrencyCode = Properties.Settings.Default.AppSetting?.LocalCurrencyCode ?? "AZN";
            var defaultCurrency = currencies.FirstOrDefault(c => string.Equals(c.CurrencyCode?.Trim(), localCurrencyCode?.Trim(), StringComparison.OrdinalIgnoreCase)) ?? currencies.FirstOrDefault();

            var list = employees.Select(emp =>
            {
                var activeContract = contracts.FirstOrDefault(c => c.CurrAccCode == emp.CurrAccCode);
                var activePosition = positions.FirstOrDefault(p => p.CurrAccCode == emp.CurrAccCode);
                var existingPayroll = existingPayrolls.FirstOrDefault(p => p.CurrAccCode == emp.CurrAccCode);

                string empName = (!string.IsNullOrEmpty(emp.CurrAccDesc)
                    ? emp.CurrAccDesc
                    : $"{emp.FirstName} {emp.LastName}".Trim());

                string? posName = activePosition?.Position?.PositionName;
                string? deptName = activePosition?.Position?.Department?.DepartmentName;

                decimal baseSalary = activeContract?.BaseSalary ?? 0;
                decimal bonus = 0;
                decimal deduction = 0;
                bool alreadyExists = existingPayroll != null;
                Guid? existingId = existingPayroll?.Id;

                string currCode = !string.IsNullOrEmpty(activeContract?.CurrencyCode)
                    ? activeContract.CurrencyCode.Trim()
                    : (defaultCurrency?.CurrencyCode ?? "AZN");

                var matchedCurrency = currencies.FirstOrDefault(c => string.Equals(c.CurrencyCode?.Trim(), currCode, StringComparison.OrdinalIgnoreCase)) ?? defaultCurrency;
                float exRate = matchedCurrency?.ExchangeRate ?? 1f;

                if (existingPayroll != null)
                {
                    var salaryLine = existingPayroll.Lines.FirstOrDefault(l => l.PayrollItemType == PayrollItemType.Salary);
                    if (salaryLine != null)
                    {
                        baseSalary = salaryLine.Amount;
                        if (!string.IsNullOrEmpty(salaryLine.CurrencyCode))
                        {
                            currCode = salaryLine.CurrencyCode.Trim();
                            exRate = salaryLine.ExchangeRate > 0 ? salaryLine.ExchangeRate : (currencies.FirstOrDefault(c => string.Equals(c.CurrencyCode?.Trim(), currCode, StringComparison.OrdinalIgnoreCase))?.ExchangeRate ?? 1f);
                        }
                    }

                    bonus = existingPayroll.Lines
                        .Where(l => l.PayrollItemType == PayrollItemType.Bonus || l.PayrollItemType == PayrollItemType.Overtime)
                        .Sum(l => l.Amount);

                    deduction = existingPayroll.Lines
                        .Where(l => l.PayrollItemType == PayrollItemType.Tax || l.PayrollItemType == PayrollItemType.Insurance || l.PayrollItemType == PayrollItemType.Deduction)
                        .Sum(l => l.Amount);
                }

                return new PayrollWizardEmployeeVM
                {
                    Selected = true,
                    CurrAccCode = emp.CurrAccCode,
                    EmployeeName = empName,
                    DepartmentName = deptName,
                    PositionName = posName,
                    BaseSalary = baseSalary,
                    Bonus = bonus,
                    Deduction = deduction,
                    CurrencyCode = currCode,
                    ExchangeRate = exRate,
                    AlreadyExists = alreadyExists,
                    ExistingPayrollHeaderId = existingId
                };
            }).ToList();

            employeeList = new BindingList<PayrollWizardEmployeeVM>(list);
            gridControlEmployees.DataSource = employeeList;
            gridViewEmployees.BestFitColumns();
        }

        private void WizardControl1_NextClick(object sender, WizardCommandButtonClickEventArgs e)
        {
            if (e.Page == welcomeWizardPage1)
            {
                if (lkpPeriod.EditValue == null)
                {
                    XtraMessageBox.Show(this,
                        Properties.Resources.Form_PayrollWizard_NoPeriodSelected,
                        Properties.Resources.Common_Attention,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    e.Handled = true;
                    return;
                }

                LoadEmployeesForPeriod((Guid)lkpPeriod.EditValue);
            }
            else if (e.Page == wizardPageEmployees)
            {
                gridViewEmployees.CloseEditor();
                gridViewEmployees.UpdateCurrentRow();

                var selectedCount = employeeList.Count(x => x.Selected);
                if (selectedCount == 0)
                {
                    XtraMessageBox.Show(this,
                        Properties.Resources.Form_PayrollWizard_NoEmployeesSelected,
                        Properties.Resources.Common_Attention,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    e.Handled = true;
                    return;
                }

                decimal totalGross = employeeList.Where(x => x.Selected).Sum(x => x.GrossSalary);
                decimal totalNet = employeeList.Where(x => x.Selected).Sum(x => x.NetSalary);
                decimal totalNetLoc = employeeList.Where(x => x.Selected).Sum(x => x.NetSalaryLoc);
                string localCurr = Properties.Settings.Default.AppSetting?.LocalCurrencyCode ?? "AZN";

                lblSummary.Text = $"{Properties.Resources.Common_EmployeeName}: {selectedCount}\n" +
                                  $"{Properties.Resources.Entity_TrPayrollHeader_GrossSalary}: {totalGross:N2}\n" +
                                  $"{Properties.Resources.Entity_TrPayrollHeader_NetSalary}: {totalNet:N2}\n" +
                                  $"{Properties.Resources.Entity_InvoiceLine_AmountLoc} ({localCurr}): {totalNetLoc:N2}";
            }
        }

        private async void WizardControl1_FinishClick(object sender, CancelEventArgs e)
        {
            gridViewEmployees.CloseEditor();
            gridViewEmployees.UpdateCurrentRow();

            if (lkpPeriod.EditValue == null) return;

            var selectedEmployees = employeeList.Where(x => x.Selected).ToList();
            if (!selectedEmployees.Any())
            {
                XtraMessageBox.Show(this,
                    Properties.Resources.Form_PayrollWizard_NoEmployeesSelected,
                    Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }

            if (!SaveSelectedPayrolls(selectedEmployees))
            {
                e.Cancel = true;
                return;
            }

            if (chkSendWhatsappOnFinish.Checked)
            {
                e.Cancel = true;
                wizardControl1.Enabled = false;
                try
                {
                    await SendBulkWhatsAppAsync(selectedEmployees);
                }
                finally
                {
                    wizardControl1.Enabled = true;
                }

                XtraMessageBox.Show(this,
                    string.Format(Properties.Resources.Form_PayrollWizard_SuccessMessage, selectedEmployees.Count),
                    Properties.Resources.Common_Info,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            XtraMessageBox.Show(this,
                string.Format(Properties.Resources.Form_PayrollWizard_SuccessMessage, selectedEmployees.Count),
                Properties.Resources.Common_Info,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
        }

        private bool SaveSelectedPayrolls(List<PayrollWizardEmployeeVM> selectedEmployees)
        {
            if (lkpPeriod.EditValue == null) return false;
            Guid periodId = (Guid)lkpPeriod.EditValue;

            try
            {
                using var initDb = new subContext();
                var strategy = initDb.Database.CreateExecutionStrategy();

                strategy.Execute(() =>
                {
                    using var saveDb = new subContext();
                    using var transaction = saveDb.Database.BeginTransaction();

                    foreach (var item in selectedEmployees)
                    {
                        decimal rate = item.ExchangeRate == 0 ? 1m : (decimal)item.ExchangeRate;
                        decimal baseSalaryLoc = Math.Round(item.BaseSalary / rate, 2);

                        TrPayrollHeader? dbHeader = null;
                        if (item.AlreadyExists && item.ExistingPayrollHeaderId.HasValue)
                        {
                            dbHeader = saveDb.TrPayrollHeaders
                                .Include(x => x.Lines)
                                .FirstOrDefault(x => x.Id == item.ExistingPayrollHeaderId.Value);
                        }

                        if (dbHeader == null)
                        {
                            var newHeaderId = Guid.NewGuid();
                            dbHeader = new TrPayrollHeader
                            {
                                Id = newHeaderId,
                                CurrAccCode = item.CurrAccCode,
                                PayrollPeriodId = periodId
                            };

                            dbHeader.Lines.Add(new TrPayrollLine
                            {
                                Id = Guid.NewGuid(),
                                PayrollHeaderId = newHeaderId,
                                PayrollItemType = PayrollItemType.Salary,
                                Description = Properties.Resources.Form_PayrollEdit_BaseSalaryFromContract,
                                Amount = item.BaseSalary,
                                CurrencyCode = item.CurrencyCode,
                                ExchangeRate = item.ExchangeRate,
                                AmountLoc = baseSalaryLoc
                            });

                            if (item.Bonus > 0)
                            {
                                decimal bonusLoc = Math.Round(item.Bonus / rate, 2);
                                dbHeader.Lines.Add(new TrPayrollLine
                                {
                                    Id = Guid.NewGuid(),
                                    PayrollHeaderId = newHeaderId,
                                    PayrollItemType = PayrollItemType.Bonus,
                                    Description = Properties.Resources.Entity_TrPayrollHeader_Bonus,
                                    Amount = item.Bonus,
                                    CurrencyCode = item.CurrencyCode,
                                    ExchangeRate = item.ExchangeRate,
                                    AmountLoc = bonusLoc
                                });
                            }

                            if (item.Deduction > 0)
                            {
                                decimal deductionLoc = Math.Round(item.Deduction / rate, 2);
                                dbHeader.Lines.Add(new TrPayrollLine
                                {
                                    Id = Guid.NewGuid(),
                                    PayrollHeaderId = newHeaderId,
                                    PayrollItemType = PayrollItemType.Deduction,
                                    Description = Properties.Resources.Entity_TrPayrollHeader_Deduction,
                                    Amount = item.Deduction,
                                    CurrencyCode = item.CurrencyCode,
                                    ExchangeRate = item.ExchangeRate,
                                    AmountLoc = deductionLoc
                                });
                            }

                            saveDb.TrPayrollHeaders.Add(dbHeader);

                            item.AlreadyExists = true;
                            item.ExistingPayrollHeaderId = newHeaderId;
                        }
                        else
                        {
                            // Sync Salary Line
                            var salaryLine = dbHeader.Lines.FirstOrDefault(x => x.PayrollItemType == PayrollItemType.Salary);
                            if (salaryLine == null)
                            {
                                dbHeader.Lines.Add(new TrPayrollLine
                                {
                                    Id = Guid.NewGuid(),
                                    PayrollHeaderId = dbHeader.Id,
                                    PayrollItemType = PayrollItemType.Salary,
                                    Description = Properties.Resources.Form_PayrollEdit_BaseSalaryFromContract,
                                    Amount = item.BaseSalary,
                                    CurrencyCode = item.CurrencyCode,
                                    ExchangeRate = item.ExchangeRate,
                                    AmountLoc = baseSalaryLoc
                                });
                            }
                            else
                            {
                                salaryLine.Amount = item.BaseSalary;
                                salaryLine.CurrencyCode = item.CurrencyCode;
                                salaryLine.ExchangeRate = item.ExchangeRate;
                                salaryLine.AmountLoc = baseSalaryLoc;
                                salaryLine.Description = Properties.Resources.Form_PayrollEdit_BaseSalaryFromContract;
                            }

                            // Sync Bonus Line
                            var bonusLine = dbHeader.Lines.FirstOrDefault(x => x.PayrollItemType == PayrollItemType.Bonus);
                            if (item.Bonus > 0)
                            {
                                decimal bonusLoc = Math.Round(item.Bonus / rate, 2);
                                if (bonusLine == null)
                                {
                                    dbHeader.Lines.Add(new TrPayrollLine
                                    {
                                        Id = Guid.NewGuid(),
                                        PayrollHeaderId = dbHeader.Id,
                                        PayrollItemType = PayrollItemType.Bonus,
                                        Description = Properties.Resources.Entity_TrPayrollHeader_Bonus,
                                        Amount = item.Bonus,
                                        CurrencyCode = item.CurrencyCode,
                                        ExchangeRate = item.ExchangeRate,
                                        AmountLoc = bonusLoc
                                    });
                                }
                                else
                                {
                                    bonusLine.Amount = item.Bonus;
                                    bonusLine.CurrencyCode = item.CurrencyCode;
                                    bonusLine.ExchangeRate = item.ExchangeRate;
                                    bonusLine.AmountLoc = bonusLoc;
                                    bonusLine.Description = Properties.Resources.Entity_TrPayrollHeader_Bonus;
                                }
                            }
                            else if (bonusLine != null)
                            {
                                saveDb.TrPayrollLines.Remove(bonusLine);
                            }

                            // Sync Deduction Line
                            var deductionLine = dbHeader.Lines.FirstOrDefault(x => x.PayrollItemType == PayrollItemType.Deduction);
                            if (item.Deduction > 0)
                            {
                                decimal deductionLoc = Math.Round(item.Deduction / rate, 2);
                                if (deductionLine == null)
                                {
                                    dbHeader.Lines.Add(new TrPayrollLine
                                    {
                                        Id = Guid.NewGuid(),
                                        PayrollHeaderId = dbHeader.Id,
                                        PayrollItemType = PayrollItemType.Deduction,
                                        Description = Properties.Resources.Entity_TrPayrollHeader_Deduction,
                                        Amount = item.Deduction,
                                        CurrencyCode = item.CurrencyCode,
                                        ExchangeRate = item.ExchangeRate,
                                        AmountLoc = deductionLoc
                                    });
                                }
                                else
                                {
                                    deductionLine.Amount = item.Deduction;
                                    deductionLine.CurrencyCode = item.CurrencyCode;
                                    deductionLine.ExchangeRate = item.ExchangeRate;
                                    deductionLine.AmountLoc = deductionLoc;
                                    deductionLine.Description = Properties.Resources.Entity_TrPayrollHeader_Deduction;
                                }
                            }
                            else if (deductionLine != null)
                            {
                                saveDb.TrPayrollLines.Remove(deductionLine);
                            }
                        }
                    }

                    saveDb.SaveChanges();
                    transaction.Commit();
                });

                gridViewEmployees.RefreshData();
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

        private async void BtnSendWhatsapp_Click(object sender, EventArgs e)
        {
            gridViewEmployees.CloseEditor();
            gridViewEmployees.UpdateCurrentRow();

            var selectedEmployees = employeeList.Where(x => x.Selected).ToList();
            if (!selectedEmployees.Any())
            {
                XtraMessageBox.Show(this,
                    Properties.Resources.Form_PayrollWizard_NoEmployeesSelected,
                    Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string confirmMsg = string.Format(Properties.Resources.Form_PayrollWizard_SendWhatsappConfirm, selectedEmployees.Count);
            if (XtraMessageBox.Show(this, confirmMsg, Properties.Resources.Common_Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            if (!SaveSelectedPayrolls(selectedEmployees))
            {
                return;
            }

            await SendBulkWhatsAppAsync(selectedEmployees);
        }

        private async void BtnSendWhatsappCompletion_Click(object sender, EventArgs e)
        {
            gridViewEmployees.CloseEditor();
            gridViewEmployees.UpdateCurrentRow();

            var selectedEmployees = employeeList.Where(x => x.Selected).ToList();
            if (!selectedEmployees.Any())
            {
                XtraMessageBox.Show(this,
                    Properties.Resources.Form_PayrollWizard_NoEmployeesSelected,
                    Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string confirmMsg = string.Format(Properties.Resources.Form_PayrollWizard_SendWhatsappConfirm, selectedEmployees.Count);
            if (XtraMessageBox.Show(this, confirmMsg, Properties.Resources.Common_Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            if (!SaveSelectedPayrolls(selectedEmployees))
            {
                return;
            }

            await SendBulkWhatsAppAsync(selectedEmployees);
        }

        private async Task SendBulkWhatsAppAsync(List<PayrollWizardEmployeeVM> targetEmployees)
        {
            if (targetEmployees == null || !targetEmployees.Any())
                return;

            bool isApiMode = Properties.Settings.Default.AppSetting?.WhatsAppProvider == WhatsAppProvider.API;

            if (!isApiMode)
            {
                if (XtraMessageBox.Show(this,
                    Properties.Resources.Form_PayrollWizard_WhatsAppWebBulkWarning,
                    Properties.Resources.Common_Attention,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    return;
                }
            }
            else
            {
                if (!WhatsAppCreditService.HasEnoughBalance())
                {
                    XtraMessageBox.Show(this,
                        Properties.Resources.Common_InsufficientBalance,
                        Properties.Resources.Common_Attention,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }

            EfMethods efMethods = new();
            string periodName = lkpPeriod.Text;
            int successCount = 0;
            int failCount = 0;

            var prevCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                foreach (var emp in targetEmployees)
                {
                    if (!emp.ExistingPayrollHeaderId.HasValue)
                    {
                        failCount++;
                        continue;
                    }

                    List<string> phoneNums = efMethods.SelectCurrAccWhatsappRecipients(emp.CurrAccCode);
                    if (phoneNums == null || phoneNums.Count == 0)
                    {
                        failCount++;
                        continue;
                    }

                    using MemoryStream? memoryStream = PayrollReportService.GetPayrollReportImg(emp.ExistingPayrollHeaderId.Value);
                    if (memoryStream == null)
                    {
                        failCount++;
                        continue;
                    }

                    string caption = string.Format(Properties.Resources.Form_PayrollEdit_WhatsAppCaption, emp.EmployeeName, periodName);

                    if (isApiMode)
                    {
                        bool anySent = false;
                        foreach (string phoneNum in phoneNums)
                        {
                            bool sent = await PayrollReportService.SendWhatsAppViaEvolutionApiAsync(
                                emp.ExistingPayrollHeaderId.Value,
                                emp.CurrAccCode,
                                phoneNum,
                                memoryStream,
                                caption,
                                this,
                                alertControl1);

                            if (sent) anySent = true;
                            await Task.Delay(300);
                        }

                        if (anySent)
                            successCount++;
                        else
                            failCount++;
                    }
                    else
                    {
                        foreach (string phoneNum in phoneNums)
                        {
                            PayrollReportService.SendWhatsAppWeb(phoneNum, caption, memoryStream);
                            await Task.Delay(1000);
                        }
                        successCount++;
                    }
                }
            }
            finally
            {
                Cursor.Current = prevCursor;
            }

            string completedMsg = string.Format(Properties.Resources.Form_PayrollWizard_SendWhatsappCompleted, successCount, failCount);
            XtraMessageBox.Show(this, completedMsg, Properties.Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void WizardControl1_CancelClick(object sender, CancelEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (var item in employeeList)
                item.Selected = true;

            gridViewEmployees.RefreshData();
        }

        private void BtnUnselectAll_Click(object sender, EventArgs e)
        {
            foreach (var item in employeeList)
                item.Selected = false;

            gridViewEmployees.RefreshData();
        }

        private void RepoLookUpCurrency_EditValueChanged(object sender, EventArgs e)
        {
            if (sender is LookUpEdit editor && editor.EditValue != null)
            {
                string currCode = editor.EditValue.ToString()?.Trim() ?? string.Empty;
                if (!string.IsNullOrEmpty(currCode))
                {
                    var cur = currencies.FirstOrDefault(x => string.Equals(x.CurrencyCode?.Trim(), currCode, StringComparison.OrdinalIgnoreCase));
                    if (cur == null)
                    {
                        using var db = new subContext();
                        cur = db.DcCurrencies.AsNoTracking().FirstOrDefault(x => x.CurrencyCode == currCode);
                        if (cur != null)
                            currencies.Add(cur);
                    }

                    float exRate = cur?.ExchangeRate ?? 1f;

                    gridViewEmployees.PostEditor();
                    gridViewEmployees.SetFocusedRowCellValue(colCurrencyCode, cur?.CurrencyCode ?? currCode);
                    gridViewEmployees.SetFocusedRowCellValue(colExchangeRate, exRate);
                    gridViewEmployees.RefreshRow(gridViewEmployees.FocusedRowHandle);
                    gridViewEmployees.UpdateTotalSummary();
                }
            }
        }

        private void GridViewEmployees_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colCurrencyCode)
            {
                string currCode = e.Value?.ToString()?.Trim() ?? string.Empty;
                if (!string.IsNullOrEmpty(currCode))
                {
                    var cur = currencies.FirstOrDefault(x => string.Equals(x.CurrencyCode?.Trim(), currCode, StringComparison.OrdinalIgnoreCase));
                    if (cur == null)
                    {
                        using var db = new subContext();
                        cur = db.DcCurrencies.AsNoTracking().FirstOrDefault(x => x.CurrencyCode == currCode);
                        if (cur != null)
                            currencies.Add(cur);
                    }

                    float newRate = cur?.ExchangeRate ?? 1f;
                    var currentRateObj = gridViewEmployees.GetRowCellValue(e.RowHandle, colExchangeRate);
                    float currentRate = currentRateObj is float f ? f : (currentRateObj is double d ? (float)d : Convert.ToSingle(currentRateObj ?? 0));

                    if (Math.Abs(currentRate - newRate) > 0.00001f)
                    {
                        gridViewEmployees.SetRowCellValue(e.RowHandle, colExchangeRate, newRate);
                    }
                }
            }

            gridViewEmployees.RefreshRow(e.RowHandle);
            gridViewEmployees.UpdateTotalSummary();
        }

        private void GridViewEmployees_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }
}
