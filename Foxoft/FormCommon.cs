using DevExpress.Mvvm.Native;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

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
        public string Value_Id;
        public string FieldName_Id;
        public string Value_2;
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

        public FormCommon(string processCode, bool isNew, string fieldName_Id, string value_Id, string[] specialColumnsHide = null)
            : this(processCode, isNew, fieldName_Id)
        {
            this.Value_Id = value_Id;
            this.SpecialColumnsHide = specialColumnsHide;
        }

        public FormCommon(string processCode, bool isNew, string fieldName_Id, string value_Id, string fieldName_2, string value_2, string[] specialColumnsHide = null)
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
                                        Control_Id.Enabled = false;
                            }
                            else if (itemFieldName == FieldName_2)
                            {
                                Control_2 = item;

                                if (dbContext.Model.FindEntityType(typeof(T)).GetProperty(FieldName_2).IsPrimaryKey())
                                    if (!IsNew)
                                        Control_2.Enabled = false;
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
                    Value_2 = editor.EditValue?.ToString();
            }
        }

        private void FillDataLayout()
        {
            dbContext = new subContext();

            if (string.IsNullOrEmpty(Value_Id))
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

        private Func<T, bool> ConvertToPredicate(string propName, string value)
        {
            ParameterExpression? param = Expression.Parameter(typeof(T));
            MemberExpression? member = Expression.Property(param, propName);
            MethodInfo? asString = this.GetType().GetMethod("AsString");
            MethodCallExpression? stringMember = Expression.Call(asString, Expression.Convert(member, typeof(object)));
            ConstantExpression? constant = Expression.Constant(value);
            BinaryExpression? expression = Expression.Equal(stringMember, constant);
            LambdaExpression? lambda = Expression.Lambda(expression, param);
            Func<T, bool> predicate = (Func<T, bool>)lambda.Compile();
            return predicate;
        }

        private void ClearControlsAddNew()
        {
            Entity = bindingSource1.AddNew() as T;

            string tableName = dbContext.Model.FindEntityType(typeof(T)).GetTableName();

            string NewDocNum = efMethods.GetNextDocNum(false, ProcessCode, FieldName_Id, tableName, 4);

            bindingSource1.DataSource = Entity;

            Control_Id.Control.Text = NewDocNum;

            if (Control_2.Control is not null)
                Control_2.Control.Text = Value_2;

            dataLayoutControl1.SetCurrentRecordFieldValue(FieldName_2, Value_2);
        }


        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                Entity = bindingSource1.Current as T;

                string id = Control_Id.Control.Text;

                Func<T, bool> predicate_id = ConvertToPredicate(FieldName_Id, id);
                Func<T, bool> predicate_2 = string.IsNullOrEmpty(FieldName_2) ? _ => true : ConvertToPredicate(FieldName_2, Value_2);

                if (IsNew) //if invoiceHeader doesnt exist
                    if (!dbContext.Set<T>().Where(predicate_id)
                                           .Any(predicate_2))
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

        private void dataLayoutControl1_FieldRetrieving(object sender, FieldRetrievingEventArgs e)
        {
            if (e.FieldName == "ProductCode") e.EditorType = typeof(ButtonEdit);
            if (e.FieldName == "CurrAccCode") e.EditorType = typeof(ButtonEdit);
            else if (e.FieldName == "DiscountId") e.EditorType = typeof(ButtonEdit);
            else if (e.FieldName == "ReportId") e.EditorType = typeof(ButtonEdit);
            else if (e.FieldName == "RoleCode") e.EditorType = typeof(ButtonEdit);
            else if (e.FieldName == "FormCode") e.EditorType = typeof(ButtonEdit);
            else if (e.FieldName == "HierarchyCode") e.EditorType = typeof(ButtonEdit);
            else if (e.FieldName == "FeatureTypeId") e.EditorType = typeof(ButtonEdit);

            e.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            e.Handled = true;
        }

        private void dataLayoutControl1_FieldRetrieved(object sender, FieldRetrievedEventArgs e)
        {
            if (e.FieldName == "ProductCode") // add FieldRetrieving too
            {
                RepositoryItemButtonEdit btnEdit = e.RepositoryItem as RepositoryItemButtonEdit;
                btnEdit.ButtonPressed += new ButtonPressedEventHandler(repoBtnEdit_ProductCode_ButtonPressed);
            }
            if (e.FieldName == "CurrAccCode") // add FieldRetrieving too
            {
                RepositoryItemButtonEdit btnEdit = e.RepositoryItem as RepositoryItemButtonEdit;
                btnEdit.ButtonPressed += new ButtonPressedEventHandler(repoBtnEdit_CurrAccCode_ButtonPressed);
            }
            if (e.FieldName == "DiscountId")// add FieldRetrieving too
            {
                RepositoryItemButtonEdit btnEdit = e.RepositoryItem as RepositoryItemButtonEdit;
                btnEdit.ButtonPressed += new ButtonPressedEventHandler(repoBtnEdit_DiscountId_ButtonPressed);
            }
            if (e.FieldName == "FormCode")// add FieldRetrieving too
            {
                RepositoryItemButtonEdit btnEdit = e.RepositoryItem as RepositoryItemButtonEdit;
                btnEdit.ButtonPressed += new ButtonPressedEventHandler(repoBtnEdit_FormCode_ButtonPressed);
            }
            if (e.FieldName == "ReportId")// add FieldRetrieving too
            {
                RepositoryItemButtonEdit btnEdit = e.RepositoryItem as RepositoryItemButtonEdit;
                btnEdit.ButtonPressed += new ButtonPressedEventHandler(repoBtnEdit_ReportId_ButtonPressed);
            }
            if (e.FieldName == "RoleCode")// add FieldRetrieving too
            {
                RepositoryItemButtonEdit btnEdit = e.RepositoryItem as RepositoryItemButtonEdit;
                btnEdit.ButtonPressed += new ButtonPressedEventHandler(repoBtnEdit_RoleCode_ButtonPressed);
            }
            if (e.FieldName == "HierarchyCode")// add FieldRetrieving too
            {
                RepositoryItemButtonEdit btnEdit = e.RepositoryItem as RepositoryItemButtonEdit;
                btnEdit.ButtonPressed += new ButtonPressedEventHandler(repoBtnEdit_HierarchyCode_ButtonPressed);
            }
            if (e.FieldName == "FeatureTypeId")// add FieldRetrieving too
            {
                RepositoryItemButtonEdit btnEdit = e.RepositoryItem as RepositoryItemButtonEdit;
                btnEdit.ButtonPressed += new ButtonPressedEventHandler(repoBtnEdit_FeatureTypeId_ButtonPressed);
            }
        }

        private void repoBtnEdit_ProductCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            string productCode = editor.EditValue?.ToString();

            using FormProductList form = new(new byte[] { 1, 3 }, productCode);

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    editor.EditValue = form.dcProduct.ProductCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void repoBtnEdit_CurrAccCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            string currAccCode = editor.EditValue?.ToString();

            using FormCurrAccList form = new(new byte[] { 1, 2, 3 }, currAccCode);

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    editor.EditValue = form.dcCurrAcc.CurrAccCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void repoBtnEdit_DiscountId_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            string value = editor.EditValue?.ToString();

            using FormCommonList<DcDiscount> form = new("", "DiscountId", value);

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    editor.EditValue = form.Value_Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void repoBtnEdit_ReportId_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            string value = editor.EditValue?.ToString();

            using FormCommonList<DcReport> form = new("", "ReportId", value, new string[] { "ReportQuery", "ReportTypeId", "ReportLayout", "ReportFilter" });

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    editor.EditValue = form.Value_Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void repoBtnEdit_RoleCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            string value = editor.EditValue?.ToString();

            using FormCommonList<DcRole> form = new("", "RoleCode", value);

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    editor.EditValue = form.Value_Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void repoBtnEdit_FormCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            string value = editor.EditValue?.ToString();

            using FormCommonList<DcForm> form = new("", "FormCode", value);

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    editor.EditValue = form.Value_Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void repoBtnEdit_HierarchyCode_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            string value = editor.EditValue?.ToString();

            using FormCommonList<DcHierarchy> form = new("", "HierarchyCode", value);

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    editor.EditValue = form.Value_Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void repoBtnEdit_FeatureTypeId_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            string value = editor.EditValue?.ToString();

            using FormCommonList<DcFeatureType> form = new("", "FeatureTypeId", value);

            try
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    editor.EditValue = form.Value_Id;
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
