namespace Selector.Core.Application.Features.Users.Queries.GetAllUsers
{
    internal class GetAllUsersQueryHandler
        : IRequestHandler<GetAllUsersQuery, Response<IReadOnlyList<User>>>
    {
        private readonly IUserRepositoryAsync _repository;

        public GetAllUsersQueryHandler(IUserRepositoryAsync repository)
        {
            _repository = repository;
        }

        public async Task<Response<IReadOnlyList<User>>> Handle(
            GetAllUsersQuery request,
            CancellationToken cancellationToken = default)
        {
            var data = await _repository.GetAllAsync(cancellationToken);
            return new Response<IReadOnlyList<User>>(
                data: data,
                message: ResponseMessages.EntitiesSuccessfullFinded);
        }
    }
}
