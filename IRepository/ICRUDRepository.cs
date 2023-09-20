using RequestResponse;

namespace IRepository
{
    public interface ICRUDRepository<T> where T : class 
    {
        GenericFilterResponse<T> GetByFilter(GenericFilterRequest filters);
        List<T> GetAll();
        T GetById(object id);
        T Create(T request);
        T Update(T request);
        bool Delete(object id);

        List<T> CreateMultiple(List <T> request);
        List<T> UpdateMultiple(List<T> request);
        bool DeleteMultiple(object id);    
    }
}