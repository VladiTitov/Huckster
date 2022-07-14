using Selector.Core.Application.Features.SearchCriteries.Commands.CreateSearchCriteria;
using Selector.Core.Application.Features.SearchCriteries.Commands.UpdateSearchCriteria;

namespace Selector.Core.Application.Mappings
{
    internal class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateSearchCriteriaCommand, SearchCriteria>();
            CreateMap<UpdateSearchCriteriaCommand, SearchCriteria>();
        }
    }
}
