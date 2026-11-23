using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormUnitOfMeasureEdit : XtraForm
    {
        private readonly subContext db = new();
        private readonly int? id;
        private DcUnitOfMeasure entity = null!;

        public int SavedUnitOfMeasureId { get; private set; }

        public FormUnitOfMeasureEdit(int? unitOfMeasureId)
        {
            InitializeComponent();
            id = unitOfMeasureId;

            Text = id == null
                ? Properties.Resources.Form_UnitOfMeasureEdit_Caption_New
                : Properties.Resources.Form_UnitOfMeasureEdit_Caption_Edit;

            btnSave.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;
            lkpParent.ButtonClick += LkpParent_ButtonClick;
            lkpParent.EditValueChanged += (_, __) => OnParentChanged();
            txtDesc.TextChanged += (_, __) => UpdateFormula();
            spnConversionRate.EditValueChanged += (_, __) => UpdateFormula();

            Load += (_, __) => LoadEntity();
        }

        private void LkpParent_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
                lkpParent.EditValue = null;
        }

        private void LoadEntity()
        {
            List<DcUnitOfMeasure> allUnits = db.DcUnitOfMeasures.AsNoTracking().ToList();

            if (id == null)
            {
                entity = new DcUnitOfMeasure
                {
                    ConversionRate = 1m,
                    Level = 0,
                    IsBasic = false,
                    IsDisabled = false
                };
            }
            else
            {
                entity = db.DcUnitOfMeasures.First(x => x.UnitOfMeasureId == id.Value);

                HashSet<int> descendantIds = GetDescendantIds(entity.UnitOfMeasureId, allUnits);
                descendantIds.Add(entity.UnitOfMeasureId);
                allUnits = allUnits.Where(x => !descendantIds.Contains(x.UnitOfMeasureId)).ToList();
            }

            lkpParent.Properties.DataSource = allUnits;

            txtDesc.Text = entity.UnitOfMeasureDesc;
            lkpParent.EditValue = entity.ParentUnitOfMeasureId;
            spnConversionRate.Value = entity.ConversionRate > 0 ? entity.ConversionRate : 1m;
            spnLevel.Value = entity.Level;
            chkIsBasic.Checked = entity.IsBasic;
            chkIsDisabled.Checked = entity.IsDisabled;

            UpdateFormula();
        }

        private HashSet<int> GetDescendantIds(int rootId, List<DcUnitOfMeasure> list)
        {
            HashSet<int> result = new();
            Queue<int> queue = new();
            queue.Enqueue(rootId);

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                foreach (DcUnitOfMeasure child in list.Where(x => x.ParentUnitOfMeasureId == current))
                {
                    if (result.Add(child.UnitOfMeasureId))
                        queue.Enqueue(child.UnitOfMeasureId);
                }
            }

            return result;
        }

        private void OnParentChanged()
        {
            if (lkpParent.EditValue is int parentId)
            {
                DcUnitOfMeasure? parent = db.DcUnitOfMeasures.AsNoTracking()
                    .FirstOrDefault(x => x.UnitOfMeasureId == parentId);
                if (parent != null)
                    spnLevel.Value = (byte)Math.Min(255, parent.Level + 1);
            }
            else
            {
                spnLevel.Value = 0;
            }

            UpdateFormula();
        }

        private void UpdateFormula()
        {
            string desc = string.IsNullOrWhiteSpace(txtDesc.Text) ? "?" : txtDesc.Text.Trim();
            decimal rate = spnConversionRate.Value;

            if (lkpParent.EditValue is int parentId)
            {
                string parentDesc = lkpParent.Text;
                lblFormula.Text = $"1 {desc} = {rate:G29} {parentDesc}";
            }
            else
            {
                lblFormula.Text = $"1 {desc} (Baza vahid)";
            }
        }

        private void Save()
        {
            string desc = txtDesc.Text?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(desc))
            {
                XtraMessageBox.Show(this, Properties.Resources.Validation_UnitOfMeasure_DescRequired,
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDesc.Focus();
                return;
            }

            bool exists = db.DcUnitOfMeasures.Any(x =>
                x.UnitOfMeasureDesc.ToLower() == desc.ToLower() &&
                x.UnitOfMeasureId != (id ?? 0));
            if (exists)
            {
                XtraMessageBox.Show(this, Properties.Resources.Validation_UnitOfMeasure_DescExists,
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDesc.Focus();
                return;
            }

            int? selectedParentId = (int?)lkpParent.EditValue;
            if (id.HasValue && selectedParentId.HasValue)
            {
                if (selectedParentId.Value == id.Value)
                {
                    XtraMessageBox.Show(this, Properties.Resources.Validation_UnitOfMeasure_ParentSelf,
                        Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<DcUnitOfMeasure> allUnits = db.DcUnitOfMeasures.AsNoTracking().ToList();
                HashSet<int> descendants = GetDescendantIds(id.Value, allUnits);
                if (descendants.Contains(selectedParentId.Value))
                {
                    XtraMessageBox.Show(this, Properties.Resources.Validation_UnitOfMeasure_ParentCycle,
                        Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            decimal rate = spnConversionRate.Value;
            if (rate <= 0)
            {
                XtraMessageBox.Show(this, Properties.Resources.Validation_UnitOfMeasure_ConversionRatePositive,
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                spnConversionRate.Focus();
                return;
            }

            entity.UnitOfMeasureDesc = desc;
            entity.ParentUnitOfMeasureId = selectedParentId;
            entity.ConversionRate = rate;
            entity.Level = (byte)spnLevel.Value;
            entity.IsBasic = chkIsBasic.Checked;
            entity.IsDisabled = chkIsDisabled.Checked;

            if (id == null)
                db.DcUnitOfMeasures.Add(entity);
            else
                db.Entry(entity).State = EntityState.Modified;

            db.SaveChanges();
            SavedUnitOfMeasureId = entity.UnitOfMeasureId;
            DialogResult = DialogResult.OK;
        }
    }
}
