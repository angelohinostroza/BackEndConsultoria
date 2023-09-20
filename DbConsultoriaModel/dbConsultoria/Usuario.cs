using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbConsultoriaModel.dbConsultoria;

[Table("Usuario")]
public partial class Usuario
{
    [Key]
    public int IdUsuario { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string NombreUsuario { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    public int IdRol { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaCreacion { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaModificado { get; set; }

    public int IdEmpleado { get; set; }

    public bool? Estado { get; set; }

    [InverseProperty("IdUsuarioCreaNavigation")]
    public virtual ICollection<Error> Errors { get; set; } = new List<Error>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<HistoricoLogin> HistoricoLogins { get; set; } = new List<HistoricoLogin>();

    [ForeignKey("IdEmpleado")]
    [InverseProperty("Usuarios")]
    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    [ForeignKey("IdRol")]
    [InverseProperty("Usuarios")]
    public virtual Rol IdRolNavigation { get; set; } = null!;
}
