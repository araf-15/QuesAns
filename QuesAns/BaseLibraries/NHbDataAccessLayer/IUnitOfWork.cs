using System;

namespace NHbDataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        void SaveAsync();
    }
}
