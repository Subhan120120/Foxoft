using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout.Utils;
using Foxoft.AppCode;
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

            // WhatsApp Group JID visibility
            ItemForWhatsAppGroupJid.Visibility = isPhone ? LayoutVisibility.Always : LayoutVisibility.Never;

            if (isPhone)
            {
                // Phone mask
                ContactDescTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
                ContactDescTextEdit.Properties.Mask.EditMask = "+000 00 000-00-00";
                ContactDescTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;

                // Default value for new records
                if (isNew && string.IsNullOrWhiteSpace(dcContactDetail.ContactDesc))
                {
                    dcContactDetail.ContactDesc = "+994";
                    ContactDescTextEdit.DataBindings["EditValue"]?.ReadValue();
                }
            }
            else
            {
                // Remove phone mask
                ContactDescTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
                ContactDescTextEdit.Properties.Mask.EditMask = "";
                ContactDescTextEdit.Properties.Mask.UseMaskAsDisplayFormat = false;

                // Clear SendWhatsapp if not phone
                SendWhatsappCheckEdit.Checked = false;

                // Clear WhatsApp Group JID if not phone
                WhatsAppGroupJidTextEdit.EditValue = null;
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

        private async void WhatsAppGroupJidTextEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var apiSetting = efMethods.SelectEntityById<DcWhatsAppProviderSetting>(1);
            if (apiSetting == null || string.IsNullOrEmpty(apiSetting.ServerUrl)
                                   || string.IsNullOrEmpty(apiSetting.InstanceName)
                                   || string.IsNullOrEmpty(apiSetting.ApiKey))
            {
                XtraMessageBox.Show(Resources.Payment_ApiSettingsIncomplete);
                return;
            }

            Cursor = Cursors.WaitCursor;
            try
            {
                using var client = new EvolutionApiClient(apiSetting.ServerUrl, apiSetting.InstanceName, apiSetting.ApiKey);
                List<EvolutionGroupInfo> groups = await client.FetchAllGroupsAsync();

                Cursor = Cursors.Default;

                if (groups.Count == 0)
                {
                    XtraMessageBox.Show(Resources.Form_CurrAccContactDetail_NoGroupsFound);
                    return;
                }

                using var form = new XtraForm();
                form.Text = Resources.Entity_CurrAccContactDetail_WhatsAppGroupJid;
                form.StartPosition = FormStartPosition.CenterParent;
                form.Size = new Size(450, 350);
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.KeyPreview = true;

                var listBox = new ListBoxControl();
                listBox.Dock = DockStyle.Fill;
                listBox.DisplayMember = "Subject";
                listBox.ValueMember = "Id";
                listBox.DataSource = groups;

                string selectedJid = null;

                listBox.DoubleClick += (s, ev) =>
                {
                    if (listBox.SelectedValue is string jid)
                    {
                        selectedJid = jid;
                        form.DialogResult = DialogResult.OK;
                    }
                };

                form.KeyDown += (s, ev) =>
                {
                    if (ev.KeyCode == Keys.Escape)
                        form.Close();
                    else if (ev.KeyCode == Keys.Enter && listBox.SelectedValue is string jid)
                    {
                        selectedJid = jid;
                        form.DialogResult = DialogResult.OK;
                    }
                };

                form.Controls.Add(listBox);

                if (form.ShowDialog(this) == DialogResult.OK && !string.IsNullOrWhiteSpace(selectedJid))
                {
                    WhatsAppGroupJidTextEdit.EditValue = selectedJid;
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(Resources.Common_ErrorOccurred + " " + ex.Message);
            }
        }
    }
}
