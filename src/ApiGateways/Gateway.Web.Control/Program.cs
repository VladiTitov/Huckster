using Gateway.Web.Control.Cofiguration.Ioc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();
builder.Configuration.AddConfigurations();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

await app.UseOcelot();
app.Run();