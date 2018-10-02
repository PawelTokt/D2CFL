using D2CFL.Data.Organization;
using Microsoft.EntityFrameworkCore;

namespace D2CFL.Database.Context
{
    public class OrganizationContext : OrganizationDbContext
    {
        public OrganizationContext(DbContextOptions<OrganizationDbContext> dbContextOptions)
            : base(dbContextOptions, Configuration.OrganizationSchemaName)
        {

        }
    }
}