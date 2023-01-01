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
      public DbSet<DcCurrAcc> DcCurrAccs { get; set; }
      public DbSet<DcCurrAccType> DcCurrAccTypes { get; set; }
      public DbSet<DcOffice> DcOffices { get; set; }
      public DbSet<DcPaymentType> DcPaymentTypes { get; set; }
      public DbSet<DcProcess> DcProcesses { get; set; }
      public DbSet<DcProduct> DcProducts { get; set; }
      public DbSet<DcProductType> DcProductTypes { get; set; }
      public DbSet<DcRole> DcRoles { get; set; }
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
      public DbSet<TrShipmentHeader> TrShipmentHeaders { get; set; }
      public DbSet<TrShipmentLine> TrShipmentLines { get; set; }
      public DbSet<DcReport> DcReports { get; set; }
      public DbSet<DcFeature> DcFeatures { get; set; }
      public DbSet<AppSetting> AppSettings { get; set; }
      public DbSet<DcVariable> DcVariables { get; set; }
      public DbSet<TrPrice> TrPrices { get; set; }
      public DbSet<DcCurrency> DcCurrencies { get; set; }
      public DbSet<DcProductDcFeature> DcProductDcFeatures { get; set; }
      public DbSet<RetailSale> RetailSales { get; set; } // view
      public DbSet<DcReportFilter> DcReportFilters { get; set; } // view

      Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         if (!optionsBuilder.IsConfigured)
         {
            string def = Settings.Default.subConnString;
            //string conf = config
            //                    .ConnectionStrings
            //                    .ConnectionStrings["Foxoft.Properties.Settings.subConnString"]
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
             new DcCurrAcc { CurrAccCode = "CA-1", FirstName = "Sübhan", LastName = "Hüseynzadə", NewPassword = "123", PhoneNum = "0519678909", CurrAccTypeCode = 3, CreatedDate = new DateTime(1901, 01, 01), OfficeCode = "ofs01", StoreCode = "mgz01" },
             new DcCurrAcc { CurrAccCode = "CA-2", FirstName = "Mudir", LastName = "Mudir", NewPassword = "123", PhoneNum = "0519678909", CurrAccTypeCode = 3, CreatedDate = new DateTime(1901, 01, 01), OfficeCode = "ofs01", StoreCode = "mgz01" },
             new DcCurrAcc { CurrAccCode = "CA-3", FirstName = "Operator", LastName = "Operator", NewPassword = "123", PhoneNum = "0773628800", CurrAccTypeCode = 3, CreatedDate = new DateTime(1901, 01, 01), OfficeCode = "ofs01", StoreCode = "mgz01" },
             new DcCurrAcc { CurrAccCode = "CA-4", FirstName = "Satici", LastName = "Satici", NewPassword = "123", PhoneNum = "0553628804", CurrAccTypeCode = 3, CreatedDate = new DateTime(1901, 01, 01), OfficeCode = "ofs01", StoreCode = "mgz01" },
             new DcCurrAcc { CurrAccCode = "mgz01", CurrAccDesc = "Merkez Mağaza", NewPassword = "456", PhoneNum = "0773628800", CurrAccTypeCode = 4, CreatedDate = new DateTime(1901, 01, 01), OfficeCode = "ofs01", StoreCode = "mgz01" },
             new DcCurrAcc { CurrAccCode = "kassa01", CurrAccDesc = "Nağd Kassa", NewPassword = "456", PhoneNum = "", CurrAccTypeCode = 5, CreatedDate = new DateTime(1901, 01, 01), OfficeCode = "ofs01", StoreCode = "mgz01" });

         modelBuilder.Entity<DcCurrAccType>().HasData(
             new DcCurrAccType { CurrAccTypeCode = 1, CurrAccTypeDesc = "Müştəri" },
             new DcCurrAccType { CurrAccTypeCode = 2, CurrAccTypeDesc = "Tədarikçi" },
             new DcCurrAccType { CurrAccTypeCode = 3, CurrAccTypeDesc = "Personal" },
             new DcCurrAccType { CurrAccTypeCode = 4, CurrAccTypeDesc = "Mağaza" },
             new DcCurrAccType { CurrAccTypeCode = 5, CurrAccTypeDesc = "Kassa" }
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
             new DcClaim { ClaimCode = "PosDiscount", ClaimDesc = "POS Endirimi" });


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
             new DcProcess { ProcessCode = "TF", ProcessDesc = "Transfer", ProcessDir = 2 }
             );

         modelBuilder.Entity<DcProduct>().HasData(
             new DcProduct { ProductTypeCode = 1, ProductCode = "test01", ProductDesc = "Papaq", Barcode = "123456", RetailPrice = 4.5m, CreatedDate = new DateTime(1901, 01, 01) },
             new DcProduct { ProductTypeCode = 1, ProductCode = "test02", ProductDesc = "Salvar", Barcode = "2000000000013", RetailPrice = 2.5m, CreatedDate = new DateTime(1901, 01, 01) },
             new DcProduct { ProductTypeCode = 2, ProductCode = "xerc01", ProductDesc = "Yol Xerci", Barcode = "", RetailPrice = 0, CreatedDate = new DateTime(1901, 01, 01) },
             new DcProduct { ProductTypeCode = 2, ProductCode = "xerc02", ProductDesc = "Isiq Pulu", Barcode = "", RetailPrice = 0, CreatedDate = new DateTime(1901, 01, 01) }
         );

         modelBuilder.Entity<DcProductDcFeature>()
            .HasKey(bc => new { bc.ProductCode, bc.FeatureId });

         modelBuilder.Entity<DcProductType>().HasData(
             new DcProductType { ProductTypeCode = 1, ProductTypeDesc = "Məhsul" },
             new DcProductType { ProductTypeCode = 2, ProductTypeDesc = "Xərc" }
         );

         modelBuilder.Entity<DcWarehouse>().HasData(
             new DcWarehouse { WarehouseCode = "depo-01", WarehouseDesc = "Bakıxanov deposu", OfficeCode = "ofs01", StoreCode = "mgz01" },
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

         modelBuilder.Entity<TrPaymentLine>(entity =>
         {
            entity.HasOne(x => x.TrPaymentHeader)
                   .WithMany(x => x.TrPaymentLines)
                   .OnDelete(DeleteBehavior.Cascade);
         });

         modelBuilder.Entity<DcReport>().HasData(
             new DcReport { ReportName = "Satis", ReportQuery = "select * from TrInvoiceLines", ReportId = 1 });

         CustomMethods customMethods = new();
         string gvListDefault = customMethods.GetDataFromFile("Foxoft.AppCode.GvListDefaultLayout.xml");

         modelBuilder.Entity<AppSetting>().HasData(
             new AppSetting { Id = 1, GridViewLayout = gvListDefault });

         modelBuilder.Entity<DcVariable>().HasData(
             new DcVariable { VariableCode = "C", VariableDesc = "Cari" },
             new DcVariable { VariableCode = "P", VariableDesc = "Məhsul" },
             new DcVariable { VariableCode = "RS", VariableDesc = "Pərakəndə Satış" },
             new DcVariable { VariableCode = "RP", VariableDesc = "Pərakəndə Alış" },
             new DcVariable { VariableCode = "PA", VariableDesc = "Ödəmə" },
             new DcVariable { VariableCode = "SB", VariableDesc = "Toptan Alış" },
             new DcVariable { VariableCode = "WS", VariableDesc = "Toptan Satış" },
             new DcVariable { VariableCode = "EX", VariableDesc = "Xərclər" });

         modelBuilder.Entity<MigrationHistory>(entity =>
         {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                   .HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);

            entity.Property(e => e.ContextKey).HasMaxLength(300);

            entity.Property(e => e.Model).IsRequired();

            entity.Property(e => e.ProductVersion)
                     .IsRequired()
                     .HasMaxLength(32);
         });

         modelBuilder.Entity<Sysdiagrams>(entity =>
         {
            entity.HasKey(e => e.DiagramId)
                   .HasName("PK_dbo.sysdiagrams");

            entity.ToTable("sysdiagrams");

            entity.Property(e => e.DiagramId).HasColumnName("diagram_id");

            entity.Property(e => e.Definition).HasColumnName("definition");

            entity.Property(e => e.Name)
                   .IsRequired()
                   .HasColumnName("name")
                   .HasMaxLength(128);

            entity.Property(e => e.PrincipalId).HasColumnName("principal_id");

            entity.Property(e => e.Version).HasColumnName("version");
         });

         OnModelCreatingPartial(modelBuilder);
      }



      partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
   }
}
