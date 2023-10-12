using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class UbigeoRequest
    {
        public int Id { get; set; }
        public string Ubigeo1 { get; set; } = null!;
        public string Distrito { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Departamento { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;
    }
}
