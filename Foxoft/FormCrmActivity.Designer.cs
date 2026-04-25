using Foxoft.Models;
using System.ComponentModel;

namespace Foxoft
{
    partial class FormCrmActivity
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new Container();
            dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            btn_Ok = new DevExpress.XtraEditors.SimpleButton();
            ActivityCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            crmActivitiesBindingSource = new BindingSource(components);
            btnEdit_CurrAccCode = new DevExpress.XtraEditors.ButtonEdit();
            txtEdit_CurrAccDesc = new DevExpress.XtraEditors.TextEdit();
            SubjectTextEdit = new DevExpress.XtraEditors.TextEdit();
            ActivityTypeIdLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            StatusLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            PriorityLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            ActivityDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            StartTimeTimeEdit = new DevExpress.XtraEditors.TimeEdit();
            EndTimeTimeEdit = new DevExpress.XtraEditors.TimeEdit();
            btnEdit_AssignedCurrAccCode = new DevExpress.XtraEditors.ButtonEdit();
            txtEdit_AssignedCurrAccDesc = new DevExpress.XtraEditors.TextEdit();
            DescriptionMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            ResultMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            IsCompletedCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroupMain = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForActivityCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForCurrAccCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForCurrAccDesc = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForSubject = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForActivityTypeId = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForStatus = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForPriority = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForActivityDate = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForStartTime = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForEndTime = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForAssignedCurrAccCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForAssignedCurrAccDesc = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForResult = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForIsCompleted = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItemOk = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemCancel = new DevExpress.XtraLayout.LayoutControlItem();
            ((ISupportInitialize)dataLayoutControl1).BeginInit();
            dataLayoutControl1.SuspendLayout();
            ((ISupportInitialize)ActivityCodeTextEdit.Properties).BeginInit();
            ((ISupportInitialize)crmActivitiesBindingSource).BeginInit();
            ((ISupportInitialize)btnEdit_CurrAccCode.Properties).BeginInit();
            ((ISupportInitialize)txtEdit_CurrAccDesc.Properties).BeginInit();
            ((ISupportInitialize)SubjectTextEdit.Properties).BeginInit();
            ((ISupportInitialize)ActivityTypeIdLookUpEdit.Properties).BeginInit();
            ((ISupportInitialize)StatusLookUpEdit.Properties).BeginInit();
            ((ISupportInitialize)PriorityLookUpEdit.Properties).BeginInit();
            ((ISupportInitialize)ActivityDateDateEdit.Properties).BeginInit();
            ((ISupportInitialize)ActivityDateDateEdit.Properties.CalendarTimeProperties).BeginInit();
            ((ISupportInitialize)StartTimeTimeEdit.Properties).BeginInit();
            ((ISupportInitialize)EndTimeTimeEdit.Properties).BeginInit();
            ((ISupportInitialize)btnEdit_AssignedCurrAccCode.Properties).BeginInit();
            ((ISupportInitialize)txtEdit_AssignedCurrAccDesc.Properties).BeginInit();
            ((ISupportInitialize)DescriptionMemoEdit.Properties).BeginInit();
            ((ISupportInitialize)ResultMemoEdit.Properties).BeginInit();
            ((ISupportInitialize)IsCompletedCheckEdit.Properties).BeginInit();
            ((ISupportInitialize)Root).BeginInit();
            ((ISupportInitialize)layoutControlGroupMain).BeginInit();
            ((ISupportInitialize)ItemForActivityCode).BeginInit();
            ((ISupportInitialize)ItemForCurrAccCode).BeginInit();
            ((ISupportInitialize)ItemForCurrAccDesc).BeginInit();
            ((ISupportInitialize)ItemForSubject).BeginInit();
            ((ISupportInitialize)ItemForActivityTypeId).BeginInit();
            ((ISupportInitialize)ItemForStatus).BeginInit();
            ((ISupportInitialize)ItemForPriority).BeginInit();
            ((ISupportInitialize)ItemForActivityDate).BeginInit();
            ((ISupportInitialize)ItemForStartTime).BeginInit();
            ((ISupportInitialize)ItemForEndTime).BeginInit();
            ((ISupportInitialize)ItemForAssignedCurrAccCode).BeginInit();
            ((ISupportInitialize)ItemForAssignedCurrAccDesc).BeginInit();
            ((ISupportInitialize)ItemForDescription).BeginInit();
            ((ISupportInitialize)ItemForResult).BeginInit();
            ((ISupportInitialize)ItemForIsCompleted).BeginInit();
            ((ISupportInitialize)emptySpaceItem1).BeginInit();
            ((ISupportInitialize)layoutControlItemOk).BeginInit();
            ((ISupportInitialize)layoutControlItemCancel).BeginInit();
            SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            dataLayoutControl1.Controls.Add(btn_Cancel);
            dataLayoutControl1.Controls.Add(btn_Ok);
            dataLayoutControl1.Controls.Add(ActivityCodeTextEdit);
            dataLayoutControl1.Controls.Add(btnEdit_CurrAccCode);
            dataLayoutControl1.Controls.Add(txtEdit_CurrAccDesc);
            dataLayoutControl1.Controls.Add(SubjectTextEdit);
            dataLayoutControl1.Controls.Add(ActivityTypeIdLookUpEdit);
            dataLayoutControl1.Controls.Add(StatusLookUpEdit);
            dataLayoutControl1.Controls.Add(PriorityLookUpEdit);
            dataLayoutControl1.Controls.Add(ActivityDateDateEdit);
            dataLayoutControl1.Controls.Add(StartTimeTimeEdit);
            dataLayoutControl1.Controls.Add(EndTimeTimeEdit);
            dataLayoutControl1.Controls.Add(btnEdit_AssignedCurrAccCode);
            dataLayoutControl1.Controls.Add(txtEdit_AssignedCurrAccDesc);
            dataLayoutControl1.Controls.Add(DescriptionMemoEdit);
            dataLayoutControl1.Controls.Add(ResultMemoEdit);
            dataLayoutControl1.Controls.Add(IsCompletedCheckEdit);
            dataLayoutControl1.Dock = DockStyle.Fill;
            dataLayoutControl1.Location = new Point(0, 0);
            dataLayoutControl1.Name = "dataLayoutControl1";
            dataLayoutControl1.Root = Root;
            dataLayoutControl1.Size = new Size(820, 560);
            dataLayoutControl1.TabIndex = 0;
            dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // btn_Cancel
            // 
            btn_Cancel.Location = new Point(714, 526);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(94, 22);
            btn_Cancel.StyleController = dataLayoutControl1;
            btn_Cancel.TabIndex = 16;
            btn_Cancel.Text = "Ləğv et";
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // btn_Ok
            // 
            btn_Ok.Location = new Point(616, 526);
            btn_Ok.Name = "btn_Ok";
            btn_Ok.Size = new Size(94, 22);
            btn_Ok.StyleController = dataLayoutControl1;
            btn_Ok.TabIndex = 15;
            btn_Ok.Text = "Yadda saxla";
            btn_Ok.Click += btn_Ok_Click;
            // 
            // ActivityCodeTextEdit
            // 
            ActivityCodeTextEdit.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "ActivityCode", true));
            ActivityCodeTextEdit.Location = new Point(108, 12);
            ActivityCodeTextEdit.Name = "ActivityCodeTextEdit";
            ActivityCodeTextEdit.Size = new Size(290, 20);
            ActivityCodeTextEdit.StyleController = dataLayoutControl1;
            ActivityCodeTextEdit.TabIndex = 0;
            // 
            // crmActivitiesBindingSource
            // 
            crmActivitiesBindingSource.DataSource = typeof(Foxoft.Models.TrCrmActivity);
            // 
            // btnEdit_CurrAccCode
            // 
            btnEdit_CurrAccCode.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "CurrAccCode", true));
            btnEdit_CurrAccCode.Location = new Point(108, 36);
            btnEdit_CurrAccCode.Name = "btnEdit_CurrAccCode";
            btnEdit_CurrAccCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[]
            {
                new DevExpress.XtraEditors.Controls.EditorButton()
            });
            btnEdit_CurrAccCode.Size = new Size(290, 20);
            btnEdit_CurrAccCode.StyleController = dataLayoutControl1;
            btnEdit_CurrAccCode.TabIndex = 1;
            btnEdit_CurrAccCode.ButtonClick += btnEdit_CurrAccCode_ButtonClick;
            btnEdit_CurrAccCode.DoubleClick += btnEdit_CurrAccCode_DoubleClick;
            btnEdit_CurrAccCode.EditValueChanged += btnEdit_CurrAccCode_EditValueChanged;
            // 
            // txtEdit_CurrAccDesc
            // 
            txtEdit_CurrAccDesc.Location = new Point(512, 36);
            txtEdit_CurrAccDesc.Name = "txtEdit_CurrAccDesc";
            txtEdit_CurrAccDesc.Properties.ReadOnly = true;
            txtEdit_CurrAccDesc.Size = new Size(296, 20);
            txtEdit_CurrAccDesc.StyleController = dataLayoutControl1;
            txtEdit_CurrAccDesc.TabIndex = 2;
            // 
            // SubjectTextEdit
            // 
            SubjectTextEdit.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "Subject", true));
            SubjectTextEdit.Location = new Point(108, 60);
            SubjectTextEdit.Name = "SubjectTextEdit";
            SubjectTextEdit.Size = new Size(700, 20);
            SubjectTextEdit.StyleController = dataLayoutControl1;
            SubjectTextEdit.TabIndex = 3;
            // 
            // ActivityTypeIdLookUpEdit
            // 
            ActivityTypeIdLookUpEdit.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "ActivityTypeId", true));
            ActivityTypeIdLookUpEdit.Location = new Point(108, 84);
            ActivityTypeIdLookUpEdit.Name = "ActivityTypeIdLookUpEdit";
            ActivityTypeIdLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[]
            {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            ActivityTypeIdLookUpEdit.Size = new Size(290, 20);
            ActivityTypeIdLookUpEdit.StyleController = dataLayoutControl1;
            ActivityTypeIdLookUpEdit.TabIndex = 4;
            // 
            // StatusLookUpEdit
            // 
            StatusLookUpEdit.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "Status", true));
            StatusLookUpEdit.Location = new Point(512, 84);
            StatusLookUpEdit.Name = "StatusLookUpEdit";
            StatusLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[]
            {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            StatusLookUpEdit.Size = new Size(296, 20);
            StatusLookUpEdit.StyleController = dataLayoutControl1;
            StatusLookUpEdit.TabIndex = 5;
            // 
            // PriorityLookUpEdit
            // 
            PriorityLookUpEdit.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "Priority", true));
            PriorityLookUpEdit.Location = new Point(108, 108);
            PriorityLookUpEdit.Name = "PriorityLookUpEdit";
            PriorityLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[]
            {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            PriorityLookUpEdit.Size = new Size(290, 20);
            PriorityLookUpEdit.StyleController = dataLayoutControl1;
            PriorityLookUpEdit.TabIndex = 6;
            // 
            // ActivityDateDateEdit
            // 
            ActivityDateDateEdit.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "ActivityDate", true));
            ActivityDateDateEdit.EditValue = null;
            ActivityDateDateEdit.Location = new Point(512, 108);
            ActivityDateDateEdit.Name = "ActivityDateDateEdit";
            ActivityDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[]
            {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            ActivityDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[]
            {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            ActivityDateDateEdit.Size = new Size(296, 20);
            ActivityDateDateEdit.StyleController = dataLayoutControl1;
            ActivityDateDateEdit.TabIndex = 7;
            // 
            // StartTimeTimeEdit
            // 
            StartTimeTimeEdit.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "StartTime", true));
            StartTimeTimeEdit.Location = new Point(108, 132);
            StartTimeTimeEdit.Name = "StartTimeTimeEdit";
            StartTimeTimeEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[]
            {
                new DevExpress.XtraEditors.Controls.EditorButton()
            });
            StartTimeTimeEdit.Size = new Size(290, 20);
            StartTimeTimeEdit.StyleController = dataLayoutControl1;
            StartTimeTimeEdit.TabIndex = 8;
            // 
            // EndTimeTimeEdit
            // 
            EndTimeTimeEdit.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "EndTime", true));
            EndTimeTimeEdit.Location = new Point(512, 132);
            EndTimeTimeEdit.Name = "EndTimeTimeEdit";
            EndTimeTimeEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[]
            {
                new DevExpress.XtraEditors.Controls.EditorButton()
            });
            EndTimeTimeEdit.Size = new Size(296, 20);
            EndTimeTimeEdit.StyleController = dataLayoutControl1;
            EndTimeTimeEdit.TabIndex = 9;
            // 
            // btnEdit_AssignedCurrAccCode
            // 
            btnEdit_AssignedCurrAccCode.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "AssignedCurrAccCode", true));
            btnEdit_AssignedCurrAccCode.Location = new Point(108, 156);
            btnEdit_AssignedCurrAccCode.Name = "btnEdit_AssignedCurrAccCode";
            btnEdit_AssignedCurrAccCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[]
            {
                new DevExpress.XtraEditors.Controls.EditorButton()
            });
            btnEdit_AssignedCurrAccCode.Size = new Size(290, 20);
            btnEdit_AssignedCurrAccCode.StyleController = dataLayoutControl1;
            btnEdit_AssignedCurrAccCode.TabIndex = 10;
            btnEdit_AssignedCurrAccCode.ButtonClick += btnEdit_AssignedCurrAccCode_ButtonClick;
            btnEdit_AssignedCurrAccCode.DoubleClick += btnEdit_AssignedCurrAccCode_DoubleClick;
            btnEdit_AssignedCurrAccCode.EditValueChanged += btnEdit_AssignedCurrAccCode_EditValueChanged;
            // 
            // txtEdit_AssignedCurrAccDesc
            // 
            txtEdit_AssignedCurrAccDesc.Location = new Point(512, 156);
            txtEdit_AssignedCurrAccDesc.Name = "txtEdit_AssignedCurrAccDesc";
            txtEdit_AssignedCurrAccDesc.Properties.ReadOnly = true;
            txtEdit_AssignedCurrAccDesc.Size = new Size(296, 20);
            txtEdit_AssignedCurrAccDesc.StyleController = dataLayoutControl1;
            txtEdit_AssignedCurrAccDesc.TabIndex = 11;
            // 
            // DescriptionMemoEdit
            // 
            DescriptionMemoEdit.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "Description", true));
            DescriptionMemoEdit.Location = new Point(108, 180);
            DescriptionMemoEdit.Name = "DescriptionMemoEdit";
            DescriptionMemoEdit.Size = new Size(700, 151);
            DescriptionMemoEdit.StyleController = dataLayoutControl1;
            DescriptionMemoEdit.TabIndex = 12;
            // 
            // ResultMemoEdit
            // 
            ResultMemoEdit.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "Result", true));
            ResultMemoEdit.Location = new Point(108, 335);
            ResultMemoEdit.Name = "ResultMemoEdit";
            ResultMemoEdit.Size = new Size(700, 151);
            ResultMemoEdit.StyleController = dataLayoutControl1;
            ResultMemoEdit.TabIndex = 13;
            // 
            // IsCompletedCheckEdit
            // 
            IsCompletedCheckEdit.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "IsCompleted", true));
            IsCompletedCheckEdit.Location = new Point(108, 490);
            IsCompletedCheckEdit.Name = "IsCompletedCheckEdit";
            IsCompletedCheckEdit.Properties.Caption = "";
            IsCompletedCheckEdit.Size = new Size(700, 20);
            IsCompletedCheckEdit.StyleController = dataLayoutControl1;
            IsCompletedCheckEdit.TabIndex = 14;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[]
            {
                layoutControlGroupMain,
                emptySpaceItem1,
                layoutControlItemOk,
                layoutControlItemCancel
            });
            Root.Name = "Root";
            Root.Size = new Size(820, 560);
            Root.TextVisible = false;
            // 
            // layoutControlGroupMain
            // 
            layoutControlGroupMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[]
            {
                ItemForActivityCode,
                ItemForCurrAccCode,
                ItemForCurrAccDesc,
                ItemForSubject,
                ItemForActivityTypeId,
                ItemForStatus,
                ItemForPriority,
                ItemForActivityDate,
                ItemForStartTime,
                ItemForEndTime,
                ItemForAssignedCurrAccCode,
                ItemForAssignedCurrAccDesc,
                ItemForDescription,
                ItemForResult,
                ItemForIsCompleted
            });
            layoutControlGroupMain.Location = new Point(0, 0);
            layoutControlGroupMain.Name = "layoutControlGroupMain";
            layoutControlGroupMain.Size = new Size(800, 514);
            layoutControlGroupMain.Text = "CRM Aktivliyi";
            // 
            // item placements
            // 
            ItemForActivityCode.Control = ActivityCodeTextEdit;
            ItemForActivityCode.Location = new Point(0, 0);
            ItemForActivityCode.Name = "ItemForActivityCode";
            ItemForActivityCode.Size = new Size(390, 24);
            ItemForActivityCode.Text = "Aktivlik Kodu";
            ItemForActivityCode.TextSize = new Size(84, 13);

            ItemForCurrAccCode.Control = btnEdit_CurrAccCode;
            ItemForCurrAccCode.Location = new Point(0, 24);
            ItemForCurrAccCode.Name = "ItemForCurrAccCode";
            ItemForCurrAccCode.Size = new Size(390, 24);
            ItemForCurrAccCode.Text = "Cari Kod";
            ItemForCurrAccCode.TextSize = new Size(84, 13);

            ItemForCurrAccDesc.Control = txtEdit_CurrAccDesc;
            ItemForCurrAccDesc.Location = new Point(390, 24);
            ItemForCurrAccDesc.Name = "ItemForCurrAccDesc";
            ItemForCurrAccDesc.Size = new Size(390, 24);
            ItemForCurrAccDesc.Text = "Cari Adı";
            ItemForCurrAccDesc.TextSize = new Size(84, 13);

            ItemForSubject.Control = SubjectTextEdit;
            ItemForSubject.Location = new Point(0, 48);
            ItemForSubject.Name = "ItemForSubject";
            ItemForSubject.Size = new Size(780, 24);
            ItemForSubject.Text = "Mövzu";
            ItemForSubject.TextSize = new Size(84, 13);

            ItemForActivityTypeId.Control = ActivityTypeIdLookUpEdit;
            ItemForActivityTypeId.Location = new Point(0, 72);
            ItemForActivityTypeId.Name = "ItemForActivityTypeId";
            ItemForActivityTypeId.Size = new Size(390, 24);
            ItemForActivityTypeId.Text = "Aktivlik Növü";
            ItemForActivityTypeId.TextSize = new Size(84, 13);

            ItemForStatus.Control = StatusLookUpEdit;
            ItemForStatus.Location = new Point(390, 72);
            ItemForStatus.Name = "ItemForStatus";
            ItemForStatus.Size = new Size(390, 24);
            ItemForStatus.Text = "Status";
            ItemForStatus.TextSize = new Size(84, 13);

            ItemForPriority.Control = PriorityLookUpEdit;
            ItemForPriority.Location = new Point(0, 96);
            ItemForPriority.Name = "ItemForPriority";
            ItemForPriority.Size = new Size(390, 24);
            ItemForPriority.Text = "Prioritet";
            ItemForPriority.TextSize = new Size(84, 13);

            ItemForActivityDate.Control = ActivityDateDateEdit;
            ItemForActivityDate.Location = new Point(390, 96);
            ItemForActivityDate.Name = "ItemForActivityDate";
            ItemForActivityDate.Size = new Size(390, 24);
            ItemForActivityDate.Text = "Tarix";
            ItemForActivityDate.TextSize = new Size(84, 13);

            ItemForStartTime.Control = StartTimeTimeEdit;
            ItemForStartTime.Location = new Point(0, 120);
            ItemForStartTime.Name = "ItemForStartTime";
            ItemForStartTime.Size = new Size(390, 24);
            ItemForStartTime.Text = "Başlama Saatı";
            ItemForStartTime.TextSize = new Size(84, 13);

            ItemForEndTime.Control = EndTimeTimeEdit;
            ItemForEndTime.Location = new Point(390, 120);
            ItemForEndTime.Name = "ItemForEndTime";
            ItemForEndTime.Size = new Size(390, 24);
            ItemForEndTime.Text = "Bitmə Saatı";
            ItemForEndTime.TextSize = new Size(84, 13);

            ItemForAssignedCurrAccCode.Control = btnEdit_AssignedCurrAccCode;
            ItemForAssignedCurrAccCode.Location = new Point(0, 144);
            ItemForAssignedCurrAccCode.Name = "ItemForAssignedCurrAccCode";
            ItemForAssignedCurrAccCode.Size = new Size(390, 24);
            ItemForAssignedCurrAccCode.Text = "Təyin edilən";
            ItemForAssignedCurrAccCode.TextSize = new Size(84, 13);

            ItemForAssignedCurrAccDesc.Control = txtEdit_AssignedCurrAccDesc;
            ItemForAssignedCurrAccDesc.Location = new Point(390, 144);
            ItemForAssignedCurrAccDesc.Name = "ItemForAssignedCurrAccDesc";
            ItemForAssignedCurrAccDesc.Size = new Size(390, 24);
            ItemForAssignedCurrAccDesc.Text = "Personal Adı";
            ItemForAssignedCurrAccDesc.TextSize = new Size(84, 13);

            ItemForDescription.Control = DescriptionMemoEdit;
            ItemForDescription.Location = new Point(0, 168);
            ItemForDescription.Name = "ItemForDescription";
            ItemForDescription.Size = new Size(780, 155);
            ItemForDescription.Text = "Açıqlama";
            ItemForDescription.TextSize = new Size(84, 13);

            ItemForResult.Control = ResultMemoEdit;
            ItemForResult.Location = new Point(0, 323);
            ItemForResult.Name = "ItemForResult";
            ItemForResult.Size = new Size(780, 155);
            ItemForResult.Text = "Nəticə";
            ItemForResult.TextSize = new Size(84, 13);

            ItemForIsCompleted.Control = IsCompletedCheckEdit;
            ItemForIsCompleted.Location = new Point(0, 478);
            ItemForIsCompleted.Name = "ItemForIsCompleted";
            ItemForIsCompleted.Size = new Size(780, 24);
            ItemForIsCompleted.Text = "Tamamlanıb";
            ItemForIsCompleted.TextSize = new Size(84, 13);

            emptySpaceItem1.Location = new Point(0, 514);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(604, 26);

            layoutControlItemOk.Control = btn_Ok;
            layoutControlItemOk.Location = new Point(604, 514);
            layoutControlItemOk.MaxSize = new Size(98, 26);
            layoutControlItemOk.MinSize = new Size(98, 26);
            layoutControlItemOk.Name = "layoutControlItemOk";
            layoutControlItemOk.Size = new Size(98, 26);
            layoutControlItemOk.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItemOk.TextSize = new Size(0, 0);
            layoutControlItemOk.TextVisible = false;

            layoutControlItemCancel.Control = btn_Cancel;
            layoutControlItemCancel.Location = new Point(702, 514);
            layoutControlItemCancel.MaxSize = new Size(98, 26);
            layoutControlItemCancel.MinSize = new Size(98, 26);
            layoutControlItemCancel.Name = "layoutControlItemCancel";
            layoutControlItemCancel.Size = new Size(98, 26);
            layoutControlItemCancel.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItemCancel.TextSize = new Size(0, 0);
            layoutControlItemCancel.TextVisible = false;
            // 
            // FormCrmActivity
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 560);
            Controls.Add(dataLayoutControl1);
            Name = "FormCrmActivity";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM Aktivliyi";
            Load += FormCrmActivity_Load;
            ((ISupportInitialize)dataLayoutControl1).EndInit();
            dataLayoutControl1.ResumeLayout(false);
            ((ISupportInitialize)ActivityCodeTextEdit.Properties).EndInit();
            ((ISupportInitialize)crmActivitiesBindingSource).EndInit();
            ((ISupportInitialize)btnEdit_CurrAccCode.Properties).EndInit();
            ((ISupportInitialize)txtEdit_CurrAccDesc.Properties).EndInit();
            ((ISupportInitialize)SubjectTextEdit.Properties).EndInit();
            ((ISupportInitialize)ActivityTypeIdLookUpEdit.Properties).EndInit();
            ((ISupportInitialize)StatusLookUpEdit.Properties).EndInit();
            ((ISupportInitialize)PriorityLookUpEdit.Properties).EndInit();
            ((ISupportInitialize)ActivityDateDateEdit.Properties.CalendarTimeProperties).EndInit();
            ((ISupportInitialize)ActivityDateDateEdit.Properties).EndInit();
            ((ISupportInitialize)StartTimeTimeEdit.Properties).EndInit();
            ((ISupportInitialize)EndTimeTimeEdit.Properties).EndInit();
            ((ISupportInitialize)btnEdit_AssignedCurrAccCode.Properties).EndInit();
            ((ISupportInitialize)txtEdit_AssignedCurrAccDesc.Properties).EndInit();
            ((ISupportInitialize)DescriptionMemoEdit.Properties).EndInit();
            ((ISupportInitialize)ResultMemoEdit.Properties).EndInit();
            ((ISupportInitialize)IsCompletedCheckEdit.Properties).EndInit();
            ((ISupportInitialize)Root).EndInit();
            ((ISupportInitialize)layoutControlGroupMain).EndInit();
            ((ISupportInitialize)ItemForActivityCode).EndInit();
            ((ISupportInitialize)ItemForCurrAccCode).EndInit();
            ((ISupportInitialize)ItemForCurrAccDesc).EndInit();
            ((ISupportInitialize)ItemForSubject).EndInit();
            ((ISupportInitialize)ItemForActivityTypeId).EndInit();
            ((ISupportInitialize)ItemForStatus).EndInit();
            ((ISupportInitialize)ItemForPriority).EndInit();
            ((ISupportInitialize)ItemForActivityDate).EndInit();
            ((ISupportInitialize)ItemForStartTime).EndInit();
            ((ISupportInitialize)ItemForEndTime).EndInit();
            ((ISupportInitialize)ItemForAssignedCurrAccCode).EndInit();
            ((ISupportInitialize)ItemForAssignedCurrAccDesc).EndInit();
            ((ISupportInitialize)ItemForDescription).EndInit();
            ((ISupportInitialize)ItemForResult).EndInit();
            ((ISupportInitialize)ItemForIsCompleted).EndInit();
            ((ISupportInitialize)emptySpaceItem1).EndInit();
            ((ISupportInitialize)layoutControlItemOk).EndInit();
            ((ISupportInitialize)layoutControlItemCancel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private BindingSource crmActivitiesBindingSource;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraEditors.SimpleButton btn_Ok;
        private DevExpress.XtraEditors.TextEdit ActivityCodeTextEdit;
        private DevExpress.XtraEditors.ButtonEdit btnEdit_CurrAccCode;
        private DevExpress.XtraEditors.TextEdit txtEdit_CurrAccDesc;
        private DevExpress.XtraEditors.TextEdit SubjectTextEdit;
        private DevExpress.XtraEditors.LookUpEdit ActivityTypeIdLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit StatusLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit PriorityLookUpEdit;
        private DevExpress.XtraEditors.DateEdit ActivityDateDateEdit;
        private DevExpress.XtraEditors.TimeEdit StartTimeTimeEdit;
        private DevExpress.XtraEditors.TimeEdit EndTimeTimeEdit;
        private DevExpress.XtraEditors.ButtonEdit btnEdit_AssignedCurrAccCode;
        private DevExpress.XtraEditors.TextEdit txtEdit_AssignedCurrAccDesc;
        private DevExpress.XtraEditors.MemoEdit DescriptionMemoEdit;
        private DevExpress.XtraEditors.MemoEdit ResultMemoEdit;
        private DevExpress.XtraEditors.CheckEdit IsCompletedCheckEdit;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupMain;
        private DevExpress.XtraLayout.LayoutControlItem ItemForActivityCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCurrAccCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCurrAccDesc;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSubject;
        private DevExpress.XtraLayout.LayoutControlItem ItemForActivityTypeId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStatus;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPriority;
        private DevExpress.XtraLayout.LayoutControlItem ItemForActivityDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStartTime;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEndTime;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAssignedCurrAccCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAssignedCurrAccDesc;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescription;
        private DevExpress.XtraLayout.LayoutControlItem ItemForResult;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIsCompleted;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemOk;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemCancel;
    }
}
