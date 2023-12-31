﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbConsultoriaModel.dbConsultoria;

[Keyless]
public partial class VistaUsuarioRol
{
    public int Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string NombreUsuario { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    public bool? Estado { get; set; }

    public int IdRol { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? NombreRol { get; set; }

    public int IdEmpleado { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Nombres { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; } = null!;
}
