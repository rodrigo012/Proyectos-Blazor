using DbFirstEjemplo.Core;
using DbFirstEjemplo.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbFirstEjemplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadorController : ControllerBase
    {
        private readonly IJugadorService jugadorService;


        public JugadorController(IJugadorService _service)
        {
            jugadorService = _service;
        }
        // GET: api/<PersonaController>
        [HttpGet]
        public List<Jugador> Get()
        {
            return jugadorService.GetAllJugadores();
        }
    }
}
