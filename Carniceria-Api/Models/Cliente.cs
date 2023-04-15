using System;
using System.Collections.Generic;

namespace Carniceria_Api.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string ApellidoNombre { get; set; } = null!;

    public string Dirección { get; set; } = null!;

    public string Teléfono { get; set; } = null!;

    public virtual ICollection<Venta> Ventas { get; } = new List<Venta>();
}
