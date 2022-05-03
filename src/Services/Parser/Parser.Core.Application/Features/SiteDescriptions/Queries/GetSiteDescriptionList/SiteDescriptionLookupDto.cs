using AutoMapper;
using Parser.Core.Domain.Models;
using Parser.Core.Application.Mappings;

namespace Parser.Core.Application.Features.SiteDescriptions.Queries.GetSiteDescriptionList
{
    public class SiteDescriptionLookupDto : IMapWith<SiteDescription>
    {
        public Guid Id { get; set; }
        public string? SiteName { get; set; }
        public string? Description { get; set; }
        public string SiteUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SiteDescription, SiteDescriptionLookupDto>()
                .ForMember(siteDescriptionVm => siteDescriptionVm.Id,
                opt => opt.MapFrom(siteDescription => siteDescription.Id))
                .ForMember(siteDescriptionVm => siteDescriptionVm.SiteName,
                opt => opt.MapFrom(siteDescription => siteDescription.SiteName))
                .ForMember(siteDescriptionVm => siteDescriptionVm.Description,
                opt => opt.MapFrom(siteDescription => siteDescription.Description))
                .ForMember(siteDescriptionVm => siteDescriptionVm.SiteUrl,
                opt => opt.MapFrom(siteDescription => siteDescription.SiteUrl));
        }
    }
}
