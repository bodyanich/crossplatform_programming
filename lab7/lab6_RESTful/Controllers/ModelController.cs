using lab6_RESTful.Data;
using lab6_RESTful.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab6_RESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModelController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model>>> GetModel()
        {
            var m = await _context.Model.ToListAsync();
            return Ok(m);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Model>>> GetModel(string id)
        {
            var models = await _context.Model
                .Where(m => m.model_code == id)
                .ToListAsync();

            if (models == null)
            {
                return NotFound();
            }

            return Ok(models);
        }
    }
}
