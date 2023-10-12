using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class RolRequest
    {  
        public int Id { get; set; }
        public string? NombreRol { get; set; }
        public bool? Estado { get; set; }


        //public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
