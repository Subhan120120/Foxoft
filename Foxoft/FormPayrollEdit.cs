using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.ViewInfo;
using Foxoft.AppCode;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormPayrollEdit : XtraForm
    {
        public FormPayrollEdit(Guid? payrollHeaderId)
        {
            InitializeComponent(); 
            
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;
        }

        private void FormPayrollEdit_Load(object sender, EventArgs e)
        {

        }

        private void BtnEditPeriod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FormCommonList<DcPayrollPeriod> formCommonList = new("", nameof(DcPayrollPeriod.Id), PayrollPeriodIdButtonEdit.EditValue?.ToString());
            if (formCommonList.ShowDialog() == DialogResult.OK)
            {
                PayrollPeriodIdButtonEdit.EditValue = formCommonList.Value_Id;
            }
        }

        private void btnEditEmployee_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FormCurrAccList formCommonList = new(new byte[] { 3 }, false, CurrAccCodeButtonEdit.EditValue?.ToString());
            if (formCommonList.ShowDialog() == DialogResult.OK)
            {
                CurrAccCodeButtonEdit.EditValue = formCommonList.dcCurrAcc.CurrAccCode;
            }
        }

    }
}
