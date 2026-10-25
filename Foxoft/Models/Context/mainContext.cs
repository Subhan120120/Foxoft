using Microsoft.EntityFrameworkCore;

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

        public DbSet<DcCompany> DcCompanies { get; set; }
        public DbSet<DcUser> DcUsers { get; set; }
        public DbSet<TrUserCompany> TrUserCompanies { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string mainConnString = Properties.Settings.Default.MainConnString;
                //string conf = config
                //                    .ConnectionStrings
                //                    .ConnectionStrings["subConnString"]
                //                    .ConnectionString;

                optionsBuilder.UseSqlServer(Foxoft.AppCode.SqlLanguageHelper.GetLocalizedConnectionString(mainConnString));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DcCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyCode);
            });

            modelBuilder.Entity<DcUser>(entity =>
            {
                entity.HasKey(e => e.UserName);
                entity.Property(e => e.UserName).HasMaxLength(30);
                entity.Property(e => e.Password).HasMaxLength(100);
                entity.Property(e => e.UserDesc).HasMaxLength(100);
            });

            modelBuilder.Entity<TrUserCompany>(entity =>
            {
                entity.HasKey(e => e.UserCompanyId);
                entity.HasIndex(e => e.CompanyCode);
                entity.HasIndex(e => new { e.UserName, e.CompanyCode }).IsUnique();

                entity.HasOne(d => d.DcCompany)
                    .WithMany(p => p.TrUserCompanies)
                    .HasForeignKey(d => d.CompanyCode)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.DcUser)
                    .WithMany(p => p.TrUserCompanies)
                    .HasForeignKey(d => d.UserName)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            InitializeHasData(modelBuilder);

            InitializeDeleteBehaviour(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }

        private static void InitializeDeleteBehaviour(ModelBuilder modelBuilder)
        {
            //All foreignkeys DeleteBehavior to Restrict (NoAction)
            //foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //    foreignKey.DeleteBehavior = DeleteBehavior.Restrict; // NoAction
        }

        private static void InitializeHasData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DcCompany>().HasData(
               new DcCompany { CompanyCode = "Company01", CompanyDesc = "Şirkət01" }
            );

            modelBuilder.Entity<DcUser>().HasData(
                new DcUser
                {
                    UserName = "admin",
                    Password = "123",
                    UserDesc = "Administrator",
                    IsDisabled = false,
                    RowGuid = new System.Guid("11111111-1111-1111-1111-111111111111")
                }
            );

            modelBuilder.Entity<TrUserCompany>().HasData(
                new TrUserCompany { UserCompanyId = 1, CompanyCode = "Company01", UserName = "admin" }
            );
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
