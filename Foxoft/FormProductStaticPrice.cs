﻿using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using Foxoft.Models;

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
            dcProduct = efMethods.SelectProduct(productCode);
        }

        private void FormProductStaticPrice_Load(object sender, EventArgs e)
        {
            List<DcPriceType> priceTypes = efMethods.SelectPriceTypes();

            foreach (DcPriceType priceType in priceTypes)
            {
                DcProductStaticPrice proPrice = efMethods.SelectStaticPrices(dcProduct.ProductCode, priceType.PriceTypeCode);

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
                    efMethods.UpdateDcProductStaticPrice_Value(edit.Name, dcProduct.ProductCode, Convert.ToDecimal(edit.EditValue));
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}