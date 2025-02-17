namespace Foxoft
{
    partial class RoleClaimsForm
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.ButtonEdit buttonEditRole;
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
            this.buttonEditRole = new DevExpress.XtraEditors.ButtonEdit();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditRole.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonEditRole
            // 
            this.buttonEditRole.Location = new System.Drawing.Point(12, 12);
            this.buttonEditRole.Name = "buttonEditRole";
            this.buttonEditRole.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEditRole.Size = new System.Drawing.Size(200, 20);
            this.buttonEditRole.TabIndex = 0;
            this.buttonEditRole.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditRole_ButtonClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 50);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(776, 388);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // RoleClaimsForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.buttonEditRole);
            this.Name = "RoleClaimsForm";
            this.Text = "Role Claims Management";
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditRole.Properties)).EndInit();
            this.ResumeLayout(false);
        }
    }
}