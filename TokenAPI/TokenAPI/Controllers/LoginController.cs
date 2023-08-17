using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TokenAPI.Libs;
using TokenAPI.Models;


namespace TokenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        public IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        // POST api/<LoginController>
        [AllowAnonymous]
        [HttpPost]
        public dynamic Post([FromBody] Login login)
        {

            var nombre = login.usuario;
            var password = login.password;

            //// validar las credenciales de acceso.
            //var usuario = Usuario
            //              .GetUsuarios()    // retornar la lista de usuarios.

            //              // buscar en la lista de usuarios todos los valores correspondientes a los campos Nombre y Password
            //              //.Where(x => x.Nombre == nombre && x.Password == password)
            //              .Where(x => x.Nombre.Equals(nombre) && x.Password.Equals(password))

            //              .FirstOrDefault();  

            var usuario = Usuario.GetUsuarios().Where(x => x.Nombre == nombre && x.Password == password).FirstOrDefault();


            if (usuario == null)
            {
                return new
                {
                    success = false,
                    message = "Usuario o Contrasena no son validas.",
                    result = ""
                };
            }

            // las credenciales de acceso son validas, procedemos a construir el JWT con los valores adecuados.

            // leer los parametros Jwt de appsettings.json y asignar al objeto del tipo JWT.
            var jwt = _config.GetSection("Jwt").Get<JWT>();

            // invocar el metodo que construye la cadena del token.
            var mitoken = JsonWebTokenLibreria.CrearMiToken(jwt , usuario);

            return new
            {
                message = "El Token ha sido creado.",
                success = true,
                result = new JwtSecurityTokenHandler().WriteToken(mitoken) // retornar el cifrado del token.
            };

        }

    }
}
