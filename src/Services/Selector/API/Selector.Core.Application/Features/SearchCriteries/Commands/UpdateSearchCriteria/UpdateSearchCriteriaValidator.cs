namespace Selector.Core.Application.Features.SearchCriteries.Commands.UpdateSearchCriteria
{
    public class UpdateSearchCriteriaValidator
        : AbstractValidator<UpdateSearchCriteriaCommand>
    {
        public UpdateSearchCriteriaValidator()
        {
            RuleFor(_ => _.Id)
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
