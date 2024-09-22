
using DevExpress.XtraEditors;

namespace Foxoft
{
    partial class XtraForm1
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
            SuspendLayout();
            // 
            // XtraForm1
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(946, 491);
            Name = "XtraForm1";
            Text = "XtraForm1";
            Load += XtraForm1_Load;
            ResumeLayout(false);
        }

        #endregion

        private FilterControl filterControl1;
        private DevExpress.XtraBars.Ribbon.GalleryControl gc;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
    }
}