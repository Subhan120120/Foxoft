using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormStore : XtraForm
    {
        subContext dbContext;
        EfMethods efMethods = new();
        public DcCurrAcc dcCurrAcc = new();

        public FormStore()
        {
            InitializeComponent();

            CurrAccTypeCodeLookUpEdit.Properties.DataSource = efMethods.SelectEntities<DcCurrAccType>();
            OfficeCodeLookUpEdit.Properties.DataSource = efMethods.SelectOffices();
            DefaultUnitOfMeasureIdLookUpEdit.Properties.DataSource = efMethods.SelectUnitOfMeasures();

            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;
        }

        public FormStore(string currAccCode)
            : this()
        {
            dcCurrAcc.CurrAccCode = currAccCode;
        }

        public FormStore(byte currAccTypeCode)
            : this()
        {
            dcCurrAcc.CurrAccTypeCode = currAccTypeCode;
        }

        private void FormFormStore_Load(object sender, EventArgs e)
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
                //dbContext.DcCurrAccs.Where(x => x.CurrAccCode == dcCurrAcc.CurrAccCode)
                //                    .LoadAsync()
                //                    .ContinueWith(loadTask => dcCurrAccsBindingSource.DataSource = dbContext.DcCurrAccs.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());

                dbContext.DcCurrAccs.Where(x => x.CurrAccCode == dcCurrAcc.CurrAccCode)
                                    .Include(x => x.SettingStore)
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
            string NewDocNum = efMethods.GetNextDocNum(true, "C", nameof(DcCurrAcc.CurrAccCode), "DcCurrAccs", 4);
            dcCurrAcc.CurrAccCode = NewDocNum;

            dcCurrAccsBindingSource.DataSource = dcCurrAcc;
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

                if (!efMethods.CurrAccExist(dcCurrAcc.CurrAccCode)) //if invoiceHeader doesnt exist
                    efMethods.InsertEntity(dcCurrAcc);
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

        private void PhoneNumTextEdit_Validating(object sender, CancelEventArgs e)
        {
            var te = (DevExpress.XtraEditors.TextEdit)sender;
            var before = te.Text;
            var after = PhoneNumberFormat.FormatIntlPhone(before);
            te.Text = after;


            string inputPhone = Regex.Replace(PhoneNumTextEdit.Text, @"\D", ""); // \D = non-digit characters

            if (!string.IsNullOrEmpty(inputPhone))
            {
                if (efMethods.CurrAccExistByPhoneNum(inputPhone))
                    dxErrorProvider1.SetError(PhoneNumTextEdit, "Bu nömrə bazada mövcuddur.", ErrorType.Warning);
                else
                    dxErrorProvider1.ClearErrors();
            }

        }
    }
}
