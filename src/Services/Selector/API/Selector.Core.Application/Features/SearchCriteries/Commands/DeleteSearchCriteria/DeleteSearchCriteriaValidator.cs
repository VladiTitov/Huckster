namespace Selector.Core.Application.Features.SearchCriteries.Commands.DeleteSearchCriteria
{
    public class DeleteSearchCriteriaValidator
        : AbstractValidator<DeleteSearchCriteriaCommand>
    {
        public DeleteSearchCriteriaValidator()
        {
            RuleFor(_ => _.Id)
                .NotEmpty().WithMessage(ValidationMessages.ValueIsRequired);
        }
    }
}
