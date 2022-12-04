using Microsoft.EntityFrameworkCore;
using TPFinal.Web.Models;

namespace TPFinal.Web
{
    public class TpFinalContext : DbContext
    {
        public TpFinalContext(DbContextOptions<TpFinalContext> options)
          : base(options)
        { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
