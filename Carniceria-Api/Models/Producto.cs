using System;
using System.Collections.Generic;

namespace Carniceria_Api.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Monto { get; set; }

    public virtual ICollection<Venta> Ventas { get; } = new List<Venta>();
}
