using NHbDataAccessLayer.Config;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace NHbDataAccessLayer
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        #region Configure
        public ISessionFactory _sessionFactory = null;

        public Repository()
        {
            var config = ConfigurationManager.SetConfiguration();
            _sessionFactory = config.BuildSessionFactory();
        }
        #endregion

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
    }
}
