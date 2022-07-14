namespace Selector.Core.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<Response<User>>
    {
        public Guid Id { get; set; }
    }
}
