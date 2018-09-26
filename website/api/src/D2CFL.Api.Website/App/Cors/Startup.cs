using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace D2CFL.Api.Website.App.Cors
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(
                options =>
                {
                    options.AddPolicy(
                        "AllowContentDisposition",
                        builder => builder
                            .AllowAnyOrigin()
                            .WithExposedHeaders("Content-Disposition")
                    );
                }
            );
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseCors(
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
            );
        }
    }
}
