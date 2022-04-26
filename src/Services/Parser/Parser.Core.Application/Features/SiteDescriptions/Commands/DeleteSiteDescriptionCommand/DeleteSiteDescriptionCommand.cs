using MediatR;

namespace Parser.Core.Application.Features.SiteDescriptions.Commands.DeleteSiteDescriptionCommand
{
    public class DeleteSiteDescriptionCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
