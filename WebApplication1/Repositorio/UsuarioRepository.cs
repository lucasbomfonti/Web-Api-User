using System.Collections.Generic;
using System.Linq;
using WebApplication1.Model;

namespace WebApplication1.Repositorio
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDbContext _contexto;
        public UsuarioRepository(UsuarioDbContext ctx)
        {
            _contexto = ctx;
        }
        public int Add(Usuario user)
        {
            _contexto.Usuarios.Add(user);
            _contexto.SaveChanges();
            return user.UsuarioId;
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _contexto.Usuarios.ToList();
        }

        public Usuario Find(int id)
        {
            return _contexto.Usuarios.Find(id);
        }

        public void Remove(int id)
        {
            var entity = Find(id);
            _contexto.Usuarios.Remove(entity);
            _contexto.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
            _contexto.SaveChanges();
        }
    }
}
