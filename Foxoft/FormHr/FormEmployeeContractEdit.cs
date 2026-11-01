using DevExpress.XtraEditors;
using Foxoft.AppCode;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormEmployeeContractEdit : XtraForm
    {
        private readonly subContext db = new();
        private readonly Guid? id;
        private TrEmployeeContract entity = null!;

        public FormEmployeeContractEdit(Guid? contractId)
        {
            InitializeComponent();
            id = contractId;

            Text = id == null ? Properties.Resources.Form_EmployeeContractEdit_Caption_New : Properties.Resources.Form_EmployeeContractEdit_Caption_Edit;

            btnEmployee.ButtonClick += BtnEmployee_ButtonClick;

            btnSave.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;

            btnAddAddendum.Click += (_, __) => AddAddendum();
            btnEditAddendum.Click += (_, __) => EditAddendum();
            btnDeleteAddendum.Click += (_, __) => DeleteAddendum();
            viewAddenda.DoubleClick += (_, __) => EditAddendum();

            Load += (_, __) => LoadEntity();
        }

        private void BtnEmployee_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FormCurrAccList formCommonList = new(new byte[] { 3 }, false, btnEmployee.EditValue?.ToString());
            if (formCommonList.ShowDialog() == DialogResult.OK)
            {
                btnEmployee.EditValue = formCommonList.dcCurrAcc.CurrAccCode;
                string name = $"{formCommonList.dcCurrAcc.FirstName} {formCommonList.dcCurrAcc.LastName}".Trim();
                if (string.IsNullOrWhiteSpace(name))
                    name = formCommonList.dcCurrAcc.CurrAccDesc ?? string.Empty;
                txtEmployeeName.Text = name;
            }
        }

        private void LoadEntity()
        {
            var types = db.DcEmploymentTypes.AsNoTracking()
                .Where(x => x.IsActive)
                .OrderBy(x => x.TypeCode)
                .Select(x => new { x.Id, x.TypeCode, x.TypeName })
                .ToList();

            lkpType.Properties.DataSource = types;

            if (id == null)
            {
                entity = new TrEmployeeContract
                {
                    Id = Guid.NewGuid(),
                    StartDate = DateTime.Today
                };
            }
            else
            {
                entity = db.TrEmployeeContracts.First(x => x.Id == id.Value);
                var emp = db.DcCurrAccs.AsNoTracking().FirstOrDefault(x => x.CurrAccCode == entity.CurrAccCode);
                if (emp != null)
                {
                    string name = $"{emp.FirstName} {emp.LastName}".Trim();
                    if (string.IsNullOrWhiteSpace(name))
                        name = emp.CurrAccDesc ?? string.Empty;
                    txtEmployeeName.Text = name;
                }
            }

            txtContractNumber.Text = entity.ContractNumber;
            btnEmployee.EditValue = entity.CurrAccCode;
            lkpType.EditValue = entity.EmploymentTypeId;
            dtStart.DateTime = entity.StartDate;
            dtEnd.EditValue = entity.EndDate;

            LoadAddenda();
        }

        private void LoadAddenda()
        {
            if (id == null)
            {
                gridAddenda.DataSource = null;
                btnAddAddendum.Enabled = false;
                btnEditAddendum.Enabled = false;
                btnDeleteAddendum.Enabled = false;
                return;
            }

            btnAddAddendum.Enabled = true;

            using var aDb = new subContext();
            var addenda = aDb.TrEmployeeContractAddenda.AsNoTracking()
                .Where(x => x.ContractId == id.Value)
                .OrderByDescending(x => x.StartDate)
                .Select(x => new
                {
                    x.Id,
                    x.AddendumNumber,
                    x.StartDate,
                    x.EndDate,
                    x.BaseSalary,
                    x.CurrencyCode,
                    x.Description
                })
                .ToList();

            gridAddenda.DataSource = addenda;

            if (viewAddenda.Columns["Id"] != null) viewAddenda.Columns["Id"].Visible = false;
            if (viewAddenda.Columns["AddendumNumber"] != null) viewAddenda.Columns["AddendumNumber"].Caption = Properties.Resources.Entity_TrEmployeeContractAddendum_AddendumNumber;
            if (viewAddenda.Columns["StartDate"] != null) viewAddenda.Columns["StartDate"].Caption = Properties.Resources.Entity_TrEmployeeContractAddendum_StartDate;
            if (viewAddenda.Columns["EndDate"] != null) viewAddenda.Columns["EndDate"].Caption = Properties.Resources.Entity_TrEmployeeContractAddendum_EndDate;
            if (viewAddenda.Columns["BaseSalary"] != null) viewAddenda.Columns["BaseSalary"].Caption = Properties.Resources.Entity_TrEmployeeContractAddendum_BaseSalary;
            if (viewAddenda.Columns["CurrencyCode"] != null) viewAddenda.Columns["CurrencyCode"].Caption = Properties.Resources.Entity_TrEmployeeContract_CurrencyCode;
            if (viewAddenda.Columns["Description"] != null) viewAddenda.Columns["Description"].Caption = Properties.Resources.Entity_TrEmployeeContractAddendum_Description;

            viewAddenda.BestFitColumns();

            btnEditAddendum.Enabled = addenda.Count > 0;
            btnDeleteAddendum.Enabled = addenda.Count > 0;
        }

        private Guid? FocusedAddendumId()
        {
            var row = viewAddenda.GetFocusedRow();
            if (row == null) return null;
            var prop = row.GetType().GetProperty("Id");
            return prop == null ? null : (Guid?)prop.GetValue(row);
        }

        private void AddAddendum()
        {
            if (id == null)
            {
                XtraMessageBox.Show(this, Properties.Resources.Form_EmployeeContractEdit_SaveFirstToAddAddendum,
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var f = new FormEmployeeContractAddendumEdit(id.Value, null);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                LoadAddenda();
            }
        }

        private void EditAddendum()
        {
            if (id == null) return;
            var addendumId = FocusedAddendumId();
            if (addendumId == null) return;

            using var f = new FormEmployeeContractAddendumEdit(id.Value, addendumId.Value);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                LoadAddenda();
            }
        }

        private void DeleteAddendum()
        {
            if (id == null) return;
            var addendumId = FocusedAddendumId();
            if (addendumId == null) return;

            if (XtraMessageBox.Show(this, Properties.Resources.Form_EmployeeContractAddendumList_DeleteConfirm,
                Properties.Resources.Common_Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using var dDb = new subContext();
            var rowToDelete = dDb.TrEmployeeContractAddenda.FirstOrDefault(x => x.Id == addendumId.Value);
            if (rowToDelete != null)
            {
                dDb.TrEmployeeContractAddenda.Remove(rowToDelete);
                dDb.SaveChanges();
            }

            LoadAddenda();
        }

        private void Save()
        {
            if (btnEmployee.EditValue == null || string.IsNullOrWhiteSpace(btnEmployee.EditValue.ToString()))
            {
                XtraMessageBox.Show(this, string.Format(Properties.Resources.Validation_Required, Properties.Resources.Entity_TrEmployeeContract_CurrAccCode),
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lkpType.EditValue == null)
            {
                XtraMessageBox.Show(this, string.Format(Properties.Resources.Validation_Required, Properties.Resources.Entity_TrEmployeeContract_EmploymentTypeId),
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            entity.ContractNumber = txtContractNumber.Text?.Trim();
            entity.CurrAccCode = btnEmployee.EditValue?.ToString();
            entity.EmploymentTypeId = (Guid)lkpType.EditValue;
            entity.StartDate = dtStart.DateTime.Date;
            entity.EndDate = dtEnd.EditValue == null ? null : dtEnd.DateTime.Date;

            if (entity.EndDate != null && entity.EndDate < entity.StartDate)
            {
                XtraMessageBox.Show(this, Properties.Resources.Validation_EndDateBeforeStartDate, Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!EntityValidationHelper.TryValidate(entity, out var msg))
            {
                XtraMessageBox.Show(this, msg, Properties.Resources.Common_Attention,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (id == null)
            {
                db.TrEmployeeContracts.Add(entity);
                db.SaveChanges();

                // Prompt user to enter the initial compensation terms/salary
                using var f = new FormEmployeeContractAddendumEdit(entity.Id, null);
                f.ShowDialog(this);
            }
            else
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            DialogResult = DialogResult.OK;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            db.Dispose();
        }
    }
}
