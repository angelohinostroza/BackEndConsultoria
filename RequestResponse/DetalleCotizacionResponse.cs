using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class DetalleCotizacionResponse
    {
        public int IidDetalleCotizacion { get; set; }
        public int IdCotizacion { get; set; }
        public string? Descripcion { get; set; }
        public string? Cantidad { get; set; }
        public string? Monto { get; set; }

        //public virtual Cotizacion IdCotizacionNavigation { get; set; } = null!;
    }
}
