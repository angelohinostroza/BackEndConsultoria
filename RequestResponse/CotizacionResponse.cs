using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class CotizacionResponse
    {
        public int IdCotizacion { get; set; }
        public int IdProyecto { get; set; }
        public DateTime FechaCotizacion { get; set; }
        public string MontoEstimado { get; set; } = null!;
        public bool? Estado { get; set; }
        public int IdEmpleadoRegistro { get; set; }


        // public virtual ICollection<DetalleCotizacion> DetalleCotizacions { get; set; } = new List<DetalleCotizacion>();
        //public virtual Empleado IdEmpleadoRegistroNavigation { get; set; } = null!;
        //public virtual Proyecto IdProyectoNavigation { get; set; } = null
    }
}
