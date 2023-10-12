using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbConsultoriaModel.dbConsultoria;

[Table("Cotizacion")]
public partial class Cotizacion
{
    [Key]
    public int Id { get; set; }

    public int IdProyecto { get; set; }

    [Column(TypeName = "date")]
    public DateTime FechaCotizacion { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string MontoEstimado { get; set; } = null!;

    public bool? Estado { get; set; }

    public int IdEmpleadoRegistro { get; set; }

    [InverseProperty("IdCotizacionNavigation")]
    public virtual ICollection<DetalleCotizacion> DetalleCotizacions { get; set; } = new List<DetalleCotizacion>();

    [ForeignKey("IdEmpleadoRegistro")]
    [InverseProperty("Cotizacions")]
    public virtual Empleado IdEmpleadoRegistroNavigation { get; set; } = null!;

    [ForeignKey("IdProyecto")]
    [InverseProperty("Cotizacions")]
    public virtual Proyecto IdProyectoNavigation { get; set; } = null!;
}
