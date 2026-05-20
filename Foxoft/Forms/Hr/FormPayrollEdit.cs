using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using Foxoft.AppCode;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormPayrollEdit : XtraForm
    {
        private readonly subContext db = new();
        private readonly Guid? id;
        private TrPayrollHeader entity;
        private BindingList<TrPayrollLine> lines = new();

        public FormPayrollEdit(Guid? payrollHeaderId)
        {
            InitializeComponent();
            id = payrollHeaderId;

            Text = id == null ? Properties.Resources.Form_PayrollEdit_Caption_New : Properties.Resources.Form_PayrollEdit_Caption_Edit;

            btnEditEmployee.ButtonClick += btnEditEmployee_ButtonClick;

            btnAddLine.Click += (_, __) => AddLine();
            btnRemoveLine.Click += (_, __) => RemoveLine();
            btnSave.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;

            viewLines.CustomDrawRowIndicator += (s, e) =>
            {
                if (e.Info.IsRowIndicator && e.RowHandle >= 0) e.Info.DisplayText = (e.RowHandle + 1).ToString();
            };

            var repoType = new RepositoryItemComboBox();
            repoType.Items.AddRange(Enum.GetNames(typeof(PayrollItemType)));

            var repoAmount = new RepositoryItemCalcEdit();

            gridLines.RepositoryItems.Add(repoType);
            gridLines.RepositoryItems.Add(repoAmount);

            viewLines.Columns.AddVisible(nameof(TrPayrollLine.PayrollItemType), Properties.Resources.Entity_TrPayrollLine_PayrollItemType).ColumnEdit = repoType;
            viewLines.Columns.AddVisible(nameof(TrPayrollLine.Description), Properties.Resources.Entity_TrPayrollLine_Description);
            viewLines.Columns.AddVisible(nameof(TrPayrollLine.Amount), Properties.Resources.Entity_TrPayrollLine_Amount).ColumnEdit = repoAmount;

            viewLines.CellValueChanged += (s, e) => RecalculateTotals();
            viewLines.RowDeleted += (s, e) => RecalculateTotals();

            Load += (_, __) => LoadEntity();
        }



        private void btnEditEmployee_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FormCurrAccList formCommonList = new(new byte[] { 3 }, false, btnEditEmployee.EditValue?.ToString());
            if (formCommonList.ShowDialog() == DialogResult.OK)
            {
                btnEditEmployee.EditValue = formCommonList.dcCurrAcc.CurrAccCode;
                txtEmployeeName.Text = $"{formCommonList.dcCurrAcc.FirstName} {formCommonList.dcCurrAcc.LastName}".Trim();
                LoadActiveContractForEmployee(formCommonList.dcCurrAcc.CurrAccCode);
            }
        }

        private void LoadEntity()
        {
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
                    Id = Guid.NewGuid(),
                    GrossSalary = 0,
                    NetSalary = 0
                };
                lines = new BindingList<TrPayrollLine>();
            }
            else
            {
                entity = db.TrPayrollHeaders
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
                            Amount = x.Amount
                        }).ToList()
                );
                
                var emp = db.DcCurrAccs.AsNoTracking().FirstOrDefault(x => x.CurrAccCode == entity.CurrAccCode);
                if (emp != null)
                {
                    txtEmployeeName.Text = $"{emp.FirstName} {emp.LastName}".Trim();
                }
            }

            btnEditEmployee.EditValue = entity.CurrAccCode == string.Empty ? null : entity.CurrAccCode;
            lkpPeriod.EditValue = entity.PayrollPeriodId == Guid.Empty ? null : (Guid?)entity.PayrollPeriodId;

            gridLines.DataSource = lines;
            viewLines.BestFitColumns();

            spGrossSalary.Value = entity.GrossSalary;
            spNetSalary.Value = entity.NetSalary;
            lines.ListChanged += (s, e) => RecalculateTotals();
        }

        private void AddLine()
        {
            var line = new TrPayrollLine
            {
                Id = Guid.NewGuid(),
                PayrollHeaderId = entity.Id,
                PayrollItemType = PayrollItemType.Salary,
                Amount = 0
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

        private void Save()
        {
            viewLines.CloseEditor();
            viewLines.UpdateCurrentRow();

            RecalculateTotals();

            if (btnEditEmployee.EditValue == null)
            {
                XtraMessageBox.Show(this, string.Format(Properties.Resources.Validation_Required, Properties.Resources.Entity_TrPayrollHeader_CurrAccCode),
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lkpPeriod.EditValue == null)
            {
                XtraMessageBox.Show(this, string.Format(Properties.Resources.Validation_Required, Properties.Resources.Entity_TrPayrollHeader_PeriodId),
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            entity.CurrAccCode = btnEditEmployee.EditValue?.ToString();
            entity.PayrollPeriodId = (Guid)lkpPeriod.EditValue;

            if (!EntityValidationHelper.TryValidate(entity, out var msgHeader))
            {
                XtraMessageBox.Show(this, msgHeader, Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var ln in lines)
            {
                ln.PayrollHeaderId = entity.Id;
                if (ln.Id == Guid.Empty) ln.Id = Guid.NewGuid();

                if (!EntityValidationHelper.TryValidate(ln, out var msgLine))
                {
                    XtraMessageBox.Show(this, msgLine, Properties.Resources.Common_Attention,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (id == null)
            {
                entity.Lines = lines.ToList();
                db.TrPayrollHeaders.Add(entity);
            }
            else
            {
                var dbEntity = db.TrPayrollHeaders
                    .Include(x => x.Lines)
                    .First(x => x.Id == entity.Id);

                dbEntity.CurrAccCode = entity.CurrAccCode;
                dbEntity.PayrollPeriodId = entity.PayrollPeriodId;
                dbEntity.GrossSalary = entity.GrossSalary;
                dbEntity.NetSalary = entity.NetSalary;

                var incomingIds = lines.Select(x => x.Id).ToHashSet();
                var toRemove = dbEntity.Lines.Where(x => !incomingIds.Contains(x.Id)).ToList();
                foreach (var rem in toRemove)
                    db.TrPayrollLines.Remove(rem);

                foreach (var ln in lines)
                {
                    var existing = dbEntity.Lines.FirstOrDefault(x => x.Id == ln.Id);
                    if (existing == null)
                    {
                        dbEntity.Lines.Add(new TrPayrollLine
                        {
                            Id = ln.Id,
                            PayrollHeaderId = dbEntity.Id,
                            PayrollItemType = ln.PayrollItemType,
                            Description = ln.Description,
                            Amount = ln.Amount
                        });
                    }
                    else
                    {
                        existing.PayrollItemType = ln.PayrollItemType;
                        existing.Description = ln.Description;
                        existing.Amount = ln.Amount;
                    }
                }
            }

            db.SaveChanges();
            DialogResult = DialogResult.OK;
        }

        private void RecalculateTotals()
        {
            if (entity == null) return;

            decimal gross = 0;
            decimal deductions = 0;

            foreach (var line in lines)
            {
                if (line.PayrollItemType == PayrollItemType.Salary ||
                    line.PayrollItemType == PayrollItemType.Bonus ||
                    line.PayrollItemType == PayrollItemType.Overtime)
                {
                    gross += line.Amount;
                }
                else if (line.PayrollItemType == PayrollItemType.Tax ||
                         line.PayrollItemType == PayrollItemType.Insurance ||
                         line.PayrollItemType == PayrollItemType.Deduction)
                {
                    deductions += line.Amount;
                }
            }

            entity.GrossSalary = gross;
            entity.NetSalary = gross - deductions;

            spGrossSalary.Value = entity.GrossSalary;
            spNetSalary.Value = entity.NetSalary;
        }

        private void LoadActiveContractForEmployee(string currAccCode)
        {
            if (id == null && lines.Count == 0 && !string.IsNullOrEmpty(currAccCode))
            {
                var today = DateTime.Today;
                var activeContract = db.TrEmployeeContracts.AsNoTracking()
                    .Where(x => x.CurrAccCode == currAccCode && x.StartDate <= today && (x.EndDate == null || x.EndDate >= today))
                    .OrderByDescending(x => x.StartDate)
                    .FirstOrDefault();

                if (activeContract != null)
                {
                    var salaryLine = new TrPayrollLine
                    {
                        Id = Guid.NewGuid(),
                        PayrollHeaderId = entity.Id,
                        PayrollItemType = PayrollItemType.Salary,
                        Description = Properties.Resources.Form_PayrollEdit_BaseSalaryFromContract,
                        Amount = activeContract.BaseSalary
                    };
                    lines.Add(salaryLine);
                    RecalculateTotals();
                }
            }
        }
    }
}
