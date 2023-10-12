using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbConsultoriaModel.dbConsultoria;

[Table("DetalleCotizacion")]
public partial class DetalleCotizacion
{
    [Key]
    public int Id { get; set; }

    public int IdCotizacion { get; set; }

    [Column(TypeName = "text")]
    public string? Descripcion { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Cantidad { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Monto { get; set; }

    [ForeignKey("IdCotizacion")]
    [InverseProperty("DetalleCotizacions")]
    public virtual Cotizacion IdCotizacionNavigation { get; set; } = null!;
}
