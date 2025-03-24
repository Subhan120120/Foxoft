
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
            LUE_Company = new DevExpress.XtraEditors.LookUpEdit();
            simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            lCG_Root = new DevExpress.XtraLayout.LayoutControlGroup();
            lCI_ERP = new DevExpress.XtraLayout.LayoutControlItem();
            lCI_POS = new DevExpress.XtraLayout.LayoutControlItem();
            lCI_UserName = new DevExpress.XtraLayout.LayoutControlItem();
            lCI_Password = new DevExpress.XtraLayout.LayoutControlItem();
            lCI_RemindMe = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            toolbarFormControl1 = new DevExpress.XtraBars.ToolbarForm.ToolbarFormControl();
            barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)lC_Root).BeginInit();
            lC_Root.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LUE_Terminal.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toolbarFormManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_UserName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_Password.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)checkEdit_RemindMe.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LUE_Company.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lCG_Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lCI_ERP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lCI_POS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lCI_UserName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lCI_Password).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lCI_RemindMe).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toolbarFormControl1).BeginInit();
            SuspendLayout();
            // 
            // btn_ERP
            // 
            btn_ERP.Appearance.Font = new Font("Tahoma", 16F);
            btn_ERP.Appearance.Options.UseFont = true;
            btn_ERP.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_ERP.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_ERP.ImageOptions.SvgImage");
            btn_ERP.Location = new Point(219, 134);
            btn_ERP.Name = "btn_ERP";
            btn_ERP.Size = new Size(203, 144);
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
            lC_Root.Controls.Add(LUE_Company);
            lC_Root.Controls.Add(simpleButton2);
            lC_Root.Dock = DockStyle.Fill;
            lC_Root.Location = new Point(0, 31);
            lC_Root.Name = "lC_Root";
            lC_Root.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(812, 190, 650, 400);
            lC_Root.Root = lCG_Root;
            lC_Root.Size = new Size(434, 290);
            lC_Root.TabIndex = 2;
            // 
            // LUE_Terminal
            // 
            LUE_Terminal.Location = new Point(68, 38);
            LUE_Terminal.MenuManager = toolbarFormManager1;
            LUE_Terminal.Name = "LUE_Terminal";
            LUE_Terminal.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            LUE_Terminal.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("TerminalId", "TerminalId"), new LookUpColumnInfo("TerminalDesc", "TerminalDesc") });
            LUE_Terminal.Properties.DisplayMember = "TerminalDesc";
            LUE_Terminal.Properties.NullText = "";
            LUE_Terminal.Properties.ValueMember = "TerminalId";
            LUE_Terminal.Size = new Size(354, 20);
            LUE_Terminal.StyleController = lC_Root;
            LUE_Terminal.TabIndex = 3;
            LUE_Terminal.EditValueChanged += LUE_Terminal_EditValueChanged;
            // 
            // toolbarFormManager1
            // 
            toolbarFormManager1.DockControls.Add(barDockControlTop);
            toolbarFormManager1.DockControls.Add(barDockControlBottom);
            toolbarFormManager1.DockControls.Add(barDockControlLeft);
            toolbarFormManager1.DockControls.Add(barDockControlRight);
            toolbarFormManager1.Form = this;
            toolbarFormManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barButtonItem1, barButtonItem2, BBI_GetKey, barButtonItem3, barButtonItem4 });
            toolbarFormManager1.MaxItemId = 5;
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 31);
            barDockControlTop.Manager = toolbarFormManager1;
            barDockControlTop.Size = new Size(434, 0);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 321);
            barDockControlBottom.Manager = toolbarFormManager1;
            barDockControlBottom.Size = new Size(434, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 31);
            barDockControlLeft.Manager = toolbarFormManager1;
            barDockControlLeft.Size = new Size(0, 290);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(434, 31);
            barDockControlRight.Manager = toolbarFormManager1;
            barDockControlRight.Size = new Size(0, 290);
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
            btn_POS.Appearance.Font = new Font("Tahoma", 16F);
            btn_POS.Appearance.Options.UseFont = true;
            btn_POS.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_POS.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_POS.ImageOptions.SvgImage");
            btn_POS.Location = new Point(12, 134);
            btn_POS.Name = "btn_POS";
            btn_POS.Size = new Size(203, 144);
            btn_POS.StyleController = lC_Root;
            btn_POS.TabIndex = 7;
            btn_POS.Text = "Satış";
            btn_POS.Click += btn_POS_Click;
            // 
            // txtEdit_UserName
            // 
            txtEdit_UserName.Location = new Point(68, 62);
            txtEdit_UserName.Name = "txtEdit_UserName";
            txtEdit_UserName.Size = new Size(354, 20);
            txtEdit_UserName.StyleController = lC_Root;
            txtEdit_UserName.TabIndex = 4;
            // 
            // txtEdit_Password
            // 
            txtEdit_Password.Location = new Point(68, 86);
            txtEdit_Password.Name = "txtEdit_Password";
            txtEdit_Password.Properties.UseSystemPasswordChar = true;
            txtEdit_Password.Size = new Size(354, 20);
            txtEdit_Password.StyleController = lC_Root;
            txtEdit_Password.TabIndex = 5;
            // 
            // checkEdit_RemindMe
            // 
            checkEdit_RemindMe.Location = new Point(12, 110);
            checkEdit_RemindMe.Name = "checkEdit_RemindMe";
            checkEdit_RemindMe.Properties.Caption = "meni xatırla";
            checkEdit_RemindMe.Size = new Size(410, 20);
            checkEdit_RemindMe.StyleController = lC_Root;
            checkEdit_RemindMe.TabIndex = 6;
            // 
            // LUE_Company
            // 
            LUE_Company.Location = new Point(68, 12);
            LUE_Company.MenuManager = toolbarFormManager1;
            LUE_Company.Name = "LUE_Company";
            LUE_Company.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            LUE_Company.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("CompanyCode", "ŞirkətKodu"), new LookUpColumnInfo("CompanyDesc", "Şirkət Adı") });
            LUE_Company.Properties.DisplayMember = "CompanyDesc";
            LUE_Company.Properties.NullText = "";
            LUE_Company.Properties.ValueMember = "CompanyCode";
            LUE_Company.Size = new Size(276, 20);
            LUE_Company.StyleController = lC_Root;
            LUE_Company.TabIndex = 0;
            LUE_Company.EditValueChanged += LUE_Company_EditValueChanged;
            LUE_Company.EditValueChanging += LUE_Company_EditValueChanging;
            // 
            // simpleButton2
            // 
            simpleButton2.Location = new Point(348, 12);
            simpleButton2.Name = "simpleButton2";
            simpleButton2.Size = new Size(74, 22);
            simpleButton2.StyleController = lC_Root;
            simpleButton2.TabIndex = 2;
            simpleButton2.Text = "constr";
            simpleButton2.Click += btn_ConStr;
            // 
            // lCG_Root
            // 
            lCG_Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            lCG_Root.GroupBordersVisible = false;
            lCG_Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { lCI_ERP, lCI_POS, lCI_UserName, lCI_Password, lCI_RemindMe, layoutControlItem3, layoutControlItem4, layoutControlItem2 });
            lCG_Root.Name = "Root";
            lCG_Root.Size = new Size(434, 290);
            lCG_Root.TextVisible = false;
            // 
            // lCI_ERP
            // 
            lCI_ERP.Control = btn_ERP;
            lCI_ERP.Location = new Point(207, 122);
            lCI_ERP.MinSize = new Size(78, 26);
            lCI_ERP.Name = "lCI_ERP";
            lCI_ERP.Size = new Size(207, 148);
            lCI_ERP.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lCI_ERP.TextSize = new Size(0, 0);
            lCI_ERP.TextVisible = false;
            // 
            // lCI_POS
            // 
            lCI_POS.Control = btn_POS;
            lCI_POS.Location = new Point(0, 122);
            lCI_POS.MinSize = new Size(78, 26);
            lCI_POS.Name = "lCI_POS";
            lCI_POS.Size = new Size(207, 148);
            lCI_POS.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lCI_POS.TextSize = new Size(0, 0);
            lCI_POS.TextVisible = false;
            // 
            // lCI_UserName
            // 
            lCI_UserName.Control = txtEdit_UserName;
            lCI_UserName.Location = new Point(0, 50);
            lCI_UserName.Name = "lCI_UserName";
            lCI_UserName.Size = new Size(414, 24);
            lCI_UserName.Text = "İstifadəçi";
            lCI_UserName.TextSize = new Size(44, 13);
            // 
            // lCI_Password
            // 
            lCI_Password.Control = txtEdit_Password;
            lCI_Password.Location = new Point(0, 74);
            lCI_Password.Name = "lCI_Password";
            lCI_Password.Size = new Size(414, 24);
            lCI_Password.Text = "Şifrə";
            lCI_Password.TextSize = new Size(44, 13);
            // 
            // lCI_RemindMe
            // 
            lCI_RemindMe.Control = checkEdit_RemindMe;
            lCI_RemindMe.Location = new Point(0, 98);
            lCI_RemindMe.Name = "lCI_RemindMe";
            lCI_RemindMe.Size = new Size(414, 24);
            lCI_RemindMe.TextSize = new Size(0, 0);
            lCI_RemindMe.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = LUE_Terminal;
            layoutControlItem3.Location = new Point(0, 26);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(414, 24);
            layoutControlItem3.Text = "Terminal";
            layoutControlItem3.TextSize = new Size(44, 13);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = LUE_Company;
            layoutControlItem4.Location = new Point(0, 0);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(336, 26);
            layoutControlItem4.Text = "Şirkət";
            layoutControlItem4.TextSize = new Size(44, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = simpleButton2;
            layoutControlItem2.Location = new Point(336, 0);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(78, 26);
            layoutControlItem2.TextSize = new Size(0, 0);
            layoutControlItem2.TextVisible = false;
            // 
            // toolbarFormControl1
            // 
            toolbarFormControl1.Location = new Point(0, 0);
            toolbarFormControl1.Manager = toolbarFormManager1;
            toolbarFormControl1.Name = "toolbarFormControl1";
            toolbarFormControl1.Size = new Size(434, 31);
            toolbarFormControl1.TabIndex = 3;
            toolbarFormControl1.TabStop = false;
            toolbarFormControl1.TitleItemLinks.Add(barButtonItem1);
            toolbarFormControl1.TitleItemLinks.Add(barButtonItem2);
            toolbarFormControl1.TitleItemLinks.Add(BBI_GetKey);
            toolbarFormControl1.TitleItemLinks.Add(barButtonItem3);
            toolbarFormControl1.TitleItemLinks.Add(barButtonItem4);
            toolbarFormControl1.ToolbarForm = this;
            // 
            // barButtonItem3
            // 
            barButtonItem3.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            barButtonItem3.Caption = "barButtonItem3";
            barButtonItem3.Id = 3;
            barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            barButtonItem4.Caption = "cap2";
            barButtonItem4.Id = 4;
            barButtonItem4.Name = "barButtonItem4";
            barButtonItem4.ItemClick += barButtonItem4_ItemClick;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 321);
            Controls.Add(lC_Root);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Controls.Add(toolbarFormControl1);
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
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
            ((System.ComponentModel.ISupportInitialize)LUE_Company.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lCG_Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)lCI_ERP).EndInit();
            ((System.ComponentModel.ISupportInitialize)lCI_POS).EndInit();
            ((System.ComponentModel.ISupportInitialize)lCI_UserName).EndInit();
            ((System.ComponentModel.ISupportInitialize)lCI_Password).EndInit();
            ((System.ComponentModel.ISupportInitialize)lCI_RemindMe).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
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
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btn_ConStringSave;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem BBI_GetKey;
        private DevExpress.XtraEditors.LookUpEdit LUE_Terminal;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.LookUpEdit LUE_Company;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
    }
}