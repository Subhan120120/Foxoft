using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using DevExpress.XtraEditors;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormImage : RibbonForm
    {
        EfMethods efMethods = new();
        string InvoiceFolder = string.Empty;
        string code = string.Empty;

        GalleryItemGroup galleryItemGroup1 = new();

        public FormImage()
        {
            InitializeComponent();

            SettingStore settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);
            if (CustomExtensions.DirectoryExist(settingStore.ImageFolder))
                Directory.CreateDirectory(settingStore.ImageFolder);

            InvoiceFolder = Path.Combine(settingStore.ImageFolder, "Invoices");

            galleryControl1.Gallery.Groups.Add(galleryItemGroup1);
        }

        public FormImage(string code)
            : this()
        {
            this.code = code;
            LoadGallaryImages();
        }

        private string CurrentFolderPath => Path.Combine(InvoiceFolder, code);

        private void FormImage_Load(object sender, EventArgs e)
        {
            LoadGallaryImages();
        }

        private void LoadGallaryImages()
        {
            galleryItemGroup1.Items.Clear();

            string folderPath = CurrentFolderPath;
            if (!Directory.Exists(folderPath))
                return;

            string[] filters = { "*.jpg", "*.jpeg", "*.png", "*.gif", "*.tiff", "*.bmp", "*.svg" };

            var files = filters
                .SelectMany(filter => Directory.GetFiles(folderPath, filter, SearchOption.TopDirectoryOnly))
                .OrderBy(x => x)
                .ToList();

            foreach (string filePath in files)
            {
                try
                {
                    using FileStream fs = new(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using Image img = Image.FromStream(fs, true, false);
                    Bitmap bmp = new(img);

                    AddImageToGallary(bmp, filePath);
                }
                catch (Exception)
                {
                    // İstəsən log əlavə edə bilərsən
                }
            }
        }

        private void AddImageToGallary(Image img, string filePath)
        {
            string fileName = Path.GetFileName(filePath);

            GalleryItem galleryItem = new(img, fileName, string.Empty)
            {
                Tag = filePath
            };

            galleryItem.ItemClick += (s, e) => OpenImageFile(filePath);

            galleryItemGroup1.Items.Add(galleryItem);
        }

        private void OpenImageFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
                return;

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
                MessageBox.Show(
                    ex.Message,
                    Resources.Common_ErrorTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void openFileDialog()
        {
            OpenFileDialog dialog = new();
            dialog.Filter =
                Resources.Common_File_ImageFilter + "|" +
                Resources.Common_File_All;

            dialog.Multiselect = true;
            dialog.Title = Resources.Form_Image_OpenDialogTitle;

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            string folderPath = CurrentFolderPath;

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            foreach (string fullPath in dialog.FileNames)
            {
                try
                {
                    string fileName = Path.GetFileName(fullPath);
                    string destinationPath = GetUniqueFilePath(folderPath, fileName);

                    using FileStream fs = new(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using Image img = Image.FromStream(fs, true, false);
                    using Bitmap bmp = new(img);

                    bmp.Save(destinationPath, GetImageFormatFromExtension(destinationPath));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        Resources.Common_ErrorTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void SaveClipboardImage()
        {
            if (!Clipboard.ContainsImage())
                return;

            Image clipboardImage = Clipboard.GetImage();
            if (clipboardImage == null)
                return;

            string folderPath = CurrentFolderPath;

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string fileName = $"IMG_{DateTime.Now:yyyyMMdd_HHmmss_fff}.jpg";
            string savePath = Path.Combine(folderPath, fileName);

            try
            {
                using Bitmap bmp = new(clipboardImage);
                bmp.Save(savePath, ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    Resources.Common_ErrorTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static string GetUniqueFilePath(string folderPath, string originalFileName)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalFileName);
            string extension = Path.GetExtension(originalFileName);

            string filePath = Path.Combine(folderPath, originalFileName);
            int counter = 1;

            while (File.Exists(filePath))
            {
                string newFileName = $"{fileNameWithoutExtension}_{counter}{extension}";
                filePath = Path.Combine(folderPath, newFileName);
                counter++;
            }

            return filePath;
        }

        private static ImageFormat GetImageFormatFromExtension(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLowerInvariant();

            return ext switch
            {
                ".bmp" => ImageFormat.Bmp,
                ".gif" => ImageFormat.Gif,
                ".jpeg" => ImageFormat.Jpeg,
                ".jpg" => ImageFormat.Jpeg,
                ".png" => ImageFormat.Png,
                ".tif" => ImageFormat.Tiff,
                ".tiff" => ImageFormat.Tiff,
                _ => ImageFormat.Jpeg
            };
        }

        private GalleryItem GetSelectedGalleryItem()
        {
            return galleryControl1.Gallery.GetCheckedItem();
        }

        private void DeleteSelectedImage()
        {
            GalleryItem item = GetSelectedGalleryItem();
            if (item == null)
                return;

            string filePath = item.Tag?.ToString();
            if (string.IsNullOrWhiteSpace(filePath))
                return;

            if (XtraMessageBox.Show(
                Resources.Common_DeleteConfirm,
                Resources.Common_Attention,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) != DialogResult.OK)
                return;

            try
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);

                LoadGallaryImages();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    Resources.Common_ErrorTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CopySelectedImageToClipboard()
        {
            GalleryItem item = GetSelectedGalleryItem();
            if (item?.Image == null)
            {
                MessageBox.Show(
                    Resources.Form_Product_Message_NoGalleryImage,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            try
            {
                Clipboard.SetImage(item.Image);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    Resources.Common_ErrorTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btn_Add_ItemClick(object sender, ItemClickEventArgs e)
        {
            openFileDialog();
            LoadGallaryImages();
        }

        private void btn_Delete_ItemClick(object sender, ItemClickEventArgs e)
        {
            DeleteSelectedImage();
        }

        private void BBI_GalleryLoad_ItemClick(object sender, ItemClickEventArgs e)
        {
            openFileDialog();
            LoadGallaryImages();
        }

        private void BBI_GalleryPaste_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveClipboardImage();
            LoadGallaryImages();
        }

        private void BBI_GalleryCopy_ItemClick(object sender, ItemClickEventArgs e)
        {
            CopySelectedImageToClipboard();
        }

        private void BBI_GalleryDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            DeleteSelectedImage();
        }

        private void popupMenu_Gallery_BeforePopup(object sender, CancelEventArgs e)
        {
            BBI_GalleryPaste.Enabled = Clipboard.ContainsImage();

            bool hasSelectedItem = galleryControl1.Gallery.GetCheckedItemsCount() > 0;

            BBI_GalleryCopy.Enabled = hasSelectedItem;
            BBI_GalleryDelete.Enabled = hasSelectedItem;
        }

        private void galleryControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                RibbonHitInfo hitInfo = galleryControl1.Gallery.CalcHitInfo(e.Location);

                if (hitInfo.GalleryItem != null)
                {
                    galleryControl1.Gallery.SetItemCheck(hitInfo.GalleryItem, true);
                }

                popupMenu_Gallery.ShowPopup(Control.MousePosition);
            }
        }

        private void galleryControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RibbonHitInfo hitInfo = galleryControl1.CalcHitInfo(e.Location);

            if (hitInfo.InGalleryItem && hitInfo.GalleryItem != null)
            {
                string filePath = hitInfo.GalleryItem.Tag?.ToString();
                OpenImageFile(filePath);
            }
        }
    }
}