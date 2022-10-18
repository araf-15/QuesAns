using NHbDataAccessLayer.Config;
using NHibernate;

namespace NHbDataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        protected ITransaction _iTransaction;
        public ISessionFactory _sessionFactory = null;

        public UnitOfWork()
        {
            var config = ConfigurationManager.SetConfiguration();
            _sessionFactory = config.BuildSessionFactory();
        }

        public void Dispose()
        {
            _iTransaction.Dispose();
        }

        public void Save()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (_iTransaction = session.BeginTransaction())
                {
                    _iTransaction.Commit();
                }
            }
        }

        public async void SaveAsync()
        {
            await _iTransaction.CommitAsync();
        }
    }
}
