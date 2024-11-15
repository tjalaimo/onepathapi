using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onepathapi.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public string MessageContent { get; set; }
        public DateTime? SentDate { get; set; }
        public int ThreadId { get; set; }
        public int SentByUserId { get; set; }
        [NotMapped]
        public MessageThread Thread { get; set; }
        [NotMapped]
        public User SentByUser { get; set; }
    }
}
