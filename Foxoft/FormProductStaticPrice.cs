using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using Foxoft.Models;
using Foxoft.Properties;   // <-- added
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormProductStaticPrice : XtraForm
    {
        EfMethods efMethods = new();
        DcProduct dcProduct = new();

        public FormProductStaticPrice()
        {
            InitializeComponent();
        }

        public FormProductStaticPrice(string productCode)
           : this()
        {
            dcProduct = efMethods.SelectProduct(productCode, new byte[] { 1 });
        }

        private void FormProductStaticPrice_Load(object sender, EventArgs e)
        {
            // Load all price types
            var priceTypes = efMethods.SelectEntities<DcPriceType>();

            foreach (DcPriceType priceType in priceTypes)
            {
                // Load existing static price
                DcProductStaticPrice proPrice =
                     efMethods.SelectEntityById<DcProductStaticPrice>(
                         dcProduct.ProductCode,
                         priceType.PriceTypeCode);

                // Create textbox dynamically
                TextEdit txt = new();
                txt.Name = priceType.PriceTypeCode;
                txt.StyleController = this.layoutControl1;

                if (proPrice is not null)
                    txt.EditValue = proPrice.Price;

                // Layout item
                LayoutControlItem lCI = new();
                lCI.Control = txt;
                lCI.Text = priceType.PriceTypeDesc;

                Root.Items.AddRange(new BaseLayoutItem[] { lCI });
            }
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in layoutControl1.Controls)
            {
                if (ctrl is TextEdit txt && txt.EditValue != null)
                {
                    decimal? result = string.IsNullOrWhiteSpace(txt.EditValue.ToString())
                                    ? null
                                    : Convert.ToDecimal(txt.EditValue);

                    efMethods.UpdateDcProductStaticPrice_Value(
                        txt.Name,            // PriceTypeCode
                        dcProduct.ProductCode,
                        result
                    );
                }
            }

            DialogResult = DialogResult.OK;
        }

        private void FormProductStaticPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
