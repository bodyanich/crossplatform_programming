using lab6_RESTful.Data;
using lab6_RESTful.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab6_RESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehicleController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicle()
        {
            var vehicles =
                await (from vehicle in _context.Vehicle
                       join manufacturer in _context.Manufacturer on vehicle.ManufacturerId equals manufacturer.manufacturer_code
                       join model in _context.Model on vehicle.ModelId equals model.model_code
                       join vehicleCategory in _context.Vehicle_Category on vehicle.Vehicle_CategoryId equals vehicleCategory.vegicle_category_code
                       select new VehicleModel
                       {
                           RegNumber = vehicle.reg_number,
                           CurrentMilleage = vehicle.current_mileage,
                           date_mot_due = vehicle.date_mot_due,
                           ManufacturerName = manufacturer.manufacturer_name,
                           ManufacturerDetails = manufacturer.manufacturer_details,
                           daily_hire_rate = model.daily_hire_rate,
                           model_name = model.model_name,
                           vegicle_category_description = vehicleCategory.vegicle_category_description
                       }).ToListAsync();

            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetVehicle(string id)
        {
            var vehicles =
                await (from vehicle in _context.Vehicle
                       where vehicle.reg_number == id
                       join manufacturer in _context.Manufacturer on vehicle.ManufacturerId equals manufacturer.manufacturer_code
                       join model in _context.Model on vehicle.ModelId equals model.model_code
                       join vehicleCategory in _context.Vehicle_Category on vehicle.Vehicle_CategoryId equals vehicleCategory.vegicle_category_code
                       select new VehicleModel
                       {
                           RegNumber = vehicle.reg_number,
                           CurrentMilleage = vehicle.current_mileage,
                           date_mot_due = vehicle.date_mot_due,
                           ManufacturerName = manufacturer.manufacturer_name,
                           ManufacturerDetails = manufacturer.manufacturer_details,
                           daily_hire_rate = model.daily_hire_rate,
                           model_name = model.model_name,
                           vegicle_category_description = vehicleCategory.vegicle_category_description
                       }).ToListAsync();

            return Ok(vehicles);
        }
    }
}
