using NHbDataAccessLayer.Config;
using NHibernate;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<object> Add(TEntity entity)
        {
            var obj = new object();
            using (var session = _sessionFactory.OpenSession())
            {
                obj = await session.SaveAsync(entity);
                await session.FlushAsync();
            }
            return obj;
        }

        

        public IList<TEntity> GetAll()
        {
            var list = new List<TEntity>();

            using (var session = _sessionFactory.OpenSession())
            {
                list = session.Query<TEntity>().ToList();

                //using (var tx = session.BeginTransaction())
                //{
                //    list = session.Query<TEntity>().ToList();
                //    tx.Commit();
                //}
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

        public void Delete(TEntity entity)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }
    }
}
