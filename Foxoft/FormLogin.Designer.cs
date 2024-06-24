
using DevExpress.XtraEditors.Controls;
using Foxoft.Models;

namespace Foxoft
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            btn_ERP = new DevExpress.XtraEditors.SimpleButton();
            lC_Root = new DevExpress.XtraLayout.LayoutControl();
            LUE_Terminal = new DevExpress.XtraEditors.LookUpEdit();
            toolbarFormManager1 = new DevExpress.XtraBars.ToolbarForm.ToolbarFormManager(components);
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            BBI_GetKey = new DevExpress.XtraBars.BarButtonItem();
            btn_POS = new DevExpress.XtraEditors.SimpleButton();
            txtEdit_UserName = new DevExpress.XtraEditors.TextEdit();
            txtEdit_Password = new DevExpress.XtraEditors.TextEdit();
            checkEdit_RemindMe = new DevExpress.XtraEditors.CheckEdit();
            txtEdit_conString = new DevExpress.XtraEditors.TextEdit();
            btn_SaveConn = new DevExpress.XtraEditors.SimpleButton();
            lCG_Root = new DevExpress.XtraLayout.LayoutControlGroup();
            lCI_ERP = new DevExpress.XtraLayout.LayoutControlItem();
            lCI_POS = new DevExpress.XtraLayout.LayoutControlItem();
            lCI_UserName = new DevExpress.XtraLayout.LayoutControlItem();
            lCI_Password = new DevExpress.XtraLayout.LayoutControlItem();
            lCI_RemindMe = new DevExpress.XtraLayout.LayoutControlItem();
            lCI_ConString = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            toolbarFormControl1 = new DevExpress.XtraBars.ToolbarForm.ToolbarFormControl();
            ((System.ComponentModel.ISupportInitialize)lC_Root).BeginInit();
            lC_Root.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LUE_Terminal.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toolbarFormManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_UserName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_Password.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkEdit_RemindMe.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_conString.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lCG_Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lCI_ERP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lCI_POS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lCI_UserName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lCI_Password).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lCI_RemindMe).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lCI_ConString).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toolbarFormControl1).BeginInit();
            SuspendLayout();
            // 
            // btn_ERP
            // 
            btn_ERP.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btn_ERP.Appearance.Options.UseFont = true;
            btn_ERP.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_ERP.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_ERP.ImageOptions.SvgImage");
            btn_ERP.Location = new System.Drawing.Point(219, 134);
            btn_ERP.Name = "btn_ERP";
            btn_ERP.Size = new System.Drawing.Size(203, 144);
            btn_ERP.StyleController = lC_Root;
            btn_ERP.TabIndex = 8;
            btn_ERP.Text = "Arxa Ofis";
            btn_ERP.Click += btn_ERP_Click;
            // 
            // lC_Root
            // 
            lC_Root.Controls.Add(LUE_Terminal);
            lC_Root.Controls.Add(btn_POS);
            lC_Root.Controls.Add(btn_ERP);
            lC_Root.Controls.Add(txtEdit_UserName);
            lC_Root.Controls.Add(txtEdit_Password);
            lC_Root.Controls.Add(checkEdit_RemindMe);
            lC_Root.Controls.Add(txtEdit_conString);
            lC_Root.Controls.Add(btn_SaveConn);
            lC_Root.Dock = System.Windows.Forms.DockStyle.Fill;
            lC_Root.Location = new System.Drawing.Point(0, 31);
            lC_Root.Name = "lC_Root";
            lC_Root.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(374, 7, 650, 400);
            lC_Root.Root = lCG_Root;
            lC_Root.Size = new System.Drawing.Size(434, 290);
            lC_Root.TabIndex = 2;
            // 
            // LUE_Terminal
            // 
            LUE_Terminal.Location = new System.Drawing.Point(101, 38);
            LUE_Terminal.MenuManager = toolbarFormManager1;
            LUE_Terminal.Name = "LUE_Terminal";
            LUE_Terminal.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            LUE_Terminal.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("TerminalId", "TerminalId"), new LookUpColumnInfo("TerminalDesc", "TerminalDesc") });
            LUE_Terminal.Properties.DisplayMember = "TerminalDesc";
            LUE_Terminal.Properties.NullText = "";
            LUE_Terminal.Properties.ValueMember = "TerminalId";
            LUE_Terminal.Size = new System.Drawing.Size(321, 20);
            LUE_Terminal.StyleController = lC_Root;
            LUE_Terminal.TabIndex = 7;
            LUE_Terminal.InvalidValue += LUE_Terminal_InvalidValue;
            LUE_Terminal.EditValueChanged += LUE_Terminal_EditValueChanged;
            LUE_Terminal.Validating += LUE_Terminal_Validating;
            // 
            // toolbarFormManager1
            // 
            toolbarFormManager1.DockControls.Add(barDockControlTop);
            toolbarFormManager1.DockControls.Add(barDockControlBottom);
            toolbarFormManager1.DockControls.Add(barDockControlLeft);
            toolbarFormManager1.DockControls.Add(barDockControlRight);
            toolbarFormManager1.Form = this;
            toolbarFormManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barButtonItem1, barButtonItem2, BBI_GetKey });
            toolbarFormManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            barDockControlTop.Location = new System.Drawing.Point(0, 31);
            barDockControlTop.Manager = toolbarFormManager1;
            barDockControlTop.Size = new System.Drawing.Size(434, 0);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            barDockControlBottom.Location = new System.Drawing.Point(0, 321);
            barDockControlBottom.Manager = toolbarFormManager1;
            barDockControlBottom.Size = new System.Drawing.Size(434, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            barDockControlLeft.Manager = toolbarFormManager1;
            barDockControlLeft.Size = new System.Drawing.Size(0, 290);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            barDockControlRight.Location = new System.Drawing.Point(434, 31);
            barDockControlRight.Manager = toolbarFormManager1;
            barDockControlRight.Size = new System.Drawing.Size(0, 290);
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "Default";
            barButtonItem1.Id = 0;
            barButtonItem1.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem1.ImageOptions.SvgImage");
            barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            barButtonItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            barButtonItem2.Caption = "cap";
            barButtonItem2.Id = 1;
            barButtonItem2.Name = "barButtonItem2";
            barButtonItem2.ItemClick += barButtonItem2_ItemClick;
            // 
            // BBI_GetKey
            // 
            BBI_GetKey.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            BBI_GetKey.Caption = "bbi";
            BBI_GetKey.Id = 2;
            BBI_GetKey.Name = "BBI_GetKey";
            BBI_GetKey.ItemClick += BBI_GetKey_ItemClick;
            // 
            // btn_POS
            // 
            btn_POS.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btn_POS.Appearance.Options.UseFont = true;
            btn_POS.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_POS.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_POS.ImageOptions.SvgImage");
            btn_POS.Location = new System.Drawing.Point(12, 134);
            btn_POS.Name = "btn_POS";
            btn_POS.Size = new System.Drawing.Size(203, 144);
            btn_POS.StyleController = lC_Root;
            btn_POS.TabIndex = 7;
            btn_POS.Text = "Satış";
            btn_POS.Click += btn_POS_Click;
            // 
            // txtEdit_UserName
            // 
            txtEdit_UserName.Location = new System.Drawing.Point(101, 62);
            txtEdit_UserName.Name = "txtEdit_UserName";
            txtEdit_UserName.Size = new System.Drawing.Size(321, 20);
            txtEdit_UserName.StyleController = lC_Root;
            txtEdit_UserName.TabIndex = 4;
            // 
            // txtEdit_Password
            // 
            txtEdit_Password.Location = new System.Drawing.Point(101, 86);
            txtEdit_Password.Name = "txtEdit_Password";
            txtEdit_Password.Properties.UseSystemPasswordChar = true;
            txtEdit_Password.Size = new System.Drawing.Size(321, 20);
            txtEdit_Password.StyleController = lC_Root;
            txtEdit_Password.TabIndex = 5;
            // 
            // checkEdit_RemindMe
            // 
            checkEdit_RemindMe.Location = new System.Drawing.Point(12, 110);
            checkEdit_RemindMe.Name = "checkEdit_RemindMe";
            checkEdit_RemindMe.Properties.Caption = "meni xatırla";
            checkEdit_RemindMe.Size = new System.Drawing.Size(410, 20);
            checkEdit_RemindMe.StyleController = lC_Root;
            checkEdit_RemindMe.TabIndex = 6;
            // 
            // txtEdit_conString
            // 
            txtEdit_conString.Location = new System.Drawing.Point(101, 12);
            txtEdit_conString.MenuManager = toolbarFormManager1;
            txtEdit_conString.Name = "txtEdit_conString";
            txtEdit_conString.Size = new System.Drawing.Size(209, 20);
            txtEdit_conString.StyleController = lC_Root;
            txtEdit_conString.TabIndex = 0;
            // 
            // btn_SaveConn
            // 
            btn_SaveConn.Location = new System.Drawing.Point(314, 12);
            btn_SaveConn.Name = "btn_SaveConn";
            btn_SaveConn.Size = new System.Drawing.Size(108, 22);
            btn_SaveConn.StyleController = lC_Root;
            btn_SaveConn.TabIndex = 2;
            btn_SaveConn.Text = "Yadda Saxla";
            btn_SaveConn.Click += btn_SaveConn_Click;
            // 
            // lCG_Root
            // 
            lCG_Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            lCG_Root.GroupBordersVisible = false;
            lCG_Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { lCI_ERP, lCI_POS, lCI_UserName, lCI_Password, lCI_RemindMe, lCI_ConString, layoutControlItem2, layoutControlItem3 });
            lCG_Root.Name = "Root";
            lCG_Root.Size = new System.Drawing.Size(434, 290);
            lCG_Root.TextVisible = false;
            // 
            // lCI_ERP
            // 
            lCI_ERP.Control = btn_ERP;
            lCI_ERP.Location = new System.Drawing.Point(207, 122);
            lCI_ERP.MinSize = new System.Drawing.Size(78, 26);
            lCI_ERP.Name = "lCI_ERP";
            lCI_ERP.Size = new System.Drawing.Size(207, 148);
            lCI_ERP.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lCI_ERP.TextSize = new System.Drawing.Size(0, 0);
            lCI_ERP.TextVisible = false;
            // 
            // lCI_POS
            // 
            lCI_POS.Control = btn_POS;
            lCI_POS.Location = new System.Drawing.Point(0, 122);
            lCI_POS.MinSize = new System.Drawing.Size(78, 26);
            lCI_POS.Name = "lCI_POS";
            lCI_POS.Size = new System.Drawing.Size(207, 148);
            lCI_POS.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lCI_POS.TextSize = new System.Drawing.Size(0, 0);
            lCI_POS.TextVisible = false;
            // 
            // lCI_UserName
            // 
            lCI_UserName.Control = txtEdit_UserName;
            lCI_UserName.Location = new System.Drawing.Point(0, 50);
            lCI_UserName.Name = "lCI_UserName";
            lCI_UserName.Size = new System.Drawing.Size(414, 24);
            lCI_UserName.Text = "İstifadəçi";
            lCI_UserName.TextSize = new System.Drawing.Size(77, 13);
            // 
            // lCI_Password
            // 
            lCI_Password.Control = txtEdit_Password;
            lCI_Password.Location = new System.Drawing.Point(0, 74);
            lCI_Password.Name = "lCI_Password";
            lCI_Password.Size = new System.Drawing.Size(414, 24);
            lCI_Password.Text = "Şifrə";
            lCI_Password.TextSize = new System.Drawing.Size(77, 13);
            // 
            // lCI_RemindMe
            // 
            lCI_RemindMe.Control = checkEdit_RemindMe;
            lCI_RemindMe.Location = new System.Drawing.Point(0, 98);
            lCI_RemindMe.Name = "lCI_RemindMe";
            lCI_RemindMe.Size = new System.Drawing.Size(414, 24);
            lCI_RemindMe.TextSize = new System.Drawing.Size(0, 0);
            lCI_RemindMe.TextVisible = false;
            // 
            // lCI_ConString
            // 
            lCI_ConString.Control = txtEdit_conString;
            lCI_ConString.Location = new System.Drawing.Point(0, 0);
            lCI_ConString.Name = "lCI_ConString";
            lCI_ConString.Size = new System.Drawing.Size(302, 26);
            lCI_ConString.Text = "Database Əlaqə";
            lCI_ConString.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = btn_SaveConn;
            layoutControlItem2.Location = new System.Drawing.Point(302, 0);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(112, 26);
            layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = LUE_Terminal;
            layoutControlItem3.Location = new System.Drawing.Point(0, 26);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(414, 24);
            layoutControlItem3.Text = "Terminal";
            layoutControlItem3.TextSize = new System.Drawing.Size(77, 13);
            // 
            // toolbarFormControl1
            // 
            toolbarFormControl1.Location = new System.Drawing.Point(0, 0);
            toolbarFormControl1.Manager = toolbarFormManager1;
            toolbarFormControl1.Name = "toolbarFormControl1";
            toolbarFormControl1.Size = new System.Drawing.Size(434, 31);
            toolbarFormControl1.TabIndex = 3;
            toolbarFormControl1.TabStop = false;
            toolbarFormControl1.TitleItemLinks.Add(barButtonItem1);
            toolbarFormControl1.TitleItemLinks.Add(barButtonItem2);
            toolbarFormControl1.TitleItemLinks.Add(BBI_GetKey);
            toolbarFormControl1.ToolbarForm = this;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(434, 321);
            Controls.Add(lC_Root);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Controls.Add(toolbarFormControl1);
            Name = "FormLogin";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Giriş";
            ToolbarFormControl = toolbarFormControl1;
            Load += FormLogin_Load;
            ((System.ComponentModel.ISupportInitialize)lC_Root).EndInit();
            lC_Root.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LUE_Terminal.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)toolbarFormManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_UserName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_Password.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)checkEdit_RemindMe.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_conString.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lCG_Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)lCI_ERP).EndInit();
            ((System.ComponentModel.ISupportInitialize)lCI_POS).EndInit();
            ((System.ComponentModel.ISupportInitialize)lCI_UserName).EndInit();
            ((System.ComponentModel.ISupportInitialize)lCI_Password).EndInit();
            ((System.ComponentModel.ISupportInitialize)lCI_RemindMe).EndInit();
            ((System.ComponentModel.ISupportInitialize)lCI_ConString).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)toolbarFormControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_ERP;
        private DevExpress.XtraLayout.LayoutControl lC_Root;
        private DevExpress.XtraEditors.SimpleButton btn_POS;
        private DevExpress.XtraLayout.LayoutControlGroup lCG_Root;
        private DevExpress.XtraLayout.LayoutControlItem lCI_POS;
        private DevExpress.XtraLayout.LayoutControlItem lCI_ERP;
        private DevExpress.XtraEditors.TextEdit txtEdit_UserName;
        private DevExpress.XtraEditors.TextEdit txtEdit_Password;
        private DevExpress.XtraLayout.LayoutControlItem lCI_UserName;
        private DevExpress.XtraLayout.LayoutControlItem lCI_Password;
        private DevExpress.XtraEditors.CheckEdit checkEdit_RemindMe;
        private DevExpress.XtraLayout.LayoutControlItem lCI_RemindMe;
        private DevExpress.XtraBars.ToolbarForm.ToolbarFormControl toolbarFormControl1;
        private DevExpress.XtraBars.ToolbarForm.ToolbarFormManager toolbarFormManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit txtEdit_conString;
        private DevExpress.XtraLayout.LayoutControlItem lCI_ConString;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btn_ConStringSave;
        private DevExpress.XtraEditors.SimpleButton btn_SaveConn;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem BBI_GetKey;
        private DevExpress.XtraEditors.LookUpEdit LUE_Terminal;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}