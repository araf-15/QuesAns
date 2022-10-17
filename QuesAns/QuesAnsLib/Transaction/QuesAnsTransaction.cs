using NHibernate;
using NHibernate.Transaction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuesAnsLib.Transaction
{
    public class QuesAnsTransaction : ITransaction
    {
        public bool IsActive => throw new NotImplementedException();

        public bool WasRolledBack => throw new NotImplementedException();

        public bool WasCommitted => throw new NotImplementedException();

        public void Begin()
        {
            throw new NotImplementedException();
        }

        public void Begin(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public Task CommitAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Enlist(DbCommand command)
        {
            throw new NotImplementedException();
        }

        public void RegisterSynchronization(ISynchronization synchronization)
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
