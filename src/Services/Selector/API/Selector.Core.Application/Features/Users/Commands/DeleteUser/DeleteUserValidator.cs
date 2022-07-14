namespace Selector.Core.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserValidator
        : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserValidator()
        {
            RuleFor(_ => _.Id)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.ValueIsRequired);
        }
    }
}
