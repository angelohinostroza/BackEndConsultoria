using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class VisitaConsultorResponse
    {
        public int IdVisitaConsultor { get; set; }
        public int IdConsultor { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaVisita { get; set; }


        //public virtual Cliente IdClienteNavigation { get; set; } = null!;
        //public virtual Consultor IdConsultorNavigation { get; set; } = null!;
        //public virtual ICollection<VisitaDetalle> VisitaDetalles { get; set; } = new List<VisitaDetalle>()
    }
}
