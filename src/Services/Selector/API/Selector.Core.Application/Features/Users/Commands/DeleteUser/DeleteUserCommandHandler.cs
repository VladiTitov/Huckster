namespace Selector.Core.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler
        : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;

        public DeleteUserCommandHandler(IUserRepositoryAsync userRepositoryAsync)
        {
            _userRepositoryAsync = userRepositoryAsync;
        }

        public async Task<bool> Handle(
            DeleteUserCommand request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var entityForDelete = await _userRepositoryAsync.GetByIdAsync(request.Id);
            if (entityForDelete is null) return false;
            await _userRepositoryAsync.DeleteAsync(entityForDelete);
            return true;
        }
    }
}
