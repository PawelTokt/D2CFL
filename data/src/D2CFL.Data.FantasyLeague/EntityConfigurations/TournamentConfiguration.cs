using System;
using Aurochses.Data.EntityFrameworkCore;
using Aurochses.Data.Extensions.MsSql;
using D2CFL.Data.FantasyLeague.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2CFL.Data.FantasyLeague.EntityConfigurations
{
    public class TournamentConfiguration : EntityTypeConfiguration<TournamentEntity, Guid>
    {
        public TournamentConfiguration(string schemaName)
            : base(schemaName)
        {
            
        }

        public override void Configure(EntityTypeBuilder<TournamentEntity> builder)
        {
            // Table
            builder.ToTable("Tournament", SchemaName);

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).HasDefaultValueSql(Functions.NewSequentialId);
            builder.Property(x => x.Name).HasColumnType(ColumnTypes.GetNVarCharWithSpecifiedLength(ColumnLengths.UniqueName)).IsRequired();
            builder.Property(x => x.StartDate).HasColumnType(ColumnTypes.Date).IsRequired();
            builder.Property(x => x.EndDate).HasColumnType(ColumnTypes.Date).IsRequired();
        }
    }
}
