using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeAPIAPP.Services
{
    public interface IRepo<K, T>
    {
        Task<T> Add(T item);
        Task<T> Get(K id);
        Task<T> Update(T item);
        Task<T> Delete(K id);
        Task<ICollection<T>> GetAll();
    }
}
