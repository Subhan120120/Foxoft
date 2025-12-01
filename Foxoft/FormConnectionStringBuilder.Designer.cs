using Foxoft.Properties;

namespace Foxoft
{
    partial class FormConnectionStringBuilder
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

        private void InitializeComponent()
        {
            lblServer = new Label();
            txtServer = new TextBox();
            lblDatabase = new Label();
            txtDatabase = new TextBox();
            lblUser = new Label();
            txtUser = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            txtConnectionString = new TextBox();
            btnTestConnection = new Button();
            lblConnectionTestResult = new Label();
            btnSave = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // lblServer
            // 
            lblServer.AutoSize = true;
            lblServer.Location = new Point(12, 15);
            lblServer.Name = "lblServer";
            lblServer.Size = new Size(42, 15);
            lblServer.TabIndex = 0;
            lblServer.Text = Resources.Form_Connection_Server;
            // 
            // txtServer
            // 
            txtServer.Location = new Point(100, 12);
            txtServer.Name = "txtServer";
            txtServer.Size = new Size(172, 23);
            txtServer.TabIndex = 1;
            txtServer.TextChanged += GenerateConnectionString;
            // 
            // lblDatabase
            // 
            lblDatabase.AutoSize = true;
            lblDatabase.Location = new Point(12, 41);
            lblDatabase.Name = "lblDatabase";
            lblDatabase.Size = new Size(58, 15);
            lblDatabase.TabIndex = 2;
            lblDatabase.Text = Resources.Form_Connection_Database;
            // 
            // txtDatabase
            // 
            txtDatabase.Location = new Point(100, 38);
            txtDatabase.Name = "txtDatabase";
            txtDatabase.Size = new Size(172, 23);
            txtDatabase.TabIndex = 3;
            txtDatabase.TextChanged += GenerateConnectionString;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(12, 67);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(33, 15);
            lblUser.TabIndex = 4;
            lblUser.Text = Resources.Form_Connection_User;
            // 
            // txtUser
            // 
            txtUser.Location = new Point(100, 64);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(172, 23);
            txtUser.TabIndex = 5;
            txtUser.TextChanged += GenerateConnectionString;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(12, 93);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 6;
            lblPassword.Text = Resources.Form_Connection_Password;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(100, 90);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(172, 23);
            txtPassword.TabIndex = 7;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += GenerateConnectionString;
            // 
            // txtConnectionString
            // 
            txtConnectionString.Location = new Point(15, 145);
            txtConnectionString.Name = "txtConnectionString";
            txtConnectionString.ReadOnly = true;
            txtConnectionString.Size = new Size(257, 23);
            txtConnectionString.TabIndex = 9;
            txtConnectionString.PlaceholderText = Resources.Form_Connection_ConnectionString;
            // 
            // btnTestConnection
            // 
            btnTestConnection.Location = new Point(121, 171);
            btnTestConnection.Name = "btnTestConnection";
            btnTestConnection.Size = new Size(151, 23);
            btnTestConnection.TabIndex = 10;
            btnTestConnection.Text = Resources.Form_Connection_TestConnection;
            btnTestConnection.UseVisualStyleBackColor = true;
            btnTestConnection.Click += btnTestConnection_Click;
            // 
            // lblConnectionTestResult
            // 
            lblConnectionTestResult.AutoSize = true;
            lblConnectionTestResult.Location = new Point(12, 197);
            lblConnectionTestResult.Name = "lblConnectionTestResult";
            lblConnectionTestResult.Size = new Size(0, 15);
            lblConnectionTestResult.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(121, 229);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(151, 23);
            btnSave.TabIndex = 12;
            btnSave.Text = Resources.Common_Save;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 229);
            button1.Name = "button1";
            button1.Size = new Size(103, 23);
            button1.TabIndex = 13;
            button1.Text = Resources.Form_Connection_CreateDatabase;
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnCreateDatabase_Click;
            // 
            // FormConnectionStringBuilder
            // 
            ClientSize = new Size(284, 265);
            Controls.Add(button1);
            Controls.Add(btnSave);
            Controls.Add(lblConnectionTestResult);
            Controls.Add(btnTestConnection);
            Controls.Add(txtConnectionString);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUser);
            Controls.Add(lblUser);
            Controls.Add(txtDatabase);
            Controls.Add(lblDatabase);
            Controls.Add(txtServer);
            Controls.Add(lblServer);
            Name = "FormConnectionStringBuilder";
            Text = Resources.Form_Connection_Caption;
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Label lblConnectionTestResult;
        private System.Windows.Forms.Button btnSave;
        private Button button1;
    }
}
