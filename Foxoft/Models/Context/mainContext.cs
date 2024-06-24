using Microsoft.EntityFrameworkCore;
using Foxoft.AppCode;
using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;
using System.IO;
using Foxoft.Models.Entity;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Foxoft.Models
{
    public partial class mainContext : DbContext
    {
        public mainContext() { }

        public mainContext(DbContextOptions<mainContext> options)
            : base(options) { }

        public DbSet<DcCompany> DcCompany { get; set; }
        public DbSet<AppSetting> AppSettings { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string mainConnString = Properties.Settings.Default.mainConnString;
                //string conf = config
                //                    .ConnectionStrings
                //                    .ConnectionStrings["subConnString"]
                //                    .ConnectionString;

                optionsBuilder.UseSqlServer(mainConnString);
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

            modelBuilder.Entity<GetNextDocNum>() //procedure
                        .HasNoKey()
                        .ToView(nameof(GetNextDocNum));

            // more foreign key same table configure
            modelBuilder.Entity<TrPaymentHeader>(e =>
            {
                e.HasOne(field => field.DcStore)
                 .WithMany(fk => fk.DcStoreTrPaymentHeaders)
                 .HasForeignKey(fk => fk.StoreCode);

                e.HasOne(field => field.ToCashReg)
                 .WithMany(fk => fk.ToCashRegTrPaymentHeaders)
                 .HasForeignKey(fk => fk.ToCashRegCode);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        private static void InitializeDeleteBehaviour(ModelBuilder modelBuilder)
        {
            //All foreignkeys DeleteBehavior to Restrict (NoAction)
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict; // NoAction
        }

        private static void InitializeHasData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DcCompany>().HasData(
               new DcCompany { CompanyDesc = "Şirkət01" }
               );
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
