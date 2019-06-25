using System;
using Aurochses.Data.EntityFrameworkCore;
using Aurochses.Data.Extensions.MsSql;
using D2CFL.Data.FantasyLeague.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2CFL.Data.FantasyLeague.EntityConfigurations
{
    public class PlayerConfiguration : EntityTypeConfiguration<PlayerEntity, Guid>
    {
        public PlayerConfiguration(string schemaName)
            : base(schemaName)
        {
        }

        public override void Configure(EntityTypeBuilder<PlayerEntity> builder)
        {
            // Table
            builder.ToTable("Player", SchemaName);

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).HasDefaultValueSql(Functions.NewSequentialId);
            builder.Property(x => x.FirstName).HasColumnType(ColumnTypes.GetNVarCharWithSpecifiedLength(ColumnLengths.UniqueName)).IsRequired();
            builder.Property(x => x.LastName).HasColumnType(ColumnTypes.GetNVarCharWithSpecifiedLength(ColumnLengths.UniqueName)).IsRequired();
            builder.Property(x => x.Nickname).HasColumnType(ColumnTypes.GetNVarCharWithSpecifiedLength(ColumnLengths.UniqueName)).IsRequired();
            builder.Property(x => x.Country).HasColumnType(ColumnTypes.GetNVarCharWithSpecifiedLength(ColumnLengths.UniqueName)).IsRequired();

            //Relationships
            builder.HasOne(x => x.Organization)
                .WithMany()
                .HasForeignKey(x => x.OrganizationId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Position)
                .WithMany()
                .HasForeignKey(x => x.PositionId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.PlayerStatistics);
        }
    }
}