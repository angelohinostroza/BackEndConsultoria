using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbConsultoriaModel.dbConsultoria;

[Keyless]
public partial class VcontratistaUbigeo
{
    public int IdContratista { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string RazonSocial { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string NroRuc { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Direccion { get; set; } = null!;

    public int? IdUbigeo { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Ubicacion { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Contacto { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string? TelefonoContacto { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string Telefono { get; set; } = null!;

    public bool? Estado { get; set; }

    public int IdProyecto { get; set; }

    public int IdEmpleadoRegistro { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaCreacion { get; set; }

    public int? IdEmpleadoModifica { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaModificado { get; set; }
}
