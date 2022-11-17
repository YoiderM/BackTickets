using Domain.Models.Overtimes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Configurations
{
    public class OvertimeTypesConfiguration : IEntityTypeConfiguration<OvertimeType>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<OvertimeType> builder)
        {
            builder.Property(x => x.Name)
                   .HasMaxLength(100);

            builder.Property(x => x.Description)
                   .HasMaxLength(400);

            builder.Property(x => x.Description1)
                   .HasMaxLength(400);

            builder.Property(x => x.Note)
                   .HasMaxLength(200);

            builder.Property(x => x.DisplayName)
                   .HasMaxLength(100);

            builder.Property(x => x.TypeHour)
                   .HasMaxLength(30);
        }
    }
}
