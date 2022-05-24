namespace Parser.Core.Application.Features.SiteDescriptions.Queries.GetSiteDescriptionDetails
{
    public class SiteDescriptionViewModel : IMapWith<SiteDescription>
    {
        public Guid Id { get; set; }
        public string? SiteName { get; set; }
        public string? Description { get; set; }
        public string? SiteUrl { get; set; }
        public string? SiteSelector { get; set; }
        public string? SiteModelTypeName { get; set; }
        public string? SiteModelSolutionName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SiteDescription, SiteDescriptionViewModel>()
                .ForMember(siteDescriptionVm => siteDescriptionVm.Id,
                opt => opt.MapFrom(siteDescription => siteDescription.Id))
                .ForMember(siteDescriptionVm => siteDescriptionVm.SiteName,
                opt => opt.MapFrom(siteDescription => siteDescription.SiteName))
                .ForMember(siteDescriptionVm => siteDescriptionVm.Description,
                opt => opt.MapFrom(siteDescription => siteDescription.Description))
                .ForMember(siteDescriptionVm => siteDescriptionVm.SiteUrl,
                opt => opt.MapFrom(siteDescription => siteDescription.SiteUrl))
                .ForMember(siteDescriptionVm => siteDescriptionVm.SiteSelector,
                opt => opt.MapFrom(siteDescription => siteDescription.SiteSelector))
                .ForMember(siteDescriptionVm => siteDescriptionVm.SiteModelTypeName,
                opt => opt.MapFrom(siteDescription => siteDescription.SiteModelTypeName))
                .ForMember(siteDescriptionVm => siteDescriptionVm.SiteModelSolutionName,
                opt => opt.MapFrom(siteDescription => siteDescription.SiteModelSolutionName));
        }
    }
}
