using System;
using Microsoft.Extensions.CommandLineUtils;

namespace D2CFL.Database
{
    internal static class DatabaseCommandLineApplication
    {
        public static CommandLineApplication Create<TService>(TService service)
            where TService : ServiceBase
        {
            var assembly = service.GetType().Assembly.GetName().Name;

            var app = new CommandLineApplication
            {
                Name = $"{assembly} Console",
                Description = "Console app for migrating database.",
                ExtendedHelpText = "This is a console app to migrate database."
                                   + Environment.NewLine +
                                   $"Depending on your OS, you may need to execute the application as {assembly}.exe or 'dotnet {assembly}.dll'"
            };

            app.HelpOption("-?|-h|--help");

            var removeBeforeApply = app.Option("-r", "Argument for remove all migrations before apply all migrations.", CommandOptionType.NoValue);
            var context = app.Option("-c <value>", "The DbContext class to use.", CommandOptionType.SingleValue);
            var migration = app.Option("-m <value>", "The target migration. Migrations may be identified by name or by ID.", CommandOptionType.SingleValue);
            var data = app.Option("-d", "Argument for apply data to database from data.sql.", CommandOptionType.NoValue);

            app.OnExecute(
                () =>
                {
                    if (removeBeforeApply.HasValue())
                    {
                        Console.WriteLine("Reset Database...");
                        service.Reset();
                    }

                    if (context.HasValue())
                    {
                        if (migration.HasValue())
                        {
                            Console.WriteLine("Apply Migrations...");
                            service.Update(context.Value(), migration.Value());
                        }
                        else
                        {
                            Console.WriteLine("Apply Migrations...");
                            service.Update(context.Value());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Apply Migrations...");
                        service.Update();
                    }

                    if (data.HasValue())
                    {
                        Console.WriteLine("Apply Data...");
                        service.ApplyDataFromSqlFile();
                    }

                    return 0;
                }
            );

            app.Command(
                "reset",
                command =>
                {
                    command.Description = "After this command all migrations to be reverted.";

                    command.OnExecute(
                        () =>
                        {
                            Console.WriteLine("Reset Database...");
                            service.Reset();

                            return 0;
                        }
                    );
                }
            );

            return app;
        }
    }
}