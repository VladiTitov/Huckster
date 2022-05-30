namespace Selector.Core.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand
        : IRequest<Guid>
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
    }
}
