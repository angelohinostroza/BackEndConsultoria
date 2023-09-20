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
    public class PagoClienteProyectoRepository : CRUDRepository<PagoClienteProyecto>, IPagoClienteProyectoRepository
    {
        public GenericFilterResponse<PagoClienteProyecto> GetByFilter(GenericFilterRequest filters)
        {
            throw new NotImplementedException();
        }

        public List<PagoClienteProyecto> ObtenerPagoClienteProyecto(int idPago)
        {
            throw new NotImplementedException();
        }
    }
    
}
