using DevExpress.XtraBars;
using DevExpress.XtraBars.ToolbarForm;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormPOS : ToolbarForm
    {
        public FormPOS()
        {
            InitializeComponent();

            UcSale ucSale = new UcSale();
            ucSale.Dock = DockStyle.Fill;
            navPage_Sale.Controls.Add(ucSale);

            UcReturn ucReturn = new UcReturn();
            ucReturn.Dock = DockStyle.Fill;
            navPage_Return.Controls.Add(ucReturn);

            UcExpense ucExpense = new UcExpense();
            ucExpense.Dock = DockStyle.Fill;
            navPage_Expenses.Controls.Add(ucExpense);

            AcceptButton = ucSale.btn_Enter;
        }

        private void FormPOS_Load(object sender, EventArgs e)
        {

        }

        private void bCI_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            BarCheckItem clickedBarItem = e.Item as BarCheckItem;
            if (clickedBarItem.Checked)
            {
                clickedBarItem.ItemAppearance.Normal.Font = new Font("Tahoma", 10F, FontStyle.Regular);
                clickedBarItem.ItemAppearance.Normal.ForeColor = Color.FromArgb(0, 0, 192);
                clickedBarItem.ItemAppearance.Normal.Options.UseFont = true;
                clickedBarItem.ItemAppearance.Normal.Options.UseForeColor = true;
            }
            else
            {
                clickedBarItem.ItemAppearance.Normal.Options.UseFont = false;
                clickedBarItem.ItemAppearance.Normal.Options.UseForeColor = false;
            }
        }

        private void bCI_return_ItemClick(object sender, ItemClickEventArgs e)
        {
            navigationFrame1.SelectedPage = navPage_Return;
            BarCheckItem clickedBtn = e.Item as BarCheckItem;
            foreach (BarItem control in toolbarFormManager1.Items)
            {
                BarCheckItem btn = control as BarCheckItem;
                if (btn == clickedBtn)
                    clickedBtn.Checked = true; // secilen true olsun 
                else
                    btn.Checked = false; // qalanlari false olsun 
            }
        }

        private void bCI_invoice_ItemClick(object sender, ItemClickEventArgs e)
        {
            navigationFrame1.SelectedPage = navPage_Sale;
            BarCheckItem clickedBtn = e.Item as BarCheckItem;
            foreach (BarItem control in toolbarFormManager1.Items)
            {
                BarCheckItem btn = control as BarCheckItem;
                if (btn == clickedBtn)
                    clickedBtn.Checked = true;
                else
                    btn.Checked = false;
            }
        }

        private void bCI_expenses_ItemClick(object sender, ItemClickEventArgs e)
        {
            navigationFrame1.SelectedPage = navPage_Expenses;
            BarCheckItem clickedBtn = e.Item as BarCheckItem;
            foreach (BarItem control in toolbarFormManager1.Items)
            {
                BarCheckItem btn = control as BarCheckItem;
                if (btn == clickedBtn)
                    clickedBtn.Checked = true;
                else
                    btn.Checked = false;
            }
        }
    }
}