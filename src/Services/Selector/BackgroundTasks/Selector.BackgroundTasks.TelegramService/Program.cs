IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostBuilder, services) =>
    {
        services.ConfigureServices(hostBuilder.Configuration);
    })
    .Build();

host.DatabaseMigrations();

await host.RunAsync();
