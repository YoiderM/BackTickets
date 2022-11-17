using Domain.Models.Overtimes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class OvertimeDetailConfiguration : IEntityTypeConfiguration<OvertimeDetail>
    {
        public void Configure(EntityTypeBuilder<OvertimeDetail> builder)
        {
            builder.Property(x => x.PaymentPercent)
                .HasMaxLength(20);

            builder.Property(x => x.Document)
                .HasMaxLength(20);

			builder.Property(x => x.Login)
				.HasMaxLength(20);

            builder.Property(x => x.Names)
                .HasMaxLength(80);

			builder.Property(x => x.JobName)
				.HasMaxLength(30);

            builder.Property(x => x.Observation)
                .HasMaxLength(150);
            
            builder.Property(x => x.AuthObservation)
                .HasMaxLength(200); 

            builder.Property(x => x.AdminObservation)
                .HasMaxLength(200);

            builder.Property(x => x.Status)
                .HasMaxLength(1);


	    }
    }
}
