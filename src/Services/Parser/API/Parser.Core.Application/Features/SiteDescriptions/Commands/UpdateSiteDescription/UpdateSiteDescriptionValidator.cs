namespace Parser.Core.Application.Features.SiteDescriptions.Commands.UpdateSiteDescription
{
    public class UpdateSiteDescriptionValidator
        : AbstractValidator<UpdateSiteDescriptionCommand>
    {
        public UpdateSiteDescriptionValidator()
        {
            RuleFor(_ => _.Id)
                .NotEqual(Guid.Empty).WithMessage(ValidationMessages.ValueIsRequired);
            RuleFor(_ => _.SiteUrl)
                .NotEmpty().WithMessage(ValidationMessages.ValueIsRequired); ;
            RuleFor(_ => _.SiteSelector)
                .NotEmpty().WithMessage(ValidationMessages.ValueIsRequired); ;
            RuleFor(_ => _.SiteModelTypeName)
                .NotEmpty().WithMessage(ValidationMessages.ValueIsRequired); ;
        }
    }
}
