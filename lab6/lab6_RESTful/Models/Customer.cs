using System.ComponentModel.DataAnnotations;

namespace lab6_RESTful.Models
{
    public class Customer
    {
        [Key]
        public int customer_id { get; set; }
        public string? customer_name { get; set; }
        public string? customer_details { get; set; }
        [StringLength(1)]
        public string? gender { get; set; }
        public string? customer_email { get; set; }
        public string? customer_phone { get; set; }
        public string? customer_address { get; set; }
        public string? customer_country { get; set; }
        public string? town { get; set; }
        public string? county { get; set; }

    }
}
