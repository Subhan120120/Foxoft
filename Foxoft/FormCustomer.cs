using DevExpress.XtraEditors;
using Foxoft.Models;
using System;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormCustomer : XtraForm
    {
        EfMethods efMethods = new EfMethods();
        public DcCurrAcc DcCurrAcc { get; set; }


        public FormCustomer(DcCurrAcc DcCurrAcc)
        {
            this.DcCurrAcc = DcCurrAcc;
            InitializeComponent();
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(DcCurrAcc.CurrAccCode))
            {
                txtEdit_CurrAccCode.EditValue = DcCurrAcc.CurrAccCode;
                txtEdit_FirstName.EditValue = DcCurrAcc.FirstName;
                memoEdit_Address.EditValue = DcCurrAcc.Address;
                dateEdit_BirthDate.EditValue = DcCurrAcc.BirthDate;
                txtEdit_BonusCard.EditValue = DcCurrAcc.BonusCardNum;
                txtEdit_PhoneNum.EditValue = DcCurrAcc.PhoneNum;
            }
            else
                txtEdit_CurrAccCode.EditValue = efMethods.GetNextDocNum(true, "C", "CurrAccCode", "DcCurrAccs", 4);
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            DcCurrAcc = efMethods.SelectCurrAcc(txtEdit_CurrAccCode.Text);
            if (DcCurrAcc == null)                                      // if Customer doesnt exist in db
                DcCurrAcc = new DcCurrAcc();

            DcCurrAcc.CurrAccCode = txtEdit_CurrAccCode.Text;
            DcCurrAcc.CurrAccTypeCode = 2;
            DcCurrAcc.Address = memoEdit_Address.Text;
            DcCurrAcc.BonusCardNum = txtEdit_BonusCard.Text;
            DcCurrAcc.FirstName = txtEdit_FirstName.Text;
            DcCurrAcc.LastName = txtEdit_LastName.Text;
            DcCurrAcc.BirthDate = Convert.ToDateTime(dateEdit_BirthDate.EditValue ?? new DateTime(1901, 01, 01));
            DcCurrAcc.PhoneNum = txtEdit_PhoneNum.Text;

            if (efMethods.EntityExists<DcCurrAcc>(txtEdit_CurrAccCode.Text))
                efMethods.UpdateEntity(DcCurrAcc);
            else
                efMethods.InsertEntity(DcCurrAcc);

            DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}