using FluentValidation;

namespace Parser.Core.Application.Features.SiteDescriptions.Commands.DeleteSiteDescriptionCommand
{
    public class DeleteSiteDescriptionValidator : AbstractValidator<DeleteSiteDescriptionCommand>
    {
        public DeleteSiteDescriptionValidator()
        {
            RuleFor(deleteSiteDescriptionCommand =>
            deleteSiteDescriptionCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
