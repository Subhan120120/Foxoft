
namespace Foxoft
{
    partial class FormReportGridOptions2
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
         this.checkEdit_GroupFooter = new DevExpress.XtraEditors.CheckEdit();
         this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
         this.checkEdit_CellReadOnly = new DevExpress.XtraEditors.CheckEdit();
         this.checkEdit_Editable = new DevExpress.XtraEditors.CheckEdit();
         this.AllowRowSizing = new DevExpress.XtraEditors.CheckEdit();
         ((System.ComponentModel.ISupportInitialize)(this.checkEdit_GroupFooter.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.checkEdit_CellReadOnly.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.checkEdit_Editable.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.AllowRowSizing.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // checkEdit_GroupFooter
         // 
         this.checkEdit_GroupFooter.Location = new System.Drawing.Point(51, 36);
         this.checkEdit_GroupFooter.Name = "checkEdit_GroupFooter";
         this.checkEdit_GroupFooter.Properties.AutoWidth = true;
         this.checkEdit_GroupFooter.Properties.Caption = "Group Footer";
         this.checkEdit_GroupFooter.Size = new System.Drawing.Size(87, 20);
         this.checkEdit_GroupFooter.TabIndex = 0;
         this.checkEdit_GroupFooter.CheckedChanged += new System.EventHandler(this.checkEdit_GroupFooter_CheckedChanged);
         // 
         // simpleButton1
         // 
         this.simpleButton1.Location = new System.Drawing.Point(368, 173);
         this.simpleButton1.Name = "simpleButton1";
         this.simpleButton1.Size = new System.Drawing.Size(75, 23);
         this.simpleButton1.TabIndex = 1;
         this.simpleButton1.Text = "Ok";
         this.simpleButton1.Click += new System.EventHandler(this.simpleButton_Ok_Click);
         // 
         // checkEdit_CellReadOnly
         // 
         this.checkEdit_CellReadOnly.Location = new System.Drawing.Point(51, 62);
         this.checkEdit_CellReadOnly.Name = "checkEdit_CellReadOnly";
         this.checkEdit_CellReadOnly.Properties.AutoWidth = true;
         this.checkEdit_CellReadOnly.Properties.Caption = "Cell ReadOnly ";
         this.checkEdit_CellReadOnly.Size = new System.Drawing.Size(93, 20);
         this.checkEdit_CellReadOnly.TabIndex = 0;
         this.checkEdit_CellReadOnly.CheckedChanged += new System.EventHandler(this.checkEdit_CellReadOnly_CheckedChanged);
         // 
         // checkEdit_Editable
         // 
         this.checkEdit_Editable.Location = new System.Drawing.Point(51, 88);
         this.checkEdit_Editable.Name = "checkEdit_Editable";
         this.checkEdit_Editable.Properties.AutoWidth = true;
         this.checkEdit_Editable.Properties.Caption = "Editable";
         this.checkEdit_Editable.Size = new System.Drawing.Size(61, 20);
         this.checkEdit_Editable.TabIndex = 0;
         this.checkEdit_Editable.CheckedChanged += new System.EventHandler(this.checkEdit_Editable_CheckedChanged);
         // 
         // AllowRowSizing
         // 
         this.AllowRowSizing.Location = new System.Drawing.Point(51, 114);
         this.AllowRowSizing.Name = "AllowRowSizing";
         this.AllowRowSizing.Properties.AutoWidth = true;
         this.AllowRowSizing.Properties.Caption = "AllowRowSizing";
         this.AllowRowSizing.Size = new System.Drawing.Size(96, 20);
         this.AllowRowSizing.TabIndex = 0;
         this.AllowRowSizing.CheckedChanged += new System.EventHandler(this.AllowRowSizing_CheckedChanged);
         // 
         // FormReportGridOptions
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(488, 223);
         this.Controls.Add(this.simpleButton1);
         this.Controls.Add(this.AllowRowSizing);
         this.Controls.Add(this.checkEdit_Editable);
         this.Controls.Add(this.checkEdit_CellReadOnly);
         this.Controls.Add(this.checkEdit_GroupFooter);
         this.Name = "FormReportGridOptions";
         this.Text = "FormReportGridConfig";
         this.Load += new System.EventHandler(this.FormReportGridOptions_Load);
         ((System.ComponentModel.ISupportInitialize)(this.checkEdit_GroupFooter.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.checkEdit_CellReadOnly.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.checkEdit_Editable.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.AllowRowSizing.Properties)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit checkEdit_GroupFooter;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.CheckEdit checkEdit_CellReadOnly;
        private DevExpress.XtraEditors.CheckEdit checkEdit_Editable;
      private DevExpress.XtraEditors.CheckEdit AllowRowSizing;
   }
}