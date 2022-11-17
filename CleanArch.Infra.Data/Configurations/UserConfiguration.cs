using Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
                                     
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Document)
                   .HasMaxLength(20);

            builder.Property(x => x.Names)
                   .HasMaxLength(100);

            builder.Property(x => x.CampaignName)
                   .HasMaxLength(150);

            builder.Property(x => x.Phone1)
                   .HasMaxLength(15);

            builder.Property(x => x.Phone2)
                   .HasMaxLength(15);

            builder.Property(x => x.Phone3)
                   .HasMaxLength(15);

            builder.Property(x => x.Email)
                   .HasMaxLength(100);

            builder.Property(x => x.login)
                   .HasMaxLength(20);

            builder.Property(x => x.PassWord)
                   .HasMaxLength(20);
   
        }
    }
}
