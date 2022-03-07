using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Services
{
    public interface IRepo<K,T>
    {
        T Add(T item);
        T Get(K id);
        T Update(T item);
        T Delete(K id);
        ICollection<T> GetAll();
    }
}
