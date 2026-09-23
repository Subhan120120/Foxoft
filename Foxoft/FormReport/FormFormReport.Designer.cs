using Foxoft.Models.Entity.Report;
using Foxoft.Properties;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Foxoft
{
    partial class FormFormReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            components = new Container();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            FormCodeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            trFormReportsBindingSource = new BindingSource(components);
            ReportIdLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            ShortcutButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            UseReportAsLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            btn_Ok = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForFormCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForReportId = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForShortcut = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForUseReportAs = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItemButtons = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItemCancel = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemOk = new DevExpress.XtraLayout.LayoutControlItem();
            dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(components);
            ((ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((ISupportInitialize)FormCodeLookUpEdit.Properties).BeginInit();
            ((ISupportInitialize)trFormReportsBindingSource).BeginInit();
            ((ISupportInitialize)ReportIdLookUpEdit.Properties).BeginInit();
            ((ISupportInitialize)ShortcutButtonEdit.Properties).BeginInit();
            ((ISupportInitialize)UseReportAsLookUpEdit.Properties).BeginInit();
            ((ISupportInitialize)Root).BeginInit();
            ((ISupportInitialize)ItemForFormCode).BeginInit();
            ((ISupportInitialize)ItemForReportId).BeginInit();
            ((ISupportInitialize)ItemForShortcut).BeginInit();
            ((ISupportInitialize)ItemForUseReportAs).BeginInit();
            ((ISupportInitialize)emptySpaceItemButtons).BeginInit();
            ((ISupportInitialize)layoutControlItemCancel).BeginInit();
            ((ISupportInitialize)layoutControlItemOk).BeginInit();
            ((ISupportInitialize)dxErrorProvider1).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(FormCodeLookUpEdit);
            layoutControl1.Controls.Add(ReportIdLookUpEdit);
            layoutControl1.Controls.Add(ShortcutButtonEdit);
            layoutControl1.Controls.Add(UseReportAsLookUpEdit);
            layoutControl1.Controls.Add(btn_Cancel);
            layoutControl1.Controls.Add(btn_Ok);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(464, 186);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // FormCodeLookUpEdit
            // 
            FormCodeLookUpEdit.DataBindings.Add(new Binding("EditValue", trFormReportsBindingSource, "FormCode", true));
            FormCodeLookUpEdit.Location = new Point(144, 12);
            FormCodeLookUpEdit.Name = "FormCodeLookUpEdit";
            FormCodeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            FormCodeLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FormCode", Resources.Entity_Form_Code, 80, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FormDesc", Resources.Entity_Form_Desc, 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)
            });
            FormCodeLookUpEdit.Properties.DisplayMember = "FormDesc";
            FormCodeLookUpEdit.Properties.NullText = "";
            FormCodeLookUpEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            FormCodeLookUpEdit.Properties.ValueMember = "FormCode";
            FormCodeLookUpEdit.Size = new Size(308, 20);
            FormCodeLookUpEdit.StyleController = layoutControl1;
            FormCodeLookUpEdit.TabIndex = 0;
            // 
            // trFormReportsBindingSource
            // 
            trFormReportsBindingSource.DataSource = typeof(TrFormReport);
            // 
            // ReportIdLookUpEdit
            // 
            ReportIdLookUpEdit.DataBindings.Add(new Binding("EditValue", trFormReportsBindingSource, "ReportId", true));
            ReportIdLookUpEdit.Location = new Point(144, 36);
            ReportIdLookUpEdit.Name = "ReportIdLookUpEdit";
            ReportIdLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            ReportIdLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ReportId", Resources.Entity_Report_Id, 50, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ReportName", Resources.Entity_Report_Name, 220, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)
            });
            ReportIdLookUpEdit.Properties.DisplayMember = "ReportName";
            ReportIdLookUpEdit.Properties.NullText = "";
            ReportIdLookUpEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            ReportIdLookUpEdit.Properties.ValueMember = "ReportId";
            ReportIdLookUpEdit.Size = new Size(308, 20);
            ReportIdLookUpEdit.StyleController = layoutControl1;
            ReportIdLookUpEdit.TabIndex = 1;
            // 
            // ShortcutButtonEdit
            // 
            ShortcutButtonEdit.DataBindings.Add(new Binding("EditValue", trFormReportsBindingSource, "Shortcut", true));
            ShortcutButtonEdit.Location = new Point(144, 60);
            ShortcutButtonEdit.Name = "ShortcutButtonEdit";
            ShortcutButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            });
            ShortcutButtonEdit.Properties.NullValuePrompt = Resources.FormShortcut_PressKey;
            ShortcutButtonEdit.Properties.ReadOnly = true;
            ShortcutButtonEdit.Properties.ShowNullValuePrompt = DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly | DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorFocused;
            ShortcutButtonEdit.Size = new Size(308, 20);
            ShortcutButtonEdit.StyleController = layoutControl1;
            ShortcutButtonEdit.TabIndex = 2;
            ShortcutButtonEdit.ButtonClick += ShortcutButtonEdit_ButtonClick;
            ShortcutButtonEdit.KeyDown += ShortcutButtonEdit_KeyDown;
            // 
            // UseReportAsLookUpEdit
            // 
            UseReportAsLookUpEdit.DataBindings.Add(new Binding("EditValue", trFormReportsBindingSource, "UseReportAs", true));
            UseReportAsLookUpEdit.Location = new Point(144, 84);
            UseReportAsLookUpEdit.Name = "UseReportAsLookUpEdit";
            UseReportAsLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            UseReportAsLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", Resources.Entity_FormReport_UseReportAs)
            });
            UseReportAsLookUpEdit.Properties.DisplayMember = "Name";
            UseReportAsLookUpEdit.Properties.NullText = "";
            UseReportAsLookUpEdit.Properties.ShowHeader = false;
            UseReportAsLookUpEdit.Properties.ValueMember = "Value";
            UseReportAsLookUpEdit.Size = new Size(308, 20);
            UseReportAsLookUpEdit.StyleController = layoutControl1;
            UseReportAsLookUpEdit.TabIndex = 3;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Location = new Point(258, 142);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(94, 32);
            btn_Cancel.StyleController = layoutControl1;
            btn_Cancel.TabIndex = 5;
            btn_Cancel.Text = Resources.Common_Cancel;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // btn_Ok
            // 
            btn_Ok.Location = new Point(356, 142);
            btn_Ok.Name = "btn_Ok";
            btn_Ok.Size = new Size(96, 32);
            btn_Ok.StyleController = layoutControl1;
            btn_Ok.TabIndex = 4;
            btn_Ok.Text = Resources.Common_Save;
            btn_Ok.Click += btn_Ok_Click;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                ItemForFormCode,
                ItemForReportId,
                ItemForShortcut,
                ItemForUseReportAs,
                emptySpaceItemButtons,
                layoutControlItemCancel,
                layoutControlItemOk
            });
            Root.Name = "Root";
            Root.Size = new Size(464, 186);
            Root.TextVisible = false;
            // 
            // ItemForFormCode
            // 
            ItemForFormCode.Control = FormCodeLookUpEdit;
            ItemForFormCode.Location = new Point(0, 0);
            ItemForFormCode.Name = "ItemForFormCode";
            ItemForFormCode.Size = new Size(444, 24);
            ItemForFormCode.Text = Resources.Entity_FormReport_FormCode;
            ItemForFormCode.TextSize = new Size(120, 13);
            // 
            // ItemForReportId
            // 
            ItemForReportId.Control = ReportIdLookUpEdit;
            ItemForReportId.Location = new Point(0, 24);
            ItemForReportId.Name = "ItemForReportId";
            ItemForReportId.Size = new Size(444, 24);
            ItemForReportId.Text = Resources.Entity_FormReport_ReportId;
            ItemForReportId.TextSize = new Size(120, 13);
            // 
            // ItemForShortcut
            // 
            ItemForShortcut.Control = ShortcutButtonEdit;
            ItemForShortcut.Location = new Point(0, 48);
            ItemForShortcut.Name = "ItemForShortcut";
            ItemForShortcut.Size = new Size(444, 24);
            ItemForShortcut.Text = Resources.Entity_FormReport_Shortcut;
            ItemForShortcut.TextSize = new Size(120, 13);
            // 
            // ItemForUseReportAs
            // 
            ItemForUseReportAs.Control = UseReportAsLookUpEdit;
            ItemForUseReportAs.Location = new Point(0, 72);
            ItemForUseReportAs.Name = "ItemForUseReportAs";
            ItemForUseReportAs.Size = new Size(444, 24);
            ItemForUseReportAs.Text = Resources.Entity_FormReport_UseReportAs;
            ItemForUseReportAs.TextSize = new Size(120, 13);
            // 
            // emptySpaceItemButtons
            // 
            emptySpaceItemButtons.AllowHotTrack = false;
            emptySpaceItemButtons.Location = new Point(0, 96);
            emptySpaceItemButtons.Name = "emptySpaceItemButtons";
            emptySpaceItemButtons.Size = new Size(246, 70);
            emptySpaceItemButtons.TextSize = new Size(0, 0);
            // 
            // layoutControlItemCancel
            // 
            layoutControlItemCancel.Control = btn_Cancel;
            layoutControlItemCancel.Location = new Point(246, 130);
            layoutControlItemCancel.MaxSize = new Size(98, 36);
            layoutControlItemCancel.MinSize = new Size(98, 36);
            layoutControlItemCancel.Name = "layoutControlItemCancel";
            layoutControlItemCancel.Size = new Size(98, 36);
            layoutControlItemCancel.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItemCancel.TextSize = new Size(0, 0);
            layoutControlItemCancel.TextVisible = false;
            // 
            // layoutControlItemOk
            // 
            layoutControlItemOk.Control = btn_Ok;
            layoutControlItemOk.Location = new Point(344, 130);
            layoutControlItemOk.MaxSize = new Size(100, 36);
            layoutControlItemOk.MinSize = new Size(100, 36);
            layoutControlItemOk.Name = "layoutControlItemOk";
            layoutControlItemOk.Size = new Size(100, 36);
            layoutControlItemOk.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItemOk.TextSize = new Size(0, 0);
            layoutControlItemOk.TextVisible = false;
            // 
            // dxErrorProvider1
            // 
            dxErrorProvider1.ContainerControl = this;
            // 
            // FormFormReport
            // 
            AcceptButton = btn_Ok;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btn_Cancel;
            ClientSize = new Size(464, 186);
            Controls.Add(layoutControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormFormReport";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = Resources.Entity_FormReport;
            Load += FormFormReport_Load;
            ((ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((ISupportInitialize)FormCodeLookUpEdit.Properties).EndInit();
            ((ISupportInitialize)trFormReportsBindingSource).EndInit();
            ((ISupportInitialize)ReportIdLookUpEdit.Properties).EndInit();
            ((ISupportInitialize)ShortcutButtonEdit.Properties).EndInit();
            ((ISupportInitialize)UseReportAsLookUpEdit.Properties).EndInit();
            ((ISupportInitialize)Root).EndInit();
            ((ISupportInitialize)ItemForFormCode).EndInit();
            ((ISupportInitialize)ItemForReportId).EndInit();
            ((ISupportInitialize)ItemForShortcut).EndInit();
            ((ISupportInitialize)ItemForUseReportAs).EndInit();
            ((ISupportInitialize)emptySpaceItemButtons).EndInit();
            ((ISupportInitialize)layoutControlItemCancel).EndInit();
            ((ISupportInitialize)layoutControlItemOk).EndInit();
            ((ISupportInitialize)dxErrorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private BindingSource trFormReportsBindingSource;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraEditors.SimpleButton btn_Ok;
        private DevExpress.XtraEditors.LookUpEdit FormCodeLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit ReportIdLookUpEdit;
        private DevExpress.XtraEditors.ButtonEdit ShortcutButtonEdit;
        private DevExpress.XtraEditors.LookUpEdit UseReportAsLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForFormCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForReportId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForShortcut;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUseReportAs;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemOk;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemCancel;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItemButtons;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
    }
}
