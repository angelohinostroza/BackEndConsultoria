using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class LoginRequest
    {
        [Required]
        [StringLength(20)]
        public string NombreUsuario { get; set; } = "";
        [Required]
        [StringLength(20,MinimumLength = 5)]
        public string Password { get; set; } = "";
    }
}
