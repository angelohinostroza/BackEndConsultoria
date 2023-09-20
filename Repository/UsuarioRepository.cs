using DbConsultoriaModel.dbConsultoria;
using IRepository;
using Microsoft.EntityFrameworkCore;
using RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UsuarioRepository : CRUDRepository<Usuario>, IUsuarioRepository
    {
        public VistaUsuarioRol BuscarPorNombreUsuario(string NombreUsuario)
        {

            VistaUsuarioRol vistaUsuario = db.VistaUsuarioRols.Where(x => x.NombreUsuario.ToLower() == NombreUsuario.ToLower()).FirstOrDefault();

            return vistaUsuario ;
        }

        public GenericFilterResponse<Usuario> GetByFilter(GenericFilterRequest filters)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ObtenerUsuario(int IdUsuario)
        {
            throw new NotImplementedException();
        }

       
    }
    
}
