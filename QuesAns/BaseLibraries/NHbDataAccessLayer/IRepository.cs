using System.Collections.Generic;

namespace NHbDataAccessLayer
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();
    }
}
