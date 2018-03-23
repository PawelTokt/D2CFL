﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2CFL.Data
{
    /// <summary>
    /// EntityTypeConfiguration.
    /// </summary>
    /// <typeparam name="TEntity">The type of the T entity.</typeparam>
    public abstract class EntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityTypeConfiguration{TEntity}"/> class.
        /// </summary>
        /// <param name="schemaName">Name of the schema.</param>
        protected EntityTypeConfiguration(string schemaName)
        {
            SchemaName = schemaName;
        }

        /// <summary>
        /// Gets the name of the schema.
        /// </summary>
        /// <value>The name of the schema.</value>
        public string SchemaName { get; }

        /// <summary>
        /// Configures the specified entity type builder.
        /// </summary>
        /// <param name="entityTypeBuilder">The entity type builder.</param>
        public abstract void Configure(EntityTypeBuilder<TEntity> entityTypeBuilder);
    }
}