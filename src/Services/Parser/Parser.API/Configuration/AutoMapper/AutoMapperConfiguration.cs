using System.Reflection;
using Parser.Core.Application.Mappings;
using Parser.Core.Application.Interfaces;

namespace Parser.API.Configuration.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
            => services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(ISiteDescriptionDbContext).Assembly));
            });
    }
}
