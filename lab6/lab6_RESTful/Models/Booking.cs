using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab6_RESTful.Models
{
    public class Booking
    {
        [Key]
        public int booking_id { get; set; }

        [Required]
        [StringLength(3)]
        [Column("booking_status_code")]
        public string? Booking_StatusId { get; set; }
        [ForeignKey("Booking_StatusId")]
        public Booking_Status? Booking_Status { get; set; }

        [Required]
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        [Required]
        [StringLength(10)]
        [Column("reg_number")]
        public string? VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public Vehicle? Vehicle { get; set; }

        public DateTime? date_from { get; set; }
        public DateTime? date_to { get; set; }
        [StringLength(1)]
        public string? confirmation_letter_sent_yn { get; set; }
        [StringLength(1)]
        public string? payment_recived_yn { get; set; }
    }
}
