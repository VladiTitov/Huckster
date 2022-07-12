namespace ParserService.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class AdModelConfiguration
        : IEntityTypeConfiguration<AdModel>
    {
        public void Configure(EntityTypeBuilder<AdModel> builder)
        {
            builder
                .HasKey(_ => _.Id);
            builder
                .HasIndex(_ => _.Id)
                .IsUnique();
        }
    }
}
