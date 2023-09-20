using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class ErrorResponse
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public string? Controller { get; set; }
        public string? Ip { get; set; }
        public string? Method { get; set; }
        public string? UserAgent { get; set; }
        public string? Host { get; set; }
        public string? ClassComponent { get; set; }
        public string? FunctionName { get; set; }
        public int LineNumber { get; set; }
        public string? Error1 { get; set; }
        public string? StackTrace { get; set; }
        public short Status { get; set; }
        public string? Request { get; set; }
        public int ErrorCode { get; set; }
        public string NombreEmpleado { get; set; } = null!;

        public int IdUsuarioCrea { get; set; }
        public DateTime? FechaCreacion { get; set; }

        //[ForeignKey("IdEmpleado")]
        //[InverseProperty("Errors")]
        //public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
    }
}
