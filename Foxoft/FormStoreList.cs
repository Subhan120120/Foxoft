using DevExpress.Data.Filtering;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormStoreList : RibbonForm
    {
        EfMethods efMethods = new();
        public DcCurrAcc dcStore { get; set; }

        public FormStoreList()
        {
            InitializeComponent();

            byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
            MemoryStream stream = new(byteArray);
            OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
            gV_StoreList.RestoreLayoutFromStream(stream, option);

            UpdateGridViewData();
        }

        private void UpdateGridViewData()
        {
            int fr = gV_StoreList.FocusedRowHandle;

            LoadStores();

            if (fr > 0)
                gV_StoreList.FocusedRowHandle = fr;
            else
                gV_StoreList.MoveLast();

            if (gV_StoreList.FocusedRowHandle >= 0)
                dcStore = gV_StoreList.GetFocusedRow() as DcCurrAcc;
            else
                dcStore = null;
        }

        private void LoadStores()
        {
            dcStoresBindingSource.DataSource = efMethods.SelectStoresIncludeDisabled();
        }

        private void gV_StoreList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle >= 0)
                dcStore = view.GetFocusedRow() as DcCurrAcc;
            else
                dcStore = null;
        }

        private void gV_StoreList_DoubleClick(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (dcStore is not null)
                DialogResult = DialogResult.OK;
        }

        private void GC_StoreList_ProcessGridKey(object sender, KeyEventArgs e)
        {
            ColumnView view = (sender as GridControl).FocusedView as ColumnView;
            if (view == null) return;

            if (dcStore is not null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DialogResult = DialogResult.OK;
                }

                if (e.KeyCode == Keys.C && e.Control)
                {
                    string cellValue = gV_StoreList.GetFocusedValue().ToString();
                    Clipboard.SetText(cellValue);
                    e.Handled = true;
                }
            }
        }

        // AutoFocus FindPanel
        bool isFirstPaint = true;
        private void gC_StoreList_Paint(object sender, PaintEventArgs e)
        {
            GridControl gC = sender as GridControl;
            GridView gV = gC.MainView as GridView;

            if (isFirstPaint)
            {
                if (!gV.FindPanelVisible)
                    gV.ShowFindPanel();
                gV.ShowFindPanel();

                gV.OptionsFind.FindFilterColumns = "CurrAccDesc";
                gV.OptionsFind.FindNullPrompt = "Axtarın...";
            }
            isFirstPaint = false;
        }

        private void gV_StoreList_ColumnFilterChanged(object sender, EventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle >= 0)
                dcStore = view.GetFocusedRow() as DcCurrAcc;
            else
                dcStore = null;
        }

        private void bBI_ExportXlsx_ItemClick(object sender, ItemClickEventArgs e)
        {
            CustomExtensions.ExportToExcel(this, Text, gC_StoreList);
        }

        private void FormStoreList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void BBI_New_ItemClick(object sender, ItemClickEventArgs e)
        {
            dcStore = new DcCurrAcc();
            FormCurrAcc form = new();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                UpdateGridViewData();
            }
        }

        private void BBI_Edit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dcStore is not null)
            {
                FormCurrAcc form = new(dcStore.StoreCode);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    UpdateGridViewData();
                }
            }
        }

        private void BBI_Delete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (efMethods.CurrAccExist(dcStore.StoreCode))
            {
                if (XtraMessageBox.Show("Silmek Isteyirsiz? \n " + dcStore.CurrAccDesc, "Diqqet", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    efMethods.DeleteEntity(dcStore);
                    LoadStores();
                }
            }
            else
                XtraMessageBox.Show("Silinmeli olan faktura yoxdur");
        }

        private void BBI_Refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            UpdateGridViewData();
        }
    }
}
