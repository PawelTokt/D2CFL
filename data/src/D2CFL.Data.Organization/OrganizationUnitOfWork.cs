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
            Func<DbContext, IRepository<PositionEntity, Guid>> positionRepository,
            Func<DbContext, IRepository<PlayerEntity, Guid>> playerRepository,
            DbContextOptions dbContextOptions,
            string schemaName)
            : base(new OrganizationDbContext(dbContextOptions, schemaName))
        {
            RegisterRepository(organizationRepository(DbContext));
            RegisterRepository(positionRepository(DbContext));
            RegisterRepository(playerRepository(DbContext));
        }

        public IRepository<OrganizationEntity, Guid> OrganizationRepository => GetRepository<OrganizationEntity, Guid>();

        public IRepository<PositionEntity, Guid> PositionRepository => GetRepository<PositionEntity, Guid>();

        public IRepository<PlayerEntity, Guid> PlayerRepository => GetRepository<PlayerEntity, Guid>();
    }
}