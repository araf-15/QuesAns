using System;

namespace DataAccessLayer
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
