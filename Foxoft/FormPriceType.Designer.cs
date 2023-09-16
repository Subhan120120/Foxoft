using Foxoft.Models;

namespace Foxoft
{
    partial class FormPriceType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPriceType));
            dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            btn_Ok = new DevExpress.XtraEditors.SimpleButton();
            PriceTypeCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            bindingSource_PriceType = new System.Windows.Forms.BindingSource(components);
            PriceTypeDescTextEdit = new DevExpress.XtraEditors.TextEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForPriceTypeCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForPriceTypeDesc = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).BeginInit();
            dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PriceTypeCodeTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource_PriceType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PriceTypeDescTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPriceTypeCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPriceTypeDesc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            dataLayoutControl1.Controls.Add(btn_Cancel);
            dataLayoutControl1.Controls.Add(btn_Ok);
            dataLayoutControl1.Controls.Add(PriceTypeCodeTextEdit);
            dataLayoutControl1.Controls.Add(PriceTypeDescTextEdit);
            dataLayoutControl1.DataSource = bindingSource_PriceType;
            dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            dataLayoutControl1.Name = "dataLayoutControl1";
            dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(760, 215, 650, 400);
            dataLayoutControl1.Root = Root;
            dataLayoutControl1.Size = new System.Drawing.Size(306, 132);
            dataLayoutControl1.TabIndex = 0;
            dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // btn_Cancel
            // 
            btn_Cancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_Cancel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_Cancel.ImageOptions.SvgImage");
            btn_Cancel.Location = new System.Drawing.Point(220, 60);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new System.Drawing.Size(74, 60);
            btn_Cancel.StyleController = dataLayoutControl1;
            btn_Cancel.TabIndex = 4;
            btn_Cancel.Text = "simpleButton2";
            // 
            // btn_Ok
            // 
            btn_Ok.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_Ok.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btn_Ok.ImageOptions.SvgImage");
            btn_Ok.Location = new System.Drawing.Point(142, 60);
            btn_Ok.Name = "btn_Ok";
            btn_Ok.Size = new System.Drawing.Size(74, 60);
            btn_Ok.StyleController = dataLayoutControl1;
            btn_Ok.TabIndex = 3;
            btn_Ok.Text = "simpleButton1";
            btn_Ok.Click += btn_Ok_Click;
            // 
            // PriceTypeCodeTextEdit
            // 
            PriceTypeCodeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", bindingSource_PriceType, "PriceTypeCode", true));
            PriceTypeCodeTextEdit.Location = new System.Drawing.Point(160, 12);
            PriceTypeCodeTextEdit.Name = "PriceTypeCodeTextEdit";
            PriceTypeCodeTextEdit.Size = new System.Drawing.Size(134, 20);
            PriceTypeCodeTextEdit.StyleController = dataLayoutControl1;
            PriceTypeCodeTextEdit.TabIndex = 0;
            // 
            // bindingSource_PriceType
            // 
            bindingSource_PriceType.DataSource = typeof(DcPriceType);
            // 
            // PriceTypeDescTextEdit
            // 
            PriceTypeDescTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", bindingSource_PriceType, "PriceTypeDesc", true));
            PriceTypeDescTextEdit.Location = new System.Drawing.Point(160, 36);
            PriceTypeDescTextEdit.Name = "PriceTypeDescTextEdit";
            PriceTypeDescTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            PriceTypeDescTextEdit.Size = new System.Drawing.Size(134, 20);
            PriceTypeDescTextEdit.StyleController = dataLayoutControl1;
            PriceTypeDescTextEdit.TabIndex = 2;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlGroup1 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(306, 132);
            Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.AllowDrawBackground = false;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForPriceTypeCode, ItemForPriceTypeDesc, layoutControlItem1, layoutControlItem2, emptySpaceItem1 });
            layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            layoutControlGroup1.Name = "autoGeneratedGroup0";
            layoutControlGroup1.Size = new System.Drawing.Size(286, 112);
            // 
            // ItemForPriceTypeCode
            // 
            ItemForPriceTypeCode.Control = PriceTypeCodeTextEdit;
            ItemForPriceTypeCode.Location = new System.Drawing.Point(0, 0);
            ItemForPriceTypeCode.Name = "ItemForPriceTypeCode";
            ItemForPriceTypeCode.Size = new System.Drawing.Size(286, 24);
            ItemForPriceTypeCode.TextSize = new System.Drawing.Size(136, 13);
            // 
            // ItemForPriceTypeDesc
            // 
            ItemForPriceTypeDesc.Control = PriceTypeDescTextEdit;
            ItemForPriceTypeDesc.Location = new System.Drawing.Point(0, 24);
            ItemForPriceTypeDesc.Name = "ItemForPriceTypeDesc";
            ItemForPriceTypeDesc.Size = new System.Drawing.Size(286, 24);
            ItemForPriceTypeDesc.TextSize = new System.Drawing.Size(136, 13);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = btn_Ok;
            layoutControlItem1.Location = new System.Drawing.Point(130, 48);
            layoutControlItem1.MinSize = new System.Drawing.Size(78, 26);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(78, 64);
            layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = btn_Cancel;
            layoutControlItem2.Location = new System.Drawing.Point(208, 48);
            layoutControlItem2.MinSize = new System.Drawing.Size(78, 26);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(78, 64);
            layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.AllowHotTrack = false;
            emptySpaceItem1.Location = new System.Drawing.Point(0, 48);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new System.Drawing.Size(130, 64);
            emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // FormPriceType
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(306, 132);
            Controls.Add(dataLayoutControl1);
            Name = "FormPriceType";
            Text = "FormPriceType";
            Load += FormPriceType_Load;
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).EndInit();
            dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PriceTypeCodeTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource_PriceType).EndInit();
            ((System.ComponentModel.ISupportInitialize)PriceTypeDescTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPriceTypeCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPriceTypeDesc).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private System.Windows.Forms.BindingSource bindingSource_PriceType;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit PriceTypeCodeTextEdit;
        private DevExpress.XtraEditors.TextEdit PriceTypeDescTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPriceTypeCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPriceTypeDesc;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraEditors.SimpleButton btn_Ok;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}