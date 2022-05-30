IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.ConfigureServices();
    })
    .Build();

await host.RunAsync();
