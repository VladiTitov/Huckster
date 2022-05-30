using Repository.Base;
using Selector.Core.Domain.Models;

namespace Selector.Infrastructure.Persistence.Interfaces
{
    public interface IUserRepositoryAsync
        : IGenericBaseRepositoryAsync<UserModel>
    {
    }
}
