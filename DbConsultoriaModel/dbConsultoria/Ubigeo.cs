using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbConsultoriaModel.dbConsultoria;

[Table("Ubigeo")]
public partial class Ubigeo
{
    [Key]
    public int IdUbigeo { get; set; }

    [Column("Ubigeo")]
    [StringLength(50)]
    [Unicode(false)]
    public string Ubigeo1 { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Distrito { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Provincia { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Departamento { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Ubicacion { get; set; } = null!;

    [InverseProperty("IdUbigeoNavigation")]
    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    [InverseProperty("IdUbigeoNavigation")]
    public virtual ICollection<Consultor> Consultors { get; set; } = new List<Consultor>();

    [InverseProperty("IdUbigeoNavigation")]
    public virtual ICollection<Contratistum> Contratista { get; set; } = new List<Contratistum>();

    [InverseProperty("IdUbigeoNavigation")]
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    [InverseProperty("IdUbigeoNavigation")]
    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
}
