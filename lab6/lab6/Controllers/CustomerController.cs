using cross_lab5.Data;
using cross_lab5.Models;
using Microsoft.AspNetCore.Mvc;

namespace cross_lab5.Controllers
{
    public class CustomerController : Controller
    {
        private readonly RESTfulDataSource DataSource;

        public CustomerController(RESTfulDataSource DataSource)
        {
            this.DataSource = DataSource;
        }

        public IActionResult Customer()
        {
            var list = DataSource.GetCustomerAsync().Result;
            return View(
                new CustomerModel
                {
                    Customers = list
                }
            );
        }

        [HttpPost]
        public IActionResult Customer(CustomerModel model)
        {
            var list = DataSource.GetCustomerAsync(model.CustomerIdToSearch).Result;
            return View(
                new CustomerModel
                {
                    Customers = list
                }
            );
        }
    }
}
