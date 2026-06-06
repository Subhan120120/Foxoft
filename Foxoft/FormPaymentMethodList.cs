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
    public partial class FormPaymentMethodList : RibbonForm
    {
        EfMethods efMethods = new();
        subContext dbContext;
        public DcPaymentMethod dcPaymentMethod { get; set; }

        public FormPaymentMethodList()
        {
            InitializeComponent();

            byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
            MemoryStream stream = new(byteArray);
            OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
            gV_PaymentMethodList.RestoreLayoutFromStream(stream, option);

            UpdateGridViewData();
        }

        private void UpdateGridViewData()
        {
            int fr = gV_PaymentMethodList.FocusedRowHandle;

            LoadData();

            if (fr > 0)
                gV_PaymentMethodList.FocusedRowHandle = fr;
            else
                gV_PaymentMethodList.MoveLast();

            if (gV_PaymentMethodList.FocusedRowHandle >= 0)
                dcPaymentMethod = gV_PaymentMethodList.GetFocusedRow() as DcPaymentMethod;
            else
                dcPaymentMethod = null;
        }

        private void LoadData()
        {
            dbContext = new subContext();
            dcPaymentMethodsBindingSource.DataSource = dbContext.DcPaymentMethods.ToList();
        }

        private void gV_PaymentMethodList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedRowHandle >= 0)
                dcPaymentMethod = view.GetFocusedRow() as DcPaymentMethod;
            else
                dcPaymentMethod = null;
        }

        private void gV_PaymentMethodList_DoubleClick(object sender, EventArgs e)
        {
            if (dcPaymentMethod is not null)
                DialogResult = DialogResult.OK;
        }

        private void bBI_New_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormPaymentMethod form = new();
            if (form.ShowDialog(this) == DialogResult.OK)
                UpdateGridViewData();
        }

        private void bBI_Edit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dcPaymentMethod is not null)
            {
                FormPaymentMethod form = new(dcPaymentMethod.PaymentMethodId);
                if (form.ShowDialog(this) == DialogResult.OK)
                    UpdateGridViewData();
            }
        }

        private void bBI_Delete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dcPaymentMethod is null)
                return;

            if (efMethods.EntityExists<DcPaymentMethod>(dcPaymentMethod.PaymentMethodId))
            {
                if (XtraMessageBox.Show(
                    string.Format(Resources.Message_DeleteConfirm, dcPaymentMethod.PaymentMethodDesc),
                    Resources.Common_Attention,
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    efMethods.DeleteEntity(dcPaymentMethod);
                    UpdateGridViewData();
                }
            }
            else
            {
                XtraMessageBox.Show(
                    Resources.Form_PaymentMethodList_NoItemToDelete,
                    Resources.Common_Attention);
            }
        }

        private void bBI_Refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            UpdateGridViewData();
        }

        private void bBI_ExportXlsx_ItemClick(object sender, ItemClickEventArgs e)
        {
            CustomExtensions.ExportToExcel(this, Text, gC_PaymentMethodList);
        }

        private void gC_PaymentMethodList_ProcessGridKey(object sender, KeyEventArgs e)
        {
            ColumnView view = (sender as GridControl).FocusedView as ColumnView;
            if (view == null) return;

            if (dcPaymentMethod is not null)
            {
                if (e.KeyCode == Keys.Enter)
                    DialogResult = DialogResult.OK;

                if (e.KeyCode == Keys.C && e.Control)
                {
                    string cellValue = gV_PaymentMethodList.GetFocusedValue()?.ToString();
                    if (!string.IsNullOrEmpty(cellValue))
                    {
                        Clipboard.SetText(cellValue);
                        e.Handled = true;
                    }
                }
            }
        }

        bool isFirstPaint = true;
        private void gC_PaymentMethodList_Paint(object sender, PaintEventArgs e)
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

        private void gV_PaymentMethodList_ColumnFilterChanged(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedRowHandle >= 0)
                dcPaymentMethod = view.GetFocusedRow() as DcPaymentMethod;
            else
                dcPaymentMethod = null;
        }

        private void FormPaymentMethodList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
