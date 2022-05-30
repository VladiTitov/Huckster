namespace Selector.Core.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand
        : IRequest<UserModel>
    { 
        public Guid Id { get; set; }
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
    }
}