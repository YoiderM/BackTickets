using Domain.Models.Mekano;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Configurations
{
    public class MekanoUsersConfiguration : IEntityTypeConfiguration<MekanoUser>
    {
        public void Configure(EntityTypeBuilder<MekanoUser> builder)
        {
            builder.Property(x => x.Document)
                   .HasMaxLength(20);

            builder.Property(x => x.Name)
                  .HasMaxLength(50);

            builder.Property(x => x.Job)
                  .HasMaxLength(50);

            builder.Property(x => x.Campaign)
                  .HasMaxLength(80);
        }
    }
}
