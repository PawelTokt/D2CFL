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
                            .AllowAnyOrigin() // todo: must be allowed only for correct domains!
                            .WithExposedHeaders("Content-Disposition")
                    );
                }
            );
        }

        public static void Configure(IApplicationBuilder app)
        {
            // Enable Cors
            app.UseCors(
                builder => builder
                    .AllowAnyOrigin() // todo: must be allowed only for correct domains!
                    .AllowAnyHeader() // todo: this is for Options method (must be solved correct)
                    .AllowAnyMethod() // todo: this is for Options method (must be solved correct)
            );
        }
    }
}