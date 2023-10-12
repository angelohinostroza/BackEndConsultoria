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
    public class UbigeoRepository : CRUDRepository<Ubigeo>, IUbigeoRepository
    {
        public List<Ubigeo> getByContains(string texto)
        {
            List<Ubigeo> list = new List<Ubigeo> ();

            list = dbSet.Where(x => x.Ubicacion.ToUpper().Contains(texto.ToUpper()))
                .Take(10)
                .ToList();

            return list;
        }

        public GenericFilterResponse<Ubigeo> GetByFilter(GenericFilterRequest filter)
        {
            GenericFilterResponse<Ubigeo> res = new GenericFilterResponse<Ubigeo>();
            List<Ubigeo> ubigeos = new List<Ubigeo>();

            //es un algoritmo para construir querys dinamicos
            var query = db.Ubigeos.Where(x => x.Id == x.Id);

            filter.Filters.ForEach(item =>
            {

                if (!string.IsNullOrEmpty(item.value))
                {
                    switch (item.name)
                    {
                        case "id":
                            query = query.Where(x => x.Id == int.Parse(item.value));
                            break;
                        case "departamento":

                            query = query.Where(x => x.Departamento.ToLower()
                            .Contains(item.value.ToLower())
                            );
                            break;
                        case "provincia":

                            query = query.Where(x => x.Provincia.ToLower()
                            .Contains(item.value.ToLower())
                            );
                            break;
                        case "distrito":

                            query = query.Where(x => x.Distrito.ToLower()
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

        public List<Ubigeo> GetByName(string name)
        {

            List<Ubigeo> cats =
                    db.Ubigeos.
                        Where(x =>
                            x.Ubicacion.ToLower().Contains(name.ToLower())
                            ).ToList();
            return cats;
        }
    }
    

}


