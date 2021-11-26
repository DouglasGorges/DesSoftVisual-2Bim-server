using System;
using System.Linq;
using server.Data;
using server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace server.Controllers
{
    [ApiController]
    [Route("server/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly DataContext _context;
        public ProdutoController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Produto produto)
        {
            produto.Categoria = _context.Categorias.Find(produto.CategoriaId);
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return Created("", produto);
        }

        [HttpGet]
        [Route("list")]
        public IActionResult List() =>
            Ok(_context.Produtos
            .Include(p => p.Categoria)
            .ToList());

        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            Produto produto = _context.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpDelete]
        [Route("delete/{nome}")]
        public IActionResult Delete([FromRoute] string nome)
        {
            //Expressão lambda
            //Buscar um objeto na tabela de produtos com base no nome
            Produto produto = _context.Produtos.FirstOrDefault(produto => produto.Nome == nome);

            if (produto == null)
            {
                return NotFound();
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return Ok(_context.Produtos.ToList());
        }


        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
            return Ok(produto);
        }
    }
}