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
    public class RolRepository : CRUDRepository<Rol>, IRolRepository
    {
        public GenericFilterResponse<Rol> GetByFilter(GenericFilterRequest filters)
        {
            throw new NotImplementedException();
        }

        public List<Rol> ObtenerRol(int idRol)
        {
            throw new NotImplementedException();
        }
    }
}
