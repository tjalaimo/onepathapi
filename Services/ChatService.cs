using onepathapi.Data;
using onepathapi.Models;
using Microsoft.EntityFrameworkCore;
using onepathapi.DTOs;

namespace onepathapi.Services
{
    public interface IChatService
    {
        Task<IEnumerable<MessageThreadDTO>> GetChats(int userId);
        Task<MessageThreadDTO> GetChat(int chatId);
        Task<Message> SendMessage(Message message);
    }

    public class ChatService : IChatService
    {
        private readonly ApplicationDbContext _context;

        public ChatService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MessageThreadDTO>> GetChats(int userId)
        {
            var messageThreads = await _context.MessageThreads
                .Where(mt => mt.InitiatorUserId == userId || mt.RecipientUserId == userId)
                .Select(mt => new MessageThreadDTO
                {
                    ThreadId = mt.ThreadId,
                    InitiatorUser = new BaseUserDTO(mt.InitiatorUser),
                    RecipientUser = new BaseUserDTO(mt.RecipientUser),
                    Messages = new List<MessageDTO>() {
                            new MessageDTO(mt.Messages
                                .Where(m => m.ThreadId == mt.ThreadId)
                                .OrderByDescending(m => m.SentDate)
                                .Take(1)
                                .FirstOrDefault()
                            )
                        }
                    })
                .ToListAsync();

            return messageThreads;
        }

        public async Task<MessageThreadDTO> GetChat(int chatId)
        {
            var thread = await _context.MessageThreads
                .Include(mt => mt.InitiatorUser)
                .Include(mt => mt.RecipientUser)
                .Include(mt => mt.Messages)
                .FirstOrDefaultAsync(mt => mt.ThreadId == chatId);

            if (thread != null)
            {
                // Order messages by SentDate descending
                thread.Messages = thread.Messages
                    .OrderByDescending(m => m.SentDate)
                    .ToList();
            }

            return new MessageThreadDTO
            {
                ThreadId = thread.ThreadId,
                InitiatorUser = new BaseUserDTO(thread.InitiatorUser),
                RecipientUser = new BaseUserDTO(thread.RecipientUser),
                CreatedDate = thread.CreatedDate,
                Messages = thread.Messages
                    .OrderByDescending(m => m.SentDate)
                    .Select(m => new MessageDTO(m))
                    .ToList()
            };
        }

        public async Task<Message> SendMessage(Message message)
        {
            message.SentDate = DateTime.UtcNow;

            // Add the message to the database
            _context.Messages.Add(message);

            // Ensure the thread exists
            var thread = await _context.MessageThreads.FirstOrDefaultAsync(t => t.ThreadId == message.ThreadId);
            if (thread == null)
            {
                throw new ArgumentException("Invalid thread ID.");
            }

            await _context.SaveChangesAsync();
            return message;
        }
    }
}
