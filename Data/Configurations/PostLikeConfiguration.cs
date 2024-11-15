using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using onepathapi.Models;

public class PostLikeConfiguration : IEntityTypeConfiguration<PostLike>
{
    public void Configure(EntityTypeBuilder<PostLike> builder)
    {
        builder.HasKey(pl => pl.PostLikeId);

        builder.HasOne(pl => pl.Post)
            .WithMany(p => p.Likes)
            .HasForeignKey(pl => pl.PostId)
            .OnDelete(DeleteBehavior.Cascade); // Delete likes if post is deleted

        builder.HasOne(pl => pl.LikedByUser)
            .WithMany(u => u.LikedPosts)
            .HasForeignKey(pl => pl.LikedByUserId)
            .OnDelete(DeleteBehavior.Cascade); // Delete likes if user is deleted
    }
}