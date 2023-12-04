using System.ComponentModel.DataAnnotations;

namespace lab6_RESTful.Models
{
    public class Manufacturer
    {
        [Key]
        [StringLength(10)]
        public string manufacturer_code { get; set; } = "0000000000";
        public string? manufacturer_name { get; set;}
        public string? manufacturer_details { get; set; }
    }
}
