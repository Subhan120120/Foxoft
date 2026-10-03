namespace Foxoft
{
    partial class FormUserEdit
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.layout = new DevExpress.XtraLayout.LayoutControl();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.txtUserDesc = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.ButtonEdit();
            this.chkIsDisabled = new DevExpress.XtraEditors.CheckEdit();
            this.gcCompanies = new DevExpress.XtraGrid.GridControl();
            this.gvCompanies = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIsSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colCompanyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnUnselectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciUserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciUserDesc = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciIsDisabled = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgCompanies = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciCompanies = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSelectAll = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciUnselectAll = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroupButtons = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciSave = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCancel = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layout)).BeginInit();
            this.layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsDisabled.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCompanies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCompanies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUserDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciIsDisabled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCompanies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCompanies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUnselectAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // layout
            // 
            this.layout.Controls.Add(this.txtUserName);
            this.layout.Controls.Add(this.txtUserDesc);
            this.layout.Controls.Add(this.txtPassword);
            this.layout.Controls.Add(this.chkIsDisabled);
            this.layout.Controls.Add(this.gcCompanies);
            this.layout.Controls.Add(this.btnSelectAll);
            this.layout.Controls.Add(this.btnUnselectAll);
            this.layout.Controls.Add(this.btnSave);
            this.layout.Controls.Add(this.btnCancel);
            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout.Location = new System.Drawing.Point(0, 0);
            this.layout.Name = "layout";
            this.layout.Root = this.Root;
            this.layout.Size = new System.Drawing.Size(520, 480);
            this.layout.TabIndex = 0;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(120, 12);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.MaxLength = 30;
            this.txtUserName.Size = new System.Drawing.Size(388, 20);
            this.txtUserName.StyleController = this.layout;
            this.txtUserName.TabIndex = 0;
            // 
            // txtUserDesc
            // 
            this.txtUserDesc.Location = new System.Drawing.Point(120, 36);
            this.txtUserDesc.Name = "txtUserDesc";
            this.txtUserDesc.Properties.MaxLength = 100;
            this.txtUserDesc.Size = new System.Drawing.Size(388, 20);
            this.txtUserDesc.StyleController = this.layout;
            this.txtUserDesc.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(120, 60);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.MaxLength = 100;
            this.txtPassword.Properties.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(388, 20);
            this.txtPassword.StyleController = this.layout;
            this.txtPassword.TabIndex = 2;
            // 
            // chkIsDisabled
            // 
            this.chkIsDisabled.Location = new System.Drawing.Point(12, 84);
            this.chkIsDisabled.Name = "chkIsDisabled";
            this.chkIsDisabled.Properties.Caption = Foxoft.Properties.Resources.Entity_User_IsDisabled;
            this.chkIsDisabled.Size = new System.Drawing.Size(496, 20);
            this.chkIsDisabled.StyleController = this.layout;
            this.chkIsDisabled.TabIndex = 3;
            // 
            // gcCompanies
            // 
            this.gcCompanies.Location = new System.Drawing.Point(24, 142);
            this.gcCompanies.MainView = this.gvCompanies;
            this.gcCompanies.Name = "gcCompanies";
            this.gcCompanies.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gcCompanies.Size = new System.Drawing.Size(472, 250);
            this.gcCompanies.TabIndex = 4;
            this.gcCompanies.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCompanies});
            // 
            // gvCompanies
            // 
            this.gvCompanies.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIsSelected,
            this.colCompanyCode,
            this.colCompanyDesc});
            this.gvCompanies.GridControl = this.gcCompanies;
            this.gvCompanies.Name = "gvCompanies";
            this.gvCompanies.OptionsView.ShowGroupPanel = false;
            this.gvCompanies.OptionsView.ShowIndicator = false;
            // 
            // colIsSelected
            // 
            this.colIsSelected.Caption = " ";
            this.colIsSelected.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colIsSelected.FieldName = "IsSelected";
            this.colIsSelected.MaxWidth = 40;
            this.colIsSelected.MinWidth = 40;
            this.colIsSelected.Name = "colIsSelected";
            this.colIsSelected.Visible = true;
            this.colIsSelected.VisibleIndex = 0;
            this.colIsSelected.Width = 40;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colCompanyCode
            // 
            this.colCompanyCode.Caption = Foxoft.Properties.Resources.Entity_Company_Code;
            this.colCompanyCode.FieldName = "CompanyCode";
            this.colCompanyCode.Name = "colCompanyCode";
            this.colCompanyCode.OptionsColumn.AllowEdit = false;
            this.colCompanyCode.Visible = true;
            this.colCompanyCode.VisibleIndex = 1;
            this.colCompanyCode.Width = 140;
            // 
            // colCompanyDesc
            // 
            this.colCompanyDesc.Caption = Foxoft.Properties.Resources.Entity_Company_Desc;
            this.colCompanyDesc.FieldName = "CompanyDesc";
            this.colCompanyDesc.Name = "colCompanyDesc";
            this.colCompanyDesc.OptionsColumn.AllowEdit = false;
            this.colCompanyDesc.Visible = true;
            this.colCompanyDesc.VisibleIndex = 2;
            this.colCompanyDesc.Width = 270;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(24, 396);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(234, 22);
            this.btnSelectAll.StyleController = this.layout;
            this.btnSelectAll.TabIndex = 5;
            this.btnSelectAll.Text = Foxoft.Properties.Resources.Form_UserEdit_SelectAll;
            // 
            // btnUnselectAll
            // 
            this.btnUnselectAll.Location = new System.Drawing.Point(262, 396);
            this.btnUnselectAll.Name = "btnUnselectAll";
            this.btnUnselectAll.Size = new System.Drawing.Size(234, 22);
            this.btnUnselectAll.StyleController = this.layout;
            this.btnUnselectAll.TabIndex = 6;
            this.btnUnselectAll.Text = Foxoft.Properties.Resources.Form_UserEdit_UnselectAll;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 436);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(246, 32);
            this.btnSave.StyleController = this.layout;
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = Foxoft.Properties.Resources.Common_Save;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(262, 436);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(246, 32);
            this.btnCancel.StyleController = this.layout;
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = Foxoft.Properties.Resources.Common_Cancel;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciUserName,
            this.lciUserDesc,
            this.lciPassword,
            this.lciIsDisabled,
            this.lcgCompanies,
            this.layoutControlGroupButtons});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(520, 480);
            this.Root.TextVisible = false;
            // 
            // lciUserName
            // 
            this.lciUserName.Control = this.txtUserName;
            this.lciUserName.Location = new System.Drawing.Point(0, 0);
            this.lciUserName.Name = "lciUserName";
            this.lciUserName.Size = new System.Drawing.Size(500, 24);
            this.lciUserName.Text = Foxoft.Properties.Resources.Entity_User_UserName;
            this.lciUserName.TextSize = new System.Drawing.Size(100, 13);
            // 
            // lciUserDesc
            // 
            this.lciUserDesc.Control = this.txtUserDesc;
            this.lciUserDesc.Location = new System.Drawing.Point(0, 24);
            this.lciUserDesc.Name = "lciUserDesc";
            this.lciUserDesc.Size = new System.Drawing.Size(500, 24);
            this.lciUserDesc.Text = Foxoft.Properties.Resources.Entity_User_UserDesc;
            this.lciUserDesc.TextSize = new System.Drawing.Size(100, 13);
            // 
            // lciPassword
            // 
            this.lciPassword.Control = this.txtPassword;
            this.lciPassword.Location = new System.Drawing.Point(0, 48);
            this.lciPassword.Name = "lciPassword";
            this.lciPassword.Size = new System.Drawing.Size(500, 24);
            this.lciPassword.Text = Foxoft.Properties.Resources.Entity_User_Password;
            this.lciPassword.TextSize = new System.Drawing.Size(100, 13);
            // 
            // lciIsDisabled
            // 
            this.lciIsDisabled.Control = this.chkIsDisabled;
            this.lciIsDisabled.Location = new System.Drawing.Point(0, 72);
            this.lciIsDisabled.Name = "lciIsDisabled";
            this.lciIsDisabled.Size = new System.Drawing.Size(500, 24);
            this.lciIsDisabled.TextSize = new System.Drawing.Size(0, 0);
            this.lciIsDisabled.TextVisible = false;
            // 
            // lcgCompanies
            // 
            this.lcgCompanies.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciCompanies,
            this.lciSelectAll,
            this.lciUnselectAll});
            this.lcgCompanies.Location = new System.Drawing.Point(0, 96);
            this.lcgCompanies.Name = "lcgCompanies";
            this.lcgCompanies.Size = new System.Drawing.Size(500, 328);
            this.lcgCompanies.Text = Foxoft.Properties.Resources.Form_UserEdit_CompaniesGroup;
            // 
            // lciCompanies
            // 
            this.lciCompanies.Control = this.gcCompanies;
            this.lciCompanies.Location = new System.Drawing.Point(0, 0);
            this.lciCompanies.Name = "lciCompanies";
            this.lciCompanies.Size = new System.Drawing.Size(476, 254);
            this.lciCompanies.TextSize = new System.Drawing.Size(0, 0);
            this.lciCompanies.TextVisible = false;
            // 
            // lciSelectAll
            // 
            this.lciSelectAll.Control = this.btnSelectAll;
            this.lciSelectAll.Location = new System.Drawing.Point(0, 254);
            this.lciSelectAll.Name = "lciSelectAll";
            this.lciSelectAll.Size = new System.Drawing.Size(238, 26);
            this.lciSelectAll.TextSize = new System.Drawing.Size(0, 0);
            this.lciSelectAll.TextVisible = false;
            // 
            // lciUnselectAll
            // 
            this.lciUnselectAll.Control = this.btnUnselectAll;
            this.lciUnselectAll.Location = new System.Drawing.Point(238, 254);
            this.lciUnselectAll.Name = "lciUnselectAll";
            this.lciUnselectAll.Size = new System.Drawing.Size(238, 26);
            this.lciUnselectAll.TextSize = new System.Drawing.Size(0, 0);
            this.lciUnselectAll.TextVisible = false;
            // 
            // layoutControlGroupButtons
            // 
            this.layoutControlGroupButtons.GroupBordersVisible = false;
            this.layoutControlGroupButtons.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciSave,
            this.lciCancel});
            this.layoutControlGroupButtons.Location = new System.Drawing.Point(0, 424);
            this.layoutControlGroupButtons.Name = "layoutControlGroupButtons";
            this.layoutControlGroupButtons.Size = new System.Drawing.Size(500, 36);
            this.layoutControlGroupButtons.TextVisible = false;
            // 
            // lciSave
            // 
            this.lciSave.Control = this.btnSave;
            this.lciSave.Location = new System.Drawing.Point(0, 0);
            this.lciSave.Name = "lciSave";
            this.lciSave.Size = new System.Drawing.Size(250, 36);
            this.lciSave.TextSize = new System.Drawing.Size(0, 0);
            this.lciSave.TextVisible = false;
            // 
            // lciCancel
            // 
            this.lciCancel.Control = this.btnCancel;
            this.lciCancel.Location = new System.Drawing.Point(250, 0);
            this.lciCancel.Name = "lciCancel";
            this.lciCancel.Size = new System.Drawing.Size(250, 36);
            this.lciCancel.TextSize = new System.Drawing.Size(0, 0);
            this.lciCancel.TextVisible = false;
            // 
            // FormUserEdit
            // 
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 480);
            this.Controls.Add(this.layout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUserEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.layout)).EndInit();
            this.layout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsDisabled.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCompanies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCompanies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUserDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciIsDisabled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgCompanies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCompanies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUnselectAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layout;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.TextEdit txtUserDesc;
        private DevExpress.XtraEditors.ButtonEdit txtPassword;
        private DevExpress.XtraEditors.CheckEdit chkIsDisabled;
        private DevExpress.XtraGrid.GridControl gcCompanies;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCompanies;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSelected;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyDesc;
        private DevExpress.XtraEditors.SimpleButton btnSelectAll;
        private DevExpress.XtraEditors.SimpleButton btnUnselectAll;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem lciUserName;
        private DevExpress.XtraLayout.LayoutControlItem lciUserDesc;
        private DevExpress.XtraLayout.LayoutControlItem lciPassword;
        private DevExpress.XtraLayout.LayoutControlItem lciIsDisabled;
        private DevExpress.XtraLayout.LayoutControlGroup lcgCompanies;
        private DevExpress.XtraLayout.LayoutControlItem lciCompanies;
        private DevExpress.XtraLayout.LayoutControlItem lciSelectAll;
        private DevExpress.XtraLayout.LayoutControlItem lciUnselectAll;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupButtons;
        private DevExpress.XtraLayout.LayoutControlItem lciSave;
        private DevExpress.XtraLayout.LayoutControlItem lciCancel;
    }
}
