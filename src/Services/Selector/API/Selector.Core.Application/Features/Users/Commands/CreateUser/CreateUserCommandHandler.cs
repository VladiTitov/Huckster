namespace Selector.Core.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler
        : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;

        public CreateUserCommandHandler(IUserRepositoryAsync userRepositoryAsync)
        { 
            _userRepositoryAsync = userRepositoryAsync; 
        
        }
        public async Task<Guid> Handle(
            CreateUserCommand request, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var user = new UserModel
            {
                UserId = request.UserId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username
            };

            await _userRepositoryAsync.AddAsync(user, cancellationToken);

            return user.Id;
        }
    }
}
