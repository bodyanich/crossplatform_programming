using lab6_RESTful.Data;
using lab6_RESTful.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab6_RESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            var bookings =
                await (from booking in _context.Booking
                       join bookingStatus in _context.Booking_Status on booking.Booking_StatusId equals bookingStatus.booking_status_code
                       join customer in _context.Customer on booking.CustomerId equals customer.customer_id
                       join vehicle in _context.Vehicle on booking.VehicleId equals vehicle.reg_number
                       join manufacturer in _context.Manufacturer on vehicle.ManufacturerId equals manufacturer.manufacturer_code
                       join model in _context.Model on vehicle.ModelId equals model.model_code
                       join vehicleCategory in _context.Vehicle_Category on vehicle.Vehicle_CategoryId equals vehicleCategory.vegicle_category_code
                       select new BookingModel
                       {
                           BookingId = booking.booking_id,
                           date_from = booking.date_from,
                           date_to = booking.date_to,
                           confirmation_letter_sent_yn = booking.confirmation_letter_sent_yn,
                           payment_recived_yn = booking.payment_recived_yn,
                           CustomerName = customer.customer_name,
                           customer_details = customer.customer_details,
                           BookingStatusDescription = bookingStatus.booking_status_description,
                           RegNumber = vehicle.reg_number,
                           CurrentMilleage = vehicle.current_mileage,
                           date_mot_due = vehicle.date_mot_due,
                           ManufacturerName = manufacturer.manufacturer_name,
                           ManufacturerDetails = manufacturer.manufacturer_details,
                           daily_hire_rate = model.daily_hire_rate,
                           model_name = model.model_name,
                           vegicle_category_description = vehicleCategory.vegicle_category_description
                       }).ToListAsync();

            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBooking(int id)
        {
            var bookings =
                await (from booking in _context.Booking
                       where booking.booking_id == id
                       join bookingStatus in _context.Booking_Status on booking.Booking_StatusId equals bookingStatus.booking_status_code
                       join customer in _context.Customer on booking.CustomerId equals customer.customer_id
                       join vehicle in _context.Vehicle on booking.VehicleId equals vehicle.reg_number
                       join manufacturer in _context.Manufacturer on vehicle.ManufacturerId equals manufacturer.manufacturer_code
                       join model in _context.Model on vehicle.ModelId equals model.model_code
                       join vehicleCategory in _context.Vehicle_Category on vehicle.Vehicle_CategoryId equals vehicleCategory.vegicle_category_code
                       select new BookingModel
                       {
                           BookingId = booking.booking_id,
                           date_from = booking.date_from,
                           date_to = booking.date_to,
                           confirmation_letter_sent_yn = booking.confirmation_letter_sent_yn,
                           payment_recived_yn = booking.payment_recived_yn,
                           CustomerName = customer.customer_name,
                           customer_details = customer.customer_details,
                           BookingStatusDescription = bookingStatus.booking_status_description,
                           RegNumber = vehicle.reg_number,
                           CurrentMilleage = vehicle.current_mileage,
                           date_mot_due = vehicle.date_mot_due,
                           ManufacturerName = manufacturer.manufacturer_name,
                           ManufacturerDetails = manufacturer.manufacturer_details,
                           daily_hire_rate = model.daily_hire_rate,
                           model_name = model.model_name,
                           vegicle_category_description = vehicleCategory.vegicle_category_description
                       }).ToListAsync();

            return Ok(bookings);
        }

        [HttpGet("date-to")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookingDateTo([FromQuery] DateTime date_to)
        {
            var bookings =
                await (from booking in _context.Booking
                       where booking.date_to == date_to
                       join bookingStatus in _context.Booking_Status on booking.Booking_StatusId equals bookingStatus.booking_status_code
                       join customer in _context.Customer on booking.CustomerId equals customer.customer_id
                       join vehicle in _context.Vehicle on booking.VehicleId equals vehicle.reg_number
                       join manufacturer in _context.Manufacturer on vehicle.ManufacturerId equals manufacturer.manufacturer_code
                       join model in _context.Model on vehicle.ModelId equals model.model_code
                       join vehicleCategory in _context.Vehicle_Category on vehicle.Vehicle_CategoryId equals vehicleCategory.vegicle_category_code
                       select new BookingModel
                       {
                           BookingId = booking.booking_id,
                           date_from = booking.date_from,
                           date_to = booking.date_to,
                           confirmation_letter_sent_yn = booking.confirmation_letter_sent_yn,
                           payment_recived_yn = booking.payment_recived_yn,
                           CustomerName = customer.customer_name,
                           customer_details = customer.customer_details,
                           BookingStatusDescription = bookingStatus.booking_status_description,
                           RegNumber = vehicle.reg_number,
                           CurrentMilleage = vehicle.current_mileage,
                           date_mot_due = vehicle.date_mot_due,
                           ManufacturerName = manufacturer.manufacturer_name,
                           ManufacturerDetails = manufacturer.manufacturer_details,
                           daily_hire_rate = model.daily_hire_rate,
                           model_name = model.model_name,
                           vegicle_category_description = vehicleCategory.vegicle_category_description
                       }).ToListAsync();

            return Ok(bookings);
        }

        [HttpGet("date-from-segment")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookingDateFromSegment([FromQuery] DateTime date_from_start, [FromQuery] DateTime date_from_end)
        {
            var bookings =
                await (from booking in _context.Booking
                       where booking.date_from >= date_from_start && booking.date_from <= date_from_end
                       join bookingStatus in _context.Booking_Status on booking.Booking_StatusId equals bookingStatus.booking_status_code
                       join customer in _context.Customer on booking.CustomerId equals customer.customer_id
                       join vehicle in _context.Vehicle on booking.VehicleId equals vehicle.reg_number
                       join manufacturer in _context.Manufacturer on vehicle.ManufacturerId equals manufacturer.manufacturer_code
                       join model in _context.Model on vehicle.ModelId equals model.model_code
                       join vehicleCategory in _context.Vehicle_Category on vehicle.Vehicle_CategoryId equals vehicleCategory.vegicle_category_code
                       select new BookingModel
                       {
                           BookingId = booking.booking_id,
                           date_from = booking.date_from,
                           date_to = booking.date_to,
                           confirmation_letter_sent_yn = booking.confirmation_letter_sent_yn,
                           payment_recived_yn = booking.payment_recived_yn,
                           CustomerName = customer.customer_name,
                           customer_details = customer.customer_details,
                           BookingStatusDescription = bookingStatus.booking_status_description,
                           RegNumber = vehicle.reg_number,
                           CurrentMilleage = vehicle.current_mileage,
                           date_mot_due = vehicle.date_mot_due,
                           ManufacturerName = manufacturer.manufacturer_name,
                           ManufacturerDetails = manufacturer.manufacturer_details,
                           daily_hire_rate = model.daily_hire_rate,
                           model_name = model.model_name,
                           vegicle_category_description = vehicleCategory.vegicle_category_description
                       }).ToListAsync();

            return Ok(bookings);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Booking>>> SearchBooking([FromQuery] string query)
        {
            var bookings =
                await (from booking in _context.Booking
                       join bookingStatus in _context.Booking_Status on booking.Booking_StatusId equals bookingStatus.booking_status_code
                       join customer in _context.Customer on booking.CustomerId equals customer.customer_id
                       join vehicle in _context.Vehicle on booking.VehicleId equals vehicle.reg_number
                       join manufacturer in _context.Manufacturer on vehicle.ManufacturerId equals manufacturer.manufacturer_code
                       join model in _context.Model on vehicle.ModelId equals model.model_code
                       join vehicleCategory in _context.Vehicle_Category on vehicle.Vehicle_CategoryId equals vehicleCategory.vegicle_category_code
                       select new BookingModel
                       {
                           BookingId = booking.booking_id,
                           date_from = booking.date_from,
                           date_to = booking.date_to,
                           confirmation_letter_sent_yn = booking.confirmation_letter_sent_yn,
                           payment_recived_yn = booking.payment_recived_yn,
                           CustomerName = customer.customer_name,
                           customer_details = customer.customer_details,
                           BookingStatusDescription = bookingStatus.booking_status_description,
                           RegNumber = vehicle.reg_number,
                           CurrentMilleage = vehicle.current_mileage,
                           date_mot_due = vehicle.date_mot_due,
                           ManufacturerName = manufacturer.manufacturer_name,
                           ManufacturerDetails = manufacturer.manufacturer_details,
                           daily_hire_rate = model.daily_hire_rate,
                           model_name = model.model_name,
                           vegicle_category_description = vehicleCategory.vegicle_category_description
                       })
                       .Where(booking =>
                        EF.Functions.Like(booking.confirmation_letter_sent_yn, $"%{query}%") ||
                        EF.Functions.Like(booking.payment_recived_yn, $"%{query}%") ||
                        EF.Functions.Like(booking.CustomerName, $"%{query}%") ||
                        EF.Functions.Like(booking.BookingStatusDescription, $"%{query}%") ||
                        EF.Functions.Like(booking.RegNumber, $"%{query}%") ||
                        EF.Functions.Like(booking.CurrentMilleage.ToString(), $"%{query}%") ||
                        EF.Functions.Like(booking.date_mot_due.ToString(), $"%{query}%") ||
                        EF.Functions.Like(booking.ManufacturerName, $"%{query}%") ||
                        EF.Functions.Like(booking.model_name, $"%{query}%") ||
                        EF.Functions.Like(booking.daily_hire_rate.ToString(), $"%{query}%"))
                       .ToListAsync();

            return Ok(bookings);
        }



        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking booking)
        {
            if (id != booking.booking_id)
            {
                return BadRequest();
            }

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccidentExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            _context.Booking.Add(booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccident", new { id = booking.booking_id }, booking);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var accident = await _context.Booking.FindAsync(id);
            if (accident == null)
            {
                return NotFound();
            }

            _context.Booking.Remove(accident);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccidentExists(int id)
        {
            return _context.Booking.Any(e => e.booking_id == id);
        }
    }
}
