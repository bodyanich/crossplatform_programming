using System.ComponentModel.DataAnnotations;

namespace lab6_RESTful.Models
{
    public class Model
    {
        [Key]
        [StringLength(10)]
        public string model_code { get; set; } = "0000000000";
        public double daily_hire_rate { get; set; }
        public string? model_name { get; set; }
    }
}
