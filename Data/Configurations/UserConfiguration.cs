using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using onepathapi.Models;

namespace onepathapi.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);

            builder.HasOne(u => u.Patient)
                .WithOne(p => p.User)
                .HasForeignKey<User>(u => u.PatientId)
                .OnDelete(DeleteBehavior.SetNull); // Set null if Patient is deleted

            builder.HasOne(u => u.Provider)
                .WithOne(p => p.User)
                .HasForeignKey<User>(u => u.ProviderId)
                .OnDelete(DeleteBehavior.SetNull); // Set null if Provider is deleted

            builder.HasMany(u => u.Posts)
                .WithOne(p => p.CreatedByUser)
                .HasForeignKey(p => p.CreatedByUserId)
                .OnDelete(DeleteBehavior.Cascade); // Delete posts if user is deleted

            builder.HasMany(u => u.LikedPosts)
                .WithOne(pl => pl.LikedByUser)
                .HasForeignKey(pl => pl.LikedByUserId)
                .OnDelete(DeleteBehavior.Cascade); // Delete post likes if user is deleted

            builder.HasMany(u => u.Comments)
                .WithOne(pc => pc.CommentedByUser)
                .HasForeignKey(pc => pc.CommentedByUserId)
                .OnDelete(DeleteBehavior.Cascade); // Delete comments if user is deleted

            builder.HasMany(u => u.InitiatedThreads)
                .WithOne(mt => mt.InitiatorUser)
                .HasForeignKey(mt => mt.InitiatorUserId)
                .OnDelete(DeleteBehavior.Cascade); // Delete threads if user is deleted

            builder.HasMany(u => u.ReceivedThreads)
                .WithOne(mt => mt.RecipientUser)
                .HasForeignKey(mt => mt.RecipientUserId)
                .OnDelete(DeleteBehavior.Cascade); // Delete threads if user is deleted

            builder.HasMany(u => u.NetworkMemberships)
                .WithOne(nu => nu.User)
                .HasForeignKey(nu => nu.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}