using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class ClienteResponse
    {
        public int IdCliente { get; set; }
        public string TipoDocumento { get; set; } = null!;
        public string NroDocumento { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public int? IdUbigeo { get; set; }
        public bool? Estado { get; set; }
        public int IdEmpleadoRegistro { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificado { get; set; }


        //public virtual Empleado IdEmpleadoRegistroNavigation { get; set; } = null!;
        //public virtual Ubigeo? IdUbigeoNavigation { get; set; }
        //public virtual ICollection<PagoClienteProyecto> PagoClienteProyectos { get; set; } = new List<PagoClienteProyecto>();
        //public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
        //public virtual ICollection<VisitaConsultor> VisitaConsultors { get; set; } = new List<VisitaConsultor>();
    }
}
