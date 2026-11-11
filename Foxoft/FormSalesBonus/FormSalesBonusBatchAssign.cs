using DevExpress.XtraEditors;
using Foxoft.AppCode;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormSalesBonusBatchAssign : XtraForm
    {
        private readonly Guid? defaultPlanId;
        private readonly HashSet<string> initialAssignedCodes = new(StringComparer.OrdinalIgnoreCase);
        private bool isInternalSelecting = false;

        public FormSalesBonusBatchAssign(Guid? defaultPlanId = null)
        {
            InitializeComponent();
            this.defaultPlanId = defaultPlanId;

            dtStart.DateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            Load += (_, __) => LoadData();
            lkpPlan.EditValueChanged += (_, __) => SelectAssignedPersonnel();
            btnSelectAll.Click += (_, __) => viewPersonnel.SelectAll();
            btnUnselectAll.Click += (_, __) => viewPersonnel.ClearSelection();
            viewPersonnel.SelectionChanged += (_, __) => UpdateSelectedCount();
            btnSave.Click += (_, __) => SaveAssignments();
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;
        }

        private void LoadData()
        {
            try
            {
                using var db = new subContext();

                var plans = db.DcSalesBonusPlans.AsNoTracking()
                    .Where(x => x.IsActive)
                    .OrderBy(x => x.PlanName)
                    .ToList()
                    .Select(x => new
                    {
                        x.SalesBonusPlanId,
                        x.PlanName,
                        CalcMethodText = SalesBonusTexts.Text(x.CalcMethod),
                        TriggerTypeText = SalesBonusTexts.Text(x.TriggerType)
                    })
                    .ToList();

                lkpPlan.Properties.DataSource = plans;
                if (defaultPlanId.HasValue && plans.Any(p => p.SalesBonusPlanId == defaultPlanId.Value))
                    lkpPlan.EditValue = defaultPlanId.Value;
                else if (plans.Count > 0)
                    lkpPlan.EditValue = plans[0].SalesBonusPlanId;

                DateTime today = DateTime.Today;

                // Yalnız aktiv şəkildə (müqavilə və saziş ilə) çalışan işçilər
                var activeContracts = db.TrEmployeeContracts.AsNoTracking()
                    .Include(c => c.Addenda)
                    .Where(c => c.StartDate <= today && (c.EndDate == null || c.EndDate >= today)
                        && c.Addenda.Any(a => a.StartDate <= today && (a.EndDate == null || a.EndDate >= today)))
                    .OrderByDescending(c => c.StartDate)
                    .ToList();

                var activeContractEmployeeMap = activeContracts
                    .GroupBy(c => c.CurrAccCode, StringComparer.OrdinalIgnoreCase)
                    .ToDictionary(g => g.Key, g => g.First(), StringComparer.OrdinalIgnoreCase);

                var activeContractEmployeeCodes = activeContractEmployeeMap.Keys.ToHashSet(StringComparer.OrdinalIgnoreCase);

                // Aktiv vəzifələr
                var positions = db.TrEmployeePositions.AsNoTracking()
                    .Include(p => p.Position)
                    .Where(p => activeContractEmployeeCodes.Contains(p.CurrAccCode)
                        && p.StartDate <= today && (p.EndDate == null || p.EndDate >= today))
                    .OrderByDescending(p => p.StartDate)
                    .ToList();

                var activePositionMap = positions
                    .GroupBy(p => p.CurrAccCode, StringComparer.OrdinalIgnoreCase)
                    .ToDictionary(g => g.Key, g => g.First().Position?.PositionName, StringComparer.OrdinalIgnoreCase);

                var activeAssignments = db.TrSalesBonusAssignments.AsNoTracking()
                    .Where(x => x.IsActive && x.StartDate <= today && (x.EndDate == null || x.EndDate >= today))
                    .Include(x => x.DcSalesBonusPlan)
                    .ToList();

                var personnel = db.DcCurrAccs.AsNoTracking()
                    .Where(x => x.CurrAccTypeCode == CurrAccType.Personnel && !x.IsDisabled && activeContractEmployeeCodes.Contains(x.CurrAccCode))
                    .OrderBy(x => x.StoreCode)
                    .ThenBy(x => x.FirstName)
                    .ThenBy(x => x.LastName)
                    .ToList()
                    .Select(x =>
                    {
                        string name = $"{x.FirstName} {x.LastName}".Trim();
                        if (string.IsNullOrWhiteSpace(name))
                            name = x.CurrAccDesc ?? string.Empty;

                        var contract = activeContractEmployeeMap[x.CurrAccCode];
                        var activeAddendum = contract.Addenda
                            .Where(a => a.StartDate <= today && (a.EndDate == null || a.EndDate >= today))
                            .OrderByDescending(a => a.StartDate)
                            .FirstOrDefault();

                        activePositionMap.TryGetValue(x.CurrAccCode, out string? positionName);

                        var plansForPerson = activeAssignments
                            .Where(a => a.SalesPersonCode == x.CurrAccCode)
                            .Select(a => a.DcSalesBonusPlan?.PlanName)
                            .Where(p => !string.IsNullOrEmpty(p))
                            .Distinct();

                        return new PersonnelAssignmentVM
                        {
                            CurrAccCode = x.CurrAccCode,
                            FullName = name,
                            StoreCode = x.StoreCode,
                            PositionName = positionName,
                            ContractNumber = contract.ContractNumber,
                            AddendumNumber = activeAddendum?.AddendumNumber,
                            CurrentPlanName = string.Join(", ", plansForPerson)
                        };
                    })
                    .ToList();

                gridPersonnel.DataSource = personnel;
                gridPersonnel.ForceInitialize();
                viewPersonnel.BestFitColumns();

                SelectAssignedPersonnel();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.InnerException?.Message ?? ex.Message, Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectAssignedPersonnel()
        {
            if (gridPersonnel.DataSource == null || viewPersonnel.DataRowCount == 0)
                return;

            initialAssignedCodes.Clear();

            if (lkpPlan.EditValue is not Guid planId)
            {
                viewPersonnel.ClearSelection();
                UpdateSelectedCount();
                return;
            }

            try
            {
                using var db = new subContext();
                DateTime today = DateTime.Today;

                var currentActiveCodes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                for (int i = 0; i < viewPersonnel.DataRowCount; i++)
                {
                    if (viewPersonnel.GetRow(i) is PersonnelAssignmentVM row && !string.IsNullOrWhiteSpace(row.CurrAccCode))
                        currentActiveCodes.Add(row.CurrAccCode);
                }

                var assigned = db.TrSalesBonusAssignments.AsNoTracking()
                    .Where(x => x.SalesBonusPlanId == planId
                        && x.IsActive
                        && (x.EndDate == null || x.EndDate >= today))
                    .Select(x => x.SalesPersonCode)
                    .ToList();

                foreach (var code in assigned)
                {
                    if (currentActiveCodes.Contains(code))
                        initialAssignedCodes.Add(code);
                }

                var sample = db.TrSalesBonusAssignments.AsNoTracking()
                    .Where(x => x.SalesBonusPlanId == planId && x.IsActive)
                    .OrderByDescending(x => x.StartDate)
                    .FirstOrDefault();

                if (sample != null)
                {
                    dtStart.DateTime = sample.StartDate;
                    dtEnd.EditValue = sample.EndDate;
                    spinTargetAmount.EditValue = sample.TargetAmount;
                    chkIsActive.Checked = sample.IsActive;
                    txtNote.Text = sample.Note ?? string.Empty;
                }
                else
                {
                    dtStart.DateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    dtEnd.EditValue = null;
                    spinTargetAmount.EditValue = null;
                    chkIsActive.Checked = true;
                    txtNote.Text = string.Empty;
                }

                isInternalSelecting = true;
                viewPersonnel.BeginSelection();
                viewPersonnel.ClearSelection();

                for (int i = 0; i < viewPersonnel.DataRowCount; i++)
                {
                    if (viewPersonnel.GetRow(i) is PersonnelAssignmentVM row && initialAssignedCodes.Contains(row.CurrAccCode))
                    {
                        viewPersonnel.SelectRow(i);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.InnerException?.Message ?? ex.Message, Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                viewPersonnel.EndSelection();
                isInternalSelecting = false;
                UpdateSelectedCount();
            }
        }

        private void UpdateSelectedCount()
        {
            if (isInternalSelecting) return;
            int count = viewPersonnel.GetSelectedRows().Count(h => h >= 0);
            lblSelectedCount.Text = string.Format(Properties.Resources.Form_SalesBonusBatchAssign_SelectedCount, count);
        }

        private void SaveAssignments()
        {
            if (lkpPlan.EditValue is not Guid planId)
            {
                XtraMessageBox.Show(this, string.Format(Properties.Resources.Validation_Required, Properties.Resources.Entity_SalesBonusAssignment_PlanId),
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int[] selectedRowHandles = viewPersonnel.GetSelectedRows();
            var selectedCodes = new List<string>();
            foreach (int h in selectedRowHandles)
            {
                if (h >= 0)
                {
                    if (viewPersonnel.GetRow(h) is PersonnelAssignmentVM row && !string.IsNullOrWhiteSpace(row.CurrAccCode))
                        selectedCodes.Add(row.CurrAccCode);
                }
            }

            var newlyAdded = selectedCodes.Except(initialAssignedCodes, StringComparer.OrdinalIgnoreCase).ToList();
            var removed = initialAssignedCodes.Except(selectedCodes, StringComparer.OrdinalIgnoreCase).ToList();

            if (selectedCodes.Count == 0 && removed.Count == 0)
            {
                XtraMessageBox.Show(this, Properties.Resources.Form_SalesBonusBatchAssign_NoPersonnelSelected,
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime startDate = dtStart.DateTime.Date;
            DateTime? endDate = dtEnd.EditValue == null ? null : dtEnd.DateTime.Date;
            if (endDate != null && endDate < startDate)
            {
                XtraMessageBox.Show(this, Properties.Resources.Validation_EndDateBeforeStartDate,
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string planName = lkpPlan.Text;
            DialogResult confirmResult;
            if (selectedCodes.Count == 0 && removed.Count > 0)
            {
                confirmResult = XtraMessageBox.Show(this,
                    string.Format(Properties.Resources.Form_SalesBonusBatchAssign_ConfirmRemoveAll, planName, removed.Count),
                    Properties.Resources.Common_Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else if (removed.Count > 0)
            {
                confirmResult = XtraMessageBox.Show(this,
                    string.Format(Properties.Resources.Form_SalesBonusBatchAssign_ConfirmWithRemoval, selectedCodes.Count, planName, removed.Count),
                    Properties.Resources.Common_Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                confirmResult = XtraMessageBox.Show(this,
                    string.Format(Properties.Resources.Form_SalesBonusBatchAssign_Confirm, selectedCodes.Count, planName),
                    Properties.Resources.Common_Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if (confirmResult != DialogResult.Yes)
                return;

            decimal? targetAmount = spinTargetAmount.EditValue == null || spinTargetAmount.EditValue == DBNull.Value
                ? null
                : Convert.ToDecimal(spinTargetAmount.EditValue);
            bool isActive = chkIsActive.Checked;
            bool closeExisting = chkCloseExisting.Checked;
            string? note = string.IsNullOrWhiteSpace(txtNote.Text) ? null : txtNote.Text.Trim();

            try
            {
                using var db = new subContext();
                DateTime today = DateTime.Today;
                DateTime rangeEnd = endDate ?? DateTime.MaxValue.Date;
                int assignedCount = 0;

                // 1. Unassigned / removed personnel
                foreach (string code in removed)
                {
                    var activeAssignments = db.TrSalesBonusAssignments
                        .Where(x => x.SalesBonusPlanId == planId
                            && x.SalesPersonCode == code
                            && x.IsActive
                            && (x.EndDate == null || x.EndDate >= today))
                        .ToList();

                    foreach (var a in activeAssignments)
                    {
                        if (a.StartDate >= today)
                            a.IsActive = false;
                        else
                            a.EndDate = today.AddDays(-1);

                        a.LastUpdatedUserName = Authorization.CurrAccCode;
                        a.LastUpdatedDate = DateTime.Now;
                    }
                }

                // 2. Selected personnel (newly assigned or updated)
                foreach (string code in selectedCodes)
                {
                    if (closeExisting && isActive)
                    {
                        var overlaps = db.TrSalesBonusAssignments
                            .Where(x => x.SalesBonusPlanId == planId
                                && x.SalesPersonCode == code
                                && x.IsActive
                                && x.StartDate <= rangeEnd
                                && (x.EndDate == null || x.EndDate >= startDate))
                            .ToList();

                        foreach (var overlap in overlaps)
                        {
                            if (overlap.StartDate >= startDate)
                                overlap.IsActive = false;
                            else
                                overlap.EndDate = startDate.AddDays(-1);

                            overlap.LastUpdatedUserName = Authorization.CurrAccCode;
                            overlap.LastUpdatedDate = DateTime.Now;
                        }
                    }

                    var assignment = new TrSalesBonusAssignment
                    {
                        SalesBonusAssignmentId = Guid.NewGuid(),
                        SalesBonusPlanId = planId,
                        SalesPersonCode = code,
                        StartDate = startDate,
                        EndDate = endDate,
                        TargetAmount = targetAmount,
                        IsActive = isActive,
                        Note = note,
                        CreatedUserName = Authorization.CurrAccCode,
                        CreatedDate = DateTime.Now,
                        LastUpdatedUserName = Authorization.CurrAccCode,
                        LastUpdatedDate = DateTime.Now
                    };
                    db.TrSalesBonusAssignments.Add(assignment);
                    assignedCount++;
                }

                db.SaveChanges();

                XtraMessageBox.Show(this, string.Format(Properties.Resources.Form_SalesBonusBatchAssign_Success, assignedCount),
                    Properties.Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.InnerException?.Message ?? ex.Message, Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class PersonnelAssignmentVM
        {
            public string CurrAccCode { get; set; } = string.Empty;
            public string FullName { get; set; } = string.Empty;
            public string StoreCode { get; set; } = string.Empty;
            public string? PositionName { get; set; }
            public string? ContractNumber { get; set; }
            public string? AddendumNumber { get; set; }
            public string? CurrentPlanName { get; set; }
        }
    }
}
