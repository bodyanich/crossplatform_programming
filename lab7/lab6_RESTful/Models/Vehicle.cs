using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab6_RESTful.Models
{
    public class Vehicle
    {
        [Key]
        [StringLength(10)]
        public string reg_number { get; set; } = "00000";

        [Required]
        [StringLength(10)]
        [Column("manufacturer_code")]
        public string? ManufacturerId { get; set; }
        [ForeignKey("ManufacturerId")]
        public Manufacturer? Manufacturer { get; set; }

        [Required]
        [StringLength(10)]
        [Column("model_code")]
        public string? ModelId { get; set; }
        [ForeignKey("ModelId")]
        public Model? Model { get; set; }

        [Required]
        [StringLength(5)]
        [Column("vegicle_category_code")]
        public string? Vehicle_CategoryId { get; set; }
        [ForeignKey("Vehicle_CategoryId")]
        public Vehicle_Category? Vehicle_Category { get; set; }

        public int current_mileage { get; set; }
        public DateTime? date_mot_due { get; set; }
    }
}
