using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repository.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> GetEntityList();
        Task<T> GetEntity(long id);
        Task Create(T item);
        Task Update(T item);
        Task Delete(T item);
        Task Save();
    }
}
