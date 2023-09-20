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
    public class ConsultorRepository : CRUDRepository<Consultor>, IConsultorRepository
    {
        public GenericFilterResponse<Consultor> GetByFilter(GenericFilterRequest filters)
        {
            throw new NotImplementedException();
        }

        public List<Consultor> ObtenerConsultor(int idConsultor)
        {
            throw new NotImplementedException();
        }
    }
    
}
