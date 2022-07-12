namespace Parser.API.Configuration.Swagger
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection RegisterSwagger(this IServiceCollection services)
            => services
                .AddSwaggerGen();

        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
            =>
                app
                    .UseSwagger()
                    .UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Huckster.Parser.Api");
                    });
    }
}
