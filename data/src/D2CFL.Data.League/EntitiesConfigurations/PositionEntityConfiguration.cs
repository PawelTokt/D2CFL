using D2CFL.Data.League.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2CFL.Data.League.EntitiesConfigurations
{
    public class PositionEntityConfiguration : EntityTypeConfiguration<PositionEntity>
    {
        public PositionEntityConfiguration(string schemaName)
            : base(schemaName)
        {

        }

        public override void Configure(EntityTypeBuilder<PositionEntity> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Positions", SchemaName);

            entityTypeBuilder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            entityTypeBuilder.Property(x => x.KillCoefficient).IsRequired();
            entityTypeBuilder.Property(x => x.DeathCoefficient).IsRequired();
            entityTypeBuilder.Property(x => x.AssistCoefficient).IsRequired();

        }
    }
}