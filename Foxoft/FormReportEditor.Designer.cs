
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
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Ok = new DevExpress.XtraEditors.SimpleButton();
            this.ReportIdTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.dcReportsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReportNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForReportId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForReportName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ReportQueryMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.colFieldName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefaultValue = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReportIdTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dcReportsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForReportId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForReportName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportQueryMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.gridControl1);
            this.dataLayoutControl1.Controls.Add(this.ReportQueryMemoEdit);
            this.dataLayoutControl1.Controls.Add(this.btn_Cancel);
            this.dataLayoutControl1.Controls.Add(this.btn_Ok);
            this.dataLayoutControl1.Controls.Add(this.ReportIdTextEdit);
            this.dataLayoutControl1.Controls.Add(this.ReportNameTextEdit);
            this.dataLayoutControl1.DataSource = this.dcReportsBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(710, 0, 650, 400);
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(870, 557);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.ImageOptions.Image")));
            this.btn_Cancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_Cancel.Location = new System.Drawing.Point(12, 461);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(382, 84);
            this.btn_Cancel.StyleController = this.dataLayoutControl1;
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "btn_Cancel";
            // 
            // btn_Ok
            // 
            this.btn_Ok.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Ok.ImageOptions.Image")));
            this.btn_Ok.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_Ok.Location = new System.Drawing.Point(398, 461);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(67, 84);
            this.btn_Ok.StyleController = this.dataLayoutControl1;
            this.btn_Ok.TabIndex = 4;
            this.btn_Ok.Text = "btn_Ok";
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // ReportIdTextEdit
            // 
            this.ReportIdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dcReportsBindingSource, "ReportId", true));
            this.ReportIdTextEdit.Location = new System.Drawing.Point(82, 12);
            this.ReportIdTextEdit.Name = "ReportIdTextEdit";
            this.ReportIdTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.ReportIdTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ReportIdTextEdit.Properties.Mask.EditMask = "N0";
            this.ReportIdTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ReportIdTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.ReportIdTextEdit.Size = new System.Drawing.Size(93, 20);
            this.ReportIdTextEdit.StyleController = this.dataLayoutControl1;
            this.ReportIdTextEdit.TabIndex = 0;
            // 
            // dcReportsBindingSource
            // 
            this.dcReportsBindingSource.DataSource = typeof(Foxoft.Models.DcReport);
            // 
            // ReportNameTextEdit
            // 
            this.ReportNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dcReportsBindingSource, "ReportName", true));
            this.ReportNameTextEdit.Location = new System.Drawing.Point(249, 12);
            this.ReportNameTextEdit.Name = "ReportNameTextEdit";
            this.ReportNameTextEdit.Size = new System.Drawing.Size(216, 20);
            this.ReportNameTextEdit.StyleController = this.dataLayoutControl1;
            this.ReportNameTextEdit.TabIndex = 2;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(870, 557);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.ItemForReportName,
            this.ItemForReportId,
            this.layoutControlItem4,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(850, 537);
            // 
            // ItemForReportId
            // 
            this.ItemForReportId.Control = this.ReportIdTextEdit;
            this.ItemForReportId.Location = new System.Drawing.Point(0, 0);
            this.ItemForReportId.Name = "ItemForReportId";
            this.ItemForReportId.Size = new System.Drawing.Size(167, 24);
            this.ItemForReportId.Text = "Report ID";
            this.ItemForReportId.TextSize = new System.Drawing.Size(58, 13);
            // 
            // ItemForReportName
            // 
            this.ItemForReportName.Control = this.ReportNameTextEdit;
            this.ItemForReportName.Location = new System.Drawing.Point(167, 0);
            this.ItemForReportName.Name = "ItemForReportName";
            this.ItemForReportName.Size = new System.Drawing.Size(290, 24);
            this.ItemForReportName.Text = "Hesabat Adı";
            this.ItemForReportName.TextSize = new System.Drawing.Size(58, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btn_Ok;
            this.layoutControlItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("layoutControlItem1.ImageOptions.Image")));
            this.layoutControlItem1.Location = new System.Drawing.Point(386, 449);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(67, 23);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(71, 88);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btn_Cancel;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 449);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(67, 23);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(386, 88);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // ReportQueryMemoEdit
            // 
            this.ReportQueryMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dcReportsBindingSource, "ReportQuery", true));
            this.ReportQueryMemoEdit.Location = new System.Drawing.Point(82, 36);
            this.ReportQueryMemoEdit.Name = "ReportQueryMemoEdit";
            this.ReportQueryMemoEdit.Size = new System.Drawing.Size(383, 421);
            this.ReportQueryMemoEdit.StyleController = this.dataLayoutControl1;
            this.ReportQueryMemoEdit.TabIndex = 3;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.ReportQueryMemoEdit;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(457, 425);
            this.layoutControlItem4.Text = "Sorgu";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(58, 13);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(469, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(389, 533);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFieldName,
            this.colOperator,
            this.colDefaultValue});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.Location = new System.Drawing.Point(457, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(393, 537);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // colFieldName
            // 
            this.colFieldName.Caption = "FieldName";
            this.colFieldName.Name = "colFieldName";
            this.colFieldName.Visible = true;
            this.colFieldName.VisibleIndex = 0;
            // 
            // colOperator
            // 
            this.colOperator.Caption = "Operator";
            this.colOperator.Name = "colOperator";
            this.colOperator.Visible = true;
            this.colOperator.VisibleIndex = 1;
            // 
            // colDefaultValue
            // 
            this.colDefaultValue.Caption = "DefaultValue";
            this.colDefaultValue.Name = "colDefaultValue";
            this.colDefaultValue.Visible = true;
            this.colDefaultValue.VisibleIndex = 2;
            // 
            // FormReportEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 557);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "FormReportEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormQueryEditor";
            this.Load += new System.EventHandler(this.FormQueryEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ReportIdTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dcReportsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForReportId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForReportName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportQueryMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraEditors.SimpleButton btn_Ok;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.BindingSource dcReportsBindingSource;
        private DevExpress.XtraEditors.TextEdit ReportIdTextEdit;
        private DevExpress.XtraEditors.TextEdit ReportNameTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForReportId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForReportName;
        private DevExpress.XtraEditors.MemoEdit ReportQueryMemoEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn FieldName;
        private DevExpress.XtraGrid.Columns.GridColumn colFieldName;
        private DevExpress.XtraGrid.Columns.GridColumn colOperator;
        private DevExpress.XtraGrid.Columns.GridColumn colDefaultValue;
    }
}