var hostBuilder = Host.CreateDefaultBuilder(args);

hostBuilder.ConfigureServices((context, services) =>
{
    services.ConfigureServices(context.Configuration);
    services.AddHostedService<Worker>();
});

var host = hostBuilder.Build();

await host.RunAsync();
