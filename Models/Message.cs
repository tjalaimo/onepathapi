using System.ComponentModel.DataAnnotations;

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

        public virtual User SentByUser { get; set; } = new User();
        public virtual MessageThread Thread { get; set; }
    }
}
