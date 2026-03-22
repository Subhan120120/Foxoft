using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Foxoft.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Foxoft
{
    public partial class FormCampaign : XtraForm
    {
        private subContext dbContext;
        private EfMethods efMethods = new();
        private Guid? campaignId;

        public DcCampaign dcCampaign = new();

        public FormCampaign()
        {
            InitializeComponent();

            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;
        }

        public FormCampaign(Guid campaignId)
            : this()
        {
            this.campaignId = campaignId;
        }

        private void FormCampaign_Load(object sender, EventArgs e)
        {
            LoadLookups();
            LoadCampaign();
        }

        private void LoadLookups()
        {
            using subContext lookUpDb = new();

            repoLUE_ProductCode.DataSource = lookUpDb.DcProducts.AsNoTracking().ToList();
            repoLUE_ProductCode.DisplayMember = nameof(DcProduct.ProductCode);
            repoLUE_ProductCode.ValueMember = nameof(DcProduct.ProductCode);
            repoLUE_ProductCode.NullText = "";

            repoLUE_CustomerCode.DataSource = lookUpDb.DcCurrAccs.AsNoTracking().ToList();
            repoLUE_CustomerCode.DisplayMember = nameof(DcCurrAcc.CurrAccCode);
            repoLUE_CustomerCode.ValueMember = nameof(DcCurrAcc.CurrAccCode);
            repoLUE_CustomerCode.NullText = "";

            repoLUE_CategoryCode.DataSource = lookUpDb.DcHierarchies.AsNoTracking().ToList();
            repoLUE_CategoryCode.DisplayMember = nameof(DcHierarchy.HierarchyCode);
            repoLUE_CategoryCode.ValueMember = nameof(DcHierarchy.HierarchyCode);
            repoLUE_CategoryCode.NullText = "";

            repoLUE_StoreCode.DataSource = efMethods.SelectStores();
            repoLUE_StoreCode.DisplayMember = "StoreCode";
            repoLUE_StoreCode.ValueMember = "StoreCode";
            repoLUE_StoreCode.NullText = "";

            repoLUE_WarehouseCode.DataSource = lookUpDb.DcWarehouses.AsNoTracking().ToList();
            repoLUE_WarehouseCode.DisplayMember = nameof(DcWarehouse.WarehouseCode);
            repoLUE_WarehouseCode.ValueMember = nameof(DcWarehouse.WarehouseCode);
            repoLUE_WarehouseCode.NullText = "";

            repoLUE_PaymentMethod.DataSource = lookUpDb.DcPaymentMethods.AsNoTracking().ToList();
            repoLUE_PaymentMethod.DisplayMember = nameof(DcPaymentMethod.PaymentMethodDesc);
            repoLUE_PaymentMethod.ValueMember = nameof(DcPaymentMethod.PaymentMethodId);
            repoLUE_PaymentMethod.NullText = "";

            CampaignTypeCodeComboBoxEdit.Properties.Items.Clear();
            CampaignTypeCodeComboBoxEdit.Properties.Items.AddRange(new object[]
            {
                CampaignTypeCode.Standard,
                CampaignTypeCode.PromoCode,
                CampaignTypeCode.CategoryDiscount,
                CampaignTypeCode.PaymentMethodCampaign
            });

            DiscountTypeCodeComboBoxEdit.Properties.Items.Clear();
            DiscountTypeCodeComboBoxEdit.Properties.Items.AddRange(new object[]
            {
                DiscountTypeCode.Percent,
                DiscountTypeCode.Amount
            });
        }

        private void LoadCampaign()
        {
            dbContext = new subContext();

            if (campaignId.HasValue)
            {
                dbContext.DcCampaigns.Where(x => x.CampaignId == campaignId.Value).Load();
                dbContext.TrCampaignProducts.Where(x => x.CampaignId == campaignId.Value).Load();
                dbContext.TrCampaignCategories.Where(x => x.CampaignId == campaignId.Value).Load();
                dbContext.TrCampaignCustomers.Where(x => x.CampaignId == campaignId.Value).Load();
                dbContext.TrCampaignStores.Where(x => x.CampaignId == campaignId.Value).Load();
                dbContext.TrCampaignWarehouses.Where(x => x.CampaignId == campaignId.Value).Load();
                dbContext.TrCampaignPaymentMethods.Where(x => x.CampaignId == campaignId.Value).Load();

                dcCampaignsBindingSource.DataSource = dbContext.DcCampaigns.Local.ToBindingList();
                dcCampaign = dcCampaignsBindingSource.Current as DcCampaign ?? new DcCampaign();

                CampaignCodeTextEdit.Properties.ReadOnly = true;
                CampaignCodeTextEdit.Properties.Appearance.BackColor = Color.LightGray;
            }
            else
            {
                dcCampaignsBindingSource.DataSource = dbContext.DcCampaigns.Local.ToBindingList();
                dcCampaign = dcCampaignsBindingSource.AddNew() as DcCampaign ?? new DcCampaign();
                dcCampaign.CampaignId = Guid.NewGuid();
                dcCampaign.CampaignCode = efMethods.GetNextDocNum(true, "CP", nameof(DcCampaign.CampaignCode), nameof(subContext.DcCampaigns), 4);
                dcCampaign.StartDate = DateTime.Today;
                dcCampaign.EndDate = DateTime.Today.AddMonths(1);
                dcCampaign.IsActive = true;
                dcCampaign.DiscountTypeCode = DiscountTypeCode.Percent;
                dcCampaign.CampaignTypeCode = CampaignTypeCode.Standard;
                dcCampaign.Priority = 100;
                dcCampaign.CreatedUserName = Authorization.CurrAccCode;
            }

            BindMainControls();
            BindChildSources();
        }

        private void BindMainControls()
        {
            CampaignCodeTextEdit.DataBindings.Clear();
            CampaignDescTextEdit.DataBindings.Clear();
            CampaignTypeCodeComboBoxEdit.DataBindings.Clear();
            PromoCodeTextEdit.DataBindings.Clear();
            DiscountTypeCodeComboBoxEdit.DataBindings.Clear();
            DiscountValueCalcEdit.DataBindings.Clear();
            PrioritySpinEdit.DataBindings.Clear();
            IsActiveCheckEdit.DataBindings.Clear();
            IsCombinableCheckEdit.DataBindings.Clear();
            StartDateDateEdit.DataBindings.Clear();
            EndDateDateEdit.DataBindings.Clear();
            MinInvoiceAmountCalcEdit.DataBindings.Clear();
            MaxDiscountAmountCalcEdit.DataBindings.Clear();
            NoteMemoEdit.DataBindings.Clear();

            CampaignCodeTextEdit.DataBindings.Add("EditValue", dcCampaignsBindingSource, nameof(DcCampaign.CampaignCode), true, DataSourceUpdateMode.OnPropertyChanged);
            CampaignDescTextEdit.DataBindings.Add("EditValue", dcCampaignsBindingSource, nameof(DcCampaign.CampaignDesc), true, DataSourceUpdateMode.OnPropertyChanged);
            CampaignTypeCodeComboBoxEdit.DataBindings.Add("EditValue", dcCampaignsBindingSource, nameof(DcCampaign.CampaignTypeCode), true, DataSourceUpdateMode.OnPropertyChanged);
            PromoCodeTextEdit.DataBindings.Add("EditValue", dcCampaignsBindingSource, nameof(DcCampaign.PromoCode), true, DataSourceUpdateMode.OnPropertyChanged);
            DiscountTypeCodeComboBoxEdit.DataBindings.Add("EditValue", dcCampaignsBindingSource, nameof(DcCampaign.DiscountTypeCode), true, DataSourceUpdateMode.OnPropertyChanged);
            DiscountValueCalcEdit.DataBindings.Add("EditValue", dcCampaignsBindingSource, nameof(DcCampaign.DiscountValue), true, DataSourceUpdateMode.OnPropertyChanged);
            PrioritySpinEdit.DataBindings.Add("EditValue", dcCampaignsBindingSource, nameof(DcCampaign.Priority), true, DataSourceUpdateMode.OnPropertyChanged);
            IsActiveCheckEdit.DataBindings.Add("EditValue", dcCampaignsBindingSource, nameof(DcCampaign.IsActive), true, DataSourceUpdateMode.OnPropertyChanged);
            IsCombinableCheckEdit.DataBindings.Add("EditValue", dcCampaignsBindingSource, nameof(DcCampaign.IsCombinable), true, DataSourceUpdateMode.OnPropertyChanged);
            StartDateDateEdit.DataBindings.Add("EditValue", dcCampaignsBindingSource, nameof(DcCampaign.StartDate), true, DataSourceUpdateMode.OnPropertyChanged);
            EndDateDateEdit.DataBindings.Add("EditValue", dcCampaignsBindingSource, nameof(DcCampaign.EndDate), true, DataSourceUpdateMode.OnPropertyChanged);
            MinInvoiceAmountCalcEdit.DataBindings.Add("EditValue", dcCampaignsBindingSource, nameof(DcCampaign.MinInvoiceAmount), true, DataSourceUpdateMode.OnPropertyChanged);
            MaxDiscountAmountCalcEdit.DataBindings.Add("EditValue", dcCampaignsBindingSource, nameof(DcCampaign.MaxDiscountAmount), true, DataSourceUpdateMode.OnPropertyChanged);
            NoteMemoEdit.DataBindings.Add("EditValue", dcCampaignsBindingSource, nameof(DcCampaign.Note), true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void BindChildSources()
        {
            trCampaignProductsBindingSource.DataSource = dbContext.TrCampaignProducts.Local.ToBindingList();
            trCampaignCategoriesBindingSource.DataSource = dbContext.TrCampaignCategories.Local.ToBindingList();
            trCampaignCustomersBindingSource.DataSource = dbContext.TrCampaignCustomers.Local.ToBindingList();
            trCampaignStoresBindingSource.DataSource = dbContext.TrCampaignStores.Local.ToBindingList();
            trCampaignWarehousesBindingSource.DataSource = dbContext.TrCampaignWarehouses.Local.ToBindingList();
            trCampaignPaymentMethodsBindingSource.DataSource = dbContext.TrCampaignPaymentMethods.Local.ToBindingList();
        }

        private bool ValidateCampaign()
        {
            if (string.IsNullOrWhiteSpace(CampaignCodeTextEdit.Text))
            {
                XtraMessageBox.Show("Kampaniya kodu daxil edilməyib.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(CampaignDescTextEdit.Text))
            {
                XtraMessageBox.Show("Kampaniya adı daxil edilməyib.");
                return false;
            }

            if (StartDateDateEdit.DateTime.Date > EndDateDateEdit.DateTime.Date)
            {
                XtraMessageBox.Show("Başlama tarixi bitmə tarixindən böyük ola bilməz.");
                return false;
            }

            return true;
        }

        private void RemoveInvalidRows()
        {
            RemoveInvalidProducts();
            RemoveInvalidCategories();
            RemoveInvalidCustomers();
            RemoveInvalidStores();
            RemoveInvalidWarehouses();
            RemoveInvalidPaymentMethods();
        }

        private void RemoveInvalidProducts()
        {
            foreach (TrCampaignProduct item in dbContext.TrCampaignProducts.Local.Where(x => string.IsNullOrWhiteSpace(x.ProductCode)).ToList())
                dbContext.TrCampaignProducts.Remove(item);
        }

        private void RemoveInvalidCategories()
        {
            foreach (TrCampaignCategory item in dbContext.TrCampaignCategories.Local.Where(x => string.IsNullOrWhiteSpace(x.HierarchyCode)).ToList())
                dbContext.TrCampaignCategories.Remove(item);
        }

        private void RemoveInvalidCustomers()
        {
            foreach (TrCampaignCustomer item in dbContext.TrCampaignCustomers.Local.Where(x => string.IsNullOrWhiteSpace(x.CurrAccCode)).ToList())
                dbContext.TrCampaignCustomers.Remove(item);
        }

        private void RemoveInvalidStores()
        {
            foreach (TrCampaignStore item in dbContext.TrCampaignStores.Local.Where(x => string.IsNullOrWhiteSpace(x.StoreCode)).ToList())
                dbContext.TrCampaignStores.Remove(item);
        }

        private void RemoveInvalidWarehouses()
        {
            foreach (TrCampaignWarehouse item in dbContext.TrCampaignWarehouses.Local.Where(x => string.IsNullOrWhiteSpace(x.WarehouseCode)).ToList())
                dbContext.TrCampaignWarehouses.Remove(item);
        }

        private void RemoveInvalidPaymentMethods()
        {
            foreach (TrCampaignPaymentMethod item in dbContext.TrCampaignPaymentMethods.Local.Where(x => x.PaymentMethodId <= 0).ToList())
                dbContext.TrCampaignPaymentMethods.Remove(item);
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (!ValidateCampaign())
                return;

            dcCampaignsBindingSource.EndEdit();
            trCampaignProductsBindingSource.EndEdit();
            trCampaignCategoriesBindingSource.EndEdit();
            trCampaignCustomersBindingSource.EndEdit();
            trCampaignStoresBindingSource.EndEdit();
            trCampaignWarehousesBindingSource.EndEdit();
            trCampaignPaymentMethodsBindingSource.EndEdit();

            RemoveInvalidRows();

            dbContext.SaveChanges(Authorization.CurrAccCode);

            DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void trCampaignProductsBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new TrCampaignProduct
            {
                CampaignProductId = Guid.NewGuid(),
                CampaignId = dcCampaign.CampaignId
            };
        }

        private void trCampaignCategoriesBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new TrCampaignCategory
            {
                CampaignCategoryId = Guid.NewGuid(),
                CampaignId = dcCampaign.CampaignId
            };
        }

        private void trCampaignCustomersBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new TrCampaignCustomer
            {
                CampaignCustomerId = Guid.NewGuid(),
                CampaignId = dcCampaign.CampaignId
            };
        }

        private void trCampaignStoresBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new TrCampaignStore
            {
                CampaignStoreId = Guid.NewGuid(),
                CampaignId = dcCampaign.CampaignId
            };
        }

        private void trCampaignWarehousesBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new TrCampaignWarehouse
            {
                CampaignWarehouseId = Guid.NewGuid(),
                CampaignId = dcCampaign.CampaignId
            };
        }

        private void trCampaignPaymentMethodsBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new TrCampaignPaymentMethod
            {
                CampaignPaymentMethodId = Guid.NewGuid(),
                CampaignId = dcCampaign.CampaignId
            };
        }

        private static void DeleteFocusedRow(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            if (gridView.FocusedRowHandle >= 0)
                gridView.DeleteRow(gridView.FocusedRowHandle);
        }

        private void btnAddProduct_Click(object sender, EventArgs e) => trCampaignProductsBindingSource.AddNew();
        private void btnDeleteProduct_Click(object sender, EventArgs e) => DeleteFocusedRow(gV_Product);
        private void btnAddCategory_Click(object sender, EventArgs e) => trCampaignCategoriesBindingSource.AddNew();
        private void btnDeleteCategory_Click(object sender, EventArgs e) => DeleteFocusedRow(gV_Category);
        private void btnAddCustomer_Click(object sender, EventArgs e) => trCampaignCustomersBindingSource.AddNew();
        private void btnDeleteCustomer_Click(object sender, EventArgs e) => DeleteFocusedRow(gV_Customer);
        private void btnAddStore_Click(object sender, EventArgs e) => trCampaignStoresBindingSource.AddNew();
        private void btnDeleteStore_Click(object sender, EventArgs e) => DeleteFocusedRow(gV_Store);
        private void btnAddWarehouse_Click(object sender, EventArgs e) => trCampaignWarehousesBindingSource.AddNew();
        private void btnDeleteWarehouse_Click(object sender, EventArgs e) => DeleteFocusedRow(gV_Warehouse);
        private void btnAddPaymentMethod_Click(object sender, EventArgs e) => trCampaignPaymentMethodsBindingSource.AddNew();
        private void btnDeletePaymentMethod_Click(object sender, EventArgs e) => DeleteFocusedRow(gV_PaymentMethod);
    }
}