using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormHierarchyFeatureType : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        EfMethods efMethods = new();

        public FormHierarchyFeatureType()
        {
            InitializeComponent();

            // Form caption (ribbon form başlığı)
            this.Text = Resources.Form_HierarchyFeatureType_Caption;

            // Sütun başlıqları Display attributelə gəlir
            colHierarchyDesc.Caption = ReflectionExt.GetDisplayName<DcHierarchy>(x => x.HierarchyDesc);
            colHierarchyCode.Caption = ReflectionExt.GetDisplayName<TrHierarchyFeatureType>(x => x.HierarchyCode);

            LoadHierarchyFeatureType(null);
        }

        private void btn_Hierarchy_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit buttonEdit = (ButtonEdit)sender;

            using (FormHierarchyList form = new())
                if (form.ShowDialog(this) == DialogResult.OK)
                    buttonEdit.EditValue = form.DcHierarchy?.HierarchyCode;
        }

        private void btn_Hierarchy_EditValueChanged(object sender, EventArgs e)
        {
            ButtonEdit buttonEdit = (ButtonEdit)sender;
            string hierarchyCode = buttonEdit.EditValue?.ToString();
            LoadHierarchyFeatureType(hierarchyCode);
        }

        private void LoadHierarchyFeatureType(string hierarchyCode)
        {
            List<TrHierarchyFeatureType> featureType = efMethods.SelectHierarchyFeatureTypes(hierarchyCode);
            myGridControl1.DataSource = featureType;

            gridView1.BestFitColumns();
        }

        private void BBI_FeatureTypeAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormCommon<TrHierarchyFeatureType> common =
                new("", true, nameof(TrHierarchyFeatureType.FeatureTypeId), "", nameof(TrHierarchyFeatureType.HierarchyCode), btn_Hierarchy.EditValue?.ToString());

            if (DialogResult.OK == common.ShowDialog())
                LoadHierarchyFeatureType(btn_Hierarchy.EditValue?.ToString());
        }

        private void gV_PriceListLine_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == $"{nameof(DcFeatureType)}.{nameof(DcFeatureType.FeatureTypeName)}" && e.IsGetData)
            {
                GridView view = sender as GridView;
                int rowInd = view.GetRowHandle(e.ListSourceRowIndex);
                int featureTypeId = Convert.ToInt32(view.GetRowCellValue(rowInd, colFeatureTypeId));

                DcFeatureType dcfeaturetype = efMethods.SelectEntityById<DcFeatureType>(featureTypeId);
                e.Value = dcfeaturetype?.FeatureTypeName;
            }

            if (e.Column.FieldName == $"{nameof(DcHierarchy)}.{nameof(DcHierarchy.HierarchyDesc)}" && e.IsGetData)
            {
                GridView view = sender as GridView;
                int rowInd = view.GetRowHandle(e.ListSourceRowIndex);
                string hierarchy = view.GetRowCellValue(rowInd, colHierarchyCode) as string ?? string.Empty;

                DcHierarchy dcHierarchy = efMethods.SelectEntityById<DcHierarchy>(hierarchy);
                e.Value = dcHierarchy?.HierarchyDesc;
            }
        }


        private void BBI_Update_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadHierarchyFeatureType(btn_Hierarchy.EditValue?.ToString());
        }

        private void BBI_Delete_ItemClick(object sender, ItemClickEventArgs e)
        {
            string hierarchyCode = gridView1.GetFocusedRowCellValue(colHierarchyCode).ToString();
            int featureTypeId = Convert.ToInt32(gridView1.GetFocusedRowCellValue(colFeatureTypeId));

            efMethods.DeleteEntityById<TrHierarchyFeatureType>(hierarchyCode, featureTypeId);
            LoadHierarchyFeatureType(btn_Hierarchy.EditValue?.ToString());
        }
    }
}
