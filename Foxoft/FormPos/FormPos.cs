using DevExpress.XtraBars;
using DevExpress.XtraBars.ToolbarForm;
using DevExpress.XtraEditors;
using Foxoft.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormPOS : ToolbarForm
    {
        private readonly EfMethods efMethods = new();
        private UcExpense ucExpense;
        private UcRetailSale ucSale;
        private UcReturn ucReturn;

        public FormPOS()
        {
            InitializeComponent();

            ucSale = new();
            ucSale.Dock = DockStyle.Fill;
            navPage_Sale.Controls.Add(ucSale);

            ucReturn = new("RS");
            ucReturn.Dock = DockStyle.Fill;
            navPage_Return.Controls.Add(ucReturn);

            ucReturn.InvoiceOpenRequested += async (s, docNum) =>
            {
                await OpenReturnInvoiceInSaleAsync(docNum);
            };

            ucSale.InvoiceReturnStateChanged += (s, isReturn) =>
            {
                bCI_invoice.Caption = isReturn
                    ? $"{Resources.Form_POS_Button_Sale} ({Resources.Entity_InvoiceHeader_IsReturn})"
                    : Resources.Form_POS_Button_Sale;
            };

            ucExpense = new();
            ucExpense.Dock = DockStyle.Fill;
            navPage_Expenses.Controls.Add(ucExpense);

            AcceptButton = ucSale.btn_Enter;
        }

        public async Task OpenReturnInvoiceInSaleAsync(string docNum)
        {
            navigationFrame1.SelectedPage = navPage_Sale;
            bCI_invoice.Checked = true;
            bCI_return.Checked = false;
            bCI_expenses.Checked = false;

            await ucSale.OpenInvoiceByDocNumAsync(docNum);

            AcceptButton = ucSale.btn_Enter;
        }

        private void FormPOS_Load(object sender, EventArgs e)
        {
            ApplyPermissions();
        }

        private void ApplyPermissions()
        {
            bool hasExpenseClaim = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "Expense")
                                || efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "DailyExpense");
            bCI_expenses.Visibility = hasExpenseClaim ? BarItemVisibility.Always : BarItemVisibility.Never;
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
            if (!efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "Expense")
                && !efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "DailyExpense"))
            {
                XtraMessageBox.Show(Resources.Common_NoPermission);
                return;
            }

            ucExpense?.EnsureTodayDailyExpense();

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
