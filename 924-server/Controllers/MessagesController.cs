using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _924_server.Data;
using _924_server.Entities;

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
        
        [HttpPost]
        public async Task<ActionResult<Message>> AddMessage(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return Ok(message);
        }
        
    }
}
