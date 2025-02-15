namespace Foxoft
{
    partial class RoleClaimsForm
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.ButtonEdit btnEditRole;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnEditRole = new DevExpress.XtraEditors.ButtonEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditRole.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditRole
            // 
            this.btnEditRole.Location = new System.Drawing.Point(12, 12);
            this.btnEditRole.Name = "btnEditRole";
            this.btnEditRole.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnEditRole.Size = new System.Drawing.Size(200, 20);
            this.btnEditRole.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(218, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 50);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(776, 388);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // RoleClaimsForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEditRole);
            this.Name = "RoleClaimsForm";
            ((System.ComponentModel.ISupportInitialize)(this.btnEditRole.Properties)).EndInit();
            this.ResumeLayout(false);
        }
    }
}