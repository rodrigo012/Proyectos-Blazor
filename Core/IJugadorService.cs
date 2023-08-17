using PrimeraAPI.Entities;

namespace PrimeraAPI.Core
{
    public interface IJugadorService
    {
        Task<List<Jugador>> GetAllJugadores();
        Jugador GetJugador(int id); 
    }
}
