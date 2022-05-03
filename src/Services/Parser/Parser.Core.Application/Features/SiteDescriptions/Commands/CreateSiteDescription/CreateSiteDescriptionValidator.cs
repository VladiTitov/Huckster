using FluentValidation;

namespace Parser.Core.Application.Features.SiteDescriptions.Commands.CreateSiteDescription
{
    public class CreateSiteDescriptionValidator : AbstractValidator<CreateSiteDescriptionCommand>
    {
        public CreateSiteDescriptionValidator()
        {
            RuleFor(createSiteDescription =>
            createSiteDescription.Id).NotEqual(Guid.Empty);
            RuleFor(createSiteDescription =>
            createSiteDescription.SiteUrl).NotEmpty();
            RuleFor(createSiteDescription =>
            createSiteDescription.SiteSelector).NotEmpty();
            RuleFor(createSiteDescription =>
            createSiteDescription.SiteModelTypeName).NotEmpty();
            RuleFor(createSiteDescription =>
            createSiteDescription.SiteModelSolutionName).NotEmpty();

        }
    }
}
