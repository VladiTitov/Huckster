using Microsoft.Extensions.DependencyInjection;
using Parser.Core.Application.Interfaces;
using Parser.Infrastructure.HtmlAgilityPackService.Interfaces;

namespace Parser.Core.Application.Services
{
    public class AdHandlerService : IAdHandlerService
    {
        private readonly IParserService _parserService;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMessageBusService _messageBusService;

        public AdHandlerService(
            IParserService parserService,
            IServiceProvider serviceProvider,
            IMessageBusService messageBusService)
        {
            _parserService = parserService;
            _serviceProvider = serviceProvider;
            _messageBusService = messageBusService;
        }

        public async void AdHandler(SiteDescription siteDescription)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var repository = scope.ServiceProvider.GetRequiredService<IAdsRepositoryAsync>();
                var adModels = GetAdList(siteDescription);
                foreach (var ad in adModels)
                {
                    if (ad.IsNull() || await repository.IsContainsAsync(ad)) continue;
                    await repository.AddAsync(ad);
                    _messageBusService.SendMessageAsync(ad);
                }
            }
        }
        private IEnumerable<AdModel> GetAdList(SiteDescription siteDescription)
            => _parserService
                .GetData<AdModel>(siteDescription);
    }
}
