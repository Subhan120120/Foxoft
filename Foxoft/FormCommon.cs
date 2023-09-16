using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraLayout;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormCommon : XtraForm
        where T : class
    {
        subContext dbContext = new();
        EfMethods efMethods = new();
        public T entity { get; set; }
        private bool isNew;
        public FormCommon(string idFieldName, bool isNew)
        {
            InitializeComponent();
            bindingSource1.DataSource = typeof(T);

            this.isNew = isNew;
            RetrieveFields();
        }

        private void RetrieveFields()
        {
            dataLayoutControl1.RetrieveFields();

            foreach (BaseLayoutItem baseItem in dataLayoutControl1.Items)
            {
                LayoutControlItem item = baseItem as LayoutControlItem;
                if (item != null && item.Control.DataBindings.Count > 0)
                {
                    if (item.Control is GridControl)
                    {
                        dataLayoutControl1.BeginUpdate();
                        dataLayoutControl1.Controls.Remove(item.Control);
                        dataLayoutControl1.EndUpdate();
                    }

                    if (item.Control.DataBindings[0].BindingMemberInfo.BindingField == "Description")
                    {
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
                    }
                }
            }
        }
    }
}
