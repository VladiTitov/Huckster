var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddConfigurations();
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

app.UseRouting();
app.ConfigureSwagger();
app.UseHttpsRedirection();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

await app.UseOcelot();
app.Run();