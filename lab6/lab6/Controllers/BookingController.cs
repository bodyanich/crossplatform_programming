using cross_lab5.Data;
using cross_lab5.Models;
using cross_lab5.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace cross_lab5.Controllers
{
    public class BookingController : Controller
    {
        private readonly RESTfulDataSource DataSource;

        public BookingController(RESTfulDataSource DataSource)
        {
            this.DataSource = DataSource;
        }

        public IActionResult Booking()
        {
            var list = DataSource.GetBookingAsync().Result;
            return View(
                new BookingModel
                {
                    Bookings = list
                }
            );
        }

        [HttpPost]
        public IActionResult Booking(BookingModel model)
        {
            var list = DataSource.GetBookingAsync(model.BookingIdToSearch).Result;
            return View(
            new BookingModel
            {
                Bookings = list
            });
        }

        public IActionResult BookingSearch(BookingModel model)
        {
            List<Booking> list;
            if (model.DateTo != null)
            {
                list = DataSource.GetBookingDateToAsync(model.DateTo).Result;
            }
            else if (model.DateFromStart != null && model.DateFromEnd != null)
            {
                list = DataSource.GetBookingDateFromSegmentAsync(model.DateFromStart, model.DateFromEnd).Result;
            }
            else if (model.Query != null)
            {
                list = DataSource.GetBookingByQueryAsync(model.Query).Result;
            }
            else
            {
                list = new List<Booking>();
            }

            return View(
                new BookingModel
                {
                    Bookings = list
                }
            );
        }
    }
}
