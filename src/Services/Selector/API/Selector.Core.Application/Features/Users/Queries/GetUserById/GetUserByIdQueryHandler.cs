namespace Selector.Core.Application.Features.Users.Queries.GetUserById
{
    internal class GetUserByIdQueryHandler
        : IRequestHandler<GetUserByIdQuery, Response<User>>
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;

        public GetUserByIdQueryHandler(IUserRepositoryAsync userRepositoryAsync)
        {
            _userRepositoryAsync = userRepositoryAsync;
        }

        public async Task<Response<User>> Handle(
            GetUserByIdQuery request, 
            CancellationToken cancellationToken)
        {
            return await _userRepositoryAsync.GetByIdAsync(
                id: request.Id,
                cancellationToken: cancellationToken) is User user
                ? new Response<User>(
                    data: user,
                    message: ResponseMessages.EntitySuccessfullFinded)
                : new Response<User>(message: ResponseMessages.EntityNotFound);
        }
    }
}
