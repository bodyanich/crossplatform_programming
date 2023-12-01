using System.ComponentModel.DataAnnotations;

namespace lab6_RESTful.Models
{
    public class Vehicle_Category
    {
        [Key]
        [StringLength(5)]
        public string vegicle_category_code { get; set; } = "00000";
        public string? vegicle_category_description { get; set; }

    }
}
