using NHibernate;

namespace NHbDataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ITransaction _iTransaction;

        public void Dispose()
        {
            _iTransaction.Dispose();
        }

        public void Save()
        {
            _iTransaction.Commit();
        }

        public async void SaveAsync()
        {
            await _iTransaction.CommitAsync();
        }
    }
}
