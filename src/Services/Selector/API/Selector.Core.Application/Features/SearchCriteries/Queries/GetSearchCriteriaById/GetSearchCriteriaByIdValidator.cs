namespace Selector.Core.Application.Features.SearchCriteries.Queries.GetSearchCriteriaById
{
    public class GetSearchCriteriaByIdValidator
        : AbstractValidator<GetSearchCriteriaByIdQuery>
    {
        public GetSearchCriteriaByIdValidator()
        {
            RuleFor(_ => _.Id)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.ValueIsRequired);
        }
    }
}
