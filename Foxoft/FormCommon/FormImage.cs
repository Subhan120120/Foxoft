using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using DevExpress.XtraEditors;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        private readonly EfMethods efMethods = new();
        private string InvoiceFolder = string.Empty;
        private string code = string.Empty;
        private string? selectedFilePath = null;

        private readonly GalleryItemGroup galleryItemGroup1 = new();

        private static readonly HashSet<string> SupportedExtensions = new(StringComparer.OrdinalIgnoreCase)
        {
            ".jpg", ".jpeg", ".png", ".gif", ".tiff", ".tif", ".bmp", ".svg", ".webp"
        };

        public FormImage()
        {
            InitializeComponent();

            SettingStore? settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);
            if (!string.IsNullOrWhiteSpace(settingStore?.ImageFolder))
            {
                try
                {
                    if (!CustomExtensions.DirectoryExist(settingStore.ImageFolder))
                        Directory.CreateDirectory(settingStore.ImageFolder);
                }
                catch
                {
                    // Do not fail initialization if folder has restricted permissions
                }
            }

            InvoiceFolder = CustomExtensions.CombinePath(settingStore?.ImageFolder, "Invoices");

            galleryControl1.Gallery.Groups.Add(galleryItemGroup1);

            galleryControl1.Gallery.ItemClick += (s, e) => UpdateSelectedPreview(e.Item);
            galleryControl1.Gallery.ItemCheckedChanged += (s, e) =>
            {
                if (e.Item.Checked)
                    UpdateSelectedPreview(e.Item);
            };
        }

        public FormImage(string code)
            : this()
        {
            this.code = code?.Trim() ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(this.code))
            {
                Text = $"{Resources.Form_Image_InvoiceTitle} - {this.code}";
                bsi_DocNum.Caption = string.Format(Resources.Form_Image_DocNum, this.code);
            }
            else
            {
                Text = Resources.Form_Image_Caption;
                bsi_DocNum.Caption = string.Empty;
            }
        }

        private string CurrentFolderPath => string.IsNullOrWhiteSpace(code)
            ? InvoiceFolder
            : CustomExtensions.CombinePath(InvoiceFolder, code);

        private void FormImage_Load(object sender, EventArgs e)
        {
            LoadGallaryImages();
        }

        private void FormImage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                SaveClipboardImage();
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                CopySelectedImageToClipboard();
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.O)
            {
                openFileDialog();
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.E)
            {
                OpenFolder();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                DeleteSelectedImage();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F5)
            {
                LoadGallaryImages(selectedFilePath);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter && !pe_Preview.Focused)
            {
                OpenSelectedImage();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
                e.Handled = true;
            }
        }

        private void LoadGallaryImages(string? fileToSelect = null)
        {
            DisposeGalleryImages();
            galleryItemGroup1.Items.Clear();

            string folderPath = CurrentFolderPath;
            if (!Directory.Exists(folderPath))
            {
                UpdateSelectedPreview(null);
                bsi_ImageCount.Caption = string.Format(Resources.Form_Image_TotalImages, 0);
                return;
            }

            string[] filters = { "*.jpg", "*.jpeg", "*.png", "*.gif", "*.tiff", "*.tif", "*.bmp", "*.svg", "*.webp" };

            var files = filters
                .SelectMany(filter => Directory.GetFiles(folderPath, filter, SearchOption.TopDirectoryOnly))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(x => x)
                .ToList();

            GalleryItem? itemToSelect = null;

            foreach (string filePath in files)
            {
                try
                {
                    using FileStream fs = new(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using Image img = Image.FromStream(fs, true, false);
                    Bitmap bmp = new(img);

                    GalleryItem item = AddImageToGallary(bmp, filePath);

                    if (!string.IsNullOrWhiteSpace(fileToSelect) &&
                        string.Equals(filePath, fileToSelect, StringComparison.OrdinalIgnoreCase))
                    {
                        itemToSelect = item;
                    }
                }
                catch
                {
                    // Ignore unreadable or corrupted files
                }
            }

            bsi_ImageCount.Caption = string.Format(Resources.Form_Image_TotalImages, galleryItemGroup1.Items.Count);

            if (itemToSelect != null)
            {
                galleryControl1.Gallery.SetItemCheck(itemToSelect, true);
                UpdateSelectedPreview(itemToSelect);
            }
            else if (galleryItemGroup1.Items.Count > 0)
            {
                GalleryItem first = galleryItemGroup1.Items[0];
                galleryControl1.Gallery.SetItemCheck(first, true);
                UpdateSelectedPreview(first);
            }
            else
            {
                UpdateSelectedPreview(null);
            }
        }

        private void DisposeGalleryImages()
        {
            foreach (GalleryItem item in galleryItemGroup1.Items)
            {
                try
                {
                    item.Image?.Dispose();
                }
                catch
                {
                }
            }
        }

        private GalleryItem AddImageToGallary(Image img, string filePath)
        {
            string fileName = Path.GetFileName(filePath);

            GalleryItem galleryItem = new(img, fileName, string.Empty)
            {
                Tag = filePath
            };

            galleryItem.ItemClick += (s, e) =>
            {
                galleryControl1.Gallery.SetItemCheck(galleryItem, true);
                UpdateSelectedPreview(galleryItem);
            };

            galleryItemGroup1.Items.Add(galleryItem);
            return galleryItem;
        }

        private void UpdateSelectedPreview(GalleryItem? item = null)
        {
            item ??= galleryControl1.Gallery.GetCheckedItem();

            if (item == null)
            {
                selectedFilePath = null;
                pe_Preview.Image?.Dispose();
                pe_Preview.Image = null;
                bsi_SelectedInfo.Caption = Resources.Form_Image_NoImageSelected;

                bbi_Copy.Enabled = false;
                bbi_Delete.Enabled = false;
                bbi_Open.Enabled = false;
                bbi_RotateLeft.Enabled = false;
                bbi_RotateRight.Enabled = false;
                return;
            }

            string? filePath = item.Tag?.ToString();
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                selectedFilePath = null;
                pe_Preview.Image?.Dispose();
                pe_Preview.Image = null;
                bsi_SelectedInfo.Caption = Resources.Form_Image_NoImageSelected;
                return;
            }

            selectedFilePath = filePath;

            try
            {
                using (FileStream fs = new(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (Image fullImg = Image.FromStream(fs, true, false))
                {
                    pe_Preview.Image?.Dispose();
                    pe_Preview.Image = new Bitmap(fullImg);

                    FileInfo fi = new(filePath);
                    string fileSizeStr = FormatFileSize(fi.Length);
                    bsi_SelectedInfo.Caption = $"{fi.Name} | {fullImg.Width}x{fullImg.Height} px | {fileSizeStr} | {fi.LastWriteTime:dd.MM.yyyy HH:mm}";
                }

                bbi_Copy.Enabled = true;
                bbi_Delete.Enabled = true;
                bbi_Open.Enabled = true;
                bbi_RotateLeft.Enabled = true;
                bbi_RotateRight.Enabled = true;
            }
            catch (Exception ex)
            {
                bsi_SelectedInfo.Caption = ex.Message;
            }
        }

        private static string FormatFileSize(long bytes)
        {
            if (bytes >= 1024 * 1024)
                return $"{bytes / (1024.0 * 1024.0):F2} MB";
            if (bytes >= 1024)
                return $"{bytes / 1024.0:F1} KB";
            return $"{bytes} B";
        }

        private void OpenSelectedImage()
        {
            if (!string.IsNullOrWhiteSpace(selectedFilePath) && File.Exists(selectedFilePath))
            {
                OpenImageFile(selectedFilePath);
            }
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
                XtraMessageBox.Show(
                    ex.Message,
                    Resources.Common_ErrorTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void OpenFolder()
        {
            try
            {
                string folder = CurrentFolderPath;
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                if (!string.IsNullOrWhiteSpace(selectedFilePath) && File.Exists(selectedFilePath))
                {
                    Process.Start(new ProcessStartInfo("explorer.exe", $"/select,\"{selectedFilePath}\"") { UseShellExecute = true });
                }
                else
                {
                    Process.Start(new ProcessStartInfo("explorer.exe", $"\"{folder}\"") { UseShellExecute = true });
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, Resources.Common_ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openFileDialog()
        {
            using OpenFileDialog dialog = new();
            dialog.Filter =
                Resources.Common_File_ImageFilter + "|" +
                Resources.Common_File_All;

            dialog.Multiselect = true;
            dialog.Title = Resources.Form_Image_OpenDialogTitle;

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            ImportFiles(dialog.FileNames);
        }

        private void ImportFiles(IEnumerable<string> filePaths)
        {
            string folderPath = CurrentFolderPath;
            if (string.IsNullOrWhiteSpace(folderPath))
                return;

            try
            {
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    ex.Message,
                    Resources.Common_ErrorTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string? lastCopied = null;
            int importedCount = 0;

            foreach (string fullPath in filePaths)
            {
                if (string.IsNullOrWhiteSpace(fullPath) || !File.Exists(fullPath))
                    continue;

                string ext = Path.GetExtension(fullPath);
                if (!SupportedExtensions.Contains(ext))
                    continue;

                try
                {
                    string fileName = Path.GetFileName(fullPath);
                    string destinationPath = GetUniqueFilePath(folderPath, fileName);

                    File.Copy(fullPath, destinationPath, true);
                    lastCopied = destinationPath;
                    importedCount++;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(
                        ex.Message,
                        Resources.Common_ErrorTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            if (importedCount > 0)
            {
                LoadGallaryImages(lastCopied);
            }
        }

        private void SaveClipboardImage()
        {
            string folderPath = CurrentFolderPath;
            if (string.IsNullOrWhiteSpace(folderPath))
                return;

            try
            {
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    ex.Message,
                    Resources.Common_ErrorTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // 1. Check if clipboard contains bitmap/image data (e.g. Snipping tool / Screenshot / Browser copy)
            if (Clipboard.ContainsImage())
            {
                try
                {
                    using Image? clipboardImage = Clipboard.GetImage();
                    if (clipboardImage != null)
                    {
                        string prefix = string.IsNullOrWhiteSpace(code) ? "IMG" : code;
                        string fileName = $"{prefix}_{DateTime.Now:yyyyMMdd_HHmmss_fff}.jpg";
                        string savePath = Path.Combine(folderPath, fileName);

                        using Bitmap bmp = new(clipboardImage);
                        bmp.Save(savePath, ImageFormat.Jpeg);

                        LoadGallaryImages(savePath);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(
                        ex.Message,
                        Resources.Common_ErrorTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }

            // 2. Check if clipboard contains files copied from Windows Explorer / Desktop
            if (Clipboard.ContainsFileDropList())
            {
                StringCollection? dropList = Clipboard.GetFileDropList();
                if (dropList != null && dropList.Count > 0)
                {
                    string? lastCopied = null;
                    int count = 0;

                    foreach (string? f in dropList)
                    {
                        if (!string.IsNullOrWhiteSpace(f) && File.Exists(f) && SupportedExtensions.Contains(Path.GetExtension(f)))
                        {
                            try
                            {
                                string dest = GetUniqueFilePath(folderPath, Path.GetFileName(f));
                                File.Copy(f, dest, true);
                                lastCopied = dest;
                                count++;
                            }
                            catch
                            {
                            }
                        }
                    }

                    if (count > 0)
                    {
                        LoadGallaryImages(lastCopied);
                        return;
                    }
                }
            }

            // 3. Neither image nor image files in clipboard
            XtraMessageBox.Show(
                Resources.Form_Image_NoImageInClipboard,
                Resources.Common_Attention,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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

        private GalleryItem? GetSelectedGalleryItem()
        {
            return galleryControl1.Gallery.GetCheckedItem();
        }

        private void DeleteSelectedImage()
        {
            GalleryItem? item = GetSelectedGalleryItem();
            if (item == null)
                return;

            string? filePath = item.Tag?.ToString();
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
                return;

            if (XtraMessageBox.Show(
                Resources.Common_DeleteConfirm,
                Resources.Common_Attention,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) != DialogResult.OK)
                return;

            try
            {
                // Release image in preview before deleting to prevent file locking!
                pe_Preview.Image?.Dispose();
                pe_Preview.Image = null;
                selectedFilePath = null;

                File.Delete(filePath);

                LoadGallaryImages();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    ex.Message,
                    Resources.Common_ErrorTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CopySelectedImageToClipboard()
        {
            GalleryItem? item = GetSelectedGalleryItem();
            if (item == null || string.IsNullOrWhiteSpace(selectedFilePath) || !File.Exists(selectedFilePath))
            {
                XtraMessageBox.Show(
                    Resources.Form_Product_Message_NoGalleryImage,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            try
            {
                DataObject data = new();
                if (pe_Preview.Image != null)
                    data.SetImage(pe_Preview.Image);
                else if (item.Image != null)
                    data.SetImage(item.Image);

                data.SetFileDropList(new StringCollection { selectedFilePath });
                Clipboard.SetDataObject(data, true);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    ex.Message,
                    Resources.Common_ErrorTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void RotateSelectedImage(RotateFlipType rotateFlipType)
        {
            if (string.IsNullOrWhiteSpace(selectedFilePath) || !File.Exists(selectedFilePath))
                return;

            try
            {
                pe_Preview.Image?.Dispose();
                pe_Preview.Image = null;

                byte[] rotatedBytes;
                using (FileStream fs = new(selectedFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (Image original = Image.FromStream(fs, true, false))
                {
                    original.RotateFlip(rotateFlipType);
                    using MemoryStream ms = new();
                    original.Save(ms, GetImageFormatFromExtension(selectedFilePath));
                    rotatedBytes = ms.ToArray();
                }

                File.WriteAllBytes(selectedFilePath, rotatedBytes);
                LoadGallaryImages(selectedFilePath);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    string.Format(Resources.Form_Image_RotateError, ex.Message),
                    Resources.Common_ErrorTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void bbi_Paste_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveClipboardImage();
        }

        private void bbi_Add_ItemClick(object sender, ItemClickEventArgs e)
        {
            openFileDialog();
        }

        private void bbi_Copy_ItemClick(object sender, ItemClickEventArgs e)
        {
            CopySelectedImageToClipboard();
        }

        private void bbi_Delete_ItemClick(object sender, ItemClickEventArgs e)
        {
            DeleteSelectedImage();
        }

        private void bbi_Open_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenSelectedImage();
        }

        private void bbi_OpenFolder_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFolder();
        }

        private void bbi_Refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadGallaryImages(selectedFilePath);
        }

        private void bbi_TogglePreview_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            splitContainerControl1.PanelVisibility = bbi_TogglePreview.Checked
                ? SplitPanelVisibility.Both
                : SplitPanelVisibility.Panel1;
        }

        private void bbi_RotateLeft_ItemClick(object sender, ItemClickEventArgs e)
        {
            RotateSelectedImage(RotateFlipType.Rotate270FlipNone);
        }

        private void bbi_RotateRight_ItemClick(object sender, ItemClickEventArgs e)
        {
            RotateSelectedImage(RotateFlipType.Rotate90FlipNone);
        }

        private void bbi_ThumbSmall_ItemClick(object sender, ItemClickEventArgs e)
        {
            galleryControl1.Gallery.ImageSize = new Size(120, 160);
        }

        private void bbi_ThumbMedium_ItemClick(object sender, ItemClickEventArgs e)
        {
            galleryControl1.Gallery.ImageSize = new Size(180, 240);
        }

        private void bbi_ThumbLarge_ItemClick(object sender, ItemClickEventArgs e)
        {
            galleryControl1.Gallery.ImageSize = new Size(260, 350);
        }

        private void FormImage_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void FormImage_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                if (e.Data.GetData(DataFormats.FileDrop) is string[] files && files.Length > 0)
                {
                    ImportFiles(files);
                }
            }
        }

        private void popupMenu_Gallery_BeforePopup(object sender, CancelEventArgs e)
        {
            bbi_Paste.Enabled = Clipboard.ContainsImage() || Clipboard.ContainsFileDropList();

            bool hasSelectedItem = galleryControl1.Gallery.GetCheckedItemsCount() > 0;
            bbi_Copy.Enabled = hasSelectedItem;
            bbi_Delete.Enabled = hasSelectedItem;
            bbi_Open.Enabled = hasSelectedItem;
            bbi_RotateLeft.Enabled = hasSelectedItem;
            bbi_RotateRight.Enabled = hasSelectedItem;
        }

        private void galleryControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                RibbonHitInfo hitInfo = galleryControl1.Gallery.CalcHitInfo(e.Location);

                if (hitInfo.GalleryItem != null)
                {
                    galleryControl1.Gallery.SetItemCheck(hitInfo.GalleryItem, true);
                    UpdateSelectedPreview(hitInfo.GalleryItem);
                }

                popupMenu_Gallery.ShowPopup(Control.MousePosition);
            }
        }

        private void galleryControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RibbonHitInfo hitInfo = galleryControl1.CalcHitInfo(e.Location);

            if (hitInfo.InGalleryItem && hitInfo.GalleryItem != null)
            {
                string? filePath = hitInfo.GalleryItem.Tag?.ToString();
                if (!string.IsNullOrWhiteSpace(filePath))
                    OpenImageFile(filePath);
            }
        }

        private void pe_Preview_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                popupMenu_Gallery.ShowPopup(Control.MousePosition);
            }
        }

        private void pe_Preview_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenSelectedImage();
        }
    }
}
