using D2CFL.Data.League.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2CFL.Data.League.EntitiesConfigurations
{
    public class PlayerEntityConfiguration : EntityTypeConfiguration<PlayerEntity>
    {
        public PlayerEntityConfiguration(string schemaName)
            : base(schemaName)
        {
            
        }

        public override void Configure(EntityTypeBuilder<PlayerEntity> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Players", SchemaName);

            entityTypeBuilder.HasKey(x => x.Id);

            entityTypeBuilder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            entityTypeBuilder.Property(x => x.Nickname).HasMaxLength(50).IsRequired();
            entityTypeBuilder.Property(x => x.Surname).HasMaxLength(50).IsRequired();

            entityTypeBuilder.HasOne(p => p.Team).WithMany(x => x.Players).HasForeignKey(x => x.TeamEntityId);

            entityTypeBuilder.HasOne(p => p.Position).WithMany(x => x.Players).HasForeignKey(x => x.PositionEntityId);
        }
    }
}