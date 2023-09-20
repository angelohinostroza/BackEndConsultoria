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
    public class VisitaConsultorRepository : CRUDRepository<VisitaConsultor>, IVisitaConsultorRepository
    {
        public GenericFilterResponse<VisitaConsultor> GetByFilter(GenericFilterRequest filters)
        {
            throw new NotImplementedException();
        }

        public List<VisitaConsultor> ObtenerVisitaConsultor(int idVisitaConsultor)
        {
            throw new NotImplementedException();
        }
    }
    
}
