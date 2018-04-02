using D2CFL.Data.League.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2CFL.Data.League.EntitiesConfigurations
{
    /// <summary>
    /// Class PlayerEntityConfiguration.
    /// </summary>
    public class PlayerEntityConfiguration : EntityTypeConfiguration<PlayerEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="PlayerEntityConfiguration"/> class.
        /// </summary>
        /// <param name="schemaName">Name of schema.</param>
        public PlayerEntityConfiguration(string schemaName)
            : base(schemaName)
        {
            
        }

        /// <summary>
        /// Configures the specified entity type builder.
        /// </summary>
        /// <param name="entityTypeBuilder">The entity type builder.</param>
        public override void Configure(EntityTypeBuilder<PlayerEntity> entityTypeBuilder)
        {
            //Table
            entityTypeBuilder.ToTable("Players", SchemaName);

            //Primary Key
            entityTypeBuilder.HasKey(x => x.Id);
            
            //Properties
            entityTypeBuilder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            entityTypeBuilder.Property(x => x.Nickname).HasMaxLength(50).IsRequired();
            entityTypeBuilder.Property(x => x.Lastname).HasMaxLength(50).IsRequired();

            //Relationships
            entityTypeBuilder.HasOne(p => p.Team).WithMany(x => x.Players).HasForeignKey(x => x.TeamId);

            entityTypeBuilder.HasOne(p => p.Position).WithMany(x => x.Players).HasForeignKey(x => x.PositionId);
        }
    }
}