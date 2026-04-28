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
            NextPlanDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroupMain = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForActivityCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForCurrAccDesc = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForSubject = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForActivityTypeId = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForPriority = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForActivityDate = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForResult = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForIsCompleted = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForCurrAccCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForStatus = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForStartTime = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForEndTime = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForNextPlanDate = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForAssignedCurrAccCode = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForAssignedCurrAccDesc = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItemOk = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemCancel = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
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
            ((ISupportInitialize)NextPlanDateDateEdit.Properties).BeginInit();
            ((ISupportInitialize)NextPlanDateDateEdit.Properties.CalendarTimeProperties).BeginInit();
            ((ISupportInitialize)Root).BeginInit();
            ((ISupportInitialize)layoutControlGroupMain).BeginInit();
            ((ISupportInitialize)ItemForActivityCode).BeginInit();
            ((ISupportInitialize)ItemForCurrAccDesc).BeginInit();
            ((ISupportInitialize)ItemForSubject).BeginInit();
            ((ISupportInitialize)ItemForActivityTypeId).BeginInit();
            ((ISupportInitialize)ItemForPriority).BeginInit();
            ((ISupportInitialize)ItemForActivityDate).BeginInit();
            ((ISupportInitialize)ItemForDescription).BeginInit();
            ((ISupportInitialize)ItemForResult).BeginInit();
            ((ISupportInitialize)ItemForIsCompleted).BeginInit();
            ((ISupportInitialize)ItemForCurrAccCode).BeginInit();
            ((ISupportInitialize)ItemForStatus).BeginInit();
            ((ISupportInitialize)ItemForStartTime).BeginInit();
            ((ISupportInitialize)ItemForEndTime).BeginInit();
            ((ISupportInitialize)ItemForNextPlanDate).BeginInit();
            ((ISupportInitialize)ItemForAssignedCurrAccCode).BeginInit();
            ((ISupportInitialize)ItemForAssignedCurrAccDesc).BeginInit();
            ((ISupportInitialize)emptySpaceItem1).BeginInit();
            ((ISupportInitialize)layoutControlItemOk).BeginInit();
            ((ISupportInitialize)layoutControlItemCancel).BeginInit();
            ((ISupportInitialize)layoutControlGroup1).BeginInit();
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
            dataLayoutControl1.Controls.Add(NextPlanDateDateEdit);
            dataLayoutControl1.DataSource = crmActivitiesBindingSource;
            dataLayoutControl1.Dock = DockStyle.Fill;
            dataLayoutControl1.Location = new Point(0, 0);
            dataLayoutControl1.Name = "dataLayoutControl1";
            dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(799, 244, 650, 400);
            dataLayoutControl1.Root = Root;
            dataLayoutControl1.Size = new Size(820, 560);
            dataLayoutControl1.TabIndex = 0;
            dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // btn_Cancel
            // 
            btn_Cancel.Location = new Point(714, 502);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(94, 22);
            btn_Cancel.StyleController = dataLayoutControl1;
            btn_Cancel.TabIndex = 18;
            btn_Cancel.Text = "Ləğv et";
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // btn_Ok
            // 
            btn_Ok.Location = new Point(616, 502);
            btn_Ok.Name = "btn_Ok";
            btn_Ok.Size = new Size(94, 22);
            btn_Ok.StyleController = dataLayoutControl1;
            btn_Ok.TabIndex = 17;
            btn_Ok.Text = "Yadda saxla";
            btn_Ok.Click += btn_Ok_Click;
            // 
            // ActivityCodeTextEdit
            // 
            ActivityCodeTextEdit.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "ActivityCode", true));
            ActivityCodeTextEdit.Location = new Point(125, 45);
            ActivityCodeTextEdit.Name = "ActivityCodeTextEdit";
            ActivityCodeTextEdit.Size = new Size(283, 20);
            ActivityCodeTextEdit.StyleController = dataLayoutControl1;
            ActivityCodeTextEdit.TabIndex = 0;
            // 
            // crmActivitiesBindingSource
            // 
            crmActivitiesBindingSource.DataSource = typeof(TrCrmActivity);
            // 
            // btnEdit_CurrAccCode
            // 
            btnEdit_CurrAccCode.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "CurrAccCode", true));
            btnEdit_CurrAccCode.Location = new Point(513, 45);
            btnEdit_CurrAccCode.Name = "btnEdit_CurrAccCode";
            btnEdit_CurrAccCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            btnEdit_CurrAccCode.Size = new Size(89, 20);
            btnEdit_CurrAccCode.StyleController = dataLayoutControl1;
            btnEdit_CurrAccCode.TabIndex = 2;
            btnEdit_CurrAccCode.ButtonClick += btnEdit_CurrAccCode_ButtonClick;
            btnEdit_CurrAccCode.EditValueChanged += btnEdit_CurrAccCode_EditValueChanged;
            btnEdit_CurrAccCode.DoubleClick += btnEdit_CurrAccCode_DoubleClick;
            // 
            // txtEdit_CurrAccDesc
            // 
            txtEdit_CurrAccDesc.Location = new Point(606, 45);
            txtEdit_CurrAccDesc.Name = "txtEdit_CurrAccDesc";
            txtEdit_CurrAccDesc.Properties.ReadOnly = true;
            txtEdit_CurrAccDesc.Size = new Size(190, 20);
            txtEdit_CurrAccDesc.StyleController = dataLayoutControl1;
            txtEdit_CurrAccDesc.TabIndex = 3;
            // 
            // SubjectTextEdit
            // 
            SubjectTextEdit.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "Subject", true));
            SubjectTextEdit.Location = new Point(125, 69);
            SubjectTextEdit.Name = "SubjectTextEdit";
            SubjectTextEdit.Size = new Size(283, 20);
            SubjectTextEdit.StyleController = dataLayoutControl1;
            SubjectTextEdit.TabIndex = 4;
            // 
            // ActivityTypeIdLookUpEdit
            // 
            ActivityTypeIdLookUpEdit.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "ActivityTypeId", true));
            ActivityTypeIdLookUpEdit.Location = new Point(125, 93);
            ActivityTypeIdLookUpEdit.Name = "ActivityTypeIdLookUpEdit";
            ActivityTypeIdLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            ActivityTypeIdLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ActivityTypeId", ""), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ActivityTypeDesc", "") });
            ActivityTypeIdLookUpEdit.Size = new Size(283, 20);
            ActivityTypeIdLookUpEdit.StyleController = dataLayoutControl1;
            ActivityTypeIdLookUpEdit.TabIndex = 6;
            // 
            // StatusLookUpEdit
            // 
            StatusLookUpEdit.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "Status", true));
            StatusLookUpEdit.Location = new Point(125, 141);
            StatusLookUpEdit.Name = "StatusLookUpEdit";
            StatusLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            StatusLookUpEdit.Size = new Size(283, 20);
            StatusLookUpEdit.StyleController = dataLayoutControl1;
            StatusLookUpEdit.TabIndex = 7;
            // 
            // PriorityLookUpEdit
            // 
            PriorityLookUpEdit.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "Priority", true));
            PriorityLookUpEdit.Location = new Point(125, 117);
            PriorityLookUpEdit.Name = "PriorityLookUpEdit";
            PriorityLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            PriorityLookUpEdit.Size = new Size(283, 20);
            PriorityLookUpEdit.StyleController = dataLayoutControl1;
            PriorityLookUpEdit.TabIndex = 8;
            // 
            // ActivityDateDateEdit
            // 
            ActivityDateDateEdit.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "ActivityDate", true));
            ActivityDateDateEdit.EditValue = null;
            ActivityDateDateEdit.Location = new Point(513, 69);
            ActivityDateDateEdit.Name = "ActivityDateDateEdit";
            ActivityDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            ActivityDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            ActivityDateDateEdit.Size = new Size(283, 20);
            ActivityDateDateEdit.StyleController = dataLayoutControl1;
            ActivityDateDateEdit.TabIndex = 9;
            // 
            // StartTimeTimeEdit
            // 
            StartTimeTimeEdit.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "StartTime", true));
            StartTimeTimeEdit.EditValue = new DateTime(2026, 4, 26, 0, 0, 0, 0);
            StartTimeTimeEdit.Location = new Point(513, 93);
            StartTimeTimeEdit.Name = "StartTimeTimeEdit";
            StartTimeTimeEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            StartTimeTimeEdit.Properties.DisplayFormat.FormatString = "HH:mm:ss";
            StartTimeTimeEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            StartTimeTimeEdit.Properties.EditFormat.FormatString = "HH:mm:ss";
            StartTimeTimeEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            StartTimeTimeEdit.Properties.Mask.EditMask = "HH:mm:ss";
            StartTimeTimeEdit.Size = new Size(89, 20);
            StartTimeTimeEdit.StyleController = dataLayoutControl1;
            StartTimeTimeEdit.TabIndex = 10;
            // 
            // EndTimeTimeEdit
            // 
            EndTimeTimeEdit.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "EndTime", true));
            EndTimeTimeEdit.EditValue = new DateTime(2026, 4, 26, 0, 0, 0, 0);
            EndTimeTimeEdit.Location = new Point(707, 93);
            EndTimeTimeEdit.Name = "EndTimeTimeEdit";
            EndTimeTimeEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            EndTimeTimeEdit.Properties.DisplayFormat.FormatString = "HH:mm:ss";
            EndTimeTimeEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            EndTimeTimeEdit.Properties.EditFormat.FormatString = "HH:mm:ss";
            EndTimeTimeEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            EndTimeTimeEdit.Properties.Mask.EditMask = "HH:mm:ss";
            EndTimeTimeEdit.Size = new Size(89, 20);
            EndTimeTimeEdit.StyleController = dataLayoutControl1;
            EndTimeTimeEdit.TabIndex = 11;
            // 
            // btnEdit_AssignedCurrAccCode
            // 
            btnEdit_AssignedCurrAccCode.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "AssignedCurrAccCode", true));
            btnEdit_AssignedCurrAccCode.Location = new Point(513, 141);
            btnEdit_AssignedCurrAccCode.Name = "btnEdit_AssignedCurrAccCode";
            btnEdit_AssignedCurrAccCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            btnEdit_AssignedCurrAccCode.Size = new Size(89, 20);
            btnEdit_AssignedCurrAccCode.StyleController = dataLayoutControl1;
            btnEdit_AssignedCurrAccCode.TabIndex = 12;
            btnEdit_AssignedCurrAccCode.ButtonClick += btnEdit_AssignedCurrAccCode_ButtonClick;
            btnEdit_AssignedCurrAccCode.EditValueChanged += btnEdit_AssignedCurrAccCode_EditValueChanged;
            btnEdit_AssignedCurrAccCode.DoubleClick += btnEdit_AssignedCurrAccCode_DoubleClick;
            // 
            // txtEdit_AssignedCurrAccDesc
            // 
            txtEdit_AssignedCurrAccDesc.Location = new Point(606, 141);
            txtEdit_AssignedCurrAccDesc.Name = "txtEdit_AssignedCurrAccDesc";
            txtEdit_AssignedCurrAccDesc.Properties.ReadOnly = true;
            txtEdit_AssignedCurrAccDesc.Size = new Size(190, 20);
            txtEdit_AssignedCurrAccDesc.StyleController = dataLayoutControl1;
            txtEdit_AssignedCurrAccDesc.TabIndex = 13;
            // 
            // DescriptionMemoEdit
            // 
            DescriptionMemoEdit.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "Description", true));
            DescriptionMemoEdit.Location = new Point(125, 165);
            DescriptionMemoEdit.Name = "DescriptionMemoEdit";
            DescriptionMemoEdit.Size = new Size(671, 161);
            DescriptionMemoEdit.StyleController = dataLayoutControl1;
            DescriptionMemoEdit.TabIndex = 14;
            // 
            // ResultMemoEdit
            // 
            ResultMemoEdit.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "Result", true));
            ResultMemoEdit.Location = new Point(125, 330);
            ResultMemoEdit.Name = "ResultMemoEdit";
            ResultMemoEdit.Size = new Size(671, 132);
            ResultMemoEdit.StyleController = dataLayoutControl1;
            ResultMemoEdit.TabIndex = 15;
            // 
            // IsCompletedCheckEdit
            // 
            IsCompletedCheckEdit.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "IsCompleted", true));
            IsCompletedCheckEdit.Location = new Point(125, 466);
            IsCompletedCheckEdit.Name = "IsCompletedCheckEdit";
            IsCompletedCheckEdit.Properties.Caption = "";
            IsCompletedCheckEdit.Size = new Size(671, 20);
            IsCompletedCheckEdit.StyleController = dataLayoutControl1;
            IsCompletedCheckEdit.TabIndex = 16;
            // 
            // NextPlanDateDateEdit
            // 
            NextPlanDateDateEdit.DataBindings.Add(new Binding("EditValue", crmActivitiesBindingSource, "NextPlanDate", true));
            NextPlanDateDateEdit.EditValue = null;
            NextPlanDateDateEdit.Location = new Point(513, 117);
            NextPlanDateDateEdit.Name = "NextPlanDateDateEdit";
            NextPlanDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            NextPlanDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            NextPlanDateDateEdit.Size = new Size(283, 20);
            NextPlanDateDateEdit.StyleController = dataLayoutControl1;
            NextPlanDateDateEdit.TabIndex = 5;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlGroupMain, emptySpaceItem1, layoutControlItemOk, layoutControlItemCancel, layoutControlGroup1 });
            Root.Name = "Root";
            Root.Size = new Size(820, 560);
            Root.TextVisible = false;
            // 
            // layoutControlGroupMain
            // 
            layoutControlGroupMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForActivityCode, ItemForCurrAccDesc, ItemForSubject, ItemForActivityTypeId, ItemForPriority, ItemForActivityDate, ItemForDescription, ItemForResult, ItemForIsCompleted, ItemForCurrAccCode, ItemForStatus, ItemForStartTime, ItemForEndTime, ItemForNextPlanDate, ItemForAssignedCurrAccCode, ItemForAssignedCurrAccDesc });
            layoutControlGroupMain.Location = new Point(0, 0);
            layoutControlGroupMain.Name = "layoutControlGroupMain";
            layoutControlGroupMain.Size = new Size(800, 490);
            layoutControlGroupMain.Text = "CRM Aktivliyi";
            // 
            // ItemForActivityCode
            // 
            ItemForActivityCode.Control = ActivityCodeTextEdit;
            ItemForActivityCode.Location = new Point(0, 0);
            ItemForActivityCode.Name = "ItemForActivityCode";
            ItemForActivityCode.Size = new Size(388, 24);
            ItemForActivityCode.Text = "Aktivlik Kodu";
            ItemForActivityCode.TextSize = new Size(89, 13);
            // 
            // ItemForCurrAccDesc
            // 
            ItemForCurrAccDesc.Control = txtEdit_CurrAccDesc;
            ItemForCurrAccDesc.Location = new Point(582, 0);
            ItemForCurrAccDesc.Name = "ItemForCurrAccDesc";
            ItemForCurrAccDesc.Size = new Size(194, 24);
            ItemForCurrAccDesc.Text = "Cari Adı";
            ItemForCurrAccDesc.TextVisible = false;
            // 
            // ItemForSubject
            // 
            ItemForSubject.Control = SubjectTextEdit;
            ItemForSubject.Location = new Point(0, 24);
            ItemForSubject.Name = "ItemForSubject";
            ItemForSubject.Size = new Size(388, 24);
            ItemForSubject.Text = "Mövzu";
            ItemForSubject.TextSize = new Size(89, 13);
            // 
            // ItemForActivityTypeId
            // 
            ItemForActivityTypeId.Control = ActivityTypeIdLookUpEdit;
            ItemForActivityTypeId.Location = new Point(0, 48);
            ItemForActivityTypeId.Name = "ItemForActivityTypeId";
            ItemForActivityTypeId.Size = new Size(388, 24);
            ItemForActivityTypeId.Text = "Aktivlik Növü";
            ItemForActivityTypeId.TextSize = new Size(89, 13);
            // 
            // ItemForPriority
            // 
            ItemForPriority.Control = PriorityLookUpEdit;
            ItemForPriority.Location = new Point(0, 72);
            ItemForPriority.Name = "ItemForPriority";
            ItemForPriority.Size = new Size(388, 24);
            ItemForPriority.Text = "Prioritet";
            ItemForPriority.TextSize = new Size(89, 13);
            // 
            // ItemForActivityDate
            // 
            ItemForActivityDate.Control = ActivityDateDateEdit;
            ItemForActivityDate.Location = new Point(388, 24);
            ItemForActivityDate.Name = "ItemForActivityDate";
            ItemForActivityDate.Size = new Size(388, 24);
            ItemForActivityDate.Text = "Tarix";
            ItemForActivityDate.TextSize = new Size(89, 13);
            // 
            // ItemForDescription
            // 
            ItemForDescription.Control = DescriptionMemoEdit;
            ItemForDescription.Location = new Point(0, 120);
            ItemForDescription.Name = "ItemForDescription";
            ItemForDescription.Size = new Size(776, 165);
            ItemForDescription.Text = "Açıqlama";
            ItemForDescription.TextSize = new Size(89, 13);
            // 
            // ItemForResult
            // 
            ItemForResult.Control = ResultMemoEdit;
            ItemForResult.Location = new Point(0, 285);
            ItemForResult.Name = "ItemForResult";
            ItemForResult.Size = new Size(776, 136);
            ItemForResult.Text = "Nəticə";
            ItemForResult.TextSize = new Size(89, 13);
            // 
            // ItemForIsCompleted
            // 
            ItemForIsCompleted.Control = IsCompletedCheckEdit;
            ItemForIsCompleted.Location = new Point(0, 421);
            ItemForIsCompleted.Name = "ItemForIsCompleted";
            ItemForIsCompleted.Size = new Size(776, 24);
            ItemForIsCompleted.Text = "Tamamlanıb";
            ItemForIsCompleted.TextSize = new Size(89, 13);
            // 
            // ItemForCurrAccCode
            // 
            ItemForCurrAccCode.Control = btnEdit_CurrAccCode;
            ItemForCurrAccCode.Location = new Point(388, 0);
            ItemForCurrAccCode.Name = "ItemForCurrAccCode";
            ItemForCurrAccCode.Size = new Size(194, 24);
            ItemForCurrAccCode.Text = "Cari Kod";
            ItemForCurrAccCode.TextSize = new Size(89, 13);
            // 
            // ItemForStatus
            // 
            ItemForStatus.Control = StatusLookUpEdit;
            ItemForStatus.Location = new Point(0, 96);
            ItemForStatus.Name = "ItemForStatus";
            ItemForStatus.Size = new Size(388, 24);
            ItemForStatus.Text = "Status";
            ItemForStatus.TextSize = new Size(89, 13);
            // 
            // ItemForStartTime
            // 
            ItemForStartTime.Control = StartTimeTimeEdit;
            ItemForStartTime.Location = new Point(388, 48);
            ItemForStartTime.Name = "ItemForStartTime";
            ItemForStartTime.Size = new Size(194, 24);
            ItemForStartTime.Text = "Başlama Saatı";
            ItemForStartTime.TextSize = new Size(89, 13);
            // 
            // ItemForEndTime
            // 
            ItemForEndTime.Control = EndTimeTimeEdit;
            ItemForEndTime.Location = new Point(582, 48);
            ItemForEndTime.Name = "ItemForEndTime";
            ItemForEndTime.Size = new Size(194, 24);
            ItemForEndTime.Text = "Bitmə Saatı";
            ItemForEndTime.TextSize = new Size(89, 13);
            // 
            // ItemForNextPlanDate
            // 
            ItemForNextPlanDate.Control = NextPlanDateDateEdit;
            ItemForNextPlanDate.Location = new Point(388, 72);
            ItemForNextPlanDate.Name = "ItemForNextPlanDate";
            ItemForNextPlanDate.Size = new Size(388, 24);
            ItemForNextPlanDate.TextSize = new Size(89, 13);
            // 
            // ItemForAssignedCurrAccCode
            // 
            ItemForAssignedCurrAccCode.Control = btnEdit_AssignedCurrAccCode;
            ItemForAssignedCurrAccCode.Location = new Point(388, 96);
            ItemForAssignedCurrAccCode.Name = "ItemForAssignedCurrAccCode";
            ItemForAssignedCurrAccCode.Size = new Size(194, 24);
            ItemForAssignedCurrAccCode.Text = "Təyin edilən";
            ItemForAssignedCurrAccCode.TextSize = new Size(89, 13);
            // 
            // ItemForAssignedCurrAccDesc
            // 
            ItemForAssignedCurrAccDesc.Control = txtEdit_AssignedCurrAccDesc;
            ItemForAssignedCurrAccDesc.Location = new Point(582, 96);
            ItemForAssignedCurrAccDesc.Name = "ItemForAssignedCurrAccDesc";
            ItemForAssignedCurrAccDesc.Size = new Size(194, 24);
            ItemForAssignedCurrAccDesc.Text = "Personal Adı";
            ItemForAssignedCurrAccDesc.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new Point(0, 490);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(604, 26);
            // 
            // layoutControlItemOk
            // 
            layoutControlItemOk.Control = btn_Ok;
            layoutControlItemOk.Location = new Point(604, 490);
            layoutControlItemOk.MaxSize = new Size(98, 26);
            layoutControlItemOk.MinSize = new Size(98, 26);
            layoutControlItemOk.Name = "layoutControlItemOk";
            layoutControlItemOk.Size = new Size(98, 26);
            layoutControlItemOk.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItemOk.TextVisible = false;
            // 
            // layoutControlItemCancel
            // 
            layoutControlItemCancel.Control = btn_Cancel;
            layoutControlItemCancel.Location = new Point(702, 490);
            layoutControlItemCancel.MaxSize = new Size(98, 26);
            layoutControlItemCancel.MinSize = new Size(98, 26);
            layoutControlItemCancel.Name = "layoutControlItemCancel";
            layoutControlItemCancel.Size = new Size(98, 26);
            layoutControlItemCancel.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItemCancel.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.AllowDrawBackground = false;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Location = new Point(0, 516);
            layoutControlGroup1.Name = "autoGeneratedGroup0";
            layoutControlGroup1.Size = new Size(800, 24);
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
            ((ISupportInitialize)NextPlanDateDateEdit.Properties.CalendarTimeProperties).EndInit();
            ((ISupportInitialize)NextPlanDateDateEdit.Properties).EndInit();
            ((ISupportInitialize)Root).EndInit();
            ((ISupportInitialize)layoutControlGroupMain).EndInit();
            ((ISupportInitialize)ItemForActivityCode).EndInit();
            ((ISupportInitialize)ItemForCurrAccDesc).EndInit();
            ((ISupportInitialize)ItemForSubject).EndInit();
            ((ISupportInitialize)ItemForActivityTypeId).EndInit();
            ((ISupportInitialize)ItemForPriority).EndInit();
            ((ISupportInitialize)ItemForActivityDate).EndInit();
            ((ISupportInitialize)ItemForDescription).EndInit();
            ((ISupportInitialize)ItemForResult).EndInit();
            ((ISupportInitialize)ItemForIsCompleted).EndInit();
            ((ISupportInitialize)ItemForCurrAccCode).EndInit();
            ((ISupportInitialize)ItemForStatus).EndInit();
            ((ISupportInitialize)ItemForStartTime).EndInit();
            ((ISupportInitialize)ItemForEndTime).EndInit();
            ((ISupportInitialize)ItemForNextPlanDate).EndInit();
            ((ISupportInitialize)ItemForAssignedCurrAccCode).EndInit();
            ((ISupportInitialize)ItemForAssignedCurrAccDesc).EndInit();
            ((ISupportInitialize)emptySpaceItem1).EndInit();
            ((ISupportInitialize)layoutControlItemOk).EndInit();
            ((ISupportInitialize)layoutControlItemCancel).EndInit();
            ((ISupportInitialize)layoutControlGroup1).EndInit();
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
        private DevExpress.XtraEditors.DateEdit NextPlanDateDateEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNextPlanDate;
    }
}
