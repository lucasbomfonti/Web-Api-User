using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Repositorio;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [Route("api/usuario")]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioService _service;
        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Usuario> GetAll()
        {
            return _service.ListUsuarios();
        }

        [HttpGet("{id}", Name = "GetUsuario")]
        public IActionResult GetById(int id)
        {
             _service.Find(id);        
            return new ObjectResult(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Usuario usuario)
        {

            _service.CreateUsuario(usuario);
            return CreatedAtRoute("getUsuario", new { id = usuario.UsuarioId }, usuario);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Usuario usuario)
        {
            
            _service.Update(usuario, id);
            return new NoContentResult();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {           
            _service.Remove(id);
            return new NoContentResult();

         }
    }
}
