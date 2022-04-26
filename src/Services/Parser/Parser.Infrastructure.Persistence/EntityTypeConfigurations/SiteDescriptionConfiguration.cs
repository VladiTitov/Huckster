namespace Parser.Infrastructure.Persistence.EntityTypeConfigurations
{
    internal class SiteDescriptionConfiguration : IEntityTypeConfiguration<SiteDescription>
    {
        public void Configure(EntityTypeBuilder<SiteDescription> builder)
        {
            builder.HasKey(siteDescription => siteDescription.Id);
            builder.HasIndex(siteDescription => siteDescription.Id).IsUnique();
        }
    }
}
