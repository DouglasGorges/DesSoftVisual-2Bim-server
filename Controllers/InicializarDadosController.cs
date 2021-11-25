using server.Data;
using server.Models;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [ApiController]
    [Route("server/inicializar")]
    public class InicializarDadosController : ControllerBase
    {
        private readonly DataContext _context;
        public InicializarDadosController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create()
        {
            _context.Categorias.AddRange(new Categoria[]
                {
                    new Categoria { CategoriaId = 1, Nome = "Alimentos" },
                    new Categoria { CategoriaId = 2, Nome = "Bebidas" },
                }
            );
            _context.Produtos.AddRange(new Produto[]
                {
                    new Produto { ProdutoId = 1, Nome = "Biscoito", Preco = 10, Quantidade = 10, CategoriaId = 1 },
                    new Produto { ProdutoId = 2, Nome = "Massa", Preco = 20, Quantidade = 20, CategoriaId = 1 },
                    new Produto { ProdutoId = 3, Nome = "Molho", Preco = 30, Quantidade = 30, CategoriaId = 1 },
                    new Produto { ProdutoId = 1, Nome = "Água'", Preco = 10, Quantidade = 10, CategoriaId = 2 },
                    new Produto { ProdutoId = 2, Nome = "Suco", Preco = 20, Quantidade = 20, CategoriaId = 2 },
                    new Produto { ProdutoId = 3, Nome = "Cerveja", Preco = 30, Quantidade = 30, CategoriaId = 2 },
                }
            );
            _context.SaveChanges();
            return Ok(new { message = "Dados inicializados com sucesso!" });
        }
    }
}