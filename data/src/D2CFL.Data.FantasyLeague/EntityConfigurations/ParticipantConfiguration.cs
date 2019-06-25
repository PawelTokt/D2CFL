using System;
using Aurochses.Data.EntityFrameworkCore;
using Aurochses.Data.Extensions.MsSql;
using D2CFL.Data.FantasyLeague.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2CFL.Data.FantasyLeague.EntityConfigurations
{
    public class ParticipantConfiguration : EntityTypeConfiguration<ParticipantEntity, Guid>
    {
        public ParticipantConfiguration(string schemaName)
            : base(schemaName)
        {
        }

        public override void Configure(EntityTypeBuilder<ParticipantEntity> builder)
        {
            // Table
            builder.ToTable("Participant", SchemaName);

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).HasDefaultValueSql(Functions.NewSequentialId);
            builder.Property(x => x.OrganizationName).HasColumnType(ColumnTypes.GetNVarCharWithSpecifiedLength(ColumnLengths.UniqueName)).HasDefaultValue();

            //Relationships
            builder.HasOne(x => x.Organization)
                .WithMany()
                .HasForeignKey(x => x.OrganizationId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Match)
                .WithMany()
                .HasForeignKey(x => x.MatchId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}