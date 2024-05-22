using _924_server.Data;
using _924_server.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _924_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly DataContext _context;

        public RequestController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Request
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequests()
        {
            return await _context.Requests.ToListAsync();
        }

        // GET: api/Request/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }

        // POST: api/Request
        [HttpPost]
        public async Task<ActionResult<Request>> PostRequest(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequest", new { id = request.Id }, request);
        }

        // PUT: api/Request/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequest(int id, Request request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Request/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
        // GET: api/Request/SentByUser/5
        [HttpGet("SentByUser/{userId}")]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequestsSentByUser(int userId)
        {
            var requests = await _context.Requests.Where(r => r.SenderId == userId).ToListAsync();

            if (requests == null)
            {
                return NotFound();
            }

            return Ok(requests);
        }

        // GET: api/Request/ReceivedByUser/5
        [HttpGet("ReceivedByUser/{userId}")]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequestsReceivedByUser(int userId)
        {
            var requests = await _context.Requests.Where(r => r.ReceiverId == userId).ToListAsync();

            if (requests == null)
            {
                return NotFound();
            }

            return Ok(requests);
        }
        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.Id == id);
        }
    }
}