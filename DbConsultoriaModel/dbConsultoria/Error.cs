using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbConsultoriaModel.dbConsultoria;

[Table("Error")]
public partial class Error
{
    [Key]
    public int Id { get; set; }

    [Unicode(false)]
    public string? Url { get; set; }

    [StringLength(200)]
    public string? Controller { get; set; }

    [StringLength(100)]
    public string? Ip { get; set; }

    [StringLength(20)]
    public string? Method { get; set; }

    [StringLength(150)]
    public string? UserAgent { get; set; }

    public string? Host { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ClassComponent { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? FunctionName { get; set; }

    public int LineNumber { get; set; }

    [Column("Error")]
    public string? Error1 { get; set; }

    public string? StackTrace { get; set; }

    public short Status { get; set; }

    public string? Request { get; set; }

    public int ErrorCode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NombreEmpleado { get; set; } = null!;

    public int IdUsuarioCrea { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaCreacion { get; set; }

    [ForeignKey("IdUsuarioCrea")]
    [InverseProperty("Errors")]
    public virtual Usuario IdUsuarioCreaNavigation { get; set; } = null!;
}
