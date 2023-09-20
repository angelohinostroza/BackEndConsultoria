using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbConsultoriaModel.dbConsultoria;

[Table("Consultor")]
public partial class Consultor
{
    [Key]
    public int IdConsultor { get; set; }

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

    [StringLength(255)]
    [Unicode(false)]
    public string Direccion { get; set; } = null!;

    public int? IdUbigeo { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string Telefono { get; set; } = null!;

    public bool? Estado { get; set; }

    public int IdEmpleadoRegistro { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaCreacion { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaModificado { get; set; }

    [ForeignKey("IdEmpleadoRegistro")]
    [InverseProperty("Consultors")]
    public virtual Empleado IdEmpleadoRegistroNavigation { get; set; } = null!;

    [ForeignKey("IdUbigeo")]
    [InverseProperty("Consultors")]
    public virtual Ubigeo? IdUbigeoNavigation { get; set; }

    [InverseProperty("IdConsultorNavigation")]
    public virtual ICollection<VisitaConsultor> VisitaConsultors { get; set; } = new List<VisitaConsultor>();
}
