using DevExpress.XtraEditors;
using Foxoft.AppCode;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormSalesBonusPlanEdit : XtraForm
    {
        private sealed class ProductRow
        {
            public string ProductCode { get; set; } = string.Empty;
            public string ProductDesc { get; set; } = string.Empty;
            public decimal? RateOverride { get; set; }
        }

        private sealed class CategoryRow
        {
            public string HierarchyCode { get; set; } = string.Empty;
            public string HierarchyDesc { get; set; } = string.Empty;
            public decimal? RateOverride { get; set; }
        }

        private readonly Guid? id;
        private DcSalesBonusPlan entity = null!;
        private bool hasTxns;

        private readonly BindingList<DcSalesBonusPlanTier> tiers = new();
        private readonly BindingList<ProductRow> products = new();
        private readonly BindingList<CategoryRow> categories = new();

        public FormSalesBonusPlanEdit(Guid? planId)
        {
            InitializeComponent();
            id = planId;

            Text = id == null ? Properties.Resources.Form_SalesBonusPlanEdit_Caption_New : Properties.Resources.Form_SalesBonusPlanEdit_Caption_Edit;

            lkpCalcMethod.Properties.DataSource = SalesBonusTexts.CalcMethods();
            lkpTriggerType.Properties.DataSource = SalesBonusTexts.TriggerTypes();
            lkpTierMode.Properties.DataSource = SalesBonusTexts.TierModes();
            lkpPeriodType.Properties.DataSource = SalesBonusTexts.PeriodTypes();

            gridTiers.DataSource = tiers;
            gridProducts.DataSource = products;
            gridCategories.DataSource = categories;

            btnAddTier.Click += (_, __) => AddTier();
            btnRemoveTier.Click += (_, __) => RemoveFocused(viewTiers, tiers);
            btnAddProduct.Click += (_, __) => AddProduct();
            btnRemoveProduct.Click += (_, __) => RemoveFocused(viewProducts, products);
            btnAddCategory.Click += (_, __) => AddCategory();
            btnRemoveCategory.Click += (_, __) => RemoveFocused(viewCategories, categories);

            lkpCalcMethod.EditValueChanged += (_, __) => ApplyMethodState();

            btnSave.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;
            Load += (_, __) => LoadEntity();
        }

        private void LoadEntity()
        {
            using var db = new subContext();

            if (id == null)
            {
                entity = new DcSalesBonusPlan { SalesBonusPlanId = Guid.NewGuid() };
            }
            else
            {
                entity = db.DcSalesBonusPlans.AsNoTracking()
                    .Include(x => x.Tiers)
                    .Include(x => x.Products).ThenInclude(x => x.DcProduct)
                    .Include(x => x.Categories).ThenInclude(x => x.DcHierarchy)
                    .First(x => x.SalesBonusPlanId == id.Value);

                hasTxns = db.TrSalesBonusTxns.Any(x => x.SalesBonusPlanId == id.Value);

                foreach (var t in entity.Tiers.OrderBy(x => x.FromValue))
                    tiers.Add(new DcSalesBonusPlanTier { SalesBonusPlanTierId = t.SalesBonusPlanTierId, SalesBonusPlanId = t.SalesBonusPlanId, FromValue = t.FromValue, ToValue = t.ToValue, Rate = t.Rate, FixedAmount = t.FixedAmount });

                foreach (var p in entity.Products.OrderBy(x => x.ProductCode))
                    products.Add(new ProductRow { ProductCode = p.ProductCode, ProductDesc = p.DcProduct?.ProductDesc ?? string.Empty, RateOverride = p.RateOverride });

                foreach (var c in entity.Categories.OrderBy(x => x.HierarchyCode))
                    categories.Add(new CategoryRow { HierarchyCode = c.HierarchyCode, HierarchyDesc = c.DcHierarchy?.HierarchyDesc ?? string.Empty, RateOverride = c.RateOverride });
            }

            txtPlanName.Text = entity.PlanName;
            txtDescription.Text = entity.Description;
            lkpCalcMethod.EditValue = (byte)entity.CalcMethod;
            lkpTriggerType.EditValue = (byte)entity.TriggerType;
            lkpTierMode.EditValue = (byte)entity.TierMode;
            lkpPeriodType.EditValue = (byte)entity.PeriodType;
            spinRate.Value = entity.Rate;
            spinFixedAmount.Value = entity.FixedAmount;
            spinTargetAmount.Value = entity.TargetAmount;
            spinTargetMinAchievement.Value = entity.TargetMinAchievementPercent;
            spinMinBaseAmount.Value = entity.MinBaseAmount;
            spinMaxBonusAmount.EditValue = entity.MaxBonusAmount;
            txtProcessCodes.Text = entity.ProcessCodes;
            chkIsActive.Checked = entity.IsActive;

            // Jurnalda əməliyyat varsa hesablama metodu dəyişdirilə bilməz (audit bütövlüyü).
            lkpCalcMethod.Enabled = !hasTxns;

            viewTiers.BestFitColumns();
            viewProducts.BestFitColumns();
            viewCategories.BestFitColumns();

            ApplyMethodState();
        }

        private BonusCalcMethod SelectedMethod =>
            lkpCalcMethod.EditValue == null ? BonusCalcMethod.SalesAmountPercent : (BonusCalcMethod)Convert.ToByte(lkpCalcMethod.EditValue);

        /// <summary>Seçilmiş metoda görə yalnız aidiyyəti olan sahələr aktiv qalır.</summary>
        private void ApplyMethodState()
        {
            BonusCalcMethod method = SelectedMethod;
            bool periodScoped = SalesBonusCalculator.IsPeriodScoped(method);

            spinRate.Enabled = method is BonusCalcMethod.SalesAmountPercent or BonusCalcMethod.GrossProfitPercent
                                      or BonusCalcMethod.PerUnitSold or BonusCalcMethod.CollectionPercent
                                      or BonusCalcMethod.SalesTargetAchievement;
            spinFixedAmount.Enabled = method is BonusCalcMethod.FixedAmount or BonusCalcMethod.SalesTargetAchievement;
            spinTargetAmount.Enabled = method == BonusCalcMethod.SalesTargetAchievement;
            spinTargetMinAchievement.Enabled = method == BonusCalcMethod.SalesTargetAchievement;
            lkpTierMode.Enabled = method == BonusCalcMethod.TieredSalesPercent;
            lkpPeriodType.Enabled = periodScoped;
            gridTiers.Enabled = method is BonusCalcMethod.TieredSalesPercent or BonusCalcMethod.SalesTargetAchievement;
            btnAddTier.Enabled = gridTiers.Enabled;
            btnRemoveTier.Enabled = gridTiers.Enabled;
        }

        private void AddTier()
        {
            viewTiers.CloseEditor();
            viewTiers.UpdateCurrentRow();

            decimal from = tiers.Count > 0 ? (tiers.Max(t => t.ToValue ?? t.FromValue)) : 0m;
            tiers.Add(new DcSalesBonusPlanTier { SalesBonusPlanTierId = Guid.NewGuid(), SalesBonusPlanId = entity.SalesBonusPlanId, FromValue = from });

            viewTiers.FocusedRowHandle = viewTiers.RowCount - 1;
            viewTiers.FocusedColumn = colTierTo;
            viewTiers.ShowEditor();
        }

        private void AddProduct()
        {
            using FormProductList form = new(new byte[] { 1 }, false);
            if (form.ShowDialog(this) != DialogResult.OK || form.dcProduct == null)
                return;

            if (products.Any(p => string.Equals(p.ProductCode, form.dcProduct.ProductCode, StringComparison.OrdinalIgnoreCase)))
            {
                XtraMessageBox.Show(this, Properties.Resources.Form_SalesBonusPlanEdit_ProductExists, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            products.Add(new ProductRow { ProductCode = form.dcProduct.ProductCode, ProductDesc = form.dcProduct.ProductDesc });
            viewProducts.BestFitColumns();
        }

        private void AddCategory()
        {
            using FormHierarchyList form = new(null);
            if (form.ShowDialog(this) != DialogResult.OK || form.DcHierarchy == null)
                return;

            if (categories.Any(c => string.Equals(c.HierarchyCode, form.DcHierarchy.HierarchyCode, StringComparison.OrdinalIgnoreCase)))
            {
                XtraMessageBox.Show(this, Properties.Resources.Form_SalesBonusPlanEdit_CategoryExists, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            categories.Add(new CategoryRow { HierarchyCode = form.DcHierarchy.HierarchyCode, HierarchyDesc = form.DcHierarchy.HierarchyDesc });
            viewCategories.BestFitColumns();
        }

        private static void RemoveFocused<T>(DevExpress.XtraGrid.Views.Grid.GridView view, BindingList<T> list)
        {
            view.CloseEditor();
            view.UpdateCurrentRow();
            if (view.GetFocusedRow() is T row)
                list.Remove(row);
        }

        private void Save()
        {
            viewTiers.CloseEditor();
            viewTiers.UpdateCurrentRow();
            viewProducts.CloseEditor();
            viewProducts.UpdateCurrentRow();
            viewCategories.CloseEditor();
            viewCategories.UpdateCurrentRow();

            BonusCalcMethod method = SelectedMethod;
            if (hasTxns && method != entity.CalcMethod)
            {
                XtraMessageBox.Show(this, Properties.Resources.Form_SalesBonusPlanEdit_CalcMethodLocked, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            entity.PlanName = txtPlanName.Text?.Trim() ?? string.Empty;
            entity.Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim();
            entity.CalcMethod = method;
            entity.TriggerType = (BonusTriggerType)Convert.ToByte(lkpTriggerType.EditValue ?? (byte)BonusTriggerType.OnInvoiceConfirm);
            entity.TierMode = (BonusTierMode)Convert.ToByte(lkpTierMode.EditValue ?? (byte)BonusTierMode.Progressive);
            entity.PeriodType = (BonusPeriodType)Convert.ToByte(lkpPeriodType.EditValue ?? (byte)BonusPeriodType.Monthly);
            entity.Rate = spinRate.Value;
            entity.FixedAmount = spinFixedAmount.Value;
            entity.TargetAmount = spinTargetAmount.Value;
            entity.TargetMinAchievementPercent = spinTargetMinAchievement.Value;
            entity.MinBaseAmount = spinMinBaseAmount.Value;
            entity.MaxBonusAmount = spinMaxBonusAmount.EditValue == null || spinMaxBonusAmount.EditValue == DBNull.Value
                ? null
                : Convert.ToDecimal(spinMaxBonusAmount.EditValue);
            entity.ProcessCodes = string.IsNullOrWhiteSpace(txtProcessCodes.Text)
                ? null
                : string.Join(",", txtProcessCodes.Text.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(x => x.ToUpperInvariant()));
            entity.IsActive = chkIsActive.Checked;

            if (!EntityValidationHelper.TryValidate(entity, out var msg))
            {
                XtraMessageBox.Show(this, msg, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (method == BonusCalcMethod.TieredSalesPercent && tiers.Count == 0)
            {
                XtraMessageBox.Show(this, Properties.Resources.Form_SalesBonusPlanEdit_TiersRequired, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var db = new subContext();

                if (db.DcSalesBonusPlans.Any(x => x.PlanName == entity.PlanName && x.SalesBonusPlanId != entity.SalesBonusPlanId))
                {
                    XtraMessageBox.Show(this, Properties.Resources.Form_SalesBonusPlanEdit_NameExists, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DcSalesBonusPlan target;
                if (id == null)
                {
                    target = entity;
                    target.CreatedUserName = Authorization.CurrAccCode;
                    target.CreatedDate = DateTime.Now;
                    target.LastUpdatedUserName = Authorization.CurrAccCode;
                    target.LastUpdatedDate = DateTime.Now;
                    target.Tiers.Clear();
                    target.Products.Clear();
                    target.Categories.Clear();
                    db.DcSalesBonusPlans.Add(target);
                }
                else
                {
                    target = db.DcSalesBonusPlans
                        .Include(x => x.Tiers)
                        .Include(x => x.Products)
                        .Include(x => x.Categories)
                        .First(x => x.SalesBonusPlanId == id.Value);

                    target.PlanName = entity.PlanName;
                    target.Description = entity.Description;
                    target.CalcMethod = entity.CalcMethod;
                    target.TriggerType = entity.TriggerType;
                    target.TierMode = entity.TierMode;
                    target.PeriodType = entity.PeriodType;
                    target.Rate = entity.Rate;
                    target.FixedAmount = entity.FixedAmount;
                    target.TargetAmount = entity.TargetAmount;
                    target.TargetMinAchievementPercent = entity.TargetMinAchievementPercent;
                    target.MinBaseAmount = entity.MinBaseAmount;
                    target.MaxBonusAmount = entity.MaxBonusAmount;
                    target.ProcessCodes = entity.ProcessCodes;
                    target.IsActive = entity.IsActive;
                    target.LastUpdatedUserName = Authorization.CurrAccCode;
                    target.LastUpdatedDate = DateTime.Now;

                    // Konfiqurasiya sətirləri tam yenilənir (jurnal onlara istinad etmir).
                    db.DcSalesBonusPlanTiers.RemoveRange(target.Tiers);
                    db.DcSalesBonusPlanProducts.RemoveRange(target.Products);
                    db.DcSalesBonusPlanCategories.RemoveRange(target.Categories);
                }

                foreach (var t in tiers.OrderBy(x => x.FromValue))
                {
                    db.DcSalesBonusPlanTiers.Add(new DcSalesBonusPlanTier
                    {
                        SalesBonusPlanTierId = Guid.NewGuid(),
                        SalesBonusPlanId = target.SalesBonusPlanId,
                        FromValue = t.FromValue,
                        ToValue = t.ToValue,
                        Rate = t.Rate,
                        FixedAmount = t.FixedAmount
                    });
                }

                foreach (var p in products)
                {
                    db.DcSalesBonusPlanProducts.Add(new DcSalesBonusPlanProduct
                    {
                        SalesBonusPlanProductId = Guid.NewGuid(),
                        SalesBonusPlanId = target.SalesBonusPlanId,
                        ProductCode = p.ProductCode,
                        RateOverride = p.RateOverride
                    });
                }

                foreach (var c in categories)
                {
                    db.DcSalesBonusPlanCategories.Add(new DcSalesBonusPlanCategory
                    {
                        SalesBonusPlanCategoryId = Guid.NewGuid(),
                        SalesBonusPlanId = target.SalesBonusPlanId,
                        HierarchyCode = c.HierarchyCode,
                        RateOverride = c.RateOverride
                    });
                }

                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.InnerException?.Message ?? ex.Message, Properties.Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
