using Foxoft.AppCode;
using Foxoft.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel;
using System.Reflection;

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

        public DbSet<DcUILanguage> DcUILanguages { get; set; }
        public DbSet<DcClaim> DcClaims { get; set; }
        public DbSet<DcClaimType> DcClaimTypes { get; set; }
        public DbSet<TrClaimReport> TrClaimReports { get; set; }
        public DbSet<DcClaimCategory> DcClaimCategories { get; set; }
        public DbSet<DcCurrAccContactDetail> DcCurrAccContactDetails { get; set; }
        public DbSet<DcContactType> DcContactType { get; set; }
        public DbSet<DcCurrAcc> DcCurrAccs { get; set; }
        public DbSet<DcCurrAccType> DcCurrAccTypes { get; set; }
        public DbSet<DcPersonalType> DcPersonalTypes { get; set; }
        public DbSet<DcOffice> DcOffices { get; set; }
        public DbSet<DcPaymentType> DcPaymentTypes { get; set; }
        public DbSet<DcPaymentKind> DcPaymentKinds { get; set; }
        public DbSet<DcPaymentMethod> DcPaymentMethods { get; set; }
        public DbSet<DcPaymentPlan> DcPaymentPlans { get; set; }
        public DbSet<TrInstallment> TrInstallments { get; set; }
        public DbSet<TrInstallmentGuarantor> TrInstallmentGuarantors { get; set; }
        public DbSet<DcProcess> DcProcesses { get; set; }
        public DbSet<DcProduct> DcProducts { get; set; }
        public DbSet<SiteProduct> SiteProducts { get; set; }
        public DbSet<TrProductBarcode> TrProductBarcodes { get; set; }
        public DbSet<DcBarcodeType> DcBarcodeTypes { get; set; }
        public DbSet<DcSerialNumber> DcSerialNumbers { get; set; }
        public DbSet<DcUnitOfMeasure> DcUnitOfMeasures { get; set; }
        //public DbSet<TrProductUnitOfMeasure> TrProductUnitOfMeasures { get; set; }
        public DbSet<DcDiscount> DcDiscounts { get; set; }
        public DbSet<TrProductDiscount> TrProductDiscounts { get; set; }
        public DbSet<DcProductType> DcProductTypes { get; set; }
        public DbSet<DcProductScale> DcProductScales { get; set; }
        public DbSet<DcRole> DcRoles { get; set; }
        public DbSet<DcForm> DcForms { get; set; }
        public DbSet<TrFormReport> TrFormReports { get; set; }
        public DbSet<DcTerminal> DcTerminals { get; set; }
        public DbSet<TrSession> TrSessions { get; set; }
        public DbSet<DcWarehouse> DcWarehouses { get; set; }
        public DbSet<MigrationHistory> MigrationHistory { get; set; }
        public DbSet<TrCurrAccRole> TrCurrAccRoles { get; set; }
        public DbSet<TrInvoiceHeader> TrInvoiceHeaders { get; set; }
        public DbSet<TrInvoiceLine> TrInvoiceLines { get; set; }
        public DbSet<TrPaymentHeader> TrPaymentHeaders { get; set; }
        public DbSet<TrPaymentLine> TrPaymentLines { get; set; }
        public DbSet<trInvoiceLineExt> TrInvoiceLineExts { get; set; }
        public DbSet<TrRoleClaim> TrRoleClaims { get; set; }
        public DbSet<DcReport> DcReports { get; set; }
        public DbSet<DcReportType> DcReportTypes { get; set; }
        public DbSet<DcReportVariable> DcReportVariables { get; set; }
        public DbSet<DcReportVariableType> dcReportVariableTypes { get; set; }
        public DbSet<DcReportCategory> DcReportCategories { get; set; }
        public DbSet<TrReportSubQuery> TrReportSubQueries { get; set; }
        public DbSet<TrReportSubQueryRelationColumn> TrReportSubQueryRelationColumns { get; set; }
        public DbSet<TrReportCustomization> TrReportCustomizations { get; set; }
        public DbSet<AppSetting> AppSettings { get; set; }
        public DbSet<SettingStore> SettingStores { get; set; }
        public DbSet<DcVariable> DcVariables { get; set; }
        public DbSet<DcProductStaticPrice> DcProductStaticPrices { get; set; }
        public DbSet<DcCurrency> DcCurrencies { get; set; }
        public DbSet<DcHierarchy> DcHierarchies { get; set; }
        public DbSet<TrHierarchyFeatureType> TrHierarchyFeatureTypes { get; set; }
        public DbSet<TrPaymentMethodDiscount> TrPaymentMethodDiscounts { get; set; }
        public DbSet<DcFeature> DcFeatures { get; set; }
        public DbSet<DcFeatureType> DcFeatureTypes { get; set; }
        public DbSet<TrProductFeature> TrProductFeatures { get; set; }
        public DbSet<DcCurrAccFeature> DcCurrAccFeatures { get; set; }
        public DbSet<DcCurrAccFeatureType> DcCurrAccFeatureTypes { get; set; }
        public DbSet<TrCurrAccFeature> TrCurrAccFeatures { get; set; }
        public DbSet<DcPriceType> DcPriceTypes { get; set; }
        public DbSet<TrProcessPriceType> TrProcessPriceTypes { get; set; }
        public DbSet<TrPriceListHeader> TrPriceListHeaders { get; set; }
        public DbSet<TrPriceListLine> TrPriceListLines { get; set; }
        public DbSet<RetailSale> RetailSales { get; set; } // view
        public DbSet<ProductBalance> ProductBalances { get; set; } // view
        public virtual DbSet<SlugifyResult> Slugify { get; set; } // function

        public int SaveChanges(string currAccCode)
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified)
                .Where(e => e.Entity is TrInvoiceHeader || e.Entity is TrInvoiceLine);

            foreach (var entry in modifiedEntries)
            {
                if (entry.Entity is TrInvoiceHeader header)
                {
                    header.LastUpdatedUserName = currAccCode;
                    header.LastUpdatedDate = DateTime.Now;
                }
                else if (entry.Entity is TrInvoiceLine line)
                {
                    line.LastUpdatedUserName = currAccCode;
                    line.LastUpdatedDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        public int SaveChanges(bool acceptAllChangesOnSuccess, string currAccCode)
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified)
                .Where(e => e.Entity is TrInvoiceHeader || e.Entity is TrInvoiceLine);

            foreach (var entry in modifiedEntries)
            {
                if (entry.Entity is TrInvoiceHeader header)
                {
                    var modifiedProps = entry.Properties
                        .Where(p => p.IsModified && !p.Metadata.IsPrimaryKey())
                        .Select(p => p.Metadata.Name);

                    if (!modifiedProps.Any() || (modifiedProps.Count() == 1 && modifiedProps.First() == nameof(TrInvoiceHeader.IsLocked)))
                        continue; // Skip updating last updated fields

                    header.LastUpdatedUserName = currAccCode;
                    header.LastUpdatedDate = DateTime.Now;
                }
                else if (entry.Entity is TrInvoiceLine line)
                {
                    line.LastUpdatedUserName = currAccCode;
                    line.LastUpdatedDate = DateTime.Now;
                }
            }

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified)
                .Where(e => e.Entity is TrInvoiceHeader || e.Entity is TrInvoiceLine);

            foreach (var entry in modifiedEntries)
            {
                if (entry.Entity is TrInvoiceHeader header)
                    header.LastUpdatedDate = DateTime.Now;
                else if (entry.Entity is TrInvoiceLine line)
                    line.LastUpdatedDate = DateTime.Now;
            }

            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified)
                .Where(e => e.Entity is TrInvoiceHeader || e.Entity is TrInvoiceLine);

            foreach (var entry in modifiedEntries)
            {
                if (entry.Entity is TrInvoiceHeader header)
                    header.LastUpdatedDate = DateTime.Now;
                else if (entry.Entity is TrInvoiceLine line)
                    line.LastUpdatedDate = DateTime.Now;
            }

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.EnableSensitiveDataLogging();

            if (!optionsBuilder.IsConfigured)
            {
                string subConnString = Properties.Settings.Default.SubConnString;
                optionsBuilder.UseSqlServer(subConnString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //for DefaultValue Attribute for Entity propertires.
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
                foreach (IMutableProperty property in entityType.GetProperties())
                {
                    MemberInfo memberInfo = property.PropertyInfo ?? (MemberInfo)property.FieldInfo;
                    if (memberInfo == null) continue;
                    DefaultValueAttribute defaultValue = Attribute.GetCustomAttribute(memberInfo, typeof(DefaultValueAttribute)) as DefaultValueAttribute;
                    if (defaultValue == null) continue;
                    property.SetDefaultValueSql(defaultValue.Value.ToString());
                }

            base.OnModelCreating(modelBuilder);

            InitializeHasData(modelBuilder);

            InitializeDeleteBehaviour(modelBuilder);

            modelBuilder.HasDbFunction(typeof(SqlFunctions).GetMethod(nameof(SqlFunctions.GetProductCost)))
                        .HasName("GetProductCost"); // function

            modelBuilder.Entity<RetailSale>() //view
                        .ToView(nameof(RetailSale));

            modelBuilder.Entity<ProductBalance>() //view
                        .ToView(nameof(ProductBalance));

            modelBuilder.Entity<GetNextDocNum>() //procedure
                        .HasNoKey()
                        .ToView(nameof(GetNextDocNum));

            modelBuilder.Entity<SlugifyResult>() // function
                        .HasNoKey()
                        .ToView(nameof(SlugifyResult));

            // more foreign key same table configure
            modelBuilder.Entity<TrPaymentHeader>(e =>
            {
                e.HasOne(field => field.DcStore)
                 .WithMany(fk => fk.DcStoreTrPaymentHeaders)
                 .HasForeignKey(fk => fk.StoreCode)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(field => field.ToCashReg)
                 .WithMany(fk => fk.ToCashRegTrPaymentHeaders)
                 .HasForeignKey(fk => fk.ToCashRegCode)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // more foreign key same table configure
            modelBuilder.Entity<DcPaymentMethod>(e =>
            {
                e.HasOne(field => field.DcCurrAcc)
                 .WithMany(fk => fk.CurrAccDcPaymentMethods)
                 .HasForeignKey(fk => fk.RedirectedCurrAccCode)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(field => field.DcCashReg)
                 .WithMany(fk => fk.CashRegDcPaymentMethods)
                 .HasForeignKey(fk => fk.DefaultCashRegCode)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // for using DcUnitOfMeasure.ParentUnitOfMeasure
            modelBuilder.Entity<DcUnitOfMeasure>()
                .HasOne(u => u.ParentUnitOfMeasure)
                .WithMany(u => u.ChildUnitOfMeasures)
                .HasForeignKey(u => u.ParentUnitOfMeasureId)
                .OnDelete(DeleteBehavior.Restrict); // prevent cascade delete loops

            //EntityTypeBuilder deleted = modelBuilder.Entity<TrInvoiceHeaderDeleted>()
            //    .ToTable("TrInvoiceHeaderDeleteds")
            //    .HasBaseType<TrInvoiceHeader>();

            modelBuilder.Entity<DcFeature>()
                        .HasKey(bc => new { bc.FeatureCode, bc.FeatureTypeId });

            modelBuilder.Entity<DcFeature>()
                        .HasMany(e => e.TrProductFeatures)
                        .WithOne(e => e.DcFeature)
                        .HasForeignKey(e => new { e.FeatureCode, e.FeatureTypeId });


            modelBuilder.Entity<TrProductFeature>(entity =>
            {
                entity.ToTable(tb => tb.UseSqlOutputClause(false)); // triggere gore xeta vermesin deye
            });

            modelBuilder.Entity<TrProductFeature>()
                        .HasKey(bc => new { bc.ProductCode, bc.FeatureTypeId, bc.FeatureCode });

            modelBuilder.Entity<TrHierarchyFeatureType>()
                        .HasKey(bc => new { bc.HierarchyCode, bc.FeatureTypeId });

            modelBuilder.Entity<DcCurrAccFeature>()
                        .HasKey(bc => new { bc.CurrAccFeatureCode, bc.CurrAccFeatureTypeId });

            modelBuilder.Entity<DcCurrAccFeature>()
                        .HasMany(e => e.TrCurrAccFeatures)
                        .WithOne(e => e.DcCurrAccFeature)
                        .HasForeignKey(e => new { e.CurrAccFeatureCode, e.CurrAccFeatureTypeId });

            modelBuilder.Entity<TrCurrAccFeature>()
                        .HasKey(bc => new { bc.CurrAccCode, bc.CurrAccFeatureTypeId, bc.CurrAccFeatureCode });

            modelBuilder.Entity<DcProductStaticPrice>()
                        .HasKey(bc => new { bc.ProductCode, bc.PriceTypeCode });

            modelBuilder.Entity<TrProductDiscount>()
                        .HasKey(bc => new { bc.ProductCode, bc.DiscountId });

            modelBuilder.Entity<TrPaymentMethodDiscount>()
                        .HasKey(bc => new { bc.DiscountId, bc.PaymentMethodId });

            modelBuilder.Entity<TrFormReport>()
                       .HasKey(bc => new { bc.FormCode, bc.ReportId });

            modelBuilder.Entity<TrProductBarcode>()
                        .HasIndex(u => u.Barcode)
                        .IsUnique();

            modelBuilder.Entity<TrProcessPriceType>()
                        .HasIndex(u => new { u.ProcessCode, u.PriceTypeCode })
                        .IsUnique();

            modelBuilder.Entity<DcHierarchy>().ToTable(tb => tb.UseSqlOutputClause(false)); // triggere gore xeta verir 
            modelBuilder.Entity<DcProduct>().ToTable(tb => tb.UseSqlOutputClause(false)); // triggere gore xeta verir 

            modelBuilder.Entity<TrInvoiceHeader>(entity =>
            {
                entity.ToTable(tb => tb.UseSqlOutputClause(false)); // triggere gore xeta verir 

                entity.Property(e => e.InvoiceHeaderId)
                      .ValueGeneratedNever();
            });

            modelBuilder.Entity<TrInvoiceLine>(entity =>
            {
                entity.ToTable(tb => tb.HasTrigger("CalcPaymenLineExt"));

                entity.ToTable(tb => tb.UseSqlOutputClause(false)); // triggere gore xeta verir 

                entity.Property(e => e.InvoiceLineId)
                      .ValueGeneratedNever();
            });

            modelBuilder.Entity<DcPriceType>(entity =>
            {
                entity.ToTable(tb => tb.UseSqlOutputClause(false)); // triggere gore xeta vermesin deye
            });

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

            OnModelCreatingPartial(modelBuilder);
        }

        private static void InitializeDeleteBehaviour(ModelBuilder modelBuilder)
        {
            //All foreignkeys DeleteBehavior to Restrict (NoAction)
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict; // NoAction



            modelBuilder.Entity<TrProductFeature>(entity =>
            {
                entity.HasOne(x => x.DcProduct)
                   .WithMany(x => x.TrProductFeatures)
                   .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TrCurrAccFeature>(entity =>
            {
                entity.HasOne(x => x.DcCurrAcc)
                   .WithMany(x => x.TrCurrAccFeatures)
                   .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TrRoleClaim>(entity =>
            {
                entity.HasOne(x => x.DcRole)
                   .WithMany(x => x.TrRoleClaims)
                   .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<DcSerialNumber>(entity =>
            {
                entity.HasOne(x => x.DcProduct)
                   .WithMany(x => x.DcSerialNumbers)
                   .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TrPaymentLine>(entity =>
            {
                entity.HasOne(x => x.TrPaymentHeader)
                    .WithMany(x => x.TrPaymentLines)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TrInstallment>(entity =>
            {
                entity.HasOne(x => x.TrInvoiceHeader)
                    .WithOne(x => x.TrInstallment)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TrInstallmentGuarantor>(entity =>
            {
                entity.HasOne(x => x.TrInstallment)
                    .WithMany(x => x.TrInstallmentGuarantors)
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

            modelBuilder.Entity<SettingStore>(entity =>
            {
                entity.HasOne(x => x.DcStore)
                    .WithOne(x => x.SettingStore)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TrInvoiceLine>(entity =>
            {
                entity.HasOne(x => x.TrInvoiceHeader)
                   .WithMany(x => x.TrInvoiceLines)
                   .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TrCurrAccRole>(entity =>
            {
                entity.HasOne(x => x.DcCurrAcc)
                   .WithMany(x => x.TrCurrAccRoles)
                   .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<trInvoiceLineExt>(entity =>
            {
                entity.HasOne(x => x.TrInvoiceLine)
                    .WithOne(x => x.TrInvoiceLineExt)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<DcReportVariable>(entity =>
            {
                entity.HasOne(x => x.DcReport)
                    .WithMany(x => x.DcReportVariables)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TrReportSubQuery>()
                .HasOne(sq => sq.DcReport)
                .WithMany(r => r.TrReportSubQueries)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TrReportSubQueryRelationColumn>()
                .HasOne(sq => sq.TrReportSubQuery)
                .WithMany(r => r.TrReportSubQueryRelationColumns)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TrClaimReport>(entity =>
            {
                entity.HasOne(x => x.DcReport)
                    .WithMany(x => x.TrClaimReports)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TrFormReport>(entity =>
            {
                entity.HasOne(x => x.DcReport)
                    .WithMany(x => x.TrFormReports)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TrReportCustomization>(entity =>
            {
                entity.HasOne(x => x.DcReport)
                    .WithMany(x => x.TrReportCustomizations)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TrReportCustomization>(entity =>
            {
                entity.HasOne(x => x.DcCurrAcc)
                    .WithMany(x => x.TrReportCustomizations)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private static void InitializeHasData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DcHierarchy>().HasData(
                new DcHierarchy { HierarchyCode = "Root", HierarchyDesc = "Root", HierarchyLevel = 0, Order = 0 }
                );

            modelBuilder.Entity<DcUILanguage>().HasData(
                new DcUILanguage { LanguageCode = "en", LanguageDesc = "English" },
                new DcUILanguage { LanguageCode = "az", LanguageDesc = "Azərbaycanca" },
                new DcUILanguage { LanguageCode = "tr", LanguageDesc = "Türkçe" },
                new DcUILanguage { LanguageCode = "ru", LanguageDesc = "Русский" }
                );

            modelBuilder.Entity<DcForm>().HasData(
                new DcForm { FormCode = "CurrAccs", FormDesc = "Cari Hesablar" },
                new DcForm { FormCode = "Products", FormDesc = "Məhsullar" },
                new DcForm { FormCode = "CashRegisters", FormDesc = "Kassalar" },
                new DcForm { FormCode = "PaymentDetails", FormDesc = "Ödəniş" },
                new DcForm { FormCode = "InstallmentSale", FormDesc = "Kredit Satış" },
                new DcForm { FormCode = "ERP", FormDesc = "ERP" }
                );

            modelBuilder.Entity<DcTerminal>().HasData(
                new DcTerminal { TerminalId = 1, TerminalDesc = "Notebook", TouchUIMode = false, TouchScaleFactor = 1 },
                new DcTerminal { TerminalId = 2, TerminalDesc = "Telefon", TouchUIMode = true, TouchScaleFactor = 2 }
                );

            modelBuilder.Entity<DcCurrAcc>().HasData(
                new DcCurrAcc { CurrAccCode = "C-000001", CurrAccDesc = "Administrator", NewPassword = "123", PhoneNum = "0519678909", CurrAccTypeCode = 3, CreatedDate = new DateTime(1901, 01, 01), OfficeCode = "ofs01", StoreCode = "mgz01" },
                new DcCurrAcc { CurrAccCode = "C-000002", CurrAccDesc = "Mudir", LastName = "Mudir", NewPassword = "123", PhoneNum = "", CurrAccTypeCode = 3, CreatedDate = new DateTime(1901, 01, 01), OfficeCode = "ofs01", StoreCode = "mgz01" },
                new DcCurrAcc { CurrAccCode = "C-000003", CurrAccDesc = "Operator", LastName = "Operator", NewPassword = "123", PhoneNum = "", CurrAccTypeCode = 3, CreatedDate = new DateTime(1901, 01, 01), OfficeCode = "ofs01", StoreCode = "mgz01" },
                new DcCurrAcc { CurrAccCode = "C-000004", CurrAccDesc = "Satici", LastName = "Satici", NewPassword = "123", PhoneNum = "", CurrAccTypeCode = 3, CreatedDate = new DateTime(1901, 01, 01), OfficeCode = "ofs01", StoreCode = "mgz01" },
                new DcCurrAcc { CurrAccCode = "C-000005", CurrAccDesc = "Ümumi Müştəri", NewPassword = "123", CurrAccTypeCode = 1, CreatedDate = new DateTime(1901, 01, 01), IsDefault = true, OfficeCode = "ofs01", StoreCode = "mgz01" },
                new DcCurrAcc { CurrAccCode = "C-000006", CurrAccDesc = "Birbank", NewPassword = "", CurrAccTypeCode = 1, CreatedDate = new DateTime(1901, 01, 01), IsDefault = true, OfficeCode = "ofs01", StoreCode = "mgz01" },
                new DcCurrAcc { CurrAccCode = "mgz01", CurrAccDesc = "Merkez Mağaza", NewPassword = "456", PhoneNum = "", CurrAccTypeCode = 4, CreatedDate = new DateTime(1901, 01, 01), OfficeCode = "ofs01", StoreCode = "mgz01" },
                new DcCurrAcc { CurrAccCode = "kassa01", CurrAccDesc = "Nağd Kassa", NewPassword = "456", CurrAccTypeCode = 5, CreatedDate = new DateTime(1901, 01, 01), IsDefault = true, OfficeCode = "ofs01", StoreCode = "mgz01" });

            modelBuilder.Entity<DcCurrAccType>().HasData(
                new DcCurrAccType { CurrAccTypeCode = 1, CurrAccTypeDesc = "Müştəri" },
                new DcCurrAccType { CurrAccTypeCode = 2, CurrAccTypeDesc = "Tədarikçi" },
                new DcCurrAccType { CurrAccTypeCode = 3, CurrAccTypeDesc = "Personal" },
                new DcCurrAccType { CurrAccTypeCode = 4, CurrAccTypeDesc = "Mağaza" },
                new DcCurrAccType { CurrAccTypeCode = 5, CurrAccTypeDesc = "Kassa" }
                );

            modelBuilder.Entity<DcContactType>().HasData(
                new DcContactType { Id = 1, ContactTypeDesc = "Telefon" },
                new DcContactType { Id = 2, ContactTypeDesc = "Adres" },
                new DcContactType { Id = 3, ContactTypeDesc = "Email" },
                new DcContactType { Id = 4, ContactTypeDesc = "Sosial Media" }
                );

            modelBuilder.Entity<DcPersonalType>().HasData(
                new DcPersonalType { PersonalTypeCode = 1, PersonalTypeDesc = "Satıcı" }
                );

            modelBuilder.Entity<SettingStore>().HasData(
               new SettingStore { Id = 1, StoreCode = "mgz01", DefaultUnitOfMeasureId = 1, DesignFileFolder = @"C:\Foxoft\Foxoft Design Files", ImageFolder = @"C:\Foxoft\Foxoft Images" }
                );

            modelBuilder.Entity<DcCurrency>().HasData(
                new DcCurrency { CurrencyCode = "AZN", CurrencyDesc = "₼ AZN", ExchangeRate = 1 },
                new DcCurrency { CurrencyCode = "USD", CurrencyDesc = "$ DOLLAR", ExchangeRate = 1.7f },
                new DcCurrency { CurrencyCode = "EUR", CurrencyDesc = "€ EURO", ExchangeRate = 1.67f }
                );

            modelBuilder.Entity<DcClaimCategory>().HasData(
                new DcClaimCategory { CategoryId = 1,/*dəyişmə olmaz*/ CategoryDesc = "Hesabatlar", CategoryLevel = 0, CategoryParentId = null },
                new DcClaimCategory { CategoryId = 2,/*dəyişmə olmaz*/ CategoryDesc = "Fakturalar", CategoryLevel = 0, CategoryParentId = null },
                new DcClaimCategory { CategoryId = 3,/*dəyişmə olmaz*/ CategoryDesc = "Pərakəndə Alış", CategoryLevel = 1, CategoryParentId = 2 },
                new DcClaimCategory { CategoryId = 4,/*dəyişmə olmaz*/ CategoryDesc = "Topdan Alış", CategoryLevel = 1, CategoryParentId = 2 },
                new DcClaimCategory { CategoryId = 5,/*dəyişmə olmaz*/ CategoryDesc = "Pərakəndə Satış", CategoryLevel = 1, CategoryParentId = 2 },
                new DcClaimCategory { CategoryId = 6,/*dəyişmə olmaz*/ CategoryDesc = "Topdan Satış", CategoryLevel = 1, CategoryParentId = 2 },
                new DcClaimCategory { CategoryId = 7,/*dəyişmə olmaz*/ CategoryDesc = "Kredit Alış", CategoryLevel = 1, CategoryParentId = 2 },
                new DcClaimCategory { CategoryId = 8,/*dəyişmə olmaz*/ CategoryDesc = "Kredit Satış", CategoryLevel = 1, CategoryParentId = 2 },
                new DcClaimCategory { CategoryId = 9,/*dəyişmə olmaz*/ CategoryDesc = "Xərc", CategoryLevel = 1, CategoryParentId = 2 },
                new DcClaimCategory { CategoryId = 10,/*dəyişmə olmaz*/ CategoryDesc = "Sayım Artırma", CategoryLevel = 1, CategoryParentId = 2 },
                new DcClaimCategory { CategoryId = 11,/*dəyişmə olmaz*/ CategoryDesc = "Sayım Azaltma", CategoryLevel = 1, CategoryParentId = 2 },
                new DcClaimCategory { CategoryId = 12,/*dəyişmə olmaz*/ CategoryDesc = "Təhvil Alma", CategoryLevel = 1, CategoryParentId = 2 },
                new DcClaimCategory { CategoryId = 13,/*dəyişmə olmaz*/ CategoryDesc = "Təhvil Vermə", CategoryLevel = 1, CategoryParentId = 2 },
                new DcClaimCategory { CategoryId = 14,/*dəyişmə olmaz*/ CategoryDesc = "Məhsul Transferi", CategoryLevel = 1, CategoryParentId = 2 },
                new DcClaimCategory { CategoryId = 15,/*dəyişmə olmaz*/ CategoryDesc = "Təhlükəsizlik", CategoryLevel = 0, CategoryParentId = null },
                new DcClaimCategory { CategoryId = 18,/*dəyişmə olmaz*/ CategoryDesc = "Məhsul", CategoryLevel = 0, CategoryParentId = null },
                new DcClaimCategory { CategoryId = 19,/*dəyişmə olmaz*/ CategoryDesc = "Cari Hesab", CategoryLevel = 0, CategoryParentId = null },
                new DcClaimCategory { CategoryId = 20,/*dəyişmə olmaz*/ CategoryDesc = "Kassa", CategoryLevel = 0, CategoryParentId = null },
                new DcClaimCategory { CategoryId = 21,/*dəyişmə olmaz*/ CategoryDesc = "Ödəniş", CategoryLevel = 0, CategoryParentId = null },
                new DcClaimCategory { CategoryId = 22,/*dəyişmə olmaz*/ CategoryDesc = "Mağaza", CategoryLevel = 0, CategoryParentId = null }
                );

            modelBuilder.Entity<DcClaim>().HasData(
                new DcClaim { ClaimCode = "ButunHesabatlar", ClaimDesc = "Butun Hesabatlar", ClaimTypeId = 2, CategoryId = 1 },
                new DcClaim { ClaimCode = "Products", ClaimDesc = "Məhsullar", ClaimTypeId = 1, CategoryId = 18 },
                new DcClaim { ClaimCode = "CurrAccs", ClaimDesc = "Cari Hesablar", ClaimTypeId = 1, CategoryId = 19 },
                new DcClaim { ClaimCode = "CashRegs", ClaimDesc = "Kassalar", ClaimTypeId = 1, CategoryId = 21 },
                new DcClaim { ClaimCode = "CashTransfer", ClaimDesc = "Pul Transferi", ClaimTypeId = 1, CategoryId = 21 },
                new DcClaim { ClaimCode = "InventoryTransfer", ClaimDesc = "Mal Transferi", ClaimTypeId = 1, CategoryId = 14 },
                new DcClaim { ClaimCode = "Expense", ClaimDesc = "Xərc", ClaimTypeId = 1, CategoryId = 9 },
                new DcClaim { ClaimCode = "RetailPurchaseInvoice", ClaimDesc = "Pərakəndə Alış Fakturası", ClaimTypeId = 1, CategoryId = 3 },
                new DcClaim { ClaimCode = "WholePurchaseInvoice", ClaimDesc = "Topdan Alış Fakturası", ClaimTypeId = 1, CategoryId = 4 },
                new DcClaim { ClaimCode = "RetailSaleInvoice", ClaimDesc = "Pərakəndə Satış Fakturası", ClaimTypeId = 1, CategoryId = 5 },
                new DcClaim { ClaimCode = "WholesaleInvoice", ClaimDesc = "Topdan Satış Fakturası", ClaimTypeId = 1, CategoryId = 6 },
                new DcClaim { ClaimCode = "InstallmentPurchaseInvoice", ClaimDesc = "Kredit Alışı", ClaimTypeId = 1, CategoryId = 7 },
                new DcClaim { ClaimCode = "InstallmentSaleInvoice", ClaimDesc = "Kredit Satışı", ClaimTypeId = 1, CategoryId = 8 },
                new DcClaim { ClaimCode = "CountIn", ClaimDesc = "Sayım Artırma", ClaimTypeId = 1, CategoryId = 10 },
                new DcClaim { ClaimCode = "CountOut", ClaimDesc = "Sayım Azaltma", ClaimTypeId = 1, CategoryId = 11 },
                new DcClaim { ClaimCode = "WaybillIn", ClaimDesc = "Təhvil Alma", ClaimTypeId = 1, CategoryId = 12 },
                new DcClaim { ClaimCode = "WaybillOut", ClaimDesc = "Təhvil Vermə", ClaimTypeId = 1, CategoryId = 13 },
                new DcClaim { ClaimCode = "RetailPurchaseOrder", ClaimDesc = "Pərakəndə Alış Sifarişi", ClaimTypeId = 1, CategoryId = 3 },
                new DcClaim { ClaimCode = "WholePurchaseOrder", ClaimDesc = "Topdan Alış Sifarişi", ClaimTypeId = 1, CategoryId = 4 },
                new DcClaim { ClaimCode = "RetailSaleOrder", ClaimDesc = "Pərakəndə Satış Sifarişi", ClaimTypeId = 1, CategoryId = 5 },
                new DcClaim { ClaimCode = "WholesaleOrder", ClaimDesc = "Topdan Satış Sifarişi", ClaimTypeId = 1, CategoryId = 6 },
                new DcClaim { ClaimCode = "InstallmentPurchaseOrder", ClaimDesc = "Kredit Alış Sifarişi", ClaimTypeId = 1, CategoryId = 7 },
                new DcClaim { ClaimCode = "InstallmentSaleOrder", ClaimDesc = "Kredit Satış Sifarişi", ClaimTypeId = 1, CategoryId = 8 },
                new DcClaim { ClaimCode = "RetailPurchaseReturn", ClaimDesc = "Pərakəndə Alışın Qaytarılması", ClaimTypeId = 1, CategoryId = 3 },
                new DcClaim { ClaimCode = "WholePurchaseReturn", ClaimDesc = "Topdan Alışın Qaytarılması", ClaimTypeId = 1, CategoryId = 4 },
                new DcClaim { ClaimCode = "RetailSaleReturn", ClaimDesc = "Pərakəndə Satışın Qaytarılması", ClaimTypeId = 1, CategoryId = 5 },
                new DcClaim { ClaimCode = "WholesaleReturn", ClaimDesc = "Topdan Satışın Qaytarılması", ClaimTypeId = 1, CategoryId = 6 },
                new DcClaim { ClaimCode = "InstallmentPurchaseReturn", ClaimDesc = "Kredit Alış Qaytarması", ClaimTypeId = 1, CategoryId = 7 },
                new DcClaim { ClaimCode = "InstallmentSaleReturn", ClaimDesc = "Kredit Satış Qaytarması", ClaimTypeId = 1, CategoryId = 8 },
                new DcClaim { ClaimCode = "DeleteInvoiceRP", ClaimDesc = "Pərakəndə Alış Fakturası Silmə", ClaimTypeId = 1, CategoryId = 3 },
                new DcClaim { ClaimCode = "DeleteInvoiceWP", ClaimDesc = "Topdan Alış Fakturası Silmə", ClaimTypeId = 1, CategoryId = 4 },
                new DcClaim { ClaimCode = "DeleteInvoiceRS", ClaimDesc = "Pərakəndə Satış Fakturası Silmə", ClaimTypeId = 1, CategoryId = 5 },
                new DcClaim { ClaimCode = "DeleteInvoiceWS", ClaimDesc = "Topdan Satış Fakturası Silmə", ClaimTypeId = 1, CategoryId = 6 },
                new DcClaim { ClaimCode = "DeleteInvoiceIP", ClaimDesc = "Kredit Alış Fakturası Silmə", ClaimTypeId = 1, CategoryId = 7 },
                new DcClaim { ClaimCode = "DeleteInvoiceIS", ClaimDesc = "Kredit Satış Fakturası Silmə", ClaimTypeId = 1, CategoryId = 8 },
                new DcClaim { ClaimCode = "DeleteInvoiceEX", ClaimDesc = "Xərc Fakturası Silmə", ClaimTypeId = 1, CategoryId = 9 },
                new DcClaim { ClaimCode = "DeleteInvoiceCI", ClaimDesc = "Sayım Artırma Fakturası Silmə", ClaimTypeId = 1, CategoryId = 10 },
                new DcClaim { ClaimCode = "DeleteInvoiceCO", ClaimDesc = "Sayım Azaltma Fakturası Silmə", ClaimTypeId = 1, CategoryId = 11 },
                new DcClaim { ClaimCode = "DeleteInvoiceIT", ClaimDesc = "Transfer Fakturası Silmə", ClaimTypeId = 1, CategoryId = 14 },
                new DcClaim { ClaimCode = "DeleteInvoiceRPO", ClaimDesc = "Pərakəndə Alış Sifarişi Silmə", ClaimTypeId = 1, CategoryId = 3 },
                new DcClaim { ClaimCode = "DeleteInvoiceWPO", ClaimDesc = "Topdan Alış Sifarişi Silmə", ClaimTypeId = 1, CategoryId = 4 },
                new DcClaim { ClaimCode = "DeleteInvoiceRSO", ClaimDesc = "Pərakəndə Satış Sifarişi Silmə", ClaimTypeId = 1, CategoryId = 5 },
                new DcClaim { ClaimCode = "DeleteInvoiceWSO", ClaimDesc = "Topdan Satış Sifarişi Silmə", ClaimTypeId = 1, CategoryId = 6 },
                new DcClaim { ClaimCode = "DeleteInvoiceIPO", ClaimDesc = "Kredit Alış Sifarişi Silmə", ClaimTypeId = 1, CategoryId = 7 },
                new DcClaim { ClaimCode = "DeleteInvoiceISO", ClaimDesc = "Kredit Satış Sifarişi Silmə", ClaimTypeId = 1, CategoryId = 8 },
                new DcClaim { ClaimCode = "DeleteLineRP", ClaimDesc = "Pərakəndə Alış Fakturası Sətiri Silmə", ClaimTypeId = 1, CategoryId = 3 },
                new DcClaim { ClaimCode = "DeleteLineWP", ClaimDesc = "Topdan Alış Fakturası Sətiri Silmə", ClaimTypeId = 1, CategoryId = 4 },
                new DcClaim { ClaimCode = "DeleteLineRS", ClaimDesc = "Pərakəndə Satış Sətiri Silmə", ClaimTypeId = 1, CategoryId = 5 },
                new DcClaim { ClaimCode = "DeleteLineWS", ClaimDesc = "Topdan Satış Sətiri Silmə", ClaimTypeId = 1, CategoryId = 6 },
                new DcClaim { ClaimCode = "DeleteLineIP", ClaimDesc = "Kredit Alış Sətiri Silmə", ClaimTypeId = 1, CategoryId = 7 },
                new DcClaim { ClaimCode = "DeleteLineIS", ClaimDesc = "Kredit Satış Sətiri Silmə", ClaimTypeId = 1, CategoryId = 8 },
                new DcClaim { ClaimCode = "DeleteLineEX", ClaimDesc = "Xərc Sətiri Silmə", ClaimTypeId = 1, CategoryId = 9 },
                new DcClaim { ClaimCode = "DeleteLineCI", ClaimDesc = "Sayım Artırma Sətiri Silmə", ClaimTypeId = 1, CategoryId = 10 },
                new DcClaim { ClaimCode = "DeleteLineCO", ClaimDesc = "Sayım Azaltma Sətiri Silmə", ClaimTypeId = 1, CategoryId = 11 },
                new DcClaim { ClaimCode = "DeleteLineIT", ClaimDesc = "Məhsul Transfer Sətiri Silmə", ClaimTypeId = 1, CategoryId = 14 },
                new DcClaim { ClaimCode = "DeleteLineRPO", ClaimDesc = "Pərakəndə Alış Sifarişi Sətiri Silmə", ClaimTypeId = 1, CategoryId = 3 },
                new DcClaim { ClaimCode = "DeleteLineWPO", ClaimDesc = "Topdan Alış Sifarişi Sətiri Silmə", ClaimTypeId = 1, CategoryId = 4 },
                new DcClaim { ClaimCode = "DeleteLineRSO", ClaimDesc = "Pərakəndə Satış Sifarişi Sətiri Silmə", ClaimTypeId = 1, CategoryId = 5 },
                new DcClaim { ClaimCode = "DeleteLineWSO", ClaimDesc = "Topdan Satış Sifarişi Sətiri Silmə", ClaimTypeId = 1, CategoryId = 6 },
                new DcClaim { ClaimCode = "DeleteLineIPO", ClaimDesc = "Kredit Alış Sifarişi Sətiri Silmə", ClaimTypeId = 1, CategoryId = 7 },
                new DcClaim { ClaimCode = "DeleteLineISO", ClaimDesc = "Kredit Satış Sifarişi Sətiri Silmə", ClaimTypeId = 1, CategoryId = 8 },
                new DcClaim { ClaimCode = "RetailPurchaseReturnCustom", ClaimDesc = "Pərakəndə Alış Xüsusi Geri Qaytarması", ClaimTypeId = 1, CategoryId = 3 },
                new DcClaim { ClaimCode = "WholePurchaseReturnCustom", ClaimDesc = "Topdan Alış Xüsusi Geri Qaytarması", ClaimTypeId = 1, CategoryId = 4 },
                new DcClaim { ClaimCode = "RetailSaleReturnCustom", ClaimDesc = "Pərakəndə Satış Xüsusi Geri Qaytarması", ClaimTypeId = 1, CategoryId = 5 },
                new DcClaim { ClaimCode = "WholesaleReturnCustom", ClaimDesc = "Topdan Satış Xüsusi Geri Qaytarması", ClaimTypeId = 1, CategoryId = 6 },
                new DcClaim { ClaimCode = "InstallmentPurchaseReturnCustom", ClaimDesc = "Kredit Alış Xüsusi Geri Qaytarması", ClaimTypeId = 1, CategoryId = 7 },
                new DcClaim { ClaimCode = "InstallmentSaleReturnCustom", ClaimDesc = "Kredit Satış Xüsusi Geri Qaytarması", ClaimTypeId = 1, CategoryId = 8 },
                new DcClaim { ClaimCode = "InventoryTransferReturnCustom", ClaimDesc = "Məhsul Transferi Xüsusi Qaytarması", ClaimTypeId = 1, CategoryId = 14 },
                new DcClaim { ClaimCode = "Column_ProductCost", ClaimDesc = "Maya Dəyəri", ClaimTypeId = 1, CategoryId = 18 },
                new DcClaim { ClaimCode = "ProductDiscountList", ClaimDesc = "Endirim Siyahısı", ClaimTypeId = 1, CategoryId = 18 },
                new DcClaim { ClaimCode = "PaymentDetail", ClaimDesc = "Ödəmə", ClaimTypeId = 1, CategoryId = 21 },
                new DcClaim { ClaimCode = "PosDiscount", ClaimDesc = "POS Endirimi", ClaimTypeId = 1, CategoryId = 2 },
                new DcClaim { ClaimCode = "PriceList", ClaimDesc = "Qiymət Cədvəli", ClaimTypeId = 1, CategoryId = 18 },
                new DcClaim { ClaimCode = "CurrAccFeatureType", ClaimDesc = "Cari Hesab Özəlliyi", ClaimTypeId = 1, CategoryId = 19 },
                new DcClaim { ClaimCode = "CurrAccCreditLimit", ClaimDesc = "Cari Hesab Kredit Limiti", ClaimTypeId = 1, CategoryId = 19 },
                new DcClaim { ClaimCode = "ProductFeatureType", ClaimDesc = "Məhsul Özəllik Tipləri", ClaimTypeId = 1, CategoryId = 18 },
                new DcClaim { ClaimCode = "CurrAccClaim", ClaimDesc = "Cari hesab yetkisi", ClaimTypeId = 1, CategoryId = 15 },
                new DcClaim { ClaimCode = "Session", ClaimDesc = "Sessiya", ClaimTypeId = 1, CategoryId = 15 },
                new DcClaim { ClaimCode = "ExpenseOfInvoice", ClaimDesc = "Faktura Xərci", ClaimTypeId = 1, CategoryId = 2 },
                new DcClaim { ClaimCode = "InstallmentSales", ClaimDesc = "Kreditlər", ClaimTypeId = 1, CategoryId = 8 },
                new DcClaim { ClaimCode = "InstallmentCommissionChange", ClaimDesc = "Kreditin Kamissiyasını Dəyişmə", ClaimTypeId = 1, CategoryId = 8 },
                new DcClaim { ClaimCode = "EditLockedInvoice", ClaimDesc = "Kilidli Fakturanı Dəyiş", ClaimTypeId = 1, CategoryId = 2 },
                new DcClaim { ClaimCode = "EditLockedPayment", ClaimDesc = "Kilidli Ödənişi Dəyiş", ClaimTypeId = 1, CategoryId = 2 },
                new DcClaim { ClaimCode = "Parameters", ClaimDesc = "Parametrlər", ClaimTypeId = 1, CategoryId = 15 },
                new DcClaim { ClaimCode = "StoreList", ClaimDesc = "Mağaza Siyahısı", ClaimTypeId = 1, CategoryId = 22 },
                new DcClaim { ClaimCode = "ChangePriceRP", ClaimDesc = "Pərakəndə Alış Qiymət Dəyişmə", ClaimTypeId = 1, CategoryId = 3 },
                new DcClaim { ClaimCode = "ChangePriceWP", ClaimDesc = "Topdan Alış Qiymət Dəyişmə", ClaimTypeId = 1, CategoryId = 4 },
                new DcClaim { ClaimCode = "ChangePriceRS", ClaimDesc = "Pərakəndə Satış Qiymət Dəyişmə", ClaimTypeId = 1, CategoryId = 5 },
                new DcClaim { ClaimCode = "ChangePriceWS", ClaimDesc = "Topdan Satış Qiymət Dəyişmə", ClaimTypeId = 1, CategoryId = 6 },
                new DcClaim { ClaimCode = "ChangePriceIP", ClaimDesc = "Kredit Alış Qiymət Dəyişmə", ClaimTypeId = 1, CategoryId = 7 },
                new DcClaim { ClaimCode = "ChangePriceIS", ClaimDesc = "Kredit Alış Qiymət Dəyişmə", ClaimTypeId = 1, CategoryId = 8 },
                new DcClaim { ClaimCode = "ChangePriceEX", ClaimDesc = "Xərc Qiymət Dəyişmə", ClaimTypeId = 1, CategoryId = 9 },
                new DcClaim { ClaimCode = "ChangePriceCI", ClaimDesc = "Sayım Artırma Qiymət Dəyişmə", ClaimTypeId = 1, CategoryId = 10 },
                new DcClaim { ClaimCode = "ChangePriceCO", ClaimDesc = "Sayım Azaltma Qiymət Dəyişmə", ClaimTypeId = 1, CategoryId = 11 }
                );

            modelBuilder.Entity<DcClaimType>().HasData(
                new DcClaimType { ClaimTypeId = 1, ClaimTypeDesc = "Embedded" },
                new DcClaimType { ClaimTypeId = 2, ClaimTypeDesc = "Report" },
                new DcClaimType { ClaimTypeId = 3, ClaimTypeDesc = "Column" }
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
                new TrRoleClaim { RoleClaimId = 4, RoleCode = "Admin", ClaimCode = "Column_ProductCost" },
                new TrRoleClaim { RoleClaimId = 5, RoleCode = "Admin", ClaimCode = "CountIn" },
                new TrRoleClaim { RoleClaimId = 6, RoleCode = "Admin", ClaimCode = "CountOut" },
                new TrRoleClaim { RoleClaimId = 7, RoleCode = "Admin", ClaimCode = "CurrAccs" },
                new TrRoleClaim { RoleClaimId = 8, RoleCode = "Admin", ClaimCode = "ProductDiscountList" },
                new TrRoleClaim { RoleClaimId = 9, RoleCode = "Admin", ClaimCode = "Expense" },
                new TrRoleClaim { RoleClaimId = 10, RoleCode = "Admin", ClaimCode = "InventoryTransfer" },
                new TrRoleClaim { RoleClaimId = 11, RoleCode = "Admin", ClaimCode = "PaymentDetail" },
                new TrRoleClaim { RoleClaimId = 12, RoleCode = "Admin", ClaimCode = "PosDiscount" },
                new TrRoleClaim { RoleClaimId = 13, RoleCode = "Admin", ClaimCode = "PriceList" },
                new TrRoleClaim { RoleClaimId = 14, RoleCode = "Admin", ClaimCode = "Products" },
                new TrRoleClaim { RoleClaimId = 16, RoleCode = "Admin", ClaimCode = "RetailPurchaseInvoice" },
                new TrRoleClaim { RoleClaimId = 17, RoleCode = "Admin", ClaimCode = "RetailSaleInvoice" },
                new TrRoleClaim { RoleClaimId = 18, RoleCode = "Admin", ClaimCode = "WholesaleInvoice" },
                new TrRoleClaim { RoleClaimId = 19, RoleCode = "Admin", ClaimCode = "RetailPurchaseReturn" },
                new TrRoleClaim { RoleClaimId = 20, RoleCode = "Admin", ClaimCode = "RetailSaleReturn" },
                new TrRoleClaim { RoleClaimId = 21, RoleCode = "Admin", ClaimCode = "WholesaleReturn" },
                new TrRoleClaim { RoleClaimId = 22, RoleCode = "Admin", ClaimCode = "ProductFeatureType" },
                new TrRoleClaim { RoleClaimId = 23, RoleCode = "Admin", ClaimCode = "CurrAccFeatureType" },
                new TrRoleClaim { RoleClaimId = 24, RoleCode = "Admin", ClaimCode = "CurrAccClaim" },
                new TrRoleClaim { RoleClaimId = 25, RoleCode = "Admin", ClaimCode = "Session" },
                new TrRoleClaim { RoleClaimId = 26, RoleCode = "Admin", ClaimCode = "WaybillIn" },
                new TrRoleClaim { RoleClaimId = 27, RoleCode = "Admin", ClaimCode = "WaybillOut" },
                new TrRoleClaim { RoleClaimId = 28, RoleCode = "Admin", ClaimCode = "ExpenseOfInvoice" },
                new TrRoleClaim { RoleClaimId = 29, RoleCode = "Admin", ClaimCode = "InstallmentSaleInvoice" },
                new TrRoleClaim { RoleClaimId = 30, RoleCode = "Admin", ClaimCode = "DeleteInvoiceRP" },
                new TrRoleClaim { RoleClaimId = 31, RoleCode = "Admin", ClaimCode = "DeleteInvoiceRS" },
                new TrRoleClaim { RoleClaimId = 32, RoleCode = "Admin", ClaimCode = "DeleteInvoiceWS" },
                new TrRoleClaim { RoleClaimId = 33, RoleCode = "Admin", ClaimCode = "DeleteInvoiceIS" },
                new TrRoleClaim { RoleClaimId = 34, RoleCode = "Admin", ClaimCode = "DeleteInvoiceEX" },
                new TrRoleClaim { RoleClaimId = 35, RoleCode = "Admin", ClaimCode = "DeleteLineRP" },
                new TrRoleClaim { RoleClaimId = 36, RoleCode = "Admin", ClaimCode = "DeleteLineRS" },
                new TrRoleClaim { RoleClaimId = 37, RoleCode = "Admin", ClaimCode = "DeleteLineWS" },
                new TrRoleClaim { RoleClaimId = 38, RoleCode = "Admin", ClaimCode = "DeleteLineIS" },
                new TrRoleClaim { RoleClaimId = 39, RoleCode = "Admin", ClaimCode = "DeleteLineEX" },
                new TrRoleClaim { RoleClaimId = 40, RoleCode = "Admin", ClaimCode = "InstallmentSaleReturn" },
                new TrRoleClaim { RoleClaimId = 41, RoleCode = "Admin", ClaimCode = "RetailPurchaseReturnCustom" },
                new TrRoleClaim { RoleClaimId = 42, RoleCode = "Admin", ClaimCode = "RetailsaleReturnCustom" },
                new TrRoleClaim { RoleClaimId = 43, RoleCode = "Admin", ClaimCode = "WholesaleReturnCustom" },
                new TrRoleClaim { RoleClaimId = 44, RoleCode = "Admin", ClaimCode = "InstallmentSaleReturnCustom" },
                new TrRoleClaim { RoleClaimId = 45, RoleCode = "Admin", ClaimCode = "InstallmentSales" },
                new TrRoleClaim { RoleClaimId = 46, RoleCode = "Admin", ClaimCode = "InstallmentCommissionChange" },
                new TrRoleClaim { RoleClaimId = 47, RoleCode = "Admin", ClaimCode = "EditLockedInvoice" },
                new TrRoleClaim { RoleClaimId = 48, RoleCode = "Admin", ClaimCode = "EditLockedPayment" },
                new TrRoleClaim { RoleClaimId = 49, RoleCode = "Admin", ClaimCode = "CurrAccCreditLimit" },
                new TrRoleClaim { RoleClaimId = 50, RoleCode = "Admin", ClaimCode = "Parameters" },
                new TrRoleClaim { RoleClaimId = 51, RoleCode = "Admin", ClaimCode = "StoreList" },
                new TrRoleClaim { RoleClaimId = 52, RoleCode = "Admin", ClaimCode = "ChangePriceRP" },
                new TrRoleClaim { RoleClaimId = 53, RoleCode = "Admin", ClaimCode = "ChangePriceWP" },
                new TrRoleClaim { RoleClaimId = 54, RoleCode = "Admin", ClaimCode = "ChangePriceRS" },
                new TrRoleClaim { RoleClaimId = 55, RoleCode = "Admin", ClaimCode = "ChangePriceWS" },
                new TrRoleClaim { RoleClaimId = 56, RoleCode = "Admin", ClaimCode = "ChangePriceIP" },
                new TrRoleClaim { RoleClaimId = 57, RoleCode = "Admin", ClaimCode = "ChangePriceIS" },
                new TrRoleClaim { RoleClaimId = 58, RoleCode = "Admin", ClaimCode = "ChangePriceCI" },
                new TrRoleClaim { RoleClaimId = 59, RoleCode = "Admin", ClaimCode = "ChangePriceCO" }
               );

            modelBuilder.Entity<TrClaimReport>().HasData(
                new TrClaimReport { ClaimReportId = 1, ClaimCode = "ButunHesabatlar", ReportId = 1 },
                new TrClaimReport { ClaimReportId = 2, ClaimCode = "ButunHesabatlar", ReportId = 2 },
                new TrClaimReport { ClaimReportId = 3, ClaimCode = "ButunHesabatlar", ReportId = 3 },
                new TrClaimReport { ClaimReportId = 4, ClaimCode = "ButunHesabatlar", ReportId = 4 },
                new TrClaimReport { ClaimReportId = 5, ClaimCode = "ButunHesabatlar", ReportId = 5 },
                new TrClaimReport { ClaimReportId = 11, ClaimCode = "ButunHesabatlar", ReportId = 11 },
                new TrClaimReport { ClaimReportId = 12, ClaimCode = "ButunHesabatlar", ReportId = 12 },
                new TrClaimReport { ClaimReportId = 13, ClaimCode = "ButunHesabatlar", ReportId = 13 },
                new TrClaimReport { ClaimReportId = 14, ClaimCode = "ButunHesabatlar", ReportId = 14 },
                new TrClaimReport { ClaimReportId = 15, ClaimCode = "ButunHesabatlar", ReportId = 15 },
                new TrClaimReport { ClaimReportId = 16, ClaimCode = "ButunHesabatlar", ReportId = 16 },
                new TrClaimReport { ClaimReportId = 17, ClaimCode = "ButunHesabatlar", ReportId = 17 },
                new TrClaimReport { ClaimReportId = 18, ClaimCode = "ButunHesabatlar", ReportId = 18 }
               );

            CustomMethods cM = new();

            modelBuilder.Entity<DcReport>().HasData(
                new DcReport { ReportId = 1, ReportTypeId = 0, ReportName = "Report_Embedded_ProductList", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Embedded_ProductList.sql"), ReportLayout = "" },
                new DcReport { ReportId = 2, ReportTypeId = 0, ReportName = "Report_Embedded_CurrAccList", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Embedded_CurrAccList.sql"), ReportLayout = "" },
                new DcReport { ReportId = 3, ReportTypeId = 0, ReportName = "Report_Embedded_CashRegList", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Embedded_CashRegList.sql"), ReportLayout = "" },
                new DcReport { ReportId = 4, ReportTypeId = 0, ReportName = "Report_Embedded_InvoiceReport", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Embedded_InvoiceReport.sql"), ReportLayout = "" },
                new DcReport { ReportId = 5, ReportTypeId = 0, ReportName = "Report_Embedded_Barcode", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Embedded_Barcode.sql"), ReportLayout = "" },
                new DcReport { ReportId = 6, ReportTypeId = 0, ReportName = "Report_Embedded_InstallmentSale", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Embedded_InstallmentSale.sql"), ReportLayout = "" },
                new DcReport { ReportId = 7, ReportTypeId = 0, ReportName = "Report_Embedded_StoreList", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Embedded_StoreList.sql"), ReportLayout = "" },
                new DcReport { ReportId = 11, ReportTypeId = 1, ReportCategoryId = 5, ReportName = "Xərclər", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Grid_Expenses.sql"), ReportLayout = "" },
                new DcReport { ReportId = 12, ReportTypeId = 1, ReportCategoryId = 5, ReportName = "Pulun Hərəkəti", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Grid_MoneyMovements.sql"), ReportLayout = "" },
                new DcReport { ReportId = 13, ReportTypeId = 1, ReportCategoryId = 1, ReportName = "Cari Hesab ilə Əməliyatlar", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Grid_MovementsWithAccounts.sql"), ReportLayout = "" },
                new DcReport { ReportId = 14, ReportTypeId = 1, ReportCategoryId = 3, ReportName = "Məhsulun Hərəkəti", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Grid_ProductMovements.sql"), ReportLayout = "" },
                new DcReport { ReportId = 15, ReportTypeId = 1, ReportCategoryId = 7, ReportName = "Gəlir", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Grid_Profit.sql"), ReportLayout = "" },
                new DcReport { ReportId = 16, ReportTypeId = 1, ReportCategoryId = 3, ReportName = "Son Gələn Mallar", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Grid_RecentGoods.sql"), ReportLayout = "" },
                new DcReport { ReportId = 17, ReportTypeId = 1, ReportCategoryId = 3, ReportName = "Depoların Qalığı", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Grid_WarehouseBalance.sql"), ReportLayout = "" },
                new DcReport { ReportId = 18, ReportTypeId = 2, ReportCategoryId = 3, ReportName = "Məhsul Kartı", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Detail_ProductCard.sql"), ReportLayout = "" },
                new DcReport { ReportId = 19, ReportTypeId = 1, ReportCategoryId = 3, ReportName = "Məhsul Qalığı", ReportQuery = cM.GetDataFromFile("Foxoft.AppCode.Report." + "Report_Grid_ProductBalanceSerialNumber.sql"), ReportLayout = "" }
               // reportlarin layoutlarin FormLogin de duzelt
               );

            modelBuilder.Entity<DcReportVariableType>().HasData(
                new DcReportVariableType { VariableTypeId = 1, VariableTypeDesc = "Parameter" },
                new DcReportVariableType { VariableTypeId = 2, VariableTypeDesc = "Filter" }
               );

            modelBuilder.Entity<DcReportVariable>().HasData(
                new DcReportVariable { VariableId = 1, ReportId = 4, VariableTypeId = 1, VariableProperty = "InvoiceHeaderId", Representative = "@InvoiceHeaderId", VariableValue = "", VariableOperator = "", VariableValueType = "System.Guid" },
                new DcReportVariable { VariableId = 2, ReportId = 13, VariableTypeId = 2, VariableProperty = "CurrAccCode", Representative = "{CurrAccCode}", VariableValue = "c-0000001", VariableOperator = "=", VariableValueType = "System.String" },
                new DcReportVariable { VariableId = 3, ReportId = 17, VariableTypeId = 2, VariableProperty = "DocumentDate", Representative = "{StartDate}", VariableValue = "08.01.2030", VariableOperator = "<=", VariableValueType = "System.DateTime" }
               );

            modelBuilder.Entity<DcReportCategory>().HasData(
                new DcReportCategory { ReportCategoryId = 1, ReportCategoryDesc = "Satış və Müştəri Hesabatları" },
                new DcReportCategory { ReportCategoryId = 2, ReportCategoryDesc = "Satınalma və Təchizatçı Hesabatları" },
                new DcReportCategory { ReportCategoryId = 3, ReportCategoryDesc = "Məhsul və Stok Hesabatları" },
                new DcReportCategory { ReportCategoryId = 4, ReportCategoryDesc = "İstehsal Hesabatları" },
                new DcReportCategory { ReportCategoryId = 5, ReportCategoryDesc = "Maliyyə Hesabatları" },
                new DcReportCategory { ReportCategoryId = 6, ReportCategoryDesc = "Kadr və İnsan Resursları Hesabatları" },
                new DcReportCategory { ReportCategoryId = 7, ReportCategoryDesc = "Mənfəət/Zərər və Rentabellik Hesabatları" }
            );

            modelBuilder.Entity<DcOffice>().HasData(
               new DcOffice { OfficeCode = "ofs01", OfficeDesc = "Mərkəz Ofisi" }
               );

            modelBuilder.Entity<DcPaymentKind>().HasData(
                new DcPaymentKind { PaymentKindId = 0, PaymentKindDesc = "Unknown" },
                new DcPaymentKind { PaymentKindId = 1, PaymentKindDesc = "Payment" },
                new DcPaymentKind { PaymentKindId = 2, PaymentKindDesc = "Invoice" },
                new DcPaymentKind { PaymentKindId = 3, PaymentKindDesc = "Installment" }
                );

            modelBuilder.Entity<DcPaymentType>().HasData(
                new DcPaymentType { PaymentTypeCode = 1, PaymentTypeDesc = "Nağd" },
                new DcPaymentType { PaymentTypeCode = 2, PaymentTypeDesc = "Nağdsız" },
                new DcPaymentType { PaymentTypeCode = 3, PaymentTypeDesc = "Bonus" },
                new DcPaymentType { PaymentTypeCode = 4, PaymentTypeDesc = "Komissiya" }
                );

            modelBuilder.Entity<DcPaymentMethod>().HasData(
                new DcPaymentMethod { PaymentMethodId = 1, PaymentTypeCode = 1, PaymentMethodDesc = "Nağd" },
                new DcPaymentMethod { PaymentMethodId = 2, PaymentTypeCode = 3, PaymentMethodDesc = "Daxili Kredit" },// Internal Credit
                new DcPaymentMethod { PaymentMethodId = 3, PaymentTypeCode = 2, PaymentMethodDesc = "Bir Kart", IsRedirected = true, RedirectedCurrAccCode = "C-000006" },
                new DcPaymentMethod { PaymentMethodId = 4, PaymentTypeCode = 1, PaymentMethodDesc = "Çatdırılma zamanı nağd ödə" },
                new DcPaymentMethod { PaymentMethodId = 5, PaymentTypeCode = 2, PaymentMethodDesc = "Saytda nağd ödə" }
                );

            modelBuilder.Entity<DcPaymentPlan>().HasData(
                new DcPaymentPlan { PaymentPlanCode = "M03", PaymentPlanDesc = "3 AY", PaymentMethodId = 2, DurationInMonths = 3 },
                new DcPaymentPlan { PaymentPlanCode = "M06", PaymentPlanDesc = "6 AY", PaymentMethodId = 2, DurationInMonths = 6 },
                new DcPaymentPlan { PaymentPlanCode = "M09", PaymentPlanDesc = "9 AY", PaymentMethodId = 2, DurationInMonths = 9 },
                new DcPaymentPlan { PaymentPlanCode = "M12", PaymentPlanDesc = "12 AY", PaymentMethodId = 2, DurationInMonths = 12 },
                new DcPaymentPlan { PaymentPlanCode = "M18", PaymentPlanDesc = "18 AY", PaymentMethodId = 2, DurationInMonths = 18 },
                new DcPaymentPlan { PaymentPlanCode = "M24", PaymentPlanDesc = "24 AY", PaymentMethodId = 2, DurationInMonths = 24 },
                new DcPaymentPlan { PaymentPlanCode = "B03", PaymentPlanDesc = "3 AY", PaymentMethodId = 3, DurationInMonths = 3 },
                new DcPaymentPlan { PaymentPlanCode = "B06", PaymentPlanDesc = "6 AY", PaymentMethodId = 3, DurationInMonths = 6 },
                new DcPaymentPlan { PaymentPlanCode = "B09", PaymentPlanDesc = "9 AY", PaymentMethodId = 3, DurationInMonths = 9 },
                new DcPaymentPlan { PaymentPlanCode = "B12", PaymentPlanDesc = "12 AY", PaymentMethodId = 3, DurationInMonths = 12 },
                new DcPaymentPlan { PaymentPlanCode = "B18", PaymentPlanDesc = "18 AY", PaymentMethodId = 3, DurationInMonths = 18 },
                new DcPaymentPlan { PaymentPlanCode = "B24", PaymentPlanDesc = "24 AY", PaymentMethodId = 3, DurationInMonths = 24 }
                );

            modelBuilder.Entity<DcProcess>().HasData(
                new DcProcess { ProcessCode = "RP", ProcessDesc = "Alış", ProcessDir = 1 },
                new DcProcess { ProcessCode = "RS", ProcessDesc = "Satış", ProcessDir = 2 },
                new DcProcess { ProcessCode = "RPO", ProcessDesc = "Alış Sifarişi", ProcessDir = 1 },
                new DcProcess { ProcessCode = "RSO", ProcessDesc = "Satış Sifarişi", ProcessDir = 2 },
                new DcProcess { ProcessCode = "SB", ProcessDesc = "Toptan Alış", ProcessDir = 1 },
                new DcProcess { ProcessCode = "WS", ProcessDesc = "Toptan Satış", ProcessDir = 2 },
                new DcProcess { ProcessCode = "SBO", ProcessDesc = "Toptan Alış Sifarişi", ProcessDir = 1 },
                new DcProcess { ProcessCode = "WSO", ProcessDesc = "Toptan Satış Sifarişi", ProcessDir = 2 },
                new DcProcess { ProcessCode = "CI", ProcessDesc = "Sayım Artırma", ProcessDir = 1 },
                new DcProcess { ProcessCode = "CO", ProcessDesc = "Sayım Azaltma", ProcessDir = 2 },
                new DcProcess { ProcessCode = "WI", ProcessDesc = "Təhvil Alma", ProcessDir = 1 },
                new DcProcess { ProcessCode = "WO", ProcessDesc = "Təhvil Vermə", ProcessDir = 2 },
                new DcProcess { ProcessCode = "PA", ProcessDesc = "Ödəmə", ProcessDir = 2 },
                new DcProcess { ProcessCode = "EX", ProcessDesc = "Xərc", ProcessDir = 1 },
                new DcProcess { ProcessCode = "EI", ProcessDesc = "Faktura Xərci", ProcessDir = 1 },
                new DcProcess { ProcessCode = "PE", ProcessDesc = "Dovr", ProcessDir = 1 },
                new DcProcess { ProcessCode = "TF", ProcessDesc = "Transfer", ProcessDir = 2 },
                new DcProcess { ProcessCode = "IT", ProcessDesc = "Mal Transferi", ProcessDir = 2 },
                new DcProcess { ProcessCode = "CT", ProcessDesc = "Pul Transferi", ProcessDir = 2 },
                new DcProcess { ProcessCode = "PL", ProcessDesc = "Qiymət Cədvəli", ProcessDir = 0 },
                new DcProcess { ProcessCode = "IS", ProcessDesc = "Kredit Satışı", ProcessDir = 2 }
                );

            modelBuilder.Entity<DcProduct>().HasData(
                new DcProduct { ProductTypeCode = 1, ProductCode = "test01", DefaultUnitOfMeasureId = 1, ProductDesc = "Test Məhsul 01", RetailPrice = 4.5m, CreatedDate = new DateTime(1901, 01, 01) },
                new DcProduct { ProductTypeCode = 1, ProductCode = "test02", DefaultUnitOfMeasureId = 1, ProductDesc = "Test Məhsul 01", RetailPrice = 2.5m, CreatedDate = new DateTime(1901, 01, 01) },
                new DcProduct { ProductTypeCode = 2, ProductCode = "xerc01", DefaultUnitOfMeasureId = 1, ProductDesc = "Yol Xərci", CreatedDate = new DateTime(1901, 01, 01) },
                new DcProduct { ProductTypeCode = 2, ProductCode = "xerc02", DefaultUnitOfMeasureId = 1, ProductDesc = "İşıq Pulu", CreatedDate = new DateTime(1901, 01, 01) }
            );

            modelBuilder.Entity<DcUnitOfMeasure>().HasData(
                new DcUnitOfMeasure { UnitOfMeasureId = 1, UnitOfMeasureDesc = "ədəd", ConversionRate = 1, Level = 0 },
                new DcUnitOfMeasure { UnitOfMeasureId = 2, UnitOfMeasureDesc = "kq", ConversionRate = 1, Level = 0 },
                new DcUnitOfMeasure { UnitOfMeasureId = 3, UnitOfMeasureDesc = "metr", ConversionRate = 1, Level = 0 },
                new DcUnitOfMeasure { UnitOfMeasureId = 4, UnitOfMeasureDesc = "litr", ConversionRate = 1, Level = 0 }
            );

            modelBuilder.Entity<DcBarcodeType>().HasData(
                new DcBarcodeType { BarcodeTypeCode = "Serbest", BarcodeTypeDesc = "Sərbəst", DefaultBarcodeType = false },
                new DcBarcodeType { BarcodeTypeCode = "EAN13", BarcodeTypeDesc = "EAN13", DefaultBarcodeType = true }
            );

            modelBuilder.Entity<DcProductType>().HasData(
                new DcProductType { ProductTypeCode = 1, ProductTypeDesc = "Məhsul" },
                new DcProductType { ProductTypeCode = 2, ProductTypeDesc = "Xərc" },
                new DcProductType { ProductTypeCode = 3, ProductTypeDesc = "Servis" }
            );

            modelBuilder.Entity<DcWarehouse>().HasData(
                new DcWarehouse { WarehouseCode = "depo-01", WarehouseDesc = "Mərkəz deposu", OfficeCode = "ofs01", StoreCode = "mgz01", IsDefault = true });

            modelBuilder.Entity<DcReportType>().HasData(
                new DcReportType { ReportTypeId = 0, ReportTypeDesc = "Embedded" },
                new DcReportType { ReportTypeId = 1, ReportTypeDesc = "Grid" },
                new DcReportType { ReportTypeId = 2, ReportTypeDesc = "Detail" }
                );

            modelBuilder.Entity<DcPriceType>().HasData(
                new DcPriceType { PriceTypeCode = "STD", PriceTypeDesc = "Standart" }
                );

            CustomMethods customMethods = new();
            string gvListDefault = customMethods.GetDataFromFile("Foxoft.AppCode.GvListDefaultLayout.xml");

            modelBuilder.Entity<AppSetting>().HasData(
                new AppSetting { Id = 1, GridViewLayout = gvListDefault, DefaultUnitOfMeasureId = 1 });

            modelBuilder.Entity<DcVariable>().HasData(
                new DcVariable { VariableCode = "20", VariableDesc = "Barkod" },
                new DcVariable { VariableCode = "C", VariableDesc = "Cari" },
                new DcVariable { VariableCode = "CI", VariableDesc = "Sayım Artırma" },
                new DcVariable { VariableCode = "CO", VariableDesc = "Sayım Azaltma" },
                new DcVariable { VariableCode = "WI", VariableDesc = "Təhvil Alma" },
                new DcVariable { VariableCode = "WO", VariableDesc = "Təhvil Vermə" },
                new DcVariable { VariableCode = "P", VariableDesc = "Məhsul" },
                new DcVariable { VariableCode = "RS", VariableDesc = "Pərakəndə Satış" },
                new DcVariable { VariableCode = "RP", VariableDesc = "Pərakəndə Alış" },
                new DcVariable { VariableCode = "PA", VariableDesc = "Ödəmə" },
                new DcVariable { VariableCode = "SB", VariableDesc = "Toptan Alış" },
                new DcVariable { VariableCode = "WS", VariableDesc = "Toptan Satış" },
                new DcVariable { VariableCode = "RSO", VariableDesc = "Pərakəndə Satış Sifarişi" },
                new DcVariable { VariableCode = "RPO", VariableDesc = "Pərakəndə Alış Sifarişi" },
                new DcVariable { VariableCode = "SBO", VariableDesc = "Toptan Alış Sifarişi" },
                new DcVariable { VariableCode = "WSO", VariableDesc = "Topdan Satış Sifarişi" },
                new DcVariable { VariableCode = "EX", VariableDesc = "Xərclər" },
                new DcVariable { VariableCode = "EI", VariableDesc = "Xərclər" },
                new DcVariable { VariableCode = "IT", VariableDesc = "Mal Transferi" },
                new DcVariable { VariableCode = "CT", VariableDesc = "Pul transferi" },
                new DcVariable { VariableCode = "IS", VariableDesc = "Kredit Satışı" }

                );
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
