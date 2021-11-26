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
                    new Produto { Id = 1, Nome = "Biscoito", Preco = 10, Quantidade = 10, CategoriaId = 1 },
                    new Produto { Id = 2, Nome = "Massa", Preco = 20, Quantidade = 20, CategoriaId = 1 },
                    new Produto { Id = 3, Nome = "Molho", Preco = 30, Quantidade = 30, CategoriaId = 1 },
                    new Produto { Id = 4, Nome = "Água", Preco = 10, Quantidade = 10, CategoriaId = 2 },
                    new Produto { Id = 5, Nome = "Suco", Preco = 20, Quantidade = 20, CategoriaId = 2 },
                    new Produto { Id = 6, Nome = "Cerveja", Preco = 30, Quantidade = 30, CategoriaId = 2 },
                }
            );

            _context.FormasPagamento.AddRange(new FormaPagamento[]
                {
                    new FormaPagamento { Id = 1, Descricao = "Cartão de Crédito", Simbolo = "CC" },
                    new FormaPagamento { Id = 2, Descricao = "Cartão de Débito", Simbolo = "CD" },
                    new FormaPagamento { Id = 3, Descricao = "Pix", Simbolo = "PIX" }
                }
            );

            _context.SaveChanges();
            return Ok(new { message = "Dados inicializados com sucesso!" });
        }
    }
}