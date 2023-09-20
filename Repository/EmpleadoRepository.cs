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
    public class EmpleadoRepository : CRUDRepository<Empleado>, IEmpleadoRepository
    {
        public GenericFilterResponse<Empleado> GetByFilter(GenericFilterRequest filters)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ObtenerEmpleado(int idEmpleado)
        {
            throw new NotImplementedException();
        }
    }
}
