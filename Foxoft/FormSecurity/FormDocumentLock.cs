using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Foxoft.Models.Entity;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;

namespace Foxoft
{
    public partial class FormDocumentLock : XtraForm
    {
        private subContext dbContext;
        private readonly EfMethods efMethods = new();

        public DocumentLock documentLock = new();

        public FormDocumentLock()
        {
            InitializeComponent();

            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;
        }

        public FormDocumentLock(Guid lockId)
            : this()
        {
            documentLock.LockId = lockId;

            // PK read-only
            LockIdTextEdit.Properties.ReadOnly = true;
            LockIdTextEdit.Properties.Appearance.BackColor = Color.LightGray;
        }

        private void FormDocumentLock_Load(object sender, EventArgs e)
        {
            LoadDocumentLock();
            LoadLayout();

            dataLayoutControl1.IsValid(out _);
        }

        private void LoadDocumentLock()
        {
            dbContext = new subContext();

            // DbSet adını subContext-ə əlavə edəndən sonra işləyəcək:
            // public DbSet<DocumentLock> DocumentLocks { get; set; }

            if (documentLock.LockId == Guid.Empty || !dbContext.Set<DocumentLock>().Any(x => x.LockId == documentLock.LockId))
                ClearControlsAddNew();
            else
            {
                dbContext.Set<DocumentLock>()
                         .Where(x => x.LockId == documentLock.LockId)
                         .Load();

                documentLocksBindingSource.DataSource = dbContext.Set<DocumentLock>().Local.ToBindingList();
            }
        }

        private void LoadLayout()
        {
            string fileName = "FormDocumentLock.xml";
            string layoutFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Foxoft",
                Settings.Default.CompanyCode,
                "Layout Xml Files",
                fileName);

            if (File.Exists(layoutFilePath))
                dataLayoutControl1.RestoreLayoutFromXml(layoutFilePath);
        }

        private void ClearControlsAddNew()
        {
            documentLock = documentLocksBindingSource.AddNew() as DocumentLock;

            // Default-lar
            documentLock.LockId = Guid.NewGuid();
            documentLock.LockedAtUtc = DateTime.UtcNow;
            documentLock.LastHeartbeatAtUtc = DateTime.UtcNow;
            documentLock.AppInstanceId = Guid.NewGuid();

            // istəsən Authorization varsa:
            // documentLock.LockedByUserName = Authorization.CurrAccCode;
            // documentLock.LockedByUserId = Authorization.CurrAccId;

            documentLocksBindingSource.DataSource = documentLock;

            DocumentTypeTextEdit.Select();
        }

        private void dataLayoutControl1_FieldRetrieving(object sender, FieldRetrievingEventArgs e)
        {
            // Lazım olmayan base field-lar varsa gizlətmək üçün (FormWarehouse kimi)
            if (e.FieldName == "ModifiedDate")
            {
                e.Visible = false;
                e.Handled = true;
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (!dataLayoutControl1.IsValid(out var errorList))
                return;

            documentLock = documentLocksBindingSource.Current as DocumentLock;

            // Utc sahələr üçün minimal qoruma
            if (documentLock.LockedAtUtc == default)
                documentLock.LockedAtUtc = DateTime.UtcNow;
            if (documentLock.LastHeartbeatAtUtc == default)
                documentLock.LastHeartbeatAtUtc = DateTime.UtcNow;

            dbContext.SaveChanges();

            DialogResult = DialogResult.OK;
        }
    }
}