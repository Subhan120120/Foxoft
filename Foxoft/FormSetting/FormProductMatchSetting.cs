using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Foxoft.Properties;

namespace Foxoft
{
    public partial class FormProductMatchSetting : XtraForm
    {
        private ProductMatchOptions _options = new();

        public ProductMatchOptions Options => _options;

        public FormProductMatchSetting()
        {
            InitializeComponent();
            ApplyLocalization();
            SetupEventHandlers();
        }

        private void FormProductMatchSetting_Load(object sender, EventArgs e)
        {
            _options = ProductMatchOptions.Load();
            BindControls();
        }

        private void SetupEventHandlers()
        {
            lblTier1Desc.Click += (s, e) => chkTier1.Checked = !chkTier1.Checked;
            lblTier2Desc.Click += (s, e) => chkTier2.Checked = !chkTier2.Checked;
            lblTier3Desc.Click += (s, e) => chkTier3.Checked = !chkTier3.Checked;
            lblTier4Desc.Click += (s, e) => chkTier4.Checked = !chkTier4.Checked;
            lblTier5Desc.Click += (s, e) => chkTier5.Checked = !chkTier5.Checked;
            lblTier6Desc.Click += (s, e) => chkTier6.Checked = !chkTier6.Checked;
        }

        private void ApplyLocalization()
        {
            Text = Resources.Form_ProductMatchSetting_Title;
            layoutControlGroupMethods.Text = Resources.Form_ProductMatchSetting_GroupMethods;
            lblInfo.Text = Resources.Form_ProductMatchSetting_Info;

            chkTier1.Text = Resources.Form_ProductMatchSetting_Tier1;
            lblTier1Desc.Text = Resources.Form_ProductMatchSetting_Tier1_Desc;

            chkTier2.Text = Resources.Form_ProductMatchSetting_Tier2;
            lblTier2Desc.Text = Resources.Form_ProductMatchSetting_Tier2_Desc;
            itemCustomStopWords.Text = Resources.Form_ProductMatchSetting_CustomStopWords;

            chkTier3.Text = Resources.Form_ProductMatchSetting_Tier3;
            lblTier3Desc.Text = Resources.Form_ProductMatchSetting_Tier3_Desc;

            chkTier4.Text = Resources.Form_ProductMatchSetting_Tier4;
            lblTier4Desc.Text = Resources.Form_ProductMatchSetting_Tier4_Desc;

            chkTier5.Text = Resources.Form_ProductMatchSetting_Tier5;
            lblTier5Desc.Text = Resources.Form_ProductMatchSetting_Tier5_Desc;

            itemFuzzyPercent.Text = Resources.Form_ProductMatchSetting_FuzzyPercent;

            chkTier6.Text = Resources.Form_ProductMatchSetting_Tier6;
            lblTier6Desc.Text = Resources.Form_ProductMatchSetting_Tier6_Desc;

            btnResetDefaults.Text = Resources.Form_ProductMatchSetting_ResetDefaults;
            btnSave.Text = Resources.Common_Save;
            btnCancel.Text = Resources.Common_Cancel;
        }

        private void BindControls()
        {
            chkTier1.Checked = _options.MatchByBarcodeAndCode;
            chkTier2.Checked = _options.MatchByCategoryStopWords;
            txtCustomStopWords.Text = _options.CustomStopWords ?? string.Empty;
            chkTier3.Checked = _options.MatchByModelAndBrand;
            chkTier4.Checked = _options.MatchByTokenOverlap;
            chkTier5.Checked = _options.MatchByFuzzySimilarity;
            spnFuzzyPercent.Value = _options.FuzzyMinSimilarityPercent > 0 ? _options.FuzzyMinSimilarityPercent : 85;
            chkTier6.Checked = _options.MatchByVendorHistory;

            UpdateCustomStopWordsState();
            UpdateFuzzyPercentState();
        }

        private void UpdateCustomStopWordsState()
        {
            itemCustomStopWords.Visibility = chkTier2.Checked
                ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void chkTier2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCustomStopWordsState();
        }

        private void UpdateFuzzyPercentState()
        {
            itemFuzzyPercent.Visibility = chkTier5.Checked
                ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void chkTier5_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFuzzyPercentState();
        }

        private void btnResetDefaults_Click(object sender, EventArgs e)
        {
            _options.ResetToDefaults();
            BindControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _options.MatchByBarcodeAndCode = chkTier1.Checked;
            _options.MatchByCategoryStopWords = chkTier2.Checked;
            _options.CustomStopWords = txtCustomStopWords.Text.Trim();
            _options.MatchByModelAndBrand = chkTier3.Checked;
            _options.MatchByTokenOverlap = chkTier4.Checked;
            _options.MatchByFuzzySimilarity = chkTier5.Checked;
            _options.FuzzyMinSimilarityPercent = (int)spnFuzzyPercent.Value;
            _options.MatchByVendorHistory = chkTier6.Checked;

            _options.Save();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
