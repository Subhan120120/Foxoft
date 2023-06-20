using Foxoft.Models;

namespace Foxoft
{
    partial class FormFeature
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFeature));
            dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            textEdit1 = new DevExpress.XtraEditors.TextEdit();
            bindingSource_feature = new System.Windows.Forms.BindingSource(components);
            btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            btn_Ok = new DevExpress.XtraEditors.SimpleButton();
            textEdit2 = new DevExpress.XtraEditors.TextEdit();
            textEdit3 = new DevExpress.XtraEditors.TextEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            FeatureCode = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            FeatureDesc = new DevExpress.XtraLayout.LayoutControlItem();
            FeatureTypeId = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).BeginInit();
            dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource_feature).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEdit2.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEdit3.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FeatureCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FeatureDesc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FeatureTypeId).BeginInit();
            SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            dataLayoutControl1.Controls.Add(textEdit1);
            dataLayoutControl1.Controls.Add(btn_Cancel);
            dataLayoutControl1.Controls.Add(btn_Ok);
            dataLayoutControl1.Controls.Add(textEdit2);
            dataLayoutControl1.Controls.Add(textEdit3);
            dataLayoutControl1.DataMember = "DcFeature";
            dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataLayoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { FeatureTypeId });
            dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            dataLayoutControl1.Name = "dataLayoutControl1";
            dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(406, 189, 650, 400);
            dataLayoutControl1.Root = Root;
            dataLayoutControl1.Size = new System.Drawing.Size(358, 150);
            dataLayoutControl1.TabIndex = 0;
            dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // textEdit1
            // 
            textEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", bindingSource_feature, "FeatureCode", true));
            textEdit1.Location = new System.Drawing.Point(87, 12);
            textEdit1.Name = "textEdit1";
            textEdit1.Size = new System.Drawing.Size(259, 20);
            textEdit1.StyleController = dataLayoutControl1;
            textEdit1.TabIndex = 0;
            // 
            // bindingSource_feature
            // 
            bindingSource_feature.DataSource = typeof(DcFeature);
            // 
            // btn_Cancel
            // 
            btn_Cancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_Cancel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_Cancel.ImageOptions.SvgImage");
            btn_Cancel.Location = new System.Drawing.Point(262, 60);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new System.Drawing.Size(84, 78);
            btn_Cancel.StyleController = dataLayoutControl1;
            btn_Cancel.TabIndex = 5;
            btn_Cancel.Text = "simpleButton1";
            // 
            // btn_Ok
            // 
            btn_Ok.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_Ok.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_Ok.ImageOptions.SvgImage");
            btn_Ok.Location = new System.Drawing.Point(184, 60);
            btn_Ok.Name = "btn_Ok";
            btn_Ok.Size = new System.Drawing.Size(74, 78);
            btn_Ok.StyleController = dataLayoutControl1;
            btn_Ok.TabIndex = 4;
            btn_Ok.Text = "simpleButton2";
            btn_Ok.Click += btn_Ok_Click;
            // 
            // textEdit2
            // 
            textEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", bindingSource_feature, "FeatureDesc", true));
            textEdit2.Location = new System.Drawing.Point(87, 36);
            textEdit2.Name = "textEdit2";
            textEdit2.Size = new System.Drawing.Size(259, 20);
            textEdit2.StyleController = dataLayoutControl1;
            textEdit2.TabIndex = 2;
            // 
            // textEdit3
            // 
            textEdit3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", bindingSource_feature, "FeatureTypeId", true));
            textEdit3.Location = new System.Drawing.Point(96, 60);
            textEdit3.Name = "textEdit3";
            textEdit3.Size = new System.Drawing.Size(250, 20);
            textEdit3.StyleController = dataLayoutControl1;
            textEdit3.TabIndex = 3;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { FeatureCode, layoutControlItem1, emptySpaceItem1, layoutControlItem2, FeatureDesc });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(358, 150);
            Root.TextVisible = false;
            // 
            // FeatureCode
            // 
            FeatureCode.Control = textEdit1;
            FeatureCode.Location = new System.Drawing.Point(0, 0);
            FeatureCode.Name = "FeatureCode";
            FeatureCode.Size = new System.Drawing.Size(338, 24);
            FeatureCode.TextSize = new System.Drawing.Size(63, 13);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = btn_Cancel;
            layoutControlItem1.Location = new System.Drawing.Point(250, 48);
            layoutControlItem1.MinSize = new System.Drawing.Size(78, 26);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(88, 82);
            layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.AllowHotTrack = false;
            emptySpaceItem1.Location = new System.Drawing.Point(0, 48);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new System.Drawing.Size(172, 82);
            emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = btn_Ok;
            layoutControlItem2.Location = new System.Drawing.Point(172, 48);
            layoutControlItem2.MinSize = new System.Drawing.Size(78, 26);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(78, 82);
            layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem2.TextVisible = false;
            // 
            // FeatureDesc
            // 
            FeatureDesc.Control = textEdit2;
            FeatureDesc.Location = new System.Drawing.Point(0, 24);
            FeatureDesc.Name = "FeatureDesc";
            FeatureDesc.Size = new System.Drawing.Size(338, 24);
            FeatureDesc.TextSize = new System.Drawing.Size(63, 13);
            // 
            // FeatureTypeId
            // 
            FeatureTypeId.Control = textEdit3;
            FeatureTypeId.Location = new System.Drawing.Point(0, 48);
            FeatureTypeId.Name = "FeatureTypeId";
            FeatureTypeId.Size = new System.Drawing.Size(338, 24);
            FeatureTypeId.TextSize = new System.Drawing.Size(72, 13);
            // 
            // FormFeature
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(358, 150);
            Controls.Add(dataLayoutControl1);
            Name = "FormFeature";
            Text = "Form1";
            Load += FormFeature_Load;
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).EndInit();
            dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource_feature).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEdit2.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEdit3.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)FeatureCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)FeatureDesc).EndInit();
            ((System.ComponentModel.ISupportInitialize)FeatureTypeId).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private System.Windows.Forms.BindingSource bindingSource_feature;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlItem FeatureCode;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btn_Ok;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem FeatureDesc;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraLayout.LayoutControlItem FeatureTypeId;
    }
}