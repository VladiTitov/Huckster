namespace Selector.Core.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler
        : IRequestHandler<GetUserByIdQuery, UserModel>
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;

        public GetUserByIdQueryHandler(IUserRepositoryAsync userRepositoryAsync)
        {
            _userRepositoryAsync = userRepositoryAsync;
        }

        public async Task<UserModel> Handle(
            GetUserByIdQuery request, 
            CancellationToken cancellationToken)
        {
            var entity = await _userRepositoryAsync.GetByIdAsync(request.Id, cancellationToken);
            return entity;
        }
    }
}
