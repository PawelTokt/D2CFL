using D2CFL.Data.League.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2CFL.Data.League.EntitiesConfigurations
{
    /// <summary>
    /// Class PositionEntityConfiguration.
    /// </summary>
    public class PositionEntityConfiguration : EntityTypeConfiguration<PositionEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="PositionEntityConfiguration"/> class.
        /// </summary>
        /// <param name="schemaName">Name of schema.</param>
        public PositionEntityConfiguration(string schemaName)
            : base(schemaName)
        {

        }

        /// <summary>
        /// Configures the specified entity type builder.
        /// </summary>
        /// <param name="entityTypeBuilder">The entity type builder.</param>
        public override void Configure(EntityTypeBuilder<PositionEntity> entityTypeBuilder)
        {
            //Table
            entityTypeBuilder.ToTable("Positions", SchemaName);

            //Primary Key
            entityTypeBuilder.HasKey(x => x.Id);

            //Properties
            entityTypeBuilder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            entityTypeBuilder.Property(x => x.KillCoefficient).IsRequired();
            entityTypeBuilder.Property(x => x.DeathCoefficient).IsRequired();
            entityTypeBuilder.Property(x => x.AssistCoefficient).IsRequired();

            //Relationships
            entityTypeBuilder.HasMany(x => x.Players);

        }
    }
}