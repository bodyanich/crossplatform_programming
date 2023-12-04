using lab6_RESTful.Data;
using lab6_RESTful.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab6_RESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking_Status>>> GetBookingStatus()
        {
            var m = await _context.Booking_Status.ToListAsync();
            return Ok(m);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Booking_Status>>> GetBookingStatus(string id)
        {
            var booking_Statuses = await _context.Booking_Status
                .Where(m => m.booking_status_code == id)
                .ToListAsync();

            if (booking_Statuses == null)
            {
                return NotFound();
            }

            return Ok(booking_Statuses);
        }
    }
}

