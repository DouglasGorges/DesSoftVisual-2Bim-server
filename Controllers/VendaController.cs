using System.Linq;
using server.Data;
using server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace server.Controllers
{
    [ApiController]
    [Route("server/venda")]
    public class VendaController : ControllerBase
    {
        private readonly DataContext _context;
        public VendaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("list")]
        public List<Venda> List()
        {
            return _context.Vendas.
                Include(i => i.Itens).
                ToList();
        }

        [HttpPost]
        [Route("create")]
        public Venda Create(Venda venda)
        {
            _context.Vendas.Add(venda);
            _context.SaveChanges();
            return venda;
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            Venda venda = _context.Vendas.Find(id);
            if (venda == null)
            {
                return NotFound();
            }
            return Ok(venda);
        }
    }
}