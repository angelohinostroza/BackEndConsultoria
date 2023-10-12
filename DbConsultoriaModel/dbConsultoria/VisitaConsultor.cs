using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbConsultoriaModel.dbConsultoria;

[Table("VisitaConsultor")]
public partial class VisitaConsultor
{
    [Key]
    public int Id { get; set; }

    public int IdConsultor { get; set; }

    public int IdCliente { get; set; }

    [Column(TypeName = "date")]
    public DateTime FechaVisita { get; set; }

    [ForeignKey("IdCliente")]
    [InverseProperty("VisitaConsultors")]
    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    [ForeignKey("IdConsultor")]
    [InverseProperty("VisitaConsultors")]
    public virtual Consultor IdConsultorNavigation { get; set; } = null!;

    [InverseProperty("IdVisitaConsultorNavigation")]
    public virtual ICollection<VisitaDetalle> VisitaDetalles { get; set; } = new List<VisitaDetalle>();
}
