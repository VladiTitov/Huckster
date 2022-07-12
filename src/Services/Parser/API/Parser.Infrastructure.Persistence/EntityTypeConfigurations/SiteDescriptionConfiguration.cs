namespace Parser.Infrastructure.Persistence.EntityTypeConfigurations
{
    internal class SiteDescriptionConfiguration 
        : IEntityTypeConfiguration<SiteDescription>
    {
        public void Configure(EntityTypeBuilder<SiteDescription> builder)
        {
            builder
                .HasKey(_ => _.Id);
            builder
                .HasIndex(_ => _.Id)
                .IsUnique();
        }
    }
}