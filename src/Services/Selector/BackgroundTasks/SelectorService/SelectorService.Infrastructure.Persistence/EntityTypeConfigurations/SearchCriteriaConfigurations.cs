namespace SelectorService.Infrastructure.Persistence.EntityTypeConfigurations
{
    internal class SearchCriteriaConfigurations
        : IEntityTypeConfiguration<SearchCriteria>
    {
        public void Configure(EntityTypeBuilder<SearchCriteria> builder)
        {
            builder
                .HasKey(_ => _.Id);

            builder
                .HasIndex(_ => _.Id)
                .IsUnique();

            builder
                .HasOne(searchCriteria => searchCriteria.User)
                .WithMany(user => user.SearchCriterias)
                .HasForeignKey(searchCriteria => searchCriteria.UserId);
        }
    }
}
