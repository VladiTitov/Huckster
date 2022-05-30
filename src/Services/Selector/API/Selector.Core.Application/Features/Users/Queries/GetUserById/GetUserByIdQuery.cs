namespace Selector.Core.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQuery
        : IRequest<UserModel>
    {
        public Guid Id { get; set; }
    }
}
