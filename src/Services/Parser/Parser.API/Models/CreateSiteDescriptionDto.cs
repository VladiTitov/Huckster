using AutoMapper;
using Parser.Core.Application.Mappings;
using Parser.Core.Application.Features.SiteDescriptions.Commands.CreateSiteDescription;

namespace Parser.API.Models
{
    public class CreateSiteDescriptionDto : IMapWith<CreateSiteDescriptionCommand>
    {
        public string SiteName { get; set; }
        public string Description { get; set; }
        public string SiteUrl { get; set; }
        public string SiteSelector { get; set; }
        public string SiteModelTypeName { get; set; }
        public string SiteModelSolutionName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateSiteDescriptionDto, CreateSiteDescriptionCommand>()
                .ForMember(siteDescription => siteDescription.SiteName,
                opt => opt.MapFrom(siteDescriptionDto => siteDescriptionDto.SiteName))
                .ForMember(siteDescription => siteDescription.Description,
                opt => opt.MapFrom(siteDescriptionDto => siteDescriptionDto.Description))
                .ForMember(siteDescription => siteDescription.SiteUrl,
                opt => opt.MapFrom(siteDescriptionDto => siteDescriptionDto.SiteUrl))
                .ForMember(siteDescription => siteDescription.SiteSelector,
                opt => opt.MapFrom(siteDescriptionDto => siteDescriptionDto.SiteSelector))
                .ForMember(siteDescription => siteDescription.SiteModelTypeName,
                opt => opt.MapFrom(siteDescriptionDto => siteDescriptionDto.SiteModelTypeName))
                .ForMember(siteDescription => siteDescription.SiteModelSolutionName,
                opt => opt.MapFrom(siteDescriptionDto => siteDescriptionDto.SiteModelSolutionName));
        }
    }
}
