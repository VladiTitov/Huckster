namespace Selector.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class UserConfigurations
        : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(_ => _.Id);

            builder
                .HasIndex(_ => _.Id)
                .IsUnique();
        }
    }
}
