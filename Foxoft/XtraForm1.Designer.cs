
using DevExpress.XtraEditors;

namespace Foxoft
{
    partial class XtraForm1
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
            filterControl1 = new FilterControl();
            SuspendLayout();
            // 
            // filterControl1
            // 
            filterControl1.Location = new System.Drawing.Point(199, 137);
            filterControl1.Name = "filterControl1";
            filterControl1.NodeSeparatorHeight = 2;
            filterControl1.ShowActionButtonMode = DevExpress.XtraEditors.ShowActionButtonMode.Default;
            filterControl1.Size = new System.Drawing.Size(515, 210);
            filterControl1.TabIndex = 0;
            filterControl1.Text = "filterControl1";
            // 
            // XtraForm1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(946, 491);
            Controls.Add(filterControl1);
            Name = "XtraForm1";
            Text = "XtraForm1";
            Load += XtraForm1_Load;
            ResumeLayout(false);
        }

        #endregion

        private FilterControl filterControl1;
    }
}