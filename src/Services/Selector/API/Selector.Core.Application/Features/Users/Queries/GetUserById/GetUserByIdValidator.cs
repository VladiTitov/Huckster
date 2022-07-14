namespace Selector.Core.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdValidator
        : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdValidator()
        {
            RuleFor(_ => _.Id)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.ValueIsRequired);
                
        }
    }
}
