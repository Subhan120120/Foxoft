﻿namespace Foxoft
{
    partial class FormDocumentViewer
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
            documentViewer1 = new DevExpress.XtraPrinting.Preview.DocumentViewer();
            SuspendLayout();
            // 
            // documentViewer1
            // 
            documentViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            documentViewer1.IsMetric = true;
            documentViewer1.Location = new System.Drawing.Point(0, 0);
            documentViewer1.Name = "documentViewer1";
            documentViewer1.Size = new System.Drawing.Size(800, 450);
            documentViewer1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(documentViewer1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraPrinting.Preview.DocumentViewer documentViewer1;
    }
}