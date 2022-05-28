using Selector.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.ConfigureSwagger();
    app.DatabaseMigrations();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();