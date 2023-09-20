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
    public class ContratistumRepository : CRUDRepository<Contratistum>, IContratistumRepository
    {
        public GenericFilterResponse<Contratistum> GetByFilter(GenericFilterRequest filters)
        {
            throw new NotImplementedException();
        }

        public List<Contratistum> ObtenerContratistum(int idContratistum)
        {
            throw new NotImplementedException();
        }
    }
    
}
