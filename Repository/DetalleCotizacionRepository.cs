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
    public class DetalleCotizacionRepository : CRUDRepository<DetalleCotizacion>, IDetalleCotizacionRepository
    {
        public GenericFilterResponse<DetalleCotizacion> GetByFilter(GenericFilterRequest filters)
        {
            throw new NotImplementedException();
        }

        public List<DetalleCotizacion> ObtenerDetalleCotizacion(int idDetalleCotizacion)
        {
            throw new NotImplementedException();
        }
    }
    
}
