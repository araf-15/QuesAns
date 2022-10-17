using System;
using System.Collections.Generic;
using System.Text;

namespace NHbDataAccessLayer
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
