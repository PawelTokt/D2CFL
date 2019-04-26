using System;
using Aurochses.Data.EntityFrameworkCore;
using Aurochses.Data.Extensions.MsSql;
using D2CFL.Data.FantasyLeague.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2CFL.Data.FantasyLeague.EntityConfigurations
{
    public class PlayerStatsConfiguration : EntityTypeConfiguration<PlayerStatsEntity, Guid>
    {
        public PlayerStatsConfiguration(string schemaName)
            : base(schemaName)
        {
            
        }

        public override void Configure(EntityTypeBuilder<PlayerStatsEntity> builder)
        {
            // Table
            builder.ToTable("PlayersStats", SchemaName);

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).HasDefaultValueSql(Functions.NewSequentialId);

            builder.HasOne(x => x.Match)
                   .WithMany()
                   .HasForeignKey(x => x.MatchId);

            builder.HasOne(x => x.Player)
                   .WithMany()
                   .HasForeignKey(x => x.PlayerId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
