using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbConsultoriaModel.dbConsultoria;

[Keyless]
public partial class VempleadoUbigeo
{
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

    [StringLength(100)]
    [Unicode(false)]
    public string Ubicacion { get; set; } = null!;

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
}
