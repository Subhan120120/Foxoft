
namespace Foxoft
{
    partial class SplashScreenStartup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreenStartup));
            labelCopyright = new DevExpress.XtraEditors.LabelControl();
            labelStatus = new DevExpress.XtraEditors.LabelControl();
            progressBarControl = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            peLogo = new DevExpress.XtraEditors.PictureEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)progressBarControl.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)peLogo.Properties).BeginInit();
            SuspendLayout();
            // 
            // labelCopyright
            // 
            labelCopyright.Appearance.ForeColor = Color.White;
            labelCopyright.Appearance.Options.UseForeColor = true;
            labelCopyright.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            labelCopyright.Location = new Point(239, 273);
            labelCopyright.Name = "labelCopyright";
            labelCopyright.Size = new Size(188, 13);
            labelCopyright.TabIndex = 6;
            labelCopyright.Text = "Copyright © 2021 Subhan Hüseynzadə";
            // 
            // labelStatus
            // 
            labelStatus.Appearance.ForeColor = Color.White;
            labelStatus.Appearance.Options.UseForeColor = true;
            labelStatus.Location = new Point(109, 237);
            labelStatus.Margin = new Padding(3, 3, 3, 1);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(50, 13);
            labelStatus.TabIndex = 7;
            labelStatus.Text = "Starting...";
            // 
            // progressBarControl
            // 
            progressBarControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBarControl.EditValue = 0;
            progressBarControl.Location = new Point(109, 254);
            progressBarControl.Name = "progressBarControl";
            progressBarControl.Size = new Size(321, 13);
            progressBarControl.TabIndex = 5;
            // 
            // peLogo
            // 
            peLogo.EditValue = resources.GetObject("peLogo.EditValue");
            peLogo.Location = new Point(124, 96);
            peLogo.Name = "peLogo";
            peLogo.Properties.AllowFocused = false;
            peLogo.Properties.Appearance.BackColor = Color.Transparent;
            peLogo.Properties.Appearance.Options.UseBackColor = true;
            peLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            peLogo.Properties.ShowMenu = false;
            peLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            peLogo.Size = new Size(121, 111);
            peLogo.TabIndex = 8;
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new Font("Tahoma", 50F);
            labelControl1.Appearance.ForeColor = Color.Silver;
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Appearance.Options.UseForeColor = true;
            labelControl1.Location = new Point(253, 133);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(117, 81);
            labelControl1.TabIndex = 9;
            labelControl1.Text = "ERP";
            // 
            // labelControl2
            // 
            labelControl2.Appearance.Font = new Font("Tahoma", 30F);
            labelControl2.Appearance.ForeColor = Color.Silver;
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Appearance.Options.UseForeColor = true;
            labelControl2.Location = new Point(311, 102);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new Size(72, 48);
            labelControl2.TabIndex = 9;
            labelControl2.Text = "POS";
            // 
            // SplashScreenStartup
            // 
            AllowControlsInImageMode = true;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 363);
            Controls.Add(labelControl2);
            Controls.Add(labelControl1);
            Controls.Add(peLogo);
            Controls.Add(labelCopyright);
            Controls.Add(labelStatus);
            Controls.Add(progressBarControl);
            Margin = new Padding(4);
            Name = "SplashScreenStartup";
            ShowMode = DevExpress.XtraSplashScreen.ShowMode.Image;
            SplashImageOptions.Image = (Image)resources.GetObject("SplashScreenStartup.SplashImageOptions.Image");
            Text = "SplashScreen1";
            ((System.ComponentModel.ISupportInitialize)progressBarControl.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)peLogo.Properties).EndInit();
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
