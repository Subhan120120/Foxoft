using DevExpress.Mvvm.Native;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;

namespace Foxoft
{
    public partial class FormCommon<T> : XtraForm
        where T : class
    {
        subContext dbContext = new();
        EfMethods efMethods = new();
        public T Entity { get; set; }
        private bool IsNew;
        string ProcessCode = "0";
        public object Value_Id;
        public string FieldName_Id;
        public object Value_2;
        public string FieldName_2;
        string[] SpecialColumnsHide = new string[] { };
        LayoutControlItem Control_Id = new();
        LayoutControlItem Control_2 = new();

        public FormCommon(string processCode, bool isNew, string fieldName_Id)
        {
            InitializeComponent();
            bindingSource1.DataSource = typeof(T);
            Text = ((DisplayAttribute)typeof(T).GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault())?.Name;

            IsNew = isNew;
            ProcessCode = processCode;
            FieldName_Id = fieldName_Id;

            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;
        }

        public FormCommon(string processCode, bool isNew, string fieldName_Id, object value_Id, string[] specialColumnsHide = null)
            : this(processCode, isNew, fieldName_Id)
        {
            this.Value_Id = value_Id;
            this.SpecialColumnsHide = specialColumnsHide;
        }

        public FormCommon(string processCode, bool isNew, string fieldName_Id, object value_Id, string fieldName_2, object value_2, string[] specialColumnsHide = null)
            : this(processCode, isNew, fieldName_Id, value_Id, specialColumnsHide)
        {
            this.FieldName_2 = fieldName_2;
            this.Value_2 = value_2;
        }

        private void FormCommon_Load(object sender, EventArgs e)
        {
            RetrieveFields();

            FillDataLayout();
        }

        private void RetrieveFields()
        {
            dataLayoutControl1.RetrieveFields();

            int lastLoc = 0;

            foreach (BaseLayoutItem baseItem in dataLayoutControl1.Items)
            {
                LayoutControlItem item = baseItem as LayoutControlItem;
                if (item != null)
                {
                    if (item.Control is GridControl)
                        dataLayoutControl1.Controls.Remove(item.Control);
                    else
                    {
                        if (item.Control.DataBindings.Count > 0)
                        {
                            string itemFieldName = item.Control.DataBindings[0].BindingMemberInfo.BindingField;
                            if (itemFieldName == FieldName_Id)
                            {
                                Control_Id = item;

                                if (dbContext.Model.FindEntityType(typeof(T)).GetProperty(FieldName_Id).IsPrimaryKey())
                                    if (!IsNew)
                                        (Control_Id.Control as BaseEdit).Properties.ReadOnly = true;
                            }
                            else if (itemFieldName == FieldName_2)
                            {
                                Control_2 = item;

                                if (dbContext.Model.FindEntityType(typeof(T)).GetProperty(FieldName_2).IsPrimaryKey())
                                    if (!IsNew)
                                        (Control_2.Control as BaseEdit).Properties.ReadOnly = true;
                            }
                            else if (dbContext.Model.GetEntityTypes().Select(t => t.GetTableName()).Distinct().ToList().Contains(itemFieldName)
                                || dbContext.Model.GetEntityTypes().Select(t => t.ClrType.Name).ToList().Contains(itemFieldName)) // relation table adlari silinsin
                                dataLayoutControl1.Remove(item);
                            else if (new string[] { "CreatedUserName", "CreatedDate", "LastUpdatedUserName", "LastUpdatedDate" }.Contains(itemFieldName))
                                item.Visibility = LayoutVisibility.OnlyInCustomization;
                            else if (SpecialColumnsHide is not null && SpecialColumnsHide.Contains(itemFieldName))
                                item.Visibility = LayoutVisibility.OnlyInCustomization;

                            if (item.Control is BaseEdit baseEdit)
                                baseEdit.EditValueChanged += BaseEdit_EditValueChanged;
                        }

                        int loc = item.Location.Y + item.Size.Height;

                        if (loc > lastLoc)
                            lastLoc = loc;
                    }
                }
            }

            LCI_Ok.Location = new Point(0, lastLoc + 10);
            LCI_Cancel.Location = new Point(0, lastLoc + 10 + LCI_Ok.Size.Height + 10);

            dataLayoutControl1.Controls.Add(btn_Ok);
            dataLayoutControl1.Controls.Add(btn_Cancel);

            Root.Items.AddRange(new BaseLayoutItem[] { LCI_Ok, LCI_Cancel });
        }

        private void BaseEdit_EditValueChanged(object sender, EventArgs e)
        {
            BaseEdit editor = sender as BaseEdit;
            if (editor != null)
            {
                string fieldName = editor.DataBindings[0].BindingMemberInfo.BindingField;
                if (fieldName == FieldName_Id)
                    Value_Id = editor.EditValue?.ToString();
                if (fieldName == FieldName_2)
                    Value_2 = editor.EditValue;
            }
        }

        private void FillDataLayout()
        {
            dbContext = new subContext();

            if (IsNew)
                ClearControlsAddNew();
            else
            {
                Func<T, bool> predicate_id = ConvertToPredicate(FieldName_Id, Value_Id);
                Func<T, bool> predicate_2 = string.IsNullOrEmpty(FieldName_2) ? _ => true : ConvertToPredicate(FieldName_2, Value_2);

                IList<T> data = dbContext.Set<T>().Where(predicate_id)
                                                  .Where(predicate_2)
                                                  .ToList();

                bindingSource1.DataSource = data;
            }
        }

        public static string AsString(object obj)
        {
            return obj?.ToString();
        }

        private Func<T, bool> ConvertToPredicate(string propName, object value)
        {
            var param = Expression.Parameter(typeof(T), "x");
            MemberExpression member = Expression.Property(param, propName);
            UnaryExpression memberAsObject = Expression.Convert(member, typeof(object));
            var convertedValue = Convert.ChangeType(value, member.Type);
            ConstantExpression constant = Expression.Constant(convertedValue, member.Type);
            var expression = Expression.Equal(member, constant);
            var lambda = Expression.Lambda<Func<T, bool>>(expression, param);
            var predicate = lambda.Compile();
            return predicate;
        }

        private void ClearControlsAddNew()
        {
            object value_2 = Value_2; //get value_2 before AddNew() fires editvalue_changed event and clears value_2 to 0

            Entity = bindingSource1.AddNew() as T;

            PropertyInfo? property_2 = typeof(T).GetProperty(FieldName_2);
            if (property_2 != null && property_2.CanWrite)
                property_2.SetValue(Entity, value_2);

            string tableName = dbContext.Model.FindEntityType(typeof(T)).GetTableName();

            string NewDocNum = efMethods.GetNextDocNum(false, ProcessCode, FieldName_Id, tableName, 4);

            bindingSource1.DataSource = Entity;

            Control_Id.Control.Text = NewDocNum;
        }


        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                Entity = bindingSource1.Current as T;

                //string id = Control_Id.Control.value;

                Func<T, bool> predicate_id = ConvertToPredicate(FieldName_Id, Value_Id);
                Func<T, bool> predicate_2 = string.IsNullOrEmpty(FieldName_2) ? _ => true : ConvertToPredicate(FieldName_2, Value_2);

                if (IsNew)
                    if (!dbContext.Set<T>().Where(predicate_id).Any(predicate_2))
                    {
                        dbContext.Set<T>().Add(Entity);
                        dbContext.SaveChanges();
                    }
                    else
                        MessageBox.Show("Bu kodda məlumat artıq mövcuddur.");
                else
                    dbContext.SaveChanges();

                DialogResult = DialogResult.OK;
            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }
        }

        private readonly Dictionary<string, Type> buttonEditFields = new()
        {
            { nameof(DcCurrAcc.CurrAccCode), typeof(DcCurrAcc) },
            { nameof(DcDiscount.DiscountId), typeof(DcDiscount) },
            { nameof(DcReport.ReportId), typeof(DcReport) },
            { nameof(DcRole.RoleCode), typeof(DcRole) },
            { nameof(DcForm.FormCode), typeof(DcForm) },
            { nameof(DcHierarchy.HierarchyCode), typeof(DcHierarchy) },
            { nameof(DcFeatureType.FeatureTypeId), typeof(DcFeatureType) },
            { nameof(DcClaim.ClaimCode), typeof(DcClaim) },
            { nameof(DcClaimCategory.CategoryId), typeof(DcClaimCategory) },
        };

        private void dataLayoutControl1_FieldRetrieving(object sender, FieldRetrievingEventArgs e)
        {
            var entityType = dbContext.Model.FindEntityType(typeof(T));

            if (entityType.FindNavigation(e.FieldName) != null)
            {
                e.Handled = true;
                return;
            }

            if (entityType.GetProperty(e.FieldName).IsPrimaryKey() && !IsNew)
            {
                e.Handled = true;
                return;
            }

            if (e.FieldName == nameof(DcProduct.ProductCode)) e.EditorType = typeof(ButtonEdit);
            else if (e.FieldName == nameof(DcCurrAcc.CurrAccCode)) e.EditorType = typeof(ButtonEdit);
            else if (e.FieldName == nameof(DcDiscount.DiscountId)) e.EditorType = typeof(ButtonEdit);
            else if (e.FieldName == nameof(DcReport.ReportId)) e.EditorType = typeof(ButtonEdit);
            else if (e.FieldName == nameof(DcRole.RoleCode)) e.EditorType = typeof(ButtonEdit);
            else if (e.FieldName == nameof(DcForm.FormCode)) e.EditorType = typeof(ButtonEdit);
            else if (e.FieldName == nameof(DcHierarchy.HierarchyCode)) e.EditorType = typeof(ButtonEdit);
            else if (e.FieldName == nameof(DcFeatureType.FeatureTypeId)) e.EditorType = typeof(ButtonEdit);
            else if (e.FieldName == nameof(DcClaim.ClaimCode)) e.EditorType = typeof(ButtonEdit);
            else if (e.FieldName == nameof(DcClaimCategory.CategoryId)) e.EditorType = typeof(ButtonEdit);

            e.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            e.Handled = true;
        }

        private void dataLayoutControl1_FieldRetrieved(object sender, FieldRetrievedEventArgs e)
        {

            if (e.FieldName == nameof(DcProduct.ProductCode)) // add FieldRetrieving too
            {
                RepositoryItemButtonEdit btnEdit = e.RepositoryItem as RepositoryItemButtonEdit;
                if (btnEdit != null)
                    btnEdit.ButtonPressed += new ButtonPressedEventHandler(repoBtnEdit_ProductCode_ButtonPressed);
            }
            if (e.FieldName == nameof(DcCurrAcc.CurrAccCode)) // add FieldRetrieving too
            {
                RepositoryItemButtonEdit btnEdit = e.RepositoryItem as RepositoryItemButtonEdit;
                if (btnEdit != null)
                    btnEdit.ButtonPressed += new ButtonPressedEventHandler(repoBtnEdit_CurrAccCode_ButtonPressed);
            }
            if (e.FieldName == nameof(DcDiscount.DiscountId))// add FieldRetrieving too
            {
                RepositoryItemButtonEdit btnEdit = e.RepositoryItem as RepositoryItemButtonEdit;
                if (btnEdit != null)
                    btnEdit.ButtonPressed += new ButtonPressedEventHandler(repoBtnEdit_DiscountId_ButtonPressed);
            }
            if (e.FieldName == nameof(DcForm.FormCode))// add FieldRetrieving too
            {
                RepositoryItemButtonEdit btnEdit = e.RepositoryItem as RepositoryItemButtonEdit;
                if (btnEdit != null)
                    btnEdit.ButtonPressed += new ButtonPressedEventHandler(repoBtnEdit_FormCode_ButtonPressed);
            }
            if (e.FieldName == nameof(DcReport.ReportId))// add FieldRetrieving too
            {
                RepositoryItemButtonEdit btnEdit = e.RepositoryItem as RepositoryItemButtonEdit;
                if (btnEdit != null)
                    btnEdit.ButtonPressed += new ButtonPressedEventHandler(repoBtnEdit_ReportId_ButtonPressed);
            }
            if (e.FieldName == nameof(DcRole.RoleCode))// add FieldRetrieving too
            {
                RepositoryItemButtonEdit btnEdit = e.RepositoryItem as RepositoryItemButtonEdit;
                if (btnEdit != null)
                    btnEdit.ButtonPressed += new ButtonPressedEventHandler(repoBtnEdit_RoleCode_ButtonPressed);
            }
            if (e.FieldName == nameof(DcHierarchy.HierarchyCode))// add FieldRetrieving too
            {
                RepositoryItemButtonEdit btnEdit = e.RepositoryItem as RepositoryItemButtonEdit;
                if (btnEdit != null)
                    btnEdit.ButtonPressed += new ButtonPressedEventHandler(repoBtnEdit_HierarchyCode_ButtonPressed);
            }
            if (e.FieldName == nameof(DcFeatureType.FeatureTypeId))// add FieldRetrieving too
            {
                RepositoryItemButtonEdit btnEdit = e.RepositoryItem as RepositoryItemButtonEdit;
                if (btnEdit != null)
                    btnEdit.ButtonPressed += new ButtonPressedEventHandler(repoBtnEdit_FeatureTypeId_ButtonPressed);
            }
            if (e.FieldName == nameof(DcClaim.ClaimCode))// add FieldRetrieving too
            {
                RepositoryItemButtonEdit btnEdit = e.RepositoryItem as RepositoryItemButtonEdit;
                if (btnEdit != null)
                    btnEdit.ButtonPressed += new ButtonPressedEventHandler(repoBtnEdit_ClaimCode_ButtonPressed);
            }
            if (e.FieldName == nameof(DcClaimCategory.CategoryId))// add FieldRetrieving too
            {
                RepositoryItemButtonEdit btnEdit = e.RepositoryItem as RepositoryItemButtonEdit;
                if (btnEdit != null)
                    btnEdit.ButtonPressed += new ButtonPressedEventHandler(repoBtnEdit_ClaimCategoryId_ButtonPressed);
            }
        }

        private void repoBtnEdit_ProductCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            string productCode = ((ButtonEdit)sender).EditValue?.ToString();

            using FormProductList form = new(new byte[] { 1, 3 }, productCode);

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    ((ButtonEdit)sender).EditValue = form.dcProduct.ProductCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void repoBtnEdit_CurrAccCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            string currAccCode = ((ButtonEdit)sender).EditValue?.ToString();

            using FormCurrAccList form = new(new byte[] { 1, 2, 3 }, currAccCode);

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    ((ButtonEdit)sender).EditValue = form.dcCurrAcc.CurrAccCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void repoBtnEdit_DiscountId_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            string value = ((ButtonEdit)sender).EditValue?.ToString();

            using FormCommonList<DcDiscount> form = new("", nameof(DcDiscount.DiscountId), value);

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    ((ButtonEdit)sender).EditValue = form.Value_Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void repoBtnEdit_ReportId_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            string value = ((ButtonEdit)sender).EditValue?.ToString();

            using FormCommonList<DcReport> form = new("", nameof(DcReport.ReportId), value, new string[] { "ReportQuery", "ReportTypeId", "ReportLayout", "ReportFilter" });

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    ((ButtonEdit)sender).EditValue = form.Value_Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void repoBtnEdit_RoleCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            string value = ((ButtonEdit)sender).EditValue?.ToString();

            using FormCommonList<DcRole> form = new("", nameof(DcRole.RoleCode), value);

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    ((ButtonEdit)sender).EditValue = form.Value_Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void repoBtnEdit_FormCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            string value = ((ButtonEdit)sender).EditValue?.ToString();

            using FormCommonList<DcForm> form = new("", nameof(DcForm.FormCode), value);

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    ((ButtonEdit)sender).EditValue = form.Value_Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void repoBtnEdit_HierarchyCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            string value = ((ButtonEdit)sender).EditValue?.ToString();

            using FormCommonList<DcHierarchy> form = new("", nameof(DcHierarchy.HierarchyCode), value);

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    ((ButtonEdit)sender).EditValue = form.Value_Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void repoBtnEdit_FeatureTypeId_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            string value = ((ButtonEdit)sender).EditValue?.ToString();

            using FormCommonList<DcFeatureType> form = new("", nameof(DcFeatureType.FeatureTypeId), value);

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    ((ButtonEdit)sender).EditValue = form.Value_Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void repoBtnEdit_ClaimCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            string value = ((ButtonEdit)sender).EditValue?.ToString();

            using FormCommonList<DcClaim> form = new("", nameof(DcClaim.ClaimCode), value);

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    ((ButtonEdit)sender).EditValue = form.Value_Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void repoBtnEdit_ClaimCategoryId_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            string value = ((ButtonEdit)sender).EditValue?.ToString();

            using FormCommonList<DcClaimCategory> form = new("", nameof(DcClaimCategory.CategoryId), value);

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    ((ButtonEdit)sender).EditValue = form.Value_Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LCI_Cancel_Click(object sender, EventArgs e)
        {

        }
    }
}
