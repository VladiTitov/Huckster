using Parser.Core.Domain.Models;

namespace Parser.Infrastructure.DataAccess.Interfaces
{
    public interface IAdsRepositoryAsync
    {
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<AdModel>> GetAllAds();
        Task<AdModel> GetAdById(string id);
        void CreateAd(AdModel ad);
    }
}
