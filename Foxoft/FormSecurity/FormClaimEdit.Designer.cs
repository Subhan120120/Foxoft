namespace Foxoft
{
    partial class FormClaimEdit
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
            this.txtClaimCode = new DevExpress.XtraEditors.TextEdit();
            this.txtClaimDesc = new DevExpress.XtraEditors.TextEdit();
            this.lkpCategory = new DevExpress.XtraEditors.LookUpEdit();
            this.lkpClaimType = new DevExpress.XtraEditors.LookUpEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciClaimCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciClaimDesc = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCategory = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciClaimType = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroupButtons = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciSave = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCancel = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layout)).BeginInit();
            this.layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtClaimCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClaimDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpClaimType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciClaimCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciClaimDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciClaimType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // layout
            // 
            this.layout.Controls.Add(this.txtClaimCode);
            this.layout.Controls.Add(this.txtClaimDesc);
            this.layout.Controls.Add(this.lkpCategory);
            this.layout.Controls.Add(this.lkpClaimType);
            this.layout.Controls.Add(this.btnSave);
            this.layout.Controls.Add(this.btnCancel);
            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout.Location = new System.Drawing.Point(0, 0);
            this.layout.Name = "layout";
            this.layout.Root = this.Root;
            this.layout.Size = new System.Drawing.Size(460, 200);
            this.layout.TabIndex = 0;
            // 
            // txtClaimCode
            // 
            this.txtClaimCode.Location = new System.Drawing.Point(100, 12);
            this.txtClaimCode.Name = "txtClaimCode";
            this.txtClaimCode.Size = new System.Drawing.Size(348, 20);
            this.txtClaimCode.StyleController = this.layout;
            this.txtClaimCode.TabIndex = 0;
            // 
            // txtClaimDesc
            // 
            this.txtClaimDesc.Location = new System.Drawing.Point(100, 36);
            this.txtClaimDesc.Name = "txtClaimDesc";
            this.txtClaimDesc.Size = new System.Drawing.Size(348, 20);
            this.txtClaimDesc.StyleController = this.layout;
            this.txtClaimDesc.TabIndex = 1;
            // 
            // lkpCategory
            // 
            this.lkpCategory.Location = new System.Drawing.Point(100, 60);
            this.lkpCategory.Name = "lkpCategory";
            this.lkpCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpCategory.Properties.NullText = "";
            this.lkpCategory.Properties.ShowHeader = true;
            this.lkpCategory.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            this.lkpCategory.Size = new System.Drawing.Size(348, 20);
            this.lkpCategory.StyleController = this.layout;
            this.lkpCategory.TabIndex = 2;
            // 
            // lkpClaimType
            // 
            this.lkpClaimType.Location = new System.Drawing.Point(100, 84);
            this.lkpClaimType.Name = "lkpClaimType";
            this.lkpClaimType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpClaimType.Properties.NullText = "";
            this.lkpClaimType.Properties.ShowHeader = true;
            this.lkpClaimType.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            this.lkpClaimType.Size = new System.Drawing.Size(348, 20);
            this.lkpClaimType.StyleController = this.layout;
            this.lkpClaimType.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(24, 132);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(204, 24);
            this.btnSave.StyleController = this.layout;
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = Foxoft.Properties.Resources.Common_Save;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(232, 132);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(204, 24);
            this.btnCancel.StyleController = this.layout;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = Foxoft.Properties.Resources.Common_Cancel;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciClaimCode,
            this.lciClaimDesc,
            this.lciCategory,
            this.lciClaimType,
            this.layoutControlGroupButtons});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(460, 200);
            this.Root.TextVisible = false;
            // 
            // lciClaimCode
            // 
            this.lciClaimCode.Control = this.txtClaimCode;
            this.lciClaimCode.Location = new System.Drawing.Point(0, 0);
            this.lciClaimCode.Name = "lciClaimCode";
            this.lciClaimCode.Size = new System.Drawing.Size(440, 24);
            this.lciClaimCode.Text = Foxoft.Properties.Resources.Entity_Claim_Code;
            this.lciClaimCode.TextSize = new System.Drawing.Size(80, 13);
            // 
            // lciClaimDesc
            // 
            this.lciClaimDesc.Control = this.txtClaimDesc;
            this.lciClaimDesc.Location = new System.Drawing.Point(0, 24);
            this.lciClaimDesc.Name = "lciClaimDesc";
            this.lciClaimDesc.Size = new System.Drawing.Size(440, 24);
            this.lciClaimDesc.Text = Foxoft.Properties.Resources.Entity_Claim_Desc;
            this.lciClaimDesc.TextSize = new System.Drawing.Size(80, 13);
            // 
            // lciCategory
            // 
            this.lciCategory.Control = this.lkpCategory;
            this.lciCategory.Location = new System.Drawing.Point(0, 48);
            this.lciCategory.Name = "lciCategory";
            this.lciCategory.Size = new System.Drawing.Size(440, 24);
            this.lciCategory.Text = Foxoft.Properties.Resources.Entity_Claim_CategoryId;
            this.lciCategory.TextSize = new System.Drawing.Size(80, 13);
            // 
            // lciClaimType
            // 
            this.lciClaimType.Control = this.lkpClaimType;
            this.lciClaimType.Location = new System.Drawing.Point(0, 72);
            this.lciClaimType.Name = "lciClaimType";
            this.lciClaimType.Size = new System.Drawing.Size(440, 24);
            this.lciClaimType.Text = Foxoft.Properties.Resources.Entity_Claim_TypeId;
            this.lciClaimType.TextSize = new System.Drawing.Size(80, 13);
            // 
            // layoutControlGroupButtons
            // 
            this.layoutControlGroupButtons.GroupBordersVisible = false;
            this.layoutControlGroupButtons.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciSave,
            this.lciCancel});
            this.layoutControlGroupButtons.Location = new System.Drawing.Point(0, 116);
            this.layoutControlGroupButtons.Name = "layoutControlGroupButtons";
            this.layoutControlGroupButtons.Size = new System.Drawing.Size(440, 64);
            this.layoutControlGroupButtons.TextVisible = false;
            // 
            // lciSave
            // 
            this.lciSave.Control = this.btnSave;
            this.lciSave.Location = new System.Drawing.Point(0, 0);
            this.lciSave.Name = "lciSave";
            this.lciSave.Size = new System.Drawing.Size(220, 64);
            this.lciSave.TextSize = new System.Drawing.Size(0, 0);
            this.lciSave.TextVisible = false;
            // 
            // lciCancel
            // 
            this.lciCancel.Control = this.btnCancel;
            this.lciCancel.Location = new System.Drawing.Point(220, 0);
            this.lciCancel.Name = "lciCancel";
            this.lciCancel.Size = new System.Drawing.Size(220, 64);
            this.lciCancel.TextSize = new System.Drawing.Size(0, 0);
            this.lciCancel.TextVisible = false;
            // 
            // FormClaimEdit
            // 
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 185);
            this.Controls.Add(this.layout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormClaimEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.layout)).EndInit();
            this.layout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtClaimCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClaimDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpClaimType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciClaimCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciClaimDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciClaimType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layout;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txtClaimCode;
        private DevExpress.XtraEditors.TextEdit txtClaimDesc;
        private DevExpress.XtraEditors.LookUpEdit lkpCategory;
        private DevExpress.XtraEditors.LookUpEdit lkpClaimType;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem lciClaimCode;
        private DevExpress.XtraLayout.LayoutControlItem lciClaimDesc;
        private DevExpress.XtraLayout.LayoutControlItem lciCategory;
        private DevExpress.XtraLayout.LayoutControlItem lciClaimType;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupButtons;
        private DevExpress.XtraLayout.LayoutControlItem lciSave;
        private DevExpress.XtraLayout.LayoutControlItem lciCancel;
    }
}
