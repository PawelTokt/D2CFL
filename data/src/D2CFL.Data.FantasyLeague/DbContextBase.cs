using Microsoft.EntityFrameworkCore;

namespace D2CFL.Data.FantasyLeague
{
    public class DbContextBase : DbContext
    {
        protected DbContextBase(DbContextOptions dbContextOptions, string schemaName)
            : base(dbContextOptions)
        {
            SchemaName = schemaName;
        }

        public string SchemaName { get; }
    }
}