using System;
using System.Collections.Generic;

namespace Carniceria_Api.Models;

public partial class Venta
{
    public int Id { get; set; }

    public int CobradorId { get; set; }

    public int ClienteId { get; set; }

    public int ProductosId { get; set; }

    public DateTime Fecha { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Cobrador Cobrador { get; set; } = null!;

    public virtual Producto Productos { get; set; } = null!;
}
