using Microsoft.EntityFrameworkCore;
using PrimeraAPI.Core.Models;
using PrimeraAPI.DataAccess;
using PrimeraAPI.Entities;

namespace PrimeraAPI.Core.Service
{
    public class JugadorService : IJugadorService
    {
        private ApiDbContext context;

        public JugadorService(ApiDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Jugador>> GetAllJugadores()
        {
            List<Jugador> jugadorList = new List<Jugador>();

            jugadorList = await context.Jugadores.Include(j => j.club).ToListAsync();
            
            return jugadorList;
        }

        public Jugador GetJugador(int id)
        {
            return context.Jugadores.Include(j => j.club).Where(j => j.Id == id).SingleOrDefault();
        }
    }
}
