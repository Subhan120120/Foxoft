using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    /// <summary>
    /// Manual bonus hesablanması: seçilmiş ay üçün gözlənilən / yazılmış / fərq önizləməsi və fərqin jurnala yazılması.
    /// Yalnız fərq yazılır, mövcud sətirlər dəyişdirilmir.
    /// </summary>
    public partial class FormSalesBonusCalc : XtraForm
    {
        private readonly SalesBonusService service = new();
        private List<SalesBonusPreviewItem> preview = new();

        public FormSalesBonusCalc()
        {
            InitializeComponent();

            DateTime prev = DateTime.Today.AddMonths(-1);
            spinYear.Value = prev.Year;
            spinMonth.Value = prev.Month;

            btnSalesPerson.ButtonClick += BtnSalesPerson_ButtonClick;
            lkpPlan.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == ButtonPredefines.Delete)
                    lkpPlan.EditValue = null;
            };

            btnPreview.Click += (_, __) => Preview();
            btnPost.Click += (_, __) => Post();
            btnClose.Click += (_, __) => Close();

            gridView1.CustomDrawRowIndicator += (s, e) =>
            {
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            };

            Load += (_, __) => LoadPlans();
        }

        private void BtnSalesPerson_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                btnSalesPerson.EditValue = null;
                return;
            }

            FormCurrAccList form = new(new byte[] { (byte)CurrAccType.Personnel }, false, btnSalesPerson.EditValue?.ToString());
            if (form.ShowDialog(this) == DialogResult.OK && form.dcCurrAcc != null)
                btnSalesPerson.EditValue = form.dcCurrAcc.CurrAccCode;
        }

        private void LoadPlans()
        {
            using var db = new subContext();
            lkpPlan.Properties.DataSource = db.DcSalesBonusPlans.AsNoTracking()
                .Where(x => x.IsActive)
                .OrderBy(x => x.PlanName)
                .ToList()
                .Select(x => new { x.SalesBonusPlanId, x.PlanName, TriggerTypeText = SalesBonusTexts.Text(x.TriggerType) })
                .ToList();
        }

        private (int Year, int Month, string? SalesPersonCode, Guid? PlanId, bool IncludeAuto) ReadFilters()
        {
            return ((int)spinYear.Value,
                    (int)spinMonth.Value,
                    btnSalesPerson.EditValue?.ToString(),
                    lkpPlan.EditValue is Guid g ? g : null,
                    chkIncludeAuto.Checked);
        }

        private void Preview()
        {
            var f = ReadFilters();
            Cursor prevCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                preview = service.PreviewPeriod(f.Year, f.Month, f.SalesPersonCode, f.PlanId, f.IncludeAuto, Authorization.CurrAccCode);
                gridControl1.DataSource = preview;
                gridView1.RefreshData();
                gridView1.BestFitColumns();
                btnPost.Enabled = preview.Any(x => Math.Abs(x.Delta) >= 0.01m);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.InnerException?.Message ?? ex.Message, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = prevCursor;
            }
        }

        private void Post()
        {
            var changes = preview.Where(x => Math.Abs(x.Delta) >= 0.01m).ToList();
            if (changes.Count == 0)
            {
                XtraMessageBox.Show(this, Properties.Resources.Form_SalesBonusCalc_NoChanges, Properties.Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string confirm = string.Format(Properties.Resources.Form_SalesBonusCalc_PostConfirm, changes.Count, changes.Sum(x => x.Delta));
            if (XtraMessageBox.Show(this, confirm, Properties.Resources.Common_Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var f = ReadFilters();
            Cursor prevCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                SalesBonusSyncResult result = service.PostPeriod(f.Year, f.Month, f.SalesPersonCode, f.PlanId, f.IncludeAuto, Authorization.CurrAccCode);
                XtraMessageBox.Show(this, string.Format(Properties.Resources.Form_SalesBonusCalc_PostDone, result.PostedCount, result.PostedAmount),
                    Properties.Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Preview();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.InnerException?.Message ?? ex.Message, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = prevCursor;
            }
        }
    }
}
