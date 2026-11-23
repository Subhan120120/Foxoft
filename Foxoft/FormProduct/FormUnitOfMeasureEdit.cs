using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Foxoft.Models;
using Foxoft.Properties;
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
        private bool isUpdatingRate;

        public int SavedUnitOfMeasureId { get; private set; }

        public FormUnitOfMeasureEdit(int? unitOfMeasureId)
        {
            InitializeComponent();
            id = unitOfMeasureId;

            Text = id == null
                ? Resources.Form_UnitOfMeasureEdit_Caption_New
                : Resources.Form_UnitOfMeasureEdit_Caption_Edit;

            btnSave.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;

            lkpParent.ButtonClick += LkpParent_ButtonClick;
            lkpParent.EditValueChanged += (_, __) => OnParentChanged();
            chkIsBasic.CheckedChanged += (_, __) => OnIsBasicChanged();

            txtDesc.TextChanged += (_, __) => UpdateFormula();
            spnConversionRate.EditValueChanged += (_, __) => OnConversionRateChanged();
            spnReverseRate.EditValueChanged += (_, __) => OnReverseRateChanged();

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
            chkIsBasic.Checked = entity.IsBasic;
            lkpParent.EditValue = entity.ParentUnitOfMeasureId;

            decimal rate = entity.ConversionRate > 0 ? entity.ConversionRate : 1m;
            spnConversionRate.Value = rate;
            spnReverseRate.Value = rate > 0 ? Math.Round(1m / rate, 6) : 1m;
            spnLevel.Value = entity.Level;
            chkIsDisabled.Checked = entity.IsDisabled;

            ApplyBasicState(entity.IsBasic);
            UpdateFormula();
        }

        private void OnIsBasicChanged()
        {
            bool isBasic = chkIsBasic.Checked;
            ApplyBasicState(isBasic);
            UpdateFormula();
        }

        private void ApplyBasicState(bool isBasic)
        {
            if (isBasic)
            {
                lkpParent.EditValue = null;
                lkpParent.ReadOnly = true;
                spnConversionRate.Value = 1m;
                spnConversionRate.ReadOnly = true;
                spnReverseRate.Value = 1m;
                spnReverseRate.ReadOnly = true;
                spnLevel.Value = 0;
            }
            else
            {
                lkpParent.ReadOnly = false;
                spnConversionRate.ReadOnly = false;
                spnReverseRate.ReadOnly = false;
                UpdateLevelFromParent();
            }
        }

        private void OnParentChanged()
        {
            if (!chkIsBasic.Checked)
            {
                UpdateLevelFromParent();
            }
            UpdateFormula();
        }

        private void UpdateLevelFromParent()
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
        }

        private void OnConversionRateChanged()
        {
            if (isUpdatingRate) return;

            decimal rate = spnConversionRate.Value;
            if (rate > 0)
            {
                isUpdatingRate = true;
                spnReverseRate.Value = Math.Round(1m / rate, 6);
                isUpdatingRate = false;
            }
            UpdateFormula();
        }

        private void OnReverseRateChanged()
        {
            if (isUpdatingRate) return;

            decimal rev = spnReverseRate.Value;
            if (rev > 0)
            {
                isUpdatingRate = true;
                spnConversionRate.Value = Math.Round(1m / rev, 6);
                isUpdatingRate = false;
            }
            UpdateFormula();
        }

        private void UpdateFormula()
        {
            string desc = string.IsNullOrWhiteSpace(txtDesc.Text) ? "?" : txtDesc.Text.Trim();

            if (chkIsBasic.Checked || lkpParent.EditValue is not int)
            {
                lblFormula.Text = $"1 {desc} ({Resources.Entity_UnitOfMeasure_IsBasic})";
            }
            else
            {
                string parentDesc = lkpParent.Text;
                decimal rate = spnConversionRate.Value;
                decimal rev = spnReverseRate.Value;

                lblFormula.Text = $"1 {desc} = {rate:0.######} {parentDesc}   \u21D4   1 {parentDesc} = {rev:0.######} {desc}";
            }
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

        private bool ValidateData()
        {
            dxErrorProvider1.ClearErrors();
            bool isValid = true;

            string desc = txtDesc.Text?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(desc))
            {
                dxErrorProvider1.SetError(txtDesc, Resources.Validation_UnitOfMeasure_DescRequired);
                isValid = false;
            }
            else
            {
                bool exists = db.DcUnitOfMeasures.Any(x =>
                    x.UnitOfMeasureDesc.ToLower() == desc.ToLower() &&
                    x.UnitOfMeasureId != (id ?? 0));
                if (exists)
                {
                    dxErrorProvider1.SetError(txtDesc, Resources.Validation_UnitOfMeasure_DescExists);
                    isValid = false;
                }
            }

            bool isBasic = chkIsBasic.Checked;
            int? selectedParentId = (int?)lkpParent.EditValue;

            if (!isBasic && !selectedParentId.HasValue)
            {
                dxErrorProvider1.SetError(lkpParent, Resources.Validation_UnitOfMeasure_ParentRequired);
                isValid = false;
            }

            if (id.HasValue && selectedParentId.HasValue)
            {
                if (selectedParentId.Value == id.Value)
                {
                    dxErrorProvider1.SetError(lkpParent, Resources.Validation_UnitOfMeasure_ParentSelf);
                    isValid = false;
                }
                else
                {
                    List<DcUnitOfMeasure> allUnits = db.DcUnitOfMeasures.AsNoTracking().ToList();
                    HashSet<int> descendants = GetDescendantIds(id.Value, allUnits);
                    if (descendants.Contains(selectedParentId.Value))
                    {
                        dxErrorProvider1.SetError(lkpParent, Resources.Validation_UnitOfMeasure_ParentCycle);
                        isValid = false;
                    }
                }
            }

            if (spnConversionRate.Value <= 0)
            {
                dxErrorProvider1.SetError(spnConversionRate, Resources.Validation_UnitOfMeasure_ConversionRatePositive);
                isValid = false;
            }

            return isValid;
        }

        private void Save()
        {
            if (!ValidateData())
                return;

            string desc = txtDesc.Text.Trim();
            bool isBasic = chkIsBasic.Checked;
            int? selectedParentId = isBasic ? null : (int?)lkpParent.EditValue;
            decimal rate = isBasic ? 1m : spnConversionRate.Value;
            byte level = isBasic ? (byte)0 : (byte)spnLevel.Value;

            entity.UnitOfMeasureDesc = desc;
            entity.IsBasic = isBasic;
            entity.ParentUnitOfMeasureId = selectedParentId;
            entity.ConversionRate = rate;
            entity.Level = level;
            entity.IsDisabled = chkIsDisabled.Checked;

            if (id == null)
                db.DcUnitOfMeasures.Add(entity);
            else
                db.Entry(entity).State = EntityState.Modified;

            db.SaveChanges();
            UnitOfMeasureHelper.InvalidateCache();
            SavedUnitOfMeasureId = entity.UnitOfMeasureId;
            DialogResult = DialogResult.OK;
        }
    }
}
