namespace Selector.Core.Application.Features.Users.Commands.DeleteUser
{
    internal class DeleteUserCommandHandler
        : IRequestHandler<DeleteUserCommand, Response<bool>>
    {
        private readonly IUserRepositoryAsync _repository;

        public DeleteUserCommandHandler(IUserRepositoryAsync repository)
        {
            _repository = repository;
        }

        public async Task<Response<bool>> Handle(
            DeleteUserCommand request,
            CancellationToken cancellationToken = default)
        {
            return await _repository.GetByIdAsync(request.Id) is User user
                ? await DeleteAsync(user)
                : new Response<bool>(
                    data: false,
                    message: ResponseMessages.EntityNotFound);
        }

        private async Task<Response<bool>> DeleteAsync(
            User user,
            CancellationToken cancellationToken = default)
        {
            await _repository.DeleteAsync(user, cancellationToken);
            return new Response<bool>(
                data: true,
                message: ResponseMessages.EntitySuccessfullyDeleted);
        }
    }
}
