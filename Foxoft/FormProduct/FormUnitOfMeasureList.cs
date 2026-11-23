using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormUnitOfMeasureList : RibbonForm
    {
        private readonly subContext db = new();
        private readonly bool isSelectMode;

        public int? SelectedUnitOfMeasureId { get; private set; }
        public DcUnitOfMeasure? SelectedUnitOfMeasure { get; private set; }

        public FormUnitOfMeasureList(bool selectMode = false)
        {
            InitializeComponent();
            isSelectMode = selectMode;

            Load += (_, __) => LoadData();

            btnNew.ItemClick += (_, __) => NewItem();
            btnEdit.ItemClick += (_, __) => EditItem();
            btnDelete.ItemClick += (_, __) => DeleteItem();
            btnRefresh.ItemClick += (_, __) => LoadData();
            btnSetBasic.ItemClick += (_, __) => SetBasicItem();
            btnToggleActive.ItemClick += (_, __) => ToggleActive();
            btnExportExcel.ItemClick += (_, __) => ExportExcel();
            btnExportPdf.ItemClick += (_, __) => ExportPdf();
            btnClose.ItemClick += (_, __) => Close();

            gridView1.DoubleClick += (_, __) =>
            {
                if (isSelectMode) SelectAndClose();
                else EditItem();
            };

            gridView1.CustomDrawRowIndicator += (s, e) =>
            {
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            };
        }

        private void LoadData(int? focusId = null)
        {
            Dictionary<int, int> productCounts = db.DcProducts.AsNoTracking()
                .GroupBy(x => x.DefaultUnitOfMeasureId)
                .Select(g => new { UnitOfMeasureId = g.Key, Count = g.Count() })
                .ToDictionary(x => x.UnitOfMeasureId, x => x.Count);

            var list = db.DcUnitOfMeasures.AsNoTracking()
                .Include(x => x.ParentUnitOfMeasure)
                .OrderBy(x => x.Level)
                .ThenBy(x => x.UnitOfMeasureDesc)
                .ToList()
                .Select(x => new
                {
                    x.UnitOfMeasureId,
                    x.UnitOfMeasureDesc,
                    ParentDesc = x.ParentUnitOfMeasure != null ? x.ParentUnitOfMeasure.UnitOfMeasureDesc : "",
                    x.ConversionRate,
                    Formula = x.ParentUnitOfMeasure != null
                        ? $"1 {x.UnitOfMeasureDesc} = {x.ConversionRate:G29} {x.ParentUnitOfMeasure.UnitOfMeasureDesc}"
                        : $"1 {x.UnitOfMeasureDesc} (Baza)",
                    x.Level,
                    x.IsBasic,
                    x.IsDisabled,
                    ProductCount = productCounts.TryGetValue(x.UnitOfMeasureId, out int c) ? c : 0
                })
                .ToList();

            gridControl1.DataSource = list;
            gridView1.BestFitColumns();

            if (focusId.HasValue)
            {
                int rowHandle = gridView1.LocateByValue("UnitOfMeasureId", focusId.Value);
                if (rowHandle != GridControl.InvalidRowHandle)
                {
                    gridView1.FocusedRowHandle = rowHandle;
                    gridView1.MakeRowVisible(rowHandle);
                }
            }
        }

        private int? FocusedId()
        {
            var row = gridView1.GetFocusedRow();
            if (row == null) return null;
            var prop = row.GetType().GetProperty("UnitOfMeasureId");
            return prop == null ? null : (int?)prop.GetValue(row);
        }

        private void SelectAndClose()
        {
            int? id = FocusedId();
            if (!id.HasValue) return;

            SelectedUnitOfMeasureId = id.Value;
            SelectedUnitOfMeasure = db.DcUnitOfMeasures.AsNoTracking().FirstOrDefault(x => x.UnitOfMeasureId == id.Value);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void NewItem()
        {
            using var f = new FormUnitOfMeasureEdit(null);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                LoadData(f.SavedUnitOfMeasureId);
                if (isSelectMode)
                {
                    SelectedUnitOfMeasureId = f.SavedUnitOfMeasureId;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void EditItem()
        {
            int? id = FocusedId();
            if (!id.HasValue) return;

            using var f = new FormUnitOfMeasureEdit(id.Value);
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData(f.SavedUnitOfMeasureId);
        }

        private void DeleteItem()
        {
            int? id = FocusedId();
            if (!id.HasValue) return;

            bool isUsedInProducts = db.DcProducts.Any(x => x.DefaultUnitOfMeasureId == id.Value);
            bool isUsedInInvoiceLines = db.TrInvoiceLines.Any(x => x.UnitOfMeasureId == id.Value);
            bool isUsedAsParent = db.DcUnitOfMeasures.Any(x => x.ParentUnitOfMeasureId == id.Value);

            if (isUsedInProducts || isUsedInInvoiceLines || isUsedAsParent)
            {
                XtraMessageBox.Show(this, Properties.Resources.Form_UnitOfMeasureList_CannotDeleteUsed,
                    Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show(this, Properties.Resources.Form_UnitOfMeasureList_DeleteConfirm,
                Properties.Resources.Common_Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var entity = db.DcUnitOfMeasures.FirstOrDefault(x => x.UnitOfMeasureId == id.Value);
            if (entity == null) return;

            db.DcUnitOfMeasures.Remove(entity);
            db.SaveChanges();
            LoadData();
        }

        private void SetBasicItem()
        {
            int? id = FocusedId();
            if (!id.HasValue) return;

            var entity = db.DcUnitOfMeasures.FirstOrDefault(x => x.UnitOfMeasureId == id.Value);
            if (entity == null) return;

            entity.IsBasic = !entity.IsBasic;
            db.SaveChanges();
            LoadData(id.Value);
        }

        private void ToggleActive()
        {
            int? id = FocusedId();
            if (!id.HasValue) return;

            var entity = db.DcUnitOfMeasures.FirstOrDefault(x => x.UnitOfMeasureId == id.Value);
            if (entity == null) return;

            entity.IsDisabled = !entity.IsDisabled;
            db.SaveChanges();
            LoadData(id.Value);
        }

        private void ExportExcel()
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = "UnitOfMeasures.xlsx"
            };
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                gridControl1.ExportToXlsx(sfd.FileName);
            }
        }

        private void ExportPdf()
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                FileName = "UnitOfMeasures.pdf"
            };
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                gridControl1.ExportToPdf(sfd.FileName);
            }
        }
    }
}
