using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Carniceria_Api.Models;

public partial class Venta
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El campo Cobrador es requerido.")]
    public int CobradorId { get; set; }
    [Required(ErrorMessage = "El campo Cliente es requerido.")]
    public int ClienteId { get; set; }
    [Required(ErrorMessage = "El campo Productos es requerido.")]
    public int ProductosId { get; set; }
    public DateTime Fecha { get; set; }
    public virtual Producto? Producto { get; set; } = null!;
    public virtual Cliente? Cliente { get; set; } = null!;
    public virtual Cobrador? Cobrador { get; set; } = null!;
}
