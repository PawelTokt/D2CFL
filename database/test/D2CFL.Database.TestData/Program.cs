﻿using System;
using System.IO;
using Aurochses.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace D2CFL.Database.TestData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // get environment name
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // startup
            var startup = new Startup(BuildConfiguration(environmentName));

            // dependency injection
            var serviceCollection = new ServiceCollection();
            startup.ConfigureServices(serviceCollection);
            var services = serviceCollection.BuildServiceProvider();

            // Service
            var service = services.GetService<Service>();

            service.Run(environmentName);
        }

        public static IConfigurationRoot BuildConfiguration(string environmentName) =>
            new ConfigurationBuilder()
                .SetBasePath(ProjectHelpers.GetProjectPath(@"src", typeof(Database.Startup).Assembly))
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables()
                .Build();

        internal static IConfigurationRoot BuildConfiguration(string path, string fileName, string environmentName) =>
            new ConfigurationBuilder()
                .SetBasePath(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), path)))
                .AddJsonFile($"{fileName}.json")
                .AddJsonFile($"{fileName}.{environmentName}.json", true)
                .AddEnvironmentVariables()
                .Build();
    }
}
