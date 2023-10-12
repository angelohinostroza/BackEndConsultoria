using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class ContratistumRequest
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; } = null!;
        public string NroRuc { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public int? IdUbigeo { get; set; }
        public string Contacto { get; set; } = null!;
        public string? TelefonoContacto { get; set; }
        public string Email { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificado { get; set; }
        public int IdProyecto { get; set; }
        public int IdEmpleadoRegistro { get; set; }
       
        
        //public virtual Empleado IdEmpleadoRegistroNavigation { get; set; } = null!;
        //public virtual Proyecto IdProyectoNavigation { get; set; } = null!;
        //public virtual Ubigeo? IdUbigeoNavigation { get; set; 
    }
}
