using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
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
    public partial class FormCurrAccProfile : RibbonForm
    {
        EfMethods efMethods = new();
        public FormCurrAccProfile()
        {
            InitializeComponent();

            col_CurrAccDesc.Caption = ReflectionExt.GetDisplayName<DcCurrAcc>(x => x.FirstName);
            col_RoleDesc.Caption = ReflectionExt.GetDisplayName<DcRole>(x => x.RoleDesc);

            LoadCurrAccRole(null);
            LoadRoleClaim(null);
        }

        private void LoadCurrAccRole(string currAccCode)
        {
            List<TrCurrAccRole> currAccRoles = efMethods.SelectCurrAccRole(currAccCode);
            gridControl1.DataSource = currAccRoles;

            gV_CurrAccRole.BestFitColumns();
        }

        private void LoadRoleClaim(string roleCode)
        {
            List<TrRoleClaim> roleClaims = efMethods.SelectRoleClaim(roleCode);
            gridControl2.DataSource = roleClaims;

            gv_RoleClaim.BestFitColumns();
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

        private void btnEdit_RoleCode_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit buttonEdit = (ButtonEdit)sender;

            using (FormCommonList<DcRole> form = new("", nameof(DcRole.RoleCode), buttonEdit.EditValue?.ToString()))
                if (form.ShowDialog(this) == DialogResult.OK)
                    buttonEdit.EditValue = form.Value_Id;
        }

        private void btnEdit_RoleCode_EditValueChanged(object sender, EventArgs e)
        {
            ButtonEdit buttonEdit = (ButtonEdit)sender;
            string roleCode = buttonEdit.EditValue?.ToString();
            LoadRoleClaim(roleCode);
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
                DcRole dcRole = efMethods.SelectEntityById<DcRole>(roleCode);
                e.Value = dcRole?.RoleDesc;
            }
        }

        private void BBI_Add_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormCommon<TrCurrAccRole> common = new("", true, nameof(TrCurrAccRole.CurrAccRoleId), "", nameof(DcCurrAcc.CurrAccCode), btnEdit_CurrAccCode.EditValue?.ToString());
            if (DialogResult.OK == common.ShowDialog())
                LoadCurrAccRole(btnEdit_CurrAccCode.EditValue?.ToString());
        }

        private void BBI_EditCurrAccRole_ItemClick(object sender, ItemClickEventArgs e)
        {
            string currAccRoleId = gV_CurrAccRole.GetFocusedRowCellValue(colCurrAccRoleId)?.ToString();

            FormCommon<TrCurrAccRole> common = new("", false, nameof(TrCurrAccRole.CurrAccRoleId), currAccRoleId);
            if (DialogResult.OK == common.ShowDialog())
                LoadCurrAccRole(btnEdit_CurrAccCode.EditValue?.ToString());
        }

        private void BBI_Delete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Silmək istədiyinizə əminmisiniz?", "Diqqət", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int currAccRolId = Convert.ToInt32(gV_CurrAccRole.GetFocusedRowCellValue(colCurrAccRoleId));

                efMethods.DeleteEntityById<TrCurrAccRole>(currAccRolId);

                LoadCurrAccRole(btnEdit_CurrAccCode.EditValue?.ToString());
            }
        }

        private void gV_CurrAccRole_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            string role = gV_CurrAccRole.GetFocusedRowCellValue(colRoleCode)?.ToString();
            btnEdit_RoleCode.EditValue = role;
        }

        private void BBI_AddRoleClaim_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormCommon<TrRoleClaim> common = new("", true, nameof(TrRoleClaim.RoleClaimId), "", nameof(DcRole.RoleCode), btnEdit_RoleCode.EditValue?.ToString());
            if (DialogResult.OK == common.ShowDialog())
                LoadRoleClaim(btnEdit_RoleCode.EditValue?.ToString());
        }

        private void BBI_DeleteRoleClaim_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Silmək istədiyinizə əminmisiniz?", "Diqqət", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int roleClaimId = Convert.ToInt32(gv_RoleClaim.GetFocusedRowCellValue(colRoleClaimId));

                efMethods.DeleteEntityById<TrRoleClaim>(roleClaimId);

                LoadRoleClaim(btnEdit_CurrAccCode.EditValue?.ToString());
            }
        }

        private void BBI_EditRoleClaim_ItemClick(object sender, ItemClickEventArgs e)
        {
            string roleClaimId = gv_RoleClaim.GetFocusedRowCellValue(colRoleClaimId)?.ToString();

            FormCommon<TrRoleClaim> common = new("", false, nameof(TrRoleClaim.RoleClaimId), roleClaimId);
            if (DialogResult.OK == common.ShowDialog())
                LoadRoleClaim(btnEdit_RoleCode.EditValue?.ToString());
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txtEdit_NewPassword.EditValue?.ToString() != txtEdit_ConfirmPassword.EditValue.ToString())
            {
                dxErrorProvider1.SetError(txtEdit_ConfirmPassword, "Təsdiq şifrəsi eyni deyil!");
                return;
            }
            else
                dxErrorProvider1.SetError(txtEdit_ConfirmPassword, ""); // Clears the error

            string currAccCode = btnEdit_CurrAccCode.EditValue?.ToString();

            DcCurrAcc dcCurrAcc = efMethods.SelectCurrAcc(currAccCode);

            if (dcCurrAcc is not null && txtEdit_NewPassword.EditValue is not null)
                efMethods.UpdateCurrAccPassword(dcCurrAcc.CurrAccCode, txtEdit_NewPassword.EditValue?.ToString());
        }
    }
}