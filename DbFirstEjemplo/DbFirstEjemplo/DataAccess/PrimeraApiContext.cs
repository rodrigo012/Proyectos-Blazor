using System;
using System.Collections.Generic;
using DbFirstEjemplo.Entities;
using Microsoft.EntityFrameworkCore;

namespace DbFirstEjemplo.DataAccess;

public partial class PrimeraApiContext : DbContext
{
    public PrimeraApiContext()
    {
    }

    public PrimeraApiContext(DbContextOptions<PrimeraApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clube> Clubes { get; set; }

    public virtual DbSet<Jugador> Jugadors { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Jugador>(entity =>
        {
            entity.ToTable("Jugador");

            entity.HasIndex(e => e.ClubId, "IX_Jugador_Club_id");

            entity.Property(e => e.ClubId).HasColumnName("Club_id");
            entity.Property(e => e.Name).HasMaxLength(50);
            
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
