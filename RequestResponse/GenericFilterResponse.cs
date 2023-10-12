using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class GenericFilterResponse <T>
    {
        /// <summary>
        /// TOTAL DE REGISTROS ENCONTRADOS
        /// </summary>
        public int TotalRecord { get; set; }
        /// <summary>
        /// LISTA DE REGISTROS
        /// </summary>
        public List<T> List { get; set; } = new List<T>();
    }
}
