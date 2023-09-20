using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class UsuarioLoginResponse
    {
        public int IdUsuario { get; set; }
        public int IdEmpleado { get; set; }
        public string NombreUsuario { get; set; } = ""!;
        public string Email { get; set; } = "";
        public int IdRol { get; set; }


    }
}
