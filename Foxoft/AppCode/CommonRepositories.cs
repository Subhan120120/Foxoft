using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Windows.Forms;

namespace Foxoft
{
    public static class GridRepositoryExtensions
    {
        public static RepositoryItemButtonEdit AddProductCodeButtonEdit(
            this GridControl grid,
            EventHandler<ButtonPressedEventArgs>? externalClick = null)
        {
            var repo = new RepositoryItemButtonEdit();   // hər dəfə yeni instans
            repo.Buttons.Clear();
            repo.Buttons.Add(new EditorButton());

            repo.ButtonClick += (s, e) =>
            {
                var editor = s as ButtonEdit;
                if (editor == null) return;

                try
                {
                    using FormProductList form = new(new byte[] { 1 }, false, editor.EditValue?.ToString());

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        editor.EditValue = form.dcProduct?.ProductCode;

                        var gridCtrl = editor.Parent as GridControl;
                        var view = gridCtrl?.FocusedView as GridView;
                        view?.PostEditor();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                externalClick?.Invoke(s, e);
            };

            grid.RepositoryItems.Add(repo);
            return repo;
        }

        public static RepositoryItemButtonEdit AddBarcodeTypeButtonEdit(
            this GridControl grid,
            EventHandler<ButtonPressedEventArgs>? externalClick = null)
        {
            var repo = new RepositoryItemButtonEdit();   // hər dəfə yeni instans
            repo.Buttons.Clear();
            repo.Buttons.Add(new EditorButton());

            repo.ButtonClick += (s, e) =>
            {
                var editor = s as ButtonEdit;
                if (editor == null) return;

                try
                {
                    using FormCommonList<DcBarcodeType> form =
                        new("", nameof(DcBarcodeType.BarcodeTypeCode), editor.EditValue?.ToString());

                    if (form.ShowDialog() == DialogResult.OK)
                        editor.EditValue = form.Value_Id;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), Resources.Common_ErrorTitle);
                }

                externalClick?.Invoke(s, e);
            };

            grid.RepositoryItems.Add(repo);
            return repo;
        }
    }
}
