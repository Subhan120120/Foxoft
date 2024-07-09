// Developer Express Code Central Example:
// How to dynamically change a Wait Form's labels
// 
// A Wait Form is displayed by a Splash Screen Manager in a separate thread. To
// dynamically change labels within the Wait Form, while it is being displayed, use
// the SplashScreenManager.SetWaitFormCaption and SetWaitFormDescription methods.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E3575

namespace WaitForm_SetDescription
{
    partial class WaitForm
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
            progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)progressBarControl1.Properties).BeginInit();
            SuspendLayout();
            // 
            // progressPanel1
            // 
            progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            progressPanel1.Appearance.Options.UseBackColor = true;
            progressPanel1.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            progressPanel1.AppearanceCaption.Options.UseFont = true;
            progressPanel1.AppearanceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            progressPanel1.AppearanceDescription.Options.UseFont = true;
            progressPanel1.Caption = "Gözləyin";
            progressPanel1.Description = "Yüklənir...";
            progressPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            progressPanel1.ImageHorzOffset = 10;
            progressPanel1.Location = new System.Drawing.Point(0, 17);
            progressPanel1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            progressPanel1.Name = "progressPanel1";
            progressPanel1.Size = new System.Drawing.Size(290, 55);
            progressPanel1.TabIndex = 0;
            progressPanel1.Text = "progressPanel1";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            tableLayoutPanel1.Controls.Add(progressPanel1, 0, 0);
            tableLayoutPanel1.Controls.Add(progressBarControl1, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 14, 0, 14);
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            tableLayoutPanel1.Size = new System.Drawing.Size(290, 143);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // progressBarControl1
            // 
            progressBarControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            progressBarControl1.Location = new System.Drawing.Point(3, 78);
            progressBarControl1.Name = "progressBarControl1";
            progressBarControl1.Size = new System.Drawing.Size(284, 48);
            progressBarControl1.TabIndex = 1;
            // 
            // WaitForm1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ClientSize = new System.Drawing.Size(290, 143);
            Controls.Add(tableLayoutPanel1);
            DoubleBuffered = true;
            MinimumSize = new System.Drawing.Size(246, 0);
            Name = "WaitForm1";
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)progressBarControl1.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
    }
}
