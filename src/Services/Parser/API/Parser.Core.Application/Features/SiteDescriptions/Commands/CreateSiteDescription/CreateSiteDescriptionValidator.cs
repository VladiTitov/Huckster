namespace Parser.Core.Application.Features.SiteDescriptions.Commands.CreateSiteDescription
{
    public class CreateSiteDescriptionValidator 
        : AbstractValidator<CreateSiteDescriptionCommand>
    {
        public CreateSiteDescriptionValidator()
        {
            RuleFor(_ => _.SiteUrl)
                .NotEmpty();
            RuleFor(_ => _.SiteSelector)
                .NotEmpty();
            RuleFor(_ => _.SiteModelTypeName)
                .NotEmpty();
        }
    }
}
