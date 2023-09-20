using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class ErrorRequest
    {
        public int Id { get; set; }

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
        public string? ClassComponent { get; set; }

        [StringLength(100)]
        public string? FunctionName { get; set; }

        public int LineNumber { get; set; }

        public string? Error1 { get; set; }

        public string? StackTrace { get; set; }

        public short Status { get; set; }

        public string? Request { get; set; }

        public int ErrorCode { get; set; }

        [StringLength(50)]
        public string NombreEmpleado { get; set; } = null!;


        public int IdUsuarioCrea { get; set; }

        public DateTime? FechaCreacion { get; set; }

        //[ForeignKey("IdEmpleado")]
        //[InverseProperty("Errors")]
        //public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

        //[ForeignKey("IdUsuarioCrea")]
        //[InverseProperty("Errors")]
        //public virtual Usuario IdUsuarioCreaNavigation { get; set; } = null!;
    }
}
