namespace Selector.Core.Application.Features.SearchCriteries.Commands.CreateSearchCriteria
{
    public class CreateSearchCriteriaValidator
        : AbstractValidator<CreateSearchCriteriaCommand>
    {
        public CreateSearchCriteriaValidator()
        {
            RuleFor(_ => _.UserId)
                .NotEmpty().WithMessage(ValidationMessages.ValueIsRequired);
            RuleFor(_ => _.MinCost)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(_ => _.MaxCost);
            RuleFor(_ => _.MaxCost)
                .GreaterThanOrEqualTo(_ => _.MinCost);
            RuleFor(_ => _.Label)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.ValueIsRequired);
        }
    }
}
