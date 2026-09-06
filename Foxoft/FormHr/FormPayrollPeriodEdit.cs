using DevExpress.XtraEditors;
using Foxoft.AppCode;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormPayrollPeriodEdit : XtraForm
    {
        private readonly subContext db = new();
        private readonly Guid? id;
        private DcPayrollPeriod entity;

        public FormPayrollPeriodEdit(Guid? periodId)
        {
            InitializeComponent();
            id = periodId;

            Text = id == null ? Properties.Resources.Form_PayrollPeriodEdit_Caption_New : Properties.Resources.Form_PayrollPeriodEdit_Caption_Edit;

            btnSave.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;
            Load += (_, __) => LoadEntity();
        }

        private void LoadEntity()
        {
            if (id == null)
            {
                entity = new DcPayrollPeriod
                {
                    Id = Guid.NewGuid(),
                    PeriodYear = DateTime.Today.Year,
                    PeriodMonth = DateTime.Today.Month,
                    IsClosed = false
                };
            }
            else
            {
                entity = db.DcPayrollPeriods.First(x => x.Id == id.Value);
            }

            spYear.Value = entity.PeriodYear;
            spMonth.Value = entity.PeriodMonth;
            chkClosed.Checked = entity.IsClosed;
        }

        private void Save()
        {
            entity.PeriodYear = (int)spYear.Value;
            entity.PeriodMonth = (int)spMonth.Value;
            entity.IsClosed = chkClosed.Checked;

            if (!EntityValidationHelper.TryValidate(entity, out var msg))
            {
                XtraMessageBox.Show(this, msg, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (id == null) db.DcPayrollPeriods.Add(entity);
            else db.Entry(entity).State = EntityState.Modified;

            db.SaveChanges();
            DialogResult = DialogResult.OK;
        }
    }
}
