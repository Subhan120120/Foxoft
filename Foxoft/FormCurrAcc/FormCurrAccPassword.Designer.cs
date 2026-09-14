using Foxoft.Properties;

namespace Foxoft
{
    partial class FormCurrAccPassword
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCurrAccPassword));
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            txtEdit_CurrAcc = new DevExpress.XtraEditors.TextEdit();
            txtEdit_NewPassword = new DevExpress.XtraEditors.TextEdit();
            txtEdit_ConfirmPassword = new DevExpress.XtraEditors.TextEdit();
            chkShowPassword = new DevExpress.XtraEditors.CheckEdit();
            btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            btn_Save = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            lciCurrAcc = new DevExpress.XtraLayout.LayoutControlItem();
            lciNewPassword = new DevExpress.XtraLayout.LayoutControlItem();
            lciConfirmPassword = new DevExpress.XtraLayout.LayoutControlItem();
            lciShowPassword = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceButtons = new DevExpress.XtraLayout.EmptySpaceItem();
            lciBtnCancel = new DevExpress.XtraLayout.LayoutControlItem();
            lciBtnSave = new DevExpress.XtraLayout.LayoutControlItem();
            dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtEdit_CurrAcc.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_NewPassword.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_ConfirmPassword.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkShowPassword.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciCurrAcc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciNewPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciConfirmPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciShowPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceButtons).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciBtnCancel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciBtnSave).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dxErrorProvider1).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(txtEdit_CurrAcc);
            layoutControl1.Controls.Add(txtEdit_NewPassword);
            layoutControl1.Controls.Add(txtEdit_ConfirmPassword);
            layoutControl1.Controls.Add(chkShowPassword);
            layoutControl1.Controls.Add(btn_Cancel);
            layoutControl1.Controls.Add(btn_Save);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(384, 185);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // txtEdit_CurrAcc
            // 
            txtEdit_CurrAcc.Location = new Point(130, 12);
            txtEdit_CurrAcc.Name = "txtEdit_CurrAcc";
            txtEdit_CurrAcc.Properties.ReadOnly = true;
            txtEdit_CurrAcc.Properties.Appearance.BackColor = Color.LightGray;
            txtEdit_CurrAcc.Size = new Size(242, 20);
            txtEdit_CurrAcc.StyleController = layoutControl1;
            txtEdit_CurrAcc.TabIndex = 0;
            // 
            // txtEdit_NewPassword
            // 
            txtEdit_NewPassword.Location = new Point(130, 36);
            txtEdit_NewPassword.Name = "txtEdit_NewPassword";
            txtEdit_NewPassword.Properties.UseSystemPasswordChar = true;
            txtEdit_NewPassword.Size = new Size(242, 20);
            txtEdit_NewPassword.StyleController = layoutControl1;
            txtEdit_NewPassword.TabIndex = 1;
            // 
            // txtEdit_ConfirmPassword
            // 
            txtEdit_ConfirmPassword.Location = new Point(130, 60);
            txtEdit_ConfirmPassword.Name = "txtEdit_ConfirmPassword";
            txtEdit_ConfirmPassword.Properties.UseSystemPasswordChar = true;
            txtEdit_ConfirmPassword.Size = new Size(242, 20);
            txtEdit_ConfirmPassword.StyleController = layoutControl1;
            txtEdit_ConfirmPassword.TabIndex = 2;
            // 
            // chkShowPassword
            // 
            chkShowPassword.Location = new Point(12, 84);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Properties.Caption = Resources.Common_ShowPassword;
            chkShowPassword.Size = new Size(360, 20);
            chkShowPassword.StyleController = layoutControl1;
            chkShowPassword.TabIndex = 3;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // btn_Cancel
            // 
            btn_Cancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_Cancel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_Cancel.ImageOptions.SvgImage");
            btn_Cancel.Location = new Point(216, 134);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(76, 39);
            btn_Cancel.StyleController = layoutControl1;
            btn_Cancel.TabIndex = 4;
            btn_Cancel.Text = Resources.Common_Cancel;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // btn_Save
            // 
            btn_Save.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_Save.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_Save.ImageOptions.SvgImage");
            btn_Save.Location = new Point(296, 134);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(76, 39);
            btn_Save.StyleController = layoutControl1;
            btn_Save.TabIndex = 5;
            btn_Save.Text = Resources.Common_Save;
            btn_Save.Click += btn_Save_Click;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { lciCurrAcc, lciNewPassword, lciConfirmPassword, lciShowPassword, emptySpaceButtons, lciBtnCancel, lciBtnSave });
            Root.Name = "Root";
            Root.Size = new Size(384, 185);
            Root.TextVisible = false;
            // 
            // lciCurrAcc
            // 
            lciCurrAcc.Control = txtEdit_CurrAcc;
            lciCurrAcc.Location = new Point(0, 0);
            lciCurrAcc.Name = "lciCurrAcc";
            lciCurrAcc.Size = new Size(364, 24);
            lciCurrAcc.Text = Resources.Form_CurrAccPassword_Account;
            lciCurrAcc.TextSize = new Size(106, 13);
            // 
            // lciNewPassword
            // 
            lciNewPassword.Control = txtEdit_NewPassword;
            lciNewPassword.Location = new Point(0, 24);
            lciNewPassword.Name = "lciNewPassword";
            lciNewPassword.Size = new Size(364, 24);
            lciNewPassword.Text = Resources.Common_NewPassword;
            lciNewPassword.TextSize = new Size(106, 13);
            // 
            // lciConfirmPassword
            // 
            lciConfirmPassword.Control = txtEdit_ConfirmPassword;
            lciConfirmPassword.Location = new Point(0, 48);
            lciConfirmPassword.Name = "lciConfirmPassword";
            lciConfirmPassword.Size = new Size(364, 24);
            lciConfirmPassword.Text = Resources.Common_ConfirmPassword;
            lciConfirmPassword.TextSize = new Size(106, 13);
            // 
            // lciShowPassword
            // 
            lciShowPassword.Control = chkShowPassword;
            lciShowPassword.Location = new Point(0, 72);
            lciShowPassword.Name = "lciShowPassword";
            lciShowPassword.Size = new Size(364, 24);
            lciShowPassword.TextVisible = false;
            // 
            // emptySpaceButtons
            // 
            emptySpaceButtons.AllowHotTrack = false;
            emptySpaceButtons.Location = new Point(0, 96);
            emptySpaceButtons.Name = "emptySpaceButtons";
            emptySpaceButtons.Size = new Size(204, 69);
            emptySpaceButtons.TextSize = new Size(0, 0);
            // 
            // lciBtnCancel
            // 
            lciBtnCancel.Control = btn_Cancel;
            lciBtnCancel.Location = new Point(204, 122);
            lciBtnCancel.MaxSize = new Size(80, 43);
            lciBtnCancel.MinSize = new Size(80, 43);
            lciBtnCancel.Name = "lciBtnCancel";
            lciBtnCancel.Size = new Size(80, 43);
            lciBtnCancel.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lciBtnCancel.TextVisible = false;
            // 
            // lciBtnSave
            // 
            lciBtnSave.Control = btn_Save;
            lciBtnSave.Location = new Point(284, 122);
            lciBtnSave.MaxSize = new Size(80, 43);
            lciBtnSave.MinSize = new Size(80, 43);
            lciBtnSave.Name = "lciBtnSave";
            lciBtnSave.Size = new Size(80, 43);
            lciBtnSave.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lciBtnSave.TextVisible = false;
            // 
            // dxErrorProvider1
            // 
            dxErrorProvider1.ContainerControl = this;
            // 
            // FormCurrAccPassword
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 185);
            Controls.Add(layoutControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCurrAccPassword";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = Resources.Form_CurrAccPassword_Title;
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtEdit_CurrAcc.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_NewPassword.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_ConfirmPassword.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkShowPassword.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciCurrAcc).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciNewPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciConfirmPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciShowPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceButtons).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciBtnCancel).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciBtnSave).EndInit();
            ((System.ComponentModel.ISupportInitialize)dxErrorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txtEdit_CurrAcc;
        private DevExpress.XtraEditors.TextEdit txtEdit_NewPassword;
        private DevExpress.XtraEditors.TextEdit txtEdit_ConfirmPassword;
        private DevExpress.XtraEditors.CheckEdit chkShowPassword;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraLayout.LayoutControlItem lciCurrAcc;
        private DevExpress.XtraLayout.LayoutControlItem lciNewPassword;
        private DevExpress.XtraLayout.LayoutControlItem lciConfirmPassword;
        private DevExpress.XtraLayout.LayoutControlItem lciShowPassword;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceButtons;
        private DevExpress.XtraLayout.LayoutControlItem lciBtnCancel;
        private DevExpress.XtraLayout.LayoutControlItem lciBtnSave;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
    }
}
