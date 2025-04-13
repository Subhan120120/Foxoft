using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;

namespace Foxoft
{
    public partial class FormCurrAcc : XtraForm
    {
        subContext dbContext;
        EfMethods efMethods = new();
        public DcCurrAcc dcCurrAcc = new();

        public FormCurrAcc()
        {
            InitializeComponent();

            CurrAccTypeCodeLookUpEdit.Properties.DataSource = efMethods.SelectEntities<DcCurrAccType>();
            OfficeCodeLookUpEdit.Properties.DataSource = efMethods.SelectOffices();
            StoreCodeLookUpEdit.Properties.DataSource = efMethods.SelectStores();
            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;

            bool currAccHasClaimCreditLimit = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "CurrAccCreditLimit");
            if (!currAccHasClaimCreditLimit)
                ItemForCreditLimit.Visibility = LayoutVisibility.Never;
        }

        public FormCurrAcc(string currAccCode)
            : this()
        {
            dcCurrAcc.CurrAccCode = currAccCode;

            CurrAccCodeTextEdit.Properties.ReadOnly = true;
            CurrAccCodeTextEdit.Properties.Appearance.BackColor = Color.LightGray;
        }

        public FormCurrAcc(byte currAccTypeCode)
            : this()
        {
            dcCurrAcc.CurrAccTypeCode = currAccTypeCode;
        }

        private void FormCurrAcc_Load(object sender, EventArgs e)
        {
            LoadCurrAcc();

            dataLayoutControl1.IsValid(out List<string> errorList);
        }

        private void LoadCurrAcc()
        {
            dbContext = new subContext();

            if (string.IsNullOrEmpty(dcCurrAcc.CurrAccCode))
                ClearControlsAddNew();
            else
            {
                dbContext.DcCurrAccs.Where(x => x.CurrAccCode == dcCurrAcc.CurrAccCode)
                    .Load();
                dcCurrAccsBindingSource.DataSource = dbContext.DcCurrAccs.Local.ToBindingList();
            }
        }

        private void ClearControlsAddNew()
        {
            byte temp = dcCurrAcc.CurrAccTypeCode;
            dcCurrAcc = dcCurrAccsBindingSource.AddNew() as DcCurrAcc;
            dcCurrAcc.CurrAccTypeCode = temp;

            dcCurrAcc.StoreCode = Authorization.StoreCode;
            dcCurrAcc.OfficeCode = Authorization.OfficeCode;
            string NewDocNum = efMethods.GetNextDocNum(true, "C", "CurrAccCode", "DcCurrAccs", 4);
            dcCurrAcc.CurrAccCode = NewDocNum;
            dcCurrAcc.DataLanguageCode = "AZ";

            dcCurrAccsBindingSource.DataSource = dcCurrAcc;
            CurrAccDescTextEdit.Select();
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
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                dcCurrAcc = dcCurrAccsBindingSource.Current as DcCurrAcc;

                if (!efMethods.CurrAccExist(dcCurrAcc.CurrAccCode)) //if doesnt exist
                    efMethods.InsertEntity<DcCurrAcc>(dcCurrAcc);
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

        private void BBI_CurrAccFeatures_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormCurrAccFeature frm = new(dcCurrAcc.CurrAccCode);
            frm.ShowDialog();
        }

        private void BBI_ContactDetail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var exist = efMethods.CurrAccContactDetailsExistByCurrAcc(dcCurrAcc.CurrAccCode);

            //if (!exist)
            //{
            //    DcCurrAccContactDetail dcCurrAccContactDetail = new DcCurrAccContactDetail()
            //    {
            //        Id = 1,
            //        CurrAccCode = dcCurrAcc.CurrAccCode,
            //        ContactDesc = "",
            //        ContactTypeId = 1,
            //    };

            //    efMethods.InsertEntity<DcCurrAccContactDetail>(dcCurrAccContactDetail);
            //}

            FormCommonList<DcCurrAccContactDetail> formCommonList = new FormCommonList<DcCurrAccContactDetail>("", nameof(DcCurrAccContactDetail.Id), null, nameof(dcCurrAcc.CurrAccCode), dcCurrAcc.CurrAccCode);
            formCommonList.ShowDialog();
        }
    }
}
