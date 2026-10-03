using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;

namespace Foxoft
{
    public partial class FormCurrAccRelationList : RibbonForm
    {
        private readonly EfMethods efMethods = new();
        private readonly string currAccCode;

        public FormCurrAccRelationList(string currAccCode)
        {
            InitializeComponent();

            this.currAccCode = currAccCode;

            BBI_New.ImageOptions.SvgImage = svgImageCollection1["add"];
            BBI_Edit.ImageOptions.SvgImage = svgImageCollection1["edit"];
            BBI_Delete.ImageOptions.SvgImage = svgImageCollection1["delete"];
            BBI_Refresh.ImageOptions.SvgImage = svgImageCollection1["refresh"];
        }

        private void FormCurrAccRelationList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using var dbContext = new subContext();

            var relations = dbContext.TrCurrAccRelations
                .Where(x => x.CurrAccCode == currAccCode || x.RelatedCurrAccCode == currAccCode)
                .Include(x => x.DcCurrAcc)
                .Include(x => x.RelatedDcCurrAcc)
                .Include(x => x.DcCurrAccRelationType)
                .ToList();

            var data = relations.Select(x =>
            {
                bool isDirect = string.Equals(x.CurrAccCode, currAccCode, StringComparison.OrdinalIgnoreCase);
                return new CurrAccRelationVM
                {
                    Id = x.Id,
                    RelatedCurrAccCode = isDirect ? x.RelatedCurrAccCode : x.CurrAccCode,
                    RelatedCurrAccDesc = isDirect ? x.RelatedDcCurrAcc?.CurrAccDesc : x.DcCurrAcc?.CurrAccDesc,
                    RelationTypeName = x.DcCurrAccRelationType?.RelationTypeName ?? string.Empty,
                    Note = x.Note
                };
            }).ToList();

            gridControl1.DataSource = data;
            gridView1.BestFitColumns();

            if (gridView1.Columns[nameof(CurrAccRelationVM.Id)] != null)
                gridView1.Columns[nameof(CurrAccRelationVM.Id)].Visible = false;
        }

        private CurrAccRelationVM? GetFocusedEntity()
        {
            if (gridView1.FocusedRowHandle >= 0)
                return gridView1.GetFocusedRow() as CurrAccRelationVM;
            return null;
        }

        private void BBI_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormCurrAccRelation frm = new(currAccCode);
            if (frm.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void BBI_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditFocusedRow();
        }

        private void EditFocusedRow()
        {
            CurrAccRelationVM? entity = GetFocusedEntity();
            if (entity != null)
            {
                FormCurrAccRelation frm = new(currAccCode, entity.Id);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    LoadData();
            }
            else
            {
                XtraMessageBox.Show(Resources.Form_CurrAccRelationList_NoItemToDelete, Resources.Common_Attention);
            }
        }

        private void BBI_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CurrAccRelationVM? entity = GetFocusedEntity();
            if (entity != null)
            {
                string desc = !string.IsNullOrWhiteSpace(entity.RelatedCurrAccDesc)
                    ? entity.RelatedCurrAccDesc
                    : entity.RelatedCurrAccCode;

                if (XtraMessageBox.Show(
                        string.Format(Resources.Message_ConfirmDelete, desc),
                        Resources.Common_Attention,
                        MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    using var dbContext = new subContext();
                    var relation = dbContext.TrCurrAccRelations.FirstOrDefault(x => x.Id == entity.Id);
                    if (relation != null)
                    {
                        dbContext.TrCurrAccRelations.Remove(relation);
                        dbContext.SaveChanges();
                        LoadData();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show(Resources.Form_CurrAccRelationList_NoItemToDelete, Resources.Common_Attention);
            }
        }

        private void BBI_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            EditFocusedRow();
        }

        private void FormCurrAccRelationList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
