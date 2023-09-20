using DbConsultoriaModel.dbConsultoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IConsultorRepository : ICRUDRepository<Consultor>
    {
        public List<Consultor> ObtenerConsultor(int idConsultor);

    }
    
}
