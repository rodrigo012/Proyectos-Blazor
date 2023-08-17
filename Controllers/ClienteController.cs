using Microsoft.AspNetCore.Mvc;
using PrimeraAPI.Core.Models;


/*
 * 
 * ClienteController : Representar todos los verbos HTTP que pueden gestionarse en un API.
 * 
 * Todos los metodos retornan un objeto de tipo dynamic, con el objetivo de retornar contenido distinto a ejemplos anteriores.
 * 
 */

namespace PrimeraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        static List<Cliente> clientes = new List<Cliente>()
            {
                new Cliente
                {
                    Id = 100,
                    Nombre = "Alberto Jimenez",
                    CorreoElectronico = "alberto@jimenez.com",
                    NumeroMovil = "04530188292"
                },
                new Cliente
                {
                    Id = 200,
                    Nombre = "Veronica Rodriguez",
                    CorreoElectronico = "vero@rodriguez.com",
                    NumeroMovil = "08774188292"
                },
            };



        // GET: api/<ClienteController>
        [HttpGet]
        public dynamic Get()
        {
            //List<Cliente> clientes = new List<Cliente>
            //{
            //    new Cliente
            //    {
            //        Id = 100,
            //        Nombre = "Alberto Jimenez",
            //        CorreoElectronico = "alberto@jimenez.com",
            //        NumeroMovil = "04530188292"
            //    },
            //    new Cliente
            //    {
            //        Id = 200,
            //        Nombre = "Veronica Rodriguez",
            //        CorreoElectronico = "vero@rodriguez.com",
            //        NumeroMovil = "08774188292"
            //    },
            //};

            return clientes;
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            return new Cliente
            {
                Id = id,
                Nombre = "Marc Gonzalez",
                CorreoElectronico = "marc@correo.com",
                NumeroMovil = "8327483748"
            };
        }

        // POST api/<ClienteController>
        [HttpPost]
        public dynamic Post([FromBody] Cliente cliente)
        {

            cliente.Id = new Random().Next(300, 900);                     
                        
            clientes.Add(cliente);

            return new
            {
                success = true,
                message = "El Cliente ha sido registrado satisfactoriamente.",
                result = cliente
            };


        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public dynamic Put(int id, [FromBody] Cliente cliente)
        {

            // Aqui debemos implementar la logica y reglas del negocio.

            return new
            {
                success = true,
                message = "El Cliente ha sido actualizado satisfactoriamente.",
                result = cliente
            };

        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public dynamic Delete(int id)
        {

            // Aqui debemos implementar la logica y reglas del negocio.

            return new
            {
                success = true,
                message = "El Cliente ha sido eliminado satisfactoriamente.",
                result = ""
            };

        }
    }
}
