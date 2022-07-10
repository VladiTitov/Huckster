namespace Parser.Core.Application.Features.SiteDescriptions.Commands.DeleteSiteDescription
{
    public class DeleteSiteDescriptionCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
