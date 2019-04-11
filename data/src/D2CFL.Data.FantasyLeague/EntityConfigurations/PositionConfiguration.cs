using System;
using Aurochses.Data.EntityFrameworkCore;
using Aurochses.Data.Extensions.MsSql;
using D2CFL.Data.FantasyLeague.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2CFL.Data.FantasyLeague.EntityConfigurations {
    public class PositionConfiguration : EntityTypeConfiguration<PositionEntity, Guid>
    {
        public PositionConfiguration(string schemaName)
            : base(schemaName)
        {
            
        }

        public override void Configure(EntityTypeBuilder<PositionEntity> builder)
        {
            // Table
            builder.ToTable("Position", SchemaName);

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).HasDefaultValueSql(Functions.NewSequentialId);
            builder.Property(x => x.Id).HasDefaultValueSql(Functions.NewSequentialId);
            builder.Property(x => x.Name).HasColumnType(ColumnTypes.GetNVarCharWithSpecifiedLength(ColumnLengths.UniqueName)).IsRequired();
        }
    }
}