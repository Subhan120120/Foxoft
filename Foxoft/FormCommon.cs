using DevExpress.Mvvm.Native;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraLayout;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormCommon<T> : XtraForm
        where T : class
    {
        subContext dbContext = new();
        EfMethods efMethods = new();
        public T entity { get; set; }
        private bool isNew;
        string processCode;
        string idValue;
        string idFieldName;
        LayoutControlItem idControl;

        public FormCommon(string idFieldName, bool isNew, string processCode)
        {
            InitializeComponent();
            bindingSource1.DataSource = typeof(T);

            this.isNew = isNew;
            this.processCode = processCode;
            this.idFieldName = idFieldName;

            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;

            RetrieveFields();
        }

        public FormCommon(string idFieldName, string idValue)
            : this(idFieldName, false, "")
        {
            this.idValue = idValue;
            idControl.Enabled = false;
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
                    {
                        dataLayoutControl1.Controls.Remove(item.Control);
                    }
                    else
                    {
                        if (item.Control.DataBindings.Count > 0)
                            if (item.Control.DataBindings[0].BindingMemberInfo.BindingField == idFieldName)
                                idControl = item;


                        int loc = item.Location.Y + item.Size.Height;

                        if (loc > lastLoc)
                            lastLoc = loc;
                    }

                    //if (item.Control.DataBindings[0].BindingMemberInfo.BindingField == "Description")
                    //{
                    //dataLayoutControl1.BeginUpdate();
                    //Control prevControl = item.Control;
                    //Binding binding = prevControl.DataBindings[0];
                    //prevControl.DataBindings.Clear();
                    //dataLayoutControl1.Controls.Remove(prevControl);
                    //Control newControl = new MemoEdit();
                    //newControl.Name = "myMemoEdit";
                    //// Bind the new control to the same field as the previous control.
                    //newControl.DataBindings.Add(new Binding(binding.PropertyName, binding.DataSource,
                    //    binding.BindingMemberInfo.BindingField, binding.FormattingEnabled));
                    //dataLayoutControl1.Controls.Add(newControl);
                    //item.Control = newControl;
                    //prevControl.Dispose();
                    //dataLayoutControl1.EndUpdate();
                    //// Change the item's size after the EndUpdate method.
                    //item.Size = new Size(100, 50);
                    //break;
                    //}
                }
            }

            LCI_Ok.Location = new Point(0, lastLoc + 10);
            LCI_Cancel.Location = new Point(0, lastLoc + 10 + LCI_Ok.Size.Height + 10);

            dataLayoutControl1.Controls.Add(btn_Ok);
            dataLayoutControl1.Controls.Add(btn_Cancel);

            Root.Items.AddRange(new BaseLayoutItem[] { LCI_Ok, LCI_Cancel });
        }

        private void FormCommon_Load(object sender, EventArgs e)
        {
            FillDataLayout();
            dataLayoutControl1.IsValid(out List<string> errorList);
        }

        private void FillDataLayout()
        {
            dbContext = new subContext();

            if (string.IsNullOrEmpty(idValue))
                ClearControlsAddNew();
            else
            {
                Func<T, bool> predicate = ConvertToPredicate(idFieldName, idValue);

                IList<T> data = dbContext.Set<T>().Where(predicate)
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
            var param = Expression.Parameter(typeof(T));
            MemberExpression member = Expression.Property(param, propName);
            var asString = this.GetType().GetMethod("AsString");
            var stringMember = Expression.Call(asString, Expression.Convert(member, typeof(object)));
            ConstantExpression constant = Expression.Constant(value);
            var expression = Expression.Equal(stringMember, constant);
            var lambda = Expression.Lambda(expression, param);
            var predicate = (Func<T, bool>)lambda.Compile();
            return predicate;
        }

        private void ClearControlsAddNew()
        {
            entity = bindingSource1.AddNew() as T;

            string NewDocNum = efMethods.GetNextDocNum(false, "0", idFieldName, typeof(T).Name + "s", 4);

            bindingSource1.DataSource = entity;

            idControl.Control.Text = NewDocNum;
        }


        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                entity = bindingSource1.Current as T;

                string id = idControl.Control.Text;

                Func<T, bool> predicate = ConvertToPredicate(idFieldName, id);

                if (isNew) //if invoiceHeader doesnt exist
                    if (!dbContext.Set<T>().Any(predicate))
                    {
                        dbContext.Set<T>().Add(entity);
                        dbContext.SaveChanges();
                    }
                    else
                        MessageBox.Show("Bu Kodda Məhsul Artıq Mövcuddur!");
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
    }
}
