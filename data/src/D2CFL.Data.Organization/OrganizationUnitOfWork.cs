using System;
using Aurochses.Data;
using Aurochses.Data.EntityFrameworkCore;
using D2CFL.Data.Organization.Contract;
using Microsoft.EntityFrameworkCore;

namespace D2CFL.Data.Organization
{
    public class OrganizationUnitOfWork : UnitOfWork, IOrganizationUnitOfWork
    {
        public OrganizationUnitOfWork(
            Func<DbContext, IRepository<OrganizationEntity, Guid>> organizationRepository,
            DbContextOptions dbContextOptions,
            string schemaName)
            : base(new OrganizationDbContext(dbContextOptions, schemaName))
        {
            RegisterRepository(organizationRepository(DbContext));
        }

        public IRepository<OrganizationEntity, Guid> OrganizationRepository => GetRepository<OrganizationEntity, Guid>();
    }
}
