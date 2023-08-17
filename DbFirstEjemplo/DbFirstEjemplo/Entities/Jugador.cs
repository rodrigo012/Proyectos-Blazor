using System;
using System.Collections.Generic;

namespace DbFirstEjemplo.Entities;

public partial class Jugador
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int ClubId { get; set; }

    public virtual Clube Club { get; set; } = null!;
}
