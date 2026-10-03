using Foxoft.Properties;

namespace Foxoft
{
    partial class FormCurrAccRelation
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
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            CurrAccCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            RelatedCurrAccCodeButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            RelatedCurrAccDescTextEdit = new DevExpress.XtraEditors.TextEdit();
            RelationTypeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            NoteTextEdit = new DevExpress.XtraEditors.TextEdit();
            btn_Ok = new DevExpress.XtraEditors.SimpleButton();
            btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForCurrAccCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForRelatedCurrAccCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForRelatedCurrAccDesc = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForRelationType = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForNote = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ItemForOk = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForCancel = new DevExpress.XtraLayout.LayoutControlItem();
            dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CurrAccCodeTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RelatedCurrAccCodeButtonEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RelatedCurrAccDescTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RelationTypeLookUpEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NoteTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCurrAccCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForRelatedCurrAccCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForRelatedCurrAccDesc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForRelationType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForNote).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForOk).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCancel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dxErrorProvider1).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(CurrAccCodeTextEdit);
            layoutControl1.Controls.Add(RelatedCurrAccCodeButtonEdit);
            layoutControl1.Controls.Add(RelatedCurrAccDescTextEdit);
            layoutControl1.Controls.Add(RelationTypeLookUpEdit);
            layoutControl1.Controls.Add(NoteTextEdit);
            layoutControl1.Controls.Add(btn_Ok);
            layoutControl1.Controls.Add(btn_Cancel);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(450, 220);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // CurrAccCodeTextEdit
            // 
            CurrAccCodeTextEdit.Location = new Point(160, 12);
            CurrAccCodeTextEdit.Name = "CurrAccCodeTextEdit";
            CurrAccCodeTextEdit.Properties.ReadOnly = true;
            CurrAccCodeTextEdit.Properties.Appearance.BackColor = Color.LightGray;
            CurrAccCodeTextEdit.Size = new Size(278, 20);
            CurrAccCodeTextEdit.StyleController = layoutControl1;
            CurrAccCodeTextEdit.TabIndex = 0;
            // 
            // RelatedCurrAccCodeButtonEdit
            // 
            RelatedCurrAccCodeButtonEdit.Location = new Point(160, 36);
            RelatedCurrAccCodeButtonEdit.Name = "RelatedCurrAccCodeButtonEdit";
            RelatedCurrAccCodeButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            RelatedCurrAccCodeButtonEdit.Properties.ButtonClick += RelatedCurrAccCodeButtonEdit_ButtonClick;
            RelatedCurrAccCodeButtonEdit.Properties.Validating += RelatedCurrAccCodeButtonEdit_Validating;
            RelatedCurrAccCodeButtonEdit.Size = new Size(278, 20);
            RelatedCurrAccCodeButtonEdit.StyleController = layoutControl1;
            RelatedCurrAccCodeButtonEdit.TabIndex = 1;
            // 
            // RelatedCurrAccDescTextEdit
            // 
            RelatedCurrAccDescTextEdit.Location = new Point(160, 60);
            RelatedCurrAccDescTextEdit.Name = "RelatedCurrAccDescTextEdit";
            RelatedCurrAccDescTextEdit.Properties.ReadOnly = true;
            RelatedCurrAccDescTextEdit.Properties.Appearance.BackColor = Color.LightGray;
            RelatedCurrAccDescTextEdit.Size = new Size(278, 20);
            RelatedCurrAccDescTextEdit.StyleController = layoutControl1;
            RelatedCurrAccDescTextEdit.TabIndex = 2;
            // 
            // RelationTypeLookUpEdit
            // 
            RelationTypeLookUpEdit.Location = new Point(160, 84);
            RelationTypeLookUpEdit.Name = "RelationTypeLookUpEdit";
            RelationTypeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            RelationTypeLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RelationTypeName", Resources.Entity_CurrAccRelationType_Name) });
            RelationTypeLookUpEdit.Properties.DisplayMember = "RelationTypeName";
            RelationTypeLookUpEdit.Properties.NullText = "";
            RelationTypeLookUpEdit.Properties.ValueMember = "RelationTypeId";
            RelationTypeLookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            RelationTypeLookUpEdit.Properties.ProcessNewValue += RelationTypeLookUpEdit_ProcessNewValue;
            RelationTypeLookUpEdit.Size = new Size(278, 20);
            RelationTypeLookUpEdit.StyleController = layoutControl1;
            RelationTypeLookUpEdit.TabIndex = 3;
            // 
            // NoteTextEdit
            // 
            NoteTextEdit.Location = new Point(160, 108);
            NoteTextEdit.Name = "NoteTextEdit";
            NoteTextEdit.Size = new Size(278, 20);
            NoteTextEdit.StyleController = layoutControl1;
            NoteTextEdit.TabIndex = 4;
            // 
            // btn_Ok
            // 
            btn_Ok.Location = new Point(12, 186);
            btn_Ok.Name = "btn_Ok";
            btn_Ok.Size = new Size(210, 22);
            btn_Ok.StyleController = layoutControl1;
            btn_Ok.TabIndex = 5;
            btn_Ok.Text = Resources.Common_Save;
            btn_Ok.Click += btn_Ok_Click;
            // 
            // btn_Cancel
            // 
            btn_Cancel.DialogResult = DialogResult.Cancel;
            btn_Cancel.Location = new Point(226, 186);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(212, 22);
            btn_Cancel.StyleController = layoutControl1;
            btn_Cancel.TabIndex = 6;
            btn_Cancel.Text = Resources.Common_Cancel;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForCurrAccCode, ItemForRelatedCurrAccCode, ItemForRelatedCurrAccDesc, ItemForRelationType, ItemForNote, emptySpaceItem1, ItemForOk, ItemForCancel });
            Root.Name = "Root";
            Root.Size = new Size(450, 220);
            Root.TextVisible = false;
            // 
            // ItemForCurrAccCode
            // 
            ItemForCurrAccCode.Control = CurrAccCodeTextEdit;
            ItemForCurrAccCode.Location = new Point(0, 0);
            ItemForCurrAccCode.Name = "ItemForCurrAccCode";
            ItemForCurrAccCode.Size = new Size(430, 24);
            ItemForCurrAccCode.Text = Resources.Entity_CurrAcc_Code;
            ItemForCurrAccCode.TextSize = new Size(140, 13);
            // 
            // ItemForRelatedCurrAccCode
            // 
            ItemForRelatedCurrAccCode.Control = RelatedCurrAccCodeButtonEdit;
            ItemForRelatedCurrAccCode.Location = new Point(0, 24);
            ItemForRelatedCurrAccCode.Name = "ItemForRelatedCurrAccCode";
            ItemForRelatedCurrAccCode.Size = new Size(430, 24);
            ItemForRelatedCurrAccCode.Text = Resources.Entity_CurrAccRelation_RelatedCurrAccCode;
            ItemForRelatedCurrAccCode.TextSize = new Size(140, 13);
            // 
            // ItemForRelatedCurrAccDesc
            // 
            ItemForRelatedCurrAccDesc.Control = RelatedCurrAccDescTextEdit;
            ItemForRelatedCurrAccDesc.Location = new Point(0, 48);
            ItemForRelatedCurrAccDesc.Name = "ItemForRelatedCurrAccDesc";
            ItemForRelatedCurrAccDesc.Size = new Size(430, 24);
            ItemForRelatedCurrAccDesc.Text = Resources.Entity_CurrAccRelation_RelatedCurrAccDesc;
            ItemForRelatedCurrAccDesc.TextSize = new Size(140, 13);
            // 
            // ItemForRelationType
            // 
            ItemForRelationType.Control = RelationTypeLookUpEdit;
            ItemForRelationType.Location = new Point(0, 72);
            ItemForRelationType.Name = "ItemForRelationType";
            ItemForRelationType.Size = new Size(430, 24);
            ItemForRelationType.Text = Resources.Entity_CurrAccRelation_RelationType;
            ItemForRelationType.TextSize = new Size(140, 13);
            // 
            // ItemForNote
            // 
            ItemForNote.Control = NoteTextEdit;
            ItemForNote.Location = new Point(0, 96);
            ItemForNote.Name = "ItemForNote";
            ItemForNote.Size = new Size(430, 24);
            ItemForNote.Text = Resources.Entity_CurrAccRelation_Note;
            ItemForNote.TextSize = new Size(140, 13);
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.AllowHotTrack = false;
            emptySpaceItem1.Location = new Point(0, 120);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(430, 54);
            emptySpaceItem1.TextSize = new Size(0, 0);
            // 
            // ItemForOk
            // 
            ItemForOk.Control = btn_Ok;
            ItemForOk.Location = new Point(0, 174);
            ItemForOk.Name = "ItemForOk";
            ItemForOk.Size = new Size(214, 26);
            ItemForOk.TextSize = new Size(0, 0);
            ItemForOk.TextVisible = false;
            // 
            // ItemForCancel
            // 
            ItemForCancel.Control = btn_Cancel;
            ItemForCancel.Location = new Point(214, 174);
            ItemForCancel.Name = "ItemForCancel";
            ItemForCancel.Size = new Size(216, 26);
            ItemForCancel.TextSize = new Size(0, 0);
            ItemForCancel.TextVisible = false;
            // 
            // dxErrorProvider1
            // 
            dxErrorProvider1.ContainerControl = this;
            // 
            // FormCurrAccRelation
            // 
            AcceptButton = btn_Ok;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btn_Cancel;
            ClientSize = new Size(450, 220);
            Controls.Add(layoutControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCurrAccRelation";
            StartPosition = FormStartPosition.CenterParent;
            Load += FormCurrAccRelation_Load;
            KeyDown += FormCurrAccRelation_KeyDown;
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CurrAccCodeTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)RelatedCurrAccCodeButtonEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)RelatedCurrAccDescTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)RelationTypeLookUpEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)NoteTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCurrAccCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForRelatedCurrAccCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForRelatedCurrAccDesc).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForRelationType).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForNote).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForOk).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCancel).EndInit();
            ((System.ComponentModel.ISupportInitialize)dxErrorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit CurrAccCodeTextEdit;
        private DevExpress.XtraEditors.ButtonEdit RelatedCurrAccCodeButtonEdit;
        private DevExpress.XtraEditors.TextEdit RelatedCurrAccDescTextEdit;
        private DevExpress.XtraEditors.LookUpEdit RelationTypeLookUpEdit;
        private DevExpress.XtraEditors.TextEdit NoteTextEdit;
        private DevExpress.XtraEditors.SimpleButton btn_Ok;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCurrAccCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForRelatedCurrAccCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForRelatedCurrAccDesc;
        private DevExpress.XtraLayout.LayoutControlItem ItemForRelationType;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNote;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOk;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCancel;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
    }
}
