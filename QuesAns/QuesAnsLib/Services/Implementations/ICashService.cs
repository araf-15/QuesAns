using System;
using System.Collections.Generic;
using System.Text;

namespace QuesAnsLib.Services.Implementations
{
    public interface ICashService<TKey, TValue> : IDictionary<TKey, TValue>
    {
        public TValue GetCashedData(TKey key);
    }
}
