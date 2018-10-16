using System;
using System.Collections.Generic;
using WebApplication1.Model;
using WebApplication1.Repositorio;

namespace WebApplication1.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;


        public UsuarioService(IUsuarioRepository repository)
        {
            //_validacao = validacao;
            _repository = repository;
        }



        protected bool ValidateUsuario(Usuario usuarioToValidate)
        {
            if (usuarioToValidate.Nome.Trim().Length < 6)                  
                throw new Exception("erro");
            return true;
        }

        public IEnumerable<Usuario> ListUsuarios()
        {
            return _repository.GetAll();
        }


        public bool CreateUsuario(Usuario usuarioToCreate)
        {
           if (!ValidateUsuario(usuarioToCreate))
            return false;
            try
            {
                _repository.Add(usuarioToCreate);
            }
            catch
            {
                return false;
            }

            return true;
        }
    
        public Usuario Find(int id)
        {
            return _repository.Find(id);
        }

        public void Remove(int id)
        {
            var usuario = _repository.Find(id);
            if (usuario != null)
            _repository.Remove(id);
        }

        public void Update(Usuario user, int id)
        {
            if (user == null || user.UsuarioId != id)
            {
                throw new Exception("fail");
            }
            var usuario = _repository.Find(user.UsuarioId);
            if (usuario == null)
            {
                throw new Exception("fail");
            }

            usuario.Email = user.Email;
            usuario.Nome = user.Nome;
            _repository.Update(usuario);
        }
    
    }
}
