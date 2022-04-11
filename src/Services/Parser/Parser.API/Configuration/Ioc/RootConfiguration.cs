using Parser.API.Configuration.Swagger;

namespace Parser.API.Configuration.Ioc
{
    public static class RootConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
            => services
            .RegisterSwagger();
    }
}
