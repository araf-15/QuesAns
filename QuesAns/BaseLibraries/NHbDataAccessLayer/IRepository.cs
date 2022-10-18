using System.Collections.Generic;

namespace NHbDataAccessLayer
{
    public interface IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        IList<TEntity> GetAll();
        public void Add(TEntity entity);
        TEntity GetById(TKey id);
        void Update(TEntity entity);
    }
}
