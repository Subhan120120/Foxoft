using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Foxoft
{
    public partial class FormWarehouse : XtraForm
    {
        subContext dbContext;
        EfMethods efMethods = new();

        public DcWarehouse dcWarehouse = new();

        public FormWarehouse()
        {
            InitializeComponent();

            OfficeCodeLookUpEdit.Properties.DataSource = efMethods.SelectOffices();
            StoreCodeLookUpEdit.Properties.DataSource = efMethods.SelectStores();

            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;
        }

        public FormWarehouse(string warehouseCode)
            : this()
        {
            dcWarehouse.WarehouseCode = warehouseCode;

            WarehouseCodeTextEdit.Properties.ReadOnly = true;
            WarehouseCodeTextEdit.Properties.Appearance.BackColor = Color.LightGray;
        }

        private void FormWarehouse_Load(object sender, System.EventArgs e)
        {
            LoadWarehouse();
            LoadLayout();

            dataLayoutControl1.IsValid(out List<string> errorList);
        }

        private void LoadWarehouse()
        {
            dbContext = new subContext();

            if (string.IsNullOrEmpty(dcWarehouse.WarehouseCode))
                ClearControlsAddNew();
            else
            {
                dbContext.DcWarehouses.Where(x => x.WarehouseCode == dcWarehouse.WarehouseCode).Load();
                dcWarehousesBindingSource.DataSource = dbContext.DcWarehouses.Local.ToBindingList();
            }
        }

        private void LoadLayout()
        {
            string fileName = "FormWarehouse.xml";
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
            dcWarehouse = dcWarehousesBindingSource.AddNew() as DcWarehouse;

            // Default-lar
            dcWarehouse.StoreCode = Authorization.StoreCode;
            dcWarehouse.OfficeCode = Authorization.OfficeCode;

            string newDocNum = efMethods.GetNextDocNum(true, "WH", nameof(DcWarehouse.WarehouseCode), nameof(subContext.DcWarehouses), 4);
            dcWarehouse.WarehouseCode = newDocNum;

            dcWarehousesBindingSource.DataSource = dcWarehouse;
            WarehouseDescTextEdit.Select();
        }

        private void dataLayoutControl1_FieldRetrieving(object sender, FieldRetrievingEventArgs e)
        {
            if (e.FieldName == "ModifiedDate")
            {
                e.Visible = false;
                e.Handled = true;
            }
        }

        private void btn_Ok_Click(object sender, System.EventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                dcWarehouse = dcWarehousesBindingSource.Current as DcWarehouse;

                if (!efMethods.EntityExists<DcWarehouse>(dcWarehouse.WarehouseCode))
                    efMethods.InsertEntity(dcWarehouse);
                else
                    dbContext.SaveChanges();

                DialogResult = DialogResult.OK;
            }
            else
            {
                string combined = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combined);
            }
        }

        private void btn_Cancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
