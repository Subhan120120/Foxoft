
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
            dcReportsBindingSource = new BindingSource(components);
            btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            btn_Ok = new DevExpress.XtraEditors.SimpleButton();
            ReportIdTextEdit = new DevExpress.XtraEditors.TextEdit();
            ReportNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            DcReportVariablesGridControl = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ReportTypeIdLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            ReportCategoryIdLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForReportId = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDcReportVariables = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForReportName = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForReportTypeId = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForReportCategoryId = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).BeginInit();
            dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ReportQueryMemoEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dcReportsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ReportIdTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ReportNameTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DcReportVariablesGridControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ReportTypeIdLookUpEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ReportCategoryIdLookUpEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForReportId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDcReportVariables).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForReportName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForReportTypeId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForReportCategoryId).BeginInit();
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
            dataLayoutControl1.Controls.Add(ReportCategoryIdLookUpEdit);
            dataLayoutControl1.DataSource = dcReportsBindingSource;
            dataLayoutControl1.Dock = DockStyle.Fill;
            dataLayoutControl1.Location = new Point(0, 0);
            dataLayoutControl1.Name = "dataLayoutControl1";
            dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(1224, 305, 650, 400);
            dataLayoutControl1.Root = Root;
            dataLayoutControl1.Size = new Size(870, 644);
            dataLayoutControl1.TabIndex = 0;
            dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // ReportQueryMemoEdit
            // 
            ReportQueryMemoEdit.DataBindings.Add(new Binding("EditValue", dcReportsBindingSource, "ReportQuery", true));
            ReportQueryMemoEdit.Location = new Point(126, 60);
            ReportQueryMemoEdit.Name = "ReportQueryMemoEdit";
            ReportQueryMemoEdit.Size = new Size(732, 309);
            ReportQueryMemoEdit.StyleController = dataLayoutControl1;
            ReportQueryMemoEdit.TabIndex = 5;
            // 
            // dcReportsBindingSource
            // 
            dcReportsBindingSource.DataSource = typeof(Models.DcReport);
            // 
            // btn_Cancel
            // 
            btn_Cancel.ImageOptions.Image = (Image)resources.GetObject("btn_Cancel.ImageOptions.Image");
            btn_Cancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_Cancel.Location = new Point(12, 534);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(421, 98);
            btn_Cancel.StyleController = dataLayoutControl1;
            btn_Cancel.TabIndex = 7;
            btn_Cancel.Text = "btn_Cancel";
            // 
            // btn_Ok
            // 
            btn_Ok.ImageOptions.Image = (Image)resources.GetObject("btn_Ok.ImageOptions.Image");
            btn_Ok.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_Ok.Location = new Point(437, 534);
            btn_Ok.Name = "btn_Ok";
            btn_Ok.Size = new Size(421, 98);
            btn_Ok.StyleController = dataLayoutControl1;
            btn_Ok.TabIndex = 8;
            btn_Ok.Text = "btn_Ok";
            btn_Ok.Click += btn_Ok_Click;
            // 
            // ReportIdTextEdit
            // 
            ReportIdTextEdit.DataBindings.Add(new Binding("EditValue", dcReportsBindingSource, "ReportId", true));
            ReportIdTextEdit.Location = new Point(126, 12);
            ReportIdTextEdit.Name = "ReportIdTextEdit";
            ReportIdTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            ReportIdTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ReportIdTextEdit.Properties.Mask.EditMask = "N0";
            ReportIdTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            ReportIdTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            ReportIdTextEdit.Size = new Size(129, 20);
            ReportIdTextEdit.StyleController = dataLayoutControl1;
            ReportIdTextEdit.TabIndex = 0;
            // 
            // ReportNameTextEdit
            // 
            ReportNameTextEdit.DataBindings.Add(new Binding("EditValue", dcReportsBindingSource, "ReportName", true));
            ReportNameTextEdit.Location = new Point(126, 36);
            ReportNameTextEdit.Name = "ReportNameTextEdit";
            ReportNameTextEdit.Size = new Size(732, 20);
            ReportNameTextEdit.StyleController = dataLayoutControl1;
            ReportNameTextEdit.TabIndex = 4;
            // 
            // DcReportVariablesGridControl
            // 
            DcReportVariablesGridControl.DataBindings.Add(new Binding("DataSource", dcReportsBindingSource, "DcReportVariables", true));
            DcReportVariablesGridControl.Location = new Point(12, 373);
            DcReportVariablesGridControl.MainView = gridView1;
            DcReportVariablesGridControl.Name = "DcReportVariablesGridControl";
            DcReportVariablesGridControl.Size = new Size(846, 157);
            DcReportVariablesGridControl.TabIndex = 6;
            DcReportVariablesGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = DcReportVariablesGridControl;
            gridView1.Name = "gridView1";
            // 
            // ReportTypeIdLookUpEdit
            // 
            ReportTypeIdLookUpEdit.DataBindings.Add(new Binding("EditValue", dcReportsBindingSource, "ReportTypeId", true));
            ReportTypeIdLookUpEdit.Location = new Point(734, 12);
            ReportTypeIdLookUpEdit.Name = "ReportTypeIdLookUpEdit";
            ReportTypeIdLookUpEdit.Properties.Appearance.Options.UseTextOptions = true;
            ReportTypeIdLookUpEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ReportTypeIdLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            ReportTypeIdLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ReportTypeId", ""), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ReportTypeDesc", "") });
            ReportTypeIdLookUpEdit.Properties.NullText = "";
            ReportTypeIdLookUpEdit.Size = new Size(124, 20);
            ReportTypeIdLookUpEdit.StyleController = dataLayoutControl1;
            ReportTypeIdLookUpEdit.TabIndex = 3;
            // 
            // ReportCategoryIdLookUpEdit
            // 
            ReportCategoryIdLookUpEdit.DataBindings.Add(new Binding("EditValue", dcReportsBindingSource, "ReportCategoryId", true));
            ReportCategoryIdLookUpEdit.Location = new Point(373, 12);
            ReportCategoryIdLookUpEdit.Name = "ReportCategoryIdLookUpEdit";
            ReportCategoryIdLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            ReportCategoryIdLookUpEdit.Properties.Appearance.Options.UseTextOptions = true;
            ReportCategoryIdLookUpEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ReportCategoryIdLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            ReportCategoryIdLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ReportCategoryId", ""), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ReportCategoryDesc", "") });
            ReportCategoryIdLookUpEdit.Properties.NullText = "";
            ReportCategoryIdLookUpEdit.Size = new Size(243, 20);
            ReportCategoryIdLookUpEdit.StyleController = dataLayoutControl1;
            ReportCategoryIdLookUpEdit.TabIndex = 2;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlGroup1 });
            Root.Name = "Root";
            Root.Size = new Size(870, 644);
            Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.AllowDrawBackground = false;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForReportId, layoutControlItem4, layoutControlItem1, layoutControlItem2, ItemForDcReportVariables, ItemForReportName, ItemForReportTypeId, ItemForReportCategoryId });
            layoutControlGroup1.Location = new Point(0, 0);
            layoutControlGroup1.Name = "autoGeneratedGroup0";
            layoutControlGroup1.Size = new Size(850, 624);
            // 
            // ItemForReportId
            // 
            ItemForReportId.Control = ReportIdTextEdit;
            ItemForReportId.Location = new Point(0, 0);
            ItemForReportId.Name = "ItemForReportId";
            ItemForReportId.Size = new Size(247, 24);
            ItemForReportId.Text = "Report ID";
            ItemForReportId.TextSize = new Size(102, 13);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = ReportQueryMemoEdit;
            layoutControlItem4.Location = new Point(0, 48);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(850, 313);
            layoutControlItem4.Text = "Sorgu";
            layoutControlItem4.TextSize = new Size(102, 13);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = btn_Ok;
            layoutControlItem1.ImageOptions.Image = (Image)resources.GetObject("layoutControlItem1.ImageOptions.Image");
            layoutControlItem1.Location = new Point(425, 522);
            layoutControlItem1.MinSize = new Size(67, 23);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(425, 102);
            layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem1.TextSize = new Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = btn_Cancel;
            layoutControlItem2.Location = new Point(0, 522);
            layoutControlItem2.MinSize = new Size(67, 23);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(425, 102);
            layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem2.TextSize = new Size(0, 0);
            layoutControlItem2.TextVisible = false;
            // 
            // ItemForDcReportVariables
            // 
            ItemForDcReportVariables.Control = DcReportVariablesGridControl;
            ItemForDcReportVariables.Location = new Point(0, 361);
            ItemForDcReportVariables.Name = "ItemForDcReportVariables";
            ItemForDcReportVariables.Size = new Size(850, 161);
            ItemForDcReportVariables.StartNewLine = true;
            ItemForDcReportVariables.Text = "Dc Report Variables";
            ItemForDcReportVariables.TextSize = new Size(0, 0);
            ItemForDcReportVariables.TextVisible = false;
            // 
            // ItemForReportName
            // 
            ItemForReportName.Control = ReportNameTextEdit;
            ItemForReportName.Location = new Point(0, 24);
            ItemForReportName.Name = "ItemForReportName";
            ItemForReportName.Size = new Size(850, 24);
            ItemForReportName.Text = "Hesabat Adı";
            ItemForReportName.TextSize = new Size(102, 13);
            // 
            // ItemForReportTypeId
            // 
            ItemForReportTypeId.Control = ReportTypeIdLookUpEdit;
            ItemForReportTypeId.Location = new Point(608, 0);
            ItemForReportTypeId.Name = "ItemForReportTypeId";
            ItemForReportTypeId.Size = new Size(242, 24);
            ItemForReportTypeId.TextSize = new Size(102, 13);
            // 
            // ItemForReportCategoryId
            // 
            ItemForReportCategoryId.Control = ReportCategoryIdLookUpEdit;
            ItemForReportCategoryId.Location = new Point(247, 0);
            ItemForReportCategoryId.Name = "ItemForReportCategoryId";
            ItemForReportCategoryId.Size = new Size(361, 24);
            ItemForReportCategoryId.Text = "Hesabat Kateqoriyası";
            ItemForReportCategoryId.TextSize = new Size(102, 13);
            // 
            // FormReportEditor
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(870, 644);
            Controls.Add(dataLayoutControl1);
            Name = "FormReportEditor";
            StartPosition = FormStartPosition.CenterScreen;
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
            ((System.ComponentModel.ISupportInitialize)ReportTypeIdLookUpEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ReportCategoryIdLookUpEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForReportId).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDcReportVariables).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForReportName).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForReportTypeId).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForReportCategoryId).EndInit();
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
        private DevExpress.XtraEditors.TextEdit ReportCategoryIdTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForReportCategoryId;
        private DevExpress.XtraEditors.LookUpEdit ReportCategoryIdLookUpEdit;
    }
}