using NHbDataAccessLayer.Config;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace NHbDataAccessLayer
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {

        #region Configure
        public ISessionFactory _sessionFactory = null;

        public Repository()
        {
            var config = ConfigurationManager.SetConfiguration();
            _sessionFactory = config.BuildSessionFactory();
        }
        #endregion

        public void Add(TEntity entity)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                session.Save(entity);
                session.Flush();
            }
        }

        public IList<TEntity> GetAll()
        {
            var list = new List<TEntity>();

            using (var session = _sessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    list = session.Query<TEntity>().ToList();
                    tx.Commit();
                }
            }
            return list;
        }

        public TEntity GetById(TKey id)
        {
            var obj = new object();
            using (var session = _sessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    obj = session.Query<TEntity>().Where(c => c.Id.ToString() == id.ToString()).FirstOrDefault();
                }
            }
            return (TEntity)obj;
        }

        public void Update(TEntity entity)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                session.Update(entity);
                session.Flush();
            }
        }
    }
}
