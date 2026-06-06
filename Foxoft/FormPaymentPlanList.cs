using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Foxoft.Properties;
using System.IO;
using System.Text;

namespace Foxoft
{
    public partial class FormPaymentPlanList : RibbonForm
    {
        EfMethods efMethods = new();
        subContext dbContext;
        public DcPaymentPlan dcPaymentPlan { get; set; }

        public FormPaymentPlanList()
        {
            InitializeComponent();

            byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
            MemoryStream stream = new(byteArray);
            OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
            gV_PaymentPlanList.RestoreLayoutFromStream(stream, option);

            UpdateGridViewData();
        }

        private void UpdateGridViewData()
        {
            int fr = gV_PaymentPlanList.FocusedRowHandle;

            LoadData();

            if (fr > 0)
                gV_PaymentPlanList.FocusedRowHandle = fr;
            else
                gV_PaymentPlanList.MoveLast();

            if (gV_PaymentPlanList.FocusedRowHandle >= 0)
                dcPaymentPlan = gV_PaymentPlanList.GetFocusedRow() as DcPaymentPlan;
            else
                dcPaymentPlan = null;
        }

        private void LoadData()
        {
            dbContext = new subContext();
            dcPaymentPlansBindingSource.DataSource = dbContext.DcPaymentPlans.ToList();
        }

        private void gV_PaymentPlanList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedRowHandle >= 0)
                dcPaymentPlan = view.GetFocusedRow() as DcPaymentPlan;
            else
                dcPaymentPlan = null;
        }

        private void gV_PaymentPlanList_DoubleClick(object sender, EventArgs e)
        {
            if (dcPaymentPlan is not null)
                DialogResult = DialogResult.OK;
        }

        private void bBI_New_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormPaymentPlan form = new();
            if (form.ShowDialog(this) == DialogResult.OK)
                UpdateGridViewData();
        }

        private void bBI_Edit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dcPaymentPlan is not null)
            {
                FormPaymentPlan form = new(dcPaymentPlan.PaymentPlanCode);
                if (form.ShowDialog(this) == DialogResult.OK)
                    UpdateGridViewData();
            }
        }

        private void bBI_Delete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dcPaymentPlan is null)
                return;

            if (efMethods.EntityExists<DcPaymentPlan>(dcPaymentPlan.PaymentPlanCode))
            {
                if (XtraMessageBox.Show(
                    string.Format(Resources.Message_DeleteConfirm, dcPaymentPlan.PaymentPlanDesc),
                    Resources.Common_Attention,
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    efMethods.DeleteEntity(dcPaymentPlan);
                    UpdateGridViewData();
                }
            }
            else
            {
                XtraMessageBox.Show(
                    Resources.Form_PaymentPlanList_NoItemToDelete,
                    Resources.Common_Attention);
            }
        }

        private void bBI_Refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            UpdateGridViewData();
        }

        private void bBI_ExportXlsx_ItemClick(object sender, ItemClickEventArgs e)
        {
            CustomExtensions.ExportToExcel(this, Text, gC_PaymentPlanList);
        }

        private void gC_PaymentPlanList_ProcessGridKey(object sender, KeyEventArgs e)
        {
            ColumnView view = (sender as GridControl).FocusedView as ColumnView;
            if (view == null) return;

            if (dcPaymentPlan is not null)
            {
                if (e.KeyCode == Keys.Enter)
                    DialogResult = DialogResult.OK;

                if (e.KeyCode == Keys.C && e.Control)
                {
                    string cellValue = gV_PaymentPlanList.GetFocusedValue()?.ToString();
                    if (!string.IsNullOrEmpty(cellValue))
                    {
                        Clipboard.SetText(cellValue);
                        e.Handled = true;
                    }
                }
            }
        }

        bool isFirstPaint = true;
        private void gC_PaymentPlanList_Paint(object sender, PaintEventArgs e)
        {
            GridControl gC = sender as GridControl;
            GridView gV = gC.MainView as GridView;

            if (isFirstPaint)
            {
                if (!gV.FindPanelVisible)
                    gV.ShowFindPanel();
                gV.ShowFindPanel();
                gV.OptionsFind.FindNullPrompt = Resources.Common_Search;
            }
            isFirstPaint = false;
        }

        private void gV_PaymentPlanList_ColumnFilterChanged(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedRowHandle >= 0)
                dcPaymentPlan = view.GetFocusedRow() as DcPaymentPlan;
            else
                dcPaymentPlan = null;
        }

        private void FormPaymentPlanList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
