using Microsoft.EntityFrameworkCore;
using Parser.Core.Domain.Models;
using Parser.Infrastructure.DataAccess.Context;
using Parser.Infrastructure.DataAccess.Interfaces;

namespace Parser.Infrastructure.DataAccess.Repositories
{
    public class AdsRepositoryAsync : IAdsRepositoryAsync
    {
        private readonly DbSet<AdModel> _ads;
        private readonly ApplicationDbContext _context;

        public AdsRepositoryAsync(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _ads = dbContext.Set<AdModel>();
        }

        public async Task<bool> SaveChangesAsync()
            => await
                _context
                    .SaveChangesAsync() >= 0;

        public async Task<IEnumerable<AdModel>> GetAllAds()
            => await
                _ads
                    .ToListAsync();

        public async Task<AdModel> GetAdById(string id)
            => await
                _ads
                    .FirstOrDefaultAsync(item => item.UrlId.Equals(id));

        public void CreateAd(AdModel ad)
            => _ads
                .Add(ad);
    }
}
