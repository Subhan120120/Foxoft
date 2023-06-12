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
    public partial class FormFeatureList : RibbonForm
    {
        EfMethods efMethods = new();
        public DcFeatureType dcFeature { get; set; }

        public FormFeatureList()
        {
            InitializeComponent();
            bBI_quit.ItemShortcut = new BarShortcut(Keys.Escape);

            byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
            MemoryStream stream = new(byteArray);
            OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
            gV_FeatureList.RestoreLayoutFromStream(stream, option);

            UpdateGridViewData();
        }

        private void gV_FeatureList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle >= 0)
                dcFeature = view.GetFocusedRow() as DcFeatureType;
            else
                dcFeature = null;
        }

        private void gV_FeatureList_DoubleClick(object sender, EventArgs e)
        {
            #region comment
            //DXMouseEventArgs ea = e as DXMouseEventArgs;
            //GridView view = sender as GridView;
            //GridHitInfo info = view.CalcHitInfo(ea.Location);
            //if (info.InRow || info.InRowCell)
            //{
            //    //info.RowHandle
            //    string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
            //    dcCurrAcc = new DcCurrAcc();
            //    string CurrAccCode = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["CurrAccCode"]).ToString();
            //    dcCurrAcc = efMethods.SelectCurrAcc(CurrAccCode);

            //    DialogResult = DialogResult.OK;
            //} 
            #endregion

            GridView view = sender as GridView;
            if (dcFeature is not null)
                DialogResult = DialogResult.OK;
        }

        private void bBI_FeatureNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            dcFeature = new DcFeatureType();
            FormCurrAcc form = new();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                UpdateGridViewData();
            }
        }

        private void bBI_FeatureEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ApplySelectedCurrAcc();

            //if (dcFeature is not null)
            //{
            //    FormCurrAcc form = new(dcFeature.FeatureCode);
            //    if (form.ShowDialog(this) == DialogResult.OK)
            //    {
            //        UpdateGridViewData();
            //    }
            //}
        }

        private void UpdateGridViewData()
        {
            int fr = gV_FeatureList.FocusedRowHandle;

            LoadFeatures();

            if (fr > 0)
                gV_FeatureList.FocusedRowHandle = fr;
            else
                gV_FeatureList.MoveLast();

            if (gV_FeatureList.FocusedRowHandle >= 0)
                dcFeature = gV_FeatureList.GetFocusedRow() as DcFeatureType;
            else
                dcFeature = null;
        }

        private void LoadFeatures()
        {
            dcFeaturesBindingSource.DataSource = efMethods.SelectFeatures();
        }

        private void bBI_refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            UpdateGridViewData();
        }

        private void gC_FeatureList_ProcessGridKey(object sender, KeyEventArgs e)
        {
            ColumnView view = (sender as GridControl).FocusedView as ColumnView;
            if (view == null) return;

            if (dcFeature is not null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DialogResult = DialogResult.OK;
                }

                if (e.KeyCode == Keys.C && e.Control)
                {
                    //if (view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn) != null && view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString() != String.Empty)
                    //   Clipboard.SetText(view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString());
                    //else
                    //   MessageBox.Show("The value in the selected cell is null or empty!");

                    string cellValue = gV_FeatureList.GetFocusedValue().ToString();
                    Clipboard.SetText(cellValue);
                    e.Handled = true;
                }

            }
        }

        // AutoFocus FindPanel
        bool isFirstPaint = true;
        private void gC_FeatureList_Paint(object sender, PaintEventArgs e)
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

        private void bBI_quit_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gV_FeatureList_ColumnFilterChanged(object sender, EventArgs e)
        {
            GridView view = sender as GridView;


            if (view.FocusedRowHandle >= 0)
                dcFeature = view.GetFocusedRow() as DcFeatureType;
            else
                dcFeature = null;
        }

        private void bBI_Report1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bBI_ExportXlsx_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraSaveFileDialog sFD = new();
            sFD.Filter = "Excel Faylı|*.xlsx";
            sFD.Title = "Excel Faylı Yadda Saxla";
            sFD.FileName = $@"\CariHesablar.xlsx";
            sFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            sFD.DefaultExt = "*.xlsx";

            var fileName = Invoke((Func<string>)(() =>
            {
                if (sFD.ShowDialog() == DialogResult.OK)
                {
                    gC_FeatureList.ExportToXlsx(sFD.FileName);

                    if (XtraMessageBox.Show(this, "Açmaq istəyirsiz?", "Diqqət", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Process p = new Process();
                        p.StartInfo = new ProcessStartInfo(sFD.FileName) { UseShellExecute = true };
                        p.Start();
                    }

                    return "Ok";
                }
                else
                    return "Fail";
            }));
        }

        private void bBI_FeatureDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (efMethods.FeatureExist(dcFeature.Id))
            {
                if (XtraMessageBox.Show("Silmek Isteyirsiz? \n " + dcFeature.FeatureName, "Diqqet", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    efMethods.DeleteFeature(dcFeature);

                    LoadFeatures();
                }
            }
            else
                XtraMessageBox.Show("Silinmeli olan faktura yoxdur");
        }

        private void bBI_FeatureRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            UpdateGridViewData();
        }
    }
}