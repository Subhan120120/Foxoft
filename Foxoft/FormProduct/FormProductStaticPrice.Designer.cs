using Foxoft.Properties;   // <-- added

namespace Foxoft
{
    partial class FormProductStaticPrice
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProductStaticPrice));
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            simpleButtonOk = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.AutoSize = true;
            layoutControl1.AutoSizeMode = AutoSizeMode.GrowOnly;
            layoutControl1.Controls.Add(simpleButtonOk);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(450, 54, 399, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(62, 81);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // simpleButtonOk
            // 
            simpleButtonOk.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            simpleButtonOk.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("simpleButtonOk.ImageOptions.SvgImage");
            simpleButtonOk.Location = new Point(12, 33);
            simpleButtonOk.Name = "simpleButtonOk";
            simpleButtonOk.Size = new Size(38, 36);
            simpleButtonOk.StyleController = layoutControl1;
            simpleButtonOk.TabIndex = 4;
            simpleButtonOk.Click += simpleButtonOk_Click;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1 });
            Root.Name = "Root";
            Root.Size = new Size(62, 81);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = simpleButtonOk;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(42, 40);
            layoutControlItem1.TextSize = new Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // FormProductStaticPrice
            // 
            AcceptButton = simpleButtonOk;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(298, 136);
            Controls.Add(layoutControl1);
            KeyPreview = true;
            Name = "FormProductStaticPrice";
            Text = Resources.Form_ProductStaticPrice_Caption;
            Load += FormProductStaticPrice_Load;
            KeyDown += FormProductStaticPrice_KeyDown;
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOk;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}
