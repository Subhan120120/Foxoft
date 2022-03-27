using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormProduct : XtraForm
    {
        subContext dbContext = new subContext();
        EfMethods efMethods = new EfMethods();
        public DcProduct dcProduct = new DcProduct();

        public FormProduct()
        {
            InitializeComponent();

            ProductTypeCodeLookUpEdit.Properties.DataSource = efMethods.SelectProductTypes();
            ProductTypeCodeLookUpEdit.Properties.ValueMember = "ProductTypeCode";
            ProductTypeCodeLookUpEdit.Properties.DisplayMember = "ProductTypeDesc";

            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;
        }

        public FormProduct(string productCode)
            : this()
        {
            this.dcProduct.ProductCode = productCode;
        }

        private void FormProduct_Load(object sender, System.EventArgs e)
        {
            FillDataLayout();
            dataLayoutControl1.isValid(out List<string> errorList);
        }

        private void FillDataLayout()
        {
            dbContext = new subContext();

            if (string.IsNullOrEmpty(dcProduct.ProductCode))
                ClearControlsAddNew();
            else
            {
                //dbContext.DcCurrAccs.Where(x => x.CurrAccCode == dcCurrAcc.CurrAccCode)
                //                    .LoadAsync()
                //                    .ContinueWith(loadTask => dcCurrAccsBindingSource.DataSource = dbContext.DcCurrAccs.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());

                dbContext.DcProducts.Where(x => x.ProductCode == dcProduct.ProductCode)
                                    .Include(x => x.DcProductType)
                                    .Load();
                dcProductsBindingSource.DataSource = dbContext.DcProducts.Local.ToBindingList();
            }
        }

        private void ClearControlsAddNew()
        {
            dcProduct = dcProductsBindingSource.AddNew() as DcProduct;

            string NewDocNum = efMethods.GetNextDocNum("PR", "ProductCode", "DcProducts");
            dcProduct.ProductCode = NewDocNum;

            dcProductsBindingSource.DataSource = dcProduct;
        }

        private void dcCurrAccsBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            //dcCurrAcc = new DcCurrAcc();
            //dcCurrAcc.CurrAccCode = efMethods.GetNextDocNum("CA", "CurrAccCode", "DcCurrAccs");
            //dcCurrAcc.DataLanguageCode = "AZ";
            //e.NewObject = dcCurrAcc;
        }

        private void dataLayoutControl1_FieldRetrieving(object sender, FieldRetrievingEventArgs e)
        {
            if (e.FieldName == "ModifiedDate")
            {
                e.Visible = false;
                e.Handled = true;
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (dataLayoutControl1.isValid(out List<string> errorList))
            {
                dcProduct = dcProductsBindingSource.Current as DcProduct;
                if (!efMethods.ProductExist(dcProduct.ProductCode)) //if invoiceHeader doesnt exist
                    efMethods.InsertProduct(dcProduct);
                else
                    dbContext.SaveChanges();
                DialogResult = DialogResult.OK;
            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }
        }
    }
}