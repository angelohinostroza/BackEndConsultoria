using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbConsultoriaModel.dbConsultoria;

[Table("Empleado")]
public partial class Empleado
{
    [Key]
    public int IdEmpleado { get; set; }

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

    [StringLength(20)]
    [Unicode(false)]
    public string Cargo { get; set; } = null!;

    public bool? Estado { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaCreacion { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaModificado { get; set; }

    [InverseProperty("IdEmpleadoRegistroNavigation")]
    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    [InverseProperty("IdEmpleadoRegistroNavigation")]
    public virtual ICollection<Consultor> Consultors { get; set; } = new List<Consultor>();

    [InverseProperty("IdEmpleadoRegistroNavigation")]
    public virtual ICollection<Contratistum> Contratista { get; set; } = new List<Contratistum>();

    [InverseProperty("IdEmpleadoRegistroNavigation")]
    public virtual ICollection<Cotizacion> Cotizacions { get; set; } = new List<Cotizacion>();

    [ForeignKey("IdUbigeo")]
    [InverseProperty("Empleados")]
    public virtual Ubigeo? IdUbigeoNavigation { get; set; }

    [InverseProperty("IdEmpleadoRegistroNavigation")]
    public virtual ICollection<PagoClienteProyecto> PagoClienteProyectos { get; set; } = new List<PagoClienteProyecto>();

    [InverseProperty("IdEmpleadoRegistroNavigation")]
    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();

    [InverseProperty("IdEmpleadoNavigation")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
