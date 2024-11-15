using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using onepathapi.Models;

public class NetworkUserConfiguration : IEntityTypeConfiguration<NetworkUser>
{
    public void Configure(EntityTypeBuilder<NetworkUser> builder)
    {
        builder.HasKey(nu => nu.NetworkUserId);

        // Define the foreign key relationship with Network
        builder.HasOne(nu => nu.Network)
            .WithMany(n => n.Members)
            .HasForeignKey(nu => nu.NetworkId)
            .OnDelete(DeleteBehavior.Cascade); // Delete network-user relationships if network is deleted

        // Define the foreign key relationship with User
        builder.HasOne(nu => nu.User)
            .WithMany(u => u.NetworkMemberships)
            .HasForeignKey(nu => nu.UserId)
            .OnDelete(DeleteBehavior.Cascade); // Delete network-user relationships if user is deleted
    }
}
