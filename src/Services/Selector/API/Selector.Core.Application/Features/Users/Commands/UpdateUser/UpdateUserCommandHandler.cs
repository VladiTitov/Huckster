namespace Selector.Core.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler
        : IRequestHandler<UpdateUserCommand, UserModel>
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;

        public UpdateUserCommandHandler(IUserRepositoryAsync userRepositoryAsync)
        {
            _userRepositoryAsync = userRepositoryAsync;
        }

        public async Task<UserModel> Handle(
            UpdateUserCommand request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var updatedEntity = await _userRepositoryAsync.GetByIdAsync(request.Id);
            if (updatedEntity is null) throw new ArgumentNullException(nameof(updatedEntity));

            updatedEntity.UserId = request.UserId;
            updatedEntity.FirstName = request.FirstName;
            updatedEntity.LastName = request.LastName;
            updatedEntity.Username = request.Username;
            
            await _userRepositoryAsync.UpdateAsync(updatedEntity, cancellationToken);

            return updatedEntity;
        }
    }
}
