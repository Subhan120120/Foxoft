using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using Foxoft.Models;

namespace Foxoft
{
    public partial class FormProductFeature : XtraForm
    {
        EfMethods efMethods = new();
        DcProduct dcProduct = new();

        public FormProductFeature()
        {
            InitializeComponent();
            //AcceptButton = simpleButtonOk;
        }

        public FormProductFeature(string productCode)
           : this()
        {
            dcProduct = efMethods.SelectProduct(productCode, new byte[] { 1 });
        }

        private void FormProductFeature_Load(object sender, EventArgs e)
        {
            List<DcFeatureType> dcFeatures = efMethods.SelectFeatureTypesByHierarchy(dcProduct.HierarchyCode);

            foreach (DcFeatureType feature in dcFeatures)
            {
                TrProductFeature proFea = efMethods.SelectProductFeature(dcProduct.ProductCode, feature.FeatureTypeId);

                ButtonEdit btn = new();
                btn.Name = feature.FeatureTypeId.ToString();
                btn.StyleController = this.layoutControl1;
                if (proFea is not null)
                    btn.EditValue = proFea.FeatureCode;
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

            FormCommonList<DcFeature> frm = new(
                "F",
                nameof(DcFeature.FeatureCode),
                editor.EditValue,
                nameof(DcFeature.FeatureTypeId),
                Convert.ToInt32(editor.Name));

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
                    efMethods.UpdateDcFeature_Value(
                        Convert.ToByte(edit.Name),
                        dcProduct.ProductCode,
                        edit.EditValue.ToString().Trim());

                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void FormProductFeature_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
