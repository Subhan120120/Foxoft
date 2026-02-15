using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormTerminalList : RibbonForm
    {
        subContext dbContext;

        int selectedTerminalId;

        public FormTerminalList()
        {
            InitializeComponent();

            KeyPreview = true;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormTerminalList_Load(object sender, EventArgs e)
        {
            RefreshTerminalList();
        }

        private void RefreshTerminalList()
        {
            using (dbContext = new subContext())
            {
                // List ekranlarında AsNoTracking()
                var list = dbContext.DcTerminals
                    .AsNoTracking()
                    .OrderBy(x => x.TerminalId)
                    .ToList();

                dcTerminalsBindingSource.DataSource = list;
            }

            gV_TerminalList.BestFitColumns();
        }

        private DcTerminal GetSelectedTerminal()
        {
            return gV_TerminalList.GetFocusedRow() as DcTerminal;
        }

        private void gV_TerminalList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var row = GetSelectedTerminal();
            selectedTerminalId = row?.TerminalId ?? 0;
        }

        private void bBI_TerminalNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Qeyd: Bu layihədə edit formu adətən FormTerminal olur.
            using (var form = new FormTerminal())
            {
                if (form.ShowDialog() == DialogResult.OK)
                    RefreshTerminalList();
            }
        }

        private void bBI_TerminalEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            var row = GetSelectedTerminal();
            if (row == null)
                return;

            // Edit yalnız düymə ilə açılmalıdır (double-click yoxdur)
            using (var form = new FormTerminal(row.TerminalId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    RefreshTerminalList();
            }
        }

        private void bBI_TerminalDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            var row = GetSelectedTerminal();
            if (row == null)
                return;

            var result = XtraMessageBox.Show(
                "Seçilmiş terminali silmək istəyirsiniz?",
                Resources.Common_Confirm,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            using (var db = new subContext())
            {
                var entity = db.DcTerminals.FirstOrDefault(x => x.TerminalId == row.TerminalId);
                if (entity == null)
                    return;

                db.DcTerminals.Remove(entity);
                db.SaveChanges();
            }

            RefreshTerminalList();
        }

        private void bBI_TerminalRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshTerminalList();
        }

        private void gC_TerminalList_ProcessGridKey(object sender, KeyEventArgs e)
        {
            // Klaviatura qısa yolları
            if (e.KeyCode == Keys.Delete)
            {
                bBI_TerminalDelete.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Insert)
            {
                bBI_TerminalNew.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F5)
            {
                bBI_TerminalRefresh.PerformClick();
                e.Handled = true;
            }
        }

        private void FormTerminalList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
            else if (e.KeyCode == Keys.Insert)
                bBI_TerminalNew.PerformClick();
            else if (e.KeyCode == Keys.F2)
                bBI_TerminalEdit.PerformClick();
            else if (e.KeyCode == Keys.Delete)
                bBI_TerminalDelete.PerformClick();
            else if (e.KeyCode == Keys.F5)
                bBI_TerminalRefresh.PerformClick();
        }
    }
}
