using DevExpress.Utils.Extensions;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraLayout.Utils;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;

namespace Foxoft
{
    public partial class FormProduct : XtraForm
    {
        subContext dbContext = new();
        EfMethods efMethods = new();
        public DcProduct dcProduct = new();
        GalleryItemGroup galleryItemGroup1 = new(); // designtime yaratmaq olmur
        string productFolder;
        string imageFilePath;
        private byte productTypeCode;
        private bool isNew;

        SettingStore settingStore;

        public FormProduct(byte productTypeCode, bool isNew)
        {
            InitializeComponent();

            InitializeControlText();

            galleryControl1.Gallery.Groups.Add(galleryItemGroup1);

            tabbedControlGroup1.SelectedTabPage = autoGroupForPrices;

            this.productTypeCode = productTypeCode;
            this.isNew = isNew;

            settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);

            if (Settings.Default.AppSetting.UseScales)
                BBI_Scales.Visibility = BarItemVisibility.Always;
            else
                BBI_Scales.Visibility = BarItemVisibility.OnlyInCustomizing;

            if (!isNew)
            {
                BBI_ProductDiscount.Enabled = true;
                BBI_ProductBarcode.Enabled = true;
                BBI_ProductStaticPriceList.Enabled = true;
                BBI_Scales.Enabled = true;
            }

            LUE_ProductTypeCode.Properties.DataSource = efMethods.SelectEntities<DcProductType>();
            LUE_DefaultUnitOfMeasureId.Properties.DataSource = efMethods.SelectEntities<DcUnitOfMeasure>();

            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;

            bool currAccHasClaimsRP = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "RetailPurchaseInvoice");
            if (!currAccHasClaimsRP)
                ItemForPurchasePrice.Visibility = LayoutVisibility.Never;

            bool currAccHasClaimsRS = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "RetailSaleInvoice");
            if (!currAccHasClaimsRS)
                ItemForRetailPrice.Visibility = LayoutVisibility.Never;

            bool currAccHasClaimsWS = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "WholesaleInvoice");
            if (!currAccHasClaimsWS)
                ItemForWholesalePrice.Visibility = LayoutVisibility.Never;
        }

        public FormProduct(byte productTypeCode, string productCode)
            : this(productTypeCode, false)
        {
            this.dcProduct.ProductCode = productCode;
            ProductCodeTextEdit.Properties.ReadOnly = true;
            ProductCodeTextEdit.Properties.Appearance.BackColor = Color.LightGray;
        }

        private void InitializeControlText()
        {
            layoutControlItem6.Name = ReflectionExt.GetDisplayName<SiteProduct>(x => x.Price);
            layoutControlItem7.Name = ReflectionExt.GetDisplayName<SiteProduct>(x => x.Desc);
            layoutControlItem11.Name = ReflectionExt.GetDisplayName<SiteProduct>(x => x.Slug);
            layoutControlItem9.Name = ReflectionExt.GetDisplayName<SiteProduct>(x => x.Rating);
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            LoadProduct();
            dataLayoutControl1.IsValid(out List<string> errorList);

            if (!CustomExtensions.DirectoryExist(settingStore?.ImageFolder))
            {
                try { Directory.CreateDirectory(settingStore?.ImageFolder); }
                catch (UnauthorizedAccessException) { }
                catch (DirectoryNotFoundException) { }
            }

            productFolder = Path.Combine(settingStore.ImageFolder, "Products", dcProduct.ProductCode);
            imageFilePath = Path.Combine(productFolder, dcProduct.ProductCode + ".jpg");

            LoadPictureBoxImage();
            LoadGalleryImages();
        }

        private void LoadProduct()
        {
            dbContext = new subContext();

            if (string.IsNullOrEmpty(dcProduct.ProductCode))
                ClearControlsAddNew();
            else
            {
                dbContext.DcProducts.Where(x => x.ProductCode == dcProduct.ProductCode)
                                    .Include(x => x.DcProductType)
                                    .Include(x => x.TrInvoiceLines).ThenInclude(x => x.TrInvoiceHeader)
                                    .Include(x => x.SiteProduct)
                                    .Load();

                dcProductsBindingSource.DataSource = dbContext.DcProducts.Local.ToBindingList();
            }
        }

        private void LoadPictureBoxImage()
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
        }

        private void ClearControlsAddNew()
        {
            dcProduct = dcProductsBindingSource.AddNew() as DcProduct;

            string NewDocNum = efMethods.GetNextDocNum(
                true,
                "P",
                nameof(DcProduct.ProductCode),
                nameof(dbContext.DcProducts),
                6);

            dcProduct.ProductCode = NewDocNum;
            dcProduct.ProductTypeCode = productTypeCode;
            dcProduct.CreatedUserName = Authorization.CurrAccCode;
            dcProduct.DefaultUnitOfMeasureId = settingStore.DefaultUnitOfMeasureId;

            dcProductsBindingSource.DataSource = dcProduct;

            ProductDescTextEdit.Select();
        }

        private void dcCurrAccsBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            //dcCurrAcc = new DcCurrAcc();
            //dcCurrAcc.CurrAccCode = efMethods.GetNextDocNum("CA", "CurrAccCode", "DcCurrAccs");
            //dcCurrAcc.DataLanguageCode = "AZ";
            //e.NewObject = dcCurrAcc;
        }

        private void SaveImage()
        {
            try
            {
                if (pictureEdit.Image is not null)
                {
                    if (!Directory.Exists(productFolder))
                        Directory.CreateDirectory(productFolder);

                    pictureEdit.Image.Save(imageFilePath);
                    GC.Collect();
                }
                else
                {
                    if (File.Exists(productFolder))
                        File.Delete(imageFilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(Resources.Form_Product_Message_SaveImageError, ex.Message),
                    Resources.Common_ErrorTitle);
            }
        }

        private void openFileDialog()
        {
            OpenFileDialog dialog = new();
            dialog.Filter =
                        "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" +
                        "All files (*.*)|*.*";

            dialog.Title = Resources.Form_Product_OpenFileDialog_Title;

            DialogResult dr = dialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                foreach (String file in dialog.FileNames)
                {
                    try
                    {
                        Image.GetThumbnailImageAbort myCallback = new(ThumbnailCallback);

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
        public bool ThumbnailCallback()
        {
            return false;
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

        private void btn_loadImage_Click(object sender, EventArgs e)
        {
        }

        private void btnEdit_Hierarchy_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit buttonEdit = (ButtonEdit)sender;

            using (FormHierarchyList form = new())
                if (form.ShowDialog(this) == DialogResult.OK)
                    buttonEdit.EditValue = form.DcHierarchy?.HierarchyCode;
        }

        private void BtnEdit_Slug_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            string slugify = dbContext.Slugify.FromSqlInterpolated($"Select dbo.Slugify ({ProductDescTextEdit.EditValue}) as Slugify").FirstOrDefault().Slugify;
            btnEdit_Slug.EditValue = slugify;
        }

        private void btnEdit_Hierarchy_EditValueChanged(object sender, EventArgs e)
        {
            if (!isNew)
                BBI_ProductFeature.Enabled = true;
            else BBI_ProductFeature.Enabled = false;
        }

        private void BBI_ProductFeature_ItemClick(object sender, ItemClickEventArgs e)
        {
            string? hierarchy = string.IsNullOrEmpty(btnEdit_Hierarchy.Text) ? null : btnEdit_Hierarchy.Text;
            efMethods.UpdateProductHierarchyCode(dcProduct.ProductCode, hierarchy);

            FormProductFeature frm = new(dcProduct.ProductCode);
            frm.ShowDialog();
        }

        private void BBI_ProductDiscount_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormCommonList<TrProductDiscount> frm = new("", "DiscountId", "", "ProductCode", dcProduct.ProductCode);
            frm.ShowDialog();
        }

        private void BBI_ProductBarcode_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormProductBarcode frm = new(dcProduct.ProductCode);
            frm.ShowDialog();
        }

        private void pictureEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void galleryControl1_MouseDown(object sender, MouseEventArgs e) // select with right click
        {
            if (e.Button == MouseButtons.Right)
            {
                RibbonHitInfo hitInfo = galleryControl1.Gallery.CalcHitInfo(e.Location);

                if (hitInfo.GalleryItem != null)
                {
                    galleryControl1.Gallery.SetItemCheck(hitInfo.GalleryItem, true);
                }
                else
                {
                    galleryControl1.Gallery.SetItemCheck(new GalleryItem(), true);
                }

                popupMenu_Gallery.ShowPopup(Control.MousePosition);
            }
        }

        private void LoadGalleryImages()
        {
            galleryItemGroup1.Items.Clear();

            if (dcProduct == null)
                return;

            if (!Directory.Exists(productFolder))
                return;

            for (int i = 1; i <= 10; i++)
            {
                string fileName = $"{dcProduct.ProductCode}-00{i}.jpg";
                string filePath = Path.Combine(productFolder, fileName);

                if (File.Exists(filePath))
                {
                    try
                    {
                        using (FileStream fs = new(filePath, FileMode.Open, FileAccess.Read))
                        {
                            using (Image img = Image.FromStream(fs, true, false))
                            {
                                Bitmap myBitmap = new(img);
                                var item = new GalleryItem(myBitmap, fileName, "");
                                item.Tag = filePath; // Store the file path in the Tag property
                                galleryItemGroup1.Items.Add(item);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error loading image {fileName}: {ex.Message}");
                    }
                }
            }
        }

        private void GalleryControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RibbonHitInfo hitInfo = galleryControl1.CalcHitInfo(e.Location);
            if (hitInfo.InGalleryItem) // Check if the double-click was on an item
            {
                GalleryItem clickedItem = hitInfo.GalleryItem;
                string filePath = clickedItem.Tag as string;

                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    try
                    {
                        ProcessStartInfo startInfo = new(filePath)
                        {
                            UseShellExecute = true
                        };
                        Process.Start(startInfo);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error opening image: {ex.Message}");
                    }
                }
            }
        }


        private void BBI_GalleryLoad_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = Resources.Form_Product_OpenFileDialog_Title;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image loadedImage = Image.FromFile(openFileDialog.FileName);

                if (!Directory.Exists(productFolder))
                    Directory.CreateDirectory(productFolder);

                string fileName = "";
                for (int i = 1; i <= 50; i++)
                {
                    fileName = $"{dcProduct.ProductCode}-00{i}.jpg";
                    string filePath = Path.Combine(productFolder, fileName);
                    if (!File.Exists(filePath))
                        break;
                }

                string savePath = Path.Combine(productFolder, fileName);

                loadedImage.Save(savePath, ImageFormat.Jpeg);

                LoadGalleryImages();
            }
        }


        private void BBI_GalleryCopy_ItemClick(object sender, ItemClickEventArgs e)
        {
            string caption = galleryControl1.Gallery.GetCheckedItem()?.Caption;
            string imagePath = Path.Combine(productFolder, caption);

            try
            {
                GalleryItem galleryItem = galleryControl1.Gallery.GetCheckedItem();
                if (galleryItem != null && galleryItem.Image != null)
                {
                    Clipboard.SetImage(galleryItem.Image);
                }
                else
                {
                    MessageBox.Show(
                        Resources.Form_Product_Message_NoGalleryImage,
                        Resources.Common_Attention);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(Resources.Form_Product_Message_DeleteFileError, ex.Message),
                    Resources.Common_ErrorTitle);
            }
        }

        private void BBI_GalleryPaste_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                Image clipboardImage = Clipboard.GetImage();

                if (clipboardImage != null)
                {
                    if (!Directory.Exists(productFolder))
                        Directory.CreateDirectory(productFolder);

                    string fileName = "";
                    for (int i = 1; i <= 50; i++)
                    {
                        fileName = $"{dcProduct.ProductCode}-00{i}.jpg";
                        string filePath = Path.Combine(productFolder, fileName);
                        if (!File.Exists(filePath))
                            break;
                    }

                    string savePath = Path.Combine(productFolder, fileName);

                    clipboardImage.Save(savePath, ImageFormat.Jpeg);

                    LoadGalleryImages();
                }
            }
            else
            {
                Console.WriteLine(Resources.Form_Product_Message_NoImageInClipboard);
            }
        }

        private void BBI_GalleryDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show(
                Resources.Common_DeleteConfirm,
                Resources.Common_Attention,
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string caption = galleryControl1.Gallery.GetCheckedItem().Caption;
                string imagePath = Path.Combine(productFolder, caption);

                try
                {
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                        LoadGalleryImages();
                    }
                    else
                        MessageBox.Show(
                            Resources.Form_Product_Message_FileDoesNotExist,
                            Resources.Common_Attention);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        string.Format(Resources.Form_Product_Message_DeleteFileError, ex.Message),
                        Resources.Common_ErrorTitle);
                }
            }
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

        private void popupMenu_Gallery_BeforePopup(object sender, CancelEventArgs e)
        {
            if (Clipboard.ContainsImage())
                BBI_GalleryPaste.Enabled = true;
            else
                BBI_GalleryPaste.Enabled = false;

            if (galleryControl1.Gallery.GetCheckedItemsCount() > 0)
            {
                BBI_GalleryCopy.Enabled = true;
                BBI_GalleryDelete.Enabled = true;
            }
            else
            {
                BBI_GalleryCopy.Enabled = false;
                BBI_GalleryDelete.Enabled = false;
            }

        }

        private void BBI_ProductStaticPriceList_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormProductStaticPrice frm = new(dcProduct.ProductCode);
            frm.ShowDialog();
        }


        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                dcProduct = dcProductsBindingSource.Current as DcProduct;
                if (isNew)
                    if (!efMethods.ProductExist(dcProduct.ProductCode))
                        efMethods.InsertProduct(dcProduct);
                    else
                        MessageBox.Show(
                            Resources.Form_Product_Message_ProductCodeExists,
                            Resources.Common_Attention);
                else
                    dbContext.SaveChanges();

                SaveImage();

                DialogResult = DialogResult.OK;
            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                dcProduct = dcProductsBindingSource.Current as DcProduct;
                if (isNew)
                    if (!efMethods.ProductExist(dcProduct.ProductCode))
                        efMethods.InsertProduct(dcProduct);
                    else
                        MessageBox.Show(
                            Resources.Form_Product_Message_ProductCodeExists,
                            Resources.Common_Attention);
                else
                    dbContext.SaveChanges();

                SaveImage();

                isNew = false;
                BBI_ProductFeature.Enabled = true;
                BBI_ProductDiscount.Enabled = true;
                BBI_ProductBarcode.Enabled = true;
                BBI_ProductStaticPriceList.Enabled = true;
                BBI_Scales.Enabled = true;

                LoadProduct();
            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }
        }

        private void BBI_Scales_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormProductScales formProductScales = new(dcProduct);
            formProductScales.ShowDialog();
        }

        private void ProductDescTextEdit_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(ProductDescTextEdit.Text)) return;

            if (efMethods.ProductExistByNameExceptProduct(ProductDescTextEdit.Text, dcProduct.ProductCode))
                dxErrorProvider1.SetError(
                    ProductDescTextEdit,
                    Resources.Form_Product_Validation_ProductNameExists,
                    ErrorType.Information);
            else
                dxErrorProvider1.ClearErrors();
        }
    }
}
