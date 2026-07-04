     namespace Foxoft
{
    partial class UcShortcutSetting
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
            this.gridControl1 = new MyGridControl();
            this.gridView1 = new MyGridView();
            this.colFormName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colButtonDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShortcutKeys = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(684, 396);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFormName,
            this.colButtonDescription,
            this.colShortcutKeys});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.ShownEditor += new System.EventHandler(this.gridView1_ShownEditor);
            // 
            // colFormName
            // 
            this.colFormName.Caption = "Form Name";
            this.colFormName.FieldName = "FormName";
            this.colFormName.Name = "colFormName";
            this.colFormName.OptionsColumn.AllowEdit = false;
            this.colFormName.Visible = true;
            this.colFormName.VisibleIndex = 0;
            // 
            // colButtonDescription
            // 
            this.colButtonDescription.Caption = "Description";
            this.colButtonDescription.FieldName = "ButtonDescription";
            this.colButtonDescription.Name = "colButtonDescription";
            this.colButtonDescription.OptionsColumn.AllowEdit = false;
            this.colButtonDescription.Visible = true;
            this.colButtonDescription.VisibleIndex = 1;
            // 
            // colShortcutKeys
            // 
            this.colShortcutKeys.Caption = "Shortcut Keys";
            this.colShortcutKeys.FieldName = "ShortcutKeys";
            this.colShortcutKeys.Name = "colShortcutKeys";
            this.colShortcutKeys.Visible = true;
            this.colShortcutKeys.VisibleIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 396);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(684, 45);
            this.panelControl1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(597, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(516, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // UcShortcutSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(684, 441);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "UcShortcutSetting";
            this.Load += new System.EventHandler(this.UcShortcutSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MyGridControl gridControl1;
        private MyGridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colFormName;
        private DevExpress.XtraGrid.Columns.GridColumn colButtonDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colShortcutKeys;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}
