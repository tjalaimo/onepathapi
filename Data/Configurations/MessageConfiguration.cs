using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using onepathapi.Models;

namespace onepathapi.Data.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(m => m.MessageId);

            builder.HasOne(m => m.SentByUser)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SentByUserId);

            builder.HasOne(m => m.Thread)
                .WithMany(t => t.Messages)
                .HasForeignKey(m => m.ThreadId);
        }
    }
}