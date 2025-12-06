using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Repository;
using Foxoft.Models;
using System;
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
            if (PropName == nameof(DcProduct.ProductCode) || PropName.Contains("." + nameof(DcProduct.ProductCode)))
                return MyProductCode();

            if (PropName == nameof(DcCurrAcc.CurrAccCode) || PropName.Contains("." + nameof(DcCurrAcc.CurrAccCode)))
                return MyCurrAccCode();

            if (PropName == nameof(DcCurrAcc.StoreCode) || PropName.Contains("." + nameof(DcCurrAcc.StoreCode)))
                return MyStoreCode();

            if (PropName == nameof(TrPaymentLine.CashRegisterCode) || PropName.Contains("." + nameof(TrPaymentLine.CashRegisterCode)))
                return MyCashRegisterCode();

            if (PropName == nameof(TrInvoiceHeader.WarehouseCode) || PropName.Contains("." + nameof(TrInvoiceHeader.WarehouseCode)))
                return MyWarehouseCode();

            if (PropName == nameof(DcProduct.HierarchyCode) || PropName.Contains("." + nameof(DcProduct.HierarchyCode)))
                return MyHierarchyCode();

            if (PropName == nameof(TrInvoiceLine.SalesPersonCode) || PropName.Contains("." + nameof(TrInvoiceLine.SalesPersonCode)))
                return MySalesPersonCode();

            return null;
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
            repoBtnEdit.ButtonPressed += (sender, e) => { SelectCurrAcc(sender, new byte[] { 1, 2, 3 }); };
            return repoBtnEdit;
        }

        private static RepositoryItem MyStoreCode()
        {
            RepositoryItemButtonEdit repoBtnEdit = new();
            repoBtnEdit.AutoHeight = false;
            repoBtnEdit.ButtonPressed += (sender, e) => { SelectCurrAcc(sender, new byte[] { 4 }); };
            return repoBtnEdit;
        }

        private static RepositoryItem MySalesPersonCode()
        {
            RepositoryItemButtonEdit repoBtnEdit = new();
            repoBtnEdit.AutoHeight = false;
            repoBtnEdit.ButtonPressed += (sender, e) => { SelectCurrAcc(sender, new byte[] { 3 }); };
            return repoBtnEdit;
        }

        private static RepositoryItem MyCashRegisterCode()
        {
            RepositoryItemButtonEdit repoBtnEdit = new();
            repoBtnEdit.AutoHeight = false;
            repoBtnEdit.ButtonPressed += (sender, e) => { SelectCurrAcc(sender, new byte[] { 5 }); };
            return repoBtnEdit;
        }

        private static RepositoryItem MyHierarchyCode()
        {
            RepositoryItemButtonEdit repoBtnEdit = new();
            repoBtnEdit.AutoHeight = false;
            repoBtnEdit.ButtonPressed += (sender, e) => { SelectHierarchy(sender); };
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

            string value = editor.EditValue?.ToString();

            using (FormProductList form = new(new byte[] { 1, 3 }, false, value))
            {
                if (form.ShowDialog(parentForm) == DialogResult.OK)
                    editor.EditValue = form.dcProduct.ProductCode;
            }
        }

        private static void SelectCurrAcc(object sender, byte[] currAccTypeCode)
        {
            ButtonEdit editor = (ButtonEdit)sender;

            string value = editor.EditValue?.ToString();

            using (FormCurrAccList form = new(currAccTypeCode, false, value))
            {
                if (form.ShowDialog(parentForm) == DialogResult.OK)
                    editor.EditValue = form.dcCurrAcc.CurrAccCode;
            }
        }

        private static void SelectHierarchy(object sender)
        {
            ButtonEdit editor = (ButtonEdit)sender;

            string value = editor.EditValue?.ToString();

            using (FormHierarchyList form = new(value))
            {
                if (form.ShowDialog(parentForm) == DialogResult.OK)
                    editor.EditValue = form.DcHierarchy.HierarchyCode;
            }
        }
    }
}
