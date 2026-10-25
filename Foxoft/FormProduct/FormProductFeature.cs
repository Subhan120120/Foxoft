using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.AppCode;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Foxoft.Models.ViewModel;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;

namespace Foxoft
{
    public partial class FormProductFeature : XtraForm
    {
        private readonly EfMethods _efMethods = new();
        private DcProduct _dcProduct = new();
        private string _barcode = string.Empty;
        private readonly BindingList<ProductFeatureLineVM> _featureLines = new();
        private readonly ProductFeatureAiService _aiService = new();
        private CancellationTokenSource? _aiCts;
        private bool _isProcessing;

        private List<DcFeature> _featuresCache = new();
        private List<DcFeatureType> _featureTypes = new();
        private readonly Dictionary<int, RepositoryItemSearchLookUpEdit> _repoLookUpCache = new();

        public FormProductFeature()
        {
            InitializeComponent();
            ApplyLocalization();
        }

        public FormProductFeature(string productCode)
           : this()
        {
            if (!string.IsNullOrWhiteSpace(productCode))
            {
                _dcProduct = _efMethods.SelectProduct(productCode, new byte[] { 1, 2, 3, 4 })
                             ?? new DcProduct { ProductCode = productCode };

                using subContext db = new();
                _barcode = db.TrProductBarcodes
                    .AsNoTracking()
                    .Where(x => x.ProductCode == productCode)
                    .OrderBy(x => x.BarcodeTypeCode)
                    .Select(x => x.Barcode)
                    .FirstOrDefault() ?? string.Empty;
            }
        }

        public FormProductFeature(DcProduct product)
            : this(product?.ProductCode ?? string.Empty)
        {
            if (product != null)
                _dcProduct = product;
        }

        private void ApplyLocalization()
        {
            Text = Resources.Form_ProductFeature_Caption;
            layoutControlGroupHeader.Text = Resources.Form_ProductFeature_Caption;
            layoutControlItemProductCode.Text = Resources.Entity_Product_Code + ":";
            layoutControlItemBarcode.Text = Resources.Common_Barcode + ":";
            layoutControlItemProductDesc.Text = Resources.Form_ProductFeature_SearchQuery + ":";

            btnSearchAi.Text = Resources.Form_ProductFeature_SearchWithAi;
            btnCancelAi.Text = Resources.Form_ProductFeature_CancelAi;

            colOrder.Caption = Resources.Form_ProductFeature_ColOrder;
            colFeatureTypeName.Caption = Resources.Form_ProductFeature_ColFeatureType;
            colAiExtractedValue.Caption = Resources.Form_ProductFeature_ColAiResult;
            colMatchStatus.Caption = Resources.Form_ProductFeature_ColStatus;
            colMatchedFeatureCode.Caption = Resources.Form_ProductFeature_ColMatchedFeature;
            colAction.Caption = Resources.Form_ProductFeature_ColAction;

            if (repoBtn_CreateFeature.Buttons.Count > 0)
                repoBtn_CreateFeature.Buttons[0].Caption = Resources.Form_ProductFeature_BtnCreate;

            simpleButtonSave.Text = Resources.Common_Save;
            simpleButtonCancel.Text = Resources.Common_Cancel;
        }

        private void FormProductFeature_Load(object sender, EventArgs e)
        {
            SetProcessingState(false);

            txtProductCode.Text = _dcProduct.ProductCode ?? string.Empty;
            txtProductDesc.Text = _dcProduct.ProductDesc ?? string.Empty;
            txtBarcode.Text = _barcode;

            gridControlFeatures.DataSource = _featureLines;

            LoadData();
            UpdateBalanceStatus();
            UpdateSummary();
        }

        private void LoadData()
        {
            try
            {
                using subContext db = new();

                _featuresCache = db.DcFeatures.AsNoTracking().ToList();

                _featureTypes = _efMethods.SelectFeatureTypesByHierarchy(_dcProduct.HierarchyCode);
                if (_featureTypes == null || _featureTypes.Count == 0)
                {
                    _featureTypes = db.DcFeatureTypes.AsNoTracking().OrderBy(x => x.Order).ToList();
                }

                var existingProductFeatures = db.TrProductFeatures
                    .AsNoTracking()
                    .Where(x => x.ProductCode == _dcProduct.ProductCode)
                    .ToList();

                _featureLines.Clear();
                int orderIndex = 1;

                foreach (var ft in _featureTypes.OrderBy(x => x.Order))
                {
                    var existingPf = existingProductFeatures.FirstOrDefault(x => x.FeatureTypeId == ft.FeatureTypeId);
                    var matchedFeature = existingPf != null
                        ? _featuresCache.FirstOrDefault(f => f.FeatureTypeId == ft.FeatureTypeId && f.FeatureCode == existingPf.FeatureCode)
                        : null;

                    ProductFeatureLineVM line = new()
                    {
                        FeatureTypeId = ft.FeatureTypeId,
                        FeatureTypeName = ft.FeatureTypeName,
                        Order = orderIndex++,
                        MatchedFeatureCode = existingPf?.FeatureCode,
                        MatchedFeatureDesc = matchedFeature?.FeatureDesc ?? existingPf?.FeatureCode,
                        Status = existingPf != null ? FeatureMatchStatus.Matched : FeatureMatchStatus.Empty,
                        CanCreate = false
                    };

                    _featureLines.Add(line);
                }

                _repoLookUpCache.Clear();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"{Resources.Common_ErrorOccurred}\n{ex.Message}", Resources.Common_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateBalanceStatus()
        {
            lblStatus.Text = string.Empty;
        }

        private void UpdateSummary()
        {
            int total = _featureLines.Count;
            int matched = _featureLines.Count(x => x.Status == FeatureMatchStatus.Matched);
            int notFound = _featureLines.Count(x => x.Status == FeatureMatchStatus.NotFound);

            lblSummary.Text = string.Format(Resources.Form_ProductFeature_SummaryStats, total, matched, notFound);
        }

        private void SetProcessingState(bool isProcessing)
        {
            _isProcessing = isProcessing;

            btnSearchAi.Enabled = !isProcessing;
            layoutControlItemCancelAi.Visibility = isProcessing ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            btnCancelAi.Enabled = isProcessing;

            progressBarAi.Properties.Stopped = !isProcessing;
            layoutControlItemProgress.Visibility = isProcessing ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            txtProductDesc.Properties.ReadOnly = isProcessing;
            simpleButtonSave.Enabled = !isProcessing;
            simpleButtonCancel.Enabled = !isProcessing;

            if (isProcessing)
                lblStatus.Text = Resources.Form_ProductFeature_StatusSearching;
            else
                UpdateBalanceStatus();
        }

        private async void btnSearchAi_Click(object sender, EventArgs e)
        {
            if (_isProcessing) return;

            // Check if there are any unassigned lines
            var unassignedLines = _featureLines.Where(l => string.IsNullOrWhiteSpace(l.MatchedFeatureCode)).ToList();
            if (unassignedLines.Count == 0)
            {
                XtraMessageBox.Show(Resources.Form_ProductFeature_AllAssigned, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string query = txtProductDesc.Text.Trim();
            if (string.IsNullOrWhiteSpace(query))
                query = _dcProduct.ProductDesc?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(query))
            {
                XtraMessageBox.Show(Resources.Form_ProductFeature_SearchQuery, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm AI execution
            string promptMsg = Resources.Form_ProductFeature_PromptConfirmAi;
            if (XtraMessageBox.Show(promptMsg, Resources.Common_Attention, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            string apiKey = Settings.Default.AppSetting?.OpenAIApiKey?.Trim() ?? string.Empty;


            if (string.IsNullOrWhiteSpace(apiKey))
            {
                XtraMessageBox.Show(Resources.Form_ProductFeature_ApiKeyRequired, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if user has sufficient credit balance before calling AI
            decimal currentBalance = CreditService.GetBalance();
            if (currentBalance < 0.01m)
            {
                XtraMessageBox.Show(Resources.Common_InsufficientBalance, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string model = Settings.Default.AppSetting?.OpenAIModel?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(model))
                model = "gpt-4o";

            bool succeeded = false;
            SetProcessingState(true);
            _aiCts = new CancellationTokenSource();

            try
            {
                var knownAssigned = _featureLines
                    .Where(l => !string.IsNullOrWhiteSpace(l.MatchedFeatureCode))
                    .Select(l => new KeyValuePair<string, string>(
                        l.FeatureTypeName,
                        !string.IsNullOrWhiteSpace(l.MatchedFeatureDesc) ? l.MatchedFeatureDesc : l.MatchedFeatureCode!))
                    .ToList();

                var targetTypes = _featureTypes
                    .Where(ft => unassignedLines.Any(u => u.FeatureTypeId == ft.FeatureTypeId))
                    .Select(ft => new ProductFeatureAiTargetTypeDto
                    {
                        FeatureTypeId = ft.FeatureTypeId,
                        FeatureTypeName = ft.FeatureTypeName,
                        ExistingValues = _featuresCache
                            .Where(f => f.FeatureTypeId == ft.FeatureTypeId)
                            .Select(f => !string.IsNullOrWhiteSpace(f.FeatureDesc) ? $"{f.FeatureCode} ({f.FeatureDesc})" : f.FeatureCode)
                            .ToList()
                    }).ToList();

                ProductFeatureAiResult result = await _aiService.ExtractFeaturesAsync(
                    query,
                    txtBarcode.Text.Trim(),
                    targetTypes,
                    apiKey,
                    model,
                    knownAssigned,
                    _aiCts.Token);

                succeeded = true;

                // Dynamic credit deduction: 6.8x actual cost (without exposing multiplier to user)
                decimal creditToDeduct = result.CreditRequired;
                if (creditToDeduct > 0)
                {
                    string creditDesc = $"Məhsul AI ({_dcProduct.ProductCode}) - {creditToDeduct:F2} kredit";
                    CreditService.TryDeductFeatureAiCredit(out _, creditToDeduct, creditDesc);
                }

                // Match AI results with existing database features for unassigned lines
                int matchedCount = 0;
                int newCount = 0;

                foreach (var aiItem in result.Features)
                {
                    var line = _featureLines.FirstOrDefault(l => l.FeatureTypeId == aiItem.FeatureTypeId);
                    if (line == null) continue;

                    // AI must never overwrite already assigned values
                    if (!string.IsNullOrWhiteSpace(line.MatchedFeatureCode))
                        continue;

                    line.AiExtractedValue = aiItem.ExtractedValue;
                    line.SuggestedNewCode = aiItem.SuggestedNewCode;
                    line.SuggestedNewDesc = aiItem.SuggestedNewDesc;
                    line.Notes = aiItem.Notes;

                    if (string.IsNullOrWhiteSpace(aiItem.ExtractedValue))
                        continue;

                    var typeFeatures = _featuresCache.Where(f => f.FeatureTypeId == line.FeatureTypeId).ToList();
                    DcFeature? matchedFeature = null;

                    // 1. OpenAI matchedFeatureCode
                    if (!string.IsNullOrWhiteSpace(aiItem.MatchedFeatureCode))
                    {
                        string targetCode = aiItem.MatchedFeatureCode.Trim();
                        matchedFeature = typeFeatures.FirstOrDefault(f => string.Equals(f.FeatureCode?.Trim(), targetCode, StringComparison.OrdinalIgnoreCase));
                    }

                    // 2. Exact match on FeatureCode
                    if (matchedFeature == null)
                    {
                        matchedFeature = typeFeatures.FirstOrDefault(f => string.Equals(f.FeatureCode?.Trim(), aiItem.ExtractedValue.Trim(), StringComparison.OrdinalIgnoreCase));
                    }

                    // 3. Exact match on FeatureDesc
                    if (matchedFeature == null)
                    {
                        matchedFeature = typeFeatures.FirstOrDefault(f => string.Equals(f.FeatureDesc?.Trim(), aiItem.ExtractedValue.Trim(), StringComparison.OrdinalIgnoreCase));
                    }

                    // 4. Normalized match
                    if (matchedFeature == null)
                    {
                        string norm = Normalize(aiItem.ExtractedValue);
                        matchedFeature = typeFeatures.FirstOrDefault(f => Normalize(f.FeatureCode) == norm || Normalize(f.FeatureDesc) == norm);
                    }

                    if (matchedFeature != null)
                    {
                        line.MatchedFeatureCode = matchedFeature.FeatureCode;
                        line.MatchedFeatureDesc = matchedFeature.FeatureDesc;
                        line.Status = FeatureMatchStatus.Matched;
                        line.CanCreate = false;
                        matchedCount++;
                    }
                    else
                    {
                        line.MatchedFeatureCode = null;
                        line.MatchedFeatureDesc = null;
                        line.Status = FeatureMatchStatus.NotFound;
                        line.CanCreate = true;

                        if (string.IsNullOrWhiteSpace(line.SuggestedNewCode))
                            line.SuggestedNewCode = CleanCode(aiItem.ExtractedValue);
                        if (string.IsNullOrWhiteSpace(line.SuggestedNewDesc))
                            line.SuggestedNewDesc = aiItem.ExtractedValue;

                        newCount++;
                    }
                }

                gridControlFeatures.RefreshDataSource();
                gridViewFeatures.RefreshData();
                UpdateSummary();

                string statsMsg = string.Format(Resources.Form_ProductFeature_SummaryStats, _featureLines.Count, _featureLines.Count(l => l.Status == FeatureMatchStatus.Matched), _featureLines.Count(l => l.Status == FeatureMatchStatus.NotFound));
                string costMsg = string.Format(Resources.Form_ProductFeature_UsedCredit, creditToDeduct);

                XtraMessageBox.Show(
                    $"{Resources.Form_ProductFeature_SuccessSummary}\n{statsMsg}\n\n{costMsg}",
                    Resources.Common_Info,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (OperationCanceledException ex)
            {
                decimal creditToDeduct = 0m;
                string? creditDesc = null;

                if (ex is AiCancelledException aiEx && aiEx.CreditRequired > 0)
                {
                    creditToDeduct = aiEx.CreditRequired;
                    creditDesc = aiEx.Description;
                }
                else
                {
                    int inTokens = (query.Length / 3) + 600;
                    decimal cost = CreditService.CalculateCostUsd(model, inTokens, 0, 1);
                    creditToDeduct = CreditService.CalculateCreditFromCost(cost);
                    creditDesc = $"Məhsul AI ləğv edildi ({_dcProduct?.ProductCode ?? query}) - {creditToDeduct:F2} kredit";
                }

                if (creditToDeduct > 0)
                {
                    CreditService.TryDeductFeatureAiCredit(out _, creditToDeduct, creditDesc);
                }

                string costMsg = creditToDeduct > 0
                    ? $"\n\n{string.Format(Resources.Form_ProductFeature_UsedCredit, creditToDeduct)}"
                    : string.Empty;

                lblStatus.Text = Resources.Common_OperationCancelled;
                XtraMessageBox.Show(
                    $"{Resources.Common_OperationCancelled}{costMsg}",
                    Resources.Common_Info,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"{Resources.Common_ErrorOccurred}\n{ex.Message}", Resources.Common_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetProcessingState(false);
                _aiCts?.Dispose();
                _aiCts = null;
            }
        }

        private void btnCancelAi_Click(object sender, EventArgs e)
        {
            try
            {
                _aiCts?.Cancel();
            }
            catch
            {
                // ignore
            }
        }

        private void repoBtn_CreateFeature_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            CreateNewFeatureForFocusedRow();
        }

        private void CreateNewFeatureForFocusedRow()
        {
            if (gridViewFeatures.GetFocusedRow() is not ProductFeatureLineVM focusedLine)
                return;

            string initialCode = !string.IsNullOrWhiteSpace(focusedLine.SuggestedNewCode)
                ? focusedLine.SuggestedNewCode
                : (!string.IsNullOrWhiteSpace(focusedLine.AiExtractedValue) ? CleanCode(focusedLine.AiExtractedValue) : string.Empty);

            string initialDesc = !string.IsNullOrWhiteSpace(focusedLine.SuggestedNewDesc)
                ? focusedLine.SuggestedNewDesc
                : (!string.IsNullOrWhiteSpace(focusedLine.AiExtractedValue) ? focusedLine.AiExtractedValue : string.Empty);

            DcFeature template = new()
            {
                FeatureTypeId = focusedLine.FeatureTypeId,
                FeatureCode = initialCode,
                FeatureDesc = initialDesc
            };

            using FormCommon<DcFeature> frm = new(
                processCode: "F",
                isNew: true,
                fieldName_Id: nameof(DcFeature.FeatureCode),
                value_Id: initialCode,
                fieldName_2: nameof(DcFeature.FeatureTypeId),
                value_2: focusedLine.FeatureTypeId,
                specialColumnsHide: null,
                templateEntity: template);

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                string newCode = frm.Value_Id?.ToString() ?? initialCode;

                using (subContext db = new())
                {
                    _featuresCache = db.DcFeatures.AsNoTracking().ToList();
                }

                _repoLookUpCache.Remove(focusedLine.FeatureTypeId);

                var savedFeature = _featuresCache.FirstOrDefault(f => f.FeatureTypeId == focusedLine.FeatureTypeId && f.FeatureCode == newCode);

                focusedLine.MatchedFeatureCode = newCode;
                focusedLine.MatchedFeatureDesc = savedFeature?.FeatureDesc ?? newCode;
                focusedLine.Status = FeatureMatchStatus.Matched;
                focusedLine.CanCreate = false;

                gridViewFeatures.RefreshRow(gridViewFeatures.FocusedRowHandle);
                UpdateSummary();
            }
        }

        private void repoBtnEdit_SelectFeature_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (gridViewFeatures.GetFocusedRow() is not ProductFeatureLineVM focusedLine)
                return;

            FormCommonList<DcFeature> frm = new(
                "F",
                nameof(DcFeature.FeatureCode),
                focusedLine.MatchedFeatureCode,
                nameof(DcFeature.FeatureTypeId),
                focusedLine.FeatureTypeId);

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                string selectedCode = frm.Value_Id?.ToString() ?? string.Empty;

                if (!string.IsNullOrWhiteSpace(selectedCode))
                {
                    using (subContext db = new())
                    {
                        _featuresCache = db.DcFeatures.AsNoTracking().ToList();
                    }

                    _repoLookUpCache.Remove(focusedLine.FeatureTypeId);

                    var f = _featuresCache.FirstOrDefault(x => x.FeatureTypeId == focusedLine.FeatureTypeId && x.FeatureCode == selectedCode);
                    focusedLine.MatchedFeatureCode = selectedCode;
                    focusedLine.MatchedFeatureDesc = f?.FeatureDesc ?? selectedCode;
                    focusedLine.Status = FeatureMatchStatus.Matched;
                    focusedLine.CanCreate = false;
                }
                else
                {
                    focusedLine.MatchedFeatureCode = null;
                    focusedLine.MatchedFeatureDesc = null;
                    focusedLine.Status = !string.IsNullOrWhiteSpace(focusedLine.AiExtractedValue)
                        ? FeatureMatchStatus.NotFound
                        : FeatureMatchStatus.Empty;
                    focusedLine.CanCreate = !string.IsNullOrWhiteSpace(focusedLine.AiExtractedValue);
                }

                gridViewFeatures.RefreshRow(gridViewFeatures.FocusedRowHandle);
                UpdateSummary();
            }
        }

        private void gridViewFeatures_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column == colMatchedFeatureCode && gridViewFeatures.GetRow(e.RowHandle) is ProductFeatureLineVM line)
            {
                if (!_repoLookUpCache.TryGetValue(line.FeatureTypeId, out var repoLookup))
                {
                    repoLookup = new RepositoryItemSearchLookUpEdit();
                    repoLookup.NullText = Resources.Form_ProductFeature_SelectFeatureHint;
                    repoLookup.ValueMember = nameof(DcFeature.FeatureCode);
                    repoLookup.DisplayMember = nameof(DcFeature.FeatureDesc);

                    var list = _featuresCache
                        .Where(f => f.FeatureTypeId == line.FeatureTypeId)
                        .Select(f => new
                        {
                            f.FeatureCode,
                            FeatureDesc = !string.IsNullOrWhiteSpace(f.FeatureDesc) ? f.FeatureDesc : f.FeatureCode
                        })
                        .ToList();

                    repoLookup.DataSource = list;
                    _repoLookUpCache[line.FeatureTypeId] = repoLookup;
                    gridControlFeatures.RepositoryItems.Add(repoLookup);
                }

                e.RepositoryItem = repoLookup;
            }
        }

        private void gridViewFeatures_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == colMatchStatus && e.Value is FeatureMatchStatus status)
            {
                e.DisplayText = status switch
                {
                    FeatureMatchStatus.Matched => Resources.Form_ProductFeature_StatusMatched,
                    FeatureMatchStatus.NotFound => Resources.Form_ProductFeature_StatusNotFound,
                    _ => Resources.Form_ProductFeature_StatusEmpty
                };
            }
            else if (e.Column == colMatchedFeatureCode)
            {
                if (gridViewFeatures.GetRow(e.ListSourceRowIndex) is ProductFeatureLineVM line && !string.IsNullOrWhiteSpace(line.MatchedFeatureCode))
                {
                    string desc = !string.IsNullOrWhiteSpace(line.MatchedFeatureDesc) ? line.MatchedFeatureDesc : line.MatchedFeatureCode;
                    e.DisplayText = $"{line.MatchedFeatureCode} - {desc}";
                }
            }
        }

        private void gridViewFeatures_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column == colMatchStatus && gridViewFeatures.GetRow(e.RowHandle) is ProductFeatureLineVM line)
            {
                if (line.Status == FeatureMatchStatus.Matched)
                {
                    e.Appearance.ForeColor = Color.FromArgb(0, 140, 60);
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }
                else if (line.Status == FeatureMatchStatus.NotFound)
                {
                    e.Appearance.ForeColor = Color.FromArgb(210, 105, 0);
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }
                else
                {
                    e.Appearance.ForeColor = Color.Gray;
                }
            }
        }

        private void gridViewFeatures_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colMatchedFeatureCode && gridViewFeatures.GetRow(e.RowHandle) is ProductFeatureLineVM line)
            {
                string code = line.MatchedFeatureCode?.Trim() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(code))
                {
                    var f = _featuresCache.FirstOrDefault(x => x.FeatureTypeId == line.FeatureTypeId && x.FeatureCode == code);
                    line.MatchedFeatureDesc = f?.FeatureDesc ?? code;
                    line.Status = FeatureMatchStatus.Matched;
                    line.CanCreate = false;
                }
                else
                {
                    line.MatchedFeatureDesc = null;
                    line.Status = !string.IsNullOrWhiteSpace(line.AiExtractedValue) ? FeatureMatchStatus.NotFound : FeatureMatchStatus.Empty;
                    line.CanCreate = !string.IsNullOrWhiteSpace(line.AiExtractedValue);
                }

                UpdateSummary();
            }
        }

        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var line in _featureLines)
                {
                    _efMethods.UpdateDcFeature_Value(
                        line.FeatureTypeId,
                        _dcProduct.ProductCode,
                        line.MatchedFeatureCode?.Trim() ?? string.Empty);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"{Resources.Common_ErrorOccurred}\n{ex.Message}", Resources.Common_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormProductFeature_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (_isProcessing)
                    btnCancelAi_Click(sender, EventArgs.Empty);
                else
                    Close();
            }
        }

        private static string Normalize(string? s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;
            return new string(s.Where(char.IsLetterOrDigit).ToArray()).ToLowerInvariant();
        }

        private static string CleanCode(string? s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;
            var clean = s.Trim().Replace(" ", "_").ToUpperInvariant();
            return clean.Length > 20 ? clean.Substring(0, 20) : clean;
        }
    }
}
