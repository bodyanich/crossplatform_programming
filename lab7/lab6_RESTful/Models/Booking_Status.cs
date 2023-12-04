using System.ComponentModel.DataAnnotations;

namespace lab6_RESTful.Models
{
    public class Booking_Status
    {
        [Key]
        [StringLength(3)]
        public string booking_status_code { get; set; } = "000";
        public string? booking_status_description { get; set; }

    }
}
