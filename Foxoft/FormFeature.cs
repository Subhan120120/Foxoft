using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormFeature : XtraForm
    {
        EfMethods efMethods = new();
        string productCode;

        public FormFeature()
        {
            InitializeComponent();
            //AcceptButton = simpleButtonOk;
        }

        public FormFeature(string productCode)
           : this()
        {
            this.productCode = productCode;
        }

        private void FormFeatureTest_Load(object sender, EventArgs e)
        {
            List<DcFeature> dcFeatures = efMethods.SelectFeatures();

            foreach (DcFeature feature in dcFeatures)
            {
                DcProductDcFeature proFea = efMethods.SelectFeature(feature.Id, productCode);

                ButtonEdit btn = new();
                btn.Name = feature.Id.ToString();
                btn.StyleController = this.layoutControl1;
                if (proFea is not null)
                    btn.EditValue = proFea.FeatureDesc;
                btn.ButtonPressed += new(this.btnEdit_DocNum_ButtonPressed);

                LayoutControlItem lCI = new();
                lCI.Control = btn;
                lCI.Name = feature.FeatureName;

                Root.Items.AddRange(new BaseLayoutItem[] { lCI });
            }
        }

        private void btnEdit_DocNum_ButtonPressed(object sender, EventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            FormFeatureList formFeatureList = new();
            if (DialogResult.OK == formFeatureList.ShowDialog())
            {
                editor.EditValue = formFeatureList.dcFeature.FeatureName;
            }
            //ButtonEdit textEdit = sender as ButtonEdit;
            //efMethods.UpdateDcFeature_Value(Convert.ToInt32(textEdit.Name), productCode, textEdit.EditValue.ToString());
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
                            efMethods.UpdateDcFeature_Value(Convert.ToInt32(edit.Name), productCode, edit.EditValue.ToString());
                            DialogResult = DialogResult.OK;
                        }
            }
        }
    }
}