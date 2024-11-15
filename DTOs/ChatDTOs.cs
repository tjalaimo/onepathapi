using onepathapi.Models;

namespace onepathapi.DTOs
{
    public class MessageDTO
    {
        public int MessageId { get; set; }
        public string MessageContent { get; set; }
        public string? MediaUrl { get; set; }
        public DateTime? SentDate { get; set; }
        public BaseUserDTO SentByUser { get; set; }

        public MessageDTO(Message message)
        {
            MessageId = message.MessageId;
            MessageContent = message.MessageContent;
            MediaUrl = string.Empty; //TODO store this and find somewhere to put images/media
            SentDate = message.SentDate;
            SentByUser = new BaseUserDTO(message.SentByUser);
        }
    }

    public class MessageThreadDTO
    {
        public int ThreadId { get; set; }
        public BaseUserDTO InitiatorUser { get; set; }
        public BaseUserDTO RecipientUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public List<MessageDTO> Messages { get; set; } = new List<MessageDTO>();
    }

}