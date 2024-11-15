using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onepathapi.Models
{
    public class MessageThread
    {
        [Key]
        public int ThreadId { get; set; }
        public int InitiatorUserId { get; set; }
        public int RecipientUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        [NotMapped]
        public User InitiatorUser { get; set; }
        [NotMapped]
        public User RecipientUser { get; set; }
        [NotMapped]
        public ICollection<Message> Messages { get; set; }
    }
}
