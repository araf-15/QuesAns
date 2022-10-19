using StackExchange.Redis;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace QuesAns.MemoryCashing
{
    public class MemoryCashing<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly IDatabase _database;

        public MemoryCashing(IDatabase database, string redisKey)
        {
            _database = database;
        }

        private string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        private TValue DeSerialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<TValue>(value);
        }

        public TValue this[TKey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<TKey> Keys => throw new NotImplementedException();

        public ICollection<TValue> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(TKey key, TValue value)
        {
            _database.HashSet(Serialize(key).ToString(), Serialize(key), Serialize(value));
        }

        public TValue GetCashedData(TKey key)
        {
            var value = _database.HashGet(Serialize(key).ToString(), Serialize(key)).ToString();
            return DeSerialize<TValue>(value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
