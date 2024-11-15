using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using onepathapi.Models;

public class NetworkConfiguration : IEntityTypeConfiguration<Network>
{
    public void Configure(EntityTypeBuilder<Network> builder)
    {
        builder.HasKey(n => n.NetworkId);

        builder.Property(n => n.NetworkName)
            .IsRequired()
            .HasMaxLength(255);

        // Define one-to-many relationship with NetworkUser
        builder.HasMany(n => n.Members)
            .WithOne(nu => nu.Network)
            .HasForeignKey(nu => nu.NetworkId)
            .OnDelete(DeleteBehavior.Cascade); // Delete members if network is deleted
    }
}