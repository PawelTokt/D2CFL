using Aurochses.Data.EntityFrameworkCore;
using D2CFL.Data.Organization.Mappings;
using Microsoft.EntityFrameworkCore;

namespace D2CFL.Data.Organization
{
    public class OrganizationDbContext : DbContextBase
    {
        public OrganizationDbContext(DbContextOptions dbContextOptions, string schemaName)
            : base(dbContextOptions, schemaName)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.AddConfiguration(new OrganizationConfiguration(SchemaName));
            builder.AddConfiguration(new PositionConfiguration(SchemaName));
            builder.AddConfiguration(new PlayerConfiguration(SchemaName));
        }

    }
}