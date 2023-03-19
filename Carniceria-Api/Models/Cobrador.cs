using System;
using System.Collections.Generic;

namespace Carniceria_Api.Models;

public partial class Cobrador
{
    public int Id { get; set; }

    public string ApellidoNombre { get; set; } = null!;

    public string Dirección { get; set; } = null!;

    public string Teléfono { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int TipoUsuario { get; set; }

    public virtual ICollection<Venta> Venta { get; } = new List<Venta>();
}
