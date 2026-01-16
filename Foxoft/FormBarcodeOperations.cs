using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Foxoft.Migrations;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel;
using System.ServiceModel;

namespace Foxoft
{
    public partial class FormBarcodeOperations : RibbonForm
    {
        private TrBarcodeOperationHeader trBarcodeOperationHeader;
        private subContext dbContext;
        private int HeaderId;
        private EfMethods efMethods = new();
        private bool _isLoading;
        private bool _isSaving;
        private int? id;

        public FormBarcodeOperations()
        {
            InitializeComponent();

            trBarcodeOperationLinesBindingSource.DataMember = nameof(TrBarcodeOperationHeader.TrBarcodeOperationLines);

            dbContext = new subContext();

            colProductCode.ColumnEdit = gridControl1.AddProductCodeButtonEdit();
            colBarcodeTypeCode.ColumnEdit = gridControl1.AddBarcodeTypeButtonEdit();

            gridControl1.DataSource = trBarcodeOperationLinesBindingSource;

            LoadData(null); // yeni header yaratsın
        }


        private void FormBarcodeOperations_Load(object sender, EventArgs e)
        {

        }

        private void TrBarcodeOperationHeaderBindingSource_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
        {
            //var header = new TrBarcodeOperationHeader
            //{
            //    Name = "TrBarcodeOperationHeaders"
            //};

            //dbContext.TrBarcodeOperationHeaders.Add(header);

            //e.NewObject = header;
        }


        private void ClearControlsAddNew()
        {
            dbContext = new subContext();

            // Local list-i bağla
            trBarcodeOperationHeaderBindingSource.DataSource =
                dbContext.TrBarcodeOperationHeaders.Local.ToBindingList();

            // Yeni header yarat (AddingNew işə düşəcək və context-ə add edəcək)
            trBarcodeOperationHeader = (TrBarcodeOperationHeader)trBarcodeOperationHeaderBindingSource.AddNew();

            // Header-i dərhal yaz ki, real Id alsın
            dbContext.SaveChanges();

            // İndi header.Id artıq 0 deyil
            trBarcodeOperationLinesBindingSource.DataSource =
                dbContext.TrBarcodeOperationLines.Local.ToBindingList();

            dataLayoutControl1.IsValid(out List<string> errorList);
            gridView1.Focus();
        }

        private void LoadData(int? headerId)
        {
            dbContext ??= new subContext();
            _isLoading = true;

            try
            {
                if (headerId.HasValue)
                {
                    trBarcodeOperationHeader = dbContext.TrBarcodeOperationHeaders
                        .Include(x => x.TrBarcodeOperationLines)
                        .Single(x => x.Id == headerId.Value);
                }
                else
                {
                    trBarcodeOperationHeader = new TrBarcodeOperationHeader
                    {
                        TrBarcodeOperationLines = new BindingList<TrBarcodeOperationLine>()
                    };

                    dbContext.TrBarcodeOperationHeaders.Add(trBarcodeOperationHeader);
                }

                trBarcodeOperationHeaderBindingSource.DataSource = trBarcodeOperationHeader;
            }
            finally
            {
                _isLoading = false;
            }
        }



        private void GridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (_isLoading) return;
            SaveAll(); // saves header + lines
        }

        private void SaveData()
        {
            
        }

        private void IdButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (FormCommonList<TrBarcodeOperationHeader> form = new("", nameof(TrBarcodeOperationHeader.Id)))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (form.Value_Id is not null)
                    {
                        LoadData(Convert.ToInt32(form.Value_Id));
                    }
                }
            }
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var line = (TrBarcodeOperationLine)gridView1.GetRow(e.RowHandle);
            if (line == null) return;

            if (line.Qty == 0) line.Qty = 1;

            // ƏN VACİB HİSSƏ: FK set etmə, navigation set et
            line.TrBarcodeOperationHeader = trBarcodeOperationHeader;

            // tracking
            if (dbContext.Entry(line).State == EntityState.Detached)
                dbContext.TrBarcodeOperationLines.Add(line);
        }


        private void BBI_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_isSaving) return;

            // Əgər əvvəlki header-də line var idisə, saxla
            if (HasAnyLine())
            {
                var result = XtraMessageBox.Show(
                    "Save current document?",
                    "Confirm",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Cancel)
                    return;

                if (result == DialogResult.Yes)
                    SaveAll();
            }

            CreateNewHeader();
        }

        private void CreateNewHeader()
        {
            _isLoading = true;

            try
            {
                // köhnə context-i tam təmizlə
                dbContext?.Dispose();
                dbContext = new subContext();

                trBarcodeOperationHeader = new TrBarcodeOperationHeader
                {
                    Name = "New",
                    TrBarcodeOperationLines = new BindingList<TrBarcodeOperationLine>()
                };

                // Header tracking-ə alınır, AMMA save edilmir
                dbContext.TrBarcodeOperationHeaders.Add(trBarcodeOperationHeader);

                trBarcodeOperationHeaderBindingSource.DataSource = trBarcodeOperationHeader;
                trBarcodeOperationLinesBindingSource.DataSource =
                    trBarcodeOperationHeader.TrBarcodeOperationLines;

                gridView1.Focus();
            }
            finally
            {
                _isLoading = false;
            }
        }

        private bool HasAnyLine()
        {
            return trBarcodeOperationHeader?.TrBarcodeOperationLines?
                .Any(l => dbContext.Entry(l).State != EntityState.Deleted) == true;
        }


        private void TrBarcodeOperationHeaderBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            SaveHeader();
        }

        private void BBI_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_isLoading || _isSaving) return;

            // Heç nə seçilməyibsə, sadəcə yeni sənəd aç
            if (trBarcodeOperationHeader == null)
            {
                CreateNewHeader();
                return;
            }

            // Hələ DB-yə yazılmayıbsa -> discard et, DB-yə toxunma
            if (trBarcodeOperationHeader.Id == 0)
            {
                var r0 = XtraMessageBox.Show(
                    "This document is not saved yet. Discard it?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (r0 != DialogResult.Yes) return;

                CreateNewHeader();
                return;
            }

            // DB-də var -> sil
            var r = XtraMessageBox.Show(
                $"Delete document #{trBarcodeOperationHeader.Id} ?\nAll lines will be deleted too.",
                "Confirm delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r != DialogResult.Yes) return;

            try
            {
                _isSaving = true;

                // UI editləri bitir
                gridView1.CloseEditor();
                gridView1.UpdateCurrentRow();
                trBarcodeOperationLinesBindingSource.EndEdit();
                trBarcodeOperationHeaderBindingSource.EndEdit();

                // ən sağlamı: yenidən DB-dən Include ilə çək, sonra sil
                var header = dbContext.TrBarcodeOperationHeaders
                    .Include(x => x.TrBarcodeOperationLines)
                    .Single(x => x.Id == trBarcodeOperationHeader.Id);

                // sonra header sil
                dbContext.TrBarcodeOperationHeaders.Remove(header);

                dbContext.SaveChanges();

                // Siləndən sonra yeni boş sənəd aç
                CreateNewHeader();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Delete Error");
            }
            finally
            {
                _isSaving = false;
            }
        }


        private void EnsureHeaderSaved()
        {
            if (trBarcodeOperationHeader == null) return;

            // new header not saved?
            if (trBarcodeOperationHeader.Id == 0)
            {
                dbContext.TrBarcodeOperationHeaders.Add(trBarcodeOperationHeader);
                dbContext.SaveChanges();
            }
        }

        private void SaveHeader()
        {
            if (_isLoading || _isSaving) return;

            try
            {
                _isSaving = true;

                trBarcodeOperationHeaderBindingSource.EndEdit();
                EnsureHeaderSaved();

                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Save Header Error");
            }
            finally
            {
                _isSaving = false;
            }
        }

        private void SaveAll()
        {
            if (_isLoading || _isSaving) return;

            try
            {
                _isSaving = true;

                gridView1.CloseEditor();
                gridView1.UpdateCurrentRow();
                trBarcodeOperationLinesBindingSource.EndEdit();
                trBarcodeOperationHeaderBindingSource.EndEdit();

                // ən azı 1 line yoxdursa DB-yə yazma
                var hasAnyLine = trBarcodeOperationHeader?.TrBarcodeOperationLines?
                    .Any(l => dbContext.Entry(l).State != EntityState.Deleted) == true;

                if (!hasAnyLine)
                    return;

                dbContext.SaveChanges(); // burada EF: əvvəl Header insert, sonra Lines insert
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Save Error");
            }
            finally
            {
                _isSaving = false;
            }
        }

    }
}
