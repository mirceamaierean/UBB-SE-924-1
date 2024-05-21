using _924_server.Data;
using _924_server.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _924_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly DataContext _context;

        public MessagesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Chat>>> GetAllChats()
        {
            var chats = await _context.Chats.ToListAsync();
            return Ok(chats);
        }

        [HttpGet("{chatId}")]
        public async Task<ActionResult<Chat>> GetChat(int chatId)
        {
            var chat = await _context.Chats.FindAsync(chatId);
            if (chat == null) return NotFound("Chat not found");
            return Ok(chat);
        }

        [HttpGet("user/{userId}/chats")]
        public async Task<ActionResult<List<Chat>>> GetUserChats(int userId)
        {
            var chats = await _context.UserChats
                .Where(uc => uc.UserId == userId)
                .Select(uc => uc.Chat)
                .ToListAsync();
            return Ok(chats);
        }

        [HttpGet("{chatId}/participants")]
        public async Task<ActionResult<List<User>>> GetChatParticipants(int chatId)
        {
            var participants = await _context.UserChats
                .Where(uc => uc.ChatId == chatId)
                .Select(uc => uc.User)
                .ToListAsync();
            return Ok(participants);
        }

        [HttpGet("{chatId}/messages")]
        public async Task<ActionResult<List<Message>>> GetChatMessages(int chatId)
        {
            var messages = await _context.Messages
                .Where(m => m.ChatId == chatId)
                .ToListAsync();
            return Ok(messages);
        }

        [HttpPost]
        public async Task<ActionResult<Message>> AddMessage(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return Ok(message);
        }

        [HttpGet("{chatId}/lastmessage")]
        public async Task<ActionResult<Message>> GetChatLastMessage(int chatId)
        {
            var lastMessage = await _context.Messages
                .Where(m => m.ChatId == chatId)
                .OrderByDescending(m => m.SentTime)
                .FirstOrDefaultAsync();
            if (lastMessage == null) return NotFound("No messages found for this chat");
            return Ok(lastMessage);
        }

        [HttpPost("{chatId}/addmessage")]
        public async Task<ActionResult<Message>> AddMessageToChat(int chatId, Message message)
        {
            var chat = await _context.Chats.FindAsync(chatId);
            if (chat == null) return NotFound("Chat not found");

            message.ChatId = chatId;
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return Ok(message);
        }
    }
}
