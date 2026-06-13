using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;

namespace Foxoft
{
    public partial class FormCurrAccContactDetail : XtraForm
    {
        subContext dbContext;
        EfMethods efMethods = new();
        private DcCurrAccContactDetail dcContactDetail;
        private string currAccCode;
        private bool isNew;
        private const byte PhoneContactTypeId = 1;

        public FormCurrAccContactDetail(string currAccCode)
        {
            InitializeComponent();

            this.currAccCode = currAccCode;
            this.isNew = true;

            Text = Resources.Form_CurrAccContactDetail_Caption_New;

            ContactTypeLookUpEdit.Properties.DataSource = efMethods.SelectEntities<DcContactType>();

            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;
        }

        public FormCurrAccContactDetail(string currAccCode, int id)
            : this(currAccCode)
        {
            this.isNew = false;
            Text = Resources.Form_CurrAccContactDetail_Caption_Edit;
        }

        private void FormCurrAccContactDetail_Load(object sender, EventArgs e)
        {
            LoadContactDetail();
        }

        private void LoadContactDetail()
        {
            dbContext = new subContext();

            if (isNew)
            {
                dcContactDetail = new DcCurrAccContactDetail();
                dcContactDetail.CurrAccCode = currAccCode;
                bindingSource1.DataSource = dcContactDetail;
                ContactTypeLookUpEdit.Select();
            }
            else
            {
                dbContext.DcCurrAccContactDetails
                    .Where(x => x.CurrAccCode == currAccCode)
                    .Include(x => x.DcContactType)
                    .Load();

                bindingSource1.DataSource = dbContext.DcCurrAccContactDetails.Local.ToBindingList();
            }

            ApplyContactTypeSettings();
        }

        private void ContactTypeLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            ApplyContactTypeSettings();
        }

        private void ApplyContactTypeSettings()
        {
            byte contactTypeId = 0;
            if (ContactTypeLookUpEdit.EditValue != null && ContactTypeLookUpEdit.EditValue != DBNull.Value)
                byte.TryParse(ContactTypeLookUpEdit.EditValue.ToString(), out contactTypeId);

            bool isPhone = contactTypeId == PhoneContactTypeId;

            // SendWhatsapp visibility
            ItemForSendWhatsapp.Visibility = isPhone ? LayoutVisibility.Always : LayoutVisibility.Never;

            if (isPhone)
            {
                // Phone mask
                ContactDescTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
                ContactDescTextEdit.Properties.Mask.EditMask = "+000 00 000-00-00";
                ContactDescTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;

                // Default value for new records
                if (isNew && string.IsNullOrWhiteSpace(ContactDescTextEdit.Text))
                    ContactDescTextEdit.EditValue = "+994";
            }
            else
            {
                // Remove phone mask
                ContactDescTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
                ContactDescTextEdit.Properties.Mask.EditMask = "";
                ContactDescTextEdit.Properties.Mask.UseMaskAsDisplayFormat = false;

                // Clear SendWhatsapp if not phone
                SendWhatsappCheckEdit.Checked = false;
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            dcContactDetail = bindingSource1.Current as DcCurrAccContactDetail;

            if (dcContactDetail == null)
                return;

            if (string.IsNullOrWhiteSpace(dcContactDetail.ContactDesc))
            {
                XtraMessageBox.Show(
                    string.Format(Resources.Validation_Required, Resources.Entity_CurrAccContactDetail_Desc),
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (dcContactDetail.ContactTypeId == 0)
            {
                XtraMessageBox.Show(
                    string.Format(Resources.Validation_Required, Resources.Entity_ContactType),
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (isNew)
                efMethods.InsertEntity(dcContactDetail);
            else
                dbContext.SaveChanges();

            DialogResult = DialogResult.OK;
        }

        private void FormCurrAccContactDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
