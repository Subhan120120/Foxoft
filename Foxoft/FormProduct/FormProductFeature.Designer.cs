namespace Foxoft
{
    partial class FormProductFeature
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProductFeature));
            layoutControlMain = new DevExpress.XtraLayout.LayoutControl();
            txtProductCode = new DevExpress.XtraEditors.TextEdit();
            txtProductDesc = new DevExpress.XtraEditors.TextEdit();
            txtBarcode = new DevExpress.XtraEditors.TextEdit();
            btnSearchAi = new DevExpress.XtraEditors.SimpleButton();
            btnCancelAi = new DevExpress.XtraEditors.SimpleButton();
            progressBarAi = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            lblStatus = new DevExpress.XtraEditors.LabelControl();
            gridControlFeatures = new MyGridControl();
            gridViewFeatures = new MyGridView();
            colOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            colFeatureTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            colAiExtractedValue = new DevExpress.XtraGrid.Columns.GridColumn();
            colMatchStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            colMatchedFeatureCode = new DevExpress.XtraGrid.Columns.GridColumn();
            repoBtnEdit_SelectFeature = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            colAction = new DevExpress.XtraGrid.Columns.GridColumn();
            repoBtn_CreateFeature = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            lblSummary = new DevExpress.XtraEditors.LabelControl();
            simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroupHeader = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItemProductCode = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemBarcode = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemProductDesc = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemSearchAi = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemProgress = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemCancelAi = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemStatus = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemGrid = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlGroupBottom = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItemSummary = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemSave = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemCancel = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItemBottom = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)layoutControlMain).BeginInit();
            layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtProductCode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtProductDesc.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBarcode.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)progressBarAi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControlFeatures).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewFeatures).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_SelectFeature).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repoBtn_CreateFeature).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupHeader).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemProductCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemBarcode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemProductDesc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemSearchAi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemProgress).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemCancelAi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupBottom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemSummary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemSave).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemCancel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItemBottom).BeginInit();
            SuspendLayout();
            // 
            // layoutControlMain
            // 
            layoutControlMain.Controls.Add(txtProductCode);
            layoutControlMain.Controls.Add(txtProductDesc);
            layoutControlMain.Controls.Add(txtBarcode);
            layoutControlMain.Controls.Add(btnSearchAi);
            layoutControlMain.Controls.Add(btnCancelAi);
            layoutControlMain.Controls.Add(progressBarAi);
            layoutControlMain.Controls.Add(lblStatus);
            layoutControlMain.Controls.Add(gridControlFeatures);
            layoutControlMain.Controls.Add(lblSummary);
            layoutControlMain.Controls.Add(simpleButtonSave);
            layoutControlMain.Controls.Add(simpleButtonCancel);
            layoutControlMain.Dock = DockStyle.Fill;
            layoutControlMain.Location = new Point(0, 0);
            layoutControlMain.Name = "layoutControlMain";
            layoutControlMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(750, 250, 650, 400);
            layoutControlMain.Root = Root;
            layoutControlMain.Size = new Size(834, 561);
            layoutControlMain.TabIndex = 0;
            layoutControlMain.Text = "layoutControlMain";
            // 
            // txtProductCode
            // 
            txtProductCode.Location = new Point(86, 38);
            txtProductCode.Name = "txtProductCode";
            txtProductCode.Properties.ReadOnly = true;
            txtProductCode.Size = new Size(99, 20);
            txtProductCode.StyleController = layoutControlMain;
            txtProductCode.TabIndex = 0;
            // 
            // txtProductDesc
            // 
            txtProductDesc.Location = new Point(525, 38);
            txtProductDesc.Name = "txtProductDesc";
            txtProductDesc.Size = new Size(292, 20);
            txtProductDesc.StyleController = layoutControlMain;
            txtProductDesc.TabIndex = 2;
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(231, 38);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Properties.ReadOnly = true;
            txtBarcode.Size = new Size(146, 20);
            txtBarcode.StyleController = layoutControlMain;
            txtBarcode.TabIndex = 1;
            // 
            // btnSearchAi
            // 
            btnSearchAi.Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            btnSearchAi.Appearance.Options.UseFont = true;
            btnSearchAi.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnSearchAi.ImageOptions.SvgImage");
            btnSearchAi.ImageOptions.SvgImageSize = new Size(16, 16);
            btnSearchAi.Location = new Point(17, 62);
            btnSearchAi.Name = "btnSearchAi";
            btnSearchAi.Size = new Size(176, 28);
            btnSearchAi.StyleController = layoutControlMain;
            btnSearchAi.TabIndex = 3;
            btnSearchAi.Text = "AI ilə doldur";
            btnSearchAi.Click += btnSearchAi_Click;
            // 
            // btnCancelAi
            // 
            btnCancelAi.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnCancelAi.ImageOptions.SvgImage");
            btnCancelAi.ImageOptions.SvgImageSize = new Size(16, 16);
            btnCancelAi.Location = new Point(703, 62);
            btnCancelAi.Name = "btnCancelAi";
            btnCancelAi.Size = new Size(86, 28);
            btnCancelAi.StyleController = layoutControlMain;
            btnCancelAi.TabIndex = 4;
            btnCancelAi.Text = "Dayandır";
            btnCancelAi.Visible = false;
            btnCancelAi.Click += btnCancelAi_Click;
            // 
            // progressBarAi
            // 
            progressBarAi.EditValue = 0;
            progressBarAi.Location = new Point(197, 67);
            progressBarAi.Name = "progressBarAi";
            progressBarAi.Properties.MarqueeAnimationSpeed = 30;
            progressBarAi.Properties.Stopped = true;
            progressBarAi.Size = new Size(502, 18);
            progressBarAi.StyleController = layoutControlMain;
            progressBarAi.TabIndex = 5;
            // 
            // lblStatus
            // 
            lblStatus.Appearance.ForeColor = Color.DimGray;
            lblStatus.Appearance.Options.UseForeColor = true;
            lblStatus.Location = new Point(793, 69);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(24, 13);
            lblStatus.StyleController = layoutControlMain;
            lblStatus.TabIndex = 6;
            // 
            // gridControlFeatures
            // 
            gridControlFeatures.Location = new Point(12, 99);
            gridControlFeatures.MainView = gridViewFeatures;
            gridControlFeatures.Name = "gridControlFeatures";
            gridControlFeatures.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repoBtnEdit_SelectFeature, repoBtn_CreateFeature });
            gridControlFeatures.Size = new Size(810, 404);
            gridControlFeatures.TabIndex = 7;
            gridControlFeatures.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewFeatures });
            // 
            // gridViewFeatures
            // 
            gridViewFeatures.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colOrder, colFeatureTypeName, colAiExtractedValue, colMatchStatus, colMatchedFeatureCode, colAction });
            gridViewFeatures.GridControl = gridControlFeatures;
            gridViewFeatures.Name = "gridViewFeatures";
            gridViewFeatures.OptionsView.ShowGroupPanel = false;
            gridViewFeatures.OptionsView.ShowIndicator = false;
            gridViewFeatures.RowHeight = 28;
            gridViewFeatures.RowCellStyle += gridViewFeatures_RowCellStyle;
            gridViewFeatures.CustomRowCellEditForEditing += gridViewFeatures_CustomRowCellEditForEditing;
            gridViewFeatures.CellValueChanged += gridViewFeatures_CellValueChanged;
            gridViewFeatures.CustomColumnDisplayText += gridViewFeatures_CustomColumnDisplayText;
            // 
            // colOrder
            // 
            colOrder.AppearanceCell.Options.UseTextOptions = true;
            colOrder.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colOrder.AppearanceHeader.Options.UseTextOptions = true;
            colOrder.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colOrder.Caption = "№";
            colOrder.FieldName = "Order";
            colOrder.MaxWidth = 45;
            colOrder.MinWidth = 35;
            colOrder.Name = "colOrder";
            colOrder.OptionsColumn.AllowEdit = false;
            colOrder.Visible = true;
            colOrder.VisibleIndex = 0;
            colOrder.Width = 40;
            // 
            // colFeatureTypeName
            // 
            colFeatureTypeName.AppearanceCell.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            colFeatureTypeName.AppearanceCell.Options.UseFont = true;
            colFeatureTypeName.Caption = "Özəllik Növü";
            colFeatureTypeName.FieldName = "FeatureTypeName";
            colFeatureTypeName.MinWidth = 100;
            colFeatureTypeName.Name = "colFeatureTypeName";
            colFeatureTypeName.OptionsColumn.AllowEdit = false;
            colFeatureTypeName.Visible = true;
            colFeatureTypeName.VisibleIndex = 1;
            colFeatureTypeName.Width = 140;
            // 
            // colAiExtractedValue
            // 
            colAiExtractedValue.AppearanceCell.ForeColor = Color.MidnightBlue;
            colAiExtractedValue.AppearanceCell.Options.UseForeColor = true;
            colAiExtractedValue.Caption = "AI Nəticəsi (Web)";
            colAiExtractedValue.FieldName = "AiExtractedValue";
            colAiExtractedValue.MinWidth = 120;
            colAiExtractedValue.Name = "colAiExtractedValue";
            colAiExtractedValue.OptionsColumn.AllowEdit = false;
            colAiExtractedValue.Visible = true;
            colAiExtractedValue.VisibleIndex = 2;
            colAiExtractedValue.Width = 180;
            // 
            // colMatchStatus
            // 
            colMatchStatus.AppearanceCell.Options.UseTextOptions = true;
            colMatchStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colMatchStatus.AppearanceHeader.Options.UseTextOptions = true;
            colMatchStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colMatchStatus.Caption = "Status";
            colMatchStatus.FieldName = "Status";
            colMatchStatus.MinWidth = 80;
            colMatchStatus.Name = "colMatchStatus";
            colMatchStatus.OptionsColumn.AllowEdit = false;
            colMatchStatus.Visible = true;
            colMatchStatus.VisibleIndex = 3;
            colMatchStatus.Width = 100;
            // 
            // colMatchedFeatureCode
            // 
            colMatchedFeatureCode.Caption = "Seçilmiş Özəllik";
            colMatchedFeatureCode.ColumnEdit = repoBtnEdit_SelectFeature;
            colMatchedFeatureCode.FieldName = "MatchedFeatureCode";
            colMatchedFeatureCode.MinWidth = 150;
            colMatchedFeatureCode.Name = "colMatchedFeatureCode";
            colMatchedFeatureCode.Visible = true;
            colMatchedFeatureCode.VisibleIndex = 4;
            colMatchedFeatureCode.Width = 230;
            // 
            // repoBtnEdit_SelectFeature
            // 
            repoBtnEdit_SelectFeature.AutoHeight = false;
            repoBtnEdit_SelectFeature.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            repoBtnEdit_SelectFeature.Name = "repoBtnEdit_SelectFeature";
            repoBtnEdit_SelectFeature.ButtonClick += repoBtnEdit_SelectFeature_ButtonClick;
            // 
            // colAction
            // 
            colAction.AppearanceHeader.Options.UseTextOptions = true;
            colAction.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colAction.Caption = "Əməliyyat";
            colAction.ColumnEdit = repoBtn_CreateFeature;
            colAction.MaxWidth = 100;
            colAction.MinWidth = 80;
            colAction.Name = "colAction";
            colAction.Visible = true;
            colAction.VisibleIndex = 5;
            colAction.Width = 85;
            // 
            // repoBtn_CreateFeature
            // 
            repoBtn_CreateFeature.AutoHeight = false;
            repoBtn_CreateFeature.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus) });
            repoBtn_CreateFeature.Name = "repoBtn_CreateFeature";
            repoBtn_CreateFeature.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            repoBtn_CreateFeature.ButtonClick += repoBtn_CreateFeature_ButtonClick;
            // 
            // lblSummary
            // 
            lblSummary.Appearance.Options.UseFont = true;
            lblSummary.Location = new Point(12, 528);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(36, 13);
            lblSummary.StyleController = layoutControlMain;
            lblSummary.TabIndex = 8;
            lblSummary.Text = "Cəmi: 0";
            // 
            // simpleButtonSave
            // 
            simpleButtonSave.Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            simpleButtonSave.Appearance.Options.UseFont = true;
            simpleButtonSave.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("simpleButtonSave.ImageOptions.SvgImage");
            simpleButtonSave.ImageOptions.SvgImageSize = new Size(16, 16);
            simpleButtonSave.Location = new Point(52, 521);
            simpleButtonSave.Name = "simpleButtonSave";
            simpleButtonSave.Size = new Size(120, 28);
            simpleButtonSave.StyleController = layoutControlMain;
            simpleButtonSave.TabIndex = 9;
            simpleButtonSave.Text = "Yadda saxla";
            simpleButtonSave.Click += simpleButtonSave_Click;
            // 
            // simpleButtonCancel
            // 
            simpleButtonCancel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("simpleButtonCancel.ImageOptions.SvgImage");
            simpleButtonCancel.ImageOptions.SvgImageSize = new Size(16, 16);
            simpleButtonCancel.Location = new Point(176, 521);
            simpleButtonCancel.Name = "simpleButtonCancel";
            simpleButtonCancel.Size = new Size(112, 28);
            simpleButtonCancel.StyleController = layoutControlMain;
            simpleButtonCancel.TabIndex = 10;
            simpleButtonCancel.Text = "Ləğv et";
            simpleButtonCancel.Click += simpleButtonCancel_Click;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlGroupHeader, layoutControlItemGrid, layoutControlGroupBottom });
            Root.Name = "Root";
            Root.Size = new Size(834, 561);
            Root.TextVisible = false;
            // 
            // layoutControlGroupHeader
            // 
            layoutControlGroupHeader.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItemProductCode, layoutControlItemBarcode, layoutControlItemProductDesc, layoutControlItemSearchAi, layoutControlItemProgress, layoutControlItemCancelAi, layoutControlItemStatus });
            layoutControlGroupHeader.Location = new Point(0, 0);
            layoutControlGroupHeader.Name = "layoutControlGroupHeader";
            layoutControlGroupHeader.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            layoutControlGroupHeader.Size = new Size(814, 87);
            layoutControlGroupHeader.Text = "Məhsul və AI Axtarış";
            // 
            // layoutControlItemProductCode
            // 
            layoutControlItemProductCode.Control = txtProductCode;
            layoutControlItemProductCode.Location = new Point(0, 0);
            layoutControlItemProductCode.MaxSize = new Size(200, 24);
            layoutControlItemProductCode.MinSize = new Size(150, 24);
            layoutControlItemProductCode.Name = "layoutControlItemProductCode";
            layoutControlItemProductCode.Size = new Size(172, 24);
            layoutControlItemProductCode.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItemProductCode.Text = "Məhsul Kodu:";
            layoutControlItemProductCode.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            layoutControlItemProductCode.TextSize = new Size(64, 13);
            layoutControlItemProductCode.TextToControlDistance = 5;
            // 
            // layoutControlItemBarcode
            // 
            layoutControlItemBarcode.Control = txtBarcode;
            layoutControlItemBarcode.Location = new Point(172, 0);
            layoutControlItemBarcode.MaxSize = new Size(210, 24);
            layoutControlItemBarcode.MinSize = new Size(150, 24);
            layoutControlItemBarcode.Name = "layoutControlItemBarcode";
            layoutControlItemBarcode.Size = new Size(192, 24);
            layoutControlItemBarcode.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItemBarcode.Text = "Barkod:";
            layoutControlItemBarcode.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            layoutControlItemBarcode.TextSize = new Size(37, 13);
            layoutControlItemBarcode.TextToControlDistance = 5;
            // 
            // layoutControlItemProductDesc
            // 
            layoutControlItemProductDesc.Control = txtProductDesc;
            layoutControlItemProductDesc.Location = new Point(364, 0);
            layoutControlItemProductDesc.Name = "layoutControlItemProductDesc";
            layoutControlItemProductDesc.Size = new Size(440, 24);
            layoutControlItemProductDesc.Text = "Axtarış sorğusu / Məhsul adı:";
            layoutControlItemProductDesc.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            layoutControlItemProductDesc.TextSize = new Size(139, 13);
            layoutControlItemProductDesc.TextToControlDistance = 5;
            // 
            // layoutControlItemSearchAi
            // 
            layoutControlItemSearchAi.Control = btnSearchAi;
            layoutControlItemSearchAi.Location = new Point(0, 24);
            layoutControlItemSearchAi.MaxSize = new Size(196, 32);
            layoutControlItemSearchAi.MinSize = new Size(180, 32);
            layoutControlItemSearchAi.Name = "layoutControlItemSearchAi";
            layoutControlItemSearchAi.Size = new Size(180, 32);
            layoutControlItemSearchAi.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItemSearchAi.TextVisible = false;
            // 
            // layoutControlItemProgress
            // 
            layoutControlItemProgress.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            layoutControlItemProgress.Control = progressBarAi;
            layoutControlItemProgress.Location = new Point(180, 24);
            layoutControlItemProgress.Name = "layoutControlItemProgress";
            layoutControlItemProgress.Size = new Size(506, 32);
            layoutControlItemProgress.TextVisible = false;
            layoutControlItemProgress.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItemCancelAi
            // 
            layoutControlItemCancelAi.Control = btnCancelAi;
            layoutControlItemCancelAi.Location = new Point(686, 24);
            layoutControlItemCancelAi.MaxSize = new Size(90, 32);
            layoutControlItemCancelAi.MinSize = new Size(80, 32);
            layoutControlItemCancelAi.Name = "layoutControlItemCancelAi";
            layoutControlItemCancelAi.Size = new Size(90, 32);
            layoutControlItemCancelAi.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItemCancelAi.TextVisible = false;
            layoutControlItemCancelAi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItemStatus
            // 
            layoutControlItemStatus.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            layoutControlItemStatus.Control = lblStatus;
            layoutControlItemStatus.Location = new Point(776, 24);
            layoutControlItemStatus.Name = "layoutControlItemStatus";
            layoutControlItemStatus.Size = new Size(28, 32);
            layoutControlItemStatus.TextVisible = false;
            // 
            // layoutControlItemGrid
            // 
            layoutControlItemGrid.Control = gridControlFeatures;
            layoutControlItemGrid.Location = new Point(0, 87);
            layoutControlItemGrid.Name = "layoutControlItemGrid";
            layoutControlItemGrid.Size = new Size(814, 408);
            layoutControlItemGrid.TextVisible = false;
            // 
            // layoutControlGroupBottom
            // 
            layoutControlGroupBottom.GroupBordersVisible = false;
            layoutControlGroupBottom.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItemSummary, layoutControlItemSave, layoutControlItemCancel, emptySpaceItemBottom });
            layoutControlGroupBottom.Location = new Point(0, 495);
            layoutControlGroupBottom.Name = "layoutControlGroupBottom";
            layoutControlGroupBottom.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            layoutControlGroupBottom.Size = new Size(814, 46);
            layoutControlGroupBottom.TextVisible = false;
            // 
            // layoutControlItemSummary
            // 
            layoutControlItemSummary.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            layoutControlItemSummary.Control = lblSummary;
            layoutControlItemSummary.Location = new Point(0, 14);
            layoutControlItemSummary.Name = "layoutControlItemSummary";
            layoutControlItemSummary.Size = new Size(40, 32);
            layoutControlItemSummary.TextVisible = false;
            // 
            // layoutControlItemSave
            // 
            layoutControlItemSave.Control = simpleButtonSave;
            layoutControlItemSave.Location = new Point(40, 14);
            layoutControlItemSave.MaxSize = new Size(124, 32);
            layoutControlItemSave.MinSize = new Size(110, 32);
            layoutControlItemSave.Name = "layoutControlItemSave";
            layoutControlItemSave.Size = new Size(124, 32);
            layoutControlItemSave.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItemSave.TextVisible = false;
            // 
            // layoutControlItemCancel
            // 
            layoutControlItemCancel.Control = simpleButtonCancel;
            layoutControlItemCancel.Location = new Point(164, 14);
            layoutControlItemCancel.MaxSize = new Size(116, 32);
            layoutControlItemCancel.MinSize = new Size(100, 32);
            layoutControlItemCancel.Name = "layoutControlItemCancel";
            layoutControlItemCancel.Size = new Size(650, 32);
            layoutControlItemCancel.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItemCancel.TextVisible = false;
            // 
            // emptySpaceItemBottom
            // 
            emptySpaceItemBottom.Location = new Point(0, 0);
            emptySpaceItemBottom.Name = "emptySpaceItemBottom";
            emptySpaceItemBottom.Size = new Size(814, 14);
            // 
            // FormProductFeature
            // 
            AcceptButton = simpleButtonSave;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = simpleButtonCancel;
            ClientSize = new Size(834, 561);
            Controls.Add(layoutControlMain);
            KeyPreview = true;
            MinimumSize = new Size(700, 450);
            Name = "FormProductFeature";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Məhsul Özəllikləri";
            Load += FormProductFeature_Load;
            KeyDown += FormProductFeature_KeyDown;
            ((System.ComponentModel.ISupportInitialize)layoutControlMain).EndInit();
            layoutControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtProductCode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtProductDesc.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBarcode.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)progressBarAi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControlFeatures).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewFeatures).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoBtnEdit_SelectFeature).EndInit();
            ((System.ComponentModel.ISupportInitialize)repoBtn_CreateFeature).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupHeader).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemProductCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemBarcode).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemProductDesc).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemSearchAi).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemProgress).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemCancelAi).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupBottom).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemSummary).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemSave).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemCancel).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItemBottom).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControlMain;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupHeader;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupBottom;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItemBottom;
        private DevExpress.XtraEditors.TextEdit txtProductCode;
        private DevExpress.XtraEditors.TextEdit txtProductDesc;
        private DevExpress.XtraEditors.TextEdit txtBarcode;
        private DevExpress.XtraEditors.SimpleButton btnSearchAi;
        private DevExpress.XtraEditors.SimpleButton btnCancelAi;
        private DevExpress.XtraEditors.MarqueeProgressBarControl progressBarAi;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemProductCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBarcode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemProductDesc;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemSearchAi;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemCancelAi;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemProgress;
        private MyGridControl gridControlFeatures;
        private MyGridView gridViewFeatures;
        private DevExpress.XtraGrid.Columns.GridColumn colOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colFeatureTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colAiExtractedValue;
        private DevExpress.XtraGrid.Columns.GridColumn colMatchStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colMatchedFeatureCode;
        private DevExpress.XtraGrid.Columns.GridColumn colAction;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repoBtnEdit_SelectFeature;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repoBtn_CreateFeature;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemGrid;
        private DevExpress.XtraEditors.LabelControl lblSummary;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemSummary;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemSave;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemCancel;
    }
}
