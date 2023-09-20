using DbConsultoriaModel.dbConsultoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IDetalleCotizacionRepository : ICRUDRepository<DetalleCotizacion>
    {
        public List<DetalleCotizacion> ObtenerDetalleCotizacion(int idDetalleCotizacion);

    }
   
}
