using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbConsultoriaModel.dbConsultoria;

[Table("PagoClienteProyecto")]
public partial class PagoClienteProyecto
{
    [Key]
    public int IdPago { get; set; }

    public int IdProyecto { get; set; }

    public int IdCliente { get; set; }

    public int IdEmpleadoRegistro { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string TipoPago { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string BancoPago { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string NroOperacion { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? Monto { get; set; }

    public bool? Estado { get; set; }

    [Column(TypeName = "date")]
    public DateTime FechaPago { get; set; }

    [ForeignKey("IdCliente")]
    [InverseProperty("PagoClienteProyectos")]
    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    [ForeignKey("IdEmpleadoRegistro")]
    [InverseProperty("PagoClienteProyectos")]
    public virtual Empleado IdEmpleadoRegistroNavigation { get; set; } = null!;

    [ForeignKey("IdProyecto")]
    [InverseProperty("PagoClienteProyectos")]
    public virtual Proyecto IdProyectoNavigation { get; set; } = null!;
}
