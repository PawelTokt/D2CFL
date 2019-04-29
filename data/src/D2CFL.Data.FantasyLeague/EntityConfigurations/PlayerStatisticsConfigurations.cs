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

            //Relationships
            builder.HasOne(x => x.Player)
                   .WithOne(x => x.PlayerStatistics)
                   .HasForeignKey<PlayerStatisticsEntity>(x => x.PlayerId);
        }
    }
}
