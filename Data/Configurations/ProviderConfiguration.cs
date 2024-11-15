using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using onepathapi.Models;

namespace onepathapi.Data.Configurations
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.HasOne(p => p.User)
                .WithOne(u => u.Provider)
                .HasForeignKey<User>(u => u.ProviderId)
                .OnDelete(DeleteBehavior.SetNull); // Set null if Provider is deleted

            builder.HasMany(p => p.Appointments)
                .WithOne(a => a.Provider)
                .HasForeignKey(a => a.ProviderId)
                .OnDelete(DeleteBehavior.Cascade); // Appointments will be deleted if the patient is deleted
        }
    }
}