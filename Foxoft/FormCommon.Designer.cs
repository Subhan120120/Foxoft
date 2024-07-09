using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System.Windows.Forms;

namespace Foxoft
{
    partial class FormCommon<T>
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
            this.components = new System.ComponentModel.Container();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(this.components);
            this.btn_Ok = new DevExpress.XtraEditors.SimpleButton();
            this.LCI_Ok = new DevExpress.XtraLayout.LayoutControlItem();
            this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.LCI_Cancel = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LCI_Ok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LCI_Cancel)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.AutoSize = true;
            this.dataLayoutControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.dataLayoutControl1.DataSource = this.bindingSource1;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(848, 189, 650, 400);
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(452, 78);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            this.dataLayoutControl1.FieldRetrieved += new System.EventHandler<DevExpress.XtraDataLayout.FieldRetrievedEventArgs>(this.dataLayoutControl1_FieldRetrieved);
            this.dataLayoutControl1.FieldRetrieving += new System.EventHandler<DevExpress.XtraDataLayout.FieldRetrievingEventArgs>(this.dataLayoutControl1_FieldRetrieving);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(452, 78);
            this.Root.TextVisible = false;
            // 
            // svgImageCollection1
            // 
            this.svgImageCollection1.Add("ok", "image://svgimages/icon builder/actions_check.svg");
            this.svgImageCollection1.Add("cancel", "image://svgimages/icon builder/actions_delete.svg");
            // 
            // btn_Ok
            // 
            this.btn_Ok.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_Ok.Location = new System.Drawing.Point(12, 12);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(428, 22);
            this.btn_Ok.StyleController = this.dataLayoutControl1;
            this.btn_Ok.TabIndex = 4;
            this.btn_Ok.Text = "Yadda Saxla";
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // LCI_Ok
            // 
            this.LCI_Ok.Control = this.btn_Ok;
            this.LCI_Ok.Location = new System.Drawing.Point(0, 0);
            this.LCI_Ok.Name = "layoutControlItem1";
            this.LCI_Ok.Size = new System.Drawing.Size(432, 26);
            this.LCI_Ok.TextSize = new System.Drawing.Size(0, 0);
            this.LCI_Ok.TextVisible = false;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_Cancel.Location = new System.Drawing.Point(12, 38);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(428, 22);
            this.btn_Cancel.StyleController = this.dataLayoutControl1;
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "Ləğv Et";
            // 
            // LCI_Cancel
            // 
            this.LCI_Cancel.Control = this.btn_Cancel;
            this.LCI_Cancel.Location = new System.Drawing.Point(0, 26);
            this.LCI_Cancel.Name = "layoutControlItem2";
            this.LCI_Cancel.Size = new System.Drawing.Size(432, 186);
            this.LCI_Cancel.TextSize = new System.Drawing.Size(0, 0);
            this.LCI_Cancel.TextVisible = false;
            this.LCI_Cancel.Click += new System.EventHandler(this.LCI_Cancel_Click);
            // 
            // FormCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(452, 78);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "FormCommon";
            this.Text = "FormCommon";
            this.Load += new System.EventHandler(this.FormCommon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LCI_Ok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LCI_Cancel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraEditors.SimpleButton btn_Ok;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private LayoutControlItem LCI_Ok;
        private LayoutControlItem LCI_Cancel;
    }
}