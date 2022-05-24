namespace Parser.Core.Application.Features.SiteDescriptions.Commands.DeleteSiteDescription
{
    public class DeleteSiteDescriptionValidator : AbstractValidator<DeleteSiteDescriptionCommand>
    {
        public DeleteSiteDescriptionValidator()
        {
            RuleFor(_ => _.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
