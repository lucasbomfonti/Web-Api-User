using System;
using System.Collections.Generic;
using WebApplication1.Model;
using WebApplication1.Repositorio;
using WebApplication1.Service;

namespace ApiUsuarios1.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IValidacao _validacao;
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IValidacao validacao, IUsuarioRepository repository)
        {
            _validacao = validacao;
            _repository = repository;
        }

        protected bool ValidateUsuario(Usuario usuarioToValidate)
        {
            if (usuarioToValidate.Nome.Trim().Length == 0)
                _validacao.addError("Name", "Name is required");
            return _validacao.isValid;
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
            throw new NotImplementedException();
        }

        public void Update(Usuario user)
        {
            throw new NotImplementedException();
        }
    }
}
