
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
         this.btn_ERP = new DevExpress.XtraEditors.SimpleButton();
         this.lC_Root = new DevExpress.XtraLayout.LayoutControl();
         this.btn_POS = new DevExpress.XtraEditors.SimpleButton();
         this.txtEdit_UserName = new DevExpress.XtraEditors.TextEdit();
         this.txtEdit_Password = new DevExpress.XtraEditors.TextEdit();
         this.checkEdit_RemindMe = new DevExpress.XtraEditors.CheckEdit();
         this.txtEdit_conString = new DevExpress.XtraEditors.TextEdit();
         this.toolbarFormManager1 = new DevExpress.XtraBars.ToolbarForm.ToolbarFormManager(this.components);
         this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
         this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
         this.btn_SaveConn = new DevExpress.XtraEditors.SimpleButton();
         this.lCG_Root = new DevExpress.XtraLayout.LayoutControlGroup();
         this.lCI_ERP = new DevExpress.XtraLayout.LayoutControlItem();
         this.lCI_POS = new DevExpress.XtraLayout.LayoutControlItem();
         this.lCI_UserName = new DevExpress.XtraLayout.LayoutControlItem();
         this.lCI_Password = new DevExpress.XtraLayout.LayoutControlItem();
         this.lCI_RemindMe = new DevExpress.XtraLayout.LayoutControlItem();
         this.lCI_ConString = new DevExpress.XtraLayout.LayoutControlItem();
         this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
         this.toolbarFormControl1 = new DevExpress.XtraBars.ToolbarForm.ToolbarFormControl();
         ((System.ComponentModel.ISupportInitialize)(this.lC_Root)).BeginInit();
         this.lC_Root.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtEdit_UserName.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtEdit_Password.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.checkEdit_RemindMe.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtEdit_conString.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.toolbarFormManager1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.lCG_Root)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.lCI_ERP)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.lCI_POS)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.lCI_UserName)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.lCI_Password)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.lCI_RemindMe)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.lCI_ConString)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.toolbarFormControl1)).BeginInit();
         this.SuspendLayout();
         // 
         // btn_ERP
         // 
         this.btn_ERP.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
         this.btn_ERP.Appearance.Options.UseFont = true;
         this.btn_ERP.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
         this.btn_ERP.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_ERP.ImageOptions.SvgImage")));
         this.btn_ERP.Location = new System.Drawing.Point(157, 110);
         this.btn_ERP.Name = "btn_ERP";
         this.btn_ERP.Size = new System.Drawing.Size(142, 109);
         this.btn_ERP.StyleController = this.lC_Root;
         this.btn_ERP.TabIndex = 7;
         this.btn_ERP.Text = "Arxa Ofis";
         this.btn_ERP.Click += new System.EventHandler(this.btn_ERP_Click);
         // 
         // lC_Root
         // 
         this.lC_Root.Controls.Add(this.btn_POS);
         this.lC_Root.Controls.Add(this.btn_ERP);
         this.lC_Root.Controls.Add(this.txtEdit_UserName);
         this.lC_Root.Controls.Add(this.txtEdit_Password);
         this.lC_Root.Controls.Add(this.checkEdit_RemindMe);
         this.lC_Root.Controls.Add(this.txtEdit_conString);
         this.lC_Root.Controls.Add(this.btn_SaveConn);
         this.lC_Root.Dock = System.Windows.Forms.DockStyle.Fill;
         this.lC_Root.Location = new System.Drawing.Point(0, 31);
         this.lC_Root.Name = "lC_Root";
         this.lC_Root.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(374, 7, 650, 400);
         this.lC_Root.Root = this.lCG_Root;
         this.lC_Root.Size = new System.Drawing.Size(311, 231);
         this.lC_Root.TabIndex = 2;
         // 
         // btn_POS
         // 
         this.btn_POS.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
         this.btn_POS.Appearance.Options.UseFont = true;
         this.btn_POS.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
         this.btn_POS.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_POS.ImageOptions.SvgImage")));
         this.btn_POS.Location = new System.Drawing.Point(12, 110);
         this.btn_POS.Name = "btn_POS";
         this.btn_POS.Size = new System.Drawing.Size(141, 109);
         this.btn_POS.StyleController = this.lC_Root;
         this.btn_POS.TabIndex = 6;
         this.btn_POS.Text = "Satış";
         this.btn_POS.Click += new System.EventHandler(this.btn_POS_Click);
         // 
         // txtEdit_UserName
         // 
         this.txtEdit_UserName.Location = new System.Drawing.Point(101, 38);
         this.txtEdit_UserName.Name = "txtEdit_UserName";
         this.txtEdit_UserName.Size = new System.Drawing.Size(198, 20);
         this.txtEdit_UserName.StyleController = this.lC_Root;
         this.txtEdit_UserName.TabIndex = 3;
         // 
         // txtEdit_Password
         // 
         this.txtEdit_Password.Location = new System.Drawing.Point(101, 62);
         this.txtEdit_Password.Name = "txtEdit_Password";
         this.txtEdit_Password.Properties.UseSystemPasswordChar = true;
         this.txtEdit_Password.Size = new System.Drawing.Size(198, 20);
         this.txtEdit_Password.StyleController = this.lC_Root;
         this.txtEdit_Password.TabIndex = 4;
         // 
         // checkEdit_RemindMe
         // 
         this.checkEdit_RemindMe.Location = new System.Drawing.Point(12, 86);
         this.checkEdit_RemindMe.Name = "checkEdit_RemindMe";
         this.checkEdit_RemindMe.Properties.Caption = "meni xatırla";
         this.checkEdit_RemindMe.Size = new System.Drawing.Size(287, 20);
         this.checkEdit_RemindMe.StyleController = this.lC_Root;
         this.checkEdit_RemindMe.TabIndex = 5;
         // 
         // txtEdit_conString
         // 
         this.txtEdit_conString.Location = new System.Drawing.Point(101, 12);
         this.txtEdit_conString.MenuManager = this.toolbarFormManager1;
         this.txtEdit_conString.Name = "txtEdit_conString";
         this.txtEdit_conString.Size = new System.Drawing.Size(120, 20);
         this.txtEdit_conString.StyleController = this.lC_Root;
         this.txtEdit_conString.TabIndex = 0;
         // 
         // toolbarFormManager1
         // 
         this.toolbarFormManager1.DockControls.Add(this.barDockControlTop);
         this.toolbarFormManager1.DockControls.Add(this.barDockControlBottom);
         this.toolbarFormManager1.DockControls.Add(this.barDockControlLeft);
         this.toolbarFormManager1.DockControls.Add(this.barDockControlRight);
         this.toolbarFormManager1.Form = this;
         this.toolbarFormManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1});
         this.toolbarFormManager1.MaxItemId = 1;
         // 
         // barDockControlTop
         // 
         this.barDockControlTop.CausesValidation = false;
         this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
         this.barDockControlTop.Location = new System.Drawing.Point(0, 31);
         this.barDockControlTop.Manager = this.toolbarFormManager1;
         this.barDockControlTop.Size = new System.Drawing.Size(311, 0);
         // 
         // barDockControlBottom
         // 
         this.barDockControlBottom.CausesValidation = false;
         this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.barDockControlBottom.Location = new System.Drawing.Point(0, 262);
         this.barDockControlBottom.Manager = this.toolbarFormManager1;
         this.barDockControlBottom.Size = new System.Drawing.Size(311, 0);
         // 
         // barDockControlLeft
         // 
         this.barDockControlLeft.CausesValidation = false;
         this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
         this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
         this.barDockControlLeft.Manager = this.toolbarFormManager1;
         this.barDockControlLeft.Size = new System.Drawing.Size(0, 231);
         // 
         // barDockControlRight
         // 
         this.barDockControlRight.CausesValidation = false;
         this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
         this.barDockControlRight.Location = new System.Drawing.Point(311, 31);
         this.barDockControlRight.Manager = this.toolbarFormManager1;
         this.barDockControlRight.Size = new System.Drawing.Size(0, 231);
         // 
         // barButtonItem1
         // 
         this.barButtonItem1.Caption = "Default";
         this.barButtonItem1.Id = 0;
         this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
         this.barButtonItem1.Name = "barButtonItem1";
         this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
         // 
         // simpleButton2
         // 
         this.btn_SaveConn.Location = new System.Drawing.Point(225, 12);
         this.btn_SaveConn.Name = "btn_Save";
         this.btn_SaveConn.Size = new System.Drawing.Size(74, 22);
         this.btn_SaveConn.StyleController = this.lC_Root;
         this.btn_SaveConn.TabIndex = 8;
         this.btn_SaveConn.Text = "Yadda Saxla";
         this.btn_SaveConn.Click += new System.EventHandler(this.btn_SaveConn_Click);
         // 
         // lCG_Root
         // 
         this.lCG_Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
         this.lCG_Root.GroupBordersVisible = false;
         this.lCG_Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lCI_ERP,
            this.lCI_POS,
            this.lCI_UserName,
            this.lCI_Password,
            this.lCI_RemindMe,
            this.lCI_ConString,
            this.layoutControlItem2});
         this.lCG_Root.Name = "Root";
         this.lCG_Root.Size = new System.Drawing.Size(311, 231);
         this.lCG_Root.TextVisible = false;
         // 
         // lCI_ERP
         // 
         this.lCI_ERP.Control = this.btn_ERP;
         this.lCI_ERP.Location = new System.Drawing.Point(145, 98);
         this.lCI_ERP.MinSize = new System.Drawing.Size(78, 26);
         this.lCI_ERP.Name = "lCI_ERP";
         this.lCI_ERP.Size = new System.Drawing.Size(146, 113);
         this.lCI_ERP.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.lCI_ERP.TextSize = new System.Drawing.Size(0, 0);
         this.lCI_ERP.TextVisible = false;
         // 
         // lCI_POS
         // 
         this.lCI_POS.Control = this.btn_POS;
         this.lCI_POS.Location = new System.Drawing.Point(0, 98);
         this.lCI_POS.MinSize = new System.Drawing.Size(78, 26);
         this.lCI_POS.Name = "lCI_POS";
         this.lCI_POS.Size = new System.Drawing.Size(145, 113);
         this.lCI_POS.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
         this.lCI_POS.TextSize = new System.Drawing.Size(0, 0);
         this.lCI_POS.TextVisible = false;
         // 
         // lCI_UserName
         // 
         this.lCI_UserName.Control = this.txtEdit_UserName;
         this.lCI_UserName.Location = new System.Drawing.Point(0, 26);
         this.lCI_UserName.Name = "lCI_UserName";
         this.lCI_UserName.Size = new System.Drawing.Size(291, 24);
         this.lCI_UserName.Text = "İstifadəçi";
         this.lCI_UserName.TextSize = new System.Drawing.Size(77, 13);
         // 
         // lCI_Password
         // 
         this.lCI_Password.Control = this.txtEdit_Password;
         this.lCI_Password.Location = new System.Drawing.Point(0, 50);
         this.lCI_Password.Name = "lCI_Password";
         this.lCI_Password.Size = new System.Drawing.Size(291, 24);
         this.lCI_Password.Text = "Şifrə";
         this.lCI_Password.TextSize = new System.Drawing.Size(77, 13);
         // 
         // lCI_RemindMe
         // 
         this.lCI_RemindMe.Control = this.checkEdit_RemindMe;
         this.lCI_RemindMe.Location = new System.Drawing.Point(0, 74);
         this.lCI_RemindMe.Name = "lCI_RemindMe";
         this.lCI_RemindMe.Size = new System.Drawing.Size(291, 24);
         this.lCI_RemindMe.TextSize = new System.Drawing.Size(0, 0);
         this.lCI_RemindMe.TextVisible = false;
         // 
         // lCI_ConString
         // 
         this.lCI_ConString.Control = this.txtEdit_conString;
         this.lCI_ConString.Location = new System.Drawing.Point(0, 0);
         this.lCI_ConString.Name = "lCI_ConString";
         this.lCI_ConString.Size = new System.Drawing.Size(213, 26);
         this.lCI_ConString.Text = "Database Əlaqə";
         this.lCI_ConString.TextSize = new System.Drawing.Size(77, 13);
         // 
         // layoutControlItem2
         // 
         this.layoutControlItem2.Control = this.btn_SaveConn;
         this.layoutControlItem2.Location = new System.Drawing.Point(213, 0);
         this.layoutControlItem2.Name = "layoutControlItem2";
         this.layoutControlItem2.Size = new System.Drawing.Size(78, 26);
         this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
         this.layoutControlItem2.TextVisible = false;
         // 
         // toolbarFormControl1
         // 
         this.toolbarFormControl1.Location = new System.Drawing.Point(0, 0);
         this.toolbarFormControl1.Manager = this.toolbarFormManager1;
         this.toolbarFormControl1.Name = "toolbarFormControl1";
         this.toolbarFormControl1.Size = new System.Drawing.Size(311, 31);
         this.toolbarFormControl1.TabIndex = 3;
         this.toolbarFormControl1.TabStop = false;
         this.toolbarFormControl1.TitleItemLinks.Add(this.barButtonItem1);
         this.toolbarFormControl1.ToolbarForm = this;
         // 
         // FormLogin
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(311, 262);
         this.Controls.Add(this.lC_Root);
         this.Controls.Add(this.barDockControlLeft);
         this.Controls.Add(this.barDockControlRight);
         this.Controls.Add(this.barDockControlBottom);
         this.Controls.Add(this.barDockControlTop);
         this.Controls.Add(this.toolbarFormControl1);
         this.Name = "FormLogin";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Giriş";
         this.ToolbarFormControl = this.toolbarFormControl1;
         this.Load += new System.EventHandler(this.FormLogin_Load);
         ((System.ComponentModel.ISupportInitialize)(this.lC_Root)).EndInit();
         this.lC_Root.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.txtEdit_UserName.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtEdit_Password.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.checkEdit_RemindMe.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtEdit_conString.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.toolbarFormManager1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.lCG_Root)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.lCI_ERP)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.lCI_POS)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.lCI_UserName)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.lCI_Password)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.lCI_RemindMe)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.lCI_ConString)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.toolbarFormControl1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

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
   }
}