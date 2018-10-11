using System.Collections.Generic;
using WebApplication1.Model;

namespace WebApplication1.Repositorio
{
    public interface IUsuarioRepository
    {
        int Add(Usuario user);
        IEnumerable<Usuario> GetAll();
        Usuario Find(int id);
        void Remove(int id);
        void Update(Usuario user);
    }
}