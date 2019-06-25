using Microsoft.EntityFrameworkCore;

namespace D2CFL.Data.FantasyLeague
{
    public class DbContextBase<TChiledClass> : DbContext
        where TChiledClass : class
    {
        public DbContextBase(DbContextOptions dbContextOptions, string schemaName)
            : base(dbContextOptions)
        {
            SchemaName = SetSchemaName(schemaName);
        }

        private string SetSchemaName(string schemaName)
        {
            if (schemaName != null)
            {
                return schemaName;
            }

            var className = typeof(TChiledClass).Name;

            var schemaname = className.Replace("Db", "").Replace("Context", "").ToLower();

            return schemaname;
        }

        public string SchemaName { get; }
    }
}