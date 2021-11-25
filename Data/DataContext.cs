using server.Models;
using Microsoft.EntityFrameworkCore;

namespace server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<FormaPagamento> FormasPagamento { get; set; }

    }
}