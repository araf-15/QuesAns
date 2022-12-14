using System.Collections.Generic;
using System.Threading.Tasks;

namespace NHbDataAccessLayer
{
    public interface IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        IList<TEntity> GetAll();
        public Task<object> Add(TEntity entity);
        TEntity GetById(TKey id);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
