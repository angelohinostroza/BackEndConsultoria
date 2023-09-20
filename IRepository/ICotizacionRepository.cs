using DbConsultoriaModel.dbConsultoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface ICotizacionRepository : ICRUDRepository<Cotizacion>
    {
        public List<Cotizacion> ObtenerCotizacion(int idCotizacion);

    }
    
}
