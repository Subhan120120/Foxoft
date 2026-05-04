using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class UcShortcutSetting : XtraUserControl
    {
        private subContext dbContext;
        private BindingList<DcShortcut> shortcutBindingList;

        public UcShortcutSetting()
        {
            InitializeComponent();
            dbContext = new subContext();
        }

        private void UcShortcutSetting_Load(object sender, EventArgs e)
        {
            LoadData();
            ApplyLocalization();
        }

        private void LoadData()
        {
            var data = dbContext.DcShortcuts.OrderBy(x => x.FormName).ThenBy(x => x.Id).ToList();
            shortcutBindingList = new BindingList<DcShortcut>(data);
            gridControl1.DataSource = shortcutBindingList;
        }

        private void ApplyLocalization()
        {
            // UserControl doesn't have Text property like a Form
            btnSave.Text = Resources.FormShortcut_Save;
            btnCancel.Text = Resources.Common_Cancel;

            colFormName.Caption = Resources.Entity_Shortcut_FormName;
            colButtonDescription.Caption = Resources.Entity_Shortcut_ButtonDescription;
            colShortcutKeys.Caption = Resources.Entity_Shortcut_ShortcutKeys;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.CloseEditor();
                gridView1.UpdateCurrentRow();
                
                // Unikallıq yoxlaması
                var duplicate = shortcutBindingList
                    .Where(s => !string.IsNullOrEmpty(s.ShortcutKeys))
                    .GroupBy(s => new { s.FormName, s.ShortcutKeys })
                    .FirstOrDefault(g => g.Count() > 1);

                if (duplicate != null)
                {
                    XtraMessageBox.Show(Resources.FormShortcut_DuplicateWarning, Resources.Common_Attention, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dbContext.SaveChanges();
                XtraMessageBox.Show(Resources.Common_SavedSuccessfully, Resources.Common_Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Resources.Common_ErrorOccurred + " " + ex.Message, Resources.Common_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // In a UserControl inside a Tab, Cancel could revert changes, 
            // but since it's an auto-saving flow mostly, maybe just reload or leave empty.
            LoadData();
        }

        // Qısayol daxil etmək üçün xüsusi editor event-ləri
        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            if (gridView1.FocusedColumn == colShortcutKeys)
            {
                var editor = gridView1.ActiveEditor as TextEdit;
                if (editor != null)
                {
                    editor.Properties.NullValuePrompt = Resources.FormShortcut_PressKey;
                    editor.Properties.ShowNullValuePrompt = DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorFocused;
                    
                    editor.KeyDown -= Editor_KeyDown;
                    editor.KeyDown += Editor_KeyDown;
                    editor.Properties.ReadOnly = true; // Yalnız KeyDown ilə dəyişsin
                }
            }
        }

        private void Editor_KeyDown(object sender, KeyEventArgs e)
        {
            var editor = sender as TextEdit;
            if (editor == null) return;

            e.Handled = true;
            e.SuppressKeyPress = true;

            // Xüsusi düymələrə ignore (tək başına ctrl, shift, alt)
            if (e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Menu)
                return;

            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                editor.EditValue = "";
                return;
            }

            string shortcutStr = ShortcutHelper.KeysToString(e.KeyData);
            if (!string.IsNullOrEmpty(shortcutStr))
            {
                editor.EditValue = shortcutStr;
            }
        }
    }
}
