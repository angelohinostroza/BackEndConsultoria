using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbConsultoriaModel.dbConsultoria;

[Table("VisitaDetalle")]
public partial class VisitaDetalle
{
    [Key]
    public int IdVisitaDetalle { get; set; }

    public int IdVisitaConsultor { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Detalles { get; set; }

    [ForeignKey("IdVisitaConsultor")]
    [InverseProperty("VisitaDetalles")]
    public virtual VisitaConsultor IdVisitaConsultorNavigation { get; set; } = null!;
}
