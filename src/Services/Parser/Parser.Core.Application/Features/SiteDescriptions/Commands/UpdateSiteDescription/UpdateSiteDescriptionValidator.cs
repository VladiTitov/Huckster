namespace Parser.Core.Application.Features.SiteDescriptions.Commands.UpdateSiteDescription
{
    public class UpdateSiteDescriptionValidator
        : AbstractValidator<UpdateSiteDescriptionCommand>
    {
        public UpdateSiteDescriptionValidator()
        {
            RuleFor(_ => _.Id)
                .NotEqual(Guid.Empty);
            RuleFor(_ => _.SiteUrl)
                .NotEmpty();
            RuleFor(_ => _.SiteSelector)
                .NotEmpty();
            RuleFor(_ => _.SiteModelTypeName)
                .NotEmpty();
            RuleFor(_ => _.SiteModelSolutionName)
                .NotEmpty();
        }
    }
}
