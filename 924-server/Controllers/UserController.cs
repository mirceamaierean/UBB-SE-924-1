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
            var users = await _context.Users.ToListAsync();
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
            var chats = await _context.UserChats
                .Where(x => x.UserId == id)
                .Select(x => x.Chat)
                .ToListAsync();
            
            //if (chats.Count == 0) return NotFound("User has no chats");
            
            return Ok(chats);
        }
    }
}
