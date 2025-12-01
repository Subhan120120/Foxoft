using DevExpress.Utils;
using Foxoft.Properties;

namespace Foxoft
{
    partial class FormChange
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChange));
            this.lC_Root = new DevExpress.XtraLayout.LayoutControl();
            this.txtEdit_Cash = new DevExpress.XtraEditors.TextEdit();
            this.txtEdit_Change = new DevExpress.XtraEditors.TextEdit();
            this.btn_Ok = new DevExpress.XtraEditors.SimpleButton();
            this.lCG_Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lCI_Cash = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_Change = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_Ok = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lC_Root)).BeginInit();
            this.lC_Root.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_Cash.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_Change.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCG_Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Cash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Change)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Ok)).BeginInit();
            this.SuspendLayout();
            // 
            // lC_Root
            // 
            this.lC_Root.Controls.Add(this.txtEdit_Cash);
            this.lC_Root.Controls.Add(this.txtEdit_Change);
            this.lC_Root.Controls.Add(this.btn_Ok);
            this.lC_Root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lC_Root.Location = new System.Drawing.Point(0, 0);
            this.lC_Root.Name = "lC_Root";
            this.lC_Root.Root = this.lCG_Root;
            this.lC_Root.Size = new System.Drawing.Size(288, 214);
            this.lC_Root.TabIndex = 0;
            this.lC_Root.Text = "layoutControl1";
            // 
            // txtEdit_Cash
            // 
            this.txtEdit_Cash.Location = new System.Drawing.Point(93, 12);
            this.txtEdit_Cash.Name = "txtEdit_Cash";
            this.txtEdit_Cash.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtEdit_Cash.Properties.Appearance.Options.UseFont = true;
            this.txtEdit_Cash.Properties.Appearance.Options.UseTextOptions = true;
            this.txtEdit_Cash.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.txtEdit_Cash.Size = new System.Drawing.Size(183, 22);
            this.txtEdit_Cash.StyleController = this.lC_Root;
            this.txtEdit_Cash.TabIndex = 4;
            // 
            // txtEdit_Change
            // 
            this.txtEdit_Change.Location = new System.Drawing.Point(93, 38);
            this.txtEdit_Change.Name = "txtEdit_Change";
            this.txtEdit_Change.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 40F);
            this.txtEdit_Change.Properties.Appearance.Options.UseFont = true;
            this.txtEdit_Change.Properties.Appearance.Options.UseTextOptions = true;
            this.txtEdit_Change.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.txtEdit_Change.Properties.Mask.EditMask = "n2";
            this.txtEdit_Change.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtEdit_Change.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtEdit_Change.Size = new System.Drawing.Size(183, 70);
            this.txtEdit_Change.StyleController = this.lC_Root;
            this.txtEdit_Change.TabIndex = 5;
            // 
            // btn_Ok
            // 
            this.btn_Ok.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_Ok.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Ok.ImageOptions.SvgImage")));
            this.btn_Ok.Location = new System.Drawing.Point(12, 112);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(264, 90);
            this.btn_Ok.StyleController = this.lC_Root;
            this.btn_Ok.TabIndex = 6;
            this.btn_Ok.Text = Resources.Common_Ok;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // lCG_Root
            // 
            this.lCG_Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lCG_Root.GroupBordersVisible = false;
            this.lCG_Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lCI_Cash,
            this.lCI_Change,
            this.lCI_Ok});
            this.lCG_Root.Name = "lCG_Root";
            this.lCG_Root.Size = new System.Drawing.Size(288, 214);
            this.lCG_Root.TextVisible = false;
            // 
            // lCI_Cash
            // 
            this.lCI_Cash.Control = this.txtEdit_Cash;
            this.lCI_Cash.Location = new System.Drawing.Point(0, 0);
            this.lCI_Cash.Name = "lCI_Cash";
            this.lCI_Cash.Size = new System.Drawing.Size(268, 26);
            this.lCI_Cash.Text = Resources.Form_Change_Label_Cash;
            this.lCI_Cash.TextSize = new System.Drawing.Size(78, 13);
            // 
            // lCI_Change
            // 
            this.lCI_Change.Control = this.txtEdit_Change;
            this.lCI_Change.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("lCI_Change.ImageOptions.SvgImage")));
            this.lCI_Change.Location = new System.Drawing.Point(0, 26);
            this.lCI_Change.Name = "lCI_Change";
            this.lCI_Change.Size = new System.Drawing.Size(268, 74);
            this.lCI_Change.Text = Resources.Form_Change_Label_Change;
            this.lCI_Change.TextSize = new System.Drawing.Size(78, 32);
            // 
            // lCI_Ok
            // 
            this.lCI_Ok.Control = this.btn_Ok;
            this.lCI_Ok.Location = new System.Drawing.Point(0, 100);
            this.lCI_Ok.MinSize = new System.Drawing.Size(78, 26);
            this.lCI_Ok.Name = "lCI_Ok";
            this.lCI_Ok.Size = new System.Drawing.Size(268, 94);
            this.lCI_Ok.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_Ok.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_Ok.TextVisible = false;
            // 
            // FormChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 214);
            this.Controls.Add(this.lC_Root);
            this.Name = "FormChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = Resources.Form_Change_Caption;
            this.Load += new System.EventHandler(this.FormChange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lC_Root)).EndInit();
            this.lC_Root.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_Cash.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_Change.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCG_Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Cash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Change)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Ok)).EndInit();
            this.ResumeLayout(false);
        }

        private DevExpress.XtraLayout.LayoutControl lC_Root;
        private DevExpress.XtraLayout.LayoutControlGroup lCG_Root;
        private DevExpress.XtraEditors.TextEdit txtEdit_Cash;
        private DevExpress.XtraEditors.TextEdit txtEdit_Change;
        private DevExpress.XtraLayout.LayoutControlItem lCI_Cash;
        private DevExpress.XtraLayout.LayoutControlItem lCI_Change;
        private DevExpress.XtraEditors.SimpleButton btn_Ok;
        private DevExpress.XtraLayout.LayoutControlItem lCI_Ok;
    }
}
