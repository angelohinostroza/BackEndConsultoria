using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbConsultoriaModel.dbConsultoria;

[Table("Proyecto")]
public partial class Proyecto
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Direccion { get; set; } = null!;

    public int? IdUbigeo { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaInicio { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaTermino { get; set; }

    public int IdCliente { get; set; }

    public bool? Estado { get; set; }

    public int IdEmpleadoRegistro { get; set; }

    [InverseProperty("IdProyectoNavigation")]
    public virtual ICollection<Contratistum> Contratista { get; set; } = new List<Contratistum>();

    [InverseProperty("IdProyectoNavigation")]
    public virtual ICollection<Cotizacion> Cotizacions { get; set; } = new List<Cotizacion>();

    [ForeignKey("IdCliente")]
    [InverseProperty("Proyectos")]
    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    [ForeignKey("IdEmpleadoRegistro")]
    [InverseProperty("Proyectos")]
    public virtual Empleado IdEmpleadoRegistroNavigation { get; set; } = null!;

    [ForeignKey("IdUbigeo")]
    [InverseProperty("Proyectos")]
    public virtual Ubigeo? IdUbigeoNavigation { get; set; }

    [InverseProperty("IdProyectoNavigation")]
    public virtual ICollection<PagoClienteProyecto> PagoClienteProyectos { get; set; } = new List<PagoClienteProyecto>();
}
