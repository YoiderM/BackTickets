using Core.Models.configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Configurations
{
    public class ConfigurationConfiguration : IEntityTypeConfiguration<Configuration>
    {
        public void Configure(EntityTypeBuilder<Configuration> builder)
        {
            builder.Property(x => x.Name)
                  .HasMaxLength(40);

            builder.Property(x => x.Description)
                  .HasMaxLength(200);
        }
    }
}
