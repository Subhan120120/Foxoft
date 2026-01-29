using DevExpress.XtraGrid.Views.Grid;

namespace Foxoft
{
    partial class FormPayrollEdit
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
            GrossSalaryTextEdit = new DevExpress.XtraEditors.TextEdit();
            bindingSource1 = new BindingSource(components);
            NetSalaryTextEdit = new DevExpress.XtraEditors.TextEdit();
            LinesGridControl = new DevExpress.XtraGrid.GridControl();
            gridView1 = new GridView();
            CurrAccCodeButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            PayrollPeriodIdButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForCurrAccCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForPayrollPeriodId = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForGrossSalary = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForNetSalary = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForLines = new DevExpress.XtraLayout.LayoutControlItem();
            btnAddLine = new DevExpress.XtraEditors.SimpleButton();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            btnRemoveLine = new DevExpress.XtraEditors.SimpleButton();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).BeginInit();
            dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GrossSalaryTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NetSalaryTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LinesGridControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CurrAccCodeButtonEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PayrollPeriodIdButtonEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCurrAccCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPayrollPeriodId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForGrossSalary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForNetSalary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForLines).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            dataLayoutControl1.Controls.Add(btnCancel);
            dataLayoutControl1.Controls.Add(btnRemoveLine);
            dataLayoutControl1.Controls.Add(btnSave);
            dataLayoutControl1.Controls.Add(btnAddLine);
            dataLayoutControl1.Controls.Add(GrossSalaryTextEdit);
            dataLayoutControl1.Controls.Add(NetSalaryTextEdit);
            dataLayoutControl1.Controls.Add(LinesGridControl);
            dataLayoutControl1.Controls.Add(CurrAccCodeButtonEdit);
            dataLayoutControl1.Controls.Add(PayrollPeriodIdButtonEdit);
            dataLayoutControl1.DataSource = bindingSource1;
            dataLayoutControl1.Dock = DockStyle.Fill;
            dataLayoutControl1.Location = new Point(0, 0);
            dataLayoutControl1.Name = "dataLayoutControl1";
            dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(228, 0, 650, 400);
            dataLayoutControl1.Root = Root;
            dataLayoutControl1.Size = new Size(800, 450);
            dataLayoutControl1.TabIndex = 0;
            dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // GrossSalaryTextEdit
            // 
            GrossSalaryTextEdit.DataBindings.Add(new Binding("EditValue", bindingSource1, "GrossSalary", true));
            GrossSalaryTextEdit.Location = new Point(102, 60);
            GrossSalaryTextEdit.Name = "GrossSalaryTextEdit";
            GrossSalaryTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            GrossSalaryTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            GrossSalaryTextEdit.Properties.Mask.EditMask = "G";
            GrossSalaryTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            GrossSalaryTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            GrossSalaryTextEdit.Size = new Size(686, 20);
            GrossSalaryTextEdit.StyleController = dataLayoutControl1;
            GrossSalaryTextEdit.TabIndex = 6;
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = typeof(Models.TrPayrollHeader);
            // 
            // NetSalaryTextEdit
            // 
            NetSalaryTextEdit.DataBindings.Add(new Binding("EditValue", bindingSource1, "NetSalary", true));
            NetSalaryTextEdit.Location = new Point(102, 84);
            NetSalaryTextEdit.Name = "NetSalaryTextEdit";
            NetSalaryTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            NetSalaryTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            NetSalaryTextEdit.Properties.Mask.EditMask = "G";
            NetSalaryTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            NetSalaryTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            NetSalaryTextEdit.Size = new Size(686, 20);
            NetSalaryTextEdit.StyleController = dataLayoutControl1;
            NetSalaryTextEdit.TabIndex = 7;
            // 
            // LinesGridControl
            // 
            LinesGridControl.DataBindings.Add(new Binding("DataSource", bindingSource1, "Lines", true));
            LinesGridControl.Location = new Point(12, 108);
            LinesGridControl.MainView = gridView1;
            LinesGridControl.Name = "LinesGridControl";
            LinesGridControl.Size = new Size(776, 226);
            LinesGridControl.TabIndex = 8;
            LinesGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = LinesGridControl;
            gridView1.Name = "gridView1";
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // CurrAccCodeButtonEdit
            // 
            CurrAccCodeButtonEdit.DataBindings.Add(new Binding("EditValue", bindingSource1, "CurrAccCode", true));
            CurrAccCodeButtonEdit.Location = new Point(102, 12);
            CurrAccCodeButtonEdit.Name = "CurrAccCodeButtonEdit";
            CurrAccCodeButtonEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            CurrAccCodeButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            CurrAccCodeButtonEdit.Size = new Size(686, 20);
            CurrAccCodeButtonEdit.StyleController = dataLayoutControl1;
            CurrAccCodeButtonEdit.TabIndex = 9;
            CurrAccCodeButtonEdit.ButtonClick += btnEditEmployee_ButtonClick;
            // 
            // PayrollPeriodIdButtonEdit
            // 
            PayrollPeriodIdButtonEdit.DataBindings.Add(new Binding("EditValue", bindingSource1, "PayrollPeriodId", true));
            PayrollPeriodIdButtonEdit.Location = new Point(102, 36);
            PayrollPeriodIdButtonEdit.Name = "PayrollPeriodIdButtonEdit";
            PayrollPeriodIdButtonEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            PayrollPeriodIdButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            PayrollPeriodIdButtonEdit.Size = new Size(686, 20);
            PayrollPeriodIdButtonEdit.StyleController = dataLayoutControl1;
            PayrollPeriodIdButtonEdit.TabIndex = 10;
            PayrollPeriodIdButtonEdit.ButtonClick += BtnEditPeriod_ButtonClick;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlGroup1 });
            Root.Name = "Root";
            Root.Size = new Size(800, 450);
            Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.AllowDrawBackground = false;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForCurrAccCode, ItemForPayrollPeriodId, ItemForGrossSalary, ItemForNetSalary, ItemForLines, layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4 });
            layoutControlGroup1.Location = new Point(0, 0);
            layoutControlGroup1.Name = "autoGeneratedGroup0";
            layoutControlGroup1.Size = new Size(780, 430);
            // 
            // ItemForCurrAccCode
            // 
            ItemForCurrAccCode.Control = CurrAccCodeButtonEdit;
            ItemForCurrAccCode.Location = new Point(0, 0);
            ItemForCurrAccCode.Name = "ItemForCurrAccCode";
            ItemForCurrAccCode.Size = new Size(780, 24);
            ItemForCurrAccCode.Text = "Curr Acc Code";
            ItemForCurrAccCode.TextSize = new Size(78, 13);
            // 
            // ItemForPayrollPeriodId
            // 
            ItemForPayrollPeriodId.Control = PayrollPeriodIdButtonEdit;
            ItemForPayrollPeriodId.Location = new Point(0, 24);
            ItemForPayrollPeriodId.Name = "ItemForPayrollPeriodId";
            ItemForPayrollPeriodId.Size = new Size(780, 24);
            ItemForPayrollPeriodId.Text = "Payroll Period Id";
            ItemForPayrollPeriodId.TextSize = new Size(78, 13);
            // 
            // ItemForGrossSalary
            // 
            ItemForGrossSalary.Control = GrossSalaryTextEdit;
            ItemForGrossSalary.Location = new Point(0, 48);
            ItemForGrossSalary.Name = "ItemForGrossSalary";
            ItemForGrossSalary.Size = new Size(780, 24);
            ItemForGrossSalary.Text = "Gross Salary";
            ItemForGrossSalary.TextSize = new Size(78, 13);
            // 
            // ItemForNetSalary
            // 
            ItemForNetSalary.Control = NetSalaryTextEdit;
            ItemForNetSalary.Location = new Point(0, 72);
            ItemForNetSalary.Name = "ItemForNetSalary";
            ItemForNetSalary.Size = new Size(780, 24);
            ItemForNetSalary.Text = "Net Salary";
            ItemForNetSalary.TextSize = new Size(78, 13);
            // 
            // ItemForLines
            // 
            ItemForLines.Control = LinesGridControl;
            ItemForLines.Location = new Point(0, 96);
            ItemForLines.Name = "ItemForLines";
            ItemForLines.Size = new Size(780, 230);
            ItemForLines.StartNewLine = true;
            ItemForLines.Text = "Lines";
            ItemForLines.TextVisible = false;
            // 
            // btnAddLine
            // 
            btnAddLine.Location = new Point(12, 338);
            btnAddLine.Name = "btnAddLine";
            btnAddLine.Size = new Size(776, 22);
            btnAddLine.StyleController = dataLayoutControl1;
            btnAddLine.TabIndex = 1;
            btnAddLine.Text = "Add Line";
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = btnAddLine;
            layoutControlItem1.Location = new Point(0, 326);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(780, 26);
            layoutControlItem1.TextVisible = false;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 390);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(776, 22);
            btnSave.StyleController = dataLayoutControl1;
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(12, 416);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(776, 22);
            btnCancel.StyleController = dataLayoutControl1;
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            // 
            // btnRemoveLine
            // 
            btnRemoveLine.Location = new Point(12, 364);
            btnRemoveLine.Name = "btnRemoveLine";
            btnRemoveLine.Size = new Size(776, 22);
            btnRemoveLine.StyleController = dataLayoutControl1;
            btnRemoveLine.TabIndex = 3;
            btnRemoveLine.Text = "Remove Line";
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = btnRemoveLine;
            layoutControlItem2.Location = new Point(0, 352);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(780, 26);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = btnSave;
            layoutControlItem3.Location = new Point(0, 378);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new Size(780, 26);
            layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = btnCancel;
            layoutControlItem4.Location = new Point(0, 404);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new Size(780, 26);
            layoutControlItem4.TextVisible = false;
            // 
            // FormPayrollEdit
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataLayoutControl1);
            Name = "FormPayrollEdit";
            Text = "Form1";
            Load += FormPayrollEdit_Load;
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).EndInit();
            dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)GrossSalaryTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)NetSalaryTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)LinesGridControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)CurrAccCodeButtonEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)PayrollPeriodIdButtonEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCurrAccCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForPayrollPeriodId).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForGrossSalary).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForNetSalary).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForLines).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private BindingSource bindingSource1;
        private DevExpress.XtraEditors.TextEdit CurrAccCodeTextEdit;
        private DevExpress.XtraEditors.TextEdit PayrollPeriodIdTextEdit;
        private DevExpress.XtraEditors.TextEdit GrossSalaryTextEdit;
        private DevExpress.XtraEditors.TextEdit NetSalaryTextEdit;
        private DevExpress.XtraGrid.GridControl LinesGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCurrAccCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPayrollPeriodId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForGrossSalary;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNetSalary;
        private DevExpress.XtraLayout.LayoutControlItem ItemForLines;
        private DevExpress.XtraEditors.ButtonEdit CurrAccCodeButtonEdit;
        private DevExpress.XtraEditors.ButtonEdit PayrollPeriodIdButtonEdit;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton btnAddLine;
        private DevExpress.XtraEditors.SimpleButton btnRemoveLine;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}