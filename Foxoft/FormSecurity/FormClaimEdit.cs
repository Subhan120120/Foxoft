using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Models.Entity.RoleClaim;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormClaimEdit : XtraForm
    {
        private readonly subContext db = new();
        private readonly string? _claimCode;
        private readonly bool _isNew;
        private DcClaim _entity = null!;

        public string SavedClaimCode { get; private set; } = string.Empty;

        public FormClaimEdit(string? claimCode)
        {
            InitializeComponent();
            _claimCode = claimCode;
            _isNew = string.IsNullOrWhiteSpace(claimCode);

            btnSave.Click += (_, _) => Save();
            btnCancel.Click += (_, _) => DialogResult = DialogResult.Cancel;
            Load += (_, _) => LoadEntity();
        }

        private void LoadEntity()
        {
            var categories = db.DcClaimCategories.AsNoTracking()
                .OrderBy(x => x.Order)
                .ThenBy(x => x.CategoryDesc)
                .Select(x => new { x.CategoryId, x.CategoryDesc })
                .ToList();

            lkpCategory.Properties.DataSource = categories;
            lkpCategory.Properties.DisplayMember = nameof(DcClaimCategory.CategoryDesc);
            lkpCategory.Properties.ValueMember = nameof(DcClaimCategory.CategoryId);
            lkpCategory.Properties.Columns.Clear();
            lkpCategory.Properties.Columns.Add(new LookUpColumnInfo(nameof(DcClaimCategory.CategoryDesc), Resources.Entity_ClaimCategory));

            var claimTypes = db.DcClaimTypes.AsNoTracking()
                .OrderBy(x => x.ClaimTypeId)
                .Select(x => new { x.ClaimTypeId, x.ClaimTypeDesc })
                .ToList();

            lkpClaimType.Properties.DataSource = claimTypes;
            lkpClaimType.Properties.DisplayMember = nameof(DcClaimType.ClaimTypeDesc);
            lkpClaimType.Properties.ValueMember = nameof(DcClaimType.ClaimTypeId);
            lkpClaimType.Properties.Columns.Clear();
            lkpClaimType.Properties.Columns.Add(new LookUpColumnInfo(nameof(DcClaimType.ClaimTypeDesc), Resources.Entity_ClaimType));

            if (_isNew)
            {
                Text = Resources.Form_ClaimEdit_Caption_New;
                _entity = new DcClaim();
                txtClaimCode.ReadOnly = false;
                txtClaimCode.Text = string.Empty;
                txtClaimDesc.Text = string.Empty;

                if (claimTypes.Count > 0)
                    lkpClaimType.EditValue = claimTypes[0].ClaimTypeId;

                if (categories.Count > 0)
                    lkpCategory.EditValue = categories[0].CategoryId;
            }
            else
            {
                _entity = db.DcClaims.FirstOrDefault(x => x.ClaimCode == _claimCode) ?? new DcClaim();
                Text = $"{Resources.Form_ClaimEdit_Caption_Edit} - {_claimCode}";
                txtClaimCode.ReadOnly = true;
                txtClaimCode.Text = _entity.ClaimCode;
                txtClaimDesc.Text = _entity.ClaimDesc;
                lkpCategory.EditValue = _entity.CategoryId;
                lkpClaimType.EditValue = _entity.ClaimTypeId;
            }
        }

        private void Save()
        {
            string code = txtClaimCode.Text?.Trim() ?? string.Empty;
            string desc = txtClaimDesc.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(code))
            {
                XtraMessageBox.Show(this, Resources.Form_ClaimEdit_CodeRequired, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClaimCode.Focus();
                return;
            }

            if (_isNew && db.DcClaims.Any(x => x.ClaimCode == code))
            {
                XtraMessageBox.Show(this, Resources.Form_ClaimEdit_CodeExists, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClaimCode.Focus();
                return;
            }

            if (lkpCategory.EditValue == null || !int.TryParse(lkpCategory.EditValue.ToString(), out int categoryId))
            {
                XtraMessageBox.Show(this, string.Format(Resources.Validation_Required, Resources.Entity_Claim_CategoryId), Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lkpCategory.Focus();
                return;
            }

            if (lkpClaimType.EditValue == null || !byte.TryParse(lkpClaimType.EditValue.ToString(), out byte claimTypeId))
            {
                XtraMessageBox.Show(this, string.Format(Resources.Validation_Required, Resources.Entity_Claim_TypeId), Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lkpClaimType.Focus();
                return;
            }

            _entity.ClaimCode = code;
            _entity.ClaimDesc = desc;
            _entity.CategoryId = categoryId;
            _entity.ClaimTypeId = claimTypeId;

            if (!EntityValidationHelper.TryValidate(_entity, out string msg))
            {
                XtraMessageBox.Show(this, msg, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_isNew)
            {
                db.DcClaims.Add(_entity);
            }
            else
            {
                db.Entry(_entity).State = EntityState.Modified;
            }

            db.SaveChanges();
            SavedClaimCode = _entity.ClaimCode;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
