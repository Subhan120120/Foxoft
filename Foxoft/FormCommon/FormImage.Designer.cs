using DevExpress.Utils.Drawing;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon.Gallery;
using Foxoft.Properties;
using System.Drawing;

namespace Foxoft
{
    partial class FormImage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImage));
            galleryControl1 = new DevExpress.XtraBars.Ribbon.GalleryControl();
            galleryControlClient1 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            btn_Add = new BarButtonItem();
            btn_Delete = new BarButtonItem();
            BBI_GalleryLoad = new BarButtonItem();
            BBI_GalleryDelete = new BarButtonItem();
            BBI_GalleryPaste = new BarButtonItem();
            BBI_GalleryCopy = new BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            popupMenu_Gallery = new PopupMenu(components);
            ((System.ComponentModel.ISupportInitialize)galleryControl1).BeginInit();
            galleryControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu_Gallery).BeginInit();
            SuspendLayout();
            // 
            // galleryControl1
            // 
            galleryControl1.Controls.Add(galleryControlClient1);
            // 
            // 
            // 
            galleryControl1.Gallery.ImageSize = new Size(210, 297);
            galleryControl1.Gallery.ItemCheckMode = ItemCheckMode.SingleCheck;
            galleryControl1.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            galleryControl1.Gallery.ShowGroupCaption = false;
            galleryControl1.Location = new Point(12, 12);
            galleryControl1.Name = "galleryControl1";
            galleryControl1.Size = new Size(750, 231);
            galleryControl1.StyleController = layoutControl1;
            galleryControl1.TabIndex = 0;
            galleryControl1.Text = "galleryControl1";
            galleryControl1.MouseDoubleClick += galleryControl1_MouseDoubleClick;
            galleryControl1.MouseDown += galleryControl1_MouseDown;
            // 
            // galleryControlClient1
            // 
            galleryControlClient1.GalleryControl = galleryControl1;
            galleryControlClient1.Location = new Point(2, 2);
            galleryControlClient1.Size = new Size(729, 227);
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(galleryControl1);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 158);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(692, 252, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(774, 255);
            layoutControl1.TabIndex = 1;
            layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1 });
            Root.Name = "Root";
            Root.Size = new Size(774, 255);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = galleryControl1;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(754, 235);
            layoutControlItem1.TextVisible = false;
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new BarItem[] { ribbonControl1.ExpandCollapseItem, btn_Add, btn_Delete, BBI_GalleryLoad, BBI_GalleryDelete, BBI_GalleryPaste, BBI_GalleryCopy });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 7;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(774, 158);
            // 
            // btn_Add
            // 
            btn_Add.Caption = Resources.Common_New;
            btn_Add.Id = 1;
            btn_Add.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_Add.ImageOptions.SvgImage");
            btn_Add.Name = "btn_Add";
            btn_Add.ItemClick += btn_Add_ItemClick;
            // 
            // btn_Delete
            // 
            btn_Delete.Caption = Resources.Common_Delete;
            btn_Delete.Id = 2;
            btn_Delete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_Delete.ImageOptions.SvgImage");
            btn_Delete.Name = "btn_Delete";
            btn_Delete.ItemClick += btn_Delete_ItemClick;
            // 
            // BBI_GalleryLoad
            // 
            BBI_GalleryLoad.Caption = Resources.Common_Load;
            BBI_GalleryLoad.Id = 3;
            BBI_GalleryLoad.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_GalleryLoad.ImageOptions.SvgImage");
            BBI_GalleryLoad.Name = "BBI_GalleryLoad";
            BBI_GalleryLoad.ItemClick += BBI_GalleryLoad_ItemClick;
            // 
            // BBI_GalleryDelete
            // 
            BBI_GalleryDelete.Caption = Resources.Common_Delete;
            BBI_GalleryDelete.Id = 4;
            BBI_GalleryDelete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_GalleryDelete.ImageOptions.SvgImage");
            BBI_GalleryDelete.Name = "BBI_GalleryDelete";
            BBI_GalleryDelete.ItemClick += BBI_GalleryDelete_ItemClick;
            // 
            // BBI_GalleryPaste
            // 
            BBI_GalleryPaste.Caption = Resources.Common_Paste;
            BBI_GalleryPaste.Id = 5;
            BBI_GalleryPaste.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_GalleryPaste.ImageOptions.SvgImage");
            BBI_GalleryPaste.Name = "BBI_GalleryPaste";
            BBI_GalleryPaste.ItemClick += BBI_GalleryPaste_ItemClick;
            // 
            // BBI_GalleryCopy
            // 
            BBI_GalleryCopy.Caption = Resources.Common_Copy;
            BBI_GalleryCopy.Id = 6;
            BBI_GalleryCopy.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_GalleryCopy.ImageOptions.SvgImage");
            BBI_GalleryCopy.Name = "BBI_GalleryCopy";
            BBI_GalleryCopy.ItemClick += BBI_GalleryCopy_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = Resources.Form_Image_RibbonPage_Main;
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(btn_Add);
            ribbonPageGroup1.ItemLinks.Add(btn_Delete);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = Resources.Common_Operations;
            // 
            // popupMenu_Gallery
            // 
            popupMenu_Gallery.ItemLinks.Add(BBI_GalleryCopy);
            popupMenu_Gallery.ItemLinks.Add(BBI_GalleryPaste);
            popupMenu_Gallery.ItemLinks.Add(BBI_GalleryLoad);
            popupMenu_Gallery.ItemLinks.Add(BBI_GalleryDelete);
            popupMenu_Gallery.Name = "popupMenu_Gallery";
            popupMenu_Gallery.Ribbon = ribbonControl1;
            popupMenu_Gallery.BeforePopup += popupMenu_Gallery_BeforePopup;
            // 
            // FormImage
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(774, 413);
            Controls.Add(layoutControl1);
            Controls.Add(ribbonControl1);
            Name = "FormImage";
            Ribbon = ribbonControl1;
            Text = "Images";
            Load += FormImage_Load;
            ((System.ComponentModel.ISupportInitialize)galleryControl1).EndInit();
            galleryControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)popupMenu_Gallery).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.GalleryControl galleryControl1;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btn_Add;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btn_Delete;

        private DevExpress.XtraBars.BarButtonItem BBI_GalleryLoad;
        private DevExpress.XtraBars.BarButtonItem BBI_GalleryDelete;
        private DevExpress.XtraBars.BarButtonItem BBI_GalleryPaste;
        private DevExpress.XtraBars.BarButtonItem BBI_GalleryCopy;
        private DevExpress.XtraBars.PopupMenu popupMenu_Gallery;
    }
}