using D2CFL.Data.League.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2CFL.Data.League.EntitiesConfigurations
{
    public class TeamEntityConfiguration : EntityTypeConfiguration<TeamEntity>
    {
        public TeamEntityConfiguration(string schemaName)
            : base(schemaName)
        {

        }

        public override void Configure(EntityTypeBuilder<TeamEntity> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Teams", SchemaName);

            entityTypeBuilder.HasKey(x => x.Id);

            entityTypeBuilder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            entityTypeBuilder.Property(x => x.Region).HasMaxLength(50).IsRequired();

            entityTypeBuilder.HasMany(x => x.Players);
        }
    }
}