using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.Gallery;
using Foxoft.Properties;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

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
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormImage));

            ribbonControl1 = new RibbonControl();
            bbi_Paste = new BarButtonItem();
            bbi_Add = new BarButtonItem();
            bbi_Copy = new BarButtonItem();
            bbi_Delete = new BarButtonItem();
            bbi_Open = new BarButtonItem();
            bbi_OpenFolder = new BarButtonItem();
            bbi_Refresh = new BarButtonItem();
            bbi_TogglePreview = new BarCheckItem();
            bbi_RotateLeft = new BarButtonItem();
            bbi_RotateRight = new BarButtonItem();
            bsi_ThumbnailSize = new BarSubItem();
            bbi_ThumbSmall = new BarButtonItem();
            bbi_ThumbMedium = new BarButtonItem();
            bbi_ThumbLarge = new BarButtonItem();
            bsi_ImageCount = new BarStaticItem();
            bsi_SelectedInfo = new BarStaticItem();
            bsi_DocNum = new BarStaticItem();

            ribbonPage1 = new RibbonPage();
            ribbonPageGroup_Operations = new RibbonPageGroup();
            ribbonPageGroup_View = new RibbonPageGroup();
            ribbonPageGroup_Tools = new RibbonPageGroup();

            ribbonStatusBar1 = new RibbonStatusBar();
            popupMenu_Gallery = new PopupMenu(components);

            splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            galleryControl1 = new GalleryControl();
            galleryControlClient1 = new GalleryControlClient();
            pe_Preview = new DevExpress.XtraEditors.PictureEdit();

            ((ISupportInitialize)ribbonControl1).BeginInit();
            ((ISupportInitialize)popupMenu_Gallery).BeginInit();
            ((ISupportInitialize)splitContainerControl1).BeginInit();
            splitContainerControl1.SuspendLayout();
            ((ISupportInitialize)galleryControl1).BeginInit();
            galleryControl1.SuspendLayout();
            ((ISupportInitialize)pe_Preview.Properties).BeginInit();
            SuspendLayout();

            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new BarItem[] {
                ribbonControl1.ExpandCollapseItem,
                bbi_Paste,
                bbi_Add,
                bbi_Copy,
                bbi_Delete,
                bbi_Open,
                bbi_OpenFolder,
                bbi_Refresh,
                bbi_TogglePreview,
                bbi_RotateLeft,
                bbi_RotateRight,
                bsi_ThumbnailSize,
                bbi_ThumbSmall,
                bbi_ThumbMedium,
                bbi_ThumbLarge,
                bsi_ImageCount,
                bsi_SelectedInfo,
                bsi_DocNum
            });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 18;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new RibbonPage[] { ribbonPage1 });
            ribbonControl1.ShowApplicationButton = DefaultBoolean.False;
            ribbonControl1.Size = new Size(1100, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            ribbonControl1.ToolbarLocation = RibbonQuickAccessToolbarLocation.Hidden;

            // 
            // bbi_Paste
            // 
            bbi_Paste.Caption = Resources.Common_Paste;
            bbi_Paste.Id = 1;
            bbi_Paste.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_GalleryPaste.ImageOptions.SvgImage");
            bbi_Paste.ItemShortcut = new BarShortcut(Keys.Control | Keys.V);
            bbi_Paste.Name = "bbi_Paste";
            bbi_Paste.RibbonStyle = RibbonItemStyles.Large | RibbonItemStyles.SmallWithText;
            bbi_Paste.ItemClick += bbi_Paste_ItemClick;

            // 
            // bbi_Add
            // 
            bbi_Add.Caption = Resources.Common_Load;
            bbi_Add.Id = 2;
            bbi_Add.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_Add.ImageOptions.SvgImage");
            bbi_Add.ItemShortcut = new BarShortcut(Keys.Control | Keys.O);
            bbi_Add.Name = "bbi_Add";
            bbi_Add.RibbonStyle = RibbonItemStyles.Large | RibbonItemStyles.SmallWithText;
            bbi_Add.ItemClick += bbi_Add_ItemClick;

            // 
            // bbi_Copy
            // 
            bbi_Copy.Caption = Resources.Common_Copy;
            bbi_Copy.Id = 3;
            bbi_Copy.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_GalleryCopy.ImageOptions.SvgImage");
            bbi_Copy.ItemShortcut = new BarShortcut(Keys.Control | Keys.C);
            bbi_Copy.Name = "bbi_Copy";
            bbi_Copy.ItemClick += bbi_Copy_ItemClick;

            // 
            // bbi_Delete
            // 
            bbi_Delete.Caption = Resources.Common_Delete;
            bbi_Delete.Id = 4;
            bbi_Delete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_Delete.ImageOptions.SvgImage");
            bbi_Delete.ItemShortcut = new BarShortcut(Keys.Delete);
            bbi_Delete.Name = "bbi_Delete";
            bbi_Delete.ItemClick += bbi_Delete_ItemClick;

            // 
            // bbi_Open
            // 
            bbi_Open.Caption = Resources.Common_Open;
            bbi_Open.Id = 5;
            bbi_Open.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbi_Open.ImageOptions.SvgImage");
            bbi_Open.ItemShortcut = new BarShortcut(Keys.Enter);
            bbi_Open.Name = "bbi_Open";
            bbi_Open.RibbonStyle = RibbonItemStyles.Large | RibbonItemStyles.SmallWithText;
            bbi_Open.ItemClick += bbi_Open_ItemClick;

            // 
            // bbi_OpenFolder
            // 
            bbi_OpenFolder.Caption = Resources.Common_OpenFolder;
            bbi_OpenFolder.Id = 6;
            bbi_OpenFolder.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbi_OpenFolder.ImageOptions.SvgImage");
            bbi_OpenFolder.ItemShortcut = new BarShortcut(Keys.Control | Keys.E);
            bbi_OpenFolder.Name = "bbi_OpenFolder";
            bbi_OpenFolder.ItemClick += bbi_OpenFolder_ItemClick;

            // 
            // bbi_Refresh
            // 
            bbi_Refresh.Caption = Resources.Common_Refresh;
            bbi_Refresh.Id = 7;
            bbi_Refresh.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbi_Refresh.ImageOptions.SvgImage");
            bbi_Refresh.ItemShortcut = new BarShortcut(Keys.F5);
            bbi_Refresh.Name = "bbi_Refresh";
            bbi_Refresh.ItemClick += bbi_Refresh_ItemClick;

            // 
            // bbi_TogglePreview
            // 
            bbi_TogglePreview.BindableChecked = true;
            bbi_TogglePreview.Caption = Resources.Common_Preview;
            bbi_TogglePreview.Checked = true;
            bbi_TogglePreview.Id = 8;
            bbi_TogglePreview.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbi_TogglePreview.ImageOptions.SvgImage");
            bbi_TogglePreview.Name = "bbi_TogglePreview";
            bbi_TogglePreview.CheckedChanged += bbi_TogglePreview_CheckedChanged;

            // 
            // bbi_RotateLeft
            // 
            bbi_RotateLeft.Caption = Resources.Form_Image_RotateLeft;
            bbi_RotateLeft.Id = 9;
            bbi_RotateLeft.ItemShortcut = new BarShortcut(Keys.Control | Keys.L);
            bbi_RotateLeft.Name = "bbi_RotateLeft";
            bbi_RotateLeft.ItemClick += bbi_RotateLeft_ItemClick;

            // 
            // bbi_RotateRight
            // 
            bbi_RotateRight.Caption = Resources.Form_Image_RotateRight;
            bbi_RotateRight.Id = 10;
            bbi_RotateRight.ItemShortcut = new BarShortcut(Keys.Control | Keys.R);
            bbi_RotateRight.Name = "bbi_RotateRight";
            bbi_RotateRight.ItemClick += bbi_RotateRight_ItemClick;

            // 
            // bsi_ThumbnailSize
            // 
            bsi_ThumbnailSize.Caption = Resources.Form_Image_ThumbnailSize;
            bsi_ThumbnailSize.Id = 11;
            bsi_ThumbnailSize.LinksPersistInfo.AddRange(new LinkPersistInfo[] {
                new LinkPersistInfo(bbi_ThumbSmall),
                new LinkPersistInfo(bbi_ThumbMedium),
                new LinkPersistInfo(bbi_ThumbLarge)
            });
            bsi_ThumbnailSize.Name = "bsi_ThumbnailSize";

            // 
            // bbi_ThumbSmall
            // 
            bbi_ThumbSmall.Caption = Resources.Form_Image_ThumbnailSmall;
            bbi_ThumbSmall.Id = 12;
            bbi_ThumbSmall.Name = "bbi_ThumbSmall";
            bbi_ThumbSmall.ItemClick += bbi_ThumbSmall_ItemClick;

            // 
            // bbi_ThumbMedium
            // 
            bbi_ThumbMedium.Caption = Resources.Form_Image_ThumbnailMedium;
            bbi_ThumbMedium.Id = 13;
            bbi_ThumbMedium.Name = "bbi_ThumbMedium";
            bbi_ThumbMedium.ItemClick += bbi_ThumbMedium_ItemClick;

            // 
            // bbi_ThumbLarge
            // 
            bbi_ThumbLarge.Caption = Resources.Form_Image_ThumbnailLarge;
            bbi_ThumbLarge.Id = 14;
            bbi_ThumbLarge.Name = "bbi_ThumbLarge";
            bbi_ThumbLarge.ItemClick += bbi_ThumbLarge_ItemClick;

            // 
            // bsi_ImageCount
            // 
            bsi_ImageCount.Caption = "";
            bsi_ImageCount.Id = 15;
            bsi_ImageCount.Name = "bsi_ImageCount";

            // 
            // bsi_SelectedInfo
            // 
            bsi_SelectedInfo.Caption = "";
            bsi_SelectedInfo.Id = 16;
            bsi_SelectedInfo.Name = "bsi_SelectedInfo";

            // 
            // bsi_DocNum
            // 
            bsi_DocNum.Alignment = BarItemLinkAlignment.Right;
            bsi_DocNum.Caption = "";
            bsi_DocNum.Id = 17;
            bsi_DocNum.Name = "bsi_DocNum";

            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new RibbonPageGroup[] {
                ribbonPageGroup_Operations,
                ribbonPageGroup_View,
                ribbonPageGroup_Tools
            });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = Resources.Form_Image_RibbonPage_Main;

            // 
            // ribbonPageGroup_Operations
            // 
            ribbonPageGroup_Operations.ItemLinks.Add(bbi_Paste);
            ribbonPageGroup_Operations.ItemLinks.Add(bbi_Add);
            ribbonPageGroup_Operations.ItemLinks.Add(bbi_Copy);
            ribbonPageGroup_Operations.ItemLinks.Add(bbi_Delete);
            ribbonPageGroup_Operations.Name = "ribbonPageGroup_Operations";
            ribbonPageGroup_Operations.Text = Resources.Common_Operations;

            // 
            // ribbonPageGroup_View
            // 
            ribbonPageGroup_View.ItemLinks.Add(bbi_Open);
            ribbonPageGroup_View.ItemLinks.Add(bbi_OpenFolder);
            ribbonPageGroup_View.ItemLinks.Add(bbi_Refresh);
            ribbonPageGroup_View.ItemLinks.Add(bbi_TogglePreview);
            ribbonPageGroup_View.Name = "ribbonPageGroup_View";
            ribbonPageGroup_View.Text = Resources.Common_View;

            // 
            // ribbonPageGroup_Tools
            // 
            ribbonPageGroup_Tools.ItemLinks.Add(bbi_RotateLeft);
            ribbonPageGroup_Tools.ItemLinks.Add(bbi_RotateRight);
            ribbonPageGroup_Tools.ItemLinks.Add(bsi_ThumbnailSize);
            ribbonPageGroup_Tools.Name = "ribbonPageGroup_Tools";
            ribbonPageGroup_Tools.Text = Resources.Common_Tools;

            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.ItemLinks.Add(bsi_ImageCount);
            ribbonStatusBar1.ItemLinks.Add(bsi_SelectedInfo);
            ribbonStatusBar1.ItemLinks.Add(bsi_DocNum);
            ribbonStatusBar1.Location = new Point(0, 676);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new Size(1100, 24);

            // 
            // popupMenu_Gallery
            // 
            popupMenu_Gallery.ItemLinks.Add(bbi_Paste);
            popupMenu_Gallery.ItemLinks.Add(bbi_Copy);
            popupMenu_Gallery.ItemLinks.Add(bbi_Add);
            popupMenu_Gallery.ItemLinks.Add(bbi_Open);
            popupMenu_Gallery.ItemLinks.Add(bbi_RotateLeft);
            popupMenu_Gallery.ItemLinks.Add(bbi_RotateRight);
            popupMenu_Gallery.ItemLinks.Add(bbi_OpenFolder);
            popupMenu_Gallery.ItemLinks.Add(bbi_Delete);
            popupMenu_Gallery.ItemLinks.Add(bbi_Refresh);
            popupMenu_Gallery.Name = "popupMenu_Gallery";
            popupMenu_Gallery.Ribbon = ribbonControl1;
            popupMenu_Gallery.BeforePopup += popupMenu_Gallery_BeforePopup;

            // 
            // splitContainerControl1
            // 
            splitContainerControl1.Dock = DockStyle.Fill;
            splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            splitContainerControl1.Horizontal = true;
            splitContainerControl1.Location = new Point(0, 158);
            splitContainerControl1.Name = "splitContainerControl1";
            splitContainerControl1.Panel1.Controls.Add(galleryControl1);
            splitContainerControl1.Panel1.Text = "Panel_Gallery";
            splitContainerControl1.Panel2.Controls.Add(pe_Preview);
            splitContainerControl1.Panel2.Text = "Panel_Preview";
            splitContainerControl1.Size = new Size(1100, 518);
            splitContainerControl1.SplitterPosition = 520;
            splitContainerControl1.TabIndex = 1;

            // 
            // galleryControl1
            // 
            galleryControl1.AllowDrop = true;
            galleryControl1.Controls.Add(galleryControlClient1);
            galleryControl1.Dock = DockStyle.Fill;
            galleryControl1.Gallery.ImageSize = new Size(180, 240);
            galleryControl1.Gallery.ItemCheckMode = ItemCheckMode.SingleCheck;
            galleryControl1.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            galleryControl1.Gallery.ShowGroupCaption = false;
            galleryControl1.Gallery.ShowItemText = true;
            galleryControl1.Location = new Point(0, 0);
            galleryControl1.Name = "galleryControl1";
            galleryControl1.Size = new Size(520, 518);
            galleryControl1.TabIndex = 0;
            galleryControl1.Text = "galleryControl1";
            galleryControl1.DragDrop += FormImage_DragDrop;
            galleryControl1.DragEnter += FormImage_DragEnter;
            galleryControl1.MouseDoubleClick += galleryControl1_MouseDoubleClick;
            galleryControl1.MouseDown += galleryControl1_MouseDown;

            // 
            // galleryControlClient1
            // 
            galleryControlClient1.GalleryControl = galleryControl1;
            galleryControlClient1.Location = new Point(2, 2);
            galleryControlClient1.Size = new Size(499, 514);

            // 
            // pe_Preview
            // 
            pe_Preview.AllowDrop = true;
            pe_Preview.Dock = DockStyle.Fill;
            pe_Preview.Location = new Point(0, 0);
            pe_Preview.MenuManager = ribbonControl1;
            pe_Preview.Name = "pe_Preview";
            pe_Preview.Properties.AllowScrollViaMouseDrag = true;
            pe_Preview.Properties.NullText = Resources.Form_Image_NoImageSelected;
            pe_Preview.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Never;
            pe_Preview.Properties.ShowScrollBars = true;
            pe_Preview.Properties.ShowZoomSubMenu = DefaultBoolean.True;
            pe_Preview.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            pe_Preview.Size = new Size(570, 518);
            pe_Preview.TabIndex = 0;
            pe_Preview.DragDrop += FormImage_DragDrop;
            pe_Preview.DragEnter += FormImage_DragEnter;
            pe_Preview.MouseDoubleClick += pe_Preview_MouseDoubleClick;
            pe_Preview.MouseDown += pe_Preview_MouseDown;

            // 
            // FormImage
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 700);
            Controls.Add(splitContainerControl1);
            Controls.Add(ribbonStatusBar1);
            Controls.Add(ribbonControl1);
            KeyPreview = true;
            Name = "FormImage";
            Ribbon = ribbonControl1;
            StartPosition = FormStartPosition.CenterParent;
            StatusBar = ribbonStatusBar1;
            Text = Resources.Form_Image_Caption;
            Load += FormImage_Load;
            DragDrop += FormImage_DragDrop;
            DragEnter += FormImage_DragEnter;
            KeyDown += FormImage_KeyDown;

            ((ISupportInitialize)ribbonControl1).EndInit();
            ((ISupportInitialize)popupMenu_Gallery).EndInit();
            ((ISupportInitialize)splitContainerControl1).EndInit();
            splitContainerControl1.ResumeLayout(false);
            ((ISupportInitialize)galleryControl1).EndInit();
            galleryControl1.ResumeLayout(false);
            ((ISupportInitialize)pe_Preview.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RibbonControl ribbonControl1;
        private RibbonPage ribbonPage1;
        private RibbonPageGroup ribbonPageGroup_Operations;
        private RibbonPageGroup ribbonPageGroup_View;
        private RibbonPageGroup ribbonPageGroup_Tools;
        private RibbonStatusBar ribbonStatusBar1;

        private BarButtonItem bbi_Paste;
        private BarButtonItem bbi_Add;
        private BarButtonItem bbi_Copy;
        private BarButtonItem bbi_Delete;
        private BarButtonItem bbi_Open;
        private BarButtonItem bbi_OpenFolder;
        private BarButtonItem bbi_Refresh;
        private BarCheckItem bbi_TogglePreview;
        private BarButtonItem bbi_RotateLeft;
        private BarButtonItem bbi_RotateRight;
        private BarSubItem bsi_ThumbnailSize;
        private BarButtonItem bbi_ThumbSmall;
        private BarButtonItem bbi_ThumbMedium;
        private BarButtonItem bbi_ThumbLarge;

        private BarStaticItem bsi_ImageCount;
        private BarStaticItem bsi_SelectedInfo;
        private BarStaticItem bsi_DocNum;

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private GalleryControl galleryControl1;
        private GalleryControlClient galleryControlClient1;
        private DevExpress.XtraEditors.PictureEdit pe_Preview;
        private PopupMenu popupMenu_Gallery;
    }
}