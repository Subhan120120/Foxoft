using DevExpress.DataAccess.Excel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Text;

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

            InitializeImportButtons();
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

            colProductCode.ColumnEdit = gC_Product.AddProductCodeButtonEdit();

            colCurrAccCode.ColumnEdit = gC_Product.AddCurrAccCodeButtonEdit();

            colHierarchyCode.ColumnEdit = gC_Product.AddHierarchyCodeButtonEdit();

            colStoreCode.ColumnEdit = gC_Product.AddStoreCodeLookUpEdit();

            colWarehouseCode.ColumnEdit = gC_Product.AddWarehouseCodeButtonEdit();

            colPaymentMethodId.ColumnEdit = gC_Product.AddPaymentMethodButtonEdit();

            //CampaignTypeCodeComboBoxEdit.Properties.Items.Clear();
            //CampaignTypeCodeComboBoxEdit.Properties.Items.AddRange(new object[]
            //{
            //    CampaignTypeCode.Standard,
            //    CampaignTypeCode.PromoCode,
            //    CampaignTypeCode.CategoryDiscount,
            //    CampaignTypeCode.PaymentMethodCampaign
            //});

            DiscountTypeCodeComboBoxEdit.Properties.Items.Clear();
            DiscountTypeCodeComboBoxEdit.Properties.Items.AddRange(new object[]
            {
                DiscountTypeCode.Percent,
                DiscountTypeCode.Amount
            });

            LUE_processCode.Properties.DataSource = efMethods.SelectEntities<DcProcess>();
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
                //dcCampaign.CampaignTypeCode = CampaignTypeCode.Standard;
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
            PromoCodeTextEdit.DataBindings.Clear();
            CampaignPasswordTextEdit.DataBindings.Clear();
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
            PromoCodeTextEdit.DataBindings.Add("EditValue", dcCampaignsBindingSource, nameof(DcCampaign.PromoCode), true, DataSourceUpdateMode.OnPropertyChanged);
            CampaignPasswordTextEdit.DataBindings.Add("EditValue", dcCampaignsBindingSource, nameof(DcCampaign.CampaignPassword), true, DataSourceUpdateMode.OnPropertyChanged);
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
            LUE_processCode.DataBindings.Add("EditValue", dcCampaignsBindingSource, nameof(DcCampaign.ProcessCode), true, DataSourceUpdateMode.OnPropertyChanged);
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

        private static void DeleteFocusedRow(GridView gridView)
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

        private void gV_Product_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == $"{nameof(DcProduct)}.{nameof(DcProduct.ProductDesc)}" && e.IsGetData)
            {
                GridView view = sender as GridView;
                int rowInd = view.GetRowHandle(e.ListSourceRowIndex);
                string productCode = view.GetRowCellValue(rowInd, colProductCode) as string ?? string.Empty;

                DcProduct dcProduct = efMethods.SelectProduct(productCode, new byte[] { 1 });

                e.Value = dcProduct?.ProductDesc;
            }
        }

        private void gV_Customer_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == $"{nameof(DcCurrAcc)}.{nameof(DcCurrAcc.CurrAccDesc)}" && e.IsGetData)
            {
                GridView view = sender as GridView;
                int rowInd = view.GetRowHandle(e.ListSourceRowIndex);
                string currAccCode = view.GetRowCellValue(rowInd, colCurrAccCode) as string ?? string.Empty;
                DcCurrAcc dcCurrAcc = efMethods.SelectCurrAcc(currAccCode);
                e.Value = dcCurrAcc?.CurrAccDesc;
            }
        }

        private void gV_PaymentMethod_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == $"{nameof(DcPaymentMethod)}.{nameof(DcPaymentMethod.PaymentMethodDesc)}" && e.IsGetData)
            {
                GridView view = sender as GridView;
                int rowInd = view.GetRowHandle(e.ListSourceRowIndex);
                int paymentMethodId = Convert.ToInt32(view.GetRowCellValue(rowInd, colPaymentMethodId));
                DcPaymentMethod dcPaymentMethod = efMethods.SelectEntityById<DcPaymentMethod>(paymentMethodId);
                e.Value = dcPaymentMethod?.PaymentMethodDesc;
            }
        }

        private sealed class ImportResult
        {
            public int AddedCount { get; set; }
            public int SkippedCount { get; set; }
            public int EmptyCount { get; set; }
            public StringBuilder Errors { get; } = new();
        }

        private void InitializeImportButtons()
        {
            AddImportButton(panelProduct, btnDeleteProduct, "btnImportProduct", btnImportProduct_Click);
            AddImportButton(panelCategory, btnDeleteCategory, "btnImportCategory", btnImportCategory_Click);
            AddImportButton(panelCustomer, btnDeleteCustomer, "btnImportCustomer", btnImportCustomer_Click);
            AddImportButton(panelStore, btnDeleteStore, "btnImportStore", btnImportStore_Click);
            AddImportButton(panelWarehouse, btnDeleteWarehouse, "btnImportWarehouse", btnImportWarehouse_Click);
            AddImportButton(panelPaymentMethod, btnDeletePaymentMethod, "btnImportPaymentMethod", btnImportPaymentMethod_Click);
        }

        private static void AddImportButton(PanelControl panel, SimpleButton anchorButton, string buttonName, EventHandler clickHandler)
        {
            SimpleButton btnImport = new()
            {
                Name = buttonName,
                Text = "Excel-dən import",
                Size = new Size(140, 24),
                Location = new Point(anchorButton.Right + 8, anchorButton.Top)
            };

            btnImport.Click += clickHandler;
            panel.Controls.Add(btnImport);
            btnImport.BringToFront();
        }

        private void btnImportProduct_Click(object sender, EventArgs e) => ImportProductsFromExcel();
        private void btnImportCategory_Click(object sender, EventArgs e) => ImportCategoriesFromExcel();
        private void btnImportCustomer_Click(object sender, EventArgs e) => ImportCustomersFromExcel();
        private void btnImportStore_Click(object sender, EventArgs e) => ImportStoresFromExcel();
        private void btnImportWarehouse_Click(object sender, EventArgs e) => ImportWarehousesFromExcel();
        private void btnImportPaymentMethod_Click(object sender, EventArgs e) => ImportPaymentMethodsFromExcel();

        private void ImportProductsFromExcel()
        {
            HashSet<string> existingValues = dbContext.TrCampaignProducts.Local
                .Where(x => x.CampaignId == dcCampaign.CampaignId && !string.IsNullOrWhiteSpace(x.ProductCode))
                .Select(x => x.ProductCode.Trim())
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            ImportFromExcel(
                gV_Product,
                new[] { colProductCode.Caption, nameof(TrCampaignProduct.ProductCode), "ProductCode", "Məhsul" },
                (lookUpDb, rawValue, result) =>
                {
                    string productCode = rawValue.Trim();

                    bool masterExists = lookUpDb.DcProducts
                        .AsNoTracking()
                        .Any(x => x.ProductCode == productCode);

                    if (!masterExists)
                    {
                        result.Errors.AppendLine($"{colProductCode.Caption}: {productCode}");
                        return;
                    }

                    if (!existingValues.Add(productCode))
                    {
                        result.SkippedCount++;
                        return;
                    }

                    dbContext.TrCampaignProducts.Add(new TrCampaignProduct
                    {
                        CampaignProductId = Guid.NewGuid(),
                        CampaignId = dcCampaign.CampaignId,
                        ProductCode = productCode
                    });

                    result.AddedCount++;
                });
        }

        private void ImportCategoriesFromExcel()
        {
            HashSet<string> existingValues = dbContext.TrCampaignCategories.Local
                .Where(x => x.CampaignId == dcCampaign.CampaignId && !string.IsNullOrWhiteSpace(x.HierarchyCode))
                .Select(x => x.HierarchyCode.Trim())
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            ImportFromExcel(
                gV_Category,
                new[] { colHierarchyCode.Caption, nameof(TrCampaignCategory.HierarchyCode), "HierarchyCode", "Kateqoriya" },
                (lookUpDb, rawValue, result) =>
                {
                    string hierarchyCode = rawValue.Trim();

                    bool masterExists = lookUpDb.DcHierarchies
                        .AsNoTracking()
                        .Any(x => x.HierarchyCode == hierarchyCode);

                    if (!masterExists)
                    {
                        result.Errors.AppendLine($"{colHierarchyCode.Caption}: {hierarchyCode}");
                        return;
                    }

                    if (!existingValues.Add(hierarchyCode))
                    {
                        result.SkippedCount++;
                        return;
                    }

                    dbContext.TrCampaignCategories.Add(new TrCampaignCategory
                    {
                        CampaignCategoryId = Guid.NewGuid(),
                        CampaignId = dcCampaign.CampaignId,
                        HierarchyCode = hierarchyCode
                    });

                    result.AddedCount++;
                });
        }

        private void ImportCustomersFromExcel()
        {
            HashSet<string> existingValues = dbContext.TrCampaignCustomers.Local
                .Where(x => x.CampaignId == dcCampaign.CampaignId && !string.IsNullOrWhiteSpace(x.CurrAccCode))
                .Select(x => x.CurrAccCode.Trim())
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            ImportFromExcel(
                gV_Customer,
                new[] { colCurrAccCode.Caption, nameof(TrCampaignCustomer.CurrAccCode), "CurrAccCode", "Müştəri" },
                (lookUpDb, rawValue, result) =>
                {
                    string currAccCode = rawValue.Trim();

                    bool masterExists = lookUpDb.DcCurrAccs
                        .AsNoTracking()
                        .Any(x => x.CurrAccCode == currAccCode);

                    if (!masterExists)
                    {
                        result.Errors.AppendLine($"{colCurrAccCode.Caption}: {currAccCode}");
                        return;
                    }

                    if (!existingValues.Add(currAccCode))
                    {
                        result.SkippedCount++;
                        return;
                    }

                    dbContext.TrCampaignCustomers.Add(new TrCampaignCustomer
                    {
                        CampaignCustomerId = Guid.NewGuid(),
                        CampaignId = dcCampaign.CampaignId,
                        CurrAccCode = currAccCode
                    });

                    result.AddedCount++;
                });
        }

        private void ImportStoresFromExcel()
        {
            HashSet<string> existingValues = dbContext.TrCampaignStores.Local
                .Where(x => x.CampaignId == dcCampaign.CampaignId && !string.IsNullOrWhiteSpace(x.StoreCode))
                .Select(x => x.StoreCode.Trim())
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            ImportFromExcel(
                gV_Store,
                new[] { colStoreCode.Caption, nameof(TrCampaignStore.StoreCode), "StoreCode", "Store" },
                (lookUpDb, rawValue, result) =>
                {
                    string storeCode = rawValue.Trim();

                    bool masterExists = lookUpDb.SettingStores
                        .AsNoTracking()
                        .Any(x => x.StoreCode == storeCode);

                    if (!masterExists)
                    {
                        result.Errors.AppendLine($"{colStoreCode.Caption}: {storeCode}");
                        return;
                    }

                    if (!existingValues.Add(storeCode))
                    {
                        result.SkippedCount++;
                        return;
                    }

                    dbContext.TrCampaignStores.Add(new TrCampaignStore
                    {
                        CampaignStoreId = Guid.NewGuid(),
                        CampaignId = dcCampaign.CampaignId,
                        StoreCode = storeCode
                    });

                    result.AddedCount++;
                });
        }

        private void ImportWarehousesFromExcel()
        {
            HashSet<string> existingValues = dbContext.TrCampaignWarehouses.Local
                .Where(x => x.CampaignId == dcCampaign.CampaignId && !string.IsNullOrWhiteSpace(x.WarehouseCode))
                .Select(x => x.WarehouseCode.Trim())
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            ImportFromExcel(
                gV_Warehouse,
                new[] { colWarehouseCode.Caption, nameof(TrCampaignWarehouse.WarehouseCode), "WarehouseCode", "Depo" },
                (lookUpDb, rawValue, result) =>
                {
                    string warehouseCode = rawValue.Trim();

                    bool masterExists = lookUpDb.DcWarehouses
                        .AsNoTracking()
                        .Any(x => x.WarehouseCode == warehouseCode);

                    if (!masterExists)
                    {
                        result.Errors.AppendLine($"{colWarehouseCode.Caption}: {warehouseCode}");
                        return;
                    }

                    if (!existingValues.Add(warehouseCode))
                    {
                        result.SkippedCount++;
                        return;
                    }

                    dbContext.TrCampaignWarehouses.Add(new TrCampaignWarehouse
                    {
                        CampaignWarehouseId = Guid.NewGuid(),
                        CampaignId = dcCampaign.CampaignId,
                        WarehouseCode = warehouseCode
                    });

                    result.AddedCount++;
                });
        }

        private void ImportPaymentMethodsFromExcel()
        {
            HashSet<int> existingValues = dbContext.TrCampaignPaymentMethods.Local
                .Where(x => x.CampaignId == dcCampaign.CampaignId && x.PaymentMethodId > 0)
                .Select(x => x.PaymentMethodId)
                .ToHashSet();

            ImportFromExcel(
                gV_PaymentMethod,
                new[] { colPaymentMethodId.Caption, nameof(TrCampaignPaymentMethod.PaymentMethodId), "PaymentMethodId", "Ödəmə üsulu" },
                (lookUpDb, rawValue, result) =>
                {
                    DcPaymentMethod paymentMethod = null;

                    if (int.TryParse(rawValue, NumberStyles.Integer, CultureInfo.InvariantCulture, out int paymentMethodId))
                    {
                        paymentMethod = lookUpDb.DcPaymentMethods
                            .AsNoTracking()
                            .FirstOrDefault(x => x.PaymentMethodId == paymentMethodId);
                    }

                    paymentMethod ??= lookUpDb.DcPaymentMethods
                        .AsNoTracking()
                        .FirstOrDefault(x => x.PaymentMethodDesc == rawValue);

                    if (paymentMethod is null)
                    {
                        result.Errors.AppendLine($"{colPaymentMethodId.Caption}: {rawValue}");
                        return;
                    }

                    if (!existingValues.Add(paymentMethod.PaymentMethodId))
                    {
                        result.SkippedCount++;
                        return;
                    }

                    dbContext.TrCampaignPaymentMethods.Add(new TrCampaignPaymentMethod
                    {
                        CampaignPaymentMethodId = Guid.NewGuid(),
                        CampaignId = dcCampaign.CampaignId,
                        PaymentMethodId = paymentMethod.PaymentMethodId
                    });

                    result.AddedCount++;
                });
        }

        private void ImportFromExcel(
            GridView gridView,
            string[] columnAliases,
            Action<subContext, string, ImportResult> importAction)
        {
            OpenFileDialog dialog = new()
            {
                Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|All files (*.*)|*.*",
                Title = "Excel faylı seçin."
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);

            try
            {
                ExcelDataSource excelDataSource = new();
                excelDataSource.FileName = dialog.FileName;

                ExcelWorksheetSettings excelWorksheetSettings = new(0);

                ExcelSourceOptions excelOptions = new();
                excelOptions.ImportSettings = excelWorksheetSettings;
                excelOptions.SkipHiddenRows = false;
                excelOptions.SkipHiddenColumns = false;
                excelOptions.UseFirstRowAsHeader = true;

                excelDataSource.SourceOptions = excelOptions;
                excelDataSource.Fill();

                DataTable dt = ToDataTableFromExcelDataSource(excelDataSource);

                if (dt.Rows.Count == 0)
                {
                    XtraMessageBox.Show("Excel faylında import ediləcək məlumat tapılmadı.");
                    return;
                }

                string columnName = ResolveColumnName(dt, columnAliases);
                if (string.IsNullOrWhiteSpace(columnName))
                {
                    XtraMessageBox.Show("Excel faylında uyğun sütun tapılmadı.");
                    return;
                }

                gridView.GridControl.BeginUpdate();
                gridView.BeginUpdate();

                try
                {
                    ImportResult result = new();
                    using subContext lookUpDb = new();

                    double rowCount = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        int progress = Convert.ToInt32(rowCount / dt.Rows.Count * 100);
                        SplashScreenManager.Default.SendCommand(WaitForm.WaitFormCommand.SetProgress, progress);
                        SplashScreenManager.Default.SetWaitFormDescription(progress + "%");
                        rowCount++;

                        string rawValue = row[columnName]?.ToString()?.Trim() ?? string.Empty;

                        if (string.IsNullOrWhiteSpace(rawValue))
                        {
                            result.EmptyCount++;
                            continue;
                        }

                        importAction(lookUpDb, rawValue, result);
                    }

                    gridView.RefreshData();
                    gridView.BestFitColumns();

                    ShowImportResult(result);
                }
                finally
                {
                    gridView.EndUpdate();
                    gridView.GridControl.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Excel import zamanı xəta baş verdi.\n" + ex.Message, "Xəta");
            }
            finally
            {
                try
                {
                    SplashScreenManager.CloseForm(false);
                }
                catch
                {
                }
            }
        }

        private static string ResolveColumnName(DataTable dt, params string[] aliases)
        {
            foreach (string alias in aliases.Where(x => !string.IsNullOrWhiteSpace(x)))
            {
                DataColumn column = dt.Columns
                    .Cast<DataColumn>()
                    .FirstOrDefault(x => string.Equals(
                        x.ColumnName?.Trim(),
                        alias.Trim(),
                        StringComparison.OrdinalIgnoreCase));

                if (column is not null)
                    return column.ColumnName;
            }

            return dt.Columns.Count > 0 ? dt.Columns[0].ColumnName : string.Empty;
        }

        public DataTable ToDataTableFromExcelDataSource(ExcelDataSource excelDataSource)
        {
            IList list = ((IListSource)excelDataSource).GetList();
            DevExpress.DataAccess.Native.Excel.DataView dataView = (DevExpress.DataAccess.Native.Excel.DataView)list;
            List<PropertyDescriptor> props = dataView.Columns.ToList<PropertyDescriptor>();

            DataTable table = new();

            foreach (var prop in props)
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (DevExpress.DataAccess.Native.Excel.ViewRow item in list)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        private static void ShowImportResult(ImportResult result)
        {
            StringBuilder message = new();
            message.AppendLine($"Əlavə edildi: {result.AddedCount}");

            if (result.SkippedCount > 0)
                message.AppendLine($"Təkrara görə keçildi: {result.SkippedCount}");

            if (result.EmptyCount > 0)
                message.AppendLine($"Boş sətir: {result.EmptyCount}");

            if (result.Errors.Length > 0)
            {
                message.AppendLine();
                message.AppendLine("Aşağıdakı dəyərlər tapılmadı və ya uyğun gəlmədi:");
                message.AppendLine(result.Errors.ToString());
            }

            XtraMessageBox.Show(message.ToString(), "Excel import");
        }
    }
}