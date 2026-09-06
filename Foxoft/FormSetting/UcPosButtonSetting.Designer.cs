namespace Foxoft
{
    partial class UcPosButtonSetting
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            panelBottom = new DevExpress.XtraEditors.PanelControl();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            btnReset = new DevExpress.XtraEditors.SimpleButton();
            splitContainer = new DevExpress.XtraEditors.SplitContainerControl();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            layoutControlGroupRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            lCG_Buttons = new DevExpress.XtraLayout.LayoutControlGroup();
            groupHidden = new DevExpress.XtraEditors.GroupControl();
            gridHidden = new MyGridControl();
            gridViewHidden = new MyGridView();
            colButtonName = new DevExpress.XtraGrid.Columns.GridColumn();
            colButtonDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)panelBottom).BeginInit();
            panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer.Panel1).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer.Panel2).BeginInit();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupRoot).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lCG_Buttons).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupHidden).BeginInit();
            groupHidden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridHidden).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewHidden).BeginInit();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(btnReset);
            panelBottom.Controls.Add(btnCancel);
            panelBottom.Controls.Add(btnSave);
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Location = new System.Drawing.Point(0, 610);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new System.Drawing.Size(800, 50);
            panelBottom.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCancel.Location = new System.Drawing.Point(698, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(90, 30);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSave.Location = new System.Drawing.Point(598, 10);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(90, 30);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // btnReset
            // 
            btnReset.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            btnReset.Location = new System.Drawing.Point(10, 10);
            btnReset.Name = "btnReset";
            btnReset.Size = new System.Drawing.Size(90, 30);
            btnReset.TabIndex = 2;
            btnReset.Text = "Reset";
            btnReset.Click += btnReset_Click;
            // 
            // splitContainer
            // 
            splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer.Horizontal = false;
            splitContainer.Location = new System.Drawing.Point(0, 0);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(layoutControl1);
            splitContainer.Panel1.MinSize = 200;
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(groupHidden);
            splitContainer.Panel2.MinSize = 150;
            splitContainer.Size = new System.Drawing.Size(800, 610);
            splitContainer.SplitterPosition = 400;
            splitContainer.TabIndex = 0;
            // 
            // layoutControl1
            // 
            layoutControl1.AllowDrop = true;
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = layoutControlGroupRoot;
            layoutControl1.Size = new System.Drawing.Size(800, 400);
            layoutControl1.TabIndex = 0;
            // 
            // layoutControlGroupRoot
            // 
            layoutControlGroupRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroupRoot.GroupBordersVisible = false;
            layoutControlGroupRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { lCG_Buttons });
            layoutControlGroupRoot.Name = "layoutControlGroupRoot";
            layoutControlGroupRoot.Size = new System.Drawing.Size(800, 400);
            // 
            // lCG_Buttons
            // 
            lCG_Buttons.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            lCG_Buttons.Location = new System.Drawing.Point(0, 0);
            lCG_Buttons.Name = "lCG_Buttons";
            lCG_Buttons.Size = new System.Drawing.Size(780, 380);
            lCG_Buttons.Text = "POS Buttons";
            // 
            // groupHidden
            // 
            groupHidden.Controls.Add(gridHidden);
            groupHidden.Dock = System.Windows.Forms.DockStyle.Fill;
            groupHidden.Location = new System.Drawing.Point(0, 0);
            groupHidden.Name = "groupHidden";
            groupHidden.Size = new System.Drawing.Size(800, 200);
            groupHidden.TabIndex = 0;
            groupHidden.Text = "Hidden Buttons";
            // 
            // gridHidden
            // 
            gridHidden.Dock = System.Windows.Forms.DockStyle.Fill;
            gridHidden.Location = new System.Drawing.Point(2, 23);
            gridHidden.MainView = gridViewHidden;
            gridHidden.Name = "gridHidden";
            gridHidden.Size = new System.Drawing.Size(796, 175);
            gridHidden.TabIndex = 0;
            gridHidden.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewHidden });
            // 
            // gridViewHidden
            // 
            gridViewHidden.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colButtonName, colButtonDescription });
            gridViewHidden.GridControl = gridHidden;
            gridViewHidden.Name = "gridViewHidden";
            gridViewHidden.OptionsView.ShowGroupPanel = false;
            gridViewHidden.OptionsView.ShowIndicator = false;
            gridViewHidden.OptionsBehavior.Editable = false;
            // 
            // colButtonName
            // 
            colButtonName.Caption = "Button Name";
            colButtonName.FieldName = "ButtonName";
            colButtonName.Name = "colButtonName";
            colButtonName.Visible = true;
            colButtonName.VisibleIndex = 0;
            // 
            // colButtonDescription
            // 
            colButtonDescription.Caption = "Description";
            colButtonDescription.FieldName = "ButtonDescription";
            colButtonDescription.Name = "colButtonDescription";
            colButtonDescription.Visible = true;
            colButtonDescription.VisibleIndex = 1;
            // 
            // UcPosButtonSetting
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(splitContainer);
            Controls.Add(panelBottom);
            Name = "UcPosButtonSetting";
            Size = new System.Drawing.Size(800, 660);
            Load += UcPosButtonSetting_Load;
            ((System.ComponentModel.ISupportInitialize)panelBottom).EndInit();
            panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer.Panel1).EndInit();
            splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer.Panel2).EndInit();
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupRoot).EndInit();
            ((System.ComponentModel.ISupportInitialize)lCG_Buttons).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupHidden).EndInit();
            groupHidden.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridHidden).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewHidden).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelBottom;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.SplitContainerControl splitContainer;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupRoot;
        private DevExpress.XtraLayout.LayoutControlGroup lCG_Buttons;
        private DevExpress.XtraEditors.GroupControl groupHidden;
        private MyGridControl gridHidden;
        private MyGridView gridViewHidden;
        private DevExpress.XtraGrid.Columns.GridColumn colButtonName;
        private DevExpress.XtraGrid.Columns.GridColumn colButtonDescription;
    }
}
