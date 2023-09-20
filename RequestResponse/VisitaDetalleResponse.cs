using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class VisitaDetalleResponse
    {
        public int IdVisitaDetalle { get; set; }
        public int IdVisitaConsultor { get; set; }
        public string? Detalles { get; set; }


        //public virtual VisitaConsultor IdVisitaConsultorNavigation { get; set; } = null!;
    }
}
