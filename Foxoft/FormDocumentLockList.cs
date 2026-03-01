using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Foxoft.AppCode;
using Foxoft.Models;
using Foxoft.Models.Entity;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;

namespace Foxoft
{
    public partial class FormDocumentLockList : RibbonForm
    {
        private subContext dbContext = new subContext();
        private readonly EfMethods efMethods = new();
        private readonly DocumentLockService _lockService;

        public FormDocumentLockList()
        {
            InitializeComponent();
            _lockService = new DocumentLockService(dbContext);
        }

        private void FormDocumentLockList_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            using (dbContext = new subContext())
            {
                var list =
                    (from dl in dbContext.Set<DocumentLock>().AsNoTracking()
                     join ih in dbContext.TrInvoiceHeaders.AsNoTracking()
                         on dl.DocumentId equals ih.InvoiceHeaderId into ihj
                     from ih in ihj.DefaultIfEmpty()
                     join ca in dbContext.DcCurrAccs.AsNoTracking()
                         on dl.LockedByUserId equals ca.CurrAccCode into caj
                     from ca in caj.DefaultIfEmpty()
                     orderby dl.LockedAtUtc descending
                     select new DocumentLockVM
                     {
                         LockId = dl.LockId,
                         DocumentType = dl.DocumentType,
                         DocumentId = dl.DocumentId,
                         LockedAtUtc = dl.LockedAtUtc,
                         LockedByUserId = dl.LockedByUserId,

                         DocumentNumber = ih != null ? ih.DocumentNumber : null,
                         LockedByUserName = ca != null ? ca.CurrAccDesc : null
                     })
                    .ToList();

                documentLocksBindingSource.DataSource = list;
            }
        }

        private DocumentLock? GetCurrent()
        {
            return documentLocksBindingSource.Current as DocumentLock;
        }

        private void bBI_DocumentLockNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var frm = new FormDocumentLock())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    RefreshList();
            }
        }

        private void bBI_DocumentLockEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            var current = GetCurrent();
            if (current == null)
                return;

            using (var frm = new FormDocumentLock(current.LockId))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    RefreshList();
            }
        }

        private void bBI_DocumentLockDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            var current = GetCurrent();
            if (current == null)
                return;

            var result = XtraMessageBox.Show(
                Resources.Common_DeleteConfirm,
                Resources.Common_Attention,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result != DialogResult.OK)
                return;

            using (var db = new subContext())
            {
                var stub = new DocumentLock { LockId = current.LockId };
                db.Attach(stub);
                db.Remove(stub);
                db.SaveChanges();
            }

            RefreshList();
        }

        private void bBI_DocumentLockRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshList();
        }

        private void bBI_ExportXlsx_ItemClick(object sender, ItemClickEventArgs e)
        {
            using var dlg = new SaveFileDialog
            {
                Filter = "Excel (*.xlsx)|*.xlsx",
                FileName = $"DocumentLocks_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
            };

            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            gC_DocumentLockList.ExportToXlsx(dlg.FileName);
        }

        private void gC_DocumentLockList_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                RefreshList();
                e.Handled = true;
                return;
            }

            if (e.KeyCode == Keys.Insert)
            {
                bBI_DocumentLockNew_ItemClick(null, null);
                e.Handled = true;
                return;
            }

            if (e.KeyCode == Keys.Delete)
            {
                bBI_DocumentLockDelete_ItemClick(null, null);
                e.Handled = true;
                return;
            }
        }

        private void gC_DocumentLockList_Paint(object sender, PaintEventArgs e)
        {
            // FormWarehouseList-də var deyə saxladım (boş qala bilər)
        }

        private void BBI_ForceUnlock_ItemClick(object sender, ItemClickEventArgs e)
        {
            DocumentLockVM documentLock = (DocumentLockVM)gV_DocumentLockList.GetFocusedRow();
            _lockService.ForceUnlock(documentLock.DocumentType, documentLock.DocumentId, documentLock.LockedByUserId, "ForceLock");
        }

        private void BBI_UnlockRequest_ItemClick(object sender, ItemClickEventArgs e)
        {
            DocumentLockVM documentLock = (DocumentLockVM)gV_DocumentLockList.GetFocusedRow();
            _lockService.ForceCloseRequest(documentLock.DocumentType, documentLock.DocumentId, documentLock.LockedByUserId, "ForceLock");
        }
    }
}