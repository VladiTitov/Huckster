namespace Selector.Core.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler
        : IRequestHandler<GetAllUsersQuery, IReadOnlyList<UserModel>>
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;

        public GetAllUsersQueryHandler(IUserRepositoryAsync userRepositoryAsync)
        {
            _userRepositoryAsync = userRepositoryAsync;
        }

        public async Task<IReadOnlyList<UserModel>> Handle(
            GetAllUsersQuery request, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var data = await _userRepositoryAsync.GetAllAsync(cancellationToken);
            return data;
        }
    }
}
