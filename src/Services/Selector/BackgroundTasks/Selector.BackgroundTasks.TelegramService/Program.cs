IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostBuilder, services) =>
    {
        services.ConfigureServices(hostBuilder.Configuration);
    })
    .Build();

await host.RunAsync();
