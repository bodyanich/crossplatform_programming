using lab6_RESTful.Data;
using lab6_RESTful.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab6_RESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehicleCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle_Category>>> GetVehicleCategory()
        {
            var m = await _context.Vehicle_Category.ToListAsync();
            return Ok(m);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Vehicle_Category>>> GetVehicleCategory(string id)
        {
            var vehicle_Categories = await _context.Vehicle_Category
                .Where(m => m.vegicle_category_code == id)
                .ToListAsync();

            if (vehicle_Categories == null)
            {
                return NotFound();
            }

            return Ok(vehicle_Categories);
        }
    }
}
