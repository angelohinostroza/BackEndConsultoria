using DbConsultoriaModel.dbConsultoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IUsuarioRepository : ICRUDRepository<Usuario>
    {
        public List<Usuario> ObtenerUsuario(int idUsuario);

        VistaUsuarioRol BuscarPorNombreUsuario(string  NombreUsuario);
    }
    
}
