using Parser.Core.Application.Features.SiteDescriptions.Commands.CreateSiteDescription;
using Parser.Core.Application.Features.SiteDescriptions.Commands.UpdateSiteDescription;

namespace Parser.Core.Application.Mappings
{
    internal class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateSiteDescriptionCommand, SiteDescription>();
            CreateMap<UpdateSiteDescriptionCommand, SiteDescription>();
        }
    }
}
