using System.Linq;
using server.Data;
using server.Models;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [ApiController]
    [Route("server/categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly DataContext _context;
        public CategoriaController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return Created("", categoria);
        }

        [HttpGet]
        [Route("list")]
        public IActionResult List() => Ok(_context.Categorias.ToList());

    }
}