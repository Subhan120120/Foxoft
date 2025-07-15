
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;

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
            xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            ReportQueryMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            dcReportsBindingSource = new BindingSource(components);
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new GridView();
            layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            LCI_Relation = new DevExpress.XtraLayout.LayoutControlItem();
            LCI_ReportQuery = new DevExpress.XtraLayout.LayoutControlItem();
            splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            btn_Ok = new DevExpress.XtraEditors.SimpleButton();
            ReportIdTextEdit = new DevExpress.XtraEditors.TextEdit();
            ReportNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            GC_ReportVariables = new DevExpress.XtraGrid.GridControl();
            dcReportVariableBindingSource = new BindingSource(components);
            GV_ReportVariables = new GridView();
            colVariableId = new DevExpress.XtraGrid.Columns.GridColumn();
            colReportId = new DevExpress.XtraGrid.Columns.GridColumn();
            colVariableTypeId = new DevExpress.XtraGrid.Columns.GridColumn();
            repoLUE_VariableType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colVariableProperty = new DevExpress.XtraGrid.Columns.GridColumn();
            colVariableValue = new DevExpress.XtraGrid.Columns.GridColumn();
            colVariableOperator = new DevExpress.XtraGrid.Columns.GridColumn();
            repoLUE_VariableOperator = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colVariableValueType = new DevExpress.XtraGrid.Columns.GridColumn();
            repoLUE_VariableValueType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            colRepresentative = new DevExpress.XtraGrid.Columns.GridColumn();
            colDcReport = new DevExpress.XtraGrid.Columns.GridColumn();
            colDcReportVariableType = new DevExpress.XtraGrid.Columns.GridColumn();
            repoDateEdit_VariableValue = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            ReportTypeIdLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            ReportCategoryIdLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForReportId = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDcReportVariables = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForReportName = new DevExpress.XtraLayout.LayoutControlItem();
            LCI_SubQueries = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForReportTypeId = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForReportCategoryId = new DevExpress.XtraLayout.LayoutControlItem();
            dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(components);
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).BeginInit();
            dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)xtraTabControl1).BeginInit();
            xtraTabControl1.SuspendLayout();
            xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ReportQueryMemoEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dcReportsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_Relation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_ReportQuery).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitterItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ReportIdTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ReportNameTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GC_ReportVariables).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dcReportVariableBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GV_ReportVariables).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoLUE_VariableType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoLUE_VariableOperator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoLUE_VariableValueType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoDateEdit_VariableValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoDateEdit_VariableValue.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ReportTypeIdLookUpEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ReportCategoryIdLookUpEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForReportId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDcReportVariables).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForReportName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LCI_SubQueries).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForReportTypeId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForReportCategoryId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dxValidationProvider1).BeginInit();
            SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            dataLayoutControl1.Controls.Add(xtraTabControl1);
            dataLayoutControl1.Controls.Add(btn_Cancel);
            dataLayoutControl1.Controls.Add(btn_Ok);
            dataLayoutControl1.Controls.Add(ReportIdTextEdit);
            dataLayoutControl1.Controls.Add(ReportNameTextEdit);
            dataLayoutControl1.Controls.Add(GC_ReportVariables);
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
            // xtraTabControl1
            // 
            xtraTabControl1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeader;
            xtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            xtraTabControl1.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            xtraTabControl1.Location = new Point(12, 60);
            xtraTabControl1.Name = "xtraTabControl1";
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            xtraTabControl1.Size = new Size(846, 371);
            xtraTabControl1.TabIndex = 5;
            xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { xtraTabPage1 });
            xtraTabControl1.CloseButtonClick += xtraTabControl1_CloseButtonClick;
            // 
            // xtraTabPage1
            // 
            xtraTabPage1.Controls.Add(layoutControl1);
            xtraTabPage1.Name = "xtraTabPage1";
            xtraTabPage1.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
            xtraTabPage1.Size = new Size(787, 369);
            xtraTabPage1.Text = "Main";
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(ReportQueryMemoEdit);
            layoutControl1.Controls.Add(gridControl1);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(905, 169, 650, 400);
            layoutControl1.Root = layoutControlGroup2;
            layoutControl1.Size = new Size(787, 369);
            layoutControl1.TabIndex = 8;
            layoutControl1.Text = "layoutControl1";
            // 
            // ReportQueryMemoEdit
            // 
            ReportQueryMemoEdit.DataBindings.Add(new Binding("EditValue", dcReportsBindingSource, "ReportQuery", true));
            ReportQueryMemoEdit.EditValue = "";
            ReportQueryMemoEdit.Location = new Point(12, 148);
            ReportQueryMemoEdit.Name = "ReportQueryMemoEdit";
            ReportQueryMemoEdit.Properties.ScrollBars = ScrollBars.Both;
            ReportQueryMemoEdit.Properties.WordWrap = false;
            ReportQueryMemoEdit.Size = new Size(763, 209);
            ReportQueryMemoEdit.StyleController = layoutControl1;
            ReportQueryMemoEdit.TabIndex = 6;
            // 
            // dcReportsBindingSource
            // 
            dcReportsBindingSource.DataSource = typeof(DcReport);
            // 
            // gridControl1
            // 
            gridControl1.Location = new Point(12, 12);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(763, 122);
            gridControl1.TabIndex = 7;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            // 
            // layoutControlGroup2
            // 
            layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup2.GroupBordersVisible = false;
            layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { LCI_Relation, LCI_ReportQuery, splitterItem1 });
            layoutControlGroup2.Name = "Root";
            layoutControlGroup2.Size = new Size(787, 369);
            layoutControlGroup2.TextVisible = false;
            // 
            // LCI_Relation
            // 
            LCI_Relation.Control = gridControl1;
            LCI_Relation.Location = new Point(0, 0);
            LCI_Relation.Name = "LCI_Relation";
            LCI_Relation.Size = new Size(767, 126);
            LCI_Relation.TextVisible = false;
            // 
            // LCI_ReportQuery
            // 
            LCI_ReportQuery.Control = ReportQueryMemoEdit;
            LCI_ReportQuery.Location = new Point(0, 136);
            LCI_ReportQuery.Name = "layoutControlItem4";
            LCI_ReportQuery.Size = new Size(767, 213);
            LCI_ReportQuery.TextVisible = false;
            // 
            // splitterItem1
            // 
            splitterItem1.Location = new Point(0, 126);
            splitterItem1.Name = "splitterItem1";
            splitterItem1.Size = new Size(767, 10);
            // 
            // btn_Cancel
            // 
            btn_Cancel.ImageOptions.Image = (Image)resources.GetObject("btn_Cancel.ImageOptions.Image");
            btn_Cancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_Cancel.Location = new Point(12, 577);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(421, 55);
            btn_Cancel.StyleController = dataLayoutControl1;
            btn_Cancel.TabIndex = 7;
            btn_Cancel.Text = "btn_Cancel";
            // 
            // btn_Ok
            // 
            btn_Ok.ImageOptions.Image = (Image)resources.GetObject("btn_Ok.ImageOptions.Image");
            btn_Ok.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn_Ok.Location = new Point(437, 577);
            btn_Ok.Name = "btn_Ok";
            btn_Ok.Size = new Size(421, 55);
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
            ReportNameTextEdit.Location = new Point(373, 12);
            ReportNameTextEdit.Name = "ReportNameTextEdit";
            ReportNameTextEdit.Size = new Size(485, 20);
            ReportNameTextEdit.StyleController = dataLayoutControl1;
            ReportNameTextEdit.TabIndex = 4;
            // 
            // GC_ReportVariables
            // 
            GC_ReportVariables.DataSource = dcReportVariableBindingSource;
            GC_ReportVariables.Location = new Point(12, 435);
            GC_ReportVariables.MainView = GV_ReportVariables;
            GC_ReportVariables.Name = "GC_ReportVariables";
            GC_ReportVariables.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repoLUE_VariableType, repoLUE_VariableValueType, repoLUE_VariableOperator, repoDateEdit_VariableValue });
            GC_ReportVariables.Size = new Size(846, 138);
            GC_ReportVariables.TabIndex = 6;
            GC_ReportVariables.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { GV_ReportVariables });
            GC_ReportVariables.KeyDown += DcReportVariablesGridControl_KeyDown;
            // 
            // dcReportVariableBindingSource
            // 
            dcReportVariableBindingSource.DataSource = typeof(DcReportVariable);
            // 
            // GV_ReportVariables
            // 
            GV_ReportVariables.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colVariableId, colReportId, colVariableTypeId, colVariableProperty, colVariableValue, colVariableOperator, colVariableValueType, colRepresentative, colDcReport, colDcReportVariableType });
            GV_ReportVariables.GridControl = GC_ReportVariables;
            GV_ReportVariables.Name = "GV_ReportVariables";
            GV_ReportVariables.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            GV_ReportVariables.OptionsBehavior.EditingMode = GridEditingMode.Inplace;
            GV_ReportVariables.OptionsNavigation.AutoFocusNewRow = true;
            GV_ReportVariables.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            GV_ReportVariables.CustomRowCellEdit += gridView1_CustomRowCellEdit;
            GV_ReportVariables.InitNewRow += gridView1_InitNewRow;
            GV_ReportVariables.CellValueChanged += gridView1_CellValueChanged;
            GV_ReportVariables.ValidateRow += gridView1_ValidateRow;
            GV_ReportVariables.ValidatingEditor += gridView1_ValidatingEditor;
            // 
            // colVariableId
            // 
            colVariableId.FieldName = "VariableId";
            colVariableId.Name = "colVariableId";
            // 
            // colReportId
            // 
            colReportId.FieldName = "ReportId";
            colReportId.Name = "colReportId";
            // 
            // colVariableTypeId
            // 
            colVariableTypeId.ColumnEdit = repoLUE_VariableType;
            colVariableTypeId.FieldName = "VariableTypeId";
            colVariableTypeId.Name = "colVariableTypeId";
            colVariableTypeId.Visible = true;
            colVariableTypeId.VisibleIndex = 0;
            // 
            // repoLUE_VariableType
            // 
            repoLUE_VariableType.AutoHeight = false;
            repoLUE_VariableType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoLUE_VariableType.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VariableTypeId", "Dəyişən Tipi Id"), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VariableTypeDesc", "Dəyişən Tipi Adı") });
            repoLUE_VariableType.DisplayMember = "VariableTypeDesc";
            repoLUE_VariableType.Name = "repoLUE_VariableType";
            repoLUE_VariableType.NullText = "";
            repoLUE_VariableType.ValueMember = "VariableTypeId";
            // 
            // colVariableProperty
            // 
            colVariableProperty.FieldName = "VariableProperty";
            colVariableProperty.Name = "colVariableProperty";
            colVariableProperty.Visible = true;
            colVariableProperty.VisibleIndex = 1;
            // 
            // colVariableValue
            // 
            colVariableValue.FieldName = "VariableValue";
            colVariableValue.Name = "colVariableValue";
            colVariableValue.Visible = true;
            colVariableValue.VisibleIndex = 3;
            // 
            // colVariableOperator
            // 
            colVariableOperator.ColumnEdit = repoLUE_VariableOperator;
            colVariableOperator.FieldName = "VariableOperator";
            colVariableOperator.Name = "colVariableOperator";
            colVariableOperator.Visible = true;
            colVariableOperator.VisibleIndex = 4;
            // 
            // repoLUE_VariableOperator
            // 
            repoLUE_VariableOperator.AutoHeight = false;
            repoLUE_VariableOperator.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoLUE_VariableOperator.Name = "repoLUE_VariableOperator";
            repoLUE_VariableOperator.NullText = "";
            // 
            // colVariableValueType
            // 
            colVariableValueType.ColumnEdit = repoLUE_VariableValueType;
            colVariableValueType.FieldName = "VariableValueType";
            colVariableValueType.Name = "colVariableValueType";
            colVariableValueType.Visible = true;
            colVariableValueType.VisibleIndex = 2;
            // 
            // repoLUE_VariableValueType
            // 
            repoLUE_VariableValueType.AutoHeight = false;
            repoLUE_VariableValueType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoLUE_VariableValueType.Name = "repoLUE_VariableValueType";
            repoLUE_VariableValueType.NullText = "";
            // 
            // colRepresentative
            // 
            colRepresentative.FieldName = "Representative";
            colRepresentative.Name = "colRepresentative";
            colRepresentative.OptionsColumn.AllowEdit = false;
            colRepresentative.Visible = true;
            colRepresentative.VisibleIndex = 5;
            // 
            // colDcReport
            // 
            colDcReport.FieldName = "DcReport";
            colDcReport.Name = "colDcReport";
            // 
            // colDcReportVariableType
            // 
            colDcReportVariableType.FieldName = "DcReportVariableType";
            colDcReportVariableType.Name = "colDcReportVariableType";
            // 
            // repoDateEdit_VariableValue
            // 
            repoDateEdit_VariableValue.AutoHeight = false;
            repoDateEdit_VariableValue.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoDateEdit_VariableValue.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repoDateEdit_VariableValue.Name = "repoDateEdit_VariableValue";
            // 
            // ReportTypeIdLookUpEdit
            // 
            ReportTypeIdLookUpEdit.DataBindings.Add(new Binding("EditValue", dcReportsBindingSource, "ReportTypeId", true));
            ReportTypeIdLookUpEdit.Location = new Point(126, 36);
            ReportTypeIdLookUpEdit.Name = "ReportTypeIdLookUpEdit";
            ReportTypeIdLookUpEdit.Properties.Appearance.Options.UseTextOptions = true;
            ReportTypeIdLookUpEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ReportTypeIdLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            ReportTypeIdLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ReportTypeId", ""), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ReportTypeDesc", "") });
            ReportTypeIdLookUpEdit.Properties.DisplayMember = "ReportTypeDesc";
            ReportTypeIdLookUpEdit.Properties.NullText = "";
            ReportTypeIdLookUpEdit.Properties.ValueMember = "ReportTypeId";
            ReportTypeIdLookUpEdit.Size = new Size(129, 20);
            ReportTypeIdLookUpEdit.StyleController = dataLayoutControl1;
            ReportTypeIdLookUpEdit.TabIndex = 3;
            // 
            // ReportCategoryIdLookUpEdit
            // 
            ReportCategoryIdLookUpEdit.DataBindings.Add(new Binding("EditValue", dcReportsBindingSource, "ReportCategoryId", true));
            ReportCategoryIdLookUpEdit.Location = new Point(373, 36);
            ReportCategoryIdLookUpEdit.Name = "ReportCategoryIdLookUpEdit";
            ReportCategoryIdLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            ReportCategoryIdLookUpEdit.Properties.Appearance.Options.UseTextOptions = true;
            ReportCategoryIdLookUpEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ReportCategoryIdLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            ReportCategoryIdLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ReportCategoryId", ""), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ReportCategoryDesc", "") });
            ReportCategoryIdLookUpEdit.Properties.DisplayMember = "ReportCategoryDesc";
            ReportCategoryIdLookUpEdit.Properties.NullText = "";
            ReportCategoryIdLookUpEdit.Properties.ValueMember = "ReportCategoryId";
            ReportCategoryIdLookUpEdit.Size = new Size(485, 20);
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
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForReportId, layoutControlItem1, layoutControlItem2, ItemForDcReportVariables, ItemForReportName, LCI_SubQueries, ItemForReportTypeId, ItemForReportCategoryId });
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
            // layoutControlItem1
            // 
            layoutControlItem1.Control = btn_Ok;
            layoutControlItem1.ImageOptions.Image = (Image)resources.GetObject("layoutControlItem1.ImageOptions.Image");
            layoutControlItem1.Location = new Point(425, 565);
            layoutControlItem1.MinSize = new Size(67, 23);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(425, 59);
            layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = btn_Cancel;
            layoutControlItem2.Location = new Point(0, 565);
            layoutControlItem2.MinSize = new Size(67, 23);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(425, 59);
            layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem2.TextVisible = false;
            // 
            // ItemForDcReportVariables
            // 
            ItemForDcReportVariables.Control = GC_ReportVariables;
            ItemForDcReportVariables.Location = new Point(0, 423);
            ItemForDcReportVariables.Name = "ItemForDcReportVariables";
            ItemForDcReportVariables.Size = new Size(850, 142);
            ItemForDcReportVariables.StartNewLine = true;
            ItemForDcReportVariables.Text = "Dc Report Variables";
            ItemForDcReportVariables.TextVisible = false;
            // 
            // ItemForReportName
            // 
            ItemForReportName.Control = ReportNameTextEdit;
            ItemForReportName.Location = new Point(247, 0);
            ItemForReportName.Name = "ItemForReportName";
            ItemForReportName.Size = new Size(603, 24);
            ItemForReportName.Text = "Hesabat Adı";
            ItemForReportName.TextSize = new Size(102, 13);
            // 
            // LCI_SubQueries
            // 
            LCI_SubQueries.Control = xtraTabControl1;
            LCI_SubQueries.Location = new Point(0, 48);
            LCI_SubQueries.Name = "LCI_SubQueries";
            LCI_SubQueries.Size = new Size(850, 375);
            LCI_SubQueries.Text = "Alt Sorğular";
            LCI_SubQueries.TextVisible = false;
            // 
            // ItemForReportTypeId
            // 
            ItemForReportTypeId.Control = ReportTypeIdLookUpEdit;
            ItemForReportTypeId.Location = new Point(0, 24);
            ItemForReportTypeId.Name = "ItemForReportTypeId";
            ItemForReportTypeId.Size = new Size(247, 24);
            ItemForReportTypeId.TextSize = new Size(102, 13);
            // 
            // ItemForReportCategoryId
            // 
            ItemForReportCategoryId.Control = ReportCategoryIdLookUpEdit;
            ItemForReportCategoryId.Location = new Point(247, 24);
            ItemForReportCategoryId.Name = "ItemForReportCategoryId";
            ItemForReportCategoryId.Size = new Size(603, 24);
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
            ((System.ComponentModel.ISupportInitialize)xtraTabControl1).EndInit();
            xtraTabControl1.ResumeLayout(false);
            xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ReportQueryMemoEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dcReportsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup2).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_Relation).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_ReportQuery).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitterItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ReportIdTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ReportNameTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)GC_ReportVariables).EndInit();
            ((System.ComponentModel.ISupportInitialize)dcReportVariableBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)GV_ReportVariables).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoLUE_VariableType).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoLUE_VariableOperator).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoLUE_VariableValueType).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoDateEdit_VariableValue.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoDateEdit_VariableValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)ReportTypeIdLookUpEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ReportCategoryIdLookUpEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForReportId).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDcReportVariables).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForReportName).EndInit();
            ((System.ComponentModel.ISupportInitialize)LCI_SubQueries).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForReportTypeId).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForReportCategoryId).EndInit();
            ((System.ComponentModel.ISupportInitialize)dxValidationProvider1).EndInit();
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
        private DevExpress.XtraGrid.GridControl DcReportFiltersGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDcReportFilters;
        private DevExpress.XtraGrid.GridControl GC_ReportVariables;
        private DevExpress.XtraGrid.Views.Grid.GridView GV_ReportVariables;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDcReportVariables;
        private DevExpress.XtraEditors.ComboBoxEdit DcReportTypeComboBoxEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDcReportType;
        private DevExpress.XtraLayout.LayoutControlItem ItemForReportTypeId;
        private DevExpress.XtraEditors.LookUpEdit ReportTypeIdLookUpEdit;
        private DevExpress.XtraEditors.TextEdit ReportCategoryIdTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForReportCategoryId;
        private DevExpress.XtraEditors.LookUpEdit ReportCategoryIdLookUpEdit;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraLayout.LayoutControlItem LCI_SubQueries;
        private BindingSource dcReportVariableBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colVariableId;
        private DevExpress.XtraGrid.Columns.GridColumn colReportId;
        private DevExpress.XtraGrid.Columns.GridColumn colVariableTypeId;
        private DevExpress.XtraGrid.Columns.GridColumn colVariableProperty;
        private DevExpress.XtraGrid.Columns.GridColumn colVariableValue;
        private DevExpress.XtraGrid.Columns.GridColumn colVariableOperator;
        private DevExpress.XtraGrid.Columns.GridColumn colVariableValueType;
        private DevExpress.XtraGrid.Columns.GridColumn colRepresentative;
        private DevExpress.XtraGrid.Columns.GridColumn colDcReport;
        private DevExpress.XtraGrid.Columns.GridColumn colDcReportVariableType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoLUE_VariableType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoLUE_VariableValueType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoLUE_VariableOperator;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repoDateEdit_VariableValue;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.MemoEdit ReportQueryMemoEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem LCI_Relation;
        private DevExpress.XtraLayout.LayoutControlItem LCI_ReportQuery;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
    }
}