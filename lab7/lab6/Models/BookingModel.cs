using cross_lab5.Models.DTO;

namespace cross_lab5.Models
{
    public class BookingModel
    {
        public int BookingIdToSearch { get; set; }
        public string? DateTo { get; set; } = null;

        public string? DateFromStart { get; set; } = null;

        public string? DateFromEnd { get; set; } = null;

        public string? Query { get; set; } = null;

        public List<Booking> Bookings { get; set; }
    }
}
