using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class LoginResponse
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = "USUARIO Y/O CONTRASEÑA INCORRECTA";
        public string Token { get; set; } = "";
        public string RefreshToken { get; set; } = "";
        public string NombresEmpleado { get; set; } = "";
        public string NombreRol { get; set; } = "";
        public string Email { get; set; } = "";

        public UsuarioLoginResponse Usuario { get; set; } = new UsuarioLoginResponse();
    }
}
