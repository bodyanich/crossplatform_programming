using cross_lab5.Models.DTO;

namespace cross_lab5.Models
{
    public class ManufacturerModel
    {
        public string ManufacturerCodeToSearch { get; set; }

        public List<Manufacturer> Manufacturers { get; set; }
    }
}
