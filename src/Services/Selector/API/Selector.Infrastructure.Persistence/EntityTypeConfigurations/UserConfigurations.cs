namespace Selector.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class UserConfigurations
        : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder
                .HasKey(_ => _.Id);

            builder
                .HasIndex(_ => _.Id)
                .IsUnique();

            builder
                .HasMany(i => i.SearchModels)
                .WithOne(i => i.User);
        }
    }
}
