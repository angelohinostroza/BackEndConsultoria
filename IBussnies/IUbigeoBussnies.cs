using DbConsultoriaModel.dbConsultoria;
using RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBussnies
{
    public interface IUbigeoBussnies : ICRUDBussnies<UbigeoRequest, UbigeoResponse>
    {
        List<UbigeoResponse> getByContains(string texto);
    }
}
