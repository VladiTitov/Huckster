using ParserService.Core.Application.Interfaces;

namespace ParserService.Core.Application.Services
{
    public class ParserBackgroundService : IParserBackgroundService
    {
        public ParserBackgroundService()
        {
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private async Task<IEnumerable<SiteDescription>> GetSiteDescriptions()
        {
            throw new NotImplementedException();
        }
    }
}
