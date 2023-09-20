using DbConsultoriaModel.dbConsultoria;
using IRepository;
using RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CotizacionRepository : CRUDRepository<Cotizacion>, ICotizacionRepository
    {
        public GenericFilterResponse<Cotizacion> GetByFilter(GenericFilterRequest filters)
        {
            throw new NotImplementedException();
        }

        public List<Cotizacion> ObtenerCotizacion(int idCotizacion)
        {
            throw new NotImplementedException();
        }
    }
   
}
