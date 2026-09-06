using DevExpress.XtraEditors;
using Foxoft.Properties;
using System;
using System.Drawing;

namespace Foxoft
{
    partial class SplashScreenStartup
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(SplashScreenStartup));

            labelCopyright = new LabelControl();
            labelStatus = new LabelControl();
            progressBarControl = new MarqueeProgressBarControl();
            peLogo = new PictureEdit();
            labelControl1 = new LabelControl();
            labelControl2 = new LabelControl();

            ((System.ComponentModel.ISupportInitialize)(progressBarControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(peLogo.Properties)).BeginInit();

            SuspendLayout();
            // 
            // labelCopyright
            // 
            labelCopyright.Appearance.ForeColor = Color.White;
            labelCopyright.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            labelCopyright.Location = new Point(239, 273);
            labelCopyright.Name = "labelCopyright";
            labelCopyright.Size = new Size(188, 13);
            labelCopyright.Text = Resources.Form_Splash_Copyright;
            // 
            // labelStatus
            // 
            labelStatus.Appearance.ForeColor = Color.White;
            labelStatus.Location = new Point(109, 237);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(50, 13);
            labelStatus.Text = Resources.Form_Splash_Status_Starting;
            // 
            // progressBarControl
            // 
            progressBarControl.Location = new Point(109, 254);
            progressBarControl.Name = "progressBarControl";
            progressBarControl.Size = new Size(321, 13);
            // 
            // peLogo
            // 
            peLogo.EditValue = resources.GetObject("peLogo.EditValue");
            peLogo.Location = new Point(124, 96);
            peLogo.Properties.ShowMenu = false;
            peLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            peLogo.Size = new Size(121, 111);
            // 
            // labelControl1 (ERP)
            // 
            labelControl1.Appearance.Font = new Font("Tahoma", 50F);
            labelControl1.Appearance.ForeColor = Color.Silver;
            labelControl1.Location = new Point(253, 133);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(117, 81);

            labelControl1.Text = Resources.Form_Splash_Title_ERP;
            // 
            // labelControl2 (POS)
            // 
            labelControl2.Appearance.Font = new Font("Tahoma", 30F);
            labelControl2.Appearance.ForeColor = Color.Silver;
            labelControl2.Location = new Point(311, 102);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(72, 48);
            labelControl2.Text = Resources.Form_Splash_Title_POS;
            // 
            // SplashScreenStartup
            // 
            AllowControlsInImageMode = true;
            ClientSize = new Size(550, 363);
            Controls.Add(labelControl2);
            Controls.Add(labelControl1);
            Controls.Add(peLogo);
            Controls.Add(labelCopyright);
            Controls.Add(labelStatus);
            Controls.Add(progressBarControl);
            Name = "SplashScreenStartup";
            ShowMode = DevExpress.XtraSplashScreen.ShowMode.Image;
            SplashImageOptions.Image =
                (Image)resources.GetObject("SplashScreenStartup.SplashImageOptions.Image");

            ((System.ComponentModel.ISupportInitialize)(progressBarControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(peLogo.Properties)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private DevExpress.XtraEditors.MarqueeProgressBarControl progressBarControl;
        private DevExpress.XtraEditors.LabelControl labelCopyright;
        private DevExpress.XtraEditors.LabelControl labelStatus;
        private DevExpress.XtraEditors.PictureEdit peLogo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}
