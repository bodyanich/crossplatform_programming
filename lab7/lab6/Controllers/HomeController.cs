using cross_lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using Asp.Versioning;

namespace cross_lab5.Controllers
{
    [ApiController]
    [Route("api/{version:apiVersion}/[controller]/[action]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet, MapToApiVersion("1.0")]
        public IActionResult IndexV1()
        {
            return View("IndexV1");
        }

        [HttpGet, MapToApiVersion("2.0")]
        public IActionResult IndexV2()
        {
            return View("IndexV2");
        }

    }
}