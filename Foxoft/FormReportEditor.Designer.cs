
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportEditor));
            dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            ReportQueryMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            dcReportsBindingSource = new System.Windows.Forms.BindingSource(components);
            btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            btn_Ok = new DevExpress.XtraEditors.SimpleButton();
            ReportIdTextEdit = new DevExpress.XtraEditors.TextEdit();
            ReportNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            DcReportVariablesGridControl = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForReportId = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDcReportVariables = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForReportName = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForReportTypeId = new DevExpress.XtraLayout.LayoutControlItem();
            ReportTypeIdLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).BeginInit();
            dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ReportQueryMemoEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dcReportsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ReportIdTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ReportNameTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DcReportVariablesGridControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForReportId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDcReportVariables).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForReportName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForReportTypeId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ReportTypeIdLookUpEdit.Properties).BeginInit();
            SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            dataLayoutControl1.Controls.Add(ReportQueryMemoEdit);
            dataLayoutControl1.Controls.Add(btn_Cancel);
            dataLayoutControl1.Controls.Add(btn_Ok);
            dataLayoutControl1.Controls.Add(ReportIdTextEdit);
            dataLayoutControl1.Controls.Add(ReportNameTextEdit);
            dataLayoutControl1.Controls.Add(DcReportVariablesGridControl);
            dataLayoutControl1.Controls.Add(ReportTypeIdLookUpEdit);
            dataLayoutControl1.DataSource = dcReportsBindingSource;
            dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            dataLayoutControl1.Name = "dataLayoutControl1";
            dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1224, 305, 650, 400);
            dataLayoutControl1.Root = Root;
            dataLayoutControl1.Size = new System.Drawing.Size(870, 644);
            dataLayoutControl1.TabIndex = 0;
            dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // ReportQueryMemoEdit
            // 
            ReportQueryMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", dcReportsBindingSource, "ReportQuery", true));
            ReportQueryMemoEdit.Location = new System.Drawing.Point(83, 60);
            ReportQueryMemoEdit.Name = "ReportQueryMemoEdit";
            ReportQueryMemoEdit.Size = new System.Drawing.Size(775, 323);
            ReportQueryMemoEdit.StyleController = dataLayoutControl1;
            ReportQueryMemoEdit.TabIndex = 3;
            // 
            // dcReportsBindingSource
            // 
            dcReportsBindingSource.DataSource = typeof(Models.DcReport);
            // 
            // btn_Cancel
            // 
            btn_Cancel.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btn_Cancel.ImageOptions.Image");
            btn_Cancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_Cancel.Location = new System.Drawing.Point(12, 555);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new System.Drawing.Size(421, 77);
            btn_Cancel.StyleController = dataLayoutControl1;
            btn_Cancel.TabIndex = 4;
            btn_Cancel.Text = "btn_Cancel";
            // 
            // btn_Ok
            // 
            btn_Ok.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btn_Ok.ImageOptions.Image");
            btn_Ok.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_Ok.Location = new System.Drawing.Point(437, 555);
            btn_Ok.Name = "btn_Ok";
            btn_Ok.Size = new System.Drawing.Size(421, 77);
            btn_Ok.StyleController = dataLayoutControl1;
            btn_Ok.TabIndex = 5;
            btn_Ok.Text = "btn_Ok";
            btn_Ok.Click += btn_Ok_Click;
            // 
            // ReportIdTextEdit
            // 
            ReportIdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", dcReportsBindingSource, "ReportId", true));
            ReportIdTextEdit.Location = new System.Drawing.Point(83, 12);
            ReportIdTextEdit.Name = "ReportIdTextEdit";
            ReportIdTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            ReportIdTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ReportIdTextEdit.Properties.Mask.EditMask = "N0";
            ReportIdTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            ReportIdTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            ReportIdTextEdit.Size = new System.Drawing.Size(350, 20);
            ReportIdTextEdit.StyleController = dataLayoutControl1;
            ReportIdTextEdit.TabIndex = 0;
            // 
            // ReportNameTextEdit
            // 
            ReportNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", dcReportsBindingSource, "ReportName", true));
            ReportNameTextEdit.Location = new System.Drawing.Point(83, 36);
            ReportNameTextEdit.Name = "ReportNameTextEdit";
            ReportNameTextEdit.Size = new System.Drawing.Size(775, 20);
            ReportNameTextEdit.StyleController = dataLayoutControl1;
            ReportNameTextEdit.TabIndex = 2;
            // 
            // DcReportVariablesGridControl
            // 
            DcReportVariablesGridControl.DataBindings.Add(new System.Windows.Forms.Binding("DataSource", dcReportsBindingSource, "DcReportVariables", true));
            DcReportVariablesGridControl.Location = new System.Drawing.Point(12, 387);
            DcReportVariablesGridControl.MainView = gridView1;
            DcReportVariablesGridControl.Name = "DcReportVariablesGridControl";
            DcReportVariablesGridControl.Size = new System.Drawing.Size(846, 164);
            DcReportVariablesGridControl.TabIndex = 6;
            DcReportVariablesGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = DcReportVariablesGridControl;
            gridView1.Name = "gridView1";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlGroup1 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(870, 644);
            Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.AllowDrawBackground = false;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForReportId, layoutControlItem4, layoutControlItem1, layoutControlItem2, ItemForDcReportVariables, ItemForReportName, ItemForReportTypeId });
            layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            layoutControlGroup1.Name = "autoGeneratedGroup0";
            layoutControlGroup1.Size = new System.Drawing.Size(850, 624);
            // 
            // ItemForReportId
            // 
            ItemForReportId.Control = ReportIdTextEdit;
            ItemForReportId.Location = new System.Drawing.Point(0, 0);
            ItemForReportId.Name = "ItemForReportId";
            ItemForReportId.Size = new System.Drawing.Size(425, 24);
            ItemForReportId.Text = "Report ID";
            ItemForReportId.TextSize = new System.Drawing.Size(59, 13);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = ReportQueryMemoEdit;
            layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new System.Drawing.Size(850, 327);
            layoutControlItem4.Text = "Sorgu";
            layoutControlItem4.TextSize = new System.Drawing.Size(59, 13);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = btn_Ok;
            layoutControlItem1.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("layoutControlItem1.ImageOptions.Image");
            layoutControlItem1.Location = new System.Drawing.Point(425, 543);
            layoutControlItem1.MinSize = new System.Drawing.Size(67, 23);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(425, 81);
            layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = btn_Cancel;
            layoutControlItem2.Location = new System.Drawing.Point(0, 543);
            layoutControlItem2.MinSize = new System.Drawing.Size(67, 23);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(425, 81);
            layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem2.TextVisible = false;
            // 
            // ItemForDcReportVariables
            // 
            ItemForDcReportVariables.Control = DcReportVariablesGridControl;
            ItemForDcReportVariables.Location = new System.Drawing.Point(0, 375);
            ItemForDcReportVariables.Name = "ItemForDcReportVariables";
            ItemForDcReportVariables.Size = new System.Drawing.Size(850, 168);
            ItemForDcReportVariables.StartNewLine = true;
            ItemForDcReportVariables.Text = "Dc Report Variables";
            ItemForDcReportVariables.TextSize = new System.Drawing.Size(0, 0);
            ItemForDcReportVariables.TextVisible = false;
            // 
            // ItemForReportName
            // 
            ItemForReportName.Control = ReportNameTextEdit;
            ItemForReportName.Location = new System.Drawing.Point(0, 24);
            ItemForReportName.Name = "ItemForReportName";
            ItemForReportName.Size = new System.Drawing.Size(850, 24);
            ItemForReportName.Text = "Hesabat Adı";
            ItemForReportName.TextSize = new System.Drawing.Size(59, 13);
            // 
            // ItemForReportTypeId
            // 
            ItemForReportTypeId.Control = ReportTypeIdLookUpEdit;
            ItemForReportTypeId.Location = new System.Drawing.Point(425, 0);
            ItemForReportTypeId.Name = "ItemForReportTypeId";
            ItemForReportTypeId.Size = new System.Drawing.Size(425, 24);
            ItemForReportTypeId.TextSize = new System.Drawing.Size(59, 13);
            // 
            // ReportTypeIdLookUpEdit
            // 
            ReportTypeIdLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", dcReportsBindingSource, "ReportTypeId", true));
            ReportTypeIdLookUpEdit.Location = new System.Drawing.Point(508, 12);
            ReportTypeIdLookUpEdit.Name = "ReportTypeIdLookUpEdit";
            ReportTypeIdLookUpEdit.Properties.Appearance.Options.UseTextOptions = true;
            ReportTypeIdLookUpEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ReportTypeIdLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            ReportTypeIdLookUpEdit.Properties.NullText = "";
            ReportTypeIdLookUpEdit.Size = new System.Drawing.Size(350, 20);
            ReportTypeIdLookUpEdit.StyleController = dataLayoutControl1;
            ReportTypeIdLookUpEdit.TabIndex = 8;
            // 
            // FormReportEditor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(870, 644);
            Controls.Add(dataLayoutControl1);
            Name = "FormReportEditor";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "FormQueryEditor";
            Load += FormQueryEditor_Load;
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).EndInit();
            dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ReportQueryMemoEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dcReportsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)ReportIdTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ReportNameTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)DcReportVariablesGridControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForReportId).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDcReportVariables).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForReportName).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForReportTypeId).EndInit();
            ((System.ComponentModel.ISupportInitialize)ReportTypeIdLookUpEdit.Properties).EndInit();
            ResumeLayout(false);
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
        private DevExpress.XtraGrid.GridControl DcReportFiltersGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDcReportFilters;
        private DevExpress.XtraGrid.GridControl DcReportVariablesGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDcReportVariables;
        private DevExpress.XtraEditors.ComboBoxEdit DcReportTypeComboBoxEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDcReportType;
        private DevExpress.XtraLayout.LayoutControlItem ItemForReportTypeId;
        private DevExpress.XtraEditors.LookUpEdit ReportTypeIdLookUpEdit;
    }
}