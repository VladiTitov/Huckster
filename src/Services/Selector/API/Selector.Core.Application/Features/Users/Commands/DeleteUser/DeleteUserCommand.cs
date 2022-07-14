namespace Selector.Core.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
    }
}
