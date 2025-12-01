using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList.Nodes;
using Foxoft.Models;
using Foxoft.Properties; // Resources
using System.Data;

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
            LoadClaimReport();
        }

        private void LoadClaimReport()
        {
            string claimCode = btnEdit_ClaimReport.Text;

            List<DcClaimReportViewModel> data = efMethods.SelectClaimReport(claimCode);
            treeList1.DataSource = data;

            treeList1.BestFitColumns();
        }

        private void LoadCurrAccRole(string currAccCode)
        {
            List<TrCurrAccRole> currAccRoles = efMethods.SelectCurrAccRole(currAccCode);
            gridControl1.DataSource = currAccRoles;

            gV_CurrAccRole.BestFitColumns();
        }

        private void btnEdit_CurrAccCode_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit buttonEdit = (ButtonEdit)sender;

            using (FormCurrAccList form = new(new byte[] { 3 }, false, buttonEdit.EditValue?.ToString()))
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
            // reserved for future
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
            if (XtraMessageBox.Show(Resources.Common_DeleteConfirm, Resources.Common_Attention, MessageBoxButtons.YesNo) == DialogResult.Yes)
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

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txtEdit_NewPassword.EditValue?.ToString() != txtEdit_ConfirmPassword.EditValue?.ToString())
            {
                dxErrorProvider1.SetError(txtEdit_ConfirmPassword, Resources.Common_Validation_PasswordConfirmMismatch);
                return;
            }
            else
                dxErrorProvider1.SetError(txtEdit_ConfirmPassword, ""); // Clears the error

            string currAccCode = btnEdit_CurrAccCode.EditValue?.ToString();

            DcCurrAcc dcCurrAcc = efMethods.SelectCurrAcc(currAccCode);

            if (dcCurrAcc is not null && txtEdit_NewPassword.EditValue is not null)
                efMethods.UpdateCurrAccPassword(dcCurrAcc.CurrAccCode, txtEdit_NewPassword.EditValue?.ToString());
        }

        private void Btn_ClaimCategoryList_Click(object sender, EventArgs e)
        {
            if (btnEdit_RoleCode.EditValue is not null)
            {
                FormClaimCategoryList formClaimCategoryList = new(btnEdit_RoleCode.EditValue?.ToString());
                formClaimCategoryList.Show();
            }
        }

        private void btnEdit_ClaimReport_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit buttonEdit = (ButtonEdit)sender;

            using (FormCommonList<DcClaim> form = new("", nameof(DcClaim.ClaimCode), buttonEdit.EditValue?.ToString(), nameof(DcClaim.ClaimTypeId), 2))
                if (form.ShowDialog(this) == DialogResult.OK)
                    buttonEdit.EditValue = form.Value_Id;
        }

        private void treeList1_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "IsSelected")
            {
                bool isChecked = Convert.ToBoolean(e.Value);
                TreeListNode node = e.Node;

                SetChildNodesChecked(node, isChecked);
                SetParentNodesChecked(node);
            }
        }

        private void SetChildNodesChecked(TreeListNode parentNode, bool isChecked)
        {
            foreach (TreeListNode child in parentNode.Nodes)
            {
                child.SetValue("IsSelected", isChecked);
                SetChildNodesChecked(child, isChecked);
            }
        }

        private void SetParentNodesChecked(TreeListNode childNode)
        {
            TreeListNode parent = childNode.ParentNode;
            while (parent != null)
            {
                bool allChecked = parent.Nodes.Cast<TreeListNode>().All(n => Convert.ToBoolean(n.GetValue("IsSelected")));
                parent.SetValue("IsSelected", allChecked);
                parent = parent.ParentNode;
            }
        }
        private void btnEdit_ClaimReport_EditValueChanged(object sender, EventArgs e)
        {
            LoadClaimReport();
        }

        private void btn_ClaimReportSave_Click(object sender, EventArgs e)
        {
            SaveNodesToDb(treeList1.Nodes);
        }

        private void SaveNodesToDb(IEnumerable<TreeListNode> nodes)
        {
            string claimCode = btnEdit_ClaimReport.Text;

            foreach (TreeListNode child in nodes)
            {
                DcReport report = efMethods.SelectEntityById<DcReport>(Convert.ToInt32(child.GetValue("ReportId")));
                bool chckd = (bool)child.GetValue("IsSelected");

                if (chckd)
                {
                    if (!efMethods.TrClaimReportExist(report.ReportId, claimCode))
                    {
                        efMethods.InsertEntity(new TrClaimReport()
                        {
                            ClaimCode = claimCode,
                            ReportId = report.ReportId
                        });
                    }
                }
                else
                {
                    TrClaimReport claimReport = efMethods.SelectClaimReport(report.ReportId, claimCode);

                    if (claimReport != null)
                        efMethods.DeleteEntity(claimReport);
                }
            }
        }
    }
}
