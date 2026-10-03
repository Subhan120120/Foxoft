using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Foxoft
{
    public partial class FormCurrAccRelation : XtraForm
    {
        private readonly EfMethods efMethods = new();
        private readonly string currAccCode;
        private readonly int? relationId;
        private readonly bool isNew;

        public FormCurrAccRelation(string currAccCode)
        {
            InitializeComponent();
            this.currAccCode = currAccCode;
            this.isNew = true;
            this.Text = Resources.Form_CurrAccRelation_Caption_New;
        }

        public FormCurrAccRelation(string currAccCode, int id)
            : this(currAccCode)
        {
            this.relationId = id;
            this.isNew = false;
            this.Text = Resources.Form_CurrAccRelation_Caption_Edit;
        }

        private void FormCurrAccRelation_Load(object sender, EventArgs e)
        {
            RelationTypeLookUpEdit.Properties.DataSource = efMethods.SelectEntities<DcCurrAccRelationType>();

            var currentAcc = efMethods.SelectCurrAcc(currAccCode);
            CurrAccCodeTextEdit.EditValue = currentAcc != null ? $"{currentAcc.CurrAccCode} - {currentAcc.CurrAccDesc}" : currAccCode;

            if (!isNew && relationId.HasValue)
            {
                using var context = new subContext();
                var relation = context.TrCurrAccRelations
                    .Include(x => x.DcCurrAcc)
                    .Include(x => x.RelatedDcCurrAcc)
                    .Include(x => x.DcCurrAccRelationType)
                    .FirstOrDefault(x => x.Id == relationId.Value);

                if (relation != null)
                {
                    string otherCode = string.Equals(relation.CurrAccCode, currAccCode, StringComparison.OrdinalIgnoreCase)
                        ? relation.RelatedCurrAccCode
                        : relation.CurrAccCode;

                    string? otherDesc = string.Equals(relation.CurrAccCode, currAccCode, StringComparison.OrdinalIgnoreCase)
                        ? relation.RelatedDcCurrAcc?.CurrAccDesc
                        : relation.DcCurrAcc?.CurrAccDesc;

                    RelatedCurrAccCodeButtonEdit.EditValue = otherCode;
                    RelatedCurrAccDescTextEdit.EditValue = otherDesc;
                    RelationTypeLookUpEdit.EditValue = relation.RelationTypeId;
                    NoteTextEdit.EditValue = relation.Note;
                }
            }
        }

        private void RelatedCurrAccCodeButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            string currentVal = RelatedCurrAccCodeButtonEdit.Text?.Trim() ?? string.Empty;
            using FormCurrAccList frm = new(new byte[] { 1, 2, 3 }, false, currentVal);

            if (frm.ShowDialog(this) == DialogResult.OK && frm.dcCurrAcc != null)
            {
                RelatedCurrAccCodeButtonEdit.EditValue = frm.dcCurrAcc.CurrAccCode;
                RelatedCurrAccDescTextEdit.EditValue = frm.dcCurrAcc.CurrAccDesc;
                dxErrorProvider1.SetError(RelatedCurrAccCodeButtonEdit, string.Empty);
            }
        }

        private void RelatedCurrAccCodeButtonEdit_Validating(object sender, CancelEventArgs e)
        {
            string code = RelatedCurrAccCodeButtonEdit.Text?.Trim() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(code))
            {
                var acc = efMethods.SelectCurrAcc(code);
                if (acc != null)
                {
                    RelatedCurrAccDescTextEdit.EditValue = acc.CurrAccDesc;
                    dxErrorProvider1.SetError(RelatedCurrAccCodeButtonEdit, string.Empty);
                }
                else
                {
                    RelatedCurrAccDescTextEdit.EditValue = null;
                    dxErrorProvider1.SetError(RelatedCurrAccCodeButtonEdit, Resources.Validation_CurrAcc_NotFound);
                }
            }
            else
            {
                RelatedCurrAccDescTextEdit.EditValue = null;
            }
        }

        private void RelationTypeLookUpEdit_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            string? newTypeName = e.DisplayValue?.ToString()?.Trim();
            if (!string.IsNullOrWhiteSpace(newTypeName))
            {
                using var context = new subContext();
                var existing = context.DcCurrAccRelationTypes.FirstOrDefault(x => x.RelationTypeName == newTypeName);
                if (existing == null)
                {
                    existing = new DcCurrAccRelationType { RelationTypeName = newTypeName };
                    context.DcCurrAccRelationTypes.Add(existing);
                    context.SaveChanges();
                }

                RelationTypeLookUpEdit.Properties.DataSource = efMethods.SelectEntities<DcCurrAccRelationType>();
                RelationTypeLookUpEdit.EditValue = existing.RelationTypeId;
                e.Handled = true;
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            string relatedCode = RelatedCurrAccCodeButtonEdit.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(relatedCode))
            {
                dxErrorProvider1.SetError(RelatedCurrAccCodeButtonEdit, string.Format(Resources.Validation_Required, Resources.Entity_CurrAccRelation_RelatedCurrAccCode));
                XtraMessageBox.Show(string.Format(Resources.Validation_Required, Resources.Entity_CurrAccRelation_RelatedCurrAccCode), Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.Equals(currAccCode, relatedCode, StringComparison.OrdinalIgnoreCase))
            {
                dxErrorProvider1.SetError(RelatedCurrAccCodeButtonEdit, Resources.Validation_CurrAcc_CannotRelateToSelf);
                XtraMessageBox.Show(Resources.Validation_CurrAcc_CannotRelateToSelf, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!efMethods.EntityExists<DcCurrAcc>(relatedCode))
            {
                dxErrorProvider1.SetError(RelatedCurrAccCodeButtonEdit, Resources.Validation_CurrAcc_NotFound);
                XtraMessageBox.Show(Resources.Validation_CurrAcc_NotFound, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var context = new subContext();

            bool relationExists = context.TrCurrAccRelations.Any(x =>
                (isNew || x.Id != relationId!.Value) &&
                ((x.CurrAccCode == currAccCode && x.RelatedCurrAccCode == relatedCode) ||
                 (x.CurrAccCode == relatedCode && x.RelatedCurrAccCode == currAccCode)));

            if (relationExists)
            {
                XtraMessageBox.Show(Resources.Validation_CurrAcc_RelationAlreadyExists, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? selectedRelationTypeId = RelationTypeLookUpEdit.EditValue is int tid
                ? tid
                : (int.TryParse(RelationTypeLookUpEdit.EditValue?.ToString(), out int parsedId) ? parsedId : null);

            string? note = NoteTextEdit.Text?.Trim();

            if (isNew)
            {
                TrCurrAccRelation newRelation = new()
                {
                    CurrAccCode = currAccCode,
                    RelatedCurrAccCode = relatedCode,
                    RelationTypeId = selectedRelationTypeId,
                    Note = string.IsNullOrWhiteSpace(note) ? null : note,
                    CreatedUserName = Authorization.CurrAccCode,
                    LastUpdatedUserName = Authorization.CurrAccCode,
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                };

                context.TrCurrAccRelations.Add(newRelation);
                context.SaveChanges();
            }
            else if (relationId.HasValue)
            {
                var existingRelation = context.TrCurrAccRelations.FirstOrDefault(x => x.Id == relationId.Value);
                if (existingRelation != null)
                {
                    if (string.Equals(existingRelation.CurrAccCode, currAccCode, StringComparison.OrdinalIgnoreCase))
                        existingRelation.RelatedCurrAccCode = relatedCode;
                    else
                        existingRelation.CurrAccCode = relatedCode;

                    existingRelation.RelationTypeId = selectedRelationTypeId;
                    existingRelation.Note = string.IsNullOrWhiteSpace(note) ? null : note;
                    existingRelation.LastUpdatedUserName = Authorization.CurrAccCode;
                    existingRelation.LastUpdatedDate = DateTime.Now;
                    context.SaveChanges();
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void FormCurrAccRelation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
