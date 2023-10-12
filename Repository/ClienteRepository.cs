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
    public class ClienteRepository : CRUDRepository<Cliente>, IClienteRepository
    {
        public GenericFilterResponse<Cliente> GetByFilter(GenericFilterRequest filter)
        {
            GenericFilterResponse<Cliente> res = new GenericFilterResponse<Cliente>();
            List<Cliente> ubigeos = new List<Cliente>();

            //es un algoritmo para construir querys dinamicos
            var query = db.Clientes.Where(x => x.Id == x.Id);

            filter.Filters.ForEach(item =>
            {

                if (!string.IsNullOrEmpty(item.value))
                {
                    switch (item.name)
                    {
                        case "id":
                            query = query.Where(x => x.Id == int.Parse(item.value));
                            break;
                        case "IdUbigeo":
                            //Contains ==> equivalente a like base de datos
                            //.ToLower() ==> convertit a minuscula
                            //.ToUpper() ==> convertit a mayuscula
                            query = query.Where(x => x.IdUbigeo == int.Parse(item.value));
                            break;
                        case "nroDocumento":
                            query = query.Where(x => x.NroDocumento.ToLower()
                            .Contains(item.value.ToLower())
                            );
                            break;

                        case "nombres":
                            query = query.Where(x => x.Nombres.ToLower()
                            .Contains(item.value.ToLower())
                            );
                            break;
                        case "apellidos":
                            query = query.Where(x => x.Apellidos.ToLower()
                            .Contains(item.value.ToLower())
                            );
                            break;

                    }
                }

            });

            res.TotalRecord = query.Count();
            res.List = query

                //.OrderBy(x => x.Nombre) //Ordenamos por nombre de A - Z
                //.OrderByDescending(x => x.Nombre) //Ordenamos por nombre de Z - A
                .Skip((filter.page - 1) * filter.quantity).Take(filter.quantity)
                .ToList();
            return res;
        }

        public List<VclienteUbigeo> ObtenerCliente()
        {
            List<VclienteUbigeo> list = db.VclienteUbigeos.ToList();
            return list;

        }

    }

       
}
