using Foxoft.Properties;

namespace Foxoft
{
    partial class FormCurrAccContactDetail
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
            ContactDescTextEdit = new DevExpress.XtraEditors.ButtonEdit();
            bindingSource1 = new BindingSource(components);
            ContactTypeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            SendWhatsappCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            btn_Ok = new DevExpress.XtraEditors.SimpleButton();
            btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForContactType = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForContactDesc = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForSendWhatsapp = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ItemForOk = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForCancel = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ContactDescTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ContactTypeLookUpEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SendWhatsappCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForContactType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForContactDesc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForSendWhatsapp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForOk).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCancel).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(ContactDescTextEdit);
            layoutControl1.Controls.Add(ContactTypeLookUpEdit);
            layoutControl1.Controls.Add(SendWhatsappCheckEdit);
            layoutControl1.Controls.Add(btn_Ok);
            layoutControl1.Controls.Add(btn_Cancel);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(448, 0, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(400, 224);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // ContactDescTextEdit
            // 
            ContactDescTextEdit.DataBindings.Add(new Binding("EditValue", bindingSource1, "ContactDesc", true));
            ContactDescTextEdit.Location = new Point(148, 36);
            ContactDescTextEdit.Name = "ContactDescTextEdit";
            ContactDescTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            ContactDescTextEdit.Properties.ButtonClick += ContactDescTextEdit_ButtonClick;
            ContactDescTextEdit.Size = new Size(240, 20);
            ContactDescTextEdit.StyleController = layoutControl1;
            ContactDescTextEdit.TabIndex = 1;
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = typeof(Models.DcCurrAccContactDetail);
            // 
            // ContactTypeLookUpEdit
            // 
            ContactTypeLookUpEdit.DataBindings.Add(new Binding("EditValue", bindingSource1, "ContactTypeId", true));
            ContactTypeLookUpEdit.Location = new Point(148, 12);
            ContactTypeLookUpEdit.Name = "ContactTypeLookUpEdit";
            ContactTypeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            ContactTypeLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ContactTypeDesc", Resources.Entity_ContactType_Desc) });
            ContactTypeLookUpEdit.Properties.DisplayMember = "ContactTypeDesc";
            ContactTypeLookUpEdit.Properties.NullText = "";
            ContactTypeLookUpEdit.Properties.ValueMember = "Id";
            ContactTypeLookUpEdit.Size = new Size(240, 20);
            ContactTypeLookUpEdit.StyleController = layoutControl1;
            ContactTypeLookUpEdit.TabIndex = 0;
            ContactTypeLookUpEdit.EditValueChanged += ContactTypeLookUpEdit_EditValueChanged;
            // 
            // SendWhatsappCheckEdit
            // 
            SendWhatsappCheckEdit.DataBindings.Add(new Binding("EditValue", bindingSource1, "SendWhatsapp", true));
            SendWhatsappCheckEdit.Location = new Point(12, 60);
            SendWhatsappCheckEdit.Name = "SendWhatsappCheckEdit";
            SendWhatsappCheckEdit.Properties.Caption = Resources.Entity_CurrAccContactDetail_SendWhatsapp;
            SendWhatsappCheckEdit.Size = new Size(376, 20);
            SendWhatsappCheckEdit.StyleController = layoutControl1;
            SendWhatsappCheckEdit.TabIndex = 2;
            // 
            // btn_Ok
            // 
            btn_Ok.Location = new Point(12, 190);
            btn_Ok.Name = "btn_Ok";
            btn_Ok.Size = new Size(108, 22);
            btn_Ok.StyleController = layoutControl1;
            btn_Ok.TabIndex = 3;
            btn_Ok.Text = "Save";
            btn_Ok.Click += btn_Ok_Click;
            // 
            // btn_Cancel
            // 
            btn_Cancel.DialogResult = DialogResult.Cancel;
            btn_Cancel.Location = new Point(124, 190);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(264, 22);
            btn_Cancel.StyleController = layoutControl1;
            btn_Cancel.TabIndex = 4;
            btn_Cancel.Text = "Cancel";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForContactType, ItemForContactDesc, ItemForSendWhatsapp, emptySpaceItem1, ItemForOk, ItemForCancel });
            Root.Name = "Root";
            Root.Size = new Size(400, 224);
            Root.TextVisible = false;
            // 
            // ItemForContactType
            // 
            ItemForContactType.Control = ContactTypeLookUpEdit;
            ItemForContactType.Location = new Point(0, 0);
            ItemForContactType.Name = "ItemForContactType";
            ItemForContactType.Size = new Size(380, 24);
            ItemForContactType.Text = Resources.Entity_ContactType;
            ItemForContactType.TextSize = new Size(124, 13);
            // 
            // ItemForContactDesc
            // 
            ItemForContactDesc.Control = ContactDescTextEdit;
            ItemForContactDesc.Location = new Point(0, 24);
            ItemForContactDesc.Name = "ItemForContactDesc";
            ItemForContactDesc.Size = new Size(380, 24);
            ItemForContactDesc.Text = Resources.Entity_CurrAccContactDetail_Desc;
            ItemForContactDesc.TextSize = new Size(124, 13);
            // 
            // ItemForSendWhatsapp
            // 
            ItemForSendWhatsapp.Control = SendWhatsappCheckEdit;
            ItemForSendWhatsapp.Location = new Point(0, 48);
            ItemForSendWhatsapp.Name = "ItemForSendWhatsapp";
            ItemForSendWhatsapp.Size = new Size(380, 24);
            ItemForSendWhatsapp.TextVisible = false;
            ItemForSendWhatsapp.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new Point(0, 72);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(380, 106);
            // 
            // ItemForOk
            // 
            ItemForOk.Control = btn_Ok;
            ItemForOk.Location = new Point(0, 178);
            ItemForOk.Name = "ItemForOk";
            ItemForOk.Size = new Size(112, 26);
            ItemForOk.TextVisible = false;
            // 
            // ItemForCancel
            // 
            ItemForCancel.Control = btn_Cancel;
            ItemForCancel.Location = new Point(112, 178);
            ItemForCancel.Name = "ItemForCancel";
            ItemForCancel.Size = new Size(268, 26);
            ItemForCancel.TextVisible = false;
            // 
            // FormCurrAccContactDetail
            // 
            AcceptButton = btn_Ok;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btn_Cancel;
            ClientSize = new Size(400, 224);
            Controls.Add(layoutControl1);
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCurrAccContactDetail";
            StartPosition = FormStartPosition.CenterParent;
            Load += FormCurrAccContactDetail_Load;
            KeyDown += FormCurrAccContactDetail_KeyDown;
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ContactDescTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ContactTypeLookUpEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)SendWhatsappCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForContactType).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForContactDesc).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForSendWhatsapp).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForOk).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCancel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.ButtonEdit ContactDescTextEdit;
        private BindingSource bindingSource1;
        private DevExpress.XtraEditors.LookUpEdit ContactTypeLookUpEdit;
        private DevExpress.XtraEditors.CheckEdit SendWhatsappCheckEdit;

        private DevExpress.XtraEditors.SimpleButton btn_Ok;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem ItemForContactDesc;
        private DevExpress.XtraLayout.LayoutControlItem ItemForContactType;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSendWhatsapp;

        private DevExpress.XtraLayout.LayoutControlItem ItemForOk;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCancel;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
