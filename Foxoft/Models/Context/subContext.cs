using Microsoft.EntityFrameworkCore;
using Foxoft.AppCode;
using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;
using System.IO;
using Foxoft.Models.Entity.View_and_Procedur;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Foxoft.Models
{
    public partial class subContext : DbContext
    {
        public subContext() { }

        public subContext(DbContextOptions<subContext> options)
            : base(options) { }

        public DbSet<DcClaim> DcClaims { get; set; }
        public DbSet<dcClaimType> DcClaimTypes { get; set; }
        public DbSet<DcCurrAcc> DcCurrAccs { get; set; }
        public DbSet<DcCurrAccType> DcCurrAccTypes { get; set; }
        public DbSet<DcOffice> DcOffices { get; set; }
        public DbSet<DcPaymentType> DcPaymentTypes { get; set; }
        public DbSet<DcPaymentMethod> DcPaymentMethods { get; set; }
        public DbSet<DcProcess> DcProcesses { get; set; }
        public DbSet<DcProduct> DcProducts { get; set; }
        public DbSet<SiteProduct> SiteProducts { get; set; }
        public DbSet<TrProductBarcode> TrProductBarcodes { get; set; }
        public DbSet<DcDiscount> DcDiscounts { get; set; }
        public DbSet<TrProductDiscount> TrProductDiscounts { get; set; }
        public DbSet<DcProductType> DcProductTypes { get; set; }
        public DbSet<DcRole> DcRoles { get; set; }
        public DbSet<DcForm> DcForms { get; set; }
        public DbSet<TrFormReport> TrFormReports { get; set; }
        public DbSet<DcTerminal> DcTerminals { get; set; }
        public DbSet<DcWarehouse> DcWarehouses { get; set; }
        public DbSet<MigrationHistory> MigrationHistory { get; set; }
        public DbSet<TrCurrAccRole> TrCurrAccRoles { get; set; }
        public DbSet<Sysdiagrams> Sysdiagrams { get; set; }
        public DbSet<TrInvoiceHeader> TrInvoiceHeaders { get; set; }
        public DbSet<TrInvoiceLine> TrInvoiceLines { get; set; }
        public DbSet<TrPaymentHeader> TrPaymentHeaders { get; set; }
        public DbSet<TrPaymentLine> TrPaymentLines { get; set; }
        public DbSet<TrRoleClaim> TrRoleClaims { get; set; }
        public DbSet<DcReport> DcReports { get; set; }
        public DbSet<DcReportType> DcReportTypes { get; set; }
        public DbSet<DcReportFilter> DcReportFilters { get; set; }
        public DbSet<DcReportSubQuery> DcReportSubQueries { get; set; }
        public DbSet<DcQueryParam> DcQueryParams { get; set; }
        public DbSet<AppSetting> AppSettings { get; set; }
        public DbSet<SettingStore> SettingStores { get; set; }
        public DbSet<DcVariable> DcVariables { get; set; }
        public DbSet<TrPrice> TrPrices { get; set; }
        public DbSet<DcCurrency> DcCurrencies { get; set; }
        public DbSet<DcHierarchy> DcHierarchies { get; set; }
        public DbSet<TrProductHierarchy> TrProductHierarchies { get; set; }
        public DbSet<TrHierarchyFeature> TrHierarchyFeatures { get; set; }
        public DbSet<TrPaymentMethodDiscount> TrPaymentMethodDiscounts { get; set; }
        public DbSet<DcFeature> DcFeatures { get; set; }
        public DbSet<DcFeatureType> DcFeatureTypes { get; set; }
        public DbSet<TrProductFeature> TrProductFeatures { get; set; }
        public DbSet<DcPriceType> DcPriceTypes { get; set; }
        public DbSet<TrPriceListHeader> TrPriceListHeaders { get; set; }
        public DbSet<TrPriceListLine> TrPriceListLines { get; set; }
        public DbSet<RetailSale> RetailSales { get; set; } // view

        public virtual DbSet<SlugifyResult> Slugify { get; set; }

        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string subConnString = Properties.Settings.Default.subConnString;
                //string conf = config
                //                    .ConnectionStrings
                //                    .ConnectionStrings["subConnString"]
                //                    .ConnectionString;

                optionsBuilder.UseSqlServer(subConnString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //for DefaultValue Attribute for Entity propertires. Usage:
            // [DefaultValue("400")]
            // public int LengthInMeters { get; set; }
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (IMutableProperty property in entityType.GetProperties())
                {
                    MemberInfo memberInfo = property.PropertyInfo ?? (MemberInfo)property.FieldInfo;
                    if (memberInfo == null) continue;
                    DefaultValueAttribute defaultValue = Attribute.GetCustomAttribute(memberInfo, typeof(DefaultValueAttribute)) as DefaultValueAttribute;
                    if (defaultValue == null) continue;
                    property.SetDefaultValueSql(defaultValue.Value.ToString());
                }
            }

            //All foreignkeys DeleteBehavior to Restrict (NoAction)
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict; // NoAction
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RetailSale>() //view
                        .ToView(nameof(RetailSale));

            modelBuilder.Entity<GetNextDocNum>() //procedure
                        .HasNoKey();

            modelBuilder.Entity<SlugifyResult>()
                .HasNoKey()
                .ToView(nameof(SlugifyResult)); // function


            // more foreign key same table configure
            modelBuilder.Entity<TrPaymentHeader>(e =>
            {
                e.HasOne(field => field.ToCashReg)
             .WithMany(fk => fk.TrPaymentHeaderToCashes)
             .HasForeignKey(fk => fk.ToCashRegCode);
            });

            modelBuilder.Entity<DcCurrAcc>().HasData(
                new DcCurrAcc { CurrAccCode = "C-000001", CurrAccDesc = "Administrator", NewPassword = "123", PhoneNum = "0519678909", CurrAccTypeCode = 3, CreatedDate = new DateTime(1901, 01, 01), OfficeCode = "ofs01", StoreCode = "mgz01" },
                new DcCurrAcc { CurrAccCode = "C-000002", CurrAccDesc = "Mudir", LastName = "Mudir", NewPassword = "123", PhoneNum = "0519678909", CurrAccTypeCode = 3, CreatedDate = new DateTime(1901, 01, 01), OfficeCode = "ofs01", StoreCode = "mgz01" },
                new DcCurrAcc { CurrAccCode = "C-000003", CurrAccDesc = "Operator", LastName = "Operator", NewPassword = "123", PhoneNum = "0773628800", CurrAccTypeCode = 3, CreatedDate = new DateTime(1901, 01, 01), OfficeCode = "ofs01", StoreCode = "mgz01" },
                new DcCurrAcc { CurrAccCode = "C-000004", CurrAccDesc = "Satici", LastName = "Satici", NewPassword = "123", PhoneNum = "0553628804", CurrAccTypeCode = 3, CreatedDate = new DateTime(1901, 01, 01), OfficeCode = "ofs01", StoreCode = "mgz01" },
                new DcCurrAcc { CurrAccCode = "C-000005", CurrAccDesc = "Ümumi Müştəri", NewPassword = "123", CurrAccTypeCode = 1, CreatedDate = new DateTime(1901, 01, 01), IsDefault = true, OfficeCode = "ofs01", StoreCode = "mgz01" },
                new DcCurrAcc { CurrAccCode = "mgz01", CurrAccDesc = "Merkez Mağaza", NewPassword = "456", PhoneNum = "0773628800", CurrAccTypeCode = 4, CreatedDate = new DateTime(1901, 01, 01), OfficeCode = "ofs01", StoreCode = "mgz01" },
                new DcCurrAcc { CurrAccCode = "kassa01", CurrAccDesc = "Nağd Kassa", NewPassword = "456", CurrAccTypeCode = 5, CreatedDate = new DateTime(1901, 01, 01), IsDefault = true, OfficeCode = "ofs01", StoreCode = "mgz01" });

            modelBuilder.Entity<DcCurrAccType>().HasData(
                new DcCurrAccType { CurrAccTypeCode = 1, CurrAccTypeDesc = "Müştəri" },
                new DcCurrAccType { CurrAccTypeCode = 2, CurrAccTypeDesc = "Tədarikçi" },
                new DcCurrAccType { CurrAccTypeCode = 3, CurrAccTypeDesc = "Personal" },
                new DcCurrAccType { CurrAccTypeCode = 4, CurrAccTypeDesc = "Mağaza" },
                new DcCurrAccType { CurrAccTypeCode = 5, CurrAccTypeDesc = "Kassa" }
                );

            modelBuilder.Entity<DcClaim>().HasData(
                new DcClaim { ClaimCode = "ButunHesabatlar", ClaimDesc = "Butun Hesabatlar", ClaimTypeId = 2 },
                new DcClaim { ClaimCode = "CashRegs", ClaimDesc = "Kassalar", ClaimTypeId = 1 },
                new DcClaim { ClaimCode = "CashTransfer", ClaimDesc = "Pul Transferi", ClaimTypeId = 1 },
                new DcClaim { ClaimCode = "Column_LastPurchasePrice", ClaimDesc = "Son Alış Qiyməti", ClaimTypeId = 1 },
                new DcClaim { ClaimCode = "CountIn", ClaimDesc = "Sayım Artırma", ClaimTypeId = 1 },
                new DcClaim { ClaimCode = "CountOut", ClaimDesc = "Sayım Azaltma", ClaimTypeId = 1 },
                new DcClaim { ClaimCode = "CurrAccs", ClaimDesc = "Cari Hesablar", ClaimTypeId = 1 },
                new DcClaim { ClaimCode = "DiscountList", ClaimDesc = "Endirim Siyahısı", ClaimTypeId = 1 },
                new DcClaim { ClaimCode = "Expense", ClaimDesc = "Xərc", ClaimTypeId = 1 },
                new DcClaim { ClaimCode = "InventoryTransfer", ClaimDesc = "Mal Transferi", ClaimTypeId = 1 },
                new DcClaim { ClaimCode = "PaymentDetail", ClaimDesc = "Ödəmə", ClaimTypeId = 1 },
                new DcClaim { ClaimCode = "PosDiscount", ClaimDesc = "POS Endirimi", ClaimTypeId = 1 },
                new DcClaim { ClaimCode = "PriceList", ClaimDesc = "Qiymət Cədvəli", ClaimTypeId = 1 },
                new DcClaim { ClaimCode = "Products", ClaimDesc = "Məhsullar", ClaimTypeId = 1 },
                new DcClaim { ClaimCode = "PurchaseIsReturn", ClaimDesc = "Alışın Qaytarılması", ClaimTypeId = 1 },
                new DcClaim { ClaimCode = "ReportZet", ClaimDesc = "Gün Sonu Hesabatı", ClaimTypeId = 1 },
                new DcClaim { ClaimCode = "RetailPurchaseInvoice", ClaimDesc = "Alış Fakturası", ClaimTypeId = 1 },
                new DcClaim { ClaimCode = "RetailSaleInvoice", ClaimDesc = "Satış Fakturası", ClaimTypeId = 1 },
                new DcClaim { ClaimCode = "SaleIsReturn", ClaimDesc = "Satışın Qaytarılması", ClaimTypeId = 1 }
                );

            modelBuilder.Entity<dcClaimType>().HasData(
                new dcClaimType { ClaimTypeId = 1, ClaimTypeDesc = "Embaded" },
                new dcClaimType { ClaimTypeId = 2, ClaimTypeDesc = "Report" },
                new dcClaimType { ClaimTypeId = 3, ClaimTypeDesc = "Column" }
                );

            modelBuilder.Entity<SettingStore>().HasData(
               new SettingStore { Id = 1, StoreCode = "mgz01", DesignFileFolder = @"C:\Foxoft\Foxoft Design Files", ImageFolder = @"C:\Foxoft\Foxoft Images" }
                );

            modelBuilder.Entity<DcCurrency>().HasData(
                new DcCurrency { CurrencyCode = "AZN", CurrencyDesc = "₼ AZN", ExchangeRate = 1 },
                new DcCurrency { CurrencyCode = "USD", CurrencyDesc = "$ DOLLAR", ExchangeRate = 1.7f },
                new DcCurrency { CurrencyCode = "EUR", CurrencyDesc = "€ EURO", ExchangeRate = 1.67f }
                );

            modelBuilder.Entity<DcRole>().HasData(
                new DcRole { RoleCode = "Admin", RoleDesc = "Administrator" },
                new DcRole { RoleCode = "MGZ", RoleDesc = "Mağaza İstifadəçisi" }
                );

            modelBuilder.Entity<TrCurrAccRole>().HasData(
               new TrCurrAccRole { CurrAccRoleId = 1, CurrAccCode = "C-000001", RoleCode = "Admin" });

            modelBuilder.Entity<TrRoleClaim>().HasData(
                new TrRoleClaim { RoleClaimId = 1, RoleCode = "Admin", ClaimCode = "ButunHesabatlar" },
                new TrRoleClaim { RoleClaimId = 2, RoleCode = "Admin", ClaimCode = "CashRegs" },
                new TrRoleClaim { RoleClaimId = 3, RoleCode = "Admin", ClaimCode = "CashTransfer" },
                new TrRoleClaim { RoleClaimId = 4, RoleCode = "Admin", ClaimCode = "Column_LastPurchasePrice" },
                new TrRoleClaim { RoleClaimId = 5, RoleCode = "Admin", ClaimCode = "CountIn" },
                new TrRoleClaim { RoleClaimId = 6, RoleCode = "Admin", ClaimCode = "CountOut" },
                new TrRoleClaim { RoleClaimId = 7, RoleCode = "Admin", ClaimCode = "CurrAccs" },
                new TrRoleClaim { RoleClaimId = 8, RoleCode = "Admin", ClaimCode = "DiscountList" },
                new TrRoleClaim { RoleClaimId = 9, RoleCode = "Admin", ClaimCode = "Expense" },
                new TrRoleClaim { RoleClaimId = 10, RoleCode = "Admin", ClaimCode = "InventoryTransfer" },
                new TrRoleClaim { RoleClaimId = 11, RoleCode = "Admin", ClaimCode = "PaymentDetail" },
                new TrRoleClaim { RoleClaimId = 12, RoleCode = "Admin", ClaimCode = "PosDiscount" },
                new TrRoleClaim { RoleClaimId = 13, RoleCode = "Admin", ClaimCode = "PriceList" },
                new TrRoleClaim { RoleClaimId = 14, RoleCode = "Admin", ClaimCode = "Products" },
                new TrRoleClaim { RoleClaimId = 15, RoleCode = "Admin", ClaimCode = "PurchaseIsReturn" },
                new TrRoleClaim { RoleClaimId = 16, RoleCode = "Admin", ClaimCode = "ReportZet" },
                new TrRoleClaim { RoleClaimId = 17, RoleCode = "Admin", ClaimCode = "RetailPurchaseInvoice" },
                new TrRoleClaim { RoleClaimId = 18, RoleCode = "Admin", ClaimCode = "RetailSaleInvoice" },
                new TrRoleClaim { RoleClaimId = 19, RoleCode = "Admin", ClaimCode = "SaleIsReturn" }
               );

            modelBuilder.Entity<TrClaimReport>().HasData(
                new TrClaimReport { ClaimReportId = 1, ClaimCode = "ButunHesabatlar", ReportId = 1 },
                new TrClaimReport { ClaimReportId = 2, ClaimCode = "ButunHesabatlar", ReportId = 2 },
                new TrClaimReport { ClaimReportId = 3, ClaimCode = "ButunHesabatlar", ReportId = 3 },
                new TrClaimReport { ClaimReportId = 4, ClaimCode = "ButunHesabatlar", ReportId = 4 },
                new TrClaimReport { ClaimReportId = 5, ClaimCode = "ButunHesabatlar", ReportId = 5 },
                new TrClaimReport { ClaimReportId = 6, ClaimCode = "ButunHesabatlar", ReportId = 6 },
                new TrClaimReport { ClaimReportId = 7, ClaimCode = "ButunHesabatlar", ReportId = 7 },
                new TrClaimReport { ClaimReportId = 8, ClaimCode = "ButunHesabatlar", ReportId = 8 },
                new TrClaimReport { ClaimReportId = 9, ClaimCode = "ButunHesabatlar", ReportId = 9 },
                new TrClaimReport { ClaimReportId = 10, ClaimCode = "ButunHesabatlar", ReportId = 10 },
                new TrClaimReport { ClaimReportId = 11, ClaimCode = "ButunHesabatlar", ReportId = 11 }
               );

            static string GetReportFile(string fileName)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                string qry = "";
                string path = "Foxoft.AppCode.Report." + fileName;
                Stream stream = assembly.GetManifestResourceStream(path);
                StreamReader reader = new(stream);
                qry = reader.ReadToEnd();

                return qry;
            }

            CustomMethods cM = new();

            modelBuilder.Entity<DcReport>().HasData(
                new DcReport { ReportId = 1, ReportTypeId = 0, ReportName = "Report_Embedded_ProductList", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Embedded_ProductList.sql"), ReportLayout = "" },
                new DcReport { ReportId = 2, ReportTypeId = 0, ReportName = "Report_Embedded_CurrAccList", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Embedded_CurrAccList.sql"), ReportLayout = "" },
                new DcReport { ReportId = 3, ReportTypeId = 0, ReportName = "Report_Embedded_CashRegList", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Embedded_CashRegList.sql"), ReportLayout = "" },
                new DcReport { ReportId = 4, ReportTypeId = 0, ReportName = "Report_Embedded_InvoiceReport", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Embedded_InvoiceReport.sql"), ReportLayout = "" },
                new DcReport { ReportId = 5, ReportTypeId = 0, ReportName = "Report_Embedded_Barcode", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Embedded_Barcode.sql"), ReportLayout = "" },
                new DcReport { ReportId = 11, ReportTypeId = 1, ReportName = "Xərclər", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Grid_Expenses.sql"), ReportLayout = "" },
                new DcReport { ReportId = 12, ReportTypeId = 1, ReportName = "Pulun Hərəkəti", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Grid_MoneyMovements.sql"), ReportLayout = "" },
                new DcReport { ReportId = 13, ReportTypeId = 1, ReportName = "Cari Hesab ilə Əməliyatlar", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Grid_MovementsWithAccounts.sql"), ReportLayout = "" },
                new DcReport { ReportId = 14, ReportTypeId = 1, ReportName = "Məhsulun Hərəkəti", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Grid_ProductMovements.sql"), ReportLayout = "" },
                new DcReport { ReportId = 15, ReportTypeId = 1, ReportName = "Gəlir", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Grid_Profit.sql"), ReportLayout = "" },
                new DcReport { ReportId = 16, ReportTypeId = 1, ReportName = "Son Gələn Mallar", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Grid_RecentGoods.sql"), ReportLayout = "" },
                new DcReport { ReportId = 17, ReportTypeId = 1, ReportName = "Depoların Qalığı", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Grid_WarehouseBalance.sql"), ReportLayout = "" },
                new DcReport { ReportId = 18, ReportTypeId = 2, ReportName = "Məhsul Kartı", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Detail_ProductCard.sql"), ReportLayout = "" }
                // reportlarin layoutlarin FormLogin de duzelt
               );

            modelBuilder.Entity<DcOffice>().HasData(
               new DcOffice { OfficeCode = "ofs01", OfficeDesc = "Mərkəz Ofisi" }
               );

            modelBuilder.Entity<DcPaymentType>().HasData(
                new DcPaymentType { PaymentTypeCode = 1, PaymentTypeDesc = "Nağd" },
                new DcPaymentType { PaymentTypeCode = 2, PaymentTypeDesc = "Nağdsız" }
                );

            modelBuilder.Entity<DcPaymentMethod>().HasData(
                new DcPaymentMethod { PaymentMethodId = 1, PaymentTypeCode = 1, PaymentMethodDesc = "Nağd" },
                new DcPaymentMethod { PaymentMethodId = 2, PaymentTypeCode = 1, PaymentMethodDesc = "Çatdırılma zamanı nağd ödə" },
                new DcPaymentMethod { PaymentMethodId = 3, PaymentTypeCode = 2, PaymentMethodDesc = "Saytda nağd ödə" },
                new DcPaymentMethod { PaymentMethodId = 4, PaymentTypeCode = 2, PaymentMethodDesc = "Bir Kart" }
                );

            modelBuilder.Entity<DcProcess>().HasData(
                new DcProcess { ProcessCode = "RP", ProcessDesc = "Alış", ProcessDir = 1 },
                new DcProcess { ProcessCode = "RS", ProcessDesc = "Satış", ProcessDir = 2 },
                new DcProcess { ProcessCode = "PA", ProcessDesc = "Ödəmə", ProcessDir = 2 },
                new DcProcess { ProcessCode = "SB", ProcessDesc = "Toptan Alış", ProcessDir = 1 },
                new DcProcess { ProcessCode = "WS", ProcessDesc = "Toptan Satış", ProcessDir = 2 },
                new DcProcess { ProcessCode = "EX", ProcessDesc = "Xərc", ProcessDir = 1 },
                new DcProcess { ProcessCode = "PE", ProcessDesc = "Dovr", ProcessDir = 1 },
                new DcProcess { ProcessCode = "CI", ProcessDesc = "Sayım Artırma", ProcessDir = 1 },
                new DcProcess { ProcessCode = "CO", ProcessDesc = "Sayım Azaltma", ProcessDir = 2 },
                new DcProcess { ProcessCode = "TF", ProcessDesc = "Transfer", ProcessDir = 2 },
                new DcProcess { ProcessCode = "IT", ProcessDesc = "Mal Transferi", ProcessDir = 2 },
                new DcProcess { ProcessCode = "CT", ProcessDesc = "Pul Transferi", ProcessDir = 2 },
                new DcProcess { ProcessCode = "PL", ProcessDesc = "Qiymət Cədvəli", ProcessDir = 0 }
                );

            modelBuilder.Entity<DcProduct>().HasData(
                new DcProduct { ProductTypeCode = 1, ProductCode = "test01", ProductDesc = "Test Məhsul 01", RetailPrice = 4.5m, CreatedDate = new DateTime(1901, 01, 01) },
                new DcProduct { ProductTypeCode = 1, ProductCode = "test02", ProductDesc = "Test Məhsul 01", RetailPrice = 2.5m, CreatedDate = new DateTime(1901, 01, 01) },
                new DcProduct { ProductTypeCode = 2, ProductCode = "xerc01", ProductDesc = "Yol Xərci", CreatedDate = new DateTime(1901, 01, 01) },
                new DcProduct { ProductTypeCode = 2, ProductCode = "xerc02", ProductDesc = "İşıq Pulu", CreatedDate = new DateTime(1901, 01, 01) }
            );

            modelBuilder.Entity<DcBarcodeType>().HasData(
                new DcBarcodeType { BarcodeTypeCode = "Serbest", BarcodeTypeDesc = "Sərbəst" },
                new DcBarcodeType { BarcodeTypeCode = "EAN13", BarcodeTypeDesc = "EAN13" }
            );

            //modelBuilder.Entity<TrProductFeature>() 
            //.HasNoKey();

            //modelBuilder.Entity<DcFeature>(e =>
            //{
            //    e.HasMany(field => field.TrProductFeatures)
            //     .WithOne(fk => fk.DcFeature)
            //     .HasForeignKey(tr => new { tr.FeatureCode, tr.DcFeatureType });
            //
            //    //e.HasOne(field => field.FromCashReg)
            //    //.WithMany(fk => fk.TrPaymentHeaderFromCashes)
            //    //.HasForeignKey(fk => fk.FromCashRegCode);
            //});

            modelBuilder.Entity<DcFeature>()
                        .HasKey(bc => new { bc.FeatureCode, bc.FeatureTypeId });

            modelBuilder.Entity<TrProductDiscount>()
                        .HasKey(bc => new { bc.ProductCode, bc.DiscountId });

            modelBuilder.Entity<TrPaymentMethodDiscount>()
                        .HasKey(bc => new { bc.DiscountId, bc.PaymentMethodId });

            modelBuilder.Entity<TrProductFeature>()
                        .HasKey(bc => new { bc.ProductCode, bc.FeatureTypeId, bc.FeatureCode });

            modelBuilder.Entity<DcFeature>()
                        .HasMany(e => e.TrProductFeatures)
                        .WithOne(e => e.DcFeature)
                        .HasForeignKey(e => new { e.FeatureCode, e.FeatureTypeId });

            modelBuilder.Entity<TrFormReport>()
                       .HasKey(bc => new { bc.FormCode, bc.ReportId });

            modelBuilder.Entity<TrProductHierarchy>()
                        .HasKey(bc => new { bc.ProductCode, bc.HierarchyCode });

            modelBuilder.Entity<TrHierarchyFeature>()
                        .HasKey(bc => new { bc.HierarchyCode, bc.FeatureTypeId });

            modelBuilder.Entity<DcProductType>().HasData(
                new DcProductType { ProductTypeCode = 1, ProductTypeDesc = "Məhsul" },
                new DcProductType { ProductTypeCode = 2, ProductTypeDesc = "Xərc" },
                new DcProductType { ProductTypeCode = 3, ProductTypeDesc = "Servis" }
            );

            //modelBuilder.Entity<TrProductBarcode>()
            //    .HasAlternateKey(c => c.Barcode);

            modelBuilder.Entity<TrProductBarcode>()
                    .HasIndex(u => u.Barcode)
                    .IsUnique();

            modelBuilder.Entity<DcWarehouse>().HasData(
                new DcWarehouse { WarehouseCode = "depo-01", WarehouseDesc = "Mərkəz deposu", OfficeCode = "ofs01", StoreCode = "mgz01", IsDefault = true });

            modelBuilder.Entity<TrInvoiceHeader>(entity =>
            {
                entity.Property(e => e.InvoiceHeaderId)
                   .ValueGeneratedNever();
            });

            modelBuilder.Entity<TrInvoiceLine>(entity =>
            {
                entity.HasOne(x => x.TrInvoiceHeader)
                   .WithMany(x => x.TrInvoiceLines)
                   .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.InvoiceLineId)
                   .ValueGeneratedNever();
            });

            modelBuilder.Entity<TrProductFeature>(entity =>
            {
                entity.HasOne(x => x.DcProduct)
                   .WithMany(x => x.TrProductFeatures)
                   .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TrPaymentLine>(entity =>
            {
                entity.HasOne(x => x.TrPaymentHeader)
                    .WithMany(x => x.TrPaymentLines)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TrPriceListLine>(entity =>
            {
                entity.HasOne(x => x.TrPriceListHeader)
                    .WithMany(x => x.TrPriceListLines)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<SiteProduct>(entity =>
            {
                entity.HasOne(x => x.DcProduct)
                    .WithOne(x => x.SiteProduct)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<DcReportType>().HasData(
                new DcReportType { ReportTypeId = 0, ReportTypeDesc = "Embedded" },
                new DcReportType { ReportTypeId = 1, ReportTypeDesc = "Grid" },
                new DcReportType { ReportTypeId = 2, ReportTypeDesc = "Detail" }
                );

            CustomMethods customMethods = new();
            string gvListDefault = customMethods.GetDataFromFile("Foxoft.AppCode.GvListDefaultLayout.xml");

            modelBuilder.Entity<AppSetting>().HasData(
                new AppSetting { Id = 1, GridViewLayout = gvListDefault });

            modelBuilder.Entity<DcVariable>().HasData(
                new DcVariable { VariableCode = "20", VariableDesc = "Barkod" },
                new DcVariable { VariableCode = "C", VariableDesc = "Cari" },
                new DcVariable { VariableCode = "CI", VariableDesc = "Sayım Artırma" },
                new DcVariable { VariableCode = "CO", VariableDesc = "Sayım Azaltma" },
                new DcVariable { VariableCode = "P", VariableDesc = "Məhsul" },
                new DcVariable { VariableCode = "RS", VariableDesc = "Pərakəndə Satış" },
                new DcVariable { VariableCode = "RP", VariableDesc = "Pərakəndə Alış" },
                new DcVariable { VariableCode = "PA", VariableDesc = "Ödəmə" },
                new DcVariable { VariableCode = "SB", VariableDesc = "Toptan Alış" },
                new DcVariable { VariableCode = "WS", VariableDesc = "Toptan Satış" },
                new DcVariable { VariableCode = "EX", VariableDesc = "Xərclər" },
                new DcVariable { VariableCode = "IT", VariableDesc = "Mal Transferi" },
                new DcVariable { VariableCode = "CT", VariableDesc = "Pul transferi" }
                );

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                   .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId)
                   .HasMaxLength(150);

                entity.Property(e => e.ContextKey)
                   .HasMaxLength(300);

                entity.Property(e => e.Model)
                   .IsRequired();

                entity.Property(e => e.ProductVersion)
                   .IsRequired()
                   .HasMaxLength(32);
            });

            modelBuilder.Entity<Sysdiagrams>(entity =>
            {
                entity.HasKey(e => e.DiagramId)
                   .HasName("PK_dbo.sysdiagrams");

                entity.ToTable("sysdiagrams");

                entity.Property(e => e.DiagramId)
                   .HasColumnName("diagram_id");

                entity.Property(e => e.Definition)
                   .HasColumnName("definition");

                entity.Property(e => e.Name)
                   .IsRequired()
                   .HasColumnName("name")
                   .HasMaxLength(128);

                entity.Property(e => e.PrincipalId)
                   .HasColumnName("principal_id");

                entity.Property(e => e.Version)
                   .HasColumnName("version");
            });

            OnModelCreatingPartial(modelBuilder);


        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
