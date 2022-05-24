namespace Parser.Core.Application.Features.SiteDescriptions.Commands.DeleteSiteDescription
{
    public class DeleteSiteDescriptionCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
