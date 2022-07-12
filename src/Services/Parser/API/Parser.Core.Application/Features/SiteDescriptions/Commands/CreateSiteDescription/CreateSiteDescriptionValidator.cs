namespace Parser.Core.Application.Features.SiteDescriptions.Commands.CreateSiteDescription
{
    public class CreateSiteDescriptionValidator 
        : AbstractValidator<CreateSiteDescriptionCommand>
    {
        public CreateSiteDescriptionValidator()
        {
            RuleFor(_ => _.SiteUrl)
                .NotEmpty().WithMessage(ValidationMessages.ValueIsRequired);
            RuleFor(_ => _.SiteSelector)
                .NotEmpty().WithMessage(ValidationMessages.ValueIsRequired);
            RuleFor(_ => _.SiteModelTypeName)
                .NotEmpty().WithMessage(ValidationMessages.ValueIsRequired);
        }
    }
}
