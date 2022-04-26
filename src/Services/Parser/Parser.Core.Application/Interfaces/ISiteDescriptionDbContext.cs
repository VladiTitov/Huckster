using Parser.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Parser.Core.Application.Interfaces
{
    public interface ISiteDescriptionDbContext
    {
        DbSet<SiteDescription> SitesDescriptions { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
