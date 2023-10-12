using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace RequestResponse
{
    public class ConsultorRequest
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; } = null!;
        public string NroDocumento { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public int? IdUbigeo { get; set; }
        public string Email { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public bool? Estado { get; set; }
        public int IdEmpleadoRegistro { get; set; }
        [JsonIgnore]
        public DateTime? FechaCreacion { get; set; } = DateTime.Now;
        [JsonIgnore]
        public DateTime? FechaModificado { get; set; } = DateTime.Now;


        //public virtual Empleado IdEmpleadoRegistroNavigation { get; set; } = null!;

        //public virtual Ubigeo? IdUbigeoNavigation { get; set; }

        //public virtual ICollection<VisitaConsultor> VisitaConsultors { get; set; } = new List<VisitaConsultor>()
    }
}
