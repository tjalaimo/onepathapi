namespace onepathapi.Models
{
    public class MessageThread
    {
        public int ThreadId { get; set; }
        public int InitiatorUserId { get; set; }
        public int RecipientUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public User InitiatorUser { get; set; }
        public User RecipientUser { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
