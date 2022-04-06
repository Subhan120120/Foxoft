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
    public partial class FormCurrAcc : XtraForm
    {
        subContext dbContext;
        EfMethods efMethods = new EfMethods();
        public DcCurrAcc dcCurrAcc = new DcCurrAcc();

        public FormCurrAcc()
        {
            InitializeComponent();
            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;
        }

        public FormCurrAcc(string currAccCode)
            : this()
        {
            dcCurrAcc.CurrAccCode = currAccCode;
        }

        private void FormCurrAcc_Load(object sender, EventArgs e)
        {
            FillDataLayout();
            dataLayoutControl1.isValid(out List<string> errorList);
        }

        private void FillDataLayout()
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
                    .Load();
                dcCurrAccsBindingSource.DataSource = dbContext.DcCurrAccs.Local.ToBindingList();
            }
        }

        private void ClearControlsAddNew()
        {
            dcCurrAcc = dcCurrAccsBindingSource.AddNew() as DcCurrAcc;

            string NewDocNum = efMethods.GetNextDocNum("CA", "CurrAccCode", "DcCurrAccs");
            dcCurrAcc.CurrAccCode = NewDocNum;
            dcCurrAcc.DataLanguageCode = "AZ";

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
            dcCurrAcc = dcCurrAccsBindingSource.Current as DcCurrAcc;
            if (!efMethods.CurrAccExist(dcCurrAcc.CurrAccCode)) //if invoiceHeader doesnt exist
                efMethods.InsertCurrAcc(dcCurrAcc);
            else
                dbContext.SaveChanges();
            DialogResult = DialogResult.OK;
        }
    }
}
