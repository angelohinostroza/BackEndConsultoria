using DbConsultoriaModel.dbConsultoria;
using IRepository;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CRUDRepository<TEntity> where TEntity : class
    {
        #region DECLARACION DE VARIABLES
        internal _dbConsultoriaContext db;
        internal DbSet<TEntity> dbSet;
        #endregion DECLARACION DE VARIABLES

        #region CONSTRUCTOR
        public CRUDRepository()
        {
            try
            {
                db = new _dbConsultoriaContext();
                dbSet = db.Set<TEntity>();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion CONSTRUCTOR

        public TEntity Create(TEntity request)
        {
            try
            {

            }
            catch (Exception ex) 
            {
                throw;
            }
            dbSet.Add(request);
            db.SaveChanges();
            return request;
        }

        public bool Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            dbSet.Remove(entityToDelete);
            db.SaveChanges();
            return true;
        }

        public List <TEntity> GetAll() 
        {
            IQueryable<TEntity> query = dbSet;
            return query.ToList();
        }

        public TEntity GetById(object id) 
        {
            return dbSet.Find(id);
        }

        public TEntity Update(TEntity request)
        {
            dbSet.Update(request);
            int a = db.SaveChanges();
            return request;
        }

        public List<TEntity> CreateMultiple(List<TEntity> request) 
        {
            dbSet.AddRange(request);
            db.SaveChanges();
            return request;
        }

        public List<TEntity> UpdateMultiple(List<TEntity> request)
        {
            dbSet.UpdateRange(request);
            db.SaveChanges();
            return request;
        }

        public bool DeleteMultiple(object id)
        {
            return true;
        }
    }

}