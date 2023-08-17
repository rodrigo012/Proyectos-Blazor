namespace PrimeraAPI.Core.Models
{
    /*
     * 
     * Cliente : Representa la estructura del ClienteController.
     * 
     */

    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string NumeroMovil { get; set; }

    }
}
