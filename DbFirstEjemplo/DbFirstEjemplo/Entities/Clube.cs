using System;
using System.Collections.Generic;

namespace DbFirstEjemplo.Entities;

public partial class Clube
{
    public int Id { get; set; }

    public string? Name { get; set; }

    //public virtual ICollection<Jugador> Jugadors { get; } = new List<Jugador>();
}
