﻿using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class FormCurrAccRole : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        EfMethods efMethods = new();
        public FormCurrAccRole()
        {
            InitializeComponent();

            col_CurrAccDesc.Caption = ReflectionExt.GetDisplayName<DcCurrAcc>(x => x.FirstName);
            col_RoleDesc.Caption = ReflectionExt.GetDisplayName<DcRole>(x => x.RoleDesc);

            LoadCurrAccRole(null);
        }

        private void LoadCurrAccRole(string hierarchyCode)
        {
            List<TrCurrAccRole> currAccRoles = efMethods.SelectCurrAccRole(hierarchyCode);
            gridControl1.DataSource = currAccRoles;

            gV_CurrAccRole.BestFitColumns();
        }

        private void btnEdit_CurrAccCode_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit buttonEdit = (ButtonEdit)sender;

            using (FormCurrAccList form = new(new byte[] { 3 }, buttonEdit.EditValue?.ToString()))
                if (form.ShowDialog(this) == DialogResult.OK)
                    buttonEdit.EditValue = form.dcCurrAcc.CurrAccCode;
        }

        private void btnEdit_CurrAccCode_EditValueChanged(object sender, EventArgs e)
        {
            ButtonEdit buttonEdit = (ButtonEdit)sender;
            string currAccCode = buttonEdit.EditValue?.ToString();
            LoadCurrAccRole(currAccCode);
        }

        private void gV_CurrAccRole_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "DcCurrAcc.FirstName" && e.IsGetData)
            {
                GridView view = sender as GridView;
                int rowInd = view.GetRowHandle(e.ListSourceRowIndex);
                string currAccCode = view.GetRowCellValue(rowInd, colCurrAccCode) as string ?? string.Empty;
                DcCurrAcc dcCurrAcc = efMethods.SelectCurrAcc(currAccCode);
                e.Value = dcCurrAcc?.CurrAccDesc;
            }

            if (e.Column.FieldName == "DcRole.RoleDesc" && e.IsGetData)
            {
                GridView view = sender as GridView;
                int rowInd = view.GetRowHandle(e.ListSourceRowIndex);
                string roleCode = view.GetRowCellValue(rowInd, colRoleCode) as string ?? string.Empty;
                DcRole dcRole = efMethods.SelectRole(roleCode);
                e.Value = dcRole?.RoleDesc;
            }
        }

        private void BBI_Add_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormCommon<TrCurrAccRole> common = new("", true, "CurrAccRoleId", "", "CurrAccCode", btnEdit_CurrAccCode.EditValue?.ToString());
            if (DialogResult.OK == common.ShowDialog())
                LoadCurrAccRole(btnEdit_CurrAccCode.EditValue?.ToString());
        }

        private void BBI_Delete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Silmək istədiyinizə əminmisiniz?", "Diqqət", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string currAccCode = gV_CurrAccRole.GetFocusedRowCellValue(colCurrAccCode).ToString();
                string roleCode = gV_CurrAccRole.GetFocusedRowCellValue(colRoleCode).ToString();

                efMethods.DeleteCurrAccRole(currAccCode, roleCode);

                LoadCurrAccRole(btnEdit_CurrAccCode.EditValue?.ToString());
            }
        }
    }
}