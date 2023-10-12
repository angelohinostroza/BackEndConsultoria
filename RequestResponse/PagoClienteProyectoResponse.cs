using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class PagoClienteProyectoResponse
    {
        public int Id { get; set; }
        public int IdProyecto { get; set; }
        public int IdCliente { get; set; }
        public int IdEmpleadoRegistro { get; set; }
        public string TipoPago { get; set; } = null!;
        public string BancoPago { get; set; } = null!;
        public string NroOperacion { get; set; } = null!;
        public string? Monto { get; set; }
        public bool? Estado { get; set; }
        public DateTime FechaPago { get; set; }


        //public virtual Cliente IdClienteNavigation { get; set; } = null!;
        //public virtual Empleado IdEmpleadoRegistroNavigation { get; set; } = null!;
        //public virtual Proyecto IdProyectoNavigation { get; set; } = null!;
    }
}
