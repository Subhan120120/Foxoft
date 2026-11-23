namespace Foxoft
{
    partial class FormUnitOfMeasureEdit
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtDesc = new DevExpress.XtraEditors.TextEdit();
            this.lkpParent = new DevExpress.XtraEditors.LookUpEdit();
            this.spnConversionRate = new DevExpress.XtraEditors.SpinEdit();
            this.lblFormula = new DevExpress.XtraEditors.LabelControl();
            this.spnLevel = new DevExpress.XtraEditors.SpinEdit();
            this.chkIsBasic = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsDisabled = new DevExpress.XtraEditors.CheckEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemDesc = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemParent = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemConversionRate = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemFormula = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemLevel = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemIsBasic = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemIsDisabled = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroupButtons = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemSave = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemCancel = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpParent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnConversionRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsBasic.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsDisabled.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemParent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemConversionRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemFormula)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemIsBasic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemIsDisabled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtDesc);
            this.layoutControl1.Controls.Add(this.lkpParent);
            this.layoutControl1.Controls.Add(this.spnConversionRate);
            this.layoutControl1.Controls.Add(this.lblFormula);
            this.layoutControl1.Controls.Add(this.spnLevel);
            this.layoutControl1.Controls.Add(this.chkIsBasic);
            this.layoutControl1.Controls.Add(this.chkIsDisabled);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(460, 290);
            this.layoutControl1.TabIndex = 0;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(145, 12);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Properties.MaxLength = 25;
            this.txtDesc.Size = new System.Drawing.Size(303, 20);
            this.txtDesc.StyleController = this.layoutControl1;
            this.txtDesc.TabIndex = 0;
            // 
            // lkpParent
            // 
            this.lkpParent.Location = new System.Drawing.Point(145, 36);
            this.lkpParent.Name = "lkpParent";
            this.lkpParent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lkpParent.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitOfMeasureDesc", Foxoft.Properties.Resources.Entity_UnitOfMeasure_Desc),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ConversionRate", Foxoft.Properties.Resources.Entity_UnitOfMeasure_ConversionRate)});
            this.lkpParent.Properties.DisplayMember = "UnitOfMeasureDesc";
            this.lkpParent.Properties.NullText = "";
            this.lkpParent.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            this.lkpParent.Properties.ValueMember = "UnitOfMeasureId";
            this.lkpParent.Size = new System.Drawing.Size(303, 20);
            this.lkpParent.StyleController = this.layoutControl1;
            this.lkpParent.TabIndex = 1;
            // 
            // spnConversionRate
            // 
            this.spnConversionRate.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnConversionRate.Location = new System.Drawing.Point(145, 60);
            this.spnConversionRate.Name = "spnConversionRate";
            this.spnConversionRate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnConversionRate.Properties.DisplayFormat.FormatString = "n4";
            this.spnConversionRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spnConversionRate.Properties.EditFormat.FormatString = "n4";
            this.spnConversionRate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spnConversionRate.Properties.MaxValue = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.spnConversionRate.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.spnConversionRate.Size = new System.Drawing.Size(303, 20);
            this.spnConversionRate.StyleController = this.layoutControl1;
            this.spnConversionRate.TabIndex = 2;
            // 
            // lblFormula
            // 
            this.lblFormula.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblFormula.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblFormula.Appearance.Options.UseFont = true;
            this.lblFormula.Appearance.Options.UseForeColor = true;
            this.lblFormula.Location = new System.Drawing.Point(12, 84);
            this.lblFormula.Name = "lblFormula";
            this.lblFormula.Size = new System.Drawing.Size(436, 20);
            this.lblFormula.StyleController = this.layoutControl1;
            this.lblFormula.TabIndex = 3;
            this.lblFormula.Text = "";
            // 
            // spnLevel
            // 
            this.spnLevel.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spnLevel.Location = new System.Drawing.Point(145, 108);
            this.spnLevel.Name = "spnLevel";
            this.spnLevel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnLevel.Properties.IsFloatValue = false;
            this.spnLevel.Properties.MaskSettings.Set("mask", "d");
            this.spnLevel.Properties.MaxValue = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.spnLevel.Size = new System.Drawing.Size(303, 20);
            this.spnLevel.StyleController = this.layoutControl1;
            this.spnLevel.TabIndex = 4;
            // 
            // chkIsBasic
            // 
            this.chkIsBasic.Location = new System.Drawing.Point(12, 132);
            this.chkIsBasic.Name = "chkIsBasic";
            this.chkIsBasic.Properties.Caption = Foxoft.Properties.Resources.Entity_UnitOfMeasure_IsBasic;
            this.chkIsBasic.Size = new System.Drawing.Size(436, 20);
            this.chkIsBasic.StyleController = this.layoutControl1;
            this.chkIsBasic.TabIndex = 5;
            // 
            // chkIsDisabled
            // 
            this.chkIsDisabled.Location = new System.Drawing.Point(12, 156);
            this.chkIsDisabled.Name = "chkIsDisabled";
            this.chkIsDisabled.Properties.Caption = Foxoft.Properties.Resources.Common_IsDisabled;
            this.chkIsDisabled.Size = new System.Drawing.Size(436, 20);
            this.chkIsDisabled.StyleController = this.layoutControl1;
            this.chkIsDisabled.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(24, 192);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(204, 24);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = Foxoft.Properties.Resources.Common_Save;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(232, 192);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(204, 24);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = Foxoft.Properties.Resources.Common_Cancel;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemDesc,
            this.layoutControlItemParent,
            this.layoutControlItemConversionRate,
            this.layoutControlItemFormula,
            this.layoutControlItemLevel,
            this.layoutControlItemIsBasic,
            this.layoutControlItemIsDisabled,
            this.layoutControlGroupButtons});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(460, 290);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItemDesc
            // 
            this.layoutControlItemDesc.Control = this.txtDesc;
            this.layoutControlItemDesc.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemDesc.Name = "layoutControlItemDesc";
            this.layoutControlItemDesc.Size = new System.Drawing.Size(440, 24);
            this.layoutControlItemDesc.Text = Foxoft.Properties.Resources.Entity_UnitOfMeasure_Desc;
            this.layoutControlItemDesc.TextSize = new System.Drawing.Size(121, 13);
            // 
            // layoutControlItemParent
            // 
            this.layoutControlItemParent.Control = this.lkpParent;
            this.layoutControlItemParent.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItemParent.Name = "layoutControlItemParent";
            this.layoutControlItemParent.Size = new System.Drawing.Size(440, 24);
            this.layoutControlItemParent.Text = Foxoft.Properties.Resources.Entity_UnitOfMeasure_ParentId;
            this.layoutControlItemParent.TextSize = new System.Drawing.Size(121, 13);
            // 
            // layoutControlItemConversionRate
            // 
            this.layoutControlItemConversionRate.Control = this.spnConversionRate;
            this.layoutControlItemConversionRate.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItemConversionRate.Name = "layoutControlItemConversionRate";
            this.layoutControlItemConversionRate.Size = new System.Drawing.Size(440, 24);
            this.layoutControlItemConversionRate.Text = Foxoft.Properties.Resources.Entity_UnitOfMeasure_ConversionRate;
            this.layoutControlItemConversionRate.TextSize = new System.Drawing.Size(121, 13);
            // 
            // layoutControlItemFormula
            // 
            this.layoutControlItemFormula.Control = this.lblFormula;
            this.layoutControlItemFormula.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItemFormula.Name = "layoutControlItemFormula";
            this.layoutControlItemFormula.Size = new System.Drawing.Size(440, 24);
            this.layoutControlItemFormula.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemFormula.TextVisible = false;
            // 
            // layoutControlItemLevel
            // 
            this.layoutControlItemLevel.Control = this.spnLevel;
            this.layoutControlItemLevel.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItemLevel.Name = "layoutControlItemLevel";
            this.layoutControlItemLevel.Size = new System.Drawing.Size(440, 24);
            this.layoutControlItemLevel.Text = Foxoft.Properties.Resources.Entity_UnitOfMeasure_Level;
            this.layoutControlItemLevel.TextSize = new System.Drawing.Size(121, 13);
            // 
            // layoutControlItemIsBasic
            // 
            this.layoutControlItemIsBasic.Control = this.chkIsBasic;
            this.layoutControlItemIsBasic.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItemIsBasic.Name = "layoutControlItemIsBasic";
            this.layoutControlItemIsBasic.Size = new System.Drawing.Size(440, 24);
            this.layoutControlItemIsBasic.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemIsBasic.TextVisible = false;
            // 
            // layoutControlItemIsDisabled
            // 
            this.layoutControlItemIsDisabled.Control = this.chkIsDisabled;
            this.layoutControlItemIsDisabled.Location = new System.Drawing.Point(0, 144);
            this.layoutControlItemIsDisabled.Name = "layoutControlItemIsDisabled";
            this.layoutControlItemIsDisabled.Size = new System.Drawing.Size(440, 24);
            this.layoutControlItemIsDisabled.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemIsDisabled.TextVisible = false;
            // 
            // layoutControlGroupButtons
            // 
            this.layoutControlGroupButtons.GroupBordersVisible = false;
            this.layoutControlGroupButtons.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemSave,
            this.layoutControlItemCancel});
            this.layoutControlGroupButtons.Location = new System.Drawing.Point(0, 168);
            this.layoutControlGroupButtons.Name = "layoutControlGroupButtons";
            this.layoutControlGroupButtons.Size = new System.Drawing.Size(440, 102);
            this.layoutControlGroupButtons.TextVisible = false;
            // 
            // layoutControlItemSave
            // 
            this.layoutControlItemSave.Control = this.btnSave;
            this.layoutControlItemSave.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemSave.Name = "layoutControlItemSave";
            this.layoutControlItemSave.Size = new System.Drawing.Size(208, 102);
            this.layoutControlItemSave.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemSave.TextVisible = false;
            // 
            // layoutControlItemCancel
            // 
            this.layoutControlItemCancel.Control = this.btnCancel;
            this.layoutControlItemCancel.Location = new System.Drawing.Point(208, 0);
            this.layoutControlItemCancel.Name = "layoutControlItemCancel";
            this.layoutControlItemCancel.Size = new System.Drawing.Size(232, 102);
            this.layoutControlItemCancel.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemCancel.TextVisible = false;
            // 
            // FormUnitOfMeasureEdit
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(460, 290);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUnitOfMeasureEdit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpParent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnConversionRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsBasic.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsDisabled.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemParent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemConversionRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemFormula)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemIsBasic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemIsDisabled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemCancel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtDesc;
        private DevExpress.XtraEditors.LookUpEdit lkpParent;
        private DevExpress.XtraEditors.SpinEdit spnConversionRate;
        private DevExpress.XtraEditors.LabelControl lblFormula;
        private DevExpress.XtraEditors.SpinEdit spnLevel;
        private DevExpress.XtraEditors.CheckEdit chkIsBasic;
        private DevExpress.XtraEditors.CheckEdit chkIsDisabled;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemDesc;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemParent;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemConversionRate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemFormula;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemLevel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemIsBasic;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemIsDisabled;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupButtons;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemSave;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemCancel;
    }
}
