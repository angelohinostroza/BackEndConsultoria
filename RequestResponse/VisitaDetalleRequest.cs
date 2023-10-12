using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class VisitaDetalleRequest
    {
        public int Id { get; set; }
        public int IdVisitaConsultor { get; set; }
        public string? Detalles { get; set; }

        
        //public virtual VisitaConsultor IdVisitaConsultorNavigation { get; set; } = null!;
    }
}
