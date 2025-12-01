using Foxoft.Properties;

namespace Foxoft
{
    partial class FormReportGridOptions
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.CheckBox chkReadOnly;
        private System.Windows.Forms.CheckBox chkAllowRowSizing;
        private System.Windows.Forms.ComboBox cmbGroupFooterShowMode;
        private System.Windows.Forms.Label lblGroupFooterShowMode;
        private System.Windows.Forms.CheckBox chkEditable;
        private System.Windows.Forms.CheckBox chkShowFooter;
        private System.Windows.Forms.Button btnClose;

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
            this.chkReadOnly = new System.Windows.Forms.CheckBox();
            this.chkAllowRowSizing = new System.Windows.Forms.CheckBox();
            this.cmbGroupFooterShowMode = new System.Windows.Forms.ComboBox();
            this.lblGroupFooterShowMode = new System.Windows.Forms.Label();
            this.chkEditable = new System.Windows.Forms.CheckBox();
            this.chkShowFooter = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkReadOnly
            // 
            this.chkReadOnly.AutoSize = true;
            this.chkReadOnly.Location = new System.Drawing.Point(12, 12);
            this.chkReadOnly.Name = "chkReadOnly";
            this.chkReadOnly.Size = new System.Drawing.Size(75, 17);
            this.chkReadOnly.TabIndex = 0;
            this.chkReadOnly.Text = Resources.Form_ReportGridOptions_ReadOnly;
            this.chkReadOnly.UseVisualStyleBackColor = true;
            // 
            // chkAllowRowSizing
            // 
            this.chkAllowRowSizing.AutoSize = true;
            this.chkAllowRowSizing.Location = new System.Drawing.Point(12, 35);
            this.chkAllowRowSizing.Name = "chkAllowRowSizing";
            this.chkAllowRowSizing.Size = new System.Drawing.Size(108, 17);
            this.chkAllowRowSizing.TabIndex = 1;
            this.chkAllowRowSizing.Text = Resources.Form_ReportGridOptions_AllowRowSizing;
            this.chkAllowRowSizing.UseVisualStyleBackColor = true;
            // 
            // cmbGroupFooterShowMode
            // 
            this.cmbGroupFooterShowMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupFooterShowMode.FormattingEnabled = true;
            this.cmbGroupFooterShowMode.Items.AddRange(new object[] {
            Resources.Form_ReportGridOptions_GroupFooter_Hidden,
            Resources.Form_ReportGridOptions_GroupFooter_VisibleAlways,
            Resources.Form_ReportGridOptions_GroupFooter_VisibleIfExpanded});
            this.cmbGroupFooterShowMode.Location = new System.Drawing.Point(12, 81);
            this.cmbGroupFooterShowMode.Name = "cmbGroupFooterShowMode";
            this.cmbGroupFooterShowMode.Size = new System.Drawing.Size(200, 21);
            this.cmbGroupFooterShowMode.TabIndex = 2;
            // 
            // lblGroupFooterShowMode
            // 
            this.lblGroupFooterShowMode.AutoSize = true;
            this.lblGroupFooterShowMode.Location = new System.Drawing.Point(12, 65);
            this.lblGroupFooterShowMode.Name = "lblGroupFooterShowMode";
            this.lblGroupFooterShowMode.Size = new System.Drawing.Size(128, 13);
            this.lblGroupFooterShowMode.TabIndex = 3;
            this.lblGroupFooterShowMode.Text = Resources.Form_ReportGridOptions_GroupFooterShowMode;
            // 
            // chkEditable
            // 
            this.chkEditable.AutoSize = true;
            this.chkEditable.Location = new System.Drawing.Point(12, 108);
            this.chkEditable.Name = "chkEditable";
            this.chkEditable.Size = new System.Drawing.Size(64, 17);
            this.chkEditable.TabIndex = 4;
            this.chkEditable.Text = Resources.Form_ReportGridOptions_Editable;
            this.chkEditable.UseVisualStyleBackColor = true;
            // 
            // chkShowFooter
            // 
            this.chkShowFooter.AutoSize = true;
            this.chkShowFooter.Location = new System.Drawing.Point(12, 131);
            this.chkShowFooter.Name = "chkShowFooter";
            this.chkShowFooter.Size = new System.Drawing.Size(86, 17);
            this.chkShowFooter.TabIndex = 5;
            this.chkShowFooter.Text = Resources.Form_ReportGridOptions_ShowFooter;
            this.chkShowFooter.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(137, 154);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = Resources.Common_Close;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // GridSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 189);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.chkShowFooter);
            this.Controls.Add(this.chkEditable);
            this.Controls.Add(this.lblGroupFooterShowMode);
            this.Controls.Add(this.cmbGroupFooterShowMode);
            this.Controls.Add(this.chkAllowRowSizing);
            this.Controls.Add(this.chkReadOnly);
            this.Name = "GridSetting";
            this.Text = Resources.Form_ReportGridOptions_Caption;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
