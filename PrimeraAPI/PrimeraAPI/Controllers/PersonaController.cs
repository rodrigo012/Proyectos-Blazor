using Microsoft.AspNetCore.Mvc;
using PrimeraAPI.Core.Models;


/*
 * 
 * PersonaController : Representar los verbos HTTP Get, Get(id), Post
 * 
 */

namespace PrimeraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        List<Persona> listaPersonas;

        // GET: api/<PersonaController>
        [HttpGet]
        public List<Persona> Get()
        {

            Persona persona = new Persona();
            listaPersonas = persona.GetPersonas();

            return listaPersonas;

        }

        // GET api/<PersonaController>/5
        [HttpGet("{id}")]
        public Persona Get(int id)
        {

            Persona persona = new Persona();

            return persona.GetPersona(id);

        }

        // POST api/<PersonaController> 
        [HttpPost] 
        public Persona Post([FromBody] Persona persona)
        {
            Persona persona2 = new Persona();
            listaPersonas = persona2.GetPersonas();

            listaPersonas.Add(persona);
            return persona;
        }

    }

}
