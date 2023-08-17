namespace PrimeraAPI.Core.Models
{

    /*
     * 
     * Persona : Representa la estructura de PersonaController.
     * 
     */

    public class Persona
    {

        public int Id { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }

        public List<Persona> GetPersonas()
        {

            List<Persona> personas = new List<Persona>();

            personas.Add(new Persona() { Id = 1, Nombre = "Pedro", Apellido = "Perez" });
            personas.Add(new Persona() { Id = 2, Nombre = "Carlos", Apellido = "Rodriguez" });
            personas.Add(new Persona() { Id = 3, Nombre = "Eduardo", Apellido = "Velazquez" });
            personas.Add(new Persona() { Id = 4, Nombre = "Noel", Apellido = "Gonzalez" });
            personas.Add(new Persona() { Id = 5, Nombre = "Mariela", Apellido = "Silva" });
            personas.Add(new Persona() { Id = 6, Nombre = "Emmanuel", Apellido = "Ranone" });
            personas.Add(new Persona() { Id = 7, Nombre = "Gisela", Apellido = "Perez" });
            personas.Add(new Persona() { Id = 8, Nombre = "Pablo", Apellido = "Loccisano" });

            return personas;

        }

        public Persona GetPersona(int id)
        {
            return GetPersonas().FirstOrDefault(p => p.Id == id);
        }

    }

}
