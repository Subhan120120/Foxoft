using DevExpress.XtraEditors;

namespace Foxoft
{
    partial class UcNotificationPopupItem
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                notificationImage?.Dispose();
                components?.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            panelAccent = new PanelControl();
            pictureSeverity = new PictureEdit();
            lblTitle = new LabelControl();
            lblBody = new LabelControl();
            lblMeta = new LabelControl();
            lblEntity = new LabelControl();
            lblStatus = new LabelControl();
            ((System.ComponentModel.ISupportInitialize)panelAccent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureSeverity.Properties).BeginInit();
            SuspendLayout();
            // 
            // panelAccent
            // 
            panelAccent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelAccent.Cursor = Cursors.Hand;
            panelAccent.Dock = DockStyle.Left;
            panelAccent.Location = new Point(0, 0);
            panelAccent.Margin = new Padding(3, 2, 3, 2);
            panelAccent.Name = "panelAccent";
            panelAccent.Size = new Size(5, 102);
            panelAccent.TabIndex = 0;
            // 
            // pictureSeverity
            // 
            pictureSeverity.Location = new Point(15, 13);
            pictureSeverity.Margin = new Padding(3, 2, 3, 2);
            pictureSeverity.Name = "pictureSeverity";
            pictureSeverity.Cursor = Cursors.Hand;
            pictureSeverity.Properties.AllowFocused = false;
            pictureSeverity.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pictureSeverity.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            pictureSeverity.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            pictureSeverity.Size = new Size(33, 31);
            pictureSeverity.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AllowHtmlString = true;
            lblTitle.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.AutoSizeMode = LabelAutoSizeMode.Vertical;
            lblTitle.Cursor = Cursors.Hand;
            lblTitle.Location = new Point(57, 10);
            lblTitle.Margin = new Padding(3, 2, 3, 2);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(189, 0);
            lblTitle.TabIndex = 2;
            // 
            // lblBody
            // 
            lblBody.AllowHtmlString = true;
            lblBody.Appearance.Font = new Font("Segoe UI", 8.25F);
            lblBody.Appearance.ForeColor = Color.FromArgb(60, 60, 60);
            lblBody.Appearance.Options.UseFont = true;
            lblBody.Appearance.Options.UseForeColor = true;
            lblBody.AutoSizeMode = LabelAutoSizeMode.Vertical;
            lblBody.Cursor = Cursors.Hand;
            lblBody.LineVisible = true;
            lblBody.Location = new Point(57, 28);
            lblBody.Margin = new Padding(3, 2, 3, 2);
            lblBody.Name = "lblBody";
            lblBody.Size = new Size(274, 0);
            lblBody.TabIndex = 3;
            // 
            // lblMeta
            // 
            lblMeta.Appearance.Font = new Font("Segoe UI", 7.8F);
            lblMeta.Appearance.ForeColor = Color.FromArgb(100, 100, 100);
            lblMeta.Appearance.Options.UseFont = true;
            lblMeta.Appearance.Options.UseForeColor = true;
            lblMeta.AutoSizeMode = LabelAutoSizeMode.Vertical;
            lblMeta.Cursor = Cursors.Hand;
            lblMeta.Location = new Point(57, 63);
            lblMeta.Margin = new Padding(3, 2, 3, 2);
            lblMeta.Name = "lblMeta";
            lblMeta.Size = new Size(274, 0);
            lblMeta.TabIndex = 4;
            // 
            // lblEntity
            // 
            lblEntity.Appearance.Font = new Font("Segoe UI", 7.8F);
            lblEntity.Appearance.ForeColor = Color.FromArgb(100, 100, 100);
            lblEntity.Appearance.Options.UseFont = true;
            lblEntity.Appearance.Options.UseForeColor = true;
            lblEntity.AutoSizeMode = LabelAutoSizeMode.Vertical;
            lblEntity.Cursor = Cursors.Hand;
            lblEntity.Location = new Point(57, 84);
            lblEntity.Margin = new Padding(3, 2, 3, 2);
            lblEntity.Name = "lblEntity";
            lblEntity.Size = new Size(274, 0);
            lblEntity.TabIndex = 5;
            // 
            // lblStatus
            // 
            lblStatus.Appearance.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold);
            lblStatus.Appearance.ForeColor = Color.White;
            lblStatus.Appearance.Options.UseFont = true;
            lblStatus.Appearance.Options.UseForeColor = true;
            lblStatus.Appearance.Options.UseTextOptions = true;
            lblStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblStatus.AutoSizeMode = LabelAutoSizeMode.None;
            lblStatus.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            lblStatus.Cursor = Cursors.Hand;
            lblStatus.Location = new Point(257, 10);
            lblStatus.Margin = new Padding(3, 2, 3, 2);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(3, 1, 3, 1);
            lblStatus.Size = new Size(74, 16);
            lblStatus.TabIndex = 6;
            // 
            // UcNotificationPopupItem
            // 
            Appearance.BackColor = Color.White;
            Appearance.Options.UseBackColor = true;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Cursor = Cursors.Hand;
            Controls.Add(lblStatus);
            Controls.Add(lblEntity);
            Controls.Add(lblMeta);
            Controls.Add(lblBody);
            Controls.Add(lblTitle);
            Controls.Add(pictureSeverity);
            Controls.Add(panelAccent);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UcNotificationPopupItem";
            Size = new Size(343, 102);
            ((System.ComponentModel.ISupportInitialize)panelAccent).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureSeverity.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PanelControl panelAccent;
        private PictureEdit pictureSeverity;
        private LabelControl lblTitle;
        private LabelControl lblBody;
        private LabelControl lblMeta;
        private LabelControl lblEntity;
        private LabelControl lblStatus;
    }
}
