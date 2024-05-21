using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _924_server.Data;
using _924_server.Entities;

namespace _924_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapLocationController : ControllerBase
    {
        private readonly DataContext _context;
        
        public MapLocationController(DataContext context)
        {
            _context = context;
        }
        
        [HttpGet("GetCurrentLocation/{id}")]
        public async Task<ActionResult<MapLocation>> GetCurrentLocation(int id)
        {
            var location = await _context.MapLocations.FirstOrDefaultAsync(x => x.UserId == id);
            if (location == null) return NotFound("Location not found");
            return Ok(location);
        }
        
    }
}
