using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TokenAPI.Libs;
using TokenAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TokenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // GET: api/<UsuarioController>
        [HttpGet]
        public dynamic Get()
        {
            return new
            {
                success = true,
                message = "Lista de Usuarios",
                result = Usuario.GetUsuarios()
            };
        }

        // GET api/<UsuarioController>/5
        [Authorize]
        [HttpGet("{id}")]
        public dynamic Get(string id)
        {

            var usuario = Usuario.GetUsuarios().FirstOrDefault( x => x.Id == id);

            if (usuario == null)
            {

                return new
                {
                    success = false,
                    message = "Usuario no encontrado.",
                    result = id
                };

            }
            else 
            {

                return new
                {
                    success = true,
                    message = "Usuario encontrado.",
                    result = usuario
                };

            }

        }

        // POST api/<UsuarioController>
        [HttpPost]
        public dynamic Post([FromBody] Usuario usuario)
        {

            return new
            {
                success = true,
                message = "Usuario agregado.",
                result = usuario
            };

        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public dynamic Put(string id, [FromBody] Usuario usuario)
        {

            return new
            {
                success = true,
                message = String.Format("Usuario con el Id {0} ha sido actualizado.", 0),
                result = usuario
            };

        }

        // DELETE 
        [HttpPost]
        [Route("Delete")]
        public dynamic Delete(Usuario _usuario)
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var miToken = JsonWebTokenLibreria.ValidarMiToken(identity);

            if ( miToken.success == false)  // !miToken.success 
                return miToken;

            Usuario usuario = miToken.result;

            if (usuario.Rol != "admin")     // !usuario.Rol.Equals("admin")
            {
                return new
                {
                    message = "El rol del usuario no esta autorizado.",
                    success = false,
                    result = ""
                };
            }

            return new
            {
                success = true,
                message = String.Format("El registro ha sido eliminado."),
                result = ""
            };

        }
    }
}
