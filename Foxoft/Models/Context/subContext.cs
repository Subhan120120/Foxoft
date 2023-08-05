using Microsoft.EntityFrameworkCore;
using Foxoft.AppCode;
using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;
using Foxoft.Properties;

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
        public DbSet<DcProcess> DcProcesses { get; set; }
        public DbSet<DcProduct> DcProducts { get; set; }
        public DbSet<SiteProduct> SiteProducts { get; set; }
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
        public DbSet<DcFeature> DcFeatures { get; set; }
        public DbSet<DcFeatureType> DcFeatureTypes { get; set; }
        public DbSet<TrProductFeature> TrProductFeatures { get; set; }
        public DbSet<RetailSale> RetailSales { get; set; } // view

        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string def = Settings.Default.subConnString;
                //string conf = config
                //                    .ConnectionStrings
                //                    .ConnectionStrings["subConnString"]
                //                    .ConnectionString;

                optionsBuilder.UseSqlServer(def);
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

            // more foreign key same table configure
            modelBuilder.Entity<TrPaymentHeader>(e =>
            {
                e.HasOne(field => field.ToCashReg)
             .WithMany(fk => fk.TrPaymentHeaderToCashes)
             .HasForeignKey(fk => fk.ToCashRegCode);

                //e.HasOne(field => field.FromCashReg)
                //.WithMany(fk => fk.TrPaymentHeaderFromCashes)
                //.HasForeignKey(fk => fk.FromCashRegCode);
            });

            modelBuilder.Entity<DcCurrAcc>().HasData(
                new DcCurrAcc { CurrAccCode = "CA-1", FirstName = "Administrator", NewPassword = "123", PhoneNum = "0519678909", CurrAccTypeCode = 3, CreatedDate = new DateTime(1901, 01, 01), OfficeCode = "ofs01", StoreCode = "mgz01" },
                new DcCurrAcc { CurrAccCode = "CA-2", FirstName = "Mudir", LastName = "Mudir", NewPassword = "123", PhoneNum = "0519678909", CurrAccTypeCode = 3, CreatedDate = new DateTime(1901, 01, 01), OfficeCode = "ofs01", StoreCode = "mgz01" },
                new DcCurrAcc { CurrAccCode = "CA-3", FirstName = "Operator", LastName = "Operator", NewPassword = "123", PhoneNum = "0773628800", CurrAccTypeCode = 3, CreatedDate = new DateTime(1901, 01, 01), OfficeCode = "ofs01", StoreCode = "mgz01" },
                new DcCurrAcc { CurrAccCode = "CA-4", FirstName = "Satici", LastName = "Satici", NewPassword = "123", PhoneNum = "0553628804", CurrAccTypeCode = 3, CreatedDate = new DateTime(1901, 01, 01), OfficeCode = "ofs01", StoreCode = "mgz01" },
                new DcCurrAcc { CurrAccCode = "CA-5", FirstName = "Ümumi Müştəri", CurrAccDesc = "Ümumi Müştəri", NewPassword = "123", CurrAccTypeCode = 1, CreatedDate = new DateTime(1901, 01, 01), IsDefault = true, OfficeCode = "ofs01", StoreCode = "mgz01" },
                new DcCurrAcc { CurrAccCode = "mgz01", CurrAccDesc = "Merkez Mağaza", NewPassword = "456", PhoneNum = "0773628800", CurrAccTypeCode = 4, CreatedDate = new DateTime(1901, 01, 01), OfficeCode = "ofs01", StoreCode = "mgz01" },
                new DcCurrAcc { CurrAccCode = "kassa01", CurrAccDesc = "Nağd Kassa", NewPassword = "456", CurrAccTypeCode = 5, CreatedDate = new DateTime(1901, 01, 01), IsDefault = true, OfficeCode = "ofs01", StoreCode = "mgz01" });

            modelBuilder.Entity<DcCurrAccType>().HasData(
                new DcCurrAccType { CurrAccTypeCode = 1, CurrAccTypeDesc = "Müştəri" },
                new DcCurrAccType { CurrAccTypeCode = 2, CurrAccTypeDesc = "Tədarikçi" },
                new DcCurrAccType { CurrAccTypeCode = 3, CurrAccTypeDesc = "Personal" },
                new DcCurrAccType { CurrAccTypeCode = 4, CurrAccTypeDesc = "Mağaza" },
                new DcCurrAccType { CurrAccTypeCode = 5, CurrAccTypeDesc = "Kassa" }
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
                new DcCurrency { CurrencyCode = "USD", CurrencyDesc = "$ DOLLAR", ExchangeRate = 1.703f },
                new DcCurrency { CurrencyCode = "EUR", CurrencyDesc = "€ EURO", ExchangeRate = 1.798f }
                );

            modelBuilder.Entity<DcRole>().HasData(
                new DcRole { RoleCode = "Admin", RoleDesc = "Administrator" },
                new DcRole { RoleCode = "MGZ", RoleDesc = "Mağaza İstifadəçisi" }
                );

            modelBuilder.Entity<TrCurrAccRole>().HasData(
               new TrCurrAccRole { CurrAccRoleId = 1, CurrAccCode = "CA-1", RoleCode = "Admin" });

            modelBuilder.Entity<DcClaim>().HasData(
                new DcClaim { ClaimCode = "PosDiscount", ClaimDesc = "POS Endirimi", ClaimTypeId = 1 });


            modelBuilder.Entity<TrRoleClaim>().HasData(
               new TrRoleClaim { RoleClaimId = 1, RoleCode = "Admin", ClaimCode = "PosDiscount" });

            modelBuilder.Entity<DcOffice>().HasData(
               new DcOffice { OfficeCode = "ofs01", OfficeDesc = "Bakıxanov Ofisi" },
               new DcOffice { OfficeCode = "ofs02", OfficeDesc = "Elmlər Ofisi" });

            modelBuilder.Entity<DcPaymentType>().HasData(
                new DcPaymentType { PaymentTypeCode = 1, PaymentTypeDesc = "Nağd" },
                new DcPaymentType { PaymentTypeCode = 2, PaymentTypeDesc = "Visa" });

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
                new DcProcess { ProcessCode = "CT", ProcessDesc = "Pul Transferi", ProcessDir = 2 }
                );

            modelBuilder.Entity<DcProduct>().HasData(
                new DcProduct { ProductTypeCode = 1, ProductCode = "test01", ProductDesc = "Papaq", Barcode = "123456", RetailPrice = 4.5m, CreatedDate = new DateTime(1901, 01, 01) },
                new DcProduct { ProductTypeCode = 1, ProductCode = "test02", ProductDesc = "Salvar", Barcode = "2000000000013", RetailPrice = 2.5m, CreatedDate = new DateTime(1901, 01, 01) },
                new DcProduct { ProductTypeCode = 2, ProductCode = "xerc01", ProductDesc = "Yol Xerci", Barcode = "", RetailPrice = 0, CreatedDate = new DateTime(1901, 01, 01) },
                new DcProduct { ProductTypeCode = 2, ProductCode = "xerc02", ProductDesc = "Isiq Pulu", Barcode = "", RetailPrice = 0, CreatedDate = new DateTime(1901, 01, 01) }
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

            modelBuilder.Entity<DcWarehouse>().HasData(
                new DcWarehouse { WarehouseCode = "depo-01", WarehouseDesc = "Mərkəz deposu", OfficeCode = "ofs01", StoreCode = "mgz01", IsDefault = true },
                new DcWarehouse { WarehouseCode = "depo-02", WarehouseDesc = "Elmlər deposu", OfficeCode = "ofs01", StoreCode = "mgz01" });

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

            modelBuilder.Entity<DcReport>().HasData(
                new DcReport { ReportId = 1, ReportName = "Satis", ReportQuery = "select * from TrInvoiceLines", ReportTypeId = 1 });

            modelBuilder.Entity<DcReportType>().HasData(
                new DcReportType { ReportTypeId = 1, ReportTypeDesc = "Grid" },
                new DcReportType { ReportTypeId = 2, ReportTypeDesc = "Detail" });

            CustomMethods customMethods = new();
            string gvListDefault = customMethods.GetDataFromFile("Foxoft.AppCode.GvListDefaultLayout.xml");

            modelBuilder.Entity<AppSetting>().HasData(
                new AppSetting { Id = 1, GridViewLayout = gvListDefault });

            modelBuilder.Entity<DcVariable>().HasData(
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
