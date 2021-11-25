using System;
using System.Linq;
using server.Data;
using server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace server.Controllers
{
    [ApiController]
    [Route("server/item")]
    public class ItemVendaController : ControllerBase
    {
        private readonly DataContext _context;
        public ItemVendaController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] ItemVenda item)
        {
            if (String.IsNullOrEmpty(item.CarrinhoId))
            {
                item.CarrinhoId = Guid.NewGuid().ToString();
            }
            item.Produto = _context.Produtos.Find(item.ProdutoId);
            _context.ItensVenda.Add(item);
            _context.SaveChanges();
            return Created("", item);
        }

        // GET: server/item/getbycartid/XXXXX-XXXX-XXXXXXXXXXX
        [HttpGet]
        [Route("getbycartid/{cartid}")]
        public IActionResult GetByCartId([FromRoute] string cartId)
        {
            return Ok(_context.ItensVenda.
                Include(i => i.Produto.Categoria).
                Where(i => i.CarrinhoId == cartId).
                ToList());
        }
    }
}