using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbConsultoriaModel.dbConsultoria;

[Keyless]
[Table("ContratistaProyecto")]
public partial class ContratistaProyecto
{
    public int IdContratista { get; set; }

    public int IdProyecto { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Fecha { get; set; }

    [ForeignKey("IdContratista")]
    public virtual Contratistum IdContratistaNavigation { get; set; } = null!;

    [ForeignKey("IdProyecto")]
    public virtual Proyecto IdProyectoNavigation { get; set; } = null!;
}
