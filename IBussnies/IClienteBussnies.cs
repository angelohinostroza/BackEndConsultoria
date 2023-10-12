using DbConsultoriaModel.dbConsultoria;
using RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBussnies
{
    public interface IClienteBussnies: ICRUDBussnies<ClienteRequest, ClienteResponse>
    {
        List<VclienteUbigeo> ObtenerCliente();

    }
}
