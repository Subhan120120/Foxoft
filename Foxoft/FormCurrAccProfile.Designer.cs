namespace Foxoft
{
    partial class FormCurrAccProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCurrAccProfile));
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            BBI_Add = new DevExpress.XtraBars.BarButtonItem();
            BBI_Delete = new DevExpress.XtraBars.BarButtonItem();
            BBI_EditCurrAccRole = new DevExpress.XtraBars.BarButtonItem();
            BBI_AddRoleClaim = new DevExpress.XtraBars.BarButtonItem();
            BBI_EditRoleClaim = new DevExpress.XtraBars.BarButtonItem();
            BBI_DeleteRoleClaim = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            btnEdit_CurrAccCode = new DevExpress.XtraEditors.ButtonEdit();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            btn_Save = new Button();
            txtEdit_ConfirmPassword = new DevExpress.XtraEditors.TextEdit();
            txtEdit_NewPassword = new DevExpress.XtraEditors.TextEdit();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            bindingSource1 = new BindingSource(components);
            gV_CurrAccRole = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCurrAccRoleId = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            col_CurrAccDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            colRoleCode = new DevExpress.XtraGrid.Columns.GridColumn();
            col_RoleDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            LCI_NewPassword = new DevExpress.XtraLayout.LayoutControlItem();
            LCI_ConfirmPassword = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            gridControl2 = new DevExpress.XtraGrid.GridControl();
            bindingSource2 = new BindingSource(components);
            gv_RoleClaim = new DevExpress.XtraGrid.Views.Grid.GridView();
            colRoleClaimId = new DevExpress.XtraGrid.Columns.GridColumn();
            colRoleCode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            colClaimCode = new DevExpress.XtraGrid.Columns.GridColumn();
            btnEdit_RoleCode = new DevExpress.XtraEditors.ButtonEdit();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            Rol = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_CurrAccCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtEdit_ConfirmPassword.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_NewPassword.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gV_CurrAccRole).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_NewPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_ConfirmPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl2).BeginInit();
            layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gv_RoleClaim).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_RoleCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Rol).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dxErrorProvider1).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbon.ExpandCollapseItem, BBI_Add, BBI_Delete, BBI_EditCurrAccRole, BBI_AddRoleClaim, BBI_EditRoleClaim, BBI_DeleteRoleClaim });
            ribbon.Location = new Point(0, 0);
            ribbon.MaxItemId = 9;
            ribbon.Name = "ribbon";
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbon.Size = new Size(1320, 158);
            ribbon.StatusBar = ribbonStatusBar;
            // 
            // BBI_Add
            // 
            BBI_Add.Caption = "Əlavə Et";
            BBI_Add.Id = 1;
            BBI_Add.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Add.ImageOptions.SvgImage");
            BBI_Add.Name = "BBI_Add";
            BBI_Add.ItemClick += BBI_Add_ItemClick;
            // 
            // BBI_Delete
            // 
            BBI_Delete.Caption = "Sil";
            BBI_Delete.Id = 3;
            BBI_Delete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_Delete.ImageOptions.SvgImage");
            BBI_Delete.Name = "BBI_Delete";
            BBI_Delete.ItemClick += BBI_Delete_ItemClick;
            // 
            // BBI_EditCurrAccRole
            // 
            BBI_EditCurrAccRole.Caption = "Dəyiş";
            BBI_EditCurrAccRole.Id = 4;
            BBI_EditCurrAccRole.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_EditCurrAccRole.ImageOptions.SvgImage");
            BBI_EditCurrAccRole.Name = "BBI_EditCurrAccRole";
            BBI_EditCurrAccRole.ItemClick += BBI_EditCurrAccRole_ItemClick;
            // 
            // BBI_AddRoleClaim
            // 
            BBI_AddRoleClaim.Caption = "Əlavə Et";
            BBI_AddRoleClaim.Id = 6;
            BBI_AddRoleClaim.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_AddRoleClaim.ImageOptions.SvgImage");
            BBI_AddRoleClaim.Name = "BBI_AddRoleClaim";
            BBI_AddRoleClaim.ItemClick += BBI_AddRoleClaim_ItemClick;
            // 
            // BBI_EditRoleClaim
            // 
            BBI_EditRoleClaim.Caption = "Dəyiş";
            BBI_EditRoleClaim.Id = 7;
            BBI_EditRoleClaim.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_EditRoleClaim.ImageOptions.SvgImage");
            BBI_EditRoleClaim.Name = "BBI_EditRoleClaim";
            BBI_EditRoleClaim.ItemClick += BBI_EditRoleClaim_ItemClick;
            // 
            // BBI_DeleteRoleClaim
            // 
            BBI_DeleteRoleClaim.Caption = "Sil";
            BBI_DeleteRoleClaim.Id = 8;
            BBI_DeleteRoleClaim.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("BBI_DeleteRoleClaim.ImageOptions.SvgImage");
            BBI_DeleteRoleClaim.Name = "BBI_DeleteRoleClaim";
            BBI_DeleteRoleClaim.ItemClick += BBI_DeleteRoleClaim_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup2 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Cari Hesab Yetkisi";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(BBI_Add);
            ribbonPageGroup1.ItemLinks.Add(BBI_EditCurrAccRole);
            ribbonPageGroup1.ItemLinks.Add(BBI_Delete);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Cari Hesab Rolu";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(BBI_AddRoleClaim);
            ribbonPageGroup2.ItemLinks.Add(BBI_EditRoleClaim);
            ribbonPageGroup2.ItemLinks.Add(BBI_DeleteRoleClaim);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Rol Yetkisi";
            // 
            // ribbonStatusBar
            // 
            ribbonStatusBar.Location = new Point(0, 524);
            ribbonStatusBar.Name = "ribbonStatusBar";
            ribbonStatusBar.Ribbon = ribbon;
            ribbonStatusBar.Size = new Size(1320, 24);
            // 
            // btnEdit_CurrAccCode
            // 
            btnEdit_CurrAccCode.Location = new Point(96, 12);
            btnEdit_CurrAccCode.MenuManager = ribbon;
            btnEdit_CurrAccCode.Name = "btnEdit_CurrAccCode";
            btnEdit_CurrAccCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            btnEdit_CurrAccCode.Size = new Size(521, 20);
            btnEdit_CurrAccCode.StyleController = layoutControl1;
            btnEdit_CurrAccCode.TabIndex = 2;
            btnEdit_CurrAccCode.ButtonPressed += btnEdit_CurrAccCode_ButtonPressed;
            btnEdit_CurrAccCode.EditValueChanged += btnEdit_CurrAccCode_EditValueChanged;
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(btn_Save);
            layoutControl1.Controls.Add(txtEdit_ConfirmPassword);
            layoutControl1.Controls.Add(txtEdit_NewPassword);
            layoutControl1.Controls.Add(gridControl1);
            layoutControl1.Controls.Add(btnEdit_CurrAccCode);
            layoutControl1.Dock = DockStyle.Left;
            layoutControl1.Location = new Point(0, 158);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(228, 0, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(629, 366);
            layoutControl1.TabIndex = 3;
            layoutControl1.Text = "layoutControl1";
            // 
            // btn_Save
            // 
            btn_Save.Location = new Point(457, 84);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(160, 20);
            btn_Save.TabIndex = 7;
            btn_Save.Text = "Yadda Saxla";
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // txtEdit_ConfirmPassword
            // 
            txtEdit_ConfirmPassword.Location = new Point(96, 60);
            txtEdit_ConfirmPassword.MenuManager = ribbon;
            txtEdit_ConfirmPassword.Name = "txtEdit_ConfirmPassword";
            txtEdit_ConfirmPassword.Properties.PasswordChar = '*';
            txtEdit_ConfirmPassword.Size = new Size(521, 20);
            txtEdit_ConfirmPassword.StyleController = layoutControl1;
            txtEdit_ConfirmPassword.TabIndex = 6;
            // 
            // txtEdit_NewPassword
            // 
            txtEdit_NewPassword.Location = new Point(96, 36);
            txtEdit_NewPassword.MenuManager = ribbon;
            txtEdit_NewPassword.Name = "txtEdit_NewPassword";
            txtEdit_NewPassword.Properties.PasswordChar = '*';
            txtEdit_NewPassword.Size = new Size(521, 20);
            txtEdit_NewPassword.StyleController = layoutControl1;
            txtEdit_NewPassword.TabIndex = 5;
            // 
            // gridControl1
            // 
            gridControl1.DataSource = bindingSource1;
            gridControl1.Location = new Point(12, 108);
            gridControl1.MainView = gV_CurrAccRole;
            gridControl1.MenuManager = ribbon;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(605, 246);
            gridControl1.TabIndex = 4;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gV_CurrAccRole });
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = typeof(Models.TrCurrAccRole);
            // 
            // gV_CurrAccRole
            // 
            gV_CurrAccRole.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCurrAccRoleId, colCurrAccCode, col_CurrAccDesc, colRoleCode, col_RoleDesc });
            gV_CurrAccRole.GridControl = gridControl1;
            gV_CurrAccRole.Name = "gV_CurrAccRole";
            gV_CurrAccRole.FocusedRowChanged += gV_CurrAccRole_FocusedRowChanged;
            gV_CurrAccRole.CustomUnboundColumnData += gV_CurrAccRole_CustomUnboundColumnData;
            // 
            // colCurrAccRoleId
            // 
            colCurrAccRoleId.FieldName = "CurrAccRoleId";
            colCurrAccRoleId.Name = "colCurrAccRoleId";
            // 
            // colCurrAccCode
            // 
            colCurrAccCode.FieldName = "CurrAccCode";
            colCurrAccCode.Name = "colCurrAccCode";
            colCurrAccCode.Visible = true;
            colCurrAccCode.VisibleIndex = 0;
            // 
            // col_CurrAccDesc
            // 
            col_CurrAccDesc.Caption = "gridColumn1";
            col_CurrAccDesc.FieldName = "DcCurrAcc.FirstName";
            col_CurrAccDesc.Name = "col_CurrAccDesc";
            col_CurrAccDesc.UnboundDataType = typeof(string);
            col_CurrAccDesc.Visible = true;
            col_CurrAccDesc.VisibleIndex = 1;
            // 
            // colRoleCode
            // 
            colRoleCode.FieldName = "RoleCode";
            colRoleCode.Name = "colRoleCode";
            colRoleCode.Visible = true;
            colRoleCode.VisibleIndex = 2;
            // 
            // col_RoleDesc
            // 
            col_RoleDesc.Caption = "gridColumn2";
            col_RoleDesc.FieldName = "DcRole.RoleDesc";
            col_RoleDesc.Name = "col_RoleDesc";
            col_RoleDesc.UnboundDataType = typeof(string);
            col_RoleDesc.Visible = true;
            col_RoleDesc.VisibleIndex = 3;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, LCI_NewPassword, LCI_ConfirmPassword, layoutControlItem3, emptySpaceItem1 });
            Root.Name = "Root";
            Root.Size = new Size(629, 366);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = btnEdit_CurrAccCode;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(609, 24);
            layoutControlItem1.Text = "Cari Hesab";
            layoutControlItem1.TextSize = new Size(72, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = gridControl1;
            layoutControlItem2.Location = new Point(0, 96);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(609, 250);
            layoutControlItem2.TextSize = new Size(0, 0);
            layoutControlItem2.TextVisible = false;
            // 
            // LCI_NewPassword
            // 
            LCI_NewPassword.Control = txtEdit_NewPassword;
            LCI_NewPassword.Location = new Point(0, 24);
            LCI_NewPassword.Name = "LCI_NewPassword";
            LCI_NewPassword.Size = new Size(609, 24);
            LCI_NewPassword.Text = "Yeni Şifrə";
            LCI_NewPassword.TextSize = new Size(72, 13);
            // 
            // LCI_ConfirmPassword
            // 
            LCI_ConfirmPassword.Control = txtEdit_ConfirmPassword;
            LCI_ConfirmPassword.Location = new Point(0, 48);
            LCI_ConfirmPassword.Name = "LCI_ConfirmPassword";
            LCI_ConfirmPassword.Size = new Size(609, 24);
            LCI_ConfirmPassword.Text = "Şifrəni Təsdiqlə";
            LCI_ConfirmPassword.TextSize = new Size(72, 13);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = btn_Save;
            layoutControlItem3.Location = new Point(445, 72);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(164, 24);
            layoutControlItem3.TextSize = new Size(0, 0);
            layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.AllowHotTrack = false;
            emptySpaceItem1.Location = new Point(0, 72);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(445, 24);
            emptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // splitterControl1
            // 
            splitterControl1.Location = new Point(629, 158);
            splitterControl1.Name = "splitterControl1";
            splitterControl1.Size = new Size(10, 366);
            splitterControl1.TabIndex = 6;
            splitterControl1.TabStop = false;
            // 
            // layoutControl2
            // 
            layoutControl2.Controls.Add(gridControl2);
            layoutControl2.Controls.Add(btnEdit_RoleCode);
            layoutControl2.Dock = DockStyle.Fill;
            layoutControl2.Location = new Point(639, 158);
            layoutControl2.Name = "layoutControl2";
            layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(1270, 233, 650, 400);
            layoutControl2.Root = layoutControlGroup1;
            layoutControl2.Size = new Size(681, 366);
            layoutControl2.TabIndex = 7;
            layoutControl2.Text = "layoutControl2";
            // 
            // gridControl2
            // 
            gridControl2.DataSource = bindingSource2;
            gridControl2.Location = new Point(12, 36);
            gridControl2.MainView = gv_RoleClaim;
            gridControl2.MenuManager = ribbon;
            gridControl2.Name = "gridControl2";
            gridControl2.Size = new Size(657, 318);
            gridControl2.TabIndex = 5;
            gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gv_RoleClaim });
            // 
            // bindingSource2
            // 
            bindingSource2.DataSource = typeof(Models.TrRoleClaim);
            // 
            // gv_RoleClaim
            // 
            gv_RoleClaim.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colRoleClaimId, colRoleCode1, colClaimCode });
            gv_RoleClaim.GridControl = gridControl2;
            gv_RoleClaim.Name = "gv_RoleClaim";
            // 
            // colRoleClaimId
            // 
            colRoleClaimId.FieldName = "RoleClaimId";
            colRoleClaimId.Name = "colRoleClaimId";
            // 
            // colRoleCode1
            // 
            colRoleCode1.FieldName = "RoleCode";
            colRoleCode1.Name = "colRoleCode1";
            colRoleCode1.Visible = true;
            colRoleCode1.VisibleIndex = 0;
            // 
            // colClaimCode
            // 
            colClaimCode.FieldName = "ClaimCode";
            colClaimCode.Name = "colClaimCode";
            colClaimCode.Visible = true;
            colClaimCode.VisibleIndex = 1;
            // 
            // btnEdit_RoleCode
            // 
            btnEdit_RoleCode.Location = new Point(39, 12);
            btnEdit_RoleCode.MenuManager = ribbon;
            btnEdit_RoleCode.Name = "btnEdit_RoleCode";
            btnEdit_RoleCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            btnEdit_RoleCode.Size = new Size(630, 20);
            btnEdit_RoleCode.StyleController = layoutControl2;
            btnEdit_RoleCode.TabIndex = 4;
            btnEdit_RoleCode.ButtonPressed += btnEdit_RoleCode_ButtonPressed;
            btnEdit_RoleCode.EditValueChanged += btnEdit_RoleCode_EditValueChanged;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { Rol, layoutControlItem4 });
            layoutControlGroup1.Name = "Root";
            layoutControlGroup1.Size = new Size(681, 366);
            layoutControlGroup1.TextVisible = false;
            // 
            // Rol
            // 
            Rol.Control = btnEdit_RoleCode;
            Rol.Location = new Point(0, 0);
            Rol.Name = "Rol";
            Rol.Size = new Size(661, 24);
            Rol.TextSize = new Size(15, 13);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = gridControl2;
            layoutControlItem4.Location = new Point(0, 24);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(661, 322);
            layoutControlItem4.TextSize = new Size(0, 0);
            layoutControlItem4.TextVisible = false;
            // 
            // dxErrorProvider1
            // 
            dxErrorProvider1.ContainerControl = this;
            // 
            // FormCurrAccProfile
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1320, 548);
            Controls.Add(layoutControl2);
            Controls.Add(splitterControl1);
            Controls.Add(layoutControl1);
            Controls.Add(ribbonStatusBar);
            Controls.Add(ribbon);
            Name = "FormCurrAccProfile";
            Ribbon = ribbon;
            StatusBar = ribbonStatusBar;
            Text = "FormCurrAccRole";
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_CurrAccCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtEdit_ConfirmPassword.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_NewPassword.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gV_CurrAccRole).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_NewPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_ConfirmPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl2).EndInit();
            layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControl2).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).EndInit();
            ((System.ComponentModel.ISupportInitialize)gv_RoleClaim).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit_RoleCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Rol).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)dxErrorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.ButtonEdit btnEdit_CurrAccCode;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_CurrAccRole;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccRoleId;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRoleCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_CurrAccDesc;
        private DevExpress.XtraGrid.Columns.GridColumn col_RoleDesc;
        private DevExpress.XtraBars.BarButtonItem BBI_Add;
        private DevExpress.XtraBars.BarButtonItem BBI_Delete;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_RoleClaim;
        private DevExpress.XtraEditors.ButtonEdit btnEdit_RoleCode;
        private DevExpress.XtraLayout.LayoutControlItem Rol;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private BindingSource bindingSource2;
        private DevExpress.XtraGrid.Columns.GridColumn colRoleClaimId;
        private DevExpress.XtraGrid.Columns.GridColumn colClaimCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRoleCode1;
        private DevExpress.XtraBars.BarButtonItem BBI_EditCurrAccRole;
        private DevExpress.XtraBars.BarButtonItem BBI_AddRoleClaim;
        private DevExpress.XtraBars.BarButtonItem BBI_EditRoleClaim;
        private DevExpress.XtraBars.BarButtonItem BBI_DeleteRoleClaim;
        private DevExpress.XtraEditors.TextEdit txtEdit_ConfirmPassword;
        private DevExpress.XtraEditors.TextEdit txtEdit_NewPassword;
        private DevExpress.XtraLayout.LayoutControlItem LCI_NewPassword;
        private DevExpress.XtraLayout.LayoutControlItem LCI_ConfirmPassword;
        private Button btn_Save;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
    }
}