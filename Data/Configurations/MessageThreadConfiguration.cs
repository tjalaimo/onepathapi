using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using onepathapi.Models;

namespace onepathapi.Data.Configurations
{
    public class MessageThreadConfiguration : IEntityTypeConfiguration<MessageThread>
    {
        public void Configure(EntityTypeBuilder<MessageThread> builder)
        {
            builder.HasKey(mt => mt.ThreadId);

            builder.HasOne(mt => mt.InitiatorUser)
                .WithMany(u => u.InitiatedThreads)
                .HasForeignKey(mt => mt.InitiatorUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(mt => mt.RecipientUser)
                .WithMany(u => u.ReceivedThreads)
                .HasForeignKey(mt => mt.RecipientUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}