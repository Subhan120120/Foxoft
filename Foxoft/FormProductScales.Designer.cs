namespace Foxoft
{
    partial class FormProductScales
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
            dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            dcProductScaleBindingSource = new BindingSource(components);
            btn_Save = new DevExpress.XtraEditors.SimpleButton();
            txtEdit_ScaleProductNumber = new DevExpress.XtraEditors.TextEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(components);
            chckEdit_UseInScale = new DevExpress.XtraEditors.CheckEdit();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).BeginInit();
            dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dcProductScaleBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_ScaleProductNumber.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dxErrorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chckEdit_UseInScale.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            dataLayoutControl1.Controls.Add(chckEdit_UseInScale);
            dataLayoutControl1.Controls.Add(btn_Save);
            dataLayoutControl1.Controls.Add(txtEdit_ScaleProductNumber);
            dataLayoutControl1.DataSource = dcProductScaleBindingSource;
            dataLayoutControl1.Dock = DockStyle.Fill;
            dataLayoutControl1.Location = new Point(0, 0);
            dataLayoutControl1.Name = "dataLayoutControl1";
            dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(386, 0, 650, 400);
            dataLayoutControl1.Root = Root;
            dataLayoutControl1.Size = new Size(338, 197);
            dataLayoutControl1.TabIndex = 0;
            dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // dcProductScaleBindingSource
            // 
            dcProductScaleBindingSource.DataSource = typeof(Models.DcProductScale);
            // 
            // btn_Save
            // 
            btn_Save.Location = new Point(12, 60);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(314, 22);
            btn_Save.StyleController = dataLayoutControl1;
            btn_Save.TabIndex = 1;
            btn_Save.Text = "Yadda Saxla";
            btn_Save.Click += btn_Save_Click;
            // 
            // txtEdit_ScaleProductNumber
            // 
            txtEdit_ScaleProductNumber.DataBindings.Add(new Binding("EditValue", dcProductScaleBindingSource, "ScaleProductNumber", true));
            txtEdit_ScaleProductNumber.Location = new Point(116, 36);
            txtEdit_ScaleProductNumber.Name = "txtEdit_ScaleProductNumber";
            txtEdit_ScaleProductNumber.Size = new Size(210, 20);
            txtEdit_ScaleProductNumber.StyleController = dataLayoutControl1;
            txtEdit_ScaleProductNumber.TabIndex = 4;
            txtEdit_ScaleProductNumber.Validating += TextEdit_ScaleProductNumber_Validating;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem4 });
            Root.Name = "Root";
            Root.Size = new Size(338, 197);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = txtEdit_ScaleProductNumber;
            layoutControlItem1.Location = new Point(0, 24);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(318, 24);
            layoutControlItem1.TextSize = new Size(92, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = btn_Save;
            layoutControlItem2.Location = new Point(0, 48);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(318, 129);
            layoutControlItem2.TextSize = new Size(0, 0);
            layoutControlItem2.TextVisible = false;
            // 
            // dxErrorProvider1
            // 
            dxErrorProvider1.ContainerControl = this;
            // 
            // checkEdit1
            // 
            chckEdit_UseInScale.DataBindings.Add(new Binding("EditValue", dcProductScaleBindingSource, "UseInScale", true));
            chckEdit_UseInScale.Location = new Point(12, 12);
            chckEdit_UseInScale.Name = "checkEdit1";
            chckEdit_UseInScale.Properties.Caption = "Tərəzidə İstifadə Et";
            chckEdit_UseInScale.Size = new Size(314, 20);
            chckEdit_UseInScale.StyleController = dataLayoutControl1;
            chckEdit_UseInScale.TabIndex = 1;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = chckEdit_UseInScale;
            layoutControlItem4.Location = new Point(0, 0);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(318, 24);
            layoutControlItem4.TextSize = new Size(0, 0);
            layoutControlItem4.TextVisible = false;
            // 
            // FormProductScales
            // 
            AcceptButton = btn_Save;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 197);
            Controls.Add(dataLayoutControl1);
            Name = "FormProductScales";
            Text = "FormProductScales";
            Load += FormProductScales_Load;
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).EndInit();
            dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dcProductScaleBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEdit_ScaleProductNumber.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dxErrorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chckEdit_UseInScale.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private BindingSource dcProductScaleBindingSource;
        private DevExpress.XtraEditors.TextEdit txtEdit_ScaleProductNumber;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.CheckEdit chckEdit_UseInScale;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}