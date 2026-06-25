using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraLayout.Utils;
using Foxoft.Models;
using Foxoft.Properties;
using Google.Apis.PeopleService.v1.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;

namespace Foxoft
{
    public partial class FormCurrAcc : XtraForm
    {
        subContext dbContext;
        EfMethods efMethods = new();
        bool isCustomer;
        public DcCurrAcc dcCurrAcc = new();
        private const string ChangeCurrAccCodeClaim = "ChangeCurrAccCode";

        public FormCurrAcc()
        {
            InitializeComponent();

            CurrAccTypeCodeLookUpEdit.Properties.DataSource = efMethods.SelectEntities<DcCurrAccType>();
            OfficeCodeLookUpEdit.Properties.DataSource = efMethods.SelectOffices();
            StoreCodeLookUpEdit.Properties.DataSource = efMethods.SelectStores();
            PersonalTypeCodeLookUpEdit.Properties.DataSource = efMethods.SelectEntities<DcPersonalType>();

            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;

            bool currAccHasClaimCreditLimit = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "CurrAccCreditLimit");
            if (!currAccHasClaimCreditLimit)
                ItemForCreditLimit.Visibility = LayoutVisibility.Never;
        }

        public FormCurrAcc(string currAccCode)
            : this()
        {
            dcCurrAcc.CurrAccCode = currAccCode;
            CurrAccCodeTextEdit.Properties.ReadOnly = true;
            CurrAccCodeTextEdit.Properties.Appearance.BackColor = Color.LightGray;
            CurrAccCodeTextEdit.Properties.Buttons[0].Enabled = CanChangeCurrAccCode();
        }

        public FormCurrAcc(string currAccCode, bool isCustomer)
            : this(currAccCode)
        {
            this.isCustomer = isCustomer;
        }

        public FormCurrAcc(CurrAccType currAccTypeCode)
            : this()
        {
            dcCurrAcc.CurrAccTypeCode = currAccTypeCode;
        }

        public FormCurrAcc(CurrAccType currAccTypeCode, bool isCustomer)
            : this(currAccTypeCode)
        {
            this.isCustomer = isCustomer;
        }

        private void FormCurrAcc_Load(object sender, EventArgs e)
        {
            LoadCurrAcc();
            LoadLayout();
            dataLayoutControl1.IsValid(out List<string> errorList);
            CurrAccTypeCodeLookUpEdit_EditValueChanged(CurrAccTypeCodeLookUpEdit, EventArgs.Empty);
        }

        private void LoadCurrAcc()
        {
            dbContext = new subContext();

            if (string.IsNullOrEmpty(dcCurrAcc.CurrAccCode))
                ClearControlsAddNew();
            else
            {
                dbContext.DcCurrAccs.Where(x => x.CurrAccCode == dcCurrAcc.CurrAccCode).Load();
                dcCurrAccsBindingSource.DataSource = dbContext.DcCurrAccs.Local.ToBindingList();
            }
        }

        private void LoadLayout()
        {
            string fileName = "FormCurrAcc.xml";
            if (isCustomer)
                fileName = "FormCustomer.xml";

            string layoutFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Foxoft", Settings.Default.CompanyCode, "Layout Xml Files", fileName);

            if (File.Exists(layoutFilePath))
                dataLayoutControl1.RestoreLayoutFromXml(layoutFilePath);
        }

        private void ClearControlsAddNew()
        {
            CurrAccType temp = dcCurrAcc.CurrAccTypeCode;
            dcCurrAcc = dcCurrAccsBindingSource.AddNew() as DcCurrAcc;
            dcCurrAcc.CurrAccTypeCode = temp;

            dcCurrAcc.StoreCode = Authorization.StoreCode;
            dcCurrAcc.OfficeCode = Authorization.OfficeCode;
            string NewDocNum = efMethods.GetNextDocNum(true, "C", "CurrAccCode", "DcCurrAccs", 4);
            dcCurrAcc.CurrAccCode = NewDocNum;
            dcCurrAcc.LanguageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            dcCurrAcc.PhoneNum = "+994";

            dcCurrAccsBindingSource.DataSource = dcCurrAcc;
            CurrAccDescTextEdit.Select();
        }

        private void dataLayoutControl1_FieldRetrieving(object sender, FieldRetrievingEventArgs e)
        {
            if (e.FieldName == "ModifiedDate")
            {
                e.Visible = false;
                e.Handled = true;
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (dataLayoutControl1.IsValid(dxErrorProvider1, out List<string> errorList))
            {
                dcCurrAcc = dcCurrAccsBindingSource.Current as DcCurrAcc;

                if (!efMethods.EntityExists<DcCurrAcc>(dcCurrAcc.CurrAccCode))
                    efMethods.InsertEntity(dcCurrAcc);
                else
                    dbContext.SaveChanges();

                DialogResult = DialogResult.OK;
            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }
        }

        private bool CanChangeCurrAccCode()
        {
            return efMethods.CurrAccHasClaims(Authorization.CurrAccCode, ChangeCurrAccCodeClaim);
        }

        private void CurrAccCodeTextEdit_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (!CanChangeCurrAccCode())
            {
                XtraMessageBox.Show(Resources.Common_NoPermission, Resources.Common_Attention);
                return;
            }

            if (dcCurrAccsBindingSource.Current is not DcCurrAcc currAcc)
                return;

            string oldCurrAccCode = currAcc.CurrAccCode;
            string? newCurrAccCode = XtraInputBox.Show(
                Resources.Form_CurrAcc_Input_NewCurrAccCode,
                Resources.Form_CurrAcc_Button_ChangeCurrAccCode,
                oldCurrAccCode)?.Trim();

            if (string.IsNullOrWhiteSpace(newCurrAccCode))
                return;

            if (string.Equals(oldCurrAccCode, newCurrAccCode, StringComparison.Ordinal))
                return;

            if (efMethods.EntityExists<DcCurrAcc>(newCurrAccCode))
            {
                XtraMessageBox.Show(Resources.Form_CurrAcc_Message_CurrAccCodeExists, Resources.Common_Attention);
                return;
            }

            DialogResult dialogResult = XtraMessageBox.Show(
                string.Format(Resources.Form_CurrAcc_Message_ChangeCurrAccCodeConfirm, oldCurrAccCode, newCurrAccCode),
                Resources.Common_Attention,
                MessageBoxButtons.YesNo);

            if (dialogResult != DialogResult.Yes)
                return;

            try
            {
                ChangeCurrAccCode(oldCurrAccCode, newCurrAccCode);

                dcCurrAcc = new DcCurrAcc { CurrAccCode = newCurrAccCode };
                LoadCurrAcc();
                dcCurrAcc = dcCurrAccsBindingSource.Current as DcCurrAcc ?? dcCurrAcc;

                XtraMessageBox.Show(Resources.Form_CurrAcc_Message_CurrAccCodeChanged, Resources.Common_Info);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    string.Format(Resources.Form_CurrAcc_Message_CurrAccCodeChangeError, ex.Message),
                    Resources.Common_ErrorTitle);
            }
        }

        public void ChangeCurrAccCode(string oldDocNum, string newDocNum)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(oldDocNum);
            ArgumentException.ThrowIfNullOrWhiteSpace(newDocNum);

            oldDocNum = oldDocNum.Trim();
            newDocNum = newDocNum.Trim();

            if (string.Equals(oldDocNum, newDocNum, StringComparison.Ordinal))
                return;

            using subContext context = new();
            using var transaction = context.Database.BeginTransaction();

            SqlParameter oldDocNumParam = new("@OldDocNum", oldDocNum);
            SqlParameter newDocNumParam = new("@NewDocNum", newDocNum);
            SqlParameter currAccCodeParam = new("@CurrAccCode", (object?)Authorization.CurrAccCode ?? DBNull.Value);

            context.Database.ExecuteSqlRaw(
                """
                SET XACT_ABORT ON;

                ALTER TABLE DcPaymentMethods NOCHECK CONSTRAINT ALL;
                ALTER TABLE TrCurrAccRoles NOCHECK CONSTRAINT ALL;
                ALTER TABLE TrInvoiceHeaders NOCHECK CONSTRAINT ALL;
                ALTER TABLE TrInvoiceLines NOCHECK CONSTRAINT ALL;
                ALTER TABLE TrPaymentHeaders NOCHECK CONSTRAINT ALL;
                ALTER TABLE TrSessions NOCHECK CONSTRAINT ALL;

                UPDATE DcCurrAccs
                SET CurrAccCode = @NewDocNum,
                    LastUpdatedUserName = @CurrAccCode,
                    LastUpdatedDate = GETDATE()
                WHERE CurrAccCode = @OldDocNum;

                UPDATE DcPaymentMethods SET RedirectedCurrAccCode = @NewDocNum WHERE RedirectedCurrAccCode = @OldDocNum;
                UPDATE TrCurrAccRoles SET CurrAccCode = @NewDocNum WHERE CurrAccCode = @OldDocNum;
                UPDATE TrInvoiceHeaders SET CurrAccCode = @NewDocNum WHERE CurrAccCode = @OldDocNum;
                UPDATE TrInvoiceLines SET SalesPersonCode = @NewDocNum WHERE SalesPersonCode = @OldDocNum;
                UPDATE TrPaymentHeaders SET CurrAccCode = @NewDocNum WHERE CurrAccCode = @OldDocNum;
                UPDATE TrSessions SET CurrAccCode = @NewDocNum WHERE CurrAccCode = @OldDocNum;

                ALTER TABLE DcPaymentMethods WITH CHECK CHECK CONSTRAINT ALL;
                ALTER TABLE TrCurrAccRoles WITH CHECK CHECK CONSTRAINT ALL;
                ALTER TABLE TrInvoiceHeaders WITH CHECK CHECK CONSTRAINT ALL;
                ALTER TABLE TrInvoiceLines WITH CHECK CHECK CONSTRAINT ALL;
                ALTER TABLE TrPaymentHeaders WITH CHECK CHECK CONSTRAINT ALL;
                ALTER TABLE TrSessions WITH CHECK CHECK CONSTRAINT ALL;
                """,
                oldDocNumParam,
                newDocNumParam,
                currAccCodeParam);

            transaction.Commit();
        }

        private void BBI_CurrAccFeatures_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormCurrAccFeature frm = new(dcCurrAcc.CurrAccCode);
            frm.ShowDialog();
        }

        private void BBI_ContactDetail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormCurrAccContactDetailList frm = new(dcCurrAcc.CurrAccCode);
            frm.ShowDialog();
        }

        private void PhoneNumTextEdit_Validating(object sender, CancelEventArgs e)
        {
            var te = (TextEdit)sender;
            var before = te.Text;
            var after = PhoneNumberFormat.FormatIntlPhone(before);
            te.Text = after;

            if (!string.IsNullOrEmpty(te.Text))
            {
                if (efMethods.CurrAccExistByPhoneNumExceptCurrAcc(te.Text, dcCurrAcc.CurrAccCode))
                    dxErrorProvider1.SetError(PhoneNumTextEdit, Resources.Validation_Phone_ExistsInAnotherCurrAcc, ErrorType.Information);
                else
                    dxErrorProvider1.ClearErrors();
            }
        }

        private void PhoneNumTextEdit_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void CurrAccTypeCodeLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            // treat null/empty as "not 3"
            var isType3 = false;

            var val = CurrAccTypeCodeLookUpEdit.EditValue;
            if (val != null && val != DBNull.Value)
            {
                // DevExpress LookUpEdit value is often string/int; handle both safely
                if (val is int i) isType3 = (i == 3);
                else if (int.TryParse(val.ToString(), out var parsed)) isType3 = (parsed == 3);
            }

            PersonalTypeCodeLookUpEdit.Enabled = isType3;

            // optional: clear value when disabled
            if (!isType3)
                PersonalTypeCodeLookUpEdit.EditValue = null;
        }

        private void BBI_HumanResources_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
