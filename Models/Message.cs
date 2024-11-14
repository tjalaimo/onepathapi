namespace onepathapi.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string MessageContent { get; set; }
        public DateTime SentDate { get; set; }
        public int ThreadId { get; set; }
        public int SentByUserId { get; set; }
        public MessageThread Thread { get; set; }
        public User SentByUser { get; set; }
    }
}
