using Domain.Models.Rol;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Configurations
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.Property(x => x.Name)
                   .HasMaxLength(50);
            builder.Property(x => x.DisplayName)
                   .HasMaxLength(50);
        }
    }
}
