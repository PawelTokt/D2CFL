using Aurochses.Database.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace D2CFL.Database
{
    public class Program : ProgramBase
    {
        public static void Main(string[] args)
        {
            Main<Startup, Service>(args);
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) => CreateWebHostBuilder<Startup>(args);
    }
}