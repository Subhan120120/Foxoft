using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
            dcProduct = efMethods.SelectProduct(productCode);
        }

        private void FormFeatureTest_Load(object sender, EventArgs e)
        {
            List<DcFeatureType> dcFeatures = efMethods.SelectFeatureTypesByHierarchy(dcProduct.HierarchyCode);

            foreach (DcFeatureType feature in dcFeatures)
            {
                TrProductFeature proFea = efMethods.SelectProductFeature(feature.FeatureTypeId, dcProduct.ProductCode);

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

            FormCommonList<DcFeature> frm = new("F", "FeatureCode", Convert.ToInt32(editor.Name).ToString());
            if (DialogResult.OK == frm.ShowDialog())
                editor.EditValue = frm.Value_Id;

            //FormFeatureList formFeatureList = new(Convert.ToInt32(editor.Name));
            //if (DialogResult.OK == formFeatureList.ShowDialog())
            //    editor.EditValue = formFeatureList.dcFeature.FeatureCode;

            //ButtonEdit textEdit = sender as ButtonEdit;
            //efMethods.UpdateDcFeature_Value(Convert.ToInt32(textEdit.Name), dcProduct.ProductCode, textEdit.EditValue.ToString());
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in layoutControl1.Controls)
            {
                BaseEdit edit = ctrl as BaseEdit;
                if (edit is ButtonEdit)
                    if (edit is not null)
                        if (edit.EditValue is not null)
                        {
                            efMethods.UpdateDcFeature_Value(Convert.ToByte(edit.Name), dcProduct.ProductCode, edit.EditValue.ToString());
                            DialogResult = DialogResult.OK;
                        }
            }
        }
    }
}