using Aurochses.Data.EntityFrameworkCore;
using D2CFL.Data.Organization.Mappings;
using Microsoft.EntityFrameworkCore;

namespace D2CFL.Data.Organization
{
    public class OrganizationDbContext :DbContextBase
    {
        public OrganizationDbContext(DbContextOptions dbContextOptions, string schemaName)
            : base(dbContextOptions, schemaName)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddConfiguration(new OrganizationConfiguration(SchemaName));
        }
    }
}