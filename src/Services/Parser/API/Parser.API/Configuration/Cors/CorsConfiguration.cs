namespace Parser.API.Configuration.Cors
{
    public static class CorsConfiguration
    {
        public static IServiceCollection RegisterCors(this IServiceCollection services)
            => services.AddCors(opt =>
            {
                opt.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

        public static IApplicationBuilder UseAllowAllCors(this IApplicationBuilder app)
            => app.UseCors("AllowAll");
    }
}
