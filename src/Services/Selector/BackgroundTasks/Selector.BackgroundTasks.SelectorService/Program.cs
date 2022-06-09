IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostBuilder, services) =>
    {
        services.ConfigureServices(hostBuilder.Configuration);
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
