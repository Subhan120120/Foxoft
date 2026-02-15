namespace Foxoft
{
    partial class FormTerminal
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
            TerminalIdTextEdit = new DevExpress.XtraEditors.TextEdit();
            dcTerminalsBindingSource = new BindingSource(components);
            TerminalDescTextEdit = new DevExpress.XtraEditors.TextEdit();
            IsDisabledCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            RowGuidTextEdit = new DevExpress.XtraEditors.TextEdit();
            TouchUIModeCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            TouchScaleFactorSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            CashRegisterCodeButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            StoreCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForTerminalId = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForTerminalDesc = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForCashRegisterCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForIsDisabled = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForTouchUIMode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForTouchScaleFactor = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ItemForStoreCode = new DevExpress.XtraLayout.LayoutControlItem();
            lcgButtons = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForOk = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForCancel = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).BeginInit();
            dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TerminalIdTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dcTerminalsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TerminalDescTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IsDisabledCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RowGuidTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TouchUIModeCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TouchScaleFactorSpinEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CashRegisterCodeButtonEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StoreCodeLookUpEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForTerminalId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForTerminalDesc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCashRegisterCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForIsDisabled).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForTouchUIMode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForTouchScaleFactor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForStoreCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lcgButtons).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForOk).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCancel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dxErrorProvider1).BeginInit();
            SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            dataLayoutControl1.Controls.Add(btn_Cancel);
            dataLayoutControl1.Controls.Add(btn_Ok);
            dataLayoutControl1.Controls.Add(TerminalIdTextEdit);
            dataLayoutControl1.Controls.Add(TerminalDescTextEdit);
            dataLayoutControl1.Controls.Add(IsDisabledCheckEdit);
            dataLayoutControl1.Controls.Add(RowGuidTextEdit);
            dataLayoutControl1.Controls.Add(TouchUIModeCheckEdit);
            dataLayoutControl1.Controls.Add(TouchScaleFactorSpinEdit);
            dataLayoutControl1.Controls.Add(CashRegisterCodeButtonEdit);
            dataLayoutControl1.Controls.Add(StoreCodeLookUpEdit);
            dataLayoutControl1.DataSource = dcTerminalsBindingSource;
            dataLayoutControl1.Dock = DockStyle.Fill;
            dataLayoutControl1.Location = new Point(0, 0);
            dataLayoutControl1.Name = "dataLayoutControl1";
            dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(568, 0, 650, 400);
            dataLayoutControl1.Root = Root;
            dataLayoutControl1.Size = new Size(520, 260);
            dataLayoutControl1.TabIndex = 0;
            dataLayoutControl1.Text = "dataLayoutControl1";
            dataLayoutControl1.FieldRetrieving += dataLayoutControl1_FieldRetrieving;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Location = new Point(262, 156);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(246, 22);
            btn_Cancel.StyleController = dataLayoutControl1;
            btn_Cancel.TabIndex = 9;
            btn_Cancel.Text = "Cancel";
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // btn_Ok
            // 
            btn_Ok.Location = new Point(12, 156);
            btn_Ok.Name = "btn_Ok";
            btn_Ok.Size = new Size(246, 22);
            btn_Ok.StyleController = dataLayoutControl1;
            btn_Ok.TabIndex = 8;
            btn_Ok.Text = "OK";
            btn_Ok.Click += btn_Ok_Click;
            // 
            // TerminalIdTextEdit
            // 
            TerminalIdTextEdit.DataBindings.Add(new Binding("EditValue", dcTerminalsBindingSource, "TerminalId", true));
            TerminalIdTextEdit.Location = new Point(120, 12);
            TerminalIdTextEdit.Name = "TerminalIdTextEdit";
            TerminalIdTextEdit.Properties.ReadOnly = true;
            TerminalIdTextEdit.Size = new Size(136, 20);
            TerminalIdTextEdit.StyleController = dataLayoutControl1;
            TerminalIdTextEdit.TabIndex = 0;
            // 
            // dcTerminalsBindingSource
            // 
            dcTerminalsBindingSource.DataSource = typeof(Models.DcTerminal);
            // 
            // TerminalDescTextEdit
            // 
            TerminalDescTextEdit.DataBindings.Add(new Binding("EditValue", dcTerminalsBindingSource, "TerminalDesc", true));
            TerminalDescTextEdit.Location = new Point(120, 36);
            TerminalDescTextEdit.Name = "TerminalDescTextEdit";
            TerminalDescTextEdit.Size = new Size(388, 20);
            TerminalDescTextEdit.StyleController = dataLayoutControl1;
            TerminalDescTextEdit.TabIndex = 1;
            // 
            // IsDisabledCheckEdit
            // 
            IsDisabledCheckEdit.DataBindings.Add(new Binding("EditValue", dcTerminalsBindingSource, "IsDisabled", true));
            IsDisabledCheckEdit.Location = new Point(12, 108);
            IsDisabledCheckEdit.Name = "IsDisabledCheckEdit";
            IsDisabledCheckEdit.Properties.Caption = Properties.Resources.Common_IsDisabled;
            IsDisabledCheckEdit.Size = new Size(244, 20);
            IsDisabledCheckEdit.StyleController = dataLayoutControl1;
            IsDisabledCheckEdit.TabIndex = 4;
            // 
            // RowGuidTextEdit
            // 
            RowGuidTextEdit.DataBindings.Add(new Binding("EditValue", dcTerminalsBindingSource, "RowGuid", true));
            RowGuidTextEdit.Location = new Point(120, 156);
            RowGuidTextEdit.Name = "RowGuidTextEdit";
            RowGuidTextEdit.Properties.ReadOnly = true;
            RowGuidTextEdit.Size = new Size(388, 20);
            RowGuidTextEdit.StyleController = dataLayoutControl1;
            RowGuidTextEdit.TabIndex = 7;
            // 
            // TouchUIModeCheckEdit
            // 
            TouchUIModeCheckEdit.DataBindings.Add(new Binding("EditValue", dcTerminalsBindingSource, "TouchUIMode", true));
            TouchUIModeCheckEdit.Location = new Point(260, 108);
            TouchUIModeCheckEdit.Name = "TouchUIModeCheckEdit";
            TouchUIModeCheckEdit.Properties.Caption = Properties.Resources.Entity_Terminal_TouchUIMode;
            TouchUIModeCheckEdit.Size = new Size(248, 20);
            TouchUIModeCheckEdit.StyleController = dataLayoutControl1;
            TouchUIModeCheckEdit.TabIndex = 5;
            // 
            // TouchScaleFactorSpinEdit
            // 
            TouchScaleFactorSpinEdit.DataBindings.Add(new Binding("EditValue", dcTerminalsBindingSource, "TouchScaleFactor", true));
            TouchScaleFactorSpinEdit.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            TouchScaleFactorSpinEdit.Location = new Point(120, 132);
            TouchScaleFactorSpinEdit.Name = "TouchScaleFactorSpinEdit";
            TouchScaleFactorSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            TouchScaleFactorSpinEdit.Properties.IsFloatValue = false;
            TouchScaleFactorSpinEdit.Properties.Mask.EditMask = "N00";
            TouchScaleFactorSpinEdit.Size = new Size(388, 20);
            TouchScaleFactorSpinEdit.StyleController = dataLayoutControl1;
            TouchScaleFactorSpinEdit.TabIndex = 6;
            // 
            // CashRegisterCodeButtonEdit
            // 
            CashRegisterCodeButtonEdit.DataBindings.Add(new Binding("EditValue", dcTerminalsBindingSource, "CashRegisterCode", true));
            CashRegisterCodeButtonEdit.Location = new Point(120, 84);
            CashRegisterCodeButtonEdit.Name = "CashRegisterCodeButtonEdit";
            CashRegisterCodeButtonEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            CashRegisterCodeButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            CashRegisterCodeButtonEdit.Size = new Size(388, 20);
            CashRegisterCodeButtonEdit.StyleController = dataLayoutControl1;
            CashRegisterCodeButtonEdit.TabIndex = 10;
            CashRegisterCodeButtonEdit.ButtonClick += CashRegisterCodeButtonEdit_ButtonClick;
            // 
            // StoreCodeLookUpEdit
            // 
            StoreCodeLookUpEdit.DataBindings.Add(new Binding("EditValue", dcTerminalsBindingSource, "StoreCode", true));
            StoreCodeLookUpEdit.Location = new Point(120, 60);
            StoreCodeLookUpEdit.Name = "StoreCodeLookUpEdit";
            StoreCodeLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            StoreCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            StoreCodeLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrAccCode", "CurrAccCode"), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrAccDesc", "CurrAccDesc") });
            StoreCodeLookUpEdit.Properties.DisplayMember = "CurrAccDesc";
            StoreCodeLookUpEdit.Properties.NullText = "";
            StoreCodeLookUpEdit.Properties.ValueMember = "CurrAccCode";
            StoreCodeLookUpEdit.Size = new Size(388, 20);
            StoreCodeLookUpEdit.StyleController = dataLayoutControl1;
            StoreCodeLookUpEdit.TabIndex = 11;
            StoreCodeLookUpEdit.EditValueChanged += StoreCodeLookUpEdit_EditValueChanged;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlGroup1, lcgButtons, layoutControlGroup2 });
            Root.Name = "Root";
            Root.Size = new Size(520, 260);
            Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForTerminalId, ItemForTerminalDesc, ItemForCashRegisterCode, ItemForIsDisabled, ItemForTouchUIMode, ItemForTouchScaleFactor, emptySpaceItem1, ItemForStoreCode });
            layoutControlGroup1.Location = new Point(0, 0);
            layoutControlGroup1.Name = "layoutControlGroup1";
            layoutControlGroup1.Size = new Size(500, 144);
            // 
            // ItemForTerminalId
            // 
            ItemForTerminalId.Control = TerminalIdTextEdit;
            ItemForTerminalId.Location = new Point(0, 0);
            ItemForTerminalId.Name = "ItemForTerminalId";
            ItemForTerminalId.Size = new Size(248, 24);
            ItemForTerminalId.Text = Properties.Resources.Entity_Terminal_Id;
            ItemForTerminalId.TextSize = new Size(96, 13);
            // 
            // ItemForTerminalDesc
            // 
            ItemForTerminalDesc.Control = TerminalDescTextEdit;
            ItemForTerminalDesc.Location = new Point(0, 24);
            ItemForTerminalDesc.Name = "ItemForTerminalDesc";
            ItemForTerminalDesc.Size = new Size(500, 24);
            ItemForTerminalDesc.Text = Properties.Resources.Entity_Terminal_Desc;
            ItemForTerminalDesc.TextSize = new Size(96, 13);
            // 
            // ItemForCashRegisterCode
            // 
            ItemForCashRegisterCode.Control = CashRegisterCodeButtonEdit;
            ItemForCashRegisterCode.Location = new Point(0, 72);
            ItemForCashRegisterCode.Name = "ItemForCashRegisterCode";
            ItemForCashRegisterCode.Size = new Size(500, 24);
            ItemForCashRegisterCode.Text = Properties.Resources.Entity_Terminal_CashRegisterCode;
            ItemForCashRegisterCode.TextSize = new Size(96, 13);
            // 
            // ItemForIsDisabled
            // 
            ItemForIsDisabled.Control = IsDisabledCheckEdit;
            ItemForIsDisabled.Location = new Point(0, 96);
            ItemForIsDisabled.Name = "ItemForIsDisabled";
            ItemForIsDisabled.Size = new Size(248, 24);
            ItemForIsDisabled.TextVisible = false;
            // 
            // ItemForTouchUIMode
            // 
            ItemForTouchUIMode.Control = TouchUIModeCheckEdit;
            ItemForTouchUIMode.Location = new Point(248, 96);
            ItemForTouchUIMode.Name = "ItemForTouchUIMode";
            ItemForTouchUIMode.Size = new Size(252, 24);
            ItemForTouchUIMode.TextVisible = false;
            // 
            // ItemForTouchScaleFactor
            // 
            ItemForTouchScaleFactor.Control = TouchScaleFactorSpinEdit;
            ItemForTouchScaleFactor.Location = new Point(0, 120);
            ItemForTouchScaleFactor.Name = "ItemForTouchScaleFactor";
            ItemForTouchScaleFactor.Size = new Size(500, 24);
            ItemForTouchScaleFactor.Text = Properties.Resources.Entity_Terminal_TouchScaleFactor;
            ItemForTouchScaleFactor.TextSize = new Size(96, 13);
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new Point(248, 0);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(252, 24);
            // 
            // ItemForStoreCode
            // 
            ItemForStoreCode.Control = StoreCodeLookUpEdit;
            ItemForStoreCode.Location = new Point(0, 48);
            ItemForStoreCode.Name = "ItemForStoreCode";
            ItemForStoreCode.Size = new Size(500, 24);
            ItemForStoreCode.TextSize = new Size(96, 13);
            // 
            // lcgButtons
            // 
            lcgButtons.GroupBordersVisible = false;
            lcgButtons.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForOk, ItemForCancel });
            lcgButtons.Location = new Point(0, 144);
            lcgButtons.Name = "lcgButtons";
            lcgButtons.Size = new Size(500, 26);
            // 
            // ItemForOk
            // 
            ItemForOk.Control = btn_Ok;
            ItemForOk.Location = new Point(0, 0);
            ItemForOk.Name = "ItemForOk";
            ItemForOk.Size = new Size(250, 26);
            ItemForOk.TextVisible = false;
            // 
            // ItemForCancel
            // 
            ItemForCancel.Control = btn_Cancel;
            ItemForCancel.Location = new Point(250, 0);
            ItemForCancel.Name = "ItemForCancel";
            ItemForCancel.OptionsTableLayoutItem.ColumnIndex = 1;
            ItemForCancel.Size = new Size(250, 26);
            ItemForCancel.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            layoutControlGroup2.AllowDrawBackground = false;
            layoutControlGroup2.GroupBordersVisible = false;
            layoutControlGroup2.Location = new Point(0, 170);
            layoutControlGroup2.Name = "autoGeneratedGroup0";
            layoutControlGroup2.Size = new Size(500, 70);
            // 
            // dxErrorProvider1
            // 
            dxErrorProvider1.ContainerControl = this;
            // 
            // FormTerminal
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 260);
            Controls.Add(dataLayoutControl1);
            Name = "FormTerminal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Terminal";
            Load += FormTerminal_Load;
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).EndInit();
            dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TerminalIdTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dcTerminalsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)TerminalDescTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)IsDisabledCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)RowGuidTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)TouchUIModeCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)TouchScaleFactorSpinEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)CashRegisterCodeButtonEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)StoreCodeLookUpEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForTerminalId).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForTerminalDesc).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCashRegisterCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForIsDisabled).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForTouchUIMode).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForTouchScaleFactor).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForStoreCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)lcgButtons).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForOk).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCancel).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dxErrorProvider1).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private System.Windows.Forms.BindingSource dcTerminalsBindingSource;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit TerminalIdTextEdit;
        private DevExpress.XtraEditors.TextEdit TerminalDescTextEdit;
        private DevExpress.XtraEditors.CheckEdit IsDisabledCheckEdit;
        private DevExpress.XtraEditors.TextEdit RowGuidTextEdit;
        private DevExpress.XtraEditors.CheckEdit TouchUIModeCheckEdit;
        private DevExpress.XtraEditors.SpinEdit TouchScaleFactorSpinEdit;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraEditors.SimpleButton btn_Ok;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTerminalId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTerminalDesc;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCashRegisterCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIsDisabled;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTouchUIMode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTouchScaleFactor;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgButtons;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOk;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCancel;
        private DevExpress.XtraEditors.ButtonEdit CashRegisterCodeButtonEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.LookUpEdit StoreCodeLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStoreCode;
    }
}
