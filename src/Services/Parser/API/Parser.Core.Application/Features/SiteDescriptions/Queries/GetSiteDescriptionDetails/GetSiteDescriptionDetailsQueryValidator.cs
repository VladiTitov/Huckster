namespace Parser.Core.Application.Features.SiteDescriptions.Queries.GetSiteDescriptionDetails
{
    public class GetSiteDescriptionDetailsQueryValidator : AbstractValidator<GetSiteDescriptionDetailsQuery>
    {
        public GetSiteDescriptionDetailsQueryValidator()
        {
            RuleFor(_ => _.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
