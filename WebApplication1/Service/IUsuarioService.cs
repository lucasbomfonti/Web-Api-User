using System.Collections.Generic;
using WebApplication1.Model;

namespace WebApplication1.Service
{
    public interface IUsuarioService
    {
        bool CreateUsuario(Usuario usuarioToCreate);
        IEnumerable<Usuario> ListUsuarios();
        Usuario Find(int id);
        void Remove(int id);
        void Update(Usuario user, int id);
    }
}
