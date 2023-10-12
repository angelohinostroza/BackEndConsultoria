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
    public class ClienteRequest
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; } = null!;
        public string NroDocumento { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public int? IdUbigeo { get; set; }
        public string Estado { get; set; } = null!;
        [JsonIgnore]
        public int IdEmpleadoCrea { get; set; } = 0;
        [JsonIgnore]
        public DateTime? FechaCreacion { get; set; } = DateTime.Now;
        [JsonIgnore]
        public int IdEmpleadoModifica { get; set; } = 0;
        [JsonIgnore]
        public DateTime? FechaModificado { get; set; } = DateTime.Now;


        //public virtual EmpleadoResponse? IdEmpleadoRegistroNavigation { get; set; } = null!;
        public virtual UbigeoResponse? IdUbigeoNavigation { get; set; }
        //public virtual ICollection<PagoClienteProyecto> PagoClienteProyectos { get; set; } = new List<PagoClienteProyecto>();
        //public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
        //public virtual ICollection<VisitaConsultor> VisitaConsultors { get; set; } = new List<VisitaConsultor>();
    }
}
