using lab6_RESTful.Data;
using lab6_RESTful.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab6_RESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            var customers = await _context.Customer.ToListAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer(int id)
        {
            var customers = await _context.Customer
                .Where(c => c.customer_id == id)
                .ToListAsync();

            if (customers == null)
            {
                return NotFound();
            }

            return Ok(customers);
        }
    }
}
