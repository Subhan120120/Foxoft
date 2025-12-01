using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using Foxoft.Models;
using Foxoft.Properties; // <-- for Resources

namespace Foxoft
{
    public partial class FormCurrAccFeature : XtraForm
    {
        EfMethods efMethods = new();
        DcCurrAcc dcCurrAcc = new();

        public FormCurrAccFeature()
        {
            InitializeComponent();
        }

        public FormCurrAccFeature(string currAccCode)
           : this()
        {
            dcCurrAcc = efMethods.SelectCurrAcc(currAccCode);
        }

        private void FormCurrAccFeature_Load(object sender, EventArgs e)
        {
            List<DcCurrAccFeatureType> dcFeatures = efMethods.SelectEntities<DcCurrAccFeatureType>();

            foreach (DcCurrAccFeatureType feature in dcFeatures)
            {
                TrCurrAccFeature currAccFea = efMethods.SelectCurrAccFeature(dcCurrAcc.CurrAccCode, feature.CurrAccFeatureTypeId);

                ButtonEdit btn = new();
                btn.Name = feature.CurrAccFeatureTypeId.ToString();
                btn.StyleController = this.layoutControl1;
                if (currAccFea is not null)
                    btn.EditValue = currAccFea.CurrAccFeatureCode;
                btn.ButtonPressed += new(this.btnEdit_ButtonPressed);

                LayoutControlItem lCI = new();
                lCI.Control = btn;
                lCI.Name = feature.FeatureTypeName;

                Root.Items.AddRange(new BaseLayoutItem[] { lCI });
            }
        }

        private void btnEdit_ButtonPressed(object sender, EventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;

            FormCommonList<DcCurrAccFeature> frm = new("F", nameof(DcCurrAccFeature.CurrAccFeatureCode), editor.EditValue, nameof(DcCurrAccFeature.CurrAccFeatureTypeId), Convert.ToInt32(editor.Name));
            if (DialogResult.OK == frm.ShowDialog())
                editor.EditValue = frm.Value_Id;
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in layoutControl1.Controls)
            {
                BaseEdit edit = ctrl as BaseEdit;

                if (edit is ButtonEdit && edit is not null && edit.EditValue is not null)
                {
                    efMethods.UpdateDcFeatureCurrAcc_Value(Convert.ToByte(edit.Name), dcCurrAcc.CurrAccCode, edit.EditValue.ToString().Trim());
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void FormCurrAccFeature_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
