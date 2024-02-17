
namespace Saluteo.Repository
{
    using Microsoft.EntityFrameworkCore;

    using Saluteo.Models.Entity;
    using Saluteo.Models.Enums;

    public class ApplicationContext : DbContext
    {
        // DbSet properties for each entity

        // Entities 
        public DbSet<Client> Client { get; set; }

        public DbSet<Company> Company { get; set; }

        public DbSet<Discount> Discount { get; set; }

        public DbSet<Branch> Branch { get; set; }

        public DbSet<Location> Location { get; set; }

        // Enums
        public DbSet<EnumCompanyCategory> EnumCompanyCategory { get; set; }

        public DbSet<EnumValueType> EnumValueType { get; set; }

        public DbSet<EnumRegion> EnumRegion { get; set; }

        public DbSet<EnumCountry> EnumCountry { get; set; }

        // Constructor to configure the DbContext
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        // Additional configuration and customization can be added here
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Entity
            this.RegisterEntities(modelBuilder);

            // Enum
            this.RegisterEnums(modelBuilder);

            // Relationships
            //modelBuilder.Entity<Company>()
            //    .HasOne(c => c.CompanyCategory)
            //    .WithMany()
            //    .HasForeignKey(c => c.FkCompanyCategoryId);

            base.OnModelCreating(modelBuilder);
        }

        private void RegisterEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Audit>()
                .HasKey(_ => _.AuditId);

            modelBuilder.Entity<Branch>()
                .HasKey(_ => _.BranchId);

            modelBuilder.Entity<Client>()
                .HasKey(_ => _.ClientId);

            modelBuilder.Entity<Company>()
                .HasKey(_ => _.CompanyId);

            modelBuilder.Entity<Discount>()
                .HasKey(_ => _.DiscountId);

            modelBuilder.Entity<Location>()
                .HasKey(_ => _.LocationId);

            modelBuilder.Entity<Product>()
                .HasKey(_ => _.ProductId);

            modelBuilder.Entity<Promotion>()
                .HasKey(_ => _.PromotionId);

            modelBuilder.Entity<PromotionBranch>()
                .HasKey(_ => _.PromotionBranchId);

            modelBuilder.Entity<PromotionClientClaimed>()
                .HasKey(_ => _.PromotionClientClaimedId);

            modelBuilder.Entity<PromotionPeriod>()
                .HasKey(_ => _.PromotionPeriodId);

            modelBuilder.Entity<PromotionProduct>()
                .HasKey(_ => _.PromotionProductId);

            modelBuilder.Entity<Review>()
                .HasKey(_ => _.ReviewId);

            modelBuilder.Entity<ReviewConfiguration>()
                .HasKey(_ => _.ReviewConfigurationId);

            modelBuilder.Entity<User>()
                .HasKey(_ => _.UserId);

            modelBuilder.Entity<UserBranchAccess>()
                .HasKey(_ => _.UserBranchAccessId);
        }

        private void RegisterEnums(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnumCompanyCategory>()
                .HasKey(e => e.CompanyCategoryId);

            modelBuilder.Entity<EnumCountry>()
                .HasKey(e => e.CountryId);

            modelBuilder.Entity<EnumCurrency>()
                .HasKey(e => e.CurrencyId);

            modelBuilder.Entity<EnumProductCategory>()
                .HasKey(e => e.ProductCategoryId);

            modelBuilder.Entity<EnumPromotionType>()
                .HasKey(e => e.PromotionTypeId);

            modelBuilder.Entity<EnumRecurringType>()
                .HasKey(e => e.RecurringTypeId);

            modelBuilder.Entity<EnumRegion>()
                .HasKey(e => e.RegionId);

            modelBuilder.Entity<EnumReviewType>()
                .HasKey(e => e.ReviewTypeId);

            modelBuilder.Entity<EnumSecurityAccessCode>()
                .HasKey(e => e.SecurityAccessCodeId);

            modelBuilder.Entity<EnumValueType>()
                .HasKey(e => e.ValueTypeId);
        }
    }
}
