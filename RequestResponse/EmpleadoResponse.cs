using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class EmpleadoResponse
    {
        public int IdEmpleado { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public int? IdUbigeo { get; set; }
        public string Email { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Cargo { get; set; } = null!;
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificado { get; set; }


        //public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
        //public virtual ICollection<Consultor> Consultors { get; set; } = new List<Consultor>();
        //public virtual ICollection<Contratistum> Contratista { get; set; } = new List<Contratistum>();
        //public virtual ICollection<Cotizacion> Cotizacions { get; set; } = new List<Cotizacion>();
        //public virtual Ubigeo? IdUbigeoNavigation { get; set; }
        //public virtual ICollection<PagoClienteProyecto> PagoClienteProyectos { get; set; } = new List<PagoClienteProyecto>()
        //public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
        //public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
