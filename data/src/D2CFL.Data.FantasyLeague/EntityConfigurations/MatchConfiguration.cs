using System;
using Aurochses.Data.EntityFrameworkCore;
using Aurochses.Data.Extensions.MsSql;
using D2CFL.Data.FantasyLeague.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2CFL.Data.FantasyLeague.EntityConfigurations
{
    public class MatchConfiguration : EntityTypeConfiguration<MatchEntity, Guid>
    {
        public MatchConfiguration(string schemaName)
            : base(schemaName)
        {
            
        }

        public override void Configure(EntityTypeBuilder<MatchEntity> builder)
        {
            // Table
            builder.ToTable("Match", SchemaName);

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).HasDefaultValueSql(Functions.NewSequentialId);
            builder.Property(x => x.Name).HasColumnType(ColumnTypes.GetNVarCharWithSpecifiedLength(ColumnLengths.UniqueName)).IsRequired();
            builder.Property(x => x.Date).HasColumnType(ColumnTypes.Date).IsRequired();

            //Relationships
            builder.HasOne(x => x.Tournament)
                   .WithMany()
                   .HasForeignKey(x => x.TournamentId);

            builder.HasOne(x => x.FirstOrganization)
                   .WithMany()
                   .HasForeignKey(x => x.FirstOrganizationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SecondOrganization)
                   .WithMany()
                   .HasForeignKey(x => x.SecondOrganizationId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
