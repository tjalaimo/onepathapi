using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using onepathapi.Models;

namespace onepathapi.Data.Configurations
{
    public class AccessCodedConfiguration : IEntityTypeConfiguration<AccessCode>
    {
        public void Configure(EntityTypeBuilder<AccessCode> builder)
        {
            builder.HasKey(ac => ac.AccessCodeId);

            builder.HasOne(ac => ac.GeneratorUser)
                .WithMany(u => u.GeneratedAccessCodes)
                .HasForeignKey(ac => ac.GeneratorUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ac => ac.RecipientUser)
                .WithMany(u => u.ReceivedAccessCodes)
                .HasForeignKey(ac => ac.RecipientUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}