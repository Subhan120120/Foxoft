using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using Foxoft.Models;
using Microsoft.IdentityModel.Tokens;

namespace Foxoft
{
    public partial class FormProductStaticPrice : XtraForm
    {
        EfMethods efMethods = new();
        DcProduct dcProduct = new();

        public FormProductStaticPrice()
        {
            InitializeComponent();
            //AcceptButton = simpleButtonOk;
        }

        public FormProductStaticPrice(string productCode)
           : this()
        {
            dcProduct = efMethods.SelectProduct(productCode, new byte[] { 1 });
        }

        private void FormProductStaticPrice_Load(object sender, EventArgs e)
        {
            List<DcPriceType> priceTypes = efMethods.SelectEntities<DcPriceType>();

            foreach (DcPriceType priceType in priceTypes)
            {
                DcProductStaticPrice proPrice = efMethods.SelectEntityById<DcProductStaticPrice>(dcProduct.ProductCode, priceType.PriceTypeCode);

                TextEdit btn = new();
                btn.Name = priceType.PriceTypeCode.ToString();
                btn.StyleController = this.layoutControl1;
                if (proPrice is not null)
                    btn.EditValue = proPrice.Price;

                LayoutControlItem lCI = new();
                lCI.Control = btn;
                lCI.Name = priceType.PriceTypeDesc;

                Root.Items.AddRange(new BaseLayoutItem[] { lCI });
            }
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in layoutControl1.Controls)
            {
                BaseEdit edit = ctrl as BaseEdit;

                if (edit is TextEdit && edit is not null && edit.EditValue is not null)
                {
                    decimal? result = string.IsNullOrEmpty(edit.EditValue.ToString()) ? null : Convert.ToDecimal(edit.EditValue);

                    efMethods.UpdateDcProductStaticPrice_Value(edit.Name, dcProduct.ProductCode, result);
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void FormProductStaticPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}