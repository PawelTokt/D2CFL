using Microsoft.EntityFrameworkCore;

namespace D2CFL.Data.FantasyLeague
{
    public class DbContextBase<TChiledClass> : DbContext
        where TChiledClass : class
    {
        public DbContextBase(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
            SchemaName = SetSchemaName();
        }

        private string SetSchemaName()
        {
            var className = typeof(TChiledClass).Name;

            var schemaname = className.Replace("Db", "").Replace("Context", "").ToLower();

            return schemaname;
        }

        public string SchemaName { get; }
    }
}