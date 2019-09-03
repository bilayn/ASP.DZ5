using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Repository
{
    interface IRepository<T> : IDisposable
    {
        T Get(int Id);
        IEnumerable<T> GetAll();
        void Remove(int Id);
        void UpdateOrCreate(T entity);
    }
}
