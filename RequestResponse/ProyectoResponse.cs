using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class ProyectoResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public int? IdUbigeo { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaTermino { get; set; }
        public int IdCliente { get; set; }
        public bool? Estado { get; set; }
        public int IdEmpleadoRegistro { get; set; }


        // public virtual ICollection<Contratistum> Contratista { get; set; } = new List<Contratistum>();

        //public virtual ICollection<Cotizacion> Cotizacions { get; set; } = new List<Cotizacion>();

        //public virtual Cliente IdClienteNavigation { get; set; } = null!;

        //public virtual Empleado IdEmpleadoRegistroNavigation { get; set; } = null!;

        //public virtual Ubigeo? IdUbigeoNavigation { get; set; }

        //public virtual ICollection<PagoClienteProyecto> PagoClienteProyectos { get; set; } = new List<PagoClienteProyecto>()
    }
}
