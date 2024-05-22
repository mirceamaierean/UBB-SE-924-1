using _924_server.Data;
using _924_server.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace _924_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        
        public UserController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _context.Users.AsNoTracking().ToListAsync();
            return Ok(users);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound("User not found");
            return Ok(user);
        }
        
        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return NotFound();
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, User user)
        {
            var userToUpdate = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (userToUpdate == null) return NotFound();
            userToUpdate.Name = user.Name;
            await _context.SaveChangesAsync();
            return Ok();
        }
        
        // define endpoint for getting all chats of a user
        [HttpGet("{id}/chats")]
        public async Task<ActionResult<List<Chat>>> GetUserChats(int id)
        {
            var chats = await _context.UserChats.AsNoTracking()
                .Where(x => x.UserId == id)
                .Join(
                    _context.Chats,
                    uc => uc.ChatId,
                    c => c.Id,
                    (uc, c) => c
                )
                .ToListAsync();
            
            //if (chats.Count == 0) return NotFound("User has no chats");
            
            return Ok(chats);
        }

        [HttpPost("{userId}/chats/{chatId}")]
        public async Task<ActionResult<UserChat>> AddUserChat(int userId, int chatId)
        {
            // Check if the user exists
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return NotFound("User not found");

            // Check if the chat exists
            var chat = await _context.Chats.FindAsync(chatId);
            if (chat == null)
                return NotFound("Chat not found");

            // Check if the user chat relationship already exists
            var existingUserChat = await _context.UserChats
                .FirstOrDefaultAsync(uc => uc.UserId == userId && uc.ChatId == chatId);

            if (existingUserChat != null)
                return Conflict("UserChat relationship already exists");

            // Create the UserChat relationship
            var newUserChat = new UserChat
            {
                UserId = userId,
                ChatId = chatId
            };

            _context.UserChats.Add(newUserChat);
            await _context.SaveChangesAsync();

            return Ok(newUserChat);
        }

    }
}
