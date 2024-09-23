using DevExpress.Utils.Extensions;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;

namespace Foxoft
{
    public partial class FormProduct : XtraForm
    {
        subContext dbContext = new();
        EfMethods efMethods = new();
        SettingStore settingStore;
        string productFolder;
        string imageFilePath;
        public DcProduct dcProduct = new();
        private byte productTypeCode;
        private bool isNew;
        GalleryItemGroup galleryItemGroup1 = new GalleryItemGroup(); // designtime yaratmaq olmur

        public FormProduct(byte productTypeCode, bool isNew)
        {
            InitializeComponent();

            InitializeControlText();

            InitializeGallery();

            tabbedControlGroup1.SelectedTabPage = autoGroupForQiymətlər;

            this.productTypeCode = productTypeCode;
            this.isNew = isNew;

            if (!isNew)
            {
                BBI_ProductDiscount.Enabled = true;
                BBI_ProductBarcode.Enabled = true;
            }

            SettingStore settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);
            settingStore = settingStore;
            if (!CustomExtensions.DirectoryExist(settingStore?.ImageFolder))
                Directory.CreateDirectory(settingStore?.ImageFolder);

            ProductTypeCodeLookUpEdit.Properties.DataSource = efMethods.SelectProductTypes();
            ProductTypeCodeLookUpEdit.Properties.ValueMember = "ProductTypeCode";
            ProductTypeCodeLookUpEdit.Properties.DisplayMember = "ProductTypeDesc";

            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;
        }

        private void InitializeGallery()
        {
            galleryItemGroup1.Caption = "Product Images";
            galleryControl1.Gallery.Groups.Add(galleryItemGroup1);
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
            FillDataLayout();
            dataLayoutControl1.IsValid(out List<string> errorList);

            productFolder = Path.Combine(settingStore.ImageFolder, dcProduct.ProductCode);
            imageFilePath = Path.Combine(productFolder, dcProduct.ProductCode + ".jpg");

            LoadPictureBoxImage();
            LoadGalleryImages();
        }

        private void FillDataLayout()
        {
            dbContext = new subContext();

            if (string.IsNullOrEmpty(dcProduct.ProductCode))
                ClearControlsAddNew();
            else
            {
                //dbContext.DcCurrAccs.Where(x => x.CurrAccCode == dcCurrAcc.CurrAccCode)
                //                    .LoadAsync()
                //                    .ContinueWith(loadTask => dcCurrAccsBindingSource.DataSource = dbContext.DcCurrAccs.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());

                dbContext.DcProducts.Where(x => x.ProductCode == dcProduct.ProductCode)
                                    .Include(x => x.DcProductType)
                                    .Include(x => x.TrInvoiceLines).ThenInclude(x => x.TrInvoiceHeader)
                                    .Include(x => x.SiteProduct)
                                    .Load();

                dbContext.DcProducts.Local.ForEach(x => x.Balance = x.TrInvoiceLines.Where(l => new string[] { "RP", "WP", "RS", "WS", "CI", "CO", "IT" }.Contains(l.TrInvoiceHeader.ProcessCode))
                                                                                    .Sum(l => l.QtyIn - l.QtyOut));

                dcProductsBindingSource.DataSource = dbContext.DcProducts.Local.ToBindingList();
            }
        }

        private void LoadPictureBoxImage()
        {
            if (File.Exists(imageFilePath))
            {
                using (var alma = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    try
                    {
                        pictureEdit.Image = Image.FromStream(alma);
                    }
                    catch (Exception) { }
                }
            }
        }

        private void ClearControlsAddNew()
        {
            dcProduct = dcProductsBindingSource.AddNew() as DcProduct;

            string NewDocNum = efMethods.GetNextDocNum(true, "P", "ProductCode", "DcProducts", 6);
            dcProduct.ProductCode = NewDocNum;
            dcProduct.ProductTypeCode = productTypeCode;
            dcProduct.CreatedUserName = Authorization.CurrAccCode;

            dcProductsBindingSource.DataSource = dcProduct;
        }

        private void dcCurrAccsBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            //dcCurrAcc = new DcCurrAcc();
            //dcCurrAcc.CurrAccCode = efMethods.GetNextDocNum("CA", "CurrAccCode", "DcCurrAccs");
            //dcCurrAcc.DataLanguageCode = "AZ";
            //e.NewObject = dcCurrAcc;
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
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                dcProduct = dcProductsBindingSource.Current as DcProduct;
                if (isNew) //if invoiceHeader doesnt exist
                    if (!efMethods.ProductExist(dcProduct.ProductCode))
                        efMethods.InsertProduct(dcProduct);
                    else
                        MessageBox.Show("Bu Kodda Məhsul Artıq Mövcuddur!");
                else
                    dbContext.SaveChanges();

                //SaveImage();

                DialogResult = DialogResult.OK;
            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }
        }

        private void SaveImage()
        {
            if (!Directory.Exists(productFolder))
                Directory.CreateDirectory(productFolder);

            try
            {
                //bitmap = pictureEdit.Image
                if (pictureEdit.Image is not null)
                {
                    pictureEdit.Image.Save(imageFilePath);
                    GC.Collect();
                }
                else
                    File.Delete(imageFilePath);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void openFileDialog()
        {
            OpenFileDialog dialog = new();
            dialog.Filter =
                        "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" +
                        "All files (*.*)|*.*";

            //dialog.Multiselect = true;
            dialog.Title = "Foxoft üçün şəkil seçin.";

            DialogResult dr = dialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                foreach (String file in dialog.FileNames)
                {
                    try
                    {
                        Image.GetThumbnailImageAbort myCallback = new(ThumbnailCallback);
                        //Image myThumbnail = myBitmap.GetThumbnailImage(300, 300, myCallback, IntPtr.Zero);

                        using (FileStream fs = new(file, FileMode.Open, FileAccess.Read))
                        {
                            using (Image img = Image.FromStream(fs, true, false))
                            {
                                Bitmap myBitmap = new(img);
                                pictureEdit.Image = myBitmap;

                                SaveImage();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
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
            openFileDialog.Title = "Select an Image";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image loadedImage = Image.FromFile(openFileDialog.FileName);

                if (!Directory.Exists(productFolder))
                {
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
        }

        private void BBI_GalleryCopy_ItemClick(object sender, ItemClickEventArgs e)
        {
            string caption = galleryControl1.Gallery.GetCheckedItem().Caption;
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
                    MessageBox.Show("No image found in the selected gallery item.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting file: {ex.Message}");
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
                Console.WriteLine("No image in the clipboard.");
            }
        }

        private void BBI_GalleryDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Silmek Isteyirsiz? \n ", "Diqqet", MessageBoxButtons.OKCancel) == DialogResult.OK)
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
                        MessageBox.Show("File does not exist.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting file: {ex.Message}");
                }
            }
        }

        private void pictureEdit_PopupMenuShowing(object sender, DevExpress.XtraEditors.Events.PopupMenuShowingEventArgs e)
        {
            //DXMenuItem oldSaveItem = null;
            DXMenuItem cutItem = null;
            DXMenuItem loadItem = null;
            DXMenuItem pasteItem = null;

            foreach (DXMenuItem item in e.PopupMenu.Items)
            {
                if (item.Tag != null)
                {
                    if ((StringId)item.Tag == StringId.PictureEditMenuCut)
                        cutItem = item;
                    else if ((StringId)item.Tag == StringId.PictureEditMenuLoad)
                        loadItem = item;
                    else if ((StringId)item.Tag == StringId.PictureEditMenuPaste)
                        pasteItem = item;
                }
            }

            DXMenuItem newLoadItem = new(loadItem.Caption, PictureEdit_LoadItem_Click, loadItem.GetImage());
            newLoadItem.Tag = StringId.PictureEditMenuLoad;
            e.PopupMenu.Items.Add(newLoadItem);

            DXMenuItem newPasteItem = new(pasteItem.Caption, PictureEdit_PasteItem_Click, pasteItem.GetImage());
            if (Clipboard.ContainsImage())
                newPasteItem.Enabled = true;
            else
                newPasteItem.Enabled = false;
            newPasteItem.Tag = StringId.PictureEditMenuPaste;
            e.PopupMenu.Items.Add(newPasteItem);

            if (cutItem != null)
                e.PopupMenu.Items.Remove(cutItem);

            if (loadItem != null)
                e.PopupMenu.Items.Remove(loadItem);

            if (pasteItem != null)
                e.PopupMenu.Items.Remove(pasteItem);
        }

        private void PictureEdit_LoadItem_Click(object sender, EventArgs e)
        {
            openFileDialog();
            SaveImage();
        }
        private void PictureEdit_PasteItem_Click(object sender, EventArgs e)
        {
            pictureEdit.Image = Clipboard.GetImage();
            SaveImage();
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
    }
}