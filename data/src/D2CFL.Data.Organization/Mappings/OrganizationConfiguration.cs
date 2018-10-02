using System;
using Aurochses.Data.EntityFrameworkCore;
using Aurochses.Data.Extensions.MsSql;
using D2CFL.Data.Organization.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2CFL.Data.Organization.Mappings
{
    public class OrganizationConfiguration : EntityTypeConfiguration<OrganizationEntity, Guid>
    {
        public OrganizationConfiguration(string schemaName)
            :base(schemaName)
        {

        }

        public override void Map(EntityTypeBuilder<OrganizationEntity> builder)
        {
            // Table
            builder.ToTable("Organization", SchemaName);

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Name).HasColumnType(ColumnTypes.GetNVarCharWithSpecifiedLength(ColumnLengths.UniqueName)).IsRequired();
            builder.Property(x => x.ShortName).HasColumnType(ColumnTypes.GetNVarCharWithSpecifiedLength(ColumnLengths.UniqueName)).IsRequired();
            builder.Property(x => x.Region).HasColumnType(ColumnTypes.GetNVarCharWithSpecifiedLength(ColumnLengths.UniqueName)).IsRequired();
        }
    }
}