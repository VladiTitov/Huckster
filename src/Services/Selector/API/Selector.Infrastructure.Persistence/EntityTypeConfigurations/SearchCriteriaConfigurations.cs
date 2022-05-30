namespace Selector.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class SearchCriteriaConfigurations
        : IEntityTypeConfiguration<SearchCriteriaModel>
    {
        public void Configure(EntityTypeBuilder<SearchCriteriaModel> builder)
        {
            builder
                .HasKey(_ => _.Id);

            builder
                .HasIndex(_ => _.Id)
                .IsUnique();
        }
    }
}
