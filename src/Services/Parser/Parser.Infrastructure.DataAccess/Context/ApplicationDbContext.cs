using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Parser.Core.Domain.Models;
using Parser.Infrastructure.DataAccess.Models;

namespace Parser.Infrastructure.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<AdModel> Ads { get; set; }

        private readonly ConnectionStringSettings _connectionStringSettings;

        public ApplicationDbContext(IOptions<ConnectionStringSettings> connectionStringOptions)
        {
            _connectionStringSettings = connectionStringOptions.Value;
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<AdModel>()
                .HasKey(i => i.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseNpgsql(_connectionStringSettings.ToString());
    }
}
