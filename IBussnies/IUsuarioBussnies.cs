using DbConsultoriaModel.dbConsultoria;
using RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBussnies
{
    public interface IUsuarioBussnies : ICRUDBussnies<UsuarioRequest, UsuarioResponse>
    {
        VistaUsuarioRol ObtenerUsuarioByUsername(string Nombreusuario);
    }
}
