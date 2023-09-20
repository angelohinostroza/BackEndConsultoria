using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbConsultoriaModel.dbConsultoria;

namespace IRepository
{
    public interface IRolRepository : ICRUDRepository<Rol>
    {
       public List<Rol> ObtenerRol(int idRol);

    }
}
