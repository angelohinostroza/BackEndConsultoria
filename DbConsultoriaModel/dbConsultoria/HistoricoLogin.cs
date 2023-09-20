using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbConsultoriaModel.dbConsultoria;

[Table("HistoricoLogin")]
public partial class HistoricoLogin
{
    [Key]
    public int IdLogin { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaLogin { get; set; }

    public int IdUsuario { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("HistoricoLogins")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
