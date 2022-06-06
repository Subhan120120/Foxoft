
namespace Foxoft
{
    partial class FormReportEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportEditor));
            this.dcReportsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.IdTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ReportNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForReportName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForReportQuery = new DevExpress.XtraLayout.LayoutControlItem();
            this.ReportQueryMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.btn_Ok = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dcReportsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IdTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForReportName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForReportQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportQueryMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // dcReportsBindingSource
            // 
            this.dcReportsBindingSource.DataSource = typeof(Foxoft.Models.DcReport);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.btn_Cancel);
            this.dataLayoutControl1.Controls.Add(this.btn_Ok);
            this.dataLayoutControl1.Controls.Add(this.IdTextEdit);
            this.dataLayoutControl1.Controls.Add(this.ReportNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.ReportQueryMemoEdit);
            this.dataLayoutControl1.DataSource = this.dcReportsBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(567, 287);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(567, 287);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForId,
            this.ItemForReportName,
            this.ItemForReportQuery,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(547, 267);
            // 
            // IdTextEdit
            // 
            this.IdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dcReportsBindingSource, "Id", true));
            this.IdTextEdit.Location = new System.Drawing.Point(106, 12);
            this.IdTextEdit.Name = "IdTextEdit";
            this.IdTextEdit.Size = new System.Drawing.Size(449, 20);
            this.IdTextEdit.StyleController = this.dataLayoutControl1;
            this.IdTextEdit.TabIndex = 4;
            // 
            // ItemForId
            // 
            this.ItemForId.Control = this.IdTextEdit;
            this.ItemForId.Location = new System.Drawing.Point(0, 0);
            this.ItemForId.Name = "ItemForId";
            this.ItemForId.Size = new System.Drawing.Size(547, 24);
            this.ItemForId.Text = "Report ID";
            this.ItemForId.TextSize = new System.Drawing.Size(82, 13);
            // 
            // ReportNameTextEdit
            // 
            this.ReportNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dcReportsBindingSource, "ReportName", true));
            this.ReportNameTextEdit.Location = new System.Drawing.Point(106, 36);
            this.ReportNameTextEdit.Name = "ReportNameTextEdit";
            this.ReportNameTextEdit.Size = new System.Drawing.Size(449, 20);
            this.ReportNameTextEdit.StyleController = this.dataLayoutControl1;
            this.ReportNameTextEdit.TabIndex = 5;
            // 
            // ItemForReportName
            // 
            this.ItemForReportName.Control = this.ReportNameTextEdit;
            this.ItemForReportName.Location = new System.Drawing.Point(0, 24);
            this.ItemForReportName.Name = "ItemForReportName";
            this.ItemForReportName.Size = new System.Drawing.Size(547, 24);
            this.ItemForReportName.Text = "Hesabat Adı";
            this.ItemForReportName.TextSize = new System.Drawing.Size(82, 13);
            // 
            // ItemForReportQuery
            // 
            this.ItemForReportQuery.Control = this.ReportQueryMemoEdit;
            this.ItemForReportQuery.Location = new System.Drawing.Point(0, 48);
            this.ItemForReportQuery.Name = "ItemForReportQuery";
            this.ItemForReportQuery.Size = new System.Drawing.Size(547, 166);
            this.ItemForReportQuery.Text = "Hesabat Sorğusu";
            this.ItemForReportQuery.TextSize = new System.Drawing.Size(82, 13);
            // 
            // ReportQueryMemoEdit
            // 
            this.ReportQueryMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dcReportsBindingSource, "ReportQuery", true));
            this.ReportQueryMemoEdit.Location = new System.Drawing.Point(106, 60);
            this.ReportQueryMemoEdit.Name = "ReportQueryMemoEdit";
            this.ReportQueryMemoEdit.Size = new System.Drawing.Size(449, 162);
            this.ReportQueryMemoEdit.StyleController = this.dataLayoutControl1;
            this.ReportQueryMemoEdit.TabIndex = 7;
            // 
            // btn_Ok
            // 
            this.btn_Ok.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btn_Ok.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_Ok.Location = new System.Drawing.Point(285, 226);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(270, 49);
            this.btn_Ok.StyleController = this.dataLayoutControl1;
            this.btn_Ok.TabIndex = 8;
            this.btn_Ok.Text = "btn_Ok";
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btn_Ok;
            this.layoutControlItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("layoutControlItem1.ImageOptions.Image")));
            this.layoutControlItem1.Location = new System.Drawing.Point(273, 214);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(78, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(274, 53);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.btn_Cancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_Cancel.Location = new System.Drawing.Point(12, 226);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(269, 49);
            this.btn_Cancel.StyleController = this.dataLayoutControl1;
            this.btn_Cancel.TabIndex = 9;
            this.btn_Cancel.Text = "btn_Cancel";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btn_Cancel;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 214);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(78, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(273, 53);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // FormReportEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 287);
            this.Controls.Add(this.dataLayoutControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormReportEditor";
            this.Text = "FormQueryEditor";
            this.Load += new System.EventHandler(this.FormQueryEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dcReportsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IdTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForReportName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForReportQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportQueryMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource dcReportsBindingSource;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraEditors.SimpleButton btn_Ok;
        private DevExpress.XtraEditors.TextEdit IdTextEdit;
        private DevExpress.XtraEditors.TextEdit ReportNameTextEdit;
        private DevExpress.XtraEditors.MemoEdit ReportQueryMemoEdit;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForReportName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForReportQuery;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}