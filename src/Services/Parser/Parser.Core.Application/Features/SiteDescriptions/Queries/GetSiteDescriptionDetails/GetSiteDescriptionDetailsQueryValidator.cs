using FluentValidation;

namespace Parser.Core.Application.Features.SiteDescriptions.Queries.GetSiteDescriptionDetails
{
    public class GetSiteDescriptionDetailsQueryValidator : AbstractValidator<GetSiteDescriptionDetailsQuery>
    {
        public GetSiteDescriptionDetailsQueryValidator()
        {
            RuleFor(getSiteDescriptionDetailsQuery =>
            getSiteDescriptionDetailsQuery.Id).NotEqual(Guid.Empty);
        }
    }
}
