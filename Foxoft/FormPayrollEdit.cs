// File: Forms/Hr/FormPayrollEdit.cs
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
    public class FormPayrollEdit : XtraForm
    {
        private readonly subContext db = new();
        private readonly Guid? id;

        private TrPayrollHeader entity;

        LayoutControl layout;
        ButtonEdit btnEditEmployee, btnEditPeriod;
        CalcEdit calcGross, calcNet;

        GridControl gridLines;
        GridView viewLines;
        SimpleButton btnAddLine, btnRemoveLine, btnSave, btnCancel;

        BindingList<TrPayrollLine> lines = new();

        public FormPayrollEdit(Guid? payrollHeaderId)
        {
            id = payrollHeaderId;

            Text = id == null ? "New Payroll" : "Edit Payroll";
            Width = 1050;
            Height = 720;
            StartPosition = FormStartPosition.CenterParent;

            BuildUi();
            Load += (_, __) => LoadEntity();
        }

        private void BuildUi()
        {
            layout = new LayoutControl { Dock = DockStyle.Fill };
            layout.Root = new LayoutControlGroup { EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True };

            btnEditEmployee = new ButtonEdit();
            btnEditEmployee.ButtonClick += btnEditEmployee_ButtonClick;

            btnEditPeriod = new ButtonEdit();
            btnEditPeriod.ButtonClick += BtnEditPeriod_ButtonClick;

            calcGross = new CalcEdit();
            calcNet = new CalcEdit();

            btnAddLine = new SimpleButton { Text = "Add Line" };
            btnRemoveLine = new SimpleButton { Text = "Remove Line" };
            btnSave = new SimpleButton { Text = "Save" };
            btnCancel = new SimpleButton { Text = "Cancel" };

            btnAddLine.Click += (_, __) => AddLine();
            btnRemoveLine.Click += (_, __) => RemoveLine();
            btnSave.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;

            gridLines = new GridControl();
            viewLines = new GridView(gridLines);
            gridLines.MainView = viewLines;

            viewLines.OptionsView.ShowGroupPanel = false;
            viewLines.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            viewLines.OptionsBehavior.Editable = true;
            viewLines.OptionsView.ColumnAutoWidth = false;
            viewLines.CustomDrawRowIndicator += (s, e) =>
            {
                if (e.Info.IsRowIndicator && e.RowHandle >= 0) e.Info.DisplayText = (e.RowHandle + 1).ToString();
            };

            // Repositories for inline edit
            var repoType = new RepositoryItemComboBox();
            repoType.Items.AddRange(Enum.GetNames(typeof(PayrollItemType)));

            var repoAmount = new RepositoryItemCalcEdit();

            gridLines.RepositoryItems.Add(repoType);
            gridLines.RepositoryItems.Add(repoAmount);

            // columns
            viewLines.Columns.AddVisible(nameof(TrPayrollLine.PayrollItemType), "Type").ColumnEdit = repoType;
            viewLines.Columns.AddVisible(nameof(TrPayrollLine.Description), "Description");
            viewLines.Columns.AddVisible(nameof(TrPayrollLine.Amount), "Amount").ColumnEdit = repoAmount;

            layout.AddItem("Employee", btnEditEmployee);
            layout.AddItem("Payroll Period", btnEditPeriod);

            var grpTotals = layout.Root.AddGroup();
            grpTotals.Text = "Totals";
            grpTotals.AddItem("Gross", calcGross);
            grpTotals.AddItem("Net", calcNet);

            var grpLines = layout.Root.AddGroup();
            grpLines.Text = "Lines";
            grpLines.AddItem("", gridLines);

            var grpLineButtons = layout.Root.AddGroup();
            grpLineButtons.GroupBordersVisible = false;
            grpLineButtons.AddItem("", btnAddLine);
            grpLineButtons.AddItem("", btnRemoveLine);

            var grpButtons = layout.Root.AddGroup();
            grpButtons.GroupBordersVisible = false;
            grpButtons.AddItem("", btnSave);
            grpButtons.AddItem("", btnCancel);

            Controls.Add(layout);
        }

        private void BtnEditPeriod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FormPayrollPeriodList formCommonList = new();
            if (formCommonList.ShowDialog() == DialogResult.OK)
            {
                //btnEditEmployee.EditValue = formCommonList.;
            }
        }

        private void btnEditEmployee_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FormCurrAccList formCommonList = new(new byte[] { 3 }, false, btnEditEmployee.EditValue?.ToString());
            if (formCommonList.ShowDialog() == DialogResult.OK)
            {
                btnEditEmployee.EditValue = formCommonList.dcCurrAcc.CurrAccCode;
            }
        }

        private void LoadEntity()
        {
            var employees = db.DcCurrAccs.AsNoTracking()
                .Where(x => !x.IsDisabled)
                .Where(x => x.CurrAccTypeCode == 3)
                .OrderBy(x => x.CurrAccCode)
                .Select(x => new { x.CurrAccCode, Text = x.CurrAccCode + " - " + x.FirstName + " " + x.LastName })
                .ToList();

            var periods = db.DcPayrollPeriods.AsNoTracking()
                .OrderByDescending(x => x.PeriodYear)
                .ThenByDescending(x => x.PeriodMonth)
                .Select(x => new { x.Id, Text = x.PeriodYear.ToString() + "-" + x.PeriodMonth.ToString("00") + (x.IsClosed ? " (Closed)" : "") })
                .ToList();

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

                // detach-like copy into BindingList for clean inline edit
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
            }

            btnEditEmployee.EditValue = entity.CurrAccCode == string.Empty ? null : entity.CurrAccCode;
            btnEditPeriod.EditValue = entity.PayrollPeriodId == Guid.Empty ? null : entity.PayrollPeriodId;
            calcGross.EditValue = entity.GrossSalary;
            calcNet.EditValue = entity.NetSalary;

            gridLines.DataSource = lines;
            viewLines.BestFitColumns();
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

            if (XtraMessageBox.Show(this, "Remove selected line?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            lines.Remove(row);
        }

        private void Save()
        {
            // commit inline editor
            viewLines.CloseEditor();
            viewLines.UpdateCurrentRow();

            if (btnEditEmployee.EditValue == null)
            {
                XtraMessageBox.Show(this, "Employee is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (btnEditPeriod.EditValue == null)
            {
                XtraMessageBox.Show(this, "Payroll Period is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            entity.CurrAccCode = btnEditEmployee.EditValue?.ToString();
            entity.PayrollPeriodId = (Guid)btnEditPeriod.EditValue;
            entity.GrossSalary = calcGross.Value;
            entity.NetSalary = calcNet.Value;

            if (!EntityValidationHelper.TryValidate(entity, out var msgHeader))
            {
                XtraMessageBox.Show(this, msgHeader, "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // validate + normalize lines
            foreach (var ln in lines)
            {
                ln.PayrollHeaderId = entity.Id;
                if (ln.Id == Guid.Empty) ln.Id = Guid.NewGuid();

                if (!EntityValidationHelper.TryValidate(ln, out var msgLine))
                {
                    XtraMessageBox.Show(this, msgLine, "Line Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (id == null)
            {
                // new
                entity.Lines = lines.ToList();
                db.TrPayrollHeaders.Add(entity);
            }
            else
            {
                // sync lines
                var dbEntity = db.TrPayrollHeaders
                    .Include(x => x.Lines)
                    .First(x => x.Id == entity.Id);

                dbEntity.CurrAccCode = entity.CurrAccCode;
                dbEntity.PayrollPeriodId = entity.PayrollPeriodId;
                dbEntity.GrossSalary = entity.GrossSalary;
                dbEntity.NetSalary = entity.NetSalary;

                // remove missing
                var incomingIds = lines.Select(x => x.Id).ToHashSet();
                var toRemove = dbEntity.Lines.Where(x => !incomingIds.Contains(x.Id)).ToList();
                foreach (var rem in toRemove)
                    db.TrPayrollLines.Remove(rem);

                // add/update
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
    }
}
