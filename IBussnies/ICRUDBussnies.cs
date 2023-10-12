using RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBussnies
{
    public interface ICRUDBussnies<T, Y>
    {
        //DONDE VAMOS A COMENZAR A HACER USO DE LOS DTO'S
        // DATA TRANSFER OBJET

        GenericFilterResponse<Y> GetByFilter(GenericFilterRequest filter);
        List<Y> GetAll();
        Y GetById(int id);
        Y Create(T request);
        Y Update(T request);
        bool Delete(object id);
        List<Y> CreateMultiple(List<T> request);
        List<Y> UpdateMultiple(List<T> request);
        bool DeleteMultiple(object id);

    }
}
