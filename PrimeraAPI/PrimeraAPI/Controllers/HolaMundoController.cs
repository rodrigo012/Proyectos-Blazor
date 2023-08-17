using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


/*
 * 
 * HolaMundoController : Representar el primer ejemplo de metodos Get y Get(id)
 * 
 */

namespace PrimeraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolaMundoController : ControllerBase
    {

        [HttpGet]
        public string Get() 
        {
            return "H O L A   M U N D O";
        }


        [HttpGet("{nombre}")]
        public string Get(string nombre)
        {
            return string.Format("H O L A  {0} !!" + nombre);
        }

    }
}
