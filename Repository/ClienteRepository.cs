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
    public class ClienteRepository : CRUDRepository<Cliente>, IClienteRepository
    {
        public GenericFilterResponse<Cliente> GetByFilter(GenericFilterRequest filters)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ObtenerCliente(int idCliente)
        {
            throw new NotImplementedException();
        }
    }
    
}
