using DevExpress.XtraBars.Ribbon;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormImage : RibbonForm
    {
        EfMethods efMethods = new();
        string imageFolder;
        string code;

        GalleryItemGroup galleryItemGroup1 = new();

        public FormImage()
        {
            InitializeComponent();

            SettingStore settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);
            if (CustomExtensions.DirectoryExist(settingStore.ImageFolder))
                imageFolder = settingStore.ImageFolder;

            galleryControl1.Gallery.Groups.Add(galleryItemGroup1);
        }

        public FormImage(string code)
            : this()
        {
            this.code = code;

            LoadGallaryImages();

            //galleryControl1.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            //galleryControl1.Gallery.ImageSize = new Size(120, 90);
            //galleryControl1.Gallery.ItemCheckMode = ItemCheckMode.SingleCheck;

            //var cb = new ContextButton
            //{
            //    Name = "Delete",
            //    Alignment = ContextItemAlignment.MiddleBottom,
            //    Visibility = ContextItemVisibility.Visible,
            //    Caption = "Sil"
            //};
            //cb.AppearanceNormal.BackColor = Color.White;
            //cb.AppearanceHover.BackColor = Color.Red;
            //cb.Click += (s, e) =>
            //{
            //    var asd = galleryControl1.Gallery.GetCheckedItem();
            //    //MessageBox.Show(asd?.Description + asd?.Caption + asd?.Tag + asd?.AccessibleName);
            //    galleryItemGroup1.Items.Remove(asd);
            //};

            //galleryControl1.Gallery.ContextButtons.Add(cb);

            //var options = galleryControl1.Gallery.ContextButtonOptions;
            //options.DisplayArea = ContextItemDisplayArea.Image;
        }

        private void LoadGallaryImages()
        {
            string folderPath = Path.Combine(imageFolder, code);

            var filters = new string[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp", "svg" };
            List<Image> images = GetFilesFrom(folderPath, filters, SearchOption.TopDirectoryOnly);

            galleryItemGroup1.Items.Clear();

            foreach (var img in images)
                AddImageToGallary(img);
        }

        public static List<Image> GetFilesFrom(String folderPath, String[] filters, SearchOption searchOption)
        {
            List<Image> filesFound = new();

            foreach (var filter in filters)
            {
                if (CustomExtensions.DirectoryExist(folderPath))
                {
                    string[] fileNames = Directory.GetFiles(folderPath, String.Format("*.{0}", filter), searchOption);

                    foreach (var fileName in fileNames)
                    {
                        string fullPath = Path.Combine(folderPath, fileName);

                        if (File.Exists(fullPath))
                            using (var file = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                            {
                                Image img = Image.FromStream(file);
                                img.Tag = fullPath;
                                filesFound.Add(img);
                            }
                    }
                }
            }

            return filesFound;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            openFileDialog();
        }

        private void openFileDialog()
        {
            OpenFileDialog dialog = new();
            dialog.Filter =
                        "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" +
                        "All files (*.*)|*.*";

            dialog.Multiselect = true;
            dialog.Title = "Foxoft üçün şəkil seçin.";

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (string fullPath in dialog.FileNames)
                {
                    Image.GetThumbnailImageAbort myCallback = new(ThumbnailCallback);

                    using FileStream fs = new(fullPath, FileMode.Open, FileAccess.Read);

                    Image img = Image.FromStream(fs, true, false);

                    if (img is not null)
                    {
                        string name = Path.GetFileName(fullPath);
                        string folderPath = Path.Combine(imageFolder, code);
                        string filePath = Path.Combine(imageFolder, code, name);

                        if (!Directory.Exists(folderPath))
                            Directory.CreateDirectory(folderPath);

                        img.Save(filePath);
                        GC.Collect();
                        img.Tag = filePath;
                    }
                }
            }
        }

        private void AddImageToGallary(Image img)
        {
            GalleryItem galleryItem = new(img, "sekil", "");

            galleryItem.ItemClick += (s, e) =>
            {
                Process p = new();
                string fullPath = img.Tag?.ToString();
                p.StartInfo = new ProcessStartInfo(fullPath) { UseShellExecute = true };
                p.Start();
            };

            galleryItemGroup1.Items.Add(galleryItem);
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        private void btn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openFileDialog();
            LoadGallaryImages();
        }

        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var item = galleryControl1.Gallery.GetCheckedItem();
            if (item != null)
            {
                File.Delete(item.Image.Tag?.ToString());
                LoadGallaryImages();
            }
        }
    }
}
