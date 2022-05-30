using Repository.Base;
using Selector.Core.Domain.Models;

namespace Selector.Infrastructure.Persistence.Repository
{
    public class UserRepositoryAsync
        : GenericBaseRepositoryAsync<UserModel>, IUserRepositoryAsync
    {
        public UserRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
