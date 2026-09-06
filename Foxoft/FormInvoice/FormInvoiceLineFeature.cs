using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormInvoiceLineFeature : XtraForm
    {
        EfMethods efMethods = new();
        Guid _invoiceLineId;

        public FormInvoiceLineFeature()
        {
            InitializeComponent();
        }

        public FormInvoiceLineFeature(Guid invoiceLineId)
           : this()
        {
            _invoiceLineId = invoiceLineId;
        }

        private void FormInvoiceLineFeature_Load(object sender, EventArgs e)
        {
            List<DcInvoiceLineFeatureType> dcFeatures = efMethods.SelectEntities<DcInvoiceLineFeatureType>();

            foreach (DcInvoiceLineFeatureType feature in dcFeatures)
            {
                TrInvoiceLineFeature invoiceLineFea = efMethods.SelectInvoiceLineFeature(_invoiceLineId, feature.InvoiceLineFeatureTypeId);

                ButtonEdit btn = new();
                btn.Name = feature.InvoiceLineFeatureTypeId.ToString();
                btn.StyleController = this.layoutControl1;
                if (invoiceLineFea is not null)
                    btn.EditValue = invoiceLineFea.InvoiceLineFeatureCode;
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

            FormCommonList<DcInvoiceLineFeature> frm = new("F", nameof(DcInvoiceLineFeature.InvoiceLineFeatureCode), editor.EditValue, nameof(DcInvoiceLineFeature.InvoiceLineFeatureTypeId), Convert.ToInt32(editor.Name));
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
                    efMethods.UpdateDcFeatureInvoiceLine_Value(Convert.ToInt32(edit.Name), _invoiceLineId, edit.EditValue.ToString().Trim());
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void FormInvoiceLineFeature_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
