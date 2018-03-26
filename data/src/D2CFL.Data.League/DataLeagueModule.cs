using Autofac;
using D2CFL.Data.Interfaces;
using D2CFL.Data.League.Contract;

namespace D2CFL.Data.League
{
    /// <summary>
    /// Class DataLeagueModule.
    /// </summary>
    /// <seealso cref="T:Autofac.Module"/>
    public class DataLeagueModule : Module
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="containerBuilder">The builder through which components can be
        /// registered.</param>
        /// <remarks>Note that the ContainerBuilder parameter is unique to this module.</remarks>
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<Repository<PlayerEntity>>().As<IRepository<PlayerEntity>>()
                .InstancePerLifetimeScope();
            containerBuilder.RegisterType<Repository<PositionEntity>>().As<IRepository<PositionEntity>>()
                .InstancePerLifetimeScope();
            containerBuilder.RegisterType<Repository<TeamEntity>>().As<IRepository<TeamEntity>>()
                .InstancePerLifetimeScope();
        }
    }
}