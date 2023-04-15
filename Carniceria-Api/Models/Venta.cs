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
}
