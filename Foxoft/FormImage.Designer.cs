using DevExpress.Utils.Drawing;
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImage));
            galleryControl1 = new DevExpress.XtraBars.Ribbon.GalleryControl();
            galleryControlClient1 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            btn_Add = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            btn_Delete = new DevExpress.XtraEditors.SimpleButton();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)galleryControl1).BeginInit();
            galleryControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            SuspendLayout();
            // 
            // galleryControl1
            // 
            galleryControl1.Controls.Add(galleryControlClient1);
            // 
            // 
            // 
            galleryControl1.Gallery.ImageSize = new Size(120, 90);
            galleryControl1.Gallery.ItemCheckMode = ItemCheckMode.SingleCheck;
            galleryControl1.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            galleryControl1.Gallery.ShowGroupCaption = false;
            galleryControl1.Location = new Point(12, 12);
            galleryControl1.Name = "galleryControl1";
            galleryControl1.Size = new Size(620, 208);
            galleryControl1.StyleController = layoutControl1;
            galleryControl1.TabIndex = 0;
            galleryControl1.Text = "galleryControl1";
            // 
            // galleryControlClient1
            // 
            galleryControlClient1.GalleryControl = galleryControl1;
            galleryControlClient1.Location = new Point(2, 2);
            galleryControlClient1.Size = new Size(599, 204);
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(btn_Delete);
            layoutControl1.Controls.Add(btn_Add);
            layoutControl1.Controls.Add(galleryControl1);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(692, 252, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(644, 297);
            layoutControl1.TabIndex = 1;
            layoutControl1.Text = "layoutControl1";
            // 
            // btn_Add
            // 
            btn_Add.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_Add.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_Add.ImageOptions.SvgImage");
            btn_Add.Location = new Point(558, 224);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new Size(74, 61);
            btn_Add.StyleController = layoutControl1;
            btn_Add.TabIndex = 2;
            btn_Add.Text = "btn_Add";
            btn_Add.Click += btn_Add_Click;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, emptySpaceItem1, layoutControlItem3 });
            Root.Name = "Root";
            Root.Size = new Size(644, 297);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = galleryControl1;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(624, 212);
            layoutControlItem1.TextSize = new Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = btn_Add;
            layoutControlItem2.Location = new Point(546, 212);
            layoutControlItem2.MinSize = new Size(78, 26);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(78, 65);
            layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem2.TextSize = new Size(0, 0);
            layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.AllowHotTrack = false;
            emptySpaceItem1.Location = new Point(0, 212);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(468, 65);
            emptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // simpleButton1
            // 
            btn_Delete.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_Delete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("simpleButton1.ImageOptions.SvgImage");
            btn_Delete.Location = new Point(480, 224);
            btn_Delete.Name = "simpleButton1";
            btn_Delete.Size = new Size(74, 61);
            btn_Delete.StyleController = layoutControl1;
            btn_Delete.TabIndex = 4;
            btn_Delete.Text = "simpleButton1";
            btn_Delete.Click += btn_Delete_Click;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = btn_Delete;
            layoutControlItem3.Location = new Point(468, 212);
            layoutControlItem3.MinSize = new Size(78, 26);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(78, 65);
            layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem3.TextSize = new Size(0, 0);
            layoutControlItem3.TextVisible = false;
            // 
            // FormImage
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new Size(644, 297);
            Controls.Add(layoutControl1);
            Name = "FormImage";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)galleryControl1).EndInit();
            galleryControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.GalleryControl galleryControl1;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btn_Add;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton btn_Delete;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}