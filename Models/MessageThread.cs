using System.ComponentModel.DataAnnotations;

namespace onepathapi.Models
{
    public class MessageThread
    {
        [Key]
        public int ThreadId { get; set; }
        public int InitiatorUserId { get; set; }
        public int RecipientUserId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual User InitiatorUser { get; set; } = new User();
        public virtual User RecipientUser { get; set; } = new User();
        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
