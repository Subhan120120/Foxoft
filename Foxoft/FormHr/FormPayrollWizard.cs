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
using DevExpress.XtraGrid.Views.Grid;
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
        private List<PayrollWizardEmployeeVM> paymentBindingList = new();
        private List<DcCurrency> currencies = new();
        private List<DcCurrAcc> cashRegisters = new();
        private EfMethods efMethods = new();

        public FormPayrollWizard()
        {
            InitializeComponent();
            LoadCurrencies();
            LoadPeriods();
            LoadCashRegisters();
            InitPaymentDefaults();
        }

        private void InitPaymentDefaults()
        {
            dtPaymentDate.DateTime = DateTime.Today;

            bool canMakePayment = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "MakePayment");
            if (!canMakePayment)
            {
                chkAutoPayBalances.Checked = false;
                chkAutoPayBalances.Enabled = false;
                groupPaymentSettings.Enabled = false;
            }
        }

        private void LoadCurrencies()
        {
            using var db = new subContext();
            currencies = db.DcCurrencies.AsNoTracking().OrderBy(x => x.CurrencyCode).ToList();
            repoLookUpCurrency.DataSource = currencies;
            lkpPaymentCurrency.Properties.DataSource = currencies;

            var localCurrencyCode = Properties.Settings.Default.AppSetting?.LocalCurrencyCode ?? "AZN";
            var defaultCurr = currencies.FirstOrDefault(c => string.Equals(c.CurrencyCode?.Trim(), localCurrencyCode?.Trim(), StringComparison.OrdinalIgnoreCase)) ?? currencies.FirstOrDefault();
            if (defaultCurr != null)
            {
                lkpPaymentCurrency.EditValue = defaultCurr.CurrencyCode;
                calcPaymentExchangeRate.EditValue = (decimal)defaultCurr.ExchangeRate;
            }
        }

        private void LkpPaymentCurrency_EditValueChanged(object sender, EventArgs e)
        {
            string? selectedCurr = lkpPaymentCurrency.EditValue?.ToString();
            if (!string.IsNullOrEmpty(selectedCurr) && currencies != null)
            {
                var curr = currencies.FirstOrDefault(c => string.Equals(c.CurrencyCode?.Trim(), selectedCurr.Trim(), StringComparison.OrdinalIgnoreCase));
                if (curr != null)
                {
                    calcPaymentExchangeRate.EditValue = (decimal)curr.ExchangeRate;
                }
            }
        }

        private void LoadCashRegisters()
        {
            cashRegisters = efMethods.SelectCashRegs();
            lkpCashRegister.Properties.DataSource = cashRegisters;
            repoLookUpPayCashRegister.DataSource = cashRegisters;

            string? defaultCashRegCode = efMethods.SelectCashRegByStore(Authorization.StoreCode);
            var defaultCashReg = cashRegisters.FirstOrDefault(x => x.CurrAccCode == defaultCashRegCode) ?? cashRegisters.FirstOrDefault();

            if (defaultCashReg != null)
            {
                lkpCashRegister.EditValue = defaultCashReg.CurrAccCode;
            }
        }

        private void LkpCashRegister_EditValueChanged(object sender, EventArgs e)
        {
            if (lkpCashRegister.EditValue is string cashRegCode && !string.IsNullOrWhiteSpace(cashRegCode))
            {
                var cashReg = cashRegisters.FirstOrDefault(x => x.CurrAccCode == cashRegCode);
                PaymentType paymentTypeCode = cashReg?.CashRegPaymentTypeCode ?? PaymentType.Cash;

                var methods = efMethods.SelectPaymentMethodsByPaymentTypes(new[] { paymentTypeCode });
                lkpPaymentMethod.Properties.DataSource = methods;

                int defaultMethodId = efMethods.SelectDefaultPaymentMethodId(paymentTypeCode);
                lkpPaymentMethod.EditValue = defaultMethodId;
            }
        }

        private void ChkAutoPayBalances_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = chkAutoPayBalances.Checked;
            groupPaymentSettings.Enabled = enabled;
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
            paymentBindingList.Clear();
            gridControlPayment.DataSource = null;
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
            DateTime periodEndDate = new(period.PeriodYear, period.PeriodMonth, daysInMonth, 23, 59, 59);

            var employees = db.DcCurrAccs.AsNoTracking()
                .Where(x => x.CurrAccTypeCode == CurrAccType.Personnel && !x.IsDisabled)
                .OrderBy(x => x.CurrAccCode)
                .ToList();

            var personnelCodes = employees.Select(x => x.CurrAccCode).ToList();

            var contracts = db.TrEmployeeContracts.AsNoTracking()
                .Include(x => x.EmploymentType)
                .Include(x => x.Addenda)
                .Where(x => personnelCodes.Contains(x.CurrAccCode) && x.StartDate <= periodEndDate && (x.EndDate == null || (x.EndDate >= periodStartDate && x.EndDate >= x.StartDate)))
                .OrderByDescending(x => x.StartDate)
                .ToList();

            var validContractEmployeeCodes = contracts
                .Select(x => x.CurrAccCode)
                .Distinct()
                .ToHashSet();

            employees = employees
                .Where(x => validContractEmployeeCodes.Contains(x.CurrAccCode))
                .ToList();

            var employeeCodes = employees.Select(x => x.CurrAccCode).ToList();

            var positions = db.TrEmployeePositions.AsNoTracking()
                .Include(x => x.Position)
                .ThenInclude(x => x.Department)
                .Where(p => employeeCodes.Contains(p.CurrAccCode) && p.StartDate <= periodEndDate && (p.EndDate == null || (p.EndDate >= periodStartDate && p.EndDate >= p.StartDate)))
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

                var (effectiveBaseSalary, effectiveCurrCode) = activeContract != null
                    ? activeContract.GetEffectiveSalaryForPeriod(periodStartDate, periodEndDate, defaultCurrency?.CurrencyCode ?? "AZN")
                    : (0m, defaultCurrency?.CurrencyCode ?? "AZN");

                decimal baseSalary = effectiveBaseSalary;
                decimal bonus = 0;
                decimal deduction = 0;
                bool alreadyExists = existingPayroll != null;
                Guid? existingId = existingPayroll?.Id;

                string currCode = effectiveCurrCode;

                var matchedCurrency = currencies.FirstOrDefault(c => string.Equals(c.CurrencyCode?.Trim(), currCode, StringComparison.OrdinalIgnoreCase)) ?? defaultCurrency;
                float exRate = matchedCurrency?.ExchangeRate ?? 1f;

                decimal existingNetSalaryLoc = 0;
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

                    existingNetSalaryLoc = existingPayroll.NetSalary;
                }

                // Balance calculation:
                decimal currentDbBalance = efMethods.SelectCurrAccBalance(emp.CurrAccCode, DateTime.Now);
                decimal previousBalance = currentDbBalance - existingNetSalaryLoc;

                var vm = new PayrollWizardEmployeeVM
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
                    ExistingPayrollHeaderId = existingId,
                    PreviousBalance = previousBalance
                };

                string defaultPayCurr = lkpPaymentCurrency.EditValue?.ToString() ?? (Properties.Settings.Default.AppSetting?.LocalCurrencyCode ?? "AZN");
                float defaultPayRate = Convert.ToSingle(calcPaymentExchangeRate.EditValue ?? 1f);
                if (defaultPayRate <= 0) defaultPayRate = 1f;

                vm.ApplyBalanceToPayAmount(defaultPayCurr, defaultPayRate);
                return vm;
            }).ToList();

            employeeList = new BindingList<PayrollWizardEmployeeVM>(list);
            gridControlEmployees.DataSource = employeeList;
            gridViewEmployees.BestFitColumns();

            txtPaymentDesc.Text = string.Format(Properties.Resources.Form_PayrollWizard_PaymentDescDefault, lkpPeriod.Text);
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

                var selectedEmployees = employeeList.Where(x => x.Selected).ToList();
                if (!selectedEmployees.Any())
                {
                    XtraMessageBox.Show(this,
                        Properties.Resources.Form_PayrollWizard_NoEmployeesSelected,
                        Properties.Resources.Common_Attention,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    e.Handled = true;
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPaymentDesc.Text))
                {
                    txtPaymentDesc.Text = string.Format(Properties.Resources.Form_PayrollWizard_PaymentDescDefault, lkpPeriod.Text);
                }
            }
            else if (e.Page == wizardPagePaymentSettings)
            {
                if (!chkAutoPayBalances.Checked)
                {
                    // User opted out of payment generation. Skip payment list page and go straight to completion!
                    UpdateCompletionSummary();
                    wizardControl1.SelectedPage = completionWizardPage1;
                    e.Handled = true;
                    return;
                }

                if (lkpCashRegister.EditValue == null || string.IsNullOrWhiteSpace(lkpCashRegister.EditValue.ToString()))
                {
                    XtraMessageBox.Show(this,
                        Properties.Resources.Form_PayrollWizard_CashRegisterRequired,
                        Properties.Resources.Common_Attention,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    e.Handled = true;
                    return;
                }

                if (lkpPaymentCurrency.EditValue == null || string.IsNullOrWhiteSpace(lkpPaymentCurrency.EditValue.ToString()))
                {
                    XtraMessageBox.Show(this,
                        Properties.Resources.Form_PayrollWizard_PaymentCurrencyRequired,
                        Properties.Resources.Common_Attention,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    e.Handled = true;
                    return;
                }

                // Payment generation is confirmed! Generate payments list based on the chosen rule:
                var selectedEmployees = employeeList.Where(x => x.Selected).ToList();
                int ruleIndex = rgPaymentRule.SelectedIndex;

                string payCurr = lkpPaymentCurrency.EditValue.ToString()!;
                float payRate = Convert.ToSingle(calcPaymentExchangeRate.EditValue ?? 1f);
                if (payRate <= 0) payRate = 1f;

                foreach (var emp in selectedEmployees)
                {
                    emp.PaymentCurrencyCode = payCurr;
                    emp.PaymentExchangeRate = payRate;
                    emp.CashRegisterCode = lkpCashRegister.EditValue?.ToString();
                    emp.PaymentMethodId = lkpPaymentMethod.EditValue is int mId ? mId : null;
                    emp.PaymentDescription = txtPaymentDesc.Text;

                    if (ruleIndex == 0)
                        emp.ApplyBalanceToPayAmount(payCurr, payRate); // Rule 0: By remaining balance in payment currency
                    else if (ruleIndex == 1)
                        emp.ApplyNetSalaryToPayAmount(payCurr, payRate); // Rule 1: By net salary in payment currency
                    else if (ruleIndex == 2)
                        emp.ResetPayAmount(payCurr, payRate); // Rule 2: Manual (start at 0)
                }

                paymentBindingList = selectedEmployees;
                gridControlPayment.DataSource = paymentBindingList;
                gridViewPayment.RefreshData();
                gridViewPayment.UpdateTotalSummary();
                gridViewPayment.BestFitColumns();
            }
            else if (e.Page == wizardPagePaymentList)
            {
                gridViewPayment.CloseEditor();
                gridViewPayment.UpdateCurrentRow();

                var employeesToPay = paymentBindingList.Where(x => x.PaySelected && x.PayAmount > 0).ToList();
                if (!employeesToPay.Any())
                {
                    if (XtraMessageBox.Show(this,
                        Properties.Resources.Form_PayrollWizard_NoEmployeesToPayConfirm,
                        Properties.Resources.Common_Confirm,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        e.Handled = true;
                        return;
                    }
                }

                UpdateCompletionSummary();
            }
        }

        private void WizardControl1_PrevClick(object sender, WizardCommandButtonClickEventArgs e)
        {
            if (e.Page == completionWizardPage1)
            {
                if (!chkAutoPayBalances.Checked)
                {
                    // Payment list was skipped when moving forward, so skip it when moving back too!
                    wizardControl1.SelectedPage = wizardPagePaymentSettings;
                    e.Handled = true;
                    return;
                }
            }
        }

        private void UpdateCompletionSummary()
        {
            var selectedEmployees = employeeList.Where(x => x.Selected).ToList();
            int selectedCount = selectedEmployees.Count;
            decimal totalGross = selectedEmployees.Sum(x => x.GrossSalary);
            decimal totalNet = selectedEmployees.Sum(x => x.NetSalary);
            decimal totalNetLoc = selectedEmployees.Sum(x => x.NetSalaryLoc);
            string localCurr = Properties.Settings.Default.AppSetting?.LocalCurrencyCode ?? "AZN";

            string summary = $"{Properties.Resources.Common_EmployeeName}: {selectedCount}\n" +
                             $"{Properties.Resources.Entity_TrPayrollHeader_GrossSalary}: {totalGross:N2} {localCurr}\n" +
                             $"{Properties.Resources.Entity_TrPayrollHeader_NetSalary}: {totalNet:N2} {localCurr}\n";

            if (chkAutoPayBalances.Checked)
            {
                var payList = paymentBindingList.Where(x => x.PaySelected && x.PayAmount > 0).ToList();
                decimal totalPay = payList.Sum(x => x.PayAmount);
                string cashRegDesc = lkpCashRegister.Text;
                DateTime payDate = dtPaymentDate.EditValue is DateTime dt ? dt : DateTime.Today;
                string payCurr = lkpPaymentCurrency.EditValue?.ToString() ?? (Properties.Settings.Default.AppSetting?.LocalCurrencyCode ?? "AZN");

                summary += $"\n----------------------------------------\n" +
                           $"{Properties.Resources.Form_PayrollWizard_SummaryPay_Title}: {Properties.Resources.Form_PayrollWizard_SummaryPay_Yes}\n" +
                           $"{Properties.Resources.Form_PayrollWizard_SummaryPay_EmployeesCount}: {payList.Count}\n" +
                           $"{Properties.Resources.Form_PayrollWizard_SummaryPay_TotalAmount}: {totalPay:N2} {payCurr}\n" +
                           $"{Properties.Resources.Form_PayrollWizard_PaymentCurrency}: {payCurr}\n" +
                           $"{Properties.Resources.Form_PayrollWizard_CashRegister}: {cashRegDesc}\n" +
                           $"{Properties.Resources.Form_PayrollWizard_PaymentDate}: {payDate:dd.MM.yyyy}";
            }
            else
            {
                summary += $"\n----------------------------------------\n" +
                           $"{Properties.Resources.Form_PayrollWizard_SummaryPay_Title}: {Properties.Resources.Form_PayrollWizard_SummaryPay_No}";
            }

            lblSummary.Text = summary;
        }

        private async void WizardControl1_FinishClick(object sender, CancelEventArgs e)
        {
            gridViewEmployees.CloseEditor();
            gridViewEmployees.UpdateCurrentRow();
            gridViewPayment.CloseEditor();
            gridViewPayment.UpdateCurrentRow();

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

            if (!SaveSelectedPayrollsAndPayments(selectedEmployees, out int paymentsCount, out decimal totalPaidAmount))
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

                ShowFinishSuccessMessage(selectedEmployees.Count, paymentsCount, totalPaidAmount);
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            ShowFinishSuccessMessage(selectedEmployees.Count, paymentsCount, totalPaidAmount);
            DialogResult = DialogResult.OK;
        }

        private void ShowFinishSuccessMessage(int payrollCount, int paymentCount, decimal totalPaidAmount)
        {
            string payCurr = lkpPaymentCurrency.EditValue?.ToString() ?? (Properties.Settings.Default.AppSetting?.LocalCurrencyCode ?? "AZN");
            string msg = paymentCount > 0
                ? string.Format(Properties.Resources.Form_PayrollWizard_SuccessWithPaymentMessage, payrollCount, paymentCount, totalPaidAmount, payCurr)
                : string.Format(Properties.Resources.Form_PayrollWizard_SuccessMessage, payrollCount);

            XtraMessageBox.Show(this,
                msg,
                Properties.Resources.Common_Info,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private bool SaveSelectedPayrollsAndPayments(
            List<PayrollWizardEmployeeVM> selectedEmployees,
            out int paymentsCreatedCount,
            out decimal totalPaidAmount)
        {
            paymentsCreatedCount = 0;
            totalPaidAmount = 0;

            if (lkpPeriod.EditValue == null) return false;
            Guid periodId = (Guid)lkpPeriod.EditValue;

            bool doPay = chkAutoPayBalances.Checked;
            string defaultCashRegCode = lkpCashRegister.EditValue?.ToString() ?? string.Empty;
            DateTime paymentDate = dtPaymentDate.EditValue is DateTime dt ? dt.Date : DateTime.Today;
            int defaultMethodId = lkpPaymentMethod.EditValue is int mId ? mId : 1;
            string defaultPaymentDesc = txtPaymentDesc.Text.Trim();

            int createdPayments = 0;
            decimal sumPaid = 0;

            try
            {
                using var initDb = new subContext();
                var strategy = initDb.Database.CreateExecutionStrategy();

                strategy.Execute(() =>
                {
                    using var saveDb = new subContext();
                    using var transaction = saveDb.Database.BeginTransaction();

                    // 1. Save or sync payroll records
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

                    // 2. Create automated payment vouchers if requested
                    if (doPay && !string.IsNullOrWhiteSpace(defaultCashRegCode))
                    {
                        var payEmployees = selectedEmployees
                            .Where(x => x.PaySelected && x.PayAmount > 0)
                            .ToList();

                        if (payEmployees.Any())
                        {
                            ExecuteBulkPayments(
                                saveDb,
                                payEmployees,
                                defaultCashRegCode,
                                paymentDate,
                                defaultMethodId,
                                defaultPaymentDesc);

                            createdPayments = payEmployees.Count;
                            sumPaid = payEmployees.Sum(x => x.PayAmount);
                        }
                    }

                    saveDb.SaveChanges();
                    transaction.Commit();
                });

                paymentsCreatedCount = createdPayments;
                totalPaidAmount = sumPaid;

                gridViewEmployees.RefreshData();
                gridViewPayment.RefreshData();
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

        private void ExecuteBulkPayments(
            subContext saveDb,
            List<PayrollWizardEmployeeVM> payEmployees,
            string defaultCashRegCode,
            DateTime paymentDate,
            int defaultPaymentMethodId,
            string defaultPaymentDesc)
        {
            string baseDocNum = efMethods.GetNextDocNum(
                true,
                "PA",
                nameof(TrPaymentHeader.DocumentNumber),
                nameof(subContext.TrPaymentHeaders),
                6);

            int docNumOffset = 0;

            for (int i = 0; i < payEmployees.Count; i++)
            {
                var emp = payEmployees[i];
                string docNum = IncrementDocNum(baseDocNum, docNumOffset);

                while (saveDb.TrPaymentHeaders.Any(x => x.DocumentNumber == docNum))
                {
                    docNumOffset++;
                    docNum = IncrementDocNum(baseDocNum, docNumOffset);
                }
                docNumOffset++;

                string cashRegCode = !string.IsNullOrWhiteSpace(emp.CashRegisterCode)
                    ? emp.CashRegisterCode!
                    : defaultCashRegCode;

                var cashReg = cashRegisters.FirstOrDefault(x => x.CurrAccCode == cashRegCode);
                PaymentType paymentTypeCode = cashReg?.CashRegPaymentTypeCode ?? PaymentType.Cash;

                int methodId = emp.PaymentMethodId.HasValue && emp.PaymentMethodId.Value > 0
                    ? emp.PaymentMethodId.Value
                    : defaultPaymentMethodId;

                string lineDesc = !string.IsNullOrWhiteSpace(emp.PaymentDescription)
                    ? emp.PaymentDescription!
                    : defaultPaymentDesc;

                string payCurr = !string.IsNullOrWhiteSpace(emp.PaymentCurrencyCode)
                    ? emp.PaymentCurrencyCode
                    : (lkpPaymentCurrency.EditValue?.ToString() ?? (Properties.Settings.Default.AppSetting?.LocalCurrencyCode ?? "AZN"));

                float payExRate = emp.PaymentExchangeRate > 0
                    ? emp.PaymentExchangeRate
                    : (calcPaymentExchangeRate.EditValue is decimal cr && cr > 0 ? (float)cr : 1f);

                decimal rate = payExRate <= 0 ? 1m : (decimal)payExRate;
                decimal payLoc = Math.Round(emp.PayAmount / rate, 4);

                Guid headerId = Guid.NewGuid();
                var paymentHeader = new TrPaymentHeader
                {
                    PaymentHeaderId = headerId,
                    DocumentNumber = docNum,
                    ProcessCode = "PA",
                    DocumentDate = paymentDate,
                    DocumentTime = DateTime.Now.TimeOfDay,
                    OperationDate = paymentDate,
                    OperationTime = DateTime.Now.TimeOfDay,
                    CurrAccCode = emp.CurrAccCode,
                    OfficeCode = Authorization.OfficeCode ?? "01",
                    StoreCode = Authorization.StoreCode ?? "01",
                    Description = lineDesc,
                    PaymentKindId = PaymentKind.Payment,
                    IsMainTF = true,
                    CreatedUserName = Authorization.CurrAccCode
                };

                var paymentLine = new TrPaymentLine
                {
                    PaymentLineId = Guid.NewGuid(),
                    PaymentHeaderId = headerId,
                    PaymentTypeCode = paymentTypeCode,
                    PaymentMethodId = methodId,
                    CashRegisterCode = cashRegCode,
                    CurrencyCode = payCurr,
                    ExchangeRate = payExRate,
                    Payment = -emp.PayAmount,     // Outflow to employee (MakePayment is negative)
                    PaymentLoc = -payLoc,
                    LineDescription = lineDesc,
                    CreatedUserName = Authorization.CurrAccCode
                };

                paymentHeader.TrPaymentLines.Add(paymentLine);
                saveDb.TrPaymentHeaders.Add(paymentHeader);
            }
        }

        private static string IncrementDocNum(string baseDocNum, int offset)
        {
            if (offset <= 0 || string.IsNullOrWhiteSpace(baseDocNum))
                return baseDocNum;

            int lastHyphen = baseDocNum.LastIndexOf('-');
            if (lastHyphen >= 0 && lastHyphen < baseDocNum.Length - 1)
            {
                string prefix = baseDocNum.Substring(0, lastHyphen + 1);
                string numPart = baseDocNum.Substring(lastHyphen + 1);
                if (long.TryParse(numPart, out long num))
                {
                    return $"{prefix}{(num + offset).ToString().PadLeft(numPart.Length, '0')}";
                }
            }

            int digitsCount = 0;
            for (int i = baseDocNum.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(baseDocNum[i])) digitsCount++;
                else break;
            }

            if (digitsCount > 0)
            {
                string prefix = baseDocNum.Substring(0, baseDocNum.Length - digitsCount);
                string numPart = baseDocNum.Substring(baseDocNum.Length - digitsCount);
                if (long.TryParse(numPart, out long num))
                {
                    return $"{prefix}{(num + offset).ToString().PadLeft(numPart.Length, '0')}";
                }
            }

            return $"{baseDocNum}_{offset}";
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

            if (!SaveSelectedPayrollsAndPayments(selectedEmployees, out _, out _))
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

            if (!SaveSelectedPayrollsAndPayments(selectedEmployees, out _, out _))
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
                if (!CreditService.HasEnoughWhatsAppBalance())
                {
                    XtraMessageBox.Show(this,
                        Properties.Resources.Common_InsufficientBalance,
                        Properties.Resources.Common_Attention,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }

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
            gridViewEmployees.CloseEditor();
            gridViewEmployees.UpdateCurrentRow();

            foreach (var item in employeeList)
                item.Selected = true;

            gridViewEmployees.RefreshData();
        }

        private void BtnUnselectAll_Click(object sender, EventArgs e)
        {
            gridViewEmployees.CloseEditor();
            gridViewEmployees.UpdateCurrentRow();

            foreach (var item in employeeList)
                item.Selected = false;

            gridViewEmployees.RefreshData();
        }

        private void BtnPaySelectAll_Click(object sender, EventArgs e)
        {
            gridViewPayment.CloseEditor();
            gridViewPayment.UpdateCurrentRow();

            foreach (var item in paymentBindingList)
                item.PaySelected = true;

            gridViewPayment.RefreshData();
            gridViewPayment.UpdateTotalSummary();
        }

        private void BtnPayUnselectAll_Click(object sender, EventArgs e)
        {
            gridViewPayment.CloseEditor();
            gridViewPayment.UpdateCurrentRow();

            foreach (var item in paymentBindingList)
                item.PaySelected = false;

            gridViewPayment.RefreshData();
            gridViewPayment.UpdateTotalSummary();
        }

        private void BtnApplyBalances_Click(object sender, EventArgs e)
        {
            gridViewPayment.CloseEditor();
            gridViewPayment.UpdateCurrentRow();

            string defaultCurr = lkpPaymentCurrency.EditValue?.ToString() ?? "AZN";
            float defaultRate = Convert.ToSingle(calcPaymentExchangeRate.EditValue ?? 1f);
            if (defaultRate <= 0) defaultRate = 1f;

            foreach (var item in paymentBindingList)
                item.ApplyBalanceToPayAmount(defaultCurr, defaultRate);

            gridViewPayment.RefreshData();
            gridViewPayment.UpdateTotalSummary();
        }

        private void BtnApplyNetSalaries_Click(object sender, EventArgs e)
        {
            gridViewPayment.CloseEditor();
            gridViewPayment.UpdateCurrentRow();

            string defaultCurr = lkpPaymentCurrency.EditValue?.ToString() ?? "AZN";
            float defaultRate = Convert.ToSingle(calcPaymentExchangeRate.EditValue ?? 1f);
            if (defaultRate <= 0) defaultRate = 1f;

            foreach (var item in paymentBindingList)
                item.ApplyNetSalaryToPayAmount(defaultCurr, defaultRate);

            gridViewPayment.RefreshData();
            gridViewPayment.UpdateTotalSummary();
        }

        private void BtnResetPayments_Click(object sender, EventArgs e)
        {
            gridViewPayment.CloseEditor();
            gridViewPayment.UpdateCurrentRow();

            foreach (var item in paymentBindingList)
                item.ResetPayAmount();

            gridViewPayment.RefreshData();
            gridViewPayment.UpdateTotalSummary();
        }

        private void GridViewPayment_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colPayCurrencyCode)
            {
                var row = gridViewPayment.GetRow(e.RowHandle) as PayrollWizardEmployeeVM;
                if (row != null && currencies != null)
                {
                    var matched = currencies.FirstOrDefault(c => string.Equals(c.CurrencyCode?.Trim(), row.PaymentCurrencyCode?.Trim(), StringComparison.OrdinalIgnoreCase));
                    if (matched != null)
                    {
                        row.PaymentExchangeRate = matched.ExchangeRate;
                        decimal rate = row.PaymentExchangeRate <= 0 ? 1m : (decimal)row.PaymentExchangeRate;
                        decimal targetBalanceLoc = row.BalanceAfterPayroll > 0 ? row.BalanceAfterPayroll : 0;
                        row.PayAmount = Math.Round(targetBalanceLoc * rate, 2);
                        row.PaySelected = row.PayAmount > 0;
                    }
                }
            }
            else if (e.Column == colPayExchangeRate)
            {
                var row = gridViewPayment.GetRow(e.RowHandle) as PayrollWizardEmployeeVM;
                if (row != null)
                {
                    decimal rate = row.PaymentExchangeRate <= 0 ? 1m : (decimal)row.PaymentExchangeRate;
                    decimal targetBalanceLoc = row.BalanceAfterPayroll > 0 ? row.BalanceAfterPayroll : 0;
                    row.PayAmount = Math.Round(targetBalanceLoc * rate, 2);
                    row.PaySelected = row.PayAmount > 0;
                }
            }
            else if (e.Column == colPayAmount)
            {
                if (e.Value is decimal val)
                {
                    if (val > 0)
                        gridViewPayment.SetRowCellValue(e.RowHandle, colPaySelected, true);
                    else if (val <= 0)
                        gridViewPayment.SetRowCellValue(e.RowHandle, colPaySelected, false);
                }
            }

            gridViewPayment.RefreshRow(e.RowHandle);
            gridViewPayment.UpdateTotalSummary();
        }

        private void GridViewPayment_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
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

        private void GridViewEmployees_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }
}
