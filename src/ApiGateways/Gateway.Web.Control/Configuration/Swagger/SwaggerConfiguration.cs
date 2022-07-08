namespace Gateway.Web.Control.Cofiguration.Swagger
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection RegisterSwagger(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddSwaggerForOcelot(configuration)
                .AddSwaggerGen();

        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
            => app
                .UseSwagger()
                .UseSwaggerForOcelotUI(opt =>
                {
                    opt.PathToSwaggerGenerator = "/swagger/docs";
                });
    }
}
