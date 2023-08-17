using Microsoft.EntityFrameworkCore;
using PrimeraAPI.Entities;

namespace PrimeraAPI.DataAccess
{
    public class ApiDbContext : DbContext
    {
        public virtual DbSet<Jugador> Jugadores { get; set; }
        public virtual DbSet<Club> Clubes { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.SeedJugadores(modelBuilder);
            this.SeedClub(modelBuilder);
        }

        private void SeedClub(ModelBuilder builder)
        {
            builder.Entity<Club>().HasData(
                new Club()
                {
                    Id = 1,
                    Name = "Boca Juniors"
                });
        }

        private void SeedJugadores(ModelBuilder builder)
        {
            builder.Entity<Jugador>().HasData(
                new Jugador()
                {
                    Id = 1,
                    Name = "Pablo",
                    Club_id = 1
                },
                new Jugador()
                {
                    Id = 2,
                    Name = "Lucas",
                    Club_id = 1
                },
                new Jugador()
                {
                    Id = 3,
                    Name = "Emmanuel"
                });
        }
    }
}
