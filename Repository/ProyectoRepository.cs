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
    public class ProyectoRepository : CRUDRepository<Proyecto>, IProyectoRepository
    {
        public GenericFilterResponse<Proyecto> GetByFilter(GenericFilterRequest filters)
        {
            throw new NotImplementedException();
        }

        public List<Proyecto> ObtenerProyecto(int idProyecto)
        {
            throw new NotImplementedException();
        }
    }
    
}
