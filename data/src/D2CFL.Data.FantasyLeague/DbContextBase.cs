using Microsoft.EntityFrameworkCore;

namespace D2CFL.Data.FantasyLeague
{
    public class DbContextBase<TClass> : DbContext
        where TClass : class
    {
        public DbContextBase(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
            SchemaName = SetSchemaName();
        }

        private static string SetSchemaName()
        {
            var className = typeof(TClass).Name;

            var schemaname = className.Replace("Db", "").Replace("Context", "").ToLower();

            return schemaname;
        }

        public string SchemaName { get; }
    }
}