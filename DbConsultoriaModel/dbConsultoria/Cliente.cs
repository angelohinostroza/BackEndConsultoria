using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbConsultoriaModel.dbConsultoria;

[Table("Cliente")]
public partial class Cliente
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string TipoDocumento { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string NroDocumento { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Nombres { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Apellidos { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string Telefono { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Direccion { get; set; } = null!;

    public int? IdUbigeo { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string? Estado { get; set; }

    public int? IdEmpleadoCrea { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaCreacion { get; set; }

    public int? IdEmpleadoModifica { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaModificado { get; set; }

    [ForeignKey("IdEmpleadoCrea")]
    [InverseProperty("Clientes")]
    public virtual Empleado? IdEmpleadoCreaNavigation { get; set; }

    [ForeignKey("IdUbigeo")]
    [InverseProperty("Clientes")]
    public virtual Ubigeo? IdUbigeoNavigation { get; set; }

    [InverseProperty("IdClienteNavigation")]
    public virtual ICollection<PagoClienteProyecto> PagoClienteProyectos { get; set; } = new List<PagoClienteProyecto>();

    [InverseProperty("IdClienteNavigation")]
    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();

    [InverseProperty("IdClienteNavigation")]
    public virtual ICollection<VisitaConsultor> VisitaConsultors { get; set; } = new List<VisitaConsultor>();
}
