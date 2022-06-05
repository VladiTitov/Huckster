namespace Parser.Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<SiteDescription> SitesDescriptions { get; set; }
        public DbSet<AdModel> Ads { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AdModelConfiguration());
            builder.ApplyConfiguration(new SiteDescriptionConfiguration());
            base.OnModelCreating(builder);
        }
    }
}