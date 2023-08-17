namespace TokenAPI.Models
{
    public class Usuario
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }


        public static List<Usuario> GetUsuarios()
        {

            var lista = new List<Usuario>()
            {
                new Usuario() { Id = "1", Nombre = "carlos", Password = "clave123", Rol = "admin" },
                new Usuario() { Id = "2", Nombre = "alberto", Password = "clave123", Rol = "usuario" },
                new Usuario() { Id = "3", Nombre = "alison", Password = "clave123", Rol = "usuario" },
            };

            return lista;

        }

    }
}
