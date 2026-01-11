using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Foxoft.Migrations;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ServiceModel;

namespace Foxoft
{
    public partial class FormBarcodeOperations : RibbonForm
    {
        private TrBarcodeOperationHeader trBarcodeOperationHeader;
        private subContext dbContext;
        private int HeaderId;
        private EfMethods efMethods = new();
        public FormBarcodeOperations()
        {
            InitializeComponent();
            colProductCode.ColumnEdit = gridControl1.AddProductCodeButtonEdit();
            colBarcodeTypeCode.ColumnEdit = gridControl1.AddBarcodeTypeButtonEdit();

            ClearControlsAddNew();
        }

        public FormBarcodeOperations(int id)
            : this()
        {
            trBarcodeOperationHeader = efMethods.SelectEntityById<TrBarcodeOperationHeader>(id);

            if (trBarcodeOperationHeader is not null)
                LoadData(trBarcodeOperationHeader.Id);
        }

        private void FormBarcodeOperations_Load(object sender, EventArgs e)
        {

        }

        private void TrBarcodeOperationHeaderBindingSource_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
        {
            var header = new TrBarcodeOperationHeader
            {
                Name = "TrBarcodeOperationHeaders"
            };

            // EF context-ə qoş (tracking)
            dbContext.TrBarcodeOperationHeaders.Add(header);

            e.NewObject = header;
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


        private void LoadData(int id)
        {
            dbContext = new subContext();

            dbContext.TrBarcodeOperationHeaders
                                      .Where(x => x.Id == id)
                                      .Load();

            LocalView<TrBarcodeOperationHeader> lV_paymentHeader = dbContext.TrBarcodeOperationHeaders.Local;

            trBarcodeOperationHeaderBindingSource.DataSource = lV_paymentHeader.ToBindingList();
            trBarcodeOperationHeader = trBarcodeOperationHeaderBindingSource.Current as TrBarcodeOperationHeader;

            dbContext.TrBarcodeOperationLines.Where(x => x.BarcodeOperationHeaderId == id)
                                    .LoadAsync()
                                    .ContinueWith(loadTask =>
                                    {
                                        trBarcodeOperationLinesBindingSource.DataSource = dbContext.TrBarcodeOperationLines.Local.ToBindingList();
                                    }, TaskScheduler.FromCurrentSynchronizationContext());

            dataLayoutControl1.IsValid(out List<string> errorList);
        }


        private void GridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                SaveData();
            }
            else
            {
                string combinedString = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combinedString);
            }
        }

        private void SaveData()
        {
            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Resources.Form_PaymentDetail_InvalidData} \n \n {ex}");
            }
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
            gridView1.SetRowCellValue(e.RowHandle, colBarcodeOperationHeaderId, trBarcodeOperationHeader.Id);
            gridView1.SetRowCellValue(e.RowHandle, colBarcodeTypeCode, "EAN13");
        }

        private void BBI_New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearControlsAddNew();
        }

        private void TrBarcodeOperationHeaderBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            trBarcodeOperationHeader = trBarcodeOperationHeaderBindingSource.Current as TrBarcodeOperationHeader;

            if (trBarcodeOperationHeader != null && dbContext != null && dataLayoutControl1.IsValid(out List<string> errorList))
            {
                int count = efMethods.SelectBarcodeOperationLinesByHeaderId(trBarcodeOperationHeader.Id).Count;
                if (count > 0)
                    SaveData();
            }
        }

        private void BBI_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (efMethods.EntityExists<TrBarcodeOperationHeader>(trBarcodeOperationHeader.Id))
            {
                if (MessageBox.Show(Resources.Common_DeleteConfirm, Resources.Common_Attention, MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    efMethods.DeleteEntityById<TrBarcodeOperationHeader>(trBarcodeOperationHeader.Id);

                    ClearControlsAddNew();
                }
            }
            else
                XtraMessageBox.Show(Resources.Form_PaymentDetail_NoPaymentToDelete);
        }
    }
}
