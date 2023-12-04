namespace lab6_RESTful.Models
{
    public class VehicleModel
    {
        public string? RegNumber { get; set; }
        public int CurrentMilleage { get; set; }
        public DateTime? date_mot_due { get; set; }
        //=====================================================
        public string? ManufacturerName { get; set; }
        public string? ManufacturerDetails { get; set; }
        //=====================================================
        public double daily_hire_rate { get; set; }
        public string? model_name { get; set; }
        //=====================================================
        public string? vegicle_category_description { get; set; }
    }
}
