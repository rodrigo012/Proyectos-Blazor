using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TokenAPI.Models;

namespace TokenAPI.Libs
{

    // Bearer XXXXXXXXXXXXXXXXXXXXXXXXXXXX

    public static class JsonWebTokenLibreria
    {

        // crear y configurar el objeto Token.
        public static JwtSecurityToken CrearMiToken(JWT _jwt , Usuario usuario)
        {

            // ASIGNACIÓN : Actualizar el metodo, para asignar los valores id y nombre del usuario.
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, _jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("id", usuario.Id),
                new Claim("nombre", usuario.Nombre)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                  _jwt.Issuer,
                  _jwt.Audience,
                  claims,
                  expires: DateTime.Now.AddMinutes(240),
                  signingCredentials: credentials
            );

            return token;

        }

        // validar el Token considerando el Claim Id del usuario.
        public static dynamic ValidarMiToken(ClaimsIdentity identity)
        {

            if (identity.Claims.Count() == 0)
            {
                return new
                {
                    message = "El token no es valido",
                    success = false,
                    result = ""
                };
            }
  
            // leer el valor del claims Id.
            var id = identity.Claims.FirstOrDefault(x => x.Type == "id").Value;

            Usuario usuario = Usuario
                              .GetUsuarios()
                              .FirstOrDefault(x => x.Id == id);

            if (usuario == null)
            {
                return new
                {
                    message = "Usuario no es valido",
                    success = false,
                    result = ""
                };
            }
            else
            {
                return new
                {
                    message = "Usuario es valido",
                    success = true,
                    result = usuario
                };
            }

        }

    }
}
