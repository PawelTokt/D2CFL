using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace D2CFL.Database
{
    /// <summary>
    /// Base class for Program.
    /// </summary>
    public abstract class ProgramBase
    {
        /// <summary>
        /// Main method.
        /// </summary>
        /// <typeparam name="TStartup">Type of Startup type.</typeparam>
        /// <typeparam name="TService">Type of Service type.</typeparam>
        /// <param name="args">Arguments.</param>
        public static void Main<TStartup, TService>(string[] args)
            where TStartup : StartupBase
            where TService : ServiceBase
        {
            // get environment name
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // startup
            var startup = (TStartup)Activator.CreateInstance(typeof(TStartup), BuildConfiguration(environmentName));

            // service collection
            var serviceCollection = new ServiceCollection();
            startup.ConfigureServices(serviceCollection);

            // add Service
            serviceCollection.AddTransient<TService>();

            // service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // service
            var service = serviceProvider.GetService<TService>();

            // app
            var app = DatabaseCommandLineApplication.Create(service);

            try
            {
                app.Execute(args);
            }
            catch (CommandParsingException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to execute application: {0}", ex.Message);
                Environment.Exit(1);
            }
        }

        /// <summary>
        /// Method for create web host builder.
        /// </summary>
        /// <typeparam name="TStartup">Type of Startup type.</typeparam>
        /// <param name="args">Arguments.</param>
        /// <returns>IWebHostBuilder.</returns>
        public static IWebHostBuilder CreateWebHostBuilder<TStartup>(string[] args)
            where TStartup : class
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<TStartup>();
        }

        /// <summary>
        /// Build configuration method.
        /// </summary>
        /// <param name="environmentName">Environment name.</param>
        /// <returns>IConfigurationRoot.</returns>
        public static IConfigurationRoot BuildConfiguration(string environmentName) =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables()
                .Build();
    }
}