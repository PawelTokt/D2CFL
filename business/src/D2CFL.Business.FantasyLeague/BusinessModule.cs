using System.Collections.Generic;
using Aurochses.Data.Autofac.EntityFrameworkCore;
using Autofac;
using Autofac.Core;
using D2CFL.Business.FantasyLeague.Contract.Match;
using D2CFL.Business.FantasyLeague.Contract.Organization;
using D2CFL.Business.FantasyLeague.Contract.Participant;
using D2CFL.Business.FantasyLeague.Contract.Player;
using D2CFL.Business.FantasyLeague.Contract.PlayerStats;
using D2CFL.Business.FantasyLeague.Contract.Position;
using D2CFL.Business.FantasyLeague.Contract.Tournament;
using D2CFL.Data.FantasyLeague;
using D2CFL.Data.FantasyLeague.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace D2CFL.Business.FantasyLeague
{
    public class BusinessModule : BusinessModuleBase
    {
        public BusinessModule(DbContextOptions dbContextOptions, string schemaName)
            : base(dbContextOptions, schemaName)
        {
            
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DataModule());

            // UnitOfWork
            builder.RegisterType<FantasyLeagueUnitOfWork>().As<IFantasyLeagueUnitOfWork>()
                   .WithParameters(
                       new List<Parameter>
                       {
                           new NamedParameter(DbContextOptionsParameter, DbContextOptions),
                           new NamedParameter(SchemaNameParameter, SchemaName)
                       })
                   .InstancePerLifetimeScope();

            // Services
            builder.RegisterType<MatchService>().As<IMatchService>().InstancePerLifetimeScope();
            builder.RegisterType<OrganizationService>().As<IOrganizationService>().InstancePerLifetimeScope();
            builder.RegisterType<ParticipantService>().As<IParticipantService>().InstancePerLifetimeScope();
            builder.RegisterType<PlayerService>().As<IPlayerService>().InstancePerLifetimeScope();
            builder.RegisterType<PlayerStatsService>().As<IPlayerStatsService>().InstancePerLifetimeScope();
            builder.RegisterType<PositionService>().As<IPositionService>().InstancePerLifetimeScope();
            builder.RegisterType<TournamentService>().As<ITournamentService>().InstancePerLifetimeScope();
        }
    }
}
