using Foxoft.Properties;

namespace Foxoft
{
    partial class FormLoyaltyProgram
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
            btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            btn_Ok = new DevExpress.XtraEditors.SimpleButton();
            NameTextEdit = new DevExpress.XtraEditors.TextEdit();
            dcLoyaltyProgramsBindingSource = new System.Windows.Forms.BindingSource(components);
            EarnPercentCalcEdit = new DevExpress.XtraEditors.CalcEdit();
            ExpireDaysSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            MaxRedeemPercentCalcEdit = new DevExpress.XtraEditors.CalcEdit();
            IsActiveCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            NoteMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            gridControlCards = new MyGridControl();
            dcLoyaltyCardsBindingSource = new System.Windows.Forms.BindingSource(components);
            gridViewCards = new MyGridView();
            colCardNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            colCardIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            colCardCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            tabProgramDetails = new DevExpress.XtraLayout.LayoutControlGroup();
            groupGeneral = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForName = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForEarnPercent = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForExpireDays = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForMaxRedeemPercent = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForIsActive = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForNote = new DevExpress.XtraLayout.LayoutControlItem();
            tabCards = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForGridCards = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemOk = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemCancel = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItemButtons = new DevExpress.XtraLayout.EmptySpaceItem();
            dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).BeginInit();
            dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NameTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dcLoyaltyProgramsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EarnPercentCalcEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ExpireDaysSpinEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MaxRedeemPercentCalcEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IsActiveCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NoteMemoEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControlCards).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dcLoyaltyCardsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewCards).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabbedControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabProgramDetails).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupGeneral).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForEarnPercent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForExpireDays).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForMaxRedeemPercent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForIsActive).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForNote).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabCards).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForGridCards).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemOk).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemCancel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItemButtons).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dxErrorProvider1).BeginInit();
            SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            dataLayoutControl1.Controls.Add(btn_Cancel);
            dataLayoutControl1.Controls.Add(btn_Ok);
            dataLayoutControl1.Controls.Add(NameTextEdit);
            dataLayoutControl1.Controls.Add(EarnPercentCalcEdit);
            dataLayoutControl1.Controls.Add(ExpireDaysSpinEdit);
            dataLayoutControl1.Controls.Add(MaxRedeemPercentCalcEdit);
            dataLayoutControl1.Controls.Add(IsActiveCheckEdit);
            dataLayoutControl1.Controls.Add(NoteMemoEdit);
            dataLayoutControl1.Controls.Add(gridControlCards);
            dataLayoutControl1.DataSource = dcLoyaltyProgramsBindingSource;
            dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            dataLayoutControl1.Name = "dataLayoutControl1";
            dataLayoutControl1.Root = Root;
            dataLayoutControl1.Size = new System.Drawing.Size(684, 461);
            dataLayoutControl1.TabIndex = 0;
            dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // btn_Cancel
            // 
            btn_Cancel.Location = new System.Drawing.Point(488, 417);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new System.Drawing.Size(88, 32);
            btn_Cancel.StyleController = dataLayoutControl1;
            btn_Cancel.TabIndex = 7;
            btn_Cancel.Text = Resources.Common_Cancel;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // btn_Ok
            // 
            btn_Ok.Location = new System.Drawing.Point(580, 417);
            btn_Ok.Name = "btn_Ok";
            btn_Ok.Size = new System.Drawing.Size(92, 32);
            btn_Ok.StyleController = dataLayoutControl1;
            btn_Ok.TabIndex = 8;
            btn_Ok.Text = Resources.Common_Ok;
            btn_Ok.Click += btn_Ok_Click;
            // 
            // NameTextEdit
            // 
            NameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", dcLoyaltyProgramsBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            NameTextEdit.Location = new System.Drawing.Point(148, 69);
            NameTextEdit.Name = "NameTextEdit";
            NameTextEdit.Properties.MaxLength = 80;
            NameTextEdit.Size = new System.Drawing.Size(512, 20);
            NameTextEdit.StyleController = dataLayoutControl1;
            NameTextEdit.TabIndex = 0;
            // 
            // dcLoyaltyProgramsBindingSource
            // 
            dcLoyaltyProgramsBindingSource.DataSource = typeof(Foxoft.Models.DcLoyaltyProgram);
            // 
            // EarnPercentCalcEdit
            // 
            EarnPercentCalcEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", dcLoyaltyProgramsBindingSource, "EarnPercent", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            EarnPercentCalcEdit.Location = new System.Drawing.Point(148, 93);
            EarnPercentCalcEdit.Name = "EarnPercentCalcEdit";
            EarnPercentCalcEdit.Properties.DisplayFormat.FormatString = "N2";
            EarnPercentCalcEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            EarnPercentCalcEdit.Properties.EditFormat.FormatString = "N2";
            EarnPercentCalcEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            EarnPercentCalcEdit.Properties.MaskSettings.Set("mask", "N2");
            EarnPercentCalcEdit.Size = new System.Drawing.Size(512, 20);
            EarnPercentCalcEdit.StyleController = dataLayoutControl1;
            EarnPercentCalcEdit.TabIndex = 1;
            // 
            // ExpireDaysSpinEdit
            // 
            ExpireDaysSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", dcLoyaltyProgramsBindingSource, "ExpireDays", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            ExpireDaysSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            ExpireDaysSpinEdit.Location = new System.Drawing.Point(148, 117);
            ExpireDaysSpinEdit.Name = "ExpireDaysSpinEdit";
            ExpireDaysSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            ExpireDaysSpinEdit.Properties.IsFloatValue = false;
            ExpireDaysSpinEdit.Properties.MaskSettings.Set("mask", "N0");
            ExpireDaysSpinEdit.Properties.MaxValue = new decimal(new int[] {
            3650,
            0,
            0,
            0});
            ExpireDaysSpinEdit.Size = new System.Drawing.Size(512, 20);
            ExpireDaysSpinEdit.StyleController = dataLayoutControl1;
            ExpireDaysSpinEdit.TabIndex = 2;
            // 
            // MaxRedeemPercentCalcEdit
            // 
            MaxRedeemPercentCalcEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", dcLoyaltyProgramsBindingSource, "MaxRedeemPercent", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            MaxRedeemPercentCalcEdit.Location = new System.Drawing.Point(148, 141);
            MaxRedeemPercentCalcEdit.Name = "MaxRedeemPercentCalcEdit";
            MaxRedeemPercentCalcEdit.Properties.DisplayFormat.FormatString = "N2";
            MaxRedeemPercentCalcEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            MaxRedeemPercentCalcEdit.Properties.EditFormat.FormatString = "N2";
            MaxRedeemPercentCalcEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            MaxRedeemPercentCalcEdit.Properties.MaskSettings.Set("mask", "N2");
            MaxRedeemPercentCalcEdit.Size = new System.Drawing.Size(512, 20);
            MaxRedeemPercentCalcEdit.StyleController = dataLayoutControl1;
            MaxRedeemPercentCalcEdit.TabIndex = 3;
            // 
            // IsActiveCheckEdit
            // 
            IsActiveCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", dcLoyaltyProgramsBindingSource, "IsActive", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            IsActiveCheckEdit.Location = new System.Drawing.Point(148, 165);
            IsActiveCheckEdit.Name = "IsActiveCheckEdit";
            IsActiveCheckEdit.Properties.Caption = Resources.Entity_DcLoyaltyProgram_IsActive;
            IsActiveCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            IsActiveCheckEdit.Size = new System.Drawing.Size(512, 20);
            IsActiveCheckEdit.StyleController = dataLayoutControl1;
            IsActiveCheckEdit.TabIndex = 4;
            // 
            // NoteMemoEdit
            // 
            NoteMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", dcLoyaltyProgramsBindingSource, "Note", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            NoteMemoEdit.Location = new System.Drawing.Point(148, 189);
            NoteMemoEdit.Name = "NoteMemoEdit";
            NoteMemoEdit.Properties.MaxLength = 200;
            NoteMemoEdit.Size = new System.Drawing.Size(512, 212);
            NoteMemoEdit.StyleController = dataLayoutControl1;
            NoteMemoEdit.TabIndex = 5;
            // 
            // gridControlCards
            // 
            gridControlCards.DataSource = dcLoyaltyCardsBindingSource;
            gridControlCards.Location = new System.Drawing.Point(24, 45);
            gridControlCards.MainView = gridViewCards;
            gridControlCards.Name = "gridControlCards";
            gridControlCards.Size = new System.Drawing.Size(636, 356);
            gridControlCards.TabIndex = 6;
            gridControlCards.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            gridViewCards});
            // 
            // dcLoyaltyCardsBindingSource
            // 
            dcLoyaltyCardsBindingSource.DataSource = typeof(Foxoft.Models.DcLoyaltyCard);
            // 
            // gridViewCards
            // 
            gridViewCards.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            colCardNumber,
            colCurrAccCode,
            colCustomerName,
            colCardIsActive,
            colCardCreatedDate});
            gridViewCards.GridControl = gridControlCards;
            gridViewCards.Name = "gridViewCards";
            gridViewCards.OptionsBehavior.Editable = false;
            gridViewCards.OptionsView.ShowFooter = true;
            gridViewCards.OptionsView.ShowGroupPanel = false;
            // 
            // colCardNumber
            // 
            colCardNumber.Caption = Resources.Entity_DcLoyaltyCard_CardNumber;
            colCardNumber.FieldName = "CardNumber";
            colCardNumber.Name = "colCardNumber";
            colCardNumber.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CardNumber", "{0}")});
            colCardNumber.Visible = true;
            colCardNumber.VisibleIndex = 0;
            colCardNumber.Width = 120;
            // 
            // colCurrAccCode
            // 
            colCurrAccCode.Caption = Resources.Entity_DcLoyaltyCard_CurrAccCode;
            colCurrAccCode.FieldName = "CurrAccCode";
            colCurrAccCode.Name = "colCurrAccCode";
            colCurrAccCode.Visible = true;
            colCurrAccCode.VisibleIndex = 1;
            colCurrAccCode.Width = 100;
            // 
            // colCustomerName
            // 
            colCustomerName.Caption = Resources.Form_LoyaltyCard_CustomerName;
            colCustomerName.FieldName = "DcCurrAcc.CurrAccDesc";
            colCustomerName.Name = "colCustomerName";
            colCustomerName.Visible = true;
            colCustomerName.VisibleIndex = 2;
            colCustomerName.Width = 180;
            // 
            // colCardIsActive
            // 
            colCardIsActive.Caption = Resources.Entity_DcLoyaltyCard_IsActive;
            colCardIsActive.FieldName = "IsActive";
            colCardIsActive.Name = "colCardIsActive";
            colCardIsActive.Visible = true;
            colCardIsActive.VisibleIndex = 3;
            colCardIsActive.Width = 70;
            // 
            // colCardCreatedDate
            // 
            colCardCreatedDate.Caption = Resources.Entity_Base_CreatedDate;
            colCardCreatedDate.DisplayFormat.FormatString = "g";
            colCardCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colCardCreatedDate.FieldName = "CreatedDate";
            colCardCreatedDate.Name = "colCardCreatedDate";
            colCardCreatedDate.Visible = true;
            colCardCreatedDate.VisibleIndex = 4;
            colCardCreatedDate.Width = 110;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            tabbedControlGroup1,
            layoutControlItemOk,
            layoutControlItemCancel,
            emptySpaceItemButtons});
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(684, 461);
            Root.TextVisible = false;
            // 
            // tabbedControlGroup1
            // 
            tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            tabbedControlGroup1.Name = "tabbedControlGroup1";
            tabbedControlGroup1.SelectedTabPage = tabProgramDetails;
            tabbedControlGroup1.Size = new System.Drawing.Size(664, 405);
            tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            tabProgramDetails,
            tabCards});
            // 
            // tabProgramDetails
            // 
            tabProgramDetails.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            groupGeneral});
            tabProgramDetails.Location = new System.Drawing.Point(0, 0);
            tabProgramDetails.Name = "tabProgramDetails";
            tabProgramDetails.Size = new System.Drawing.Size(640, 360);
            tabProgramDetails.Text = Resources.Form_LoyaltyProgram_Tab_Details;
            // 
            // groupGeneral
            // 
            groupGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            ItemForName,
            ItemForEarnPercent,
            ItemForExpireDays,
            ItemForMaxRedeemPercent,
            ItemForIsActive,
            ItemForNote});
            groupGeneral.Location = new System.Drawing.Point(0, 0);
            groupGeneral.Name = "groupGeneral";
            groupGeneral.Size = new System.Drawing.Size(640, 360);
            groupGeneral.Text = Resources.Form_LoyaltyProgram_Tab_Details;
            // 
            // ItemForName
            // 
            ItemForName.Control = NameTextEdit;
            ItemForName.Location = new System.Drawing.Point(0, 0);
            ItemForName.Name = "ItemForName";
            ItemForName.Size = new System.Drawing.Size(616, 24);
            ItemForName.Text = Resources.Entity_DcLoyaltyProgram_Name;
            ItemForName.TextSize = new System.Drawing.Size(88, 13);
            // 
            // ItemForEarnPercent
            // 
            ItemForEarnPercent.Control = EarnPercentCalcEdit;
            ItemForEarnPercent.Location = new System.Drawing.Point(0, 24);
            ItemForEarnPercent.Name = "ItemForEarnPercent";
            ItemForEarnPercent.Size = new System.Drawing.Size(616, 24);
            ItemForEarnPercent.Text = Resources.Entity_DcLoyaltyProgram_EarnPercent;
            ItemForEarnPercent.TextSize = new System.Drawing.Size(88, 13);
            // 
            // ItemForExpireDays
            // 
            ItemForExpireDays.Control = ExpireDaysSpinEdit;
            ItemForExpireDays.Location = new System.Drawing.Point(0, 48);
            ItemForExpireDays.Name = "ItemForExpireDays";
            ItemForExpireDays.Size = new System.Drawing.Size(616, 24);
            ItemForExpireDays.Text = Resources.Entity_DcLoyaltyProgram_ExpireDays;
            ItemForExpireDays.TextSize = new System.Drawing.Size(88, 13);
            // 
            // ItemForMaxRedeemPercent
            // 
            ItemForMaxRedeemPercent.Control = MaxRedeemPercentCalcEdit;
            ItemForMaxRedeemPercent.Location = new System.Drawing.Point(0, 72);
            ItemForMaxRedeemPercent.Name = "ItemForMaxRedeemPercent";
            ItemForMaxRedeemPercent.Size = new System.Drawing.Size(616, 24);
            ItemForMaxRedeemPercent.Text = Resources.Entity_DcLoyaltyProgram_MaxRedeemPercent;
            ItemForMaxRedeemPercent.TextSize = new System.Drawing.Size(88, 13);
            // 
            // ItemForIsActive
            // 
            ItemForIsActive.Control = IsActiveCheckEdit;
            ItemForIsActive.Location = new System.Drawing.Point(0, 96);
            ItemForIsActive.Name = "ItemForIsActive";
            ItemForIsActive.Size = new System.Drawing.Size(616, 24);
            ItemForIsActive.Text = Resources.Entity_DcLoyaltyProgram_IsActive;
            ItemForIsActive.TextSize = new System.Drawing.Size(0, 0);
            ItemForIsActive.TextVisible = false;
            // 
            // ItemForNote
            // 
            ItemForNote.Control = NoteMemoEdit;
            ItemForNote.Location = new System.Drawing.Point(0, 120);
            ItemForNote.Name = "ItemForNote";
            ItemForNote.Size = new System.Drawing.Size(616, 195);
            ItemForNote.Text = Resources.Entity_DcLoyaltyProgram_Note;
            ItemForNote.TextSize = new System.Drawing.Size(88, 13);
            // 
            // tabCards
            // 
            tabCards.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            ItemForGridCards});
            tabCards.Location = new System.Drawing.Point(0, 0);
            tabCards.Name = "tabCards";
            tabCards.Size = new System.Drawing.Size(640, 360);
            tabCards.Text = Resources.Form_LoyaltyProgram_Tab_Cards;
            // 
            // ItemForGridCards
            // 
            ItemForGridCards.Control = gridControlCards;
            ItemForGridCards.Location = new System.Drawing.Point(0, 0);
            ItemForGridCards.Name = "ItemForGridCards";
            ItemForGridCards.Size = new System.Drawing.Size(640, 360);
            ItemForGridCards.TextSize = new System.Drawing.Size(0, 0);
            ItemForGridCards.TextVisible = false;
            // 
            // layoutControlItemOk
            // 
            layoutControlItemOk.Control = btn_Ok;
            layoutControlItemOk.Location = new System.Drawing.Point(568, 405);
            layoutControlItemOk.MaxSize = new System.Drawing.Size(96, 36);
            layoutControlItemOk.MinSize = new System.Drawing.Size(96, 36);
            layoutControlItemOk.Name = "layoutControlItemOk";
            layoutControlItemOk.Size = new System.Drawing.Size(96, 36);
            layoutControlItemOk.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItemOk.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItemOk.TextVisible = false;
            // 
            // layoutControlItemCancel
            // 
            layoutControlItemCancel.Control = btn_Cancel;
            layoutControlItemCancel.Location = new System.Drawing.Point(476, 405);
            layoutControlItemCancel.MaxSize = new System.Drawing.Size(92, 36);
            layoutControlItemCancel.MinSize = new System.Drawing.Size(92, 36);
            layoutControlItemCancel.Name = "layoutControlItemCancel";
            layoutControlItemCancel.Size = new System.Drawing.Size(92, 36);
            layoutControlItemCancel.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItemCancel.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItemCancel.TextVisible = false;
            // 
            // emptySpaceItemButtons
            // 
            emptySpaceItemButtons.AllowHotTrack = false;
            emptySpaceItemButtons.Location = new System.Drawing.Point(0, 405);
            emptySpaceItemButtons.Name = "emptySpaceItemButtons";
            emptySpaceItemButtons.Size = new System.Drawing.Size(476, 36);
            emptySpaceItemButtons.TextSize = new System.Drawing.Size(0, 0);
            // 
            // dxErrorProvider1
            // 
            dxErrorProvider1.ContainerControl = this;
            // 
            // FormLoyaltyProgram
            // 
            AcceptButton = btn_Ok;
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btn_Cancel;
            ClientSize = new System.Drawing.Size(684, 461);
            Controls.Add(dataLayoutControl1);
            MinimumSize = new System.Drawing.Size(550, 400);
            Name = "FormLoyaltyProgram";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = Resources.Form_LoyaltyProgram_Title;
            Load += FormLoyaltyProgram_Load;
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).EndInit();
            dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NameTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dcLoyaltyProgramsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)EarnPercentCalcEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ExpireDaysSpinEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)MaxRedeemPercentCalcEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)IsActiveCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)NoteMemoEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControlCards).EndInit();
            ((System.ComponentModel.ISupportInitialize)dcLoyaltyCardsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewCards).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabbedControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabProgramDetails).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupGeneral).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForName).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForEarnPercent).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForExpireDays).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForMaxRedeemPercent).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForIsActive).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForNote).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabCards).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForGridCards).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemOk).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemCancel).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItemButtons).EndInit();
            ((System.ComponentModel.ISupportInitialize)dxErrorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup tabProgramDetails;
        private DevExpress.XtraLayout.LayoutControlGroup groupGeneral;
        private DevExpress.XtraLayout.LayoutControlGroup tabCards;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraEditors.SimpleButton btn_Ok;
        private DevExpress.XtraEditors.TextEdit NameTextEdit;
        private DevExpress.XtraEditors.CalcEdit EarnPercentCalcEdit;
        private DevExpress.XtraEditors.SpinEdit ExpireDaysSpinEdit;
        private DevExpress.XtraEditors.CalcEdit MaxRedeemPercentCalcEdit;
        private DevExpress.XtraEditors.CheckEdit IsActiveCheckEdit;
        private DevExpress.XtraEditors.MemoEdit NoteMemoEdit;
        private MyGridControl gridControlCards;
        private MyGridView gridViewCards;
        private DevExpress.XtraGrid.Columns.GridColumn colCardNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCardIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colCardCreatedDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEarnPercent;
        private DevExpress.XtraLayout.LayoutControlItem ItemForExpireDays;
        private DevExpress.XtraLayout.LayoutControlItem ItemForMaxRedeemPercent;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIsActive;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNote;
        private DevExpress.XtraLayout.LayoutControlItem ItemForGridCards;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemOk;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemCancel;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItemButtons;
        private System.Windows.Forms.BindingSource dcLoyaltyProgramsBindingSource;
        private System.Windows.Forms.BindingSource dcLoyaltyCardsBindingSource;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
    }
}