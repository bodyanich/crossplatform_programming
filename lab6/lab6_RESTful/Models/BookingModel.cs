using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.ComponentModel.DataAnnotations;

namespace lab6_RESTful.Models
{
    public class BookingModel
    {
        public int BookingId { get; set; }
        public DateTime? date_from { get; set; }
        public DateTime? date_to { get; set; }
        public string? confirmation_letter_sent_yn { get; set; }
        public string? payment_recived_yn { get; set; }
        //=====================================================
        public string? CustomerName { get; set; }
        public string? customer_details { get; set; }
        //=====================================================
        public string? BookingStatusDescription { get; set; }
        //=====================================================
        public string? RegNumber { get; set; }
        public int CurrentMilleage { get; set; }
        public DateTime? date_mot_due { get; set; }
        //=====================================================
        public string? ManufacturerName { get; set; }
        public string? ManufacturerDetails { get; set;}
        //=====================================================
        public double daily_hire_rate { get; set; }
        public string? model_name { get; set; }
        //=====================================================
        public string? vegicle_category_description { get; set; }
    }
}
