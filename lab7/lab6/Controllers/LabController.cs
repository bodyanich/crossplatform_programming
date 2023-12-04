using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using cross_lab5.Models;
using cross_lab5.Data;

namespace cross_lab5.Controllers
{
    [Authorize]
    public class LabController : Controller
    {
        private Lab123Executor lab123Executor;

        public LabController(Lab123Executor lab123Executor)
        {
            this.lab123Executor = lab123Executor;
        }

        [HttpGet]
        public IActionResult Lab1()
        {
            return View(new LabViewModel());
        }

        [HttpPost]
        public IActionResult Lab1(LabViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Lab1", model);
            }

            string outputText = lab123Executor.ExecuteLab1(model.Input);
            model.Output = outputText;
            return View(model);
        }

        [HttpGet]
        public IActionResult Lab2()
        {
            return View(new LabViewModel());
        }

        [HttpPost]
        public IActionResult Lab2(LabViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Lab2", model);
            }

            string outputText = lab123Executor.ExecuteLab2(model.Input);
            model.Output = outputText;
            return View(model);
        }

        [HttpGet]
        public IActionResult Lab3()
        {
            return View(new LabViewModel());
        }

        [HttpPost]
        public IActionResult Lab3(LabViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Lab3", model);
            }

            string outputText = lab123Executor.ExecuteLab3(model.Input);
            model.Output = outputText;
            return View(model);
        }
    }
}
