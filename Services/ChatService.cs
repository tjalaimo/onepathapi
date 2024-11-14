using onepathapi.Data;
using onepathapi.Models;
using Microsoft.EntityFrameworkCore;

namespace onepathapi.Services
{
    public interface IChatService
    {
        object GetChats(string userId);
        string SendMessage();
    }

    public class ChatService : IChatService
    {
        private readonly ApplicationDbContext _context;

        public ChatService(ApplicationDbContext context)
        {
            _context = context;
        }

        public object GetChats(string userId)
        {
            return new[]
            {
                new { Sender = "User1", Recipient = "User2", Message = "Hello!", Timestamp = "2024-10-12T10:00:00" },
                new { Sender = "User2", Recipient = "User1", Message = "Hi there!", Timestamp = "2024-10-12T10:05:00" }
            };
        }

        public string SendMessage()
        {
            return "Message sent successfully!";
        }
    }
}
