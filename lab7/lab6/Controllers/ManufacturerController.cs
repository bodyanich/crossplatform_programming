using cross_lab5.Data;
using cross_lab5.Models;
using Microsoft.AspNetCore.Mvc;

namespace cross_lab5.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly RESTfulDataSource DataSource;

        public ManufacturerController(RESTfulDataSource DataSource)
        {
            this.DataSource = DataSource;
        }

        public IActionResult Manufacturer()
        {
            var list = DataSource.GetManufacturerAsync().Result;
            return View(
                new ManufacturerModel
                {
                    Manufacturers = list
                }
            );
        }

        [HttpPost]
        public IActionResult Manufacturer(ManufacturerModel model)
        {
            var list = DataSource.GetManufacturerAsync(model.ManufacturerCodeToSearch).Result;
            return View(
                new ManufacturerModel
                {
                    Manufacturers = list
                }
            );
        }

    }
}
