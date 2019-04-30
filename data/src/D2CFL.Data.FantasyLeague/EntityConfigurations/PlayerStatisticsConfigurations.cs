using System;
using Aurochses.Data.EntityFrameworkCore;
using Aurochses.Data.Extensions.MsSql;
using D2CFL.Data.FantasyLeague.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2CFL.Data.FantasyLeague.EntityConfigurations
{
    public class PlayerStatisticsConfigurations : EntityTypeConfiguration<PlayerStatisticsEntity, Guid>
    {
        public PlayerStatisticsConfigurations(string schemaName)
            : base(schemaName)
        {
            
        }

        public override void Configure(EntityTypeBuilder<PlayerStatisticsEntity> builder)
        {
            // Table
            builder.ToTable("PlayerStatistics", SchemaName);

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).HasDefaultValueSql(Functions.NewSequentialId);
            builder.Property(x => x.MatchesPlayed).HasDefaultValue(0);
            builder.Property(x => x.TotalKills).HasDefaultValue(0);
            builder.Property(x => x.TotalAssists).HasDefaultValue(0);
            builder.Property(x => x.TotalDeaths).HasDefaultValue(0);
            builder.Property(x => x.TotalPoints).HasDefaultValue(0);
            builder.Property(x => x.AverageKills).HasDefaultValue(0);
            builder.Property(x => x.AverageAssists).HasDefaultValue(0);
            builder.Property(x => x.AverageDeaths).HasDefaultValue(0);
            builder.Property(x => x.AveragePoints).HasDefaultValue(0);

            //Relationships
            builder.HasOne(x => x.Player)
                   .WithOne(x => x.PlayerStatistics)
                   .HasForeignKey<PlayerStatisticsEntity>(x => x.Id);
        }
    }
}
