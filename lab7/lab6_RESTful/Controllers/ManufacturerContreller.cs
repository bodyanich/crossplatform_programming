using lab6_RESTful.Data;
using lab6_RESTful.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab6_RESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManufacturerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetManufacturer()
        {
            var m = await _context.Manufacturer.ToListAsync();
            return Ok(m);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetManufacturer(string id)
        {
            var manufacturers =  await _context.Manufacturer
                .Where(m => m.manufacturer_code == id)
                .ToListAsync();

            if (manufacturers == null)
            {
                return NotFound();
            }

            return Ok(manufacturers);
        }
    }
}
