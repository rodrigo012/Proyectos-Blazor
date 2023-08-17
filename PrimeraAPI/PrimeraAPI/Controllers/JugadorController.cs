using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeraAPI.Core;
using PrimeraAPI.Core.Service;
using PrimeraAPI.Entities;

namespace PrimeraAPI.Controllers
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
        public async Task<List<Jugador>> GetAll()
        {
            return await jugadorService.GetAllJugadores();
        }

        // GET: api/<PersonaController>/id
        [HttpGet("{id}")]
        public Jugador GetById(int id)
        {
            return jugadorService.GetJugador(id);
        }


    }
}
