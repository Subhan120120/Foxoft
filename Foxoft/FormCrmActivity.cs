using DevExpress.XtraEditors;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace Foxoft
{
    public partial class FormCrmActivity : XtraForm
    {
        private subContext dbContext;
        private EfMethods efMethods = new();
        private Guid? activityId;

        public TrCrmActivity trCrmActivity = new();

        public FormCrmActivity()
        {
            InitializeComponent();

            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;
        }

        public FormCrmActivity(Guid activityId)
            : this()
        {
            this.activityId = activityId;
        }

        private void FormCrmActivity_Load(object sender, EventArgs e)
        {
            LoadLookups();
            LoadActivity();
            LoadLayout();

            dataLayoutControl1.IsValid(out List<string> errorList);
        }

        private void LoadLookups()
        {
            using (var db = new subContext())
            {
                ActivityTypeIdLookUpEdit.Properties.DataSource = db.DcCrmActivityTypes
                    .AsNoTracking()
                    .Where(x => !x.IsDisabled)
                    .OrderBy(x => x.ActivityTypeDesc)
                    .ToList();
            }

            ActivityTypeIdLookUpEdit.Properties.DisplayMember = nameof(DcCrmActivityType.ActivityTypeDesc);
            ActivityTypeIdLookUpEdit.Properties.ValueMember = nameof(DcCrmActivityType.ActivityTypeId);
            ActivityTypeIdLookUpEdit.Properties.NullText = string.Empty;

            StatusLookUpEdit.Properties.DataSource = EnumToList<CrmActivityStatus>();
            StatusLookUpEdit.Properties.DisplayMember = nameof(EnumItem<CrmActivityStatus>.Text);
            StatusLookUpEdit.Properties.ValueMember = nameof(EnumItem<CrmActivityStatus>.Value);
            StatusLookUpEdit.Properties.NullText = string.Empty;

            PriorityLookUpEdit.Properties.DataSource = EnumToList<CrmActivityPriority>();
            PriorityLookUpEdit.Properties.DisplayMember = nameof(EnumItem<CrmActivityPriority>.Text);
            PriorityLookUpEdit.Properties.ValueMember = nameof(EnumItem<CrmActivityPriority>.Value);
            PriorityLookUpEdit.Properties.NullText = string.Empty;
        }

        private BindingList<EnumItem<TEnum>> EnumToList<TEnum>() where TEnum : struct, Enum
        {
            return new BindingList<EnumItem<TEnum>>(
                Enum.GetValues(typeof(TEnum))
                    .Cast<TEnum>()
                    .Select(x => new EnumItem<TEnum>
                    {
                        Value = x,
                        Text = GetEnumDescription(x)
                    })
                    .ToList());
        }

        private string GetEnumDescription<TEnum>(TEnum value) where TEnum : struct, Enum
        {
            var member = typeof(TEnum).GetMember(value.ToString()).FirstOrDefault();

            if (member is null)
                return value.ToString();

            var attr = member.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .Cast<DescriptionAttribute>()
                .FirstOrDefault();

            return attr?.Description ?? value.ToString();
        }

        private void LoadActivity()
        {
            dbContext = new subContext();

            if (activityId.HasValue)
            {
                dbContext.TrCrmActivities
                    .Include(x => x.DcCurrAcc)
                    .Include(x => x.DcCrmActivityType)
                    .Where(x => x.ActivityId == activityId.Value)
                    .Load();

                crmActivitiesBindingSource.DataSource = dbContext.TrCrmActivities.Local.ToBindingList();
                trCrmActivity = crmActivitiesBindingSource.Current as TrCrmActivity ?? new TrCrmActivity();

                ActivityCodeTextEdit.Properties.ReadOnly = true;
                ActivityCodeTextEdit.Properties.Appearance.BackColor = Color.LightGray;

                FillCustomerDescriptions();
            }
            else
            {
                ClearControlsAddNew();
            }
        }

        private void LoadLayout()
        {
            string fileName = "FormCrmActivity.xml";
            string layoutFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Foxoft",
                Settings.Default.CompanyCode,
                "Layout Xml Files",
                fileName);

            if (File.Exists(layoutFilePath))
                dataLayoutControl1.RestoreLayoutFromXml(layoutFilePath);
        }

        private void ClearControlsAddNew()
        {
            trCrmActivity = crmActivitiesBindingSource.AddNew() as TrCrmActivity ?? new TrCrmActivity();

            trCrmActivity.ActivityId = Guid.NewGuid();
            trCrmActivity.ActivityCode = efMethods.GetNextDocNum(true, "CRA", nameof(TrCrmActivity.ActivityCode), nameof(subContext.TrCrmActivities), 6);
            trCrmActivity.OfficeCode = Authorization.OfficeCode;
            trCrmActivity.StoreCode = Authorization.StoreCode;
            trCrmActivity.ActivityDate = DateTime.Today;
            trCrmActivity.StartTime = DateTime.Now.TimeOfDay;
            trCrmActivity.Status = CrmActivityStatus.Planned;
            trCrmActivity.Priority = CrmActivityPriority.Medium;
            trCrmActivity.ActivityTypeId = 1;
            trCrmActivity.IsCompleted = false;
            trCrmActivity.CreatedDate = DateTime.Now;
            trCrmActivity.CreatedUserName = Authorization.CurrAccCode;

            crmActivitiesBindingSource.DataSource = trCrmActivity;

            ActivityCodeTextEdit.Properties.ReadOnly = true;
            ActivityCodeTextEdit.Properties.Appearance.BackColor = Color.LightGray;

            SubjectTextEdit.Select();
            FillCustomerDescriptions();
        }

        private void FillCustomerDescriptions()
        {
            txtEdit_CurrAccDesc.EditValue = GetCurrAccDesc(trCrmActivity?.CurrAccCode);
            txtEdit_AssignedCurrAccDesc.EditValue = GetCurrAccDesc(trCrmActivity?.AssignedCurrAccCode);
        }

        private string GetCurrAccDesc(string? currAccCode)
        {
            if (string.IsNullOrWhiteSpace(currAccCode))
                return string.Empty;

            DcCurrAcc currAcc = efMethods.SelectCurrAcc(currAccCode);

            if (currAcc is null)
                return string.Empty;

            return $"{currAcc.CurrAccDesc} {currAcc.FirstName} {currAcc.LastName}".Trim();
        }

        private void btnEdit_CurrAccCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SelectCurrAcc();
        }

        private void btnEdit_CurrAccCode_DoubleClick(object sender, EventArgs e)
        {
            SelectCurrAcc();
        }

        private void btnEdit_AssignedCurrAccCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SelectAssignedCurrAcc();
        }

        private void btnEdit_AssignedCurrAccCode_DoubleClick(object sender, EventArgs e)
        {
            SelectAssignedCurrAcc();
        }

        private void SelectCurrAcc()
        {
            using FormCurrAccList form = new(new byte[] { 1, 2, 3 }, false, btnEdit_CurrAccCode.EditValue?.ToString());

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                btnEdit_CurrAccCode.EditValue = form.dcCurrAcc?.CurrAccCode;
                txtEdit_CurrAccDesc.EditValue = GetCurrAccDesc(form.dcCurrAcc?.CurrAccCode);
            }
        }

        private void SelectAssignedCurrAcc()
        {
            using FormCurrAccList form = new(new byte[] { 3 }, false, btnEdit_AssignedCurrAccCode.EditValue?.ToString());

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                btnEdit_AssignedCurrAccCode.EditValue = form.dcCurrAcc?.CurrAccCode;
                txtEdit_AssignedCurrAccDesc.EditValue = GetCurrAccDesc(form.dcCurrAcc?.CurrAccCode);
            }
        }

        private void btnEdit_CurrAccCode_EditValueChanged(object sender, EventArgs e)
        {
            txtEdit_CurrAccDesc.EditValue = GetCurrAccDesc(btnEdit_CurrAccCode.EditValue?.ToString());
        }

        private void btnEdit_AssignedCurrAccCode_EditValueChanged(object sender, EventArgs e)
        {
            txtEdit_AssignedCurrAccDesc.EditValue = GetCurrAccDesc(btnEdit_AssignedCurrAccCode.EditValue?.ToString());
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                crmActivitiesBindingSource.EndEdit();

                trCrmActivity = crmActivitiesBindingSource.Current as TrCrmActivity ?? new TrCrmActivity();

                if (!efMethods.EntityExists<TrCrmActivity>(trCrmActivity.ActivityId))
                {
                    trCrmActivity.CreatedDate = trCrmActivity.CreatedDate == default ? DateTime.Now : trCrmActivity.CreatedDate;
                    trCrmActivity.CreatedUserName ??= Authorization.CurrAccCode;

                    efMethods.InsertEntity(trCrmActivity);
                }
                else
                {
                    trCrmActivity.LastUpdatedDate = DateTime.Now;
                    trCrmActivity.LastUpdatedUserName = Authorization.CurrAccCode;

                    dbContext.SaveChanges();
                }

                DialogResult = DialogResult.OK;
            }
            else
            {
                string combined = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combined);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }

    public class EnumItem<TEnum> where TEnum : struct, Enum
    {
        public TEnum Value { get; set; }
        public string Text { get; set; }
    }
}
