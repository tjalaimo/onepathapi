using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using onepathapi.Models;

public class PostCommentConfiguration : IEntityTypeConfiguration<PostComment>
{
    public void Configure(EntityTypeBuilder<PostComment> builder)
    {
        builder.HasKey(pc => pc.CommentId);

        builder.HasOne(pc => pc.Post)
            .WithMany(p => p.Comments)
            .HasForeignKey(pc => pc.PostId)
            .OnDelete(DeleteBehavior.Cascade); // Delete likes if post is deleted

        builder.HasOne(pc => pc.CommentedByUser)
            .WithMany(u => u.Comments)
            .HasForeignKey(pc => pc.CommentedByUserId)
            .OnDelete(DeleteBehavior.Cascade); // Delete likes if user is deleted
    }
}