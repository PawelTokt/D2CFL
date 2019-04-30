using System;
using Aurochses.Data.EntityFrameworkCore;
using Aurochses.Data.Extensions.MsSql;
using D2CFL.Data.FantasyLeague.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2CFL.Data.FantasyLeague.EntityConfigurations {
    public class PlayerStatisticsPerMatchConfiguration : EntityTypeConfiguration<PlayerStatisticsPerMatchEntity, Guid>
    {
        public PlayerStatisticsPerMatchConfiguration(string schemaName)
            : base(schemaName)
        {

        }

        public override void Configure(EntityTypeBuilder<PlayerStatisticsPerMatchEntity> builder)
        {
            // Table
            builder.ToTable("PlayerStatisticsPerMatch", SchemaName);

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).HasDefaultValueSql(Functions.NewSequentialId);
            builder.Property(x => x.PlayerName).HasColumnType(ColumnTypes.GetNVarCharWithSpecifiedLength(ColumnLengths.UniqueName)).HasDefaultValue();

            //Relationships
            builder.HasOne(x => x.Player)
                   .WithMany()
                   .HasForeignKey(x => x.PlayerId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Match)
                   .WithMany()
                   .HasForeignKey(x => x.MatchId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
