using Foxoft.AppCode;
using System.Threading.Tasks;
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
using DevExpress.Utils.Menu;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;

namespace Foxoft
{
    public partial class FormCurrAcc : XtraForm
    {
        subContext dbContext;
        EfMethods efMethods = new();
        bool isCustomer;
        public DcCurrAcc dcCurrAcc = new();
        private const string ChangeCurrAccCodeClaim = "ChangeCurrAccCode";
        SettingStore? settingStore;
        string currAccFolder = string.Empty;
        string imageFilePath = string.Empty;
        private bool isImageChanged;

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

            bool currAccHasBonusEarn = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "BonusEarn");
            if (!currAccHasBonusEarn)
                ItemForBonusCardNum.Visibility = LayoutVisibility.Never;
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
            settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);

            if (!string.IsNullOrWhiteSpace(settingStore?.ImageFolder) && !CustomExtensions.DirectoryExist(settingStore.ImageFolder))
            {
                try { Directory.CreateDirectory(settingStore.ImageFolder); }
                catch (UnauthorizedAccessException) { }
                catch (DirectoryNotFoundException) { }
            }
            LoadCurrAcc();
            LoadLayout();
            UpdateImagePath();
            LoadPictureBoxImage();
            dataLayoutControl1.IsValid(out List<string> errorList);
            CurrAccTypeCodeLookUpEdit_EditValueChanged(CurrAccTypeCodeLookUpEdit, EventArgs.Empty);
        }

        private void LoadCurrAcc()
        {
            dbContext = new subContext();

            if (string.IsNullOrEmpty(dcCurrAcc.CurrAccCode))
            {
                ClearControlsAddNew();
                BBI_MergeCurrAcc.Enabled = false;
                BBI_Info.Enabled = false;
            }
            else
            {
                dbContext.DcCurrAccs.Where(x => x.CurrAccCode == dcCurrAcc.CurrAccCode).Load();
                dcCurrAccsBindingSource.DataSource = dbContext.DcCurrAccs.Local.ToBindingList();


                dcCurrAcc = dcCurrAccsBindingSource.Current as DcCurrAcc;

                //if (string.IsNullOrWhiteSpace(dcCurrAcc.PhoneNum) 
                //    //|| dcCurrAcc.PhoneNum.Trim() == "+994" 
                //    //|| dcCurrAcc.PhoneNum.Trim() == "+"
                //    )
                //    dcCurrAcc.PhoneNum = null;
                bool exists = efMethods.EntityExists<DcCurrAcc>(dcCurrAcc.CurrAccCode);
                BBI_MergeCurrAcc.Enabled = exists;
                BBI_Info.Enabled = exists;
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
            dcCurrAcc.PhoneNum = null;
            dcCurrAcc.CreatedUserName = Authorization.CurrAccCode;
            dcCurrAcc.LastUpdatedUserName = Authorization.CurrAccCode;

            dcCurrAccsBindingSource.DataSource = dcCurrAcc;
            CurrAccDescTextEdit.Select();
            pictureEdit.Image = null;
            isImageChanged = false;
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

                //if (string.IsNullOrWhiteSpace(dcCurrAcc.PhoneNum) 
                //    //|| dcCurrAcc.PhoneNum.Trim() == "+994" 
                //    //|| dcCurrAcc.PhoneNum.Trim() == "+"
                //    )
                //    dcCurrAcc.PhoneNum = null;

                bool isNew = !efMethods.EntityExists<DcCurrAcc>(dcCurrAcc.CurrAccCode);
                if (isNew)
                {
                    efMethods.InsertEntity(dcCurrAcc);

                    bool autoCreateEnabled = Settings.Default.AppSetting?.AutoCreateGoogleContact ?? false;
                    if (autoCreateEnabled)
                    {
                        if (XtraMessageBox.Show(
                            Resources.Form_CurrAcc_Question_AddToGoogleContacts,
                            Resources.Common_Attention,
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            CreateGoogleContactInBackground(dcCurrAcc);
                        }
                    }
                }
                else
                {
                    dcCurrAcc.LastUpdatedUserName = Authorization.CurrAccCode;
                    dcCurrAcc.LastUpdatedDate = DateTime.Now;
                    dbContext.SaveChanges();
                }

                SaveImage();

                BBI_MergeCurrAcc.Enabled = true;
                BBI_Info.Enabled = true;

                DialogResult = DialogResult.OK;
            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }
        }

        
        private void CreateGoogleContactInBackground(DcCurrAcc acc)
        {
            var snapshot = new DcCurrAcc
            {
                CurrAccCode = acc.CurrAccCode,
                CurrAccDesc = acc.CurrAccDesc,
                FirstName = acc.FirstName,
                LastName = acc.LastName,
                FatherName = acc.FatherName,
                PhoneNum = acc.PhoneNum,
                Address = acc.Address,
                CurrAccTypeCode = acc.CurrAccTypeCode
            };

            if (acc.DcCurrAccContactDetails != null && acc.DcCurrAccContactDetails.Count > 0)
            {
                snapshot.DcCurrAccContactDetails = acc.DcCurrAccContactDetails
                    .Select(cd => new DcCurrAccContactDetail
                    {
                        ContactTypeId = cd.ContactTypeId,
                        ContactDesc = cd.ContactDesc
                    }).ToList();
            }

            Task.Run(async () =>
            {
                try
                {
                    using GoogleContactAPI api = new();
                    await api.CreateContactAsync(snapshot);
                }
                catch
                {
                    // Fail gracefully in background
                }
            });
        }

        private bool CanChangeCurrAccCode()
        {
            return efMethods.CurrAccHasClaims(Authorization.CurrAccCode, ChangeCurrAccCodeClaim);
        }

        private void BonusCardNumTextEdit_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                dbContext ??= new subContext();

                string barcode;
                do
                {
                    string genNumber = efMethods.GetNextDocNum(
                        false,
                        "20",
                        nameof(DcCurrAcc.BonusCardNum),
                        nameof(subContext.DcCurrAccs),
                        10);

                    string checkDigit = CustomExtensions.CalculateChecksumDigit("20", genNumber.Substring(2));
                    barcode = genNumber + checkDigit;
                } while (dbContext.DcCurrAccs.Any(x => x.BonusCardNum == barcode));

                BonusCardNumTextEdit.EditValue = barcode;
                BonusCardNumTextEdit.IsModified = true;
                dcCurrAccsBindingSource.EndEdit();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.Common_ErrorTitle);
            }
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
                ALTER TABLE TrUserRoles NOCHECK CONSTRAINT ALL;
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
                UPDATE TrUserRoles SET UserName = @NewDocNum WHERE UserName = @OldDocNum;
                UPDATE TrInvoiceHeaders SET CurrAccCode = @NewDocNum WHERE CurrAccCode = @OldDocNum;
                UPDATE TrInvoiceLines SET SalesPersonCode = @NewDocNum WHERE SalesPersonCode = @OldDocNum;
                UPDATE TrPaymentHeaders SET CurrAccCode = @NewDocNum WHERE CurrAccCode = @OldDocNum;
                UPDATE TrSessions SET CurrAccCode = @NewDocNum WHERE CurrAccCode = @OldDocNum;

                ALTER TABLE DcPaymentMethods WITH CHECK CHECK CONSTRAINT ALL;
                ALTER TABLE TrUserRoles WITH CHECK CHECK CONSTRAINT ALL;
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
        private void BBI_RelatedCurrAcc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormCurrAccRelationList frm = new(dcCurrAcc.CurrAccCode);
            frm.ShowDialog();
        }

        private void BBI_Info_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dcCurrAcc == null || string.IsNullOrEmpty(dcCurrAcc.CurrAccCode))
                return;

            string createdUser = efMethods.GetUserDisplayName(dcCurrAcc.CreatedUserName);
            string updatedUser = efMethods.GetUserDisplayName(dcCurrAcc.LastUpdatedUserName);

            string createdUserName = ReflectionExt.GetDisplayName<DcCurrAcc>(x => x.CreatedUserName) + ": " + createdUser;
            string createdDate = ReflectionExt.GetDisplayName<DcCurrAcc>(x => x.CreatedDate) + ": " + (dcCurrAcc.CreatedDate == default ? string.Empty : dcCurrAcc.CreatedDate.ToString());
            string updatedUserName = ReflectionExt.GetDisplayName<DcCurrAcc>(x => x.LastUpdatedUserName) + ": " + updatedUser;
            string updatedDateText = ReflectionExt.GetDisplayName<DcCurrAcc>(x => x.LastUpdatedDate) + ": " + (dcCurrAcc.LastUpdatedDate == default ? string.Empty : dcCurrAcc.LastUpdatedDate.ToString());

            XtraMessageBox.Show(createdUserName + "\n\n" + createdDate + "\n\n" + updatedUserName + "\n\n" + updatedDateText, Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PhoneNumTextEdit_Validating(object sender, CancelEventArgs e)
        {
            var te = (TextEdit)sender;
            var before = te.Text;
            var after = PhoneNumberFormat.FormatIntlPhone(before);

            if (string.IsNullOrWhiteSpace(after))
            {
                te.EditValue = null;
                dxErrorProvider1.ClearErrors();
                return;
            }

            te.Text = after;

            if (efMethods.CurrAccExistByPhoneNumExceptCurrAcc(te.Text, dcCurrAcc.CurrAccCode))
                dxErrorProvider1.SetError(PhoneNumTextEdit, Resources.Validation_Phone_ExistsInAnotherCurrAcc, ErrorType.Information);
            else
                dxErrorProvider1.ClearErrors();
        }

        private void PhoneNumTextEdit_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void CurrAccTypeCodeLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            bool isPersonnel = CurrAccTypeCodeLookUpEdit.EditValue is CurrAccType.Personnel;

            PersonalTypeCodeLookUpEdit.Enabled = isPersonnel;

            if (!isPersonnel)
                PersonalTypeCodeLookUpEdit.EditValue = null;
        }

        private void BBI_HumanResources_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BBI_MergeCurrAcc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using FormCurrAccList frm = new(new byte[] { (byte)dcCurrAcc.CurrAccTypeCode }, false);
            if (frm.ShowDialog() != DialogResult.OK || frm.dcCurrAcc is null)
                return;

            string sourceCurrAccCode = frm.dcCurrAcc.CurrAccCode;
            string sourceCurrAccDesc = frm.dcCurrAcc.CurrAccDesc;

            if (sourceCurrAccCode == dcCurrAcc.CurrAccCode)
            {
                XtraMessageBox.Show(
                    Resources.Form_CurrAcc_Message_CannotMergeSameCurrAcc,
                    Resources.Common_Attention);
                return;
            }

            DialogResult dialogResult = XtraMessageBox.Show(
                string.Format(
                    Resources.Form_CurrAcc_Message_MergeConfirm,
                    sourceCurrAccDesc, sourceCurrAccCode,
                    dcCurrAcc.CurrAccDesc, dcCurrAcc.CurrAccCode),
                Resources.Common_Attention,
                MessageBoxButtons.YesNo);

            if (dialogResult != DialogResult.Yes)
                return;

            try
            {
                MergeCurrAccs(sourceCurrAccCode, dcCurrAcc.CurrAccCode);

                dcCurrAcc = new DcCurrAcc { CurrAccCode = dcCurrAcc.CurrAccCode };
                LoadCurrAcc();
                dcCurrAcc = dcCurrAccsBindingSource.Current as DcCurrAcc ?? dcCurrAcc;

                XtraMessageBox.Show(
                    Resources.Form_CurrAcc_Message_MergeSuccess,
                    Resources.Common_Info);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    string.Format(Resources.Form_CurrAcc_Message_MergeError, ex.Message),
                    Resources.Common_ErrorTitle);
            }
        }

        private void MergeCurrAccs(string sourceCurrAccCode, string targetCurrAccCode)
        {
            efMethods.MergeCurrAccs(sourceCurrAccCode, targetCurrAccCode);
        }

        private void UpdateImagePath()
        {
            currAccFolder = CustomExtensions.CombinePath(settingStore?.ImageFolder, "CurrAccs", dcCurrAcc?.CurrAccCode);
            imageFilePath = CustomExtensions.CombinePath(currAccFolder, dcCurrAcc?.CurrAccCode + ".jpg");
        }

        private void LoadPictureBoxImage()
        {
            try
            {
                if (File.Exists(imageFilePath))
                {
                    using (var fs = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        try
                        {
                            using (Image img = Image.FromStream(fs, true, false))
                            {
                                Bitmap myBitmap = new(img);
                                pictureEdit.Image = myBitmap;
                            }
                        }
                        catch (Exception) { }
                    }
                }
                else
                {
                    pictureEdit.Image = null;
                }
            }
            finally
            {
                isImageChanged = false;
            }
        }

        private void SaveImage()
        {
            if (!isImageChanged)
                return;

            try
            {
                UpdateImagePath();

                if (string.IsNullOrWhiteSpace(currAccFolder) || string.IsNullOrWhiteSpace(imageFilePath))
                    return;

                if (pictureEdit.Image is not null)
                {
                    if (!Directory.Exists(currAccFolder))
                        Directory.CreateDirectory(currAccFolder);

                    using (MemoryStream ms = new())
                    {
                        using (Bitmap bmp = new(pictureEdit.Image))
                        {
                            bmp.Save(ms, ImageFormat.Jpeg);
                        }
                        File.WriteAllBytes(imageFilePath, ms.ToArray());
                    }

                    isImageChanged = false;
                    GC.Collect();
                }
                else
                {
                    if (File.Exists(imageFilePath))
                        File.Delete(imageFilePath);

                    isImageChanged = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    string.Format(Resources.Form_CurrAcc_Message_SaveImageError, ex.Message),
                    Resources.Common_Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void openFileDialog()
        {
            OpenFileDialog dialog = new();
            dialog.Filter =
                "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" +
                "All files (*.*)|*.*";

            dialog.Title = Resources.Form_CurrAcc_OpenFileDialog_Title;

            DialogResult dr = dialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                foreach (string file in dialog.FileNames)
                {
                    try
                    {
                        using (FileStream fs = new(file, FileMode.Open, FileAccess.Read))
                        {
                            using (Image img = Image.FromStream(fs, true, false))
                            {
                                Bitmap myBitmap = new(img);
                                pictureEdit.Image = myBitmap;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"{Resources.Common_ErrorTitle}: {ex.Message}",
                            Resources.Common_ErrorTitle);
                    }
                }
            }
        }

        private void pictureEdit_DoubleClick(object sender, EventArgs e)
        {
            if (File.Exists(imageFilePath))
            {
                ProcessStartInfo startInfo = new(imageFilePath);
                startInfo.UseShellExecute = true;
                Process.Start(startInfo);
            }
        }

        private void pictureEdit_EditValueChanged(object sender, EventArgs e)
        {
            isImageChanged = true;
        }

        private void pictureEdit_PopupMenuShowing(object sender, DevExpress.XtraEditors.Events.PopupMenuShowingEventArgs e)
        {
            void RemoveMenuItem(StringId tag)
            {
                var itemToRemove = e.PopupMenu.Items.FirstOrDefault(item => item.Tag != null && (StringId)item.Tag == tag);
                if (itemToRemove != null)
                    e.PopupMenu.Items.Remove(itemToRemove);
            }

            void AddMenuItem(string caption, DXMenuItem oldItem, EventHandler clickHandler, bool enabled = true)
            {
                if (oldItem == null) return;
                var newItem = new DXMenuItem(caption, clickHandler, oldItem.GetImage()) { Enabled = enabled, Tag = oldItem.Tag };
                e.PopupMenu.Items.Add(newItem);
            }

            var cutItem = e.PopupMenu.Items.FirstOrDefault(item => item.Tag != null && (StringId)item.Tag == StringId.PictureEditMenuCut);
            var saveItem = e.PopupMenu.Items.FirstOrDefault(item => item.Tag != null && (StringId)item.Tag == StringId.PictureEditMenuSave);
            var loadItem = e.PopupMenu.Items.FirstOrDefault(item => item.Tag != null && (StringId)item.Tag == StringId.PictureEditMenuLoad);
            var pasteItem = e.PopupMenu.Items.FirstOrDefault(item => item.Tag != null && (StringId)item.Tag == StringId.PictureEditMenuPaste);
            var deleteItem = e.PopupMenu.Items.FirstOrDefault(item => item.Tag != null && (StringId)item.Tag == StringId.PictureEditMenuDelete);

            AddMenuItem(Resources.Common_Paste, pasteItem, PictureEdit_PasteItem_Click, Clipboard.ContainsImage());
            AddMenuItem(Resources.Common_Load, loadItem, PictureEdit_LoadItem_Click);
            AddMenuItem(Resources.Common_Delete, deleteItem, PictureEdit_DeleteItem_Click, pictureEdit.Image != null);

            RemoveMenuItem(StringId.PictureEditMenuCut);
            RemoveMenuItem(StringId.PictureEditMenuSave);
            RemoveMenuItem(StringId.PictureEditMenuLoad);
            RemoveMenuItem(StringId.PictureEditMenuPaste);
            RemoveMenuItem(StringId.PictureEditMenuDelete);
        }

        private void PictureEdit_LoadItem_Click(object sender, EventArgs e)
        {
            openFileDialog();
        }

        private void PictureEdit_DeleteItem_Click(object sender, EventArgs e)
        {
            pictureEdit.Image = null;
        }

        private void PictureEdit_PasteItem_Click(object sender, EventArgs e)
        {
            pictureEdit.Image = Clipboard.GetImage();
        }
    }
}