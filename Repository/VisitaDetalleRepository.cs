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
    public class VisitaDetalleRepository : CRUDRepository<VisitaDetalle>, IVisitaDetalleRepository
    {
        public GenericFilterResponse<VisitaDetalle> GetByFilter(GenericFilterRequest filters)
        {
            throw new NotImplementedException();
        }

        public List<VisitaDetalle> ObtenerVisitaDetalle(int idVisitaDetalle)
        {
            throw new NotImplementedException();
        }
    }
    
}
