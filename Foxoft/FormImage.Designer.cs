using Foxoft.Properties;

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
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            btn_Add = new DevExpress.XtraEditors.SimpleButton();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)galleryControl1).BeginInit();
            galleryControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            SuspendLayout();
            // 
            // galleryControl1
            // 
            galleryControl1.Controls.Add(galleryControlClient1);
            // 
            // 
            // 
            galleryControl1.Gallery.ShowGroupCaption = false;
            galleryControl1.Location = new System.Drawing.Point(12, 12);
            galleryControl1.Name = "galleryControl1";
            galleryControl1.Size = new System.Drawing.Size(620, 215);
            galleryControl1.StyleController = layoutControl1;
            galleryControl1.TabIndex = 0;
            galleryControl1.Text = "galleryControl1";
            // 
            // galleryControlClient1
            // 
            galleryControlClient1.GalleryControl = galleryControl1;
            galleryControlClient1.Location = new System.Drawing.Point(2, 2);
            galleryControlClient1.Size = new System.Drawing.Size(599, 211);
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(btn_Add);
            layoutControl1.Controls.Add(galleryControl1);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(692, 252, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(644, 297);
            layoutControl1.TabIndex = 1;
            layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, emptySpaceItem1 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(644, 297);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = galleryControl1;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(624, 219);
            layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // btn_Add
            // 
            btn_Add.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_Add.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("simpleButton1.ImageOptions.SvgImage");
            btn_Add.Location = new System.Drawing.Point(558, 231);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new System.Drawing.Size(74, 54);
            btn_Add.StyleController = layoutControl1;
            btn_Add.TabIndex = 2;
            btn_Add.Text = "btn_Add";
            btn_Add.Click += btn_Add_Click;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = btn_Add;
            layoutControlItem2.Location = new System.Drawing.Point(546, 219);
            layoutControlItem2.MinSize = new System.Drawing.Size(78, 26);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(78, 58);
            layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.AllowHotTrack = false;
            emptySpaceItem1.Location = new System.Drawing.Point(0, 219);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new System.Drawing.Size(546, 58);
            emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // FormImage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(644, 297);
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
    }
}