using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Model
{
    public class UsuarioDbContext : DbContext
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}
