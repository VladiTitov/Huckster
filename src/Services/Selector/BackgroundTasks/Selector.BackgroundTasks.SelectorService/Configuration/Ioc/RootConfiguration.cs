namespace Selector.BackgroundTasks.SelectorService.Configuration.Ioc
{
    public static class RootConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddPersistenceInfrastructure(configuration)
                .AppSettingsSectionsRegister(configuration)
                .AddSingleton<ISearchItemService, SearchItemService>()
                .AddSingleton<IRabbitMqPublisher, RabbitMqPublisher>()
                .AddSingleton<IRabbitMqSubscriber, RabbitMqSubscriber>()
                .AddSingleton<IRabbitMqContext, RabbitMqContext>()
                .AddSingleton<IEventProcessor, MessageBusEventHandler>()
                .AddSingleton<ISearchCriteriaService, SearchCriteriaService>();
    }
}