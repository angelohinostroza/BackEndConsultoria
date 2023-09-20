using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class UsuarioResponse
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int IdRol { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificado { get; set; }
        public int IdEmpleado { get; set; }
        public bool? Estado { get; set; }


        //public virtual ICollection<HistoricoLogin> HistoricoLogins { get; set; } = new List<HistoricoLogin>();
        //public virtual Empleado IdEmpleadoRegistroNavigation { get; set; } = null!;
        //public virtual Rol IdRolNavigation { get; set; } = null!;
    }
}
