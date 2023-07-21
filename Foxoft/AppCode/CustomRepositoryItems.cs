﻿using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Repository;
using System.Windows.Forms;

namespace Foxoft
{
    public static class CustomRepositoryItems
    {
        public static IWin32Window parentForm;

        public static void InitFilterRepositoryItems(this object valueditor, IWin32Window parentForm)
        {
            parentForm = parentForm;

            if (valueditor.GetType() == typeof(CustomValueEditorArgs))
            {
                CustomValueEditorArgs e = (CustomValueEditorArgs)valueditor;
                e.RepositoryItem = MyRepositoryItem(e.Node.FirstOperand.PropertyName);
            }

            if (valueditor.GetType() == typeof(ShowValueEditorEventArgs))
            {
                ShowValueEditorEventArgs e = (ShowValueEditorEventArgs)valueditor;
                e.CustomRepositoryItem = MyRepositoryItem((e.CurrentNode.Property).Name);
            }
        }

        private static RepositoryItem MyRepositoryItem(string PropName)
        {
            return PropName switch
            {
                "ProductCode" => MyProductCode(),
                "CurrAccCode" => MyCurrAccCode(),
                "StoreCode" => MyStoreCode(),
                "CashRegisterCode" => MyCashRegisterCode(),
                "WarehouseCode" => MyWarehouseCode(),
                _ => null,
            };
        }

        private static RepositoryItem MyProductCode()
        {
            RepositoryItemButtonEdit repoBtnEdit = new();
            repoBtnEdit.AutoHeight = false;
            repoBtnEdit.ButtonPressed += (sender, e) => { SelectProduct(sender); };
            return repoBtnEdit;
        }

        private static RepositoryItem MyCurrAccCode()
        {
            RepositoryItemButtonEdit repoBtnEdit = new();
            repoBtnEdit.AutoHeight = false;
            repoBtnEdit.ButtonPressed += (sender, e) => { SelectCurrAcc(sender, 0); };
            return repoBtnEdit;
        }

        private static RepositoryItem MyStoreCode()
        {
            RepositoryItemButtonEdit repoBtnEdit = new();
            repoBtnEdit.AutoHeight = false;
            repoBtnEdit.ButtonPressed += (sender, e) => { SelectCurrAcc(sender, 4); };
            return repoBtnEdit;
        }

        private static RepositoryItem MyCashRegisterCode()
        {
            RepositoryItemButtonEdit repoBtnEdit = new();
            repoBtnEdit.AutoHeight = false;
            repoBtnEdit.ButtonPressed += (sender, e) => { SelectCurrAcc(sender, 5); };
            return repoBtnEdit;
        }

        private static RepositoryItem MyWarehouseCode()
        {
            RepositoryItemButtonEdit repoBtnEdit = new();
            repoBtnEdit.AutoHeight = false;
            repoBtnEdit.ButtonPressed += (sender, e) =>
            {
                ButtonEdit editor = (ButtonEdit)sender;
                using (FormWarehouseList form = new())
                {
                    if (form.ShowDialog(parentForm) == DialogResult.OK)
                        editor.EditValue = form.dcWarehouse.WarehouseCode;
                }
            };
            return repoBtnEdit;
        }

        private static void SelectProduct(object sender)
        {
            ButtonEdit editor = (ButtonEdit)sender;

            string value = "";
            if (editor.EditValue is not null)
                value = editor.EditValue.ToString();

            using (FormProductList form = new(new byte[] { 1, 3 }, value))
            {
                if (form.ShowDialog(parentForm) == DialogResult.OK)
                    editor.EditValue = form.dcProduct.ProductCode;
            }
        }

        private static void SelectCurrAcc(object sender, byte currAccTypeCode)
        {
            ButtonEdit editor = (ButtonEdit)sender;

            string value = "";
            if (editor.EditValue is not null)
                value = editor.EditValue.ToString();

            using (FormCurrAccList form = new(new byte[] { 1, 2, 3 }, value))
            {
                if (form.ShowDialog(parentForm) == DialogResult.OK)
                    editor.EditValue = form.dcCurrAcc.CurrAccCode;
            }
        }
    }
}
