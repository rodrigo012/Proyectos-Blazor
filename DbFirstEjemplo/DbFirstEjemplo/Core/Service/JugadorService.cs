using DbFirstEjemplo.DataAccess;
using DbFirstEjemplo.Entities;
using Microsoft.EntityFrameworkCore;

namespace DbFirstEjemplo.Core.Service
{
    public class JugadorService : IJugadorService
    {
        private PrimeraApiContext context;

        public JugadorService(PrimeraApiContext _context)
        {
            context = _context;
        }

        public List<Jugador> GetAllJugadores()
        {
            List<Jugador> jugadorList = new List<Jugador>();

            jugadorList = context.Jugadors.Include(j => j.Club).ToList();

            return jugadorList;
        }
    }
}
