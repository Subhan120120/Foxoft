using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Mvvm.Native;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using DevExpress.XtraEditors;
using Foxoft.Models;

namespace Foxoft
{
    public partial class FormImage : XtraForm
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
        }

        public FormImage(string code)
            : this()
        {
            code = code;
            string folderPath = imageFolder + @"\" + code;

            var filters = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp", "svg" };
            List<Image> images = GetFilesFrom(folderPath, filters, SearchOption.TopDirectoryOnly);

            galleryControl1.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            galleryControl1.Gallery.ImageSize = new Size(120, 90);
            galleryControl1.Gallery.Groups.Add(galleryItemGroup1);

            //var cb = new ContextButton
            //{
            //    Name = "Move",
            //    Alignment = ContextItemAlignment.Center,
            //    Visibility = ContextItemVisibility.Visible,
            //    Caption = "Moooov"
            //};
            //cb.AppearanceNormal.BackColor = Color.White;
            //cb.AppearanceHover.BackColor = Color.Red;
            //galleryControl1.Gallery.ContextButtons.Add(cb);
            //var options = galleryControl1.Gallery.ContextButtonOptions;
            //options.DisplayArea = ContextItemDisplayArea.Image;


            foreach (var img in images)
            {
                GalleryItem galleryItem = new GalleryItem(img, "sekil", "");

                galleryItem.ItemClick += (s, e) =>
                {
                    Process p = new Process();
                    string fullPath = img.Tag?.ToString();
                    p.StartInfo = new ProcessStartInfo(fullPath) { UseShellExecute = true };
                    p.Start();
                };

                galleryItemGroup1.Items.Add(galleryItem);
            }
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

            //dialog.Multiselect = true;
            dialog.Title = "Foxoft üçün şəkil seçin.";

            DialogResult dr = dialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                foreach (String fullPath in dialog.FileNames)
                {
                    try
                    {
                        Image.GetThumbnailImageAbort myCallback = new(ThumbnailCallback);
                        //Image myThumbnail = myBitmap.GetThumbnailImage(300, 300, myCallback, IntPtr.Zero);

                        using (FileStream fs = new(fullPath, FileMode.Open, FileAccess.Read))
                        {
                            using (Image img = Image.FromStream(fs, true, false))
                            {
                                if (img is not null)
                                {
                                    string ext = Path.GetExtension(fullPath);
                                    string name = Path.GetFileName(fullPath);

                                    string folderPath = imageFolder + @"\" + code;

                                    img.Save(folderPath);
                                    GC.Collect();
                                }

                                img.Tag = fullPath;
                                AddImageToGallary(img);
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

        private void AddImageToGallary(Image img)
        {
            GalleryItem galleryItem = new GalleryItem(img, "sekil", "");

            galleryItem.ItemClick += (s, e) =>
            {
                Process p = new Process();
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
    }
}
