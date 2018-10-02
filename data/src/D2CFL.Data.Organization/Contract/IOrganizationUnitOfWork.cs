using System;
using Aurochses.Data;

namespace D2CFL.Data.Organization.Contract
{
    public interface IOrganizationUnitOfWork : IUnitOfWork
    {
        IRepository<OrganizationEntity, Guid> OrganizationRepository { get; }

        IRepository<PositionEntity, Guid> PositionRepository { get; }

        IRepository<PlayerEntity, Guid> PlayerRepository { get; }
    }
}